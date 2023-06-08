using ns152;

namespace ns153;

internal class Class4708
{
	private Class4707 class4707_0;

	public Class4708(Class4707 operandStack)
	{
		class4707_0 = operandStack;
	}

	public bool method_0()
	{
		return class4707_0.Count > 0;
	}

	public bool method_1()
	{
		return method_2(2);
	}

	public bool method_2(int stackItems)
	{
		return class4707_0.Count >= stackItems;
	}
}
