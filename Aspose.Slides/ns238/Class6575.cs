namespace ns238;

internal class Class6575 : Class6568
{
	private const int int_0 = 20000;

	private const int int_1 = 12000;

	public Class6575(Class6567 context)
		: base(context)
	{
	}

	public void Write(bool isCompressed)
	{
		base.Writer.WriteByte(isCompressed ? 67 : 70);
		base.Writer.WriteByte(87);
		base.Writer.WriteByte(83);
		base.Writer.WriteByte(11);
		base.Writer.method_2(0);
		base.Writer.method_13(0, 20000, 0, 12000);
		base.Writer.WriteByte(0);
		base.Writer.WriteByte(24);
		base.Writer.method_1(1);
	}
}
