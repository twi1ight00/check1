using System.IO;
using ns60;

namespace ns63;

internal class Class2745 : Class2623
{
	internal const int int_0 = 61748;

	private uint uint_0;

	private int int_1;

	private uint uint_1;

	public uint CalcMode
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

	public bool FByPropertyUsed
	{
		get
		{
			return (int_1 & 1) == 1;
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

	public bool FFromPropertyUsed
	{
		get
		{
			return (int_1 & 2) == 2;
		}
		set
		{
			if (value)
			{
				int_1 |= 2;
			}
			else
			{
				int_1 &= -3;
			}
		}
	}

	public bool FToPropertyUsed
	{
		get
		{
			return (int_1 & 4) == 4;
		}
		set
		{
			if (value)
			{
				int_1 |= 4;
			}
			else
			{
				int_1 &= -5;
			}
		}
	}

	public bool FCalcModePropertyUsed
	{
		get
		{
			return (int_1 & 8) == 8;
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

	public bool FAnimationValuesPropertyUsed
	{
		get
		{
			return (int_1 & 0x10) == 16;
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

	public bool FValueTypePropertyUsed
	{
		get
		{
			return (int_1 & 0x20) == 32;
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

	public Enum397 ValueType
	{
		get
		{
			return (Enum397)uint_1;
		}
		set
		{
			uint_1 = (uint)value;
		}
	}

	public Class2745()
	{
		base.Header.Type = 61748;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		int_1 = reader.ReadInt32();
		uint_1 = reader.ReadUInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(int_1);
		writer.Write(uint_1);
	}

	public override int vmethod_2()
	{
		return 12;
	}
}
