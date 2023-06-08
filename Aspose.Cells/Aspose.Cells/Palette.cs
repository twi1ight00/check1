using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Aspose.Cells;

[Serializable]
internal class Palette
{
	private SortedList colorList;

	private Color[] m_Colors;

	internal Color[] Colors
	{
		get
		{
			if (m_Colors == null)
			{
				m_Colors = new Color[56];
				for (int i = 0; i < 56; i++)
				{
					ref Color reference = ref m_Colors[i];
					reference = GetColor(i + 8);
				}
			}
			return m_Colors;
		}
	}

	internal Palette()
	{
		colorList = new SortedList();
		colorList[0] = 0;
		colorList[1] = 16777215;
		colorList[2] = 255;
		colorList[3] = 65280;
		colorList[4] = 16711680;
		colorList[5] = 65535;
		colorList[6] = 16711935;
		colorList[7] = 16776960;
		colorList[8] = 0;
		colorList[9] = 16777215;
		colorList[10] = 255;
		colorList[11] = 65280;
		colorList[12] = 16711680;
		colorList[13] = 65535;
		colorList[14] = 16711935;
		colorList[15] = 16776960;
		colorList[16] = 128;
		colorList[17] = 32768;
		colorList[18] = 8388608;
		colorList[19] = 32896;
		colorList[20] = 8388736;
		colorList[21] = 8421376;
		colorList[22] = 12632256;
		colorList[23] = 8421504;
		colorList[24] = 16751001;
		colorList[25] = 6697881;
		colorList[26] = 13434879;
		colorList[27] = 16777164;
		colorList[28] = 6684774;
		colorList[29] = 8421631;
		colorList[30] = 13395456;
		colorList[31] = 16764108;
		colorList[32] = 8388608;
		colorList[33] = 16711935;
		colorList[34] = 65535;
		colorList[35] = 16776960;
		colorList[36] = 8388736;
		colorList[37] = 128;
		colorList[38] = 8421376;
		colorList[39] = 16711680;
		colorList[40] = 16763904;
		colorList[41] = 16777164;
		colorList[42] = 13434828;
		colorList[43] = 10092543;
		colorList[44] = 16764057;
		colorList[45] = 13408767;
		colorList[46] = 16751052;
		colorList[47] = 10079487;
		colorList[48] = 16737843;
		colorList[49] = 13421619;
		colorList[50] = 52377;
		colorList[51] = 52479;
		colorList[52] = 39423;
		colorList[53] = 26367;
		colorList[54] = 10053222;
		colorList[55] = 9868950;
		colorList[56] = 6697728;
		colorList[57] = 6723891;
		colorList[58] = 13056;
		colorList[59] = 13107;
		colorList[60] = 13209;
		colorList[61] = 6697881;
		colorList[62] = 10040115;
		colorList[63] = 3355443;
	}

	[SpecialName]
	internal SortedList method_0()
	{
		return colorList;
	}

	private int method_1(int int_0)
	{
		int num = 0;
		int num2 = 63;
		while (true)
		{
			if (num2 >= 8)
			{
				num = (int)colorList[num2];
				if (int_0 == num)
				{
					break;
				}
				num2--;
				continue;
			}
			int num3 = 0;
			while (true)
			{
				if (num3 < 8)
				{
					num = (int)colorList[num3];
					if (int_0 == num)
					{
						break;
					}
					num3++;
					continue;
				}
				return -1;
			}
			return num3;
		}
		return num2;
	}

	internal int method_2(Color color_0)
	{
		int int_ = color_0.R + (color_0.G << 8) + (color_0.B << 16);
		return method_1(int_);
	}

	internal void SetColor(int int_0, int int_1)
	{
		colorList[int_1] = int_0;
	}

	internal void ChangePalette(Color color_0, int int_0)
	{
		int int_ = color_0.R + (color_0.G << 8) + (color_0.B << 16);
		SetColor(int_, int_0);
		if (m_Colors != null)
		{
			m_Colors[int_0 - 8] = color_0;
		}
	}

	internal void Copy(Palette palette_0)
	{
		for (int i = 8; i < 64; i++)
		{
			colorList[i] = palette_0.colorList[i];
		}
	}

	internal Color GetColor(int int_0)
	{
		int num = (int)colorList[int_0];
		int red = num & 0xFF;
		int green = (num & 0xFF00) >> 8;
		int blue = (num & 0xFF0000) >> 16;
		return Color.FromArgb(red, green, blue);
	}

	internal int method_3(int int_0)
	{
		int num = (int)colorList[int_0];
		int num2 = num & 0xFF;
		int num3 = (num & 0xFF0000) >> 16;
		num = (int)(num & 0xFF00FF00u);
		num |= num2 << 16;
		return num | num3;
	}

	internal int method_4(int int_0, int int_1, int int_2)
	{
		int result = -1;
		int num = int.MaxValue;
		int num2 = 0;
		for (int i = 8; i <= 63; i++)
		{
			int num3 = (int)colorList[i];
			int num4 = num3 & 0xFF;
			int num5 = (num3 & 0xFF00) >> 8;
			int num6 = (num3 & 0xFF0000) >> 16;
			num2 = (int_0 - num4) * (int_0 - num4) + (int_2 - num6) * (int_2 - num6) + (int_1 - num5) * (int_1 - num5);
			if (num > num2)
			{
				num = num2;
				result = i;
			}
		}
		for (int j = 0; j < 8; j++)
		{
			int num3 = (int)colorList[j];
			int num7 = num3 & 0xFF;
			int num8 = (num3 & 0xFF00) >> 8;
			int num9 = (num3 & 0xFF0000) >> 16;
			num2 = (int_0 - num7) * (int_0 - num7) + (int_2 - num9) * (int_2 - num9) + (int_1 - num8) * (int_1 - num8);
			if (num > num2)
			{
				num = num2;
				result = j;
			}
		}
		return result;
	}

	internal int method_5(int int_0)
	{
		int num = int_0 & 0xFF;
		int num2 = (int_0 & 0xFF00) >> 8;
		int num3 = (int_0 & 0xFF0000) >> 16;
		int result = -1;
		int num4 = int.MaxValue;
		int num5 = 0;
		for (int i = 8; i <= 63; i++)
		{
			int num6 = (int)colorList[i];
			int num7 = num6 & 0xFF;
			int num8 = (num6 & 0xFF00) >> 8;
			int num9 = (num6 & 0xFF0000) >> 16;
			num5 = (num - num7) * (num - num7) + (num3 - num9) * (num3 - num9) + (num2 - num8) * (num2 - num8);
			if (num4 > num5)
			{
				num4 = num5;
				result = i;
			}
		}
		for (int j = 0; j < 8; j++)
		{
			int num6 = (int)colorList[j];
			int num10 = num6 & 0xFF;
			int num11 = (num6 & 0xFF00) >> 8;
			int num12 = (num6 & 0xFF0000) >> 16;
			num5 = (num - num10) * (num - num10) + (num3 - num12) * (num3 - num12) + (num2 - num11) * (num2 - num11);
			if (num4 > num5)
			{
				num4 = num5;
				result = j;
			}
		}
		return result;
	}

	private Color method_6(int int_0)
	{
		int red = int_0 & 0xFF;
		int green = (int_0 & 0xFF00) >> 8;
		int blue = (int_0 & 0xFF0000) >> 16;
		return Color.FromArgb(red, green, blue);
	}

	internal Color method_7(int int_0)
	{
		switch (int_0)
		{
		case 80:
			return Color.FromArgb(255, 255, 225);
		default:
		{
			if (int_0 > colorList.Count)
			{
				return Color.Empty;
			}
			int int_ = (int)colorList[int_0];
			return method_6(int_);
		}
		case 64:
		case 65:
		case 67:
		case 77:
		case 78:
		case 79:
		case 81:
		case 32767:
			return Color.Empty;
		}
	}

	internal bool IsColorInPalette(Color color_0)
	{
		int num = color_0.R + (color_0.G << 8) + (color_0.B << 16);
		int num2 = 0;
		while (true)
		{
			if (num2 < colorList.Count)
			{
				int num3 = (int)colorList[num2];
				if (num3 == num)
				{
					break;
				}
				num2++;
				continue;
			}
			return false;
		}
		return true;
	}
}
