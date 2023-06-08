using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;

namespace xfce5b6a304778b89;

internal class xd55b70bad23cdcb2
{
	private xd55b70bad23cdcb2()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, x1ba13e535f55aa54 x44ecfea61c937b8e)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		xf7125312c7ee115c xf7125312c7ee115c = new xf7125312c7ee115c();
		if (x0d299f323d241756.x5959bccb67bbf051(x44ecfea61c937b8e.x6901ea11a338ff2b))
		{
			x95973895507fea32 x95973895507fea = xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(x44ecfea61c937b8e.x6901ea11a338ff2b, "graphic");
			if (x95973895507fea is x1ba13e535f55aa54)
			{
				x1ba13e535f55aa54 x1ba13e535f55aa55 = (x1ba13e535f55aa54)x95973895507fea;
				if (x1ba13e535f55aa55.xf7125312c7ee115c != null)
				{
					xf7125312c7ee115c = (xf7125312c7ee115c)x1ba13e535f55aa55.xf7125312c7ee115c.x8b61531c8ea35b85();
				}
			}
		}
		string text = null;
		string xbd5a2e7a4ff749c = null;
		string x8f9f54b64019439b = "";
		string x8f9f54b64019439b2 = "";
		string xbd5a2e7a4ff749c2 = null;
		string xd925f447ef7e00a = null;
		VerticalAlignment verticalAlignment = VerticalAlignment.None;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			if (xf871da68decec406.xe486365cb08165a7(xca994afbcb9073a, x44ecfea61c937b8e.xb70a9d14469748bf) || xf871da68decec406.xb0473d4afe16cb4d(xca994afbcb9073a, x44ecfea61c937b8e.xb09bf7248f4ba6cb) || xf871da68decec406.xb8a5c0590fac08ae(xca994afbcb9073a, x44ecfea61c937b8e.x6e5a54a5c6ac3f42))
			{
				continue;
			}
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "auto-grow-height":
			case "auto-grow-width":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "true")
				{
					xf7125312c7ee115c.xae20093bed1e48a8(190, true);
				}
				else
				{
					xf7125312c7ee115c.xae20093bed1e48a8(190, false);
				}
				break;
			case "clip":
			{
				string[] array = xca994afbcb9073a.xd2f68ee6f47e9dfb.Replace("rect", "").Replace("(", "").Replace(")", "")
					.Replace(",", " ")
					.Replace("  ", " ")
					.Trim(' ')
					.Split(' ');
				x44ecfea61c937b8e.xda8d5e2df97ef739 = xbb857c9fc36f5054.xc42baa2576960ea5(array[0]);
				x44ecfea61c937b8e.x911fb1cc904ad8ee = xbb857c9fc36f5054.xc42baa2576960ea5(array[1]);
				x44ecfea61c937b8e.xd7776f52196e7855 = xbb857c9fc36f5054.xc42baa2576960ea5(array[2]);
				x44ecfea61c937b8e.x332a4841aef33498 = xbb857c9fc36f5054.xc42baa2576960ea5(array[3]);
				break;
			}
			case "wrap":
				xf7125312c7ee115c.xae20093bed1e48a8(4097, x0eb9a864413f34de.x11d727ed1ffc07fe(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				xf7125312c7ee115c.xae20093bed1e48a8(4098, x0eb9a864413f34de.xc857a84afe54635b(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "horizontal-pos":
				xf7125312c7ee115c.xae20093bed1e48a8(911, x0eb9a864413f34de.x17c06b0a2e7f6479(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "horizontal-rel":
				xf7125312c7ee115c.xae20093bed1e48a8(912, x0eb9a864413f34de.xc20d2a534e22db7e(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "vertical-pos":
				verticalAlignment = x0eb9a864413f34de.xdf0002ad29b56fd1(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				xf7125312c7ee115c.x52b190e626f65140(913);
				break;
			case "vertical-rel":
				xf7125312c7ee115c.xae20093bed1e48a8(914, x0eb9a864413f34de.x4fd9cfbe5f5253d0(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "stroke-width":
				xf7125312c7ee115c.xae20093bed1e48a8(459, xbb857c9fc36f5054.xdea5d4100fe5f461(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "stroke-color":
				xf7125312c7ee115c.xae20093bed1e48a8(448, xbb857c9fc36f5054.xd9a94ec83011098f(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "stroke-opacity":
				xf7125312c7ee115c.xae20093bed1e48a8(449, xbb857c9fc36f5054.x0b133b860e555abb(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "shadow-color":
				xf7125312c7ee115c.xae20093bed1e48a8(513, xbb857c9fc36f5054.xd9a94ec83011098f(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "shadow":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "visible")
				{
					xf7125312c7ee115c.xae20093bed1e48a8(574, true);
				}
				else if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "hidden")
				{
					xf7125312c7ee115c.xae20093bed1e48a8(574, false);
				}
				break;
			case "shadow-opacity":
				xf7125312c7ee115c.xae20093bed1e48a8(516, xbb857c9fc36f5054.x0b133b860e555abb(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "shadow-offset-x":
				xf7125312c7ee115c.xae20093bed1e48a8(517, xbb857c9fc36f5054.xdea5d4100fe5f461(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "shadow-offset-y":
				xf7125312c7ee115c.xae20093bed1e48a8(518, xbb857c9fc36f5054.xdea5d4100fe5f461(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "run-through":
				xf7125312c7ee115c.xae20093bed1e48a8(954, xca994afbcb9073a.xd2f68ee6f47e9dfb == "background");
				break;
			case "stroke":
				text = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				switch (text)
				{
				case "none":
					xf7125312c7ee115c.xae20093bed1e48a8(508, false);
					break;
				case "solid":
					xf7125312c7ee115c.xae20093bed1e48a8(508, true);
					break;
				}
				break;
			case "stroke-dash":
				xbd5a2e7a4ff749c = xbb857c9fc36f5054.x94045081801bb82d(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "marker-start":
				x0eb9a864413f34de.x48a90babb0267a41(xe134235b3526fa75, xca994afbcb9073a.xd2f68ee6f47e9dfb, xf7125312c7ee115c, xa59013d234619c58: true);
				break;
			case "marker-end":
				x0eb9a864413f34de.x48a90babb0267a41(xe134235b3526fa75, xca994afbcb9073a.xd2f68ee6f47e9dfb, xf7125312c7ee115c, xa59013d234619c58: false);
				break;
			case "background-color":
				if (xf7125312c7ee115c.xf7866f89640a29a3(385) == null)
				{
					xf7125312c7ee115c.xae20093bed1e48a8(385, xbb857c9fc36f5054.xd9a94ec83011098f(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				}
				break;
			case "fill-color":
				xf7125312c7ee115c.xae20093bed1e48a8(385, xbb857c9fc36f5054.xd9a94ec83011098f(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "secondary-fill-color":
				xf7125312c7ee115c.xae20093bed1e48a8(647, xbb857c9fc36f5054.xd9a94ec83011098f(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "fill-gradient-name":
				xbd5a2e7a4ff749c2 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "fill":
				xd925f447ef7e00a = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "background-transparency":
				xf7125312c7ee115c.xae20093bed1e48a8(386, xbb857c9fc36f5054.x17816a52864a361a(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "opacity":
				xf7125312c7ee115c.xae20093bed1e48a8(386, xbb857c9fc36f5054.x0b133b860e555abb(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "luminance":
				xf7125312c7ee115c.xae20093bed1e48a8(265, xbb857c9fc36f5054.x88b59025a8c57163(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "contrast":
				xf7125312c7ee115c.xae20093bed1e48a8(264, xbb857c9fc36f5054.x668697ef5336f8da(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "color-mode":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "greyscale")
				{
					xf7125312c7ee115c.xae20093bed1e48a8(317, true);
				}
				else if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "mono")
				{
					xf7125312c7ee115c.xae20093bed1e48a8(318, true);
				}
				break;
			case "marker-start-width":
				x8f9f54b64019439b = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "marker-end-width":
				x8f9f54b64019439b2 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "wrap-option":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "no-wrap")
				{
					xf7125312c7ee115c.xae20093bed1e48a8(133, TextBoxWrapMode.None);
				}
				else
				{
					xf7125312c7ee115c.xae20093bed1e48a8(133, TextBoxWrapMode.Square);
				}
				break;
			}
		}
		object obj = xf7125312c7ee115c.xf7866f89640a29a3(914);
		if (obj == null || (RelativeVerticalPosition)obj != RelativeVerticalPosition.Line)
		{
			xf7125312c7ee115c.xae20093bed1e48a8(913, verticalAlignment);
		}
		xf2c5ad4b4d2975c8 xf2c5ad4b4d2975c = xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xbd5a2e7a4ff749c, (string)null, x0bfe184ad871a4c2: false, xafd04c36a00d5bcf: false) as xf2c5ad4b4d2975c8;
		DashStyle dashStyle = x0eb9a864413f34de.x89d821e7a5db0c45(text, xf2c5ad4b4d2975c);
		if (dashStyle != 0 && dashStyle != 0)
		{
			xf7125312c7ee115c.xae20093bed1e48a8(462, dashStyle);
		}
		if (xf2c5ad4b4d2975c != null)
		{
			if (xf2c5ad4b4d2975c.xfe2178c1f916f36c == "round")
			{
				xf7125312c7ee115c.xae20093bed1e48a8(471, EndCap.Round);
			}
			else if (x0d299f323d241756.x5959bccb67bbf051(xf2c5ad4b4d2975c.xfe2178c1f916f36c))
			{
				xf7125312c7ee115c.xae20093bed1e48a8(471, EndCap.Flat);
			}
		}
		x4189ee18bf070d29(xf7125312c7ee115c, x44ecfea61c937b8e, text != "none");
		xd9ff11e3f20a5302(x8f9f54b64019439b, xf7125312c7ee115c, xa59013d234619c58: true);
		xd9ff11e3f20a5302(x8f9f54b64019439b2, xf7125312c7ee115c, xa59013d234619c58: false);
		x425eec8888f9cefa xc41398e743370c = xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xbd5a2e7a4ff749c2, (string)null, x0bfe184ad871a4c2: false, xafd04c36a00d5bcf: false) as x425eec8888f9cefa;
		x957cddcfe8e5fc4f(xf7125312c7ee115c, xd925f447ef7e00a, xc41398e743370c);
		if (xf7125312c7ee115c.xd44988f225497f3a > 0)
		{
			x44ecfea61c937b8e.xf7125312c7ee115c = xf7125312c7ee115c;
		}
	}

	private static void x957cddcfe8e5fc4f(xf7125312c7ee115c xa5e8b8b5991a4e1d, string xd925f447ef7e00a4, x425eec8888f9cefa xc41398e743370c21)
	{
		if (xd925f447ef7e00a4 == null)
		{
			return;
		}
		if (xd925f447ef7e00a4 == "none")
		{
			xa5e8b8b5991a4e1d.xae20093bed1e48a8(443, false);
			return;
		}
		xa5e8b8b5991a4e1d.xae20093bed1e48a8(443, true);
		xa5e8b8b5991a4e1d.xae20093bed1e48a8(384, x0eb9a864413f34de.x420ef5b455ea067b(xd925f447ef7e00a4, xc41398e743370c21));
		if (xd925f447ef7e00a4 == "gradient" && xc41398e743370c21 != null)
		{
			if (x0d299f323d241756.x5959bccb67bbf051(xc41398e743370c21.x7d2dc175c2f289c5))
			{
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(385, xbb857c9fc36f5054.xd9a94ec83011098f(xc41398e743370c21.x7d2dc175c2f289c5));
			}
			if (x0d299f323d241756.x5959bccb67bbf051(xc41398e743370c21.xf3874816968aabd7))
			{
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(387, xbb857c9fc36f5054.xd9a94ec83011098f(xc41398e743370c21.xf3874816968aabd7));
			}
			if (x0d299f323d241756.x5959bccb67bbf051(xc41398e743370c21.x869fb763fab11919))
			{
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(386, xbb857c9fc36f5054.x0b133b860e555abb(xc41398e743370c21.x869fb763fab11919));
			}
			if (x0d299f323d241756.x5959bccb67bbf051(xc41398e743370c21.xfaf5ba04f7a15657))
			{
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(388, xbb857c9fc36f5054.x0b133b860e555abb(xc41398e743370c21.xfaf5ba04f7a15657));
			}
			if (x0d299f323d241756.x5959bccb67bbf051(xc41398e743370c21.xb5e5bf124e3ded2d))
			{
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(397, xbb857c9fc36f5054.x5ea2f04c5aa3dba5(xc41398e743370c21.xb5e5bf124e3ded2d));
			}
			if (x0d299f323d241756.x5959bccb67bbf051(xc41398e743370c21.x9af8f492114408ed))
			{
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(398, xbb857c9fc36f5054.x5ea2f04c5aa3dba5(xc41398e743370c21.x9af8f492114408ed));
			}
			if (x0d299f323d241756.x5959bccb67bbf051(xc41398e743370c21.x6b1fe03343d9a6a4))
			{
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(395, xbb857c9fc36f5054.x0de3a17de401c0aa(xc41398e743370c21.x6b1fe03343d9a6a4) / 10);
			}
			if (xc41398e743370c21.xfe2178c1f916f36c == "axial")
			{
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(396, -1);
			}
			if (xc41398e743370c21.xfe2178c1f916f36c == "linear")
			{
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(396, 100);
			}
		}
	}

	private static void xd9ff11e3f20a5302(string x8f9f54b64019439b, xf7125312c7ee115c xa5e8b8b5991a4e1d, bool xa59013d234619c58)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(x8f9f54b64019439b))
		{
			int num = xbb857c9fc36f5054.x30490843b282206a(x8f9f54b64019439b);
			int xba08ce632055a1d = (xa59013d234619c58 ? 466 : 468);
			int xba08ce632055a1d2 = (xa59013d234619c58 ? 464 : 465);
			switch (num)
			{
			case 420:
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(xba08ce632055a1d2, ArrowType.Open);
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(xba08ce632055a1d, ArrowWidth.Wide);
				break;
			case 350:
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(xba08ce632055a1d, ArrowWidth.Wide);
				break;
			case 315:
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(xba08ce632055a1d2, ArrowType.Open);
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(xba08ce632055a1d, ArrowWidth.Medium);
				break;
			case 210:
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(xba08ce632055a1d, ArrowWidth.Medium);
				break;
			case 245:
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(xba08ce632055a1d2, ArrowType.Open);
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(xba08ce632055a1d, ArrowWidth.Narrow);
				break;
			case 140:
				xa5e8b8b5991a4e1d.xae20093bed1e48a8(xba08ce632055a1d, ArrowWidth.Narrow);
				break;
			}
		}
	}

	private static void x4189ee18bf070d29(xf7125312c7ee115c xa5e8b8b5991a4e1d, x38c672d671ef22c7 x44ecfea61c937b8e, bool x103863f095353be0)
	{
		x6a3b9cbff75fd927 xb70a9d14469748bf = x44ecfea61c937b8e.xb70a9d14469748bf;
		x1ba0adbe4f846c39 x6e5a54a5c6ac3f = x44ecfea61c937b8e.x6e5a54a5c6ac3f42;
		xaf975f26d67e34e8 xb09bf7248f4ba6cb = x44ecfea61c937b8e.xb09bf7248f4ba6cb;
		if ((xb70a9d14469748bf.xa8c2637cc4888928 != null && xb70a9d14469748bf.xa8c2637cc4888928.x3d0571719b5893b4 != 0) || x103863f095353be0 || x6e5a54a5c6ac3f.x41c7a253dffab96d != 0.0)
		{
			xa5e8b8b5991a4e1d.xae20093bed1e48a8(4106, x533663bbcdc757a9.x95dfc63190e8c019(xb70a9d14469748bf.xa8c2637cc4888928, x6e5a54a5c6ac3f.x41c7a253dffab96d, 0));
		}
		xa5e8b8b5991a4e1d.xae20093bed1e48a8(901, xbb857c9fc36f5054.x65e9699e8d18e38e(xb09bf7248f4ba6cb.x71043d5524bf9d58.x83551eb97a16bb65));
		if ((xb70a9d14469748bf.x79d902473861f242 != null && xb70a9d14469748bf.x79d902473861f242.x3d0571719b5893b4 != 0) || x103863f095353be0 || x6e5a54a5c6ac3f.xf2f0e85a6d5b32fb != 0.0)
		{
			xa5e8b8b5991a4e1d.xae20093bed1e48a8(4108, x533663bbcdc757a9.x95dfc63190e8c019(xb70a9d14469748bf.x79d902473861f242, x6e5a54a5c6ac3f.xf2f0e85a6d5b32fb, 0));
		}
		xa5e8b8b5991a4e1d.xae20093bed1e48a8(903, xbb857c9fc36f5054.x65e9699e8d18e38e(xb09bf7248f4ba6cb.x71043d5524bf9d58.xa671de6a1e9bcaae));
		if ((xb70a9d14469748bf.xaea087ab32102492 != null && xb70a9d14469748bf.xaea087ab32102492.x3d0571719b5893b4 != 0) || x103863f095353be0 || x6e5a54a5c6ac3f.x1fce31db7994633f != 0.0)
		{
			xa5e8b8b5991a4e1d.xae20093bed1e48a8(4107, x533663bbcdc757a9.x95dfc63190e8c019(xb70a9d14469748bf.xaea087ab32102492, x6e5a54a5c6ac3f.x1fce31db7994633f, 0));
		}
		xa5e8b8b5991a4e1d.xae20093bed1e48a8(900, xbb857c9fc36f5054.x65e9699e8d18e38e(xb09bf7248f4ba6cb.xa3e94d39710969ea.xc334118c782d9421));
		if ((xb70a9d14469748bf.xd7a21e27974f626c != null && xb70a9d14469748bf.xd7a21e27974f626c.x3d0571719b5893b4 != 0) || x103863f095353be0 || x6e5a54a5c6ac3f.x5035ade17b9c6f87 != 0.0)
		{
			xa5e8b8b5991a4e1d.xae20093bed1e48a8(4109, x533663bbcdc757a9.x95dfc63190e8c019(xb70a9d14469748bf.xd7a21e27974f626c, x6e5a54a5c6ac3f.x5035ade17b9c6f87, 0));
		}
		xa5e8b8b5991a4e1d.xae20093bed1e48a8(902, xbb857c9fc36f5054.x65e9699e8d18e38e(xb09bf7248f4ba6cb.xa3e94d39710969ea.xc6c700120c59c6b8));
	}
}
