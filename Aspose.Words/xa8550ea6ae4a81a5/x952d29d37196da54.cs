using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Lists;
using x1a3e96f4b89a7a77;
using x6c95d9cf46ff5f25;
using x7c7a1dceb600404e;
using x909757d9fd2dd6ae;
using xd2754ae26d400653;
using xda075892eccab2ad;

namespace xa8550ea6ae4a81a5;

internal class x952d29d37196da54
{
	private x952d29d37196da54()
	{
	}

	internal static void x6210059f049f0d48(xaf66e8c590b2b553 xbdfb620b7167944b)
	{
		DocumentBase x2c8c6741422a = xbdfb620b7167944b.x2c8c6741422a1298;
		if (x2c8c6741422a.Lists.xddf1da3d36406847 != 0 || x2c8c6741422a.Lists.Count != 0)
		{
			x8f3af96aa56f1e32 x8f3af96aa56f1e33 = xbdfb620b7167944b.xa24813b526772a3b("numbering.xml", "application/vnd.openxmlformats-officedocument.wordprocessingml.numbering+xml", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/numbering");
			xbdfb620b7167944b.xefc309b2831366cb(x8f3af96aa56f1e33);
			x8f3af96aa56f1e33.x454da6e050647673("w:numbering");
			xa23a9cf7d03725c8(x2c8c6741422a, xbdfb620b7167944b);
			x2788ff87c749937c(x2c8c6741422a, xbdfb620b7167944b);
			xb95b48034d7dfbc5(x2c8c6741422a, xbdfb620b7167944b);
			x8f3af96aa56f1e33.xa0dfc102c691b11f();
			xbdfb620b7167944b.xa493f0b03338ab7a();
		}
	}

	private static void xa23a9cf7d03725c8(DocumentBase x6beba47238e0ade6, xaf66e8c590b2b553 xbdfb620b7167944b)
	{
		x8f3af96aa56f1e32 xca93abf9292cd4f = xbdfb620b7167944b.xca93abf9292cd4f1;
		for (int i = 0; i < x6beba47238e0ade6.Lists.xe10f375b4290d48f; i++)
		{
			Shape x5770cdefd8931aa = x6beba47238e0ade6.Lists.x4916e8670feefe58(i);
			xca93abf9292cd4f.x2307058321cdb62f("w:numPicBullet");
			xca93abf9292cd4f.x943f6be3acf634db("w:numPicBulletId", i);
			xca93abf9292cd4f.x2307058321cdb62f("w:pict");
			xa25dec8c824ea182.x6210059f049f0d48(x5770cdefd8931aa, xca93abf9292cd4f, xbdfb620b7167944b);
			xca93abf9292cd4f.x2dfde153f4ef96d0();
			xca93abf9292cd4f.x2dfde153f4ef96d0();
			xca93abf9292cd4f.x2dfde153f4ef96d0();
		}
	}

	private static void x2788ff87c749937c(DocumentBase x6beba47238e0ade6, xaf66e8c590b2b553 xbdfb620b7167944b)
	{
		x8f3af96aa56f1e32 xca93abf9292cd4f = xbdfb620b7167944b.xca93abf9292cd4f1;
		for (int i = 0; i < x6beba47238e0ade6.Lists.xddf1da3d36406847; i++)
		{
			x178ff6dcbf808c38 x178ff6dcbf808c = x6beba47238e0ade6.Lists.x3bfa6064d69ac0da(i);
			xca93abf9292cd4f.x2307058321cdb62f("w:abstractNum");
			xca93abf9292cd4f.x943f6be3acf634db("w:abstractNumId", i);
			xca93abf9292cd4f.x547195bcc386fe66("w:nsid", xc1b08afa36bf580c.x0d28bf60e577f9e5(x178ff6dcbf808c.x1eac770549050632));
			xca93abf9292cd4f.x547195bcc386fe66("w:multiLevelType", x4a909034643add70.xc042c81bbc46cc9d(x178ff6dcbf808c.x902c8ac86fbaf048));
			xca93abf9292cd4f.x547195bcc386fe66("w:tmpl", xc1b08afa36bf580c.x0d28bf60e577f9e5(x178ff6dcbf808c.x18f9fc979b70e77f));
			xca93abf9292cd4f.x547195bcc386fe66("w:name", x178ff6dcbf808c.x759aa16c2016a289);
			if (x178ff6dcbf808c.xf81d0e09758457fe)
			{
				xca93abf9292cd4f.x547195bcc386fe66("w:styleLink", xbdfb620b7167944b.x7af082eaf8e0caa4(x178ff6dcbf808c.xc657ea789af2c1f0));
			}
			if (x178ff6dcbf808c.x01381925b7dd551e)
			{
				xca93abf9292cd4f.x547195bcc386fe66("w:numStyleLink", xbdfb620b7167944b.x7af082eaf8e0caa4(x178ff6dcbf808c.xc657ea789af2c1f0));
			}
			else
			{
				for (int j = 0; j < x178ff6dcbf808c.x438a2a8db4b2d07b.Count; j++)
				{
					x788718c529bf1726(x178ff6dcbf808c.x438a2a8db4b2d07b[j], xbdfb620b7167944b);
				}
			}
			xca93abf9292cd4f.x2dfde153f4ef96d0();
		}
	}

	private static void xb95b48034d7dfbc5(DocumentBase x6beba47238e0ade6, xaf66e8c590b2b553 xbdfb620b7167944b)
	{
		x8f3af96aa56f1e32 xca93abf9292cd4f = xbdfb620b7167944b.xca93abf9292cd4f1;
		foreach (List list in x6beba47238e0ade6.Lists)
		{
			int num = x6beba47238e0ade6.Lists.x19a9fba0f6b6b791(list.x1eac770549050632);
			if (num < 0)
			{
				continue;
			}
			xca93abf9292cd4f.x2307058321cdb62f("w:num");
			xca93abf9292cd4f.x943f6be3acf634db("w:numId", list.ListId);
			xca93abf9292cd4f.x547195bcc386fe66("w:abstractNumId", num);
			foreach (x136abcf7d9c0eef3 item in list.x6047afa6812e47bc)
			{
				xca93abf9292cd4f.x2307058321cdb62f("w:lvlOverride");
				xca93abf9292cd4f.x943f6be3acf634db("w:ilvl", item.xf13a626e550cef8f.x008c23e8f687bbd3);
				if (item.x33160172e2e7ff13)
				{
					xca93abf9292cd4f.x547195bcc386fe66("w:startOverride", item.x6da6130e001c6962);
				}
				if (item.x178c863a9c967cd2)
				{
					x788718c529bf1726(item.xf13a626e550cef8f, xbdfb620b7167944b);
				}
				xca93abf9292cd4f.x2dfde153f4ef96d0();
			}
			xca93abf9292cd4f.x2dfde153f4ef96d0();
		}
	}

	private static void x788718c529bf1726(ListLevel x66bbd7ed8c65740d, xaf66e8c590b2b553 xbdfb620b7167944b)
	{
		x8f3af96aa56f1e32 xca93abf9292cd4f = xbdfb620b7167944b.xca93abf9292cd4f1;
		xca93abf9292cd4f.x2307058321cdb62f("w:lvl");
		xca93abf9292cd4f.x943f6be3acf634db("w:ilvl", x66bbd7ed8c65740d.x008c23e8f687bbd3);
		xca93abf9292cd4f.x943f6be3acf634db("w:tentative", x66bbd7ed8c65740d.x83b68d5fabfc1faa ? "1" : "");
		xca93abf9292cd4f.x547195bcc386fe66("w:start", x66bbd7ed8c65740d.StartAt);
		xca93abf9292cd4f.x547195bcc386fe66("w:numFmt", xc62574be95c1c918.x235742abf07b06ea(x66bbd7ed8c65740d.NumberStyle));
		if (x66bbd7ed8c65740d.xfbad6d0650721048)
		{
			xca93abf9292cd4f.x547195bcc386fe66("w:lvlRestart", x66bbd7ed8c65740d.RestartAfterLevel + 1);
		}
		if (x66bbd7ed8c65740d.x4a1340b0df048976 != 4095)
		{
			xca93abf9292cd4f.x547195bcc386fe66("w:pStyle", xbdfb620b7167944b.x7af082eaf8e0caa4(x66bbd7ed8c65740d.x4a1340b0df048976));
		}
		xca93abf9292cd4f.x9601fe92a1b73d3f("w:isLgl", x66bbd7ed8c65740d.IsLegal);
		if (x66bbd7ed8c65740d.TrailingCharacter != 0)
		{
			xca93abf9292cd4f.x547195bcc386fe66("w:suff", x4a909034643add70.xa59cf2a9649328d2(x66bbd7ed8c65740d.TrailingCharacter));
		}
		if (x0d299f323d241756.x5959bccb67bbf051(x66bbd7ed8c65740d.NumberFormat))
		{
			xca93abf9292cd4f.x2307058321cdb62f("w:lvlText");
			xca93abf9292cd4f.xff520a0047c27122("w:val", xc1b08afa36bf580c.x0bd71ffeca440ed7(x66bbd7ed8c65740d.NumberFormat));
			xca93abf9292cd4f.x2dfde153f4ef96d0();
		}
		if (x66bbd7ed8c65740d.x44b52529222cea8a)
		{
			xca93abf9292cd4f.x547195bcc386fe66("w:lvlPicBulletId", x66bbd7ed8c65740d.x4d819daa8b29e86b);
		}
		if (x66bbd7ed8c65740d.xf9be1d0b8b44c7e8)
		{
			xca93abf9292cd4f.xc049ea80ee267201("w:legacy", "w:legacy", x66bbd7ed8c65740d.xf9be1d0b8b44c7e8, "w:legacySpace", x66bbd7ed8c65740d.x42bf8be828fc1b33, "w:legacyIndent", x66bbd7ed8c65740d.x5cf63f659ff5ee9f);
		}
		xca93abf9292cd4f.x547195bcc386fe66("w:lvlJc", x4a909034643add70.x9ad35d4738b8b3a0(x66bbd7ed8c65740d.Alignment));
		x2aa41ce9e83be7cd.x6210059f049f0d48(x66bbd7ed8c65740d.x1a78664fa10a3755, xbdfb620b7167944b);
		xc70f986e9535e88a.x064651cf6a5fbfbe(x66bbd7ed8c65740d.xeedad81aaed42a76, x66bbd7ed8c65740d.xeedad81aaed42a76, xbdfb620b7167944b);
		xca93abf9292cd4f.x2dfde153f4ef96d0();
	}
}
