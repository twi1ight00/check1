using x6c95d9cf46ff5f25;

namespace Aspose.Words;

public class BookmarkStart : Node
{
	internal const int xbf3cff60054fdc72 = 40;

	private string xc61ff88f1f98652d = "";

	private int xdda6cfd28220b3fb;

	public override NodeType NodeType => NodeType.BookmarkStart;

	public string Name => xc61ff88f1f98652d;

	public Bookmark Bookmark => new Bookmark(this);

	internal int x586b7652ac7cefe0 => xdda6cfd28220b3fb;

	internal bool xf1b59c88b25f8eec => (xdda6cfd28220b3fb & 0x8000) == 32768;

	internal int xb78c16d5f2d4f2f7
	{
		get
		{
			return xdda6cfd28220b3fb & 0x7F;
		}
		set
		{
			int num = xdda6cfd28220b3fb;
			num &= -128;
			num |= value & 0x7F;
			num |= 0x8000;
			xdda6cfd28220b3fb = num;
		}
	}

	internal int x279da4adfba57f2d
	{
		get
		{
			return (xdda6cfd28220b3fb & 0x7F00) >> 8;
		}
		set
		{
			int num = xdda6cfd28220b3fb;
			num &= -32513;
			num |= (value & 0x7F) << 8;
			num |= 0x8000;
			xdda6cfd28220b3fb = num;
		}
	}

	public BookmarkStart(DocumentBase doc, string name)
		: this(doc, name, 0)
	{
	}

	internal BookmarkStart(DocumentBase doc)
		: base(doc)
	{
	}

	internal BookmarkStart(DocumentBase doc, string name, int flags)
		: base(doc)
	{
		x0d299f323d241756.x0aaaea7864a53f26(name, "name");
		xc61ff88f1f98652d = name;
		xdda6cfd28220b3fb = flags;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return Node.x9708eba393e07242(visitor.VisitBookmarkStart(this));
	}

	public override string GetText()
	{
		return string.Empty;
	}

	internal void x54f99ef1e934e59c(string xc15bd84e01929885)
	{
		x0d299f323d241756.x0aaaea7864a53f26(xc15bd84e01929885, "name");
		xc61ff88f1f98652d = xc15bd84e01929885;
	}
}
