using System.Runtime.CompilerServices;
using Aspose.Cells;
using ns2;

namespace ns14;

internal class Class426 : Class423
{
	private readonly Class484[] class484_0;

	private readonly double[] double_0;

	private readonly double double_1;

	private double double_2;

	private int int_0;

	internal double Width
	{
		set
		{
			double_2 = value;
		}
	}

	internal Class426(Workbook workbook_0, bool bool_0)
	{
		Font font = workbook_0.DefaultStyle.Font;
		Class484 @class = new Class484(font.Name, font.Size, font.method_30(), bool_1: true, null);
		double num = vmethod_1(@class);
		Class1683 class2 = workbook_0.Worksheets.method_58();
		class484_0 = new Class484[class2.Count];
		double_0 = new double[class484_0.Length];
		class484_0[0] = @class;
		if (bool_0)
		{
			double_0[0] = num;
			double_1 = 1.0;
			double_2 = 12.0 * num;
		}
		else
		{
			double_0[0] = 1.0;
			double_1 = num;
			double_2 = 12.0;
		}
		for (int i = 1; i < double_0.Length; i++)
		{
			Font font2 = class2[i].method_40();
			if (font2 != null && !@class.method_1(font2.Name, font2.Size, font2.method_30()))
			{
				class484_0[i] = new Class484(font2.Name, font2.Size, font2.method_30(), bool_1: false, @class);
				if (bool_0)
				{
					double_0[i] = vmethod_1(class484_0[i]);
				}
				else
				{
					double_0[i] = vmethod_1(class484_0[i]) / num;
				}
			}
			else
			{
				class484_0[i] = @class;
				if (bool_0)
				{
					double_0[i] = num;
				}
				else
				{
					double_0[i] = 1.0;
				}
			}
		}
	}

	[SpecialName]
	internal void method_0(int int_1)
	{
		if (int_1 > -1 && int_1 < class484_0.Length)
		{
			int_0 = int_1;
		}
		else
		{
			int_0 = 0;
		}
	}

	protected override int vmethod_0(string string_0)
	{
		return (int)((double_2 - ((string_0 == null || string_0.Equals("")) ? 0.0 : ((double)class484_0[int_0].method_2(string_0) / double_1))) / double_0[int_0]);
	}
}
