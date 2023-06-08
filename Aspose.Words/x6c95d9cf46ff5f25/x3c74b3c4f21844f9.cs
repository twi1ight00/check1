using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using Aspose;
using x38d3ef1c1d247e82;
using xf9a9481c3f63a419;

namespace x6c95d9cf46ff5f25;

internal class x3c74b3c4f21844f9
{
	private readonly XmlTextWriter xb6fc07ce0d1eefeb;

	private readonly StringBuilder xb3e1be53c8005a1f;

	public XmlTextWriter x5222f4285e37d66b => xb6fc07ce0d1eefeb;

	public x3c74b3c4f21844f9(Stream stream, Encoding encoding, bool isPrettyFormat)
	{
		if (encoding.CodePage == 65000)
		{
			byte[] preamble = encoding.GetPreamble();
			if (preamble.Length == 0)
			{
				preamble = xe4b3641e8e4ef359.xfe0d791ab77e8b8b;
				stream.Write(preamble, 0, preamble.Length);
			}
		}
		xb6fc07ce0d1eefeb = xd165c26d81eb4a1e.x93e8666599d1712d(stream, encoding);
		xb3e1be53c8005a1f = new StringBuilder(2048);
		xb6fc07ce0d1eefeb.Namespaces = false;
		if (isPrettyFormat)
		{
			xb6fc07ce0d1eefeb.Formatting = Formatting.Indented;
			xb6fc07ce0d1eefeb.Indentation = 1;
			xb6fc07ce0d1eefeb.IndentChar = '\t';
		}
	}

	public x3c74b3c4f21844f9(Stream stream, bool isPrettyFormat)
		: this(stream, Encoding.UTF8, isPrettyFormat)
	{
	}

	[JavaThrows(true)]
	public void x9b9ed0109b743e3b(string x9929b6e6e29df711)
	{
		xb6fc07ce0d1eefeb.WriteStartDocument(standalone: true);
		x2307058321cdb62f(x9929b6e6e29df711);
	}

	[JavaThrows(true)]
	public void xa0dfc102c691b11f()
	{
		xb6fc07ce0d1eefeb.WriteEndElement();
		xb6fc07ce0d1eefeb.WriteEndDocument();
		xb6fc07ce0d1eefeb.Flush();
	}

	[JavaThrows(true)]
	public void x2307058321cdb62f(string x121383aa64985888)
	{
		xb6fc07ce0d1eefeb.WriteStartElement(x121383aa64985888);
	}

	[JavaThrows(true)]
	public void x2dfde153f4ef96d0()
	{
		xb6fc07ce0d1eefeb.WriteEndElement();
	}

	[JavaThrows(true)]
	public void x2dfde153f4ef96d0(string x121383aa64985888)
	{
		xb6fc07ce0d1eefeb.WriteEndElement();
	}

	[JavaThrows(true)]
	public void x538f0e0fb2bf15ab()
	{
		xb6fc07ce0d1eefeb.WriteFullEndElement();
	}

	[JavaThrows(true)]
	public void x538f0e0fb2bf15ab(string x121383aa64985888)
	{
		xb6fc07ce0d1eefeb.WriteFullEndElement();
	}

	[JavaThrows(true)]
	public void xd52401bdf5aacef6(string xb41faee6912a2313)
	{
		xb6fc07ce0d1eefeb.WriteRaw(xb41faee6912a2313);
	}

	public void xf68f9c3818e1f4b1(string x121383aa64985888)
	{
		x6b73ce92fd8e3f2c(x121383aa64985888, null);
	}

	public void x6b73ce92fd8e3f2c(string x121383aa64985888, string xbcea506a33cf9111)
	{
		x2307058321cdb62f(x121383aa64985888);
		x3d1be38abe5723e3(xbcea506a33cf9111);
		x2dfde153f4ef96d0();
	}

	public void x6d7247ebbf9a7643(string x121383aa64985888, string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			x6b73ce92fd8e3f2c(x121383aa64985888, xbcea506a33cf9111);
		}
	}

	public void x6d7247ebbf9a7643(string x121383aa64985888, DateTime xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111.Year > 1)
		{
			x6b73ce92fd8e3f2c(x121383aa64985888, xca004f56614e2431.x6efbf9d15154c80d(xbcea506a33cf9111));
		}
	}

	public void x6b73ce92fd8e3f2c(string x121383aa64985888, int xbcea506a33cf9111)
	{
		x6b73ce92fd8e3f2c(x121383aa64985888, xca004f56614e2431.x754c3a5f03a2ce84(xbcea506a33cf9111));
	}

	[JavaThrows(true)]
	public void x3d1be38abe5723e3(string xbcea506a33cf9111)
	{
		xb6fc07ce0d1eefeb.WriteString(x80134a53bcbb9665(xbcea506a33cf9111));
	}

	[JavaThrows(true)]
	public void x487ee90e3fcccc21(string xc15bd84e01929885, string xbcea506a33cf9111, string xc6e85c82d0d89508)
	{
		if (!(xbcea506a33cf9111 == xc6e85c82d0d89508))
		{
			xff520a0047c27122(xc15bd84e01929885, xbcea506a33cf9111);
		}
	}

	[JavaThrows(true)]
	public void xff520a0047c27122(string xc15bd84e01929885, string xbcea506a33cf9111)
	{
		xb6fc07ce0d1eefeb.WriteAttributeString(xc15bd84e01929885, x80134a53bcbb9665(xbcea506a33cf9111));
	}

	[JavaThrows(true)]
	public void xe24c4103102bcb90(Stream xcf18e5243f8d5fd3)
	{
		if (xcf18e5243f8d5fd3 is MemoryStream)
		{
			xe24c4103102bcb90(((MemoryStream)xcf18e5243f8d5fd3).GetBuffer(), 0, (int)xcf18e5243f8d5fd3.Length);
		}
		else
		{
			xe24c4103102bcb90(x0d299f323d241756.xa0aed4cd3b3d5d92(xcf18e5243f8d5fd3), 0, (int)xcf18e5243f8d5fd3.Length);
		}
	}

	[JavaThrows(true)]
	public void xe24c4103102bcb90(byte[] x5cafa8d49ea71ea1, int xc0c4c459c6ccbd00, int x10f4d88af727adbc)
	{
		x8523dbdcd67276f2 x8523dbdcd67276f3 = new x8523dbdcd67276f2(x5cafa8d49ea71ea1, xc0c4c459c6ccbd00, x10f4d88af727adbc);
		while (!x8523dbdcd67276f3.x0e410626c9576523)
		{
			x3d1be38abe5723e3(x8523dbdcd67276f3.x83f07df6a659e05b());
			xb6fc07ce0d1eefeb.WriteWhitespace("\r\n");
		}
	}

	public string x80134a53bcbb9665(string xb41faee6912a2313)
	{
		if (!xb325dc1192251bb1(xb41faee6912a2313))
		{
			return xb41faee6912a2313;
		}
		xb3e1be53c8005a1f.Length = 0;
		foreach (int item in new x115139807e6482f7(xb41faee6912a2313))
		{
			if (xc543627ab03d4585(item))
			{
				xb3e1be53c8005a1f.Append(xdf3a1f89dca325a3.x251dbcb3221739c5(item));
			}
		}
		return xb3e1be53c8005a1f.ToString();
	}

	private static bool xb325dc1192251bb1(string xb41faee6912a2313)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xb41faee6912a2313))
		{
			return false;
		}
		foreach (int item in new x115139807e6482f7(xb41faee6912a2313))
		{
			if (!xc543627ab03d4585(item))
			{
				return true;
			}
		}
		return false;
	}

	private static bool xc543627ab03d4585(int x0730d42ae0e1c701)
	{
		if (x0730d42ae0e1c701 != 9 && x0730d42ae0e1c701 != 10 && x0730d42ae0e1c701 != 13 && (x0730d42ae0e1c701 < 32 || x0730d42ae0e1c701 > 55295) && (x0730d42ae0e1c701 < 57344 || x0730d42ae0e1c701 > 65533))
		{
			if (x0730d42ae0e1c701 >= 65536)
			{
				return x0730d42ae0e1c701 <= 1114111;
			}
			return false;
		}
		return true;
	}

	public static IDictionary x43dbf3137e50f2b1(x1e9b3e0e8864e135 x337e217cb3ba0627)
	{
		IDictionary dictionary = null;
		StringBuilder stringBuilder = new StringBuilder(1024);
		foreach (string item in x337e217cb3ba0627)
		{
			if (x0d4257c35a8bbef9(item))
			{
				continue;
			}
			if (dictionary == null)
			{
				dictionary = xd51c34d05311eee3.xdb04a310bbb29cff();
			}
			xba682a279001cb45(item, stringBuilder);
			string text2 = stringBuilder.ToString();
			string text3 = text2;
			for (int i = 1; i < 1000; i++)
			{
				if (!x337e217cb3ba0627.x263d579af1d0d43f(text3) && !dictionary.Contains(text3))
				{
					dictionary.Add(item, text3);
					break;
				}
				text3 = $"{text2}_{i}";
			}
		}
		return dictionary;
	}

	private static bool x0d4257c35a8bbef9(string xeaf1b27180c0557b)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xeaf1b27180c0557b))
		{
			return false;
		}
		bool x4273ee7850673e = true;
		foreach (int item in new x115139807e6482f7(xeaf1b27180c0557b))
		{
			if (!x78ebc95b1a8f48cc(item, x4273ee7850673e))
			{
				return false;
			}
			x4273ee7850673e = false;
		}
		return true;
	}

	private static void xba682a279001cb45(string xeaf1b27180c0557b, StringBuilder xfef0c89324a5fd31)
	{
		xfef0c89324a5fd31.Length = 0;
		if (!x0d299f323d241756.x5959bccb67bbf051(xeaf1b27180c0557b))
		{
			return;
		}
		string text = new string('_', 1);
		bool x4273ee7850673e = true;
		foreach (int item in new x115139807e6482f7(xeaf1b27180c0557b))
		{
			xfef0c89324a5fd31.Append(x78ebc95b1a8f48cc(item, x4273ee7850673e) ? xdf3a1f89dca325a3.x251dbcb3221739c5(item) : text);
			x4273ee7850673e = false;
		}
	}

	private static bool x78ebc95b1a8f48cc(int x0730d42ae0e1c701, bool x4273ee7850673e88)
	{
		if (!x4273ee7850673e88)
		{
			return x1984aecce962103b(x0730d42ae0e1c701);
		}
		return x3a2befcfdc144628(x0730d42ae0e1c701);
	}

	private static bool x3a2befcfdc144628(int x0730d42ae0e1c701)
	{
		if (x0730d42ae0e1c701 < 65 || x0730d42ae0e1c701 > 90)
		{
			switch (x0730d42ae0e1c701)
			{
			default:
				if ((x0730d42ae0e1c701 < 192 || x0730d42ae0e1c701 > 214) && (x0730d42ae0e1c701 < 216 || x0730d42ae0e1c701 > 246) && (x0730d42ae0e1c701 < 248 || x0730d42ae0e1c701 > 767) && (x0730d42ae0e1c701 < 880 || x0730d42ae0e1c701 > 893) && (x0730d42ae0e1c701 < 895 || x0730d42ae0e1c701 > 8191) && (x0730d42ae0e1c701 < 8204 || x0730d42ae0e1c701 > 8205) && (x0730d42ae0e1c701 < 8304 || x0730d42ae0e1c701 > 8591) && (x0730d42ae0e1c701 < 11264 || x0730d42ae0e1c701 > 12271) && (x0730d42ae0e1c701 < 12289 || x0730d42ae0e1c701 > 55295) && (x0730d42ae0e1c701 < 63744 || x0730d42ae0e1c701 > 64975) && (x0730d42ae0e1c701 < 65008 || x0730d42ae0e1c701 > 65533))
				{
					if (x0730d42ae0e1c701 >= 65536)
					{
						return x0730d42ae0e1c701 <= 983039;
					}
					return false;
				}
				break;
			case 95:
			case 97:
			case 98:
			case 99:
			case 100:
			case 101:
			case 102:
			case 103:
			case 104:
			case 105:
			case 106:
			case 107:
			case 108:
			case 109:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 119:
			case 120:
			case 121:
			case 122:
				break;
			}
		}
		return true;
	}

	private static bool x1984aecce962103b(int x0730d42ae0e1c701)
	{
		if (!x3a2befcfdc144628(x0730d42ae0e1c701))
		{
			switch (x0730d42ae0e1c701)
			{
			default:
				if (x0730d42ae0e1c701 != 183 && (x0730d42ae0e1c701 < 768 || x0730d42ae0e1c701 > 879))
				{
					if (x0730d42ae0e1c701 >= 8255)
					{
						return x0730d42ae0e1c701 <= 8256;
					}
					return false;
				}
				break;
			case 45:
			case 46:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 57:
				break;
			}
		}
		return true;
	}

	[Conditional("DEBUG")]
	private static void xeb47c8dc84ee7633()
	{
	}

	[Conditional("DEBUG")]
	private static void x58589292704c0b5d(string x121383aa64985888)
	{
	}

	[Conditional("DEBUG")]
	private static void x2b87fc6ec1e75336(string x121383aa64985888)
	{
	}
}
