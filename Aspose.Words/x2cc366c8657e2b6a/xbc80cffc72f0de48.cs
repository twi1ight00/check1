using Aspose.Words;
using x1495530f35d79681;
using x9db5f2e5af3d596e;
using xda075892eccab2ad;

namespace x2cc366c8657e2b6a;

internal class xbc80cffc72f0de48
{
	private xbc80cffc72f0de48()
	{
	}

	internal static void x06b0e25aa6ad68a9(xedb0eb766e25e0c9 xe193ceb565ecaa0a, xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		string xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f;
		while (x3bcd232d01c.x152cbadbfa8061b1(xa66385d80d4d296f))
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
			case "annotation":
				x9cee4b6d17a3fda9.x7e6b47bfc114eada(xe134235b3526fa75, xe193ceb565ecaa0a);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void x854cf484bab5ab30(xedb0eb766e25e0c9 xe193ceb565ecaa0a, x3c85359e1389ad43 xe134235b3526fa75)
	{
		bool flag = false;
		bool flag2 = false;
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "h-rule":
				xe193ceb565ecaa0a.x85e9ab4255d7e70c = xd106566a5d9f6f46.xe39d51b7fd3464b5(xe134235b3526fa75.xd2f68ee6f47e9dfb);
				flag = true;
				break;
			case "val":
				xe193ceb565ecaa0a.xb0f146032f47c24e = xe134235b3526fa75.xbba6773b8ce56a01;
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
