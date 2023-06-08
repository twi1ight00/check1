using System.Collections;
using Aspose.Words;
using x0a300997a0b66409;
using x1495530f35d79681;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x9db5f2e5af3d596e;
using xda075892eccab2ad;

namespace x2cc366c8657e2b6a;

internal class x93675d61d5941ea0
{
	private x93675d61d5941ea0()
	{
	}

	internal static void x06b0e25aa6ad68a9(x21a61af92fc2a45e xe134235b3526fa75)
	{
		xc25c28c64aadfd1b xc25c28c64aadfd1b = new xc25c28c64aadfd1b();
		Hashtable xab86e890c57aa6f = new Hashtable();
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("styles"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "latentStyles":
				x7b6e399a5fa35ca1(xe134235b3526fa75);
				break;
			case "style":
				x637d7e009920d5a9(xe134235b3526fa75, xc25c28c64aadfd1b, xab86e890c57aa6f);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			case "versionOfBuiltInStylenames":
				break;
			}
		}
		xc25c28c64aadfd1b.x5f3c0783a74b5d80(xe134235b3526fa75);
	}

	private static void x7b6e399a5fa35ca1(x21a61af92fc2a45e xe134235b3526fa75)
	{
		x90347bcd8deede01 x90347bcd8deede = xe134235b3526fa75.x2c8c6741422a1298.Styles.x90347bcd8deede01;
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "defLockedState":
				x90347bcd8deede.x799a64ee3b4ce806 = x3bcd232d01c.xc3be6b142c6aca84;
				break;
			case "latentStyleCount":
				x90347bcd8deede.x6c7ca9aba118e7af = x3bcd232d01c.xbba6773b8ce56a01;
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

	private static void x6fdeeab1197729bf(x21a61af92fc2a45e xe134235b3526fa75)
	{
		x90347bcd8deede01 x90347bcd8deede = xe134235b3526fa75.x2c8c6741422a1298.Styles.x90347bcd8deede01;
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		bool locked = x90347bcd8deede.x799a64ee3b4ce806;
		string xbcea506a33cf = "";
		bool x0c40b3ed8738297c = x90347bcd8deede.x0c40b3ed8738297c;
		bool xe27cb3f1d698353d = x90347bcd8deede.xe27cb3f1d698353d;
		int x4d0e04ab61f50baa = x90347bcd8deede.x4d0e04ab61f50baa;
		bool xa657c8b674ff2f = x90347bcd8deede.xa657c8b674ff2f76;
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
			}
		}
		StyleIdentifier styleIdentifier = x72a0c846678ecaf9.x3b3cea4656a2e16d(xbcea506a33cf);
		if (styleIdentifier != StyleIdentifier.User)
		{
			x90347bcd8deede.x31805fef2aff8b5f.xd6b6ed77479ef68c(new x565726a756595ed4(styleIdentifier, locked, x0c40b3ed8738297c, xe27cb3f1d698353d, x4d0e04ab61f50baa, xa657c8b674ff2f));
		}
	}

	private static void x637d7e009920d5a9(x21a61af92fc2a45e xe134235b3526fa75, ArrayList x92323ab304083408, Hashtable xab86e890c57aa6f7)
	{
		StyleCollection styles = xe134235b3526fa75.x2c8c6741422a1298.Styles;
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		StyleType x4320c3ef9926c38d = StyleType.Paragraph;
		string text = null;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "type":
				x4320c3ef9926c38d = x0beb84bbfae8adcf.xe81f47353a038d1b(x3bcd232d01c.xd2f68ee6f47e9dfb);
				break;
			case "styleId":
				text = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			}
		}
		Style style = Style.xebcf83b00134300b(x4320c3ef9926c38d);
		x22510822ff0a46e1 x22510822ff0a46e = new x22510822ff0a46e1(style);
		string text2 = null;
		while (x3bcd232d01c.x152cbadbfa8061b1("style"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "name":
			{
				string text3 = x3bcd232d01c.xbbfc54380705e01e();
				if (x0d299f323d241756.x5959bccb67bbf051(text3))
				{
					x2a19dee8776aaa44.x5d14aa99881b11fb(text3, styles, x5409eeb7bc334110: false, style);
					if (!x0d299f323d241756.x5959bccb67bbf051(text))
					{
						text = text3;
					}
					xe134235b3526fa75.x214a3d715a732d1d(text, style.x8301ab10c226b0c2);
				}
				break;
			}
			case "aliases":
				text2 = x3bcd232d01c.xbbfc54380705e01e();
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
				xfa42bde210de8802.x06b0e25aa6ad68a9(xe134235b3526fa75, style.xeedad81aaed42a76);
				break;
			case "uiName":
			{
				string xbcea506a33cf = x3bcd232d01c.xbbfc54380705e01e();
				if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
				{
					style.x2b8399f052630a13(xbcea506a33cf);
				}
				break;
			}
			default:
				x7290c8622d8a6914(xe134235b3526fa75, style);
				break;
			}
		}
		string[] x4bb79322d6f = null;
		if (text2 != null)
		{
			x4bb79322d6f = text2.Split(',');
		}
		if (x0d299f323d241756.x5959bccb67bbf051(style.Name))
		{
			styles.x4880cad9f3196627(style, x4bb79322d6f);
			x92323ab304083408.Add(x22510822ff0a46e);
		}
	}

	private static void x7290c8622d8a6914(x21a61af92fc2a45e xe134235b3526fa75, Style x44ecfea61c937b8e)
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
			xf24b05793143359f.x0fef18e7f16bf0ca(tableStyle.xedb0eb766e25e0c9, xe134235b3526fa75, x37f701492043cfc5: true);
			break;
		case "trPr":
			xbc80cffc72f0de48.x06b0e25aa6ad68a9(tableStyle.x511a581657d77f2b, xe134235b3526fa75);
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

	private static xe12ab2f55355c7f0 xdb3281e85b415b8d(x21a61af92fc2a45e xe134235b3526fa75)
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
				xfa42bde210de8802.x06b0e25aa6ad68a9(xe134235b3526fa75, xe12ab2f55355c7f.xeedad81aaed42a76);
				break;
			case "tblPr":
				xe12ab2f55355c7f.xedb0eb766e25e0c9 = new xedb0eb766e25e0c9();
				xf24b05793143359f.x0fef18e7f16bf0ca(xe12ab2f55355c7f.xedb0eb766e25e0c9, xe134235b3526fa75, x37f701492043cfc5: true);
				break;
			case "trPr":
				xe12ab2f55355c7f.x511a581657d77f2b = new xedb0eb766e25e0c9();
				xbc80cffc72f0de48.x06b0e25aa6ad68a9(xe12ab2f55355c7f.x511a581657d77f2b, xe134235b3526fa75);
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
