using Aspose.Words;
using Aspose.Words.Fonts;
using x0a300997a0b66409;
using x1495530f35d79681;
using xda075892eccab2ad;

namespace x2cc366c8657e2b6a;

internal class x989f89f6aff238fe
{
	private x989f89f6aff238fe()
	{
	}

	internal static void x06b0e25aa6ad68a9(x21a61af92fc2a45e xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		DocumentBase x2c8c6741422a = xe134235b3526fa75.x2c8c6741422a1298;
		while (x3bcd232d01c.x152cbadbfa8061b1("fonts"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "defaultFonts":
				while (x3bcd232d01c.x1ac1960adc8c4c39())
				{
					switch (x3bcd232d01c.xa66385d80d4d296f)
					{
					case "ascii":
						x2c8c6741422a.Styles.x27096df7ca0cfe2e.x51cf23ce6e71b84c = x3bcd232d01c.xd2f68ee6f47e9dfb;
						break;
					case "fareast":
						x2c8c6741422a.Styles.x27096df7ca0cfe2e.x31ece097bda75a20 = x3bcd232d01c.xd2f68ee6f47e9dfb;
						break;
					case "h-ansi":
						x2c8c6741422a.Styles.x27096df7ca0cfe2e.xd08cbc518cf39317 = x3bcd232d01c.xd2f68ee6f47e9dfb;
						break;
					case "cs":
						x2c8c6741422a.Styles.x27096df7ca0cfe2e.xf3d194b4e6a2594a = x3bcd232d01c.xd2f68ee6f47e9dfb;
						break;
					}
				}
				break;
			case "font":
				x2c8c6741422a.FontInfos.xd5da23b762ce52a2(xdafccb198ba91439(x3bcd232d01c));
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static FontInfo xdafccb198ba91439(x3c85359e1389ad43 x97bf2eeabd4abc7b)
	{
		FontInfo fontInfo = new FontInfo(x97bf2eeabd4abc7b.xd68abcd61e368af9("name", ""));
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("font"))
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "altName":
				fontInfo.AltName = x97bf2eeabd4abc7b.xbbfc54380705e01e();
				break;
			case "panose-1":
				fontInfo.Panose = new byte[10];
				xc1b08afa36bf580c.xa9aaee2edd3cd025(x97bf2eeabd4abc7b.xbbfc54380705e01e(), fontInfo.Panose, 0);
				break;
			case "charset":
				fontInfo.Charset = xc1b08afa36bf580c.x5c612ff105e66e13(x97bf2eeabd4abc7b.xbbfc54380705e01e());
				break;
			case "family":
				fontInfo.Family = x0beb84bbfae8adcf.xc0345a7cc312751a(x97bf2eeabd4abc7b.xbbfc54380705e01e());
				break;
			case "notTrueType":
				fontInfo.IsTrueType = !x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "pitch":
				fontInfo.Pitch = x72a0c846678ecaf9.x7ddd0b36cb2e685a(x97bf2eeabd4abc7b.xbbfc54380705e01e());
				break;
			case "sig":
				fontInfo.x9df4cc3a14431dcc = new byte[24];
				while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
				{
					switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
					{
					case "usb-0":
						xc1b08afa36bf580c.xe0cee8cc226d674a(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb, fontInfo.x9df4cc3a14431dcc, 0);
						break;
					case "usb-1":
						xc1b08afa36bf580c.xe0cee8cc226d674a(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb, fontInfo.x9df4cc3a14431dcc, 4);
						break;
					case "usb-2":
						xc1b08afa36bf580c.xe0cee8cc226d674a(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb, fontInfo.x9df4cc3a14431dcc, 8);
						break;
					case "usb-3":
						xc1b08afa36bf580c.xe0cee8cc226d674a(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb, fontInfo.x9df4cc3a14431dcc, 12);
						break;
					case "csb-0":
						xc1b08afa36bf580c.xe0cee8cc226d674a(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb, fontInfo.x9df4cc3a14431dcc, 16);
						break;
					case "csb-1":
						xc1b08afa36bf580c.xe0cee8cc226d674a(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb, fontInfo.x9df4cc3a14431dcc, 20);
						break;
					}
				}
				break;
			default:
				x97bf2eeabd4abc7b.IgnoreElement();
				break;
			}
		}
		return fontInfo;
	}
}
