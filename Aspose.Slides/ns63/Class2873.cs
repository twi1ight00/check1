using System.IO;
using ns60;

namespace ns63;

internal class Class2873 : Class2623
{
	internal const int int_0 = 1034;

	private int int_1;

	public uint ExObjIdSeed
	{
		get
		{
			return (uint)int_1;
		}
		set
		{
			int_1 = (int)value;
		}
	}

	public Class2873()
	{
		base.Header.Type = 1034;
		int_1 = 1;
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
