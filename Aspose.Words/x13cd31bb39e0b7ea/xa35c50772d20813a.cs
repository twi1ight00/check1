using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.Math;
using xe5b37aee2c2a4d4e;

namespace x13cd31bb39e0b7ea;

internal class xa35c50772d20813a
{
	private enum x89112c07fa771a28
	{
		xe45639e45009687f,
		x0d39c0715b186fbf,
		x2e35cd578fb843c3
	}

	private x89112c07fa771a28 xdf6b6b5096b274b9;

	private int xc9bdbf0e5ca18249;

	private int xeea8a4d5c7166457;

	private int x1a6988d00dbc4502;

	private readonly bool x87c375247bb278f8;

	private readonly Hashtable x77b1595b6d53b7e1;

	private readonly DocumentBase x232be220f517f721;

	internal xa35c50772d20813a(bool reconstructMissingArguments, DocumentBase doc)
	{
		x232be220f517f721 = doc;
		x87c375247bb278f8 = reconstructMissingArguments;
		if (x87c375247bb278f8)
		{
			x77b1595b6d53b7e1 = new Hashtable();
		}
	}

	internal static bool x824a132df9284c08(OfficeMath x203bd7b4a3be8d02)
	{
		x3e68720d12325f49 x3e68720d12325f = x203bd7b4a3be8d02.x52642f91ccdeeb35.x3e68720d12325f49;
		if (x3e68720d12325f != x3e68720d12325f49.x3d0bfd5419916b93)
		{
			return x3e68720d12325f == x3e68720d12325f49.x1745ba6c6d5efbc4;
		}
		return true;
	}

	internal VisitorAction xe2d69851fb4d6421(OfficeMath x203bd7b4a3be8d02)
	{
		switch (xdf6b6b5096b274b9)
		{
		case x89112c07fa771a28.xe45639e45009687f:
			if (x203bd7b4a3be8d02.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x3d0bfd5419916b93)
			{
				xdf6b6b5096b274b9 = x89112c07fa771a28.x0d39c0715b186fbf;
				xc9bdbf0e5ca18249 = 0;
			}
			break;
		case x89112c07fa771a28.x0d39c0715b186fbf:
			if (x203bd7b4a3be8d02.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x1745ba6c6d5efbc4)
			{
				xc9bdbf0e5ca18249++;
				xeea8a4d5c7166457 = 1;
				xdf6b6b5096b274b9 = x89112c07fa771a28.x2e35cd578fb843c3;
			}
			break;
		case x89112c07fa771a28.x2e35cd578fb843c3:
			if (x203bd7b4a3be8d02.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x1745ba6c6d5efbc4)
			{
				xeea8a4d5c7166457++;
			}
			break;
		default:
			throw new InvalidOperationException("Please report exception");
		}
		return VisitorAction.Continue;
	}

	internal VisitorAction xb678a1dd33952080(OfficeMath x203bd7b4a3be8d02)
	{
		switch (xdf6b6b5096b274b9)
		{
		case x89112c07fa771a28.xe45639e45009687f:
			if (x203bd7b4a3be8d02.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x30727a59b1643735)
			{
				((xa097a2be55e6fe20)x203bd7b4a3be8d02.x52642f91ccdeeb35).xe9e7cd52b91094f9.xf84614781814c042(x1a6988d00dbc4502);
				if (x87c375247bb278f8)
				{
					x2256a6ecc64fb0c6();
				}
			}
			break;
		case x89112c07fa771a28.x0d39c0715b186fbf:
			if (x203bd7b4a3be8d02.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x3d0bfd5419916b93)
			{
				xdf6b6b5096b274b9 = x89112c07fa771a28.xe45639e45009687f;
				if (x1a6988d00dbc4502 < xc9bdbf0e5ca18249)
				{
					x1a6988d00dbc4502 = xc9bdbf0e5ca18249;
				}
				if (x87c375247bb278f8)
				{
					x77b1595b6d53b7e1.Add(x203bd7b4a3be8d02, xc9bdbf0e5ca18249);
				}
			}
			break;
		case x89112c07fa771a28.x2e35cd578fb843c3:
			if (x203bd7b4a3be8d02.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x1745ba6c6d5efbc4)
			{
				xeea8a4d5c7166457--;
				if (xeea8a4d5c7166457 == 0)
				{
					xdf6b6b5096b274b9 = x89112c07fa771a28.x0d39c0715b186fbf;
				}
			}
			break;
		default:
			throw new InvalidOperationException("Please report exception");
		}
		return VisitorAction.Continue;
	}

	private void x2256a6ecc64fb0c6()
	{
		foreach (OfficeMath key in x77b1595b6d53b7e1.Keys)
		{
			int num = x1a6988d00dbc4502 - (int)x77b1595b6d53b7e1[key];
			for (int i = 0; i < num; i++)
			{
				key.PrependChild(new OfficeMath(x232be220f517f721, new xb4dde217cd172a7b(x3e68720d12325f49.x1745ba6c6d5efbc4)));
			}
		}
	}
}
