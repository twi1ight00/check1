using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Saving;
using x1c8faa688b1f0b0c;
using x28925c9b27b37a46;
using x59d6a4fc5007b7a4;
using x6a42c37b95e9caa1;
using xf9a9481c3f63a419;

namespace x077e797660ceec8d;

internal class x39513200ff58c2e3 : x3d2908992e1d1667
{
	private ImageSaveOptions x1cb867f3d40f3203;

	private xcde671c53995c411 x6e31545a80821a3e;

	private xdeb77ea37ad74c56 xd5f4d4b5bdd8e58a;

	private SaveOutputParameters x8cac5adfe79bc025(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		x1cb867f3d40f3203 = (ImageSaveOptions)x5ac1382edb7bf2c2.xf57de0fd37d5e97d;
		Document x2c8c6741422a = x5ac1382edb7bf2c2.x2c8c6741422a1298;
		x6e31545a80821a3e = x2c8c6741422a.xcde671c53995c411;
		xd5f4d4b5bdd8e58a = x2c8c6741422a.xdeb77ea37ad74c56;
		int num = 1;
		if (x1cb867f3d40f3203.SaveFormat == SaveFormat.Tiff)
		{
			num = ((x1cb867f3d40f3203.PageCount == int.MaxValue) ? x6e31545a80821a3e.xd44988f225497f3a : x1cb867f3d40f3203.PageCount);
		}
		x0c90271e80b9c1ce(x1cb867f3d40f3203.PageIndex, num);
		if (x1cb867f3d40f3203.SaveFormat == SaveFormat.Tiff && num > 1)
		{
			x19700a3ae5522c70(num, x5ac1382edb7bf2c2.xb8a774e0111d0fbe);
		}
		else
		{
			x53c5cdce403a6243(x5ac1382edb7bf2c2.xb8a774e0111d0fbe);
		}
		return new SaveOutputParameters(x4174cf11d3326281(x1cb867f3d40f3203.SaveFormat));
	}

	SaveOutputParameters x3d2908992e1d1667.xa2e0b7f7da663553(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x8cac5adfe79bc025
		return this.x8cac5adfe79bc025(x5ac1382edb7bf2c2);
	}

	private void x19700a3ae5522c70(int x7eefaa679a020ea6, Stream xcf18e5243f8d5fd3)
	{
		if (x7eefaa679a020ea6 < 2)
		{
			throw new ArgumentOutOfRangeException("actualPageCount");
		}
		int pageIndex = x1cb867f3d40f3203.PageIndex;
		int num = pageIndex + x7eefaa679a020ea6;
		using x3cd5d648729cd9b6 x3cd5d648729cd9b = x6c547a819272949b(pageIndex++);
		using xebe2492c6fd44f51 xebe2492c6fd44f = new xebe2492c6fd44f51();
		xebe2492c6fd44f.x2c68b59bdffce478(x3cd5d648729cd9b.x45634637f3d108db(), xcf18e5243f8d5fd3, x1cb867f3d40f3203.x858159a2ee718ca5, x5229aac0e655112a: true);
		while (pageIndex < num)
		{
			using x3cd5d648729cd9b6 xe205f0cd = x6c547a819272949b(pageIndex++);
			xebe2492c6fd44f.xf111a06c3ff6a33d(xe205f0cd);
		}
		xebe2492c6fd44f.x95ce6f08245274c1();
	}

	private void x53c5cdce403a6243(Stream xcf18e5243f8d5fd3)
	{
		xc67adcdbca121a26 xc67adcdbca121a = xd381d35c6170f2ab(x1cb867f3d40f3203.PageIndex);
		x0a376fc3a80043f7.x53c5cdce403a6243(xc67adcdbca121a, xc67adcdbca121a.x437e3b626c0fdd43, xcf18e5243f8d5fd3, x1cb867f3d40f3203);
	}

	private x3cd5d648729cd9b6 x6c547a819272949b(int xbf13a47a02af0066)
	{
		xc67adcdbca121a26 xc67adcdbca121a = xd381d35c6170f2ab(xbf13a47a02af0066);
		return x0a376fc3a80043f7.xf5af41f85264e71d(xc67adcdbca121a, xc67adcdbca121a.x437e3b626c0fdd43, x1cb867f3d40f3203);
	}

	private xc67adcdbca121a26 xd381d35c6170f2ab(int xbf13a47a02af0066)
	{
		xdcf47a8f1807f37c x32eaf67d0ee57cb = x6e31545a80821a3e.get_xe6d4b1b411ed94b5(xbf13a47a02af0066);
		xfef22f4f866de8d2 xfef22f4f866de8d = new xfef22f4f866de8d2();
		return xfef22f4f866de8d.xe406325e56f74b46(x32eaf67d0ee57cb, xd5f4d4b5bdd8e58a);
	}

	private void x0c90271e80b9c1ce(int xbf13a47a02af0066, int x0375600be29bf902)
	{
		int xd44988f225497f3a = x6e31545a80821a3e.xd44988f225497f3a;
		if (xbf13a47a02af0066 < 0 || xbf13a47a02af0066 > xd44988f225497f3a - 1)
		{
			throw new ArgumentOutOfRangeException("pageIndex");
		}
		if (x0375600be29bf902 < 1 || xbf13a47a02af0066 + x0375600be29bf902 > xd44988f225497f3a)
		{
			throw new ArgumentOutOfRangeException("pageCount");
		}
	}

	private static string x4174cf11d3326281(SaveFormat xd003f66121eb36a0)
	{
		return xd003f66121eb36a0 switch
		{
			SaveFormat.Emf => "image/x-emf", 
			SaveFormat.Tiff => "image/tiff", 
			SaveFormat.Png => "image/png", 
			SaveFormat.Bmp => "image/bmp", 
			SaveFormat.Jpeg => "image/jpeg", 
			_ => throw new InvalidOperationException("Unknown save format requested."), 
		};
	}
}
