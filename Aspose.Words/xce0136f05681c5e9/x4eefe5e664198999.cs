using Aspose.Words;
using x28925c9b27b37a46;
using x66dd9eaee57cfba4;

namespace xce0136f05681c5e9;

internal class x4eefe5e664198999
{
	private readonly DocumentBase xd1424e1a0bb4a72b;

	private readonly xe2ff3c3cd396cfd9 x18ddd758cd8495e3;

	private readonly x202941c978357b4f x7e0bc249ae734293;

	private readonly xe98f79ab11a30ea7 xbf77f1b25eb10db0;

	private readonly xbaf8b2953ab3e261 x44f66dc3f12ea6cf;

	private x515d2f71e3e1988e xe1410f585439c7d4 => x18ddd758cd8495e3.xe1410f585439c7d4;

	internal x4eefe5e664198999(DocumentBase document, xe2ff3c3cd396cfd9 writerCommon, x202941c978357b4f styleWriter, xe98f79ab11a30ea7 i18nWriter)
	{
		xd1424e1a0bb4a72b = document;
		x18ddd758cd8495e3 = writerCommon;
		x7e0bc249ae734293 = styleWriter;
		xbf77f1b25eb10db0 = i18nWriter;
		x44f66dc3f12ea6cf = new xbaf8b2953ab3e261();
	}

	internal void x7e87e53a0ba2f770(Font x26094932cf7a9139, string xb41faee6912a2313, x000f21cbda739311 xcb075c7088c3b520, bool x07532f30a274f493, bool xf544375d86767c28)
	{
		xe1410f585439c7d4.xd52401bdf5aacef6("<span");
		x7e0bc249ae734293.xabeba2b272a12ca7(x26094932cf7a9139, xcb075c7088c3b520, xf544375d86767c28);
		xbf77f1b25eb10db0.xeded1061813a0ab1(x26094932cf7a9139);
		xe1410f585439c7d4.xd52401bdf5aacef6(">");
		x6b1a899052c71a60 x6b1a899052c71a = xd1424e1a0bb4a72b.FontInfos.x26ee10d60756aeab.FetchTTFont(x26094932cf7a9139.xaf95fb496eb25433(xcb075c7088c3b520), x26094932cf7a9139.xfa47517dba72fd20, null);
		xb41faee6912a2313 = x6b1a899052c71a.x839c39284cd04767(xb41faee6912a2313);
		xb41faee6912a2313 = x44f66dc3f12ea6cf.x83793d947b8211ad(xb41faee6912a2313);
		if (x07532f30a274f493)
		{
			xe1410f585439c7d4.x3d1be38abe5723e3(xb41faee6912a2313);
		}
		else
		{
			xe1410f585439c7d4.xd52401bdf5aacef6(xb41faee6912a2313);
		}
		xe1410f585439c7d4.xd52401bdf5aacef6("</span>");
	}

	internal void x4f6533d333848d34(Font x26094932cf7a9139, bool xf544375d86767c28)
	{
		x7e87e53a0ba2f770(x26094932cf7a9139, "&#xa0;", x000f21cbda739311.x175297738c8b8d1e, x07532f30a274f493: false, xf544375d86767c28);
	}
}
