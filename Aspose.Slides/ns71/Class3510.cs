using System.IO;
using System.Text;

namespace ns71;

internal class Class3510 : Class3483
{
	private readonly int int_0;

	private uint uint_0;

	private uint uint_1;

	private string string_0;

	public override ushort Id => 13;

	public string Libid
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

	internal Class3510(int codePage, string libid)
	{
		int_0 = codePage;
		string_0 = libid;
	}

	internal Class3510(int codePage)
	{
		int_0 = codePage;
	}

	protected override void vmethod_2(BinaryReader reader)
	{
		uint_0 = reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
		string_0 = Class3524.smethod_1(reader.ReadBytes((int)uint_1), int_0);
		if (reader.ReadUInt32() != 0)
		{
			throw new Exception10();
		}
		if (reader.ReadUInt16() != 0)
		{
			throw new Exception10();
		}
	}

	protected override void vmethod_3(BinaryWriter writer)
	{
		Encoding encoding = Encoding.GetEncoding(int_0);
		byte[] bytes = encoding.GetBytes(string_0);
		uint_0 = (uint)(bytes.Length + 10);
		writer.Write(uint_0);
		writer.Write(uint_1);
		writer.Write(bytes);
		writer.Write(0u);
		writer.Write((ushort)0);
	}
}
