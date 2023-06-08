using x28925c9b27b37a46;
using x53eb9320ebbb8395;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Markup;

public class CustomXmlMarkup : CompositeNode, x55997ac957018945
{
	private readonly MarkupLevel xaabccab0c06d038b;

	private string x18078bbe01c444ae = "";

	private string x1bb455bedd98d593 = "";

	private string x85672ef2a158d360 = "";

	private CustomXmlPropertyCollection x66cd11f407255d70;

	public override NodeType NodeType => NodeType.CustomXmlMarkup;

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

	public string Placeholder
	{
		get
		{
			return x18078bbe01c444ae;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "Placeholder");
			x18078bbe01c444ae = value;
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

	public MarkupLevel Level => xaabccab0c06d038b;

	MarkupLevel x55997ac957018945.x67996c0046b4bd57 => Level;

	public CustomXmlMarkup(DocumentBase doc, MarkupLevel level)
		: base(doc)
	{
		x66cd11f407255d70 = new CustomXmlPropertyCollection();
		xaabccab0c06d038b = level;
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		CustomXmlMarkup customXmlMarkup = (CustomXmlMarkup)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		customXmlMarkup.x66cd11f407255d70 = x66cd11f407255d70.x8b61531c8ea35b85();
		return customXmlMarkup;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return xf7ae36cd24e0b11c(visitor);
	}

	internal override VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitCustomXmlMarkupStart(this);
	}

	internal override VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitCustomXmlMarkupEnd(this);
	}

	internal override bool x8a4414b7d9d4073f(Node x40e458b3a58f5782)
	{
		return x2b1ee3a87b36a988.x7a452479f1ce15c7(this, x40e458b3a58f5782);
	}
}
