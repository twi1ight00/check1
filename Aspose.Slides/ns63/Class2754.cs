using System;
using System.IO;
using ns60;

namespace ns63;

internal class Class2754 : Class2623
{
	internal const int int_0 = 61751;

	private int int_1;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	private uint uint_0;

	public float XBy
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public float YBy
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public float XFrom
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	public float YFrom
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	public float XTo
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
		}
	}

	public float YTo
	{
		get
		{
			return float_5;
		}
		set
		{
			float_5 = value;
		}
	}

	public uint BehaviorOrigin
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

	public bool FOriginPropertyUsed
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

	public bool FPathPropertyUsed
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

	public bool FEditRotationPropertyUsed
	{
		get
		{
			return (int_1 & 0x40) == 64;
		}
		set
		{
			if (value)
			{
				int_1 |= 64;
			}
			else
			{
				int_1 &= -65;
			}
		}
	}

	public bool FPointsTypesPropertyUsed
	{
		get
		{
			return (int_1 & 0x80) == 128;
		}
		set
		{
			if (value)
			{
				int_1 |= 128;
			}
			else
			{
				int_1 &= -129;
			}
		}
	}

	public Class2754()
	{
		base.Header.Type = 61751;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int_1 = reader.ReadInt32();
		float_0 = BitConverter.ToSingle(BitConverter.GetBytes(reader.ReadUInt32()), 0);
		float_1 = BitConverter.ToSingle(BitConverter.GetBytes(reader.ReadUInt32()), 0);
		float_2 = BitConverter.ToSingle(BitConverter.GetBytes(reader.ReadUInt32()), 0);
		float_3 = BitConverter.ToSingle(BitConverter.GetBytes(reader.ReadUInt32()), 0);
		float_4 = BitConverter.ToSingle(BitConverter.GetBytes(reader.ReadUInt32()), 0);
		float_5 = BitConverter.ToSingle(BitConverter.GetBytes(reader.ReadUInt32()), 0);
		uint_0 = reader.ReadUInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(int_1);
		writer.Write(BitConverter.ToUInt32(BitConverter.GetBytes(float_0), 0));
		writer.Write(BitConverter.ToUInt32(BitConverter.GetBytes(float_1), 0));
		writer.Write(BitConverter.ToUInt32(BitConverter.GetBytes(float_2), 0));
		writer.Write(BitConverter.ToUInt32(BitConverter.GetBytes(float_3), 0));
		writer.Write(BitConverter.ToUInt32(BitConverter.GetBytes(float_4), 0));
		writer.Write(BitConverter.ToUInt32(BitConverter.GetBytes(float_5), 0));
		writer.Write(uint_0);
	}

	public override int vmethod_2()
	{
		return 32;
	}
}
