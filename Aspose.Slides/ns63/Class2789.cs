using System.IO;
using ns60;

namespace ns63;

internal class Class2789 : Class2623
{
	protected byte[] byte_0;

	internal Class2789()
	{
	}

	internal Class2789(ushort type)
	{
		base.Header.Type = type;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		byte_0 = reader.ReadBytes(base.Header.Length);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		if (byte_0 != null)
		{
			writer.Write(byte_0);
		}
	}

	public override int vmethod_2()
	{
		if (byte_0 == null)
		{
			return 0;
		}
		return byte_0.Length;
	}
}
