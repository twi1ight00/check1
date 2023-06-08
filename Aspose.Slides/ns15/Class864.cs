using System;
using Aspose.Slides;
using Aspose.Slides.Warnings;
using ns24;
using ns62;

namespace ns15;

internal class Class864
{
	internal static void smethod_0(IThreeDFormat threeDFormat, Class2834 fopt, Class2837 tertiaryFopt, Class854 slideDeserializationContext)
	{
		Class2944 @class = ((fopt != null) ? fopt.Properties : new Class2944());
		Class2915 class2 = @class[Enum426.const_352] as Class2915;
		if (!(class2 == null) && class2.AfUsef3D && class2.Ef3D)
		{
			Class2911 class3 = @class[Enum426.const_342] as Class2911;
			Class2911 class4 = @class[Enum426.const_343] as Class2911;
			Class2911 class5 = @class[Enum426.const_345] as Class2911;
			Class2911 class6 = @class[Enum426.const_338] as Class2911;
			Class2911 class7 = @class[Enum426.const_339] as Class2911;
			Class2911 class8 = @class[Enum426.const_340] as Class2911;
			Class2911 class9 = @class[Enum426.const_359] as Class2911;
			Class2911 class10 = @class[Enum426.const_360] as Class2911;
			Class2911 class11 = @class[Enum426.const_361] as Class2911;
			Class2911 class12 = @class[Enum426.const_362] as Class2911;
			Class359 pPTXUnsupportedProps = ((ThreeDFormat)threeDFormat).PPTXUnsupportedProps;
			int num = (int)(class3?.Value ?? 0);
			int num2 = -num + (int)(class4?.Value ?? 457200);
			threeDFormat.ExtrusionHeight = (double)(num2 - 13500 - 13500) / 12700.0;
			threeDFormat.BevelTop.Width = 1.062992125984252;
			threeDFormat.BevelTop.Height = 1.062992125984252;
			threeDFormat.BevelTop.BevelType = BevelPresetType.Angle;
			threeDFormat.BevelBottom.Width = 1.062992125984252;
			threeDFormat.BevelBottom.Height = 1.062992125984252;
			threeDFormat.BevelBottom.BevelType = BevelPresetType.Angle;
			threeDFormat.Depth = (double)num / 12700.0;
			uint num3 = class6?.Value ?? 0;
			uint num4 = class7?.Value ?? 65536;
			uint num5 = class8?.Value ?? 5;
			uint num6 = class12?.Value ?? 0;
			if (num3 == 80000 && num4 == 65536 && num5 == 5 && num6 == 0)
			{
				threeDFormat.Material = MaterialPresetType.LegacyPlastic;
			}
			else if (num3 == 80000 && num4 == 43712 && num5 == 5 && num6 == 0)
			{
				threeDFormat.Material = MaterialPresetType.LegacyMetal;
			}
			else if (num3 == 0 && num4 == 0 && num5 == 0 && num6 == 1)
			{
				threeDFormat.Material = MaterialPresetType.LegacyWireframe;
			}
			else
			{
				threeDFormat.Material = MaterialPresetType.LegacyMatte;
			}
			if (class9 != null || class10 != null || class11 != null)
			{
				slideDeserializationContext.DeserializationContext.DomPresentation.LoadOptions.method_1("Deserialization of some ThreeDFormat ppt data (Style3Dc3DRotationCenterX, ..Y, ..Z) is not imlemented yet.", WarningType.MinorFormattingLoss);
			}
			Class1049.smethod_1(threeDFormat.ExtrusionColor, class5?.Value ?? 268435703, 1.0);
			Class859.smethod_0(threeDFormat.Camera, fopt, slideDeserializationContext);
			Class861.smethod_0(threeDFormat.LightRig, fopt, slideDeserializationContext);
			Class860.smethod_0(pPTXUnsupportedProps.BackdropPlane, fopt, tertiaryFopt);
		}
	}

	internal static void smethod_1(IThreeDFormat threeDFormat, Class2834 fopt, Class2837 tertiaryFopt, Class856 serializationContext)
	{
		Class2944 properties = fopt.Properties;
		if (threeDFormat == null)
		{
			for (int i = 640; i < 653; i++)
			{
				properties.Remove((Enum426)i);
			}
			properties.Remove(Enum426.const_352);
			for (int j = 704; j < 730; j++)
			{
				properties.Remove((Enum426)j);
			}
			properties.Remove(Enum426.const_380);
			return;
		}
		bool flag = false;
		Class2915 @class = new Class2915();
		@class.AfUsef3D = true;
		@class.BfUsefc3DMetallic = true;
		@class.CfUsefc3DUseExtrusionColor = true;
		@class.Ef3D = true;
		@class.Gfc3DUseExtrusionColor = true;
		properties.method_0(@class);
		Class2917 property = new Class2917();
		properties.method_0(property);
		Class359 pPTXUnsupportedProps = ((ThreeDFormat)threeDFormat).PPTXUnsupportedProps;
		if (threeDFormat.Camera.CameraType != CameraPresetType.NotDefined || threeDFormat.LightRig.LightType != LightRigPresetType.NotDefined)
		{
			Class859.smethod_1(threeDFormat.Camera, fopt, serializationContext);
			Class861.smethod_1(threeDFormat.LightRig, fopt, serializationContext);
			Class860.smethod_1(pPTXUnsupportedProps.BackdropPlane, fopt, tertiaryFopt, serializationContext);
			flag = true;
		}
		if (threeDFormat.ContourWidth != 0.0 || threeDFormat.ExtrusionHeight != 0.0 || threeDFormat.BevelTop.BevelType != BevelPresetType.NotDefined || threeDFormat.BevelBottom.BevelType != BevelPresetType.NotDefined)
		{
			if (!(Math.Abs(threeDFormat.BevelTop.Width - 1.062992125984252) > 1E-06) && !(Math.Abs(threeDFormat.BevelTop.Height - 1.062992125984252) > 1E-06) && threeDFormat.BevelTop.BevelType == BevelPresetType.Angle && !(Math.Abs(threeDFormat.BevelBottom.Width - 1.062992125984252) > 1E-06) && !(Math.Abs(threeDFormat.BevelBottom.Height - 1.062992125984252) > 1E-06) && threeDFormat.BevelBottom.BevelType == BevelPresetType.Angle)
			{
				int num = (int)(threeDFormat.Depth * 12700.0);
				if (num != 0)
				{
					properties.method_0(new Class2911(Enum426.const_342, (uint)num));
				}
				uint num2 = (uint)(threeDFormat.ExtrusionHeight * 12700.0 + 13500.0 + 13500.0 + (double)num);
				if (num2 != 457200)
				{
					properties.method_0(new Class2911(Enum426.const_343, num2));
				}
				flag = true;
			}
			else
			{
				serializationContext.method_15("Ppt serialization of the Bevel is not imlemented yet.", WarningType.MajorFormattingLoss);
			}
			if (threeDFormat.ExtrusionColor.ColorType != ColorType.NotDefined)
			{
				uint num3 = Class1049.smethod_7(threeDFormat.ExtrusionColor, serializationContext);
				if (num3 != 268435703)
				{
					properties.method_0(new Class2911(Enum426.const_345, num3));
				}
				flag = true;
			}
		}
		if (threeDFormat.Material != MaterialPresetType.NotDefined && threeDFormat.Material != MaterialPresetType.LegacyMatte)
		{
			if (threeDFormat.Material == MaterialPresetType.LegacyPlastic)
			{
				properties.method_0(new Class2911(Enum426.const_338, 80000u));
				properties.Remove(Enum426.const_339);
				properties.Remove(Enum426.const_340);
				flag = true;
			}
			else if (threeDFormat.Material == MaterialPresetType.LegacyMetal)
			{
				properties.method_0(new Class2911(Enum426.const_338, 80000u));
				properties.method_0(new Class2911(Enum426.const_339, 43712u));
				properties.Remove(Enum426.const_340);
				@class.Ffc3DMetallic = true;
				flag = true;
			}
			else if (threeDFormat.Material == MaterialPresetType.LegacyWireframe)
			{
				properties.Remove(Enum426.const_338);
				properties.method_0(new Class2911(Enum426.const_339, 0u));
				properties.method_0(new Class2911(Enum426.const_340, 0u));
				properties.method_0(new Class2911(Enum426.const_362, 1u));
				flag = true;
			}
			else
			{
				serializationContext.method_15("Ppt serialization of the non-Legacy material is not imlemented yet.", WarningType.MinorFormattingLoss);
			}
		}
		else
		{
			properties.Remove(Enum426.const_338);
			properties.Remove(Enum426.const_339);
			properties.Remove(Enum426.const_340);
			if (threeDFormat.Material == MaterialPresetType.LegacyMatte)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			properties.Remove(Enum426.const_352);
			properties.Remove(Enum426.const_380);
		}
	}
}
