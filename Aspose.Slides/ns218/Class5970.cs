using System.Collections;
using ns234;

namespace ns218;

internal class Class5970 : IComparer
{
	public static readonly IComparer icomparer_0 = new Class5970();

	private Class5970()
	{
	}

	public int Compare(object a, object b)
	{
		if (a == b)
		{
			return 0;
		}
		if (a == null)
		{
			return -1;
		}
		if (b == null)
		{
			return 1;
		}
		string text = (string)a;
		string text2 = (string)b;
		int length = text.Length;
		int length2 = text2.Length;
		int num = 0;
		int num2 = 0;
		while (num < length && num2 < length2)
		{
			int num3 = text[num];
			int num4 = text2[num2];
			if ((num3 | num4) <= 127)
			{
				if (num3 >= 97 && num3 <= 122)
				{
					num3 ^= 0x20;
				}
				if (num4 >= 97 && num4 <= 122)
				{
					num4 ^= 0x20;
				}
				if (num3 != num4)
				{
					return num3 - num4;
				}
			}
			else if (num3 != num4)
			{
				num3 = Class6550.smethod_0((char)num3);
				num4 = Class6550.smethod_0((char)num4);
				if (num3 != num4)
				{
					num3 = Class6550.smethod_1((char)num3);
					num4 = Class6550.smethod_1((char)num4);
					if (num3 != num4)
					{
						return num3 - num4;
					}
				}
			}
			num++;
			num2++;
		}
		return length - length2;
	}
}
