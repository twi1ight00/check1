using System.Runtime.CompilerServices;

namespace ns18;

internal struct Struct90
{
	private int int_0;

	private int int_1;

	private byte byte_0;

	public int Code => int_0;

	[SpecialName]
	public void method_0(int int_2)
	{
		int_0 = int_2;
	}

	[SpecialName]
	public int method_1()
	{
		return int_1;
	}

	[SpecialName]
	public void method_2(int int_2)
	{
		int_1 = int_2;
	}

	[SpecialName]
	public byte method_3()
	{
		return byte_0;
	}

	[SpecialName]
	public void method_4(byte byte_1)
	{
		byte_0 = byte_1;
	}
}
