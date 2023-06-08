using System;
using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;
using x2a6f63b6650e76c4;
using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class x25abb95a730411e4
{
	private readonly Field x54c413cc80cb99d5;

	private xbe79105033f99558 xf8b3fa68f2999220;

	internal string xe3e1b80b2b1644ca => x54c413cc80cb99d5.xb452e2ee706d7a67.x6eba61762c5e83d7("\\#");

	internal string x21d82b8f3e4c4642 => x54c413cc80cb99d5.xb452e2ee706d7a67.x6eba61762c5e83d7("\\@");

	internal xbe79105033f99558 xcb95a4eb398e8796
	{
		get
		{
			if (xf8b3fa68f2999220 == null)
			{
				xf8b3fa68f2999220 = new xbe79105033f99558(x54c413cc80cb99d5.xb452e2ee706d7a67);
			}
			return xf8b3fa68f2999220;
		}
	}

	internal x25abb95a730411e4(Field field)
	{
		x54c413cc80cb99d5 = field;
	}

	internal bool xd4f20c6c3f6afa2f(x82e26649b09596bd xbcea506a33cf9111, out string x7d95d971d8923f4c)
	{
		bool flag = xe63a183f2c163577(xbcea506a33cf9111, out x7d95d971d8923f4c) || x9540796cdde76ac8(xbcea506a33cf9111, out x7d95d971d8923f4c) || x14a2072f78336d5b(xbcea506a33cf9111, out x7d95d971d8923f4c) || x6681811cca8ac252(xbcea506a33cf9111, out x7d95d971d8923f4c);
		string xbcea506a33cf9112 = x7d95d971d8923f4c;
		bool result = x4f3f165f4a93dc19(xbcea506a33cf9112, out x7d95d971d8923f4c);
		if (!flag)
		{
			return result;
		}
		return true;
	}

	private bool x6681811cca8ac252(x82e26649b09596bd xbcea506a33cf9111, out string x7d95d971d8923f4c)
	{
		x7d95d971d8923f4c = xbcea506a33cf9111.xf6e2349738d2d14e;
		string x43f4d74ca20da89e = x21d82b8f3e4c4642;
		if (!x0d299f323d241756.x5959bccb67bbf051(x43f4d74ca20da89e))
		{
			x43f4d74ca20da89e = x54c413cc80cb99d5.x6edce55dcd2d335b.x43f4d74ca20da89e;
		}
		if (!x0d299f323d241756.x5959bccb67bbf051(x43f4d74ca20da89e))
		{
			return false;
		}
		string text = xbcea506a33cf9111.x6681811cca8ac252(x43f4d74ca20da89e, x54c413cc80cb99d5.xb452e2ee706d7a67.x55913a1dc35ee24c);
		if (text != null)
		{
			x7d95d971d8923f4c = text;
			return true;
		}
		return false;
	}

	private bool x9540796cdde76ac8(x82e26649b09596bd xbcea506a33cf9111, out string x7d95d971d8923f4c)
	{
		x7d95d971d8923f4c = xbcea506a33cf9111.xf6e2349738d2d14e;
		string text = xe3e1b80b2b1644ca;
		if (!x0d299f323d241756.x5959bccb67bbf051(text))
		{
			return false;
		}
		string text2 = xbcea506a33cf9111.x9540796cdde76ac8(text);
		if (text2 != null)
		{
			x7d95d971d8923f4c = text2;
			return true;
		}
		return false;
	}

	private bool xe63a183f2c163577(x82e26649b09596bd xbcea506a33cf9111, out string x7d95d971d8923f4c)
	{
		x7d95d971d8923f4c = null;
		if (!xbcea506a33cf9111.xbbbd3dabf01980ee(out var xbcea506a33cf9112))
		{
			return false;
		}
		int num = (int)xbcea506a33cf9112;
		if (num < 0 || num > 32767)
		{
			return false;
		}
		string text = xcb95a4eb398e8796.xd113acd60d1dd3f6();
		if (text != null)
		{
			string text2;
			if ((text2 = text.ToLower()) != null && text2 == "dollartext")
			{
				x7d95d971d8923f4c = xce449f9cbc44a7e6.x9d3c32d8c874fcd5(xbcea506a33cf9112);
			}
			else
			{
				x7d95d971d8923f4c = x00b47748a95c9437.x19fa8583862b446b(num, xb40472df83f14c02(text), x3b747bc7816d8768: false);
			}
			return true;
		}
		return false;
	}

	private bool x14a2072f78336d5b(x82e26649b09596bd xbcea506a33cf9111, out string x7d95d971d8923f4c)
	{
		x7d95d971d8923f4c = null;
		if (!xbcea506a33cf9111.xbbbd3dabf01980ee(out var xbcea506a33cf9112))
		{
			return false;
		}
		Section section = x54c413cc80cb99d5.xe8d4351bdfdbf28a();
		if (section != null)
		{
			x7d95d971d8923f4c = x00b47748a95c9437.x19fa8583862b446b((int)xbcea506a33cf9112, section.PageSetup.PageNumberStyle, x3b747bc7816d8768: false);
			return true;
		}
		return false;
	}

	private bool x4f3f165f4a93dc19(string xbcea506a33cf9111, out string x7d95d971d8923f4c)
	{
		x7d95d971d8923f4c = xbcea506a33cf9111;
		bool result = false;
		foreach (string item in xcb95a4eb398e8796)
		{
			xbc1709746b087e6c xbc1709746b087e6c = x5c4a790acd3f0100(item);
			if (xbc1709746b087e6c != 0)
			{
				x7d95d971d8923f4c = xb7dbd7bb3ed97d5b.x041cc377735f8501(x7d95d971d8923f4c, xbc1709746b087e6c);
				result = true;
			}
		}
		return result;
	}

	internal x04c0e061352aeb47 xab1a64aa04b401a0()
	{
		string text = xcb95a4eb398e8796.xe4f99d01c82052fc();
		if (text == null)
		{
			if (!x5c29822913be33c1.xbe3a0f5f2b0d8ea2(x54c413cc80cb99d5.Type))
			{
				return new x2a70bc2d90576783(x54c413cc80cb99d5);
			}
			return new xd668791b2f624cdb();
		}
		return text.ToLower() switch
		{
			"charformat" => new x2a70bc2d90576783(x54c413cc80cb99d5), 
			"mergeformat" => new x6faec3efd633f535(x54c413cc80cb99d5), 
			_ => throw new InvalidOperationException(), 
		};
	}

	private static NumberStyle xb40472df83f14c02(string x5786461d089b10a0)
	{
		switch (x5786461d089b10a0.ToLower())
		{
		case "arabic":
			return NumberStyle.Arabic;
		case "roman":
			if (!char.IsLower(x5786461d089b10a0[0]))
			{
				return NumberStyle.UppercaseRoman;
			}
			return NumberStyle.LowercaseRoman;
		case "alphabetic":
			if (!char.IsLower(x5786461d089b10a0[0]))
			{
				return NumberStyle.UppercaseLetter;
			}
			return NumberStyle.LowercaseLetter;
		case "ordinal":
			return NumberStyle.Ordinal;
		case "ordtext":
			return NumberStyle.OrdinalText;
		case "cardtext":
			return NumberStyle.Number;
		case "hex":
			return NumberStyle.Hex;
		default:
			return NumberStyle.None;
		}
	}

	private static xbc1709746b087e6c x5c4a790acd3f0100(string x5786461d089b10a0)
	{
		return x5786461d089b10a0.ToLower() switch
		{
			"caps" => xbc1709746b087e6c.xa6417f0b87702333, 
			"firstcap" => xbc1709746b087e6c.x4c95b3a38f1afc3a, 
			"lower" => xbc1709746b087e6c.x3f230538ea01aa0e, 
			"upper" => xbc1709746b087e6c.xad26a7203634de8e, 
			"dbchar" => xbc1709746b087e6c.xce79258263c70a58, 
			_ => xbc1709746b087e6c.xb9715d2f06b63cf0, 
		};
	}
}
