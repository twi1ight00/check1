using Aspose.Words;
using Aspose.Words.Tables;
using x2cc366c8657e2b6a;
using x79490184cecf12a1;
using x9db5f2e5af3d596e;
using xda075892eccab2ad;

namespace x1495530f35d79681;

internal class xfad593021ab5340a
{
	private xfad593021ab5340a()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75, xf8cef531dae89ea3 x51dd02ffcbaa972d)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		x51dd02ffcbaa972d.xae20093bed1e48a8(3180, true);
		x51dd02ffcbaa972d.xae20093bed1e48a8(3190, false);
		x51dd02ffcbaa972d.xae20093bed1e48a8(3040, CellMerge.None);
		x51dd02ffcbaa972d.xae20093bed1e48a8(3030, CellMerge.None);
		x51dd02ffcbaa972d.xae20093bed1e48a8(3060, CellVerticalAlignment.Top);
		x51dd02ffcbaa972d.xae20093bed1e48a8(3050, TextOrientation.Horizontal);
		x3bcd232d01c.x99f8cdb2827fa686();
		string xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f;
		while (x3bcd232d01c.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "cnfStyle":
				x3bcd232d01c.xcd9275cfaac59c99();
				break;
			case "tcW":
				x51dd02ffcbaa972d.x921a6336ff3c4dd3(x3bcd232d01c.xe210c2db3704ad78());
				break;
			case "gridSpan":
				x51dd02ffcbaa972d.xae20093bed1e48a8(3900, x3bcd232d01c.xb8ac33c25776194c());
				break;
			case "hmerge":
			case "hMerge":
			{
				string text2 = x3bcd232d01c.xbbfc54380705e01e();
				if (text2 == null)
				{
					text2 = "continue";
				}
				x51dd02ffcbaa972d.xae20093bed1e48a8(3040, xd106566a5d9f6f46.x7186e130a3665f42(text2));
				break;
			}
			case "vmerge":
			case "vMerge":
			{
				string text = x3bcd232d01c.xbbfc54380705e01e();
				if (text == null)
				{
					text = "continue";
				}
				x51dd02ffcbaa972d.xae20093bed1e48a8(3030, xd106566a5d9f6f46.x7186e130a3665f42(text));
				break;
			}
			case "tcBorders":
				xe486365cb08165a7(x3bcd232d01c, x51dd02ffcbaa972d);
				break;
			case "shd":
				x51dd02ffcbaa972d.xae20093bed1e48a8(3170, x3bcd232d01c.x8e2bd36fcdee9a28());
				break;
			case "noWrap":
				x51dd02ffcbaa972d.xae20093bed1e48a8(3180, !x3bcd232d01c.xe04906126da94dd1());
				break;
			case "hideMark":
				x51dd02ffcbaa972d.xae20093bed1e48a8(3220, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "tcMar":
				xb0473d4afe16cb4d(x3bcd232d01c, x51dd02ffcbaa972d);
				break;
			case "textFlow":
			case "textDirection":
				x51dd02ffcbaa972d.xae20093bed1e48a8(3050, x72a0c846678ecaf9.xa07e8cf04ba73040(x3bcd232d01c.xbbfc54380705e01e()));
				break;
			case "tcFitText":
				x51dd02ffcbaa972d.xae20093bed1e48a8(3190, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "vAlign":
				x51dd02ffcbaa972d.xae20093bed1e48a8(3060, xd106566a5d9f6f46.x0e2868a293beb06a(x3bcd232d01c.xbbfc54380705e01e()));
				break;
			case "tcPrChange":
				x993aabbdc0e02955.x72c209cf673c0dfb(xe134235b3526fa75, x51dd02ffcbaa972d);
				break;
			case "annotation":
				x9cee4b6d17a3fda9.x72c209cf673c0dfb(x51dd02ffcbaa972d, xe134235b3526fa75);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void xe486365cb08165a7(x3c85359e1389ad43 x97bf2eeabd4abc7b, xf8cef531dae89ea3 x51dd02ffcbaa972d)
	{
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("tcBorders"))
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "top":
				x51dd02ffcbaa972d.xc6dffc0c16c55f7a(3110, x97bf2eeabd4abc7b.x204e881194ee5797());
				break;
			case "left":
			case "start":
				x51dd02ffcbaa972d.xc6dffc0c16c55f7a(3120, x97bf2eeabd4abc7b.x204e881194ee5797());
				break;
			case "bottom":
				x51dd02ffcbaa972d.xc6dffc0c16c55f7a(3130, x97bf2eeabd4abc7b.x204e881194ee5797());
				break;
			case "right":
			case "end":
				x51dd02ffcbaa972d.xc6dffc0c16c55f7a(3140, x97bf2eeabd4abc7b.x204e881194ee5797());
				break;
			case "tl2br":
				x51dd02ffcbaa972d.xc6dffc0c16c55f7a(3150, x97bf2eeabd4abc7b.x204e881194ee5797());
				break;
			case "tr2bl":
				x51dd02ffcbaa972d.xc6dffc0c16c55f7a(3160, x97bf2eeabd4abc7b.x204e881194ee5797());
				break;
			case "insideH":
				x51dd02ffcbaa972d.xc6dffc0c16c55f7a(3200, x97bf2eeabd4abc7b.x204e881194ee5797());
				break;
			case "insideV":
				x51dd02ffcbaa972d.xc6dffc0c16c55f7a(3210, x97bf2eeabd4abc7b.x204e881194ee5797());
				break;
			default:
				x97bf2eeabd4abc7b.IgnoreElement();
				break;
			}
		}
	}

	private static void xb0473d4afe16cb4d(x3c85359e1389ad43 x97bf2eeabd4abc7b, xf8cef531dae89ea3 x51dd02ffcbaa972d)
	{
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("tcMar"))
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "top":
				x51dd02ffcbaa972d.xae20093bed1e48a8(3070, x97bf2eeabd4abc7b.xcd17950d1ac4bef2());
				break;
			case "left":
			case "start":
				x51dd02ffcbaa972d.xae20093bed1e48a8(3090, x97bf2eeabd4abc7b.xcd17950d1ac4bef2());
				break;
			case "bottom":
				x51dd02ffcbaa972d.xae20093bed1e48a8(3080, x97bf2eeabd4abc7b.xcd17950d1ac4bef2());
				break;
			case "right":
			case "end":
				x51dd02ffcbaa972d.xae20093bed1e48a8(3100, x97bf2eeabd4abc7b.xcd17950d1ac4bef2());
				break;
			default:
				x97bf2eeabd4abc7b.IgnoreElement();
				break;
			}
		}
	}
}
