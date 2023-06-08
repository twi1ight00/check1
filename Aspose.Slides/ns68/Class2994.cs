using System;
using System.Collections.Generic;
using ns67;

namespace ns68;

internal sealed class Class2994 : Class2991
{
	public class Class2997 : IComparer<Class2994>
	{
		int IComparer<Class2994>.Compare(Class2994 x, Class2994 y)
		{
			if (x.short_0 < y.short_0)
			{
				return -1;
			}
			if (x.short_0 > y.short_0)
			{
				return 1;
			}
			return 0;
		}
	}

	private double double_0;

	private Struct159 struct159_2;

	private short short_0;

	private Class2998 class2998_0;

	private int int_0;

	private Struct159 struct159_3;

	private Struct159 struct159_4;

	private Class3014 class3014_0;

	private Class3027 class3027_0;

	public short EdgeID
	{
		get
		{
			return short_0;
		}
		set
		{
			short_0 = value;
		}
	}

	public double Length => double_0;

	public Struct159 InnerNormal => struct159_2;

	public Class2998 Contour
	{
		get
		{
			return class2998_0;
		}
		set
		{
			class2998_0 = value;
		}
	}

	public int ContourIndex
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public Struct159 AB => struct159_3;

	public Struct159 BA => struct159_4;

	public Class3014 Step1BuilderCache => class3014_0;

	public Class3027 Step2PrimitiveBuilder => class3027_0;

	public Class2994(Struct159 a, Struct159 b)
		: base(a, b)
	{
		struct159_3 = new Struct159(b.X - a.X, b.Y - a.Y);
		struct159_4 = new Struct159(a.X - b.X, a.Y - b.Y);
		class3014_0 = new Class3014();
		class3027_0 = new Class3027(this);
		double_0 = Math.Sqrt(AB.X * AB.X + AB.Y * AB.Y);
		struct159_2 = new Struct159(AB.Y / double_0, (0.0 - AB.X) / double_0);
	}

	public Class2994(Struct159 a, Struct159 b, double length)
		: base(a, b)
	{
		struct159_3 = new Struct159(b.X - a.X, b.Y - a.Y);
		struct159_4 = new Struct159(a.X - b.X, a.Y - b.Y);
		class3014_0 = new Class3014();
		class3027_0 = new Class3027(this);
		double_0 = length;
		struct159_2 = new Struct159(AB.Y / double_0, (0.0 - AB.X) / double_0);
	}
}
