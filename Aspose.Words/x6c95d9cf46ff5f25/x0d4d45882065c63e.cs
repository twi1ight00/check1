using System;
using System.IO;
using System.Text;

namespace x6c95d9cf46ff5f25;

internal class x0d4d45882065c63e
{
	private const string x19ae442ed43df7b4 = " <>{}|^[]`\"%";

	private static readonly char[] xb57ccad7f8ac5b5e = new char[11]
	{
		' ', '<', '>', '{', '}', '|', '^', '[', ']', '`',
		'"'
	};

	private static readonly char[] x7229ac1cdc5b060e = new char[2] { '/', '\\' };

	private x0d4d45882065c63e()
	{
	}

	public static string xed9f2ad1e95ded9e(string x50fc2dc03ef1fe05, string x66fab2e81382593c)
	{
		if (!x6bff1629b1379ac5(x66fab2e81382593c))
		{
			return xda76dc634eb9b4f6(x50fc2dc03ef1fe05, x66fab2e81382593c);
		}
		return x66fab2e81382593c;
	}

	public static string x53d54e96515ee37d(string x50fc2dc03ef1fe05, string x66fab2e81382593c)
	{
		x66fab2e81382593c = x2fbbd6c36ce879ff(x66fab2e81382593c);
		if (!x6bff1629b1379ac5(x66fab2e81382593c))
		{
			return xda76dc634eb9b4f6(x50fc2dc03ef1fe05, x66fab2e81382593c);
		}
		return x66fab2e81382593c;
	}

	public static string xc8c8ca56669559a3(string x585da4d9795fa783)
	{
		int num = x585da4d9795fa783.IndexOf('#');
		if (num < 0)
		{
			return x585da4d9795fa783;
		}
		return x585da4d9795fa783.Substring(0, num);
	}

	public static string x358b45b4ddbfa57c(string x585da4d9795fa783)
	{
		int num = x585da4d9795fa783.IndexOf('#');
		if (num < 0)
		{
			return string.Empty;
		}
		return x585da4d9795fa783.Substring(num + 1);
	}

	public static string x60ea34a7657b9f8a(string x179bb663e71b1f59, string x0cc9007787189866)
	{
		if (x179bb663e71b1f59 == null)
		{
			x179bb663e71b1f59 = string.Empty;
		}
		if (x0d299f323d241756.x5959bccb67bbf051(x0cc9007787189866))
		{
			return x179bb663e71b1f59 + "#" + x0cc9007787189866;
		}
		return x179bb663e71b1f59;
	}

	public static bool xe06270bc72b12369(string x585da4d9795fa783)
	{
		return x585da4d9795fa783.IndexOf(':') > 1;
	}

	public static bool x4602b59392dc27e9(string x585da4d9795fa783)
	{
		if (!x4cd6e1c46f1525a6(x585da4d9795fa783))
		{
			return x7c12ca7e8a9abcb8(x585da4d9795fa783);
		}
		return true;
	}

	public static bool x4cd6e1c46f1525a6(string x585da4d9795fa783)
	{
		if (x585da4d9795fa783.Length > 2 && xe827b835e194b994(x585da4d9795fa783[0]) && x585da4d9795fa783[1] == ':')
		{
			if (x585da4d9795fa783[2] != '\\')
			{
				return x585da4d9795fa783[2] == '/';
			}
			return true;
		}
		return false;
	}

	public static bool x7c12ca7e8a9abcb8(string x585da4d9795fa783)
	{
		return x585da4d9795fa783.StartsWith("\\\\");
	}

	public static bool xc327dd161360e68e(string x585da4d9795fa783)
	{
		return x585da4d9795fa783.StartsWith("cid:");
	}

	private static bool xe827b835e194b994(char x3c4da2980d043c95)
	{
		if (x3c4da2980d043c95 < 'a' || x3c4da2980d043c95 > 'z')
		{
			if (x3c4da2980d043c95 >= 'A')
			{
				return x3c4da2980d043c95 <= 'Z';
			}
			return false;
		}
		return true;
	}

	public static string xda76dc634eb9b4f6(string xe468eb5df96d8454, string x5f05d3bdce9c3487)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xe468eb5df96d8454))
		{
			return x5f05d3bdce9c3487;
		}
		string text = ((xe468eb5df96d8454.IndexOf("\\") == -1) ? "/" : "\\");
		if (xe468eb5df96d8454.EndsWith(text))
		{
			return xe468eb5df96d8454 + x5f05d3bdce9c3487;
		}
		return xe468eb5df96d8454 + text + x5f05d3bdce9c3487;
	}

	public static string xad7c54e85c011ae5(string x585da4d9795fa783)
	{
		int num = x585da4d9795fa783.LastIndexOfAny(x7229ac1cdc5b060e);
		if (num >= 0)
		{
			return x585da4d9795fa783.Substring(0, Math.Max(num, 1));
		}
		return ".";
	}

	public static bool xa141f5cbe7fb508b(string x585da4d9795fa783)
	{
		int num = x585da4d9795fa783.LastIndexOf('.');
		int num2 = x585da4d9795fa783.LastIndexOfAny(x7229ac1cdc5b060e);
		int num3 = x585da4d9795fa783.IndexOf("://");
		if (num > num2)
		{
			if (num3 >= 0)
			{
				return num3 + 2 != num2;
			}
			return true;
		}
		return false;
	}

	public static bool xbf8774d82d777b9e(string x585da4d9795fa783)
	{
		return x585da4d9795fa783.StartsWith("#");
	}

	public static string x8644581dcf469731(string x585da4d9795fa783)
	{
		if (!xab1f55e55a78d1e0(x585da4d9795fa783))
		{
			return x585da4d9795fa783;
		}
		return x53e8298db8439150(x585da4d9795fa783);
	}

	public static string x53e8298db8439150(string x585da4d9795fa783)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in x585da4d9795fa783)
		{
			if (x3b80d1af8cbdebd6(c))
			{
				x094090d728f71904(stringBuilder, c);
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	public static string x2fbbd6c36ce879ff(string x585da4d9795fa783)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x585da4d9795fa783))
		{
			return x585da4d9795fa783;
		}
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		while (num < x585da4d9795fa783.Length)
		{
			char c = x585da4d9795fa783[num];
			if (c == '%' && num + 2 < x585da4d9795fa783.Length)
			{
				string xe4115acdf4fbfccc = x585da4d9795fa783.Substring(num, 3);
				if (xbfdf8ed15859a9a9(xe4115acdf4fbfccc))
				{
					stringBuilder.Append(xb6e9e62a82ccfb2f(xe4115acdf4fbfccc));
					num += 3;
					continue;
				}
			}
			stringBuilder.Append(c);
			num++;
		}
		return stringBuilder.ToString();
	}

	private static bool x3b80d1af8cbdebd6(char xb867a42da3ae686d)
	{
		return " <>{}|^[]`\"%".IndexOf(xb867a42da3ae686d) >= 0;
	}

	private static bool xab1f55e55a78d1e0(string x585da4d9795fa783)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x585da4d9795fa783))
		{
			return false;
		}
		if (x4cd6e1c46f1525a6(x585da4d9795fa783) || x7c12ca7e8a9abcb8(x585da4d9795fa783))
		{
			return false;
		}
		if (x585da4d9795fa783.IndexOfAny(xb57ccad7f8ac5b5e) >= 0)
		{
			return true;
		}
		for (int i = 0; i < x585da4d9795fa783.Length; i++)
		{
			if (x585da4d9795fa783[i] == '%' && i + 2 < x585da4d9795fa783.Length && !xbfdf8ed15859a9a9(x585da4d9795fa783.Substring(i, 3)))
			{
				return true;
			}
		}
		return false;
	}

	private static bool x6bff1629b1379ac5(string x585da4d9795fa783)
	{
		if (!xe06270bc72b12369(x585da4d9795fa783) && !x4cd6e1c46f1525a6(x585da4d9795fa783))
		{
			return x7c12ca7e8a9abcb8(x585da4d9795fa783);
		}
		return true;
	}

	private static bool xbfdf8ed15859a9a9(string xe4115acdf4fbfccc)
	{
		if (xe4115acdf4fbfccc.Length == 3 && xe4115acdf4fbfccc[0] == '%' && x0d299f323d241756.xb8f085ba3fb39f54(xe4115acdf4fbfccc[1]))
		{
			return x0d299f323d241756.xb8f085ba3fb39f54(xe4115acdf4fbfccc[2]);
		}
		return false;
	}

	private static char xb6e9e62a82ccfb2f(string xe4115acdf4fbfccc)
	{
		return (char)(x0d299f323d241756.xe3ec68422266caf1(xe4115acdf4fbfccc[1]) * 16 + x0d299f323d241756.xe3ec68422266caf1(xe4115acdf4fbfccc[2]));
	}

	private static void x094090d728f71904(StringBuilder x52f1c2093c8a7493, char xb867a42da3ae686d)
	{
		x52f1c2093c8a7493.Append('%');
		x52f1c2093c8a7493.Append(x0d299f323d241756.xd7eddd4ee94f26bb((byte)xb867a42da3ae686d));
	}

	public static string xbb8e765da244dfdd(string x2203195bfd781fc2, string xafe2f3653ee64ebc)
	{
		if (Path.GetFileName(xafe2f3653ee64ebc) == xafe2f3653ee64ebc)
		{
			return Path.Combine(Path.GetDirectoryName(x2203195bfd781fc2), Path.GetFileName(xafe2f3653ee64ebc));
		}
		return xafe2f3653ee64ebc;
	}
}
