using System.IO;
using ns60;

namespace ns63;

internal class Class2880 : Class2623
{
	internal const int int_0 = 11008;

	private uint uint_0;

	public uint Hash
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

	public Class2880()
	{
		base.Header.Type = 11008;
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
