using System;
using System.Text;

namespace x6c95d9cf46ff5f25;

internal class x8523dbdcd67276f2
{
	private const int x4768360a773c96e5 = 76;

	private readonly string xc6968386e87173ce;

	private int x17b118c17e16d257;

	public bool x0e410626c9576523 => x17b118c17e16d257 >= xc6968386e87173ce.Length;

	public x8523dbdcd67276f2(byte[] data, int index, int count)
	{
		xc6968386e87173ce = Convert.ToBase64String(data, index, count);
	}

	public string x83f07df6a659e05b()
	{
		int num = Math.Min(76, xc6968386e87173ce.Length - x17b118c17e16d257);
		string result = xc6968386e87173ce.Substring(x17b118c17e16d257, num);
		x17b118c17e16d257 += num;
		return result;
	}

	public static string x5b81632e5b71b64c(byte[] x4a3f0a05c02f235f, string x3de314ab70bbd9bf)
	{
		x8523dbdcd67276f2 x8523dbdcd67276f3 = new x8523dbdcd67276f2(x4a3f0a05c02f235f, 0, x4a3f0a05c02f235f.Length);
		StringBuilder stringBuilder = new StringBuilder();
		while (true)
		{
			stringBuilder.Append(x8523dbdcd67276f3.x83f07df6a659e05b());
			if (x8523dbdcd67276f3.x0e410626c9576523)
			{
				break;
			}
			stringBuilder.Append(x3de314ab70bbd9bf);
		}
		stringBuilder.Append(x3de314ab70bbd9bf);
		return stringBuilder.ToString();
	}
}
