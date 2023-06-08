using System.IO;
using ns60;

namespace ns63;

internal class Class2872 : Class2623
{
	internal const int int_0 = 4100;

	private uint uint_0;

	private int int_1;

	private int int_2;

	public uint ExObjId
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

	public bool FLoop
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

	public bool FRewind
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

	public bool FNarration
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

	internal Class2872()
	{
		base.Header.Type = 4100;
		int_1 = 0;
		int_2 = 1077;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		int_1 = reader.ReadUInt16();
		int_2 = reader.ReadUInt16();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write((ushort)int_1);
		writer.Write((ushort)int_2);
	}

	public override int vmethod_2()
	{
		return 8;
	}
}
