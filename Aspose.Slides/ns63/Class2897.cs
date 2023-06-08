using System.IO;
using ns60;

namespace ns63;

internal class Class2897 : Class2623
{
	public const int int_0 = 5003;

	private byte[] byte_0;

	public Class2897()
	{
		base.Header.Type = 5003;
		base.Header.Instance = 3;
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
