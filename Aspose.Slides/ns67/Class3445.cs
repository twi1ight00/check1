namespace ns67;

internal sealed class Class3445 : Class3443
{
	private Struct159 struct159_0;

	private Struct159 struct159_1;

	private Struct159 struct159_2;

	public Struct159 FirstControlPoint
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

	public Struct159 SecondControlPoint
	{
		get
		{
			return struct159_1;
		}
		set
		{
			struct159_1 = value;
		}
	}

	public Struct159 EndingPoint
	{
		get
		{
			return struct159_2;
		}
		set
		{
			struct159_2 = value;
		}
	}

	public Class3445(Struct159 firstControlPoint, Struct159 secondControlPoint, Struct159 endingPoint)
	{
		FirstControlPoint = firstControlPoint;
		SecondControlPoint = secondControlPoint;
		EndingPoint = endingPoint;
	}

	public override Class3443 vmethod_0()
	{
		return new Class3445(struct159_0, struct159_1, struct159_2);
	}

	internal override Struct159 vmethod_1(Class3062 dest, Struct159 startingPoint)
	{
		dest.method_5(startingPoint.method_1(), struct159_0.method_1(), struct159_1.method_1(), struct159_2.method_1());
		return struct159_2;
	}
}
