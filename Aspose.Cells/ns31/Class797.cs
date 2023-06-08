using System.Collections;
using System.Drawing;

namespace ns31;

internal class Class797
{
	private SortedList sortedList_0;

	internal Class797(SortedList sortedList_1, bool bool_0)
	{
		sortedList_0 = new SortedList();
		int num = 0;
		if (bool_0)
		{
			sortedList_0[num++] = 255;
			sortedList_0[num++] = 65280;
			sortedList_0[num++] = 16711680;
			sortedList_0[num++] = 65535;
			sortedList_0[num++] = 16711935;
			sortedList_0[num++] = 16776960;
			sortedList_0[num++] = 128;
			sortedList_0[num++] = 32768;
			sortedList_0[num++] = 8388608;
			sortedList_0[num++] = 32896;
			sortedList_0[num++] = 8388736;
			sortedList_0[num++] = 8421376;
			sortedList_0[num++] = 12632256;
			sortedList_0[num++] = 8421504;
		}
		if (sortedList_1 != null && sortedList_1.Count != 0)
		{
			for (int i = 0; i < sortedList_1.Count; i++)
			{
				sortedList_0[num++] = sortedList_1[i];
			}
			return;
		}
		sortedList_0[num++] = 16751001;
		sortedList_0[num++] = 6697881;
		sortedList_0[num++] = 13434879;
		sortedList_0[num++] = 16777164;
		sortedList_0[num++] = 6684774;
		sortedList_0[num++] = 8421631;
		sortedList_0[num++] = 13395456;
		sortedList_0[num++] = 16764108;
		sortedList_0[num++] = 8388608;
		sortedList_0[num++] = 16711935;
		sortedList_0[num++] = 65535;
		sortedList_0[num++] = 16776960;
		sortedList_0[num++] = 8388736;
		sortedList_0[num++] = 128;
		sortedList_0[num++] = 8421376;
		sortedList_0[num++] = 16711680;
		sortedList_0[num++] = 16763904;
		sortedList_0[num++] = 16777164;
		sortedList_0[num++] = 13434828;
		sortedList_0[num++] = 10092543;
		sortedList_0[num++] = 16764057;
		sortedList_0[num++] = 13408767;
		sortedList_0[num++] = 16751052;
		sortedList_0[num++] = 10079487;
		sortedList_0[num++] = 16737843;
		sortedList_0[num++] = 13421619;
		sortedList_0[num++] = 52377;
		sortedList_0[num++] = 52479;
		sortedList_0[num++] = 39423;
		sortedList_0[num++] = 26367;
		sortedList_0[num++] = 10053222;
		sortedList_0[num++] = 9868950;
		sortedList_0[num++] = 6697728;
		sortedList_0[num++] = 6723891;
		sortedList_0[num++] = 13056;
		sortedList_0[num++] = 13107;
		sortedList_0[num++] = 13209;
		sortedList_0[num++] = 6697881;
		sortedList_0[num++] = 10040115;
		sortedList_0[num++] = 3355443;
		sortedList_0[num++] = 0;
		sortedList_0[num++] = 16777215;
		sortedList_0[num++] = 255;
		sortedList_0[num++] = 65280;
		sortedList_0[num++] = 16711680;
		sortedList_0[num++] = 65535;
		sortedList_0[num++] = 16711935;
		sortedList_0[num++] = 16776960;
		sortedList_0[num++] = 128;
		sortedList_0[num++] = 32768;
		sortedList_0[num++] = 8388608;
		sortedList_0[num++] = 32896;
		sortedList_0[num++] = 8388736;
		sortedList_0[num++] = 8421376;
		sortedList_0[num++] = 12632256;
		sortedList_0[num++] = 8421504;
	}

	internal Color GetColor(int int_0)
	{
		int num = (int)sortedList_0[int_0 % sortedList_0.Count];
		int red = num & 0xFF;
		int green = (num & 0xFF00) >> 8;
		int blue = (num & 0xFF0000) >> 16;
		return Color.FromArgb(red, green, blue);
	}

	private void SetColor(int int_0, int int_1)
	{
		sortedList_0[int_1] = int_0;
	}

	internal void ChangePalette(Color[] color_0, bool bool_0)
	{
		if (color_0 != null && color_0.Length != 0)
		{
			int num = 0;
			if (bool_0)
			{
				num = 14;
			}
			for (int i = 0; i < color_0.Length; i++)
			{
				int int_ = color_0[i].R + (color_0[i].G << 8) + (color_0[i].B << 16);
				SetColor(int_, num);
				num++;
			}
		}
	}
}
