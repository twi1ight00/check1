using System;
using System.Drawing.Drawing2D;
using System.IO;
using Aspose;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x4f4df92b75ba3b67;

internal class x20a936294adb09c3 : x585f64260eb07f7b
{
	private const int x25c4fc0c303931ae = 10000;

	private byte[] xd08494dce3b2b550;

	private int xc870c20d40920a8c;

	private int x42e5c99daad7b47e;

	private x54366fa5f75a02f7 x46dc07fda422a02f;

	private WrapMode x95f514a4b958699a;

	private readonly int xcc4a525a8e257473;

	private readonly x5e9754e56a4f759f xa31c8fed8093bc20;

	private bool x45a5e303546e652a;

	protected override x54366fa5f75a02f7 BrushTransform => x46dc07fda422a02f;

	protected override int TileWidth
	{
		get
		{
			x38ef28be92579963();
			switch (x95f514a4b958699a)
			{
			case WrapMode.Tile:
			case WrapMode.TileFlipY:
				return x42e5c99daad7b47e;
			case WrapMode.TileFlipX:
			case WrapMode.TileFlipXY:
				return x42e5c99daad7b47e * 2;
			case WrapMode.Clamp:
				return 10000;
			default:
				throw new InvalidOperationException("Not supported brush wrap mode.");
			}
		}
	}

	protected override int TileHeight
	{
		get
		{
			x38ef28be92579963();
			switch (x95f514a4b958699a)
			{
			case WrapMode.Tile:
			case WrapMode.TileFlipX:
				return xc870c20d40920a8c;
			case WrapMode.TileFlipY:
			case WrapMode.TileFlipXY:
				return xc870c20d40920a8c * 2;
			case WrapMode.Clamp:
				return 10000;
			default:
				throw new InvalidOperationException("Not supported brush wrap mode.");
			}
		}
	}

	public x20a936294adb09c3(x4882ae789be6e2ef context, x5e9754e56a4f759f brush)
		: base(context)
	{
		xa31c8fed8093bc20 = brush;
		x46dc07fda422a02f = brush.xaccac17571a8d9fa;
		x95f514a4b958699a = brush.x349ff0df1e641b4e;
		x46dc07fda422a02f = brush.xaccac17571a8d9fa;
		x95f514a4b958699a = brush.x349ff0df1e641b4e;
		if (brush.xcc18177a965e0313 != null)
		{
			xcc4a525a8e257473 = brush.xcc18177a965e0313.GetHashCode();
		}
	}

	protected override void WriteStream()
	{
		x38ef28be92579963();
		switch (x95f514a4b958699a)
		{
		case WrapMode.Tile:
		case WrapMode.Clamp:
			xdb55316cd005e09a.x27335b788ad093c5(xd08494dce3b2b550, x9cccc39a9aedb161(), null, null);
			break;
		case WrapMode.TileFlipX:
			xdb55316cd005e09a.x27335b788ad093c5(xd08494dce3b2b550, x9cccc39a9aedb161(), null, null);
			xdb55316cd005e09a.x27335b788ad093c5(xd08494dce3b2b550, x4100fa8403c26422(), null, null);
			break;
		case WrapMode.TileFlipY:
			xdb55316cd005e09a.x27335b788ad093c5(xd08494dce3b2b550, x9cccc39a9aedb161(), null, null);
			xdb55316cd005e09a.x27335b788ad093c5(xd08494dce3b2b550, x08937c48ee804044(), null, null);
			break;
		case WrapMode.TileFlipXY:
			xdb55316cd005e09a.x27335b788ad093c5(xd08494dce3b2b550, x9cccc39a9aedb161(), null, null);
			xdb55316cd005e09a.x27335b788ad093c5(xd08494dce3b2b550, x4100fa8403c26422(), null, null);
			xdb55316cd005e09a.x27335b788ad093c5(xd08494dce3b2b550, x08937c48ee804044(), null, null);
			xdb55316cd005e09a.x27335b788ad093c5(xd08494dce3b2b550, x88c30f0c2fc89603(), null, null);
			break;
		default:
			throw new InvalidOperationException("Not supported brush wrap mode.");
		}
	}

	protected override bool EqualsInternal(x02cd5c9c8d54330e other)
	{
		if (!(other is x20a936294adb09c3))
		{
			return false;
		}
		x20a936294adb09c3 x20a936294adb09c4 = (x20a936294adb09c3)other;
		if (!x20a936294adb09c4.x4f8b95913da5318f(x95f514a4b958699a))
		{
			return false;
		}
		return x20a936294adb09c4.x6953d256826431bd(xcc4a525a8e257473);
	}

	private bool x4f8b95913da5318f(WrapMode xa4aa8b4150b11435)
	{
		return xa4aa8b4150b11435 == x95f514a4b958699a;
	}

	private bool x6953d256826431bd(int x936c859967ca7020)
	{
		return xcc4a525a8e257473 == x936c859967ca7020;
	}

	private x54366fa5f75a02f7 x9cccc39a9aedb161()
	{
		return new x54366fa5f75a02f7(x42e5c99daad7b47e, 0f, 0f, -xc870c20d40920a8c, 0f, xc870c20d40920a8c);
	}

	private x54366fa5f75a02f7 x4100fa8403c26422()
	{
		return new x54366fa5f75a02f7(-x42e5c99daad7b47e, 0f, 0f, -xc870c20d40920a8c, 2 * x42e5c99daad7b47e, xc870c20d40920a8c);
	}

	private x54366fa5f75a02f7 x08937c48ee804044()
	{
		return new x54366fa5f75a02f7(x42e5c99daad7b47e, 0f, 0f, xc870c20d40920a8c, 0f, xc870c20d40920a8c);
	}

	private x54366fa5f75a02f7 x88c30f0c2fc89603()
	{
		return new x54366fa5f75a02f7(-x42e5c99daad7b47e, 0f, 0f, xc870c20d40920a8c, 2 * x42e5c99daad7b47e, xc870c20d40920a8c);
	}

	[JavaConvertCheckedExceptions]
	private void x38ef28be92579963()
	{
		if (x45a5e303546e652a)
		{
			return;
		}
		using x3cd5d648729cd9b6 x3cd5d648729cd9b = new x3cd5d648729cd9b6(xa31c8fed8093bc20);
		if (x3cd5d648729cd9b.x688d6f6524ba3c8b != xfe2ff3c162b47c70.x796ab23ce57ee1e0)
		{
			using MemoryStream memoryStream = new MemoryStream();
			x3cd5d648729cd9b.x0acd3c2012ea2ee8(memoryStream, xfe2ff3c162b47c70.x6339cdb9e2b512c7);
			xd08494dce3b2b550 = x0d299f323d241756.xa0aed4cd3b3d5d92(memoryStream);
		}
		else
		{
			xd08494dce3b2b550 = xa31c8fed8093bc20.xcc18177a965e0313;
		}
		x42e5c99daad7b47e = x3cd5d648729cd9b.xdc1bf80853046136;
		xc870c20d40920a8c = x3cd5d648729cd9b.xb0f146032f47c24e;
		x45a5e303546e652a = true;
	}
}
