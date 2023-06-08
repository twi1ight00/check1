using System.IO;
using ns60;

namespace ns63;

internal class Class2893 : Class2623
{
	internal const int int_0 = 1017;

	private int int_1;

	private int int_2;

	private byte byte_0;

	private byte byte_1;

	private short short_0;

	private byte byte_2;

	public int SlideTime
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

	public int SoundIdRef
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

	public byte EffectDirection
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

	public byte EffectType
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

	public short BuildFlags
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

	public byte Speed
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

	public Class2893()
	{
		base.Header.Type = 1017;
		short_0 = 1;
		byte_0 = 2;
		int_1 = 0;
		int_2 = 0;
		byte_2 = 0;
		byte_1 = 0;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int_1 = reader.ReadInt32();
		int_2 = reader.ReadInt32();
		byte_0 = reader.ReadByte();
		byte_1 = reader.ReadByte();
		short_0 = reader.ReadInt16();
		byte_2 = reader.ReadByte();
		reader.ReadByte();
		reader.ReadByte();
		reader.ReadByte();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(int_1);
		writer.Write(int_2);
		writer.Write(byte_0);
		writer.Write(byte_1);
		writer.Write(short_0);
		writer.Write(byte_2);
		writer.Write((byte)0);
		writer.Write((byte)0);
		writer.Write((byte)0);
	}

	public override int vmethod_2()
	{
		return 16;
	}

	public void method_1()
	{
		switch (byte_1)
		{
		case 0:
		case 2:
		case 3:
		case 8:
		case 11:
		case 21:
			if (byte_0 > 1)
			{
				byte_0 = 0;
			}
			break;
		case 4:
		case 7:
		case 9:
		case 10:
		case 12:
		case 13:
		case 14:
		case 15:
		case 16:
		case 20:
		case 24:
		case 25:
		case 26:
			break;
		case 1:
		case 5:
		case 6:
		case 17:
		case 18:
		case 19:
		case 22:
		case 23:
		case 27:
			byte_0 = 0;
			break;
		}
	}
}
