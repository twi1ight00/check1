using System;
using System.Text;

namespace ns218;

internal class Class5949
{
	private const int int_0 = 76;

	private readonly string string_0;

	private int int_1;

	public bool IsEof => int_1 >= string_0.Length;

	public Class5949(byte[] data, int index, int count)
	{
		string_0 = Convert.ToBase64String(data, index, count);
	}

	public string method_0()
	{
		int num = Math.Min(76, string_0.Length - int_1);
		string result = string_0.Substring(int_1, num);
		int_1 += num;
		return result;
	}

	public static string smethod_0(byte[] data, string separator)
	{
		Class5949 @class = new Class5949(data, 0, data.Length);
		StringBuilder stringBuilder = new StringBuilder();
		while (true)
		{
			stringBuilder.Append(@class.method_0());
			if (@class.IsEof)
			{
				break;
			}
			stringBuilder.Append(separator);
		}
		return stringBuilder.ToString();
	}
}
