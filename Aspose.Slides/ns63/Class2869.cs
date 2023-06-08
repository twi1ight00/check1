using System.IO;
using ns60;

namespace ns63;

internal class Class2869 : Class2623
{
	internal const int int_0 = 4051;

	private uint uint_0;

	public uint ExHyperlinkId
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

	public Class2869()
	{
		base.Header.Type = 4051;
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
