using x28925c9b27b37a46;

namespace Aspose.Words;

public class Body : Story
{
	public override NodeType NodeType => NodeType.Body;

	public Section ParentSection => (Section)base.ParentNode;

	public Body(DocumentBase doc)
		: base(doc, StoryType.MainText)
	{
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return xf7ae36cd24e0b11c(visitor);
	}

	internal override VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitBodyStart(this);
	}

	internal override VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitBodyEnd(this);
	}

	public void EnsureMinimum()
	{
		xb7dbd7bb3ed97d5b.x9d7a28ea717302c8(this);
	}
}
