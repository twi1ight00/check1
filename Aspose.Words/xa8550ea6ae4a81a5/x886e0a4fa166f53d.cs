using Aspose.Words;
using x1a3e96f4b89a7a77;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x909757d9fd2dd6ae;
using xda075892eccab2ad;

namespace xa8550ea6ae4a81a5;

internal class x886e0a4fa166f53d
{
	private x886e0a4fa166f53d()
	{
	}

	internal static void x6210059f049f0d48(xaf66e8c590b2b553 xbdfb620b7167944b)
	{
		x8f3af96aa56f1e32 x8f3af96aa56f1e33 = xbdfb620b7167944b.xa24813b526772a3b("styles.xml", "application/vnd.openxmlformats-officedocument.wordprocessingml.styles+xml", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles");
		xbdfb620b7167944b.xefc309b2831366cb(x8f3af96aa56f1e33);
		x8f3af96aa56f1e33.x9b9ed0109b743e3b("w:styles");
		x8f3af96aa56f1e33.xff520a0047c27122("xmlns:r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		x8f3af96aa56f1e33.xff520a0047c27122("xmlns:w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
		x384c6d0205ba9ce0(xbdfb620b7167944b);
		x36da930309c3ccad(xbdfb620b7167944b);
		x6f126bc7f29ba4bf(xbdfb620b7167944b);
		x8f3af96aa56f1e33.xa0dfc102c691b11f();
		xbdfb620b7167944b.xa493f0b03338ab7a();
	}

	private static void x384c6d0205ba9ce0(xaf66e8c590b2b553 xbdfb620b7167944b)
	{
		StyleCollection styles = xbdfb620b7167944b.x2c8c6741422a1298.Styles;
		x8f3af96aa56f1e32 xca93abf9292cd4f = xbdfb620b7167944b.xca93abf9292cd4f1;
		xca93abf9292cd4f.x2307058321cdb62f("w:docDefaults");
		xca93abf9292cd4f.x2307058321cdb62f("w:rPrDefault");
		xc70f986e9535e88a.x064651cf6a5fbfbe(styles.x27096df7ca0cfe2e, styles.x27096df7ca0cfe2e, xbdfb620b7167944b);
		xca93abf9292cd4f.x2dfde153f4ef96d0();
		xca93abf9292cd4f.x2307058321cdb62f("w:pPrDefault");
		x2aa41ce9e83be7cd.x6210059f049f0d48(styles.xf4eb04b8b9073eeb, xbdfb620b7167944b);
		xca93abf9292cd4f.x2dfde153f4ef96d0();
		xca93abf9292cd4f.x2dfde153f4ef96d0();
	}

	private static void x36da930309c3ccad(xaf66e8c590b2b553 xbdfb620b7167944b)
	{
		DocumentBase x2c8c6741422a = xbdfb620b7167944b.x2c8c6741422a1298;
		x90347bcd8deede01 x90347bcd8deede = x2c8c6741422a.Styles.x90347bcd8deede01;
		x8f3af96aa56f1e32 xca93abf9292cd4f = xbdfb620b7167944b.xca93abf9292cd4f1;
		xca93abf9292cd4f.x2307058321cdb62f("w:latentStyles");
		xca93abf9292cd4f.x943f6be3acf634db("w:defLockedState", x90347bcd8deede.x799a64ee3b4ce806);
		xca93abf9292cd4f.x943f6be3acf634db("w:defUIPriority", x90347bcd8deede.x4d0e04ab61f50baa);
		xca93abf9292cd4f.x943f6be3acf634db("w:defSemiHidden", x90347bcd8deede.xe27cb3f1d698353d);
		xca93abf9292cd4f.x943f6be3acf634db("w:defUnhideWhenUsed", x90347bcd8deede.xa657c8b674ff2f76);
		xca93abf9292cd4f.x943f6be3acf634db("w:defQFormat", x90347bcd8deede.x0c40b3ed8738297c);
		xca93abf9292cd4f.x943f6be3acf634db("w:count", x90347bcd8deede.x6c7ca9aba118e7af);
		if (x90347bcd8deede.x31805fef2aff8b5f.xd44988f225497f3a <= 0)
		{
			x90347bcd8deede.x02b347558ccec04e();
		}
		for (int i = 0; i < x90347bcd8deede.x31805fef2aff8b5f.xd44988f225497f3a; i++)
		{
			x565726a756595ed4 x565726a756595ed = x90347bcd8deede.x31805fef2aff8b5f.get_xe6d4b1b411ed94b5(i);
			string xbcea506a33cf = x72a0c846678ecaf9.x27d6a5b617edc9db(x565726a756595ed.x9a4aa9a3455eb440, "");
			if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
			{
				xca93abf9292cd4f.x2307058321cdb62f("w:lsdException");
				xca93abf9292cd4f.xff520a0047c27122("w:name", xbcea506a33cf);
				if (x565726a756595ed.x2d8aaa05bddcf40c != x90347bcd8deede.x799a64ee3b4ce806)
				{
					xca93abf9292cd4f.x943f6be3acf634db("w:locked", x565726a756595ed.x2d8aaa05bddcf40c);
				}
				if (x565726a756595ed.x45101ac87546632f != x90347bcd8deede.xe27cb3f1d698353d)
				{
					xca93abf9292cd4f.x943f6be3acf634db("w:semiHidden", x565726a756595ed.x45101ac87546632f);
				}
				if (x565726a756595ed.x9eb07da9aa5bbf9e != x90347bcd8deede.x4d0e04ab61f50baa)
				{
					xca93abf9292cd4f.x943f6be3acf634db("w:uiPriority", x565726a756595ed.x9eb07da9aa5bbf9e);
				}
				if (x565726a756595ed.x5356a3af7e7ecdfa != x90347bcd8deede.xa657c8b674ff2f76)
				{
					xca93abf9292cd4f.x943f6be3acf634db("w:unhideWhenUsed", x565726a756595ed.x5356a3af7e7ecdfa);
				}
				if (x565726a756595ed.xebe0f6c7e6f4ae3a != x90347bcd8deede.x0c40b3ed8738297c)
				{
					xca93abf9292cd4f.x943f6be3acf634db("w:qFormat", x565726a756595ed.xebe0f6c7e6f4ae3a);
				}
				xca93abf9292cd4f.x2dfde153f4ef96d0();
			}
		}
		xca93abf9292cd4f.x2dfde153f4ef96d0();
	}

	private static void x6f126bc7f29ba4bf(xaf66e8c590b2b553 xbdfb620b7167944b)
	{
		StyleCollection styles = xbdfb620b7167944b.x2c8c6741422a1298.Styles;
		for (int i = 0; i < styles.Count; i++)
		{
			xaedce5725e456ac5(xbdfb620b7167944b, styles[i]);
		}
	}

	private static void xaedce5725e456ac5(xaf66e8c590b2b553 xbdfb620b7167944b, Style x44ecfea61c937b8e)
	{
		x8f3af96aa56f1e32 xca93abf9292cd4f = xbdfb620b7167944b.xca93abf9292cd4f1;
		xca93abf9292cd4f.x2307058321cdb62f("w:style");
		xca93abf9292cd4f.xff520a0047c27122("w:type", xc62574be95c1c918.xdcf2ecdfdd04b46c(x44ecfea61c937b8e.Type));
		switch (x44ecfea61c937b8e.StyleIdentifier)
		{
		case StyleIdentifier.Normal:
		case StyleIdentifier.DefaultParagraphFont:
		case StyleIdentifier.TableNormal:
		case StyleIdentifier.NoList:
			xca93abf9292cd4f.xff520a0047c27122("w:default", "1");
			break;
		case StyleIdentifier.User:
			xca93abf9292cd4f.xff520a0047c27122("w:customStyle", "1");
			break;
		}
		xca93abf9292cd4f.xff520a0047c27122("w:styleId", xbdfb620b7167944b.x7af082eaf8e0caa4(x44ecfea61c937b8e.x8301ab10c226b0c2));
		xca93abf9292cd4f.x547195bcc386fe66("w:name", x72a0c846678ecaf9.x27d6a5b617edc9db(x44ecfea61c937b8e.StyleIdentifier, x44ecfea61c937b8e.Name));
		xca93abf9292cd4f.x547195bcc386fe66("w:aliases", x44ecfea61c937b8e.Styles.x4c0f9b9b517a1ec4(x44ecfea61c937b8e, xe9f84f829511a789: false));
		xca93abf9292cd4f.x547195bcc386fe66("w:basedOn", xbdfb620b7167944b.x7af082eaf8e0caa4(x44ecfea61c937b8e.xe709b224f455b863));
		if (x44ecfea61c937b8e.xfb77c9ea054ac31c != x44ecfea61c937b8e.x8301ab10c226b0c2)
		{
			xca93abf9292cd4f.x547195bcc386fe66("w:next", xbdfb620b7167944b.x7af082eaf8e0caa4(x44ecfea61c937b8e.xfb77c9ea054ac31c));
		}
		xca93abf9292cd4f.x547195bcc386fe66("w:link", xbdfb620b7167944b.x7af082eaf8e0caa4(x44ecfea61c937b8e.x4cf1854ef833220f));
		xca93abf9292cd4f.x9601fe92a1b73d3f("w:autoRedefine", x44ecfea61c937b8e.x913ff5916b187824);
		xca93abf9292cd4f.x9601fe92a1b73d3f("w:hidden", x44ecfea61c937b8e.x96e55b5d052d1279);
		xca93abf9292cd4f.x67aa7400b293b13a("w:uiPriority", x44ecfea61c937b8e.x9eb07da9aa5bbf9e);
		xca93abf9292cd4f.x9601fe92a1b73d3f("w:semiHidden", x44ecfea61c937b8e.x45101ac87546632f);
		xca93abf9292cd4f.x9601fe92a1b73d3f("w:unhideWhenUsed", x44ecfea61c937b8e.x5356a3af7e7ecdfa);
		xca93abf9292cd4f.x9601fe92a1b73d3f("w:qFormat", x44ecfea61c937b8e.xebe0f6c7e6f4ae3a);
		xca93abf9292cd4f.x9601fe92a1b73d3f("w:locked", x44ecfea61c937b8e.x2d8aaa05bddcf40c);
		xca93abf9292cd4f.x9601fe92a1b73d3f("w:personal", x44ecfea61c937b8e.xdf3672ec434b4524);
		xca93abf9292cd4f.x9601fe92a1b73d3f("w:personalCompose", x44ecfea61c937b8e.xde61abbe9514a1ee);
		xca93abf9292cd4f.x9601fe92a1b73d3f("w:personalReply", x44ecfea61c937b8e.x3bbb21ee843f081c);
		if (x44ecfea61c937b8e.xe12a6bc6d222e782 != 0)
		{
			xca93abf9292cd4f.x547195bcc386fe66("w:rsid", xc1b08afa36bf580c.x0d28bf60e577f9e5(x44ecfea61c937b8e.xe12a6bc6d222e782));
		}
		if (x44ecfea61c937b8e.Type != StyleType.Character)
		{
			x2aa41ce9e83be7cd.x6210059f049f0d48(x44ecfea61c937b8e.x1a78664fa10a3755, xbdfb620b7167944b);
		}
		xc70f986e9535e88a.x064651cf6a5fbfbe(x44ecfea61c937b8e.xeedad81aaed42a76, x44ecfea61c937b8e, xbdfb620b7167944b);
		if (x44ecfea61c937b8e.Type == StyleType.Table)
		{
			TableStyle tableStyle = (TableStyle)x44ecfea61c937b8e;
			x31b31073210f038b.x6210059f049f0d48(tableStyle.xedb0eb766e25e0c9, x97b4bbf66b3d8bc6: true, x37f701492043cfc5: true, xbdfb620b7167944b, xbdfb620b7167944b.x0b744c5c26c5b3b3);
			x31b31073210f038b.x6210059f049f0d48(tableStyle.x511a581657d77f2b, x97b4bbf66b3d8bc6: false, x37f701492043cfc5: true, xbdfb620b7167944b);
			x7142005363c1dbcf.x6210059f049f0d48(tableStyle.xf8cef531dae89ea3, xbdfb620b7167944b);
			foreach (xe12ab2f55355c7f0 item in tableStyle.x7205cb42c2f994a4)
			{
				xd03779bae999fc47(item, xbdfb620b7167944b);
			}
		}
		xca93abf9292cd4f.x2dfde153f4ef96d0();
	}

	private static void xd03779bae999fc47(xe12ab2f55355c7f0 x29a70965cdc631ed, xaf66e8c590b2b553 xbdfb620b7167944b)
	{
		x8f3af96aa56f1e32 xca93abf9292cd4f = xbdfb620b7167944b.xca93abf9292cd4f1;
		xca93abf9292cd4f.x2307058321cdb62f("w:tblStylePr");
		xca93abf9292cd4f.x943f6be3acf634db("w:type", x72a0c846678ecaf9.x1cc48fed2015ead6(x29a70965cdc631ed.x3146d638ec378671));
		x2aa41ce9e83be7cd.x6210059f049f0d48(x29a70965cdc631ed.x1a78664fa10a3755, xbdfb620b7167944b);
		xc70f986e9535e88a.x064651cf6a5fbfbe(x29a70965cdc631ed.xeedad81aaed42a76, x29a70965cdc631ed.xeedad81aaed42a76, xbdfb620b7167944b);
		x31b31073210f038b.x6210059f049f0d48(x29a70965cdc631ed.xedb0eb766e25e0c9, x97b4bbf66b3d8bc6: true, x37f701492043cfc5: true, xbdfb620b7167944b, xbdfb620b7167944b.x0b744c5c26c5b3b3);
		x31b31073210f038b.x6210059f049f0d48(x29a70965cdc631ed.x511a581657d77f2b, x97b4bbf66b3d8bc6: false, x37f701492043cfc5: true, xbdfb620b7167944b);
		x7142005363c1dbcf.x6210059f049f0d48(x29a70965cdc631ed.xf8cef531dae89ea3, xbdfb620b7167944b);
		xca93abf9292cd4f.x2dfde153f4ef96d0();
	}
}
