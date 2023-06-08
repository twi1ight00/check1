using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using ns301;

namespace ns288;

internal static class Class6962
{
	private const string string_0 = "(?<=</?\\s*)option(?=[^\\>]*>)";

	private const string string_1 = "\\<(?!/?\\w+[^<>]*?\\>)";

	private const string string_2 = "(?<!\\<[^>]+)\\>";

	public static string smethod_0(string rawHtml)
	{
		rawHtml = smethod_2(rawHtml, "PRE");
		rawHtml = smethod_2(rawHtml, "XMP");
		rawHtml = smethod_2(rawHtml, "PLAINTEXT");
		rawHtml = smethod_2(rawHtml, "TEXTAREA");
		rawHtml = smethod_1(rawHtml);
		return rawHtml;
	}

	private static string smethod_1(string html)
	{
		return Regex.Replace(html, "(?<=</?\\s*)option(?=[^\\>]*>)", "MODOPTION");
	}

	private static string smethod_2(string html, string tag)
	{
		if (Class6973.smethod_0(html))
		{
			return html;
		}
		if (Class6973.smethod_0(tag))
		{
			return html;
		}
		tag = tag.ToLower(CultureInfo.InvariantCulture).Trim();
		StringBuilder stringBuilder = new StringBuilder(html);
		for (int num = html.IndexOf(tag, StringComparison.OrdinalIgnoreCase); num > 0; num = stringBuilder.ToString().IndexOf(tag, StringComparison.OrdinalIgnoreCase))
		{
			if (stringBuilder[num - 1].ToString().Equals("<", StringComparison.OrdinalIgnoreCase))
			{
				stringBuilder = stringBuilder.Remove(0, num + 4);
				int num2 = stringBuilder.ToString().IndexOf(string.Format(CultureInfo.InvariantCulture, "/{0}", new object[1] { tag }), StringComparison.OrdinalIgnoreCase);
				if (num2 < 1)
				{
					break;
				}
				stringBuilder = stringBuilder.Remove(num2 - 1, stringBuilder.Length - num2 + 1);
				string oldValue = stringBuilder.ToString();
				string newValue = (tag.Equals("PRE", StringComparison.OrdinalIgnoreCase) ? smethod_3(stringBuilder.ToString()) : stringBuilder.ToString().Replace("<", "&lt;"));
				html = html.Replace(oldValue, newValue);
			}
			else
			{
				stringBuilder = stringBuilder.Remove(0, num + 3);
			}
		}
		return html;
	}

	private static string smethod_3(string html)
	{
		if (Class6973.smethod_0(html))
		{
			return html;
		}
		MatchCollection matchCollection = Regex.Matches(html, "<");
		int num = 0;
		for (int i = 0; i < matchCollection.Count; i++)
		{
			Match match = matchCollection[i];
			int j = 1;
			bool flag = smethod_5(match, 1, num, html);
			bool flag2 = true;
			if (!flag)
			{
				char c = smethod_4(match, html, j, num);
				for (; !smethod_5(match, j, num, html); j++)
				{
					if (c != " "[0] && c != "/"[0])
					{
						break;
					}
					c = smethod_4(match, html, j, num);
				}
				flag2 = char.IsLetter(c);
			}
			if (flag || !flag2)
			{
				html = html.Remove(match.Index + num, 1);
				html = html.Insert(match.Index + num, "&lt;");
				num += 3;
			}
		}
		return html;
	}

	private static char smethod_4(Match match, string html, int pos, int offset)
	{
		return html[match.Index + pos + offset];
	}

	private static bool smethod_5(Match match, int pos, int offset, string html)
	{
		return match.Index + pos + offset == html.Length;
	}
}
