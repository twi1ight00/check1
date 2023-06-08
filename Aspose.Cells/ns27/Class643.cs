using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;
using ns52;
using ns59;

namespace ns27;

internal class Class643 : Class538
{
	internal ArrayList arrayList_0;

	internal Class643()
	{
		method_2(4198);
	}

	internal void method_4(FillFormat fillFormat_0)
	{
		switch (fillFormat_0.Type)
		{
		case FillType.Solid:
			method_9(fillFormat_0);
			break;
		case FillType.Gradient:
			SetGradient(fillFormat_0);
			break;
		case FillType.Texture:
			if (fillFormat_0.Texture == TextureType.Unknown)
			{
				method_5(fillFormat_0.TextureFill.method_2());
			}
			else
			{
				method_6(fillFormat_0.Texture);
			}
			break;
		case FillType.Pattern:
			method_7(fillFormat_0);
			break;
		}
	}

	private void method_5(byte[] byte_1)
	{
		byte[] array = method_13();
		int num = method_10() + byte_1.Length + array.Length;
		if (num > 8224)
		{
			method_0(8224);
		}
		else
		{
			method_0((short)num);
		}
		byte_0 = new byte[base.Length];
		int num2 = method_10();
		Array.Copy(method_12(), 0, byte_0, 0, method_10());
		Array.Copy(BitConverter.GetBytes(num - 8 - array.Length), 0, byte_0, 4, 4);
		byte_0[10] = 3;
		Array.Copy(BitConverter.GetBytes(byte_1.Length), 0, byte_0, method_11(), 4);
		if (num <= 8224)
		{
			Array.Copy(byte_1, 0, byte_0, num2, byte_1.Length);
			Array.Copy(array, 0, byte_0, num2 + byte_1.Length, array.Length);
			return;
		}
		arrayList_0 = new ArrayList();
		int num3 = 8224 - num2;
		if (num3 > byte_1.Length)
		{
			Array.Copy(byte_1, 0, byte_0, num2, byte_1.Length);
			Array.Copy(array, 0, byte_0, byte_1.Length, num3 - byte_1.Length);
		}
		else
		{
			Array.Copy(byte_1, 0, byte_0, num2, 8224 - num2);
		}
		byte[] array2 = null;
		int num4 = 0;
		while (num3 < byte_1.Length + array.Length)
		{
			num4 = byte_1.Length + array.Length - num3;
			Class619 @class = new Class619();
			arrayList_0.Add(@class);
			if (num4 <= 8224)
			{
				array2 = new byte[num4];
				if (num4 <= array.Length)
				{
					Array.Copy(array, array.Length - num4, array2, 0, num4);
				}
				else
				{
					Array.Copy(byte_1, num3, array2, 0, num4 - array.Length);
					Array.Copy(array, 0, array2, num4 - array.Length, array.Length);
				}
				@class.method_3(array2);
				num3 = byte_1.Length + array.Length;
			}
			else
			{
				array2 = new byte[8224];
				if (num3 + 8224 > byte_1.Length)
				{
					Array.Copy(byte_1, num3, array2, 0, byte_1.Length - num3);
					Array.Copy(array, 0, array2, byte_1.Length - num3, 8224 + num3 - byte_1.Length);
				}
				else
				{
					Array.Copy(byte_1, num3, array2, 0, 8224);
				}
				@class.method_3(array2);
				num3 += 8224;
			}
		}
	}

	internal void method_6(TextureType textureType_0)
	{
		byte[] array = Class1707.smethod_2(textureType_0);
		if (array != null)
		{
			method_0((short)(array.Length + method_10()));
			byte_0 = new byte[base.Length];
			Array.Copy(method_12(), 0, byte_0, 0, method_10());
			Array.Copy(array, 0, byte_0, method_10(), array.Length);
			Array.Copy(BitConverter.GetBytes((short)(base.Length - 8)), 0, byte_0, 4, 2);
			byte_0[10] = 2;
			Array.Copy(BitConverter.GetBytes(array.Length), 0, byte_0, method_11(), 4);
		}
	}

	internal void method_7(FillFormat fillFormat_0)
	{
		byte[] array = MsoFillFormatHelper.smethod_74(fillFormat_0.Pattern);
		if (array != null)
		{
			method_0((short)(array.Length + method_10()));
			byte_0 = new byte[base.Length];
			Array.Copy(method_12(), 0, byte_0, 0, method_10());
			Array.Copy(array, 0, byte_0, method_10(), array.Length);
			Array.Copy(BitConverter.GetBytes((short)(base.Length - 8)), 0, byte_0, 4, 2);
			byte_0[10] = 1;
			Array.Copy(BitConverter.GetBytes(array.Length), 0, byte_0, method_11(), 4);
			SetColor(16, fillFormat_0.method_0().ForegroundColor);
			SetColor(28, fillFormat_0.method_0().BackgroundColor);
		}
	}

	internal void method_8(Area area_0)
	{
		method_0((short)method_10());
		byte_0 = new byte[base.Length];
		Array.Copy(method_12(), 0, byte_0, 0, method_10());
		Array.Copy(BitConverter.GetBytes((short)(base.Length - 8)), 0, byte_0, 4, 2);
		SetColor(16, area_0.ForegroundColor);
		SetColor(28, area_0.BackgroundColor);
	}

	internal void method_9(FillFormat fillFormat_0)
	{
		method_0((short)method_10());
		byte_0 = new byte[base.Length];
		Array.Copy(method_12(), 0, byte_0, 0, method_10());
		Array.Copy(BitConverter.GetBytes((short)(base.Length - 8)), 0, byte_0, 4, 2);
		SetColor(16, fillFormat_0.SolidFill.Color);
		SetColor(28, Color.Empty);
	}

	private void SetColor(int int_0, Color color_0)
	{
		byte_0[int_0] = color_0.R;
		byte_0[int_0 + 1] = color_0.G;
		byte_0[int_0 + 2] = color_0.B;
	}

	internal void SetGradient(FillFormat fillFormat_0)
	{
		byte[] array = null;
		if (fillFormat_0.GradientColorType == GradientColorType.PresetColors)
		{
			if (fillFormat_0.PresetColor == GradientPresetType.Unknown)
			{
				GradientStopCollection gradientStops = fillFormat_0.GradientFill.GradientStops;
				array = new byte[gradientStops.Count * 8 + 6];
				Array.Copy(BitConverter.GetBytes((ushort)gradientStops.Count), 0, array, 0, 2);
				Array.Copy(BitConverter.GetBytes((ushort)gradientStops.Count), 0, array, 2, 2);
				array[4] = 8;
				int num = 6;
				for (int i = 0; i < gradientStops.Count; i++)
				{
					GradientStop gradientStop = gradientStops[i];
					Color color = gradientStop.internalColor_0.method_6(fillFormat_0.method_0().Chart.method_14().Workbook);
					array[num] = color.R;
					array[num + 1] = color.G;
					array[num + 2] = color.B;
					int num2 = (int)(gradientStop.Position / 100.0);
					Array.Copy(BitConverter.GetBytes((ushort)((gradientStop.Position / 100.0 - (double)num2) * 65536.0)), 0, array, num + 4, 2);
					Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array, num + 6, 2);
					num += 8;
				}
			}
			else
			{
				array = MsoFillFormatHelper.smethod_49(fillFormat_0.PresetColor);
			}
		}
		if (array != null)
		{
			method_0((short)(method_10() + array.Length));
			byte_0 = new byte[base.Length];
			Array.Copy(array, 0, byte_0, method_10(), array.Length);
		}
		else
		{
			method_0(188);
			byte_0 = new byte[base.Length];
		}
		byte_0[0] = 227;
		byte_0[1] = 1;
		byte_0[2] = 11;
		byte_0[3] = 240;
		Array.Copy(BitConverter.GetBytes((short)(base.Length - 8)), 0, byte_0, 4, 2);
		byte_0[8] = 128;
		byte_0[9] = 1;
		switch (fillFormat_0.GradientStyle)
		{
		default:
			byte_0[10] = 7;
			break;
		case GradientStyleType.FromCenter:
			byte_0[10] = 6;
			break;
		case GradientStyleType.FromCorner:
			byte_0[10] = 5;
			break;
		}
		byte_0[14] = 129;
		byte_0[15] = 1;
		if (fillFormat_0.SetType == FormatSetType.IsGradientSet)
		{
			switch (fillFormat_0.GradientColorType)
			{
			case GradientColorType.PresetColors:
				Array.Copy(array, 6, byte_0, 16, 4);
				break;
			case GradientColorType.OneColor:
			case GradientColorType.TwoColors:
				SetColor(16, fillFormat_0.GradientColor1);
				break;
			}
		}
		byte_0[20] = 130;
		byte_0[21] = 1;
		byte_0[24] = 1;
		byte_0[26] = 131;
		byte_0[27] = 1;
		if (fillFormat_0.SetType == FormatSetType.IsGradientSet)
		{
			switch (fillFormat_0.GradientColorType)
			{
			case GradientColorType.OneColor:
				byte_0[28] = 240;
				Array.Copy(method_14(fillFormat_0.GradientDegree), 0, byte_0, 29, 2);
				byte_0[31] = 16;
				break;
			case GradientColorType.PresetColors:
				Array.Copy(array, array.Length - 8, byte_0, 28, 4);
				break;
			case GradientColorType.TwoColors:
				SetColor(28, fillFormat_0.GradientColor2);
				break;
			}
		}
		byte_0[32] = 132;
		byte_0[33] = 1;
		byte_0[36] = 1;
		byte_0[38] = 133;
		byte_0[39] = 1;
		byte_0[40] = 244;
		byte_0[43] = 16;
		byte_0[44] = 134;
		byte_0[45] = 193;
		byte_0[50] = 135;
		byte_0[51] = 193;
		byte_0[56] = 136;
		byte_0[57] = 1;
		byte_0[62] = 137;
		byte_0[63] = 1;
		byte_0[68] = 138;
		byte_0[69] = 1;
		byte_0[74] = 139;
		byte_0[75] = 1;
		switch (fillFormat_0.GradientStyle)
		{
		case GradientStyleType.DiagonalDown:
			byte_0[78] = 211;
			byte_0[79] = byte.MaxValue;
			break;
		case GradientStyleType.DiagonalUp:
			byte_0[78] = 121;
			byte_0[79] = byte.MaxValue;
			break;
		case GradientStyleType.Vertical:
			byte_0[78] = 90;
			byte_0[79] = 0;
			break;
		}
		byte_0[80] = 140;
		byte_0[81] = 1;
		switch (fillFormat_0.GradientStyle)
		{
		case GradientStyleType.DiagonalDown:
		case GradientStyleType.DiagonalUp:
			switch (fillFormat_0.GradientVariant)
			{
			case 1:
				byte_0[82] = 100;
				break;
			case 3:
				byte_0[82] = 206;
				byte_0[83] = byte.MaxValue;
				byte_0[84] = byte.MaxValue;
				byte_0[85] = byte.MaxValue;
				break;
			case 4:
				byte_0[82] = 50;
				break;
			}
			break;
		default:
			switch (fillFormat_0.GradientVariant)
			{
			case 1:
				byte_0[82] = 100;
				break;
			case 3:
				byte_0[82] = 50;
				break;
			case 4:
				byte_0[82] = 206;
				byte_0[83] = byte.MaxValue;
				byte_0[84] = byte.MaxValue;
				byte_0[85] = byte.MaxValue;
				break;
			}
			break;
		case GradientStyleType.FromCorner:
			byte_0[82] = 100;
			break;
		}
		byte_0[86] = 141;
		byte_0[87] = 1;
		if (fillFormat_0.GradientStyle == GradientStyleType.FromCenter)
		{
			byte_0[89] = 128;
		}
		else if (fillFormat_0.GradientStyle == GradientStyleType.FromCorner && (fillFormat_0.GradientVariant == 2 || fillFormat_0.GradientVariant == 4))
		{
			byte_0[90] = 1;
		}
		byte_0[92] = 142;
		byte_0[93] = 1;
		if (fillFormat_0.GradientStyle == GradientStyleType.FromCenter)
		{
			byte_0[95] = 128;
		}
		else if (fillFormat_0.GradientStyle == GradientStyleType.FromCorner && (fillFormat_0.GradientVariant == 3 || fillFormat_0.GradientVariant == 4))
		{
			byte_0[96] = 1;
		}
		byte_0[98] = 143;
		byte_0[99] = 1;
		if (fillFormat_0.GradientStyle == GradientStyleType.FromCenter)
		{
			byte_0[101] = 128;
		}
		else if (fillFormat_0.GradientStyle == GradientStyleType.FromCorner && (fillFormat_0.GradientVariant == 2 || fillFormat_0.GradientVariant == 4))
		{
			byte_0[102] = 1;
		}
		byte_0[104] = 144;
		byte_0[105] = 1;
		if (fillFormat_0.GradientStyle == GradientStyleType.FromCenter)
		{
			byte_0[107] = 128;
		}
		else if (fillFormat_0.GradientStyle == GradientStyleType.FromCorner && (fillFormat_0.GradientVariant == 3 || fillFormat_0.GradientVariant == 4))
		{
			byte_0[108] = 1;
		}
		byte_0[110] = 145;
		byte_0[111] = 1;
		byte_0[116] = 146;
		byte_0[117] = 1;
		byte_0[122] = 147;
		byte_0[123] = 1;
		byte_0[128] = 148;
		byte_0[129] = 1;
		byte_0[134] = 149;
		byte_0[135] = 1;
		byte_0[140] = 150;
		byte_0[141] = 1;
		byte_0[146] = 151;
		byte_0[147] = 193;
		if (array != null)
		{
			Array.Copy(BitConverter.GetBytes(array.Length), 0, byte_0, 148, 4);
		}
		byte_0[152] = 152;
		byte_0[153] = 1;
		byte_0[158] = 153;
		byte_0[159] = 1;
		byte_0[164] = 154;
		byte_0[165] = 1;
		byte_0[170] = 155;
		byte_0[171] = 1;
		byte_0[176] = 156;
		byte_0[177] = 1;
		if (fillFormat_0.SetType == FormatSetType.IsGradientSet)
		{
			switch (fillFormat_0.GradientColorType)
			{
			case GradientColorType.OneColor:
				byte_0[178] = 11;
				byte_0[181] = 64;
				break;
			case GradientColorType.TwoColors:
				byte_0[178] = 3;
				byte_0[181] = 64;
				break;
			}
		}
		byte_0[182] = 191;
		byte_0[183] = 1;
		byte_0[184] = 28;
		byte_0[186] = 31;
	}

	[SpecialName]
	internal int method_10()
	{
		return 188;
	}

	[SpecialName]
	internal int method_11()
	{
		return 46;
	}

	private byte[] method_12()
	{
		return new byte[188]
		{
			227, 1, 11, 240, 180, 0, 0, 0, 128, 1,
			0, 0, 0, 0, 129, 1, 0, 0, 0, 0,
			130, 1, 0, 0, 1, 0, 131, 1, 0, 0,
			0, 0, 132, 1, 0, 0, 1, 0, 133, 1,
			244, 0, 0, 16, 134, 193, 0, 0, 0, 0,
			135, 193, 0, 0, 0, 0, 136, 1, 0, 0,
			0, 0, 137, 1, 0, 0, 0, 0, 138, 1,
			0, 0, 0, 0, 139, 1, 0, 0, 0, 0,
			140, 1, 100, 0, 0, 0, 141, 1, 0, 0,
			0, 0, 142, 1, 0, 0, 0, 0, 143, 1,
			0, 0, 0, 0, 144, 1, 0, 0, 0, 0,
			145, 1, 0, 0, 0, 0, 146, 1, 0, 0,
			0, 0, 147, 1, 0, 0, 0, 0, 148, 1,
			0, 0, 0, 0, 149, 1, 0, 0, 0, 0,
			150, 1, 0, 0, 0, 0, 151, 193, 0, 0,
			0, 0, 152, 1, 0, 0, 0, 0, 153, 1,
			0, 0, 0, 0, 154, 1, 0, 0, 0, 0,
			155, 1, 0, 0, 0, 0, 156, 1, 11, 0,
			0, 64, 191, 1, 28, 0, 31, 0
		};
	}

	private byte[] method_13()
	{
		return new byte[8] { 3, 0, 34, 241, 0, 0, 0, 0 };
	}

	internal override void vmethod_0(Class1725 class1725_0)
	{
		if (byte_0 == null)
		{
			return;
		}
		class1725_0.method_7(method_1());
		class1725_0.method_7(base.Length);
		class1725_0.method_3(byte_0);
		if (arrayList_0 == null)
		{
			return;
		}
		foreach (Class619 item in arrayList_0)
		{
			item.vmethod_0(class1725_0);
		}
	}

	private byte[] method_14(double double_0)
	{
		byte[] array = new byte[2];
		if (double_0 < 0.5)
		{
			array[0] = 1;
			array[1] = (byte)(double_0 * 512.0);
		}
		else if (double_0 == 0.5)
		{
			array[0] = 1;
			array[1] = byte.MaxValue;
		}
		else
		{
			array[0] = 2;
			array[1] = (byte)((1.0 - double_0) * 512.0);
		}
		return array;
	}
}
