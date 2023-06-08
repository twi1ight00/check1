using Aspose.Words;
using Aspose.Words.Fonts;
using x0a300997a0b66409;
using x6c95d9cf46ff5f25;
using xda075892eccab2ad;
using xf9a9481c3f63a419;

namespace xbe829a00a7a86dc3;

internal class x26b7a1d1ec03d3ee
{
	private x26b7a1d1ec03d3ee()
	{
	}

	internal static void x6210059f049f0d48(Document x6beba47238e0ade6, xf7173b82df2a4de7 xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("w:fonts");
		xd07ce4b74c5774a7.x2307058321cdb62f("w:defaultFonts");
		xd07ce4b74c5774a7.xff520a0047c27122("w:ascii", x6beba47238e0ade6.Styles.x27096df7ca0cfe2e.x51cf23ce6e71b84c);
		xd07ce4b74c5774a7.xff520a0047c27122("w:fareast", x6beba47238e0ade6.Styles.x27096df7ca0cfe2e.x31ece097bda75a20);
		xd07ce4b74c5774a7.xff520a0047c27122("w:h-ansi", x6beba47238e0ade6.Styles.x27096df7ca0cfe2e.xd08cbc518cf39317);
		xd07ce4b74c5774a7.xff520a0047c27122("w:cs", x6beba47238e0ade6.Styles.x27096df7ca0cfe2e.xf3d194b4e6a2594a);
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		foreach (FontInfo fontInfo in x6beba47238e0ade6.FontInfos)
		{
			xd07ce4b74c5774a7.x2307058321cdb62f("w:font");
			xd07ce4b74c5774a7.xff520a0047c27122("w:name", fontInfo.Name);
			if (x0d299f323d241756.x5959bccb67bbf051(fontInfo.AltName))
			{
				if (fontInfo.AltName.IndexOf("\0") >= 0)
				{
					fontInfo.AltName = fontInfo.AltName.Substring(0, fontInfo.AltName.IndexOf("\0"));
				}
				xd07ce4b74c5774a7.x547195bcc386fe66("w:altName", fontInfo.AltName.Replace("\0", ";"));
			}
			if (fontInfo.Panose != null)
			{
				xd07ce4b74c5774a7.x547195bcc386fe66("w:panose-1", x0d299f323d241756.x482624a13e9e9d98(fontInfo.Panose));
			}
			xd07ce4b74c5774a7.x547195bcc386fe66("w:charset", xca004f56614e2431.x928e44a7dd7cdb8b(fontInfo.Charset));
			xd07ce4b74c5774a7.x547195bcc386fe66("w:family", x0beb84bbfae8adcf.x67eaf55f2c275fc1(fontInfo.Family));
			if (!fontInfo.IsTrueType)
			{
				xd07ce4b74c5774a7.xf68f9c3818e1f4b1("w:notTrueType");
			}
			xd07ce4b74c5774a7.x547195bcc386fe66("w:pitch", x72a0c846678ecaf9.x24861a95aca39ef5(fontInfo.Pitch));
			if (fontInfo.x9df4cc3a14431dcc != null)
			{
				xd07ce4b74c5774a7.x2307058321cdb62f("w:sig");
				xd07ce4b74c5774a7.xff520a0047c27122("w:usb-0", xc1b08afa36bf580c.x0d28bf60e577f9e5(fontInfo.x9df4cc3a14431dcc, 0));
				xd07ce4b74c5774a7.xff520a0047c27122("w:usb-1", xc1b08afa36bf580c.x0d28bf60e577f9e5(fontInfo.x9df4cc3a14431dcc, 4));
				xd07ce4b74c5774a7.xff520a0047c27122("w:usb-2", xc1b08afa36bf580c.x0d28bf60e577f9e5(fontInfo.x9df4cc3a14431dcc, 8));
				xd07ce4b74c5774a7.xff520a0047c27122("w:usb-3", xc1b08afa36bf580c.x0d28bf60e577f9e5(fontInfo.x9df4cc3a14431dcc, 12));
				xd07ce4b74c5774a7.xff520a0047c27122("w:csb-0", xc1b08afa36bf580c.x0d28bf60e577f9e5(fontInfo.x9df4cc3a14431dcc, 16));
				xd07ce4b74c5774a7.xff520a0047c27122("w:csb-1", xc1b08afa36bf580c.x0d28bf60e577f9e5(fontInfo.x9df4cc3a14431dcc, 20));
				xd07ce4b74c5774a7.x2dfde153f4ef96d0();
			}
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}
}
