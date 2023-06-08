using System.IO;
using Aspose.Slides;
using ns60;

namespace ns63;

internal class Class2895 : Class2623
{
	public const int int_0 = 4085;

	private int int_1 = 28;

	private uint uint_0 = 256u;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	private uint uint_4;

	private Enum454 enum454_0;

	private uint uint_5;

	public uint LastSlideIdRef
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

	public uint OffsetLastEdit
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

	public int OffsetPersistDirectory
	{
		get
		{
			return (int)uint_2;
		}
		set
		{
			uint_2 = (uint)value;
		}
	}

	public uint DocPersistIdRef
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	public uint PersistIdSeed
	{
		get
		{
			return uint_4;
		}
		set
		{
			uint_4 = value;
		}
	}

	public Enum454 LastView
	{
		get
		{
			return enum454_0;
		}
		set
		{
			enum454_0 = value;
		}
	}

	public uint EncryptSessionPersistIdRef
	{
		get
		{
			return uint_5;
		}
		set
		{
			if (value == 0)
			{
				int_1 = 28;
			}
			else
			{
				int_1 = 32;
			}
			uint_5 = value;
		}
	}

	public Class2895()
	{
		base.Header.Type = 4085;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int_1 = base.Header.Length;
		uint_0 = reader.ReadUInt32();
		reader.ReadInt16();
		reader.ReadByte();
		reader.ReadByte();
		uint_1 = reader.ReadUInt32();
		uint_2 = reader.ReadUInt32();
		uint_3 = reader.ReadUInt32();
		uint_4 = reader.ReadUInt32();
		enum454_0 = (Enum454)reader.ReadInt16();
		reader.ReadInt16();
		switch (base.Header.Length)
		{
		default:
			throw new PptReadException("Wrong size of UserEditAtom.");
		case 32:
			EncryptSessionPersistIdRef = reader.ReadUInt32();
			break;
		case 28:
			EncryptSessionPersistIdRef = 0u;
			break;
		}
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(50338212);
		writer.Write(uint_1);
		writer.Write(uint_2);
		writer.Write(uint_3);
		writer.Write(uint_4);
		writer.Write((short)enum454_0);
		writer.Write((short)12741);
		if (int_1 > 28)
		{
			writer.Write(uint_5);
		}
	}

	public override int vmethod_2()
	{
		return int_1;
	}
}
