using Aspose.Words;
using x2845e7a1a7dc898b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;
using xf9a9481c3f63a419;

namespace xfce5b6a304778b89;

internal class xaf0a8e2144428ff9
{
	private xaf0a8e2144428ff9()
	{
	}

	internal static xeedad81aaed42a76 x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, x5668c8829b7abcee x79cf302e32e8599c)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		xeedad81aaed42a76 xeedad81aaed42a = new xeedad81aaed42a76();
		string text = xca994afbcb9073a.xd68abcd61e368af9("font-size", "10pt");
		if (text.EndsWith("%"))
		{
			text = "10pt";
		}
		int x5c021e387157a = xbb857c9fc36f5054.x2331ecbb921f8120(text);
		string arg = "";
		string arg2 = "";
		string arg3 = "";
		string arg4 = "";
		string arg5 = "";
		string arg6 = "";
		string text2 = "";
		string text3 = "";
		string text4 = "";
		string x5be89112f1b625bc = "";
		xf80d6ac0b6a56f39 xf80d6ac0b6a56f = null;
		xca994afbcb9073a.x99f8cdb2827fa686();
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			string xd2f68ee6f47e9dfb = xca994afbcb9073a.xd2f68ee6f47e9dfb;
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "hyphenate":
			{
				bool flag = xd2f68ee6f47e9dfb == "true";
				if (x79cf302e32e8599c.x4ccc2e5631b8ba9c == "paragraph" && x79cf302e32e8599c.x759aa16c2016a289 == null)
				{
					xe134235b3526fa75.x2c8c6741422a1298.xdade2366eaa6f915.xdf76d3eeb73027d7 = flag;
				}
				x79cf302e32e8599c.x1a78664fa10a3755.xb6157b6da9895c0d(1410, !flag);
				break;
			}
			case "font-variant":
				if (xd2f68ee6f47e9dfb == "small-caps")
				{
					xeedad81aaed42a.xd00aa8389522ce53(110, x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc);
				}
				break;
			case "text-transform":
				if (xd2f68ee6f47e9dfb == "uppercase")
				{
					xeedad81aaed42a.xd00aa8389522ce53(120, x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc);
				}
				break;
			case "color":
				xeedad81aaed42a.xd00aa8389522ce53(160, xbb857c9fc36f5054.xd9a94ec83011098f(xd2f68ee6f47e9dfb));
				break;
			case "text-outline":
				if (xd2f68ee6f47e9dfb == "true")
				{
					xeedad81aaed42a.xd00aa8389522ce53(90, x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc);
				}
				break;
			case "text-line-through-type":
				if (xd2f68ee6f47e9dfb == "double")
				{
					xeedad81aaed42a.xd00aa8389522ce53(300, x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc);
				}
				if (xd2f68ee6f47e9dfb == "single")
				{
					xeedad81aaed42a.xd00aa8389522ce53(80, x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc);
				}
				break;
			case "text-line-through-style":
				if (xd2f68ee6f47e9dfb == "solid")
				{
					xeedad81aaed42a.xd00aa8389522ce53(80, x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc);
				}
				else if (xd2f68ee6f47e9dfb == "none")
				{
					xeedad81aaed42a.xd00aa8389522ce53(80, x9b28b1f7f0cc963f.x12642456c7bf0815);
				}
				break;
			case "text-position":
				if (xd2f68ee6f47e9dfb == "super 58%" || xd2f68ee6f47e9dfb == "sub 58%")
				{
					xeedad81aaed42a.xd00aa8389522ce53(210, x0eb9a864413f34de.xc4b75e84c6310a3b(xd2f68ee6f47e9dfb));
				}
				xeedad81aaed42a.xd00aa8389522ce53(200, xbb857c9fc36f5054.x07425727e27d8547(xd2f68ee6f47e9dfb, x5c021e387157a));
				break;
			case "font-name":
			{
				string text5 = (string)xe134235b3526fa75.xa2bae26554bf2a93[xca994afbcb9073a.xd2f68ee6f47e9dfb];
				if (x0d299f323d241756.x5959bccb67bbf051(text5))
				{
					xeedad81aaed42a.x51cf23ce6e71b84c = text5;
					xeedad81aaed42a.xd08cbc518cf39317 = xeedad81aaed42a.x51cf23ce6e71b84c;
				}
				break;
			}
			case "font-name-complex":
			{
				string xbcea506a33cf2 = (string)xe134235b3526fa75.xa2bae26554bf2a93[xca994afbcb9073a.xd2f68ee6f47e9dfb];
				if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf2))
				{
					xeedad81aaed42a.xf3d194b4e6a2594a = (string)xe134235b3526fa75.xa2bae26554bf2a93[xca994afbcb9073a.xd2f68ee6f47e9dfb];
				}
				break;
			}
			case "font-name-asian":
			{
				string xbcea506a33cf = (string)xe134235b3526fa75.xa2bae26554bf2a93[xca994afbcb9073a.xd2f68ee6f47e9dfb];
				if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
				{
					xeedad81aaed42a.x31ece097bda75a20 = (string)xe134235b3526fa75.xa2bae26554bf2a93[xca994afbcb9073a.xd2f68ee6f47e9dfb];
				}
				break;
			}
			case "font-size":
				xbb857c9fc36f5054.x2331ecbb921f8120(xca994afbcb9073a.xd2f68ee6f47e9dfb, x79cf302e32e8599c, xeedad81aaed42a, 190);
				break;
			case "font-size-asian":
			case "font-size-complex":
				xbb857c9fc36f5054.x2331ecbb921f8120(xca994afbcb9073a.xd2f68ee6f47e9dfb, x79cf302e32e8599c, xeedad81aaed42a, 350);
				break;
			case "font-weight":
				xeedad81aaed42a.xd00aa8389522ce53(60, xbb857c9fc36f5054.x04c8efb539cf6f17(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "font-weight-asian":
			case "font-weight-complex":
				xeedad81aaed42a.xd00aa8389522ce53(250, xbb857c9fc36f5054.x04c8efb539cf6f17(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "font-style":
				xeedad81aaed42a.xd00aa8389522ce53(70, xbb857c9fc36f5054.x77391c255918b2ef(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "font-style-asian":
			case "font-style-complex":
				xeedad81aaed42a.xd00aa8389522ce53(260, xbb857c9fc36f5054.x77391c255918b2ef(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "language":
				arg = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "country":
				arg2 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "language-asian":
				arg3 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "country-asian":
				arg4 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "language-complex":
				arg5 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "country-complex":
				arg6 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "background-color":
				xeedad81aaed42a.xd00aa8389522ce53(370, xbb857c9fc36f5054.x56cdf34322e60e51(xd2f68ee6f47e9dfb, (Shading)xeedad81aaed42a.x9bd0b4c41657450b(370)));
				break;
			case "letter-spacing":
				xeedad81aaed42a.xd00aa8389522ce53(150, (!(xca994afbcb9073a.xd2f68ee6f47e9dfb == "normal")) ? xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb) : 0);
				break;
			case "font-relief":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "engraved")
				{
					xeedad81aaed42a.xd00aa8389522ce53(180, x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc);
				}
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "embossed")
				{
					xeedad81aaed42a.xd00aa8389522ce53(170, x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc);
				}
				break;
			case "display":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "none")
				{
					xeedad81aaed42a.xd00aa8389522ce53(130, x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc);
				}
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "true")
				{
					xeedad81aaed42a.xd00aa8389522ce53(130, x9b28b1f7f0cc963f.x12642456c7bf0815);
				}
				break;
			case "text-blinking":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "true")
				{
					xeedad81aaed42a.xd00aa8389522ce53(310, TextEffect.BlinkingBackground);
				}
				break;
			case "text-scale":
				xeedad81aaed42a.xd00aa8389522ce53(290, xca004f56614e2431.x59884ab46dd0d856(xca994afbcb9073a.xd2f68ee6f47e9dfb.Replace("%", "")));
				break;
			case "text-shadow":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb != "none")
				{
					xeedad81aaed42a.xd00aa8389522ce53(100, x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc);
				}
				break;
			case "text-underline-width":
				text2 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "text-underline-style":
				text3 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "text-underline-type":
				x5be89112f1b625bc = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "text-underline-mode":
				text4 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "text-underline-color":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb != "font-color")
				{
					xeedad81aaed42a.xd00aa8389522ce53(450, xbb857c9fc36f5054.xd9a94ec83011098f(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				}
				break;
			case "text-rotation-scale":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "line-height")
				{
					if (xf80d6ac0b6a56f == null)
					{
						xf80d6ac0b6a56f = x8d00b02612b3ecc2(xe134235b3526fa75);
					}
					xf80d6ac0b6a56f.x8983dff00ce7e17a = true;
				}
				break;
			case "text-rotation-angle":
			{
				int num = xca004f56614e2431.xa93402510be8434e(xd2f68ee6f47e9dfb) % 360;
				if ((num >= 45 && num < 180) || (num >= -315 && num < -180))
				{
					if (xf80d6ac0b6a56f == null)
					{
						xf80d6ac0b6a56f = x8d00b02612b3ecc2(xe134235b3526fa75);
					}
					xf80d6ac0b6a56f.x61c108cc44ef385a = true;
				}
				if (xf80d6ac0b6a56f == null)
				{
					x79cf302e32e8599c.x4f039b1e0e8b59ec = x0eb9a864413f34de.x9d37a8a506e662b7(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				}
				break;
			}
			}
		}
		if (xf80d6ac0b6a56f != null)
		{
			xeedad81aaed42a.xd00aa8389522ce53(780, xf80d6ac0b6a56f);
		}
		xeedad81aaed42a.xd00aa8389522ce53(380, x0eb9a864413f34de.x1fd658c8428b3dd6($"{arg}-{arg2}"));
		xeedad81aaed42a.xd00aa8389522ce53(390, x0eb9a864413f34de.x1fd658c8428b3dd6($"{arg3}-{arg4}"));
		xeedad81aaed42a.xd00aa8389522ce53(340, x0eb9a864413f34de.x1fd658c8428b3dd6($"{arg5}-{arg6}"));
		if (x0d299f323d241756.x5959bccb67bbf051(text3) || text4 == "skip-white-space" || text2 == "thick")
		{
			xeedad81aaed42a.xd00aa8389522ce53(140, x0eb9a864413f34de.x57328579aa0dc5af(text3, text2, text4, x5be89112f1b625bc));
		}
		return xeedad81aaed42a;
	}

	private static xf80d6ac0b6a56f39 x8d00b02612b3ecc2(xf871da68decec406 xe134235b3526fa75)
	{
		xf80d6ac0b6a56f39 xf80d6ac0b6a56f = new xf80d6ac0b6a56f39();
		xf80d6ac0b6a56f.xd9c2f8178451a779 = xe134235b3526fa75.xd9c2f8178451a779;
		xe134235b3526fa75.xd9c2f8178451a779++;
		return xf80d6ac0b6a56f;
	}
}
