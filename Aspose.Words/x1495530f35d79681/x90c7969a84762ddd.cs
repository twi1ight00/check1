using System;
using System.Xml;
using Aspose.Words;
using Aspose.Words.Drawing;
using x28925c9b27b37a46;
using x2cc366c8657e2b6a;
using x6c95d9cf46ff5f25;
using x79490184cecf12a1;
using x7c7a1dceb600404e;
using x909757d9fd2dd6ae;
using xda075892eccab2ad;
using xf989f31a236ff98c;

namespace x1495530f35d79681;

internal class x90c7969a84762ddd
{
	private static readonly char[] x98b35fbeb0465499 = new char[2] { ' ', '\t' };

	private x90c7969a84762ddd()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x06b0e25aa6ad68a9(xe134235b3526fa75, null);
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		if (x789564759d365819 == null)
		{
			x789564759d365819 = new xeedad81aaed42a76();
		}
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "rsidR":
			{
				int num2 = xc1b08afa36bf580c.x2a2d5f8dcb4bf0c9(x3bcd232d01c.xd2f68ee6f47e9dfb);
				if (num2 != int.MinValue && num2 != x3bcd232d01c.xbd89d3a43f3ef7f9)
				{
					x789564759d365819.xae20093bed1e48a8(40, num2);
				}
				break;
			}
			case "rsidRPr":
			{
				int num = xc1b08afa36bf580c.x2a2d5f8dcb4bf0c9(x3bcd232d01c.xd2f68ee6f47e9dfb);
				if (num != int.MinValue)
				{
					x789564759d365819.xae20093bed1e48a8(30, num);
				}
				break;
			}
			}
		}
		x19f61333b2e4b4ee(xe134235b3526fa75, x789564759d365819);
		x81b156ace6c5ad7c(xe134235b3526fa75, x789564759d365819);
	}

	private static void x19f61333b2e4b4ee(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		x3bcd232d01c.x99f8cdb2827fa686();
		string xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f;
		while (x3bcd232d01c.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "rPr":
				if (xe134235b3526fa75.x325f1926b78ae5cd)
				{
					x419d718f5b3e63d8.x06b0e25aa6ad68a9(xe134235b3526fa75, x789564759d365819);
				}
				else
				{
					xfa42bde210de8802.x06b0e25aa6ad68a9(xe134235b3526fa75, x789564759d365819);
				}
				break;
			case "t":
			case "instrText":
			case "delText":
			case "delInstrText":
				xc3a6fb8513d320a3(xe134235b3526fa75, x789564759d365819);
				break;
			case "tab":
				x3bcd232d01c.xc6e279ea85863f66.Append(ControlChar.Tab);
				break;
			case "cr":
				x3bcd232d01c.xc6e279ea85863f66.Append(ControlChar.ParagraphBreak);
				break;
			case "softHyphen":
				x3bcd232d01c.xc6e279ea85863f66.Append(ControlChar.xa105f6e68b723c97);
				break;
			case "noBreakHyphen":
				x3bcd232d01c.xc6e279ea85863f66.Append(ControlChar.x6d39aeda91fde741);
				break;
			case "sym":
				x50a0aa193f9f43f8(xe134235b3526fa75, x789564759d365819);
				break;
			case "endnoteReference":
			case "endnote":
				x0edf7490d724552b(xe134235b3526fa75, x789564759d365819, FootnoteType.Endnote);
				break;
			case "footnoteReference":
			case "footnote":
				x0edf7490d724552b(xe134235b3526fa75, x789564759d365819, FootnoteType.Footnote);
				break;
			case "footnoteRef":
			case "endnoteRef":
				x8b92481e3279f961(xe134235b3526fa75, x789564759d365819, '\u0002');
				break;
			case "separator":
				x8b92481e3279f961(xe134235b3526fa75, x789564759d365819, '\u0003');
				break;
			case "continuationSeparator":
				x8b92481e3279f961(xe134235b3526fa75, x789564759d365819, '\u0004');
				break;
			case "commentReference":
			case "annotation":
				x3e6c33155caa6324(xe134235b3526fa75, x789564759d365819);
				break;
			case "annotationRef":
				x8b92481e3279f961(xe134235b3526fa75, x789564759d365819, '\u0005');
				break;
			case "pgNum":
				x2c1796a7ecb546ef(xe134235b3526fa75, x789564759d365819);
				break;
			case "AlternateContent":
				x44ea761ba7ed7dbe(xe134235b3526fa75, x789564759d365819);
				break;
			case "ptab":
				xd136fe6132d998f9(xe134235b3526fa75, x789564759d365819);
				break;
			default:
				if (!x46414487ffde0726(xe134235b3526fa75, x789564759d365819))
				{
					x3bcd232d01c.IgnoreElement();
				}
				break;
			}
		}
	}

	private static void xd136fe6132d998f9(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		AbsolutePositionTab absolutePositionTab = new AbsolutePositionTab(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819);
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "alignment":
				absolutePositionTab.x9ba359ff37a3a63b = xc62574be95c1c918.xbbc60c8915068464(x3bcd232d01c.xd2f68ee6f47e9dfb);
				break;
			case "leader":
				absolutePositionTab.x312ff11290b951a5 = xc62574be95c1c918.x2197c2548108522a(x3bcd232d01c.xd2f68ee6f47e9dfb);
				break;
			case "relativeTo":
				absolutePositionTab.x7073c129de8d5e65 = xc62574be95c1c918.x9529b42fbc8f7272(x3bcd232d01c.xd2f68ee6f47e9dfb);
				break;
			}
		}
		xe134235b3526fa75.x1fa9148f6731ff24(absolutePositionTab);
	}

	private static void x81b156ace6c5ad7c(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		string text = x3bcd232d01c.xc6e279ea85863f66.ToString();
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			Run xda5bf54deb817e = new Run(xe134235b3526fa75.x2c8c6741422a1298, text, x789564759d365819);
			xe134235b3526fa75.x1fa9148f6731ff24(xda5bf54deb817e);
			x3bcd232d01c.xc6e279ea85863f66.Length = 0;
		}
	}

	private static void xc3a6fb8513d320a3(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		string xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f;
		bool flag = xe134235b3526fa75.x936e45dfa3e35eb8 || x3bcd232d01c.xd68abcd61e368af9("space", "") == "preserve" || xa66385d80d4d296f != "t";
		while (x3bcd232d01c.x416ea3123144a39f(xa66385d80d4d296f, x764dfdef5d60f7e6.x96ad199d34a16ce4))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "":
			{
				string xd2f68ee6f47e9dfb = x3bcd232d01c.xd2f68ee6f47e9dfb;
				xd2f68ee6f47e9dfb = xd2f68ee6f47e9dfb.Replace(ControlChar.CrLf, ControlChar.x3e1feffd8ca6feb2);
				if (!flag)
				{
					xd2f68ee6f47e9dfb = xd2f68ee6f47e9dfb.Trim(x98b35fbeb0465499);
					xd2f68ee6f47e9dfb = xd2f68ee6f47e9dfb.Replace('\t', ' ');
				}
				if (x3116e182d030e996(xd2f68ee6f47e9dfb))
				{
					x8b92481e3279f961(xe134235b3526fa75, x789564759d365819, xd2f68ee6f47e9dfb[0]);
				}
				else if (!x1d7da5ef576694f3(xd2f68ee6f47e9dfb))
				{
					x3bcd232d01c.xc6e279ea85863f66.Append(xd2f68ee6f47e9dfb);
				}
				break;
			}
			case "p":
				x51c0702a7631ff46(xe134235b3526fa75);
				break;
			case "tbl":
				xf6fd3fa0599be429(xe134235b3526fa75);
				break;
			default:
				x46414487ffde0726(xe134235b3526fa75, x789564759d365819);
				break;
			}
		}
	}

	private static bool x3116e182d030e996(string x3201d6d15a947682)
	{
		if (x3201d6d15a947682.Length == 1)
		{
			return x3201d6d15a947682[0] == '\u2002';
		}
		return false;
	}

	private static bool x1d7da5ef576694f3(string x3201d6d15a947682)
	{
		if (x3201d6d15a947682.Length > 0 && x3201d6d15a947682[0] == '\r')
		{
			return x0d299f323d241756.x70405672eb3bbb86(x3201d6d15a947682);
		}
		return false;
	}

	internal static bool x46414487ffde0726(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		bool result = true;
		switch (x3bcd232d01c.xa66385d80d4d296f)
		{
		case "pict":
		case "object":
			x555a4f9aa0159d14(xe134235b3526fa75, x789564759d365819);
			break;
		case "drawing":
			x07932593320d7b76(xe134235b3526fa75, x789564759d365819);
			break;
		case "br":
			x3bcd232d01c.xc6e279ea85863f66.Append(xe2345b371772ea0f(x3bcd232d01c, x789564759d365819));
			break;
		case "fldChar":
			xe72aadd3c9a02eb7(xe134235b3526fa75, x789564759d365819);
			break;
		case "fldSimple":
			x85e176379653bc91.x06b0e25aa6ad68a9(xe134235b3526fa75);
			break;
		case "r":
			x06b0e25aa6ad68a9(xe134235b3526fa75, x789564759d365819);
			break;
		default:
			result = false;
			break;
		}
		return result;
	}

	private static void xf6fd3fa0599be429(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.Paragraph);
		if (xe134235b3526fa75.x325f1926b78ae5cd)
		{
			x22063a019e9be4a2.x06b0e25aa6ad68a9(xe134235b3526fa75);
		}
		else
		{
			x41644ef0753fd015.x06b0e25aa6ad68a9(xe134235b3526fa75);
		}
		xe134235b3526fa75.x490834a62c46f14d(new Paragraph(xe134235b3526fa75.x2c8c6741422a1298));
	}

	internal static void x51c0702a7631ff46(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.Paragraph);
		if (xe134235b3526fa75.x325f1926b78ae5cd)
		{
			xf32efa9aef6963ce.x06b0e25aa6ad68a9(xe134235b3526fa75);
		}
		else
		{
			xe20a0cd5b17e35ef.x06b0e25aa6ad68a9(xe134235b3526fa75);
		}
		xe134235b3526fa75.x490834a62c46f14d(new Paragraph(xe134235b3526fa75.x2c8c6741422a1298));
	}

	private static void x8b92481e3279f961(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819, char x3c4da2980d043c95)
	{
		x81b156ace6c5ad7c(xe134235b3526fa75, x789564759d365819);
		xe134235b3526fa75.x1fa9148f6731ff24(new SpecialChar(xe134235b3526fa75.x2c8c6741422a1298, x3c4da2980d043c95, x789564759d365819));
	}

	private static void x50a0aa193f9f43f8(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		x81b156ace6c5ad7c(xe134235b3526fa75, x789564759d365819);
		xeedad81aaed42a76 xeedad81aaed42a = (xeedad81aaed42a76)x789564759d365819.x8b61531c8ea35b85();
		char c = xe134235b3526fa75.x3bcd232d01c14846.x50a0aa193f9f43f8(xeedad81aaed42a);
		xe134235b3526fa75.x1fa9148f6731ff24(new Run(xe134235b3526fa75.x2c8c6741422a1298, c.ToString(), xeedad81aaed42a));
	}

	private static void x0edf7490d724552b(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819, FootnoteType xd3526c7313d75391)
	{
		x81b156ace6c5ad7c(xe134235b3526fa75, x789564759d365819);
		int xeaf1b27180c0557b = -1;
		bool flag = false;
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "id":
				xeaf1b27180c0557b = x3bcd232d01c.xbba6773b8ce56a01;
				break;
			case "customMarkFollows":
				flag = x3bcd232d01c.xc3be6b142c6aca84;
				break;
			case "suppressRef":
				flag = x3bcd232d01c.xc3be6b142c6aca84;
				break;
			}
		}
		Footnote footnote;
		if (xe134235b3526fa75.x325f1926b78ae5cd)
		{
			footnote = xe134235b3526fa75.x3e5f4bed8c6ef7e6(xd3526c7313d75391, xeaf1b27180c0557b);
		}
		else
		{
			footnote = new Footnote(xe134235b3526fa75.x2c8c6741422a1298, xd3526c7313d75391, isAuto: true, null, x789564759d365819);
			x38ecd42e68717d79.x06b0e25aa6ad68a9(xe134235b3526fa75, footnote);
		}
		if (footnote != null)
		{
			footnote.xa72bf798a679c0aa = !flag;
			footnote.x39e7b5501cce0c51(x789564759d365819);
			if (flag)
			{
				x2f1c2fa8dd114cf8(xe134235b3526fa75, x789564759d365819, x3bcd232d01c, footnote);
			}
			xe134235b3526fa75.x1fa9148f6731ff24(footnote);
		}
	}

	private static void x2f1c2fa8dd114cf8(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819, x3c85359e1389ad43 x97bf2eeabd4abc7b, Footnote x897ec71a9f9588a0)
	{
		if (x97bf2eeabd4abc7b.x152cbadbfa8061b1("r"))
		{
			if (x97bf2eeabd4abc7b.xa66385d80d4d296f == "t" && x97bf2eeabd4abc7b.x416ea3123144a39f("t", x764dfdef5d60f7e6.x96ad199d34a16ce4) && x97bf2eeabd4abc7b.xa66385d80d4d296f == "")
			{
				x897ec71a9f9588a0.x715a8c5c33fdc1a6 = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb;
				return;
			}
			if (x97bf2eeabd4abc7b.xa66385d80d4d296f == "br")
			{
				x897ec71a9f9588a0.x715a8c5c33fdc1a6 = xe2345b371772ea0f(x97bf2eeabd4abc7b, x789564759d365819).ToString();
				return;
			}
			if (x97bf2eeabd4abc7b.xa66385d80d4d296f == "sym")
			{
				x897ec71a9f9588a0.x715a8c5c33fdc1a6 = xe134235b3526fa75.x3bcd232d01c14846.x50a0aa193f9f43f8(x789564759d365819).ToString();
				return;
			}
			throw new InvalidOperationException("Unsupported footnote reference mark.");
		}
		throw new InvalidOperationException("Unable to find footnote reference mark.");
	}

	private static void x3e6c33155caa6324(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		x81b156ace6c5ad7c(xe134235b3526fa75, x789564759d365819);
		Comment comment;
		if (xe134235b3526fa75.x325f1926b78ae5cd)
		{
			int xeaf1b27180c0557b = xe134235b3526fa75.x3bcd232d01c14846.xe8602379c60acf13("id", 0);
			comment = xe134235b3526fa75.x8acb911280b864de(xeaf1b27180c0557b);
		}
		else
		{
			comment = x9cee4b6d17a3fda9.x3e6c33155caa6324(x789564759d365819, xe134235b3526fa75);
		}
		if (comment != null)
		{
			comment.x39e7b5501cce0c51(x789564759d365819);
			xe134235b3526fa75.x1fa9148f6731ff24(comment);
		}
	}

	private static void x555a4f9aa0159d14(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		x81b156ace6c5ad7c(xe134235b3526fa75, x789564759d365819);
		ShapeBase shapeBase = xcb00358ab5144003.x06b0e25aa6ad68a9(xe134235b3526fa75);
		if (shapeBase != null)
		{
			shapeBase.xeedad81aaed42a76 = x789564759d365819;
			xe134235b3526fa75.x1fa9148f6731ff24(shapeBase);
		}
	}

	private static void x07932593320d7b76(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		x81b156ace6c5ad7c(xe134235b3526fa75, x789564759d365819);
		xf721f41ceaf253ab xf721f41ceaf253ab2 = (xf721f41ceaf253ab)xe134235b3526fa75;
		xf721f41ceaf253ab2.xd41ddc432f1bf535(x789564759d365819);
	}

	private static void xe72aadd3c9a02eb7(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		x81b156ace6c5ad7c(xe134235b3526fa75, x789564759d365819);
		xc1789523d0b1c8b2.x06b0e25aa6ad68a9(xe134235b3526fa75, x789564759d365819);
	}

	private static void x2c1796a7ecb546ef(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		x81b156ace6c5ad7c(xe134235b3526fa75, x789564759d365819);
		Node[] array = x558767d34a146386.x2163dabd23663d1e(xe134235b3526fa75.x2c8c6741422a1298, x789564759d365819);
		for (int i = 0; i < array.Length; i++)
		{
			xe134235b3526fa75.x1fa9148f6731ff24(array[i]);
		}
	}

	private static char xe2345b371772ea0f(x3c85359e1389ad43 x97bf2eeabd4abc7b, xeedad81aaed42a76 x789564759d365819)
	{
		char result = '\v';
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "type":
				result = xf2a0216b53787578.x5e8e32872393aa9a(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
				break;
			case "clear":
				x789564759d365819.xae20093bed1e48a8(45, xf2a0216b53787578.x79ef6054f168893e(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb));
				break;
			}
		}
		return result;
	}

	private static void x44ea761ba7ed7dbe(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		xd3deb252d4974658 x8a63c4a378f6a = null;
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		bool flag = false;
		while (x3bcd232d01c.x152cbadbfa8061b1("AlternateContent"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "Choice":
				x8a63c4a378f6a = x90f88ef6f3bea229(xe134235b3526fa75, x789564759d365819);
				flag = true;
				break;
			case "Fallback":
				x1f1760fae05e9ab9(xe134235b3526fa75, x789564759d365819, x8a63c4a378f6a);
				if (!flag)
				{
					return;
				}
				break;
			default:
				x3bcd232d01c.xbd5e5733680bbfc8(WarningType.UnexpectedContent, WarningSource.Nrx, x3bcd232d01c.xa66385d80d4d296f);
				break;
			}
		}
	}

	private static xd3deb252d4974658 x90f88ef6f3bea229(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		bool flag = false;
		xd3deb252d4974658 xd3deb252d = new xd3deb252d4974658();
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "Requires")
			{
				string xd2f68ee6f47e9dfb = x3bcd232d01c.xd2f68ee6f47e9dfb;
				if (x0d299f323d241756.x5959bccb67bbf051(xd2f68ee6f47e9dfb))
				{
					string x5172a8cc9ba966dc = x3bcd232d01c.xadae1fe271161ea1(xd2f68ee6f47e9dfb);
					if (xd9ad16ec6228d9a2.xad055c0a8e6d060b(x5172a8cc9ba966dc))
					{
						flag = true;
						xd3deb252d.x410f604cf61abebe = xd2f68ee6f47e9dfb;
					}
				}
			}
			else
			{
				x3bcd232d01c.xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, WarningSource.Nrx, x3bcd232d01c.xa66385d80d4d296f);
			}
		}
		if (flag)
		{
			CompositeNode x0547ea8ef1ef19b = xe134235b3526fa75.x0547ea8ef1ef19b1;
			xe134235b3526fa75.xf5b0b9b6ff7ac462(x0547ea8ef1ef19b.NodeType);
			x0547ea8ef1ef19b.Remove();
			CompositeNode compositeNode = (CompositeNode)x0547ea8ef1ef19b.Clone(isCloneChildren: false);
			xe134235b3526fa75.x490834a62c46f14d(compositeNode);
			x19f61333b2e4b4ee(xe134235b3526fa75, x789564759d365819);
			xe134235b3526fa75.xf5b0b9b6ff7ac462(compositeNode.NodeType);
			compositeNode.Remove();
			xe134235b3526fa75.x490834a62c46f14d(x0547ea8ef1ef19b);
			if (xf0fb968d5ed93ef5(compositeNode))
			{
				return null;
			}
			while (compositeNode.HasChildNodes)
			{
				xe134235b3526fa75.x0547ea8ef1ef19b1.AppendChild(compositeNode.FirstChild);
			}
			return xd3deb252d;
		}
		return null;
	}

	private static bool xf0fb968d5ed93ef5(CompositeNode xff4e081b76a89237)
	{
		NodeCollection childNodes = xff4e081b76a89237.GetChildNodes(NodeType.DrawingML, isDeep: true);
		foreach (DrawingML item in childNodes)
		{
			XmlNodeList elementsByTagName = item.xb327816528e8798b.GetElementsByTagName("txbx", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");
			if (elementsByTagName.Count > 0)
			{
				return true;
			}
		}
		return false;
	}

	private static void x1f1760fae05e9ab9(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819, xd3deb252d4974658 x8a63c4a378f6a927)
	{
		if (x8a63c4a378f6a927 != null)
		{
			CompositeNode compositeNode = (CompositeNode)xe134235b3526fa75.x0547ea8ef1ef19b1.Clone(isCloneChildren: false);
			xe134235b3526fa75.x490834a62c46f14d(compositeNode);
			x19f61333b2e4b4ee(xe134235b3526fa75, (xeedad81aaed42a76)x789564759d365819.x8b61531c8ea35b85());
			x8a63c4a378f6a927.x852c08d9d47ed9db = compositeNode;
			x789564759d365819.xae20093bed1e48a8(790, x8a63c4a378f6a927);
			xe134235b3526fa75.xf5b0b9b6ff7ac462(xe134235b3526fa75.x0547ea8ef1ef19b1.NodeType);
			compositeNode.Remove();
		}
		else
		{
			x19f61333b2e4b4ee(xe134235b3526fa75, x789564759d365819);
		}
	}
}
