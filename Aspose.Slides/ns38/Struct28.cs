using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using Aspose.Slides.Charts;
using ns2;
using ns33;
using ns35;
using ns36;
using ns37;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct28
{
	internal static int int_0 = 3;

	internal static SizeF smethod_0(Interface32 g, Class757 nSeries, int seriesIndex, int chartPointIndex, int scaleWidth, Class784 renderContext, Class783 axisXRenderContext)
	{
		Class759 @class = nSeries.method_0(seriesIndex);
		Class740 chart = @class.Chart;
		Class748 class2 = @class.PointsInternal.method_0(chartPointIndex);
		Class750 dataLabelsInternal = class2.DataLabelsInternal;
		if (!dataLabelsInternal.IsShown)
		{
			return new SizeF(0f, 0f);
		}
		bool flag = false;
		List<Interface8> list;
		List<Interface8> list2;
		if (axisXRenderContext.AxisType == Enum160.const_0)
		{
			flag = chart.NSeriesInternal.bool_0;
			list = chart.NSeriesInternal.CategoryLabelsInternal;
			list2 = list;
		}
		else
		{
			flag = chart.NSeriesInternal.bool_1;
			list = chart.NSeriesInternal.Category2LabelsInternal;
			list2 = list;
			if ((renderContext.X2AxisRenderContext.Axis == null || !renderContext.X2AxisRenderContext.Axis.IsVisible) && flag)
			{
				list2 = chart.NSeriesInternal.OriginalCategory2Labels;
			}
		}
		string format = dataLabelsInternal.Format;
		bool isCulture = dataLabelsInternal.IsCulture;
		bool linkedSource = dataLabelsInternal.LinkedSource;
		string name = @class.Name;
		string text = "";
		if (smethod_10(@class.ResembleType))
		{
			object xValueOriginal = class2.XValueOriginal;
			text = smethod_5(xValueOriginal, format, isCulture);
			if (linkedSource)
			{
				text = smethod_5(xValueOriginal, class2.XFormat, class2.XValueIsCulture);
			}
		}
		else if (flag)
		{
			string text2 = ((chartPointIndex < list.Count) ? ((Class743)list2[chartPointIndex]).SourceFormat : "");
			bool flag2 = chartPointIndex < list.Count && ((Class743)list2[chartPointIndex]).IsCulture;
			if (linkedSource)
			{
				format = text2;
				isCulture = flag2;
			}
			if (chartPointIndex < list.Count)
			{
				object labelValue = ((Class743)list[chartPointIndex]).LabelValue;
				int num = Struct24.smethod_52(labelValue, chart.IsDate1904);
				object labelValue2 = ((Class743)list2[chartPointIndex]).LabelValue;
				text = ((num != -1) ? smethod_5(labelValue2, format, isCulture) : "");
			}
			else
			{
				text = "";
			}
		}
		else
		{
			text = ((chartPointIndex >= axisXRenderContext.arrayList_0.Count) ? "" : smethod_5(axisXRenderContext.arrayList_0[chartPointIndex], format, isCulture));
		}
		Class783 class3 = Struct21.smethod_43(renderContext, axisXRenderContext);
		double yValue = class2.YValue;
		yValue = (class3.Axis.IsLogarithmic ? class3.method_1(yValue) : yValue);
		yValue = (class3.Axis.IsLogarithmic ? yValue : (yValue * Math.Pow(10.0, (double)class3.Axis.DisplayUnit)));
		string text3 = smethod_5(yValue, format, isCulture);
		if (linkedSource)
		{
			text3 = smethod_5(yValue, class2.YFormat, class2.YValueIsCulture);
		}
		string text4 = smethod_5(class2.BubbleSizeValue, format, isCulture);
		if (linkedSource)
		{
			text4 = smethod_5(class2.BubbleSizeValue, class2.BubbleSizeFormat, class2.BubbleSizeIsCulture);
		}
		string text5 = smethod_3(dataLabelsInternal.Separator);
		Font textFont = dataLabelsInternal.ChartFrameInternal.TextFont;
		int rotation = dataLabelsInternal.Rotation;
		Enum157 textHorizontalAlignment = dataLabelsInternal.TextHorizontalAlignment;
		Enum157 textVerticalAlignment = dataLabelsInternal.TextVerticalAlignment;
		SizeF sizeF = new SizeF(0f, 0f);
		if (dataLabelsInternal.IsLegendKeyShown)
		{
			sizeF = Struct31.smethod_3(g, renderContext);
		}
		string text6 = "";
		if (dataLabelsInternal.Text == null)
		{
			if (dataLabelsInternal.IsSeriesNameShown)
			{
				text6 += name;
			}
			if (dataLabelsInternal.IsCategoryNameShown)
			{
				if (text6 != "")
				{
					text6 += text5;
				}
				text6 += text;
			}
			if (dataLabelsInternal.IsValueShown)
			{
				if (text6 != "")
				{
					text6 += text5;
				}
				text6 += text3;
			}
			if (dataLabelsInternal.IsBubbleSizeShown)
			{
				if (text6 != "")
				{
					text6 += text5;
				}
				text6 += text4;
			}
		}
		else
		{
			text6 = dataLabelsInternal.Text;
		}
		SizeF layoutArea = new SizeF(scaleWidth, (float)chart.Position.Height * 0.5f);
		Size size = Struct39.smethod_3(g, text6, rotation, textFont, layoutArea, textHorizontalAlignment, textVerticalAlignment);
		if (text6 == "")
		{
			return new SizeF(0f, 0f);
		}
		if (dataLabelsInternal.IsLegendKeyShown)
		{
			return new SizeF((float)size.Width + sizeF.Width, size.Height);
		}
		return new SizeF(size.Width, size.Height);
	}

	internal static void smethod_1(Interface32 g, Class757 nSeries, int seriesIndex, int chartPointIndex, Rectangle rect, Class784 renderContext, Class783 axisXRenderContext)
	{
		RectangleF rect2 = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
		smethod_2(g, nSeries, seriesIndex, chartPointIndex, rect2, renderContext, axisXRenderContext);
	}

	internal static void smethod_2(Interface32 g, Class757 nSeries, int seriesIndex, int chartPointIndex, RectangleF rect, Class784 renderContext, Class783 axisXRenderContext)
	{
		Class759 @class = nSeries.method_0(seriesIndex);
		Class740 chart = @class.Chart;
		Class748 class2 = @class.PointsInternal.method_0(chartPointIndex);
		Class750 dataLabelsInternal = class2.DataLabelsInternal;
		if (!dataLabelsInternal.IsShown || (dataLabelsInternal.ChartFrameInternal.IsXAuto && (rect.X < 0f || rect.Right > (float)chart.Width)) || (dataLabelsInternal.ChartFrameInternal.IsYAuto && (rect.Y < 0f || rect.Bottom > (float)chart.Height)))
		{
			return;
		}
		chart.method_2(ref rect);
		bool flag = false;
		List<Interface8> list;
		List<Interface8> list2;
		if (axisXRenderContext.AxisType == Enum160.const_0)
		{
			flag = chart.NSeriesInternal.bool_0;
			list = chart.NSeriesInternal.CategoryLabelsInternal;
			list2 = list;
		}
		else
		{
			flag = chart.NSeriesInternal.bool_1;
			list = chart.NSeriesInternal.Category2LabelsInternal;
			list2 = list;
			if ((renderContext.X2AxisRenderContext.Axis == null || !renderContext.X2AxisRenderContext.Axis.IsVisible) && flag)
			{
				list2 = chart.NSeriesInternal.OriginalCategory2Labels;
			}
		}
		string format = dataLabelsInternal.Format;
		bool isCulture = dataLabelsInternal.IsCulture;
		bool linkedSource = dataLabelsInternal.LinkedSource;
		string name = @class.Name;
		string text = "";
		bool flag2 = false;
		if (smethod_10(@class.ResembleType))
		{
			object xValueOriginal = class2.XValueOriginal;
			text = smethod_5(xValueOriginal, format, isCulture);
			if (linkedSource)
			{
				text = smethod_5(xValueOriginal, class2.XFormat, class2.XValueIsCulture);
				flag2 = smethod_7(xValueOriginal, class2.XFormat);
			}
		}
		else if (flag)
		{
			string text2 = ((chartPointIndex < list.Count) ? ((Class743)list2[chartPointIndex]).SourceFormat : "");
			bool flag3 = chartPointIndex < list.Count && ((Class743)list2[chartPointIndex]).IsCulture;
			if (linkedSource)
			{
				format = text2;
				isCulture = flag3;
			}
			if (chartPointIndex < list.Count)
			{
				object labelValue = ((Class743)list[chartPointIndex]).LabelValue;
				int num = Struct24.smethod_52(labelValue, chart.IsDate1904);
				object labelValue2 = ((Class743)list2[chartPointIndex]).LabelValue;
				text = ((num != -1) ? smethod_5(labelValue2, format, isCulture) : "");
				if (linkedSource)
				{
					flag2 = smethod_7(labelValue, format);
				}
			}
			else
			{
				text = "";
			}
		}
		else
		{
			text = ((chartPointIndex >= axisXRenderContext.arrayList_0.Count) ? "" : smethod_5(axisXRenderContext.arrayList_0[chartPointIndex], format, isCulture));
			if (chartPointIndex < axisXRenderContext.arrayList_0.Count && linkedSource)
			{
				flag2 = smethod_7(axisXRenderContext.arrayList_0[chartPointIndex], format);
			}
		}
		Class783 class3 = Struct21.smethod_43(renderContext, axisXRenderContext);
		double yValue = class2.YValue;
		yValue = (class3.Axis.IsLogarithmic ? class3.method_1(yValue) : yValue);
		yValue = (class3.Axis.IsLogarithmic ? yValue : (yValue * Math.Pow(10.0, (double)class3.Axis.DisplayUnit)));
		string text3 = smethod_5(yValue, format, isCulture);
		bool flag4 = false;
		if (linkedSource)
		{
			text3 = smethod_5(yValue, class2.YFormat, class2.YValueIsCulture);
			flag4 = smethod_7(yValue, class2.YFormat);
		}
		string text4 = smethod_5(class2.BubbleSizeValue, format, isCulture);
		if (linkedSource)
		{
			text4 = smethod_5(text4, class2.BubbleSizeFormat, class2.BubbleSizeIsCulture);
		}
		string text5 = smethod_3(dataLabelsInternal.Separator);
		Font textFont = dataLabelsInternal.ChartFrameInternal.TextFont;
		Color fontColor = dataLabelsInternal.ChartFrameInternal.FontColor;
		int rotation = dataLabelsInternal.Rotation;
		Enum157 textHorizontalAlignment = dataLabelsInternal.TextHorizontalAlignment;
		Enum157 textVerticalAlignment = dataLabelsInternal.TextVerticalAlignment;
		SizeF sizeF = Struct31.smethod_3(g, renderContext);
		int num2 = (int)rect.X;
		int num3 = (int)rect.Y;
		int num4 = (int)rect.Width;
		int num5 = (int)rect.Height;
		int x = (dataLabelsInternal.IsLegendKeyShown ? (num2 - int_0) : num2);
		int y = num3 - int_0;
		int width = (dataLabelsInternal.IsLegendKeyShown ? (num4 + 2 * int_0) : num4);
		int height = num5 + 2 * int_0;
		dataLabelsInternal.ChartFrameInternal.rectangle_1 = new Rectangle(x, y, width, height);
		dataLabelsInternal.ChartFrameInternal.method_17();
		if (dataLabelsInternal.IsLegendKeyShown)
		{
			RectangleF rect2 = new RectangleF(rect.X, rect.Y, sizeF.Width, sizeF.Height);
			Struct31.smethod_5(g, rect2, @class);
			num2 += (int)sizeF.Width;
			num4 -= (int)sizeF.Width;
		}
		string text6 = "";
		if (dataLabelsInternal.Text == null)
		{
			if (dataLabelsInternal.IsSeriesNameShown)
			{
				text6 += name;
			}
			if (dataLabelsInternal.IsCategoryNameShown)
			{
				if (text6 != "")
				{
					text6 += text5;
				}
				text6 += text;
			}
			if (dataLabelsInternal.IsValueShown)
			{
				if (text6 != "")
				{
					text6 += text5;
				}
				text6 += text3;
			}
			if (dataLabelsInternal.IsBubbleSizeShown)
			{
				if (text6 != "")
				{
					text6 += text5;
				}
				text6 += text4;
			}
		}
		else
		{
			text6 = dataLabelsInternal.Text;
		}
		Rectangle rect3 = new Rectangle(num2, num3, num4, num5);
		if (flag2 || flag4)
		{
			fontColor = Color.Red;
		}
		TextRenderingHint textRenderingHint = chart.Graphics.TextRenderingHint;
		if (chart.ChartAreaInternal.AreaInternal.IsTransparent && dataLabelsInternal.ChartFrameInternal.AreaInternal.IsTransparent)
		{
			chart.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
		}
		smethod_12(g, dataLabelsInternal, rect3, text6, rotation, textFont, fontColor, textHorizontalAlignment, textVerticalAlignment);
		if (chart.ChartAreaInternal.AreaInternal.IsTransparent && dataLabelsInternal.ChartFrameInternal.AreaInternal.IsTransparent)
		{
			chart.Graphics.TextRenderingHint = textRenderingHint;
		}
	}

	internal static string smethod_3(Enum153 separator)
	{
		string result = "";
		switch (separator)
		{
		case Enum153.const_1:
			result = " ";
			break;
		case Enum153.const_0:
		case Enum153.const_2:
			result = ", ";
			break;
		case Enum153.const_3:
			result = "; ";
			break;
		case Enum153.const_4:
			result = ". ";
			break;
		case Enum153.const_5:
			result = "\n";
			break;
		}
		return result;
	}

	internal static string smethod_4(Class750 dataLabels)
	{
		Enum153 separator = dataLabels.Separator;
		string result = "";
		switch (separator)
		{
		case Enum153.const_0:
			result = ((!dataLabels.IsCategoryNameShown || !dataLabels.IsPercentageShown || dataLabels.IsSeriesNameShown || dataLabels.IsValueShown) ? ", " : "\n");
			break;
		case Enum153.const_1:
			result = " ";
			break;
		case Enum153.const_2:
			result = ", ";
			break;
		case Enum153.const_3:
			result = "; ";
			break;
		case Enum153.const_4:
			result = ". ";
			break;
		case Enum153.const_5:
			result = "\n";
			break;
		}
		return result;
	}

	internal static string smethod_5(object obj, string format, bool isCulture)
	{
		if (obj == null)
		{
			return "";
		}
		if (format == null && obj != null)
		{
			return obj.ToString();
		}
		string text = "";
		TypeCode typeCode = Type.GetTypeCode(obj.GetType());
		try
		{
			if (smethod_8(format) && (typeCode == TypeCode.Double || typeCode == TypeCode.Int32))
			{
				switch (typeCode)
				{
				case TypeCode.Double:
				{
					double doubleValue = (double)obj;
					DateTime dateTime = smethod_9(doubleValue);
					return Struct43.smethod_0(dateTime, format, isCulture);
				}
				case TypeCode.Int32:
				{
					double doubleValue = (int)obj;
					DateTime dateTime = smethod_9(doubleValue);
					return Struct43.smethod_0(dateTime, format, isCulture);
				}
				}
			}
			return Struct43.smethod_0(obj, format, isCulture: false);
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
			return obj.ToString();
		}
	}

	internal static Color smethod_6(object val, string format, Color color)
	{
		if (format != null && !(format == ""))
		{
			TypeCode typeCode = Type.GetTypeCode(val.GetType());
			if ((typeCode == TypeCode.Double || typeCode == TypeCode.Int32) && format.ToLower().IndexOf("[red]") > 0)
			{
				if (!((double)val < 0.0))
				{
					return color;
				}
				return Color.Red;
			}
			return color;
		}
		return color;
	}

	internal static bool smethod_7(object val, string format)
	{
		if (format != null && !(format == ""))
		{
			TypeCode typeCode = Type.GetTypeCode(val.GetType());
			if ((typeCode == TypeCode.Double || typeCode == TypeCode.Int32) && format.ToLower().IndexOf("[red]") > 0 && (double)val < 0.0)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private static bool smethod_8(string format)
	{
		string[] array = new string[32]
		{
			"MMM", "DD", "YYYY", "M/", "/M", "/D", "D/", "/Y", "Y/", "-M",
			"M-", "-D", "D-", "-Y", "Y-", "MM/DD", "DD/MM", "M/D", "D/M", "MM-DD",
			"DD-MM", "M-D", "D-M", "H:MM", "MM:SS", "Дк", "ФВ", "ИХ", "К±", "·Ц",
			"Гл", "MM"
		};
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				if (format.IndexOf(array[num]) != -1 || format.ToUpper().IndexOf(array[num]) != -1)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private static DateTime smethod_9(double doubleValue)
	{
		DateTime dateTime = new DateTime(1899, 12, 30, 0, 0, 1);
		if (doubleValue < 0.0)
		{
			return dateTime;
		}
		if (doubleValue > 2958465.99)
		{
			return new DateTime(9999, 12, 31, 23, 59, 59);
		}
		if (doubleValue < 60.0)
		{
			doubleValue += 1.0;
		}
		return dateTime + TimeSpan.FromDays(doubleValue);
	}

	internal static bool smethod_10(ChartType chartType)
	{
		if (chartType != ChartType.ScatterWithMarkers && chartType != ChartType.Bubble)
		{
			return false;
		}
		return true;
	}

	internal static LegendDataLabelPosition smethod_11(ChartType seriesType)
	{
		switch (seriesType)
		{
		case ChartType.Pie:
		case ChartType.Pie3D:
		case ChartType.PieOfPie:
		case ChartType.ExplodedPie:
		case ChartType.ExplodedPie3D:
		case ChartType.BarOfPie:
			return LegendDataLabelPosition.BestFit;
		case ChartType.ClusteredColumn:
		case ChartType.ClusteredColumn3D:
		case ChartType.Column3D:
		case ChartType.ClusteredCylinder:
		case ChartType.Cylinder3D:
		case ChartType.ClusteredCone:
		case ChartType.Cone3D:
		case ChartType.ClusteredPyramid:
		case ChartType.Pyramid3D:
		case ChartType.ClusteredBar3D:
		case ChartType.ClusteredBar:
		case ChartType.ClusteredHorizontalCylinder:
		case ChartType.ClusteredHorizontalCone:
		case ChartType.ClusteredHorizontalPyramid:
			return LegendDataLabelPosition.OutsideEnd;
		default:
			return LegendDataLabelPosition.Center;
		case ChartType.StackedColumn:
		case ChartType.PercentsStackedColumn:
		case ChartType.StackedColumn3D:
		case ChartType.PercentsStackedColumn3D:
		case ChartType.StackedCylinder:
		case ChartType.PercentsStackedCylinder:
		case ChartType.StackedCone:
		case ChartType.PercentsStackedCone:
		case ChartType.StackedPyramid:
		case ChartType.PercentsStackedPyramid:
		case ChartType.PercentsStackedBar:
		case ChartType.StackedBar:
		case ChartType.StackedBar3D:
		case ChartType.PercentsStackedBar3D:
		case ChartType.StackedHorizontalCylinder:
		case ChartType.PercentsStackedHorizontalCylinder:
		case ChartType.StackedHorizontalCone:
		case ChartType.PercentsStackedHorizontalCone:
		case ChartType.StackedHorizontalPyramid:
		case ChartType.PercentsStackedHorizontalPyramid:
		case ChartType.Area:
		case ChartType.StackedArea:
		case ChartType.PercentsStackedArea:
		case ChartType.Area3D:
		case ChartType.StackedArea3D:
		case ChartType.PercentsStackedArea3D:
		case ChartType.Doughnut:
		case ChartType.ExplodedDoughnut:
			return LegendDataLabelPosition.Center;
		case ChartType.Line:
		case ChartType.StackedLine:
		case ChartType.PercentsStackedLine:
		case ChartType.LineWithMarkers:
		case ChartType.StackedLineWithMarkers:
		case ChartType.PercentsStackedLineWithMarkers:
		case ChartType.Line3D:
		case ChartType.ScatterWithMarkers:
		case ChartType.ScatterWithSmoothLinesAndMarkers:
		case ChartType.ScatterWithSmoothLines:
		case ChartType.ScatterWithStraightLinesAndMarkers:
		case ChartType.ScatterWithStraightLines:
		case ChartType.Bubble:
		case ChartType.BubbleWith3D:
			return LegendDataLabelPosition.Right;
		}
	}

	public static void smethod_12(Interface32 g, Class750 dataLabels, Rectangle rect, string text, int rotation, Font font, Color fontColor, Enum157 horizontalAlignment, Enum157 verticalAlignment)
	{
		bool flag = false;
		TextRenderingHint textRenderingHint = g.TextRenderingHint;
		if (dataLabels.ChartFrameInternal.Chart.ChartAreaInternal.AreaInternal.IsTransparent && dataLabels.ChartFrameInternal.AreaInternal.IsTransparent)
		{
			flag = true;
			g.TextRenderingHint = TextRenderingHint.AntiAlias;
		}
		StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
		stringFormat.Alignment = Struct39.smethod_18(horizontalAlignment);
		stringFormat.LineAlignment = Struct39.smethod_18(verticalAlignment);
		switch (Math.Abs(rotation))
		{
		default:
		{
			double num = Math.Sqrt(Math.Pow(rect.Width, 2.0) + Math.Pow(rect.Height, 2.0));
			stringFormat.FormatFlags = StringFormatFlags.NoWrap;
			SizeF sizeF = g.imethod_110(text, font, (int)num, stringFormat);
			g.imethod_132(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
			g.imethod_115(-rotation);
			g.imethod_61(layoutRectangle: new RectangleF((0f - sizeF.Width) / 2f, (0f - sizeF.Height) / 2f, sizeF.Width, sizeF.Height), s: text, font: font, brush: new SolidBrush(fontColor), format: stringFormat);
			g.ResetTransform();
			break;
		}
		case 90:
			g.imethod_132(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
			g.imethod_115(-rotation);
			rect = new Rectangle(-rect.Height / 2, -rect.Width / 2, rect.Height, rect.Width);
			g.imethod_62(text, font, new SolidBrush(fontColor), rect, stringFormat);
			g.ResetTransform();
			break;
		case 0:
			g.imethod_62(text, font, new SolidBrush(fontColor), rect, stringFormat);
			break;
		}
		if (flag)
		{
			g.TextRenderingHint = textRenderingHint;
		}
	}
}
