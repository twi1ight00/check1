using System.IO;
using ns60;

namespace ns63;

internal class Class2838 : Class2623
{
	internal const int int_0 = 4081;

	private Class2966 class2966_0;

	private int int_1;

	private uint uint_0;

	private int int_2;

	private short short_0;

	private ushort ushort_0;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	private byte byte_4;

	private byte byte_5;

	private byte byte_6;

	private byte byte_7;

	public Class2966 DimColor
	{
		get
		{
			return class2966_0;
		}
		set
		{
			class2966_0 = value;
		}
	}

	public int Flags
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

	public uint SoundIdRef
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

	public int DelayTime
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

	public short OrderID
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

	public ushort SlideCount
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

	public byte AnimBuildType
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

	public byte AnimEffect
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

	public byte AnimEffectDirection
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

	public byte AnimAfterEffect
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

	public byte TextBuildSubEffect
	{
		get
		{
			return byte_4;
		}
		set
		{
			byte_4 = value;
		}
	}

	public byte OLEVerb
	{
		get
		{
			return byte_5;
		}
		set
		{
			byte_5 = value;
		}
	}

	public byte Unknown1
	{
		get
		{
			return byte_6;
		}
		set
		{
			byte_6 = value;
		}
	}

	public byte Unknown2
	{
		get
		{
			return byte_7;
		}
		set
		{
			byte_7 = value;
		}
	}

	public Class2838()
	{
		base.Header.Type = 4081;
		base.Header.Version = 1;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		class2966_0 = new Class2966(reader.ReadUInt32());
		int_1 = reader.ReadInt32();
		uint_0 = reader.ReadUInt32();
		int_2 = reader.ReadInt32();
		short_0 = reader.ReadInt16();
		ushort_0 = reader.ReadUInt16();
		byte_0 = reader.ReadByte();
		byte_1 = reader.ReadByte();
		byte_2 = reader.ReadByte();
		byte_3 = reader.ReadByte();
		byte_4 = reader.ReadByte();
		byte_5 = reader.ReadByte();
		byte_6 = reader.ReadByte();
		byte_7 = reader.ReadByte();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(class2966_0.Struct);
		writer.Write(int_1);
		writer.Write(uint_0);
		writer.Write(int_2);
		writer.Write(short_0);
		writer.Write(ushort_0);
		writer.Write(byte_0);
		writer.Write(byte_1);
		writer.Write(byte_2);
		writer.Write(byte_3);
		writer.Write(byte_4);
		writer.Write(byte_5);
		writer.Write(byte_6);
		writer.Write(byte_7);
	}

	public override int vmethod_2()
	{
		return 28;
	}

	public override void vmethod_4()
	{
		class2966_0 = new Class2966(0u);
	}
}
