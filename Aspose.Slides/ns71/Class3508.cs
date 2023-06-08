using System.IO;

namespace ns71;

internal class Class3508 : Class3483
{
	private uint uint_0;

	private byte[] byte_0;

	public override ushort Id => 51;

	protected override void vmethod_2(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		byte_0 = reader.ReadBytes((int)uint_0);
	}

	protected override void vmethod_3(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(byte_0);
	}
}
