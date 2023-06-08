using System.IO;
using ns60;

namespace ns63;

internal class Class2749 : Class2623
{
	internal const int int_0 = 61755;

	private int int_1;

	private uint uint_0;

	public bool FTypePropertyUsed
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

	public bool FCommandPropertyUsed
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

	public uint CommandBehaviorType
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

	public Class2749()
	{
		base.Header.Type = 61755;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int_1 = reader.ReadInt32();
		uint_0 = reader.ReadUInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(int_1);
		writer.Write(uint_0);
	}

	public override int vmethod_2()
	{
		return 8;
	}
}
