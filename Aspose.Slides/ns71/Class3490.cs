using System.IO;

namespace ns71;

internal class Class3490 : Class3483
{
	public override ushort Id => 40;

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
