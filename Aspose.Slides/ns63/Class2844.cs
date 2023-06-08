using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using ns45;
using ns60;

namespace ns63;

internal class Class2844 : Class2623
{
	public const int int_0 = 4086;

	private uint uint_0;

	private string string_0 = "";

	private uint uint_1 = 3817979999u;

	public uint HeaderToken => uint_1;

	public uint OffsetToCurrentEdit
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

	public string AnsiUserName
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = ((value == null) ? "" : value);
		}
	}

	public Class2844()
	{
		base.Header.Type = 4086;
	}

	public static Class2844 smethod_0(Class1110 fs)
	{
		try
		{
			MemoryStream memoryStream = new MemoryStream(((Class1106)fs.RootFolder.method_2("Current User")).method_7());
			Class2844 result = (Class2844)Class2950.smethod_1(new BinaryReader(memoryStream), null);
			memoryStream.Close();
			return result;
		}
		catch (Exception exception)
		{
			throw new PptUnsupportedFormatException("Unknown file format.", exception);
		}
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		int num = (int)reader.BaseStream.Position;
		reader.ReadUInt32();
		uint_1 = reader.ReadUInt32();
		uint_0 = reader.ReadUInt32();
		short count = reader.ReadInt16();
		reader.ReadInt16();
		reader.ReadByte();
		reader.ReadByte();
		reader.ReadInt16();
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		char[] chars = uTF8Encoding.GetChars(reader.ReadBytes(count));
		if (chars != null)
		{
			string_0 = new string(chars);
		}
		reader.ReadInt32();
		int num2 = (int)reader.BaseStream.Position - num;
		if (num2 < base.Header.Length)
		{
			reader.ReadBytes(base.Header.Length - num2);
		}
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(20u);
		writer.Write(uint_1);
		writer.Write(uint_0);
		writer.Write((short)string_0.Length);
		writer.Write((short)1012);
		writer.Write((byte)3);
		writer.Write((byte)0);
		writer.Write((short)0);
		for (int i = 0; i < string_0.Length; i++)
		{
			writer.Write((byte)string_0[i]);
		}
		writer.Write(8);
	}

	public override int vmethod_2()
	{
		return 24 + string_0.Length;
	}
}
