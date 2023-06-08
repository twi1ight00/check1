using System.IO;
using ns60;

namespace ns63;

internal class Class2886 : Class2623
{
	internal const int int_0 = 11017;

	private uint uint_0;

	private uint uint_1;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	private uint uint_2;

	public uint ParaBuild
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

	public uint BuildLevel
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

	public byte FAnimBackground
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

	public byte FReverse
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

	public byte FUserSetAnimBackground
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
		}
	}

	public byte FAutomatic
	{
		get
		{
			return byte_3;
		}
		set
		{
			byte_3 = value;
		}
	}

	public uint DelayTime
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

	public Class2886()
	{
		base.Header.Type = 11017;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
		byte_0 = reader.ReadByte();
		byte_1 = reader.ReadByte();
		byte_2 = reader.ReadByte();
		byte_3 = reader.ReadByte();
		uint_2 = reader.ReadUInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(uint_1);
		writer.Write(byte_0);
		writer.Write(byte_1);
		writer.Write(byte_2);
		writer.Write(byte_3);
		writer.Write(uint_2);
	}

	public override int vmethod_2()
	{
		return 16;
	}
}
