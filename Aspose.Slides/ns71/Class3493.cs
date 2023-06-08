using System.IO;

namespace ns71;

internal class Class3493 : Class3483
{
	private ushort ushort_0;

	public override ushort Id => ushort_0;

	public bool IsProceduralModule
	{
		get
		{
			return ushort_0 == 33;
		}
		set
		{
			ushort_0 = 33;
		}
	}

	public Class3493()
	{
	}

	public Class3493(bool isProceduralModule)
	{
		if (isProceduralModule)
		{
			ushort_0 = 33;
		}
		else
		{
			ushort_0 = 34;
		}
	}

	internal override void vmethod_0(BinaryReader reader)
	{
		ushort_0 = reader.ReadUInt16();
		if (ushort_0 != 33 && ushort_0 != 34)
		{
			throw new Exception10();
		}
		vmethod_2(reader);
	}

	protected override void vmethod_2(BinaryReader reader)
	{
		if (reader.ReadUInt32() != 0)
		{
			throw new Exception10();
		}
	}

	protected override void vmethod_3(BinaryWriter writer)
	{
		writer.Write(0u);
	}
}
