using System.Collections;
using System.Text;
using Aspose.Words;
using Aspose.Words.Fields;
using x6c95d9cf46ff5f25;
using xe86f37adaccef1c3;
using xf9a9481c3f63a419;

namespace xfbd1009a0cbb9842;

internal class x83172c5a922ba47d : Field, x6ed66b5cf8da2955, x64b01a877c5fd558
{
	private static readonly IDictionary xa6e82ce59d36e77d;

	private static readonly string[] xedde941ecc730680;

	private string xe6b1194a5c81b5f1;

	private string xef352825cdb55c36;

	private StringBuilder xd1741972b5cc2b0c;

	internal string x871c6948f8f9ceb5 => base.xb452e2ee706d7a67.x6eba61762c5e83d7("\\e");

	internal string xa16a589005db14c8 => base.xb452e2ee706d7a67.x6eba61762c5e83d7("\\f");

	internal string x609daf39d0822544 => base.xb452e2ee706d7a67.x6eba61762c5e83d7("\\l");

	string x64b01a877c5fd558.x5c6443ded0369839 => xa16a589005db14c8;

	IDictionary x64b01a877c5fd558.xe731d6cec9a63042 => xa6e82ce59d36e77d;

	internal override x5dc2b4bc740c9563 x83bcdf1790545fdb()
	{
		xa11a4c48b53f49a6 xa11a4c48b53f49a = (xa11a4c48b53f49a6)base.x6edce55dcd2d335b.xc1acbb49fa87a8a3();
		if (xa11a4c48b53f49a != null)
		{
			if (xd1741972b5cc2b0c == null)
			{
				xd1741972b5cc2b0c = new StringBuilder();
			}
			else
			{
				xd1741972b5cc2b0c.Length = 0;
			}
			xde99a4913041ec62 xde99a4913041ec63 = new xde99a4913041ec62(this, xa11a4c48b53f49a);
			string text = xde99a4913041ec63.x0a554e652b768c5d();
			if (!x0d299f323d241756.x5959bccb67bbf051(text) || !x714601b213bca6b5())
			{
				text = x871c6948f8f9ceb5;
			}
			return new xca592a476766b11a(this, $"{xe6b1194a5c81b5f1} {text}{xef352825cdb55c36}", new x15d8a03b1db63b1e(applyToContainingField: false, removeParentParagraph: false));
		}
		return new xca592a476766b11a(this, "«GreetingLine»");
	}

	private bool x714601b213bca6b5()
	{
		string x19218ffab70283ef = xd1741972b5cc2b0c.ToString();
		for (int i = 0; i < xedde941ecc730680.Length; i++)
		{
			if (x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, xedde941ecc730680[i]))
			{
				return true;
			}
		}
		return false;
	}

	private x9f6b815e19fa8f62 x6b9dc5b8ca4335e3(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\e":
		case "\\f":
		case "\\l":
			return x9f6b815e19fa8f62.x47e3e032f7bd5d28;
		default:
			return x9f6b815e19fa8f62.xf6c17f648b65c793;
		}
	}

	x9f6b815e19fa8f62 x6ed66b5cf8da2955.x3ecf81e56889c4af(string x724fbd227bfb6eda)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x6b9dc5b8ca4335e3
		return this.x6b9dc5b8ca4335e3(x724fbd227bfb6eda);
	}

	private Document x6fc9cf1a21adbc81()
	{
		return x357c90b33d6bb8e6();
	}

	Document x64b01a877c5fd558.x0e887c4fa8f397a5()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x6fc9cf1a21adbc81
		return this.x6fc9cf1a21adbc81();
	}

	private string xa8e833ece84dedc4(x190443e12b0b496b x0f7b23d1c393aed9, x714b8c1b8d1b556b x37f3a555926e71c4)
	{
		switch (x37f3a555926e71c4.x759aa16c2016a289.ToUpper())
		{
		case "BEFORE":
			xe6b1194a5c81b5f1 = x37f3a555926e71c4.x97586616c5ed2194.Trim();
			return string.Empty;
		case "AFTER":
			xef352825cdb55c36 = x37f3a555926e71c4.x97586616c5ed2194.Trim();
			return string.Empty;
		default:
		{
			string text = x0f7b23d1c393aed9.x193434603289be03(x37f3a555926e71c4.x759aa16c2016a289);
			if (!x0d299f323d241756.x5959bccb67bbf051(text))
			{
				return string.Empty;
			}
			switch (x37f3a555926e71c4.x759aa16c2016a289.ToUpper())
			{
			case "TITLE1":
			case "FIRST1":
				xd1741972b5cc2b0c.AppendFormat("<<_and {0}_>>", x37f3a555926e71c4.x759aa16c2016a289);
				return $"and {text}";
			default:
				xd1741972b5cc2b0c.AppendFormat("<<_{0}_>>", x37f3a555926e71c4.x759aa16c2016a289);
				return text;
			}
		}
		}
	}

	string x64b01a877c5fd558.x193434603289be03(x190443e12b0b496b x0f7b23d1c393aed9, x714b8c1b8d1b556b x37f3a555926e71c4)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa8e833ece84dedc4
		return this.xa8e833ece84dedc4(x0f7b23d1c393aed9, x37f3a555926e71c4);
	}

	static x83172c5a922ba47d()
	{
		xa6e82ce59d36e77d = xd51c34d05311eee3.xdb04a310bbb29cff();
		xedde941ecc730680 = new string[13]
		{
			"<<_TITLE0_>><<_LAST0_>>", "<<_TITLE0_>><<and _TITLE1_>><<_LAST0_>>", "<<_TITLE0_>><<_FIRST0_>><<_LAST0_>><<_SUFFIX0_>>", "<<_TITLE0_>><<_NICK0_>><<_LAST0_>><<_SUFFIX0_>>", "<<_FIRST0_>><<_LAST0_>><<_SUFFIX0_>>", "<<_NICK0_>><<_LAST0_>><<_SUFFIX0_>>", "<<_FIRST0_>><<and _FIRST1_>><<_LAST0_>>", "<<_NICK0_>><<and _FIRST1_>><<_LAST0_>>", "<<_FIRST0_>>", "<<_NICK0_>>",
			"<<_FIRST0_>><<and _FIRST1_>>", "<<_NICK0_>><<and _FIRST1_>>", "<<Mr. and Mrs. _LAST0_>>"
		};
		xa6e82ce59d36e77d.Add("TITLE0", "Courtesy Title");
		xa6e82ce59d36e77d.Add("NICK0", "Nickname");
		xa6e82ce59d36e77d.Add("FIRST0", "First Name");
		xa6e82ce59d36e77d.Add("LAST0", "Last Name");
		xa6e82ce59d36e77d.Add("SUFFIX0", "Suffix");
		xa6e82ce59d36e77d.Add("TITLE1", "Spouse Courtesy Title");
		xa6e82ce59d36e77d.Add("NICK1", "Spouse Nickname");
		xa6e82ce59d36e77d.Add("FIRST1", "Spouse First Name");
		xa6e82ce59d36e77d.Add("LAST1", "Spouse Last Name");
	}
}
