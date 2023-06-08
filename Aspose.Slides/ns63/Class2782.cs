using System.IO;
using ns60;

namespace ns63;

internal class Class2782 : Class2623
{
	internal const int int_0 = 1058;

	private uint uint_0;

	private ushort ushort_0;

	public uint MainMasterId
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

	public ushort ContentMasterInstanceId
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

	internal Class2782()
	{
		base.Header.Type = 1058;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		ushort_0 = reader.ReadUInt16();
		reader.ReadUInt16();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(uint_0);
		writer.Write(ushort_0);
		writer.Write((ushort)0);
	}

	public override int vmethod_2()
	{
		return 8;
	}
}
