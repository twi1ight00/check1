using System.Text;

namespace ns2;

internal class Class1652
{
	internal Class1652()
	{
	}

	internal static int smethod_0(string string_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			byte[] bytes = Encoding.ASCII.GetBytes(string_0);
			int[] array = smethod_1(bytes);
			int num = array[0];
			for (int i = 1; i < array.Length; i++)
			{
				num ^= array[i];
			}
			num ^= array.Length;
			return num ^ 0xCE4B;
		}
		return 0;
	}

	private static int[] smethod_1(byte[] byte_0)
	{
		int[] array = new int[byte_0.Length];
		for (int i = 0; i < byte_0.Length; i++)
		{
			int num = byte_0[i];
			for (int j = 1; j < i + 2; j++)
			{
				num <<= 1;
				if (num > 32767)
				{
					num -= 32767;
				}
			}
			array[i] = num;
		}
		return array;
	}
}
