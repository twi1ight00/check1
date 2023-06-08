using System.Drawing;
using x011d489fb9df7027;
using x1495530f35d79681;
using x4c895f6c49b1bff5;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;

namespace xf84318f571847613;

internal class x5a9d21b39400e01a
{
	private x5a9d21b39400e01a()
	{
	}

	internal static x26d9ecb4bdf0456d x07d1b52af8293592(x3c85359e1389ad43 xe134235b3526fa75)
	{
		string xa66385d80d4d296f = xe134235b3526fa75.xa66385d80d4d296f;
		if (xe134235b3526fa75.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			return xd5963bbd428b603e(xe134235b3526fa75);
		}
		return x26d9ecb4bdf0456d.x45260ad4b94166f2;
	}

	internal static x26d9ecb4bdf0456d xd5963bbd428b603e(x3c85359e1389ad43 xe134235b3526fa75)
	{
		switch (xe134235b3526fa75.xa66385d80d4d296f)
		{
		case "prstClr":
			return x3b1cea1a98a9ddd4(xe134235b3526fa75);
		case "schemeClr":
			return x69d699695dfb18d8(xe134235b3526fa75);
		case "srgbClr":
			return x6e7e6d18b23386c0(xe134235b3526fa75);
		default:
			xe134235b3526fa75.IgnoreElement();
			return x26d9ecb4bdf0456d.x45260ad4b94166f2;
		}
	}

	private static x26d9ecb4bdf0456d x3b1cea1a98a9ddd4(x3c85359e1389ad43 xe134235b3526fa75)
	{
		x26d9ecb4bdf0456d x6c50a99faab7d = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xe134235b3526fa75.xa66385d80d4d296f) != null && xa66385d80d4d296f == "val")
			{
				x6c50a99faab7d = x97322ba304f17e30.xbe44ef62bab638f7(xe134235b3526fa75.xd2f68ee6f47e9dfb);
			}
		}
		return x1a61c9707bf49ad2(xe134235b3526fa75, x6c50a99faab7d);
	}

	private static x26d9ecb4bdf0456d x69d699695dfb18d8(x3c85359e1389ad43 xe134235b3526fa75)
	{
		x26d9ecb4bdf0456d x45260ad4b94166f = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xe134235b3526fa75.xa66385d80d4d296f) != null && xa66385d80d4d296f == "val")
			{
				x97322ba304f17e30.xca6f18eaa61ae7f2(xe134235b3526fa75.xd2f68ee6f47e9dfb);
				x45260ad4b94166f = x26d9ecb4bdf0456d.x45260ad4b94166f2;
			}
		}
		return x1a61c9707bf49ad2(xe134235b3526fa75, x45260ad4b94166f);
	}

	private static x26d9ecb4bdf0456d x6e7e6d18b23386c0(x3c85359e1389ad43 xe134235b3526fa75)
	{
		x26d9ecb4bdf0456d x6c50a99faab7d = x26d9ecb4bdf0456d.x45260ad4b94166f2;
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xe134235b3526fa75.xa66385d80d4d296f) != null && xa66385d80d4d296f == "val")
			{
				x6c50a99faab7d = xc1b08afa36bf580c.x5e71f16a78faf353(xe134235b3526fa75.xd2f68ee6f47e9dfb);
			}
		}
		return x1a61c9707bf49ad2(xe134235b3526fa75, x6c50a99faab7d);
	}

	private static x26d9ecb4bdf0456d x1a61c9707bf49ad2(x3c85359e1389ad43 xe134235b3526fa75, x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		xe134235b3526fa75.x99f8cdb2827fa686();
		string xa66385d80d4d296f = xe134235b3526fa75.xa66385d80d4d296f;
		while (xe134235b3526fa75.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "alpha":
			{
				double num = x95d37387163b57db.x1acd48d5a10b1315(xe134235b3526fa75.xf2f856bffb5c6cf3(xe134235b3526fa75.xbbfc54380705e01e()));
				int newAlpha = x15e971129fd80714.x43fcc3f62534530b((double)x6c50a99faab7d741.xda71bf6f7c07c3bc * num);
				x6c50a99faab7d741 = new x26d9ecb4bdf0456d(newAlpha, x6c50a99faab7d741);
				break;
			}
			case "tint":
				x95d37387163b57db.x1acd48d5a10b1315(xe134235b3526fa75.xf2f856bffb5c6cf3(xe134235b3526fa75.xbbfc54380705e01e()));
				break;
			case "satMod":
				x95d37387163b57db.x1acd48d5a10b1315(xe134235b3526fa75.xf2f856bffb5c6cf3(xe134235b3526fa75.xbbfc54380705e01e()));
				break;
			case "shade":
				xe134235b3526fa75.IgnoreElement();
				break;
			default:
				xe134235b3526fa75.IgnoreElement();
				break;
			}
		}
		return x6c50a99faab7d741;
	}

	internal static Point x377eba140365e262(x3c85359e1389ad43 xe134235b3526fa75)
	{
		int x = 0;
		int y = 0;
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "x":
				x = xe134235b3526fa75.xbba6773b8ce56a01;
				break;
			case "y":
				y = xe134235b3526fa75.xbba6773b8ce56a01;
				break;
			}
		}
		return new Point(x, y);
	}

	internal static Size x004439da9053a258(x3c85359e1389ad43 xe134235b3526fa75)
	{
		int width = 0;
		int height = 0;
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "cx":
				width = xe134235b3526fa75.xbba6773b8ce56a01;
				break;
			case "cy":
				height = xe134235b3526fa75.xbba6773b8ce56a01;
				break;
			}
		}
		return new Size(width, height);
	}

	internal static Rectangle xa531ba5a6429d387(x3c85359e1389ad43 xe134235b3526fa75)
	{
		int left = 0;
		int top = 0;
		int right = 0;
		int bottom = 0;
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "l":
				left = xe134235b3526fa75.xf2f856bffb5c6cf3(xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			case "t":
				top = xe134235b3526fa75.xf2f856bffb5c6cf3(xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			case "r":
				right = xe134235b3526fa75.xf2f856bffb5c6cf3(xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			case "b":
				bottom = xe134235b3526fa75.xf2f856bffb5c6cf3(xe134235b3526fa75.xd2f68ee6f47e9dfb);
				break;
			}
		}
		return Rectangle.FromLTRB(left, top, right, bottom);
	}

	internal static void x7e39e44f75f5990b(x3c85359e1389ad43 xe134235b3526fa75, xf7125312c7ee115c xa5e8b8b5991a4e1d)
	{
		while (xe134235b3526fa75.x1ac1960adc8c4c39())
		{
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "noAdjustHandles":
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(126, xe134235b3526fa75.xc3be6b142c6aca84);
				break;
			case "noChangeAspect":
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(120, xe134235b3526fa75.xc3be6b142c6aca84);
				break;
			case "noChangeShapeType":
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(828, xe134235b3526fa75.xc3be6b142c6aca84);
				break;
			case "noCrop":
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(123, xe134235b3526fa75.xc3be6b142c6aca84);
				break;
			case "noEditPoints":
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(124, xe134235b3526fa75.xc3be6b142c6aca84);
				break;
			case "noGrp":
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(127, xe134235b3526fa75.xc3be6b142c6aca84);
				break;
			case "noMove":
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(121, xe134235b3526fa75.xc3be6b142c6aca84);
				break;
			case "noRot":
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(119, xe134235b3526fa75.xc3be6b142c6aca84);
				break;
			case "noSelect":
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(122, xe134235b3526fa75.xc3be6b142c6aca84);
				break;
			}
		}
		xe134235b3526fa75.x99f8cdb2827fa686();
		string xa66385d80d4d296f = xe134235b3526fa75.xa66385d80d4d296f;
		while (xe134235b3526fa75.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			string xa66385d80d4d296f2;
			if ((xa66385d80d4d296f2 = xe134235b3526fa75.xa66385d80d4d296f) == null || !(xa66385d80d4d296f2 == "extLst"))
			{
				xe134235b3526fa75.IgnoreElement();
			}
		}
	}
}
