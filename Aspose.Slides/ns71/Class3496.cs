using System.IO;

namespace ns71;

internal class Class3496 : Class3483
{
	private uint uint_0;

	private ushort ushort_0;

	public override ushort Id => 19;

	public uint Size
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

	public ushort Cookie
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
		writer.Write(ushort.MaxValue);
	}
}
