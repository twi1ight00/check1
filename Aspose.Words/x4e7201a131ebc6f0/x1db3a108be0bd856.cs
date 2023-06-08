using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using x13f1efc79617a47b;

namespace x4e7201a131ebc6f0;

internal class x1db3a108be0bd856
{
	private const int x052403dc5e63e617 = 1;

	private const int x1b66421930435ec6 = 1;

	private const int x99e856301bc3f80e = 2;

	private const int x4fde6a39c51d35c8 = 3;

	private const int x43b8be9c2e35d35e = 1;

	private const int x9690d8e3090b042e = 2;

	private const int x92d131401f840608 = 3;

	private string x98e285df741c9d32;

	private x8945e5e373eb8aa6 x15c090733a9bf2c2;

	private string x347bb27adfa38121;

	private string x7a983c23a1cc73c3;

	private string x9ab2e82916a560a2;

	private string x1b852f5d9710e969;

	private string x4f458257d25803e7;

	private string x56a92d904f726de2;

	private string x8a00922c82fa5383;

	private static readonly Regex x678a6f08f08fcd29 = new Regex("\\r?\\n\\r?\\n|$", RegexOptions.Compiled);

	private static readonly Regex xb53f6d383ed1a570 = new Regex("\\r?\\n(?=\\S)", RegexOptions.Compiled);

	private static readonly Regex xa0f7865c8982ce05 = new Regex("\\s*:\\s*", RegexOptions.Compiled);

	private static readonly Regex xcc049ec477f6a06c = new Regex("\\r?\\n[ \\t]", RegexOptions.Compiled);

	private static readonly Regex x4e18f72e55a9f04a = new Regex("\\s+[/\\\\]\\s*|[/\\\\]\\s+", RegexOptions.Compiled);

	private static readonly Regex x7f97760fb3bc6e60 = new Regex("\\A([^\\s;]+)\\s*;?\\s*", RegexOptions.Compiled);

	private static readonly Regex x8c660428bd09c448 = new Regex("([^\\s=]+)\\s*=\\s*(?:\"([^\"]+)\"|([^\\s;]+))\\s*;?\\s*", RegexOptions.Compiled);

	private static readonly Regex xa9c724a731a4716b = new Regex("\\s*=\\?([^\\s\\(\\)<>@,;:\"/\\[\\]\\?\\.=]+)\\?([QqBb])\\?([^\\s\\?]*)\\?=\\s*", RegexOptions.Compiled);

	private static readonly Regex x7e1d2fdaeaf3f8dc = new Regex("=([0-9A-F]{2})", RegexOptions.Compiled);

	internal string x0b93856f95be30d0 => x98e285df741c9d32;

	internal x8945e5e373eb8aa6 x8945e5e373eb8aa6 => x15c090733a9bf2c2;

	internal string xa1e62debd3c311a5 => x347bb27adfa38121;

	internal string x27ef141299301ded => x7a983c23a1cc73c3;

	internal string x0707b0d65a658243 => x9ab2e82916a560a2;

	internal string xd6224c0caa44176e => x1b852f5d9710e969;

	internal string xcf1958c8ba1531d5 => x4f458257d25803e7;

	internal string x1ce10e3dd5f1d7f4 => x56a92d904f726de2;

	internal string x56c1af88a9bb0378 => x8a00922c82fa5383;

	internal bool x1f490eac106aee12(string x00ea17a1f369c090, ref int x56cdbfca406748e3, bool xfc076963a5541b8a)
	{
		x98e285df741c9d32 = "";
		x15c090733a9bf2c2 = x8945e5e373eb8aa6.x4d0b9d4447ba7566;
		x347bb27adfa38121 = "";
		x7a983c23a1cc73c3 = "";
		x9ab2e82916a560a2 = "";
		x1b852f5d9710e969 = "";
		x4f458257d25803e7 = "";
		x56a92d904f726de2 = "";
		x8a00922c82fa5383 = "";
		Match match = x678a6f08f08fcd29.Match(x00ea17a1f369c090, x56cdbfca406748e3);
		string input = x00ea17a1f369c090.Substring(x56cdbfca406748e3, match.Index - x56cdbfca406748e3).Trim();
		x56cdbfca406748e3 = match.Index + match.Length;
		bool flag = true;
		string[] array = xb53f6d383ed1a570.Split(input);
		foreach (string input2 in array)
		{
			string[] array2 = xa0f7865c8982ce05.Split(input2, 2);
			if (array2.Length < 2)
			{
				flag = false;
				break;
			}
			xeac2c2722e3cc133(array2[0], array2[1]);
		}
		if (!flag && xfc076963a5541b8a)
		{
			throw new InvalidOperationException("Unexpected format of MIME heading.");
		}
		return flag;
	}

	private void xeac2c2722e3cc133(string xd1020a9db563b699, string xbcea506a33cf9111)
	{
		xbcea506a33cf9111 = xcc049ec477f6a06c.Replace(xbcea506a33cf9111, " ");
		switch (xd1020a9db563b699.ToLower())
		{
		case "content-type":
			x85220fd59294a2de(xbcea506a33cf9111);
			break;
		case "content-transfer-encoding":
			x1b852f5d9710e969 = xbcea506a33cf9111.ToLower();
			break;
		case "content-id":
			if (xbcea506a33cf9111[0] == '<' && xbcea506a33cf9111[xbcea506a33cf9111.Length - 1] == '>')
			{
				x4f458257d25803e7 = xbcea506a33cf9111.Substring(1, xbcea506a33cf9111.Length - 2);
			}
			break;
		case "content-location":
			if (xbcea506a33cf9111[0] == '"' && xbcea506a33cf9111[xbcea506a33cf9111.Length - 1] == '"')
			{
				xbcea506a33cf9111 = xbcea506a33cf9111.Substring(1, xbcea506a33cf9111.Length - 2);
			}
			x56a92d904f726de2 = xdeb01e6d6add541b(xbcea506a33cf9111);
			break;
		case "content-disposition":
			xd6a09f576710ba1e(xbcea506a33cf9111);
			break;
		}
	}

	private void x85220fd59294a2de(string xbcea506a33cf9111)
	{
		Match match = x7f97760fb3bc6e60.Match(xbcea506a33cf9111);
		if (!match.Success)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lidbhkkbhkbcagicaipcjkgdfkndikeegjlemjcfpjjfffagjhhgljogpifhbimhjddikhkiihbjdhijjhpjlggkjhnkfgelfhllhgcmkgjmggandchn", 1349587785)));
		}
		x98e285df741c9d32 = match.Groups[1].Value.ToLower();
		x15c090733a9bf2c2 = x6b72ac741bc83d18(x0b93856f95be30d0);
		int num = match.Length;
		while ((match = x8c660428bd09c448.Match(xbcea506a33cf9111, num)).Success)
		{
			switch (match.Groups[1].Value.ToLower())
			{
			case "boundary":
				x347bb27adfa38121 = x057c66bad7447c07(match);
				break;
			case "charset":
				x7a983c23a1cc73c3 = x057c66bad7447c07(match).ToLower();
				break;
			case "type":
				x9ab2e82916a560a2 = x057c66bad7447c07(match).ToLower();
				break;
			}
			num += match.Length;
		}
		if (xa1e62debd3c311a5.Length == 0 && x8945e5e373eb8aa6 != 0)
		{
			throw new InvalidOperationException("Boundary is missing in MIME heading with multipart Content-Type.");
		}
	}

	private static x8945e5e373eb8aa6 x6b72ac741bc83d18(string xe1d3286d17e44a37)
	{
		if (!xe1d3286d17e44a37.StartsWith("multipart/"))
		{
			return x8945e5e373eb8aa6.x4d0b9d4447ba7566;
		}
		return xe1d3286d17e44a37.Substring("multipart/".Length) switch
		{
			"related" => x8945e5e373eb8aa6.x4584065da1a89b7a, 
			"alternative" => x8945e5e373eb8aa6.xea4d252d87fc677b, 
			_ => x8945e5e373eb8aa6.x36110ac077c974bc, 
		};
	}

	private void xd6a09f576710ba1e(string xbcea506a33cf9111)
	{
		Match match = x7f97760fb3bc6e60.Match(xbcea506a33cf9111);
		if (!match.Success)
		{
			return;
		}
		int num = match.Length;
		while ((match = x8c660428bd09c448.Match(xbcea506a33cf9111, num)).Success)
		{
			string text;
			if ((text = match.Groups[1].Value.ToLower()) != null && text == "filename")
			{
				x8a00922c82fa5383 = xdeb01e6d6add541b(x057c66bad7447c07(match));
			}
			num += match.Length;
		}
	}

	private static string xdeb01e6d6add541b(string xbcea506a33cf9111)
	{
		xbcea506a33cf9111 = x4e18f72e55a9f04a.Replace(xbcea506a33cf9111, "/");
		Match match = xa9c724a731a4716b.Match(xbcea506a33cf9111);
		if (match.Success)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			string text = null;
			bool flag = false;
			int num = 0;
			using MemoryStream x6e0053ba4d6bb1c = new MemoryStream();
			do
			{
				stringBuilder.Append(xbcea506a33cf9111, num, match.Index - num);
				string text2 = match.Groups[1].Value.ToLower();
				string value = match.Groups[2].Value;
				bool flag2 = value == "B" || value == "b";
				string value2 = match.Groups[3].Value;
				if (stringBuilder2.Length == 0)
				{
					stringBuilder2.Append(value2);
					text = text2;
					flag = flag2;
				}
				else if (flag2 == flag && text2 == text)
				{
					stringBuilder2.Append(value2);
				}
				else
				{
					x1024d7ef45e215ca(stringBuilder, stringBuilder2, text, flag, x6e0053ba4d6bb1c);
					stringBuilder2.Append(value2);
					text = text2;
					flag = flag2;
				}
				num = match.Index + match.Length;
				match = xa9c724a731a4716b.Match(xbcea506a33cf9111, num);
			}
			while (match.Success);
			if (stringBuilder2.Length != 0)
			{
				x1024d7ef45e215ca(stringBuilder, stringBuilder2, text, flag, x6e0053ba4d6bb1c);
			}
			stringBuilder.Append(xbcea506a33cf9111, num, xbcea506a33cf9111.Length - num);
			xbcea506a33cf9111 = stringBuilder.ToString();
		}
		else
		{
			xbcea506a33cf9111 = x7e1d2fdaeaf3f8dc.Replace(xbcea506a33cf9111, "%$1");
		}
		return xbcea506a33cf9111;
	}

	private static void x1024d7ef45e215ca(StringBuilder x259613e6fd32742d, StringBuilder xbd89c4785239f9ef, string x1ec8d3808cca2695, bool x3b80d05e7c93547c, MemoryStream x6e0053ba4d6bb1c4)
	{
		Encoding encoding = x56eb95f766e8a78c.xba7d93913e2c1836(x1ec8d3808cca2695);
		if (encoding != null)
		{
			x6e0053ba4d6bb1c4.Position = 0L;
			if (x3b80d05e7c93547c)
			{
				x56eb95f766e8a78c.xabd317c9e1f583de(x6e0053ba4d6bb1c4, xbd89c4785239f9ef.ToString(), 0, xbd89c4785239f9ef.Length);
			}
			else
			{
				x56eb95f766e8a78c.x30a36efd4976138c(x6e0053ba4d6bb1c4, xbd89c4785239f9ef.ToString(), 0, xbd89c4785239f9ef.Length);
			}
			x6e0053ba4d6bb1c4.Position = 0L;
			StreamReader streamReader = new StreamReader(x6e0053ba4d6bb1c4, encoding);
			x259613e6fd32742d.Append(streamReader.ReadToEnd());
		}
		xbd89c4785239f9ef.Length = 0;
	}

	private static string x057c66bad7447c07(Match x1b25e8c7ff13d736)
	{
		Group group = x1b25e8c7ff13d736.Groups[2];
		if (!group.Success)
		{
			group = x1b25e8c7ff13d736.Groups[3];
		}
		return group.Value;
	}
}
