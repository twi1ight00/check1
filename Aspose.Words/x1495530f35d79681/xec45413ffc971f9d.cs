using Aspose.Words;
using x28925c9b27b37a46;
using x2cc366c8657e2b6a;
using x79490184cecf12a1;
using xda075892eccab2ad;

namespace x1495530f35d79681;

internal class xec45413ffc971f9d
{
	private xec45413ffc971f9d()
	{
	}

	internal static bool x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75, x1a78664fa10a3755 x062aae8c9613eeaa, xeedad81aaed42a76 x789564759d365819)
	{
		bool result = false;
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("pPr"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "pStyle":
			{
				int num = xe134235b3526fa75.xc9b7340b035562c6(x3bcd232d01c.xbbfc54380705e01e(), 0);
				x062aae8c9613eeaa.xae20093bed1e48a8(1000, num);
				break;
			}
			case "keepNext":
				x062aae8c9613eeaa.xae20093bed1e48a8(1050, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "keepLines":
				x062aae8c9613eeaa.xae20093bed1e48a8(1040, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "pageBreakBefore":
				x062aae8c9613eeaa.xae20093bed1e48a8(1060, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "framePr":
				x0235feb924dcbd5a(x3bcd232d01c, x062aae8c9613eeaa);
				break;
			case "widowControl":
				x062aae8c9613eeaa.xae20093bed1e48a8(1470, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "numPr":
			case "listPr":
				xb55c4c6e333ae897(x3bcd232d01c, x062aae8c9613eeaa);
				break;
			case "suppressLineNumbers":
			case "supressLineNumbers":
				x062aae8c9613eeaa.xae20093bed1e48a8(1130, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "pBdr":
				xe486365cb08165a7(x3bcd232d01c, x062aae8c9613eeaa);
				break;
			case "shd":
				x062aae8c9613eeaa.xae20093bed1e48a8(1460, x3bcd232d01c.x8e2bd36fcdee9a28());
				break;
			case "tabs":
				x286075756f09e824(x3bcd232d01c, x062aae8c9613eeaa);
				break;
			case "suppressAutoHyphens":
				x062aae8c9613eeaa.xae20093bed1e48a8(1410, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "kinsoku":
				x062aae8c9613eeaa.xae20093bed1e48a8(1070, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "wordWrap":
				x062aae8c9613eeaa.xae20093bed1e48a8(1080, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "overflowPunct":
				x062aae8c9613eeaa.xae20093bed1e48a8(1090, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "topLinePunct":
				x062aae8c9613eeaa.xae20093bed1e48a8(1100, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "autoSpaceDE":
				x062aae8c9613eeaa.xae20093bed1e48a8(1240, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "autoSpaceDN":
				x062aae8c9613eeaa.xae20093bed1e48a8(1250, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "bidi":
				x062aae8c9613eeaa.xae20093bed1e48a8(1560, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "adjustRightInd":
				x062aae8c9613eeaa.xae20093bed1e48a8(1270, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "snapToGrid":
				x062aae8c9613eeaa.xae20093bed1e48a8(1260, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "spacing":
				x76f949cb2bf6300b(x3bcd232d01c, x062aae8c9613eeaa);
				break;
			case "ind":
				xea7d7af37c691e96(x3bcd232d01c, x062aae8c9613eeaa);
				break;
			case "contextualSpacing":
				x062aae8c9613eeaa.xae20093bed1e48a8(1022, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "suppressOverlap":
				x062aae8c9613eeaa.xae20093bed1e48a8(1660, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "jc":
				x062aae8c9613eeaa.xae20093bed1e48a8(1020, x92309521ce1fc453.x394c54208191de14(x3bcd232d01c.xbbfc54380705e01e()));
				break;
			case "textDirection":
				x062aae8c9613eeaa.xae20093bed1e48a8(1480, x72a0c846678ecaf9.xa07e8cf04ba73040(x3bcd232d01c.xbbfc54380705e01e()));
				break;
			case "textAlignment":
				x062aae8c9613eeaa.xae20093bed1e48a8(1510, x92309521ce1fc453.xf248423f5577449f(x3bcd232d01c.xbbfc54380705e01e()));
				break;
			case "outlineLvl":
				x062aae8c9613eeaa.xae20093bed1e48a8(1280, (OutlineLevel)x3bcd232d01c.xb8ac33c25776194c());
				break;
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
			case "sectPr":
			{
				Paragraph paragraph = (Paragraph)xe134235b3526fa75.x0547ea8ef1ef19b1;
				xc0f8e03cabf3a123.x06b0e25aa6ad68a9(xe134235b3526fa75, paragraph.ParentSection);
				result = true;
				break;
			}
			case "pPrChange":
				x993aabbdc0e02955.x94612d0143ac9d96(xe134235b3526fa75, x062aae8c9613eeaa, x789564759d365819);
				break;
			case "annotation":
				x9cee4b6d17a3fda9.x94612d0143ac9d96(xe134235b3526fa75, x062aae8c9613eeaa, x789564759d365819);
				break;
			case "mirrorIndents":
				x062aae8c9613eeaa.xae20093bed1e48a8(1145, x3bcd232d01c.xe04906126da94dd1());
				break;
			default:
				if (xe134235b3526fa75.x325f1926b78ae5cd)
				{
					x419d718f5b3e63d8.x152cbadbfa8061b1(xe134235b3526fa75, x789564759d365819);
				}
				else
				{
					xfa42bde210de8802.x152cbadbfa8061b1(xe134235b3526fa75, x789564759d365819);
				}
				break;
			}
		}
		return result;
	}

	internal static void x0235feb924dcbd5a(x3c85359e1389ad43 x97bf2eeabd4abc7b, x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "dropCap":
			case "drop-cap":
				x062aae8c9613eeaa.xae20093bed1e48a8(1440, x92309521ce1fc453.x26dc9f8eb858bc15(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb));
				break;
			case "lines":
				x062aae8c9613eeaa.xae20093bed1e48a8(1450, x97bf2eeabd4abc7b.xbba6773b8ce56a01);
				break;
			case "w":
				x062aae8c9613eeaa.xae20093bed1e48a8(1310, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "h":
				x062aae8c9613eeaa.xae20093bed1e48a8(1420, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "vSpace":
			case "vspace":
				x062aae8c9613eeaa.xae20093bed1e48a8(1490, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "hSpace":
			case "hspace":
				x062aae8c9613eeaa.xae20093bed1e48a8(1500, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "wrap":
				x062aae8c9613eeaa.xae20093bed1e48a8(1340, x92309521ce1fc453.xa76a170faf04ac8c(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb));
				break;
			case "hAnchor":
			case "hanchor":
				x062aae8c9613eeaa.xae20093bed1e48a8(1320, x92309521ce1fc453.xcf7be470fced425c(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb));
				break;
			case "vAnchor":
			case "vanchor":
				x062aae8c9613eeaa.xae20093bed1e48a8(1330, x92309521ce1fc453.xb26f8f5e78b630a9(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb));
				break;
			case "x":
				x062aae8c9613eeaa.xae20093bed1e48a8(1292, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "y":
				x062aae8c9613eeaa.xae20093bed1e48a8(1302, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "xAlign":
			case "x-align":
				x062aae8c9613eeaa.xae20093bed1e48a8(1290, x92309521ce1fc453.x15b3d0aaa5b4546f(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb));
				break;
			case "yAlign":
			case "y-align":
				x062aae8c9613eeaa.xae20093bed1e48a8(1300, x92309521ce1fc453.x130a3ebac2306cbd(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb));
				break;
			case "hRule":
			case "h-rule":
				x062aae8c9613eeaa.xae20093bed1e48a8(1430, x92309521ce1fc453.xe39d51b7fd3464b5(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb));
				break;
			case "anchorLock":
				x062aae8c9613eeaa.xae20093bed1e48a8(1520, x97bf2eeabd4abc7b.xc3be6b142c6aca84);
				break;
			case "anchor-lock":
				x062aae8c9613eeaa.xae20093bed1e48a8(1520, x97bf2eeabd4abc7b.xc3be6b142c6aca84);
				break;
			}
		}
		if (x062aae8c9613eeaa.xbc5dc59d0d9b620d(1420) && !x062aae8c9613eeaa.xbc5dc59d0d9b620d(1430))
		{
			x062aae8c9613eeaa.xae20093bed1e48a8(1430, HeightRule.AtLeast);
		}
	}

	internal static void xea7d7af37c691e96(x3c85359e1389ad43 x97bf2eeabd4abc7b, x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "left":
			case "start":
				x062aae8c9613eeaa.xae20093bed1e48a8(1160, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "right":
			case "end":
				x062aae8c9613eeaa.xae20093bed1e48a8(1150, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "firstLine":
			case "first-line":
				x062aae8c9613eeaa.xae20093bed1e48a8(1170, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "hanging":
				x062aae8c9613eeaa.xae20093bed1e48a8(1170, -x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "leftChars":
			case "left-chars":
			case "startChars":
				x062aae8c9613eeaa.xae20093bed1e48a8(1165, x97bf2eeabd4abc7b.xbba6773b8ce56a01);
				break;
			case "rightChars":
			case "right-chars":
			case "endChars":
				x062aae8c9613eeaa.xae20093bed1e48a8(1155, x97bf2eeabd4abc7b.xbba6773b8ce56a01);
				break;
			case "firstLineChars":
			case "first-line-chars":
				x062aae8c9613eeaa.xae20093bed1e48a8(1175, x97bf2eeabd4abc7b.xbba6773b8ce56a01);
				break;
			case "hangingChars":
			case "hanging-chars":
				x062aae8c9613eeaa.xae20093bed1e48a8(1175, -x97bf2eeabd4abc7b.xbba6773b8ce56a01);
				break;
			}
		}
	}

	internal static void x76f949cb2bf6300b(x3c85359e1389ad43 x97bf2eeabd4abc7b, x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "before":
				xf86dec24f8bcc947(x062aae8c9613eeaa, 1200, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "beforeLines":
			case "before-lines":
				x062aae8c9613eeaa.xae20093bed1e48a8(1205, x97bf2eeabd4abc7b.xbba6773b8ce56a01);
				break;
			case "beforeAutospacing":
			case "before-autospacing":
				x062aae8c9613eeaa.xae20093bed1e48a8(1210, x97bf2eeabd4abc7b.xc3be6b142c6aca84);
				break;
			case "after":
				xf86dec24f8bcc947(x062aae8c9613eeaa, 1220, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "afterLines":
			case "after-lines":
				x062aae8c9613eeaa.xae20093bed1e48a8(1225, x97bf2eeabd4abc7b.xbba6773b8ce56a01);
				break;
			case "afterAutospacing":
			case "after-autospacing":
				x062aae8c9613eeaa.xae20093bed1e48a8(1230, x97bf2eeabd4abc7b.xc3be6b142c6aca84);
				break;
			case "line":
				x062aae8c9613eeaa.x84bbacdc1fc0efd2 = x97bf2eeabd4abc7b.xeeed7b3df57c138f;
				break;
			case "lineRule":
			case "line-rule":
				x062aae8c9613eeaa.x6ecc1a11cfc2c359 = x92309521ce1fc453.x3fd0472225201508(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
				break;
			}
		}
	}

	private static void xf86dec24f8bcc947(x1a78664fa10a3755 x062aae8c9613eeaa, int xba08ce632055a1d9, int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 >= 0)
		{
			x062aae8c9613eeaa.xae20093bed1e48a8(xba08ce632055a1d9, xbcea506a33cf9111);
		}
	}

	internal static void x286075756f09e824(x3c85359e1389ad43 x97bf2eeabd4abc7b, x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		TabStopCollection tabStopCollection = new TabStopCollection();
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("tabs"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x97bf2eeabd4abc7b.xa66385d80d4d296f) == null || !(xa66385d80d4d296f == "tab"))
			{
				continue;
			}
			TabAlignment alignment = TabAlignment.Clear;
			TabLeader leader = TabLeader.None;
			int positionTwips = 0;
			while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
			{
				switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
				{
				case "val":
					alignment = x92309521ce1fc453.x34ab042462331e81(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
					break;
				case "leader":
					leader = x92309521ce1fc453.xa1511adbdafd3114(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
					break;
				case "pos":
					positionTwips = x97bf2eeabd4abc7b.xeeed7b3df57c138f;
					break;
				}
			}
			tabStopCollection.Add(new TabStop(positionTwips, alignment, leader));
		}
		if (tabStopCollection.Count > 0)
		{
			x062aae8c9613eeaa.xae20093bed1e48a8(1140, tabStopCollection);
		}
	}

	internal static void xe486365cb08165a7(x3c85359e1389ad43 x97bf2eeabd4abc7b, x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("pBdr"))
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "top":
				x062aae8c9613eeaa.xae20093bed1e48a8(1350, x97bf2eeabd4abc7b.xd5dc54a8d91c4443());
				break;
			case "left":
				x062aae8c9613eeaa.xae20093bed1e48a8(1360, x97bf2eeabd4abc7b.xd5dc54a8d91c4443());
				break;
			case "bottom":
				x062aae8c9613eeaa.xae20093bed1e48a8(1370, x97bf2eeabd4abc7b.xd5dc54a8d91c4443());
				break;
			case "right":
				x062aae8c9613eeaa.xae20093bed1e48a8(1380, x97bf2eeabd4abc7b.xd5dc54a8d91c4443());
				break;
			case "between":
				x062aae8c9613eeaa.xae20093bed1e48a8(1390, x97bf2eeabd4abc7b.xd5dc54a8d91c4443());
				break;
			case "bar":
				x062aae8c9613eeaa.xae20093bed1e48a8(1400, x97bf2eeabd4abc7b.xd5dc54a8d91c4443());
				break;
			}
		}
	}

	internal static void xb55c4c6e333ae897(x3c85359e1389ad43 x97bf2eeabd4abc7b, x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		string xa66385d80d4d296f = x97bf2eeabd4abc7b.xa66385d80d4d296f;
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "ilvl":
				x062aae8c9613eeaa.xae20093bed1e48a8(1110, x97bf2eeabd4abc7b.xb8ac33c25776194c());
				break;
			case "numId":
			case "ilfo":
				x062aae8c9613eeaa.xae20093bed1e48a8(1120, x97bf2eeabd4abc7b.xb8ac33c25776194c());
				break;
			case "ins":
				x993aabbdc0e02955.xf796d0eb82a17b5a(x97bf2eeabd4abc7b, x062aae8c9613eeaa);
				break;
			case "numberingChange":
				x993aabbdc0e02955.x8d8ac158f7c4f96a(x97bf2eeabd4abc7b, x062aae8c9613eeaa);
				break;
			case "annotation":
				x9cee4b6d17a3fda9.x51c46e5e6e76d587(x062aae8c9613eeaa, x97bf2eeabd4abc7b);
				break;
			case "t":
				x97bf2eeabd4abc7b.xbd5e5733680bbfc8(WarningType.MinorFormattingLossCategory, WarningSource.WordML, "Import of 't' element within 'listPr' is not supported in WordML format by Aspose.Words.");
				break;
			case "font":
				x97bf2eeabd4abc7b.xbd5e5733680bbfc8(WarningType.MinorFormattingLossCategory, WarningSource.WordML, "Import of 'font' element within 'listPr' is not supported in WordML format by Aspose.Words.");
				break;
			default:
				x97bf2eeabd4abc7b.IgnoreElement();
				break;
			}
		}
	}
}
