namespace ns67;

internal sealed class Class3082 : Class3073
{
	private readonly Class3390 class3390_0;

	private double double_0;

	private readonly Class3406 class3406_0;

	private double double_1;

	public Class3082(Class3390 paragraphProperties, Class3406 defaultCharacterProperties)
	{
		class3390_0 = paragraphProperties;
		class3406_0 = defaultCharacterProperties;
		double_0 = 0.0;
		double_1 = 0.0;
	}

	public override Class3455 vmethod_0()
	{
		return new Class3455(double_1, double_0);
	}

	public Class3081 method_3()
	{
		int num = ((class3390_0.Level == null) ? 1 : (class3390_0.Level.Value + 1));
		double marginLeft = ((class3390_0.LeftMargin != null) ? class3390_0.LeftMargin.Value : ((double)(347663 * num)));
		double marginRight = ((class3390_0.RightMargin != null) ? class3390_0.RightMargin.Value : 0.0);
		double indent = 0.0;
		if (GetCount() == 0)
		{
			indent = ((class3390_0.Indent != null) ? class3390_0.Indent.Value : (-342900.0));
		}
		return new Class3081(indent, marginLeft, marginRight);
	}

	public void method_4(Class3081 lineBuilder)
	{
		lineBuilder.Point = new Class3456(0.0, double_0);
		method_1(lineBuilder);
		double_0 += lineBuilder.vmethod_0().Cy;
		method_6();
	}

	public Class3081 method_5()
	{
		Class3072 @class = method_2();
		double_0 -= @class.vmethod_0().Cy;
		method_6();
		return (Class3081)@class;
	}

	private void method_6()
	{
		double_1 = 0.0;
		Class3072[] array = method_0();
		Class3072[] array2 = array;
		foreach (Class3072 @class in array2)
		{
			if (@class.vmethod_0().Cx > double_1)
			{
				double_1 = @class.vmethod_0().Cx;
			}
		}
	}
}
