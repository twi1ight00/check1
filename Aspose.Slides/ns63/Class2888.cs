using System.IO;
using ns60;

namespace ns63;

internal class Class2888 : Class2623
{
	internal const int int_0 = 1007;

	private Enum451 enum451_0;

	private readonly Enum384[] enum384_0 = new Enum384[8];

	private uint uint_0;

	private uint uint_1;

	private int int_1;

	private short short_0 = 12299;

	public Enum451 Geom
	{
		get
		{
			return enum451_0;
		}
		set
		{
			enum451_0 = value;
		}
	}

	public Enum384[] RgPlaceholderTypes => enum384_0;

	public uint MasterIdRef
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

	public uint NotesIdRef
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

	public bool FMasterObjects
	{
		get
		{
			return (int_1 & 1) == 1;
		}
		set
		{
			if (value)
			{
				int_1 |= 1;
			}
			else
			{
				int_1 &= -2;
			}
		}
	}

	public bool FMasterScheme
	{
		get
		{
			return (int_1 & 2) == 2;
		}
		set
		{
			if (value)
			{
				int_1 |= 2;
			}
			else
			{
				int_1 &= -3;
			}
		}
	}

	public bool FMasterBackground
	{
		get
		{
			return (int_1 & 4) == 4;
		}
		set
		{
			if (value)
			{
				int_1 |= 4;
			}
			else
			{
				int_1 &= -5;
			}
		}
	}

	public Class2888()
	{
		base.Header.Type = 1007;
		base.Header.Version = 2;
		for (int i = 0; i < enum384_0.Length; i++)
		{
			enum384_0[i] = Enum384.const_0;
		}
	}

	internal void method_1(Enum452 queryType)
	{
		base.Header.Instance = 0;
		if (queryType == Enum452.const_2)
		{
			enum451_0 = Enum451.const_0;
			enum384_0[0] = Enum384.const_15;
			enum384_0[1] = Enum384.const_16;
			enum384_0[2] = Enum384.const_0;
			enum384_0[3] = Enum384.const_0;
			enum384_0[4] = Enum384.const_0;
			enum384_0[5] = Enum384.const_0;
			enum384_0[6] = Enum384.const_0;
			enum384_0[7] = Enum384.const_0;
			uint_0 = 2147483648u;
			uint_1 = 0u;
			int_1 = 7;
		}
		else
		{
			enum451_0 = Enum451.const_1;
			enum384_0[0] = Enum384.const_1;
			enum384_0[1] = Enum384.const_2;
			enum384_0[2] = Enum384.const_7;
			enum384_0[3] = Enum384.const_9;
			enum384_0[4] = Enum384.const_8;
			enum384_0[5] = Enum384.const_0;
			enum384_0[6] = Enum384.const_0;
			enum384_0[7] = Enum384.const_0;
			uint_0 = 0u;
			uint_1 = 0u;
			int_1 = 0;
		}
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		enum451_0 = (Enum451)reader.ReadInt32();
		enum384_0[0] = (Enum384)reader.ReadByte();
		enum384_0[1] = (Enum384)reader.ReadByte();
		enum384_0[2] = (Enum384)reader.ReadByte();
		enum384_0[3] = (Enum384)reader.ReadByte();
		enum384_0[4] = (Enum384)reader.ReadByte();
		enum384_0[5] = (Enum384)reader.ReadByte();
		enum384_0[6] = (Enum384)reader.ReadByte();
		enum384_0[7] = (Enum384)reader.ReadByte();
		uint_0 = reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
		int_1 = reader.ReadUInt16();
		short_0 = reader.ReadInt16();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write((uint)enum451_0);
		writer.Write((byte)enum384_0[0]);
		writer.Write((byte)enum384_0[1]);
		writer.Write((byte)enum384_0[2]);
		writer.Write((byte)enum384_0[3]);
		writer.Write((byte)enum384_0[4]);
		writer.Write((byte)enum384_0[5]);
		writer.Write((byte)enum384_0[6]);
		writer.Write((byte)enum384_0[7]);
		writer.Write(uint_0);
		writer.Write(uint_1);
		writer.Write((ushort)int_1);
		writer.Write(short_0);
	}

	public override int vmethod_2()
	{
		return 24;
	}
}
