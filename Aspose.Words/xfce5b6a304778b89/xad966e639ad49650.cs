using Aspose.Words;
using x55b2bd426d41d30c;

namespace xfce5b6a304778b89;

internal class xad966e639ad49650
{
	private xad966e639ad49650()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75)
	{
		xe134235b3526fa75.xb9e32c79bd755ad8 = true;
		x0ca5e8b532953a51 x0ca5e8b532953a = xe134235b3526fa75.x39c7aeeec1af9dd0.x5621ebad67e4df79("/content.xml");
		if (x0ca5e8b532953a == null)
		{
			return;
		}
		x536e1b48249b1390 x536e1b48249b1392 = (xe134235b3526fa75.xca994afbcb9073a2 = new x536e1b48249b1390(x0ca5e8b532953a.xb8a774e0111d0fbe));
		while (x536e1b48249b1392.x152cbadbfa8061b1("document-content"))
		{
			switch (x536e1b48249b1392.xa66385d80d4d296f)
			{
			case "font-face-decls":
				x64964b51e54adaea.x06b0e25aa6ad68a9(xe134235b3526fa75);
				break;
			case "automatic-styles":
				x91603de83f3b5410.x06b0e25aa6ad68a9(xe134235b3526fa75);
				break;
			case "body":
				x2dc551ee28d58aab(xe134235b3526fa75);
				break;
			default:
				x536e1b48249b1392.IgnoreElement();
				break;
			}
		}
	}

	private static void x2dc551ee28d58aab(xf871da68decec406 xe134235b3526fa75)
	{
		xe134235b3526fa75.x49cbb572afb26d4b(x2a7214f600b3f97c: false, x2598783a06246741: true);
		while (xe134235b3526fa75.xca994afbcb9073a2.x152cbadbfa8061b1("body"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xe134235b3526fa75.xca994afbcb9073a2.xa66385d80d4d296f) != null && xa66385d80d4d296f == "text")
			{
				xc3a6fb8513d320a3(xe134235b3526fa75);
			}
			else
			{
				xe134235b3526fa75.xca994afbcb9073a2.IgnoreElement();
			}
		}
	}

	private static void xc3a6fb8513d320a3(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		CompositeNode x8b2c3c076d5a7daf = null;
		while (xca994afbcb9073a.x152cbadbfa8061b1("text"))
		{
			xe134235b3526fa75.xe5ffcf1e3f9bd387 = xe134235b3526fa75.xca994afbcb9073a2.xd68abcd61e368af9("style-name", "Standard");
			x899ab188166aec2d x0f4599bff013bd = x78ad567c64a94dad.x4098110b0f5e24b2(xe134235b3526fa75);
			x8b2c3c076d5a7daf = x78ad567c64a94dad.xe96f630c4a2ed468(xe134235b3526fa75, x0f4599bff013bd, x8b2c3c076d5a7daf);
			if (!x78ad567c64a94dad.x152cbadbfa8061b1(xe134235b3526fa75, x8b2c3c076d5a7daf, x0f4599bff013bd))
			{
				string xa66385d80d4d296f;
				if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "forms")
				{
					x559a7eec404440e2(xe134235b3526fa75);
				}
				else
				{
					xca994afbcb9073a.IgnoreElement();
				}
			}
		}
	}

	private static void x559a7eec404440e2(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("forms"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "form")
			{
				xace67fa74d3d3787(xe134235b3526fa75);
			}
			else
			{
				xca994afbcb9073a.IgnoreElement();
			}
		}
	}

	private static void xace67fa74d3d3787(xf871da68decec406 xe134235b3526fa75)
	{
		x250900dc40a654f4 x250900dc40a654f5 = new x250900dc40a654f4();
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("form"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "checkbox")
			{
				x250900dc40a654f5.x2ee60809805f40f3.Add(x4a31c83c9ec4875a(xe134235b3526fa75));
			}
			else
			{
				xca994afbcb9073a.IgnoreElement();
			}
		}
		xe134235b3526fa75.x1673de9450d42ee5.Add(x250900dc40a654f5);
	}

	private static xdc86c0f058b433d5 x4a31c83c9ec4875a(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		xdc86c0f058b433d5 xdc86c0f058b433d6 = new xdc86c0f058b433d5();
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "id":
				xdc86c0f058b433d6.xea1e81378298fa81 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "current-state":
				xdc86c0f058b433d6.x83dec78bc96b9b92 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			}
		}
		return xdc86c0f058b433d6;
	}
}
