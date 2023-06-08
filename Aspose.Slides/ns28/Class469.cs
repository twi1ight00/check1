using System.Drawing;
using Aspose.Slides;
using ns4;

namespace ns28;

internal class Class469
{
	private FillType fillType_0 = FillType.NotDefined;

	private Color color_0 = Color.Empty;

	private PictureFillFormat pictureFillFormat_0;

	private GradientFormat gradientFormat_0;

	private PatternFormat patternFormat_0;

	internal PatternFormat PatternFormat => patternFormat_0;

	internal GradientFormat GradientFormat => gradientFormat_0;

	internal PictureFillFormat PictureFillFormat => pictureFillFormat_0;

	internal Color FillColor => color_0;

	internal FillType FillType => fillType_0;

	public Class469(IFillParamSource[] fills)
	{
		foreach (IFillParamSource fillprop in fills)
		{
			method_0(fillprop);
		}
	}

	internal Class469(FillFormat fillFormat)
	{
		method_0(fillFormat);
	}

	internal Class469(IFillParamSource fillPck)
	{
		method_0(fillPck);
	}

	internal Class469()
	{
	}

	internal void method_0(IFillParamSource fillprop)
	{
		if (fillprop == null)
		{
			return;
		}
		if (fillprop is FillFormat)
		{
			FillFormat fillFormat = (FillFormat)fillprop;
			switch (fillFormat.fillType_0)
			{
			case FillType.NoFill:
				fillType_0 = FillType.NoFill;
				break;
			case FillType.Solid:
				fillType_0 = FillType.Solid;
				color_0 = fillFormat.SolidFillColor.Color;
				break;
			case FillType.Gradient:
				fillType_0 = FillType.Gradient;
				gradientFormat_0 = (GradientFormat)fillFormat.GradientFormat;
				break;
			case FillType.Pattern:
				fillType_0 = FillType.Pattern;
				patternFormat_0 = (PatternFormat)fillFormat.PatternFormat;
				break;
			case FillType.Picture:
				fillType_0 = FillType.Picture;
				pictureFillFormat_0 = (PictureFillFormat)fillFormat.PictureFillFormat;
				break;
			}
		}
		if (fillprop is LineFillFormat)
		{
			LineFillFormat lineFillFormat = (LineFillFormat)fillprop;
			switch (lineFillFormat.fillType_0)
			{
			case FillType.NoFill:
				fillType_0 = FillType.NoFill;
				break;
			case FillType.Solid:
				fillType_0 = FillType.Solid;
				color_0 = lineFillFormat.colorFormat_0.Color;
				break;
			}
		}
		else if (fillprop is Class493)
		{
			Class493 @class = (Class493)fillprop;
			method_0(@class.ifillFormat_0);
			if (@class.floatColor_0 != null)
			{
				color_0 = @class.floatColor_0.Color;
			}
		}
	}

	internal void method_1(Class470 fillProp, BaseSlide slide, Class476 odpPackage, FloatColor styleColor)
	{
		switch (FillType)
		{
		case FillType.NotDefined:
		case FillType.NoFill:
			fillProp.FillStyle = Enum36.const_0;
			break;
		case FillType.Solid:
			fillProp.FillStyle = Enum36.const_1;
			fillProp.FillColor = FillColor;
			break;
		case FillType.Gradient:
			fillProp.FillStyle = Enum36.const_3;
			GradientFormat.method_4(fillProp, slide, odpPackage);
			break;
		case FillType.Pattern:
			fillProp.FillStyle = Enum36.const_2;
			PatternFormat.method_3(fillProp, odpPackage, styleColor);
			break;
		case FillType.Picture:
			fillProp.FillStyle = Enum36.const_2;
			PictureFillFormat.method_4(fillProp, slide, odpPackage);
			break;
		}
	}
}
