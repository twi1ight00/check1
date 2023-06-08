using System;
using Aspose.Words;
using x0a300997a0b66409;
using x28925c9b27b37a46;
using x909757d9fd2dd6ae;
using xda075892eccab2ad;
using xf9a9481c3f63a419;

namespace x1a3e96f4b89a7a77;

internal class xce7f0abd6b3cc3be
{
	private xce7f0abd6b3cc3be()
	{
	}

	internal static void x6210059f049f0d48(Section xb32f8dd719a105db, xfe11bbc13ba649c3 xbdfb620b7167944b)
	{
		x7f77ea92be0d9042 xfc72d4c9b765cad = xb32f8dd719a105db.xfc72d4c9b765cad7;
		x873451caae5ad4ae xe1410f585439c7d = xbdfb620b7167944b.xe1410f585439c7d4;
		xe1410f585439c7d.x2307058321cdb62f("w:sectPr");
		if (xbdfb620b7167944b.x325f1926b78ae5cd)
		{
			xe1410f585439c7d.x943f6be3acf634db("w:rsidSect", xc1b08afa36bf580c.x0d28bf60e577f9e5(xfc72d4c9b765cad.xf7866f89640a29a3(2250)));
		}
		if (xfc72d4c9b765cad.x5fb16e270c21db2e != null)
		{
			xaa925c370fe2a33b(xb32f8dd719a105db, xbdfb620b7167944b);
			x7f77ea92be0d9042 x7f77ea92be0d = (x7f77ea92be0d9042)xfc72d4c9b765cad.x8b61531c8ea35b85();
			x7f77ea92be0d.xcb395027497bc067();
			x60e7c3c569225ff5(x7f77ea92be0d, x8ac36580a5b23125: false, xbdfb620b7167944b);
			xe1410f585439c7d.xd0c5f01ab55153ce(xfc72d4c9b765cad.x5fb16e270c21db2e, "w:sectPrChange", xbdfb620b7167944b.x28ee4b8b8f777b55());
			xe1410f585439c7d.x2307058321cdb62f("w:sectPr");
			if (xbdfb620b7167944b.x325f1926b78ae5cd)
			{
				xe1410f585439c7d.x943f6be3acf634db("w:rsidSect", xc1b08afa36bf580c.x0d28bf60e577f9e5(xfc72d4c9b765cad.xf7866f89640a29a3(2250)));
			}
			x60e7c3c569225ff5(xfc72d4c9b765cad, x8ac36580a5b23125: true, xbdfb620b7167944b);
			xe1410f585439c7d.x2dfde153f4ef96d0();
			xe1410f585439c7d.x44d8d13f25d44840();
		}
		else
		{
			xaa925c370fe2a33b(xb32f8dd719a105db, xbdfb620b7167944b);
			x60e7c3c569225ff5(xfc72d4c9b765cad, x8ac36580a5b23125: false, xbdfb620b7167944b);
		}
		xe1410f585439c7d.x2dfde153f4ef96d0("w:sectPr");
	}

	private static void x60e7c3c569225ff5(x4c1e058c67948d6a xe9707cb1ec88db49, bool x8ac36580a5b23125, xfe11bbc13ba649c3 xbdfb620b7167944b)
	{
		x873451caae5ad4ae xe1410f585439c7d = xbdfb620b7167944b.xe1410f585439c7d4;
		bool x325f1926b78ae5cd = xbdfb620b7167944b.x325f1926b78ae5cd;
		string text = null;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		string text5 = null;
		string text6 = null;
		string text7 = null;
		string text8 = null;
		string text9 = null;
		string text10 = null;
		string text11 = null;
		string text12 = null;
		string text13 = null;
		string xbcea506a33cf = null;
		string xbcea506a33cf2 = null;
		string xbcea506a33cf3 = null;
		Border border = null;
		Border border2 = null;
		Border border3 = null;
		Border border4 = null;
		string text14 = null;
		string text15 = null;
		string text16 = null;
		string text17 = null;
		string text18 = null;
		string text19 = null;
		string text20 = null;
		string text21 = null;
		object obj = null;
		string text22 = null;
		string text23 = null;
		object obj2 = null;
		x28980d9c5ec3f471 x28980d9c5ec3f = null;
		string text24 = null;
		string text25 = null;
		string text26 = null;
		string xbcea506a33cf4 = null;
		string xbcea506a33cf5 = null;
		object xbcea506a33cf6 = null;
		object xbcea506a33cf7 = null;
		object xbcea506a33cf8 = null;
		object xbcea506a33cf9 = null;
		object xbcea506a33cf10 = null;
		object xbcea506a33cf11 = null;
		for (int i = 0; i < xe9707cb1ec88db49.xd44988f225497f3a; i++)
		{
			int num = xe9707cb1ec88db49.xf15263674eb297bb(i);
			object obj3 = xe9707cb1ec88db49.x6d3720b962bd3112(i);
			switch (num)
			{
			case 2450:
				xbcea506a33cf6 = obj3;
				break;
			case 2410:
				xbcea506a33cf7 = obj3;
				break;
			case 2040:
				xbcea506a33cf8 = obj3;
				break;
			case 2390:
				xbcea506a33cf9 = !(bool)obj3;
				break;
			case 2100:
				xbcea506a33cf10 = obj3;
				break;
			case 2030:
				xbcea506a33cf4 = x93625b0e8808b0cc.xc934493ed158282d((SectionStart)obj3, x325f1926b78ae5cd);
				break;
			case 2340:
				xbcea506a33cf5 = x93625b0e8808b0cc.x77c962ff7ad4c74f((PageVerticalAlignment)obj3);
				break;
			case 2440:
				xbcea506a33cf11 = (x325f1926b78ae5cd ? xc62574be95c1c918.xfcf5289e205091d4((x6d434087bc06a37d)obj3) : x0beb84bbfae8adcf.xb0a19899404cb3ed((x6d434087bc06a37d)obj3));
				break;
			case 2430:
				text24 = x93625b0e8808b0cc.x1d700be36115046f((x704ea28be0f90278)obj3, x325f1926b78ae5cd);
				break;
			case 2170:
				text25 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj3);
				break;
			case 2420:
				text26 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj3);
				break;
			case 2260:
				text = xca004f56614e2431.x754c3a5f03a2ce84((int)obj3);
				break;
			case 2270:
				text2 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj3);
				break;
			case 2210:
				text3 = x93625b0e8808b0cc.x7a93588696d51464((Orientation)obj3);
				break;
			case 2090:
				text4 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj3);
				break;
			case 2300:
				text5 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj3);
				break;
			case 2290:
				text6 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj3);
				break;
			case 2310:
				text7 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj3);
				break;
			case 2280:
				text8 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj3);
				break;
			case 2320:
				text9 = xca004f56614e2431.x1d99ce1556ea7f1f(Convert.ToUInt32(obj3));
				break;
			case 2330:
				text10 = xca004f56614e2431.x1d99ce1556ea7f1f(Convert.ToUInt32(obj3));
				break;
			case 2312:
				text11 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj3);
				break;
			case 2070:
				text12 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj3);
				break;
			case 2080:
				text13 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj3);
				break;
			case 2230:
				xbcea506a33cf = ((!(bool)obj3) ? "back" : "front");
				break;
			case 2220:
				xbcea506a33cf2 = x93625b0e8808b0cc.x9ad683bb9269c7e6((PageBorderAppliesTo)obj3, x325f1926b78ae5cd);
				break;
			case 2240:
				xbcea506a33cf3 = x93625b0e8808b0cc.x8e3b97700f64ed41((PageBorderDistanceFrom)obj3);
				break;
			case 2130:
				border = (Border)obj3;
				break;
			case 2140:
				border2 = (Border)obj3;
				break;
			case 2150:
				border3 = (Border)obj3;
				break;
			case 2160:
				border4 = (Border)obj3;
				break;
			case 2120:
				text14 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj3);
				break;
			case 2180:
				text15 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj3 - 1);
				break;
			case 2400:
				text16 = xca004f56614e2431.x1d99ce1556ea7f1f(Convert.ToUInt32(obj3));
				break;
			case 2110:
				text17 = x93625b0e8808b0cc.x44022575e103c89c((LineNumberRestartMode)obj3, x325f1926b78ae5cd);
				break;
			case 2010:
				text18 = (x325f1926b78ae5cd ? xc62574be95c1c918.x235742abf07b06ea((NumberStyle)obj3) : x0beb84bbfae8adcf.x2e2d51c1b79b10ca((NumberStyle)obj3));
				break;
			case 2200:
				if ((bool)xe9707cb1ec88db49.xfe91eeeafcb3026a(2050))
				{
					text19 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj3);
				}
				break;
			case 2190:
				text20 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj3);
				break;
			case 2020:
				text21 = x93625b0e8808b0cc.x3d5f56a80ed53f22((xbdc85485688e2cf3)obj3, x325f1926b78ae5cd);
				break;
			case 2360:
				obj = obj3;
				break;
			case 2370:
				text22 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj3);
				break;
			case 2350:
				text23 = xca004f56614e2431.x754c3a5f03a2ce84((int)obj3);
				break;
			case 2060:
				obj2 = obj3;
				break;
			case 2380:
				x28980d9c5ec3f = (x28980d9c5ec3f471)obj3;
				break;
			}
		}
		if (!x8ac36580a5b23125)
		{
			if (text9 == null)
			{
				text9 = xca004f56614e2431.x754c3a5f03a2ce84((int)xfc72d4c9b765cad7.x0095b789d636f3ae(2320));
			}
			if (text10 == null)
			{
				text10 = xca004f56614e2431.x754c3a5f03a2ce84((int)xfc72d4c9b765cad7.x0095b789d636f3ae(2330));
			}
			if (text22 == null)
			{
				text22 = xca004f56614e2431.x754c3a5f03a2ce84((int)xfc72d4c9b765cad7.x0095b789d636f3ae(2370));
			}
		}
		xbdfb620b7167944b.xf65c32ef4443c2c5(xe9707cb1ec88db49, x28ee2f81ab05fedb: false);
		xe1410f585439c7d.x547195bcc386fe66("w:type", xbcea506a33cf4);
		xe1410f585439c7d.xc049ea80ee267201("w:pgSz", "w:w", text, "w:h", text2, "w:orient", text3, "w:code", text4);
		xe1410f585439c7d.xc049ea80ee267201("w:pgMar", "w:top", text5, "w:right", text6, "w:bottom", text7, "w:left", text8, "w:header", text9, "w:footer", text10, "w:gutter", text11);
		xe1410f585439c7d.xc049ea80ee267201("w:paperSrc", "w:first", text12, "w:other", text13);
		if (border != null || border2 != null || border3 != null || border4 != null)
		{
			xe1410f585439c7d.x2307058321cdb62f("w:pgBorders");
			xe1410f585439c7d.x943f6be3acf634db(x325f1926b78ae5cd ? "w:zOrder" : "w:z-order", xbcea506a33cf);
			xe1410f585439c7d.x943f6be3acf634db("w:display", xbcea506a33cf2);
			xe1410f585439c7d.x943f6be3acf634db(x325f1926b78ae5cd ? "w:offsetFrom" : "w:offset-from", xbcea506a33cf3);
			xe1410f585439c7d.x7bb3fbb369864bd2("w:top", border);
			xe1410f585439c7d.x7bb3fbb369864bd2("w:left", border2);
			xe1410f585439c7d.x7bb3fbb369864bd2("w:bottom", border3);
			xe1410f585439c7d.x7bb3fbb369864bd2("w:right", border4);
			xe1410f585439c7d.x2dfde153f4ef96d0();
		}
		xe1410f585439c7d.xc049ea80ee267201("w:lnNumType", x325f1926b78ae5cd ? "w:countBy" : "w:count-by", text14, "w:start", text15, "w:distance", text16, "w:restart", text17);
		xe1410f585439c7d.xc049ea80ee267201("w:pgNumType", "w:fmt", text18, "w:start", text19, x325f1926b78ae5cd ? "w:chapStyle" : "w:chap-style", text20, x325f1926b78ae5cd ? "w:chapSep" : "w:chap-sep", text21);
		if (xe1410f585439c7d.x4122f10182ac673a("w:cols", "w:num", text23, "w:sep", obj2, "w:space", text22, "w:equalWidth", obj))
		{
			if (x28980d9c5ec3f != null)
			{
				for (int j = 0; j < x28980d9c5ec3f.xd44988f225497f3a; j++)
				{
					xe1410f585439c7d.xc049ea80ee267201("w:col", "w:w", (x28980d9c5ec3f.get_xe6d4b1b411ed94b5(j).x7219de950d4b708a > 0) ? ((object)x28980d9c5ec3f.get_xe6d4b1b411ed94b5(j).x7219de950d4b708a) : null, "w:space", (x28980d9c5ec3f.get_xe6d4b1b411ed94b5(j).xbe8b68828bd16a4b > 0) ? ((object)x28980d9c5ec3f.get_xe6d4b1b411ed94b5(j).xbe8b68828bd16a4b) : null);
				}
			}
			xe1410f585439c7d.x2dfde153f4ef96d0();
		}
		xe1410f585439c7d.x547195bcc386fe66("w:formProt", xbcea506a33cf9);
		xe1410f585439c7d.x547195bcc386fe66("w:vAlign", xbcea506a33cf5);
		xe1410f585439c7d.x547195bcc386fe66("w:noEndnote", xbcea506a33cf10);
		xe1410f585439c7d.x547195bcc386fe66("w:titlePg", xbcea506a33cf8);
		xe1410f585439c7d.x547195bcc386fe66(x325f1926b78ae5cd ? "w:textDirection" : "w:textFlow", xbcea506a33cf11);
		xe1410f585439c7d.x547195bcc386fe66("w:bidi", xbcea506a33cf6);
		xe1410f585439c7d.x547195bcc386fe66("w:rtlGutter", xbcea506a33cf7);
		xe1410f585439c7d.xc049ea80ee267201("w:docGrid", "w:type", text24, x325f1926b78ae5cd ? "w:linePitch" : "w:line-pitch", text25, x325f1926b78ae5cd ? "w:charSpace" : "w:char-space", text26);
	}

	private static void xaa925c370fe2a33b(Section xb32f8dd719a105db, xfe11bbc13ba649c3 xbdfb620b7167944b)
	{
		x6075c9125351e131(xb32f8dd719a105db, HeaderFooterType.HeaderEven, xbdfb620b7167944b);
		x6075c9125351e131(xb32f8dd719a105db, HeaderFooterType.HeaderPrimary, xbdfb620b7167944b);
		x6075c9125351e131(xb32f8dd719a105db, HeaderFooterType.FooterEven, xbdfb620b7167944b);
		x6075c9125351e131(xb32f8dd719a105db, HeaderFooterType.FooterPrimary, xbdfb620b7167944b);
		x6075c9125351e131(xb32f8dd719a105db, HeaderFooterType.HeaderFirst, xbdfb620b7167944b);
		x6075c9125351e131(xb32f8dd719a105db, HeaderFooterType.FooterFirst, xbdfb620b7167944b);
	}

	private static void x6075c9125351e131(Section xb32f8dd719a105db, HeaderFooterType xa685fef1a31f5d4d, xfe11bbc13ba649c3 xbdfb620b7167944b)
	{
		HeaderFooter headerFooter = xb32f8dd719a105db.HeadersFooters[xa685fef1a31f5d4d];
		if (headerFooter != null)
		{
			xbdfb620b7167944b.x6075c9125351e131(headerFooter);
		}
	}
}
