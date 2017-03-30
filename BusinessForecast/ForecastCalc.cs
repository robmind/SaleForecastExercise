using System;
using System.Collections.Generic;

namespace BusinessForecast
{
	public class ForecastCalc
	{
		//ForecastReportByDate
		/// <summary>
		/// It take 3 parameters as Datetime, List of Datetime, List of value.
		/// And, return the estimated value in linear time.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="xValues"></param>
		/// <param name="yValues"></param>
		/// <returns>double</returns>
		public double ForecastReportByDate(DateTime x, List<DateTime> xValues, List<double> yValues)
		{
			double x_Avg = 0f;
			double y_Avg = 0f;

			double forecast = 0f;
			double b = 0f;
			double a = 0f;

			double tempTop = 0f;
			double tempBottom = 0f;

			// X
			for (int i = 0; i < xValues.Count; i++)
			{
				x_Avg += i;
			}
			x_Avg /= xValues.Count;

			// Y
			foreach (var t in yValues)
				y_Avg += t;
			y_Avg /= yValues.Count;

			for (var i = 0; i < yValues.Count; i++)
			{
				tempTop += (i - x_Avg)*(yValues[i] - y_Avg);
				tempBottom += Math.Pow(i - x_Avg, 2f);
			}

			b = tempTop/tempBottom;
			a = y_Avg - b*x_Avg;

			forecast = a + b*(xValues.Count);

			return forecast;
		}

		//ForecastReportByValue
		/// <summary>
		/// It take 3 parameters as double, List of double, List of double.
		/// And, return the estimated value in linear time.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="xValues"></param>
		/// <param name="yValues"></param>
		/// <returns>double</returns>
		public double ForecastReportByValue(double x, List<double> xValues, List<double> yValues)
		{
			double x_Avg = 0f;
			double y_Avg = 0f;

			double forecast = 0f;
			double b = 0f;
			double a = 0f;

			double tempTop = 0f;
			double tempBottom = 0f;

			// X
			foreach (var t in xValues)
				x_Avg += t;
			x_Avg /= xValues.Count;

			// Y
			foreach (var t in yValues)
				y_Avg += t;
			y_Avg /= yValues.Count;

			for (var i = 0; i < yValues.Count; i++)
			{
				tempTop += (xValues[i] - x_Avg)*(yValues[i] - y_Avg);
				tempBottom += Math.Pow(xValues[i] - x_Avg, 2f);
			}

			b = tempTop/tempBottom;
			a = y_Avg - b*x_Avg;

			forecast = a + b*x;

			return forecast;
		}
	}
}
