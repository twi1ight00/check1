using Aspose.Words.Fonts;
using x1495530f35d79681;
using x909757d9fd2dd6ae;
using xda075892eccab2ad;

namespace x79490184cecf12a1;

internal class x5f1c415523b4e090
{
	private x5f1c415523b4e090()
	{
	}

	internal static void x06b0e25aa6ad68a9(x11e1346c12ead315 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3c85359e1389ad = xe134235b3526fa75.x1b1aeab2a2e668c4("http://schemas.openxmlformats.org/officeDocument/2006/relationships/fontTable");
		if (x3c85359e1389ad == null)
		{
			return;
		}
		FontInfoCollection fontInfos = xe134235b3526fa75.x2c8c6741422a1298.FontInfos;
		while (x3c85359e1389ad.x152cbadbfa8061b1("fonts"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3c85359e1389ad.xa66385d80d4d296f) != null && xa66385d80d4d296f == "font")
			{
				fontInfos.xd5da23b762ce52a2(xdafccb198ba91439(xe134235b3526fa75));
			}
			else
			{
				x3c85359e1389ad.IgnoreElement();
			}
		}
		xe134235b3526fa75.xc8ab4e294c74831b();
	}

	private static FontInfo xdafccb198ba91439(x11e1346c12ead315 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		FontInfo fontInfo = new FontInfo(x3bcd232d01c.xd68abcd61e368af9("name", ""));
		while (x3bcd232d01c.x152cbadbfa8061b1("font"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "altName":
				fontInfo.AltName = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "panose1":
				fontInfo.Panose = new byte[10];
				xc1b08afa36bf580c.xa9aaee2edd3cd025(x3bcd232d01c.xbbfc54380705e01e(), fontInfo.Panose, 0);
				break;
			case "charset":
				fontInfo.Charset = xc1b08afa36bf580c.x5c612ff105e66e13(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "family":
				fontInfo.Family = xc62574be95c1c918.x4d3ddb635556b2b1(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "notTrueType":
				fontInfo.IsTrueType = !x3bcd232d01c.xe04906126da94dd1();
				break;
			case "pitch":
				fontInfo.Pitch = x72a0c846678ecaf9.x7ddd0b36cb2e685a(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "sig":
				fontInfo.x9df4cc3a14431dcc = new byte[24];
				while (x3bcd232d01c.x1ac1960adc8c4c39())
				{
					switch (x3bcd232d01c.xa66385d80d4d296f)
					{
					case "usb0":
						xc1b08afa36bf580c.xe0cee8cc226d674a(x3bcd232d01c.xd2f68ee6f47e9dfb, fontInfo.x9df4cc3a14431dcc, 0);
						break;
					case "usb1":
						xc1b08afa36bf580c.xe0cee8cc226d674a(x3bcd232d01c.xd2f68ee6f47e9dfb, fontInfo.x9df4cc3a14431dcc, 4);
						break;
					case "usb2":
						xc1b08afa36bf580c.xe0cee8cc226d674a(x3bcd232d01c.xd2f68ee6f47e9dfb, fontInfo.x9df4cc3a14431dcc, 8);
						break;
					case "usb3":
						xc1b08afa36bf580c.xe0cee8cc226d674a(x3bcd232d01c.xd2f68ee6f47e9dfb, fontInfo.x9df4cc3a14431dcc, 12);
						break;
					case "csb0":
						xc1b08afa36bf580c.xe0cee8cc226d674a(x3bcd232d01c.xd2f68ee6f47e9dfb, fontInfo.x9df4cc3a14431dcc, 16);
						break;
					case "csb1":
						xc1b08afa36bf580c.xe0cee8cc226d674a(x3bcd232d01c.xd2f68ee6f47e9dfb, fontInfo.x9df4cc3a14431dcc, 20);
						break;
					}
				}
				break;
			case "embedRegular":
				x9ad301193e318fc1(xe134235b3526fa75, x3bcd232d01c, fontInfo, EmbeddedFontStyle.Regular);
				break;
			case "embedBold":
				x9ad301193e318fc1(xe134235b3526fa75, x3bcd232d01c, fontInfo, EmbeddedFontStyle.Bold);
				break;
			case "embedItalic":
				x9ad301193e318fc1(xe134235b3526fa75, x3bcd232d01c, fontInfo, EmbeddedFontStyle.Italic);
				break;
			case "embedBoldItalic":
				x9ad301193e318fc1(xe134235b3526fa75, x3bcd232d01c, fontInfo, EmbeddedFontStyle.BoldItalic);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
		return fontInfo;
	}

	private static void x9ad301193e318fc1(x11e1346c12ead315 xe134235b3526fa75, x3c85359e1389ad43 x97bf2eeabd4abc7b, FontInfo xfa5e135bae569bda, EmbeddedFontStyle xb8d36db9ad45116a)
	{
		string xc06e652f250a = x97bf2eeabd4abc7b.xf3ea3ee1c9ee5265();
		string text = x97bf2eeabd4abc7b.xd68abcd61e368af9("fontKey", null);
		bool xa41bb3cedcce769d = x97bf2eeabd4abc7b.x9c1302ecb6c4f3a2("subsetted", xc6e85c82d0d89508: false);
		byte[] array = xe134235b3526fa75.xc0d748bf95efe833(xc06e652f250a);
		if (text != null)
		{
			x8b8b2d207d13a328.xd793f79da39af8af(array, text);
		}
		array = xe134235b3526fa75.x622213a14a0645f2(array);
		xfa5e135bae569bda.x88b4954c294baf8f(array, EmbeddedFontFormat.OpenType, xb8d36db9ad45116a, xa41bb3cedcce769d);
	}
}
