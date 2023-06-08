using System.IO;
using ns60;

namespace ns63;

internal class Class2891 : Class2623
{
	internal const int int_0 = 2023;

	private byte[] byte_0;

	public byte[] Data
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	internal Class2891()
	{
		base.Header.Type = 2023;
		byte_0 = new byte[0];
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		byte_0 = reader.ReadBytes(base.Header.Length);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(byte_0);
	}

	public override int vmethod_2()
	{
		return byte_0.Length;
	}
}
