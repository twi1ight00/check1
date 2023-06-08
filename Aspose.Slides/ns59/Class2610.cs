using System;
using System.IO;
using System.Text;
using ns4;

namespace ns59;

internal class Class2610
{
	public uint uint_0;

	public uint uint_1;

	public ushort ushort_0;

	public byte byte_0;

	public byte byte_1;

	public uint uint_2;

	public string string_0;

	public bool IsStream => 1 == (byte_1 & 1);

	internal int method_0()
	{
		return 16 + (string_0.Length * 2 + 2);
	}

	internal void method_1(int offset, byte[] dataParam)
	{
		Class1162.smethod_16(dataParam, offset, (int)uint_0);
		Class1162.smethod_16(dataParam, offset + 4, (int)uint_1);
		Class1162.smethod_12(dataParam, offset + 8, (short)ushort_0);
		dataParam[offset + 10] = byte_0;
		dataParam[offset + 11] = byte_1;
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
		byte[] bytes = unicodeEncoding.GetBytes(string_0.ToCharArray());
		Array.Copy(bytes, 0, dataParam, offset + 16, bytes.Length);
		Class1162.smethod_12(dataParam, offset + 16 + bytes.Length, 0);
	}

	public static Class2610 smethod_0(Stream stream)
	{
		Class2610 @class = new Class2610();
		@class.uint_0 = (uint)Class1162.smethod_24(stream);
		@class.uint_1 = (uint)Class1162.smethod_24(stream);
		@class.ushort_0 = (ushort)Class1162.smethod_22(stream);
		@class.byte_0 = (byte)stream.ReadByte();
		@class.byte_1 = (byte)stream.ReadByte();
		@class.uint_2 = (uint)Class1162.smethod_24(stream);
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
		char[] chars = unicodeEncoding.GetChars(Class1162.smethod_28(stream, @class.byte_0 * 2 + 2), 0, @class.byte_0 * 2 + 2);
		@class.string_0 = new string(chars, 0, @class.byte_0);
		return @class;
	}
}
