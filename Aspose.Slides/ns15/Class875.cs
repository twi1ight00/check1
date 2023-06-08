using Aspose.Slides;
using ns62;

namespace ns15;

internal class Class875
{
	internal static void smethod_0(IEffectFormat effectFormat, Class2670 shapeContainer, Class854 slideDeserializationContext)
	{
		Class2834 shapePrimaryOptions = shapeContainer.ShapePrimaryOptions;
		Class2837 shapeTertiaryOptions = shapeContainer.ShapeTertiaryOptions;
		Class2944 @class = ((shapePrimaryOptions != null) ? shapePrimaryOptions.Properties : new Class2944());
		Class2916 class2 = @class[Enum426.const_324] as Class2916;
		if (!(class2 == null) && class2.BfUsefShadow && class2.EfShadow)
		{
			if (Class872.smethod_1(shapePrimaryOptions))
			{
				Class872.smethod_0(effectFormat, shapeContainer);
			}
			else
			{
				Class874.smethod_0(effectFormat, shapeContainer, slideDeserializationContext);
			}
			Class865.smethod_0(effectFormat.BlurEffect, shapePrimaryOptions, shapeTertiaryOptions, slideDeserializationContext);
			Class867.smethod_0(effectFormat.FillOverlayEffect, shapePrimaryOptions, shapeTertiaryOptions, slideDeserializationContext);
			Class868.smethod_0(effectFormat.GlowEffect, shapePrimaryOptions, shapeTertiaryOptions, slideDeserializationContext);
			Class869.smethod_0(effectFormat.InnerShadowEffect, shapePrimaryOptions, shapeTertiaryOptions, slideDeserializationContext);
			Class871.smethod_0(effectFormat.ReflectionEffect, shapePrimaryOptions, shapeTertiaryOptions, slideDeserializationContext);
			Class870.smethod_0(effectFormat.SoftEdgeEffect, shapePrimaryOptions, shapeTertiaryOptions, slideDeserializationContext);
		}
	}

	internal static void smethod_1(IEffectFormat effectFormat, Class2834 fopt, Class2837 tertiaryFopt, Class856 serializationContext)
	{
		if (effectFormat != null && !effectFormat.IsNoEffects)
		{
			Class2944 properties = fopt.Properties;
			Class2916 @class = new Class2916();
			@class.BfUsefShadow = true;
			@class.CfUsefshadowObscured = true;
			@class.EfShadow = true;
			properties.method_0(@class);
			Class865.smethod_1(effectFormat.BlurEffect, fopt, tertiaryFopt, serializationContext);
			Class867.smethod_1(effectFormat.FillOverlayEffect, fopt, tertiaryFopt, serializationContext);
			Class868.smethod_1(effectFormat.GlowEffect, fopt, tertiaryFopt, serializationContext);
			Class869.smethod_1(effectFormat.InnerShadowEffect, fopt, tertiaryFopt, serializationContext);
			Class874.smethod_1(effectFormat.OuterShadowEffect, fopt, tertiaryFopt, serializationContext);
			Class872.smethod_10(effectFormat.PresetShadowEffect, fopt, tertiaryFopt, serializationContext);
			Class871.smethod_1(effectFormat.ReflectionEffect, fopt, tertiaryFopt, serializationContext);
			Class870.smethod_1(effectFormat.SoftEdgeEffect, fopt, tertiaryFopt, serializationContext);
			if (properties.Contains(Enum426.const_304) || properties.Contains(Enum426.const_307) || properties.Contains(Enum426.const_305) || properties.Contains(Enum426.const_306))
			{
				properties.method_0(new Class2911(Enum426.const_295, 2u));
			}
		}
	}
}
