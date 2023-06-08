using System.IO;

namespace ns71;

internal class Class3480 : Class3478
{
	private byte byte_0;

	public byte Value
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

	internal override void vmethod_0(BinaryReader reader)
	{
		byte_0 = reader.ReadByte();
	}

	internal override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(byte_0);
	}

	public override void vmethod_2(BinaryWriter writer)
	{
		writer.Write(byte_0);
	}
}
