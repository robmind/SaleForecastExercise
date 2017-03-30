using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessForecast
{
	class ForecastCalcTesting
	{
		public void ForecastReportByValue()
		{
			ForecastCalc forecastCalc = new ForecastCalc();
			List<double> xValues = new List<double>() { 2003, 2004, 2005, 2006, 2007, 2008 };
			List<double> yValues = new List<double>() { 227, 451, 438, 373, 357, 305 };
			double result = forecastCalc.ForecastReportByValue(2009, xValues, yValues);
			Console.WriteLine(result);
			//result: 362.80000000000018
		}
		public void ForecastReportByDate()
		{
			ForecastCalc _forecastCalc = new ForecastCalc();
			var x_Values = new List<DateTime>();
			x_Values.Add(new DateTime(2017, 1, 1));
			x_Values.Add(new DateTime(2017, 1, 2));
			x_Values.Add(new DateTime(2017, 1, 3));
			x_Values.Add(new DateTime(2017, 1, 4));
			x_Values.Add(new DateTime(2017, 1, 5));
			x_Values.Add(new DateTime(2017, 1, 6));
			x_Values.Add(new DateTime(2017, 1, 7));
			List<double> y_Values = new List<double>() { 9550, 2135, 7899, 2235, 7887, 1112, 5654 };
			double result = _forecastCalc.ForecastReportByDate(new DateTime(2017, 1, 8), x_Values, y_Values);
			Console.WriteLine(result);
			//result: 3246.5714285714294
		}
	}
}
