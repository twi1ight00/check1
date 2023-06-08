using System.IO;
using ns60;

namespace ns63;

internal class Class2784 : Class2623
{
	internal const int int_0 = 3037;

	private Enum384 enum384_0;

	public Enum384 NewPlaceholderId
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

	internal Class2784()
	{
		base.Header.Type = 3037;
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
