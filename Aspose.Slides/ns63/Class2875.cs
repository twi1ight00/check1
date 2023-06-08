using System.IO;
using ns60;

namespace ns63;

internal class Class2875 : Class2623
{
	internal const int int_0 = 4035;

	private int int_1;

	private Enum438 enum438_0;

	private uint uint_0;

	private Enum424 enum424_0;

	private uint uint_1;

	public int DrawAspect
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public Enum438 ObjType
	{
		get
		{
			return enum438_0;
		}
		set
		{
			enum438_0 = value;
		}
	}

	public uint ExObjId
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

	public Enum424 SubType
	{
		get
		{
			return enum424_0;
		}
		set
		{
			enum424_0 = value;
		}
	}

	public uint PersistIdRef
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

	internal Class2875()
	{
		base.Header.Type = 4035;
		base.Header.Version = 1;
		int_1 = 1;
		enum438_0 = Enum438.const_0;
		uint_0 = 0u;
		enum424_0 = Enum424.const_4;
		uint_1 = 0u;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int_1 = reader.ReadInt32();
		enum438_0 = (Enum438)reader.ReadInt32();
		uint_0 = reader.ReadUInt32();
		enum424_0 = (Enum424)reader.ReadInt32();
		uint_1 = reader.ReadUInt32();
		reader.ReadInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(int_1);
		writer.Write((int)enum438_0);
		writer.Write(uint_0);
		writer.Write((int)enum424_0);
		writer.Write(uint_1);
		writer.Write(8015616);
	}

	public override int vmethod_2()
	{
		return 24;
	}
}
