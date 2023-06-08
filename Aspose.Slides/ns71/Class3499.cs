using System.IO;

namespace ns71;

internal class Class3499 : Class3483
{
	private readonly int int_0;

	private uint uint_0;

	private string string_0;

	private uint uint_1;

	private string string_1;

	public override ushort Id => 6;

	public string HelpFile1
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

	public uint SizeOfHelpFile1
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

	public uint SizeOfHelpFile2
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

	public string HelpFile2
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

	public Class3499(int codePage)
	{
		int_0 = codePage;
	}

	protected override void vmethod_2(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		string_0 = Class3524.smethod_1(reader.ReadBytes((int)uint_0), int_0);
		ushort num = reader.ReadUInt16();
		if (num != 61)
		{
			throw new Exception10();
		}
		uint_1 = reader.ReadUInt32();
		string_1 = Class3524.smethod_1(reader.ReadBytes((int)uint_1), int_0);
	}

	protected override void vmethod_3(BinaryWriter writer)
	{
		Class3523.smethod_3(writer, string_0, int_0);
		writer.Write((ushort)61);
		Class3523.smethod_3(writer, string_1, int_0);
	}
}
