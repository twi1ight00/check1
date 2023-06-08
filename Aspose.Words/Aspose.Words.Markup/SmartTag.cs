using x28925c9b27b37a46;
using x53eb9320ebbb8395;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Markup;

public class SmartTag : CompositeNode, x55997ac957018945
{
	private string x1bb455bedd98d593 = "";

	private string x85672ef2a158d360 = "";

	private CustomXmlPropertyCollection x66cd11f407255d70;

	public override NodeType NodeType => NodeType.SmartTag;

	public string Element
	{
		get
		{
			return x1bb455bedd98d593;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "Element");
			x1bb455bedd98d593 = value;
		}
	}

	public string Uri
	{
		get
		{
			return x85672ef2a158d360;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "Uri");
			x85672ef2a158d360 = value;
		}
	}

	public CustomXmlPropertyCollection Properties => x66cd11f407255d70;

	MarkupLevel x55997ac957018945.x67996c0046b4bd57 => MarkupLevel.Inline;

	public SmartTag(DocumentBase doc)
		: base(doc)
	{
		x66cd11f407255d70 = new CustomXmlPropertyCollection();
	}

	internal void xbc843e6d2f8d6fe7(SmartTag xd6efc2d6e891a521)
	{
		string text = x1bb455bedd98d593;
		x1bb455bedd98d593 = xd6efc2d6e891a521.x1bb455bedd98d593;
		xd6efc2d6e891a521.x1bb455bedd98d593 = text;
		string text2 = x85672ef2a158d360;
		x85672ef2a158d360 = xd6efc2d6e891a521.x85672ef2a158d360;
		xd6efc2d6e891a521.x85672ef2a158d360 = text2;
		CustomXmlPropertyCollection customXmlPropertyCollection = x66cd11f407255d70;
		x66cd11f407255d70 = xd6efc2d6e891a521.x66cd11f407255d70;
		xd6efc2d6e891a521.x66cd11f407255d70 = customXmlPropertyCollection;
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		SmartTag smartTag = (SmartTag)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		smartTag.x66cd11f407255d70 = x66cd11f407255d70.x8b61531c8ea35b85();
		return smartTag;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return xf7ae36cd24e0b11c(visitor);
	}

	internal override VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitSmartTagStart(this);
	}

	internal override VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitSmartTagEnd(this);
	}

	internal override bool x8a4414b7d9d4073f(Node x40e458b3a58f5782)
	{
		return x2b1ee3a87b36a988.x15bc008974f7d712(x40e458b3a58f5782);
	}
}
