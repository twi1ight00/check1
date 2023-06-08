using Aspose.Words;
using Aspose.Words.BuildingBlocks;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using Aspose.Words.Lists;
using x28925c9b27b37a46;
using xd2754ae26d400653;

namespace x13cd31bb39e0b7ea;

internal abstract class x2d1eb36fbee7f55a : DocumentVisitor
{
	public override VisitorAction VisitDocumentEnd(Document doc)
	{
		xf782f51f33237aa0(doc);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitGlossaryDocumentEnd(GlossaryDocument glossary)
	{
		xf782f51f33237aa0(glossary);
		return VisitorAction.Continue;
	}

	private void xf782f51f33237aa0(DocumentBase x6beba47238e0ade6)
	{
		x89e50236fdb8421d(x6beba47238e0ade6.Styles);
		xac4e4b8983fbf0d5(x6beba47238e0ade6.Lists);
	}

	private void x89e50236fdb8421d(StyleCollection x3fa6ecdd18b2ff6e)
	{
		DoHandleRunPr(x3fa6ecdd18b2ff6e.x27096df7ca0cfe2e);
		foreach (Style item in x3fa6ecdd18b2ff6e)
		{
			DoHandleRunPr(item.xeedad81aaed42a76);
			StyleType type = item.Type;
			if (type == StyleType.Table)
			{
				x162b998565f4bbe7((TableStyle)item);
			}
		}
	}

	private void x162b998565f4bbe7(TableStyle x44ecfea61c937b8e)
	{
		foreach (xe12ab2f55355c7f0 item in x44ecfea61c937b8e.x7205cb42c2f994a4)
		{
			DoHandleRunPr(item.xeedad81aaed42a76);
		}
	}

	private void xac4e4b8983fbf0d5(ListCollection x7d45a69b707b1582)
	{
		for (int i = 0; i < x7d45a69b707b1582.xddf1da3d36406847; i++)
		{
			x178ff6dcbf808c38 x178ff6dcbf808c = x7d45a69b707b1582.x3bfa6064d69ac0da(i);
			foreach (ListLevel item in x178ff6dcbf808c.x438a2a8db4b2d07b)
			{
				DoHandleRunPr(item.xeedad81aaed42a76);
			}
		}
		foreach (List item2 in x7d45a69b707b1582)
		{
			foreach (x136abcf7d9c0eef3 item3 in item2.x6047afa6812e47bc)
			{
				if (item3.x178c863a9c967cd2)
				{
					DoHandleRunPr(item3.xf13a626e550cef8f.xeedad81aaed42a76);
				}
			}
		}
	}

	public override VisitorAction VisitParagraphStart(Paragraph paragraph)
	{
		DoHandleRunPr(paragraph.x344511c4e4ce09da);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentStart(Comment comment)
	{
		DoHandleRunPr(comment.xeedad81aaed42a76);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFootnoteStart(Footnote footnote)
	{
		DoHandleRunPr(footnote.xeedad81aaed42a76);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitShapeStart(Shape shape)
	{
		DoHandleRunPr(shape.xeedad81aaed42a76);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitGroupShapeStart(GroupShape groupShape)
	{
		DoHandleRunPr(groupShape.xeedad81aaed42a76);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFormField(FormField formField)
	{
		DoHandleRunPr(formField.xeedad81aaed42a76);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitRun(Run run)
	{
		DoHandleRunPr(run.xeedad81aaed42a76);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldStart(FieldStart fieldStart)
	{
		DoHandleRunPr(fieldStart.xeedad81aaed42a76);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldSeparator(FieldSeparator fieldSeparator)
	{
		DoHandleRunPr(fieldSeparator.xeedad81aaed42a76);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldEnd(FieldEnd fieldEnd)
	{
		DoHandleRunPr(fieldEnd.xeedad81aaed42a76);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitSpecialChar(SpecialChar specialChar)
	{
		DoHandleRunPr(specialChar.xeedad81aaed42a76);
		return VisitorAction.Continue;
	}

	protected abstract void DoHandleRunPr(xeedad81aaed42a76 runPr);
}
