using System;
using System.Text;

namespace ns218;

internal static class Class5973
{
	private const string string_0 = " <>{}|^[]`\"%";

	private static readonly char[] char_0 = new char[11]
	{
		' ', '<', '>', '{', '}', '|', '^', '[', ']', '`',
		'"'
	};

	private static readonly char[] char_1 = new char[2] { '/', '\\' };

	public static string smethod_0(string baseUri, string originalUri)
	{
		if (!smethod_5(originalUri))
		{
			return smethod_12(baseUri, originalUri);
		}
		return originalUri;
	}

	public static string smethod_1(string baseUri, string originalUri)
	{
		originalUri = smethod_18(originalUri);
		if (!smethod_5(originalUri))
		{
			return smethod_12(baseUri, originalUri);
		}
		return originalUri;
	}

	public static string smethod_2(string href)
	{
		int num = href.IndexOf('#');
		if (num < 0)
		{
			return href;
		}
		return href.Substring(0, num);
	}

	public static string smethod_3(string href)
	{
		int num = href.IndexOf('#');
		if (num < 0)
		{
			return string.Empty;
		}
		return href.Substring(num + 1);
	}

	public static string smethod_4(string address, string subAddress)
	{
		if (address == null)
		{
			address = string.Empty;
		}
		if (Class5964.smethod_20(subAddress))
		{
			return address + "#" + subAddress;
		}
		return address;
	}

	public static bool smethod_5(string href)
	{
		if (!smethod_6(href) && !smethod_8(href))
		{
			return smethod_9(href);
		}
		return true;
	}

	public static bool smethod_6(string href)
	{
		return href.IndexOf(':') > 1;
	}

	public static bool smethod_7(string href)
	{
		if (!smethod_8(href))
		{
			return smethod_9(href);
		}
		return true;
	}

	public static bool smethod_8(string href)
	{
		if (href.Length > 2 && smethod_11(href[0]) && href[1] == ':')
		{
			if (href[2] != '\\')
			{
				return href[2] == '/';
			}
			return true;
		}
		return false;
	}

	public static bool smethod_9(string href)
	{
		return href.StartsWith("\\\\");
	}

	public static bool smethod_10(string href)
	{
		return href.StartsWith("cid:");
	}

	private static bool smethod_11(char c)
	{
		if (c >= 'a' && c <= 'z')
		{
			return true;
		}
		if (c >= 'A')
		{
			return c <= 'Z';
		}
		return false;
	}

	public static string smethod_12(string basePart, string relativePart)
	{
		if (!Class5964.smethod_20(basePart))
		{
			return relativePart;
		}
		string text = ((basePart.IndexOf("\\") == -1) ? "/" : "\\");
		if (basePart.EndsWith(text))
		{
			return basePart + relativePart;
		}
		return basePart + text + relativePart;
	}

	public static string smethod_13(string href)
	{
		int num = href.LastIndexOfAny(char_1);
		if (num >= 0)
		{
			return href.Substring(0, Math.Max(num, 1));
		}
		return ".";
	}

	public static bool smethod_14(string href)
	{
		int num = href.LastIndexOf('.');
		int num2 = href.LastIndexOfAny(char_1);
		int num3 = href.IndexOf("://");
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

	public static bool smethod_15(string href)
	{
		return href.StartsWith("#");
	}

	public static string smethod_16(string href)
	{
		if (!smethod_20(href))
		{
			return href;
		}
		return smethod_17(href);
	}

	public static string smethod_17(string href)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in href)
		{
			if (smethod_19(c))
			{
				smethod_23(stringBuilder, c);
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	public static string smethod_18(string href)
	{
		if (!Class5964.smethod_20(href))
		{
			return href;
		}
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		while (num < href.Length)
		{
			char c = href[num];
			if (c == '%' && num + 2 < href.Length)
			{
				string s = href.Substring(num, 3);
				if (smethod_21(s))
				{
					stringBuilder.Append(smethod_22(s));
					num += 3;
					continue;
				}
			}
			stringBuilder.Append(c);
			num++;
		}
		return stringBuilder.ToString();
	}

	private static bool smethod_19(char ch)
	{
		return " <>{}|^[]`\"%".IndexOf(ch) >= 0;
	}

	private static bool smethod_20(string href)
	{
		if (!Class5964.smethod_20(href))
		{
			return false;
		}
		if (!smethod_8(href) && !smethod_9(href))
		{
			if (href.IndexOfAny(char_0) >= 0)
			{
				return true;
			}
			int num = 0;
			while (true)
			{
				if (num < href.Length)
				{
					if (href[num] == '%' && num + 2 < href.Length && !smethod_21(href.Substring(num, 3)))
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	private static bool smethod_21(string s)
	{
		if (s.Length == 3 && s[0] == '%' && Class5964.smethod_36(s[1]))
		{
			return Class5964.smethod_36(s[2]);
		}
		return false;
	}

	private static char smethod_22(string s)
	{
		return (char)(Class5964.smethod_35(s[1]) * 16 + Class5964.smethod_35(s[2]));
	}

	private static void smethod_23(StringBuilder stringBuilder, char ch)
	{
		stringBuilder.Append('%');
		stringBuilder.Append(Class5964.smethod_40((byte)ch));
	}
}
