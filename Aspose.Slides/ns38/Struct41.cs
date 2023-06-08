using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using Aspose.Slides.Charts;
using ns16;
using ns2;
using ns221;
using ns35;
using ns36;
using ns37;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct41
{
	internal static int int_0 = 80;

	internal static int int_1 = 10;

	internal static int int_2 = 4;

	internal static int int_3 = 5;

	internal static float float_0 = 0.2f;

	internal static void smethod_0(Interface32 g, Class752 errorBar, ChartType chartType, Rectangle plotRect)
	{
		if (smethod_21(plotRect) || errorBar == null)
		{
			return;
		}
		for (int i = 0; i < errorBar.ilist_2.Count; i++)
		{
			Struct19 @struct = errorBar.ilist_2[i];
			PointF pointF_ = @struct.pointF_0;
			float num = @struct.float_0;
			float float_ = @struct.float_1;
			if (pointF_.IsEmpty || !errorBar.IsVisible)
			{
				continue;
			}
			int num2 = 3;
			bool flag = errorBar.YDirection;
			if (Struct24.smethod_8(chartType))
			{
				flag = false;
			}
			float num3 = pointF_.X;
			float num4 = pointF_.Y;
			if (flag)
			{
				if (num3 < (float)plotRect.Left || num3 > (float)plotRect.Right)
				{
					continue;
				}
				if (num4 < (float)plotRect.Top)
				{
					num4 = plotRect.Top;
				}
				if (num4 > (float)plotRect.Bottom)
				{
					num4 = plotRect.Bottom;
				}
				if (errorBar.DisplayType == ErrorBarType.Both || errorBar.DisplayType == ErrorBarType.Plus)
				{
					float x = pointF_.X;
					float num5 = pointF_.Y - float_;
					if (num5 < (float)plotRect.Top)
					{
						num5 = plotRect.Top;
					}
					if (num5 > (float)plotRect.Bottom)
					{
						num5 = plotRect.Bottom;
					}
					if (float_ != 0f)
					{
						errorBar.BorderInternal.method_3(num3, num4, x, num5);
					}
					if (errorBar.ShowMarkerTTop && pointF_.Y - float_ >= (float)plotRect.Top && pointF_.Y - float_ <= (float)plotRect.Bottom)
					{
						errorBar.BorderInternal.method_3(pointF_.X - (float)num2, pointF_.Y - float_, pointF_.X + (float)num2, pointF_.Y - float_);
					}
				}
				if (errorBar.DisplayType == ErrorBarType.Both || errorBar.DisplayType == ErrorBarType.Minus)
				{
					float x = pointF_.X;
					float num5 = pointF_.Y + num;
					if (num5 < (float)plotRect.Top)
					{
						num5 = plotRect.Top;
					}
					if (num5 > (float)plotRect.Bottom)
					{
						num5 = plotRect.Bottom;
					}
					if (num != 0f)
					{
						errorBar.BorderInternal.method_3(num3, num4, x, num5);
					}
					if (errorBar.ShowMarkerTTop && pointF_.Y + num >= (float)plotRect.Top && pointF_.Y + num <= (float)plotRect.Bottom)
					{
						errorBar.BorderInternal.method_3(pointF_.X - (float)num2, pointF_.Y + num, pointF_.X + (float)num2, pointF_.Y + num);
					}
				}
				continue;
			}
			if (num3 < (float)plotRect.Left)
			{
				num3 = plotRect.Left;
			}
			if (num3 > (float)plotRect.Right)
			{
				num3 = plotRect.Right;
			}
			if (num4 < (float)plotRect.Top || num4 > (float)plotRect.Bottom)
			{
				continue;
			}
			if (errorBar.DisplayType == ErrorBarType.Both || errorBar.DisplayType == ErrorBarType.Plus)
			{
				float x = pointF_.X + float_;
				float num5 = pointF_.Y;
				if (x < (float)plotRect.Left)
				{
					x = plotRect.Left;
				}
				if (x > (float)plotRect.Right)
				{
					x = plotRect.Right;
				}
				if (float_ != 0f)
				{
					errorBar.BorderInternal.method_3(num3, num4, x, num5);
				}
				if (errorBar.ShowMarkerTTop && pointF_.X + float_ >= (float)plotRect.Left && pointF_.X + float_ <= (float)plotRect.Right)
				{
					errorBar.BorderInternal.method_3(pointF_.X + float_, pointF_.Y - (float)num2, pointF_.X + float_, pointF_.Y + (float)num2);
				}
			}
			if (errorBar.DisplayType == ErrorBarType.Both || errorBar.DisplayType == ErrorBarType.Minus)
			{
				float x = pointF_.X - num;
				float num5 = pointF_.Y;
				if (x < (float)plotRect.Left)
				{
					x = plotRect.Left;
				}
				if (x > (float)plotRect.Right)
				{
					x = plotRect.Right;
				}
				if (num != 0f)
				{
					errorBar.BorderInternal.method_3(num3, num4, x, num5);
				}
				if (errorBar.ShowMarkerTTop && pointF_.X - num >= (float)plotRect.Left && pointF_.X - num <= (float)plotRect.Right)
				{
					errorBar.BorderInternal.method_3(pointF_.X - num, pointF_.Y - (float)num2, pointF_.X - num, pointF_.Y + (float)num2);
				}
			}
		}
	}

	[Attribute7(true)]
	private static void smethod_1(Class757 series, int index)
	{
		for (int i = 0; i < series.Count; i++)
		{
			Class759 @class = series.method_0(i);
			Class747 pointsInternal = @class.PointsInternal;
			if (pointsInternal.Count - 1 > index)
			{
				pointsInternal.RemoveAt(index);
			}
		}
	}

	internal static void smethod_2(Class783 axisRenderContext, List<Interface8> categoryLabels, Class757 series)
	{
		if (axisRenderContext.Axis == null || axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType != Enum267.const_2 || categoryLabels.Count <= 0 || series.Count <= 0 || (axisRenderContext.Axis.IsAutomaticMaxValue && axisRenderContext.Axis.IsAutomaticMinValue))
		{
			return;
		}
		for (int i = 0; i < categoryLabels.Count; i++)
		{
			double num = Struct24.smethod_52(((Class743)categoryLabels[i]).LabelValue, axisRenderContext.ChartRenderContext.Chart2007.IsDate1904);
			if (!axisRenderContext.Axis.IsAutomaticMaxValue && num > axisRenderContext.MaxValue)
			{
				smethod_1(series, i);
				categoryLabels.RemoveAt(i);
				i--;
			}
			if (!axisRenderContext.Axis.IsAutomaticMinValue && num < axisRenderContext.MinValue)
			{
				smethod_1(series, i);
				categoryLabels.RemoveAt(i);
				i--;
			}
		}
	}

	private static void Remove(List<Interface8> categoryLabels, Class757 nSeries, ref int j, Class747 points, int allPointIndex, Class783 axisRenderContext)
	{
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		if (!axisRenderContext.Axis.IsAutomaticMaxValue)
		{
			double num;
			if (categoryLabels.Count > j)
			{
				num = Struct24.smethod_52(categoryLabels[j].LabelValue, chart.IsDate1904);
			}
			else
			{
				string text = "";
				text = ((axisRenderContext.Axis.BaseUnitScale == TimeUnitType.Days) ? "M/d/yy" : ((axisRenderContext.Axis.BaseUnitScale != TimeUnitType.Months) ? "yyyy" : "MMM-yy"));
				num = allPointIndex + 1;
				Class743 @class = new Class743(null, num);
				@class.SourceFormat = text;
				categoryLabels.Add(@class);
			}
			if (num > axisRenderContext.MaxValue)
			{
				points.RemoveAt(j);
				categoryLabels.RemoveAt(j);
				j--;
			}
		}
		if (!axisRenderContext.Axis.IsAutomaticMinValue)
		{
			double num2;
			if (categoryLabels.Count > j)
			{
				num2 = Struct24.smethod_52(((Class743)categoryLabels[j]).LabelValue, chart.IsDate1904);
			}
			else
			{
				string text2 = "";
				text2 = ((axisRenderContext.Axis.BaseUnitScale == TimeUnitType.Days) ? "M/d/yy" : ((axisRenderContext.Axis.BaseUnitScale != TimeUnitType.Months) ? "yyyy" : "MMM-yy"));
				num2 = allPointIndex + 1;
				Class743 class2 = new Class743(null, num2);
				class2.SourceFormat = text2;
				categoryLabels.Add(class2);
			}
			if (num2 < axisRenderContext.MinValue)
			{
				points.RemoveAt(j);
				categoryLabels.RemoveAt(j);
				j--;
			}
		}
	}

	internal static int smethod_3(double val)
	{
		return (int)Math.Ceiling(val);
	}

	internal static int smethod_4(double val)
	{
		return (int)Math.Floor(val);
	}

	internal static int smethod_5(double val)
	{
		return (int)(val + 0.5);
	}

	internal static bool smethod_6(PointF[] pointArray)
	{
		return true;
	}

	internal static void smethod_7(Interface32 g, float x, float y, Color c, int size)
	{
		g.imethod_88(new SolidBrush(c), x - (float)(size / 2), y - (float)(size / 2), size, size);
	}

	internal static void smethod_8(Class757 series, Class759 firstSeires, Class783 categoryAxisRenderContext, Class783 valueAxisRenderContext)
	{
		if (firstSeires.IsStatckedSeries || firstSeires.IsPercentSeries)
		{
			return;
		}
		if (categoryAxisRenderContext.Axis != null && categoryAxisRenderContext.Axis.IsLogarithmic && firstSeires.IsXValueSeries)
		{
			for (int i = 0; i < series.Count; i++)
			{
				for (int j = 0; j < series[i].Points.Count; j++)
				{
					Class748 @class = series.method_0(i).PointsInternal.method_0(j);
					if (@class != null)
					{
						if (@class.XValue > 0.0)
						{
							@class.XValue = Math.Log(@class.XValue, categoryAxisRenderContext.Axis.LogBase);
						}
						else
						{
							@class.NotPlotted = true;
						}
					}
				}
			}
		}
		if (valueAxisRenderContext.Axis == null || !valueAxisRenderContext.Axis.IsLogarithmic)
		{
			return;
		}
		for (int k = 0; k < series.Count; k++)
		{
			for (int l = 0; l < series[k].Points.Count; l++)
			{
				Class748 class2 = series.method_0(k).PointsInternal.method_0(l);
				if (class2 != null)
				{
					if (class2.YValue > 0.0)
					{
						class2.YValue = Math.Log(class2.YValue, valueAxisRenderContext.Axis.LogBase);
					}
					else
					{
						class2.NotPlotted = true;
					}
				}
			}
		}
	}

	internal static int smethod_9(double d)
	{
		char c = Convert.ToChar(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
		int num = 1;
		string text = "";
		string text2 = d.ToString();
		int num2 = text2.IndexOf("E");
		int num3 = text2.IndexOf("e");
		if (num2 > 0 || num3 > 0)
		{
			string[] array = ((num2 <= 0) ? text2.Split('e') : text2.Split('E'));
			if (array[0][0] == '-')
			{
				array[0] = array[0].Substring(1);
			}
			int num4 = array[0].IndexOf(c);
			int num5 = Math.Abs(Convert.ToInt32(array[1]));
			if (num4 > 0)
			{
				text = array[0].Substring(0, num4) + array[0].Substring(num4 + 1);
				if (array[1][0] == '-')
				{
					int num6 = num5 - (num4 - 1);
					if (num6 > 0)
					{
						while (num6 > 0)
						{
							text = "0" + text;
							num6--;
						}
						text = text[0].ToString() + c + text.Substring(1);
					}
					else if (num6 < 0)
					{
						text = text.Substring(0, num4 + num6) + c + text.Substring(num4 + num6);
					}
				}
				else
				{
					while (num5 > 0)
					{
						text += "0";
						num5--;
					}
				}
			}
			else
			{
				text = array[0];
				if (array[1][0] == '-')
				{
					int num7 = num5 - (text.Length - 1);
					if (num7 > 0)
					{
						while (num7 > 0)
						{
							text = "0" + text;
							num7--;
						}
						text = text[0].ToString() + c + text.Substring(1);
					}
					else if (num7 < 0)
					{
						text = text.Substring(0, text.Length + num7) + c + text.Substring(text.Length + num7);
					}
				}
				else
				{
					while (num5 > 0)
					{
						text += "0";
						num5--;
					}
				}
			}
			text2 = text;
		}
		int num8 = text2.IndexOf(c, 0);
		if (num8 > 0)
		{
			for (int i = num8 + 1; i < text2.Length; i++)
			{
				num++;
			}
		}
		if (num <= 15)
		{
			return num;
		}
		return 15;
	}

	internal static int smethod_10(params double[] list)
	{
		int num = 0;
		for (int i = 0; i < list.Length; i++)
		{
			int num2 = smethod_9(list[i]);
			if (num2 > num)
			{
				num = num2;
			}
		}
		return num;
	}

	internal static double smethod_11(double a, double b)
	{
		int num = smethod_9(a);
		int num2 = smethod_9(b);
		int digits = ((num > num2) ? num : num2);
		return Math.Round(a - b, digits);
	}

	internal static double smethod_12(double a, double b)
	{
		int num = smethod_9(a);
		int num2 = smethod_9(b);
		int num3 = ((num > num2) ? num : num2);
		if (num3 > 15)
		{
			num3 = 15;
		}
		if (num3 < 0)
		{
			num3 = 0;
		}
		return Math.Round(a + b, num3);
	}

	internal static int smethod_13(double d)
	{
		double num = Math.Log10(d);
		bool flag = true;
		if (num < 0.0)
		{
			flag = false;
		}
		num = Math.Abs(num);
		int num2 = smethod_4(num);
		if ((double)num2 != num)
		{
			num2++;
		}
		if (!flag)
		{
			num2 = -num2;
		}
		return num2;
	}

	internal static void smethod_14(Class740 chart, ref RectangleF rect)
	{
		if (rect.X < 0f)
		{
			rect.X = 0f;
		}
		if (rect.Right > (float)chart.Width)
		{
			rect.X = (float)chart.Width - rect.Width;
		}
		if (rect.Y < 0f)
		{
			rect.Y = 0f;
		}
		if (rect.Bottom > (float)chart.Height)
		{
			rect.Y = (float)chart.Height - rect.Height;
		}
	}

	internal static PointF[] smethod_15(ArrayList list)
	{
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] == null)
			{
				list.RemoveAt(i);
				i--;
			}
		}
		PointF[] array = new PointF[list.Count];
		for (int j = 0; j < list.Count; j++)
		{
			ref PointF reference = ref array[j];
			reference = (PointF)list[j];
		}
		return array;
	}

	internal static bool smethod_16(ref double pointVal, out double valTotal, IList displaySeries, int displayOrder, int pointIndex, double maxValue, double minValue)
	{
		valTotal = 0.0;
		if (pointVal >= 0.0)
		{
			if ((pointVal > 0.0 && maxValue <= 0.0) || (pointVal == 0.0 && maxValue < 0.0))
			{
				pointVal = 0.0;
				valTotal = 0.0;
				return false;
			}
			for (int i = 0; i < displayOrder; i++)
			{
				Class748 @class = ((Class759)displaySeries[i]).PointsInternal.method_0(pointIndex);
				if (@class == null)
				{
					continue;
				}
				double yValue = @class.YValue;
				if (yValue >= 0.0)
				{
					if (!(valTotal + yValue <= maxValue))
					{
						valTotal = maxValue;
						pointVal = 0.0;
						return false;
					}
					valTotal += yValue;
				}
			}
			if (pointVal + valTotal <= maxValue)
			{
				valTotal += pointVal;
			}
			else
			{
				pointVal = maxValue - valTotal;
				valTotal = maxValue;
			}
		}
		else
		{
			if ((pointVal < 0.0 && minValue >= 0.0) || (pointVal == 0.0 && minValue > 0.0))
			{
				pointVal = 0.0;
				valTotal = 0.0;
				return false;
			}
			for (int j = 0; j < displayOrder; j++)
			{
				Class748 class2 = ((Class759)displaySeries[j]).PointsInternal.method_0(pointIndex);
				if (class2 == null)
				{
					continue;
				}
				double yValue2 = class2.YValue;
				if (yValue2 < 0.0)
				{
					if (!(valTotal + yValue2 >= minValue))
					{
						valTotal = minValue;
						pointVal = 0.0;
						return false;
					}
					valTotal += yValue2;
				}
			}
			if (pointVal + valTotal >= minValue)
			{
				valTotal += pointVal;
			}
			else
			{
				pointVal = minValue - valTotal;
				valTotal = minValue;
			}
		}
		return true;
	}

	internal static double smethod_17(IList displaySeries, int pointIndex)
	{
		double num = 0.0;
		for (int i = 0; i < displaySeries.Count; i++)
		{
			Class748 @class = ((Class759)displaySeries[i]).PointsInternal.method_0(pointIndex);
			if (@class != null)
			{
				double yValue = @class.YValue;
				num += Math.Abs(yValue);
			}
		}
		return num;
	}

	internal static bool smethod_18(ref double pointVal, out double valTotal, IList displaySeries, int displayOrder, int pointIndex, double valTotalAll, Class783 axisRenderContext)
	{
		double maxValue = axisRenderContext.MaxValue * valTotalAll / 100.0;
		double minValue = axisRenderContext.MinValue * valTotalAll / 100.0;
		return smethod_16(ref pointVal, out valTotal, displaySeries, displayOrder, pointIndex, maxValue, minValue);
	}

	internal static float smethod_19(Class740 c, bool isBar)
	{
		SizeF sizeF = new SizeF(480f, 288f);
		float num = 250f;
		float num2 = num;
		if (isBar)
		{
			if ((float)c.Width > sizeF.Width)
			{
				num2 -= ((float)c.Width - sizeF.Width) / sizeF.Width * 100f;
			}
		}
		else if ((float)c.Height > sizeF.Height)
		{
			num2 -= ((float)c.Height - sizeF.Height) / sizeF.Height * 100f;
		}
		if (num2 < 100f)
		{
			num2 = 100f;
		}
		return num2;
	}

	internal static void smethod_20(ref Rectangle rect)
	{
		if (rect.Width > rect.Height)
		{
			rect.X += (rect.Width - rect.Height) / 2;
			rect.Width = rect.Height;
		}
		else if (rect.Height > rect.Width)
		{
			rect.Y += (rect.Height - rect.Width) / 2;
			rect.Height = rect.Width;
		}
	}

	internal static bool smethod_21(Rectangle rect)
	{
		if (rect.Width > 0 && rect.Height > 0)
		{
			return false;
		}
		return true;
	}

	internal static void smethod_22(ref Rectangle rect)
	{
		if (rect.Width < 0)
		{
			rect.Width = 0;
		}
		if (rect.Height < 0)
		{
			rect.Height = 0;
		}
	}

	internal static RectangleF smethod_23(Rectangle rect)
	{
		return new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
	}

	internal static SizeF smethod_24(Size size)
	{
		return new SizeF(size.Width, size.Height);
	}

	internal static Size smethod_25(Size src)
	{
		return new Size(src.Width, src.Height);
	}

	internal static SizeF smethod_26(SizeF src)
	{
		return new SizeF(src.Width, src.Height);
	}

	internal static RectangleF smethod_27(RectangleF src)
	{
		return new RectangleF(src.X, src.Y, src.Width, src.Height);
	}

	internal static Rectangle smethod_28(Rectangle src)
	{
		return new Rectangle(src.X, src.Y, src.Width, src.Height);
	}

	internal static DateTime smethod_29(double doubleValue, bool date1904)
	{
		if (doubleValue > 2958465.99)
		{
			return DateTime.MaxValue;
		}
		if (date1904)
		{
			doubleValue += 1462.0;
		}
		if (doubleValue < 60.0)
		{
			doubleValue += 1.0;
		}
		return DateTime.FromOADate(doubleValue);
	}

	internal static double smethod_30(DateTime dateTime, bool date1904)
	{
		if (date1904)
		{
			double totalDays = (dateTime - new DateTime(1904, 1, 1)).TotalDays;
			if (totalDays < 0.0)
			{
				return -1.0;
			}
			return totalDays;
		}
		DateTime dateTime2 = new DateTime(1900, 3, 1);
		DateTime dateTime3 = ((!((dateTime - dateTime2).TotalDays > 0.0)) ? new DateTime(1899, 12, 31) : new DateTime(1899, 12, 30));
		DateTime dateTime4 = new DateTime(9999, 12, 31, 23, 59, 59, 999);
		if ((dateTime4 - dateTime).TotalDays < 0.0)
		{
			return -1.0;
		}
		TimeSpan timeSpan = dateTime - dateTime3;
		if (timeSpan.TotalDays < 0.0)
		{
			return -1.0;
		}
		double num = timeSpan.TotalDays;
		if (dateTime.Year == 1900 && dateTime.Month == 3 && dateTime.Day == 1)
		{
			num += 1.0;
		}
		return num;
	}
}
