using System.Collections;
using x6c95d9cf46ff5f25;
using x8bb6b4f09b5230a5;
using xb649d0eaa181773c;
using xeb326c6285a77ac1;

namespace x95bd05bb616368d3;

internal class x8a5b455e53b31d53 : xaaf059f0543cf507, x838c5cd8f4489ee9
{
	private x76628cd19dfc5c73 x122e6aca0ef08591;

	private x1a5567678eaa8bea x5c623e43fc1478d0;

	public x1a5567678eaa8bea x58ac0c97cb937d80
	{
		get
		{
			if (x5c623e43fc1478d0 == null)
			{
				x5c623e43fc1478d0 = new x58ac0c97cb937d80();
			}
			return x5c623e43fc1478d0;
		}
		set
		{
			x5c623e43fc1478d0 = value;
		}
	}

	public x8a5b455e53b31d53(xe9481907c579c280 serviceLocator)
		: base(serviceLocator)
	{
	}

	public x76628cd19dfc5c73 xda09af88ab899a50(xc1dcd6189d01216e xe134235b3526fa75)
	{
		x4c28ef76f151d171(xe134235b3526fa75);
		x122e6aca0ef08591 = new x76628cd19dfc5c73();
		switch (xe134235b3526fa75.xa66385d80d4d296f)
		{
		case "custGeom":
			x332f80d8a98a801c("custGeom");
			break;
		case "prstGeom":
		{
			string text = xe134235b3526fa75.xd68abcd61e368af9("prst", "");
			x122e6aca0ef08591.xdf4a121570aaed7e = text;
			if (x61c72b22c160fcf6(text))
			{
				x332f80d8a98a801c("prstGeom");
			}
			break;
		}
		default:
			xf4732ad4641eec1a();
			break;
		}
		return x122e6aca0ef08591;
	}

	private bool x61c72b22c160fcf6(string x00f49b798ac56374)
	{
		xc1dcd6189d01216e xc1dcd6189d01216e = x7450cc1e48712286;
		try
		{
			string text = x58ac0c97cb937d80.x0bad4dd26413d7a1(x00f49b798ac56374);
			if (!x0d299f323d241756.x5959bccb67bbf051(text))
			{
				return false;
			}
			if (x00f49b798ac56374 == "rect")
			{
				text = "<rect1" + text.Substring(5, text.Length - 10) + "rect1>";
				x00f49b798ac56374 = "rect1";
			}
			x7450cc1e48712286 = new xc1dcd6189d01216e(text, new Hashtable());
			x332f80d8a98a801c(x00f49b798ac56374);
			return true;
		}
		finally
		{
			x7450cc1e48712286 = xc1dcd6189d01216e;
		}
	}

	private void x332f80d8a98a801c(string xffe521cc76054baf)
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1(xffe521cc76054baf))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "pathLst":
				x28d349ab09ca59c5();
				break;
			case "avLst":
				x6b73b466ee15f38b();
				break;
			case "gdLst":
				xba5f58277532655b();
				break;
			case "ahLst":
			case "cxnLst":
			case "rect":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	private void xba5f58277532655b()
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("gdLst"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "gd")
			{
				x5436091ae6564c13(x0e71ba6e57580425: false);
			}
			else
			{
				xf4732ad4641eec1a();
			}
		}
	}

	private void x5436091ae6564c13(bool x0e71ba6e57580425)
	{
		string text = x7450cc1e48712286.xd68abcd61e368af9("name", "");
		string text2 = x7450cc1e48712286.xd68abcd61e368af9("fmla", "");
		if (!(text2 == "") && !(text == ""))
		{
			if (x0e71ba6e57580425)
			{
				x122e6aca0ef08591.x2639dfbfaf0930ee.xdd6780868524dfa8(text, text2);
			}
			else
			{
				x122e6aca0ef08591.x2639dfbfaf0930ee.x436652f076b7c10c(text, text2);
			}
		}
	}

	private void x6b73b466ee15f38b()
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("avLst"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "gd")
			{
				x5436091ae6564c13(x0e71ba6e57580425: true);
			}
			else
			{
				xf4732ad4641eec1a();
			}
		}
	}

	private void x28d349ab09ca59c5()
	{
		x19d01a238442e94d x19d01a238442e94d2 = new x19d01a238442e94d(base.xca687bd498227c89);
		while (x7450cc1e48712286.x152cbadbfa8061b1("pathLst"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "path")
			{
				xec86d47cfa7ad297 xe125219852864557 = x19d01a238442e94d2.xda09af88ab899a50(x7450cc1e48712286);
				x122e6aca0ef08591.x9f280d9f6d9d4ccb(xe125219852864557);
			}
			else
			{
				xf4732ad4641eec1a();
			}
		}
	}
}
