using Aspose.Words;
using x9db5f2e5af3d596e;
using xbe73d5820f7f4ae3;

namespace xfce5b6a304778b89;

internal class xb60a69db39b2be7e
{
	private xb60a69db39b2be7e()
	{
	}

	internal static void x11dc6d08cde44f37(xf871da68decec406 xe134235b3526fa75, xc559a3dd8354bcaa x44ecfea61c937b8e)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			if (!xf871da68decec406.xb0473d4afe16cb4d(xca994afbcb9073a, x44ecfea61c937b8e.xb09bf7248f4ba6cb))
			{
				switch (xca994afbcb9073a.xa66385d80d4d296f)
				{
				case "align":
					x44ecfea61c937b8e.x458cae322037b237 = x0eb9a864413f34de.x8047f9bb4019189b(xca994afbcb9073a.xd2f68ee6f47e9dfb);
					break;
				case "width":
					x44ecfea61c937b8e.xdc1bf80853046136 = xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb);
					break;
				case "writing-mode":
					x44ecfea61c937b8e.x28e5011224ac892b = xca994afbcb9073a.xd2f68ee6f47e9dfb;
					break;
				}
			}
		}
	}

	internal static void xfb4dc46aca01801d(xf871da68decec406 xe134235b3526fa75, xac09988577d41b0c x44ecfea61c937b8e)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		xedb0eb766e25e0c9 xedb0eb766e25e0c = new xedb0eb766e25e0c9();
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "min-row-height":
				xedb0eb766e25e0c.xb0f146032f47c24e = xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				xedb0eb766e25e0c.x85e9ab4255d7e70c = HeightRule.AtLeast;
				break;
			case "row-height":
				xedb0eb766e25e0c.xb0f146032f47c24e = xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				xedb0eb766e25e0c.x85e9ab4255d7e70c = HeightRule.Exactly;
				break;
			case "keep-together":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "always")
				{
					xedb0eb766e25e0c.x422daa4ae9c73301(4360, false);
				}
				break;
			}
		}
		if (xedb0eb766e25e0c.xd44988f225497f3a > 0)
		{
			x44ecfea61c937b8e.xedb0eb766e25e0c9 = xedb0eb766e25e0c;
		}
	}

	internal static void xa78413eb43f85369(xf871da68decec406 xe134235b3526fa75, xb40eb2b6a428e174 x44ecfea61c937b8e)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		xf8cef531dae89ea3 xf8cef531dae89ea = new xf8cef531dae89ea3();
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			if (xf871da68decec406.xb0473d4afe16cb4d(xca994afbcb9073a, x44ecfea61c937b8e.xb09bf7248f4ba6cb) || xf871da68decec406.xb8a5c0590fac08ae(xca994afbcb9073a, x44ecfea61c937b8e.x6e5a54a5c6ac3f42) || xf871da68decec406.xe486365cb08165a7(xca994afbcb9073a, x44ecfea61c937b8e.xb70a9d14469748bf))
			{
				continue;
			}
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "writing-mode":
				if (x0eb9a864413f34de.x81274fb3a0882f18(xca994afbcb9073a.xd2f68ee6f47e9dfb) != 0)
				{
					xf8cef531dae89ea.xad3f776eaf7a915d(3050, x0eb9a864413f34de.x81274fb3a0882f18(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				}
				break;
			case "glyph-orientation-vertical":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "0")
				{
					xf8cef531dae89ea.xad3f776eaf7a915d(3050, TextOrientation.Upward);
				}
				break;
			case "vertical-align":
				xf8cef531dae89ea.xad3f776eaf7a915d(3060, x0eb9a864413f34de.x28cd796d97d12ba6(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "background-color":
				xf8cef531dae89ea.xad3f776eaf7a915d(3170, xbb857c9fc36f5054.x56cdf34322e60e51(xca994afbcb9073a.xd2f68ee6f47e9dfb, (Shading)xf8cef531dae89ea.x34f1b0fbc88f0b8a(3170)));
				break;
			case "wrap-option":
				xf8cef531dae89ea.xae20093bed1e48a8(3180, xca994afbcb9073a.xd2f68ee6f47e9dfb == "wrap");
				break;
			}
		}
		x4189ee18bf070d29(xf8cef531dae89ea, x44ecfea61c937b8e);
		if (xf8cef531dae89ea.xd44988f225497f3a > 0)
		{
			x44ecfea61c937b8e.xf8cef531dae89ea3 = xf8cef531dae89ea;
		}
	}

	private static void x4189ee18bf070d29(xf8cef531dae89ea3 x51dd02ffcbaa972d, xb40eb2b6a428e174 x44ecfea61c937b8e)
	{
		x6a3b9cbff75fd927 xb70a9d14469748bf = x44ecfea61c937b8e.xb70a9d14469748bf;
		x1ba0adbe4f846c39 x6e5a54a5c6ac3f = x44ecfea61c937b8e.x6e5a54a5c6ac3f42;
		if (xb70a9d14469748bf.xa8c2637cc4888928 != null)
		{
			x51dd02ffcbaa972d.xae20093bed1e48a8(3110, x533663bbcdc757a9.x95dfc63190e8c019(xb70a9d14469748bf.xa8c2637cc4888928));
		}
		if (x6e5a54a5c6ac3f.x41c7a253dffab96d != 0.0)
		{
			x51dd02ffcbaa972d.xdf2361611d684889 = xbb857c9fc36f5054.x286c839093f58b61(x6e5a54a5c6ac3f.x41c7a253dffab96d);
		}
		if (xb70a9d14469748bf.x79d902473861f242 != null)
		{
			x51dd02ffcbaa972d.xae20093bed1e48a8(3130, x533663bbcdc757a9.x95dfc63190e8c019(xb70a9d14469748bf.x79d902473861f242));
		}
		if (x6e5a54a5c6ac3f.xf2f0e85a6d5b32fb != 0.0)
		{
			x51dd02ffcbaa972d.x425c70a737882333 = xbb857c9fc36f5054.x286c839093f58b61(x6e5a54a5c6ac3f.xf2f0e85a6d5b32fb);
		}
		if (xb70a9d14469748bf.xaea087ab32102492 != null)
		{
			x51dd02ffcbaa972d.xae20093bed1e48a8(3120, x533663bbcdc757a9.x95dfc63190e8c019(xb70a9d14469748bf.xaea087ab32102492));
		}
		if (x6e5a54a5c6ac3f.x1fce31db7994633f != 0.0)
		{
			x51dd02ffcbaa972d.xcad2e59522947ede = xbb857c9fc36f5054.x286c839093f58b61(x6e5a54a5c6ac3f.x1fce31db7994633f);
		}
		if (xb70a9d14469748bf.xd7a21e27974f626c != null)
		{
			x51dd02ffcbaa972d.xae20093bed1e48a8(3140, x533663bbcdc757a9.x95dfc63190e8c019(xb70a9d14469748bf.xd7a21e27974f626c));
		}
		if (x6e5a54a5c6ac3f.x5035ade17b9c6f87 != 0.0)
		{
			x51dd02ffcbaa972d.x41c99cca24bc80be = xbb857c9fc36f5054.x286c839093f58b61(x6e5a54a5c6ac3f.x5035ade17b9c6f87);
		}
	}

	internal static void x0bf12215bc6d5482(xf871da68decec406 xe134235b3526fa75, x68feb341faa622d7 x44ecfea61c937b8e)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "column-width")
			{
				x44ecfea61c937b8e.x884d3da464d53ce7 = xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb);
			}
		}
	}
}
