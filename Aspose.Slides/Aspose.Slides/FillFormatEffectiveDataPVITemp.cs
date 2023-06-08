using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Slides.Theme;
using ns4;

namespace Aspose.Slides;

internal class FillFormatEffectiveDataPVITemp : Class20<FillFormat, FillFormatEffectiveDataPVITemp>, IFillFormatEffectiveData
{
	private FillFormat fillFormat_0;

	internal FillType fillType_0 = FillType.NotDefined;

	internal bool bool_1;

	internal Class18 class18_0;

	internal Class58 class58_0;

	internal PictureFillFormatEffectiveDataPVITemp pictureFillFormatEffectiveDataPVITemp_0;

	internal Class59 class59_0;

	internal bool bool_2;

	private static readonly FillFormatEffectiveDataPVITemp fillFormatEffectiveDataPVITemp_0 = smethod_0();

	[CompilerGenerated]
	private static Class21.Delegate2 delegate2_0;

	[CompilerGenerated]
	private static Class21.Delegate2 delegate2_1;

	internal override FillFormatEffectiveDataPVITemp Default => fillFormatEffectiveDataPVITemp_0;

	public FillType FillType => fillType_0;

	public Color SolidFillColor => class18_0.Color;

	public IGradientFormatEffectiveData GradientFormat => class58_0;

	public IPatternFormatEffectiveData PatternFormat => class59_0;

	public IPictureFillFormatEffectiveData PictureFillFormat => pictureFillFormatEffectiveDataPVITemp_0;

	public bool RotateWithShape => bool_2;

	internal FillFormatEffectiveDataPVITemp(FillFormat parentAccessablePVIObject)
		: base(parentAccessablePVIObject)
	{
		bool_1 = false;
		class18_0 = new Class18();
		class59_0 = new Class59();
		class58_0 = new Class58();
		pictureFillFormatEffectiveDataPVITemp_0 = new PictureFillFormatEffectiveDataPVITemp(this);
		bool_2 = false;
	}

	internal override FillFormatEffectiveDataPVITemp vmethod_3()
	{
		IPresentationComponent parent = fillFormat_0.Parent;
		if (parent is Shape)
		{
			Shape shape = (Shape)parent;
			if (fillFormat_0.FillType == FillType.NotDefined && shape is GeometryShape && ((GeometryShape)shape).ShapeStyle != null)
			{
				ThemeEffectiveData themeEffectiveData = (ThemeEffectiveData)base.Slide.CreateThemeEffective();
				IShapeStyle shapeStyle = ((GeometryShape)shape).ShapeStyle;
				if (themeEffectiveData != null && shapeStyle != null)
				{
					FillFormat fillFormat = themeEffectiveData.method_4(shapeStyle.FillStyleIndex);
					if (fillFormat == null)
					{
						return Default;
					}
					return fillFormat.method_4();
				}
				return Default;
			}
			Shape shape2 = shape.method_3();
			return (shape2 != null) ? shape2.fillFormat_0.method_4() : Default;
		}
		if (!(parent is FormatScheme))
		{
			throw new NotImplementedException();
		}
		return Default;
	}

	internal override void vmethod_4()
	{
		if (fillFormat_0.Parent is Shape shape && fillType_0 == FillType.Group)
		{
			FillFormatEffectiveDataPVITemp source = ((shape.ParentGroupInternal != null) ? shape.ParentGroupInternal.fillFormat_0.method_4() : Default);
			vmethod_0(source);
			bool_1 = true;
		}
	}

	private static FillFormatEffectiveDataPVITemp smethod_0()
	{
		FillFormatEffectiveDataPVITemp fillFormatEffectiveDataPVITemp = new FillFormatEffectiveDataPVITemp(null);
		fillFormatEffectiveDataPVITemp.fillType_0 = FillType.NoFill;
		fillFormatEffectiveDataPVITemp.class59_0.class18_0.ColorResolver = (IBaseSlide colorMappingSlide, FloatColor styleColor) => Color.Black;
		fillFormatEffectiveDataPVITemp.class59_0.class18_1.ColorResolver = (IBaseSlide colorMappingSlide, FloatColor styleColor) => Color.White;
		fillFormatEffectiveDataPVITemp.class58_0.gradientShape_0 = GradientShape.Linear;
		return fillFormatEffectiveDataPVITemp;
	}

	internal override void vmethod_0(FillFormatEffectiveDataPVITemp source)
	{
		if (source.bool_1)
		{
			fillType_0 = FillType.Group;
		}
		else
		{
			fillType_0 = source.FillType;
			switch (fillType_0)
			{
			default:
				throw new ArgumentException();
			case FillType.Solid:
				class18_0.ColorResolver = source.class18_0.ColorResolver;
				break;
			case FillType.Gradient:
				class58_0.method_2(source.class58_0);
				break;
			case FillType.Pattern:
				class59_0.method_2(source.class59_0);
				break;
			case FillType.Picture:
				pictureFillFormatEffectiveDataPVITemp_0.vmethod_0(source.pictureFillFormatEffectiveDataPVITemp_0);
				break;
			case FillType.NotDefined:
			case FillType.NoFill:
			case FillType.Group:
				break;
			}
		}
		bool_2 = source.bool_2;
	}

	internal override void vmethod_1(FillFormat source)
	{
		if (source.FillType != FillType.NotDefined)
		{
			fillType_0 = source.FillType;
			switch (fillType_0)
			{
			default:
				throw new ArgumentException();
			case FillType.NotDefined:
				throw new ArgumentException();
			case FillType.Solid:
				class18_0.ColorResolver = source.colorFormat_0.method_5;
				break;
			case FillType.Gradient:
				class58_0.method_0(source.gradientFormat_0);
				break;
			case FillType.Pattern:
				class59_0.method_0(source.patternFormat_0);
				break;
			case FillType.Picture:
				pictureFillFormatEffectiveDataPVITemp_0.vmethod_1(source.pictureFillFormat_0);
				break;
			case FillType.NoFill:
			case FillType.Group:
				break;
			}
			if (source.RotateWithShape != NullableBool.NotDefined)
			{
				bool_2 = source.RotateWithShape == NullableBool.True;
			}
		}
	}

	internal override void vmethod_2(IBaseSlide slide, FloatColor effectiveStyleColor)
	{
		switch (fillType_0)
		{
		case FillType.Solid:
			class18_0.method_0(slide, effectiveStyleColor);
			break;
		case FillType.Gradient:
			class58_0.method_1(slide, effectiveStyleColor);
			break;
		case FillType.Pattern:
			class59_0.method_1(slide, effectiveStyleColor);
			break;
		case FillType.Picture:
			pictureFillFormatEffectiveDataPVITemp_0.vmethod_2(slide, effectiveStyleColor);
			break;
		case FillType.NoFill:
			break;
		}
	}

	public override bool Equals(object obj)
	{
		if (!(obj is FillFormatEffectiveDataPVITemp obj2))
		{
			return false;
		}
		return method_2(obj2);
	}

	internal bool method_2(FillFormatEffectiveDataPVITemp obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (fillType_0 != obj.fillType_0)
		{
			return false;
		}
		switch (fillType_0)
		{
		default:
			return true;
		case FillType.Solid:
			return class18_0.Equals(obj.class18_0);
		case FillType.Gradient:
			if (class58_0.method_3(obj.class58_0))
			{
				return bool_2 == obj.bool_2;
			}
			return false;
		case FillType.Pattern:
			if (class59_0.method_3(obj.class59_0))
			{
				return bool_2 == obj.bool_2;
			}
			return false;
		case FillType.Picture:
			if (pictureFillFormatEffectiveDataPVITemp_0.method_3(obj.pictureFillFormatEffectiveDataPVITemp_0))
			{
				return bool_2 == obj.bool_2;
			}
			return false;
		}
	}

	internal bool method_3(FillFormatEffectiveData obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (fillType_0 != obj.fillType_0)
		{
			return false;
		}
		switch (fillType_0)
		{
		default:
			return true;
		case FillType.Solid:
			return class18_0.Color.Equals(obj.color_0);
		case FillType.Gradient:
			if (class58_0.method_4(obj.gradientFormatEffectiveData_0))
			{
				return bool_2 == obj.bool_0;
			}
			return false;
		case FillType.Pattern:
			if (class59_0.method_4(obj.patternFormatEffectiveData_0))
			{
				return bool_2 == obj.bool_0;
			}
			return false;
		case FillType.Picture:
			if (pictureFillFormatEffectiveDataPVITemp_0.method_4(obj.pictureFillFormatEffectiveData_0))
			{
				return bool_2 == obj.bool_0;
			}
			return false;
		}
	}

	public override int GetHashCode()
	{
		return 23454;
	}

	internal Class63 method_4(Class67 arguments)
	{
		return new Class63(arguments, this);
	}

	[CompilerGenerated]
	private static Color smethod_1(IBaseSlide colorMappingSlide, FloatColor styleColor)
	{
		return Color.Black;
	}

	[CompilerGenerated]
	private static Color smethod_2(IBaseSlide colorMappingSlide, FloatColor styleColor)
	{
		return Color.White;
	}
}
