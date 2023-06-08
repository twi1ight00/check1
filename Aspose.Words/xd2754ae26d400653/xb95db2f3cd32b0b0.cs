using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.Drawing;

namespace xd2754ae26d400653;

internal class xb95db2f3cd32b0b0 : DocumentVisitor
{
	private enum xd7e99cef2a7396ff
	{
		x555897a1eb70677c,
		x924e4e3967c494db,
		x69d28a4aeef83a6f,
		xd90ac7fcbe961761,
		xa9993ed2e0c64574,
		x937e050c63ea1527
	}

	private const int x0071b65f40ca4960 = 6;

	private readonly xcb0a3bdf6cb11198[] x6a0aea401d61b166 = new xcb0a3bdf6cb11198[6];

	private readonly Stack x78381e8a0fe2ae8b = new Stack();

	private xcb0a3bdf6cb11198 x9d8744f22571275f => (xcb0a3bdf6cb11198)x78381e8a0fe2ae8b.Peek();

	internal static void xb8f4fa4f62915b68(Document x6beba47238e0ade6)
	{
		x6beba47238e0ade6.Accept(new xb95db2f3cd32b0b0(x6beba47238e0ade6));
	}

	private xb95db2f3cd32b0b0(Document doc)
	{
		for (int i = 0; i < 6; i++)
		{
			x6a0aea401d61b166[i] = new xcb0a3bdf6cb11198(doc);
		}
	}

	public override VisitorAction VisitBodyStart(Body body)
	{
		x1dd2858743928049(xd7e99cef2a7396ff.x555897a1eb70677c);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitBodyEnd(Body body)
	{
		xeb1304b4500b35ae();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitHeaderFooterStart(HeaderFooter headerFooter)
	{
		x1dd2858743928049(xd7e99cef2a7396ff.x924e4e3967c494db);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitHeaderFooterEnd(HeaderFooter headerFooter)
	{
		xeb1304b4500b35ae();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFootnoteStart(Footnote footnote)
	{
		switch (footnote.FootnoteType)
		{
		case FootnoteType.Footnote:
			x1dd2858743928049(xd7e99cef2a7396ff.x69d28a4aeef83a6f);
			break;
		case FootnoteType.Endnote:
			x1dd2858743928049(xd7e99cef2a7396ff.xd90ac7fcbe961761);
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFootnoteEnd(Footnote footnote)
	{
		xeb1304b4500b35ae();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentStart(Comment comment)
	{
		x1dd2858743928049(xd7e99cef2a7396ff.x937e050c63ea1527);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentEnd(Comment comment)
	{
		xeb1304b4500b35ae();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitShapeStart(Shape shape)
	{
		x1dd2858743928049(xd7e99cef2a7396ff.xa9993ed2e0c64574);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitShapeEnd(Shape shape)
	{
		xeb1304b4500b35ae();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitParagraphStart(Paragraph para)
	{
		x9d8744f22571275f.x201200bdd10d9567(para);
		return VisitorAction.Continue;
	}

	private void x1dd2858743928049(xd7e99cef2a7396ff xdd2e02377d7065ba)
	{
		x78381e8a0fe2ae8b.Push(x6a0aea401d61b166[(int)xdd2e02377d7065ba]);
	}

	private void xeb1304b4500b35ae()
	{
		x78381e8a0fe2ae8b.Pop();
	}
}
