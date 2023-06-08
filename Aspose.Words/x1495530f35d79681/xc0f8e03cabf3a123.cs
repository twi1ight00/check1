using Aspose.Words;
using x0a300997a0b66409;
using x28925c9b27b37a46;
using x2cc366c8657e2b6a;
using x79490184cecf12a1;
using x909757d9fd2dd6ae;
using xda075892eccab2ad;

namespace x1495530f35d79681;

internal class xc0f8e03cabf3a123
{
	private xc0f8e03cabf3a123()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75, Section xb32f8dd719a105db)
	{
		bool flag = xb32f8dd719a105db.xfc72d4c9b765cad7.xd44988f225497f3a > 0;
		xfc72d4c9b765cad7 xfc72d4c9b765cad = xb32f8dd719a105db.xfc72d4c9b765cad7;
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		if (xe134235b3526fa75.x325f1926b78ae5cd)
		{
			while (x3bcd232d01c.x1ac1960adc8c4c39())
			{
				string xa66385d80d4d296f;
				if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "rsidSect")
				{
					int num = xc1b08afa36bf580c.x2a2d5f8dcb4bf0c9(x3bcd232d01c.xd2f68ee6f47e9dfb);
					if (num != int.MinValue)
					{
						xfc72d4c9b765cad.xae20093bed1e48a8(2250, num);
					}
				}
			}
		}
		while (x3bcd232d01c.x152cbadbfa8061b1("sectPr"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "headerReference":
			case "footerReference":
				if (!flag)
				{
					x594679cbec3cc56e.x06b0e25aa6ad68a9(xe134235b3526fa75);
				}
				break;
			case "hdr":
			case "ftr":
				xab815447a5920dc3(xb32f8dd719a105db, xe134235b3526fa75);
				break;
			case "footnotePr":
			case "endnotePr":
				if (xe134235b3526fa75.x325f1926b78ae5cd)
				{
					xa193b87bb5ca0dde.xdc71cdfc66231158(x3bcd232d01c, x3bcd232d01c.xa66385d80d4d296f, xfc72d4c9b765cad);
				}
				else
				{
					xf12e0633e78c468f.xdc71cdfc66231158(xe134235b3526fa75, x3bcd232d01c.xa66385d80d4d296f, xfc72d4c9b765cad);
				}
				break;
			case "type":
				xfc72d4c9b765cad.xae20093bed1e48a8(2030, x93625b0e8808b0cc.x1e1ba0c92e3db5b5(x3bcd232d01c.xbbfc54380705e01e()));
				break;
			case "pgSz":
				x36d8728b5cd0a324(x3bcd232d01c, xfc72d4c9b765cad);
				break;
			case "pgMar":
				xe4f44ecab793ced3(x3bcd232d01c, xfc72d4c9b765cad);
				break;
			case "paperSrc":
				x9347f8e062b494c7(x3bcd232d01c, xfc72d4c9b765cad);
				break;
			case "pgBorders":
				xe486365cb08165a7(x3bcd232d01c, xfc72d4c9b765cad);
				break;
			case "lnNumType":
				x5f1845bd71573902(x3bcd232d01c, xfc72d4c9b765cad);
				break;
			case "pgNumType":
				xb4bc81d7ba1a851a(xe134235b3526fa75, xfc72d4c9b765cad);
				break;
			case "cols":
				x7b5cc2108992e0a0(x3bcd232d01c, xfc72d4c9b765cad);
				break;
			case "formProt":
				xfc72d4c9b765cad.xae20093bed1e48a8(2390, !x3bcd232d01c.xe04906126da94dd1());
				break;
			case "vAlign":
				xfc72d4c9b765cad.xae20093bed1e48a8(2340, x93625b0e8808b0cc.xa0fb3530f89d4d71(x3bcd232d01c.xbbfc54380705e01e()));
				break;
			case "noEndnote":
				xfc72d4c9b765cad.xae20093bed1e48a8(2100, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "titlePg":
				xfc72d4c9b765cad.xae20093bed1e48a8(2040, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "textDirection":
				xfc72d4c9b765cad.xae20093bed1e48a8(2440, xc62574be95c1c918.x2abb13ef43ef56e7(x3bcd232d01c.xbbfc54380705e01e()));
				break;
			case "textFlow":
				xfc72d4c9b765cad.xae20093bed1e48a8(2440, x0beb84bbfae8adcf.x86e704dfaed62dab(x3bcd232d01c.xbbfc54380705e01e()));
				break;
			case "bidi":
				xfc72d4c9b765cad.xae20093bed1e48a8(2450, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "rtlGutter":
				xfc72d4c9b765cad.xae20093bed1e48a8(2410, x3bcd232d01c.xe04906126da94dd1());
				break;
			case "docGrid":
				xb9529ebe69a7518c(x3bcd232d01c, xfc72d4c9b765cad);
				break;
			case "sectPrChange":
				x993aabbdc0e02955.x23b47cfc315238f5(xe134235b3526fa75, xfc72d4c9b765cad);
				break;
			case "annotation":
				x9cee4b6d17a3fda9.x23b47cfc315238f5(xfc72d4c9b765cad, xe134235b3526fa75);
				break;
			}
		}
	}

	private static void xab815447a5920dc3(Section xb32f8dd719a105db, xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		bool x59c6d00e0898f6b = x3bcd232d01c.xa66385d80d4d296f == "hdr";
		HeaderFooterType headerFooterType = x93625b0e8808b0cc.x188cbe5b54678d25(x3bcd232d01c.xd68abcd61e368af9("type", ""), x59c6d00e0898f6b);
		HeaderFooter headerFooter = new HeaderFooter(xb32f8dd719a105db.Document, headerFooterType);
		xe134235b3526fa75.xf41b717aaedc8265 = true;
		x38ecd42e68717d79.x06b0e25aa6ad68a9(xe134235b3526fa75, headerFooter);
		xe134235b3526fa75.xf41b717aaedc8265 = false;
		if (xb32f8dd719a105db.HeadersFooters[headerFooter.HeaderFooterType] == null)
		{
			xb32f8dd719a105db.InsertBefore(headerFooter, xb32f8dd719a105db.Body);
		}
	}

	private static void x36d8728b5cd0a324(x3c85359e1389ad43 x97bf2eeabd4abc7b, xfc72d4c9b765cad7 x873e775b892867cf)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "w":
				x873e775b892867cf.xae20093bed1e48a8(2260, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "h":
				x873e775b892867cf.xae20093bed1e48a8(2270, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "orient":
				x873e775b892867cf.xae20093bed1e48a8(2210, x93625b0e8808b0cc.x3c8305a64db58186(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb));
				break;
			case "code":
				x873e775b892867cf.xae20093bed1e48a8(2090, x97bf2eeabd4abc7b.xbba6773b8ce56a01);
				break;
			}
		}
	}

	private static void xe4f44ecab793ced3(x3c85359e1389ad43 x97bf2eeabd4abc7b, xfc72d4c9b765cad7 x873e775b892867cf)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "top":
				x873e775b892867cf.xae20093bed1e48a8(2300, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "right":
				x873e775b892867cf.xae20093bed1e48a8(2290, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "bottom":
				x873e775b892867cf.xae20093bed1e48a8(2310, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "left":
				x873e775b892867cf.xae20093bed1e48a8(2280, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "header":
				x873e775b892867cf.xae20093bed1e48a8(2320, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "footer":
				x873e775b892867cf.xae20093bed1e48a8(2330, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "gutter":
				x873e775b892867cf.xae20093bed1e48a8(2312, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			}
		}
	}

	private static void x9347f8e062b494c7(x3c85359e1389ad43 x97bf2eeabd4abc7b, xfc72d4c9b765cad7 x873e775b892867cf)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "first":
				x873e775b892867cf.xae20093bed1e48a8(2070, x97bf2eeabd4abc7b.xbba6773b8ce56a01);
				break;
			case "other":
				x873e775b892867cf.xae20093bed1e48a8(2080, x97bf2eeabd4abc7b.xbba6773b8ce56a01);
				break;
			}
		}
	}

	private static void xe486365cb08165a7(x3c85359e1389ad43 x97bf2eeabd4abc7b, xfc72d4c9b765cad7 x873e775b892867cf)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "zOrder":
			case "z-order":
				switch (x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb)
				{
				case "front":
					x873e775b892867cf.xae20093bed1e48a8(2230, true);
					break;
				case "back":
					x873e775b892867cf.xae20093bed1e48a8(2230, false);
					break;
				}
				break;
			case "display":
				x873e775b892867cf.xae20093bed1e48a8(2220, x93625b0e8808b0cc.xc85890fabe91a528(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb));
				break;
			case "offsetFrom":
			case "offset-from":
				x873e775b892867cf.xae20093bed1e48a8(2240, x93625b0e8808b0cc.xe162baa3fc1b526f(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb));
				break;
			}
		}
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("pgBorders"))
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "top":
				x873e775b892867cf.xae20093bed1e48a8(2130, x97bf2eeabd4abc7b.xd5dc54a8d91c4443());
				break;
			case "left":
				x873e775b892867cf.xae20093bed1e48a8(2140, x97bf2eeabd4abc7b.xd5dc54a8d91c4443());
				break;
			case "bottom":
				x873e775b892867cf.xae20093bed1e48a8(2150, x97bf2eeabd4abc7b.xd5dc54a8d91c4443());
				break;
			case "right":
				x873e775b892867cf.xae20093bed1e48a8(2160, x97bf2eeabd4abc7b.xd5dc54a8d91c4443());
				break;
			}
		}
	}

	private static void x5f1845bd71573902(x3c85359e1389ad43 x97bf2eeabd4abc7b, xfc72d4c9b765cad7 x873e775b892867cf)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "countBy":
			case "count-by":
				x873e775b892867cf.xae20093bed1e48a8(2120, x97bf2eeabd4abc7b.xbba6773b8ce56a01);
				break;
			case "start":
				x873e775b892867cf.xae20093bed1e48a8(2180, x97bf2eeabd4abc7b.xbba6773b8ce56a01 + 1);
				break;
			case "distance":
				x873e775b892867cf.xae20093bed1e48a8(2400, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "restart":
				x873e775b892867cf.xae20093bed1e48a8(2110, x93625b0e8808b0cc.x73d1b9b1a07e8505(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb));
				break;
			}
		}
	}

	private static void xb4bc81d7ba1a851a(xdfce7f4f687956d7 xe134235b3526fa75, xfc72d4c9b765cad7 x873e775b892867cf)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "fmt":
				x873e775b892867cf.x6090553824279e24 = (xe134235b3526fa75.x325f1926b78ae5cd ? xc62574be95c1c918.x5dabea7b873aecb0(x3bcd232d01c.xd2f68ee6f47e9dfb) : x0beb84bbfae8adcf.x8a2d49471f5ae9a4(x3bcd232d01c.xd2f68ee6f47e9dfb));
				break;
			case "start":
				x873e775b892867cf.xea80bd18e8a43904 = x3bcd232d01c.xbba6773b8ce56a01;
				x873e775b892867cf.x464e144455d016ba = true;
				break;
			case "chapStyle":
			case "chap-style":
				x873e775b892867cf.xee524e151121559b = x3bcd232d01c.xbba6773b8ce56a01;
				break;
			case "chapSep":
			case "chap-sep":
				x873e775b892867cf.xbdc85485688e2cf3 = x93625b0e8808b0cc.xefd54afbbe139da4(x3bcd232d01c.xd2f68ee6f47e9dfb);
				break;
			}
		}
	}

	private static void x7b5cc2108992e0a0(x3c85359e1389ad43 x97bf2eeabd4abc7b, xfc72d4c9b765cad7 x873e775b892867cf)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "num":
				x873e775b892867cf.xae20093bed1e48a8(2350, x97bf2eeabd4abc7b.xbba6773b8ce56a01);
				break;
			case "sep":
				x873e775b892867cf.xae20093bed1e48a8(2060, x97bf2eeabd4abc7b.xc3be6b142c6aca84);
				break;
			case "space":
				x873e775b892867cf.xae20093bed1e48a8(2370, x97bf2eeabd4abc7b.xeeed7b3df57c138f);
				break;
			case "equalWidth":
				x873e775b892867cf.xae20093bed1e48a8(2360, x97bf2eeabd4abc7b.xc3be6b142c6aca84);
				break;
			}
		}
		x28980d9c5ec3f471 x28980d9c5ec3f = new x28980d9c5ec3f471();
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("cols"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x97bf2eeabd4abc7b.xa66385d80d4d296f) != null && xa66385d80d4d296f == "col")
			{
				x28980d9c5ec3f.xd6b6ed77479ef68c(x775fae28c3d3b670(x97bf2eeabd4abc7b));
			}
		}
		if (x28980d9c5ec3f.xd44988f225497f3a > 0)
		{
			x873e775b892867cf.xae20093bed1e48a8(2380, x28980d9c5ec3f);
		}
	}

	private static TextColumn x775fae28c3d3b670(x3c85359e1389ad43 x97bf2eeabd4abc7b)
	{
		TextColumn textColumn = new TextColumn();
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "w":
				textColumn.x7219de950d4b708a = x97bf2eeabd4abc7b.xeeed7b3df57c138f;
				break;
			case "space":
				textColumn.xbe8b68828bd16a4b = x97bf2eeabd4abc7b.xeeed7b3df57c138f;
				break;
			}
		}
		return textColumn;
	}

	private static void xb9529ebe69a7518c(x3c85359e1389ad43 x97bf2eeabd4abc7b, xfc72d4c9b765cad7 x873e775b892867cf)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "type":
			{
				x704ea28be0f90278 x704ea28be0f = x93625b0e8808b0cc.xbe53f95e31b85211(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
				x873e775b892867cf.xae20093bed1e48a8(2430, (int)x704ea28be0f);
				break;
			}
			case "linePitch":
			case "line-pitch":
				x873e775b892867cf.xae20093bed1e48a8(2170, x97bf2eeabd4abc7b.xbba6773b8ce56a01);
				break;
			case "charSpace":
			case "char-space":
				x873e775b892867cf.xae20093bed1e48a8(2420, x97bf2eeabd4abc7b.xbba6773b8ce56a01);
				break;
			}
		}
	}
}
