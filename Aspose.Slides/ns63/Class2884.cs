using System.IO;
using ns60;

namespace ns63;

internal class Class2884 : Class2623
{
	public const int int_0 = 1009;

	private uint uint_0;

	private int int_1;

	public uint SlideIdRef
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

	public bool FMasterObjects
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

	public bool FMasterScheme
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

	public bool FMasterBackground
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

	public Class2884()
	{
		base.Header.Version = 1;
		base.Header.Type = 1009;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		int_1 = reader.ReadUInt16();
		reader.ReadUInt16();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write((ushort)int_1);
		writer.Write((ushort)12298);
	}

	public override int vmethod_2()
	{
		return 8;
	}
}
