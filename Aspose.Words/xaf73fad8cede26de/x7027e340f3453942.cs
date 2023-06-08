using System.Drawing;
using x6c95d9cf46ff5f25;

namespace xaf73fad8cede26de;

internal class x7027e340f3453942
{
	private x7027e340f3453942()
	{
	}

	public static void x6210059f049f0d48(x3c74b3c4f21844f9 xd07ce4b74c5774a7, SizeF x278780fb19a87271, bool x65278395acd43d58)
	{
		xf165e94d0616a73b(xd07ce4b74c5774a7);
		x47e113d773248a4b(xd07ce4b74c5774a7, x278780fb19a87271);
		xfed8bcb4c15b4e35(xd07ce4b74c5774a7, x65278395acd43d58);
		xd07ce4b74c5774a7.xa0dfc102c691b11f();
	}

	public static void x473cc59a91f47b0d(x3c74b3c4f21844f9 xd07ce4b74c5774a7)
	{
		xf165e94d0616a73b(xd07ce4b74c5774a7);
		xd07ce4b74c5774a7.xa0dfc102c691b11f();
	}

	private static void xf165e94d0616a73b(x3c74b3c4f21844f9 xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x9b9ed0109b743e3b("psf:PrintTicket");
		xd07ce4b74c5774a7.xff520a0047c27122("version", "1");
		xd07ce4b74c5774a7.xff520a0047c27122("xmlns:psf", "http://schemas.microsoft.com/windows/2003/08/printing/printschemaframework");
		xd07ce4b74c5774a7.xff520a0047c27122("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
		xd07ce4b74c5774a7.xff520a0047c27122("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
		xd07ce4b74c5774a7.xff520a0047c27122("xmlns:ns0000", "http://schemas.microsoft.com/windows/2006/06/printing/printschemakeywords/microsoftxpsdocumentwriter");
		xd07ce4b74c5774a7.xff520a0047c27122("xmlns:psk", "http://schemas.microsoft.com/windows/2003/08/printing/printschemakeywords");
	}

	private static void x47e113d773248a4b(x3c74b3c4f21844f9 xd07ce4b74c5774a7, SizeF x0ceec69a97f73617)
	{
		bool flag = x0ceec69a97f73617.Width > x0ceec69a97f73617.Height;
		int num = (flag ? x4574ea26106f0edb.x5d11bb3eea3af0d2(x0ceec69a97f73617.Height) : x4574ea26106f0edb.x5d11bb3eea3af0d2(x0ceec69a97f73617.Width));
		int num2 = (flag ? x4574ea26106f0edb.x5d11bb3eea3af0d2(x0ceec69a97f73617.Width) : x4574ea26106f0edb.x5d11bb3eea3af0d2(x0ceec69a97f73617.Height));
		xe99b2cf45664fc21(xd07ce4b74c5774a7, "psk:PageMediaSize");
		x59b89a7221b22865(xd07ce4b74c5774a7, xeed7cfd26981eeae.x575b390503ad9332(x0ceec69a97f73617, flag));
		x65201ce58ddff264(xd07ce4b74c5774a7, "psk:MediaSizeWidth");
		x1f1f55fedebae441(xd07ce4b74c5774a7, "xsd:integer", num.ToString());
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		x65201ce58ddff264(xd07ce4b74c5774a7, "psk:MediaSizeHeight");
		x1f1f55fedebae441(xd07ce4b74c5774a7, "xsd:integer", num2.ToString());
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		xe99b2cf45664fc21(xd07ce4b74c5774a7, "psk:PageOrientation");
		x59b89a7221b22865(xd07ce4b74c5774a7, flag ? "psk:Landscape" : "psk:Portrait");
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void xfed8bcb4c15b4e35(x3c74b3c4f21844f9 xd07ce4b74c5774a7, bool x65278395acd43d58)
	{
		xe99b2cf45664fc21(xd07ce4b74c5774a7, x65278395acd43d58 ? "psk:PageInputBin" : "psk:JobInputBin");
		x59b89a7221b22865(xd07ce4b74c5774a7, "psk:AutoSelect");
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void xe99b2cf45664fc21(x3c74b3c4f21844f9 xd07ce4b74c5774a7, string xd5bd92f11dc11e5f)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("psf:Feature");
		xd07ce4b74c5774a7.xff520a0047c27122("name", xd5bd92f11dc11e5f);
	}

	private static void x59b89a7221b22865(x3c74b3c4f21844f9 xd07ce4b74c5774a7, string x0dbb409c29595b7f)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("psf:Option");
		xd07ce4b74c5774a7.xff520a0047c27122("name", x0dbb409c29595b7f);
	}

	private static void x65201ce58ddff264(x3c74b3c4f21844f9 xd07ce4b74c5774a7, string xc3513c7f2bbafa84)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("psf:ScoredProperty");
		xd07ce4b74c5774a7.xff520a0047c27122("name", xc3513c7f2bbafa84);
	}

	private static void x9cd183417ab71dad(x3c74b3c4f21844f9 xd07ce4b74c5774a7, string xc3513c7f2bbafa84)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("psf:Property");
		xd07ce4b74c5774a7.xff520a0047c27122("name", xc3513c7f2bbafa84);
	}

	private static void x1f1f55fedebae441(x3c74b3c4f21844f9 xd07ce4b74c5774a7, string x9c0894a7be16d6de, string xbcea506a33cf9111)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("psf:Value");
		xd07ce4b74c5774a7.xff520a0047c27122("xsi:type", x9c0894a7be16d6de);
		xd07ce4b74c5774a7.x3d1be38abe5723e3(xbcea506a33cf9111);
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}
}
