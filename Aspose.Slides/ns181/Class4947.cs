namespace ns181;

internal abstract class Class4947 : Class4944
{
	protected class Class4977 : Class4976
	{
		internal int int_3;

		internal Class4977(int stretch, int shrink, int adj)
			: base(stretch, shrink, adj)
		{
		}
	}

	private int int_19;

	private int int_20;

	private Class4977 class4977_0;

	private int int_21;

	public Class4947()
	{
	}

	public Class4947(int stretch, int shrink, int adj)
	{
		class4977_0 = new Class4977(stretch, shrink, adj);
	}

	public int method_53()
	{
		return int_19;
	}

	public void method_54(int textWordSpaceAdjusT)
	{
		int_19 = textWordSpaceAdjusT;
	}

	public int method_55()
	{
		return int_20;
	}

	public void method_56(int textLetterSpaceAdjusT)
	{
		int_20 = textLetterSpaceAdjusT;
	}

	public void method_57(int spaceDiff)
	{
		class4977_0.int_3 = spaceDiff;
	}

	public override bool vmethod_5(double variationFactor, int lineStretch, int lineShrink)
	{
		if (class4977_0 != null)
		{
			double num = 1.0;
			if (variationFactor < 0.0)
			{
				num = ((int_19 >= 0) ? ((double)class4977_0.int_1 / (double)class4977_0.int_0 * ((double)lineStretch / (double)lineShrink)) : ((double)class4977_0.int_0 / (double)class4977_0.int_1 * ((double)lineShrink / (double)lineStretch)));
			}
			int_19 = (int)((double)(int_19 - class4977_0.int_3) * variationFactor * num) + class4977_0.int_3;
			int_20 = (int)((double)int_20 * variationFactor);
			int num2 = class4977_0.int_2;
			class4977_0.int_2 = (int)((double)class4977_0.int_2 * num * variationFactor);
			int_12 += class4977_0.int_2 - num2;
		}
		return false;
	}

	public int method_58()
	{
		return int_21;
	}

	public void method_59(int baselineOffset)
	{
		int_21 = baselineOffset;
	}

	internal override int vmethod_6()
	{
		return method_42();
	}

	internal override int vmethod_7()
	{
		return vmethod_1();
	}
}
