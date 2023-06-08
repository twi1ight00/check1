using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Theme;
using ns16;
using ns35;
using ns37;

namespace ns2;

internal class Class784
{
	private Class788 class788_0;

	private Class786 class786_0;

	private Class740 class740_0;

	private Class785 class785_0;

	private Chart chart_0;

	private Interface32 interface32_0;

	private Class783 class783_0;

	private Class783 class783_1;

	private Class783 class783_2;

	private Class783 class783_3;

	private Class783 class783_4;

	private IColorScheme icolorScheme_0;

	internal Class788 LegendRenderContext => class788_0;

	internal Class786 DataTableRenderContext => class786_0;

	internal Class785 ChartTitleRenderContext => class785_0;

	internal Class740 Chart2007 => class740_0;

	internal Chart Chart => chart_0;

	internal Interface32 Graphics => interface32_0;

	internal Class783 X1AxisRenderContext => class783_0;

	internal Class783 X2AxisRenderContext => class783_1;

	internal Class783 Y1AxisRenderContext => class783_2;

	internal Class783 Y2AxisRenderContext => class783_3;

	internal Class783 SeriesAxisRenderContext => class783_4;

	public Class784(Chart sourceChart, Interface32 g, Class740 chart2007)
	{
		chart_0 = sourceChart;
		class740_0 = chart2007;
		interface32_0 = g;
		class788_0 = new Class788((Legend)chart_0.Legend, this);
		class786_0 = new Class786((DataTable)chart_0.ChartDataTable, this);
		class785_0 = new Class785((ChartTitle)chart_0.ChartTitle, this);
		switch (ChartTypeCharacterizer.smethod_0((sourceChart.ChartData.SeriesGroups.Count > 0) ? sourceChart.ChartData.SeriesGroups[0].Series[0].Type : sourceChart.Type))
		{
		default:
			throw new Exception();
		case Enum169.const_0:
			class783_0 = new Class783(null, this, Enum160.const_0);
			class783_2 = new Class783(null, this, Enum160.const_2);
			class783_1 = new Class783(null, this, Enum160.const_1);
			class783_3 = new Class783(null, this, Enum160.const_3);
			break;
		case Enum169.const_3:
			class783_0 = new Class783((Axis)sourceChart.Axes.VerticalAxis, this, Enum160.const_0);
			class783_2 = new Class783((Axis)sourceChart.Axes.HorizontalAxis, this, Enum160.const_2);
			class783_1 = new Class783((Axis)sourceChart.Axes.SecondaryVerticalAxis, this, Enum160.const_1);
			class783_3 = new Class783((Axis)sourceChart.Axes.SecondaryHorizontalAxis, this, Enum160.const_3);
			break;
		case Enum169.const_1:
		case Enum169.const_2:
		case Enum169.const_4:
		case Enum169.const_5:
			class783_0 = new Class783((Axis)sourceChart.Axes.HorizontalAxis, this, Enum160.const_0);
			class783_2 = new Class783((Axis)sourceChart.Axes.VerticalAxis, this, Enum160.const_2);
			class783_1 = new Class783((Axis)sourceChart.Axes.SecondaryHorizontalAxis, this, Enum160.const_1);
			class783_3 = new Class783((Axis)sourceChart.Axes.SecondaryVerticalAxis, this, Enum160.const_3);
			break;
		}
		class783_4 = new Class783((Axis)sourceChart.Axes.SeriesAxis, this, Enum160.const_4);
		if (Chart.Axes.VerticalAxis != null && Chart.Axes.HorizontalAxis != null && ((Axis)Chart.Axes.VerticalAxis).CrossBetween == Enum268.const_2)
		{
			class783_0.AxisBetweenCategories = false;
		}
	}

	internal Color method_0(ColorSchemeIndex colorSchemeIndex)
	{
		if (Chart.PPTXUnsupportedProps.ColorMappingOverride.On && Chart.ThemeManager.IsOverrideThemeEnabled)
		{
			IColorScheme colorScheme = Chart.ThemeManager.OverrideTheme.ColorScheme;
			return colorScheme[colorSchemeIndex].Color;
		}
		IColorSchemeEffectiveData colorScheme2 = ((ISlideComponent)Chart).Slide.CreateThemeEffective().GetColorScheme(Color.Empty);
		return colorScheme2[colorSchemeIndex];
	}

	internal void method_1()
	{
		_ = Chart2007.ActualChartSize;
		int num = (int)Chart.LineFormat.Width;
		RectangleF rect;
		if (num <= 1)
		{
			float width = Chart2007.Width - 1;
			float height = Chart2007.Height - 1;
			rect = new RectangleF(0f, 0f, width, height);
		}
		else
		{
			float width = Chart2007.Width;
			float height = Chart2007.Height;
			rect = new RectangleF((float)num / 2f, (float)num / 2f, width, height);
		}
		if (Chart2007.IsRectangularCornered)
		{
			method_2(rect.X, rect.Y, rect.Width, rect.Height, 13f);
		}
		else
		{
			Struct44.smethod_2(Color.Empty, this, rect, (LineFormat)chart_0.LineFormat, (FillFormat)chart_0.FillFormat);
		}
	}

	private void method_2(float X, float Y, float width, float height, float radius)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(X + radius, Y, X + width - radius * 2f, Y);
		graphicsPath.AddArc(X + width - radius * 2f, Y, radius * 2f, radius * 2f, 270f, 90f);
		graphicsPath.AddLine(X + width, Y + radius, X + width, Y + height - radius * 2f);
		graphicsPath.AddArc(X + width - radius * 2f, Y + height - radius * 2f, radius * 2f, radius * 2f, 0f, 90f);
		graphicsPath.AddLine(X + width - radius * 2f, Y + height, X + radius, Y + height);
		graphicsPath.AddArc(X, Y + height - radius * 2f, radius * 2f, radius * 2f, 90f, 90f);
		graphicsPath.AddLine(X, Y + height - radius * 2f, X, Y + radius);
		graphicsPath.AddArc(X, Y, radius * 2f, radius * 2f, 180f, 90f);
		graphicsPath.CloseFigure();
		Struct44.smethod_3(Color.Empty, this, graphicsPath, (LineFormat)chart_0.LineFormat, (FillFormat)chart_0.FillFormat);
	}
}
