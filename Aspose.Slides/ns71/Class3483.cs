using System.IO;

namespace ns71;

internal abstract class Class3483 : Class3473
{
	public abstract ushort Id { get; }

	internal override void vmethod_0(BinaryReader reader)
	{
		ushort num = reader.ReadUInt16();
		if (num != Id)
		{
			throw new Exception10();
		}
		vmethod_2(reader);
	}

	internal override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(Id);
		vmethod_3(writer);
	}

	protected abstract void vmethod_2(BinaryReader reader);

	protected abstract void vmethod_3(BinaryWriter writer);
}
