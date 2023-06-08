namespace ns67;

internal sealed class Class3447 : Class3443
{
	private Struct159 struct159_0;

	private Struct159 struct159_1;

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

	public Struct159 EndingPoint
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

	public Class3447(Struct159 firstControlPoint, Struct159 endingPoint)
	{
		FirstControlPoint = firstControlPoint;
		EndingPoint = endingPoint;
	}

	public override Class3443 vmethod_0()
	{
		return new Class3447(struct159_0, struct159_1);
	}

	internal override Struct159 vmethod_1(Class3062 dest, Struct159 startingPoint)
	{
		double num = struct159_0.X - startingPoint.X;
		double num2 = struct159_0.Y - startingPoint.Y;
		double num3 = struct159_1.X - startingPoint.X;
		double num4 = struct159_1.Y - startingPoint.Y;
		double num5 = num * 2.0 / 3.0;
		double num6 = num2 * 2.0 / 3.0;
		double num7 = num5 + num3 / 3.0;
		double num8 = num6 + num4 / 3.0;
		Struct159 @struct = new Struct159(startingPoint.X + num5, startingPoint.Y + num6);
		Struct159 struct2 = new Struct159(startingPoint.X + num7, startingPoint.Y + num8);
		dest.method_5(startingPoint.method_1(), @struct.method_1(), struct2.method_1(), struct159_1.method_1());
		return struct159_1;
	}
}
