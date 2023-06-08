using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns2;
using ns35;
using ns36;
using ns37;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct26
{
	internal static void smethod_0(Interface32 g, int x, int y, int width, bool primaryAxisIsDisplayAxisSameAsBar, Class784 renderContext)
	{
		Class740 chart = renderContext.Chart2007;
		if (!renderContext.Chart.HasDataTable || chart.PlotAreaInternal.method_16())
		{
			return;
		}
		DataTable dataTable = (DataTable)renderContext.Chart.ChartDataTable;
		int num = Struct39.smethod_10(g, "a", renderContext.DataTableRenderContext.Font).Width * renderContext.X1AxisRenderContext.TickLabelsOffset / 300;
		TextRenderingHint textRenderingHint = chart.Graphics.TextRenderingHint;
		if (chart.ChartAreaInternal.AreaInternal.IsTransparent)
		{
			chart.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
		}
		Size legendSize = renderContext.DataTableRenderContext.LegendSize;
		int height = legendSize.Height + renderContext.DataTableRenderContext.CategoryLabelHeight;
		SizeF sizeF = Struct31.smethod_3(g, renderContext);
		List<Class787> list = Struct31.smethod_26(isVertical: true, primaryAxisIsDisplayAxisSameAsBar, renderContext.DataTableRenderContext.LegendEntries, chart, renderContext);
		Rectangle rectangle = new Rectangle(x, y, width, height);
		Rectangle rectangle2 = new Rectangle(x - legendSize.Width, y + renderContext.DataTableRenderContext.CategoryLabelHeight, width + legendSize.Width, legendSize.Height);
		if (dataTable.HasBorderOutline)
		{
			Struct44.smethod_1(renderContext.DataTableRenderContext.color_1, renderContext, rectangle, (Format)dataTable.Format);
			Struct44.smethod_1(renderContext.DataTableRenderContext.color_1, renderContext, rectangle2, (Format)dataTable.Format);
		}
		float num2 = (float)legendSize.Height / (float)list.Count;
		if (dataTable.HasBorderHorizontal)
		{
			for (int i = 1; i < list.Count; i++)
			{
				float x2 = rectangle2.Left;
				float num3 = (float)rectangle2.Top + (float)i * num2;
				float x3 = rectangle2.Right;
				float y2 = num3;
				Struct44.smethod_0(new PointF(x2, num3), new PointF(x3, y2), renderContext.DataTableRenderContext.color_1, (LineFormat)dataTable.Format.Line, renderContext);
			}
		}
		int num4 = chart.NSeriesInternal.method_1();
		Font font = renderContext.DataTableRenderContext.Font;
		Brush brush = new SolidBrush(renderContext.DataTableRenderContext.FontColor);
		float num5 = (float)width / (float)num4;
		bool flag = false;
		List<Interface8> categoryLabelsInternal = chart.NSeriesInternal.CategoryLabelsInternal;
		List<Interface8>[] categories = chart.NSeriesInternal.Categories;
		if (renderContext.X1AxisRenderContext.IsLinkedSource && categoryLabelsInternal.Count > 0)
		{
			flag = true;
		}
		if (categories != null && categories.Length > 0 && categoryLabelsInternal.Count > 0)
		{
			flag = true;
		}
		for (int j = 0; j < num4; j++)
		{
			if (dataTable.HasBorderVertical)
			{
				float x2 = (float)x + num5 * (float)j;
				float num3 = rectangle.Top;
				float x3 = x2;
				float y2 = num3 + (float)renderContext.DataTableRenderContext.FirstRowCategoryLabelHeight;
				Struct44.smethod_0(new PointF(x2, num3), new PointF(x3, y2), renderContext.DataTableRenderContext.color_1, (LineFormat)dataTable.Format.Line, renderContext);
			}
			int num6 = j;
			if (renderContext.X1AxisRenderContext.Axis.IsPlotOrderReversed)
			{
				num6 = num4 - j - 1;
			}
			string s = "";
			if (num6 <= chart.NSeriesInternal.CategoryLabelsInternal.Count - 1)
			{
				Class743 @class = (Class743)categoryLabelsInternal[num6];
				if (!flag)
				{
					s = Struct21.smethod_34(@class.LabelValue, renderContext.X1AxisRenderContext);
				}
				else
				{
					string text = "";
					bool flag2 = false;
					text = ((num6 < categoryLabelsInternal.Count) ? @class.SourceFormat : "");
					flag2 = num6 < categoryLabelsInternal.Count && @class.IsCulture;
					s = Struct28.smethod_5(@class.LabelValue, text, flag2);
				}
			}
			RectangleF layoutRectangle = new RectangleF((float)x + (float)j * num5, y + num, num5, renderContext.DataTableRenderContext.FirstRowCategoryLabelHeight - num);
			StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
			stringFormat.LineAlignment = StringAlignment.Near;
			stringFormat.Alignment = StringAlignment.Center;
			g.imethod_61(s, font, brush, layoutRectangle, stringFormat);
		}
		if (categories != null && categories.Length > 0 && chart.NSeriesInternal.CategoryLabelsInternal.Count > 0)
		{
			Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
			float xLableOffset = num;
			float lineStartY = y;
			bool isPlus = false;
			float labelY = rectangle2.Top;
			float num7 = 0f;
			num7 = (renderContext.X1AxisRenderContext.Axis.IsPlotOrderReversed ? ((float)rectangle.Right) : ((float)rectangle.Left));
			smethod_1(g, categories, num7, labelY, xLableOffset, isPlus, num5, Enum157.const_1, lineStartY, rectangle, isDisplayAxisSameAsBar: false, x1AxisRenderContext, renderContext);
		}
		for (int k = 0; k < list.Count; k++)
		{
			Class787 class2 = list[k];
			Class759 series = class2.Series;
			float num8 = (float)rectangle2.Top + (float)k * num2;
			float num9 = 0f;
			if (dataTable.ShowLegendKey)
			{
				RectangleF rect = new RectangleF(rectangle2.Left + Struct31.int_0, num8, sizeF.Width, num2);
				Struct31.smethod_24(g, rect, class2, renderContext);
				num9 = sizeF.Width + (float)Struct31.int_0;
			}
			string name = series.Name;
			SizeF sizeF2 = Struct39.smethod_14(g, name, font);
			PointF point = new PointF((float)(x - legendSize.Width) + num9, num8 + num2 / 2f - sizeF2.Height / 2f);
			g.imethod_57(name, font, brush, point);
			for (int l = 0; l < series.PointsInternal.Count; l++)
			{
				if (dataTable.HasBorderVertical && l < series.PointsInternal.Count - 1)
				{
					float x2 = (float)x + (float)(l + 1) * num5;
					float num3 = num8;
					float x3 = x2;
					float y2 = num8 + num2;
					Struct44.smethod_0(new PointF(x2, num3), new PointF(x3, y2), renderContext.DataTableRenderContext.color_1, (LineFormat)dataTable.Format.Line, renderContext);
				}
				int index = l;
				if (renderContext.X1AxisRenderContext.Axis.IsPlotOrderReversed)
				{
					index = series.PointsInternal.Count - l - 1;
				}
				Class748 class3 = series.PointsInternal.method_0(index);
				if (!class3.NotPlotted && (class3.YValueOriginal == null || !class3.YValueOriginal.ToString().Equals("#N/A")))
				{
					string yFormat = class3.YFormat;
					bool yValueIsCulture = class3.YValueIsCulture;
					name = Struct28.smethod_5(class3.YValue, yFormat, yValueIsCulture);
					sizeF2 = Struct39.smethod_14(g, name, font);
					point = new PointF((float)x + (float)l * num5 + num5 / 2f - sizeF2.Width / 2f, num8 + num2 / 2f - sizeF2.Height / 2f);
					g.imethod_60(name, font, brush, point, new StringFormat(StringFormat.GenericTypographic));
				}
			}
		}
		if (chart.ChartAreaInternal.AreaInternal.IsTransparent)
		{
			chart.Graphics.TextRenderingHint = textRenderingHint;
		}
	}

	private static void smethod_1(Interface32 g, List<Interface8>[] categoryList, float labelX, float labelY, float xLableOffset, bool isPlus, double unitWidth, Enum157 vAlign, float lineStartY, Rectangle plotAreaRect, bool isDisplayAxisSameAsBar, Class783 axisRenderContext, Class784 renderContext)
	{
		int rotation = 0;
		float num = labelY;
		IDataTable chartDataTable = renderContext.Chart.ChartDataTable;
		Class786 dataTableRenderContext = renderContext.DataTableRenderContext;
		SizeF layoutArea = new SizeF((float)unitWidth, (float)plotAreaRect.Height / 2f);
		foreach (IList list in categoryList)
		{
			Size size = smethod_2(g, list, rotation, dataTableRenderContext, layoutArea);
			float num2 = labelX;
			for (int j = 0; j < list.Count; j++)
			{
				Class743 @class = (Class743)list[j];
				string text = Struct28.smethod_5(@class.LabelValue, @class.SourceFormat, @class.IsCulture);
				int num3 = Struct21.smethod_39(@class);
				float num4 = (float)((double)num3 * unitWidth);
				float x = (axisRenderContext.Axis.IsPlotOrderReversed ? (num2 - num4 / 2f - (float)(size.Width / 2)) : (num2 + num4 / 2f - (float)(size.Width / 2)));
				float y = (isPlus ? num : (num - (float)size.Height));
				RectangleF value = new RectangleF(x, y, size.Width, size.Height);
				Struct21.smethod_45(g, Rectangle.Round(value), text, rotation, dataTableRenderContext.Font, dataTableRenderContext.FontColor, Enum157.const_1, vAlign);
				if (renderContext.Chart.ChartDataTable.HasBorderVertical)
				{
					Struct44.smethod_0(new PointF(num2, lineStartY), new PointF(num2, num), renderContext.DataTableRenderContext.color_1, (LineFormat)chartDataTable.Format.Line, renderContext);
					float num5 = num;
					num5 = (isPlus ? (num + (xLableOffset + (float)size.Height)) : (num - (xLableOffset + (float)size.Height)));
					smethod_3(@class.Children, num2, lineStartY, num5, isPlus, unitWidth, axisRenderContext, renderContext);
				}
				num2 = (axisRenderContext.Axis.IsPlotOrderReversed ? (num2 - num4) : (num2 + num4));
			}
			if (chartDataTable.HasBorderVertical)
			{
				Struct44.smethod_0(new PointF(num2, lineStartY), new PointF(num2, num), renderContext.DataTableRenderContext.color_1, (LineFormat)chartDataTable.Format.Line, renderContext);
			}
			num = ((!isPlus) ? (num - (xLableOffset + (float)size.Height)) : (num + (xLableOffset + (float)size.Height)));
		}
	}

	internal static Size smethod_2(Interface32 g, IList categoryList, int rotation, Class786 dataTableRenderContext, SizeF layoutArea)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < categoryList.Count; i++)
		{
			Class743 @class = (Class743)categoryList[i];
			string text = Struct28.smethod_5(@class.LabelValue, @class.SourceFormat, @class.IsCulture);
			Size size = Struct39.smethod_3(g, text, rotation, dataTableRenderContext.Font, layoutArea, Enum157.const_1, Enum157.const_1);
			if (size.Width > num)
			{
				num = size.Width;
			}
			if (size.Height > num2)
			{
				num2 = size.Height;
			}
		}
		return new Size(num, num2);
	}

	private static void smethod_3(Interface7 categoryLabelList, float startX, float startY, float endY, bool isPlus, double unitWidth, Class783 axisRenderContext, Class784 chartRenderContext)
	{
		float num = startX;
		for (int i = 0; i < categoryLabelList.Count; i++)
		{
			Class743 categoryLabel = (Class743)categoryLabelList[i];
			int num2 = Struct21.smethod_39(categoryLabel);
			float num3 = (float)((double)num2 * unitWidth);
			num = (axisRenderContext.Axis.IsPlotOrderReversed ? (num - num3) : (num + num3));
			Struct44.smethod_0(new PointF(num, startY), new PointF(num, endY), chartRenderContext.DataTableRenderContext.color_1, (LineFormat)chartRenderContext.Chart.ChartDataTable.Format.Line, chartRenderContext);
		}
	}

	internal static Size smethod_4(Interface32 g, Class784 renderContext)
	{
		DataTable dataTable = (DataTable)renderContext.Chart.ChartDataTable;
		SizeF sizeF = smethod_5(g, renderContext);
		int num;
		if (dataTable.ShowLegendKey)
		{
			num = (int)(Struct31.smethod_3(g, renderContext).Width + sizeF.Width) + Struct31.int_0 + 1;
		}
		else
		{
			num = (int)sizeF.Width + 1;
			if (sizeF.Width == 0f)
			{
				num += Struct31.int_0;
			}
		}
		int num2 = ((sizeF.Height != 0f) ? ((int)((double)sizeF.Height + 0.5) + 1 + Struct31.int_0) : ((int)((double)g.imethod_105("A", renderContext.DataTableRenderContext.Font).Height + 0.5) + 1 + Struct31.int_0));
		if (num > renderContext.Chart2007.Width)
		{
			num = renderContext.Chart2007.Width;
		}
		if (num > renderContext.Chart2007.ChartAreaInternal.Width - 2 * Struct24.int_0)
		{
			num = renderContext.Chart2007.ChartAreaInternal.Width - 2 * Struct24.int_0;
		}
		return new Size(num, num2 * renderContext.Chart2007.NSeries.Count);
	}

	private static SizeF smethod_5(Interface32 g, Class784 renderContext)
	{
		Class757 nSeriesInternal = renderContext.Chart2007.NSeriesInternal;
		SizeF result = new SizeF(0f, 0f);
		for (int i = 0; i < nSeriesInternal.Count; i++)
		{
			Class759 @class = nSeriesInternal.method_0(i);
			SizeF sizeF = g.imethod_105(@class.Name, renderContext.DataTableRenderContext.Font);
			if (result.Width < sizeF.Width)
			{
				result.Width = sizeF.Width;
			}
			if (result.Height < sizeF.Height)
			{
				result.Height = sizeF.Height;
			}
		}
		return result;
	}

	internal static int smethod_6(Interface32 g, Rectangle plotRect, Class784 renderContext)
	{
		Class786 dataTableRenderContext = renderContext.DataTableRenderContext;
		int num = Struct39.smethod_10(g, "a", dataTableRenderContext.Font).Width * renderContext.X1AxisRenderContext.TickLabelsOffset / 300;
		int num2 = 0;
		num2 = 0 + num;
		Font font = dataTableRenderContext.Font;
		Class740 chart = renderContext.Chart2007;
		List<Interface8> categoryLabelsInternal = chart.NSeriesInternal.CategoryLabelsInternal;
		List<Interface8>[] categories = chart.NSeriesInternal.Categories;
		float width = ((renderContext.X1AxisRenderContext.Axis != null) ? ((float)plotRect.Width / (float)renderContext.X1AxisRenderContext.arrayList_0.Count) : ((float)categoryLabelsInternal.Count));
		SizeF layoutArea = new SizeF(width, (float)plotRect.Height / 2f);
		Size size = new Size(0, 0);
		if (categoryLabelsInternal.Count > 0)
		{
			for (int i = 0; i < categoryLabelsInternal.Count; i++)
			{
				Class743 @class = (Class743)categoryLabelsInternal[i];
				string text = Struct28.smethod_5(@class.LabelValue, @class.SourceFormat, @class.IsCulture);
				Size size2 = Struct39.smethod_4(g, text, 0, font, layoutArea, Enum157.const_1, Enum157.const_1, isTabelShown: true);
				if (size2.Width > size.Width)
				{
					size.Width = size2.Width;
				}
				if (size2.Height > size.Height)
				{
					size.Height = size2.Height;
				}
			}
		}
		else
		{
			size = Struct39.smethod_3(g, "123", 0, font, layoutArea, Enum157.const_1, Enum157.const_1);
		}
		num2 = (dataTableRenderContext.FirstRowCategoryLabelHeight = num2 + size.Height);
		int num4 = 0;
		if (categories != null && categories.Length > 0 && categoryLabelsInternal.Count > 0)
		{
			num2 += num * categories.Length;
			foreach (IList categoryList in categories)
			{
				num4 += smethod_2(g, categoryList, 0, dataTableRenderContext, layoutArea).Height;
			}
		}
		return num2 + num4;
	}
}
