using System;
using System.Text;
using ns4;

namespace ns47;

internal class Class1142
{
	private byte[] byte_0;

	public int Size => Class1162.smethod_6(byte_0, 0);

	public byte[] RawData => byte_0;

	public Class1142()
	{
		byte[] array = new byte[4];
		byte_0 = array;
	}

	public Class1142(byte[] rawBlolbBytes)
	{
		byte_0 = new byte[rawBlolbBytes.Length];
		Array.Copy(rawBlolbBytes, byte_0, rawBlolbBytes.Length);
	}

	public override string ToString()
	{
		string @string = Encoding.Unicode.GetString(byte_0, 4, Size);
		char[] trimChars = new char[1];
		return @string.TrimEnd(trimChars);
	}

	public void method_0(string value)
	{
		string text = value;
		char[] trimChars = new char[1];
		value = text.TrimEnd(trimChars);
		int num = 4 + value.Length * 2 + 2;
		int num2 = num % 4;
		if (num2 != 0)
		{
			num = num - num2 + 4;
		}
		byte_0 = new byte[num];
		Array.Copy(Encoding.Unicode.GetBytes(value), 0, byte_0, 4, value.Length * 2);
		Class1162.smethod_16(byte_0, 0, num - 4);
	}
}
