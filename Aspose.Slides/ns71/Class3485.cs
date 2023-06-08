using System.IO;
using System.Text;

namespace ns71;

internal class Class3485 : Class3483
{
	private readonly int int_0;

	private uint uint_0;

	private string string_0;

	private uint uint_1;

	private string string_1;

	public override ushort Id => 28;

	public uint SizeOfDocString
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

	public string DocString
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public uint SizeOfDocStringUnicode
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public string DocStringUnicode
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public Class3485(int codePage, string docString)
	{
		int_0 = codePage;
		string_0 = docString;
		string_1 = docString;
	}

	public Class3485(int codePage)
	{
		int_0 = codePage;
	}

	protected override void vmethod_2(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		string_0 = Class3522.smethod_2(reader, (int)uint_0, int_0);
		ushort num = reader.ReadUInt16();
		if (num != 72)
		{
			throw new Exception10();
		}
		uint_1 = reader.ReadUInt32();
		string_1 = Class3522.smethod_3(reader, (int)uint_1, Encoding.Unicode);
	}

	protected override void vmethod_3(BinaryWriter writer)
	{
		Class3523.smethod_3(writer, string_0, int_0);
		writer.Write((ushort)72);
		Class3523.smethod_2(writer, string_1, Encoding.Unicode);
	}
}
