using System.IO;
using ns60;

namespace ns63;

internal class Class2766 : Class2765, Interface39, Interface43
{
	internal const int int_0 = 11009;

	private uint uint_0;

	public Enum401 TargetElementType
	{
		get
		{
			return (Enum401)uint_0;
		}
		set
		{
			uint_0 = (uint)value;
		}
	}

	public Class2766()
	{
		base.Header.Type = 11009;
		TargetElementType = Enum401.const_1;
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
