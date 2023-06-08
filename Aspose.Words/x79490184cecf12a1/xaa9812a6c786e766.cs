using Aspose.Words;
using x1495530f35d79681;
using x28925c9b27b37a46;
using x9db5f2e5af3d596e;
using xda075892eccab2ad;

namespace x79490184cecf12a1;

internal class xaa9812a6c786e766
{
	private xaa9812a6c786e766()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75, xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("trPr"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "cnfStyle":
				x3bcd232d01c.xcd9275cfaac59c99();
				break;
			case "divId":
				x3bcd232d01c.IgnoreElement();
				break;
			case "wBefore":
				xe193ceb565ecaa0a.x90aab2cbd2f48623 = x3bcd232d01c.xcd17950d1ac4bef2();
				break;
			case "wAfter":
				xe193ceb565ecaa0a.xd29e69906712391d = x3bcd232d01c.xcd17950d1ac4bef2();
				break;
			case "gridBefore":
				xe193ceb565ecaa0a.xae20093bed1e48a8(5104, x3bcd232d01c.xb8ac33c25776194c());
				break;
			case "gridAfter":
				x3bcd232d01c.IgnoreElement();
				break;
			case "cantSplit":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4360, !x3bcd232d01c.xe04906126da94dd1());
				break;
			case "trHeight":
				x854cf484bab5ab30(xe193ceb565ecaa0a, x3bcd232d01c);
				break;
			case "tblHeader":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4040, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "tblCellSpacing":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4290, x3bcd232d01c.xcd17950d1ac4bef2());
				break;
			case "jc":
				xe193ceb565ecaa0a.x9ba359ff37a3a63b = xd106566a5d9f6f46.x285a29cfd1b91f80(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "trPrChange":
				x993aabbdc0e02955.x15ead434c7389b7d(xe134235b3526fa75, xe193ceb565ecaa0a);
				break;
			case "del":
				x993aabbdc0e02955.x54a56194235eead3(xe134235b3526fa75, xe193ceb565ecaa0a, x91bb72ac77aa7230.x1f522a512716a2ae);
				break;
			case "ins":
				x993aabbdc0e02955.x54a56194235eead3(xe134235b3526fa75, xe193ceb565ecaa0a, x91bb72ac77aa7230.xf059562f878b500e);
				break;
			case "hidden":
				xe193ceb565ecaa0a.xae20093bed1e48a8(4520, true);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void x854cf484bab5ab30(xedb0eb766e25e0c9 xe193ceb565ecaa0a, x3c85359e1389ad43 x97bf2eeabd4abc7b)
	{
		bool flag = false;
		bool flag2 = false;
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "hRule":
				xe193ceb565ecaa0a.x85e9ab4255d7e70c = xd106566a5d9f6f46.xe39d51b7fd3464b5(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
				flag = true;
				break;
			case "val":
				xe193ceb565ecaa0a.xb0f146032f47c24e = x97bf2eeabd4abc7b.xbba6773b8ce56a01;
				flag2 = true;
				break;
			}
		}
		if (flag2 && !flag)
		{
			xe193ceb565ecaa0a.x85e9ab4255d7e70c = HeightRule.AtLeast;
		}
	}
}
