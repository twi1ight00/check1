using Aspose.Slides;
using Aspose.Slides.Effects;
using ns62;

namespace ns15;

internal class Class872
{
	internal class Class873
	{
		public Class2911 class2911_0;

		public Class2911 class2911_1;

		public Class2911 class2911_2;

		public Class2911 class2911_3;

		public Class2911 class2911_4;

		public Class2911 class2911_5;

		public Class2911 class2911_6;

		public Class2911 class2911_7;

		internal Class873(Class2834 fopt)
		{
			Class2944 properties = fopt.Properties;
			class2911_0 = properties[Enum426.const_295] as Class2911;
			class2911_1 = properties[Enum426.const_305] as Class2911;
			class2911_2 = properties[Enum426.const_307] as Class2911;
			class2911_3 = properties[Enum426.const_309] as Class2911;
			class2911_4 = properties[Enum426.const_311] as Class2911;
			class2911_5 = properties[Enum426.const_312] as Class2911;
			class2911_6 = properties[Enum426.const_300] as Class2911;
			class2911_7 = properties[Enum426.const_301] as Class2911;
		}
	}

	internal static void smethod_0(IEffectFormat effectFormat, Class2670 shapeContainer)
	{
		Class2834 shapePrimaryOptions = shapeContainer.ShapePrimaryOptions;
		Class873 propsCache = new Class873(shapePrimaryOptions);
		if (smethod_2(propsCache))
		{
			Class2911 propShadowOffsetX = shapePrimaryOptions.Properties[Enum426.const_300] as Class2911;
			Class2911 propShadowOffsetY = shapePrimaryOptions.Properties[Enum426.const_301] as Class2911;
			effectFormat.EnablePresetShadowEffect();
			IPresetShadow presetShadowEffect = effectFormat.PresetShadowEffect;
			if (smethod_3(propsCache))
			{
				presetShadowEffect.Preset = PresetShadowType.BackLeftLongPerspectiveShadow;
			}
			if (smethod_4(propsCache))
			{
				presetShadowEffect.Preset = PresetShadowType.BackRightLongPerspectiveShadow;
			}
			if (smethod_5(propsCache))
			{
				presetShadowEffect.Preset = PresetShadowType.TopLeftDoubleDropShadow;
			}
			if (smethod_6(propsCache))
			{
				presetShadowEffect.Preset = PresetShadowType.FrontLeftLongPerspectiveShadow;
			}
			if (smethod_7(propsCache))
			{
				presetShadowEffect.Preset = PresetShadowType.FrontRightLongPerspectiveShadow;
			}
			if (smethod_8(propsCache))
			{
				presetShadowEffect.Preset = PresetShadowType.OuterBoxShadow3D;
			}
			if (smethod_9(propsCache))
			{
				presetShadowEffect.Preset = PresetShadowType.InnerBoxShadow3D;
			}
			Struct54 @struct = Class866.smethod_0(propShadowOffsetX, propShadowOffsetY);
			presetShadowEffect.Distance = @struct.double_0;
			presetShadowEffect.Direction = @struct.float_0;
			Class1049.smethod_2(presetShadowEffect.ShadowColor, shapeContainer, Enum426.const_296, Enum426.const_299, 8421504u);
		}
	}

	internal static bool smethod_1(Class2834 fopt)
	{
		return smethod_2(new Class873(fopt));
	}

	private static bool smethod_2(Class873 propsCache)
	{
		if (!smethod_3(propsCache) && !smethod_4(propsCache) && !smethod_5(propsCache) && !smethod_6(propsCache) && !smethod_7(propsCache) && !smethod_8(propsCache) && !smethod_9(propsCache))
		{
			return false;
		}
		return true;
	}

	private static bool smethod_3(Class873 propsCache)
	{
		if (propsCache.class2911_0 != null && propsCache.class2911_0.Value == 2 && propsCache.class2911_1 != null && propsCache.class2911_1.Value == 92680 && propsCache.class2911_3 != null && propsCache.class2911_3.Value == 4294967280u && propsCache.class2911_4 != null && propsCache.class2911_4.Value == 4294934528u && propsCache.class2911_5 != null)
		{
			return propsCache.class2911_5.Value == 32768;
		}
		return false;
	}

	private static bool smethod_4(Class873 propsCache)
	{
		if (propsCache.class2911_0 != null && propsCache.class2911_0.Value == 2 && propsCache.class2911_1 != null && propsCache.class2911_1.Value == 4294874616u && propsCache.class2911_3 != null && propsCache.class2911_3.Value == 4294967280u && propsCache.class2911_4 != null && propsCache.class2911_4.Value == 32768 && propsCache.class2911_5 != null)
		{
			return propsCache.class2911_5.Value == 32768;
		}
		return false;
	}

	private static bool smethod_5(Class873 propsCache)
	{
		if (propsCache.class2911_0 != null)
		{
			return propsCache.class2911_0.Value == 1;
		}
		return false;
	}

	private static bool smethod_6(Class873 propsCache)
	{
		if (propsCache.class2911_0 != null && propsCache.class2911_0.Value == 2 && propsCache.class2911_1 != null && propsCache.class2911_1.Value == 92680 && propsCache.class2911_2 != null && propsCache.class2911_2.Value == 4294901760u && propsCache.class2911_3 != null && propsCache.class2911_3.Value == 4294967280u && propsCache.class2911_4 != null && propsCache.class2911_4.Value == 4294934528u && propsCache.class2911_5 != null)
		{
			return propsCache.class2911_5.Value == 32768;
		}
		return false;
	}

	private static bool smethod_7(Class873 propsCache)
	{
		if (propsCache.class2911_0 != null && propsCache.class2911_0.Value == 2 && propsCache.class2911_1 != null && propsCache.class2911_1.Value == 4294874616u && propsCache.class2911_2 != null && propsCache.class2911_2.Value == 4294901760u && propsCache.class2911_3 != null && propsCache.class2911_3.Value == 4294967280u && propsCache.class2911_4 != null && propsCache.class2911_4.Value == 32768 && propsCache.class2911_5 != null)
		{
			return propsCache.class2911_5.Value == 32768;
		}
		return false;
	}

	private static bool smethod_8(Class873 propsCache)
	{
		if (propsCache.class2911_0 != null && propsCache.class2911_0.Value == 5)
		{
			return !smethod_9(propsCache);
		}
		return false;
	}

	private static bool smethod_9(Class873 propsCache)
	{
		if (propsCache.class2911_0 != null && propsCache.class2911_0.Value == 5 && propsCache.class2911_6 != null && propsCache.class2911_6.Value == 4294954596u && propsCache.class2911_7 != null)
		{
			return propsCache.class2911_7.Value == 4294954596u;
		}
		return false;
	}

	internal static void smethod_10(IPresetShadow presetShadow, Class2834 fopt, Class2837 tertiaryFopt, Class856 serializationContext)
	{
		if (presetShadow != null)
		{
			Class2944 properties = fopt.Properties;
			Class866.smethod_1(new Struct54(presetShadow.Distance, presetShadow.Direction), fopt);
			Class1049.smethod_8(presetShadow.ShadowColor, properties, Enum426.const_296, Enum426.const_299, serializationContext);
			switch (presetShadow.Preset)
			{
			case PresetShadowType.BackLeftLongPerspectiveShadow:
				properties.method_0(new Class2911(Enum426.const_295, 2u));
				properties.method_0(new Class2911(Enum426.const_305, 92680u));
				properties.method_0(new Class2911(Enum426.const_309, 4294967280u));
				properties.method_0(new Class2911(Enum426.const_311, 4294934528u));
				properties.method_0(new Class2911(Enum426.const_312, 32768u));
				break;
			case PresetShadowType.BackRightLongPerspectiveShadow:
				properties.method_0(new Class2911(Enum426.const_295, 2u));
				properties.method_0(new Class2911(Enum426.const_305, 4294874616u));
				properties.method_0(new Class2911(Enum426.const_309, 4294967280u));
				properties.method_0(new Class2911(Enum426.const_311, 32768u));
				properties.method_0(new Class2911(Enum426.const_312, 32768u));
				break;
			case PresetShadowType.TopLeftDoubleDropShadow:
				properties.method_0(new Class2911(Enum426.const_295, 1u));
				properties.method_0(new Class2911(Enum426.const_297, 275121139u));
				properties.method_0(new Class2911(Enum426.const_302, (properties[Enum426.const_300] as Class2911).Value * 2));
				properties.method_0(new Class2911(Enum426.const_303, (properties[Enum426.const_301] as Class2911).Value * 2));
				break;
			case PresetShadowType.FrontLeftLongPerspectiveShadow:
				properties.method_0(new Class2911(Enum426.const_295, 2u));
				properties.method_0(new Class2911(Enum426.const_305, 92680u));
				properties.method_0(new Class2911(Enum426.const_307, 4294901760u));
				properties.method_0(new Class2911(Enum426.const_309, 4294967280u));
				properties.method_0(new Class2911(Enum426.const_311, 4294934528u));
				properties.method_0(new Class2911(Enum426.const_312, 32768u));
				break;
			case PresetShadowType.FrontRightLongPerspectiveShadow:
				properties.method_0(new Class2911(Enum426.const_295, 2u));
				properties.method_0(new Class2911(Enum426.const_305, 4294874616u));
				properties.method_0(new Class2911(Enum426.const_307, 4294901760u));
				properties.method_0(new Class2911(Enum426.const_309, 4294967280u));
				properties.method_0(new Class2911(Enum426.const_311, 32768u));
				properties.method_0(new Class2911(Enum426.const_312, 32768u));
				break;
			case PresetShadowType.OuterBoxShadow3D:
			case PresetShadowType.InnerBoxShadow3D:
				properties.method_0(new Class2911(Enum426.const_295, 5u));
				properties.method_0(new Class2911(Enum426.const_297, 275121139u));
				properties.method_0(new Class2911(Enum426.const_302, (uint)(0uL - (ulong)(properties[Enum426.const_300] as Class2911).Value)));
				properties.method_0(new Class2911(Enum426.const_303, (uint)(0uL - (ulong)(properties[Enum426.const_301] as Class2911).Value)));
				break;
			case PresetShadowType.TopLeftDropShadow:
			case PresetShadowType.TopLeftLargeDropShadow:
			case PresetShadowType.BottomRightSmallDropShadow:
			case PresetShadowType.BackCenterPerspectiveShadow:
			case PresetShadowType.TopRightDropShadow:
			case PresetShadowType.FrontBottomShadow:
			case PresetShadowType.BackLeftPerspectiveShadow:
			case PresetShadowType.BackRightPerspectiveShadow:
			case PresetShadowType.BottomLeftDropShadow:
			case PresetShadowType.BottomRightDropShadow:
			case PresetShadowType.FrontLeftPerspectiveShadow:
			case PresetShadowType.FrontRightPerspectiveShadow:
			case PresetShadowType.TopLeftSmallDropShadow:
				break;
			}
		}
	}
}
