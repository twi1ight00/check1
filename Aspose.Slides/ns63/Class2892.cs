using System;
using System.IO;
using ns60;

namespace ns63;

internal class Class2892 : Class2623
{
	public const int int_0 = 1025;

	private uint uint_0;

	private int int_1;

	private short short_0;

	private short short_1;

	private byte[] byte_0;

	private int int_2;

	public uint PenColor
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

	public int RestartTime
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

	public short StartSlide
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

	public short EndSlide
	{
		get
		{
			return short_1;
		}
		set
		{
			short_1 = value;
		}
	}

	public byte[] NamedShow
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

	public bool ManualAdvance
	{
		get
		{
			return (int_2 & 1) == 0;
		}
		set
		{
			if (!value)
			{
				int_2 |= 1;
			}
			else
			{
				int_2 &= -2;
			}
		}
	}

	public bool ShowWithAnimation
	{
		get
		{
			return (int_2 & 2) == 0;
		}
		set
		{
			if (!value)
			{
				int_2 |= 2;
			}
			else
			{
				int_2 &= -3;
			}
		}
	}

	public bool ShowWithNarration
	{
		get
		{
			return (int_2 & 0x40) == 0;
		}
		set
		{
			if (!value)
			{
				int_2 |= 64;
			}
			else
			{
				int_2 &= -65;
			}
		}
	}

	public bool LoopUntilStopped
	{
		get
		{
			return (int_2 & 0x80) != 0;
		}
		set
		{
			if (value)
			{
				int_2 |= 128;
			}
			else
			{
				int_2 &= -129;
			}
		}
	}

	public bool ShowScrollbar
	{
		get
		{
			return (int_2 & 0x100) == 0;
		}
		set
		{
			if (!value)
			{
				int_2 |= 256;
			}
			else
			{
				int_2 &= -257;
			}
		}
	}

	public int ShowType
	{
		get
		{
			if ((int_2 & 0x1A0) == 416)
			{
				return 0;
			}
			if ((int_2 & 0x10) == 16)
			{
				return 1;
			}
			return 2;
		}
		set
		{
			switch (value)
			{
			case 2:
				int_2 &= -433;
				break;
			case 1:
				int_2 &= -417;
				int_2 |= 16;
				break;
			default:
				int_2 &= -17;
				int_2 |= 416;
				break;
			}
		}
	}

	public int RangeType
	{
		get
		{
			if ((int_2 & 4) == 4)
			{
				return 2;
			}
			if ((int_2 & 8) == 8)
			{
				return 1;
			}
			return 0;
		}
		set
		{
			switch (value)
			{
			case 0:
				int_2 &= -15;
				break;
			case 1:
				int_2 &= -5;
				int_2 |= 8;
				break;
			default:
				int_2 &= -9;
				int_2 |= 4;
				break;
			}
		}
	}

	public Class2892()
	{
		base.Header.Type = 1025;
		base.Header.Version = 1;
		uint_0 = 16777216u;
		int_1 = int.MaxValue;
		short_0 = 0;
		short_1 = 0;
		int_2 = 1;
		byte_0 = new byte[64];
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		int_1 = reader.ReadInt32();
		short_0 = reader.ReadInt16();
		short_1 = reader.ReadInt16();
		byte_0 = reader.ReadBytes(64);
		int_2 = reader.ReadInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(int_1);
		writer.Write(short_0);
		writer.Write(short_1);
		byte[] array = new byte[64];
		Array.Copy(byte_0, 0, array, 0, 64);
		writer.Write(array);
		writer.Write(int_2);
	}

	public override int vmethod_2()
	{
		return 80;
	}
}
