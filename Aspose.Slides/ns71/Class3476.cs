using System.IO;

namespace ns71;

internal class Class3476 : Class3473
{
	private uint uint_0;

	private byte byte_0;

	private byte byte_1;

	public uint CompressedChunkSize
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public byte CompressedChunkSignature
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

	public byte CompressedChunkFlag
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	internal override void vmethod_0(BinaryReader reader)
	{
		ushort num = reader.ReadUInt16();
		uint_0 = num & 0xFFFu;
		byte_0 = (byte)((uint)(num >> 12) & 7u);
		byte_1 = (byte)((uint)(num >> 15) & 1u);
	}

	internal override void vmethod_1(BinaryWriter writer)
	{
		ushort num = (ushort)uint_0;
		num = (ushort)(num + (ushort)(byte_0 << 12));
		num = (ushort)(num + (ushort)(byte_1 << 15));
		writer.Write(num);
	}
}
