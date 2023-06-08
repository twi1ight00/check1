using System.IO;
using ns60;

namespace ns63;

internal class Class2906 : Class2623
{
	internal const int int_0 = 4050;

	private Enum404 enum404_0;

	public Enum404 Level
	{
		get
		{
			return enum404_0;
		}
		set
		{
			enum404_0 = value;
		}
	}

	public Class2906()
	{
		base.Header.Type = 4050;
		base.Header.Instance = 3;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		enum404_0 = (Enum404)reader.ReadInt32();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write((int)enum404_0);
	}

	public override int vmethod_2()
	{
		return 4;
	}
}
