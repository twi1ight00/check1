using System.IO;
using ns33;
using ns60;

namespace ns63;

internal class Class2874 : Class2623
{
	internal const int int_0 = 3009;

	private uint uint_0;

	public uint ExObjIdRef
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

	public Class2874()
	{
		base.Header.Type = 3009;
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

	public override void vmethod_3(Interface38 statistics)
	{
		statistics?.imethod_0(uint_0);
	}
}
