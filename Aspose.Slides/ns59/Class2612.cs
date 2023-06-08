using System.IO;
using System.Text;
using ns4;

namespace ns59;

internal class Class2612
{
	public Struct134 struct134_0;

	public uint uint_0;

	public int int_0;

	public int int_1;

	public uint uint_1;

	public uint uint_2;

	public uint uint_3;

	public uint uint_4;

	public string string_0;

	public uint uint_5;

	public Class2612()
	{
		struct134_0.fCryptoAPI = true;
		uint_0 = 0u;
		int_0 = 26625;
		int_1 = 32772;
		uint_1 = 40u;
		uint_2 = 1u;
		uint_3 = 0u;
		uint_4 = 0u;
		string_0 = "Microsoft Base Cryptographic Provider v1.0";
		uint_5 = 118u;
	}

	internal int method_0()
	{
		return 32 + (string_0.Length * 2 + 2);
	}

	public void method_1(BinaryWriter writer)
	{
		writer.Write(struct134_0.uint_0);
		writer.Write(uint_0);
		writer.Write(int_0);
		writer.Write(int_1);
		writer.Write(uint_1);
		writer.Write(uint_2);
		writer.Write(uint_3);
		writer.Write(uint_4);
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
		byte[] bytes = unicodeEncoding.GetBytes(string_0.ToCharArray());
		writer.Write(bytes);
		writer.Write((short)0);
	}

	public static Class2612 smethod_0(Stream stream, uint encryptionHeaderSize)
	{
		Class2612 @class = new Class2612();
		@class.struct134_0 = Struct134.smethod_0(stream);
		@class.uint_0 = (uint)Class1162.smethod_24(stream);
		@class.int_0 = Class1162.smethod_24(stream);
		@class.int_1 = Class1162.smethod_24(stream);
		@class.uint_1 = (uint)Class1162.smethod_24(stream);
		if (@class.uint_1 == 0)
		{
			@class.uint_1 = 40u;
		}
		@class.uint_2 = (uint)Class1162.smethod_24(stream);
		@class.uint_3 = (uint)Class1162.smethod_24(stream);
		@class.uint_4 = (uint)Class1162.smethod_24(stream);
		uint num = encryptionHeaderSize - 32;
		int num2 = (int)(num / 2u - 1);
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
		char[] chars = unicodeEncoding.GetChars(Class1162.smethod_28(stream, num2 * 2), 0, num2 * 2);
		Class1162.smethod_28(stream, 2);
		@class.string_0 = new string(chars);
		return @class;
	}

	public bool method_2()
	{
		if (struct134_0.fExternal)
		{
			return false;
		}
		int num = int_1;
		if (num != 0 && num != 32772)
		{
			return false;
		}
		return true;
	}
}
