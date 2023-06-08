using System.Collections;
using Aspose.Words;
using x1495530f35d79681;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x909757d9fd2dd6ae;
using x9db5f2e5af3d596e;
using xda075892eccab2ad;

namespace x79490184cecf12a1;

internal class x703bc0db5f036bb2
{
	private x703bc0db5f036bb2()
	{
	}

	internal static void x06b0e25aa6ad68a9(x11e1346c12ead315 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3c85359e1389ad = xe134235b3526fa75.x1b1aeab2a2e668c4("http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles");
		if (x3c85359e1389ad == null)
		{
			return;
		}
		xc25c28c64aadfd1b xc25c28c64aadfd1b = new xc25c28c64aadfd1b();
		while (x3c85359e1389ad.x152cbadbfa8061b1("styles"))
		{
			switch (x3c85359e1389ad.xa66385d80d4d296f)
			{
			case "docDefaults":
				xc156bf2e5c334aac(xe134235b3526fa75);
				break;
			case "latentStyles":
				x7b6e399a5fa35ca1(xe134235b3526fa75);
				break;
			case "style":
				x637d7e009920d5a9(xe134235b3526fa75, xc25c28c64aadfd1b);
				break;
			default:
				x3c85359e1389ad.IgnoreElement();
				break;
			}
		}
		xc25c28c64aadfd1b.x5f3c0783a74b5d80(xe134235b3526fa75);
		xe134235b3526fa75.xc8ab4e294c74831b();
	}

	private static void xc156bf2e5c334aac(x11e1346c12ead315 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("docDefaults"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "rPrDefault":
				xae853c527653f9a6(xe134235b3526fa75);
				break;
			case "pPrDefault":
				x358b16dcf7ac13ae(xe134235b3526fa75);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void xae853c527653f9a6(x11e1346c12ead315 xe134235b3526fa75)
	{
		StyleCollection styles = xe134235b3526fa75.x2c8c6741422a1298.Styles;
		styles.x17edf608baa39956 = true;
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("rPrDefault"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "rPr")
			{
				xeedad81aaed42a76 x27096df7ca0cfe2e = styles.x27096df7ca0cfe2e;
				x419d718f5b3e63d8.x06b0e25aa6ad68a9(xe134235b3526fa75, x27096df7ca0cfe2e);
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
	}

	private static void x358b16dcf7ac13ae(x11e1346c12ead315 xe134235b3526fa75)
	{
		StyleCollection styles = xe134235b3526fa75.x2c8c6741422a1298.Styles;
		styles.x3dde3ba6a116b7ee = true;
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("pPrDefault"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "pPr")
			{
				x1a78664fa10a3755 xf4eb04b8b9073eeb = styles.xf4eb04b8b9073eeb;
				xeedad81aaed42a76 x27096df7ca0cfe2e = styles.x27096df7ca0cfe2e;
				xec45413ffc971f9d.x06b0e25aa6ad68a9(xe134235b3526fa75, xf4eb04b8b9073eeb, x27096df7ca0cfe2e);
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
	}

	private static void x7b6e399a5fa35ca1(x11e1346c12ead315 xe134235b3526fa75)
	{
		x90347bcd8deede01 x90347bcd8deede = xe134235b3526fa75.x2c8c6741422a1298.Styles.x90347bcd8deede01;
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "count":
				x90347bcd8deede.x6c7ca9aba118e7af = x3bcd232d01c.xbba6773b8ce56a01;
				break;
			case "defLockedState":
				x90347bcd8deede.x799a64ee3b4ce806 = x3bcd232d01c.xc3be6b142c6aca84;
				break;
			case "defQFormat":
				x90347bcd8deede.x0c40b3ed8738297c = x3bcd232d01c.xc3be6b142c6aca84;
				break;
			case "defSemiHidden":
				x90347bcd8deede.xe27cb3f1d698353d = x3bcd232d01c.xc3be6b142c6aca84;
				break;
			case "defUIPriority":
				x90347bcd8deede.x4d0e04ab61f50baa = x3bcd232d01c.xbba6773b8ce56a01;
				break;
			case "defUnhideWhenUsed":
				x90347bcd8deede.xa657c8b674ff2f76 = x3bcd232d01c.xc3be6b142c6aca84;
				break;
			}
		}
		while (x3bcd232d01c.x152cbadbfa8061b1("latentStyles"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "lsdException")
			{
				x6fdeeab1197729bf(xe134235b3526fa75);
			}
		}
	}

	private static void x6fdeeab1197729bf(x11e1346c12ead315 xe134235b3526fa75)
	{
		x90347bcd8deede01 x90347bcd8deede = xe134235b3526fa75.x2c8c6741422a1298.Styles.x90347bcd8deede01;
		bool locked = x90347bcd8deede.x799a64ee3b4ce806;
		string xbcea506a33cf = "";
		bool quickFormat = x90347bcd8deede.x0c40b3ed8738297c;
		bool semiHidden = x90347bcd8deede.xe27cb3f1d698353d;
		int uiPriority = x90347bcd8deede.x4d0e04ab61f50baa;
		bool unhideWhenUsed = x90347bcd8deede.xa657c8b674ff2f76;
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "locked":
				locked = x3bcd232d01c.xc3be6b142c6aca84;
				break;
			case "name":
				xbcea506a33cf = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			case "qFormat":
				quickFormat = x3bcd232d01c.xc3be6b142c6aca84;
				break;
			case "semiHidden":
				semiHidden = x3bcd232d01c.xc3be6b142c6aca84;
				break;
			case "uiPriority":
				uiPriority = x3bcd232d01c.xbba6773b8ce56a01;
				break;
			case "unhideWhenUsed":
				unhideWhenUsed = x3bcd232d01c.xc3be6b142c6aca84;
				break;
			}
		}
		StyleIdentifier styleIdentifier = x72a0c846678ecaf9.x3b3cea4656a2e16d(xbcea506a33cf);
		if (styleIdentifier != StyleIdentifier.User)
		{
			x90347bcd8deede.x31805fef2aff8b5f.xd6b6ed77479ef68c(new x565726a756595ed4(styleIdentifier, locked, quickFormat, semiHidden, uiPriority, unhideWhenUsed));
		}
	}

	private static void x637d7e009920d5a9(x11e1346c12ead315 xe134235b3526fa75, ArrayList x92323ab304083408)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		StyleCollection styles = xe134235b3526fa75.x2c8c6741422a1298.Styles;
		bool x5409eeb7bc = false;
		string text = null;
		StyleType x4320c3ef9926c38d = StyleType.Paragraph;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "customStyle":
				x5409eeb7bc = x3bcd232d01c.xc3be6b142c6aca84;
				break;
			case "styleId":
				text = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			case "type":
				x4320c3ef9926c38d = xc62574be95c1c918.xfefa9c1896e1f470(x3bcd232d01c.xd2f68ee6f47e9dfb);
				break;
			}
		}
		Style style = Style.xebcf83b00134300b(x4320c3ef9926c38d);
		x22510822ff0a46e1 x22510822ff0a46e = new x22510822ff0a46e1(style);
		string text2 = null;
		string text3 = null;
		while (x3bcd232d01c.x152cbadbfa8061b1("style"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "name":
				text2 = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "aliases":
				text3 = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "basedOn":
				x22510822ff0a46e.x4c48a782e25bce54 = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "next":
				x22510822ff0a46e.xbc13914359462815 = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "link":
				x22510822ff0a46e.xe014cc494bbbb1d4 = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "autoRedefine":
				style.x913ff5916b187824 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "hidden":
				style.x96e55b5d052d1279 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "uiPriority":
				style.x9eb07da9aa5bbf9e = x3bcd232d01c.xb8ac33c25776194c();
				break;
			case "unhideWhenUsed":
				style.x5356a3af7e7ecdfa = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "qFormat":
				style.xebe0f6c7e6f4ae3a = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "semiHidden":
				style.x45101ac87546632f = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "locked":
				style.x2d8aaa05bddcf40c = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "personal":
				style.xdf3672ec434b4524 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "personalCompose":
				style.xde61abbe9514a1ee = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "personalReply":
				style.x3bbb21ee843f081c = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "rsid":
			{
				int num = xc1b08afa36bf580c.x2a2d5f8dcb4bf0c9(x3bcd232d01c.xbbfc54380705e01e());
				if (num != int.MinValue)
				{
					style.xe12a6bc6d222e782 = num;
				}
				break;
			}
			case "pPr":
				xec45413ffc971f9d.x06b0e25aa6ad68a9(xe134235b3526fa75, style.x1a78664fa10a3755, style.xeedad81aaed42a76);
				break;
			case "rPr":
				x419d718f5b3e63d8.x06b0e25aa6ad68a9(xe134235b3526fa75, style.xeedad81aaed42a76);
				break;
			default:
				x7290c8622d8a6914(xe134235b3526fa75, style);
				break;
			}
		}
		if (!x0d299f323d241756.x5959bccb67bbf051(text2) && x0d299f323d241756.x5959bccb67bbf051(text))
		{
			text2 = text;
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text2))
		{
			x2a19dee8776aaa44.x5d14aa99881b11fb(text2, styles, x5409eeb7bc, style);
			if (!x0d299f323d241756.x5959bccb67bbf051(text))
			{
				text = text2;
			}
			xe134235b3526fa75.x214a3d715a732d1d(text, style.x8301ab10c226b0c2);
		}
		string[] x4bb79322d6f = null;
		if (text3 != null)
		{
			x4bb79322d6f = text3.Split(',');
		}
		if (x0d299f323d241756.x5959bccb67bbf051(style.Name))
		{
			styles.x4880cad9f3196627(style, x4bb79322d6f);
			x92323ab304083408.Add(x22510822ff0a46e);
		}
	}

	private static void x7290c8622d8a6914(x11e1346c12ead315 xe134235b3526fa75, Style x44ecfea61c937b8e)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		if (!(x44ecfea61c937b8e is TableStyle tableStyle))
		{
			x3bcd232d01c.IgnoreElement();
			return;
		}
		switch (x3bcd232d01c.xa66385d80d4d296f)
		{
		case "tblPr":
			xebd82bd99fc8c73d.x0fef18e7f16bf0ca(xe134235b3526fa75, tableStyle.xedb0eb766e25e0c9, x37f701492043cfc5: true);
			break;
		case "trPr":
			xaa9812a6c786e766.x06b0e25aa6ad68a9(xe134235b3526fa75, tableStyle.x511a581657d77f2b);
			break;
		case "tcPr":
			xfad593021ab5340a.x06b0e25aa6ad68a9(xe134235b3526fa75, tableStyle.xf8cef531dae89ea3);
			break;
		case "tblStylePr":
			tableStyle.x7205cb42c2f994a4.Add(xdb3281e85b415b8d(xe134235b3526fa75));
			break;
		default:
			x3bcd232d01c.IgnoreElement();
			break;
		}
	}

	private static xe12ab2f55355c7f0 xdb3281e85b415b8d(x11e1346c12ead315 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		xe12ab2f55355c7f0 xe12ab2f55355c7f = new xe12ab2f55355c7f0();
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "type")
			{
				xe12ab2f55355c7f.x3146d638ec378671 = x72a0c846678ecaf9.xd1c99b969f2441fd(x3bcd232d01c.xd2f68ee6f47e9dfb);
			}
		}
		while (x3bcd232d01c.x152cbadbfa8061b1("tblStylePr"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "pPr":
				xe12ab2f55355c7f.x1a78664fa10a3755 = new x1a78664fa10a3755();
				xec45413ffc971f9d.x06b0e25aa6ad68a9(xe134235b3526fa75, xe12ab2f55355c7f.x1a78664fa10a3755, xe12ab2f55355c7f.xeedad81aaed42a76);
				break;
			case "rPr":
				xe12ab2f55355c7f.xeedad81aaed42a76 = new xeedad81aaed42a76();
				x419d718f5b3e63d8.x06b0e25aa6ad68a9(xe134235b3526fa75, xe12ab2f55355c7f.xeedad81aaed42a76);
				break;
			case "tblPr":
				xe12ab2f55355c7f.xedb0eb766e25e0c9 = new xedb0eb766e25e0c9();
				xebd82bd99fc8c73d.x0fef18e7f16bf0ca(xe134235b3526fa75, xe12ab2f55355c7f.xedb0eb766e25e0c9, x37f701492043cfc5: true);
				break;
			case "trPr":
				xe12ab2f55355c7f.x511a581657d77f2b = new xedb0eb766e25e0c9();
				xaa9812a6c786e766.x06b0e25aa6ad68a9(xe134235b3526fa75, xe12ab2f55355c7f.x511a581657d77f2b);
				break;
			case "tcPr":
				xe12ab2f55355c7f.xf8cef531dae89ea3 = new xf8cef531dae89ea3();
				xfad593021ab5340a.x06b0e25aa6ad68a9(xe134235b3526fa75, xe12ab2f55355c7f.xf8cef531dae89ea3);
				break;
			}
		}
		return xe12ab2f55355c7f;
	}
}
