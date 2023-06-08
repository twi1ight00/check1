using System.IO;

namespace ns63;

internal class Class2854 : Class2845
{
	internal const int int_0 = 3998;

	private int int_1;

	public int Index
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

	public Class2854(Class2951 stf)
		: base(stf)
	{
		base.Header.Type = 3998;
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
