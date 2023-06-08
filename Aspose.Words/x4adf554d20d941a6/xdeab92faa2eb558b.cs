using System;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class xdeab92faa2eb558b : xcf9d359063aa93f2
{
	internal static readonly x8e3db3d2a7fdbd41 x017043e01a3905d0;

	private int xa64b5a7bb6ad890e = x21708a6b561aa4e4;

	private bool xd75ea86f450133e4 = x0fc0bd390d8ac716;

	private x8e3db3d2a7fdbd41 x5f8c1ae0800942b6 = x017043e01a3905d0;

	private bool xe16c075635d1d26b = xcfd75d503189c331;

	private static bool xcfd75d503189c331;

	private static readonly int x21708a6b561aa4e4;

	private static readonly bool x0fc0bd390d8ac716;

	internal override bool xe76bdd563aa52beb => true;

	internal int x39043a80f49a07e2
	{
		get
		{
			return xa64b5a7bb6ad890e;
		}
		set
		{
			x71c6d753219cc1b7();
			xa64b5a7bb6ad890e = value;
		}
	}

	internal bool x87119342b85a2a43
	{
		get
		{
			return xd75ea86f450133e4;
		}
		set
		{
			x71c6d753219cc1b7();
			xd75ea86f450133e4 = value;
		}
	}

	internal x8e3db3d2a7fdbd41 x109e3389933c23a8
	{
		get
		{
			if (x5f8c1ae0800942b6 == null)
			{
				x5f8c1ae0800942b6 = new x8e3db3d2a7fdbd41(x17dcbf5fe3c0d2d2, initKey: false);
				x5f8c1ae0800942b6.xab6edfb47ff0b74c = x017043e01a3905d0.xab6edfb47ff0b74c;
				x5f8c1ae0800942b6.x72d92bd1aff02e37 = x017043e01a3905d0.x72d92bd1aff02e37;
				x5f8c1ae0800942b6.xe360b1885d8d4a41 = x017043e01a3905d0.xe360b1885d8d4a41;
				x5f8c1ae0800942b6.x0fcdf9c7f9f2eb9e = x017043e01a3905d0.x0fcdf9c7f9f2eb9e;
				x5f8c1ae0800942b6.xab67cb9464a3325b = x017043e01a3905d0.xab67cb9464a3325b;
				x5f8c1ae0800942b6.xf6ce0e8106e6a1d8 = x017043e01a3905d0.xf6ce0e8106e6a1d8;
				x5f8c1ae0800942b6.x5d0ebb82ae68cc43 = x017043e01a3905d0.x5d0ebb82ae68cc43;
			}
			return x5f8c1ae0800942b6;
		}
		set
		{
			x71c6d753219cc1b7();
			x5f8c1ae0800942b6 = value;
		}
	}

	internal bool x2ac6c66ecbcafe54
	{
		get
		{
			return xe16c075635d1d26b;
		}
		set
		{
			x71c6d753219cc1b7();
			xe16c075635d1d26b = value;
		}
	}

	internal xdeab92faa2eb558b(x17dcbf5fe3c0d2d2 context)
		: base(context)
	{
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (!x39f156868f37b760(obj))
		{
			return false;
		}
		xdeab92faa2eb558b xdeab92faa2eb558b2 = (xdeab92faa2eb558b)obj;
		return x39043a80f49a07e2.Equals(xdeab92faa2eb558b2.x39043a80f49a07e2) && x87119342b85a2a43 == xdeab92faa2eb558b2.x87119342b85a2a43 && x2ac6c66ecbcafe54 == xdeab92faa2eb558b2.x2ac6c66ecbcafe54 && object.Equals(x109e3389933c23a8, xdeab92faa2eb558b2.x109e3389933c23a8);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	protected override void AddKeysToHashCode()
	{
		x1e94bce19c84490b(x39043a80f49a07e2);
		x1e94bce19c84490b(x87119342b85a2a43);
		x1e94bce19c84490b(x2ac6c66ecbcafe54);
		xd94964d84c426258(x109e3389933c23a8);
	}

	internal static xdeab92faa2eb558b x38758cbbee49e4cb(xdeab92faa2eb558b x50a18ad2656e7181)
	{
		if (x50a18ad2656e7181 == null)
		{
			x50a18ad2656e7181 = new xdeab92faa2eb558b(null);
		}
		if (x50a18ad2656e7181.x17dcbf5fe3c0d2d2 == null)
		{
			return x50a18ad2656e7181;
		}
		if (x50a18ad2656e7181.xe76bdd563aa52beb)
		{
			return x50a18ad2656e7181;
		}
		xdeab92faa2eb558b xdeab92faa2eb558b2 = (xdeab92faa2eb558b)x50a18ad2656e7181.x17dcbf5fe3c0d2d2.xf7125312c7ee115c[x50a18ad2656e7181];
		if (xdeab92faa2eb558b2 == null)
		{
			x50a18ad2656e7181.x17dcbf5fe3c0d2d2.xf7125312c7ee115c.Add(x50a18ad2656e7181, xdeab92faa2eb558b2 = x50a18ad2656e7181);
		}
		return xdeab92faa2eb558b2;
	}

	internal static int x31ae04883db2d985(WrapType x1b33630b689cfddb, int xeae4dc1cc60de736, bool x4bc6b3ad6bc5ebf9)
	{
		if (x1b33630b689cfddb == WrapType.Inline)
		{
			return 0;
		}
		return (x4bc6b3ad6bc5ebf9 ? int.MinValue : 0) + Math.Max(0, xeae4dc1cc60de736) + 1;
	}

	static xdeab92faa2eb558b()
	{
		x0fc0bd390d8ac716 = (bool)xf7125312c7ee115c.x0095b789d636f3ae(944);
		x21708a6b561aa4e4 = x31ae04883db2d985((WrapType)xf7125312c7ee115c.x0095b789d636f3ae(4097), (int)xf7125312c7ee115c.x0095b789d636f3ae(4154), (bool)xf7125312c7ee115c.x0095b789d636f3ae(954));
		x0fc0bd390d8ac716 = (bool)xf7125312c7ee115c.x0095b789d636f3ae(944);
		xcfd75d503189c331 = (bool)xf7125312c7ee115c.x0095b789d636f3ae(948);
		x017043e01a3905d0 = new x8e3db3d2a7fdbd41(null, initKey: false);
		x017043e01a3905d0.xab6edfb47ff0b74c = WrapType.None;
		x017043e01a3905d0.x72d92bd1aff02e37 = x4574ea26106f0edb.x8d50b8a62ba1cd84(0.0);
		x017043e01a3905d0.xe360b1885d8d4a41 = x4574ea26106f0edb.x8d50b8a62ba1cd84(0.0);
		x017043e01a3905d0.x0fcdf9c7f9f2eb9e = RelativeHorizontalPosition.Column;
		x017043e01a3905d0.xab67cb9464a3325b = HorizontalAlignment.None;
		x017043e01a3905d0.xf6ce0e8106e6a1d8 = VerticalAlignment.None;
		x017043e01a3905d0.x5d0ebb82ae68cc43 = RelativeVerticalPosition.Paragraph;
		x017043e01a3905d0.xed344a170caf7ac3 = true;
		x017043e01a3905d0.GetHashCode();
	}
}
