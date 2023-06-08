using System.Collections;
using xf9a9481c3f63a419;

namespace x6c95d9cf46ff5f25;

internal class xebbd06a8e6c039fe : IComparer
{
	public static readonly IComparer xb9715d2f06b63cf0 = new xebbd06a8e6c039fe();

	private xebbd06a8e6c039fe()
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
				num3 = xebb9db61691ea142.x15d62484053869de((char)num3);
				num4 = xebb9db61691ea142.x15d62484053869de((char)num4);
				if (num3 != num4)
				{
					num3 = xebb9db61691ea142.x169b0f985985948a((char)num3);
					num4 = xebb9db61691ea142.x169b0f985985948a((char)num4);
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
