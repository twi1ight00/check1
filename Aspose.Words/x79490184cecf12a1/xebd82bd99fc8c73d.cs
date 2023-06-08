using x1495530f35d79681;
using x6c95d9cf46ff5f25;
using x909757d9fd2dd6ae;
using x9db5f2e5af3d596e;
using xda075892eccab2ad;

namespace x79490184cecf12a1;

internal class xebd82bd99fc8c73d
{
	private xebd82bd99fc8c73d()
	{
	}

	internal static void x0fef18e7f16bf0ca(xdfce7f4f687956d7 xe134235b3526fa75, xedb0eb766e25e0c9 xe193ceb565ecaa0a, bool x37f701492043cfc5)
	{
		if (!x37f701492043cfc5)
		{
			xe193ceb565ecaa0a.x292ab95da92a6344 = true;
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
				xf091924ebf034e99(x3bcd232d01c, xe193ceb565ecaa0a);
				break;
			case "tblOverlap":
				if (x3bcd232d01c.xbbfc54380705e01e() == "never")
				{
					xe193ceb565ecaa0a.xae20093bed1e48a8(4350, false);
				}
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
				x682606fd575823dc(xe134235b3526fa75, xe193ceb565ecaa0a);
				break;
			}
		}
	}

	private static void xf091924ebf034e99(x3c85359e1389ad43 x97bf2eeabd4abc7b, xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "leftFromText":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4210, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "rightFromText":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4270, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "topFromText":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4220, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "bottomFromText":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4280, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "vertAnchor":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4160, x72a0c846678ecaf9.xb26f8f5e78b630a9(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb, x48f1c6fc66ceb233: true));
				break;
			case "horzAnchor":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4150, x72a0c846678ecaf9.xcf7be470fced425c(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb));
				break;
			case "tblpXSpec":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4180, x72a0c846678ecaf9.x15b3d0aaa5b4546f(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb));
				break;
			case "tblpX":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4170, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "tblpYSpec":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4200, x72a0c846678ecaf9.x130a3ebac2306cbd(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb));
				break;
			case "tblpY":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4190, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			}
		}
		x6dc3c089fb9aba80(xe193ceb565ecaa0a);
	}

	private static void x6dc3c089fb9aba80(xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		xe193ceb565ecaa0a.x8e7c1e12075a84b3();
		if (!xe193ceb565ecaa0a.x1dec24c9f70b5f45())
		{
			x8ce60d83c5c86ca3(xe193ceb565ecaa0a, 4190);
		}
		x8ce60d83c5c86ca3(xe193ceb565ecaa0a, 4170);
	}

	private static void x8ce60d83c5c86ca3(xedb0eb766e25e0c9 xe193ceb565ecaa0a, int xad5ee812e0b28f28)
	{
		if (xe193ceb565ecaa0a.xbc5dc59d0d9b620d(xad5ee812e0b28f28))
		{
			int num = (int)((x09ce2c02826e31a6)xe193ceb565ecaa0a).get_xe6d4b1b411ed94b5(xad5ee812e0b28f28);
			((x09ce2c02826e31a6)xe193ceb565ecaa0a).set_xe6d4b1b411ed94b5(xad5ee812e0b28f28, (object)(--num));
		}
	}

	internal static void x3542c3148699107e(xdfce7f4f687956d7 xe134235b3526fa75, xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("tblPrEx"))
		{
			x682606fd575823dc(xe134235b3526fa75, xe193ceb565ecaa0a);
		}
	}

	private static void x682606fd575823dc(xdfce7f4f687956d7 xe134235b3526fa75, xedb0eb766e25e0c9 xe193ceb565ecaa0a)
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
			xe486365cb08165a7(x3bcd232d01c, xe193ceb565ecaa0a);
			break;
		case "shd":
			xe193ceb565ecaa0a.xae20093bed1e48a8(4330, x3bcd232d01c.x8e2bd36fcdee9a28());
			break;
		case "tblLayout":
			x8cfaa9305db8a6e2(x3bcd232d01c, xe193ceb565ecaa0a);
			break;
		case "tblCellMar":
			xb0473d4afe16cb4d(x3bcd232d01c, xe193ceb565ecaa0a);
			break;
		case "tblLook":
			xe193ceb565ecaa0a.xae20093bed1e48a8(4140, xd701baa8d8c978fa.x6acbbe254d0bb830(x3bcd232d01c));
			break;
		case "tblPrChange":
		case "tblPrExChange":
			x993aabbdc0e02955.x959c98cd5d3017e7(xe134235b3526fa75, xe193ceb565ecaa0a);
			break;
		case "tblDescription":
			xe193ceb565ecaa0a.x3d235fc95c355365 = x3bcd232d01c.xbbfc54380705e01e();
			break;
		case "tblCaption":
			xe193ceb565ecaa0a.xa062a601a9c3c2aa = x3bcd232d01c.xbbfc54380705e01e();
			break;
		default:
			x3bcd232d01c.IgnoreElement();
			break;
		}
	}

	private static void xe486365cb08165a7(x3c85359e1389ad43 x97bf2eeabd4abc7b, xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("tblBorders"))
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "top":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4050, x97bf2eeabd4abc7b.xd5dc54a8d91c4443());
				break;
			case "left":
			case "start":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4060, x97bf2eeabd4abc7b.xd5dc54a8d91c4443());
				break;
			case "bottom":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4070, x97bf2eeabd4abc7b.xd5dc54a8d91c4443());
				break;
			case "right":
			case "end":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4080, x97bf2eeabd4abc7b.xd5dc54a8d91c4443());
				break;
			case "insideH":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4090, x97bf2eeabd4abc7b.xd5dc54a8d91c4443());
				break;
			case "insideV":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4100, x97bf2eeabd4abc7b.xd5dc54a8d91c4443());
				break;
			default:
				x97bf2eeabd4abc7b.IgnoreElement();
				break;
			}
		}
	}

	private static void x8cfaa9305db8a6e2(x3c85359e1389ad43 x97bf2eeabd4abc7b, xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x97bf2eeabd4abc7b.xa66385d80d4d296f) != null && xa66385d80d4d296f == "type")
			{
				xe193ceb565ecaa0a.xae20093bed1e48a8(4240, x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb != "fixed");
			}
		}
	}

	private static void xb0473d4afe16cb4d(x3c85359e1389ad43 x97bf2eeabd4abc7b, xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("tblCellMar"))
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "top":
				xe193ceb565ecaa0a.xdf2361611d684889 = x97bf2eeabd4abc7b.xcd17950d1ac4bef2();
				break;
			case "left":
			case "start":
				xe193ceb565ecaa0a.xcad2e59522947ede = x97bf2eeabd4abc7b.xcd17950d1ac4bef2();
				break;
			case "bottom":
				xe193ceb565ecaa0a.x425c70a737882333 = x97bf2eeabd4abc7b.xcd17950d1ac4bef2();
				break;
			case "right":
			case "end":
				xe193ceb565ecaa0a.x41c99cca24bc80be = x97bf2eeabd4abc7b.xcd17950d1ac4bef2();
				break;
			default:
				x97bf2eeabd4abc7b.IgnoreElement();
				break;
			}
		}
	}
}
