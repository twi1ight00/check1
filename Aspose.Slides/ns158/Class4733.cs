using ns118;
using ns134;

namespace ns158;

internal class Class4733
{
	private bool bool_0;

	private Class4602[] class4602_0;

	private Interface116 interface116_0;

	private int int_0;

	private double[] double_0;

	private double[] double_1;

	private double[] double_2;

	private double[] double_3;

	private double double_4;

	private double double_5;

	public bool IsRecording => bool_0;

	public Class4602[] ResultCurves => class4602_0;

	public Class4733(Interface116 context)
	{
		bool_0 = false;
		interface116_0 = context;
	}

	public void method_0()
	{
		bool_0 = true;
		int_0 = 0;
		class4602_0 = new Class4602[2];
		double_0 = new double[3];
		double_1 = new double[3];
		double_2 = new double[3];
		double_3 = new double[3];
	}

	public void method_1()
	{
		class4602_0[0] = Class4701.smethod_3(interface116_0, double_1[0], double_0[0], double_1[1], double_0[1], double_1[2], double_0[2]);
		class4602_0[1] = Class4701.smethod_3(interface116_0, double_3[0], double_2[0], double_3[1], double_2[1], double_3[2], double_2[2]);
		bool_0 = false;
	}

	public void method_2(double dx, double dy)
	{
		switch (int_0)
		{
		case 0:
			double_4 = dx;
			double_5 = dy;
			break;
		case 1:
			double_1[int_0 - 1] = dx + double_4;
			double_0[int_0 - 1] = dy + double_5;
			break;
		case 2:
		case 3:
			double_1[int_0 - 1] = dx;
			double_0[int_0 - 1] = dy;
			break;
		case 4:
		case 5:
		case 6:
			double_3[int_0 - 4] = dx;
			double_2[int_0 - 4] = dy;
			break;
		}
		int_0++;
	}
}
