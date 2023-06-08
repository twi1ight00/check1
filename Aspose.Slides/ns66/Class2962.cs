using System;
using System.IO;
using System.Text;
using ns61;

namespace ns66;

internal sealed class Class2962
{
	private const int int_0 = 33554433;

	private const int int_1 = -1;

	private int int_2;

	private int int_3 = 33554433;

	private Enum439 enum439_0;

	private Class2960 class2960_0;

	private Class2960 class2960_1;

	private Class2960 class2960_2;

	private int int_4 = -1;

	private Guid guid_0;

	private string string_0;

	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private int int_5;

	public int Version => int_3;

	public int Flags
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public Enum439 LinkUpdateOption
	{
		get
		{
			return enum439_0;
		}
		set
		{
			enum439_0 = value;
		}
	}

	public uint ReservedMonikerStreamSize
	{
		get
		{
			if (class2960_0 == null)
			{
				return 0u;
			}
			return class2960_0.method_0();
		}
	}

	public Class2960 ReservedMonikerStream
	{
		get
		{
			return class2960_0;
		}
		set
		{
			class2960_0 = value;
		}
	}

	public uint RelativeSourceMonikerStreamSize
	{
		get
		{
			if (class2960_1 == null)
			{
				return 0u;
			}
			return class2960_1.method_0();
		}
	}

	public Class2960 RelativeSourceMonikerStream
	{
		get
		{
			return class2960_1;
		}
		set
		{
			class2960_1 = value;
		}
	}

	public uint AbsoluteSourceMonikerStreamSize
	{
		get
		{
			if (class2960_2 == null)
			{
				return 0u;
			}
			return class2960_2.method_0();
		}
	}

	public Class2960 AbsoluteSourceMonikerStream
	{
		get
		{
			return class2960_2;
		}
		set
		{
			class2960_2 = value;
		}
	}

	public int ClsidIndicator => int_4;

	public Guid Clsid
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

	public string ReservedDisplayName
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

	public uint LocalUpdateTime
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

	public uint LocalCheckUpdateTime
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

	public uint RemoteUpdateTime
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

	public Class2962()
	{
	}

	public Class2962(BinaryReader reader)
	{
		Read(reader);
	}

	public void Read(BinaryReader reader)
	{
		if (reader.ReadInt32() != 33554433)
		{
			throw new Exception7("Wrong Version field value in OLEStream.");
		}
		Flags = reader.ReadInt32();
		LinkUpdateOption = (Enum439)reader.ReadInt32();
		if (reader.ReadInt32() != 0)
		{
			throw new Exception7("Wrong Reserved1 field value in OLEStream.");
		}
		if (reader.ReadUInt32() != 0)
		{
			class2960_0 = new Class2960(reader);
		}
		if (Flags != 0)
		{
			if (reader.ReadUInt32() != 0)
			{
				class2960_1 = new Class2960(reader);
			}
			if (reader.ReadUInt32() != 0)
			{
				class2960_2 = new Class2960(reader);
			}
			int num = reader.ReadInt32();
			if (num != -1)
			{
				throw new Exception7("Wrong ClsidIndicator field value in OLEStream.");
			}
			Clsid = new Guid(reader.ReadBytes(16));
			int num2 = reader.ReadInt32();
			if (num2 != 0)
			{
				ReservedDisplayName = Encoding.Unicode.GetString(reader.ReadBytes(num2 * 2));
			}
			int_5 = reader.ReadInt32();
			LocalUpdateTime = reader.ReadUInt32();
			LocalCheckUpdateTime = reader.ReadUInt32();
			RemoteUpdateTime = reader.ReadUInt32();
		}
	}

	public void Write(BinaryWriter writer)
	{
		writer.Write(Version);
		writer.Write(Flags);
		writer.Write((int)LinkUpdateOption);
		writer.Write(0);
		writer.Write(ReservedMonikerStreamSize);
		if (ReservedMonikerStreamSize != 0)
		{
			ReservedMonikerStream.Write(writer);
		}
		if (Flags != 0)
		{
			writer.Write(RelativeSourceMonikerStreamSize);
			if (RelativeSourceMonikerStreamSize != 0)
			{
				RelativeSourceMonikerStream.Write(writer);
			}
			writer.Write(AbsoluteSourceMonikerStreamSize);
			AbsoluteSourceMonikerStream.Write(writer);
			writer.Write(ClsidIndicator);
			writer.Write(Clsid.ToByteArray());
			if (ReservedDisplayName != null)
			{
				writer.Write(ReservedDisplayName.Length);
				writer.Write(Encoding.Unicode.GetBytes(ReservedDisplayName));
			}
			else
			{
				writer.Write(0);
			}
			writer.Write(int_5);
			writer.Write(LocalUpdateTime);
			writer.Write(LocalCheckUpdateTime);
			writer.Write(RemoteUpdateTime);
		}
	}
}
