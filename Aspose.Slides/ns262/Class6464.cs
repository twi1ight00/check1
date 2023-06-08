using System.Collections.Generic;
using ns252;

namespace ns262;

internal class Class6464 : Interface308
{
	private double double_0;

	private int int_0;

	private double double_1;

	private List<Class6463> list_0;

	private double double_2;

	private List<Interface305> list_1;

	private int int_1;

	public List<Class6463> imethod_0(List<Interface305> layoutSpans, Interface309 widthProvider)
	{
		Initialize(layoutSpans);
		while (int_0 < list_1.Count)
		{
			double_1 = widthProvider.imethod_0();
			method_3();
			method_2();
			method_1();
			method_0();
		}
		return list_0;
	}

	private void Initialize(List<Interface305> layoutSpans)
	{
		list_0 = new List<Class6463>();
		list_1 = layoutSpans;
		int_1 = 0;
		int_0 = 0;
		double_0 = 0.0;
		double_2 = 0.0;
	}

	private void method_0()
	{
		Class6324<Interface305> @class = new Class6324<Interface305>(list_1);
		@class.StartIndex = int_1;
		@class.EndIndex = int_0;
		Class6463 item = new Class6463(double_1, @class);
		list_0.Add(item);
		int_1 = int_0;
		double_0 = 0.0;
		double_2 = 0.0;
	}

	private void method_1()
	{
		while (int_0 < list_1.Count)
		{
			Interface305 @interface = list_1[int_0];
			if (@interface.Type != Enum835.const_1)
			{
				break;
			}
			double_0 += @interface.OriginalWidth;
			int_0++;
		}
	}

	private void method_2()
	{
		while (int_0 < list_1.Count)
		{
			Interface305 @interface = list_1[int_0];
			if (double_0 + @interface.OriginalWidth <= double_1)
			{
				double_0 += @interface.OriginalWidth;
				double_2 += @interface.OriginalWidth;
				int_0++;
				continue;
			}
			break;
		}
	}

	private void method_3()
	{
		while (true)
		{
			if (int_0 < list_1.Count)
			{
				Interface305 @interface = list_1[int_0];
				double_0 += @interface.OriginalWidth;
				double_2 += @interface.OriginalWidth;
				if (@interface.Type != Enum835.const_1)
				{
					break;
				}
				int_0++;
				continue;
			}
			return;
		}
		int_0++;
	}
}
