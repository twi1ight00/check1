using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ns71;

internal class Class3515 : Class3473
{
	private readonly int int_0;

	private string string_0;

	private string string_1;

	internal string ModuleName => string_0;

	public Class3515(int codePage, string name)
	{
		int_0 = codePage;
		string_0 = name;
		string_1 = name;
	}

	public Class3515(int codePage)
	{
		int_0 = codePage;
	}

	internal override void vmethod_0(BinaryReader reader)
	{
		byte[] byteArray = Class3522.smethod_4(reader, 0);
		string_0 = Class3524.smethod_1(byteArray, int_0);
		List<byte> list = new List<byte>();
		while (Class3522.smethod_1(reader) != 0 && Class3522.smethod_1(reader) != 0)
		{
			list.AddRange(reader.ReadBytes(2));
		}
		reader.ReadBytes(2);
		string_1 = Class3524.smethod_0(list.ToArray(), Encoding.Unicode);
	}

	internal override void vmethod_1(BinaryWriter writer)
	{
		Class3523.smethod_1(writer, string_0, int_0);
		writer.Write((byte)0);
		Class3523.smethod_0(writer, string_1, Encoding.Unicode);
		writer.Write((byte)0);
		writer.Write((byte)0);
	}
}
