using System;
using Aspose.Words;
using Aspose.Words.Drawing;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xbe829a00a7a86dc3;
using xda075892eccab2ad;

namespace x1a3e96f4b89a7a77;

internal class x2aa41ce9e83be7cd
{
	private const int xe862e9cded1a02e4 = -31680;

	private x2aa41ce9e83be7cd()
	{
	}

	internal static void x6210059f049f0d48(x1a78664fa10a3755 x062aae8c9613eeaa, xfe11bbc13ba649c3 xbdfb620b7167944b)
	{
		if (xd29409f2ba9889e2(x062aae8c9613eeaa, xbdfb620b7167944b))
		{
			xbdfb620b7167944b.xe1410f585439c7d4.x2dfde153f4ef96d0();
		}
	}

	internal static bool xd29409f2ba9889e2(x1a78664fa10a3755 x062aae8c9613eeaa, xfe11bbc13ba649c3 xbdfb620b7167944b)
	{
		if (x062aae8c9613eeaa == null || x062aae8c9613eeaa.xd44988f225497f3a == 0)
		{
			return false;
		}
		x873451caae5ad4ae xe1410f585439c7d = xbdfb620b7167944b.xe1410f585439c7d4;
		if (x062aae8c9613eeaa.x5fb16e270c21db2e != null)
		{
			xe1410f585439c7d.x2307058321cdb62f("w:pPr");
			x7f77ea92be0d9042 x7f77ea92be0d = (x7f77ea92be0d9042)x062aae8c9613eeaa.x8b61531c8ea35b85();
			x7f77ea92be0d.xcb395027497bc067();
			x60e7c3c569225ff5(x7f77ea92be0d, x87564afa00f612a1: false, xbdfb620b7167944b, x79788295c2ba4da1: false);
			xe1410f585439c7d.xd0c5f01ab55153ce(x062aae8c9613eeaa.x5fb16e270c21db2e, "w:pPrChange", xbdfb620b7167944b.x28ee4b8b8f777b55());
			xe1410f585439c7d.x2307058321cdb62f("w:pPr");
			x60e7c3c569225ff5(x062aae8c9613eeaa, x87564afa00f612a1: false, xbdfb620b7167944b, x79788295c2ba4da1: true);
			xe1410f585439c7d.x2dfde153f4ef96d0("w:pPr");
			xe1410f585439c7d.x44d8d13f25d44840();
			return true;
		}
		return x60e7c3c569225ff5(x062aae8c9613eeaa, x87564afa00f612a1: true, xbdfb620b7167944b, x79788295c2ba4da1: false);
	}

	private static bool x60e7c3c569225ff5(x7f77ea92be0d9042 xe9707cb1ec88db49, bool x87564afa00f612a1, xfe11bbc13ba649c3 xbdfb620b7167944b, bool x79788295c2ba4da1)
	{
		bool x325f1926b78ae5cd = xbdfb620b7167944b.x325f1926b78ae5cd;
		x873451caae5ad4ae xe1410f585439c7d = xbdfb620b7167944b.xe1410f585439c7d4;
		int num = 0;
		string text = null;
		object xbcea506a33cf = null;
		object xbcea506a33cf2 = null;
		object xbcea506a33cf3 = null;
		string text2 = null;
		object obj = null;
		object obj2 = null;
		object obj3 = null;
		object obj4 = null;
		object obj5 = null;
		string text3 = null;
		string text4 = null;
		string text5 = null;
		object obj6 = null;
		string text6 = null;
		object obj7 = null;
		string text7 = null;
		string text8 = null;
		object obj8 = null;
		object xbcea506a33cf4 = null;
		object obj9 = null;
		object obj10 = null;
		object xbcea506a33cf5 = null;
		Border border = null;
		Border border2 = null;
		Border border3 = null;
		Border border4 = null;
		Border border5 = null;
		Border border6 = null;
		Shading x12b7f8e5698b30a = null;
		TabStopCollection xc06f388a56e1a8e = null;
		object xbcea506a33cf6 = null;
		object xbcea506a33cf7 = null;
		object xbcea506a33cf8 = null;
		object xbcea506a33cf9 = null;
		object xbcea506a33cf10 = null;
		object xbcea506a33cf11 = null;
		object xbcea506a33cf12 = null;
		object xbcea506a33cf13 = null;
		object xbcea506a33cf14 = null;
		object xbcea506a33cf15 = null;
		object obj11 = null;
		object obj12 = null;
		object obj13 = null;
		object obj14 = null;
		object obj15 = null;
		object obj16 = null;
		object obj17 = null;
		string text9 = null;
		object obj18 = null;
		object obj19 = null;
		object obj20 = null;
		object obj21 = null;
		object obj22 = null;
		object obj23 = null;
		object obj24 = null;
		object obj25 = null;
		object obj26 = null;
		object xbcea506a33cf16 = null;
		object xbcea506a33cf17 = null;
		string xbcea506a33cf18 = null;
		string xbcea506a33cf19 = null;
		string xbcea506a33cf20 = null;
		object xbcea506a33cf21 = null;
		x978620a99b6d5014 x978620a99b6d = null;
		for (int i = 0; i < xe9707cb1ec88db49.xd44988f225497f3a; i++)
		{
			int num2 = xe9707cb1ec88db49.xf15263674eb297bb(i);
			object obj27 = xe9707cb1ec88db49.x6d3720b962bd3112(i);
			num++;
			switch (num2)
			{
			case 1000:
				if ((int)obj27 != 0)
				{
					text = xbdfb620b7167944b.x7af082eaf8e0caa4((int)obj27);
				}
				else
				{
					text = null;
					num--;
				}
				if (text != null)
				{
					Style style = xbdfb620b7167944b.x2c8c6741422a1298.Styles.x1976fb6958cf7237((int)obj27, x988fcf605f8efa7e: false);
					if (style.Type == StyleType.List || xe1410f585439c7d.xa35b0cf71c822836)
					{
						text = null;
						num--;
					}
				}
				break;
			case 1050:
				xbcea506a33cf = obj27;
				break;
			case 1040:
				xbcea506a33cf2 = obj27;
				break;
			case 1060:
				xbcea506a33cf3 = obj27;
				break;
			case 1440:
				text2 = x92309521ce1fc453.xd937af05f4d45eb5((DropCapPosition)obj27);
				break;
			case 1450:
				obj = obj27;
				break;
			case 1310:
				obj2 = obj27;
				break;
			case 1420:
				obj3 = obj27;
				break;
			case 1500:
				obj5 = obj27;
				break;
			case 1490:
				obj4 = obj27;
				break;
			case 1340:
				text3 = x92309521ce1fc453.x6c8d42123b0d0381((WrapType)obj27, x325f1926b78ae5cd);
				break;
			case 1320:
				text4 = x92309521ce1fc453.x14e082375ba0c07c((RelativeHorizontalPosition)obj27);
				break;
			case 1330:
				text5 = x92309521ce1fc453.xd28acd82ad3fd5e3((RelativeVerticalPosition)obj27);
				break;
			case 1292:
				obj6 = obj27;
				break;
			case 1290:
				text6 = x92309521ce1fc453.x9617344359c63dd2((HorizontalAlignment)obj27);
				break;
			case 1302:
				obj7 = obj27;
				break;
			case 1300:
				text7 = x92309521ce1fc453.xf7b3d51063ad99cc((VerticalAlignment)obj27);
				break;
			case 1430:
				text8 = x92309521ce1fc453.xe450fbc63c45b368((HeightRule)obj27, x325f1926b78ae5cd);
				break;
			case 1520:
				obj8 = obj27;
				break;
			case 1470:
				xbcea506a33cf4 = obj27;
				break;
			case 1120:
				obj9 = obj27;
				break;
			case 1110:
				obj10 = obj27;
				break;
			case 1130:
				xbcea506a33cf5 = obj27;
				break;
			case 1400:
				border6 = (Border)obj27;
				break;
			case 1390:
				border5 = (Border)obj27;
				break;
			case 1370:
				border3 = (Border)obj27;
				break;
			case 1360:
				border2 = (Border)obj27;
				break;
			case 1380:
				border4 = (Border)obj27;
				break;
			case 1350:
				border = (Border)obj27;
				break;
			case 1460:
				x12b7f8e5698b30a = (Shading)obj27;
				break;
			case 1140:
				xc06f388a56e1a8e = (TabStopCollection)obj27;
				break;
			case 1410:
				xbcea506a33cf6 = obj27;
				break;
			case 1070:
				xbcea506a33cf7 = obj27;
				break;
			case 1080:
				xbcea506a33cf8 = obj27;
				break;
			case 1090:
				xbcea506a33cf9 = obj27;
				break;
			case 1100:
				xbcea506a33cf10 = obj27;
				break;
			case 1240:
				xbcea506a33cf11 = obj27;
				break;
			case 1250:
				xbcea506a33cf12 = obj27;
				break;
			case 1560:
				xbcea506a33cf13 = obj27;
				break;
			case 1270:
				xbcea506a33cf14 = obj27;
				break;
			case 1260:
				xbcea506a33cf15 = obj27;
				break;
			case 1220:
				obj14 = obj27;
				break;
			case 1225:
				obj15 = obj27;
				break;
			case 1230:
				obj16 = obj27;
				break;
			case 1200:
				obj11 = obj27;
				break;
			case 1205:
				obj12 = obj27;
				break;
			case 1210:
				obj13 = obj27;
				break;
			case 1650:
			{
				x84bbacdc1fc0efd2 x84bbacdc1fc0efd = (x84bbacdc1fc0efd2)obj27;
				obj17 = x84bbacdc1fc0efd.xd2f68ee6f47e9dfb;
				text9 = x92309521ce1fc453.x41319507d42a4e5c(x84bbacdc1fc0efd.xea9485ec61071863, x325f1926b78ae5cd);
				break;
			}
			case 1145:
				obj18 = obj27;
				break;
			case 1170:
				if ((int)obj27 < 0)
				{
					obj21 = -(int)obj27;
				}
				else
				{
					obj22 = obj27;
				}
				break;
			case 1160:
				obj19 = obj27;
				break;
			case 1150:
				obj20 = obj27;
				break;
			case 1175:
				if ((int)obj27 < 0)
				{
					obj25 = -(int)obj27;
				}
				else
				{
					obj26 = obj27;
				}
				break;
			case 1165:
				obj23 = obj27;
				break;
			case 1155:
				obj24 = obj27;
				break;
			case 1022:
				xbcea506a33cf16 = obj27;
				break;
			case 1660:
				xbcea506a33cf17 = obj27;
				break;
			case 1020:
				xbcea506a33cf18 = x92309521ce1fc453.x443159ac7b83b091((ParagraphAlignment)obj27);
				break;
			case 1480:
				xbcea506a33cf19 = x72a0c846678ecaf9.x5d29ab24a0be9aab((TextOrientation)obj27, x325f1926b78ae5cd);
				break;
			case 1510:
				xbcea506a33cf20 = x92309521ce1fc453.xc173fe801c66caab((x8fdc64e3f5579ea8)obj27);
				break;
			case 1280:
				xbcea506a33cf21 = (int)obj27;
				break;
			case 1125:
				if (!x79788295c2ba4da1)
				{
					x978620a99b6d = (x978620a99b6d5014)obj27;
					if (!x978620a99b6d.x8c84b6fad60c11f5)
					{
						x978620a99b6d = null;
						num--;
					}
				}
				break;
			case 10010:
				num--;
				break;
			default:
				num--;
				break;
			}
		}
		if (num == 0)
		{
			return false;
		}
		if (x87564afa00f612a1)
		{
			xe1410f585439c7d.x2307058321cdb62f("w:pPr");
		}
		xe1410f585439c7d.x547195bcc386fe66("w:pStyle", text);
		xe1410f585439c7d.x547195bcc386fe66("w:keepNext", xbcea506a33cf);
		xe1410f585439c7d.x547195bcc386fe66("w:keepLines", xbcea506a33cf2);
		xe1410f585439c7d.x547195bcc386fe66("w:pageBreakBefore", xbcea506a33cf3);
		if (x0d299f323d241756.x5959bccb67bbf051(text6))
		{
			obj6 = null;
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text7))
		{
			obj7 = null;
		}
		xe1410f585439c7d.xc049ea80ee267201("w:framePr", x325f1926b78ae5cd ? "w:dropCap" : "w:drop-cap", text2, "w:lines", obj, "w:w", obj2, "w:h", obj3, x325f1926b78ae5cd ? "w:hRule" : "w:h-rule", text8, x325f1926b78ae5cd ? "w:hSpace" : "w:hspace", obj5, x325f1926b78ae5cd ? "w:vSpace" : "w:vspace", obj4, "w:wrap", text3, x325f1926b78ae5cd ? "w:vAnchor" : "w:vanchor", text5, x325f1926b78ae5cd ? "w:hAnchor" : "w:hanchor", text4, "w:x", obj6, x325f1926b78ae5cd ? "w:xAlign" : "w:x-align", text6, "w:y", obj7, x325f1926b78ae5cd ? "w:yAlign" : "w:y-align", text7, x325f1926b78ae5cd ? "w:anchorLock" : "w:anchor-lock", obj8);
		xe1410f585439c7d.x547195bcc386fe66("w:widowControl", xbcea506a33cf4);
		bool flag = obj10 != null;
		bool flag2 = obj9 != null;
		string text10 = (x325f1926b78ae5cd ? null : ((x4f037d20d40d8390)xbdfb620b7167944b).x8204ba5be8a516ae);
		string text11 = (x325f1926b78ae5cd ? null : ((x4f037d20d40d8390)xbdfb620b7167944b).x412ac5cf0bbdaed3);
		bool flag3 = x978620a99b6d?.x8c84b6fad60c11f5 ?? false;
		if (flag || flag2 || flag3 || text10 != null || text11 != null)
		{
			xe1410f585439c7d.x2307058321cdb62f(x325f1926b78ae5cd ? "w:numPr" : "w:listPr");
			if (flag)
			{
				xe1410f585439c7d.x547195bcc386fe66("w:ilvl", obj10);
			}
			if (flag2)
			{
				xe1410f585439c7d.x547195bcc386fe66(x325f1926b78ae5cd ? "w:numId" : "w:ilfo", obj9);
			}
			if (text10 != null)
			{
				xe1410f585439c7d.x547195bcc386fe66("wx:t", text10);
			}
			if (text11 != null)
			{
				xe1410f585439c7d.x547195bcc386fe66("wx:font", text11);
			}
			if (flag3)
			{
				xe1410f585439c7d.xb24134df8aeb5772(x978620a99b6d, xbdfb620b7167944b.x28ee4b8b8f777b55());
			}
			xe1410f585439c7d.x2dfde153f4ef96d0();
		}
		xe1410f585439c7d.x547195bcc386fe66(x325f1926b78ae5cd ? "w:suppressLineNumbers" : "w:supressLineNumbers", xbcea506a33cf5);
		xe1410f585439c7d.xa653462abd146df5("w:pBdr", "w:top", border, "w:left", border2, "w:bottom", border3, "w:right", border4, "w:between", border5, "w:bar", border6);
		xe1410f585439c7d.xbcea76c28b5e9461(x12b7f8e5698b30a);
		xaa87698597995c87(xc06f388a56e1a8e, xbdfb620b7167944b);
		xe1410f585439c7d.x547195bcc386fe66("w:suppressAutoHyphens", xbcea506a33cf6);
		xe1410f585439c7d.x547195bcc386fe66("w:kinsoku", xbcea506a33cf7);
		xe1410f585439c7d.x547195bcc386fe66("w:wordWrap", xbcea506a33cf8);
		xe1410f585439c7d.x547195bcc386fe66("w:overflowPunct", xbcea506a33cf9);
		xe1410f585439c7d.x547195bcc386fe66("w:topLinePunct", xbcea506a33cf10);
		xe1410f585439c7d.x547195bcc386fe66("w:autoSpaceDE", xbcea506a33cf11);
		xe1410f585439c7d.x547195bcc386fe66("w:autoSpaceDN", xbcea506a33cf12);
		xe1410f585439c7d.x547195bcc386fe66("w:bidi", xbcea506a33cf13);
		xe1410f585439c7d.x547195bcc386fe66("w:adjustRightInd", xbcea506a33cf14);
		xe1410f585439c7d.x547195bcc386fe66("w:snapToGrid", xbcea506a33cf15);
		xe1410f585439c7d.xc049ea80ee267201("w:spacing", "w:before", obj11, x325f1926b78ae5cd ? "w:beforeLines" : "w:before-lines", obj12, x325f1926b78ae5cd ? "w:beforeAutospacing" : "w:before-autospacing", obj13, "w:after", obj14, x325f1926b78ae5cd ? "w:afterLines" : "w:after-lines", obj15, x325f1926b78ae5cd ? "w:afterAutospacing" : "w:after-autospacing", obj16, "w:line", obj17, x325f1926b78ae5cd ? "w:lineRule" : "w:line-rule", text9);
		xe1410f585439c7d.xc049ea80ee267201("w:ind", "w:left", obj19, "w:right", obj20, "w:hanging", obj21, x325f1926b78ae5cd ? "w:firstLine" : "w:first-line", obj22, x325f1926b78ae5cd ? "w:leftChars" : "w:left-chars", obj23, x325f1926b78ae5cd ? "w:rightChars" : "w:right-chars", obj24, x325f1926b78ae5cd ? "w:hangingChars" : "w:hanging-chars", obj25, x325f1926b78ae5cd ? "w:firstLineChars" : "w:first-line-chars", obj26);
		xe1410f585439c7d.x547195bcc386fe66("w:contextualSpacing", xbcea506a33cf16);
		xe1410f585439c7d.x547195bcc386fe66("w:suppressOverlap", xbcea506a33cf17);
		xe1410f585439c7d.x547195bcc386fe66("w:jc", xbcea506a33cf18);
		xe1410f585439c7d.x547195bcc386fe66("w:textDirection", xbcea506a33cf19);
		xe1410f585439c7d.x547195bcc386fe66("w:textAlignment", xbcea506a33cf20);
		xe1410f585439c7d.x547195bcc386fe66("w:outlineLvl", xbcea506a33cf21);
		if (x325f1926b78ae5cd)
		{
			xe1410f585439c7d.x547195bcc386fe66("w:mirrorIndents", obj18);
		}
		else if (obj18 != null)
		{
			xbdfb620b7167944b.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, "MirrorIndents is not supported in WordML.");
		}
		return true;
	}

	private static void xaa87698597995c87(TabStopCollection xc06f388a56e1a8e4, xfe11bbc13ba649c3 xbdfb620b7167944b)
	{
		if (xc06f388a56e1a8e4 != null && xc06f388a56e1a8e4.Count != 0)
		{
			x873451caae5ad4ae xe1410f585439c7d = xbdfb620b7167944b.xe1410f585439c7d4;
			xe1410f585439c7d.x2307058321cdb62f("w:tabs");
			for (int i = 0; i < xc06f388a56e1a8e4.Count; i++)
			{
				TabStop tabStop = xc06f388a56e1a8e4[i];
				string text = x92309521ce1fc453.x6effb923e5aae32a(tabStop.Leader, xbdfb620b7167944b.x325f1926b78ae5cd);
				int num = Math.Max(tabStop.PositionTwips, -31680);
				xe1410f585439c7d.xc049ea80ee267201("w:tab", "w:val", x92309521ce1fc453.xe929b13e37410177(tabStop.Alignment, xbdfb620b7167944b.x325f1926b78ae5cd), "w:leader", (text != "none") ? text : null, "w:pos", num);
			}
			xe1410f585439c7d.x2dfde153f4ef96d0();
		}
	}
}
