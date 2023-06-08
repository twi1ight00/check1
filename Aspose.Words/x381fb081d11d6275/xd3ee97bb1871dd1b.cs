using System.Collections;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using Aspose.Words.Tables;
using x28925c9b27b37a46;

namespace x381fb081d11d6275;

internal class xd3ee97bb1871dd1b : DocumentVisitor
{
	private readonly x9df536d98415d2d0 xa737d500a7554634;

	private readonly Stack x23e60cfe8f788a9e;

	private readonly xc962dd50add9c406 x9af56536cdcf0ffc;

	private readonly x611b52a649966359 x38c4187576184787;

	private readonly x6868017fd9012087 x226a09a3303fed2e;

	private readonly x22033edbeead0f61 x4af07f520b56f886;

	private readonly x404be4b8fc06bce3 xb9e6b034b22e403e;

	private readonly x68331b8428496f91 xa056586c1f99e199;

	private readonly x0ce95024f2f68661 x05b7e725c9a2cde4;

	private bool xe7cc8657048a54df => x23e60cfe8f788a9e.Count > 0;

	internal xd3ee97bb1871dd1b(Document doc, xc962dd50add9c406 listWriter, x611b52a649966359 coreWriter, x6868017fd9012087 fieldWriter, x22033edbeead0f61 bookmarkWriter, x404be4b8fc06bce3 tableWriter, x68331b8428496f91 warningCallback, x9df536d98415d2d0 fontColorResolver, x0ce95024f2f68661 shapeResourceWriter)
	{
		x9af56536cdcf0ffc = listWriter;
		x38c4187576184787 = coreWriter;
		x226a09a3303fed2e = fieldWriter;
		x4af07f520b56f886 = bookmarkWriter;
		xb9e6b034b22e403e = tableWriter;
		xa056586c1f99e199 = warningCallback;
		xa737d500a7554634 = fontColorResolver;
		x05b7e725c9a2cde4 = shapeResourceWriter;
		x23e60cfe8f788a9e = new Stack();
	}

	public override VisitorAction VisitRun(Run run)
	{
		if (!base.x991897f13cf6aadc && !x226a09a3303fed2e.xc4712ab603fe2431(run))
		{
			return x38c4187576184787.x9a7ad1735553086c(run);
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitSpecialChar(SpecialChar specialChar)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		string text = specialChar.GetText();
		if (!(text == ControlChar.xf4a399b5bb9c2b9e) && !(text == ControlChar.x52a843d47a26d1df))
		{
			return x38c4187576184787.x9a7ad1735553086c(specialChar);
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentStart(Comment comment)
	{
		xa056586c1f99e199.xbbf9a1ead81dd3a1(WarningType.DataLoss, "Exporting of comments is not supported in HTML and flow XAML.");
		return VisitorAction.SkipThisNode;
	}

	public override VisitorAction VisitFieldStart(FieldStart fieldStart)
	{
		if (!base.x991897f13cf6aadc)
		{
			x226a09a3303fed2e.x8605874f1b4c6798(fieldStart);
		}
		x815ef51367edcfcb();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldSeparator(FieldSeparator fieldSeparator)
	{
		if (!x226a09a3303fed2e.xa29fb79ffcf5f9ba(fieldSeparator.FieldType))
		{
			xe6a4e902193701d4();
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldEnd(FieldEnd fieldEnd)
	{
		xafa80fe1f24f67ce();
		if (!base.x991897f13cf6aadc)
		{
			x226a09a3303fed2e.x98ab27c28fa098eb(fieldEnd);
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitBookmarkStart(BookmarkStart bookmarkStart)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		x4af07f520b56f886.x334f73a0b642051d(bookmarkStart.Name);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitGroupShapeStart(GroupShape group)
	{
		return x0840d2c3fa2eb773(group, null);
	}

	public override VisitorAction VisitShapeStart(Shape shape)
	{
		return x0840d2c3fa2eb773(shape, shape);
	}

	public override VisitorAction VisitTableStart(Table table)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		x9af56536cdcf0ffc.xd7696af0a28b1b06();
		xb9e6b034b22e403e.xe717a5a4daba5191(table);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitTableEnd(Table table)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		xb9e6b034b22e403e.xcaecd61600966f36(table);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitRowStart(Row row)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		xa737d500a7554634.x00149f2495b0f026(row.xedb0eb766e25e0c9.x554aca059bdf6d48);
		xb9e6b034b22e403e.x48610c3e5cca6f3e(row);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitRowEnd(Row row)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		xa737d500a7554634.xbcd358ebb8d4e95e();
		xb9e6b034b22e403e.xd507f724ce92c500(row);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCellStart(Cell cell)
	{
		if (cell.xf8cef531dae89ea3.x61127d98597c4898)
		{
			return VisitorAction.SkipThisNode;
		}
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		if (cell.xf8cef531dae89ea3.xdc1bf80853046136 == 0)
		{
			return VisitorAction.SkipThisNode;
		}
		xa737d500a7554634.x00149f2495b0f026(cell.xf8cef531dae89ea3.x554aca059bdf6d48);
		xb9e6b034b22e403e.x30a57b87f2670c44(cell);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCellEnd(Cell cell)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		x9af56536cdcf0ffc.xd7696af0a28b1b06();
		xa737d500a7554634.xbcd358ebb8d4e95e();
		xb9e6b034b22e403e.x191c57b612fc7df5();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitParagraphStart(Paragraph para)
	{
		if (!base.x991897f13cf6aadc)
		{
			return x38c4187576184787.x1b08a07a3132f8bc(para);
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitParagraphEnd(Paragraph para)
	{
		if (!base.x991897f13cf6aadc)
		{
			return x38c4187576184787.xa2e5fe5057cd7778(para);
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFormField(FormField formField)
	{
		return x226a09a3303fed2e.x85599597a4d57020(formField);
	}

	public override VisitorAction VisitFootnoteStart(Footnote footnote)
	{
		return x38c4187576184787.x1b12ad7e0ad0df34(footnote);
	}

	public override VisitorAction VisitFootnoteEnd(Footnote footnote)
	{
		return x38c4187576184787.x29a51827c03d354b(footnote);
	}

	public override VisitorAction VisitAbsolutePositionTab(AbsolutePositionTab tab)
	{
		x38c4187576184787.xb5fb564b7a85b58c(tab);
		return base.VisitAbsolutePositionTab(tab);
	}

	private VisitorAction x0840d2c3fa2eb773(ShapeBase x8739b0dd3627f37e, Shape x5770cdefd8931aa9)
	{
		if (base.x991897f13cf6aadc)
		{
			return VisitorAction.Continue;
		}
		if (!x8739b0dd3627f37e.IsTopLevel || x8739b0dd3627f37e.x96e55b5d052d1279 || x8739b0dd3627f37e.Font.Hidden)
		{
			return VisitorAction.SkipThisNode;
		}
		if (x8739b0dd3627f37e.xdbcc1aacec52b0fa)
		{
			x9af56536cdcf0ffc.xd7696af0a28b1b06();
			x38c4187576184787.x51ff2e1c5d5075fd(x5770cdefd8931aa9);
		}
		else
		{
			x05b7e725c9a2cde4.x1a2622a1866b8f97(x8739b0dd3627f37e, x5770cdefd8931aa9);
		}
		return VisitorAction.SkipThisNode;
	}

	private void x815ef51367edcfcb()
	{
		x23e60cfe8f788a9e.Push(true);
		x75be698bf0c3a5c5();
	}

	private void xe6a4e902193701d4()
	{
		if (xe7cc8657048a54df && (bool)x23e60cfe8f788a9e.Peek())
		{
			x45277e5380a187db();
			x23e60cfe8f788a9e.Pop();
			x23e60cfe8f788a9e.Push(false);
		}
	}

	private void xafa80fe1f24f67ce()
	{
		if (xe7cc8657048a54df && (bool)x23e60cfe8f788a9e.Pop())
		{
			x45277e5380a187db();
		}
	}
}
