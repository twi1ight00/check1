using Aspose.Words;
using Aspose.Words.Math;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;
using xe5b37aee2c2a4d4e;
using xf9a9481c3f63a419;

namespace xa2462df43988ffad;

internal class x76b14a346ff269e6
{
	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	private bool xe75692d611538875;

	private bool xd325dee341a26cc9;

	private x8c423dccdd6d92c0 x587265599ce76643;

	internal bool x6f60ee90ecc71e66
	{
		get
		{
			return xe75692d611538875;
		}
		set
		{
			xe75692d611538875 = value;
		}
	}

	internal bool xc9616fd35264939f
	{
		get
		{
			return xd325dee341a26cc9;
		}
		set
		{
			xd325dee341a26cc9 = value;
		}
	}

	internal x76b14a346ff269e6(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
		xd325dee341a26cc9 = false;
		xe75692d611538875 = false;
	}

	internal void x6210059f049f0d48(xac4d96a62eaba39e x1a84eefd5d3e114a, x4c1e058c67948d6a x062aae8c9613eeaa)
	{
		x6210059f049f0d48(x1a84eefd5d3e114a, x062aae8c9613eeaa, xaab0c5f1acc303e5: false);
	}

	internal void x6210059f049f0d48(xac4d96a62eaba39e x1a84eefd5d3e114a, x4c1e058c67948d6a x062aae8c9613eeaa, bool xaab0c5f1acc303e5)
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		x587265599ce76643 = new x8c423dccdd6d92c0();
		x17b9cb8fd941ac25(x1a84eefd5d3e114a, x062aae8c9613eeaa, xaab0c5f1acc303e5);
		if (x587265599ce76643.x5fb16e270c21db2e != null)
		{
			x17b9cb8fd941ac25(x1a84eefd5d3e114a, x587265599ce76643.x5fb16e270c21db2e.xdf4bcc85da8f85b2, xaab0c5f1acc303e5);
		}
		bool flag = x9b287b671d592594.x2c8c6741422a1298.xdade2366eaa6f915.xa7e6dbdb484bb52e && x1a84eefd5d3e114a is Style && (x1a84eefd5d3e114a as Style).StyleIdentifier == StyleIdentifier.Normal;
		bool flag2 = x587265599ce76643.xd44988f225497f3a > 0 || xc9616fd35264939f || x6f60ee90ecc71e66 || x587265599ce76643.xa7e6dbdb484bb52e || flag || xaab0c5f1acc303e5;
		if (flag2)
		{
			xe1410f585439c7d.x2307058321cdb62f("style:paragraph-properties");
			xe1410f585439c7d.x943f6be3acf634db("style:text-autospace", x587265599ce76643.xea290db468d877fc);
			xe1410f585439c7d.x943f6be3acf634db("fo:text-align", x587265599ce76643.x2f4602b24218079d);
			xe1410f585439c7d.x943f6be3acf634db("fo:text-align-last", x587265599ce76643.xe587cd8fc02c5158);
			object obj = ((x1a84eefd5d3e114a is Paragraph) ? x9b287b671d592594.x10d7a1cae426b158.xfc72d4c9b765cad7.xf7866f89640a29a3(2350) : null);
			bool flag3 = obj != null && (int)obj > 0;
			if (xc9616fd35264939f || (x6f60ee90ecc71e66 && !flag3))
			{
				x587265599ce76643.xbc96485c569333a8 = "page";
			}
			else if (x6f60ee90ecc71e66 && flag3 && x587265599ce76643.xbc96485c569333a8 == null)
			{
				x587265599ce76643.xbc96485c569333a8 = "column";
			}
			xe1410f585439c7d.x943f6be3acf634db("fo:break-before", x587265599ce76643.xbc96485c569333a8);
			xe1410f585439c7d.x943f6be3acf634db("fo:background-color", x587265599ce76643.x83729c7ebf48ae24);
			xe1410f585439c7d.x943f6be3acf634db("fo:text-indent", x587265599ce76643.x27a8f9fa3e97cb1f);
			if (x587265599ce76643.x284b6150c11a15a2 == LineSpacingRule.AtLeast)
			{
				xe1410f585439c7d.x943f6be3acf634db("style:line-height-at-least", x587265599ce76643.xf7cc67f973fd3737);
			}
			else
			{
				xe1410f585439c7d.x943f6be3acf634db("fo:line-height", x587265599ce76643.xf7cc67f973fd3737);
			}
			x587265599ce76643.x950295903e1e85d3.x6210059f049f0d48(xe1410f585439c7d);
			xe1410f585439c7d.x943f6be3acf634db("fo:keep-with-next", x587265599ce76643.xb23678ebc646e486);
			xe1410f585439c7d.x943f6be3acf634db("fo:keep-together", x587265599ce76643.x6fcd6a1a1789dd49);
			if (x587265599ce76643.xa7e6dbdb484bb52e || flag)
			{
				xe1410f585439c7d.x943f6be3acf634db("fo:orphans", "2");
				xe1410f585439c7d.x943f6be3acf634db("fo:widows", "2");
			}
			xe1410f585439c7d.x943f6be3acf634db("style:writing-mode", x587265599ce76643.x28e5011224ac892b);
			xe1410f585439c7d.x943f6be3acf634db("text:number-lines", x587265599ce76643.x7ff22c593daf1cc1);
			xe1410f585439c7d.x943f6be3acf634db("text:line-number", x587265599ce76643.x845183cdf0fdbeec);
			xe1410f585439c7d.x943f6be3acf634db("style:snap-to-layout-grid", x587265599ce76643.x50a4d0a7e490f9da);
			xe1410f585439c7d.x943f6be3acf634db("style:punctuation-wrap", x587265599ce76643.x0423b5cf92ff0d2c);
			xe1410f585439c7d.x943f6be3acf634db("fo:hyphenation-ladder-count", x587265599ce76643.x76914fe436d96a0e);
			xe1410f585439c7d.x943f6be3acf634db("style:vertical-align", x587265599ce76643.xd17687d6bc61356f);
			if (xaab0c5f1acc303e5 && x9b287b671d592594.x2c8c6741422a1298.xdade2366eaa6f915.xd72f9bc5cc53fc1c != 0 && x9b287b671d592594.x2c8c6741422a1298.xdade2366eaa6f915.xd72f9bc5cc53fc1c != 1134)
			{
				xe1410f585439c7d.x943f6be3acf634db("style:tab-stop-distance", xbb857c9fc36f5054.xf7c347cb12d2a63f(x9b287b671d592594.x2c8c6741422a1298.xdade2366eaa6f915.xd72f9bc5cc53fc1c));
			}
			xe1410f585439c7d.x943f6be3acf634db("style:page-number", x587265599ce76643.x7155dda3b72cd3e5);
		}
		if (xf97af5824fe884c9(x1a84eefd5d3e114a, x5c701860612ba96c(x1a84eefd5d3e114a, flag2) || flag2))
		{
			xe1410f585439c7d.x2dfde153f4ef96d0("style:paragraph-properties");
		}
	}

	private bool xf97af5824fe884c9(xac4d96a62eaba39e x1a84eefd5d3e114a, bool xaf0bcd75ad7e8b39)
	{
		if (x587265599ce76643.xf4ee8b502e787f78 != null || x587265599ce76643.xb047b4214cd3e381 != null)
		{
			if (!xaf0bcd75ad7e8b39)
			{
				x9b287b671d592594.xe1410f585439c7d4.x2307058321cdb62f("style:paragraph-properties");
			}
			string text = null;
			if (x1a84eefd5d3e114a is Paragraph)
			{
				int num = 0;
				foreach (Run run in (x1a84eefd5d3e114a as Paragraph).Runs)
				{
					num += run.Text.Length;
				}
				text = ((num <= 0) ? 1 : num).ToString();
			}
			x9b287b671d592594.xe1410f585439c7d4.xc049ea80ee267201("style:drop-cap", "style:lines", (x587265599ce76643.xf4ee8b502e787f78 != null) ? x587265599ce76643.xf4ee8b502e787f78 : "1", "style:distance", x587265599ce76643.xb047b4214cd3e381, "style:length", text);
			return true;
		}
		return xaf0bcd75ad7e8b39;
	}

	private bool x5c701860612ba96c(xac4d96a62eaba39e x1a84eefd5d3e114a, bool xaf0bcd75ad7e8b39)
	{
		Paragraph paragraph = ((x1a84eefd5d3e114a is Paragraph) ? ((Paragraph)x1a84eefd5d3e114a) : null);
		TabStopCollection x8df6f6ca274123b = x587265599ce76643.x8df6f6ca274123b0;
		if (x8df6f6ca274123b == null || x8df6f6ca274123b.Count == 0)
		{
			return false;
		}
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		bool flag = true;
		TabStopCollection tabStopCollection = null;
		if (paragraph != null && paragraph.xfcffbd79482d97c7 != null)
		{
			tabStopCollection = paragraph.xfcffbd79482d97c7.x1a78664fa10a3755.x8df6f6ca274123b0;
		}
		int i = 0;
		for (int j = 0; j < x8df6f6ca274123b.Count; j++)
		{
			TabStop tabStop = x8df6f6ca274123b[j];
			if (tabStopCollection != null)
			{
				for (; i < tabStopCollection.Count; i++)
				{
					TabStop tabStop2 = tabStopCollection[i];
					int positionTwips = tabStop2.PositionTwips;
					int positionTwips2 = tabStop.PositionTwips;
					if (positionTwips > positionTwips2)
					{
						break;
					}
					if (positionTwips < positionTwips2)
					{
						flag = x66a1809f5b01c258(tabStop2, flag, xaf0bcd75ad7e8b39);
					}
				}
			}
			flag = x66a1809f5b01c258(tabStop, flag, xaf0bcd75ad7e8b39);
		}
		if (tabStopCollection != null)
		{
			while (i < tabStopCollection.Count)
			{
				flag = x66a1809f5b01c258(tabStopCollection[i++], flag, xaf0bcd75ad7e8b39);
			}
		}
		if (!flag)
		{
			xe1410f585439c7d.x2dfde153f4ef96d0("style:tab-stops");
			return true;
		}
		return false;
	}

	private bool x66a1809f5b01c258(TabStop xa642f49a9f39b18a, bool x1947f700a35a52c7, bool xaf0bcd75ad7e8b39)
	{
		if (x0eb9a864413f34de.x0977d00ea3519faa(xa642f49a9f39b18a.Alignment) != null)
		{
			x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
			if (x1947f700a35a52c7)
			{
				if (!xaf0bcd75ad7e8b39)
				{
					xe1410f585439c7d.x2307058321cdb62f("style:paragraph-properties");
				}
				xe1410f585439c7d.x2307058321cdb62f("style:tab-stops");
			}
			xe1410f585439c7d.xc049ea80ee267201("style:tab-stop", "style:type", x0eb9a864413f34de.x0977d00ea3519faa(xa642f49a9f39b18a.Alignment), "style:leader-style", x0eb9a864413f34de.xa75e7f72ded19fa7(xa642f49a9f39b18a.Leader), "style:leader-text", x0eb9a864413f34de.xea82020d7562fd79(xa642f49a9f39b18a.Leader), "style:char", (xa642f49a9f39b18a.Alignment == TabAlignment.Decimal) ? "," : null, "style:position", xbb857c9fc36f5054.xf7c347cb12d2a63f(xa642f49a9f39b18a.PositionTwips - x587265599ce76643.xd2db8e613a09073a));
			return false;
		}
		return x1947f700a35a52c7;
	}

	private void x17b9cb8fd941ac25(xac4d96a62eaba39e x1a84eefd5d3e114a, x4c1e058c67948d6a x974a3d6bb4a71c4d, bool xaab0c5f1acc303e5)
	{
		x4c1e058c67948d6a x4c1e058c67948d6a = xc231d18bd26e9044(x1a84eefd5d3e114a, x974a3d6bb4a71c4d, xaab0c5f1acc303e5);
		x587265599ce76643.x950295903e1e85d3.xf398ffaf32ffe055 = false;
		ParagraphFormat xcaea6554216f3cac = null;
		if (x1a84eefd5d3e114a is Paragraph)
		{
			xcaea6554216f3cac = (x1a84eefd5d3e114a as Paragraph).ParagraphFormat;
		}
		else if (x1a84eefd5d3e114a is Style)
		{
			xcaea6554216f3cac = (x1a84eefd5d3e114a as Style).ParagraphFormat;
		}
		ParagraphAlignment x4ec4022180cbf8f = ParagraphAlignment.Left;
		bool x916d6a98a11ca50c = false;
		for (int i = 0; i < x4c1e058c67948d6a.xd44988f225497f3a; i++)
		{
			int num = x4c1e058c67948d6a.xf15263674eb297bb(i);
			object obj = x4c1e058c67948d6a.x6d3720b962bd3112(i);
			if (obj == null)
			{
				continue;
			}
			x587265599ce76643.xd44988f225497f3a++;
			switch (num)
			{
			case 1020:
				x916d6a98a11ca50c = true;
				x4ec4022180cbf8f = (ParagraphAlignment)obj;
				break;
			case 1060:
				x587265599ce76643.xbc96485c569333a8 = (((bool)obj) ? "page" : "auto");
				break;
			case 1230:
				x587265599ce76643.xe4df0d6b4f2f917f = (bool)obj;
				x587265599ce76643.xd44988f225497f3a--;
				break;
			case 1210:
				x587265599ce76643.xde0050126320a1b9 = (bool)obj;
				x587265599ce76643.xd44988f225497f3a--;
				break;
			case 1200:
				x587265599ce76643.x950295903e1e85d3.xa8c2637cc4888928.x6545d1f2c1b77773 = xbb857c9fc36f5054.xf7c347cb12d2a63f((int)obj);
				break;
			case 1220:
				if (x1a84eefd5d3e114a is Paragraph)
				{
					Paragraph paragraph = (Paragraph)x1a84eefd5d3e114a;
					if (paragraph.NextSibling == null || !(paragraph.NextSibling is Paragraph))
					{
						x587265599ce76643.x950295903e1e85d3.x79d902473861f242.x6545d1f2c1b77773 = xbb857c9fc36f5054.xf7c347cb12d2a63f((int)obj);
						x6de27d9db44f6bd3(x1a84eefd5d3e114a);
						break;
					}
					Paragraph paragraph2 = (Paragraph)paragraph.NextSibling;
					object obj2 = paragraph2.x1a78664fa10a3755.xb86fdbeadec3b75c(1200);
					if (obj2 != null && paragraph2.x1a78664fa10a3755.x394e77381b2234fd)
					{
						obj2 = 280;
					}
					if (obj2 == null || (int)obj2 < (int)obj)
					{
						x587265599ce76643.x950295903e1e85d3.x79d902473861f242.x6545d1f2c1b77773 = xbb857c9fc36f5054.xf7c347cb12d2a63f((int)obj);
						x6de27d9db44f6bd3(x1a84eefd5d3e114a);
					}
					else
					{
						x587265599ce76643.xd44988f225497f3a--;
					}
				}
				else
				{
					x587265599ce76643.x950295903e1e85d3.x79d902473861f242.x6545d1f2c1b77773 = xbb857c9fc36f5054.xf7c347cb12d2a63f((int)obj);
				}
				break;
			case 1560:
				if ((bool)obj)
				{
					x587265599ce76643.x28e5011224ac892b = "rl-tb";
				}
				else
				{
					x587265599ce76643.x28e5011224ac892b = "lr-tb";
				}
				break;
			case 1150:
				if (!(x1a84eefd5d3e114a is Paragraph) || !((Paragraph)x1a84eefd5d3e114a).IsListItem || ((Paragraph)x1a84eefd5d3e114a).ListFormat.ListLevel.x1a78664fa10a3755.xf7866f89640a29a3(1150) == null)
				{
					x587265599ce76643.x950295903e1e85d3.xd7a21e27974f626c.x6545d1f2c1b77773 = xbb857c9fc36f5054.xf7c347cb12d2a63f((int)obj);
					x6de27d9db44f6bd3(x1a84eefd5d3e114a);
				}
				else
				{
					x587265599ce76643.xd44988f225497f3a--;
				}
				break;
			case 1160:
				if (!(x1a84eefd5d3e114a is Paragraph) || !((Paragraph)x1a84eefd5d3e114a).IsListItem || ((Paragraph)x1a84eefd5d3e114a).ListFormat.ListLevel.x1a78664fa10a3755.xf7866f89640a29a3(1160) == null)
				{
					x587265599ce76643.x950295903e1e85d3.xaea087ab32102492.x6545d1f2c1b77773 = xbb857c9fc36f5054.xf7c347cb12d2a63f((int)obj);
					x6de27d9db44f6bd3(x1a84eefd5d3e114a);
				}
				else
				{
					x587265599ce76643.xd44988f225497f3a--;
				}
				x587265599ce76643.xd2db8e613a09073a = (int)obj;
				break;
			case 1170:
				if (!(x1a84eefd5d3e114a is Paragraph) || (int)obj >= 0)
				{
					x587265599ce76643.x27a8f9fa3e97cb1f = xbb857c9fc36f5054.xf7c347cb12d2a63f((int)obj);
				}
				else if (x1a84eefd5d3e114a is Paragraph && !(x1a84eefd5d3e114a as Paragraph).IsListItem)
				{
					x587265599ce76643.x27a8f9fa3e97cb1f = xbb857c9fc36f5054.xf7c347cb12d2a63f((int)obj);
				}
				else
				{
					x587265599ce76643.xd44988f225497f3a--;
				}
				break;
			case 1650:
			{
				x84bbacdc1fc0efd2 x84bbacdc1fc0efd = (x84bbacdc1fc0efd2)obj;
				x587265599ce76643.x284b6150c11a15a2 = x84bbacdc1fc0efd.xea9485ec61071863;
				if ((!(x1a84eefd5d3e114a is Paragraph) || !((Paragraph)x1a84eefd5d3e114a).x1a78664fa10a3755.xd007a6c2c317166c) && (x1a84eefd5d3e114a is Paragraph || x1a84eefd5d3e114a is Style))
				{
					x587265599ce76643.xf7cc67f973fd3737 = xbb857c9fc36f5054.xa605a684cfdf1a39(x84bbacdc1fc0efd);
				}
				else
				{
					x587265599ce76643.xd44988f225497f3a--;
				}
				break;
			}
			case 1460:
				x587265599ce76643.x83729c7ebf48ae24 = xbb857c9fc36f5054.x0ad4dcbc0b50ce41((Shading)obj);
				if (x587265599ce76643.x83729c7ebf48ae24 == null)
				{
					x587265599ce76643.xd44988f225497f3a--;
				}
				break;
			case 1350:
				x587265599ce76643.x950295903e1e85d3.xa8c2637cc4888928.x03cb705fbd5700a4 = (Border)obj;
				x587265599ce76643.xd44988f225497f3a--;
				break;
			case 1370:
				x587265599ce76643.x950295903e1e85d3.x79d902473861f242.x03cb705fbd5700a4 = (Border)obj;
				x587265599ce76643.xd44988f225497f3a--;
				break;
			case 1360:
				x587265599ce76643.x950295903e1e85d3.xaea087ab32102492.x03cb705fbd5700a4 = (Border)obj;
				x587265599ce76643.xd44988f225497f3a--;
				break;
			case 1380:
				x587265599ce76643.x950295903e1e85d3.xd7a21e27974f626c.x03cb705fbd5700a4 = (Border)obj;
				x587265599ce76643.xd44988f225497f3a--;
				break;
			case 1140:
				if (obj != null && ((TabStopCollection)obj).Count != 0)
				{
					x587265599ce76643.x8df6f6ca274123b0 = (TabStopCollection)obj;
				}
				x587265599ce76643.xd44988f225497f3a--;
				break;
			case 1450:
				x587265599ce76643.xf4ee8b502e787f78 = ((int)obj).ToString();
				x587265599ce76643.xd44988f225497f3a--;
				break;
			case 1500:
				if (x4c1e058c67948d6a.x263d579af1d0d43f(1450))
				{
					x587265599ce76643.xb047b4214cd3e381 = xbb857c9fc36f5054.xf7c347cb12d2a63f(obj);
				}
				x587265599ce76643.xd44988f225497f3a--;
				break;
			case 1050:
				if ((bool)obj)
				{
					x587265599ce76643.xb23678ebc646e486 = "always";
				}
				else
				{
					x587265599ce76643.xd44988f225497f3a--;
				}
				break;
			case 1040:
				if ((bool)obj)
				{
					x587265599ce76643.x6fcd6a1a1789dd49 = "always";
				}
				else
				{
					x587265599ce76643.xd44988f225497f3a--;
				}
				break;
			case 1470:
				if ((bool)obj)
				{
					x587265599ce76643.xa7e6dbdb484bb52e = true;
				}
				else
				{
					x587265599ce76643.xd44988f225497f3a--;
				}
				break;
			case 1260:
				if ((bool)obj)
				{
					x587265599ce76643.x50a4d0a7e490f9da = "true";
				}
				else
				{
					x587265599ce76643.xd44988f225497f3a--;
				}
				break;
			case 1240:
				x587265599ce76643.xea290db468d877fc = (((bool)obj) ? "ideograph-alpha" : "none");
				break;
			case 1090:
				if (!(bool)obj)
				{
					x587265599ce76643.x0423b5cf92ff0d2c = "simple";
				}
				else
				{
					x587265599ce76643.xd44988f225497f3a--;
				}
				break;
			case 1410:
				if ((bool)obj)
				{
					x587265599ce76643.x76914fe436d96a0e = "no-limit";
				}
				else
				{
					x587265599ce76643.xd44988f225497f3a--;
				}
				break;
			case 1130:
				if (!(bool)obj)
				{
					x587265599ce76643.x7ff22c593daf1cc1 = "true";
				}
				else
				{
					x587265599ce76643.xd44988f225497f3a--;
				}
				break;
			case 1510:
				x587265599ce76643.xd17687d6bc61356f = x0eb9a864413f34de.x28c092e469dbab2a((x8fdc64e3f5579ea8)obj);
				if (x587265599ce76643.xd17687d6bc61356f == null)
				{
					x587265599ce76643.xd44988f225497f3a--;
				}
				break;
			case 10010:
				x587265599ce76643.x5fb16e270c21db2e = (x5fb16e270c21db2e)obj;
				x587265599ce76643.xd44988f225497f3a--;
				break;
			default:
				x587265599ce76643.xd44988f225497f3a--;
				break;
			}
		}
		x4b66571195618e95(x1a84eefd5d3e114a);
		xb38378133bf7c629(x1a84eefd5d3e114a, xcaea6554216f3cac, x4ec4022180cbf8f, x916d6a98a11ca50c);
		if (x587265599ce76643.xde0050126320a1b9 && x587265599ce76643.x950295903e1e85d3.xa8c2637cc4888928.x6545d1f2c1b77773 != null)
		{
			if (x1a84eefd5d3e114a is Paragraph && ((Paragraph)x1a84eefd5d3e114a).PreviousSibling == null)
			{
				x587265599ce76643.x950295903e1e85d3.xa8c2637cc4888928.x6545d1f2c1b77773 = null;
				x587265599ce76643.xd44988f225497f3a--;
			}
			else
			{
				x587265599ce76643.x950295903e1e85d3.xa8c2637cc4888928.x6545d1f2c1b77773 = xbb857c9fc36f5054.xf7c347cb12d2a63f(280);
			}
		}
		if (x587265599ce76643.xe4df0d6b4f2f917f && x587265599ce76643.x950295903e1e85d3.x79d902473861f242.x6545d1f2c1b77773 != null)
		{
			if (x1a84eefd5d3e114a is Paragraph && ((Paragraph)x1a84eefd5d3e114a).NextSibling == null)
			{
				x587265599ce76643.x950295903e1e85d3.x79d902473861f242.x6545d1f2c1b77773 = null;
				x587265599ce76643.xd44988f225497f3a--;
			}
			else
			{
				x587265599ce76643.x950295903e1e85d3.x79d902473861f242.x6545d1f2c1b77773 = xbb857c9fc36f5054.xf7c347cb12d2a63f(280);
			}
		}
		if (x587265599ce76643.x950295903e1e85d3.x5f92400e1485c05c(x2b818897b65c872e: true, xa6651a0a6d059494: false))
		{
			x587265599ce76643.xd44988f225497f3a++;
		}
	}

	private void x6de27d9db44f6bd3(xac4d96a62eaba39e x1a84eefd5d3e114a)
	{
		if (x1a84eefd5d3e114a is Paragraph)
		{
			Paragraph paragraph = (Paragraph)x1a84eefd5d3e114a;
			if (paragraph.IsInCell)
			{
				x9b287b671d592594.x3939850b09f0d40e = true;
			}
		}
	}

	private void x4b66571195618e95(xac4d96a62eaba39e x1a84eefd5d3e114a)
	{
		if (!(x1a84eefd5d3e114a is Paragraph))
		{
			return;
		}
		Paragraph paragraph = (Paragraph)x1a84eefd5d3e114a;
		Section parentSection = paragraph.ParentSection;
		xfc72d4c9b765cad7 xfc72d4c9b765cad = parentSection.xfc72d4c9b765cad7;
		object obj = xfc72d4c9b765cad.xf7866f89640a29a3(2180);
		object obj2 = xfc72d4c9b765cad.xf7866f89640a29a3(2110);
		if (paragraph == parentSection.Body.FirstParagraph)
		{
			if (obj != null || obj2 != null)
			{
				x587265599ce76643.x7ff22c593daf1cc1 = "true";
			}
			if (xfc72d4c9b765cad.x464e144455d016ba && !xd325dee341a26cc9 && !xe75692d611538875)
			{
				x587265599ce76643.x7155dda3b72cd3e5 = xca004f56614e2431.x754c3a5f03a2ce84(xfc72d4c9b765cad.xea80bd18e8a43904);
				x587265599ce76643.xd44988f225497f3a++;
			}
		}
		if (x587265599ce76643.x7ff22c593daf1cc1 == "true" && !x0d299f323d241756.x5959bccb67bbf051(x587265599ce76643.x845183cdf0fdbeec))
		{
			object obj3 = xfc72d4c9b765cad.xf7866f89640a29a3(2180);
			x587265599ce76643.x845183cdf0fdbeec = ((obj3 != null) ? xca004f56614e2431.x754c3a5f03a2ce84((int)obj3) : "1");
			x587265599ce76643.xd44988f225497f3a++;
		}
	}

	private void xb38378133bf7c629(xac4d96a62eaba39e x1a84eefd5d3e114a, ParagraphFormat xcaea6554216f3cac, ParagraphAlignment x4ec4022180cbf8f4, bool x916d6a98a11ca50c)
	{
		TextOrientation xd1c56470d96cb24c = TextOrientation.Horizontal;
		CellVerticalAlignment xdc46a7254c7770ad = CellVerticalAlignment.Top;
		if (x1a84eefd5d3e114a is Paragraph)
		{
			Paragraph paragraph = (Paragraph)x1a84eefd5d3e114a;
			if (paragraph.IsInCell)
			{
				xd1c56470d96cb24c = paragraph.xc5464084edc8e226.xf8cef531dae89ea3.x2c5926113e101674;
				xdc46a7254c7770ad = paragraph.xc5464084edc8e226.xf8cef531dae89ea3.xf6ce0e8106e6a1d8;
			}
		}
		string text = x0eb9a864413f34de.x2e0e7b4c48ef8f54(x916d6a98a11ca50c, x4ec4022180cbf8f4, xd1c56470d96cb24c, xdc46a7254c7770ad);
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			x587265599ce76643.x2f4602b24218079d = text;
		}
		if (xcaea6554216f3cac != null && x4ec4022180cbf8f4 == ParagraphAlignment.Distributed)
		{
			x587265599ce76643.xe587cd8fc02c5158 = "justify";
		}
		if (!x0d299f323d241756.x5959bccb67bbf051(x587265599ce76643.x2f4602b24218079d) && x916d6a98a11ca50c)
		{
			x587265599ce76643.xd44988f225497f3a--;
		}
		if (x0d299f323d241756.x5959bccb67bbf051(x587265599ce76643.x2f4602b24218079d) && !x916d6a98a11ca50c)
		{
			x587265599ce76643.xd44988f225497f3a++;
		}
		xbda080263aa71ba9(x1a84eefd5d3e114a);
	}

	private void xbda080263aa71ba9(xac4d96a62eaba39e x1a84eefd5d3e114a)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(x587265599ce76643.x2f4602b24218079d) || !(x1a84eefd5d3e114a is Paragraph))
		{
			return;
		}
		Node child = ((Paragraph)x1a84eefd5d3e114a).GetChild(NodeType.OfficeMath, 0, isDeep: false);
		if (child == null)
		{
			return;
		}
		object obj = ((OfficeMath)child).x52642f91ccdeeb35.xf7866f89640a29a3(15010);
		x587265599ce76643.x2f4602b24218079d = "center";
		if (obj != null)
		{
			x2cdbcd6273a149f1 x2cdbcd6273a149f = (x2cdbcd6273a149f1)obj;
			if (x2cdbcd6273a149f == x2cdbcd6273a149f1.x72d92bd1aff02e37)
			{
				x587265599ce76643.x2f4602b24218079d = "left";
			}
			if (x2cdbcd6273a149f == x2cdbcd6273a149f1.x419ba17a5322627b)
			{
				x587265599ce76643.x2f4602b24218079d = "right";
			}
		}
		x587265599ce76643.xd44988f225497f3a++;
	}

	private x4c1e058c67948d6a xc231d18bd26e9044(xac4d96a62eaba39e x1a84eefd5d3e114a, x4c1e058c67948d6a x974a3d6bb4a71c4d, bool xaab0c5f1acc303e5)
	{
		x4c1e058c67948d6a x4c1e058c67948d6a = x974a3d6bb4a71c4d;
		if (xdb0bf9f81de4b38c.x7fcd4a3e93426c63(x1a84eefd5d3e114a, xaab0c5f1acc303e5))
		{
			x4c1e058c67948d6a = x9b287b671d592594.x2c8c6741422a1298.Styles.xf4eb04b8b9073eeb.x8b61531c8ea35b85();
			x974a3d6bb4a71c4d.xab3af626b1405ee8(x4c1e058c67948d6a);
		}
		return x4c1e058c67948d6a;
	}
}
