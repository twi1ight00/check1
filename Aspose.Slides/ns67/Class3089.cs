using System;
using System.Collections;
using DrawingMLRenderer;

namespace ns67;

internal abstract class Class3089
{
	protected interface Interface51
	{
		void Add(string name, double defaultValue);
	}

	private class Class3325 : Interface51, Interface52
	{
		private readonly SortedList sortedList_0;

		public double this[string name]
		{
			get
			{
				method_0(name);
				return (double)sortedList_0[name];
			}
			set
			{
				method_0(name);
				sortedList_0[name] = value;
			}
		}

		public Class3325()
		{
			sortedList_0 = new SortedList();
		}

		public void Add(string name, double defaultValue)
		{
			sortedList_0.Add(name, defaultValue);
		}

		private void method_0(string key)
		{
			if (!sortedList_0.ContainsKey(key))
			{
				throw new DrawingMLRenderer.Exception("The shape has no adjust value with name '" + key + "'.");
			}
		}
	}

	private Class3325 class3325_0;

	public Interface52 AdjustValues
	{
		get
		{
			if (class3325_0 == null)
			{
				class3325_0 = new Class3325();
				vmethod_0(class3325_0);
			}
			return class3325_0;
		}
	}

	protected virtual void vmethod_0(Interface51 values)
	{
	}

	protected void method_0()
	{
		class3325_0 = null;
	}

	protected static double smethod_0(double x, double y, double z)
	{
		if (y < x)
		{
			return x;
		}
		if (y > z)
		{
			return z;
		}
		return y;
	}

	protected static double smethod_1(double x, double y, double z)
	{
		return x * y / z;
	}

	protected static double smethod_2(double x, double y, double z)
	{
		return x + y - z;
	}

	protected static double smethod_3(double x, double y, double z)
	{
		return (x + y) / z;
	}

	protected static double smethod_4(double x, double y, double z)
	{
		if (!(x > 0.0))
		{
			return z;
		}
		return y;
	}

	protected static double smethod_5(double x, double y)
	{
		return Math.Atan2(y, x) * 60000.0 * 180.0 / Math.PI;
	}

	protected static double smethod_6(double x, double y, double z)
	{
		return x * Math.Cos(Math.Atan2(z, y));
	}

	protected static double smethod_7(double x, double y)
	{
		return x * Math.Cos(y * Math.PI / 10800000.0);
	}

	protected static double smethod_8(double x, double y, double z)
	{
		return Math.Sqrt(x * x + y * y + z * z);
	}

	protected static double smethod_9(double x, double y, double z)
	{
		return x * Math.Sin(Math.Atan2(z, y));
	}

	protected static double smethod_10(double x, double y)
	{
		return x * Math.Sin(y * Math.PI / 10800000.0);
	}

	protected static double smethod_11(double x, double y)
	{
		return x * Math.Tan(y * Math.PI / 10800000.0);
	}
}
