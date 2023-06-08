using x011d489fb9df7027;

namespace Aspose.Words.Drawing;

public class GroupShape : ShapeBase
{
	public override NodeType NodeType => NodeType.GroupShape;

	internal x5e63bd35f6835a06 x5e63bd35f6835a06
	{
		get
		{
			return (x5e63bd35f6835a06)xfc928672852cc4c4(1280);
		}
		set
		{
			x0817d5cde9e19bf6(1280, value);
		}
	}

	public GroupShape(DocumentBase doc)
		: base(doc)
	{
		x88d1b78392d1a0ab(ShapeType.Group);
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return xf7ae36cd24e0b11c(visitor);
	}

	internal override VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitGroupShapeStart(this);
	}

	internal override VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitGroupShapeEnd(this);
	}

	internal override bool x8a4414b7d9d4073f(Node x40e458b3a58f5782)
	{
		switch (x40e458b3a58f5782.NodeType)
		{
		case NodeType.GroupShape:
		case NodeType.Shape:
			return true;
		default:
			return false;
		}
	}
}
