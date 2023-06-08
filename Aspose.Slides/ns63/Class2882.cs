using System.IO;
using ns60;

namespace ns63;

internal class Class2882 : Class2623
{
	internal const int int_0 = 4083;

	private uint uint_0;

	private uint uint_1;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private byte byte_3;

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

	public uint ExHyperlinkIdRef
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

	public Enum381 Action
	{
		get
		{
			return (Enum381)byte_0;
		}
		set
		{
			byte_0 = (byte)value;
		}
	}

	public byte OleVerb
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

	public Enum382 Jump
	{
		get
		{
			return (Enum382)byte_2;
		}
		set
		{
			byte_2 = (byte)value;
		}
	}

	public bool FAnimated
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public bool FStopSound
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool FCustomShowReturn
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public Enum383 HyperlinkType
	{
		get
		{
			return (Enum383)byte_3;
		}
		set
		{
			byte_3 = (byte)value;
		}
	}

	public Class2882()
	{
		base.Header.Type = 4083;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = (uint)reader.ReadInt32();
		uint_1 = (uint)reader.ReadInt32();
		byte_0 = reader.ReadByte();
		byte_1 = reader.ReadByte();
		byte_2 = reader.ReadByte();
		byte b = reader.ReadByte();
		bool_1 = (b & 1) > 0;
		bool_2 = (b & 2) > 0;
		bool_3 = (b & 4) > 0;
		byte_3 = reader.ReadByte();
		reader.ReadByte();
		reader.ReadByte();
		reader.ReadByte();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(uint_1);
		writer.Write(byte_0);
		writer.Write(byte_1);
		writer.Write(byte_2);
		byte b = 0;
		if (bool_1)
		{
			b = (byte)(b | 1u);
		}
		if (bool_2)
		{
			b = (byte)(b | 2u);
		}
		if (bool_3)
		{
			b = (byte)(b | 4u);
		}
		writer.Write(b);
		writer.Write(byte_3);
		writer.Write((byte)0);
		writer.Write((byte)0);
		writer.Write((byte)0);
	}

	public override int vmethod_2()
	{
		return 16;
	}
}
