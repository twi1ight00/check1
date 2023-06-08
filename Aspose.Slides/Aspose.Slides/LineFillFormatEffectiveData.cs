using System.Drawing;

namespace Aspose.Slides;

public class LineFillFormatEffectiveData : IFillParamSource, ILineFillFormatEffectiveData, IEffectiveData
{
	internal FillType fillType_0 = FillType.NotDefined;

	internal Color color_0;

	internal GradientFormatEffectiveData gradientFormatEffectiveData_0;

	internal PatternFormatEffectiveData patternFormatEffectiveData_0;

	internal bool bool_0;

	public FillType FillType => fillType_0;

	public Color SolidFillColor => color_0;

	public IGradientFormatEffectiveData GradientFormat => gradientFormatEffectiveData_0;

	public IPatternFormatEffectiveData PatternFormat => patternFormatEffectiveData_0;

	public bool RotateWithShape => bool_0;

	IFillParamSource ILineFillFormatEffectiveData.AsIFillParamSource => this;

	internal LineFillFormatEffectiveData()
	{
		gradientFormatEffectiveData_0 = new GradientFormatEffectiveData();
		patternFormatEffectiveData_0 = new PatternFormatEffectiveData();
		bool_0 = false;
	}

	internal LineFillFormatEffectiveData(LineFillFormat format)
		: this()
	{
		method_1(format, ((ISlideComponent)format).Slide, new FloatColor(0f, 0f, 0f));
	}

	internal LineFillFormatEffectiveData(LineFillFormat format, BaseSlide slide, FloatColor styleColor)
		: this()
	{
		method_1(format, slide, styleColor);
	}

	internal void method_0(LineFillFormat source, BaseSlide slide, FloatColor styleColor)
	{
		if (source != null)
		{
			if (source.fillType_0 != FillType.NotDefined)
			{
				fillType_0 = source.fillType_0;
			}
			if (source.colorFormat_0 != null)
			{
				color_0 = source.colorFormat_0.method_5(slide, styleColor);
			}
			if (source.gradientFormat_0 != null)
			{
				gradientFormatEffectiveData_0 = new GradientFormatEffectiveData(source.gradientFormat_0, slide, styleColor);
			}
			if (source.patternFormat_0 != null)
			{
				patternFormatEffectiveData_0 = new PatternFormatEffectiveData(source.patternFormat_0, slide, styleColor);
			}
			if (source.nullableBool_0 != NullableBool.NotDefined)
			{
				bool_0 = source.nullableBool_0 == NullableBool.True;
			}
		}
	}

	internal void method_1(LineFillFormat source, IBaseSlide slide, FloatColor styleColor)
	{
		if (source != null)
		{
			if (source.fillType_0 != FillType.NotDefined)
			{
				fillType_0 = source.fillType_0;
			}
			if (source.colorFormat_0 != null)
			{
				color_0 = source.colorFormat_0.method_5(slide, styleColor);
			}
			if (source.gradientFormat_0 != null)
			{
				gradientFormatEffectiveData_0 = new GradientFormatEffectiveData(source.gradientFormat_0, slide, styleColor);
			}
			if (source.patternFormat_0 != null)
			{
				patternFormatEffectiveData_0 = new PatternFormatEffectiveData(source.patternFormat_0, slide, styleColor);
			}
			if (source.nullableBool_0 != NullableBool.NotDefined)
			{
				bool_0 = source.nullableBool_0 == NullableBool.True;
			}
		}
	}

	public override bool Equals(object obj)
	{
		if (!(obj is LineFillFormatEffectiveData lineFillFormatEffectiveData))
		{
			return false;
		}
		if (fillType_0 != lineFillFormatEffectiveData.fillType_0)
		{
			return false;
		}
		switch (fillType_0)
		{
		default:
			return true;
		case FillType.Solid:
			return color_0 == lineFillFormatEffectiveData.color_0;
		case FillType.Gradient:
			if (gradientFormatEffectiveData_0 == lineFillFormatEffectiveData.gradientFormatEffectiveData_0)
			{
				return bool_0 == lineFillFormatEffectiveData.bool_0;
			}
			return false;
		case FillType.Pattern:
			if (patternFormatEffectiveData_0 == lineFillFormatEffectiveData.patternFormatEffectiveData_0)
			{
				return bool_0 == lineFillFormatEffectiveData.bool_0;
			}
			return false;
		}
	}

	public override int GetHashCode()
	{
		return 23453;
	}
}
