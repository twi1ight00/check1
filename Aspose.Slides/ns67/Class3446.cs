namespace ns67;

internal sealed class Class3446 : Class3443
{
	private Struct159 struct159_0;

	public Struct159 Point
	{
		get
		{
			return struct159_0;
		}
		set
		{
			struct159_0 = value;
		}
	}

	public Class3446(double x, double y)
		: this(new Struct159(x, y))
	{
	}

	public Class3446(Struct159 point)
	{
		struct159_0 = point;
	}

	public override Class3443 vmethod_0()
	{
		return new Class3446(struct159_0);
	}

	internal override Struct159 vmethod_1(Class3062 dest, Struct159 startingPoint)
	{
		dest.method_3(startingPoint.method_1(), struct159_0.method_1());
		return struct159_0;
	}
}
