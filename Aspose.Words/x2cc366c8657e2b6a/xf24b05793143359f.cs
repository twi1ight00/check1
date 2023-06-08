using Aspose.Words.Tables;
using x1495530f35d79681;
using x9db5f2e5af3d596e;
using xda075892eccab2ad;

namespace x2cc366c8657e2b6a;

internal class xf24b05793143359f
{
	private xf24b05793143359f()
	{
	}

	internal static void x0fef18e7f16bf0ca(xedb0eb766e25e0c9 xe193ceb565ecaa0a, xdfce7f4f687956d7 xe134235b3526fa75, bool x37f701492043cfc5)
	{
		if (!x37f701492043cfc5)
		{
			xe193ceb565ecaa0a.x292ab95da92a6344 = true;
			xe193ceb565ecaa0a.xae20093bed1e48a8(4140, TableStyleOptions.Default2003);
		}
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		x3bcd232d01c.x99f8cdb2827fa686();
		string xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f;
		while (x3bcd232d01c.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "tblStyle":
			{
				int x8301ab10c226b0c = xe134235b3526fa75.xc9b7340b035562c6(x3bcd232d01c.xbbfc54380705e01e(), 11);
				xe193ceb565ecaa0a.x8301ab10c226b0c2 = x8301ab10c226b0c;
				break;
			}
			case "tblpPr":
				xf091924ebf034e99(xe193ceb565ecaa0a, x3bcd232d01c);
				break;
			case "tblOverlap":
				if (x3bcd232d01c.xbbfc54380705e01e() == "Never")
				{
					xe193ceb565ecaa0a.xae20093bed1e48a8(4350, false);
				}
				break;
			case "tblRtl":
				x3bcd232d01c.IgnoreElement();
				break;
			case "bidiVisual":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4380, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "tblStyleRowBandSize":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4500, x3bcd232d01c.xb8ac33c25776194c());
				break;
			case "tblStyleColBandSize":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4510, x3bcd232d01c.xb8ac33c25776194c());
				break;
			default:
				x682606fd575823dc(xe193ceb565ecaa0a, xe134235b3526fa75);
				break;
			}
		}
	}

	private static void xf091924ebf034e99(xedb0eb766e25e0c9 xe193ceb565ecaa0a, x3c85359e1389ad43 xe134235b3526fa75)
	{
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "leftFromText":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4210, xe134235b3526fa75.xbba6773b8ce56a01);
				break;
			case "rightFromText":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4270, xe134235b3526fa75.xbba6773b8ce56a01);
				break;
			case "topFromText":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4220, xe134235b3526fa75.xbba6773b8ce56a01);
				break;
			case "bottomFromText":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4280, xe134235b3526fa75.xbba6773b8ce56a01);
				break;
			case "vertAnchor":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4160, x72a0c846678ecaf9.xb26f8f5e78b630a9(xe134235b3526fa75.xd2f68ee6f47e9dfb, x48f1c6fc66ceb233: true));
				break;
			case "horzAnchor":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4150, x72a0c846678ecaf9.xcf7be470fced425c(xe134235b3526fa75.xd2f68ee6f47e9dfb));
				break;
			case "tblpXSpec":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4180, x72a0c846678ecaf9.x15b3d0aaa5b4546f(xe134235b3526fa75.xd2f68ee6f47e9dfb));
				break;
			case "tblpX":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4170, xe134235b3526fa75.xbba6773b8ce56a01 - 1);
				break;
			case "tblpYSpec":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4200, x72a0c846678ecaf9.x130a3ebac2306cbd(xe134235b3526fa75.xd2f68ee6f47e9dfb));
				break;
			case "tblpY":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4190, xe134235b3526fa75.xbba6773b8ce56a01 - 1);
				break;
			}
		}
	}

	internal static void x3542c3148699107e(xedb0eb766e25e0c9 xe193ceb565ecaa0a, xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("tblPrEx"))
		{
			x682606fd575823dc(xe193ceb565ecaa0a, xe134235b3526fa75);
		}
	}

	private static void x682606fd575823dc(xedb0eb766e25e0c9 xe193ceb565ecaa0a, xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		switch (x3bcd232d01c.xa66385d80d4d296f)
		{
		case "tblW":
			xe193ceb565ecaa0a.xae20093bed1e48a8(4230, x3bcd232d01c.xe210c2db3704ad78());
			break;
		case "jc":
			xe193ceb565ecaa0a.x9ba359ff37a3a63b = xd106566a5d9f6f46.x285a29cfd1b91f80(x3bcd232d01c.xbbfc54380705e01e());
			break;
		case "tblCellSpacing":
			xe193ceb565ecaa0a.xae20093bed1e48a8(4290, x3bcd232d01c.xcd17950d1ac4bef2());
			break;
		case "tblInd":
			xe193ceb565ecaa0a.xae20093bed1e48a8(4340, x3bcd232d01c.xcd17950d1ac4bef2());
			break;
		case "tblBorders":
			xe486365cb08165a7(xe193ceb565ecaa0a, x3bcd232d01c);
			break;
		case "shd":
			xe193ceb565ecaa0a.xae20093bed1e48a8(4330, x3bcd232d01c.x8e2bd36fcdee9a28());
			break;
		case "tblLayout":
			x8cfaa9305db8a6e2(xe193ceb565ecaa0a, x3bcd232d01c);
			break;
		case "tblCellMar":
			xb0473d4afe16cb4d(xe193ceb565ecaa0a, x3bcd232d01c);
			break;
		case "tblLook":
			xe193ceb565ecaa0a.xae20093bed1e48a8(4140, x4cf3b47199c96529.xb7e770c54c5f7404(xc1b08afa36bf580c.x5c612ff105e66e13(x3bcd232d01c.xbbfc54380705e01e())));
			break;
		case "annotation":
			x9cee4b6d17a3fda9.xa74ef6ee0db04174(xe134235b3526fa75, xe193ceb565ecaa0a);
			break;
		default:
			x3bcd232d01c.IgnoreElement();
			break;
		}
	}

	private static void xe486365cb08165a7(xedb0eb766e25e0c9 xe193ceb565ecaa0a, x3c85359e1389ad43 xe134235b3526fa75)
	{
		while (xe134235b3526fa75.x152cbadbfa8061b1("tblBorders"))
		{
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "top":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4050, xe134235b3526fa75.xd5dc54a8d91c4443());
				break;
			case "left":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4060, xe134235b3526fa75.xd5dc54a8d91c4443());
				break;
			case "bottom":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4070, xe134235b3526fa75.xd5dc54a8d91c4443());
				break;
			case "right":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4080, xe134235b3526fa75.xd5dc54a8d91c4443());
				break;
			case "insideH":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4090, xe134235b3526fa75.xd5dc54a8d91c4443());
				break;
			case "insideV":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4100, xe134235b3526fa75.xd5dc54a8d91c4443());
				break;
			default:
				xe134235b3526fa75.IgnoreElement();
				break;
			}
		}
	}

	private static void x8cfaa9305db8a6e2(xedb0eb766e25e0c9 xe193ceb565ecaa0a, x3c85359e1389ad43 xe134235b3526fa75)
	{
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xe134235b3526fa75.xa66385d80d4d296f) != null && xa66385d80d4d296f == "type")
			{
				xe193ceb565ecaa0a.xae20093bed1e48a8(4240, xe134235b3526fa75.xd2f68ee6f47e9dfb != "Fixed");
			}
		}
	}

	private static void xb0473d4afe16cb4d(xedb0eb766e25e0c9 xe193ceb565ecaa0a, x3c85359e1389ad43 xe134235b3526fa75)
	{
		while (xe134235b3526fa75.x152cbadbfa8061b1("tblCellMar"))
		{
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "top":
				xe193ceb565ecaa0a.xdf2361611d684889 = xe134235b3526fa75.xcd17950d1ac4bef2();
				break;
			case "left":
				xe193ceb565ecaa0a.xcad2e59522947ede = xe134235b3526fa75.xcd17950d1ac4bef2();
				break;
			case "bottom":
				xe193ceb565ecaa0a.x425c70a737882333 = xe134235b3526fa75.xcd17950d1ac4bef2();
				break;
			case "right":
				xe193ceb565ecaa0a.x41c99cca24bc80be = xe134235b3526fa75.xcd17950d1ac4bef2();
				break;
			default:
				xe134235b3526fa75.IgnoreElement();
				break;
			}
		}
	}
}
