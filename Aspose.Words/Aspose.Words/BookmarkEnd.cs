using x6c95d9cf46ff5f25;

namespace Aspose.Words;

public class BookmarkEnd : Node
{
	internal const int xbf3cff60054fdc72 = 40;

	private string xc61ff88f1f98652d = "";

	public override NodeType NodeType => NodeType.BookmarkEnd;

	public string Name => xc61ff88f1f98652d;

	public BookmarkEnd(DocumentBase doc, string name)
		: base(doc)
	{
		x0d299f323d241756.x0aaaea7864a53f26(name, "name");
		xc61ff88f1f98652d = name;
	}

	internal BookmarkEnd(DocumentBase doc)
		: base(doc)
	{
	}

	internal void x54f99ef1e934e59c(string xc15bd84e01929885)
	{
		x0d299f323d241756.x0aaaea7864a53f26(xc15bd84e01929885, "name");
		xc61ff88f1f98652d = xc15bd84e01929885;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return Node.x9708eba393e07242(visitor.VisitBookmarkEnd(this));
	}
}
