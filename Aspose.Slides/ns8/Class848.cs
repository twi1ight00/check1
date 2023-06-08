using System.Collections.Generic;
using ns56;

namespace ns8;

internal class Class848
{
	private Enum305 enum305_0;

	private Class837 class837_0;

	private double double_0;

	private double double_1;

	private double double_2;

	private Enum326 enum326_0;

	private List<Class837> list_0;

	public Enum305 Type => enum305_0;

	public double TargetFactor => double_0 * double_1;

	public double CustomRatio
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

	public Class837 Target => class837_0;

	public Enum326 Operator => enum326_0;

	public List<Class837> Points => list_0;

	public Class848(double value, Enum305 type, Enum326 op)
	{
		enum305_0 = type;
		double_0 = 1.0;
		double_1 = 1.0;
		enum326_0 = op;
		double_2 = value;
		list_0 = new List<Class837>();
	}

	public Class848(Class837 target, Enum305 type, double factor, Enum326 op)
	{
		enum305_0 = type;
		class837_0 = target;
		double_0 = factor;
		double_1 = 1.0;
		enum326_0 = op;
		list_0 = new List<Class837>();
	}

	public double method_0()
	{
		if (class837_0 != null && (class837_0 == null || enum305_0 != Enum305.const_22))
		{
			return class837_0.method_32(Type) * TargetFactor;
		}
		return double_2 * TargetFactor;
	}
}
