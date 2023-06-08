namespace ns322;

internal class Class7376 : Class7361
{
	private Class7361 class7361_0;

	private Class7361 class7361_1;

	private Class7361 class7361_2;

	public Class7361 LeftExpression => class7361_0;

	public Class7361 MiddleExpression => class7361_1;

	public Class7361 RightExpression => class7361_2;

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_31(this);
	}

	public override string ToString()
	{
		return class7361_0.ToString() + " (" + class7361_1.ToString() + ", " + class7361_2.ToString() + ")";
	}

	public Class7376(Class7361 leftExpression, Class7361 middleExpression, Class7361 rightExpression)
	{
		class7361_0 = leftExpression;
		class7361_1 = middleExpression;
		class7361_2 = rightExpression;
	}
}
