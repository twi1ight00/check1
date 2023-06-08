using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns35;
using ns36;
using ns38;

namespace ns2;

internal class Class785
{
	private string string_0;

	private Font font_0;

	private Color color_0;

	internal Rectangle rectangle_0;

	private float float_0;

	private bool bool_0;

	public bool IsTransparent => bool_0;

	public string Text => string_0;

	public Font TextFont => font_0;

	public Color FontColor => color_0;

	public float Rotation
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	internal Class785(ChartTitle title, Class784 chartRenderContext)
	{
		Chart chart = (Chart)title.Chart;
		TextFrame textFrame = (TextFrame)title.TextFrameForOverriding;
		float_0 = ((TextFrameFormat)title.TextFormatManager.TextFormatOfAutoText.TextBlockFormat).RotationAngle;
		if (float.IsNaN(float_0) && textFrame != null)
		{
			float_0 = ((TextFrameFormat)textFrame.TextFrameFormat).PPTXUnsupportedProps.RotationAngle;
		}
		float_0 = (float.IsNaN(float_0) ? float_0 : (float_0 * -1f));
		if (textFrame == null && (chart.ChartData.Series.Count == 1 || chart.Type == ChartType.Pie))
		{
			if (chart.ChartData.Series[0].Name.ToString() != null)
			{
				string_0 = chart.ChartData.Series[0].Name.ToString();
			}
		}
		else
		{
			string_0 = ((textFrame == null || !(textFrame.Text != "")) ? "Chart Title" : textFrame.TextInternal.Replace("\r", Environment.NewLine));
		}
		if (chart.Style + 1 > StyleType.Style41)
		{
			color_0 = chartRenderContext.method_0(ColorSchemeIndex.Light1);
		}
		else
		{
			color_0 = chartRenderContext.method_0(ColorSchemeIndex.Dark1);
		}
		color_0 = chart.method_14(title.TextFormatManager, textFrame, color_0, chartRenderContext.Chart2007);
		font_0 = chart.method_15(title.TextFormatManager, textFrame, isBold: true, isTitle: true);
		switch (title.Format.Fill.FillType)
		{
		case FillType.NoFill:
			bool_0 = true;
			break;
		case FillType.Solid:
		{
			Color color;
			if (title.Format.Fill.SolidFillColor.SchemeColor != SchemeColor.NotDefined)
			{
				ColorFormat colorFormat = ((Slide)chart.Slide).method_2(title.Format.Fill.SolidFillColor.SchemeColor);
				((ColorOperationCollection)colorFormat.ColorTransform).list_0 = ((ColorOperationCollection)title.Format.Fill.SolidFillColor.ColorTransform).list_0;
				color = colorFormat.Color;
			}
			else
			{
				color = title.Format.Fill.SolidFillColor.Color;
			}
			if (color.A <= 250)
			{
				bool_0 = true;
			}
			break;
		}
		}
	}

	internal Size method_0(SizeF layoutArea, Interface32 g)
	{
		return Struct39.smethod_3(g, Text, (!float.IsNaN(float_0)) ? ((int)float_0) : 0, TextFont, layoutArea, Enum157.const_1, Enum157.const_1);
	}
}
