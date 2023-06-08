using Aspose.JavaScript;
using ns328;

namespace ns322;

internal class Class7364 : Class7361
{
	private Class7361 class7361_0;

	private Class7361 class7361_1;

	private BinaryExpressionType binaryExpressionType_0;

	public Class7361 LeftExpression => class7361_0;

	public Class7361 RightExpression => class7361_1;

	public BinaryExpressionType Type => binaryExpressionType_0;

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_30(this);
	}

	public override string ToString()
	{
		return Class7691.smethod_0(typeof(BinaryExpressionType)).vmethod_0(Type) + " (" + class7361_0.ToString() + ", " + class7361_1.ToString() + ")";
	}

	public Class7364(BinaryExpressionType type, Class7361 leftExpression, Class7361 rightExpression)
	{
		binaryExpressionType_0 = type;
		class7361_0 = leftExpression;
		class7361_1 = rightExpression;
	}
}
