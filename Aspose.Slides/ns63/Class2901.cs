using System.IO;
using ns60;

namespace ns63;

internal class Class2901 : Class2623
{
	internal const int int_0 = 1037;

	private int int_1 = 46448;

	private int int_2 = 46448;

	public int X
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

	public int Y
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public Class2901()
	{
		base.Header.Type = 1037;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int_1 = reader.ReadInt32();
		int_2 = reader.ReadInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(int_1);
		writer.Write(int_2);
	}

	public override int vmethod_2()
	{
		return 8;
	}
}
