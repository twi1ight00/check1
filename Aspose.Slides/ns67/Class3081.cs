namespace ns67;

internal class Class3081 : Class3073
{
	private Class3075 class3075_0;

	private double double_0;

	private readonly double double_1;

	private double double_2;

	private readonly double double_3;

	private readonly double double_4;

	private double double_5;

	public Class3075 BulletBuilder
	{
		get
		{
			return class3075_0;
		}
		set
		{
			method_7();
			method_8(value);
		}
	}

	public double Indent => double_1;

	public double MarginLeft => double_3;

	public double MarginRight => double_4;

	public Class3081(double indent, double marginLeft, double marginRight)
	{
		double_1 = indent;
		double_3 = marginLeft;
		double_4 = marginRight;
		double_0 = 0.0;
		double_2 = 0.0;
		double_5 = double_3 + double_1;
	}

	public override Class3455 vmethod_0()
	{
		return new Class3455(double_3 + double_1 + double_5 + double_4, double_0);
	}

	public void method_3(Class3080 subbuilder)
	{
		subbuilder.method_3();
		method_1(subbuilder);
		subbuilder.Point = new Class3456(double_5, subbuilder.Point.Y);
		double_5 += subbuilder.vmethod_0().Cx;
		method_6();
		method_5();
	}

	public Class3080 method_4()
	{
		Class3072 @class = method_2();
		method_6();
		return @class as Class3080;
	}

	private void method_5()
	{
		Class3072.smethod_0();
		Class3072[] array = method_0();
		Class3072[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Class3080 @class = (Class3080)array2[i];
			@class.Point = new Class3456(@class.Point.X, double_0);
		}
		if (class3075_0 != null)
		{
			class3075_0.Point = new Class3456(class3075_0.Point.X, double_0);
		}
	}

	private void method_6()
	{
		double_0 = 0.0;
		double_2 = 0.0;
		Class3072[] array = method_0();
		Class3072[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Class3080 @class = (Class3080)array2[i];
			Class3455 class2 = @class.vmethod_0();
			if (class2.Cy > double_0)
			{
				double_0 = @class.vmethod_0().Cy;
			}
			if (@class.Properties.FontSize > double_2)
			{
				double_2 = @class.Properties.FontSize;
			}
		}
	}

	private void method_7()
	{
		Class3072[] array = method_0();
		if (class3075_0 != null)
		{
			double_5 = double_3 + double_1;
			Class3072[] array2 = array;
			foreach (Class3072 @class in array2)
			{
				@class.Point = new Class3456(double_5, @class.Point.Y);
				Class3455 class2 = @class.vmethod_0();
				double_5 += class2.Cx;
			}
		}
	}

	private void method_8(Class3075 bulletBuilder)
	{
		Class3072[] array = method_0();
		class3075_0 = bulletBuilder;
		if (class3075_0 != null)
		{
			double_5 = double_3 + double_1;
			class3075_0.Point = new Class3456(double_5, class3075_0.Point.Y);
			if (class3075_0 is Class3076)
			{
				double_5 = double_3;
			}
			else
			{
				double_5 += class3075_0.vmethod_0().Cx;
			}
			Class3072[] array2 = array;
			foreach (Class3072 @class in array2)
			{
				@class.Point = new Class3456(double_5, @class.Point.Y);
				double_5 += @class.vmethod_0().Cx;
			}
			method_5();
		}
	}
}
