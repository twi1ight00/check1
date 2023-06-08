using System.IO;
using ns60;

namespace ns63;

internal class Class2746 : Class2623
{
	internal const int int_0 = 61763;

	private int int_1;

	public int Time
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

	public Class2746()
	{
		base.Header.Type = 61763;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int_1 = reader.ReadInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(int_1);
	}

	public override int vmethod_2()
	{
		return 4;
	}
}
