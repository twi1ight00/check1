using System;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Words;
using x6c95d9cf46ff5f25;
using xf989f31a236ff98c;

namespace x9b5b1a17490bd5f3;

internal class x5b6d43a151149c74
{
	private class x3b6af6c72b7dd3df
	{
		internal string xb66f90d7e750b49e = "";

		internal string xd2f68ee6f47e9dfb = "";
	}

	private static readonly Regex xfba2737de158c0d0 = new Regex("^['\"]?([^'\"; ]*)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

	private static readonly Regex xe8d9b348769f088f = new Regex("charset=([^'\"; ]*)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

	private readonly x755940550ade8e52 x93ce70fb4ad3e4ab;

	private readonly StringBuilder x08de3ae40531cc51 = new StringBuilder();

	private int xc8c6a66f6feb5d9c;

	private Encoding xcce637b6f486a407;

	private bool x44e600b1432df755;

	private bool xe4d9883bf4be5db6 => xc8c6a66f6feb5d9c >= 3;

	private bool x86dcbeea648fc549
	{
		get
		{
			if (!xe4d9883bf4be5db6)
			{
				return xc8c6a66f6feb5d9c < 0;
			}
			return true;
		}
	}

	private x5b6d43a151149c74(x755940550ade8e52 textReader)
	{
		x93ce70fb4ad3e4ab = textReader;
	}

	internal static FileFormatInfo xdef7f68a22ec051d(x755940550ade8e52 xe43224d95d6cd278)
	{
		return new x5b6d43a151149c74(xe43224d95d6cd278).xdef7f68a22ec051d();
	}

	private FileFormatInfo xdef7f68a22ec051d()
	{
		xcce637b6f486a407 = x93ce70fb4ad3e4ab.x9ee491ab5579b9fc;
		if (xbf3a1fd0c9f6f123(xcce637b6f486a407))
		{
			x44e600b1432df755 = true;
		}
		while ((!x86dcbeea648fc549 || (xe4d9883bf4be5db6 && !x44e600b1432df755)) && x148b831a2855f4c4() && x7e8e720b6a0534eb())
		{
		}
		if (xe4d9883bf4be5db6)
		{
			FileFormatInfo fileFormatInfo = new FileFormatInfo();
			fileFormatInfo.x9d4c5edc77b82e9e(LoadFormat.Html);
			fileFormatInfo.x07279a63090af02d(xcce637b6f486a407);
			return fileFormatInfo;
		}
		return null;
	}

	private bool x148b831a2855f4c4()
	{
		while (x93ce70fb4ad3e4ab.x5959bccb67bbf051)
		{
			switch (x93ce70fb4ad3e4ab.xb079f24d79abc35e())
			{
			case '<':
				x93ce70fb4ad3e4ab.x299147f04b6b58b8();
				return true;
			case '>':
				return false;
			}
		}
		return false;
	}

	private bool x7e8e720b6a0534eb()
	{
		string text = x53a57b164851e56a().ToLower();
		switch (text)
		{
		case "?xml":
		case "!doctype":
		case "html":
		case "head":
		case "title":
		case "meta":
			x93ce70fb4ad3e4ab.x2bb95aedd2d8729f();
			break;
		case "/head":
		case "body":
			x93ce70fb4ad3e4ab.x0e5c2b2252b3794a();
			break;
		case "!--":
			return xdaebc0dbbf713aec();
		case "":
			return false;
		}
		return x16dc06808a729a66(text);
	}

	private string x53a57b164851e56a()
	{
		if (!x93ce70fb4ad3e4ab.x5959bccb67bbf051)
		{
			return "";
		}
		char c = x93ce70fb4ad3e4ab.xb079f24d79abc35e();
		x08de3ae40531cc51.Length = 0;
		while (x93ce70fb4ad3e4ab.x5959bccb67bbf051)
		{
			c = x93ce70fb4ad3e4ab.xb079f24d79abc35e();
			switch (c)
			{
			case '\0':
				return "";
			case '>':
				x93ce70fb4ad3e4ab.x299147f04b6b58b8();
				return x08de3ae40531cc51.ToString();
			}
			if (x0d299f323d241756.x6c589c7857d7d8d9(c))
			{
				return x08de3ae40531cc51.ToString();
			}
			if (c == '-' && x08de3ae40531cc51.ToString() == "!-")
			{
				return "!--";
			}
			x08de3ae40531cc51.Append(c);
		}
		return "";
	}

	private bool xdaebc0dbbf713aec()
	{
		int num = 0;
		while (x93ce70fb4ad3e4ab.x5959bccb67bbf051)
		{
			switch (x93ce70fb4ad3e4ab.xb079f24d79abc35e())
			{
			case '-':
				num++;
				break;
			case '>':
				if (num >= 2)
				{
					return true;
				}
				num = 0;
				break;
			case '\n':
			case '\r':
				x93ce70fb4ad3e4ab.x2bb95aedd2d8729f();
				num = 0;
				break;
			default:
				num = 0;
				break;
			}
		}
		return false;
	}

	private bool x16dc06808a729a66(string x91ef5ae2997ab6c4)
	{
		xd345c73dd1b16b74 xd345c73dd1b16b = xf9e6d2f3b5df04ab();
		if (xd345c73dd1b16b == null)
		{
			return false;
		}
		switch (x91ef5ae2997ab6c4)
		{
		case "?xml":
			if (!x44e600b1432df755)
			{
				xb48178454dc900e9(xd345c73dd1b16b);
			}
			break;
		case "!doctype":
			x7b293abf0ba0c504(xd345c73dd1b16b);
			break;
		case "html":
			xc8c6a66f6feb5d9c = 3;
			break;
		case "head":
		case "title":
		case "body":
		case "table":
		case "tr":
		case "td":
		case "h1":
		case "h2":
		case "h3":
		case "h4":
		case "h5":
		case "h6":
		case "p":
		case "img":
			xc8c6a66f6feb5d9c++;
			break;
		case "meta":
			xc8c6a66f6feb5d9c++;
			if (!x44e600b1432df755)
			{
				xefd49e92984cb654(xd345c73dd1b16b);
			}
			break;
		}
		return true;
	}

	private xd345c73dd1b16b74 xf9e6d2f3b5df04ab()
	{
		xd345c73dd1b16b74 xd345c73dd1b16b = new xd345c73dd1b16b74();
		while (true)
		{
			x3b6af6c72b7dd3df x53d1e845496bf9ed = new x3b6af6c72b7dd3df();
			if (!x1f18aff2ee96f644(x53d1e845496bf9ed))
			{
				break;
			}
			x340db2a86222758a(xd345c73dd1b16b, x53d1e845496bf9ed);
		}
		if (!x934d16237f3e0545())
		{
			return null;
		}
		return xd345c73dd1b16b;
	}

	private bool x1f18aff2ee96f644(x3b6af6c72b7dd3df x53d1e845496bf9ed)
	{
		x53d1e845496bf9ed.xb66f90d7e750b49e = x867f4b0ec22f809b();
		if (x53d1e845496bf9ed.xb66f90d7e750b49e == "")
		{
			return false;
		}
		while (x93ce70fb4ad3e4ab.x5959bccb67bbf051)
		{
			char c = x93ce70fb4ad3e4ab.xb079f24d79abc35e();
			if (!x0d299f323d241756.x6c589c7857d7d8d9(c))
			{
				if (c == '=')
				{
					break;
				}
				x93ce70fb4ad3e4ab.x299147f04b6b58b8();
				return true;
			}
		}
		x53d1e845496bf9ed.xd2f68ee6f47e9dfb = x867f4b0ec22f809b();
		return true;
	}

	private string x867f4b0ec22f809b()
	{
		while (x93ce70fb4ad3e4ab.x5959bccb67bbf051)
		{
			char c = x93ce70fb4ad3e4ab.xb079f24d79abc35e();
			if (!x0d299f323d241756.x6c589c7857d7d8d9(c))
			{
				if (c == '\'' || c == '"')
				{
					return x9404a1d7eaa74471(c);
				}
				x93ce70fb4ad3e4ab.x299147f04b6b58b8();
				return x5acf0daaeb571adb();
			}
		}
		return "";
	}

	private string x9404a1d7eaa74471(char x7dcfa5d5a75077cf)
	{
		x08de3ae40531cc51.Length = 0;
		while (x93ce70fb4ad3e4ab.x5959bccb67bbf051)
		{
			char c = x93ce70fb4ad3e4ab.xb079f24d79abc35e();
			if (c == x7dcfa5d5a75077cf)
			{
				break;
			}
			x08de3ae40531cc51.Append(c);
		}
		return x08de3ae40531cc51.ToString();
	}

	private string x5acf0daaeb571adb()
	{
		x08de3ae40531cc51.Length = 0;
		while (x93ce70fb4ad3e4ab.x5959bccb67bbf051)
		{
			char c = x93ce70fb4ad3e4ab.xb079f24d79abc35e();
			if (x0d299f323d241756.x6c589c7857d7d8d9(c))
			{
				break;
			}
			if (c == '/' || c == '>' || c == '=')
			{
				x93ce70fb4ad3e4ab.x299147f04b6b58b8();
				break;
			}
			x08de3ae40531cc51.Append(c);
		}
		return x08de3ae40531cc51.ToString();
	}

	private void x340db2a86222758a(xd345c73dd1b16b74 x14cfeed0dce50fbf, x3b6af6c72b7dd3df x53d1e845496bf9ed)
	{
		if (!(x53d1e845496bf9ed.xb66f90d7e750b49e == ""))
		{
			string text = x53d1e845496bf9ed.xb66f90d7e750b49e.ToLower();
			x14cfeed0dce50fbf[text] = x53d1e845496bf9ed.xd2f68ee6f47e9dfb.ToLower();
			if (text.StartsWith("xmlns:"))
			{
				x93ce70fb4ad3e4ab.x2bb95aedd2d8729f();
			}
		}
	}

	private bool x934d16237f3e0545()
	{
		if (!x93ce70fb4ad3e4ab.x5959bccb67bbf051)
		{
			return false;
		}
		char c = x93ce70fb4ad3e4ab.xb079f24d79abc35e();
		if (c == '>')
		{
			return true;
		}
		if (!x93ce70fb4ad3e4ab.x5959bccb67bbf051)
		{
			return false;
		}
		c = x93ce70fb4ad3e4ab.xb079f24d79abc35e();
		return c == '>';
	}

	private void xb48178454dc900e9(xd345c73dd1b16b74 x5a5afef41bcb775d)
	{
		string text = (string)x5a5afef41bcb775d["encoding"];
		if (text != null)
		{
			x6d79993f3a8a7338(text);
		}
	}

	private void x7b293abf0ba0c504(xd345c73dd1b16b74 x5a5afef41bcb775d)
	{
		xc8c6a66f6feb5d9c = (x5a5afef41bcb775d.Contains("html") ? 3 : (-1));
	}

	private void xefd49e92984cb654(xd345c73dd1b16b74 x5a5afef41bcb775d)
	{
		string text = (string)x5a5afef41bcb775d["http-equiv"];
		if (text == null || text.ToLower() != "content-type")
		{
			return;
		}
		string text2 = (string)x5a5afef41bcb775d["content"];
		if (text2 == null)
		{
			return;
		}
		Match match = xfba2737de158c0d0.Match(text2);
		if (match.Success)
		{
			string text3 = match.Groups[1].Value.ToLower();
			if (text3 == "text/html")
			{
				xc8c6a66f6feb5d9c = 3;
			}
		}
		match = xe8d9b348769f088f.Match(text2);
		if (match.Success)
		{
			string value = match.Groups[1].Value;
			x6d79993f3a8a7338(value);
		}
	}

	private void x6d79993f3a8a7338(string xa85e323f87f7a358)
	{
		try
		{
			Encoding encoding = Encoding.GetEncoding(xa85e323f87f7a358);
			if (!xbf3a1fd0c9f6f123(encoding))
			{
				xcce637b6f486a407 = encoding;
				x44e600b1432df755 = true;
			}
		}
		catch (ArgumentException)
		{
		}
	}

	private static bool xbf3a1fd0c9f6f123(Encoding xff3edc9aa5f0523b)
	{
		if (xff3edc9aa5f0523b != Encoding.BigEndianUnicode && xff3edc9aa5f0523b != Encoding.Unicode && xff3edc9aa5f0523b != Encoding.GetEncoding(12001) && xff3edc9aa5f0523b != Encoding.UTF32)
		{
			return xff3edc9aa5f0523b == Encoding.UTF7;
		}
		return true;
	}
}
