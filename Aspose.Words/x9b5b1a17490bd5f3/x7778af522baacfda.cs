using System.Collections;
using System.Text.RegularExpressions;
using Aspose.Words;
using x2697283ff424107e;
using x38d3ef1c1d247e82;
using x6c95d9cf46ff5f25;
using x7c4557e104065fc9;
using xf9a9481c3f63a419;

namespace x9b5b1a17490bd5f3;

internal class x7778af522baacfda
{
	private const string x9e40e888d580b25a = "[_a-zA-Z][-_a-zA-Z0-9]*";

	private const int x8a0b6fd8a0e7c73f = 1;

	private const int x0a58ceb82516a8f9 = 2;

	private const int x7c91d263fa61c13f = 3;

	private const string xf477944bc89372c5 = "(?:(?:[_a-zA-Z][-_a-zA-Z0-9]*)?\\.[_a-zA-Z][-_a-zA-Z0-9]*|[_a-zA-Z][-_a-zA-Z0-9]*)";

	private const string x25bd1829659e0863 = "\\{(.*?)\\}";

	private const int xc539b6c9dc712556 = 1;

	private const int x45899702dafd0c22 = 2;

	private const int x7dff2725aa9b23b1 = 3;

	private const string x91ba8be3fe12c0ba = "\"([^\"]+)\"|'([^']+)'|([^\"'\\s]+)";

	private const int x7637cfd317f8fe2e = 1;

	private const int x0ff1cf15166f39e0 = 6;

	private const int x99b1edb1182bd2bf = 1;

	private const int x610276e565298373 = 2;

	private const int xcf52b2ed287d24ed = 1;

	private const int x7ff50abb6b121b4f = 2;

	private readonly StyleCollection x7e088242b8081b52;

	private readonly x0cd0eeb5ca95cea9 xc7c8ca940d0bde59;

	private readonly Hashtable x36b637b892abf848 = new Hashtable();

	private readonly x6519502b0e34e920 x9ea627267c2500d4 = x6519502b0e34e920.x820665812c4c07a7();

	private readonly IDictionary xd234f1d916b7ba3b = xd51c34d05311eee3.xdb04a310bbb29cff();

	private readonly Hashtable x7926d0491d61c6f1 = new Hashtable();

	private static readonly Regex x6503396ac88ed8a6 = new Regex("[\\t\\r\\n\\f]+", RegexOptions.Compiled);

	private static readonly Regex x47e2fcde5660eb17 = new Regex("/\\*.*?\\*/|\\<!--|(//)?--\\>", RegexOptions.Compiled);

	private static readonly Regex xe48ede0fcbc363de = new Regex("\\s*,\\s*", RegexOptions.Compiled);

	private static readonly Regex x1a29d51e453d5ce9 = new Regex("((?:[_a-zA-Z][-_a-zA-Z0-9]*)?)\\.([_a-zA-Z][-_a-zA-Z0-9]*)|([_a-zA-Z][-_a-zA-Z0-9]*)", RegexOptions.Compiled);

	private static readonly Regex x8776204e8dc86bb9 = new Regex("((?:(?:[_a-zA-Z][-_a-zA-Z0-9]*)?\\.[_a-zA-Z][-_a-zA-Z0-9]*|[_a-zA-Z][-_a-zA-Z0-9]*)\\s*(?:,\\s*(?:(?:[_a-zA-Z][-_a-zA-Z0-9]*)?\\.[_a-zA-Z][-_a-zA-Z0-9]*|[_a-zA-Z][-_a-zA-Z0-9]*)\\s*)*|(.*?))\\{(.*?)\\}", RegexOptions.Compiled);

	private static readonly Regex xff95a928bd84c989 = new Regex("^(?:url\\s*\\(\\s*(?:\"([^\"]+)\"|'([^']+)'|([^\"'\\s]+))\\s*\\)|(?:\"([^\"]+)\"|'([^']+)'|([^\"'\\s]+)))\\s*;$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

	private static readonly Regex x5682f599edc4b15f = new Regex("^([_a-zA-Z][-_a-zA-Z0-9]*)\\s*\\{(.*?)\\}", RegexOptions.Compiled);

	private static readonly Regex xcfe6c462ecef96b2 = new Regex("^([_a-zA-Z][-_a-zA-Z0-9]*(?:\\s*,\\s*[_a-zA-Z][-_a-zA-Z0-9]*)*)\\s*\\{(.*)\\}", RegexOptions.Compiled);

	internal x7778af522baacfda(Document targetDocument, x0cd0eeb5ca95cea9 htmlResourceLoader)
	{
		x7e088242b8081b52 = targetDocument.Styles;
		xc7c8ca940d0bde59 = htmlResourceLoader;
	}

	internal void x60c9fd7f08568188(string x04d36c684aaf6f89, string xbda579af315c6893, string x50fc2dc03ef1fe05)
	{
		x9ea627267c2500d4.xa9d636b00ff486b7();
		if (xbda579af315c6893 != null)
		{
			x9ea627267c2500d4.xd6b6ed77479ef68c(xbda579af315c6893);
		}
		x8a34a5c27d8145fe(x04d36c684aaf6f89, x50fc2dc03ef1fe05);
	}

	private void x8a34a5c27d8145fe(string x04d36c684aaf6f89, string x50fc2dc03ef1fe05)
	{
		if (x50fc2dc03ef1fe05 != null)
		{
			x04d36c684aaf6f89 = xaca4ebd805fc7700(x04d36c684aaf6f89);
		}
		bool x2c9afb583c7d348f = false;
		int num = 0;
		while (num + 1 < x04d36c684aaf6f89.Length)
		{
			num = xdd2dd32100e8befd(x04d36c684aaf6f89, num);
			if (num >= x04d36c684aaf6f89.Length)
			{
				break;
			}
			if (x04d36c684aaf6f89[num] == '@')
			{
				int num2 = num;
				num = xf6d71c9b699e8dc6(x04d36c684aaf6f89, num2);
				string x32936360d12105dc = x04d36c684aaf6f89.Substring(num2, num - num2);
				num2 = xdd2dd32100e8befd(x04d36c684aaf6f89, num);
				num = x48791f50537fa2a8(x04d36c684aaf6f89, num2);
				string x35b46f86779ed21a = x04d36c684aaf6f89.Substring(num2, num - num2);
				if (x50fc2dc03ef1fe05 != null)
				{
					x44f14bb72213a671(x32936360d12105dc, x35b46f86779ed21a, x2c9afb583c7d348f, x50fc2dc03ef1fe05);
				}
			}
			else
			{
				x2c9afb583c7d348f = true;
				int num2 = num;
				num = x110d383f21288d1a(x04d36c684aaf6f89, num);
				string input = x04d36c684aaf6f89.Substring(num2, num - num2);
				Match match = x8776204e8dc86bb9.Match(input);
				if (!match.Groups[2].Success && match.Groups[1].Success && match.Groups[3].Success)
				{
					x3a546e05b41dc8b9(match);
				}
			}
		}
	}

	private int xdd2dd32100e8befd(string xf6987a1745781d6f, int x30cc7819189f11b6)
	{
		while (x30cc7819189f11b6 < xf6987a1745781d6f.Length && char.IsWhiteSpace(xf6987a1745781d6f[x30cc7819189f11b6]))
		{
			x30cc7819189f11b6++;
		}
		return x30cc7819189f11b6;
	}

	private int xf6d71c9b699e8dc6(string xf6987a1745781d6f, int x30cc7819189f11b6)
	{
		while (x30cc7819189f11b6 < xf6987a1745781d6f.Length && !char.IsWhiteSpace(xf6987a1745781d6f[x30cc7819189f11b6]))
		{
			x30cc7819189f11b6++;
		}
		return x30cc7819189f11b6;
	}

	private int x48791f50537fa2a8(string xf6987a1745781d6f, int x30cc7819189f11b6)
	{
		int num = 0;
		while (x30cc7819189f11b6 < xf6987a1745781d6f.Length)
		{
			switch (xf6987a1745781d6f[x30cc7819189f11b6])
			{
			case ';':
				if (num <= 0)
				{
					return ++x30cc7819189f11b6;
				}
				break;
			case '{':
				num++;
				break;
			case '}':
				num--;
				if (num <= 0)
				{
					return ++x30cc7819189f11b6;
				}
				break;
			}
			x30cc7819189f11b6++;
		}
		return x30cc7819189f11b6;
	}

	private int x110d383f21288d1a(string xf6987a1745781d6f, int x30cc7819189f11b6)
	{
		int num = 0;
		while (x30cc7819189f11b6 < xf6987a1745781d6f.Length)
		{
			switch (xf6987a1745781d6f[x30cc7819189f11b6])
			{
			case '{':
				num++;
				break;
			case '}':
				num--;
				if (num <= 0)
				{
					return ++x30cc7819189f11b6;
				}
				break;
			}
			x30cc7819189f11b6++;
		}
		return x30cc7819189f11b6;
	}

	private void x44f14bb72213a671(string x32936360d12105dc, string x35b46f86779ed21a, bool x2c9afb583c7d348f, string x50fc2dc03ef1fe05)
	{
		switch (x32936360d12105dc.ToLower())
		{
		case "@import":
			if (!x2c9afb583c7d348f)
			{
				x0f6b79899f652aae(x35b46f86779ed21a, x50fc2dc03ef1fe05);
			}
			break;
		case "@page":
			xb19b007e2ac1497d(x35b46f86779ed21a);
			break;
		case "@media":
			x015651162eaeafa4(x35b46f86779ed21a);
			break;
		}
	}

	private void x3a546e05b41dc8b9(Match x6088325dec1baa2a)
	{
		string[] array = xe48ede0fcbc363de.Split(x6088325dec1baa2a.Groups[1].Value);
		string value = x6088325dec1baa2a.Groups[3].Value;
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6(value);
		bool makeCopy = false;
		string[] array2 = array;
		foreach (string input in array2)
		{
			Match match = x1a29d51e453d5ce9.Match(input);
			Group group = match.Groups[3];
			string text;
			string text2;
			if (group.Success)
			{
				text = group.Value.ToLower();
				text2 = string.Empty;
			}
			else
			{
				text = match.Groups[1].Value.ToLower();
				text2 = match.Groups[2].Value;
			}
			string text3 = x352dc21988193b7c(text, text2);
			xfb9688e07381b985 xfb9688e07381b986 = xa179e1821d2382e1(text3);
			if (xfb9688e07381b986 == null)
			{
				x36b637b892abf848.Add(text3, new xfb9688e07381b985(text, text2, xa3fc7dcdc8182ff, makeCopy));
				makeCopy = true;
			}
			else
			{
				xfb9688e07381b986.x3238f01fbed8df7e(xa3fc7dcdc8182ff);
			}
		}
	}

	private void x0f6b79899f652aae(string x1b6acd5877b3c637, string x50fc2dc03ef1fe05)
	{
		Match match = xff95a928bd84c989.Match(x1b6acd5877b3c637);
		if (!match.Success)
		{
			return;
		}
		string text = null;
		for (int i = 1; i <= 6; i++)
		{
			if (match.Groups[i].Success)
			{
				text = match.Groups[i].Value;
				break;
			}
		}
		string text2 = x0d4d45882065c63e.x53d54e96515ee37d(x50fc2dc03ef1fe05, text);
		if (x9ea627267c2500d4.xd6b6ed77479ef68c(text2))
		{
			string text3 = xc7c8ca940d0bde59.xfef1b21403df783d(x50fc2dc03ef1fe05, text);
			if (x0d299f323d241756.x5959bccb67bbf051(text3))
			{
				x8a34a5c27d8145fe(text3, x0d4d45882065c63e.xad7c54e85c011ae5(text2));
			}
		}
	}

	private void xb19b007e2ac1497d(string x1b6acd5877b3c637)
	{
		Match match = x5682f599edc4b15f.Match(x1b6acd5877b3c637);
		if (match.Success)
		{
			string value = match.Groups[1].Value;
			string value2 = match.Groups[2].Value;
			xd234f1d916b7ba3b[value] = new xa3fc7dcdc8182ff6(value2);
		}
	}

	private void x015651162eaeafa4(string x1b6acd5877b3c637)
	{
		Match match = xcfe6c462ecef96b2.Match(x1b6acd5877b3c637);
		if (!match.Success)
		{
			return;
		}
		string[] array = xe48ede0fcbc363de.Split(match.Groups[1].Value.ToLower());
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text == "all" || text == "screen")
			{
				string value = match.Groups[2].Value;
				x8a34a5c27d8145fe(value, null);
				break;
			}
		}
	}

	internal void xd873da8d8a81b465()
	{
		xfb9688e07381b985 xfb9688e07381b986 = xa179e1821d2382e1("html");
		xfb9688e07381b985 xfb9688e07381b987 = xa179e1821d2382e1("body");
		xfb9688e07381b985 xfb9688e07381b988 = xa179e1821d2382e1("p");
		xfb9688e07381b985[] array = new xfb9688e07381b985[3] { xfb9688e07381b986, xfb9688e07381b987, xfb9688e07381b988 };
		xdac4b063edd35130(array, StyleIdentifier.Normal);
		for (StyleIdentifier styleIdentifier = StyleIdentifier.Heading1; styleIdentifier <= StyleIdentifier.Heading6; styleIdentifier++)
		{
			string xba08ce632055a1d = $"h{(int)styleIdentifier}";
			xfb9688e07381b985 xfb9688e07381b989 = xa179e1821d2382e1(xba08ce632055a1d);
			if (xfb9688e07381b989 != null)
			{
				array[2] = xfb9688e07381b989;
				xdac4b063edd35130(array, styleIdentifier);
			}
		}
		bool x01809bd1ca = true;
		while (x01809bd1ca)
		{
			x01809bd1ca = false;
			foreach (xfb9688e07381b985 value in x36b637b892abf848.Values)
			{
				if (value.x20bd1b246951296e != null || !x5d9cc241017d1f32(value))
				{
					continue;
				}
				xfb9688e07381b985 x45effb35fc0146be = null;
				string x6d1dc28c8a9d4c4e = value.x6d1dc28c8a9d4c4e;
				string x93168ed101bbb = value.x93168ed101bbb044;
				if (x6d1dc28c8a9d4c4e.Length != 0)
				{
					if (x93168ed101bbb.Length != 0)
					{
						x45effb35fc0146be = x4e9eb31f7969231e(x6d1dc28c8a9d4c4e, out x01809bd1ca);
						x8fff472610e0cebb(xaa8d6055ed927851(string.Empty, x93168ed101bbb), null);
						if (x01809bd1ca)
						{
							break;
						}
					}
				}
				else
				{
					x8fff472610e0cebb(xa179e1821d2382e1(x93168ed101bbb), null);
					x8fff472610e0cebb(value, null);
				}
				x8fff472610e0cebb(value, x45effb35fc0146be);
			}
		}
	}

	private bool x5d9cc241017d1f32(xfb9688e07381b985 x1560a0b5003d54a5)
	{
		if (x1560a0b5003d54a5.x6d1dc28c8a9d4c4e == "div" && x1560a0b5003d54a5.x93168ed101bbb044.Length != 0)
		{
			xa3fc7dcdc8182ff6 xf5753384a1839c = x1560a0b5003d54a5.xf5753384a1839c45;
			if (xf5753384a1839c.xd44988f225497f3a == 1)
			{
				xedac08b4826d3056 xedac08b4826d = xf5753384a1839c.get_xe6d4b1b411ed94b5("page");
				if (xedac08b4826d != null)
				{
					string text = xf5753384a1839c.get_xe6d4b1b411ed94b5("page").x48112399d54b30c7();
					if (text.Length != 0)
					{
						x7926d0491d61c6f1[x1560a0b5003d54a5.x93168ed101bbb044] = xd234f1d916b7ba3b[text];
						return false;
					}
				}
			}
		}
		return true;
	}

	private void xdac4b063edd35130(xfb9688e07381b985[] x033581d554415920, StyleIdentifier xa3be2ccad541ab25)
	{
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = null;
		Style style = null;
		foreach (xfb9688e07381b985 xfb9688e07381b986 in x033581d554415920)
		{
			if (xfb9688e07381b986 != null)
			{
				if (xa3fc7dcdc8182ff == null)
				{
					xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
					style = x7e088242b8081b52.xf21e14e2c9db279a(xa3be2ccad541ab25, x988fcf605f8efa7e: true);
				}
				xa3fc7dcdc8182ff.x5b4b16238b2a05ea(xfb9688e07381b986.xf5753384a1839c45);
				if (xfb9688e07381b986.x20bd1b246951296e == null)
				{
					xfb9688e07381b986.x20bd1b246951296e = style;
				}
			}
		}
		if (xa3fc7dcdc8182ff != null)
		{
			xc99f196d172b68a9(xa3fc7dcdc8182ff, style);
		}
	}

	private xfb9688e07381b985 x4e9eb31f7969231e(string x121383aa64985888, out bool x01809bd1ca117109)
	{
		x01809bd1ca117109 = false;
		xfb9688e07381b985 xfb9688e07381b986 = xa179e1821d2382e1(x121383aa64985888);
		if (xfb9688e07381b986 == null && x121383aa64985888.Length == 2 && x121383aa64985888[0] == 'h')
		{
			char c = x121383aa64985888[1];
			if (c >= '1' && c <= '6')
			{
				StyleIdentifier xa3be2ccad541ab = (StyleIdentifier)(1 + (c - 49));
				xfb9688e07381b986 = new xfb9688e07381b985(x121383aa64985888, string.Empty, new xa3fc7dcdc8182ff6(), makeCopy: false);
				x36b637b892abf848.Add(x121383aa64985888, xfb9688e07381b986);
				x01809bd1ca117109 = true;
				xfb9688e07381b985[] x033581d = new xfb9688e07381b985[3]
				{
					xa179e1821d2382e1("html"),
					xa179e1821d2382e1("body"),
					xfb9688e07381b986
				};
				xdac4b063edd35130(x033581d, xa3be2ccad541ab);
			}
		}
		x8fff472610e0cebb(xfb9688e07381b986, null);
		return xfb9688e07381b986;
	}

	private void x8fff472610e0cebb(xfb9688e07381b985 x1560a0b5003d54a5, xfb9688e07381b985 x45effb35fc0146be)
	{
		x8fff472610e0cebb(x1560a0b5003d54a5, x45effb35fc0146be, xbc2b3e3429425e3f: false);
	}

	private void x8fff472610e0cebb(xfb9688e07381b985 x1560a0b5003d54a5, xfb9688e07381b985 x45effb35fc0146be, bool xbc2b3e3429425e3f)
	{
		if (x1560a0b5003d54a5 == null || x1560a0b5003d54a5.x20bd1b246951296e != null)
		{
			return;
		}
		StyleType styleType = xbb1ec6e50f11bc14(x1560a0b5003d54a5, x45effb35fc0146be);
		string xc15bd84e = x1560a0b5003d54a5.x9bcf3bd384d4541c(xbc2b3e3429425e3f);
		xc15bd84e = x7e088242b8081b52.x816b1ea8b69dca23(xc15bd84e);
		x1560a0b5003d54a5.x20bd1b246951296e = x7e088242b8081b52.Add(styleType, xc15bd84e);
		xc99f196d172b68a9(x1560a0b5003d54a5.xf5753384a1839c45, x1560a0b5003d54a5.x20bd1b246951296e);
		if (xbc2b3e3429425e3f)
		{
			x36b637b892abf848.Add(x352dc21988193b7c(x1560a0b5003d54a5.x6d1dc28c8a9d4c4e, x1560a0b5003d54a5.x93168ed101bbb044), x1560a0b5003d54a5);
		}
		string text;
		if (x45effb35fc0146be == null)
		{
			text = ((styleType == StyleType.Character) ? "Default Paragraph Font" : "Normal");
		}
		else
		{
			Style x20bd1b246951296e = x45effb35fc0146be.x20bd1b246951296e;
			if (x20bd1b246951296e.Type != styleType)
			{
				text = x7e088242b8081b52.x816b1ea8b69dca23(x20bd1b246951296e.Name);
				x20bd1b246951296e = x7e088242b8081b52.Add(styleType, text);
				xc99f196d172b68a9(x45effb35fc0146be.xf5753384a1839c45, x20bd1b246951296e);
			}
			else
			{
				text = x20bd1b246951296e.Name;
			}
		}
		x1560a0b5003d54a5.x20bd1b246951296e.BaseStyleName = text;
	}

	private static StyleType xbb1ec6e50f11bc14(xfb9688e07381b985 x1560a0b5003d54a5, xfb9688e07381b985 x45effb35fc0146be)
	{
		xedac08b4826d3056 xedac08b4826d = x1560a0b5003d54a5.xf5753384a1839c45.get_xe6d4b1b411ed94b5("display");
		if (xedac08b4826d == null && x45effb35fc0146be != null)
		{
			xedac08b4826d = x45effb35fc0146be.xf5753384a1839c45.get_xe6d4b1b411ed94b5("display");
		}
		bool flag;
		if (xedac08b4826d != null)
		{
			switch (xedac08b4826d.x48112399d54b30c7().ToLower())
			{
			case "none":
				flag = xf994bf17bf2ebd41(x1560a0b5003d54a5.x6d1dc28c8a9d4c4e);
				break;
			case "inline":
			case "inline-block":
				flag = true;
				break;
			default:
				flag = false;
				break;
			}
		}
		else
		{
			flag = xf994bf17bf2ebd41(x1560a0b5003d54a5.x6d1dc28c8a9d4c4e);
		}
		if (!flag)
		{
			return StyleType.Paragraph;
		}
		return StyleType.Character;
	}

	internal bool x4e17596495bdb6e2(string x121383aa64985888, string x9e7a6fd57c6718d8)
	{
		Style style = xded912b09294bdf7(x121383aa64985888, x9e7a6fd57c6718d8);
		if (style == null)
		{
			return xf994bf17bf2ebd41(x121383aa64985888);
		}
		return style.Type == StyleType.Character;
	}

	internal static bool xf994bf17bf2ebd41(string x121383aa64985888)
	{
		switch (x121383aa64985888)
		{
		case "a":
		case "em":
		case "strong":
		case "dfn":
		case "code":
		case "samp":
		case "kbd":
		case "var":
		case "cite":
		case "abbr":
		case "acronym":
		case "q":
		case "sub":
		case "sup":
		case "b":
		case "i":
		case "u":
		case "s":
		case "strike":
		case "big":
		case "small":
		case "tt":
		case "font":
		case "basefont":
		case "del":
		case "ins":
		case "span":
		case "br":
		case "input":
			return true;
		default:
			return false;
		}
	}

	private static void xc99f196d172b68a9(xa3fc7dcdc8182ff6 x36c843bef78b260f, Style xfbe7d0b7b71963f5)
	{
		ParagraphFormat paragraphFormat = xfbe7d0b7b71963f5.ParagraphFormat;
		if (paragraphFormat != null)
		{
			x4edf5a654b83812d.xe7ce6487f5f217d1(x36c843bef78b260f, paragraphFormat);
		}
		Font font = xfbe7d0b7b71963f5.Font;
		if (font != null)
		{
			x69e8b423c22edb61.xff280c75a0537411(x36c843bef78b260f, font, x032ab0a06188d97e: false);
		}
	}

	internal Style xded912b09294bdf7(string x121383aa64985888, string x9e7a6fd57c6718d8)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(x121383aa64985888))
		{
			return null;
		}
		xfb9688e07381b985 xfb9688e07381b986 = xaa8d6055ed927851(x121383aa64985888, x9e7a6fd57c6718d8);
		if (xfb9688e07381b986 == null && x9e7a6fd57c6718d8.Length != 0)
		{
			xfb9688e07381b986 = xaa8d6055ed927851(string.Empty, x9e7a6fd57c6718d8);
			if (xfb9688e07381b986 != null)
			{
				StyleType type = xfb9688e07381b986.x20bd1b246951296e.Type;
				if ((type != StyleType.Paragraph || !(x121383aa64985888 == "p")) && (type != StyleType.Character || !(x121383aa64985888 == "span")))
				{
					bool x01809bd1ca;
					xfb9688e07381b985 x45effb35fc0146be = x4e9eb31f7969231e(x121383aa64985888, out x01809bd1ca);
					xfb9688e07381b986 = new xfb9688e07381b985(x121383aa64985888, x9e7a6fd57c6718d8, xfb9688e07381b986.xf5753384a1839c45, makeCopy: true);
					x8fff472610e0cebb(xfb9688e07381b986, x45effb35fc0146be, xbc2b3e3429425e3f: true);
				}
			}
			else
			{
				xfb9688e07381b986 = xa179e1821d2382e1(x121383aa64985888);
			}
		}
		return xfb9688e07381b986?.x20bd1b246951296e;
	}

	internal void xd44cab19179e2eee(string x9e7a6fd57c6718d8, PageSetup xaa066f9e98b59c33)
	{
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = (xa3fc7dcdc8182ff6)x7926d0491d61c6f1[x9e7a6fd57c6718d8];
		if (xa3fc7dcdc8182ff != null)
		{
			x015eb412e40a664b.xd5bbd6a43704bfde(xa3fc7dcdc8182ff, xaa066f9e98b59c33);
		}
	}

	internal Hashtable x68b65ea0acfbdf00()
	{
		return x36b637b892abf848;
	}

	private xfb9688e07381b985 xaa8d6055ed927851(string x121383aa64985888, string x9e7a6fd57c6718d8)
	{
		return xa179e1821d2382e1(x352dc21988193b7c(x121383aa64985888, x9e7a6fd57c6718d8));
	}

	private xfb9688e07381b985 xa179e1821d2382e1(string xba08ce632055a1d9)
	{
		return (xfb9688e07381b985)x36b637b892abf848[xba08ce632055a1d9];
	}

	internal static string x352dc21988193b7c(string x121383aa64985888, string x9e7a6fd57c6718d8)
	{
		if (x9e7a6fd57c6718d8.Length != 0)
		{
			return $"{x121383aa64985888}.{x9e7a6fd57c6718d8}";
		}
		return x121383aa64985888;
	}

	internal static string xaca4ebd805fc7700(string x2235b3d6e82b21f8)
	{
		return x47e2fcde5660eb17.Replace(x6503396ac88ed8a6.Replace(x2235b3d6e82b21f8, " "), " ");
	}
}
