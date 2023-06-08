using System.IO;
using ns60;

namespace ns63;

internal class Class2783 : Class2623
{
	internal const int int_0 = 1056;

	private Enum384 enum384_0;

	public Enum384 PlaceholderId
	{
		get
		{
			return enum384_0;
		}
		set
		{
			enum384_0 = value;
		}
	}

	internal Class2783()
	{
		base.Header.Type = 1056;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		enum384_0 = (Enum384)reader.ReadByte();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write((byte)enum384_0);
	}

	public override int vmethod_2()
	{
		return 1;
	}
}
