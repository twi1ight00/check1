using System.IO;
using System.Text;

namespace ns71;

internal class Class3507 : Class3483
{
	private readonly int int_0;

	private uint uint_0;

	private string string_0;

	private uint uint_1;

	private string string_1;

	public override ushort Id => 22;

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			string_1 = value;
		}
	}

	internal Class3507(int codePage, string name)
	{
		int_0 = codePage;
		string_0 = name;
		string_1 = name;
	}

	internal Class3507(int codePage)
	{
		int_0 = codePage;
	}

	protected override void vmethod_2(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		string_0 = Class3524.smethod_1(reader.ReadBytes((int)uint_0), int_0);
		ushort num = reader.ReadUInt16();
		if (num != 62)
		{
			throw new Exception10();
		}
		uint_1 = reader.ReadUInt32();
		string_1 = Class3522.smethod_3(reader, (int)uint_1, Encoding.Unicode);
	}

	protected override void vmethod_3(BinaryWriter writer)
	{
		Class3523.smethod_3(writer, string_0, int_0);
		writer.Write((ushort)62);
		Class3523.smethod_2(writer, string_1, Encoding.Unicode);
	}
}
