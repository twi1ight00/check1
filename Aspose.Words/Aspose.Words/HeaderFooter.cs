using x28925c9b27b37a46;

namespace Aspose.Words;

public class HeaderFooter : Story
{
	public override NodeType NodeType => NodeType.HeaderFooter;

	public Section ParentSection => (Section)base.ParentNode;

	public HeaderFooterType HeaderFooterType => xb7dbd7bb3ed97d5b.x442f5a91105f9e6a(base.StoryType);

	public bool IsHeader
	{
		get
		{
			if (HeaderFooterType != HeaderFooterType.HeaderPrimary && HeaderFooterType != HeaderFooterType.HeaderFirst)
			{
				return HeaderFooterType == HeaderFooterType.HeaderEven;
			}
			return true;
		}
	}

	public bool IsLinkedToPrevious
	{
		get
		{
			return !base.HasChildNodes;
		}
		set
		{
			if (value)
			{
				RemoveAllChildren();
			}
			else if (!base.HasChildNodes)
			{
				AppendChild(new Paragraph(base.Document));
			}
		}
	}

	public HeaderFooter(DocumentBase doc, HeaderFooterType headerFooterType)
		: base(doc, xb7dbd7bb3ed97d5b.x3bcc8e857eb29ca0(headerFooterType))
	{
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return xf7ae36cd24e0b11c(visitor);
	}

	internal override VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitHeaderFooterStart(this);
	}

	internal override VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitHeaderFooterEnd(this);
	}
}
