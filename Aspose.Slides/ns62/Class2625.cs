using System.IO;

namespace ns62;

internal class Class2625 : Class2624
{
	internal const int int_0 = 61460;

	private uint uint_0;

	private uint uint_1;

	public uint RuleId
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

	public uint ShapeId
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

	internal Class2625()
		: base(61460, 0)
	{
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(uint_1);
	}

	public override int vmethod_2()
	{
		return 8;
	}
}
