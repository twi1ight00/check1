using System;
using System.Text;
using Aspose.Words;
using Aspose.Words.Fields;
using Aspose.Words.Settings;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xfbd1009a0cbb9842;

namespace xf989f31a236ff98c;

internal class x08802e9e984cd3ee
{
	private readonly xaa47e6d0b035aea6 xb595028f9534e276;

	private readonly StringBuilder x2cecce51cee63fa3 = new StringBuilder(2048);

	private Font x11480eb30248e5ba;

	private string xdd512a32116c26d3;

	private x000f21cbda739311 xc2254c1cc5b184a1 = x000f21cbda739311.x175297738c8b8d1e;

	private readonly CompatibilityOptions xb53ae056f09e3965;

	internal x08802e9e984cd3ee(xaa47e6d0b035aea6 handler, CompatibilityOptions compatibility)
	{
		if (handler == null)
		{
			throw new ArgumentNullException("handler");
		}
		xb595028f9534e276 = handler;
		xb53ae056f09e3965 = compatibility;
	}

	internal void x5c6f8dca650ee955(Inline x31545d7c306a55e4)
	{
		xd22cb714335f8d2c(x31545d7c306a55e4.GetText(), x31545d7c306a55e4.Font);
	}

	internal void xd22cb714335f8d2c(string xb41faee6912a2313, Font x26094932cf7a9139)
	{
		x964b5d2e75135646();
		x11480eb30248e5ba = x26094932cf7a9139;
		xdd512a32116c26d3 = x11480eb30248e5ba.xaf95fb496eb25433(xc2254c1cc5b184a1);
		foreach (char c in xb41faee6912a2313)
		{
			switch (c)
			{
			case '\r':
				xc325f08e9c7ac384();
				xb595028f9534e276.x284f8021a6d47363(x11480eb30248e5ba);
				break;
			case '\v':
				xc325f08e9c7ac384();
				xb595028f9534e276.x284f8021a6d47363(x11480eb30248e5ba);
				break;
			case '\f':
				xc325f08e9c7ac384();
				xb595028f9534e276.x6597dd39dd2fe401(x11480eb30248e5ba);
				break;
			case '\u000e':
				xc325f08e9c7ac384();
				xb595028f9534e276.x52597787a113eeb0(x11480eb30248e5ba);
				break;
			case '\t':
				xc325f08e9c7ac384();
				xb595028f9534e276.x3d5e17ecf5a24632(x11480eb30248e5ba);
				break;
			case '\u00a0':
				xc325f08e9c7ac384();
				xb595028f9534e276.x036788cf7c188d59(x11480eb30248e5ba);
				break;
			case '\u001e':
				xc325f08e9c7ac384();
				xb595028f9534e276.x85c770ad4ef06982(x11480eb30248e5ba);
				break;
			case '\u001f':
				xc325f08e9c7ac384();
				xb595028f9534e276.xf376b77c1a1556bf(x11480eb30248e5ba);
				break;
			case '\u2002':
				xc325f08e9c7ac384();
				xb595028f9534e276.x036788cf7c188d59(x11480eb30248e5ba);
				break;
			case ' ':
				xb696f85280947ed5(c);
				break;
			case '\\':
				xc4d300f8cf80a8d6(x3aff3b90ab163f1b() ? '¥' : c);
				break;
			case '\u200f':
				xc325f08e9c7ac384();
				xb595028f9534e276.x920950f507ecd136(x11480eb30248e5ba, xe68b7760102eb0fd: true);
				break;
			case '\u200e':
				xc325f08e9c7ac384();
				xb595028f9534e276.x920950f507ecd136(x11480eb30248e5ba, xe68b7760102eb0fd: false);
				break;
			default:
				xc4d300f8cf80a8d6(c);
				break;
			case '\u0002':
				break;
			}
		}
		xc325f08e9c7ac384();
	}

	private bool x3aff3b90ab163f1b()
	{
		if (xb53ae056f09e3965.DoNotLeaveBackslashAlone)
		{
			return x11480eb30248e5ba.LocaleIdFarEast == 1041;
		}
		return false;
	}

	private void xc4d300f8cf80a8d6(char x3c4da2980d043c95)
	{
		x000f21cbda739311 x000f21cbda = x8a88fed54cea007c(x3c4da2980d043c95, x11480eb30248e5ba);
		if (x000f21cbda != xc2254c1cc5b184a1)
		{
			string text = x11480eb30248e5ba.xaf95fb496eb25433(x000f21cbda);
			if (xdd512a32116c26d3 != text)
			{
				xc325f08e9c7ac384();
			}
			xc2254c1cc5b184a1 = x000f21cbda;
			xdd512a32116c26d3 = text;
		}
		xb696f85280947ed5(x3c4da2980d043c95);
	}

	private static x000f21cbda739311 x8a88fed54cea007c(char x3c4da2980d043c95, Font x26094932cf7a9139)
	{
		x000f21cbda739311 x000f21cbda = xb7dbd7bb3ed97d5b.xc0f0857806be03ff(x3c4da2980d043c95);
		if (x000f21cbda != 0)
		{
			return x000f21cbda;
		}
		if (x000f21cbda == x000f21cbda739311.x22a0fbb9469b35e1 && x26094932cf7a9139.xf2ad33c56ce6586d && x26094932cf7a9139.x405f93d712e7bd65 == x000f21cbda739311.x7c8c2d13fa5b79fa)
		{
			if (!xe8abfa8506874b16.xe5e9215c47c64515(x3c4da2980d043c95, x26094932cf7a9139.LocaleIdFarEast))
			{
				return x000f21cbda739311.x22a0fbb9469b35e1;
			}
			return x000f21cbda739311.x7c8c2d13fa5b79fa;
		}
		if (!x26094932cf7a9139.xf2ad33c56ce6586d)
		{
			return x000f21cbda;
		}
		return x26094932cf7a9139.x405f93d712e7bd65;
	}

	private void xc325f08e9c7ac384()
	{
		if (x2cecce51cee63fa3.Length > 0)
		{
			xb595028f9534e276.x4fb8d507f4b3c96e(x11480eb30248e5ba, x2cecce51cee63fa3.ToString(), xc2254c1cc5b184a1);
			x964b5d2e75135646();
		}
	}

	internal void xa7aaf885c26f719e(Field xe01ae93d9fe5a880)
	{
		x7e263f21a73a027a x7e263f21a73a027a = xe01ae93d9fe5a880.x1c428e55430b2acc();
		if (x7e263f21a73a027a == null)
		{
			return;
		}
		int num = 0;
		xb56968f92e308c8a xb56968f92e308c8a = new xb56968f92e308c8a(x7e263f21a73a027a);
		while (xb56968f92e308c8a.x1ef2c3be187f37a2(x0d900d42b3598fde: true))
		{
			Node x3387295f12854dfd = xb56968f92e308c8a.x3387295f12854dfd;
			switch (x3387295f12854dfd.NodeType)
			{
			case NodeType.FieldStart:
				num++;
				break;
			case NodeType.FieldSeparator:
				num--;
				break;
			case NodeType.FieldEnd:
				if (!((FieldEnd)x3387295f12854dfd).HasSeparator)
				{
					num--;
				}
				break;
			default:
				if (num == 0 && x3387295f12854dfd is Inline x31545d7c306a55e)
				{
					x5c6f8dca650ee955(x31545d7c306a55e);
				}
				break;
			}
		}
	}

	internal void x9085a9baa2b43723(Field xe01ae93d9fe5a880)
	{
		x92c79996b74b2c30 x92c79996b74b2c = x92c79996b74b2c30.x1f490eac106aee12(xe01ae93d9fe5a880.GetFieldCode());
		if (x92c79996b74b2c.xfea0b9f75f567474 != 0)
		{
			Font font = new Font((xeedad81aaed42a76)xe01ae93d9fe5a880.End.xeedad81aaed42a76.x8b61531c8ea35b85(), xe01ae93d9fe5a880.End.Document.Styles);
			if (x0d299f323d241756.x5959bccb67bbf051(x92c79996b74b2c.x707c2bded9e130c2))
			{
				font.Name = x92c79996b74b2c.x707c2bded9e130c2;
			}
			if (x92c79996b74b2c.x70c328f6f2e77d76 > 0.0)
			{
				font.Size = x92c79996b74b2c.x70c328f6f2e77d76;
			}
			xd22cb714335f8d2c(x92c79996b74b2c.xfb1fc02db7c42694.ToString(), font);
		}
	}

	internal void x4870ccdb67430ef1(Paragraph x41baca1d6c0c2e8e)
	{
		bool flag = !x41baca1d6c0c2e8e.x843b0ab4e04a29f2;
		if (!flag)
		{
			flag = x41baca1d6c0c2e8e.xf562da51e0b3c429()?.Text.EndsWith(ControlChar.LineBreak) ?? false;
		}
		if (x41baca1d6c0c2e8e.IsEndOfCell)
		{
			flag = flag && !(x41baca1d6c0c2e8e.x90463af0c741fac1 is Table);
		}
		else if (x41baca1d6c0c2e8e.IsEndOfSection && !x41baca1d6c0c2e8e.IsEndOfDocument)
		{
			flag = flag && x41baca1d6c0c2e8e.ParentStory.x74f5d3c8c1c169b6;
		}
		if (flag)
		{
			xb595028f9534e276.xa2b89eef4b059bae(x41baca1d6c0c2e8e.ParagraphBreakFont);
		}
	}

	private void xb696f85280947ed5(char x3c4da2980d043c95)
	{
		x2cecce51cee63fa3.Append(x3c4da2980d043c95);
	}

	private void x964b5d2e75135646()
	{
		x2cecce51cee63fa3.Length = 0;
	}
}
