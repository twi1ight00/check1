using System.IO;

namespace ns71;

internal class Class3506 : Class3483
{
	private uint uint_0;

	private ushort ushort_0;

	public override ushort Id => 9;

	public uint VersionMajor
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

	public ushort VersionMinor
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
		uint num = reader.ReadUInt32();
		if (num != 4)
		{
			throw new Exception10();
		}
		uint_0 = reader.ReadUInt32();
		ushort_0 = reader.ReadUInt16();
	}

	protected override void vmethod_3(BinaryWriter writer)
	{
		writer.Write(4u);
		writer.Write(uint_0);
		writer.Write(ushort_0);
	}
}
