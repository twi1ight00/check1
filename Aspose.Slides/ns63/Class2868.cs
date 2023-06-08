using System.IO;
using ns15;
using ns60;

namespace ns63;

internal class Class2868 : Class2623
{
	internal const int int_0 = 4045;

	private Enum423 enum423_0;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	public Enum423 ExColorFollow
	{
		get
		{
			return enum423_0;
		}
		set
		{
			enum423_0 = value;
		}
	}

	public byte FCantLockServer
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

	public byte FNoSizeToServer
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

	public byte FIsTable
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

	public Class2868()
	{
		base.Header.Type = 4045;
		enum423_0 = Enum423.const_0;
		byte_0 = 0;
		byte_1 = 0;
		byte_2 = 0;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		enum423_0 = (Enum423)reader.ReadInt32();
		byte_0 = reader.ReadByte();
		byte_1 = reader.ReadByte();
		byte_2 = reader.ReadByte();
		reader.ReadByte();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write((int)enum423_0);
		writer.Write(byte_0);
		writer.Write(byte_1);
		writer.Write(byte_2);
		writer.Write((byte)0);
	}

	public override int vmethod_2()
	{
		return 8;
	}
}
