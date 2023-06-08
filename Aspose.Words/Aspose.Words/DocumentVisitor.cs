using Aspose.Words.BuildingBlocks;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using Aspose.Words.Markup;
using Aspose.Words.Math;
using Aspose.Words.Tables;

namespace Aspose.Words;

public abstract class DocumentVisitor
{
	private int xafc4b914f07c2d11;

	internal virtual bool x0ee6e13d00a3931f => true;

	internal bool x991897f13cf6aadc => xafc4b914f07c2d11 > 0;

	[JavaThrows(true)]
	public virtual VisitorAction VisitDocumentStart(Document doc)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitDocumentEnd(Document doc)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitSectionStart(Section section)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitSectionEnd(Section section)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitBodyStart(Body body)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitBodyEnd(Body body)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitHeaderFooterStart(HeaderFooter headerFooter)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitHeaderFooterEnd(HeaderFooter headerFooter)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitParagraphStart(Paragraph paragraph)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitParagraphEnd(Paragraph paragraph)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitTableStart(Table table)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitTableEnd(Table table)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitRowStart(Row row)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitRowEnd(Row row)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitCellStart(Cell cell)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitCellEnd(Cell cell)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitRun(Run run)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitFieldStart(FieldStart fieldStart)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitFieldSeparator(FieldSeparator fieldSeparator)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitFieldEnd(FieldEnd fieldEnd)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitFormField(FormField formField)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitBookmarkStart(BookmarkStart bookmarkStart)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitBookmarkEnd(BookmarkEnd bookmarkEnd)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitFootnoteStart(Footnote footnote)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitFootnoteEnd(Footnote footnote)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitCommentStart(Comment comment)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitCommentEnd(Comment comment)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitShapeStart(Shape shape)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitShapeEnd(Shape shape)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitGroupShapeStart(GroupShape groupShape)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitGroupShapeEnd(GroupShape groupShape)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitOfficeMathStart(OfficeMath officeMath)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitOfficeMathEnd(OfficeMath officeMath)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitDrawingML(DrawingML drawingML)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitSpecialChar(SpecialChar specialChar)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitAbsolutePositionTab(AbsolutePositionTab tab)
	{
		return VisitSpecialChar(tab);
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitSmartTagStart(SmartTag smartTag)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitSmartTagEnd(SmartTag smartTag)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitCustomXmlMarkupStart(CustomXmlMarkup customXmlMarkup)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitCustomXmlMarkupEnd(CustomXmlMarkup customXmlMarkup)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitStructuredDocumentTagStart(StructuredDocumentTag sdt)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitStructuredDocumentTagEnd(StructuredDocumentTag sdt)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitGlossaryDocumentStart(GlossaryDocument glossary)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitGlossaryDocumentEnd(GlossaryDocument glossary)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitBuildingBlockStart(BuildingBlock block)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitBuildingBlockEnd(BuildingBlock block)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitCommentRangeStart(CommentRangeStart commentRangeStart)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitCommentRangeEnd(CommentRangeEnd commentRangeEnd)
	{
		return VisitorAction.Continue;
	}

	[JavaThrows(true)]
	public virtual VisitorAction VisitSubDocument(SubDocument subDocument)
	{
		return VisitorAction.Continue;
	}

	internal void x75be698bf0c3a5c5()
	{
		xafc4b914f07c2d11++;
	}

	internal void x45277e5380a187db()
	{
		if (xafc4b914f07c2d11 > 0)
		{
			xafc4b914f07c2d11--;
		}
	}
}
