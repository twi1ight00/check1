using System;
using System.Text;
using Aspose.Words;
using Aspose.Words.Drawing;
using x28925c9b27b37a46;
using x556d8f9846e43329;

namespace x639ad3f66698fe1b;

internal class xb9e5964dad84ecc2
{
	private readonly x21f0d20d41203be1 x8cedcaa9a62c6e39;

	private bool xa65b4d57fd0e01c1;

	private bool xfc4a1905104cf6a9;

	private int x7f3c86b3fa6e7e46;

	private int x736beab29c5c4a88;

	private x84bbacdc1fc0efd2 xa05ac4bc2dfd6d7b;

	private x8fdc64e3f5579ea8 xadcebaff63013df7;

	internal static bool x492f529cee830a40;

	private xbfd162a6d47f59a4 xe1410f585439c7d4 => x8cedcaa9a62c6e39.xe1410f585439c7d4;

	internal xb9e5964dad84ecc2(x21f0d20d41203be1 context)
	{
		x8cedcaa9a62c6e39 = context;
	}

	internal void x6210059f049f0d48(x1a78664fa10a3755 x062aae8c9613eeaa, bool x00ce61b8358bb4cc, bool x02cadcecef04989f)
	{
		if (x062aae8c9613eeaa.x0f53f53f15b61ef5)
		{
			x1a78664fa10a3755 x1a78664fa10a = (x1a78664fa10a3755)x062aae8c9613eeaa.x8b61531c8ea35b85();
			x1a78664fa10a.xcb395027497bc067();
			x60e7c3c569225ff5(x1a78664fa10a, x00ce61b8358bb4cc, x02cadcecef04989f);
			xac55650dda4d602e(x062aae8c9613eeaa);
		}
		else
		{
			x60e7c3c569225ff5(x062aae8c9613eeaa, x00ce61b8358bb4cc, x02cadcecef04989f);
		}
	}

	private void x60e7c3c569225ff5(x1a78664fa10a3755 x062aae8c9613eeaa, bool x00ce61b8358bb4cc, bool x02cadcecef04989f)
	{
		xa65b4d57fd0e01c1 = x02cadcecef04989f;
		xfc4a1905104cf6a9 = false;
		x7f3c86b3fa6e7e46 = 0;
		x736beab29c5c4a88 = 0;
		xa05ac4bc2dfd6d7b = new x84bbacdc1fc0efd2(0, LineSpacingRule.Multiple);
		ParagraphAlignment paragraphAlignment = ParagraphAlignment.Left;
		xadcebaff63013df7 = x8fdc64e3f5579ea8.x2bca50d746ec73b2;
		int[] xc107b75a85428bd = xa0d3611565b2a1f2.x339a4889e0bd1111(x062aae8c9613eeaa, xbcea506a33cf9111: true);
		for (int i = 0; i < x062aae8c9613eeaa.xd44988f225497f3a; i++)
		{
			int num = x062aae8c9613eeaa.xf15263674eb297bb(i);
			if (xa65b4d57fd0e01c1 && !xb17afad2761aac92(num))
			{
				continue;
			}
			object obj = x062aae8c9613eeaa.x6d3720b962bd3112(i);
			switch (num)
			{
			case 1510:
				xadcebaff63013df7 = (x8fdc64e3f5579ea8)obj;
				break;
			case 1410:
				xe1410f585439c7d4.xaf432784cda9acfa("\\hyphpar", !(bool)obj);
				break;
			case 1130:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\noline", (bool)obj);
				break;
			case 1470:
				if ((bool)obj)
				{
					xe1410f585439c7d4.xb8aea59edd4060ce("\\widctlpar", xbcea506a33cf9111: true);
				}
				else
				{
					xe1410f585439c7d4.xb8aea59edd4060ce("\\nowidctlpar", xbcea506a33cf9111: true);
				}
				break;
			case 1060:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\pagebb", (bool)obj);
				break;
			case 1030:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\sbys", (bool)obj);
				break;
			case 1000:
				if (x00ce61b8358bb4cc)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913("\\s", (int)obj);
				}
				break;
			case 1170:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\fi", (int)obj);
				break;
			case 1200:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\sb", (int)obj);
				break;
			case 1220:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\sa", (int)obj);
				break;
			case 1205:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\lisb", (int)obj);
				break;
			case 1225:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\lisa", (int)obj);
				break;
			case 1165:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\culi", (int)obj);
				break;
			case 1155:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\curi", (int)obj);
				break;
			case 1175:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\cufi", (int)obj);
				break;
			case 1210:
				xe1410f585439c7d4.x5fdd0595d40cfe6d("\\sbauto", (bool)obj);
				break;
			case 1230:
				xe1410f585439c7d4.x5fdd0595d40cfe6d("\\saauto", (bool)obj);
				break;
			case 1650:
				xa05ac4bc2dfd6d7b = (x84bbacdc1fc0efd2)obj;
				break;
			case 1260:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\nosnaplinegrid", !(bool)obj);
				break;
			case 1090:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\nooverflow", !(bool)obj);
				break;
			case 1080:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\nowwrap", !(bool)obj);
				break;
			case 1240:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\aspalpha", (bool)obj);
				break;
			case 1100:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\toplinepunct", (bool)obj);
				break;
			case 1250:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\aspnum", (bool)obj);
				break;
			case 1270:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\adjustright", (bool)obj);
				break;
			case 1580:
			{
				int num2 = (int)obj;
				x8cedcaa9a62c6e39.x05d5755b32029482.xd6b6ed77479ef68c(num2);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\pararsid", num2);
				break;
			}
			case 1040:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\keep", (bool)obj);
				break;
			case 1050:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\keepn", (bool)obj);
				break;
			case 1280:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\outlinelevel", Convert.ToInt32(obj));
				break;
			case 1140:
				x5c701860612ba96c((TabStopCollection)obj);
				break;
			case 1350:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\brdrt");
				x4bf0725a1c29dbf0.x6210059f049f0d48(x8cedcaa9a62c6e39, (Border)obj);
				break;
			case 1370:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\brdrb");
				x4bf0725a1c29dbf0.x6210059f049f0d48(x8cedcaa9a62c6e39, (Border)obj);
				break;
			case 1360:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\brdrl");
				x4bf0725a1c29dbf0.x6210059f049f0d48(x8cedcaa9a62c6e39, (Border)obj);
				break;
			case 1380:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\brdrr");
				x4bf0725a1c29dbf0.x6210059f049f0d48(x8cedcaa9a62c6e39, (Border)obj);
				break;
			case 1390:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\brdrbtw");
				x4bf0725a1c29dbf0.x6210059f049f0d48(x8cedcaa9a62c6e39, (Border)obj);
				break;
			case 1400:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\brdrbar");
				x4bf0725a1c29dbf0.x6210059f049f0d48(x8cedcaa9a62c6e39, (Border)obj);
				break;
			case 1460:
			{
				Shading shading = (Shading)obj;
				xf2c041437cd4ab14.x6210059f049f0d48(x8cedcaa9a62c6e39, shading, "\\shading", "\\cbpat", "\\cfpat", xcb1f99bcd961367e.xac5a7a97f8b14aea(shading.Texture));
				break;
			}
			case 1120:
			{
				int xbcea506a33cf = (int)obj;
				xe1410f585439c7d4.x4d14ee33f46b5913("\\ls", xbcea506a33cf, 0);
				break;
			}
			case 1110:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\ilvl", (int)obj);
				break;
			case 1125:
				x72bc48dae6f74342((x978620a99b6d5014)obj);
				break;
			case 1320:
			{
				RelativeHorizontalPosition x5658014337e42c2d = x062aae8c9613eeaa.x5658014337e42c2d;
				if (x5658014337e42c2d != RelativeHorizontalPosition.Column)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913(xcb1f99bcd961367e.xd2b15bd56bbd56f2(x5658014337e42c2d));
				}
				break;
			}
			case 1330:
			{
				RelativeVerticalPosition x4695f72379aabf = x062aae8c9613eeaa.x4695f72379aabf86;
				xe1410f585439c7d4.x4d14ee33f46b5913(xcb1f99bcd961367e.x81ebc6d588b0838e(x4695f72379aabf));
				break;
			}
			case 1520:
				if (x062aae8c9613eeaa.x6f6877b222ed4153)
				{
					xe1410f585439c7d4.x5fdd0595d40cfe6d("\\abslock", (bool)obj);
				}
				break;
			case 1340:
				if (x062aae8c9613eeaa.x6f6877b222ed4153)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913(xa0d3611565b2a1f2.xa1827014a0d63ae0((WrapType)obj));
				}
				break;
			case 1500:
				if (x062aae8c9613eeaa.x6f6877b222ed4153)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913("\\dfrmtxtx", (int)obj);
				}
				break;
			case 1490:
				if (x062aae8c9613eeaa.x6f6877b222ed4153)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913("\\dfrmtxty", (int)obj);
				}
				break;
			case 1480:
				if (x062aae8c9613eeaa.x6f6877b222ed4153)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913(xcb1f99bcd961367e.xa3840404cf5718d4((TextOrientation)obj));
				}
				break;
			case 1660:
				xe1410f585439c7d4.x5fdd0595d40cfe6d("\\absnoovrlp", (bool)obj);
				break;
			case 1440:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\dropcapt", Convert.ToInt32(obj), 0);
				break;
			case 1450:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\dropcapli", (int)obj);
				break;
			case 1022:
				if ((bool)obj)
				{
					xe1410f585439c7d4.x4d14ee33f46b5913("\\contextualspace");
				}
				break;
			case 1560:
				xfc4a1905104cf6a9 = (bool)obj;
				break;
			case 1160:
				x7f3c86b3fa6e7e46 = (int)obj;
				break;
			case 1150:
				x736beab29c5c4a88 = (int)obj;
				break;
			case 1020:
				paragraphAlignment = (ParagraphAlignment)obj;
				break;
			case 1070:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\nocwrap", !(bool)obj);
				break;
			case 1145:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\indmirror", (bool)obj);
				break;
			default:
				_ = x492f529cee830a40;
				break;
			case 1290:
			case 1292:
			case 1300:
			case 1302:
			case 1310:
			case 1420:
			case 1430:
			case 10010:
				break;
			}
		}
		if (!x02cadcecef04989f && !x8cedcaa9a62c6e39.xf57de0fd37d5e97d.ExportCompactSize)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913(xfc4a1905104cf6a9 ? "\\rtlpar" : "\\ltrpar");
		}
		xbb96b8fc57ad32d3();
		if (!x02cadcecef04989f)
		{
			if (x062aae8c9613eeaa.xcedf9c82728ad579)
			{
				paragraphAlignment = x1a78664fa10a3755.xbf8ba56877f02689(paragraphAlignment);
			}
			xe1410f585439c7d4.x4d14ee33f46b5913(xcb1f99bcd961367e.xdd639997a0028526(paragraphAlignment));
			xe1410f585439c7d4.x4d14ee33f46b5913(xcb1f99bcd961367e.x22e4dfafa96157e6(xadcebaff63013df7));
			x0903e691b4eb3676();
			x61c305191003eb85(x062aae8c9613eeaa);
			x01ae8708f1a38752(x062aae8c9613eeaa);
		}
		xa0d3611565b2a1f2.x60367ca2e6e44bc3(x062aae8c9613eeaa, xc107b75a85428bd);
	}

	private void xac55650dda4d602e(x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		x5fb16e270c21db2e x5fb16e270c21db2e = x062aae8c9613eeaa.x5fb16e270c21db2e;
		xe1410f585439c7d4.x4d14ee33f46b5913("\\prauth", x8cedcaa9a62c6e39.x2086e697b5620586.xd6b6ed77479ef68c(x5fb16e270c21db2e.xb063bbfcfeade526));
		xe1410f585439c7d4.x4d14ee33f46b5913("\\prdate", xa0d3611565b2a1f2.x7c734cfcbb14646a(x5fb16e270c21db2e.x242851e6278ed355));
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		xe1410f585439c7d4.xee60bff2900a72f2("\\*\\oldpprops");
		xe1410f585439c7d4.x4d14ee33f46b5913("\\pard");
		x60e7c3c569225ff5(x062aae8c9613eeaa, x00ce61b8358bb4cc: true, x02cadcecef04989f: false);
		xe1410f585439c7d4.xc8a13a52db0580ae();
	}

	private void xbb96b8fc57ad32d3()
	{
		xe1410f585439c7d4.x4d14ee33f46b5913("\\li", xfc4a1905104cf6a9 ? x736beab29c5c4a88 : x7f3c86b3fa6e7e46);
		xe1410f585439c7d4.x4d14ee33f46b5913("\\lin", x7f3c86b3fa6e7e46);
		if (!xa65b4d57fd0e01c1)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913("\\ri", xfc4a1905104cf6a9 ? x7f3c86b3fa6e7e46 : x736beab29c5c4a88);
			xe1410f585439c7d4.x4d14ee33f46b5913("\\rin", x736beab29c5c4a88);
		}
	}

	private void x0903e691b4eb3676()
	{
		if (xa05ac4bc2dfd6d7b.xd2f68ee6f47e9dfb != 0)
		{
			switch (xa05ac4bc2dfd6d7b.xea9485ec61071863)
			{
			case LineSpacingRule.Exactly:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\sl", -xa05ac4bc2dfd6d7b.xd2f68ee6f47e9dfb);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\slmult0");
				break;
			case LineSpacingRule.Multiple:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\sl", xa05ac4bc2dfd6d7b.xd2f68ee6f47e9dfb);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\slmult1");
				break;
			default:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\sl", xa05ac4bc2dfd6d7b.xd2f68ee6f47e9dfb);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\slmult0");
				break;
			}
		}
	}

	private void x5c701860612ba96c(TabStopCollection x5ffa547f17ecad54)
	{
		for (int i = 0; i < x5ffa547f17ecad54.Count; i++)
		{
			TabStop tabStop = x5ffa547f17ecad54[i];
			switch (tabStop.Alignment)
			{
			case TabAlignment.Right:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\tqr");
				break;
			case TabAlignment.Center:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\tqc");
				break;
			case TabAlignment.Decimal:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\tqdec");
				break;
			}
			xe1410f585439c7d4.xb8aea59edd4060ce("\\jclisttab", xa65b4d57fd0e01c1);
			xe1410f585439c7d4.x4d14ee33f46b5913(xcb1f99bcd961367e.xaad25f7a25f501c8(tabStop.Leader));
			xe1410f585439c7d4.x4d14ee33f46b5913((tabStop.Alignment == TabAlignment.Bar) ? "\\tb" : "\\tx", tabStop.PositionTwips);
		}
	}

	private void x61c305191003eb85(x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		x2da87913451ec5ec(x062aae8c9613eeaa);
		xf52f5bef5370d3e1(x062aae8c9613eeaa);
	}

	private void x2da87913451ec5ec(x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		if (x062aae8c9613eeaa.x608d0b033d69391d)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913((x062aae8c9613eeaa.x07f0fe00ef8c8a88 < 0) ? "\\posnegx" : "\\posx", x062aae8c9613eeaa.x07f0fe00ef8c8a88);
		}
		if (x062aae8c9613eeaa.x94cd2c49f6b54b50 && x062aae8c9613eeaa.x1fd2932b74d8b051 != 0)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913(xcb1f99bcd961367e.x83b1ccc4b4899faf(x062aae8c9613eeaa.x1fd2932b74d8b051));
		}
	}

	private void xf52f5bef5370d3e1(x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		if (x062aae8c9613eeaa.x35918784dcf6eda5)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913((x062aae8c9613eeaa.x2c651fc94bf42334 < 0) ? "\\posnegy" : "\\posy", x062aae8c9613eeaa.x2c651fc94bf42334);
		}
		if (x062aae8c9613eeaa.x4328589875ed34c8 && x062aae8c9613eeaa.x55953052a01f3b15 != 0)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913(xcb1f99bcd961367e.x2c1d37865de363ef(x062aae8c9613eeaa.x55953052a01f3b15));
		}
	}

	private void x01ae8708f1a38752(x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		if (!x062aae8c9613eeaa.x6f6877b222ed4153)
		{
			return;
		}
		if (x062aae8c9613eeaa.xd7883654e283dfbb)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913("\\absw", x062aae8c9613eeaa.xa3c274715c3e6abe);
		}
		if (x062aae8c9613eeaa.x4ee23c2cb0444455)
		{
			switch (x062aae8c9613eeaa.x0774245c2a920aee ? x062aae8c9613eeaa.xc055999463b0ae9a : HeightRule.Auto)
			{
			case HeightRule.AtLeast:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\absh", x062aae8c9613eeaa.xbd8332bdab045b05);
				break;
			case HeightRule.Exactly:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\absh", -x062aae8c9613eeaa.xbd8332bdab045b05);
				break;
			default:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\absh", 0);
				break;
			}
		}
	}

	private void x72bc48dae6f74342(x978620a99b6d5014 xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 == null)
		{
			return;
		}
		xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrauth", x8cedcaa9a62c6e39.x2086e697b5620586.xd6b6ed77479ef68c(xbcea506a33cf9111.xb063bbfcfeade526));
		xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrdate", xa0d3611565b2a1f2.x7c734cfcbb14646a(xbcea506a33cf9111.x242851e6278ed355));
		if (xbcea506a33cf9111.x55e2dcfc986cb10b)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrnot1");
		}
		else if (xbcea506a33cf9111.x22f16e8bb3c02a0b)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrstart0");
			xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrxst", xbcea506a33cf9111.x5051a4a3b273ffce.Length & 0xFF);
			xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrxst", (xbcea506a33cf9111.x5051a4a3b273ffce.Length >> 8) & 0xFF);
			byte[] bytes = Encoding.Unicode.GetBytes(xbcea506a33cf9111.x5051a4a3b273ffce);
			for (int i = 0; i < bytes.Length; i++)
			{
				xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrxst", bytes[i]);
			}
			xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrstop", bytes.Length + 2);
			xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrstart1");
			for (int j = 0; j < 9; j++)
			{
				xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrrgb", xbcea506a33cf9111.x044891ce086d094b[j]);
			}
			xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrstop", 9);
			xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrstart2");
			for (int k = 0; k < 9; k++)
			{
				int num = Convert.ToInt32(xbcea506a33cf9111.x7e30db41abd34a71[k]);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrnfc", num & 0xFF);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrnfc", (num >> 8) & 0xFF);
			}
			xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrstop", 18);
			xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrstart3");
			for (int l = 0; l < 9; l++)
			{
				int num2 = xbcea506a33cf9111.x632f31cdeda76ff9[l];
				xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrpnbr", num2 & 0xFF);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrpnbr", (num2 >> 8) & 0xFF);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrpnbr", (num2 >> 16) & 0xFF);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrpnbr", (num2 >> 24) & 0xFF);
			}
			xe1410f585439c7d4.x4d14ee33f46b5913("\\pnrstop", 36);
		}
	}

	private static bool xb17afad2761aac92(int xad5ee812e0b28f28)
	{
		if (xad5ee812e0b28f28 == 1140 || xad5ee812e0b28f28 == 1160 || xad5ee812e0b28f28 == 1170)
		{
			return true;
		}
		return false;
	}
}
