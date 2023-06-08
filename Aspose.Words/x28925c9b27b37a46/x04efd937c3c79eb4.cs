using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using Aspose.Words.Lists;
using xd2754ae26d400653;

namespace x28925c9b27b37a46;

internal class x04efd937c3c79eb4 : DocumentVisitor
{
	private int xdc2bd6ef196a1d87;

	private int x409093f4dae66f16;

	private int xc143993757c01b1a;

	private int x919043a2d86e312e;

	private bool xd8e9521024322207;

	private bool x04b810a137d19062;

	public override VisitorAction VisitDocumentStart(Document doc)
	{
		xb95db2f3cd32b0b0.xb8f4fa4f62915b68(doc);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitDocumentEnd(Document doc)
	{
		xb690385160080815();
		doc.BuiltInDocumentProperties.Characters = x409093f4dae66f16;
		doc.BuiltInDocumentProperties.CharactersWithSpaces = x409093f4dae66f16 + xdc2bd6ef196a1d87;
		doc.BuiltInDocumentProperties.Words = xc143993757c01b1a;
		doc.BuiltInDocumentProperties.Paragraphs = x919043a2d86e312e;
		return VisitorAction.Stop;
	}

	public override VisitorAction VisitHeaderFooterStart(HeaderFooter headerFooter)
	{
		x75be698bf0c3a5c5();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitHeaderFooterEnd(HeaderFooter headerFooter)
	{
		x45277e5380a187db();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFootnoteStart(Footnote footnote)
	{
		x75be698bf0c3a5c5();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFootnoteEnd(Footnote footnote)
	{
		x45277e5380a187db();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitShapeStart(Shape shape)
	{
		x75be698bf0c3a5c5();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitShapeEnd(Shape shape)
	{
		x45277e5380a187db();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldStart(FieldStart fieldStart)
	{
		x75be698bf0c3a5c5();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldSeparator(FieldSeparator fieldSeparator)
	{
		x45277e5380a187db();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldEnd(FieldEnd fieldEnd)
	{
		if (!fieldEnd.HasSeparator)
		{
			x45277e5380a187db();
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitParagraphStart(Paragraph para)
	{
		if (!base.x991897f13cf6aadc && para.IsListItem)
		{
			string labelString = para.ListLabel.LabelString;
			if (labelString != null)
			{
				x409093f4dae66f16 += labelString.Length;
				xc143993757c01b1a++;
				if (para.ListLabel.xd8359a0ce34a3ba5 != ListTrailingCharacter.Nothing)
				{
					xdc2bd6ef196a1d87++;
				}
			}
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitParagraphEnd(Paragraph para)
	{
		if (!base.x991897f13cf6aadc)
		{
			xb690385160080815();
			xe154837a42132b31();
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitSectionEnd(Section section)
	{
		if (!base.x991897f13cf6aadc)
		{
			xb690385160080815();
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitSpecialChar(SpecialChar specialChar)
	{
		if (specialChar.GetText() == '\u2002'.ToString())
		{
			x3eaacbd458b28373();
			xd8e9521024322207 = true;
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitRun(Run run)
	{
		if (!base.x991897f13cf6aadc)
		{
			for (int i = 0; i < run.Text.Length; i++)
			{
				char x3c4da2980d043c = run.Text[i];
				if (x6ff4e1d033327ce7(x3c4da2980d043c))
				{
					xdc2bd6ef196a1d87++;
					xb690385160080815();
				}
				else if (xd347ae8c21d17d89(x3c4da2980d043c))
				{
					x3eaacbd458b28373();
					xb690385160080815();
				}
				else if (x547676779611bfaa(x3c4da2980d043c))
				{
					x3eaacbd458b28373();
					xd8e9521024322207 = true;
					x04b810a137d19062 = true;
				}
			}
		}
		return VisitorAction.Continue;
	}

	private void x3eaacbd458b28373()
	{
		x409093f4dae66f16++;
	}

	private void xb690385160080815()
	{
		if (xd8e9521024322207)
		{
			xc143993757c01b1a++;
			xd8e9521024322207 = false;
		}
	}

	private void xe154837a42132b31()
	{
		if (x04b810a137d19062)
		{
			x919043a2d86e312e++;
			x04b810a137d19062 = false;
		}
	}

	private static bool x6ff4e1d033327ce7(char x3c4da2980d043c95)
	{
		if (char.IsWhiteSpace(x3c4da2980d043c95))
		{
			return x547676779611bfaa(x3c4da2980d043c95);
		}
		return false;
	}

	private static bool xd347ae8c21d17d89(char x3c4da2980d043c95)
	{
		switch (x3c4da2980d043c95)
		{
		case '–':
		case '—':
			return true;
		default:
			return false;
		}
	}

	private static bool x547676779611bfaa(char x3c4da2980d043c95)
	{
		switch (x3c4da2980d043c95)
		{
		case '\f':
		case '\u000e':
			return false;
		default:
			return true;
		}
	}
}
