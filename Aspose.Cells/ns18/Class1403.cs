using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1403
{
	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private double double_0;

	private double double_1;

	public int Width
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public int Height
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public double HorizontalResolution
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public double VerticalResolution
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public static Class1403 smethod_0()
	{
		return smethod_1(0, 0, 96.0, 96.0);
	}

	public static Class1403 smethod_1(int int_4, int int_5, double double_2, double double_3)
	{
		return new Class1403(0, 0, int_4, int_5, double_2, double_3);
	}

	public static Class1403 smethod_2(int int_4, int int_5, int int_6, int int_7, double double_2, double double_3)
	{
		int int_8 = int_6 - int_4;
		int int_9 = int_7 - int_5;
		return new Class1403(int_4, int_5, int_8, int_9, double_2, double_3);
	}

	public static Class1403 smethod_3(int int_4, int int_5, int int_6, int int_7, int int_8, int int_9)
	{
		int num = int_6 - int_4;
		int num2 = int_7 - int_5;
		double double_ = (double)num / Class1395.smethod_7(int_8);
		double double_2 = (double)num2 / Class1395.smethod_7(int_9);
		return new Class1403(int_4, int_5, num, num2, double_, double_2);
	}

	private Class1403()
	{
	}

	private Class1403(int int_4, int int_5, int int_6, int int_7, double double_2, double double_3)
	{
		int_0 = int_4;
		int_1 = int_5;
		int_2 = int_6;
		int_3 = int_7;
		double_0 = double_2;
		double_1 = double_3;
	}

	[SpecialName]
	public double method_0()
	{
		return Class1395.smethod_3(int_2, double_0);
	}

	[SpecialName]
	public double method_1()
	{
		return Class1395.smethod_3(int_3, double_1);
	}
}
