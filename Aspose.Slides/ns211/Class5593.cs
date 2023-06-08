using System;
using System.Text;
using ns195;

namespace ns211;

internal class Class5593
{
	private Class5593()
	{
	}

	public static int[] smethod_0(string s, int substitution, bool errorOnSubstitution)
	{
		int length;
		if ((length = s.Length) == 0)
		{
			return new int[0];
		}
		int[] array = new int[length];
		int num = 0;
		int num2 = 0;
		while (true)
		{
			if (num2 < length)
			{
				int num3 = s[num2];
				if (num3 >= 55296 && num3 < 57344)
				{
					int num4 = num3;
					int num5 = ((num2 + 1 < length) ? s[num2 + 1] : '\0');
					if (num4 < 56320)
					{
						if (num5 >= 56320 && num5 < 57344)
						{
							num3 = (num4 - 55296 << 10) + (num5 - 56320) + 65536;
							num2++;
						}
						else
						{
							if (errorOnSubstitution)
							{
								throw new ArgumentException("isolated high (leading) surrogate");
							}
							num3 = substitution;
						}
					}
					else
					{
						if (errorOnSubstitution)
						{
							throw new ArgumentException("isolated low (trailing) surrogate");
						}
						num3 = substitution;
					}
				}
				array[num++] = num3;
				num2++;
				continue;
			}
			if (num != length)
			{
				break;
			}
			return array;
		}
		int[] array2 = new int[num];
		Array.Copy(array, 0, array2, 0, num);
		return array2;
	}

	public static string smethod_1(int[] sa)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (int num in sa)
		{
			if (num < 65535)
			{
				if (num < 55296 || num > 57343)
				{
					stringBuilder.Append((char)num);
					continue;
				}
				string text = Class5710.smethod_8(num);
				throw new ArgumentException("illegal scalar value 0x" + Class5479.smethod_0(text, 2, text.Length - 1) + "; cannot be UTF-16 surrogate");
			}
			if (num < 1114112)
			{
				int num2 = ((num - 65536 >> 10) & 0x3FF) + 55296;
				int num3 = ((num - 65536) & 0x3FF) + 56320;
				stringBuilder.Append((char)num2);
				stringBuilder.Append((char)num3);
				continue;
			}
			string text2 = Class5710.smethod_8(num);
			throw new ArgumentException("illegal scalar value 0x" + Class5479.smethod_0(text2, 2, text2.Length - 1) + "; out of range for UTF-16");
		}
		return stringBuilder.ToString();
	}
}
