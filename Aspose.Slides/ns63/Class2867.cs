using System.IO;
using ns60;

namespace ns63;

internal class Class2867 : Class2623
{
	internal const int int_0 = 4091;

	private uint uint_0;

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

	internal Class2867()
	{
		base.Header.Type = 4091;
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
