using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using x1495530f35d79681;
using x4c895f6c49b1bff5;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using x996431aaaaf00543;

namespace xf84318f571847613;

internal class x88cc21ed387e51b7
{
	private readonly x1709225c4bd1ed83 x21328b445a743482;

	private readonly x3c85359e1389ad43 xc3723d392789e04d;

	private Shape x317be79405176667;

	internal x88cc21ed387e51b7(x1709225c4bd1ed83 dataProvider, x3c85359e1389ad43 reader)
	{
		x21328b445a743482 = dataProvider;
		xc3723d392789e04d = reader;
	}

	internal void x14a565c15004b08c(Shape x5770cdefd8931aa9)
	{
		x317be79405176667 = x5770cdefd8931aa9;
		while (xc3723d392789e04d.x152cbadbfa8061b1("pic"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "blipFill":
				x48669f9ff482fccd();
				break;
			case "nvPicPr":
				xa07fad70616496c4();
				break;
			case "spPr":
				xe6e2fb0875e027c7();
				break;
			case "AlternateContent":
				x44ea761ba7ed7dbe();
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			case "extLst":
			case "style":
				break;
			}
		}
	}

	private void x44ea761ba7ed7dbe()
	{
		while (xc3723d392789e04d.x152cbadbfa8061b1("AlternateContent"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "Choice":
				xc3723d392789e04d.IgnoreElement();
				break;
			case "Fallback":
				x1f1760fae05e9ab9();
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
	}

	private void x1f1760fae05e9ab9()
	{
		while (xc3723d392789e04d.x152cbadbfa8061b1("Fallback"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f) != null && xa66385d80d4d296f == "blipFill")
			{
				x48669f9ff482fccd();
			}
			else
			{
				xc3723d392789e04d.IgnoreElement();
			}
		}
	}

	private void xa07fad70616496c4()
	{
		while (xc3723d392789e04d.x152cbadbfa8061b1("nvPicPr"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "cNvPicPr":
				xc99a797df8f26c74();
				break;
			case "cNvPr":
				x6f0ba1f2285f4819();
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
	}

	private void xc99a797df8f26c74()
	{
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f) != null && xa66385d80d4d296f == "preferRelativeResize")
			{
				x317be79405176667.x0817d5cde9e19bf6(827, xc3723d392789e04d.xc3be6b142c6aca84);
			}
		}
		while (xc3723d392789e04d.x152cbadbfa8061b1("cNvPicPr"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "picLocks":
				x5a9d21b39400e01a.x7e39e44f75f5990b(xc3723d392789e04d, x317be79405176667.xf7125312c7ee115c);
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			case "extLst":
				break;
			}
		}
	}

	private void x6f0ba1f2285f4819()
	{
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "descr":
				x317be79405176667.x0817d5cde9e19bf6(4103, xc3723d392789e04d.xd2f68ee6f47e9dfb);
				break;
			case "name":
				if (x0d299f323d241756.x5959bccb67bbf051(xc3723d392789e04d.xd2f68ee6f47e9dfb))
				{
					x317be79405176667.x0817d5cde9e19bf6(896, xc3723d392789e04d.xd2f68ee6f47e9dfb);
				}
				break;
			}
		}
		xc3723d392789e04d.x99f8cdb2827fa686();
		string xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f;
		while (xc3723d392789e04d.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "extLst":
			case "hlinkClick":
			case "hlinkHover":
				continue;
			}
			xc3723d392789e04d.IgnoreElement();
		}
	}

	private void x48669f9ff482fccd()
	{
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "rotWithShape":
				x317be79405176667.x0817d5cde9e19bf6(442, xc3723d392789e04d.xc3be6b142c6aca84);
				break;
			}
		}
		while (xc3723d392789e04d.x152cbadbfa8061b1("blipFill"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "blip":
				xaa3605e01d42e852();
				break;
			case "srcRect":
				xb119267b858aca1f();
				break;
			case "stretch":
				x1e743ebff6a845f7();
				break;
			case "tile":
				xc3723d392789e04d.IgnoreElement();
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
	}

	private void xaa3605e01d42e852()
	{
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "embed":
				x317be79405176667.ImageData.x7a0cb9855dd2eab1(x21328b445a743482.x3e0c39f372c8f2f9(xc3723d392789e04d.xd2f68ee6f47e9dfb));
				break;
			case "link":
				x317be79405176667.x0817d5cde9e19bf6(4104, x21328b445a743482.x052a6c2e603b1662(xc3723d392789e04d.xd2f68ee6f47e9dfb));
				break;
			}
		}
		while (xc3723d392789e04d.x152cbadbfa8061b1("blip"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "biLevel":
				xe8ada8459a984d7e();
				break;
			case "clrChange":
				x1133a181911851f4();
				break;
			case "duotone":
				xc4cdb0833a8452a6();
				break;
			case "grayscl":
				x317be79405176667.x0817d5cde9e19bf6(317, true);
				break;
			case "lum":
				x876c8b3ce31d8a07();
				break;
			case "extLst":
				xc3723d392789e04d.IgnoreElement();
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
	}

	private void x1e743ebff6a845f7()
	{
		x317be79405176667.x0817d5cde9e19bf6(446, true);
		while (xc3723d392789e04d.x152cbadbfa8061b1("stretch"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f) != null && xa66385d80d4d296f == "fillRect")
			{
				xc7069d77f9fa758a();
			}
			else
			{
				xc3723d392789e04d.xbd5e5733680bbfc8(WarningType.UnexpectedContent, WarningSource.DrawingML, xc3723d392789e04d.xa66385d80d4d296f);
			}
		}
	}

	private void xc7069d77f9fa758a()
	{
		Rectangle rectangle = x5a9d21b39400e01a.xa531ba5a6429d387(xc3723d392789e04d);
		if (!rectangle.IsEmpty)
		{
			x317be79405176667.x0817d5cde9e19bf6(401, rectangle.Left);
			x317be79405176667.x0817d5cde9e19bf6(402, rectangle.Top);
			x317be79405176667.x0817d5cde9e19bf6(403, rectangle.Right);
			x317be79405176667.x0817d5cde9e19bf6(404, rectangle.Bottom);
		}
	}

	private void xe8ada8459a984d7e()
	{
		x317be79405176667.x0817d5cde9e19bf6(318, true);
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f) != null && xa66385d80d4d296f == "thresh")
			{
				x95d37387163b57db.x1acd48d5a10b1315(xc3723d392789e04d.xf2f856bffb5c6cf3(xc3723d392789e04d.xd2f68ee6f47e9dfb));
			}
		}
	}

	private void x1133a181911851f4()
	{
		bool flag = true;
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f) != null && xa66385d80d4d296f == "useA")
			{
				flag = xc3723d392789e04d.xc3be6b142c6aca84;
			}
		}
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		x26d9ecb4bdf0456d x26d9ecb4bdf0456d2 = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		while (xc3723d392789e04d.x152cbadbfa8061b1("clrChange"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "clrFrom":
				x26d9ecb4bdf0456d = x5a9d21b39400e01a.x07d1b52af8293592(xc3723d392789e04d);
				break;
			case "clrTo":
				x26d9ecb4bdf0456d2 = x5a9d21b39400e01a.x07d1b52af8293592(xc3723d392789e04d);
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
		if (flag && !x26d9ecb4bdf0456d.x7149c962c02931b3 && !x26d9ecb4bdf0456d2.x7149c962c02931b3 && x26d9ecb4bdf0456d.xc613adc4330033f3 == x26d9ecb4bdf0456d2.xc613adc4330033f3 && x26d9ecb4bdf0456d.x26463655896fd90a == x26d9ecb4bdf0456d2.x26463655896fd90a && x26d9ecb4bdf0456d.x8e8f6cc6a0756b05 == x26d9ecb4bdf0456d2.x8e8f6cc6a0756b05 && x26d9ecb4bdf0456d.xda71bf6f7c07c3bc != x26d9ecb4bdf0456d2.xda71bf6f7c07c3bc)
		{
			x317be79405176667.x0817d5cde9e19bf6(263, x26d9ecb4bdf0456d);
		}
	}

	private void x876c8b3ce31d8a07()
	{
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "bright":
				x317be79405176667.x0817d5cde9e19bf6(265, x95d37387163b57db.x75a8fe18c626e4d8(xc3723d392789e04d.xbba6773b8ce56a01));
				break;
			case "contrast":
				x317be79405176667.x0817d5cde9e19bf6(264, x95d37387163b57db.x74889b7236d69e83(xc3723d392789e04d.xbba6773b8ce56a01));
				break;
			}
		}
	}

	private void xc4cdb0833a8452a6()
	{
		_ = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		_ = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		int num = 0;
		while (xc3723d392789e04d.x152cbadbfa8061b1("duotone"))
		{
			x26d9ecb4bdf0456d x26d9ecb4bdf0456d = x5a9d21b39400e01a.xd5963bbd428b603e(xc3723d392789e04d);
			switch (num)
			{
			}
			num++;
		}
	}

	private void xb119267b858aca1f()
	{
		Rectangle rectangle = x5a9d21b39400e01a.xa531ba5a6429d387(xc3723d392789e04d);
		if (!rectangle.IsEmpty)
		{
			x317be79405176667.x0817d5cde9e19bf6(258, x95d37387163b57db.xe763adae8c02dc67(rectangle.Left));
			x317be79405176667.x0817d5cde9e19bf6(256, x95d37387163b57db.xe763adae8c02dc67(rectangle.Top));
			x317be79405176667.x0817d5cde9e19bf6(259, x95d37387163b57db.xe763adae8c02dc67(rectangle.Right));
			x317be79405176667.x0817d5cde9e19bf6(257, x95d37387163b57db.xe763adae8c02dc67(rectangle.Bottom));
		}
	}

	private void xe6e2fb0875e027c7()
	{
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f) != null && xa66385d80d4d296f == "bwMode")
			{
				x317be79405176667.x0817d5cde9e19bf6(772, x97322ba304f17e30.x3730b3866c388d0e(xc3723d392789e04d.xd2f68ee6f47e9dfb));
			}
		}
		while (xc3723d392789e04d.x152cbadbfa8061b1("spPr"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "effectLst":
				xc3723d392789e04d.IgnoreElement();
				break;
			case "ln":
				x8f8baa4940fa5229();
				break;
			case "noFill":
				x317be79405176667.x0817d5cde9e19bf6(443, false);
				break;
			case "prstGeom":
				xc3723d392789e04d.IgnoreElement();
				break;
			case "solidFill":
				x317be79405176667.x0817d5cde9e19bf6(385, x5a9d21b39400e01a.x07d1b52af8293592(xc3723d392789e04d));
				break;
			case "xfrm":
				xf1235f46cb400700();
				break;
			case "scene3d":
				xc3723d392789e04d.IgnoreElement();
				break;
			case "sp3d":
				xc3723d392789e04d.IgnoreElement();
				break;
			case "gradFill":
				xc3723d392789e04d.IgnoreElement();
				break;
			case "extLst":
				xc3723d392789e04d.IgnoreElement();
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
	}

	private void xf1235f46cb400700()
	{
		FlipOrientation flipOrientation = FlipOrientation.None;
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "flipH":
				if (xc3723d392789e04d.xc3be6b142c6aca84)
				{
					flipOrientation |= FlipOrientation.Horizontal;
				}
				break;
			case "flipV":
				if (xc3723d392789e04d.xc3be6b142c6aca84)
				{
					flipOrientation |= FlipOrientation.Vertical;
				}
				break;
			case "rot":
				x317be79405176667.x0817d5cde9e19bf6(4, x16fda7e0158845cb.xc848f787aa9badc5(xc3723d392789e04d.xbba6773b8ce56a01));
				break;
			}
		}
		if (flipOrientation != 0)
		{
			x317be79405176667.x0817d5cde9e19bf6(4096, flipOrientation);
		}
		while (xc3723d392789e04d.x152cbadbfa8061b1("xfrm"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "off":
				x5a9d21b39400e01a.x377eba140365e262(xc3723d392789e04d);
				break;
			case "ext":
			{
				Size size = x5a9d21b39400e01a.x004439da9053a258(xc3723d392789e04d);
				x317be79405176667.xf7125312c7ee115c.xae20093bed1e48a8(260, x4574ea26106f0edb.xa23e6b6c3169521d(size.Width));
				x317be79405176667.xf7125312c7ee115c.xae20093bed1e48a8(261, x4574ea26106f0edb.xa23e6b6c3169521d(size.Height));
				break;
			}
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
	}

	private void x8f8baa4940fa5229()
	{
		x317be79405176667.x0817d5cde9e19bf6(508, true);
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "align":
			case "algn":
				x317be79405176667.x0817d5cde9e19bf6(505, x97322ba304f17e30.x97855c8b214ac09d(xc3723d392789e04d.xd2f68ee6f47e9dfb));
				break;
			case "cap":
				x317be79405176667.x0817d5cde9e19bf6(471, x97322ba304f17e30.xd84ecd8ccdd3431d(xc3723d392789e04d.xd2f68ee6f47e9dfb));
				break;
			case "cmpd":
				x317be79405176667.x0817d5cde9e19bf6(461, x97322ba304f17e30.x3bce5c2dc8ca4fe7(xc3723d392789e04d.xd2f68ee6f47e9dfb));
				break;
			case "w":
				x317be79405176667.x0817d5cde9e19bf6(459, xc3723d392789e04d.xbba6773b8ce56a01);
				break;
			}
		}
		while (xc3723d392789e04d.x152cbadbfa8061b1("ln"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "bevel":
				x317be79405176667.x0817d5cde9e19bf6(470, JoinStyle.Bevel);
				break;
			case "headEnd":
				x01f914180b66d179(464, 467, 466);
				break;
			case "miter":
				x0ad23bdb80b17228();
				break;
			case "noFill":
				x317be79405176667.x0817d5cde9e19bf6(508, false);
				break;
			case "prstDash":
				x317be79405176667.x0817d5cde9e19bf6(462, x97322ba304f17e30.xea178040e7924434(xc3723d392789e04d.xbbfc54380705e01e()));
				break;
			case "round":
				x317be79405176667.x0817d5cde9e19bf6(470, JoinStyle.Round);
				break;
			case "solidFill":
				x317be79405176667.x0817d5cde9e19bf6(448, x5a9d21b39400e01a.x07d1b52af8293592(xc3723d392789e04d));
				break;
			case "tailEnd":
				x01f914180b66d179(465, 469, 468);
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
	}

	private void x0ad23bdb80b17228()
	{
		x317be79405176667.x0817d5cde9e19bf6(470, JoinStyle.Miter);
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f) != null && xa66385d80d4d296f == "lim")
			{
				x317be79405176667.x0817d5cde9e19bf6(460, x95d37387163b57db.xe763adae8c02dc67(xc3723d392789e04d.xbba6773b8ce56a01));
			}
		}
	}

	private void x01f914180b66d179(int x929ca4db86bc3421, int x81198cbf451653a6, int xb7daf0b6c21165df)
	{
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "type":
				x317be79405176667.x0817d5cde9e19bf6(x929ca4db86bc3421, x97322ba304f17e30.x6375521e8ad36b01(xc3723d392789e04d.xd2f68ee6f47e9dfb));
				break;
			case "len":
				x317be79405176667.x0817d5cde9e19bf6(x81198cbf451653a6, x97322ba304f17e30.xb9b440a719dbdd84(xc3723d392789e04d.xd2f68ee6f47e9dfb));
				break;
			case "w":
				x317be79405176667.x0817d5cde9e19bf6(xb7daf0b6c21165df, x97322ba304f17e30.x4c3fcc4b05408ef5(xc3723d392789e04d.xd2f68ee6f47e9dfb));
				break;
			}
		}
	}
}
