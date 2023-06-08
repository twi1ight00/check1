using System;
using System.IO;

namespace ns71;

internal class Class3514 : Class3473
{
	private readonly int int_0;

	private Class3508 class3508_0;

	private ushort ushort_0;

	private uint uint_0;

	private string string_0;

	private uint uint_1;

	private Class3507 class3507_0;

	private uint uint_2;

	private uint uint_3;

	private string string_1;

	private Guid guid_0;

	private uint uint_4;

	internal Class3508 OriginalRecord
	{
		get
		{
			return class3508_0;
		}
		set
		{
			class3508_0 = value;
		}
	}

	public ushort Id
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

	public uint SizeTwiddled
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

	public string LibidTwiddled
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public uint SizeOfLibidTwiddled
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

	internal Class3507 NameRecordExtended
	{
		get
		{
			return class3507_0;
		}
		set
		{
			class3507_0 = value;
		}
	}

	public uint SizeExtended
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

	public uint SizeOfLibidExtended
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

	public string LibidExtended
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public Guid OriginalTypeLib
	{
		get
		{
			return guid_0;
		}
		set
		{
			guid_0 = value;
		}
	}

	public uint Cookie
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

	internal Class3514(int codePage)
	{
		int_0 = codePage;
	}

	internal override void vmethod_0(BinaryReader reader)
	{
		if (Class3522.smethod_0(reader) == 51)
		{
			class3508_0 = new Class3508();
			class3508_0.vmethod_0(reader);
		}
		ushort_0 = reader.ReadUInt16();
		if (ushort_0 != 47)
		{
			throw new Exception10();
		}
		uint_0 = reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
		string_0 = Class3524.smethod_1(reader.ReadBytes((int)uint_1), int_0);
		if (reader.ReadUInt32() != 0)
		{
			throw new Exception10();
		}
		if (reader.ReadUInt16() != 0)
		{
			throw new Exception10();
		}
		if (Class3522.smethod_0(reader) == 22)
		{
			class3507_0 = new Class3507(int_0);
			class3507_0.vmethod_0(reader);
		}
		ushort num = reader.ReadUInt16();
		if (num != 48)
		{
			throw new Exception10();
		}
		uint_2 = reader.ReadUInt32();
		uint_3 = reader.ReadUInt32();
		string_1 = Class3524.smethod_1(reader.ReadBytes((int)uint_3), int_0);
		reader.ReadUInt32();
		reader.ReadUInt16();
		byte[] b = reader.ReadBytes(16);
		guid_0 = new Guid(b);
		uint_4 = reader.ReadUInt32();
	}

	internal override void vmethod_1(BinaryWriter writer)
	{
		if (class3508_0 != null)
		{
			class3508_0.vmethod_1(writer);
		}
		writer.Write((ushort)47);
		writer.Write(uint_0);
		Class3523.smethod_3(writer, string_0, int_0);
		writer.Write(0u);
		writer.Write((ushort)0);
		if (class3507_0 != null)
		{
			class3507_0.vmethod_1(writer);
		}
		writer.Write((ushort)48);
		writer.Write(uint_2);
		Class3523.smethod_3(writer, string_1, int_0);
		writer.Write(0u);
		writer.Write((ushort)0);
		writer.Write(guid_0.ToByteArray());
		writer.Write(uint_4);
	}
}
