using System;
using System.IO;
using ns60;

namespace ns63;

internal class Class2756 : Class2623
{
	internal const int int_0 = 61752;

	private int int_1;

	private float float_0;

	private float float_1;

	private float float_2;

	private uint uint_0;

	public float By
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

	public float From
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

	public float To
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

	public uint RotationDirection
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

	public bool FDirectionPropertyUsed
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

	public Class2756()
	{
		base.Header.Type = 61752;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int_1 = reader.ReadInt32();
		float_0 = BitConverter.ToSingle(BitConverter.GetBytes(reader.ReadUInt32()), 0);
		float_1 = BitConverter.ToSingle(BitConverter.GetBytes(reader.ReadUInt32()), 0);
		float_2 = BitConverter.ToSingle(BitConverter.GetBytes(reader.ReadUInt32()), 0);
		uint_0 = reader.ReadUInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(int_1);
		writer.Write(BitConverter.ToUInt32(BitConverter.GetBytes(float_0), 0));
		writer.Write(BitConverter.ToUInt32(BitConverter.GetBytes(float_1), 0));
		writer.Write(BitConverter.ToUInt32(BitConverter.GetBytes(float_2), 0));
		writer.Write(uint_0);
	}

	public override int vmethod_2()
	{
		return 20;
	}
}
