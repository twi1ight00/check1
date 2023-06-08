using System;
using System.Drawing;

namespace ns51;

internal class Class1132 : IComparable
{
	internal Class1134[] class1134_0;

	private bool bool_0;

	internal Class1134 class1134_1;

	internal Class1134 class1134_2;

	internal Class1134 class1134_3;

	internal Color color_0;

	public Class1134 Normal => class1134_1;

	public Class1134 MinCoords => class1134_2;

	public Class1134 MaxCoords => class1134_3;

	public Class1134[] Vertexes => class1134_0;

	public Color FaceColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	public Class1132(Class1134[] vertexes, bool toLeft)
	{
		class1134_0 = (Class1134[])vertexes.Clone();
		bool_0 = toLeft;
		class1134_2 = null;
		class1134_3 = null;
	}

	public void method_0()
	{
		class1134_2 = new Class1134(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
		class1134_3 = new Class1134(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
		Class1134[] array = class1134_0;
		foreach (Class1134 @class in array)
		{
			if (class1134_2.float_0 > @class.float_0)
			{
				class1134_2.float_0 = @class.float_0;
			}
			if (class1134_2.float_1 > @class.float_1)
			{
				class1134_2.float_1 = @class.float_1;
			}
			if (class1134_2.float_2 > @class.float_2)
			{
				class1134_2.float_2 = @class.float_2;
			}
			if (class1134_3.float_0 < @class.float_0)
			{
				class1134_3.float_0 = @class.float_0;
			}
			if (class1134_3.float_1 < @class.float_1)
			{
				class1134_3.float_1 = @class.float_1;
			}
			if (class1134_3.float_2 < @class.float_2)
			{
				class1134_3.float_2 = @class.float_2;
			}
		}
	}

	public void method_1()
	{
		Class1134 @class = Class1134.smethod_0(class1134_0[1], class1134_0[0]);
		Class1134 class2 = Class1134.smethod_0(class1134_0[class1134_0.Length - 1], class1134_0[0]);
		class1134_1 = (bool_0 ? Class1134.smethod_2(@class, class2) : Class1134.smethod_2(class2, @class));
		class1134_1.method_0();
	}

	public int CompareTo(object obj)
	{
		float float_ = ((Class1132)obj).class1134_2.float_2;
		if (class1134_2.float_2 < float_)
		{
			return 1;
		}
		if (class1134_2.float_2 > float_)
		{
			return -1;
		}
		return 0;
	}
}
