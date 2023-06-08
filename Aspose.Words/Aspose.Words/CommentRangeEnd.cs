using x28925c9b27b37a46;

namespace Aspose.Words;

public class CommentRangeEnd : Node, x8ad0c0863d1cd403
{
	private int x60adf410a9cceab0;

	public int Id
	{
		get
		{
			return x60adf410a9cceab0;
		}
		set
		{
			x60adf410a9cceab0 = value;
		}
	}

	int x8ad0c0863d1cd403.xb514a0ed67981a02
	{
		get
		{
			return Id;
		}
		set
		{
			x60adf410a9cceab0 = value;
		}
	}

	public override NodeType NodeType => NodeType.CommentRangeEnd;

	public CommentRangeEnd(DocumentBase doc, int id)
		: base(doc)
	{
		x60adf410a9cceab0 = id;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return Node.x9708eba393e07242(visitor.VisitCommentRangeEnd(this));
	}
}
