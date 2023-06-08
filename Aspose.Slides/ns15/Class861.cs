using Aspose.Slides;
using Aspose.Slides.Warnings;
using ns62;

namespace ns15;

internal class Class861
{
	internal static void smethod_0(ILightRig lightRig, Class2834 fopt, Class854 slideDeserializationContext)
	{
		Class2944 @class = ((fopt != null) ? fopt.Properties : new Class2944());
		Class2911 class2 = @class[Enum426.const_371] as Class2911;
		Class2911 class3 = @class[Enum426.const_372] as Class2911;
		Class2911 class4 = @class[Enum426.const_373] as Class2911;
		Class2911 class5 = @class[Enum426.const_374] as Class2911;
		Class2911 class6 = @class[Enum426.const_375] as Class2911;
		Class2911 class7 = @class[Enum426.const_379] as Class2911;
		Class2917 class8 = (@class[Enum426.const_380] as Class2917) ?? new Class2917();
		uint num = class2?.Value ?? 20000;
		uint num2 = class3?.Value ?? 50000;
		uint num3 = class4?.Value ?? 0;
		uint num4 = class6?.Value ?? 38000;
		uint num5 = class7?.Value ?? 38000;
		bool folded_fc3DKeyHarsh = class8.Folded_fc3DKeyHarsh;
		bool folded_fc3DFillHarsh = class8.Folded_fc3DFillHarsh;
		lightRig.LightType = LightRigPresetType.NotDefined;
		lightRig.Direction = LightingDirection.NotDefined;
		if (num2 == 4294917296u && num3 == 4294917296u)
		{
			if (num == 20000 && num4 == 38000 && num5 == 38000 && folded_fc3DKeyHarsh && !folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyFlat2;
				lightRig.Direction = LightingDirection.Top;
			}
			else if (num == 10000 && num4 == 44000 && num5 == 24000 && folded_fc3DKeyHarsh && !folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyNormal2;
				lightRig.Direction = LightingDirection.Top;
			}
			else if (num == 4000 && num4 == 52000 && num5 == 14000 && folded_fc3DKeyHarsh && folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyHarsh2;
				lightRig.Direction = LightingDirection.Top;
			}
		}
		else if (num2 == 4294917296u && num3 == 0)
		{
			if (num == 20000 && num4 == 38000 && num5 == 38000 && folded_fc3DKeyHarsh && !folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyFlat3;
				lightRig.Direction = LightingDirection.Top;
			}
			else if (num == 10000 && num4 == 44000 && num5 == 24000 && folded_fc3DKeyHarsh && !folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyNormal3;
				lightRig.Direction = LightingDirection.Top;
			}
			else if (num == 4000 && num4 == 52000 && num5 == 14000 && folded_fc3DKeyHarsh && folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyHarsh3;
				lightRig.Direction = LightingDirection.Top;
			}
		}
		else if (num2 == 4294917296u && num3 == 50000)
		{
			if (num == 20000 && num4 == 38000 && num5 == 38000 && folded_fc3DKeyHarsh && !folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyFlat4;
				lightRig.Direction = LightingDirection.Top;
			}
			else if (num == 10000 && num4 == 44000 && num5 == 24000 && folded_fc3DKeyHarsh && !folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyNormal4;
				lightRig.Direction = LightingDirection.Top;
			}
			else if (num == 4000 && num4 == 52000 && num5 == 14000 && folded_fc3DKeyHarsh && folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyHarsh4;
				lightRig.Direction = LightingDirection.Top;
			}
		}
		else if (num2 == 0 && num3 == 4294917296u)
		{
			if (num == 20000 && num4 == 38000 && num5 == 38000 && folded_fc3DKeyHarsh && !folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyFlat3;
				lightRig.Direction = LightingDirection.Right;
			}
			else if (num == 10000 && num4 == 44000 && num5 == 24000 && folded_fc3DKeyHarsh && !folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyNormal3;
				lightRig.Direction = LightingDirection.Right;
			}
			else if (num == 4000 && num4 == 52000 && num5 == 14000 && folded_fc3DKeyHarsh && folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyHarsh3;
				lightRig.Direction = LightingDirection.Right;
			}
		}
		else if (num2 == 0 && num3 == 50000)
		{
			if (num == 20000 && num4 == 38000 && num5 == 38000 && folded_fc3DKeyHarsh && !folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyFlat3;
				lightRig.Direction = LightingDirection.Left;
			}
			else if (num == 10000 && num4 == 44000 && num5 == 24000 && folded_fc3DKeyHarsh && !folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyNormal3;
				lightRig.Direction = LightingDirection.Left;
			}
			else if (num == 4000 && num4 == 52000 && num5 == 14000 && folded_fc3DKeyHarsh && folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyHarsh3;
				lightRig.Direction = LightingDirection.Left;
			}
		}
		else if (num2 == 50000 && num3 == 4294917296u)
		{
			if (num == 20000 && num4 == 38000 && num5 == 38000 && folded_fc3DKeyHarsh && !folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyFlat4;
				lightRig.Direction = LightingDirection.Bottom;
			}
			else if (num == 10000 && num4 == 44000 && num5 == 24000 && folded_fc3DKeyHarsh && !folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyNormal4;
				lightRig.Direction = LightingDirection.Bottom;
			}
			else if (num == 4000 && num4 == 52000 && num5 == 14000 && folded_fc3DKeyHarsh && folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyHarsh4;
				lightRig.Direction = LightingDirection.Bottom;
			}
		}
		else if (num2 == 50000 && num3 == 0)
		{
			if (num == 20000 && num4 == 38000 && num5 == 38000 && folded_fc3DKeyHarsh && !folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyFlat3;
				lightRig.Direction = LightingDirection.Bottom;
			}
			else if (num == 10000 && num4 == 44000 && num5 == 24000 && folded_fc3DKeyHarsh && !folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyNormal3;
				lightRig.Direction = LightingDirection.Bottom;
			}
			else if (num == 4000 && num4 == 52000 && num5 == 14000 && folded_fc3DKeyHarsh && folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyHarsh3;
				lightRig.Direction = LightingDirection.Bottom;
			}
		}
		else if (num2 == 50000 && num3 == 50000)
		{
			if (num == 20000 && num4 == 38000 && num5 == 38000 && folded_fc3DKeyHarsh && !folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyFlat2;
				lightRig.Direction = LightingDirection.Bottom;
			}
			else if (num == 10000 && num4 == 44000 && num5 == 24000 && folded_fc3DKeyHarsh && !folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyNormal2;
				lightRig.Direction = LightingDirection.Bottom;
			}
			else if (num == 4000 && num4 == 52000 && num5 == 14000 && folded_fc3DKeyHarsh && folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyHarsh2;
				lightRig.Direction = LightingDirection.Bottom;
			}
		}
		else if (num2 == 0 && num3 == 0)
		{
			if (num == 20000 && num4 == 38000 && num5 == 38000 && folded_fc3DKeyHarsh && !folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyFlat1;
				lightRig.Direction = LightingDirection.Top;
			}
			else if (num == 10000 && num4 == 44000 && num5 == 24000 && folded_fc3DKeyHarsh && !folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyNormal1;
				lightRig.Direction = LightingDirection.Top;
			}
			else if (num == 4000 && num4 == 52000 && num5 == 14000 && folded_fc3DKeyHarsh && folded_fc3DFillHarsh)
			{
				lightRig.LightType = LightRigPresetType.LegacyHarsh1;
				lightRig.Direction = LightingDirection.Top;
			}
		}
		if (lightRig.LightType == LightRigPresetType.NotDefined || lightRig.Direction == LightingDirection.NotDefined)
		{
			lightRig.LightType = LightRigPresetType.LegacyFlat1;
			lightRig.Direction = LightingDirection.Right;
			((LightRig)lightRig).IsRigDirLoadedApproximately = true;
		}
		if (class5 != null)
		{
			slideDeserializationContext.DeserializationContext.DomPresentation.LoadOptions.method_1("Deserialization of the Style3Dc3DKeyZ is not imlemented yet.", WarningType.MinorFormattingLoss);
		}
		_ = @class[Enum426.const_376];
		_ = @class[Enum426.const_377];
		_ = @class[Enum426.const_378];
	}

	internal static void smethod_1(ILightRig lightRig, Class2834 fopt, Class856 serializationContext)
	{
		Class2944 properties = fopt.Properties;
		if (lightRig.LightType != LightRigPresetType.NotDefined)
		{
			Class2917 @class = properties[Enum426.const_380] as Class2917;
			if (lightRig.LightType == LightRigPresetType.LegacyFlat2 && lightRig.Direction == LightingDirection.Top)
			{
				properties.method_0(new Class2911(Enum426.const_372, 4294917296u));
				properties.method_0(new Class2911(Enum426.const_373, 4294917296u));
				properties.Remove(Enum426.const_371);
				properties.Remove(Enum426.const_375);
				properties.method_0(new Class2911(Enum426.const_376, 50000u));
				properties.Remove(Enum426.const_377);
				properties.Remove(Enum426.const_379);
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = false;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyNormal2 && lightRig.Direction == LightingDirection.Top)
			{
				properties.method_0(new Class2911(Enum426.const_372, 4294917296u));
				properties.method_0(new Class2911(Enum426.const_373, 4294917296u));
				properties.method_0(new Class2911(Enum426.const_371, 10000u));
				properties.method_0(new Class2911(Enum426.const_375, 44000u));
				properties.method_0(new Class2911(Enum426.const_376, 50000u));
				properties.Remove(Enum426.const_377);
				properties.method_0(new Class2911(Enum426.const_379, 24000u));
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = false;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyHarsh2 && lightRig.Direction == LightingDirection.Top)
			{
				properties.method_0(new Class2911(Enum426.const_372, 4294917296u));
				properties.method_0(new Class2911(Enum426.const_373, 4294917296u));
				properties.method_0(new Class2911(Enum426.const_371, 4000u));
				properties.method_0(new Class2911(Enum426.const_375, 52000u));
				properties.method_0(new Class2911(Enum426.const_376, 50000u));
				properties.Remove(Enum426.const_377);
				properties.method_0(new Class2911(Enum426.const_379, 14000u));
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = true;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyFlat3 && lightRig.Direction == LightingDirection.Top)
			{
				properties.method_0(new Class2911(Enum426.const_372, 4294917296u));
				properties.Remove(Enum426.const_373);
				properties.Remove(Enum426.const_371);
				properties.Remove(Enum426.const_375);
				properties.method_0(new Class2911(Enum426.const_376, 50000u));
				properties.Remove(Enum426.const_377);
				properties.Remove(Enum426.const_379);
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = false;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyNormal3 && lightRig.Direction == LightingDirection.Top)
			{
				properties.method_0(new Class2911(Enum426.const_372, 4294917296u));
				properties.Remove(Enum426.const_373);
				properties.method_0(new Class2911(Enum426.const_371, 10000u));
				properties.method_0(new Class2911(Enum426.const_375, 44000u));
				properties.method_0(new Class2911(Enum426.const_376, 50000u));
				properties.Remove(Enum426.const_377);
				properties.method_0(new Class2911(Enum426.const_379, 24000u));
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = false;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyHarsh3 && lightRig.Direction == LightingDirection.Top)
			{
				properties.method_0(new Class2911(Enum426.const_372, 4294917296u));
				properties.Remove(Enum426.const_373);
				properties.method_0(new Class2911(Enum426.const_371, 4000u));
				properties.method_0(new Class2911(Enum426.const_375, 52000u));
				properties.method_0(new Class2911(Enum426.const_376, 50000u));
				properties.Remove(Enum426.const_377);
				properties.method_0(new Class2911(Enum426.const_379, 14000u));
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = true;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyFlat4 && lightRig.Direction == LightingDirection.Top)
			{
				properties.method_0(new Class2911(Enum426.const_372, 4294917296u));
				properties.method_0(new Class2911(Enum426.const_373, 50000u));
				properties.Remove(Enum426.const_371);
				properties.Remove(Enum426.const_375);
				properties.method_0(new Class2911(Enum426.const_376, 50000u));
				properties.Remove(Enum426.const_377);
				properties.Remove(Enum426.const_379);
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = false;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyNormal4 && lightRig.Direction == LightingDirection.Top)
			{
				properties.method_0(new Class2911(Enum426.const_372, 4294917296u));
				properties.method_0(new Class2911(Enum426.const_373, 50000u));
				properties.method_0(new Class2911(Enum426.const_371, 10000u));
				properties.method_0(new Class2911(Enum426.const_375, 44000u));
				properties.method_0(new Class2911(Enum426.const_376, 50000u));
				properties.Remove(Enum426.const_377);
				properties.method_0(new Class2911(Enum426.const_379, 24000u));
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = false;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyHarsh4 && lightRig.Direction == LightingDirection.Top)
			{
				properties.method_0(new Class2911(Enum426.const_372, 4294917296u));
				properties.method_0(new Class2911(Enum426.const_373, 50000u));
				properties.method_0(new Class2911(Enum426.const_371, 4000u));
				properties.method_0(new Class2911(Enum426.const_375, 52000u));
				properties.method_0(new Class2911(Enum426.const_376, 50000u));
				properties.Remove(Enum426.const_377);
				properties.method_0(new Class2911(Enum426.const_379, 14000u));
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = true;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyFlat3 && lightRig.Direction == LightingDirection.Right)
			{
				properties.method_0(new Class2911(Enum426.const_372, 0u));
				properties.method_0(new Class2911(Enum426.const_373, 4294917296u));
				properties.Remove(Enum426.const_371);
				properties.Remove(Enum426.const_375);
				properties.method_0(new Class2911(Enum426.const_376, 0u));
				properties.method_0(new Class2911(Enum426.const_377, 50000u));
				properties.Remove(Enum426.const_379);
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = false;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyNormal3 && lightRig.Direction == LightingDirection.Right)
			{
				properties.method_0(new Class2911(Enum426.const_372, 0u));
				properties.method_0(new Class2911(Enum426.const_373, 4294917296u));
				properties.method_0(new Class2911(Enum426.const_371, 10000u));
				properties.method_0(new Class2911(Enum426.const_375, 44000u));
				properties.method_0(new Class2911(Enum426.const_376, 0u));
				properties.method_0(new Class2911(Enum426.const_377, 50000u));
				properties.method_0(new Class2911(Enum426.const_379, 24000u));
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = false;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyHarsh3 && lightRig.Direction == LightingDirection.Right)
			{
				properties.method_0(new Class2911(Enum426.const_372, 0u));
				properties.method_0(new Class2911(Enum426.const_373, 4294917296u));
				properties.method_0(new Class2911(Enum426.const_371, 4000u));
				properties.method_0(new Class2911(Enum426.const_375, 52000u));
				properties.method_0(new Class2911(Enum426.const_376, 0u));
				properties.method_0(new Class2911(Enum426.const_377, 50000u));
				properties.method_0(new Class2911(Enum426.const_379, 14000u));
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = true;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyFlat3 && lightRig.Direction == LightingDirection.Left)
			{
				properties.method_0(new Class2911(Enum426.const_372, 0u));
				properties.method_0(new Class2911(Enum426.const_373, 50000u));
				properties.Remove(Enum426.const_371);
				properties.Remove(Enum426.const_375);
				properties.method_0(new Class2911(Enum426.const_376, 0u));
				properties.method_0(new Class2911(Enum426.const_377, 4294917296u));
				properties.Remove(Enum426.const_379);
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = false;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyNormal3 && lightRig.Direction == LightingDirection.Left)
			{
				properties.method_0(new Class2911(Enum426.const_372, 0u));
				properties.method_0(new Class2911(Enum426.const_373, 50000u));
				properties.method_0(new Class2911(Enum426.const_371, 10000u));
				properties.method_0(new Class2911(Enum426.const_375, 44000u));
				properties.method_0(new Class2911(Enum426.const_376, 0u));
				properties.method_0(new Class2911(Enum426.const_377, 4294917296u));
				properties.method_0(new Class2911(Enum426.const_379, 24000u));
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = false;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyHarsh3 && lightRig.Direction == LightingDirection.Left)
			{
				properties.method_0(new Class2911(Enum426.const_372, 0u));
				properties.method_0(new Class2911(Enum426.const_373, 50000u));
				properties.method_0(new Class2911(Enum426.const_371, 4000u));
				properties.method_0(new Class2911(Enum426.const_375, 52000u));
				properties.method_0(new Class2911(Enum426.const_376, 0u));
				properties.method_0(new Class2911(Enum426.const_377, 4294917296u));
				properties.method_0(new Class2911(Enum426.const_379, 14000u));
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = true;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyFlat4 && lightRig.Direction == LightingDirection.Bottom)
			{
				properties.Remove(Enum426.const_372);
				properties.method_0(new Class2911(Enum426.const_373, 4294917296u));
				properties.Remove(Enum426.const_371);
				properties.Remove(Enum426.const_375);
				properties.Remove(Enum426.const_376);
				properties.Remove(Enum426.const_377);
				properties.Remove(Enum426.const_379);
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = false;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyNormal4 && lightRig.Direction == LightingDirection.Bottom)
			{
				properties.Remove(Enum426.const_372);
				properties.method_0(new Class2911(Enum426.const_373, 4294917296u));
				properties.method_0(new Class2911(Enum426.const_371, 10000u));
				properties.method_0(new Class2911(Enum426.const_375, 44000u));
				properties.Remove(Enum426.const_376);
				properties.Remove(Enum426.const_377);
				properties.method_0(new Class2911(Enum426.const_379, 24000u));
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = false;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyHarsh4 && lightRig.Direction == LightingDirection.Bottom)
			{
				properties.Remove(Enum426.const_372);
				properties.method_0(new Class2911(Enum426.const_373, 4294917296u));
				properties.method_0(new Class2911(Enum426.const_371, 4000u));
				properties.method_0(new Class2911(Enum426.const_375, 52000u));
				properties.Remove(Enum426.const_376);
				properties.Remove(Enum426.const_377);
				properties.method_0(new Class2911(Enum426.const_379, 14000u));
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = true;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyFlat3 && lightRig.Direction == LightingDirection.Bottom)
			{
				properties.Remove(Enum426.const_372);
				properties.Remove(Enum426.const_373);
				properties.Remove(Enum426.const_371);
				properties.Remove(Enum426.const_375);
				properties.Remove(Enum426.const_376);
				properties.Remove(Enum426.const_377);
				properties.Remove(Enum426.const_379);
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = false;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyNormal3 && lightRig.Direction == LightingDirection.Bottom)
			{
				properties.Remove(Enum426.const_372);
				properties.Remove(Enum426.const_373);
				properties.method_0(new Class2911(Enum426.const_371, 10000u));
				properties.method_0(new Class2911(Enum426.const_375, 44000u));
				properties.Remove(Enum426.const_376);
				properties.Remove(Enum426.const_377);
				properties.method_0(new Class2911(Enum426.const_379, 24000u));
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = false;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyHarsh3 && lightRig.Direction == LightingDirection.Bottom)
			{
				properties.Remove(Enum426.const_372);
				properties.Remove(Enum426.const_373);
				properties.method_0(new Class2911(Enum426.const_371, 4000u));
				properties.method_0(new Class2911(Enum426.const_375, 52000u));
				properties.Remove(Enum426.const_376);
				properties.Remove(Enum426.const_377);
				properties.method_0(new Class2911(Enum426.const_379, 14000u));
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = true;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyFlat2 && lightRig.Direction == LightingDirection.Bottom)
			{
				properties.Remove(Enum426.const_372);
				properties.method_0(new Class2911(Enum426.const_373, 50000u));
				properties.Remove(Enum426.const_371);
				properties.Remove(Enum426.const_375);
				properties.Remove(Enum426.const_376);
				properties.Remove(Enum426.const_377);
				properties.Remove(Enum426.const_379);
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = false;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyNormal2 && lightRig.Direction == LightingDirection.Bottom)
			{
				properties.Remove(Enum426.const_372);
				properties.method_0(new Class2911(Enum426.const_373, 50000u));
				properties.method_0(new Class2911(Enum426.const_371, 10000u));
				properties.method_0(new Class2911(Enum426.const_375, 44000u));
				properties.Remove(Enum426.const_376);
				properties.Remove(Enum426.const_377);
				properties.method_0(new Class2911(Enum426.const_379, 24000u));
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = false;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyHarsh2 && lightRig.Direction == LightingDirection.Bottom)
			{
				properties.Remove(Enum426.const_372);
				properties.method_0(new Class2911(Enum426.const_373, 50000u));
				properties.method_0(new Class2911(Enum426.const_371, 4000u));
				properties.method_0(new Class2911(Enum426.const_375, 52000u));
				properties.Remove(Enum426.const_376);
				properties.Remove(Enum426.const_377);
				properties.method_0(new Class2911(Enum426.const_379, 14000u));
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = true;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyFlat1 && lightRig.Direction == LightingDirection.Top)
			{
				properties.method_0(new Class2911(Enum426.const_372, 0u));
				properties.Remove(Enum426.const_373);
				properties.Remove(Enum426.const_371);
				properties.Remove(Enum426.const_375);
				properties.method_0(new Class2911(Enum426.const_376, 0u));
				properties.Remove(Enum426.const_377);
				properties.Remove(Enum426.const_379);
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = false;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyNormal1 && lightRig.Direction == LightingDirection.Top)
			{
				properties.method_0(new Class2911(Enum426.const_372, 0u));
				properties.Remove(Enum426.const_373);
				properties.method_0(new Class2911(Enum426.const_371, 10000u));
				properties.method_0(new Class2911(Enum426.const_375, 44000u));
				properties.method_0(new Class2911(Enum426.const_376, 0u));
				properties.Remove(Enum426.const_377);
				properties.method_0(new Class2911(Enum426.const_379, 24000u));
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = false;
			}
			else if (lightRig.LightType == LightRigPresetType.LegacyHarsh1 && lightRig.Direction == LightingDirection.Top)
			{
				properties.method_0(new Class2911(Enum426.const_372, 0u));
				properties.Remove(Enum426.const_373);
				properties.method_0(new Class2911(Enum426.const_371, 4000u));
				properties.method_0(new Class2911(Enum426.const_375, 52000u));
				properties.method_0(new Class2911(Enum426.const_376, 0u));
				properties.Remove(Enum426.const_377);
				properties.method_0(new Class2911(Enum426.const_379, 14000u));
				@class.Folded_fc3DKeyHarsh = true;
				@class.Folded_fc3DFillHarsh = true;
			}
			else if (lightRig.LightType != LightRigPresetType.LegacyFlat1 || lightRig.Direction != LightingDirection.Right || !((LightRig)lightRig).IsRigDirLoadedApproximately)
			{
				serializationContext.method_15("Serialization of the non-Legacy combinations of lightRig.LightType and lightRig.Direction into metroBlob is not imlemented yet.", WarningType.MinorFormattingLoss);
			}
			float[] rotation = lightRig.GetRotation();
			if (rotation[0] != 0f || rotation[1] != 0f || rotation[2] != 0f)
			{
				serializationContext.method_15("Serialization of the lightRig Rotation is not imlemented yet.", WarningType.MinorFormattingLoss);
			}
		}
	}
}
