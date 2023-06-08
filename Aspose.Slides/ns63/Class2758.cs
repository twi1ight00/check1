using System.IO;
using ns60;

namespace ns63;

internal class Class2758 : Class2623
{
	internal const int int_0 = 61761;

	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private int int_1;

	public uint Concurrency
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

	public uint NextAction
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

	public uint PreviousAction
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

	public bool FConcurrencyPropertyUsed
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

	public bool FNextActionPropertyUsed
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

	public bool FPreviousActionPropertyUsed
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

	public Class2758()
	{
		base.Header.Type = 61761;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
		uint_2 = reader.ReadUInt32();
		reader.ReadUInt32();
		int_1 = reader.ReadInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(uint_1);
		writer.Write(uint_2);
		writer.Write(0u);
		writer.Write(int_1);
	}

	public override int vmethod_2()
	{
		return 20;
	}
}
