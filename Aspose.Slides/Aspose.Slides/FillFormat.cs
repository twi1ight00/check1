using System;
using Aspose.Slides.Charts;
using Aspose.Slides.Theme;
using ns28;
using ns4;

namespace Aspose.Slides;

public class FillFormat : IAccessiblePVIObject<FillFormatEffectiveDataPVITemp>, IFillParamSource, IFillFormat, IPVIObject
{
	internal FillType fillType_0 = FillType.NotDefined;

	internal ColorFormat colorFormat_0;

	internal GradientFormat gradientFormat_0;

	internal PictureFillFormat pictureFillFormat_0;

	internal PatternFormat patternFormat_0;

	private NullableBool nullableBool_0;

	private IPresentationComponent ipresentationComponent_0;

	private FillFormatEffectiveDataPVITemp fillFormatEffectiveDataPVITemp_0;

	private uint uint_0;

	IPresentationComponent IAccessiblePVIObject<FillFormatEffectiveDataPVITemp>.Parent => Parent;

	internal IPresentationComponent Parent => ipresentationComponent_0;

	public FillType FillType
	{
		get
		{
			return fillType_0;
		}
		set
		{
			fillType_0 = value;
			method_3();
		}
	}

	public IColorFormat SolidFillColor => colorFormat_0;

	public IGradientFormat GradientFormat => gradientFormat_0;

	public IPatternFormat PatternFormat => patternFormat_0;

	public IPictureFillFormat PictureFillFormat => pictureFillFormat_0;

	public NullableBool RotateWithShape
	{
		get
		{
			return nullableBool_0;
		}
		set
		{
			nullableBool_0 = value;
			method_3();
		}
	}

	uint IPVIObject.Version => Version;

	internal uint Version => uint_0 + colorFormat_0.Version + gradientFormat_0.Version + pictureFillFormat_0.Version + patternFormat_0.Version;

	IFillParamSource IFillFormat.AsIFillParamSource => this;

	internal FillFormat(IPresentationComponent parent)
	{
		if (parent != null && !(parent is Background) && !(parent is Cell) && !(parent is FormatScheme) && !(parent is Shape) && !(parent is Class144) && !(parent is IFormattedTextContainer) && !(parent is Portion) && !(parent is Field) && !(parent is Paragraph) && !(parent is MasterSlide) && !(parent is Presentation) && !(parent is TextFrame))
		{
			throw new ArgumentException();
		}
		ipresentationComponent_0 = parent;
		fillFormatEffectiveDataPVITemp_0 = new FillFormatEffectiveDataPVITemp(this);
		colorFormat_0 = new ColorFormat(parent as ISlideComponent, PresetColor.Black);
		gradientFormat_0 = new GradientFormat(parent);
		pictureFillFormat_0 = new PictureFillFormat(parent);
		patternFormat_0 = new PatternFormat(parent);
		nullableBool_0 = NullableBool.NotDefined;
	}

	internal void method_0(FillFormat source)
	{
		fillType_0 = source.fillType_0;
		colorFormat_0.method_0(source.colorFormat_0);
		gradientFormat_0.method_0(source.gradientFormat_0);
		pictureFillFormat_0.method_1(source.pictureFillFormat_0);
		patternFormat_0.method_0(source.patternFormat_0);
		nullableBool_0 = source.nullableBool_0;
		method_3();
	}

	internal void method_1(FillFormatEffectiveData source)
	{
		fillType_0 = source.fillType_0;
		colorFormat_0.method_1(source.color_0);
		gradientFormat_0.method_1(source.gradientFormatEffectiveData_0);
		pictureFillFormat_0.method_2(source.pictureFillFormatEffectiveData_0);
		patternFormat_0.method_1(source.patternFormatEffectiveData_0);
		nullableBool_0 = (source.bool_0 ? NullableBool.True : NullableBool.False);
		method_3();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is FillFormat fillFormat))
		{
			return base.Equals(obj);
		}
		if (fillType_0 != fillFormat.fillType_0)
		{
			return false;
		}
		switch (fillType_0)
		{
		case FillType.Solid:
			return colorFormat_0.Equals(fillFormat.colorFormat_0);
		case FillType.Gradient:
			if (gradientFormat_0.Equals(fillFormat.gradientFormat_0))
			{
				return nullableBool_0 == fillFormat.nullableBool_0;
			}
			return false;
		case FillType.Pattern:
			if (patternFormat_0.Equals(fillFormat.patternFormat_0))
			{
				return nullableBool_0 == fillFormat.nullableBool_0;
			}
			return false;
		case FillType.Picture:
			if (pictureFillFormat_0.Equals(fillFormat.pictureFillFormat_0))
			{
				return nullableBool_0 == fillFormat.nullableBool_0;
			}
			return false;
		default:
			return true;
		}
	}

	public override int GetHashCode()
	{
		return 23454;
	}

	internal void method_2(Class470 fillProp, Class476 package)
	{
		switch (fillProp.FillStyle)
		{
		default:
			FillType = FillType.NoFill;
			break;
		case Enum36.const_1:
			FillType = FillType.Solid;
			colorFormat_0.Color = fillProp.FillColor;
			break;
		case Enum36.const_2:
			FillType = FillType.Picture;
			((PictureFillFormat)PictureFillFormat).method_3(fillProp, package);
			break;
		case Enum36.const_3:
		{
			FillType = FillType.Gradient;
			Class396 class2 = package.class465_0.method_5(fillProp.GradientName);
			if (class2 != null)
			{
				((GradientFormat)GradientFormat).method_3(class2);
			}
			break;
		}
		case Enum36.const_4:
		{
			FillType = FillType.Pattern;
			Class399 @class = package.class465_0.method_7(fillProp.HatchName);
			if (@class != null)
			{
				((PatternFormat)PatternFormat).method_2(@class);
			}
			break;
		}
		}
		method_3();
	}

	private void method_3()
	{
		uint_0++;
	}

	internal FillFormatEffectiveDataPVITemp method_4()
	{
		fillFormatEffectiveDataPVITemp_0.method_0();
		return fillFormatEffectiveDataPVITemp_0;
	}
}
