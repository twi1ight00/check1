using Aspose.Slides;
using Aspose.Slides.Warnings;
using ns22;
using ns62;

namespace ns15;

internal class Class859
{
	internal static void smethod_0(ICamera camera, Class2834 fopt, Class854 slideDeserializationContext)
	{
		Class2944 @class = ((fopt != null) ? fopt.Properties : new Class2944());
		Class269 pPTUnsupportedProps = ((Camera)camera).PPTUnsupportedProps;
		Class2911 class2 = @class[Enum426.const_353] as Class2911;
		Class2911 class3 = @class[Enum426.const_354] as Class2911;
		Class2911 class4 = @class[Enum426.const_364] as Class2911;
		Class2911 class5 = @class[Enum426.const_365] as Class2911;
		Class2911 class6 = @class[Enum426.const_367] as Class2911;
		Class2911 class7 = @class[Enum426.const_368] as Class2911;
		Class2917 class8 = (@class[Enum426.const_380] as Class2917) ?? new Class2917();
		uint num = class4?.Value ?? 1250000;
		uint num2 = (uint)(((int?)class5?.Value) ?? (-1250000));
		uint num3 = class6?.Value ?? 32768;
		uint num4 = (uint)(((int?)class7?.Value) ?? (-32768));
		if (num == 4293717296u && num2 == 4293717296u && num3 == 4294934528u && num4 == 4294934528u)
		{
			camera.CameraType = ((!class8.Folded_fc3DParallel) ? CameraPresetType.LegacyPerspectiveTopLeft : CameraPresetType.LegacyObliqueTopLeft);
		}
		else if (num == 0 && num2 == 4293717296u && num3 == 0 && num4 == 4294934528u)
		{
			camera.CameraType = ((!class8.Folded_fc3DParallel) ? CameraPresetType.LegacyPerspectiveTop : CameraPresetType.LegacyObliqueTop);
		}
		else if (num == 1250000 && num2 == 4293717296u && num3 == 32768 && num4 == 4294934528u)
		{
			camera.CameraType = ((!class8.Folded_fc3DParallel) ? CameraPresetType.LegacyPerspectiveTopRight : CameraPresetType.LegacyObliqueTopRight);
		}
		else if (num == 4293717296u && num2 == 0 && num3 == 4294934528u && num4 == 0)
		{
			camera.CameraType = ((!class8.Folded_fc3DParallel) ? CameraPresetType.LegacyPerspectiveLeft : CameraPresetType.LegacyObliqueLeft);
		}
		else if (num == 0 && num2 == 0 && num3 == 0 && num4 == 0)
		{
			camera.CameraType = ((!class8.Folded_fc3DParallel) ? CameraPresetType.LegacyPerspectiveFront : CameraPresetType.LegacyObliqueFront);
		}
		else if (num == 1250000 && num2 == 0 && num3 == 32768 && num4 == 0)
		{
			camera.CameraType = ((!class8.Folded_fc3DParallel) ? CameraPresetType.LegacyPerspectiveRight : CameraPresetType.LegacyObliqueRight);
		}
		else if (num == 4293717296u && num2 == 1250000 && num3 == 4294934528u && num4 == 32768)
		{
			camera.CameraType = ((!class8.Folded_fc3DParallel) ? CameraPresetType.LegacyPerspectiveBottomLeft : CameraPresetType.LegacyObliqueBottomLeft);
		}
		else if (num == 0 && num2 == 1250000 && num3 == 0 && num4 == 32768)
		{
			camera.CameraType = ((!class8.Folded_fc3DParallel) ? CameraPresetType.LegacyPerspectiveBottom : CameraPresetType.LegacyObliqueBottom);
		}
		else if (num == 1250000 && num2 == 1250000 && num3 == 32768 && num4 == 32768)
		{
			camera.CameraType = ((!class8.Folded_fc3DParallel) ? CameraPresetType.LegacyPerspectiveBottomRight : CameraPresetType.LegacyObliqueBottomRight);
		}
		else
		{
			camera.CameraType = ((!class8.Folded_fc3DParallel) ? CameraPresetType.LegacyPerspectiveTopLeft : CameraPresetType.LegacyObliqueTopLeft);
			pPTUnsupportedProps.IsCameraTypeLoadedApproximately = true;
		}
		if (class8.Folded_fc3DConstrainRotation)
		{
			int num5 = (int)(class3?.Value ?? 0);
			int num6 = (int)(class2?.Value ?? 0);
			int num7 = 0;
			float num8 = (float)(-num5) / 65536f;
			if (num8 < 0f)
			{
				num8 += 360f;
			}
			float num9 = (float)num6 / 65536f;
			if (num9 < 0f)
			{
				num9 += 360f;
			}
			camera.SetRotation(num8, num9, (float)num7 / 65536f);
		}
		else
		{
			slideDeserializationContext.DeserializationContext.DomPresentation.LoadOptions.method_1("Deserialization of the Style3Dc3DRotationAxisX, ..AxisY, ..AxisZ, ..Angle Camera data is not imlemented yet.", WarningType.MajorFormattingLoss);
		}
	}

	internal static void smethod_1(ICamera camera, Class2834 fopt, Class856 serializationContext)
	{
		Class2944 properties = fopt.Properties;
		Class269 pPTUnsupportedProps = ((Camera)camera).PPTUnsupportedProps;
		if (pPTUnsupportedProps.IsCameraTypeChangedAfterLoading)
		{
			properties.Remove(Enum426.const_366);
			properties.Remove(Enum426.const_369);
			properties.Remove(Enum426.const_370);
		}
		properties.Remove(Enum426.const_353);
		properties.Remove(Enum426.const_354);
		if (camera.CameraType == CameraPresetType.NotDefined)
		{
			return;
		}
		Class2917 @class = properties[Enum426.const_380] as Class2917;
		switch (camera.CameraType)
		{
		default:
			serializationContext.method_15("Serialization of the non-Legacy CameraPreset types into metroBlob is not imlemented yet.", WarningType.MajorFormattingLoss);
			break;
		case CameraPresetType.LegacyObliqueBottom:
		case CameraPresetType.LegacyPerspectiveBottom:
			properties.method_0(new Class2911(Enum426.const_364, 0u));
			properties.method_0(new Class2911(Enum426.const_365, 1250000u));
			properties.method_0(new Class2911(Enum426.const_367, 0u));
			properties.method_0(new Class2911(Enum426.const_368, 32768u));
			if (pPTUnsupportedProps.IsCameraTypeChangedAfterLoading)
			{
				properties.method_0(new Class2911(Enum426.const_369, 5898240u));
			}
			@class.Folded_fc3DParallel = camera.CameraType == CameraPresetType.LegacyObliqueBottom;
			break;
		case CameraPresetType.LegacyObliqueBottomLeft:
		case CameraPresetType.LegacyPerspectiveBottomLeft:
			properties.method_0(new Class2911(Enum426.const_364, 4293717296u));
			properties.method_0(new Class2911(Enum426.const_365, 1250000u));
			properties.method_0(new Class2911(Enum426.const_367, 4294934528u));
			properties.method_0(new Class2911(Enum426.const_368, 32768u));
			if (pPTUnsupportedProps.IsCameraTypeChangedAfterLoading)
			{
				properties.method_0(new Class2911(Enum426.const_369, 2949120u));
			}
			@class.Folded_fc3DParallel = camera.CameraType == CameraPresetType.LegacyObliqueBottomLeft;
			break;
		case CameraPresetType.LegacyObliqueBottomRight:
		case CameraPresetType.LegacyPerspectiveBottomRight:
			properties.Remove(Enum426.const_364);
			properties.method_0(new Class2911(Enum426.const_365, 1250000u));
			properties.Remove(Enum426.const_367);
			properties.method_0(new Class2911(Enum426.const_368, 32768u));
			if (pPTUnsupportedProps.IsCameraTypeChangedAfterLoading)
			{
				properties.method_0(new Class2911(Enum426.const_369, 8847360u));
			}
			@class.Folded_fc3DParallel = camera.CameraType == CameraPresetType.LegacyObliqueBottomRight;
			break;
		case CameraPresetType.LegacyObliqueFront:
		case CameraPresetType.LegacyPerspectiveFront:
			properties.method_0(new Class2911(Enum426.const_364, 0u));
			properties.method_0(new Class2911(Enum426.const_365, 0u));
			properties.method_0(new Class2911(Enum426.const_367, 0u));
			properties.method_0(new Class2911(Enum426.const_368, 0u));
			if (pPTUnsupportedProps.IsCameraTypeChangedAfterLoading)
			{
				properties.method_0(new Class2911(Enum426.const_369, 0u));
			}
			@class.Folded_fc3DParallel = camera.CameraType == CameraPresetType.LegacyObliqueFront;
			break;
		case CameraPresetType.LegacyObliqueLeft:
		case CameraPresetType.LegacyPerspectiveLeft:
			properties.method_0(new Class2911(Enum426.const_364, 4293717296u));
			properties.method_0(new Class2911(Enum426.const_365, 0u));
			properties.method_0(new Class2911(Enum426.const_367, 4294934528u));
			properties.method_0(new Class2911(Enum426.const_368, 0u));
			if (pPTUnsupportedProps.IsCameraTypeChangedAfterLoading)
			{
				properties.method_0(new Class2911(Enum426.const_369, 4271374336u));
			}
			@class.Folded_fc3DParallel = camera.CameraType == CameraPresetType.LegacyObliqueLeft;
			break;
		case CameraPresetType.LegacyObliqueRight:
		case CameraPresetType.LegacyPerspectiveRight:
			properties.Remove(Enum426.const_364);
			properties.method_0(new Class2911(Enum426.const_365, 0u));
			properties.Remove(Enum426.const_367);
			properties.method_0(new Class2911(Enum426.const_368, 0u));
			if (pPTUnsupportedProps.IsCameraTypeChangedAfterLoading)
			{
				properties.method_0(new Class2911(Enum426.const_369, 11796480u));
			}
			@class.Folded_fc3DParallel = camera.CameraType == CameraPresetType.LegacyObliqueRight;
			break;
		case CameraPresetType.LegacyObliqueTop:
		case CameraPresetType.LegacyPerspectiveTop:
			properties.method_0(new Class2911(Enum426.const_364, 0u));
			properties.Remove(Enum426.const_365);
			properties.method_0(new Class2911(Enum426.const_367, 0u));
			properties.Remove(Enum426.const_368);
			if (pPTUnsupportedProps.IsCameraTypeChangedAfterLoading)
			{
				properties.method_0(new Class2911(Enum426.const_369, 4289069056u));
			}
			@class.Folded_fc3DParallel = camera.CameraType == CameraPresetType.LegacyObliqueTop;
			break;
		case CameraPresetType.LegacyObliqueTopLeft:
		case CameraPresetType.LegacyPerspectiveTopLeft:
			if (!pPTUnsupportedProps.IsCameraTypeLoadedApproximately || pPTUnsupportedProps.IsCameraTypeChangedAfterLoading)
			{
				properties.method_0(new Class2911(Enum426.const_364, 4293717296u));
				properties.method_0(new Class2911(Enum426.const_367, 4294934528u));
				properties.method_0(new Class2911(Enum426.const_369, 4292018176u));
				@class.Folded_fc3DParallel = camera.CameraType == CameraPresetType.LegacyObliqueTopLeft;
			}
			break;
		case CameraPresetType.LegacyObliqueTopRight:
		case CameraPresetType.LegacyPerspectiveTopRight:
			properties.Remove(Enum426.const_364);
			properties.Remove(Enum426.const_365);
			properties.Remove(Enum426.const_367);
			properties.Remove(Enum426.const_368);
			@class.Folded_fc3DParallel = camera.CameraType == CameraPresetType.LegacyObliqueTopRight;
			break;
		case CameraPresetType.NotDefined:
			break;
		}
		float[] rotation = camera.GetRotation();
		if (rotation != null)
		{
			int num = (int)((double)(0f - rotation[0]) * 65536.0);
			if (num != 0)
			{
				properties.Add(new Class2911(Enum426.const_354, (uint)num));
			}
			int num2 = (int)((double)rotation[1] * 65536.0);
			if (num2 != 0)
			{
				properties.Add(new Class2911(Enum426.const_353, (uint)num2));
			}
		}
	}
}
