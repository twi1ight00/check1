using System;
using Aspose.Slides;
using Aspose.Slides.Warnings;
using ns62;

namespace ns15;

internal class Class1052
{
	internal static void smethod_0(FillFormat targetFormat, Class2670 frame, Class854 slideDeserializationContext)
	{
		Class2911 @class = Class2945.smethod_2(frame, Enum426.const_119) as Class2911;
		Class2911 class2 = Class2945.smethod_2(frame, Enum426.const_0) as Class2911;
		Class2670 class3 = null;
		if (!Class1049.smethod_6(frame, class3))
		{
			Class2911 class4 = Class2945.smethod_2(frame, Enum426.const_82) as Class2911;
			if (@class == null && class4 != null)
			{
				targetFormat.FillType = FillType.Solid;
				Class1049.smethod_3(targetFormat.colorFormat_0, frame, class3, Enum426.const_82, Enum426.const_83, 16777215u);
			}
			else
			{
				targetFormat.FillType = FillType.NoFill;
			}
		}
		else
		{
			uint num = Class2945.smethod_10(frame, class3, Enum426.const_81, 0u);
			switch (num)
			{
			case 0u:
				targetFormat.FillType = FillType.Solid;
				Class1049.smethod_3(targetFormat.colorFormat_0, frame, class3, Enum426.const_82, Enum426.const_83, 16777215u);
				break;
			case 1u:
				targetFormat.FillType = FillType.Pattern;
				Class1060.smethod_0(targetFormat.patternFormat_0, frame, slideDeserializationContext);
				break;
			case 2u:
			case 3u:
				targetFormat.FillType = FillType.Picture;
				Class1061.smethod_0(targetFormat.pictureFillFormat_0, frame.ShapePrimaryOptions, num, slideDeserializationContext);
				break;
			case 4u:
			case 5u:
			case 6u:
			case 7u:
				targetFormat.FillType = FillType.Gradient;
				Class1053.smethod_0(targetFormat.gradientFormat_0, frame, class3, slideDeserializationContext);
				break;
			default:
				targetFormat.FillType = FillType.NotDefined;
				break;
			case 9u:
				if (targetFormat.Parent is AutoShape)
				{
					AutoShape autoShape = (AutoShape)targetFormat.Parent;
					autoShape.UseBackgroundFill = true;
				}
				break;
			}
		}
		Class2837 shapeTertiaryOptions = frame.ShapeTertiaryOptions;
		if (shapeTertiaryOptions != null && shapeTertiaryOptions.Properties != null)
		{
			@class = shapeTertiaryOptions.Properties[Enum426.const_119] as Class2920;
		}
		if (@class == null)
		{
			@class = Class2945.smethod_3(frame, Enum426.const_119) as Class2920;
		}
		class2 = null;
		if (class3 != null)
		{
			shapeTertiaryOptions = class3.ShapeTertiaryOptions;
			if (shapeTertiaryOptions != null && shapeTertiaryOptions.Properties != null)
			{
				class2 = shapeTertiaryOptions.Properties[Enum426.const_119] as Class2911;
			}
			if (class2 == null)
			{
				class2 = Class2945.smethod_3(class3, Enum426.const_119);
			}
		}
		uint num3;
		if (@class != null)
		{
			if (class2 != null)
			{
				uint num2 = @class.Value >> 16;
				num3 = ((class2.Value & ~num2) | (@class.Value & num2)) & 0xFFFFu;
			}
			else
			{
				num3 = @class.Value & 0xFFFFu;
			}
		}
		else
		{
			num3 = ((class2 != null) ? (class2.Value & 0xFFFFu) : uint.MaxValue);
		}
		if (num3 == uint.MaxValue)
		{
			targetFormat.RotateWithShape = NullableBool.NotDefined;
		}
		else
		{
			targetFormat.RotateWithShape = (((num3 & 0x20u) != 0) ? NullableBool.True : NullableBool.False);
		}
	}

	internal static void smethod_1(IFillFormat fillFormat, Class2834 fopt, Class2837 tertiaryFopt, bool background, Class856 serializationContext)
	{
		if (fillFormat == null)
		{
			return;
		}
		IPresentationComponent parent = ((FillFormat)fillFormat).Parent;
		Class2944 properties = fopt.Properties;
		Class2920 @class = new Class2920();
		properties.method_0(@class);
		if (background)
		{
			@class.Folded_fillUseRect = true;
			properties.Add(new Class2911(Enum426.const_100, isBid: false, 9150350u));
			properties.Add(new Class2911(Enum426.const_101, isBid: false, 6864350u));
		}
		if (parent is AutoShape && ((AutoShape)parent).UseBackgroundFill)
		{
			properties.method_0(new Class2911(Enum426.const_81, 9u));
			@class.Folded_fFilled = true;
			return;
		}
		switch (fillFormat.FillType)
		{
		default:
			throw new ArgumentOutOfRangeException();
		case FillType.NotDefined:
		case FillType.NoFill:
			if (parent is Cell)
			{
				@class.Folded_fNoFillHitTest = true;
				@class.Folded_fillShape = false;
			}
			else
			{
				@class.Folded_fNoFillHitTest = false;
				@class.Folded_fillShape = true;
			}
			@class.Folded_fFilled = false;
			break;
		case FillType.Solid:
			@class.Folded_fFilled = true;
			if (parent is Cell)
			{
				@class.Folded_fillShape = false;
			}
			else
			{
				@class.Folded_fillShape = true;
			}
			Class1049.smethod_8(fillFormat.SolidFillColor, properties, Enum426.const_82, Enum426.const_83, serializationContext);
			break;
		case FillType.Gradient:
			@class.Folded_fFilled = true;
			Class1053.smethod_1((GradientFormat)fillFormat.GradientFormat, fopt, serializationContext);
			properties.Remove(Enum426.const_119);
			properties.Add(new Class2911(Enum426.const_119, 1048592u));
			break;
		case FillType.Pattern:
			@class.Folded_fFilled = true;
			Class1060.smethod_1((PatternFormat)fillFormat.PatternFormat, fopt, serializationContext);
			break;
		case FillType.Picture:
			@class.Folded_fFilled = true;
			Class1061.smethod_1((PictureFillFormat)fillFormat.PictureFillFormat, fopt, serializationContext);
			if (!background)
			{
				smethod_2(fillFormat.RotateWithShape, tertiaryFopt);
			}
			break;
		case FillType.Group:
			serializationContext.method_15("FillType.Group PPT serialization is not implemented yet.", WarningType.MinorFormattingLoss);
			break;
		}
	}

	internal static void smethod_2(NullableBool rotateWithShape, Class2837 tertiaryFopt)
	{
		if (rotateWithShape != NullableBool.NotDefined)
		{
			Class2920 @class = (Class2920)tertiaryFopt.Properties[Enum426.const_119];
			if (@class == null)
			{
				tertiaryFopt.Properties.Add(@class = new Class2920());
			}
			@class.Folded_fUseShapeAnchor = rotateWithShape == NullableBool.True;
		}
	}
}
