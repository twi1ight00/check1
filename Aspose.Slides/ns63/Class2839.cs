using System.IO;
using ns60;

namespace ns63;

internal class Class2839 : Class2623
{
	internal const int int_0 = 11011;

	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private byte byte_0;

	private byte byte_1;

	public uint BuildType
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

	public uint BuildId
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public uint ShapeIdRef
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	public byte FExpanded
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

	public byte FUIExpanded
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

	public Class2839()
	{
		base.Header.Type = 11011;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
		uint_2 = reader.ReadUInt32();
		byte_0 = reader.ReadByte();
		byte_1 = reader.ReadByte();
		reader.BaseStream.Seek(2L, SeekOrigin.Current);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(uint_1);
		writer.Write(uint_2);
		writer.Write(byte_0);
		writer.Write(byte_1);
		writer.Write((byte)0);
		writer.Write((byte)0);
	}

	public override int vmethod_2()
	{
		return 16;
	}
}
