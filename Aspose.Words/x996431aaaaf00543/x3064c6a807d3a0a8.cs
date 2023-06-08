using System.Drawing;
using System.IO;
using System.Xml;
using Aspose;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;
using x8784bdb393e53e65;
using x8bb6b4f09b5230a5;
using x95bd05bb616368d3;
using x9e34b6f7e9185197;
using xf9a9481c3f63a419;

namespace x996431aaaaf00543;

internal class x3064c6a807d3a0a8
{
	private xe9481907c579c280 xd995695f8e3419d6;

	private xc3771fe1bb35895f xe2402942d9938b17;

	private xb90920c8e2771a6c x7557677325090916;

	private xcfcf83824997a909 x33f4de5340c65cea;

	private x69d6218f270f1b49 x7450cc1e48712286;

	private bool x6a88a8f13e7d575c;

	internal xc3771fe1bb35895f xc3771fe1bb35895f
	{
		get
		{
			if (xe2402942d9938b17 == null)
			{
				xe2402942d9938b17 = new xc3771fe1bb35895f(xd995695f8e3419d6);
			}
			return xe2402942d9938b17;
		}
		set
		{
			xe2402942d9938b17 = value;
		}
	}

	internal xb90920c8e2771a6c xb90920c8e2771a6c
	{
		get
		{
			if (x7557677325090916 == null)
			{
				x7557677325090916 = new xb90920c8e2771a6c(xd995695f8e3419d6);
			}
			return x7557677325090916;
		}
		set
		{
			x7557677325090916 = value;
		}
	}

	internal xcfcf83824997a909 xcfcf83824997a909
	{
		get
		{
			if (x33f4de5340c65cea == null)
			{
				x33f4de5340c65cea = new xcfcf83824997a909(xd995695f8e3419d6);
			}
			return x33f4de5340c65cea;
		}
		set
		{
			x33f4de5340c65cea = value;
		}
	}

	public x3064c6a807d3a0a8(x6ecdfaec63740001 themeProvider, x1709225c4bd1ed83 dataProvider, x54b98d0096d7251a warningCallback)
	{
		xd995695f8e3419d6 = new x28b4ef62913b051b
		{
			x2898a4fa3477fa50 = themeProvider,
			xe9e9c556ec0c3e33 = dataProvider,
			xf69ca7a9bb4a4a51 = warningCallback
		};
	}

	[JavaConvertCheckedExceptions]
	public xe56ce0e761e4e9ea x5b81632e5b71b64c(XmlDocument x5510939d5b9dcd91, SizeF xbc26217ba3290abe, x56ef2519e07fdbb4 x10154c16e21df88a)
	{
		using MemoryStream memoryStream = new MemoryStream();
		xd165c26d81eb4a1e.x8ebf37a8980eb562(x5510939d5b9dcd91, memoryStream);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		x7450cc1e48712286 = new x69d6218f270f1b49(memoryStream);
		x18041b360bf02656 x18041b360bf2657 = xffe8719b6d87d067();
		if (x18041b360bf2657 == null)
		{
			xd995695f8e3419d6.xf69ca7a9bb4a4a51.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x42daab0e7e499260, x3959df40367ac8a3.xc37a0b27f6a0dfd4, "DrawingML smart art is not supported.");
			return null;
		}
		x2094302a66c2ec77 x2094302a66c2ec78 = new x2094302a66c2ec77(xd995695f8e3419d6);
		x2094302a66c2ec78.x43e348908d6e68da = xbc26217ba3290abe;
		xb8e7e788f6d59708 xb8e7e788f6d = (xb8e7e788f6d59708)x18041b360bf2657.Render(x2094302a66c2ec78);
		RectangleF boundingBox = x55fe8a62afa91ade(xb8e7e788f6d);
		xe56ce0e761e4e9ea xe56ce0e761e4e9ea2 = new xe56ce0e761e4e9ea(xb8e7e788f6d, boundingBox);
		if (x6a88a8f13e7d575c)
		{
			xe56ce0e761e4e9ea2.x1601b59463fd995a(xbc26217ba3290abe);
		}
		else
		{
			x78e18bdf9a108059 transform = x18041b360bf2657.GetTransform();
			float x2f9aa2aec94ad2fb = (float)x4574ea26106f0edb.xa23e6b6c3169521d(transform.xdc1bf80853046136);
			float x55a22ee0f14038b = (float)x4574ea26106f0edb.xa23e6b6c3169521d(transform.x1be93eed8950d961);
			xe56ce0e761e4e9ea2.xf866d88e8aa6d4a3(x2f9aa2aec94ad2fb, x55a22ee0f14038b, xbc26217ba3290abe);
		}
		xe56ce0e761e4e9ea2.xd73aad34130a5d8c(x10154c16e21df88a);
		return xe56ce0e761e4e9ea2;
	}

	private RectangleF x55fe8a62afa91ade(xb8e7e788f6d59708 x08ce8f4769eb3234)
	{
		x8abed58e51c8641c x8abed58e51c8641c = new x8abed58e51c8641c();
		return x8abed58e51c8641c.xb1de1ba20faeeff8(x08ce8f4769eb3234);
	}

	private x18041b360bf02656 xffe8719b6d87d067()
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("graphic"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "graphicData")
			{
				return x85d408c887af682f();
			}
			x7450cc1e48712286.IgnoreElement();
		}
		return null;
	}

	private x18041b360bf02656 x85d408c887af682f()
	{
		while (x7450cc1e48712286.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null)
			{
				_ = xa66385d80d4d296f == "uri";
			}
		}
		while (x7450cc1e48712286.x152cbadbfa8061b1("graphicData"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "lockedCanvas":
				x6a88a8f13e7d575c = true;
				return xc3771fe1bb35895f.x46fa9da8bbd8388c(x7450cc1e48712286);
			case "pic":
				x6a88a8f13e7d575c = false;
				return xb90920c8e2771a6c.xda09af88ab899a50(x7450cc1e48712286);
			case "chart":
				x6a88a8f13e7d575c = false;
				return xcfcf83824997a909.x6326991a5dd21743(x7450cc1e48712286);
			}
			x7450cc1e48712286.IgnoreElement();
		}
		return null;
	}
}
