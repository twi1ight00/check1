using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;

namespace x4f4df92b75ba3b67;

internal class xd99feecae3b0ba7a : xcb3d00e64f2216e5
{
	private readonly xcd986872cf3bcf68 xe65db51216614d6f;

	private readonly xb5ab0d03444f8c24 x7714c03e65207361;

	internal override bool xc668392aa770aaef => true;

	internal xb5ab0d03444f8c24 xe8b46cb1a427b4f6 => x7714c03e65207361;

	internal xcd986872cf3bcf68 x968fd3630f239305 => xe65db51216614d6f;

	internal xd99feecae3b0ba7a(x6b1a899052c71a60 font, x4882ae789be6e2ef context)
		: base(font)
	{
		xe65db51216614d6f = x734f4f9d70307a0f(font, context);
		x7714c03e65207361 = x4545fd6adb8b7fed(context, xe65db51216614d6f);
	}

	private static xcd986872cf3bcf68 x734f4f9d70307a0f(x6b1a899052c71a60 x26094932cf7a9139, x4882ae789be6e2ef x0f7b23d1c393aed9)
	{
		xcd986872cf3bcf68 xcd986872cf3bcf = x26094932cf7a9139.x78789688b9fe78d2(x0f7b23d1c393aed9.x73979cef1002ed01.x977582846a207e5e, !x0f7b23d1c393aed9.x73979cef1002ed01.x977582846a207e5e && x0f7b23d1c393aed9.x73979cef1002ed01.x0b744c5c26c5b3b3 == xb587de0cfcf15643.xa0ff1e9eba3c108d);
		xcd986872cf3bcf.x3452aa488cc9006d(65);
		return xcd986872cf3bcf;
	}

	private static xb5ab0d03444f8c24 x4545fd6adb8b7fed(x4882ae789be6e2ef x0f7b23d1c393aed9, xcd986872cf3bcf68 xb1561dfd709a9b5a)
	{
		if (xb1561dfd709a9b5a.x29f65b3e7616f6b3.xba2310b1d8e576ad)
		{
			return new x36f3cc9da1a9048d(x0f7b23d1c393aed9, "/CIDFontType0C", xb1561dfd709a9b5a);
		}
		return new xaed01f450602b405(x0f7b23d1c393aed9, xb1561dfd709a9b5a);
	}

	internal override bool xd116716bb9acc746(string xb41faee6912a2313)
	{
		bool result = false;
		foreach (int item in new x115139807e6482f7(xb41faee6912a2313))
		{
			if (x968fd3630f239305.x3452aa488cc9006d(item) <= 0)
			{
				result = true;
			}
		}
		return result;
	}

	internal override int x5827fed50444ba26()
	{
		int num = x7819ee089c842c62.x2c954a87e3cd6144;
		for (int i = 0; i < x968fd3630f239305.x8f0b229fb69d4269.xd44988f225497f3a; i++)
		{
			int x079b6eca7602c = x968fd3630f239305.x8f0b229fb69d4269.xf15263674eb297bb(i);
			if (x7819ee089c842c62.xc3b52d8fb3995dd1(x079b6eca7602c))
			{
				int num2 = x7819ee089c842c62.x616408f81e1cc0f1(x079b6eca7602c);
				num = ((num > num2) ? num2 : num);
			}
		}
		return num;
	}

	internal override int xb6ce281bc6a25482()
	{
		int num = x7819ee089c842c62.x5daf4fa8d3eca37d;
		for (int i = 0; i < x968fd3630f239305.x8f0b229fb69d4269.xd44988f225497f3a; i++)
		{
			int x079b6eca7602c = x968fd3630f239305.x8f0b229fb69d4269.xf15263674eb297bb(i);
			if (x7819ee089c842c62.xc3b52d8fb3995dd1(x079b6eca7602c))
			{
				int num2 = x7819ee089c842c62.x616408f81e1cc0f1(x079b6eca7602c);
				num = ((num < num2) ? num2 : num);
			}
		}
		return num;
	}

	internal override void xb98ce8f1ed7517e8(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.xa4dc0ad8886e23a2(xe8b46cb1a427b4f6.x612c0155ea8cfdfa, xe8b46cb1a427b4f6.x899a2110a8a35fda);
	}
}
