using Aspose.Words;
using x1495530f35d79681;
using x452f379ec5921195;
using x79578da6a8a3ae37;
using x909757d9fd2dd6ae;
using xda075892eccab2ad;

namespace x79490184cecf12a1;

internal class xd8ed588de8ef8335
{
	private xd8ed588de8ef8335()
	{
	}

	internal static void x06b0e25aa6ad68a9(x11e1346c12ead315 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3c85359e1389ad = xe134235b3526fa75.x1b1aeab2a2e668c4("http://schemas.openxmlformats.org/officeDocument/2006/relationships/webSettings");
		if (x3c85359e1389ad == null)
		{
			return;
		}
		DocumentBase x2c8c6741422a = xe134235b3526fa75.x2c8c6741422a1298;
		xdade2366eaa6f915 xdade2366eaa6f = x2c8c6741422a.xdade2366eaa6f915;
		while (x3c85359e1389ad.x152cbadbfa8061b1("webSettings"))
		{
			switch (x3c85359e1389ad.xa66385d80d4d296f)
			{
			case "frameset":
			{
				x227665e444fb500a x227665e444fb500a = new x227665e444fb500a();
				x227665e444fb500a.x3650f9b73dc5111b = x3650f9b73dc5111b.xe74f26d8f4cfb63f;
				((Document)x2c8c6741422a).x227665e444fb500a = x227665e444fb500a;
				x8834ab836c23d666.x06b0e25aa6ad68a9(xe134235b3526fa75, x227665e444fb500a, x5fbb1a9c98604ef5: true);
				break;
			}
			case "divs":
				x3c85359e1389ad.IgnoreElement();
				break;
			case "encoding":
				xdade2366eaa6f.x39cf0a6ea1f1263e = x3c85359e1389ad.xbbfc54380705e01e();
				break;
			case "optimizeForBrowser":
				xdade2366eaa6f.x35aefdf519d4db96 = x3c85359e1389ad.xe04906126da94dd1();
				while (x3c85359e1389ad.x1ac1960adc8c4c39())
				{
					if (x3c85359e1389ad.xa66385d80d4d296f == "target")
					{
						xdade2366eaa6f.x7868d665e9cfc8d9 = xa4dfc7b68138d280.x6566c52aa91f9be8(x3c85359e1389ad.xd2f68ee6f47e9dfb);
					}
				}
				break;
			case "relyOnVML":
				xdade2366eaa6f.xc2d62826afc28ce5 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "allowPNG":
				xdade2366eaa6f.xbd16abbd8b896a52 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "doNotRelyOnCSS":
				xdade2366eaa6f.x033ad91511e4e3ff = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "doNotSaveAsSingleFile":
				xdade2366eaa6f.x82cbf79051b7e083 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "doNotOrganizeInFolder":
				xdade2366eaa6f.x43d1e7077fb85de6 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "doNotUseLongFileNames":
				xdade2366eaa6f.x117cfa28c87eba97 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "pixelsPerInch":
				xdade2366eaa6f.x1115d25f593044ad = x3c85359e1389ad.xb8ac33c25776194c();
				break;
			case "targetScreenSz":
				xdade2366eaa6f.x86698283e3eda37c = x72a0c846678ecaf9.xe9e387051394a2ba(x3c85359e1389ad.xbbfc54380705e01e());
				break;
			default:
				x3c85359e1389ad.IgnoreElement();
				break;
			}
		}
		xe134235b3526fa75.xc8ab4e294c74831b();
	}
}
