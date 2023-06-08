using System.IO;
using ns60;

namespace ns63;

internal class Class2870 : Class2623
{
	internal const int int_0 = 4120;

	private uint uint_0;

	public uint Flags
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

	public Class2870()
	{
		base.Header.Type = 4120;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
	}

	public override int vmethod_2()
	{
		return 4;
	}
}
