using System;
using System.Text;

namespace ns71;

internal static class Class3524
{
	public static string smethod_0(byte[] byteArray, Encoding encoding)
	{
		if (byteArray == null)
		{
			throw new ArgumentNullException("byteArray");
		}
		if (encoding == null)
		{
			throw new ArgumentNullException("encoding");
		}
		char[] chars = encoding.GetChars(byteArray);
		if (chars != null)
		{
			return new string(chars);
		}
		return null;
	}

	public static string smethod_1(byte[] byteArray, int codePage)
	{
		if (byteArray == null)
		{
			throw new ArgumentNullException("byteArray");
		}
		Encoding encoding = Encoding.GetEncoding(codePage);
		return smethod_0(byteArray, encoding);
	}
}
