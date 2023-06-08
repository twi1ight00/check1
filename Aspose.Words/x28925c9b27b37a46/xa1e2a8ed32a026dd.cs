using Aspose.Words;

namespace x28925c9b27b37a46;

internal class xa1e2a8ed32a026dd : CompositeNode
{
	private readonly x101cddc73c4f8cc2 xf9ed05fb0602c089;

	public override NodeType NodeType => NodeType.System;

	internal x101cddc73c4f8cc2 xaf761da18e9851ce => xf9ed05fb0602c089;

	internal xa1e2a8ed32a026dd(DocumentBase doc, x101cddc73c4f8cc2 separatorType)
		: base(doc)
	{
		xf9ed05fb0602c089 = separatorType;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return x464d2134480a7bf2(visitor);
	}

	internal override VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d)
	{
		return VisitorAction.Continue;
	}

	internal override VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d)
	{
		return VisitorAction.Continue;
	}

	internal override bool x8a4414b7d9d4073f(Node x40e458b3a58f5782)
	{
		return true;
	}
}
