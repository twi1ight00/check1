using System;
using x13f1efc79617a47b;
using x28925c9b27b37a46;

namespace Aspose.Words;

public class Footnote : InlineStory
{
	private FootnoteType x569868da696e4454;

	private bool xf2537fc9e30eb6a6;

	private string x3ed76e0f92ce554b;

	public override NodeType NodeType => NodeType.Footnote;

	public override StoryType StoryType => x569868da696e4454 switch
	{
		FootnoteType.Footnote => StoryType.Footnotes, 
		FootnoteType.Endnote => StoryType.Endnotes, 
		_ => throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("omdceokconbdonidmnpdbogefnneeiefhmlfnmcgkmjgmmahdmhhbmohdmfiblmijgdjklkjmlbkalikckpkiggl", 1417945977))), 
	};

	public FootnoteType FootnoteType => x569868da696e4454;

	internal bool xa72bf798a679c0aa
	{
		get
		{
			return xf2537fc9e30eb6a6;
		}
		set
		{
			xf2537fc9e30eb6a6 = value;
			if (!xf2537fc9e30eb6a6)
			{
				x3ed76e0f92ce554b = "";
			}
		}
	}

	internal string x715a8c5c33fdc1a6
	{
		get
		{
			return x3ed76e0f92ce554b;
		}
		set
		{
			x3ed76e0f92ce554b = value;
		}
	}

	public Footnote(DocumentBase doc, FootnoteType footnoteType)
		: this(doc, footnoteType, isAuto: true, "", new xeedad81aaed42a76())
	{
	}

	internal Footnote(DocumentBase doc, FootnoteType footnoteType, bool isAuto, string referenceMark, xeedad81aaed42a76 runPr)
		: base(doc, runPr)
	{
		x569868da696e4454 = footnoteType;
		xf2537fc9e30eb6a6 = isAuto;
		x3ed76e0f92ce554b = referenceMark;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return xf7ae36cd24e0b11c(visitor);
	}

	internal override VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitFootnoteStart(this);
	}

	internal override VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitFootnoteEnd(this);
	}

	internal void x88ea8242dd9d6152(FootnoteType x43163d22e8cd5a71)
	{
		x569868da696e4454 = x43163d22e8cd5a71;
	}
}
