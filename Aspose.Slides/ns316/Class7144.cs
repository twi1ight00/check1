using System;
using System.Collections;

namespace ns316;

internal class Class7144
{
	internal struct Struct255
	{
		internal int int_0;

		internal int int_1;

		internal int int_2;

		internal int int_3;
	}

	internal enum Enum972
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6,
		const_7,
		const_8,
		const_9,
		const_10,
		const_11,
		const_12,
		const_13,
		const_14,
		const_15,
		const_16,
		const_17,
		const_18
	}

	internal class Class7145
	{
		internal int int_0;

		internal int int_1;

		internal int int_2;

		internal int int_3;

		internal int int_4;

		internal Class7145 class7145_0;

		internal int int_5;

		internal int int_6;

		internal int int_7;

		internal byte[] byte_0 = new byte[0];

		internal int int_8;
	}

	internal ArrayList arrayList_0 = new ArrayList(new string[16]
	{
		"Normal", "Multiply", "Screen", "Overlay", "Darken", "Lighten", "ColorDodge", "ColorBurn", "HardLight", "SoftLight",
		"Difference", "Exclusion", "Hue", "Saturation", "Color", "Luminosity"
	});

	internal static int smethod_0(int firstColor, int secondColor)
	{
		return Math.Max(firstColor, secondColor);
	}

	internal static int smethod_1(int firstColor, int secondColor)
	{
		secondColor = 255 - secondColor;
		if (firstColor == 0)
		{
			return 0;
		}
		if (firstColor >= secondColor)
		{
			return 255;
		}
		return (510 * firstColor + secondColor) / (secondColor << 1);
	}

	internal static void smethod_2(ref Class7145 dest, ref Class7145 source, int alpha, int blendmode, int isolated, ref Class7145 shape)
	{
		int num;
		byte[] byte_;
		if ((isolated & alpha) < 255)
		{
			byte_ = source.byte_0;
			num = source.int_2 * source.int_3 * source.int_4;
			int num2 = 0;
			while (num-- > 0)
			{
				byte_[num2] = Convert.ToByte(smethod_11(byte_[num2], alpha));
				num2++;
			}
		}
		Struct255 @struct = smethod_15(ref dest);
		int int_ = @struct.int_0;
		int int_2 = @struct.int_1;
		int width = @struct.int_2 - @struct.int_0;
		int num3 = @struct.int_3 - @struct.int_1;
		num = source.int_4;
		int num4 = ((int_2 - source.int_1) * source.int_2 + (int_ - source.int_0)) * num;
		byte_ = new byte[source.byte_0.Length - num4];
		Buffer.BlockCopy(source.byte_0, num4, byte_, 0, byte_.Length - num4);
		int num5 = ((int_2 - dest.int_1) * dest.int_2 + (int_ - dest.int_0)) * num;
		byte[] bBytes = new byte[dest.byte_0.Length - num4];
		Buffer.BlockCopy(dest.byte_0, num5, bBytes, 0, bBytes.Length - num5);
		if (isolated == 0)
		{
			int num6 = (int_2 - shape.int_1) * shape.int_2 + (int_ - shape.int_0);
			byte[] hBytes = new byte[shape.byte_0.Length - num6];
			Buffer.BlockCopy(shape.byte_0, num6, hBytes, 0, shape.byte_0.Length - num6);
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			while (num3-- > 0)
			{
				if (num == 4 && blendmode >= 14)
				{
					smethod_20(ref bBytes, ref byte_, width, blendmode, ref hBytes, alpha);
				}
				else
				{
					smethod_19(ref bBytes, ref byte_, num, width, blendmode, ref hBytes, alpha);
				}
				num7 += source.int_2 * num;
				num8 += dest.int_2 * num;
				num9 += shape.int_2;
			}
			return;
		}
		int num10 = 0;
		int num11 = 0;
		while (num3-- > 0)
		{
			if (num == 4 && blendmode >= 14)
			{
				smethod_18(ref bBytes, ref byte_, width, blendmode, num10, num11);
			}
			else
			{
				smethod_17(ref bBytes, ref byte_, num, width, blendmode, num10, num11);
			}
			num10 += source.int_2 * num;
			num11 += dest.int_2 * num;
		}
	}

	internal static int smethod_3(int bColor, int sColor)
	{
		bColor = 255 - bColor;
		if (bColor == 0)
		{
			return 255;
		}
		if (bColor >= sColor)
		{
			return 0;
		}
		return 255 - (510 * bColor + sColor) / (sColor << 1);
	}

	internal static int smethod_4(int bColor, int sColor)
	{
		if (sColor < 128)
		{
			return bColor - smethod_11(smethod_11(255 - (sColor << 1), bColor), 255 - bColor);
		}
		int num = ((bColor >= 64) ? ((int)Math.Sqrt(255f * (float)bColor)) : smethod_11(smethod_11((bColor << 4) - 12, bColor) + 4, bColor));
		return bColor + smethod_11((sColor << 1) - 255, num - bColor);
	}

	internal static int smethod_5(int bParam, int sParam)
	{
		return Math.Abs(bParam - sParam);
	}

	internal static int smethod_6(int bParam, int sParam)
	{
		return bParam + sParam - (smethod_11(bParam, sParam) << 1);
	}

	internal static void smethod_7(ref int red, ref int green, ref int blue, int redValue, int greenValue, int blueValue, int rsat, int gsat, int bsat)
	{
		int num = (rsat - redValue) * 77 + (gsat - greenValue) * 151 + (bsat - blueValue) * 28 + 128 >> 8;
		int num2 = redValue + num;
		int num3 = greenValue + num;
		int num4 = blueValue + num;
		int num5 = rsat * 77 + gsat * 151 + bsat * 28 + 128 >> 8;
		int num7;
		if (num > 0)
		{
			int num6 = Math.Max(num2, Math.Max(num3, num4));
			num7 = (255 - num5 << 16) / (num6 - num5);
		}
		else
		{
			int num8 = Math.Min(num2, Math.Min(num3, num4));
			num7 = (num5 << 16) / (num5 - num8);
		}
		num2 = num5 + ((num2 - num5) * num7 + 32768 >> 16);
		num3 = num5 + ((num3 - num5) * num7 + 32768 >> 16);
		num4 = num5 + ((num4 - num5) * num7 + 32768 >> 16);
		red = num2;
		green = num3;
		blue = num4;
	}

	internal static void smethod_8(ref int red, ref int green, ref int blue, int rByte, int gByte, int bByte, int rSat, int gSat, int bSat)
	{
		int num = Math.Max(rByte, Math.Max(gByte, bByte));
		int num2 = Math.Min(rByte, Math.Min(gByte, bByte));
		if (num2 == num)
		{
			red = gByte;
			green = gByte;
			blue = gByte;
			return;
		}
		int num3 = Math.Min(rSat, Math.Min(gSat, bSat));
		int num4 = Math.Max(rSat, Math.Max(gSat, bSat));
		int num5 = (num4 - num3 << 16) / (num - num2);
		int num6 = rByte * 77 + gByte * 151 + bByte * 28 + 128 >> 8;
		int num7 = num6 + ((rByte - num6) * num5 + 32768 >> 16);
		int num8 = num6 + ((gByte - num6) * num5 + 32768 >> 16);
		int num9 = num6 + ((bByte - num6) * num5 + 32768 >> 16);
		int num10 = Math.Min(num7, Math.Min(num8, num9));
		int num11 = Math.Max(num7, Math.Max(num8, num9));
		int val = ((num10 >= 0) ? 65536 : ((num6 << 16) / (num6 - num10)));
		int val2 = ((num11 <= 255) ? 65536 : ((255 - num6 << 16) / (num11 - num6)));
		num5 = Math.Min(val, val2);
		num7 = num6 + ((num7 - num6) * num5 + 32768 >> 16);
		num8 = num6 + ((num8 - num6) * num5 + 32768 >> 16);
		num9 = num6 + ((num9 - num6) * num5 + 32768 >> 16);
		red = num7;
		green = num8;
		blue = num9;
	}

	internal static void smethod_9(ref int red, ref int green, ref int blue, int byteR, int byteG, int byteB, int satR, int satG, int satB)
	{
		smethod_7(ref red, ref green, ref blue, satR, satG, satB, byteR, byteG, byteB);
	}

	internal static void smethod_10(ref int red, ref int green, ref int blue, int byteRed, int byteGreen, int byteBlue, int satR, int satG, int satB)
	{
		int red2 = 0;
		int green2 = 0;
		int blue2 = 0;
		smethod_7(ref red2, ref green2, ref blue2, satR, satG, satB, byteRed, byteGreen, byteBlue);
		smethod_8(ref red, ref green, ref blue, red2, green2, blue2, byteRed, byteGreen, byteBlue);
	}

	internal int method_0(string name)
	{
		int num = 0;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				if (name == arrayList_0[num].ToString())
				{
					break;
				}
				num++;
				continue;
			}
			return 0;
		}
		return num;
	}

	internal string method_1(int blendmode)
	{
		if (blendmode >= 0 && blendmode < arrayList_0.Count)
		{
			return arrayList_0[blendmode].ToString();
		}
		return "Normal";
	}

	internal static int smethod_11(int aByte, int bByte)
	{
		int num = aByte * bByte + 128;
		num += num >> 8;
		return num >> 8;
	}

	internal static int smethod_12(int bByte, int sByte)
	{
		return bByte + sByte - smethod_11(bByte, sByte);
	}

	internal static int smethod_13(int bByte, int sByte)
	{
		int num = sByte << 1;
		if (sByte <= 127)
		{
			return smethod_11(bByte, num);
		}
		return smethod_12(bByte, num - 255);
	}

	internal static int smethod_14(int bByte, int sByte)
	{
		return smethod_13(sByte, bByte);
	}

	internal static Struct255 smethod_15(ref Class7145 pixels)
	{
		Struct255 result = default(Struct255);
		result.int_0 = pixels.int_0;
		result.int_1 = pixels.int_1;
		result.int_2 = pixels.int_0 + pixels.int_2;
		result.int_3 = pixels.int_1 + pixels.int_3;
		return result;
	}

	internal static int smethod_16(int bByte, int sByte)
	{
		return Math.Min(bByte, sByte);
	}

	internal static void smethod_17(ref byte[] bBytes, ref byte[] sBytes, int nPos, int width, int blendmode, int spIndex, int dpIndex)
	{
		int num = nPos - 1;
		while (width-- > 0)
		{
			int num2 = sBytes[num + spIndex];
			int num3 = bBytes[num + dpIndex];
			int num4 = smethod_11(num2, num3);
			int num5 = ((num2 > 0) ? (65280 / num2) : 0);
			int num6 = ((num3 > 0) ? (65280 / num3) : 0);
			int i;
			for (i = 0; i < num; i++)
			{
				int num7 = sBytes[i + spIndex] * num5 >> 8;
				int num8 = bBytes[i + dpIndex] * num6 >> 8;
				int bByte = 255;
				switch (blendmode)
				{
				case 0:
					bByte = num7;
					break;
				case 1:
					bByte = smethod_11(num8, num7);
					break;
				case 2:
					bByte = smethod_12(num8, num7);
					break;
				case 3:
					bByte = smethod_14(num8, num7);
					break;
				case 4:
					bByte = smethod_16(num8, num7);
					break;
				case 5:
					bByte = smethod_0(num8, num7);
					break;
				case 7:
					bByte = smethod_1(num8, num7);
					break;
				case 8:
					bByte = smethod_3(num8, num7);
					break;
				case 10:
					bByte = smethod_13(num8, num7);
					break;
				case 11:
					bByte = smethod_4(num8, num7);
					break;
				case 12:
					bByte = smethod_5(num8, num7);
					break;
				case 13:
					bByte = smethod_6(num8, num7);
					break;
				}
				bBytes[i] = (byte)(smethod_11(255 - num2, bBytes[i + dpIndex]) + smethod_11(255 - num3, sBytes[i + spIndex]) + smethod_11(num4, bByte));
			}
			bBytes[i + dpIndex] = (byte)(num3 + num2 - num4);
			spIndex += nPos;
			dpIndex += nPos;
		}
	}

	internal static void smethod_18(ref byte[] bBytes, ref byte[] sBytes, int width, int blendmode, int spIndex, int dpIndex)
	{
		while (width-- > 0)
		{
			int red = 0;
			int green = 0;
			int blue = 0;
			int num = sBytes[3 + spIndex];
			int num2 = bBytes[3 + dpIndex];
			int num3 = smethod_11(num, num2);
			int num4 = ((num > 0) ? (65280 / num) : 0);
			int num5 = ((num2 > 0) ? (65280 / num2) : 0);
			int num6 = sBytes[spIndex] * num4 >> 8;
			int num7 = sBytes[1 + spIndex] * num4 >> 8;
			int num8 = sBytes[2 + spIndex] * num4 >> 8;
			int num9 = bBytes[dpIndex] * num5 >> 8;
			int num10 = bBytes[1 + dpIndex] * num5 >> 8;
			int num11 = bBytes[2 + dpIndex] * num5 >> 8;
			switch (blendmode)
			{
			case 14:
				smethod_10(ref red, ref green, ref blue, num9, num10, num11, num6, num7, num8);
				break;
			case 15:
				smethod_8(ref red, ref green, ref blue, num9, num10, num11, num6, num7, num8);
				break;
			case 16:
				smethod_9(ref red, ref green, ref blue, num9, num10, num11, num6, num7, num8);
				break;
			case 17:
				smethod_7(ref red, ref green, ref blue, num9, num10, num11, num6, num7, num8);
				break;
			}
			bBytes[dpIndex] = (byte)(smethod_11(255 - num, bBytes[dpIndex]) + smethod_11(255 - num2, sBytes[spIndex]) + smethod_11(num3, red));
			bBytes[1 + dpIndex] = (byte)(smethod_11(255 - num, bBytes[1 + dpIndex]) + smethod_11(255 - num2, sBytes[1 + spIndex]) + smethod_11(num3, green));
			bBytes[2 + dpIndex] = (byte)(smethod_11(255 - num, bBytes[2 + dpIndex]) + smethod_11(255 - num2, sBytes[2 + spIndex]) + smethod_11(num3, blue));
			bBytes[3 + dpIndex] = (byte)(num2 + num - num3);
			spIndex += 4;
			dpIndex += 4;
		}
	}

	internal static void smethod_19(ref byte[] bBytes, ref byte[] sBytes, int nPos, int width, int blendmode, ref byte[] hBytes, int alpha)
	{
		int num = nPos - 1;
		int num2 = 0;
		if (alpha == 255 && blendmode == 0)
		{
			while (width-- > 0)
			{
				int num3 = smethod_11(hBytes[num2], alpha);
				num2++;
				if (num3 != 0)
				{
					for (int i = 0; i < nPos; i++)
					{
						bBytes[i + num2] = sBytes[i + num2];
					}
				}
				num2 += nPos;
			}
			return;
		}
		while (width-- > 0)
		{
			int num4 = hBytes[num2];
			num2++;
			int num5 = smethod_11(num4, alpha);
			if (num5 != 0)
			{
				int num6 = sBytes[num + num2];
				int num7 = bBytes[num + num2];
				int num8 = smethod_11(num7, num5);
				int num9 = ((num6 > 0) ? (65280 / num6) : 0);
				int num10 = ((num7 > 0) ? (65280 / num7) : 0);
				byte b;
				bBytes[num + num2] = (b = Convert.ToByte(num7 - num8 + num5));
				int num11 = b;
				int num12 = ((num4 > 0) ? (65280 / num4) : 0);
				if (num11 != 0)
				{
					for (int i = 0; i < num; i++)
					{
						int num13 = sBytes[i + num2] * num9 >> 8;
						int num14 = bBytes[i + num2] * num10 >> 8;
						int bByte = 255;
						num13 = ((num13 - num14) * num12 >> 8) + num14;
						if (num13 < 0)
						{
							num13 = 0;
						}
						if (num13 > 255)
						{
							num13 = 255;
						}
						switch (blendmode)
						{
						case 0:
							bByte = num13;
							break;
						case 1:
							bByte = smethod_11(num14, num13);
							break;
						case 2:
							bByte = smethod_12(num14, num13);
							break;
						case 3:
							bByte = smethod_14(num14, num13);
							break;
						case 4:
							bByte = smethod_16(num14, num13);
							break;
						case 5:
							bByte = smethod_0(num14, num13);
							break;
						case 7:
							bByte = smethod_1(num14, num13);
							break;
						case 8:
							bByte = smethod_3(num14, num13);
							break;
						case 10:
							bByte = smethod_13(num14, num13);
							break;
						case 11:
							bByte = smethod_4(num14, num13);
							break;
						case 12:
							bByte = smethod_5(num14, num13);
							break;
						case 13:
							bByte = smethod_6(num14, num13);
							break;
						}
						bByte = smethod_11(255 - num5, num14) + smethod_11(smethod_11(255 - num7, num13), num5) + smethod_11(num8, bByte);
						if (bByte < 0)
						{
							bByte = 0;
						}
						if (bByte > 255)
						{
							bByte = 255;
						}
						bBytes[i + num2] = Convert.ToByte(smethod_11(bByte, num11));
					}
				}
			}
			num2 += nPos;
		}
	}

	internal static void smethod_20(ref byte[] bBytes, ref byte[] sBytes, int width, int blendmode, ref byte[] hBytes, int alpha)
	{
		int num = 0;
		while (width-- > 0)
		{
			int num2 = Convert.ToInt32(hBytes[num]);
			num++;
			int num3 = smethod_11(num2, alpha);
			if (num3 != 0)
			{
				int num4 = sBytes[3 + num];
				int num5 = bBytes[3 + num];
				int num6 = smethod_11(num5, num3);
				byte b;
				bBytes[3 + num] = (b = Convert.ToByte(num5 - num6 + num3));
				int num7 = b;
				if (num7 != 0)
				{
					int num8 = ((num2 > 0) ? (65280 / num2) : 0);
					int red = 0;
					int green = 0;
					int blue = 0;
					int num9 = ((num4 > 0) ? (65280 / num4) : 0);
					int num10 = ((num5 > 0) ? (65280 / num5) : 0);
					int num11 = sBytes[num] * num9 >> 8;
					int num12 = sBytes[1 + num] * num9 >> 8;
					int num13 = sBytes[2 + num] * num9 >> 8;
					int num14 = bBytes[num] * num10 >> 8;
					int num15 = bBytes[1 + num] * num10 >> 8;
					int num16 = bBytes[2 + num] * num10 >> 8;
					num11 = ((num11 - num14) * num8 >> 8) + num14;
					num12 = ((num12 - num15) * num8 >> 8) + num15;
					num13 = ((num13 - num16) * num8 >> 8) + num16;
					switch (blendmode)
					{
					case 14:
						smethod_10(ref red, ref green, ref blue, num14, num15, num16, num11, num12, num13);
						break;
					case 15:
						smethod_8(ref red, ref green, ref blue, num14, num15, num16, num11, num12, num13);
						break;
					case 16:
						smethod_9(ref red, ref green, ref blue, num14, num15, num16, num11, num12, num13);
						break;
					case 17:
						smethod_7(ref red, ref green, ref blue, num14, num15, num16, num11, num12, num13);
						break;
					}
					red = smethod_11(255 - num3, bBytes[num]) + smethod_11(smethod_11(255 - num5, num11), num3) + smethod_11(num6, red);
					green = smethod_11(255 - num3, bBytes[1 + num]) + smethod_11(smethod_11(255 - num5, num12), num3) + smethod_11(num6, green);
					blue = smethod_11(255 - num3, bBytes[2 + num]) + smethod_11(smethod_11(255 - num5, num13), num3) + smethod_11(num6, blue);
					bBytes[num] = Convert.ToByte(smethod_11(num7, Math.Abs(red)));
					bBytes[1 + num] = Convert.ToByte(smethod_11(num7, Math.Abs(green)));
					bBytes[2 + num] = Convert.ToByte(smethod_11(num7, Math.Abs(blue)));
				}
			}
			num += 4;
		}
	}
}
