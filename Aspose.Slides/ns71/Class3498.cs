using System.IO;

namespace ns71;

internal class Class3498 : Class3483
{
	private uint uint_0;

	private uint uint_1;

	public override ushort Id => 7;

	public uint Size => uint_0;

	public uint HelpContext
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	protected override void vmethod_2(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
	}

	protected override void vmethod_3(BinaryWriter writer)
	{
		writer.Write(4u);
		writer.Write(uint_1);
	}
}
