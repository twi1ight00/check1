using System.IO;
using ns60;

namespace ns63;

internal class Class2890 : Class2623
{
	internal const int int_0 = 2021;

	private int int_1;

	public int SoundIdSeed
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

	public Class2890()
	{
		base.Header.Type = 2021;
		int_1 = 0;
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
