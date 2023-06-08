using System;
using System.Collections;
using System.Drawing;
using System.Xml;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x1495530f35d79681;
using x4c895f6c49b1bff5;
using x6c95d9cf46ff5f25;
using x79490184cecf12a1;
using xf9a9481c3f63a419;
using xfc5388ad7dff404f;

namespace xf84318f571847613;

internal class x8f22b0507bb6c621
{
	private x11e1346c12ead315 x7450cc1e48712286;

	private x3c85359e1389ad43 xc3723d392789e04d;

	private xf7125312c7ee115c x017d3b59849466e1;

	private DrawingML x61f18ca85b7c2226;

	private static readonly Hashtable xab23f86f96a9ccc0;

	private static readonly Hashtable x7f8ce182f2b6e7f4;

	internal DrawingML xd41ddc432f1bf535(x11e1346c12ead315 xe134235b3526fa75)
	{
		x7450cc1e48712286 = xe134235b3526fa75;
		xc3723d392789e04d = xe134235b3526fa75.x3bcd232d01c14846;
		x017d3b59849466e1 = new xf7125312c7ee115c();
		x61f18ca85b7c2226 = null;
		while (xc3723d392789e04d.x152cbadbfa8061b1("drawing"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "anchor":
				x8809397b7abf7718(WrapType.None);
				break;
			case "inline":
				x8809397b7abf7718(WrapType.Inline);
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
		if (x61f18ca85b7c2226 != null)
		{
			x61f18ca85b7c2226.xf7125312c7ee115c = x017d3b59849466e1;
		}
		return x61f18ca85b7c2226;
	}

	private void x8809397b7abf7718(WrapType x1b33630b689cfddb)
	{
		x017d3b59849466e1.xae20093bed1e48a8(4097, x1b33630b689cfddb);
		bool x97e9ca64b26f19c = false;
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "allowOverlap":
				x017d3b59849466e1.xae20093bed1e48a8(950, xc3723d392789e04d.xc3be6b142c6aca84);
				break;
			case "behindDoc":
				x017d3b59849466e1.xae20093bed1e48a8(954, xc3723d392789e04d.xc3be6b142c6aca84);
				break;
			case "distB":
				x017d3b59849466e1.xae20093bed1e48a8(903, xc3723d392789e04d.xbba6773b8ce56a01);
				break;
			case "distL":
				x017d3b59849466e1.xae20093bed1e48a8(900, xc3723d392789e04d.xbba6773b8ce56a01);
				break;
			case "distR":
				x017d3b59849466e1.xae20093bed1e48a8(902, xc3723d392789e04d.xbba6773b8ce56a01);
				break;
			case "distT":
				x017d3b59849466e1.xae20093bed1e48a8(901, xc3723d392789e04d.xbba6773b8ce56a01);
				break;
			case "hidden":
				x017d3b59849466e1.xae20093bed1e48a8(958, xc3723d392789e04d.xc3be6b142c6aca84);
				break;
			case "layoutInCell":
				x017d3b59849466e1.xae20093bed1e48a8(944, xc3723d392789e04d.xc3be6b142c6aca84);
				break;
			case "locked":
				x017d3b59849466e1.xae20093bed1e48a8(4099, xc3723d392789e04d.xc3be6b142c6aca84);
				break;
			case "relativeHeight":
				x017d3b59849466e1.xae20093bed1e48a8(4154, xc3723d392789e04d.xbba6773b8ce56a01);
				break;
			case "simplePos":
				x97e9ca64b26f19c = xc3723d392789e04d.xc3be6b142c6aca84;
				break;
			}
		}
		xc3723d392789e04d.x99f8cdb2827fa686();
		string xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f;
		bool flag = false;
		while (true)
		{
			if (flag)
			{
				if (xc3723d392789e04d.x5f5740eafb9c0cef(xa66385d80d4d296f))
				{
					break;
				}
			}
			else if (!xc3723d392789e04d.x152cbadbfa8061b1(xa66385d80d4d296f))
			{
				break;
			}
			flag = x9c4d396732496cb5(x97e9ca64b26f19c);
		}
	}

	private bool x9c4d396732496cb5(bool x97e9ca64b26f19c5)
	{
		bool result = false;
		switch (xc3723d392789e04d.xa66385d80d4d296f)
		{
		case "cNvGraphicFramePr":
			x204cb39220ec262d();
			break;
		case "docPr":
			xd2d944508f3973a5();
			break;
		case "effectExtent":
			x278c60233de677d9();
			break;
		case "extent":
		{
			Size size = x5a9d21b39400e01a.x004439da9053a258(xc3723d392789e04d);
			x017d3b59849466e1.xae20093bed1e48a8(4131, x4574ea26106f0edb.xa23e6b6c3169521d(size.Width));
			x017d3b59849466e1.xae20093bed1e48a8(4132, x4574ea26106f0edb.xa23e6b6c3169521d(size.Height));
			break;
		}
		case "graphic":
			xffe8719b6d87d067();
			result = true;
			break;
		case "positionH":
			x964a7fa4ff162e97();
			break;
		case "positionV":
			x1439b32828703f37();
			break;
		case "simplePos":
			if (x97e9ca64b26f19c5)
			{
				x6da12fc4ab48a21d();
			}
			else
			{
				xc3723d392789e04d.xcd9275cfaac59c99();
			}
			break;
		case "wrapNone":
			x4f20d5e30002fcdf(WrapType.None);
			break;
		case "wrapSquare":
			x4f20d5e30002fcdf(WrapType.Square);
			break;
		case "wrapThrough":
			x4f20d5e30002fcdf(WrapType.Through);
			break;
		case "wrapTight":
			x4f20d5e30002fcdf(WrapType.Tight);
			break;
		case "wrapTopAndBottom":
			x4f20d5e30002fcdf(WrapType.TopBottom);
			break;
		case "sizeRelH":
		case "sizeRelV":
			xc3723d392789e04d.IgnoreElement();
			break;
		case "AlternateContent":
			xc3723d392789e04d.IgnoreElement();
			break;
		default:
			xc3723d392789e04d.IgnoreElement();
			break;
		}
		return result;
	}

	private void x278c60233de677d9()
	{
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "b":
				x017d3b59849466e1.xae20093bed1e48a8(4146, xc3723d392789e04d.xbba6773b8ce56a01);
				break;
			case "l":
				x017d3b59849466e1.xae20093bed1e48a8(4143, xc3723d392789e04d.xbba6773b8ce56a01);
				break;
			case "r":
				x017d3b59849466e1.xae20093bed1e48a8(4145, xc3723d392789e04d.xbba6773b8ce56a01);
				break;
			case "t":
				x017d3b59849466e1.xae20093bed1e48a8(4144, xc3723d392789e04d.xbba6773b8ce56a01);
				break;
			}
		}
	}

	private void xdde45c1b1c74dc97()
	{
		ArrayList arrayList = new ArrayList();
		while (xc3723d392789e04d.x152cbadbfa8061b1("wrapPolygon"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "start":
			case "lineTo":
				arrayList.Add(x5a9d21b39400e01a.x377eba140365e262(xc3723d392789e04d));
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
		Point point = (Point)arrayList[0];
		Point point2 = (Point)arrayList[arrayList.Count - 1];
		if (point.Equals(point2))
		{
			arrayList.RemoveAt(arrayList.Count - 1);
		}
		x08d932077485c285[] array = new x08d932077485c285[arrayList.Count];
		for (int i = 0; i < arrayList.Count; i++)
		{
			array[i] = new x08d932077485c285((Point)arrayList[i]);
		}
		x017d3b59849466e1.xae20093bed1e48a8(899, array);
	}

	private void x204cb39220ec262d()
	{
		while (xc3723d392789e04d.x152cbadbfa8061b1("cNvGraphicFramePr"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "graphicFrameLocks":
				x5a9d21b39400e01a.x7e39e44f75f5990b(xc3723d392789e04d, x017d3b59849466e1);
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
	}

	private void xd2d944508f3973a5()
	{
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "descr":
				x017d3b59849466e1.xae20093bed1e48a8(897, xc3723d392789e04d.xd2f68ee6f47e9dfb);
				break;
			case "hidden":
				x017d3b59849466e1.xae20093bed1e48a8(958, xc3723d392789e04d.xc3be6b142c6aca84);
				break;
			case "id":
				x017d3b59849466e1.xae20093bed1e48a8(4124, xc3723d392789e04d.xbba6773b8ce56a01);
				break;
			case "name":
				x017d3b59849466e1.xae20093bed1e48a8(896, xc3723d392789e04d.xd2f68ee6f47e9dfb);
				break;
			}
		}
		while (xc3723d392789e04d.x152cbadbfa8061b1("docPr"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "hlinkClick":
				x7c6231f54cbc56df();
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
	}

	private void x7c6231f54cbc56df()
	{
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "id":
				x017d3b59849466e1.xae20093bed1e48a8(898, x7450cc1e48712286.x052a6c2e603b1662(xc3723d392789e04d.xd2f68ee6f47e9dfb));
				break;
			case "tgtFrame":
				x017d3b59849466e1.xae20093bed1e48a8(4120, xc3723d392789e04d.xd2f68ee6f47e9dfb);
				break;
			case "tooltip":
				x017d3b59849466e1.xae20093bed1e48a8(909, xc3723d392789e04d.xd2f68ee6f47e9dfb);
				break;
			}
		}
		while (xc3723d392789e04d.x152cbadbfa8061b1("hlinkClick"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f) != null && !(xa66385d80d4d296f == "extLst"))
			{
				_ = xa66385d80d4d296f == "snd";
			}
			xc3723d392789e04d.IgnoreElement();
		}
	}

	private void x964a7fa4ff162e97()
	{
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f) != null && xa66385d80d4d296f == "relativeFrom")
			{
				x017d3b59849466e1.xae20093bed1e48a8(912, x97322ba304f17e30.x68b1942244b2939d(xc3723d392789e04d.xd2f68ee6f47e9dfb));
			}
		}
		while (xc3723d392789e04d.x152cbadbfa8061b1("positionH"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "align":
				x017d3b59849466e1.xae20093bed1e48a8(911, x97322ba304f17e30.xc64e9202d12c3637(xc3723d392789e04d.x2a1ea9d24e62bf84()));
				break;
			case "posOffset":
				x017d3b59849466e1.xae20093bed1e48a8(4129, x4574ea26106f0edb.xa23e6b6c3169521d(xc3723d392789e04d.xab461f3453328cf7()));
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
	}

	private void x1439b32828703f37()
	{
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f) != null && xa66385d80d4d296f == "relativeFrom")
			{
				x017d3b59849466e1.xae20093bed1e48a8(914, x97322ba304f17e30.xec8c6265e60c25d3(xc3723d392789e04d.xd2f68ee6f47e9dfb));
			}
		}
		while (xc3723d392789e04d.x152cbadbfa8061b1("positionV"))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "align":
				x017d3b59849466e1.xae20093bed1e48a8(913, x97322ba304f17e30.x31bc9f905518ed6a(xc3723d392789e04d.x2a1ea9d24e62bf84()));
				break;
			case "posOffset":
				x017d3b59849466e1.xae20093bed1e48a8(4130, x4574ea26106f0edb.xa23e6b6c3169521d(xc3723d392789e04d.xab461f3453328cf7()));
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
	}

	private void x6da12fc4ab48a21d()
	{
		x017d3b59849466e1.xae20093bed1e48a8(912, RelativeHorizontalPosition.Page);
		x017d3b59849466e1.xae20093bed1e48a8(911, HorizontalAlignment.None);
		x017d3b59849466e1.xae20093bed1e48a8(914, RelativeVerticalPosition.Page);
		x017d3b59849466e1.xae20093bed1e48a8(913, VerticalAlignment.None);
		Point point = x5a9d21b39400e01a.x377eba140365e262(xc3723d392789e04d);
		x017d3b59849466e1.xae20093bed1e48a8(4129, x4574ea26106f0edb.xa23e6b6c3169521d(point.X));
		x017d3b59849466e1.xae20093bed1e48a8(4130, x4574ea26106f0edb.xa23e6b6c3169521d(point.Y));
	}

	private void x4f20d5e30002fcdf(WrapType x1b33630b689cfddb)
	{
		x017d3b59849466e1.xae20093bed1e48a8(4097, x1b33630b689cfddb);
		while (xc3723d392789e04d.x1ac1960adc8c4c39())
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "distB":
				x017d3b59849466e1.xae20093bed1e48a8(903, xc3723d392789e04d.xbba6773b8ce56a01);
				break;
			case "distL":
				x017d3b59849466e1.xae20093bed1e48a8(900, xc3723d392789e04d.xbba6773b8ce56a01);
				break;
			case "distR":
				x017d3b59849466e1.xae20093bed1e48a8(902, xc3723d392789e04d.xbba6773b8ce56a01);
				break;
			case "distT":
				x017d3b59849466e1.xae20093bed1e48a8(901, xc3723d392789e04d.xbba6773b8ce56a01);
				break;
			case "wrapText":
				x017d3b59849466e1.xae20093bed1e48a8(4098, x97322ba304f17e30.x082b219865016f91(xc3723d392789e04d.xd2f68ee6f47e9dfb));
				break;
			}
		}
		xc3723d392789e04d.x99f8cdb2827fa686();
		string xa66385d80d4d296f = xc3723d392789e04d.xa66385d80d4d296f;
		while (xc3723d392789e04d.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (xc3723d392789e04d.xa66385d80d4d296f)
			{
			case "effectExtent":
				x278c60233de677d9();
				break;
			case "wrapPolygon":
				xdde45c1b1c74dc97();
				break;
			default:
				xc3723d392789e04d.IgnoreElement();
				break;
			}
		}
	}

	private void xffe8719b6d87d067()
	{
		string x536ee0b561cc97c = xc3723d392789e04d.x7a5890ace27d0288();
		XmlDocument xmlDocument = xd165c26d81eb4a1e.xbbd823d2b4dbb41a(x536ee0b561cc97c, x835fd5ade25a938d: true);
		x40136e0b18d3d4d5 relatedDatas = x4d79c72fc0d767df(xmlDocument);
		x61f18ca85b7c2226 = new DrawingML(x7450cc1e48712286.x2c8c6741422a1298, xmlDocument, relatedDatas);
	}

	private x40136e0b18d3d4d5 x4d79c72fc0d767df(XmlDocument x5510939d5b9dcd91)
	{
		XmlElement blipFill = x52e89e22b9173f4b(x5510939d5b9dcd91);
		x40136e0b18d3d4d5 x40136e0b18d3d4d = new x40136e0b18d3d4d5(blipFill);
		xd394fc68b9964017(x5510939d5b9dcd91, x40136e0b18d3d4d, "//@r:embed");
		xd394fc68b9964017(x5510939d5b9dcd91, x40136e0b18d3d4d, "//@r:blip");
		xb4672d97960e66bf(x5510939d5b9dcd91, x40136e0b18d3d4d, "//@r:link");
		x984a74325be15ae5(x5510939d5b9dcd91, x40136e0b18d3d4d, "//@r:id");
		x184677cd6f074581(x5510939d5b9dcd91, x40136e0b18d3d4d, "//@r:dm");
		x184677cd6f074581(x5510939d5b9dcd91, x40136e0b18d3d4d, "//@r:lo");
		x184677cd6f074581(x5510939d5b9dcd91, x40136e0b18d3d4d, "//@r:qs");
		x184677cd6f074581(x5510939d5b9dcd91, x40136e0b18d3d4d, "//@r:cs");
		x184677cd6f074581(x5510939d5b9dcd91, x40136e0b18d3d4d, "//@relId");
		return x40136e0b18d3d4d;
	}

	internal static XmlElement x52e89e22b9173f4b(XmlDocument x5510939d5b9dcd91)
	{
		IList list = xd165c26d81eb4a1e.x478a82deb55cde7c(x5510939d5b9dcd91.DocumentElement, "a:graphicData/pic:pic/pic:blipFill/a:blip", x7f8ce182f2b6e7f4);
		if (list.Count == 0)
		{
			return null;
		}
		return (XmlElement)list[0];
	}

	private void xd394fc68b9964017(XmlDocument x5510939d5b9dcd91, x40136e0b18d3d4d5 x1dc2f2327607c9b8, string x7e81152f4b5e4c64)
	{
		IList list = xd165c26d81eb4a1e.x478a82deb55cde7c(x5510939d5b9dcd91.DocumentElement, x7e81152f4b5e4c64, xab23f86f96a9ccc0);
		foreach (XmlAttribute item in list)
		{
			if (x0d299f323d241756.x5959bccb67bbf051(item.Value))
			{
				x1dc2f2327607c9b8.Add(new x5645a78cb658cd2d(item, x7450cc1e48712286.x7b29fad09d9101c5(item.Value)));
			}
		}
	}

	private void xb4672d97960e66bf(XmlDocument x5510939d5b9dcd91, x40136e0b18d3d4d5 x1dc2f2327607c9b8, string x7e81152f4b5e4c64)
	{
		IList list = xd165c26d81eb4a1e.x478a82deb55cde7c(x5510939d5b9dcd91.DocumentElement, x7e81152f4b5e4c64, xab23f86f96a9ccc0);
		foreach (XmlAttribute item in list)
		{
			if (x0d299f323d241756.x5959bccb67bbf051(item.Value))
			{
				x1dc2f2327607c9b8.Add(new x5645a78cb658cd2d(item, x7450cc1e48712286.x052a6c2e603b1662(item.Value)));
			}
		}
	}

	private void x984a74325be15ae5(XmlDocument x5510939d5b9dcd91, x40136e0b18d3d4d5 x1dc2f2327607c9b8, string x7e81152f4b5e4c64)
	{
		IList list = xd165c26d81eb4a1e.x478a82deb55cde7c(x5510939d5b9dcd91.DocumentElement, x7e81152f4b5e4c64, xab23f86f96a9ccc0);
		foreach (XmlAttribute item in list)
		{
			if (!x0d299f323d241756.x5959bccb67bbf051(item.Value))
			{
				continue;
			}
			switch (item.OwnerElement.LocalName)
			{
			case "hlinkHover":
			case "hlinkClick":
			case "hlickMouseOver":
			case "hyperlink":
				x1dc2f2327607c9b8.Add(new x5645a78cb658cd2d(item, x7450cc1e48712286.x052a6c2e603b1662(item.Value)));
				break;
			case "chart":
			case "userShapes":
				x1dc2f2327607c9b8.Add(x0ab0d9176cb12ced(item));
				break;
			case "externalData":
				if (!x7450cc1e48712286.x1ee3ea6f8381b669(item.Value))
				{
					x1dc2f2327607c9b8.Add(new x5645a78cb658cd2d(item, x7450cc1e48712286.x7b29fad09d9101c5(item.Value)));
				}
				else
				{
					x1dc2f2327607c9b8.Add(new x5645a78cb658cd2d(item, x7450cc1e48712286.x052a6c2e603b1662(item.Value), external: true));
				}
				break;
			default:
				throw new InvalidOperationException("Unexpected parent of the id attribute.");
			}
		}
	}

	private void x184677cd6f074581(XmlDocument x5510939d5b9dcd91, x40136e0b18d3d4d5 x1dc2f2327607c9b8, string x7e81152f4b5e4c64)
	{
		IList list = xd165c26d81eb4a1e.x478a82deb55cde7c(x5510939d5b9dcd91.DocumentElement, x7e81152f4b5e4c64, xab23f86f96a9ccc0);
		foreach (XmlAttribute item in list)
		{
			if (x0d299f323d241756.x5959bccb67bbf051(item.Value) && x0d299f323d241756.x5959bccb67bbf051(x7450cc1e48712286.x052a6c2e603b1662(item.Value)))
			{
				x1dc2f2327607c9b8.Add(x0ab0d9176cb12ced(item));
			}
		}
	}

	private x5645a78cb658cd2d x0ab0d9176cb12ced(XmlAttribute xad5ee812e0b28f28)
	{
		bool flag = xad5ee812e0b28f28.Name == "relId";
		x9ea8b270a83f04a0 xe134235b3526fa = null;
		if (flag)
		{
			xe134235b3526fa = x7450cc1e48712286.xc8ab4e294c74831b();
		}
		xa2f1c3dcbd86f20a x398b3bd0acd94b = x7450cc1e48712286.x663a863d790eefe8(xad5ee812e0b28f28.Value).x398b3bd0acd94b61;
		x398b3bd0acd94b.xb8a774e0111d0fbe.Position = 0L;
		XmlDocument xmlDocument = xd165c26d81eb4a1e.xbbd823d2b4dbb41a(x398b3bd0acd94b.xb8a774e0111d0fbe, x835fd5ade25a938d: true);
		x40136e0b18d3d4d5 relatedDataCollection = x4d79c72fc0d767df(xmlDocument);
		x7450cc1e48712286.xc8ab4e294c74831b();
		if (flag)
		{
			x7450cc1e48712286.x5f81a20b8dd0c3a7(xe134235b3526fa);
		}
		return new x5645a78cb658cd2d(xad5ee812e0b28f28, xmlDocument, relatedDataCollection);
	}

	static x8f22b0507bb6c621()
	{
		xab23f86f96a9ccc0 = new Hashtable();
		xab23f86f96a9ccc0["r"] = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";
		x7f8ce182f2b6e7f4 = new Hashtable();
		x7f8ce182f2b6e7f4["a"] = "http://schemas.openxmlformats.org/drawingml/2006/main";
		x7f8ce182f2b6e7f4["pic"] = "http://schemas.openxmlformats.org/drawingml/2006/picture";
	}
}
