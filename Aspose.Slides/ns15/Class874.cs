using System;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Warnings;
using ns62;

namespace ns15;

internal class Class874
{
	internal static void smethod_0(IEffectFormat effectFormat, Class2670 shapeContainer, Class854 slideDeserializationContext)
	{
		Class2834 shapePrimaryOptions = shapeContainer.ShapePrimaryOptions;
		Class2837 shapeTertiaryOptions = shapeContainer.ShapeTertiaryOptions;
		Class2911 propShadowOffsetX = shapePrimaryOptions.Properties[Enum426.const_300] as Class2911;
		Class2911 propShadowOffsetY = shapePrimaryOptions.Properties[Enum426.const_301] as Class2911;
		Class2911 @class = shapePrimaryOptions.Properties[Enum426.const_311] as Class2911;
		Class2911 class2 = shapePrimaryOptions.Properties[Enum426.const_312] as Class2911;
		Class2911 class3 = shapePrimaryOptions.Properties[Enum426.const_304] as Class2911;
		Class2911 class4 = shapePrimaryOptions.Properties[Enum426.const_307] as Class2911;
		Class2911 class5 = shapePrimaryOptions.Properties[Enum426.const_305] as Class2911;
		Class2911 class6 = shapePrimaryOptions.Properties[Enum426.const_306] as Class2911;
		Class2911 class7 = ((shapeTertiaryOptions == null) ? null : (shapeTertiaryOptions.Properties[Enum426.const_323] as Class2911));
		effectFormat.EnableOuterShadowEffect();
		IOuterShadow outerShadowEffect = effectFormat.OuterShadowEffect;
		outerShadowEffect.BlurRadius = ((class7 != null) ? ((double)(int)class7.Value / 12700.0) : 0.0);
		Struct54 @struct = Class866.smethod_0(propShadowOffsetX, propShadowOffsetY);
		outerShadowEffect.Distance = @struct.double_0;
		outerShadowEffect.Direction = @struct.float_0;
		Class1049.smethod_2(outerShadowEffect.ShadowColor, shapeContainer, Enum426.const_296, Enum426.const_299, 8421504u);
		uint num = 0u;
		uint num2 = 0u;
		if (@class != null)
		{
			num = @class.Value;
		}
		if (class2 != null)
		{
			num2 = class2.Value;
		}
		if (num == 4294934528u && num2 == 4294934528u)
		{
			outerShadowEffect.RectangleAlign = RectangleAlignment.TopLeft;
		}
		else if (num == 0 && num2 == 4294934528u)
		{
			outerShadowEffect.RectangleAlign = RectangleAlignment.Top;
		}
		else if (num == 32768 && num2 == 4294934528u)
		{
			outerShadowEffect.RectangleAlign = RectangleAlignment.TopRight;
		}
		else if (num == 4294934528u && num2 == 0)
		{
			outerShadowEffect.RectangleAlign = RectangleAlignment.Left;
		}
		else if (num == 0 && num2 == 0)
		{
			outerShadowEffect.RectangleAlign = RectangleAlignment.Center;
		}
		else if (num == 32768 && num2 == 0)
		{
			outerShadowEffect.RectangleAlign = RectangleAlignment.Right;
		}
		else if (num == 4294934528u && num2 == 32768)
		{
			outerShadowEffect.RectangleAlign = RectangleAlignment.BottomLeft;
		}
		else if (num == 0 && num2 == 32768)
		{
			outerShadowEffect.RectangleAlign = RectangleAlignment.Bottom;
		}
		else if (num == 32768 && num2 == 32768)
		{
			outerShadowEffect.RectangleAlign = RectangleAlignment.BottomRight;
		}
		else
		{
			slideDeserializationContext.DeserializationContext.DomPresentation.LoadOptions.method_1("Loading of non-predefined OuterShadow.RectangleAlign ppt data is not implemented yet.", WarningType.MinorFormattingLoss);
		}
		int num3 = (int)(class3?.Value ?? 65536);
		int num4 = (int)(class4?.Value ?? 65536);
		int num5 = (int)(class5?.Value ?? 0);
		int num6 = (int)(class6?.Value ?? 0);
		outerShadowEffect.ScaleHorizontal = (double)num3 * 100.0 / 65536.0;
		outerShadowEffect.ScaleVertical = (double)num4 * 100.0 / 65536.0;
		outerShadowEffect.SkewHorizontal = Math.Atan((double)num5 / (double)num3) * 180.0 / Math.PI;
		outerShadowEffect.SkewVertical = Math.Atan((double)num6 / (double)num4) * 180.0 / Math.PI;
	}

	internal static void smethod_1(IOuterShadow outerShadow, Class2834 fopt, Class2837 tertiaryFopt, Class856 serializationContext)
	{
		if (outerShadow != null)
		{
			Class2944 properties = fopt.Properties;
			Class2944 properties2 = tertiaryFopt.Properties;
			if (outerShadow.BlurRadius != 0.0)
			{
				properties2.method_0(new Class2911(Enum426.const_323, (uint)(outerShadow.BlurRadius * 12700.0 + 0.5)));
			}
			Class866.smethod_1(new Struct54(outerShadow.Distance, outerShadow.Direction), fopt);
			Class1049.smethod_8(outerShadow.ShadowColor, properties, Enum426.const_296, Enum426.const_299, serializationContext);
			switch (outerShadow.RectangleAlign)
			{
			default:
				throw new Exception();
			case RectangleAlignment.TopLeft:
				properties.method_0(new Class2911(Enum426.const_311, 4294934528u));
				properties.method_0(new Class2911(Enum426.const_312, 4294934528u));
				break;
			case RectangleAlignment.Top:
				properties.method_0(new Class2911(Enum426.const_312, 4294934528u));
				break;
			case RectangleAlignment.TopRight:
				properties.method_0(new Class2911(Enum426.const_311, 32768u));
				properties.method_0(new Class2911(Enum426.const_312, 4294934528u));
				break;
			case RectangleAlignment.Left:
				properties.method_0(new Class2911(Enum426.const_311, 4294934528u));
				break;
			case RectangleAlignment.Right:
				properties.method_0(new Class2911(Enum426.const_311, 32768u));
				break;
			case RectangleAlignment.BottomLeft:
				properties.method_0(new Class2911(Enum426.const_311, 4294934528u));
				properties.method_0(new Class2911(Enum426.const_312, 32768u));
				break;
			case RectangleAlignment.NotDefined:
			case RectangleAlignment.Bottom:
				properties.method_0(new Class2911(Enum426.const_312, 32768u));
				break;
			case RectangleAlignment.BottomRight:
				properties.method_0(new Class2911(Enum426.const_311, 32768u));
				properties.method_0(new Class2911(Enum426.const_312, 32768u));
				break;
			case RectangleAlignment.Center:
				break;
			}
			int num = 65536;
			int num2 = 65536;
			if (outerShadow.ScaleHorizontal != 100.0)
			{
				properties.method_0(new Class2911(Enum426.const_304, (uint)(num = (int)(outerShadow.ScaleHorizontal * 65536.0 / 100.0 + (double)Math.Sign(outerShadow.ScaleHorizontal) * 0.5))));
			}
			if (outerShadow.ScaleVertical != 100.0)
			{
				properties.method_0(new Class2911(Enum426.const_307, (uint)(num2 = (int)(outerShadow.ScaleVertical * 65536.0 / 100.0 + (double)Math.Sign(outerShadow.ScaleVertical) * 0.5))));
			}
			if (outerShadow.SkewHorizontal != 0.0)
			{
				properties.method_0(new Class2911(Enum426.const_305, (uint)((double)num * Math.Tan(outerShadow.SkewHorizontal * Math.PI / 180.0) + (double)Math.Sign(outerShadow.SkewHorizontal) * 0.5)));
			}
			if (outerShadow.SkewVertical != 0.0)
			{
				properties.method_0(new Class2911(Enum426.const_306, (uint)((double)num2 * Math.Tan(outerShadow.SkewVertical * Math.PI / 180.0) + (double)Math.Sign(outerShadow.SkewVertical) * 0.5)));
			}
		}
	}
}
