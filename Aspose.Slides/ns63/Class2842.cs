using System.IO;
using ns60;

namespace ns63;

internal class Class2842 : Class2623
{
	internal const int int_0 = 12005;

	private int int_1;

	private int int_2;

	public int ColorIndex
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

	public int CommentIndexSeed
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

	public Class2842()
	{
		base.Header.Type = 12005;
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
