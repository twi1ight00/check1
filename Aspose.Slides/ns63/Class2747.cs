using System.IO;
using ns60;

namespace ns63;

internal class Class2747 : Class2623
{
	internal const int int_0 = 61747;

	private int int_1;

	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	public bool FAdditivePropertyUsed
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

	public bool FAttributeNamesPropertyUsed
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

	public uint BehaviorAdditive
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

	public uint BehaviorAccumulate
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

	public uint BehaviorTransform
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

	public Class2747()
	{
		base.Header.Type = 61747;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int_1 = reader.ReadInt32();
		uint_0 = reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
		uint_2 = reader.ReadUInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(int_1);
		writer.Write(uint_0);
		writer.Write(uint_1);
		writer.Write(uint_2);
	}

	public override int vmethod_2()
	{
		return 16;
	}
}
