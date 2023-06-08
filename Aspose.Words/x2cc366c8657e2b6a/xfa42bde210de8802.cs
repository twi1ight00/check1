using Aspose.Words;
using Aspose.Words.Tables;
using x1495530f35d79681;
using x2845e7a1a7dc898b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x79490184cecf12a1;
using x909757d9fd2dd6ae;
using xda075892eccab2ad;

namespace x2cc366c8657e2b6a;

internal class xfa42bde210de8802
{
	private xfa42bde210de8802()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("rPr"))
		{
			x152cbadbfa8061b1(xe134235b3526fa75, x789564759d365819);
		}
	}

	internal static void x152cbadbfa8061b1(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		switch (x3bcd232d01c.xa66385d80d4d296f)
		{
		case "rStyle":
		{
			int num = xe134235b3526fa75.xc9b7340b035562c6(x3bcd232d01c.xbbfc54380705e01e(), 10);
			x789564759d365819.xae20093bed1e48a8(50, num);
			break;
		}
		case "rFonts":
			x2506b757d67702ec(x789564759d365819, x3bcd232d01c);
			break;
		case "font":
			if (!x789564759d365819.xbc5dc59d0d9b620d(230))
			{
				x789564759d365819.xae20093bed1e48a8(230, x3bcd232d01c.xbbfc54380705e01e());
			}
			break;
		case "b":
			x789564759d365819.xae20093bed1e48a8(60, x3bcd232d01c.x73d42b465084186e());
			break;
		case "b-cs":
			x789564759d365819.xae20093bed1e48a8(250, x3bcd232d01c.x73d42b465084186e());
			break;
		case "i":
			x789564759d365819.xae20093bed1e48a8(70, x3bcd232d01c.x73d42b465084186e());
			break;
		case "i-cs":
			x789564759d365819.xae20093bed1e48a8(260, x3bcd232d01c.x73d42b465084186e());
			break;
		case "caps":
			x789564759d365819.xae20093bed1e48a8(120, x3bcd232d01c.x73d42b465084186e());
			break;
		case "smallCaps":
			x789564759d365819.xae20093bed1e48a8(110, x3bcd232d01c.x73d42b465084186e());
			break;
		case "strike":
			x789564759d365819.xae20093bed1e48a8(80, x3bcd232d01c.x73d42b465084186e());
			break;
		case "dstrike":
			x789564759d365819.xae20093bed1e48a8(300, x3bcd232d01c.x73d42b465084186e());
			break;
		case "outline":
			x789564759d365819.xae20093bed1e48a8(90, x3bcd232d01c.x73d42b465084186e());
			break;
		case "shadow":
			x789564759d365819.xae20093bed1e48a8(100, x3bcd232d01c.x73d42b465084186e());
			break;
		case "emboss":
			x789564759d365819.xae20093bed1e48a8(170, x3bcd232d01c.x73d42b465084186e());
			break;
		case "imprint":
			x789564759d365819.xae20093bed1e48a8(180, x3bcd232d01c.x73d42b465084186e());
			break;
		case "noProof":
			x789564759d365819.xae20093bed1e48a8(440, x3bcd232d01c.x73d42b465084186e());
			break;
		case "vanish":
			x789564759d365819.xae20093bed1e48a8(130, x3bcd232d01c.x73d42b465084186e());
			break;
		case "snapToGrid":
			x789564759d365819.xae20093bed1e48a8(330, x3bcd232d01c.x73d42b465084186e());
			break;
		case "webHidden":
			x789564759d365819.xae20093bed1e48a8(132, x3bcd232d01c.x73d42b465084186e());
			break;
		case "color":
		{
			string text = x3bcd232d01c.xbbfc54380705e01e();
			if (text != null)
			{
				x789564759d365819.xae20093bed1e48a8(160, xc1b08afa36bf580c.x5e71f16a78faf353(text));
			}
			break;
		}
		case "spacing":
			x789564759d365819.xae20093bed1e48a8(150, x3bcd232d01c.xb8ac33c25776194c());
			break;
		case "w":
			x789564759d365819.xae20093bed1e48a8(290, x3bcd232d01c.xb8ac33c25776194c());
			break;
		case "kern":
			x789564759d365819.xae20093bed1e48a8(220, x3bcd232d01c.xb8ac33c25776194c());
			break;
		case "position":
			x789564759d365819.xae20093bed1e48a8(200, x3bcd232d01c.xb8ac33c25776194c());
			break;
		case "sz":
			x789564759d365819.xae20093bed1e48a8(190, x3bcd232d01c.xb8ac33c25776194c());
			break;
		case "sz-cs":
			x789564759d365819.xae20093bed1e48a8(350, x3bcd232d01c.xb8ac33c25776194c());
			break;
		case "highlight":
			x789564759d365819.xae20093bed1e48a8(20, xf2a0216b53787578.xf605f8f5dedc8c5e(x3bcd232d01c.xbbfc54380705e01e()));
			break;
		case "u":
			xdbc1ce5508fce5b5(x789564759d365819, x3bcd232d01c);
			break;
		case "effect":
			x789564759d365819.xae20093bed1e48a8(310, xf2a0216b53787578.xea66715906956b46(x3bcd232d01c.xbbfc54380705e01e()));
			break;
		case "bdr":
			x789564759d365819.xae20093bed1e48a8(360, x3bcd232d01c.xd5dc54a8d91c4443());
			break;
		case "shd":
			x789564759d365819.xae20093bed1e48a8(370, x3bcd232d01c.x8e2bd36fcdee9a28());
			break;
		case "fitText":
			x3bcd232d01c.IgnoreElement();
			break;
		case "vertAlign":
			x789564759d365819.xae20093bed1e48a8(210, xf2a0216b53787578.x29d363e0f9b0c0ec(x3bcd232d01c.xbbfc54380705e01e()));
			break;
		case "rtl":
			x789564759d365819.xae20093bed1e48a8(265, x3bcd232d01c.x73d42b465084186e());
			break;
		case "cs":
			x789564759d365819.xae20093bed1e48a8(268, x3bcd232d01c.x73d42b465084186e());
			break;
		case "em":
			x789564759d365819.xae20093bed1e48a8(770, xf2a0216b53787578.x7e8ef68ffbe367c2(x3bcd232d01c.xbbfc54380705e01e()));
			break;
		case "hyphen":
			xddde94bd2b602fa2(x789564759d365819, x3bcd232d01c);
			break;
		case "lang":
			x06979ac400337450(x789564759d365819, x3bcd232d01c);
			break;
		case "asianLayout":
			x99dfa097f123587e(x789564759d365819, x3bcd232d01c);
			break;
		case "specVanish":
			x789564759d365819.xae20093bed1e48a8(10, x3bcd232d01c.x73d42b465084186e());
			break;
		case "sym":
			x3bcd232d01c.xcd9275cfaac59c99();
			break;
		case "annotation":
			x9cee4b6d17a3fda9.x63e15184a6cf147b(x789564759d365819, xe134235b3526fa75);
			break;
		case "gridSpan":
			if (xe134235b3526fa75.x0547ea8ef1ef19b1.GetAncestor(NodeType.Cell) is Cell cell)
			{
				cell.xf8cef531dae89ea3.xae20093bed1e48a8(3900, x3bcd232d01c.xb8ac33c25776194c());
			}
			break;
		default:
			if (!x5bf8f2c5394b6b07(xe134235b3526fa75, x789564759d365819))
			{
				x3bcd232d01c.IgnoreElement();
			}
			break;
		}
	}

	private static bool x5bf8f2c5394b6b07(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x789564759d365819)
	{
		if (xe134235b3526fa75 is x21a61af92fc2a45e x21a61af92fc2a45e2 && x21a61af92fc2a45e2.xff407d097cedd1e6)
		{
			x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "lit":
				x789564759d365819.x44497371634b39ba = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "nor":
				x789564759d365819.x60c60b1f72126a4c = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "scr":
				x789564759d365819.x1380d412169e361b = xc62574be95c1c918.x141ad7bf025159d2(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "sty":
				x789564759d365819.x65251a26aa8f6af1 = xc62574be95c1c918.xab4d594e6fa0441f(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "brk":
				x789564759d365819.x488a5f49abd86bb8 = x769e3b44d6c5a4cb.xc19594ce8c9b5fe1(x3bcd232d01c);
				break;
			case "aln":
				x789564759d365819.xfb525f871dc9c79f = x3bcd232d01c.xe04906126da94dd1();
				break;
			}
			return true;
		}
		return false;
	}

	private static void x99dfa097f123587e(xeedad81aaed42a76 x789564759d365819, x3c85359e1389ad43 xe134235b3526fa75)
	{
		xf80d6ac0b6a56f39 xf80d6ac0b6a56f = new xf80d6ac0b6a56f39();
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "id":
				xf80d6ac0b6a56f.xd9c2f8178451a779 = xe134235b3526fa75.xbba6773b8ce56a01;
				break;
			case "vert":
				xf80d6ac0b6a56f.x61c108cc44ef385a = xe134235b3526fa75.xc3be6b142c6aca84;
				break;
			case "vert-compress":
				xf80d6ac0b6a56f.x8983dff00ce7e17a = xe134235b3526fa75.xc3be6b142c6aca84;
				break;
			case "combine":
				xf80d6ac0b6a56f.xcc75e504ef58a07f = xe134235b3526fa75.xc3be6b142c6aca84;
				break;
			case "combine-brackets":
				xf80d6ac0b6a56f.x69ec038defa753a8 = xf2a0216b53787578.xc41b20051fb66652(xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			}
		}
		x789564759d365819.xf80d6ac0b6a56f39 = xf80d6ac0b6a56f;
	}

	private static void x2506b757d67702ec(xeedad81aaed42a76 x789564759d365819, x3c85359e1389ad43 xe134235b3526fa75)
	{
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "ascii":
				x789564759d365819.xae20093bed1e48a8(230, xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			case "h-ansi":
				x789564759d365819.xae20093bed1e48a8(240, xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			case "fareast":
				x789564759d365819.xae20093bed1e48a8(235, xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			case "cs":
				x789564759d365819.xae20093bed1e48a8(270, xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			case "hint":
				x789564759d365819.xae20093bed1e48a8(400, xf2a0216b53787578.xf2bfcf7101dcb000(xe134235b3526fa75.xd2f68ee6f47e9dfb));
				break;
			}
		}
	}

	private static void xdbc1ce5508fce5b5(xeedad81aaed42a76 x789564759d365819, x3c85359e1389ad43 xe134235b3526fa75)
	{
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "val":
				x789564759d365819.xae20093bed1e48a8(140, xf2a0216b53787578.x0ae1d706c7d8a3e7(xe134235b3526fa75.xd2f68ee6f47e9dfb));
				break;
			case "color":
				x789564759d365819.xae20093bed1e48a8(450, xc1b08afa36bf580c.x5e71f16a78faf353(xe134235b3526fa75.xd2f68ee6f47e9dfb));
				break;
			}
		}
	}

	private static void xddde94bd2b602fa2(xeedad81aaed42a76 x789564759d365819, x3c85359e1389ad43 xe134235b3526fa75)
	{
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "val":
				if (x0d299f323d241756.x5959bccb67bbf051(xe134235b3526fa75.xd2f68ee6f47e9dfb))
				{
					x789564759d365819.xae20093bed1e48a8(470, xe134235b3526fa75.xd2f68ee6f47e9dfb[0]);
				}
				break;
			case "rule":
				x789564759d365819.xae20093bed1e48a8(460, xf2a0216b53787578.x7c6acb2cba42ded5(xe134235b3526fa75.xd2f68ee6f47e9dfb));
				break;
			}
		}
	}

	private static void x06979ac400337450(xeedad81aaed42a76 x789564759d365819, x3c85359e1389ad43 xe134235b3526fa75)
	{
		bool flag = false;
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "val":
				x789564759d365819.xae20093bed1e48a8(380, xf2a0216b53787578.xae88295ea6bfc819(xe134235b3526fa75.xd2f68ee6f47e9dfb, x5fbb1a9c98604ef5: false));
				flag = true;
				break;
			case "fareast":
				x789564759d365819.xae20093bed1e48a8(390, xf2a0216b53787578.xae88295ea6bfc819(xe134235b3526fa75.xd2f68ee6f47e9dfb, x5fbb1a9c98604ef5: false));
				flag = true;
				break;
			case "bidi":
				x789564759d365819.xae20093bed1e48a8(340, xf2a0216b53787578.xae88295ea6bfc819(xe134235b3526fa75.xd2f68ee6f47e9dfb, x5fbb1a9c98604ef5: false));
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			x789564759d365819.xae20093bed1e48a8(380, 0);
		}
	}
}
