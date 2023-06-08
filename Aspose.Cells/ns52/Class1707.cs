using System;
using Aspose.Cells;
using Aspose.Cells.Drawing;

namespace ns52;

internal class Class1707
{
	internal static GradientStopCollection smethod_0(GradientFill gradientFill_0, GradientPresetType gradientPresetType_0, bool bool_0, bool bool_1)
	{
		byte[] byte_ = MsoFillFormatHelper.smethod_49(gradientPresetType_0);
		return smethod_1(gradientFill_0, byte_, bool_0, bool_1);
	}

	internal static GradientStopCollection smethod_1(GradientFill gradientFill_0, byte[] byte_0, bool bool_0, bool bool_1)
	{
		int num = BitConverter.ToUInt16(byte_0, 0);
		int num2 = BitConverter.ToUInt16(byte_0, 4);
		if (num2 != 8 && num * num2 != byte_0.Length - 6)
		{
			return null;
		}
		int num3 = 6;
		GradientStopCollection gradientStopCollection = new GradientStopCollection(gradientFill_0);
		for (int i = 0; i < num; i++)
		{
			GradientStop gradientStop = new GradientStop(gradientStopCollection);
			gradientStop.internalColor_0.SetColor(ColorType.RGB, (byte_0[num3] << 16) + (byte_0[num3 + 1] << 8) + byte_0[num3 + 2]);
			num3 += 4;
			gradientStop.Position = ((float)(int)BitConverter.ToUInt16(byte_0, num3) / 65536f + (float)(int)byte_0[num3 + 2]) * 100f;
			num3 += 4;
			if (bool_0)
			{
				gradientStop.Position = 100.0 - gradientStop.Position;
				gradientStopCollection.Insert(0, gradientStop);
			}
			else
			{
				gradientStopCollection.Add(gradientStop);
			}
		}
		if (bool_1)
		{
			for (int j = 0; j < num; j++)
			{
				GradientStop gradientStop2 = gradientStopCollection[j];
				gradientStop2.Position /= 2.0;
				if (100.0 - gradientStop2.Position != gradientStop2.Position)
				{
					GradientStop gradientStop3 = new GradientStop(gradientStopCollection);
					gradientStop3.Position = 100.0 - gradientStop2.Position;
					gradientStop3.internalColor_0.method_19(gradientStop2.internalColor_0);
					gradientStopCollection.Insert(num, gradientStop3);
				}
			}
		}
		return gradientStopCollection;
	}

	internal static byte[] smethod_2(TextureType textureType_0)
	{
		return textureType_0 switch
		{
			TextureType.BlueTissuePaper => MsoFillFormatHelper.smethod_58(), 
			TextureType.Bouquet => MsoFillFormatHelper.smethod_61(), 
			TextureType.BrownMarble => MsoFillFormatHelper.smethod_56(), 
			TextureType.Canvas => MsoFillFormatHelper.smethod_63(), 
			TextureType.Cork => MsoFillFormatHelper.smethod_70(), 
			TextureType.Denim => MsoFillFormatHelper.smethod_64(), 
			TextureType.FishFossil => MsoFillFormatHelper.smethod_68(), 
			TextureType.Granite => MsoFillFormatHelper.smethod_57(), 
			TextureType.GreenMarble => MsoFillFormatHelper.smethod_54(), 
			TextureType.MediumWood => MsoFillFormatHelper.smethod_73(), 
			TextureType.Newsprint => MsoFillFormatHelper.smethod_50(), 
			TextureType.Oak => MsoFillFormatHelper.smethod_72(), 
			TextureType.PaperBag => MsoFillFormatHelper.smethod_67(), 
			TextureType.Papyrus => MsoFillFormatHelper.smethod_62(), 
			TextureType.Parchment => MsoFillFormatHelper.smethod_52(), 
			TextureType.PinkTissuePaper => MsoFillFormatHelper.smethod_59(), 
			TextureType.PurpleMesh => MsoFillFormatHelper.smethod_60(), 
			TextureType.RecycledPaper => MsoFillFormatHelper.smethod_51(), 
			TextureType.Sand => MsoFillFormatHelper.smethod_69(), 
			TextureType.Stationery => MsoFillFormatHelper.smethod_53(), 
			TextureType.Walnut => MsoFillFormatHelper.smethod_71(), 
			TextureType.WaterDroplets => MsoFillFormatHelper.smethod_66(), 
			TextureType.WhiteMarble => MsoFillFormatHelper.smethod_55(), 
			TextureType.WovenMat => MsoFillFormatHelper.smethod_65(), 
			_ => null, 
		};
	}
}
