using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using BusinessForecast;
using ServiceObjects;
using BusinessObjects;
using Newtonsoft.Json;

namespace SalesForecastApp
{
	class Program
	{
		static void Main(string[] args)
		{
			#region Initial Json product service
			//Initial Json product service
			//Deserialize Json Objects in this function
			ProductService grabbingProcess = new ProductService();
			List<Product> jsonGrabbingProcess = grabbingProcess.JsonGrabbingProcess();
			#endregion

			#region Question 1.

			//Identify a pattern on any set of fields that can help predict how much a customer will spend.
			//If I answer this question, I chose this answer;
			//For "BUFFET" product, 
			//i* how much total was paid as Money
			//ii* how much was consumed As KG 
			//Maybe, here too many questions can be asked. Which was ordered more than the desk. Which days was consumed more, etc.

			double spendForBuffet = 0; //As Money
			double eatForBuffet = 0; //As KG

			foreach (var productCol in jsonGrabbingProcess)
			{
				foreach (var detCol in productCol.Dets)
				{
					if (detCol.Prod.XProd == "BUFFET")
					{
						spendForBuffet += detCol.Prod.VProd;
						eatForBuffet += detCol.Prod.QCom;
					}
				}
			}

			Console.WriteLine("**Identify a pattern on any set of fields that can help predict how much a customer will spend.");
			Console.WriteLine("Total BUFFET Product");
			Console.WriteLine("As Money: "+ spendForBuffet + " - As KG: " + eatForBuffet);
			//As Money: 75523.52 - As KG: 1101.014 

			#endregion

			Console.WriteLine("");

			#region Question 2.
			//Calculate a sales forecast for the next week.

			//Step 1. Create TotalProductList list
			//Aim of this, obtain all sales information and include in the list
			List<TotalProductList> forecastTotalModel = new List<TotalProductList>();
			Console.WriteLine("**Calculate a sales forecast for the next week.");
			foreach (var productCol in jsonGrabbingProcess)
			{
				forecastTotalModel.Add(new TotalProductList()
				{
					DateTime = productCol.Ide.DhEmi.Date,
					ProdTotal = productCol.Complemento.ValorTotal
				});
			}

			//Step 2. Trying to do a query to an Enumerable<Datetime Of Sales Information> to group by week
			//For example, 
			// Week 1
			// Sale1  8/4/2013 120 (Name, Datetime, Sale Total)
			// Sale2  9/4/2013 221
			// Week 2
			// Sale3  16/4/2013 34
			// Sale4  18/4/2013 332
			// Week 3
			// Sale5  24/4/2013 255
			// Sale6  26/4/2013 221
			var weekGroups = forecastTotalModel
				.Select(p => new
				{
					Project = p,
					Year = p.DateTime.Year,
					Week = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear
						(p.DateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday),
					Sales = p.ProdTotal
				})
				.GroupBy(x => new { x.Year, x.Week })
				.Select((g, i) => new
				{
					WeekGroup = g,
					WeekNum = i + 1,
					Year = g.Key.Year,
					CalendarWeek = g.Key.Week
				});

			//Step 3. Create ForecastLinearSales list
			//Aim of this, obtain all enumerable<Datetime Of Sales Information> from Step2
			List<ForecastLinearSales> forecastLinearSalesModels = new List<ForecastLinearSales>();

			foreach (var projGroup in weekGroups)
			{
				double countTotalSales = 0;
				foreach (var proj in projGroup.WeekGroup)
				{
					countTotalSales += proj.Sales;
				}

				Console.WriteLine("Week " + projGroup.WeekNum + " total sales = " + countTotalSales + " " + projGroup.WeekGroup.FirstOrDefault().Project.DateTime + " " + " " + projGroup.WeekGroup.LastOrDefault().Project.DateTime);
				forecastLinearSalesModels.Add(new ForecastLinearSales()
				{
					Week = projGroup.WeekNum,
					Datetime = projGroup.WeekGroup.FirstOrDefault().Project.DateTime + " " + " " + projGroup.WeekGroup.LastOrDefault().Project.DateTime,
					ProdTotal = countTotalSales
				});
			}

			//Step 4. Calculate sale forecast by the weeks of Step3
			ForecastCalc forecastCalc = new ForecastCalc();
			List<double> xValues = new List<double>() {};
			List<double> yValues = new List<double>() {};
			foreach (var vColLinearSaleModel in forecastLinearSalesModels)
			{
				xValues.Add(vColLinearSaleModel.Week);
				yValues.Add(vColLinearSaleModel.ProdTotal);
			}
			//xValues -> week of datetime list
			//yValues -> it shows the total expenditures made during these weeks
			//ForecastReportByValue (next list value of xvalue, xvalue, yvalue)
			//xValues.Count + 1,,, mean that begin next value of list
			//such as, listOfA => [1,2,3,4,5], listOfB => [10,11,12,13,14]
			//listOfASize => [1,2,3,4,5] + 1 (for next value) 
			//[1,2,3,4,5] has 5 item. So size of list is 5. but, we want to learn next item, 5+1 is 6
			//Like, ForecastReportByValue (listOfASize, listOfA, listOfB) -> (6, [1,2,3,4,5], [10,11,12,13,14]) 
			double result = forecastCalc.ForecastReportByValue(xValues.Count + 1, xValues, yValues);
			Console.WriteLine("next week sales forecast: " +result);

			#endregion

			Console.ReadLine();
		}
	}
}