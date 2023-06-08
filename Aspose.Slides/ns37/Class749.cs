using System.Collections;
using System.Drawing;
using ns38;

namespace ns37;

internal class Class749
{
	private SortedList sortedList_0;

	internal Class749(SortedList sourceList, int count, int index)
	{
		if (sourceList != null && sourceList.Count != 0)
		{
			sortedList_0 = sourceList;
		}
		else if (index == 1)
		{
			sortedList_0 = Class766.smethod_0(count);
		}
		else
		{
			sortedList_0 = Class766.smethod_1(count);
		}
	}

	internal Color method_0(int index)
	{
		int num = (int)sortedList_0[index % sortedList_0.Count];
		int red = num & 0xFF;
		int green = (num & 0xFF00) >> 8;
		int blue = (num & 0xFF0000) >> 16;
		return Color.FromArgb(red, green, blue);
	}

	private int method_1(int index)
	{
		if (index < sortedList_0.Count)
		{
			return (int)sortedList_0[index];
		}
		return 0;
	}

	private void method_2(int color, int index)
	{
		sortedList_0[index] = color;
	}

	private void method_3(Color color, int index)
	{
		int color2 = color.R + (color.G << 8) + (color.B << 16);
		method_2(color2, index);
	}
}
