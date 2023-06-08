using System.Collections;
using System.Drawing;
using System.Text;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x1a3e96f4b89a7a77;
using x2697283ff424107e;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;
using xf9a9481c3f63a419;

namespace x7c7a1dceb600404e;

internal class xa25dec8c824ea182
{
	private xa25dec8c824ea182()
	{
	}

	internal static void x6210059f049f0d48(ShapeBase x5770cdefd8931aa9, x873451caae5ad4ae xd07ce4b74c5774a7, x2cd1f1f5e07462a8 x0f7b23d1c393aed9)
	{
		x6210059f049f0d48(x5770cdefd8931aa9, xe4b4fecd3c706380: false, xd07ce4b74c5774a7, x0f7b23d1c393aed9);
	}

	internal static void x6210059f049f0d48(ShapeBase x5770cdefd8931aa9, bool xe4b4fecd3c706380, x873451caae5ad4ae xd07ce4b74c5774a7, x2cd1f1f5e07462a8 x0f7b23d1c393aed9)
	{
		string text = "v:shape";
		string text2 = null;
		bool flag = false;
		switch (x5770cdefd8931aa9.ShapeType)
		{
		case ShapeType.Group:
			text = "v:group";
			break;
		case ShapeType.NonPrimitive:
			text = "v:shape";
			break;
		case ShapeType.Rectangle:
			text = "v:rect";
			break;
		case ShapeType.RoundRectangle:
			text = "v:roundrect";
			break;
		case ShapeType.Ellipse:
			text = "v:oval";
			break;
		case ShapeType.Line:
			text = "v:line";
			break;
		case ShapeType.OleObject:
			text2 = $"#_x0000_t{75}";
			flag = true;
			break;
		default:
			text2 = $"#_x0000_t{(int)x5770cdefd8931aa9.ShapeType}";
			flag = true;
			break;
		}
		if (xe4b4fecd3c706380)
		{
			text = "v:background";
		}
		x4c28fed4089bb8e4 x4c28fed4089bb8e5 = new x4c28fed4089bb8e4(x5770cdefd8931aa9, xd07ce4b74c5774a7, x0f7b23d1c393aed9);
		xe70e7c93110e9374 xe70e7c93110e9375 = new xe70e7c93110e9374(xd07ce4b74c5774a7, x0f7b23d1c393aed9);
		x1b2f3d2bdda7ea21 x1b2f3d2bdda7ea22 = new x1b2f3d2bdda7ea21(x5770cdefd8931aa9, xd07ce4b74c5774a7, x0f7b23d1c393aed9);
		xbfa8eb0310372fb0 xbfa8eb0310372fb = new xbfa8eb0310372fb0(xd07ce4b74c5774a7);
		xec665a37b56b57bd xec665a37b56b57bd2 = new xec665a37b56b57bd(xd07ce4b74c5774a7);
		x44b09cab0cde18f9 x44b09cab0cde18f10 = new x44b09cab0cde18f9(x5770cdefd8931aa9, xd07ce4b74c5774a7);
		xb18057f7e8d4ae41 xb18057f7e8d4ae42 = new xb18057f7e8d4ae41(xd07ce4b74c5774a7);
		x1afa8eb56970ec16 x1afa8eb56970ec17 = new x1afa8eb56970ec16(xd07ce4b74c5774a7);
		x5e429fd2260c69b9 x5e429fd2260c69b10 = new x5e429fd2260c69b9(x0f7b23d1c393aed9, xd07ce4b74c5774a7);
		xe7ba244cf8751cb1 xe7ba244cf8751cb2 = new xe7ba244cf8751cb1(xd07ce4b74c5774a7);
		x43f81f42ceba24dc x43f81f42ceba24dc2 = new x43f81f42ceba24dc(xd07ce4b74c5774a7);
		string text3 = null;
		string text4 = null;
		Hashtable hashtable = new Hashtable();
		xf7125312c7ee115c xf7125312c7ee115c = x5770cdefd8931aa9.xf7125312c7ee115c;
		for (int i = 0; i < xf7125312c7ee115c.xd44988f225497f3a; i++)
		{
			int num = xf7125312c7ee115c.xf15263674eb297bb(i);
			object obj = xf7125312c7ee115c.x6d3720b962bd3112(i);
			switch (num & -64)
			{
			case 384:
				x4c28fed4089bb8e5.x4ac9f4b2e295bbfd(num, obj);
				continue;
			case 448:
				if (num == 507)
				{
					x44b09cab0cde18f10.x4ac9f4b2e295bbfd(num, obj);
				}
				else
				{
					xe70e7c93110e9375.x4ac9f4b2e295bbfd(num, obj);
				}
				continue;
			case 256:
				x1b2f3d2bdda7ea22.x4ac9f4b2e295bbfd(num, obj);
				continue;
			case 512:
				xbfa8eb0310372fb.x4ac9f4b2e295bbfd(num, obj);
				continue;
			case 640:
			case 704:
				xec665a37b56b57bd2.x4ac9f4b2e295bbfd(num, obj);
				continue;
			case 320:
				x44b09cab0cde18f10.x4ac9f4b2e295bbfd(num, obj);
				continue;
			case 192:
				xb18057f7e8d4ae42.x4ac9f4b2e295bbfd(num, obj);
				continue;
			case 64:
				x1afa8eb56970ec17.x4ac9f4b2e295bbfd(num, obj);
				continue;
			case 1280:
				x5e429fd2260c69b10.x4ac9f4b2e295bbfd(num, obj);
				continue;
			case 832:
				xe7ba244cf8751cb2.x4ac9f4b2e295bbfd(num, obj);
				continue;
			}
			switch (num)
			{
			case 4111:
				x4c28fed4089bb8e5.x4ac9f4b2e295bbfd(num, obj);
				break;
			case 4110:
				xe70e7c93110e9375.x4ac9f4b2e295bbfd(num, obj);
				break;
			case 4102:
			case 4103:
			case 4104:
				x1b2f3d2bdda7ea22.x4ac9f4b2e295bbfd(num, obj);
				break;
			case 828:
				x1afa8eb56970ec17.x4ac9f4b2e295bbfd(num, obj);
				break;
			case 772:
			case 773:
			case 774:
				hashtable[num] = xf4107e64edda7fac.xe9974f6e10f3d43f((x17abde5b32777816)obj);
				break;
			case 777:
				text3 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj);
				break;
			case 778:
				text4 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj);
				break;
			case 4125:
			case 4126:
			case 4127:
			case 4128:
				hashtable[num] = (int)obj;
				break;
			case 4096:
				hashtable[num] = xf4107e64edda7fac.xd174199743a6b72d((FlipOrientation)obj);
				break;
			case 911:
			{
				HorizontalAlignment horizontalAlignment = (HorizontalAlignment)obj;
				if (horizontalAlignment != 0)
				{
					hashtable[num] = x72a0c846678ecaf9.x9617344359c63dd2(horizontalAlignment);
				}
				break;
			}
			case 912:
			{
				RelativeHorizontalPosition relativeHorizontalPosition = (RelativeHorizontalPosition)obj;
				if (relativeHorizontalPosition != RelativeHorizontalPosition.Column)
				{
					hashtable[num] = x72a0c846678ecaf9.x14e082375ba0c07c(relativeHorizontalPosition);
				}
				break;
			}
			case 913:
			{
				VerticalAlignment verticalAlignment = (VerticalAlignment)obj;
				if (verticalAlignment != 0)
				{
					hashtable[num] = x72a0c846678ecaf9.xf7b3d51063ad99cc(verticalAlignment);
				}
				break;
			}
			case 914:
			{
				RelativeVerticalPosition relativeVerticalPosition = (RelativeVerticalPosition)obj;
				if (relativeVerticalPosition != RelativeVerticalPosition.Paragraph)
				{
					hashtable[num] = x72a0c846678ecaf9.xd28acd82ad3fd5e3(relativeVerticalPosition);
				}
				break;
			}
			case 900:
			case 901:
			case 902:
			case 903:
				hashtable[num] = x4574ea26106f0edb.xa23e6b6c3169521d((int)obj);
				break;
			case 771:
				hashtable[num] = xf4107e64edda7fac.xfab9bfe321d4ba4b((x5b865d49b2c8440d)obj);
				break;
			case 133:
				hashtable[num] = xf4107e64edda7fac.x6583182d646501d9((TextBoxWrapMode)obj);
				break;
			case 135:
				hashtable[num] = xf4107e64edda7fac.x821eaadc09724bff((x69aaa2975337eae6)obj);
				break;
			case 190:
				if ((bool)obj)
				{
					hashtable[num] = "t";
				}
				break;
			case 916:
			{
				x206d87dc07f8c9e2 x206d87dc07f8c9e = (x206d87dc07f8c9e2)obj;
				if (x206d87dc07f8c9e != 0)
				{
					hashtable[num] = xf4107e64edda7fac.x091d9ce96dcb1aa1(x206d87dc07f8c9e);
				}
				break;
			}
			case 1984:
			case 1985:
			case 1986:
			case 1987:
				hashtable[num] = xca004f56614e2431.xc8ba948e0d631490((int)obj);
				break;
			case 1988:
				hashtable[num] = x72a0c846678ecaf9.xe1e700ad465a4394((x8307b3d797c38a81)obj);
				break;
			case 1989:
				hashtable[num] = x72a0c846678ecaf9.xeb27a86ee5c9f6a0((xc51d0ca9388f31bd)obj);
				break;
			case 1921:
			case 1922:
			case 1923:
			case 1924:
			case 1925:
			case 1926:
			case 1927:
			case 1928:
			case 1980:
			case 1981:
			case 1982:
			case 1983:
				x43f81f42ceba24dc2.x4ac9f4b2e295bbfd(num, obj);
				break;
			default:
				hashtable[num] = obj;
				break;
			}
		}
		if (!x0f7b23d1c393aed9.x325f1926b78ae5cd && hashtable[952] != null && (bool)hashtable[952])
		{
			string xbcea506a33cf = ((hashtable[922] == null) ? xf4107e64edda7fac.xd3319784e55a8806(hashtable[920]) : (hashtable[922] as string));
			xd07ce4b74c5774a7.x2307058321cdb62f("w:scriptAnchor");
			xd07ce4b74c5774a7.x6b73ce92fd8e3f2c("w:language", xbcea506a33cf);
			xd07ce4b74c5774a7.x6b73ce92fd8e3f2c("w:args", hashtable[919] as string);
			xd07ce4b74c5774a7.x6b73ce92fd8e3f2c("w:scriptText", hashtable[910] as string);
			return;
		}
		if (flag && !x0f7b23d1c393aed9.xa5a04b025492f124.Contains(text2))
		{
			x0f7b23d1c393aed9.xa5a04b025492f124.Add(text2);
			string text5 = x6f6338c074d2d794.xed451fba51ebd67a(x5770cdefd8931aa9.ShapeType);
			if (x0d299f323d241756.x5959bccb67bbf051(text5))
			{
				xd07ce4b74c5774a7.xd52401bdf5aacef6("\r\n");
				xd07ce4b74c5774a7.xd52401bdf5aacef6(text5);
				xd07ce4b74c5774a7.xd52401bdf5aacef6("\r\n");
			}
		}
		if (x1b2f3d2bdda7ea22.xcc18177a965e0313 != null)
		{
			x1b2f3d2bdda7ea22.x1cdb46ecf83a213d = x0f7b23d1c393aed9.x2f696e6403c110df(x1b2f3d2bdda7ea22.xcc18177a965e0313);
			if (x0d299f323d241756.x5959bccb67bbf051(x1b2f3d2bdda7ea22.x0769bc4ba9e7139a) && x1b2f3d2bdda7ea22.x0769bc4ba9e7139a != x1b2f3d2bdda7ea22.x1cdb46ecf83a213d)
			{
				x1b2f3d2bdda7ea22.x0769bc4ba9e7139a = x0f7b23d1c393aed9.xf1b629587cb7c15e(x1b2f3d2bdda7ea22.x0769bc4ba9e7139a);
			}
		}
		else if (x0d299f323d241756.x5959bccb67bbf051(x1b2f3d2bdda7ea22.x0769bc4ba9e7139a))
		{
			x1b2f3d2bdda7ea22.x1cdb46ecf83a213d = x0f7b23d1c393aed9.xf1b629587cb7c15e(x1b2f3d2bdda7ea22.x0769bc4ba9e7139a);
		}
		if (x4c28fed4089bb8e5.xcc18177a965e0313 != null)
		{
			x4c28fed4089bb8e5.x1cdb46ecf83a213d = x0f7b23d1c393aed9.x2f696e6403c110df(x4c28fed4089bb8e5.xcc18177a965e0313);
		}
		if (xe70e7c93110e9375.xcc18177a965e0313 != null)
		{
			xe70e7c93110e9375.x1cdb46ecf83a213d = x0f7b23d1c393aed9.x2f696e6403c110df(xe70e7c93110e9375.xcc18177a965e0313);
		}
		xd07ce4b74c5774a7.x2307058321cdb62f(text);
		if (x5770cdefd8931aa9.ShapeType == ShapeType.CustomShape)
		{
			string xbcea506a33cf2 = (string)hashtable[896];
			if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf2))
			{
				xd07ce4b74c5774a7.xfb5ff561cb1d5db2("id", xbcea506a33cf2);
				xd07ce4b74c5774a7.xfb5ff561cb1d5db2("o:spid", x64893267b789fd52.x67581c842683a852(x5770cdefd8931aa9));
			}
			else
			{
				xd07ce4b74c5774a7.xfb5ff561cb1d5db2("id", x64893267b789fd52.x67581c842683a852(x5770cdefd8931aa9));
			}
			if (xe70e7c93110e9375.x2482cd436e6e98a9 == null)
			{
				xe70e7c93110e9375.x2482cd436e6e98a9 = "miter";
			}
			if (hashtable[4127] == null)
			{
				hashtable[4127] = x5770cdefd8931aa9.x133d653c1b9b01f2;
			}
			if (hashtable[4128] == null)
			{
				hashtable[4128] = x5770cdefd8931aa9.xc97e136f0019c237;
			}
		}
		else if (x0d299f323d241756.x5959bccb67bbf051((string)hashtable[896]))
		{
			xd07ce4b74c5774a7.xfb5ff561cb1d5db2("id", hashtable[896]);
			xd07ce4b74c5774a7.xfb5ff561cb1d5db2("o:spid", x64893267b789fd52.x67581c842683a852(x5770cdefd8931aa9));
			xd07ce4b74c5774a7.xfb5ff561cb1d5db2("type", text2);
		}
		else
		{
			xd07ce4b74c5774a7.xfb5ff561cb1d5db2("id", x64893267b789fd52.x67581c842683a852(x5770cdefd8931aa9));
			xd07ce4b74c5774a7.xfb5ff561cb1d5db2("type", text2);
			xd07ce4b74c5774a7.xfb5ff561cb1d5db2("editas", x5e429fd2260c69b10.x5e63bd35f6835a06);
		}
		if (!x5770cdefd8931aa9.IsInline || !x5770cdefd8931aa9.IsImage)
		{
			xd07ce4b74c5774a7.xfb5ff561cb1d5db2("href", hashtable[898]);
			xd07ce4b74c5774a7.xfb5ff561cb1d5db2("target", hashtable[4120]);
			xd07ce4b74c5774a7.xfb5ff561cb1d5db2("title", hashtable[909]);
			xd07ce4b74c5774a7.xfb5ff561cb1d5db2("alt", hashtable[897]);
		}
		else
		{
			xd07ce4b74c5774a7.xfb5ff561cb1d5db2("alt", hashtable[897]);
		}
		if (!xe4b4fecd3c706380)
		{
			xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff = new xa3fc7dcdc8182ff6();
			if (!x5770cdefd8931aa9.IsInline)
			{
				xa3fc7dcdc8182ff.xf0ca15702ca7498c("position", "absolute");
			}
			string text6 = "";
			if (x5770cdefd8931aa9.IsTopLevel)
			{
				text6 = "margin-";
			}
			if (x5770cdefd8931aa9.ShapeType != ShapeType.Line)
			{
				if (!x5770cdefd8931aa9.IsInline)
				{
					if (x5770cdefd8931aa9.IsTopLevel || x5770cdefd8931aa9.Left != 0.0)
					{
						xa3fc7dcdc8182ff.xf0ca15702ca7498c(text6 + "left", x64893267b789fd52.xc86b859f104c5de7(x5770cdefd8931aa9.Left, x5770cdefd8931aa9.IsTopLevel));
					}
					if (x5770cdefd8931aa9.IsTopLevel || x5770cdefd8931aa9.Top != 0.0)
					{
						xa3fc7dcdc8182ff.xf0ca15702ca7498c(text6 + "top", x64893267b789fd52.xc86b859f104c5de7(x5770cdefd8931aa9.Top, x5770cdefd8931aa9.IsTopLevel));
					}
				}
				xa3fc7dcdc8182ff.xf0ca15702ca7498c("width", x64893267b789fd52.xc86b859f104c5de7(x5770cdefd8931aa9.Width, x5770cdefd8931aa9.IsTopLevel));
				xa3fc7dcdc8182ff.xf0ca15702ca7498c("height", x64893267b789fd52.xc86b859f104c5de7(x5770cdefd8931aa9.Height, x5770cdefd8931aa9.IsTopLevel));
			}
			object obj2 = hashtable[4];
			if (obj2 != null)
			{
				int num2 = (int)obj2;
				if (num2 != 0)
				{
					xa3fc7dcdc8182ff.xf0ca15702ca7498c("rotation", x64893267b789fd52.x933e1cb72ce52a40(num2));
				}
			}
			if (x0d299f323d241756.x5959bccb67bbf051((string)hashtable[4096]))
			{
				xa3fc7dcdc8182ff.xf0ca15702ca7498c("flip", (string)hashtable[4096]);
			}
			if (x5770cdefd8931aa9.IsTopLevel && !x5770cdefd8931aa9.IsInline)
			{
				xa3fc7dcdc8182ff.x0973ec6da4c01c5e("z-index", x5770cdefd8931aa9.x2dacf7fcd96fee63);
			}
			if (hashtable[958] != null)
			{
				xa3fc7dcdc8182ff.xf0ca15702ca7498c("visibility", ((bool)hashtable[958]) ? "hidden" : "visible");
			}
			if (hashtable[953] != null)
			{
				xa3fc7dcdc8182ff.xf0ca15702ca7498c("mso-wrap-edited", ((bool)hashtable[953]) ? "" : "f");
			}
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("mso-wrap-distance-left", x64893267b789fd52.xc86b859f104c5de7(hashtable[900], x5770cdefd8931aa9.IsTopLevel));
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("mso-wrap-distance-top", x64893267b789fd52.xc86b859f104c5de7(hashtable[901], x5770cdefd8931aa9.IsTopLevel));
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("mso-wrap-distance-right", x64893267b789fd52.xc86b859f104c5de7(hashtable[902], x5770cdefd8931aa9.IsTopLevel));
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("mso-wrap-distance-bottom", x64893267b789fd52.xc86b859f104c5de7(hashtable[903], x5770cdefd8931aa9.IsTopLevel));
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("mso-position-horizontal", (string)hashtable[911]);
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("mso-position-horizontal-relative", (string)hashtable[912]);
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("mso-position-vertical", (string)hashtable[913]);
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("mso-position-vertical-relative", (string)hashtable[914]);
			if (x0f7b23d1c393aed9.x325f1926b78ae5cd)
			{
				xa3fc7dcdc8182ff.xf0ca15702ca7498c("mso-left-percent", (string)hashtable[1986]);
				xa3fc7dcdc8182ff.xf0ca15702ca7498c("mso-top-percent", (string)hashtable[1987]);
				xa3fc7dcdc8182ff.xf0ca15702ca7498c("mso-width-percent", (string)hashtable[1984]);
				xa3fc7dcdc8182ff.xf0ca15702ca7498c("mso-height-percent", (string)hashtable[1985]);
				xa3fc7dcdc8182ff.xf0ca15702ca7498c("mso-width-relative", (string)hashtable[1988]);
				xa3fc7dcdc8182ff.xf0ca15702ca7498c("mso-height-relative", (string)hashtable[1989]);
			}
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("mso-wrap-style", (string)hashtable[133]);
			xa3fc7dcdc8182ff.xf0ca15702ca7498c("v-text-anchor", (string)hashtable[135]);
			xd07ce4b74c5774a7.x943f6be3acf634db("style", x64893267b789fd52.xe9a7724568345f89(xa3fc7dcdc8182ff));
		}
		if (hashtable[780] != null)
		{
			xd07ce4b74c5774a7.x943f6be3acf634db("equationxml", Encoding.UTF8.GetString((byte[])hashtable[780]));
		}
		xd07ce4b74c5774a7.x943f6be3acf634db("w:themeColor", hashtable[4147]);
		xd07ce4b74c5774a7.x943f6be3acf634db("w:themeShade", hashtable[4148]);
		xd07ce4b74c5774a7.x943f6be3acf634db("w:themeTint", hashtable[4149]);
		xd07ce4b74c5774a7.x943f6be3acf634db("o:bwmode", hashtable[772]);
		xd07ce4b74c5774a7.x943f6be3acf634db("o:bwpure", hashtable[773]);
		xd07ce4b74c5774a7.x943f6be3acf634db("o:bwnormal", hashtable[774]);
		if (!xe4b4fecd3c706380)
		{
			xd07ce4b74c5774a7.xfb5ff561cb1d5db2("o:oleicon", hashtable[826]);
		}
		if (x5770cdefd8931aa9.IsInline && x5770cdefd8931aa9.xa170cce2bc40bdf5)
		{
			xd07ce4b74c5774a7.xff520a0047c27122("o:ole", "");
		}
		if (x5770cdefd8931aa9.IsInline)
		{
			xd07ce4b74c5774a7.x943f6be3acf634db("o:bordertopcolor", x64893267b789fd52.x2a162e0e073f78e7((Border)hashtable[4106]));
			xd07ce4b74c5774a7.x943f6be3acf634db("o:borderleftcolor", x64893267b789fd52.x2a162e0e073f78e7((Border)hashtable[4107]));
			xd07ce4b74c5774a7.x943f6be3acf634db("o:borderbottomcolor", x64893267b789fd52.x2a162e0e073f78e7((Border)hashtable[4108]));
			xd07ce4b74c5774a7.x943f6be3acf634db("o:borderrightcolor", x64893267b789fd52.x2a162e0e073f78e7((Border)hashtable[4109]));
		}
		switch (x5770cdefd8931aa9.ShapeType)
		{
		case ShapeType.Line:
			xd07ce4b74c5774a7.xfb5ff561cb1d5db2("from", x64893267b789fd52.xb174242678100558(x5770cdefd8931aa9.Left, x5770cdefd8931aa9.Top, x5770cdefd8931aa9.IsTopLevel));
			xd07ce4b74c5774a7.xfb5ff561cb1d5db2("to", x64893267b789fd52.xb174242678100558(x5770cdefd8931aa9.Left + x5770cdefd8931aa9.Width, x5770cdefd8931aa9.Top + x5770cdefd8931aa9.Height, x5770cdefd8931aa9.IsTopLevel));
			break;
		case ShapeType.RoundRectangle:
			xd07ce4b74c5774a7.xfb5ff561cb1d5db2("arcsize", x64893267b789fd52.x19523ee23bbcf67d(xc29f054aa9ce07cb(x5770cdefd8931aa9)));
			break;
		}
		xfedf842bc95b0880(xd07ce4b74c5774a7, hashtable, 4125, 4126, "coordorigin");
		xfedf842bc95b0880(xd07ce4b74c5774a7, hashtable, 4127, 4128, "coordsize");
		xd07ce4b74c5774a7.x31389f0c752f577e("o:allowincell", hashtable[944], true);
		xd07ce4b74c5774a7.x31389f0c752f577e("o:allowoverlap", hashtable[950], true);
		if (x5770cdefd8931aa9.ShapeType == ShapeType.CustomShape)
		{
			xd07ce4b74c5774a7.xfb5ff561cb1d5db2("o:spt", "100");
		}
		if (text3 != null)
		{
			xd07ce4b74c5774a7.x943f6be3acf634db("o:dgmlayout", text3);
		}
		if (text4 != null)
		{
			xd07ce4b74c5774a7.x943f6be3acf634db("o:dgmnodekind", text4);
		}
		xd07ce4b74c5774a7.xfb5ff561cb1d5db2("o:connectortype", hashtable[771]);
		x44b09cab0cde18f10.xfe6dd186bf14d15a();
		x44b09cab0cde18f10.xdc1601b12d681407();
		xd07ce4b74c5774a7.xfb5ff561cb1d5db2("o:preferrelative", hashtable[827]);
		xd07ce4b74c5774a7.xfb5ff561cb1d5db2("o:button", hashtable[956]);
		xd07ce4b74c5774a7.xfb5ff561cb1d5db2("o:hrpct", hashtable[915]);
		xd07ce4b74c5774a7.xfb5ff561cb1d5db2("o:hralign", hashtable[916]);
		xd07ce4b74c5774a7.xfb5ff561cb1d5db2("o:hrstd", hashtable[946]);
		xd07ce4b74c5774a7.xfb5ff561cb1d5db2("o:hrnoshade", hashtable[947]);
		xd07ce4b74c5774a7.xfb5ff561cb1d5db2("o:hr", hashtable[948]);
		xd07ce4b74c5774a7.xfb5ff561cb1d5db2("o:bullet", hashtable[945]);
		x4c28fed4089bb8e5.x6c932b420ec526ec();
		if (!xe4b4fecd3c706380)
		{
			xe70e7c93110e9375.x6c932b420ec526ec();
		}
		x4c28fed4089bb8e5.x6210059f049f0d48();
		xe70e7c93110e9375.x6210059f049f0d48();
		x1b2f3d2bdda7ea22.x6210059f049f0d48();
		xbfa8eb0310372fb.x6210059f049f0d48();
		xec665a37b56b57bd2.x6210059f049f0d48();
		if (text == "v:shape")
		{
			x44b09cab0cde18f10.xf7b167486e3ffbc1();
			x44b09cab0cde18f10.x476b678a12519529();
			xb18057f7e8d4ae42.x6210059f049f0d48();
			x44b09cab0cde18f10.xcf3c1593b79b7899();
		}
		if (!xe4b4fecd3c706380)
		{
			x1afa8eb56970ec17.x6210059f049f0d48();
		}
		if (x5770cdefd8931aa9.xded2c9c41054f4dd != null)
		{
			xd07ce4b74c5774a7.x2307058321cdb62f("o:ink");
			xd07ce4b74c5774a7.x943f6be3acf634db("i", x5770cdefd8931aa9.xded2c9c41054f4dd);
			xd07ce4b74c5774a7.xfb5ff561cb1d5db2("annotation", x5770cdefd8931aa9.x04253a50feaae58a);
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		}
		x43f81f42ceba24dc2.x6210059f049f0d48();
		x5e429fd2260c69b10.x524ce4a564445ccf();
		xe7ba244cf8751cb2.x6210059f049f0d48();
		xda393f86430bcf09("w10:bordertop", hashtable[4106], xd07ce4b74c5774a7);
		xda393f86430bcf09("w10:borderleft", hashtable[4107], xd07ce4b74c5774a7);
		xda393f86430bcf09("w10:borderbottom", hashtable[4108], xd07ce4b74c5774a7);
		xda393f86430bcf09("w10:borderright", hashtable[4109], xd07ce4b74c5774a7);
		bool flag2 = x0f7b23d1c393aed9.x8556eed81191af11.xa2c21fc178d67af8.x263d579af1d0d43f(x5770cdefd8931aa9.xea1e81378298fa81);
		if (x5770cdefd8931aa9.IsGroup || (!x5770cdefd8931aa9.HasChildNodes && !flag2))
		{
			return;
		}
		xd07ce4b74c5774a7.x2307058321cdb62f("v:textbox");
		xa3fc7dcdc8182ff6 xa3fc7dcdc8182ff2 = new xa3fc7dcdc8182ff6();
		if (hashtable.Contains(136))
		{
			LayoutFlow layoutFlow = (LayoutFlow)hashtable[136];
			if (layoutFlow == LayoutFlow.BottomToTop)
			{
				xa3fc7dcdc8182ff2.xf0ca15702ca7498c("layout-flow", "vertical");
				xa3fc7dcdc8182ff2.xf0ca15702ca7498c("mso-layout-flow-alt", "bottom-to-top");
			}
			else
			{
				xa3fc7dcdc8182ff2.xf0ca15702ca7498c("layout-flow", xf4107e64edda7fac.x2381a86d596f6653(layoutFlow));
			}
		}
		int xdf3d5f8941ea27a = x5770cdefd8931aa9.xdf3d5f8941ea27a6;
		if (xdf3d5f8941ea27a != 0)
		{
			Shape shape = (Shape)x0f7b23d1c393aed9.x8556eed81191af11.xe42bd130f1e95570[xdf3d5f8941ea27a];
			string xbcea506a33cf3 = (x0d299f323d241756.x5959bccb67bbf051(shape.Name) ? $"#{shape.Name}" : $"#_x0000_s{xdf3d5f8941ea27a}");
			xa3fc7dcdc8182ff2.xf0ca15702ca7498c("mso-next-textbox", xbcea506a33cf3);
		}
		xa3fc7dcdc8182ff2.xf0ca15702ca7498c("mso-fit-shape-to-text", (string)hashtable[190]);
		xd07ce4b74c5774a7.xfb5ff561cb1d5db2("style", x64893267b789fd52.xe9a7724568345f89(xa3fc7dcdc8182ff2));
		xd07ce4b74c5774a7.xfb5ff561cb1d5db2("inset", x64893267b789fd52.xc3b86f9c2e8b19e4(hashtable));
		xd07ce4b74c5774a7.x2307058321cdb62f("w:txbxContent");
		if (!x5770cdefd8931aa9.HasChildNodes && flag2)
		{
			xd07ce4b74c5774a7.x2dfde153f4ef96d0("w:txbxContent");
			xd07ce4b74c5774a7.x2dfde153f4ef96d0("v:textbox");
		}
	}

	private static void xfedf842bc95b0880(x873451caae5ad4ae xd07ce4b74c5774a7, Hashtable xa5ea04da0b735c3b, int x52354f8f9d0f63ae, int x0d9bf3ca6118c952, string xb591dc602a67d872)
	{
		object obj = xa5ea04da0b735c3b[x52354f8f9d0f63ae];
		object obj2 = xa5ea04da0b735c3b[x0d9bf3ca6118c952];
		if (obj != null && obj2 != null)
		{
			xd07ce4b74c5774a7.xfb5ff561cb1d5db2(xb591dc602a67d872, x64893267b789fd52.xb174242678100558(new Point((int)obj, (int)obj2)));
		}
	}

	internal static void xe9c9c7110892d4dc(ShapeBase x5770cdefd8931aa9, x873451caae5ad4ae xd07ce4b74c5774a7)
	{
		xf7125312c7ee115c xf7125312c7ee115c = x5770cdefd8931aa9.xf7125312c7ee115c;
		string xbcea506a33cf = (xf7125312c7ee115c.x263d579af1d0d43f(4097) ? xf4107e64edda7fac.x07433c1bb14b71d3(x5770cdefd8931aa9.WrapType) : "");
		if (x5770cdefd8931aa9.xf7125312c7ee115c.x263d579af1d0d43f(4097))
		{
			string text = x72a0c846678ecaf9.x14e082375ba0c07c(x5770cdefd8931aa9.RelativeHorizontalPosition);
			if (text == "text")
			{
				text = "";
			}
			string text2 = x72a0c846678ecaf9.xd28acd82ad3fd5e3(x5770cdefd8931aa9.RelativeVerticalPosition);
			if (text2 == "text")
			{
				text2 = "";
			}
			string xbcea506a33cf2 = (xf7125312c7ee115c.x263d579af1d0d43f(4098) ? xf4107e64edda7fac.x92345caf1ef1f461(x5770cdefd8931aa9.WrapSide) : "");
			if (x5770cdefd8931aa9.IsInline)
			{
				if (text == "char" && text2 == "line")
				{
					xd07ce4b74c5774a7.x2307058321cdb62f("w10:wrap");
					xd07ce4b74c5774a7.xfb5ff561cb1d5db2("type", xbcea506a33cf);
					xd07ce4b74c5774a7.x2dfde153f4ef96d0();
				}
			}
			else if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
			{
				xd07ce4b74c5774a7.x2307058321cdb62f("w10:wrap");
				xd07ce4b74c5774a7.xfb5ff561cb1d5db2("type", xbcea506a33cf);
				xd07ce4b74c5774a7.xfb5ff561cb1d5db2("side", xbcea506a33cf2);
				xd07ce4b74c5774a7.x2dfde153f4ef96d0();
			}
			else if (x0d299f323d241756.x5959bccb67bbf051(text) || x0d299f323d241756.x5959bccb67bbf051(text2))
			{
				xd07ce4b74c5774a7.x2307058321cdb62f("w10:wrap");
				xd07ce4b74c5774a7.xfb5ff561cb1d5db2("side", xbcea506a33cf2);
				if (xd8ab25d547517355(text))
				{
					xd07ce4b74c5774a7.xfb5ff561cb1d5db2("anchorx", text);
				}
				if (xd8ab25d547517355(text2))
				{
					xd07ce4b74c5774a7.xfb5ff561cb1d5db2("anchory", text2);
				}
				xd07ce4b74c5774a7.x2dfde153f4ef96d0();
			}
		}
		if (x5770cdefd8931aa9.AnchorLocked)
		{
			xd07ce4b74c5774a7.xf68f9c3818e1f4b1("w10:anchorlock");
		}
	}

	private static bool xd8ab25d547517355(string xbcea506a33cf9111)
	{
		if (!(xbcea506a33cf9111 == "margin") && !(xbcea506a33cf9111 == "page"))
		{
			return xbcea506a33cf9111 == "text";
		}
		return true;
	}

	private static void xda393f86430bcf09(string xcd172a8263240bf1, object x2b4bceeb0893721a, x873451caae5ad4ae xd07ce4b74c5774a7)
	{
		if (x2b4bceeb0893721a is Border)
		{
			Border border = (Border)x2b4bceeb0893721a;
			if (border.LineStyle != 0)
			{
				xd07ce4b74c5774a7.x2307058321cdb62f(xcd172a8263240bf1);
				xd07ce4b74c5774a7.x943f6be3acf634db("type", xf4107e64edda7fac.xffd0441ff6d535d5(border.LineStyle));
				xd07ce4b74c5774a7.x943f6be3acf634db("width", xca004f56614e2431.xdbca7a004e2d3753(border.LineWidth * 8.0));
				xd07ce4b74c5774a7.x943f6be3acf634db("shadow", x64893267b789fd52.xdd13b76d78255522(border.Shadow, xc6e85c82d0d89508: false));
				xd07ce4b74c5774a7.x2dfde153f4ef96d0();
			}
		}
	}

	private static int xc29f054aa9ce07cb(ShapeBase x5770cdefd8931aa9)
	{
		object obj = x5770cdefd8931aa9.x048513c924d75f6b(327);
		if (obj != null)
		{
			int num = (int)obj;
			double xbcea506a33cf = (double)num / (double)x5770cdefd8931aa9.x133d653c1b9b01f2;
			return x4574ea26106f0edb.x091b250f00534aae(xbcea506a33cf);
		}
		return 10923;
	}
}
