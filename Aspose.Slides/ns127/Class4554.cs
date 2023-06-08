using System.Text;
using System.Text.RegularExpressions;

namespace ns127;

internal class Class4554
{
	public static string smethod_0(byte[] bytes)
	{
		string @string = Encoding.ASCII.GetString(bytes);
		@string = @string.Replace("\0", "\\0");
		@string = Regex.Replace(@string, "(?<=[^\\r])[\\n]", "\r\n");
		return Regex.Replace(@string, "[\\r](?=[^\\n])", "\r\n");
	}

	public static string smethod_1(byte[] bytes)
	{
		char[] array = new char[bytes.Length];
		for (int i = 0; i < bytes.Length; i++)
		{
			array[i] = (char)bytes[i];
		}
		return new string(array);
	}

	public static byte[] smethod_2(string byteString)
	{
		byte[] array = new byte[byteString.Length];
		for (int i = 0; i < byteString.Length; i++)
		{
			array[i] = (byte)byteString[i];
		}
		return array;
	}

	public static bool smethod_3(byte[] source, byte[] checkBytes)
	{
		if (source.Length != checkBytes.Length)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < source.Length)
			{
				if (smethod_4(source, num, checkBytes))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public static bool Contains(byte[] source, byte[] checkBytes)
	{
		int num = 0;
		while (true)
		{
			if (num < source.Length)
			{
				if (smethod_4(source, num, checkBytes))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public static bool smethod_4(byte[] source, int startPos, byte[] checkBytes)
	{
		if (startPos + checkBytes.Length > source.Length)
		{
			return false;
		}
		int num = startPos;
		while (true)
		{
			if (num < startPos + checkBytes.Length)
			{
				if (source[num] != checkBytes[num - startPos])
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}
}
