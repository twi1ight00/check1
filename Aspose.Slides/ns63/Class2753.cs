using System.IO;
using ns60;

namespace ns63;

internal class Class2753 : Class2623
{
	internal const int int_0 = 61737;

	private uint uint_0;

	private uint uint_1;

	public uint TimeModifierType
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

	public uint Value
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

	public Class2753()
	{
		base.Header.Type = 61737;
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
