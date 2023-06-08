using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace ns301;

internal class Class6968
{
	private static readonly char[] char_0 = new char[3] { ';', '&', ' ' };

	public static string smethod_0(string s)
	{
		if (s == null)
		{
			return null;
		}
		if (s.IndexOf('&') < 0)
		{
			return s;
		}
		StringBuilder stringBuilder = new StringBuilder();
		StringWriter output = new StringWriter(stringBuilder, CultureInfo.InvariantCulture);
		smethod_1(s, output);
		return stringBuilder.ToString();
	}

	public static void smethod_1(string s, TextWriter output)
	{
		if (s == null)
		{
			return;
		}
		if (s.IndexOf('&') < 0)
		{
			output.Write(s);
			return;
		}
		int length = s.Length;
		for (int i = 0; i < length; i++)
		{
			char c = s[i];
			if (c == '&')
			{
				int num = s.IndexOfAny(char_0, i + 1);
				string text = string.Empty;
				bool flag = false;
				if (num > 0 && (s[num] == ';' || s[num] == ' '))
				{
					text = s.Substring(i + 1, num - i - 1);
					flag = s[num] == ';';
				}
				else if (num < 0)
				{
					text = s.Substring(i + 1, s.Length - i - 1);
				}
				if (text.Length == 0)
				{
					output.Write(c);
					continue;
				}
				i = ((num <= -1) ? (s.Length - 1) : num);
				if (text.Length > 1 && text[0] == '#')
				{
					try
					{
						c = ((text[1] == 'x' || text[1] == 'X') ? ((char)int.Parse(text.Substring(2), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture)) : ((char)int.Parse(text.Substring(1), CultureInfo.InvariantCulture)));
					}
					catch (FormatException)
					{
						i++;
					}
					catch (ArgumentException)
					{
						i++;
					}
				}
				else
				{
					char c2 = Class6967.smethod_0(text);
					if (c2 == '\0')
					{
						output.Write('&');
						output.Write(text);
						if (flag)
						{
							output.Write(';');
						}
						continue;
					}
					c = c2;
				}
			}
			output.Write(c);
		}
	}

	public static void smethod_2(string s, TextWriter output)
	{
		if (s == null)
		{
			return;
		}
		if (s.IndexOf('&') < 0)
		{
			output.Write(s);
			return;
		}
		int length = s.Length;
		for (int i = 0; i < length; i++)
		{
			char c = s[i];
			if (c == '&')
			{
				int num = s.IndexOfAny(char_0, i + 1);
				if (num > 0 && s[num] == ';')
				{
					string text = s.Substring(i + 1, num - i - 1);
					if (text.Length > 1 && text[0] == '#')
					{
						try
						{
							c = ((text[1] == 'x' || text[1] == 'X') ? ((char)int.Parse(text.Substring(2), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture)) : ((char)int.Parse(text.Substring(1), CultureInfo.InvariantCulture)));
							i = num;
						}
						catch (FormatException)
						{
							i++;
						}
						catch (ArgumentException)
						{
							i++;
						}
					}
					else
					{
						i = num;
						char c2 = Class6967.smethod_0(text);
						if (c2 == '\0')
						{
							output.Write('&');
							output.Write(text);
							output.Write(';');
							continue;
						}
						c = c2;
					}
				}
			}
			output.Write(c);
		}
	}
}
