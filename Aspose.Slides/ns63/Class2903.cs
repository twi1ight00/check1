using System.IO;
using ns60;

namespace ns63;

internal class Class2903 : Class2623
{
	internal const int int_0 = 1019;

	private uint uint_0;

	private int int_1;

	public uint GuidType
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

	public int Pos
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

	internal Class2903()
	{
		base.Header.Type = 1019;
		base.Header.Instance = 7;
	}

	internal void method_1(int index)
	{
		switch (index)
		{
		case 0:
			uint_0 = 0u;
			int_1 = 2160;
			break;
		case 1:
			uint_0 = 1u;
			int_1 = 2880;
			break;
		}
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		int_1 = reader.ReadInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(int_1);
	}

	public override int vmethod_2()
	{
		return 8;
	}
}
