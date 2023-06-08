using System.Collections;

namespace x6c95d9cf46ff5f25;

internal class x86c17cfc92c052fd : IComparer
{
	public static readonly IComparer xb9715d2f06b63cf0;

	private static readonly Hashtable xbf0f924453f389b1;

	private static readonly int[] x8735b1d38ec31051;

	private x86c17cfc92c052fd()
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
			int num3 = x72634e98f4d9c25c(text[num]);
			int num4 = x72634e98f4d9c25c(text2[num2]);
			if (num3 != num4)
			{
				return num3 - num4;
			}
			num++;
			num2++;
		}
		return length - length2;
	}

	private static int x72634e98f4d9c25c(char xb867a42da3ae686d)
	{
		if (!char.IsLetterOrDigit(xb867a42da3ae686d))
		{
			object obj = xbf0f924453f389b1[(int)xb867a42da3ae686d];
			if (obj != null)
			{
				return (int)obj;
			}
			return 0;
		}
		return char.ToLower(xb867a42da3ae686d) - 48 + xbf0f924453f389b1.Count;
	}

	static x86c17cfc92c052fd()
	{
		xb9715d2f06b63cf0 = new x86c17cfc92c052fd();
		xbf0f924453f389b1 = new Hashtable();
		x8735b1d38ec31051 = new int[32]
		{
			33, 34, 35, 36, 37, 38, 40, 41, 42, 44,
			46, 47, 58, 59, 63, 64, 91, 92, 39, 45,
			93, 94, 95, 96, 123, 124, 125, 126, 43, 60,
			61, 62
		};
		int[] array = x8735b1d38ec31051;
		foreach (int num in array)
		{
			xbf0f924453f389b1.Add(num, xbf0f924453f389b1.Count);
		}
	}
}
