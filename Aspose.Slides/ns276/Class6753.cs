using System.IO;
using System.Text;

namespace ns276;

internal class Class6753
{
	public static int smethod_0(int number, int bits)
	{
		return (int)((uint)number >> bits);
	}

	public static long smethod_1(long number, int bits)
	{
		return (long)((ulong)number >> bits);
	}

	public static int smethod_2(TextReader sourceTextReader, byte[] target, int start, int count)
	{
		if (target.Length == 0)
		{
			return 0;
		}
		char[] array = new char[target.Length];
		int num = sourceTextReader.Read(array, start, count);
		if (num == 0)
		{
			return -1;
		}
		for (int i = start; i < start + num; i++)
		{
			target[i] = (byte)array[i];
		}
		return num;
	}

	internal static byte[] smethod_3(string sourceString)
	{
		return Encoding.UTF8.GetBytes(sourceString);
	}

	internal static char[] smethod_4(byte[] byteArray)
	{
		return Encoding.UTF8.GetChars(byteArray);
	}
}
