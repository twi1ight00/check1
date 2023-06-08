using System.IO;

namespace ns60;

internal class Class2943
{
	private byte byte_0;

	private short short_0;

	private ushort ushort_0;

	private int int_0;

	public bool IsContainer => byte_0 == 15;

	public byte Version
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

	public short Instance
	{
		get
		{
			return short_0;
		}
		set
		{
			short_0 = value;
		}
	}

	internal short InstanceVersionWord => (short)((short_0 << 4) | (byte_0 & 0xF));

	public ushort Type
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	public int Length
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal Class2943()
	{
	}

	public Class2943(BinaryReader reader)
	{
		Read(reader);
	}

	public override string ToString()
	{
		return $"RecordHeader, Type:0x{ushort_0:X} [{(Enum386)ushort_0}], Version:{byte_0}, Instance:{short_0}, Length:0x{int_0:X}";
	}

	internal void Read(BinaryReader reader)
	{
		int num = reader.ReadInt32();
		byte_0 = (byte)((uint)num & 0xFu);
		short_0 = (short)((num & 0xFFF0) >> 4);
		ushort_0 = (ushort)((num & 0xFFFF0000L) >> 16);
		int_0 = (int)reader.ReadUInt32();
	}

	internal void Write(BinaryWriter writer)
	{
		int num = 0;
		num = 0 | byte_0;
		num |= short_0 << 4;
		num |= ushort_0 << 16;
		writer.Write(num);
		writer.Write(int_0);
	}
}
