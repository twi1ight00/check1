namespace ns130;

internal class Class4585
{
	public const int int_0 = 4;

	public Class4592 class4592_0;

	public byte[] byte_0;

	private Class4573 class4573_0;

	public Class4585(string tag, byte[] data)
	{
		class4592_0 = new Class4592();
		class4592_0.string_0 = tag;
		class4592_0.uint_2 = (uint)data.Length;
		byte_0 = data;
		class4573_0 = new Class4573(data);
	}

	protected void method_0(int offset, int value)
	{
		class4573_0.Position = offset;
		class4573_0.Write(value);
	}

	protected void method_1(int offset, uint value)
	{
		class4573_0.Position = offset;
		class4573_0.Write(value);
	}

	protected void method_2(int offset, short value)
	{
		class4573_0.Position = offset;
		class4573_0.Write(value);
	}

	protected void method_3(int offset, ushort value)
	{
		class4573_0.Position = offset;
		class4573_0.method_0(value);
	}

	protected void method_4(int offset, byte value)
	{
		class4573_0.Position = offset;
		class4573_0.Write(value);
	}
}
