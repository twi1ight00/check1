using System.IO;

namespace ns71;

internal class Class3494 : Class3483
{
	private uint uint_0;

	private ushort ushort_0;

	public override ushort Id => 3;

	public uint Size => uint_0;

	public ushort CodePage
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	protected override void vmethod_2(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		ushort_0 = reader.ReadUInt16();
	}

	protected override void vmethod_3(BinaryWriter writer)
	{
		writer.Write(2u);
		writer.Write(ushort_0);
	}
}
