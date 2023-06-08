using System.IO;
using ns60;
using ns64;

namespace ns63;

internal class Class2755 : Class2623
{
	internal const int int_0 = 61735;

	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	private uint uint_4;

	private uint uint_5;

	private int int_1;

	private int int_2;

	public uint Restart
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

	public Enum398 TimeNodeType
	{
		get
		{
			return (Enum398)uint_2;
		}
		set
		{
			uint_2 = (uint)value;
		}
	}

	public uint Fill
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

	public int Duration
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

	public bool FFillProperty
	{
		get
		{
			return (int_2 & 1) == 1;
		}
		set
		{
			if (value)
			{
				int_2 |= 1;
			}
			else
			{
				int_2 &= -2;
			}
		}
	}

	public bool FRestartProperty
	{
		get
		{
			return (int_2 & 2) == 2;
		}
		set
		{
			if (value)
			{
				int_2 |= 2;
			}
			else
			{
				int_2 &= -3;
			}
		}
	}

	public bool FGroupingTypeProperty
	{
		get
		{
			return (int_2 & 8) == 8;
		}
		set
		{
			if (value)
			{
				int_2 |= 8;
			}
			else
			{
				int_2 &= -9;
			}
		}
	}

	public bool FDurationProperty
	{
		get
		{
			return (int_2 & 0x10) == 16;
		}
		set
		{
			if (value)
			{
				int_2 |= 16;
			}
			else
			{
				int_2 &= -17;
			}
		}
	}

	public Class2755()
	{
		base.Header.Type = 61735;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
		uint_2 = reader.ReadUInt32();
		uint_3 = reader.ReadUInt32();
		uint_4 = reader.ReadUInt32();
		uint_5 = reader.ReadUInt32();
		int_1 = reader.ReadInt32();
		int_2 = reader.ReadInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(uint_1);
		writer.Write(uint_2);
		writer.Write(uint_3);
		writer.Write(uint_4);
		writer.Write(uint_5);
		writer.Write(int_1);
		writer.Write(int_2);
	}

	public override int vmethod_2()
	{
		return 32;
	}
}
