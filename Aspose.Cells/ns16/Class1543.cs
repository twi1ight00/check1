namespace ns16;

internal class Class1543
{
	private uint uint_0;

	internal bool method_0(Enum216 enum216_0)
	{
		return (uint_0 & (uint)enum216_0) != 0;
	}

	internal void method_1(Enum216 enum216_0)
	{
		uint_0 |= (uint)enum216_0;
	}
}
