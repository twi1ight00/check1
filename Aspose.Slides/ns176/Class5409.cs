using System;
using System.Text;
using ns195;

namespace ns176;

internal class Class5409
{
	private static string string_0 = ",;:$&+=";

	private static string string_1 = string_0 + "?/[]@";

	private static char[] char_0 = new char[16]
	{
		'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
		'A', 'B', 'C', 'D', 'E', 'F'
	};

	private Class5409()
	{
	}

	public static string smethod_0(string href)
	{
		href = href.Trim();
		if (href.StartsWith("url(") && href.IndexOf(")") != -1)
		{
			href = Class5479.smethod_0(href, 4, href.LastIndexOf(")")).Trim();
			if (href.StartsWith("'") && href.EndsWith("'"))
			{
				href = Class5479.smethod_0(href, 1, href.Length - 1);
			}
			else if (href.StartsWith("\"") && href.EndsWith("\""))
			{
				href = Class5479.smethod_0(href, 1, href.Length - 1);
			}
		}
		return href;
	}

	private static bool smethod_1(char ch)
	{
		return true;
	}

	private static bool smethod_2(char ch)
	{
		if (ch >= '0')
		{
			return ch <= '9';
		}
		return false;
	}

	private static bool smethod_3(char ch)
	{
		if (ch >= 'A' && ch <= 'Z')
		{
			return true;
		}
		if (ch >= 'A')
		{
			return ch <= 'z';
		}
		return false;
	}

	private static bool smethod_4(char ch)
	{
		if ((ch >= '0' && ch <= '9') || (ch >= 'A' && ch <= 'F'))
		{
			return true;
		}
		if (ch >= 'a')
		{
			return ch <= 'f';
		}
		return false;
	}

	private static bool smethod_5(char ch)
	{
		if (string_1.IndexOf(ch) >= 0)
		{
			return true;
		}
		if ('#' == ch)
		{
			return true;
		}
		return false;
	}

	private static bool smethod_6(char ch)
	{
		if (!smethod_2(ch) && !smethod_3(ch))
		{
			if ("_-!.~'()*".IndexOf(ch) >= 0)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	private static void smethod_7(StringBuilder sb, byte b)
	{
		sb.Append('%').Append(char_0[(b >> 4) & 0xF]).Append(char_0[b & 0xF]);
	}

	public static string smethod_8(string uri)
	{
		uri = smethod_0(uri);
		StringBuilder stringBuilder = new StringBuilder();
		int i = 0;
		for (int length = uri.Length; i < length; i++)
		{
			char c = uri[i];
			if (c == '%' && i < length - 3 && smethod_4(uri[i + 1]) && smethod_4(uri[i + 2]))
			{
				stringBuilder.Append(c);
			}
			else if (!smethod_5(c) && !smethod_6(c))
			{
				try
				{
					byte[] bytes = Encoding.UTF8.GetBytes(c.ToString());
					int j = 0;
					for (int num = bytes.Length; j < num; j++)
					{
						smethod_7(stringBuilder, bytes[j]);
					}
				}
				catch (NotSupportedException)
				{
					throw;
				}
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}
}
