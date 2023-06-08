using System.IO;
using ns60;

namespace ns63;

internal class Class2881 : Class2623
{
	internal const int int_0 = 4058;

	private short short_0;

	private int int_1;

	public short FormatId
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

	public bool FHasDate
	{
		get
		{
			return (int_1 & 1) != 0;
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

	public bool FHasSlideNumber
	{
		get
		{
			return (int_1 & 8) != 0;
		}
		set
		{
			if (value)
			{
				int_1 |= 8;
			}
			else
			{
				int_1 &= -9;
			}
		}
	}

	public bool FHasHeader
	{
		get
		{
			return (int_1 & 0x10) != 0;
		}
		set
		{
			if (value)
			{
				int_1 |= 16;
			}
			else
			{
				int_1 &= -17;
			}
		}
	}

	public bool FHasFooter
	{
		get
		{
			return (int_1 & 0x20) != 0;
		}
		set
		{
			if (value)
			{
				int_1 |= 32;
			}
			else
			{
				int_1 &= -33;
			}
		}
	}

	public bool IsDateTimeFixed
	{
		get
		{
			return (int_1 & 4) != 0;
		}
		set
		{
			if (value)
			{
				int_1 &= -3;
				int_1 |= 4;
			}
			else
			{
				int_1 &= -5;
				int_1 |= 2;
			}
		}
	}

	public Class2881()
	{
		base.Header.Type = 4058;
		int_1 = 2;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		short_0 = reader.ReadInt16();
		int_1 = reader.ReadUInt16();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(short_0);
		writer.Write((short)int_1);
	}

	public override int vmethod_2()
	{
		return 4;
	}
}
