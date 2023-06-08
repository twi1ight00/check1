using Aspose.Cells;
using Aspose.Cells.Charts;

namespace ns7;

internal class Class1383
{
	internal ushort ushort_0;

	internal ushort ushort_1;

	internal ushort ushort_2;

	internal int int_0;

	internal ushort ushort_3;

	internal Chart chart_0;

	internal Font Font
	{
		get
		{
			if (int_0 != -1)
			{
				return (Font)chart_0.method_14().method_52()[(int_0 > 4) ? (int_0 - 1) : int_0];
			}
			return null;
		}
	}

	internal Class1383(Chart chart_1, int int_1, bool bool_0)
	{
		int_0 = -1;
		chart_0 = chart_1;
		ushort_2 = 1;
		if (bool_0)
		{
			Resize(int_1);
		}
	}

	internal void Resize(int int_1)
	{
		ushort_0 = (ushort)((double)((float)(chart_0.ChartObject.Width * 20) * 72f / (float)chart_0.method_14().method_75()) + 0.5 - 135.0);
		ushort_1 = (ushort)((double)((float)(chart_0.ChartObject.Height * 20) * 72f / (float)chart_0.method_14().method_75()) + 0.5 - 135.0);
		if (ushort_1 > 32767 || ushort_0 > 32767)
		{
			ushort_0 = 0;
			ushort_1 = 0;
		}
		ushort_3 = (ushort)(int_1 * 20);
	}

	internal void Copy(Class1383 class1383_0)
	{
		ushort_0 = class1383_0.ushort_0;
		ushort_1 = class1383_0.ushort_1;
		ushort_2 = class1383_0.ushort_2;
		int_0 = class1383_0.int_0;
		ushort_3 = class1383_0.ushort_3;
	}

	internal bool method_0(Class1383 class1383_0, Font font_0)
	{
		if (int_0 == -1)
		{
			return false;
		}
		if (ushort_0 == class1383_0.ushort_0 && ushort_1 == class1383_0.ushort_1 && ushort_2 == class1383_0.ushort_2)
		{
			return Font.method_18(font_0);
		}
		return false;
	}
}
