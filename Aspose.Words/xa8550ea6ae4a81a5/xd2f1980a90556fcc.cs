using System;
using Aspose.Words.Fonts;
using x4b4f8b01ec4cb4b2;
using x6c95d9cf46ff5f25;
using x909757d9fd2dd6ae;
using xda075892eccab2ad;
using xf9a9481c3f63a419;
using xfc5388ad7dff404f;

namespace xa8550ea6ae4a81a5;

internal class xd2f1980a90556fcc
{
	private readonly xaf66e8c590b2b553 x9b287b671d592594;

	private readonly x8f3af96aa56f1e32 x800085dd555f7711;

	private readonly FontInfoCollection xcf7aa3cc906cdb68;

	private int x285b1faede71ddd6;

	internal static void x6210059f049f0d48(xaf66e8c590b2b553 xbdfb620b7167944b)
	{
		new xd2f1980a90556fcc(xbdfb620b7167944b).x6210059f049f0d48();
	}

	private xd2f1980a90556fcc(xaf66e8c590b2b553 writer)
	{
		x9b287b671d592594 = writer;
		x800085dd555f7711 = writer.xa24813b526772a3b("fontTable.xml", "application/vnd.openxmlformats-officedocument.wordprocessingml.fontTable+xml", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/fontTable");
		xcf7aa3cc906cdb68 = writer.x2c8c6741422a1298.FontInfos;
		x285b1faede71ddd6 = 1;
	}

	private void x6210059f049f0d48()
	{
		x800085dd555f7711.x9b9ed0109b743e3b("w:fonts");
		x800085dd555f7711.xff520a0047c27122("xmlns:r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		x800085dd555f7711.xff520a0047c27122("xmlns:w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
		foreach (FontInfo item in xcf7aa3cc906cdb68)
		{
			x91fcb0533d14f71a(item);
		}
		x800085dd555f7711.xa0dfc102c691b11f();
	}

	private void x91fcb0533d14f71a(FontInfo xfa5e135bae569bda)
	{
		x800085dd555f7711.x2307058321cdb62f("w:font");
		x800085dd555f7711.xff520a0047c27122("w:name", xfa5e135bae569bda.Name);
		if (x0d299f323d241756.x5959bccb67bbf051(xfa5e135bae569bda.AltName))
		{
			if (xfa5e135bae569bda.AltName.IndexOf("\0") >= 0)
			{
				xfa5e135bae569bda.AltName = xfa5e135bae569bda.AltName.Substring(0, xfa5e135bae569bda.AltName.IndexOf("\0"));
			}
			x800085dd555f7711.x547195bcc386fe66("w:altName", xfa5e135bae569bda.AltName.Replace("\0", ";"));
		}
		if (xfa5e135bae569bda.Panose != null)
		{
			x800085dd555f7711.x547195bcc386fe66("w:panose1", x0d299f323d241756.x482624a13e9e9d98(xfa5e135bae569bda.Panose));
		}
		x800085dd555f7711.x547195bcc386fe66("w:charset", xca004f56614e2431.x928e44a7dd7cdb8b(xfa5e135bae569bda.Charset));
		x800085dd555f7711.x547195bcc386fe66("w:family", xc62574be95c1c918.x1bdd36ffc1b64f6c(xfa5e135bae569bda.Family));
		if (!xfa5e135bae569bda.IsTrueType)
		{
			x800085dd555f7711.xf68f9c3818e1f4b1("w:notTrueType");
		}
		x800085dd555f7711.x547195bcc386fe66("w:pitch", x72a0c846678ecaf9.x24861a95aca39ef5(xfa5e135bae569bda.Pitch));
		if (xfa5e135bae569bda.x9df4cc3a14431dcc != null)
		{
			x911daf141b12e0b2(xfa5e135bae569bda.x9df4cc3a14431dcc);
		}
		x393d198b88cf5ed5[] array = xfa5e135bae569bda.xf24d2f6e3cbd9dd5(EmbeddedFontFormat.OpenType);
		if (array != null)
		{
			x74e3273210558a30(array);
		}
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	private void x911daf141b12e0b2(byte[] x2f9ad81484440792)
	{
		x800085dd555f7711.x2307058321cdb62f("w:sig");
		x800085dd555f7711.xff520a0047c27122("w:usb0", xc1b08afa36bf580c.x0d28bf60e577f9e5(x2f9ad81484440792, 0));
		x800085dd555f7711.xff520a0047c27122("w:usb1", xc1b08afa36bf580c.x0d28bf60e577f9e5(x2f9ad81484440792, 4));
		x800085dd555f7711.xff520a0047c27122("w:usb2", xc1b08afa36bf580c.x0d28bf60e577f9e5(x2f9ad81484440792, 8));
		x800085dd555f7711.xff520a0047c27122("w:usb3", xc1b08afa36bf580c.x0d28bf60e577f9e5(x2f9ad81484440792, 12));
		x800085dd555f7711.xff520a0047c27122("w:csb0", xc1b08afa36bf580c.x0d28bf60e577f9e5(x2f9ad81484440792, 16));
		x800085dd555f7711.xff520a0047c27122("w:csb1", xc1b08afa36bf580c.x0d28bf60e577f9e5(x2f9ad81484440792, 20));
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	private void x74e3273210558a30(x393d198b88cf5ed5[] x565a5959cf73bee2)
	{
		foreach (x393d198b88cf5ed5 x393d198b88cf5ed in x565a5959cf73bee2)
		{
			if (x393d198b88cf5ed != null)
			{
				string x71eb6c63deb56ed = "fonts/font" + xca004f56614e2431.xc8ba948e0d631490(x285b1faede71ddd6++) + ".odttf";
				x682e95b934c8a7ad(x393d198b88cf5ed, x71eb6c63deb56ed);
			}
		}
	}

	private void x682e95b934c8a7ad(x393d198b88cf5ed5 x18c8cfcf0ea5f3c7, string x71eb6c63deb56ed6)
	{
		string xc06e652f250a;
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = x9b287b671d592594.x39c7aeeec1af9dd0.x42c5f80e2ed823ff(x800085dd555f7711.x398b3bd0acd94b61, x71eb6c63deb56ed6, "application/vnd.openxmlformats-officedocument.obfuscatedFont", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/font", out xc06e652f250a);
		string xbcea506a33cf = x8b8b2d207d13a328.x91eaf487186d6fb0(x18c8cfcf0ea5f3c7, xa2f1c3dcbd86f20a.xb8a774e0111d0fbe);
		x800085dd555f7711.x2307058321cdb62f(x3cceeff00783fb7e(x18c8cfcf0ea5f3c7.xfe2178c1f916f36c));
		x800085dd555f7711.xff520a0047c27122("r:id", xc06e652f250a);
		x800085dd555f7711.x0ea3ef8dd3ae2f3f("w:subsetted", x18c8cfcf0ea5f3c7.xf485d4dac21a6985);
		x800085dd555f7711.xff520a0047c27122("w:fontKey", xbcea506a33cf);
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	private static string x3cceeff00783fb7e(EmbeddedFontStyle x768946a353232575)
	{
		return x768946a353232575 switch
		{
			EmbeddedFontStyle.Regular => "w:embedRegular", 
			EmbeddedFontStyle.Bold => "w:embedBold", 
			EmbeddedFontStyle.Italic => "w:embedItalic", 
			EmbeddedFontStyle.BoldItalic => "w:embedBoldItalic", 
			_ => throw new ArgumentException("fontStyle"), 
		};
	}
}
