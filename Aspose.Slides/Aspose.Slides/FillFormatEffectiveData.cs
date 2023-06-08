using System.Drawing;

namespace Aspose.Slides;

public class FillFormatEffectiveData : IFillFormatEffectiveData, IEffectiveData
{
	internal FillType fillType_0 = FillType.NotDefined;

	internal Color color_0;

	internal GradientFormatEffectiveData gradientFormatEffectiveData_0;

	internal PictureFillFormatEffectiveData pictureFillFormatEffectiveData_0;

	internal PatternFormatEffectiveData patternFormatEffectiveData_0;

	internal bool bool_0;

	public FillType FillType => fillType_0;

	public Color SolidFillColor => color_0;

	public IGradientFormatEffectiveData GradientFormat => gradientFormatEffectiveData_0;

	public IPatternFormatEffectiveData PatternFormat => patternFormatEffectiveData_0;

	public IPictureFillFormatEffectiveData PictureFillFormat => pictureFillFormatEffectiveData_0;

	public bool RotateWithShape => bool_0;

	internal FillFormatEffectiveData()
	{
		gradientFormatEffectiveData_0 = new GradientFormatEffectiveData();
		pictureFillFormatEffectiveData_0 = new PictureFillFormatEffectiveData();
		patternFormatEffectiveData_0 = new PatternFormatEffectiveData();
		bool_0 = false;
	}

	internal FillFormatEffectiveData(IFillFormat format, BaseSlide slide, FloatColor styleColor)
		: this()
	{
		method_0(format, slide, styleColor);
	}

	internal void method_0(IFillFormat source, BaseSlide slide, FloatColor styleColor)
	{
		if (source == null)
		{
			fillType_0 = FillType.NotDefined;
			return;
		}
		FillType fillType = source.FillType;
		switch (fillType)
		{
		case FillType.Solid:
			color_0 = ((ColorFormat)source.SolidFillColor).method_5(slide, styleColor);
			break;
		case FillType.Gradient:
			gradientFormatEffectiveData_0.method_0((GradientFormat)source.GradientFormat, slide, styleColor);
			break;
		case FillType.Pattern:
			patternFormatEffectiveData_0.method_0((PatternFormat)source.PatternFormat, slide, styleColor);
			break;
		case FillType.Picture:
			pictureFillFormatEffectiveData_0.method_0((PictureFillFormat)source.PictureFillFormat, slide, styleColor);
			break;
		}
		fillType_0 = fillType;
		if (source.RotateWithShape != NullableBool.NotDefined)
		{
			bool_0 = source.RotateWithShape == NullableBool.True;
		}
	}

	internal void method_1(IFillFormat source, BaseSlide slide, FloatColor styleColor)
	{
		if (source == null || source.FillType == FillType.NotDefined)
		{
			return;
		}
		FillType fillType = source.FillType;
		switch (fillType)
		{
		case FillType.Solid:
			color_0 = ((ColorFormat)source.SolidFillColor).method_5(slide, styleColor);
			break;
		case FillType.Gradient:
			if (fillType_0 == fillType)
			{
				gradientFormatEffectiveData_0.method_1((GradientFormat)source.GradientFormat, slide, styleColor);
			}
			else
			{
				gradientFormatEffectiveData_0.method_0((GradientFormat)source.GradientFormat, slide, styleColor);
			}
			break;
		case FillType.Pattern:
			if (fillType_0 == fillType)
			{
				patternFormatEffectiveData_0.method_1((PatternFormat)source.PatternFormat, slide, styleColor);
			}
			else
			{
				patternFormatEffectiveData_0.method_0((PatternFormat)source.PatternFormat, slide, styleColor);
			}
			break;
		case FillType.Picture:
			pictureFillFormatEffectiveData_0.method_0((PictureFillFormat)source.PictureFillFormat, slide, styleColor);
			break;
		}
		fillType_0 = fillType;
		if (source.RotateWithShape != NullableBool.NotDefined)
		{
			bool_0 = source.RotateWithShape == NullableBool.True;
		}
	}

	public override bool Equals(object obj)
	{
		if (!(obj is FillFormatEffectiveData fillFormatEffectiveData))
		{
			return base.Equals(obj);
		}
		if (fillType_0 != fillFormatEffectiveData.fillType_0)
		{
			return false;
		}
		switch (fillType_0)
		{
		default:
			return true;
		case FillType.Solid:
			return color_0.Equals(fillFormatEffectiveData.color_0);
		case FillType.Gradient:
			if (gradientFormatEffectiveData_0.Equals(fillFormatEffectiveData.gradientFormatEffectiveData_0))
			{
				return bool_0 == fillFormatEffectiveData.bool_0;
			}
			return false;
		case FillType.Pattern:
			if (patternFormatEffectiveData_0.Equals(fillFormatEffectiveData.patternFormatEffectiveData_0))
			{
				return bool_0 == fillFormatEffectiveData.bool_0;
			}
			return false;
		case FillType.Picture:
			if (pictureFillFormatEffectiveData_0.Equals(fillFormatEffectiveData.pictureFillFormatEffectiveData_0))
			{
				return bool_0 == fillFormatEffectiveData.bool_0;
			}
			return false;
		}
	}

	public override int GetHashCode()
	{
		return 23454;
	}
}
