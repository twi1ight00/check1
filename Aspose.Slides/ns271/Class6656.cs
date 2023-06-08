using System.IO;

namespace ns271;

internal class Class6656 : Class6654
{
	private readonly byte[] byte_0;

	public byte[] Data => byte_0;

	public Class6656(byte[] data)
	{
		byte_0 = data;
	}

	public override Stream vmethod_0()
	{
		return new MemoryStream(Data);
	}

	public override int vmethod_1()
	{
		if (!vmethod_2())
		{
			return 0;
		}
		return Data.Length;
	}

	public override bool vmethod_2()
	{
		return Data != null;
	}
}
