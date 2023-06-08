using System;
using System.Collections;
using System.IO;
using Aspose.Words;
using Aspose.Words.BuildingBlocks;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using Aspose.Words.Markup;
using Aspose.Words.Math;
using Aspose.Words.Properties;
using Aspose.Words.Rendering;
using Aspose.Words.Saving;
using Aspose.Words.Settings;
using Aspose.Words.Tables;
using x011d489fb9df7027;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x38d3ef1c1d247e82;
using x50d2f537cc336076;
using x53eb9320ebbb8395;
using x5af3f327d745698a;
using x6c95d9cf46ff5f25;
using x9db5f2e5af3d596e;
using xb92b7270f78a4e8d;
using xd2754ae26d400653;
using xf84318f571847613;
using xfbd1009a0cbb9842;

namespace x13cd31bb39e0b7ea;

internal class xcc0b5baa75272714 : DocumentVisitor
{
	private x8556eed81191af11 xb36c250515e408ad;

	private x68c54364f77a7d3b xce44aa27f95f207c;

	private x10687f898060ea2b xee3fc38c4581f239;

	private xfed58eabcc10ae18 xbb02665fbbdb01aa;

	private xaa6aac6156ffea29 x243bb528d2faf578;

	private x04fb9568ed86f085 xddd176d72ca20434;

	private x3e50ba9028aa4ca7 x1004dc53dfb6ee0b;

	private xd8102f3a59d221a1 x953e86951da4f25a;

	private x6ccb5500e3324be8 x8f59c12073ee8d26;

	private xb3eb29598c62ff6d x608fa89196996e43;

	private xb82ae5a29166d7a2 xe91706552cfdaa4c;

	private x81e499fc7c476682 x37c274d071660c35;

	private x94c83b1ca7961561 x0da9da90bfa5838b;

	private x7eb91168165e4c6e x4e3ea0132f6ad8ef;

	private Stack x3c347579e9b06f74;

	private bool x99d7d1b2b3aa26cb;

	private int x26744015762c08e1;

	private bool x991884ab71db6cf8;

	private x416e4f8cf09bfa33 xf4fe3ca58e8fa1bb;

	private x93c25ac9dfbf7fc3 xf2d41f5c7c48324a;

	private readonly Hashtable x6e101250772d242a = new Hashtable();

	private Hashtable xc5a7fd62c8debf14;

	private static readonly Hashtable x99721e76766a944c;

	internal override bool x0ee6e13d00a3931f => false;

	internal Hashtable x22ff8ac1bb608a92 => xc5a7fd62c8debf14;

	private IWarningCallback xf69ca7a9bb4a4a51 => xb36c250515e408ad.xf57de0fd37d5e97d.WarningCallback;

	private StoryType x391d7559b0955a1e => (StoryType)x3c347579e9b06f74.Peek();

	internal void x18dfca7c5fd2402f(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		Document x2c8c6741422a = x5ac1382edb7bf2c2.x2c8c6741422a1298;
		xb36c250515e408ad = x5ac1382edb7bf2c2;
		xce44aa27f95f207c = new x68c54364f77a7d3b(x5ac1382edb7bf2c2);
		xee3fc38c4581f239 = new x10687f898060ea2b();
		xc5a7fd62c8debf14 = new Hashtable();
		xbb02665fbbdb01aa = new xfed58eabcc10ae18(xb36c250515e408ad.xf57de0fd37d5e97d, xf69ca7a9bb4a4a51);
		x243bb528d2faf578 = x43b74f70460e9c4f(xb36c250515e408ad.x707d72c3570dbf2d);
		x37c274d071660c35 = new x81e499fc7c476682(x2c8c6741422a.Lists, xf69ca7a9bb4a4a51);
		xf2d41f5c7c48324a = new x93c25ac9dfbf7fc3();
		x2c8c6741422a.Accept(this);
		if (x2c8c6741422a.GlossaryDocument != null)
		{
			x2c8c6741422a.GlossaryDocument.Accept(this);
		}
		x0f20e5e0ffb8c02d(x2c8c6741422a);
		if (x757a5da0f267b35e(xaa6aac6156ffea29.xb8f4fa4f62915b68))
		{
			xb95db2f3cd32b0b0.xb8f4fa4f62915b68(x2c8c6741422a);
		}
		xce44aa27f95f207c.xa0dfc102c691b11f();
		x5ac1382edb7bf2c2.x158c955c749c5e5b = x2d425143e1f95bba.x4d24d9830b88d1e5(xddd176d72ca20434.x05f339cb92407608);
		foreach (string item in x2c8c6741422a.xdade2366eaa6f915.xf6915d468ae54ed1)
		{
			xb36c250515e408ad.xf6915d468ae54ed1[item] = item;
		}
		x378d2013f6ee1de9(x2c8c6741422a);
	}

	internal void x3522790e002e1ba4()
	{
		if (xf4fe3ca58e8fa1bb != null)
		{
			xf4fe3ca58e8fa1bb.xe0f695b229ca8b8a();
		}
		if (x991884ab71db6cf8)
		{
			foreach (Style style in xb36c250515e408ad.x2c8c6741422a1298.Styles)
			{
				if (style.x114c8a4fcd139550)
				{
					style.xeedad81aaed42a76 = (xeedad81aaed42a76)style.xeedad81aaed42a76.x75eab24f5629a618;
					style.x1a78664fa10a3755 = (x1a78664fa10a3755)style.x1a78664fa10a3755.x75eab24f5629a618;
				}
			}
		}
		foreach (DictionaryEntry item in x6e101250772d242a)
		{
			Shape shape = (Shape)item.Key;
			OfficeMath officeMath = (OfficeMath)item.Value;
			officeMath.x3e229cd2762a6ef5(xb36c250515e408ad.x2c8c6741422a1298);
			xc44de28e9ee69a99(officeMath, shape);
			shape.Remove();
		}
	}

	public override VisitorAction VisitDocumentStart(Document doc)
	{
		x03fd3121305b7e22(doc);
		xb7dbd7bb3ed97d5b.x7feaa17f5d673c47(doc);
		x336a12a5b91fd629();
		doc.BuiltInDocumentProperties.x3c02714b73cc8076();
		doc.EnsureMinimum();
		if (!doc.x2f5330e0b9089bce.x38921fc0c986c5d7)
		{
			doc.x2f5330e0b9089bce.x19ea552051b359a3();
		}
		xf2d41f5c7c48324a.VisitDocumentStart(doc);
		if (doc.DigitalSignatures.Count > 0)
		{
			xbbf9a1ead81dd3a1(WarningType.DataLoss, WarningSource.Validator, "Document is digitally signed, export of digital signatures is not supported by Aspose.Words.");
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitDocumentEnd(Document doc)
	{
		x16505750e02b9056(doc);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitGlossaryDocumentStart(GlossaryDocument glossary)
	{
		glossary.x2f5330e0b9089bce.x19ea552051b359a3();
		x03fd3121305b7e22(glossary);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitGlossaryDocumentEnd(GlossaryDocument glossary)
	{
		x16505750e02b9056(glossary);
		return VisitorAction.Continue;
	}

	private void x03fd3121305b7e22(DocumentBase x6beba47238e0ade6)
	{
		xddd176d72ca20434 = new x04fb9568ed86f085(xf69ca7a9bb4a4a51);
		x1004dc53dfb6ee0b = new x3e50ba9028aa4ca7(x6beba47238e0ade6, xf69ca7a9bb4a4a51);
		x953e86951da4f25a = new xd8102f3a59d221a1(xf69ca7a9bb4a4a51);
		x8f59c12073ee8d26 = new x6ccb5500e3324be8(x6beba47238e0ade6);
		x608fa89196996e43 = new xb3eb29598c62ff6d(x243bb528d2faf578, xf69ca7a9bb4a4a51);
		xe91706552cfdaa4c = (x757a5da0f267b35e(xaa6aac6156ffea29.xb4233e318bd9b762) ? new xb82ae5a29166d7a2() : null);
		x0da9da90bfa5838b = (x757a5da0f267b35e(xaa6aac6156ffea29.x1dd92c14dc4b33b5) ? x94c83b1ca7961561.x964c8ab59da5fc93() : null);
		bool flag = xb36c250515e408ad.xf57de0fd37d5e97d is OoxmlSaveOptions ooxmlSaveOptions && ooxmlSaveOptions.x351d5c790f4a6545;
		x4e3ea0132f6ad8ef = ((flag || x757a5da0f267b35e(xaa6aac6156ffea29.x62b106b481f1f656)) ? new x7eb91168165e4c6e() : null);
		x3c347579e9b06f74 = new Stack();
		x99d7d1b2b3aa26cb = false;
		x26744015762c08e1 = 0;
		x991884ab71db6cf8 = xaa48dd633aa04997(x6beba47238e0ade6);
		xf4fe3ca58e8fa1bb = null;
		if (x9b85952f60e79c4a(xb36c250515e408ad.x2c8c6741422a1298.OriginalLoadFormat) && (x757a5da0f267b35e(xaa6aac6156ffea29.xd0c6b0cc823598c8) || x991884ab71db6cf8) && x8aa2f229e1442f89(x6beba47238e0ade6))
		{
			xf4fe3ca58e8fa1bb = new x416e4f8cf09bfa33();
		}
		xf684c38edec87ab6(x6beba47238e0ade6);
	}

	private static void xf684c38edec87ab6(DocumentBase x6beba47238e0ade6)
	{
		Shape backgroundShape = x6beba47238e0ade6.BackgroundShape;
		if (backgroundShape != null)
		{
			backgroundShape.xea1e81378298fa81 = 1025;
			backgroundShape.Filled = true;
			backgroundShape.StrokeWeight = 0.0;
			backgroundShape.Stroked = false;
			backgroundShape.FlipOrientation = FlipOrientation.None;
		}
	}

	private void x16505750e02b9056(DocumentBase x6beba47238e0ade6)
	{
		bool flag = x757a5da0f267b35e(xaa6aac6156ffea29.x1dd92c14dc4b33b5);
		bool flag2 = x6beba47238e0ade6.x9bb3f6e28fa55f34() != null && x757a5da0f267b35e(xaa6aac6156ffea29.x30f96f66f1661e11);
		if (flag || flag2)
		{
			xa221ccdc1dc5bd27 xa221ccdc1dc5bd28 = new xa221ccdc1dc5bd27();
			xa221ccdc1dc5bd28.x18dfca7c5fd2402f(x6beba47238e0ade6, x0da9da90bfa5838b, flag2);
		}
		if (flag)
		{
			x6beba47238e0ade6.FontInfos.x9b3bacb3ea1603b5(x0da9da90bfa5838b);
		}
		if (x991884ab71db6cf8)
		{
			x52a8937d7d8a25f0(x6beba47238e0ade6);
		}
		MailMergeSettings xe690cef2446c7d = x6beba47238e0ade6.xdade2366eaa6f915.xe690cef2446c7d46;
		if (!xe690cef2446c7d.x7149c962c02931b3)
		{
			xe690cef2446c7d.Odso.FieldMapDatas.xb37a1dde21a93661();
		}
		x953e86951da4f25a.x648a8aa88d1bbe19();
		x1004dc53dfb6ee0b.x648a8aa88d1bbe19();
		xddd176d72ca20434.x648a8aa88d1bbe19();
		x37c274d071660c35.x648a8aa88d1bbe19();
	}

	private static bool x9b85952f60e79c4a(LoadFormat xdef7b99b7fc67519)
	{
		switch (xdef7b99b7fc67519)
		{
		case LoadFormat.Doc:
		case LoadFormat.Dot:
		case LoadFormat.Docx:
		case LoadFormat.Docm:
		case LoadFormat.Dotx:
		case LoadFormat.Dotm:
		case LoadFormat.FlatOpc:
		case LoadFormat.WordML:
			return true;
		default:
			return false;
		}
	}

	private static bool x8aa2f229e1442f89(DocumentBase x6beba47238e0ade6)
	{
		foreach (Style style in x6beba47238e0ade6.Styles)
		{
			if (style is TableStyle && style.x4a6c2b56be2364cf())
			{
				return true;
			}
		}
		return false;
	}

	private bool xaa48dd633aa04997(DocumentBase x6beba47238e0ade6)
	{
		if (!x757a5da0f267b35e(xaa6aac6156ffea29.x5881838f2f95a8cd))
		{
			return false;
		}
		StyleCollection styles = x6beba47238e0ade6.Styles;
		if (styles.xf4eb04b8b9073eeb.xd44988f225497f3a > 0)
		{
			return true;
		}
		for (int i = 0; i < styles.x27096df7ca0cfe2e.xd44988f225497f3a; i++)
		{
			if (!x14acbee1923c4c21(styles.x27096df7ca0cfe2e.xf15263674eb297bb(i)))
			{
				return true;
			}
		}
		return false;
	}

	private static void x52a8937d7d8a25f0(DocumentBase x6beba47238e0ade6)
	{
		StyleCollection styles = x6beba47238e0ade6.Styles;
		xeedad81aaed42a76 xeedad81aaed42a = (xeedad81aaed42a76)styles.x27096df7ca0cfe2e.x8b61531c8ea35b85();
		for (int num = xeedad81aaed42a.xd44988f225497f3a - 1; num >= 0; num--)
		{
			if (x14acbee1923c4c21(xeedad81aaed42a.xf15263674eb297bb(num)))
			{
				xeedad81aaed42a.x7121e9e177952651(num);
			}
		}
		x1a78664fa10a3755 xf4eb04b8b9073eeb = styles.xf4eb04b8b9073eeb;
		foreach (Style item in styles)
		{
			if (item.x114c8a4fcd139550)
			{
				xeedad81aaed42a76 xeedad81aaed42a2 = (xeedad81aaed42a76)xeedad81aaed42a.x8b61531c8ea35b85();
				item.xeedad81aaed42a76.xab3af626b1405ee8(xeedad81aaed42a2);
				xeedad81aaed42a2.x75eab24f5629a618 = (xeedad81aaed42a76)item.xeedad81aaed42a76.x8b61531c8ea35b85();
				item.xeedad81aaed42a76 = xeedad81aaed42a2;
				x1a78664fa10a3755 x1a78664fa10a = (x1a78664fa10a3755)xf4eb04b8b9073eeb.x8b61531c8ea35b85();
				item.x1a78664fa10a3755.xab3af626b1405ee8(x1a78664fa10a);
				x1a78664fa10a.x75eab24f5629a618 = (x1a78664fa10a3755)item.x1a78664fa10a3755.x8b61531c8ea35b85();
				item.x1a78664fa10a3755 = x1a78664fa10a;
			}
		}
	}

	private static bool x14acbee1923c4c21(int xba08ce632055a1d9)
	{
		if (xba08ce632055a1d9 != 230 && xba08ce632055a1d9 != 235 && xba08ce632055a1d9 != 240 && xba08ce632055a1d9 != 270 && xba08ce632055a1d9 != 380 && xba08ce632055a1d9 != 390)
		{
			return xba08ce632055a1d9 == 340;
		}
		return true;
	}

	private void x336a12a5b91fd629()
	{
		DocumentSecurity documentSecurity = DocumentSecurity.None;
		if (xb36c250515e408ad.x2c8c6741422a1298.xdade2366eaa6f915.xc57807e17cfa13d2.ReadOnlyRecommended)
		{
			documentSecurity |= DocumentSecurity.ReadOnlyRecommended;
		}
		if (xb36c250515e408ad.x2c8c6741422a1298.xdade2366eaa6f915.xc57807e17cfa13d2.IsWriteProtected)
		{
			documentSecurity |= DocumentSecurity.ReadOnlyEnforced;
		}
		switch (xb36c250515e408ad.x2c8c6741422a1298.ProtectionType)
		{
		case ProtectionType.AllowOnlyComments:
		case ProtectionType.ReadOnly:
			documentSecurity |= DocumentSecurity.ReadOnlyExceptAnnotations;
			break;
		default:
			throw new InvalidOperationException("Unknown protection type.");
		case ProtectionType.NoProtection:
		case ProtectionType.AllowOnlyRevisions:
		case ProtectionType.AllowOnlyFormFields:
			break;
		}
		xb36c250515e408ad.x2c8c6741422a1298.BuiltInDocumentProperties.Security = documentSecurity;
	}

	public override VisitorAction VisitSectionStart(Section section)
	{
		x26744015762c08e1++;
		section.EnsureMinimum();
		xbb02665fbbdb01aa.x2b044873d442f783(section);
		xf2d41f5c7c48324a.VisitSectionStart(section);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitParagraphStart(Paragraph paragraph)
	{
		if (xe91706552cfdaa4c != null)
		{
			xe91706552cfdaa4c.xc30b48dd08fbdff0(paragraph);
		}
		if (paragraph.IsListItem)
		{
			x37c274d071660c35.x57a5d79d9b9d67f5(paragraph);
		}
		xf2d41f5c7c48324a.VisitParagraphStart(paragraph);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitBodyStart(Body body)
	{
		xc3b0ad6a8458eac6(body.StoryType);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitBodyEnd(Body body)
	{
		xbbb4501cf9ca0e39(body.StoryType);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitHeaderFooterStart(HeaderFooter headerFooter)
	{
		x99d7d1b2b3aa26cb = true;
		xc3b0ad6a8458eac6(headerFooter.StoryType);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitHeaderFooterEnd(HeaderFooter headerFooter)
	{
		x99d7d1b2b3aa26cb = false;
		xbbb4501cf9ca0e39(headerFooter.StoryType);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentStart(Comment comment)
	{
		if (x435660966d08ad82(comment))
		{
			return VisitorAction.SkipThisNode;
		}
		x1004dc53dfb6ee0b.x0a2f96470b05c54f(comment);
		xc3b0ad6a8458eac6(comment.StoryType);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentEnd(Comment comment)
	{
		xbbb4501cf9ca0e39(comment.StoryType);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentRangeStart(CommentRangeStart commentRangeStart)
	{
		if (x435660966d08ad82(commentRangeStart))
		{
			return VisitorAction.SkipThisNode;
		}
		return x1004dc53dfb6ee0b.x66511c5e952e5fcb(commentRangeStart);
	}

	public override VisitorAction VisitCommentRangeEnd(CommentRangeEnd commentRangeEnd)
	{
		if (x435660966d08ad82(commentRangeEnd))
		{
			return VisitorAction.SkipThisNode;
		}
		return x1004dc53dfb6ee0b.x057ef68b6193f0b3(commentRangeEnd);
	}

	public override VisitorAction VisitFootnoteStart(Footnote footnote)
	{
		if (x391d7559b0955a1e != StoryType.MainText)
		{
			throw new InvalidOperationException("Footnotes are only allowed inside the main text of the document.");
		}
		if (footnote.FootnoteType == FootnoteType.Footnote)
		{
			xb36c250515e408ad.xd72e197c9500653f = true;
		}
		else
		{
			xb36c250515e408ad.x427aee4dfcc89c31 = true;
		}
		footnote.EnsureMinimum();
		xc3b0ad6a8458eac6(footnote.StoryType);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFootnoteEnd(Footnote footnote)
	{
		xbbb4501cf9ca0e39(footnote.StoryType);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCellStart(Cell cell)
	{
		return x608fa89196996e43.x37f46648998425f0(cell);
	}

	public override VisitorAction VisitRowStart(Row row)
	{
		row.x29079397f840690c();
		return x608fa89196996e43.xf7a3d740c38d9959(row);
	}

	public override VisitorAction VisitRowEnd(Row row)
	{
		return x608fa89196996e43.x73486983017b4ba2(row);
	}

	public override VisitorAction VisitTableStart(Table table)
	{
		return x608fa89196996e43.xe35e18fbd2d5ad9e(table);
	}

	public override VisitorAction VisitTableEnd(Table table)
	{
		if (xf4fe3ca58e8fa1bb != null)
		{
			xf4fe3ca58e8fa1bb.x8810335244b90b9d(table);
		}
		return x608fa89196996e43.x49cd8bac108971e1(table);
	}

	public override VisitorAction VisitShapeStart(Shape shape)
	{
		xa8de8dcc2d6dbbd5(shape);
		xd8ab57a204d7525c(shape);
		xc3b0ad6a8458eac6(shape.StoryType);
		return VisitorAction.Continue;
	}

	private static void xa8de8dcc2d6dbbd5(CompositeNode x93d8434f027afd5a)
	{
		if (x93d8434f027afd5a.LastChild != null && x93d8434f027afd5a.LastChild.NodeType != NodeType.Paragraph)
		{
			x93d8434f027afd5a.AppendChild(new Paragraph(x93d8434f027afd5a.Document));
		}
	}

	public override VisitorAction VisitShapeEnd(Shape shape)
	{
		xbbb4501cf9ca0e39(shape.StoryType);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitGroupShapeStart(GroupShape groupShape)
	{
		if (groupShape.x73db39780c76cb8d)
		{
			xd8ab57a204d7525c(groupShape);
			return VisitorAction.Continue;
		}
		groupShape.Remove();
		return VisitorAction.SkipThisNode;
	}

	private void xd8ab57a204d7525c(ShapeBase x5770cdefd8931aa9)
	{
		switch (x391d7559b0955a1e)
		{
		case StoryType.Endnotes:
		case StoryType.Comments:
		case StoryType.Textbox:
			if (x5770cdefd8931aa9.WrapType != 0)
			{
				x5770cdefd8931aa9.WrapType = WrapType.Inline;
			}
			break;
		}
		x5770cdefd8931aa9.x983fb06bfa0c608a();
		if (x5770cdefd8931aa9.ShapeType != ShapeType.CustomShape)
		{
			x5770cdefd8931aa9.x6315bc3d24476fb0();
		}
		xce44aa27f95f207c.xfdd6c9bd3eff16bf(x5770cdefd8931aa9, x99d7d1b2b3aa26cb);
		xb36c250515e408ad.xdc421ae00841d163(x5770cdefd8931aa9, x99d7d1b2b3aa26cb);
		xee3fc38c4581f239.x1b7f35899f1c1f42(x5770cdefd8931aa9);
		if (x5770cdefd8931aa9.xa170cce2bc40bdf5)
		{
			xf48e3f825daee74e((Shape)x5770cdefd8931aa9);
		}
		if (x5770cdefd8931aa9.ShapeType == ShapeType.CustomShape && x5770cdefd8931aa9.xf7125312c7ee115c.xf7866f89640a29a3(326) == null)
		{
			x5770cdefd8931aa9.xf7125312c7ee115c.xae20093bed1e48a8(326, new x44f2b8bf33b16275[0]);
		}
		x352130b5e3712f6b(x5770cdefd8931aa9);
	}

	private static void x352130b5e3712f6b(ShapeBase x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.NodeType != NodeType.Shape)
		{
			return;
		}
		Shape shape = (Shape)x5770cdefd8931aa9;
		int[] array = new int[2] { 4111, 4110 };
		foreach (int xba08ce632055a1d in array)
		{
			byte[] array2 = (byte[])x5770cdefd8931aa9.x048513c924d75f6b(xba08ce632055a1d);
			if (array2 != null)
			{
				x5770cdefd8931aa9.x0817d5cde9e19bf6(xba08ce632055a1d, x8e500baeffc6e539.x601e9a2243ca6720(array2));
			}
		}
		if (shape.x169baa05e57bf312)
		{
			shape.ImageData.ImageBytes = x8e500baeffc6e539.x601e9a2243ca6720(shape.ImageData.ImageBytes);
		}
	}

	private void xf48e3f825daee74e(Shape x4d691c6466f15c8f)
	{
		if (xb36c250515e408ad.xf57de0fd37d5e97d.x3d42c161dd5cf126)
		{
			x3ef57265b3705bec(x4d691c6466f15c8f);
		}
		SaveFormat x707d72c3570dbf2d = xb36c250515e408ad.x707d72c3570dbf2d;
		if (x707d72c3570dbf2d != SaveFormat.Doc && x707d72c3570dbf2d != SaveFormat.WordML && x707d72c3570dbf2d != SaveFormat.Rtf)
		{
			return;
		}
		Guid guid = x9ac0da7388ceac43.x38fd54ed55196575(x4d691c6466f15c8f.OleFormat.ProgId);
		if (guid == Guid.Empty)
		{
			xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, WarningSource.Shapes, $"Unknown ProgId value '{x4d691c6466f15c8f.OleFormat.ProgId}'. This might cause inaccessible OLE embedding.");
		}
		xe7be411416cfcd54 xe7be411416cfcd = null;
		if (x4d691c6466f15c8f.OleFormat.x58932c7e6fa3b905 is xb7e718098524b76c)
		{
			xb7e718098524b76c x648e6e09d03a446a = (xb7e718098524b76c)x4d691c6466f15c8f.OleFormat.x58932c7e6fa3b905;
			if (!x4d691c6466f15c8f.x2e3d2d1def6f4dad)
			{
				xe7be411416cfcd = x9ac0da7388ceac43.xf89ebf883c1c9c6d(guid, x4d691c6466f15c8f.OleFormat.ProgId, x648e6e09d03a446a, x4d691c6466f15c8f.OleFormat.OleIcon);
			}
			else
			{
				xbbf9a1ead81dd3a1(WarningType.DataLoss, WarningSource.Doc, "OOXML control is not supported in DOC and will be converted to image.");
			}
		}
		else if (x4d691c6466f15c8f.OleFormat.x58932c7e6fa3b905 is x71d39fdf56861cca)
		{
			x71d39fdf56861cca x71d39fdf56861cca = (x71d39fdf56861cca)x4d691c6466f15c8f.OleFormat.x58932c7e6fa3b905;
			xe7be411416cfcd = x71d39fdf56861cca.x6b73aa01aa019d3a;
			if (xe7be411416cfcd.x933ed8cf24f04c67 == Guid.Empty)
			{
				xe7be411416cfcd.x933ed8cf24f04c67 = guid;
			}
		}
		if (xe7be411416cfcd != null)
		{
			xb36c250515e408ad.x7c3f3666365efbc6[x4d691c6466f15c8f.OleFormat.x58932c7e6fa3b905.x85c663cff7276f51] = xe7be411416cfcd;
			switch (x4d691c6466f15c8f.x1ba6afab4f42a0ee)
			{
			case x1ba6afab4f42a0ee.xd5a7a92b8cfb14b3:
				xb36c250515e408ad.xdff795aea0409829 = true;
				break;
			case x1ba6afab4f42a0ee.xc24de6454f8b0f37:
				xb36c250515e408ad.xf341204f1f55ff47[x4d691c6466f15c8f.OleFormat.x58932c7e6fa3b905.x85c663cff7276f51] = xe7be411416cfcd;
				break;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ackkgdblkcilkdplpcgmbcnmmbenkclnibcoebjonmpojpgpdpnpjoeabmlanadbnpjbcabckphcfpocdagdmkmdnpdeppkedpbffoiflkpf", 891398603)));
			case x1ba6afab4f42a0ee.x1891c445b78b044b:
				break;
			}
		}
	}

	private static void x3ef57265b3705bec(Shape x4d691c6466f15c8f)
	{
		if (x4d691c6466f15c8f.xa8228c6215bc2643 && x4d691c6466f15c8f.OleFormat.x71d39fdf56861cca != null)
		{
			xe7be411416cfcd54 x6b73aa01aa019d3a = x4d691c6466f15c8f.OleFormat.x71d39fdf56861cca.x6b73aa01aa019d3a;
			string x7418697d519d9ddc = new x432b11171adc04ec(x6b73aa01aa019d3a).x7418697d519d9ddc;
			x9ac0da7388ceac43.x4123eb825f799ecb(x6b73aa01aa019d3a, new x432b11171adc04ec(x7418697d519d9ddc));
		}
	}

	public override VisitorAction VisitDrawingML(DrawingML drawingML)
	{
		if (xb36c250515e408ad.x707d72c3570dbf2d == SaveFormat.Rtf || xb36c250515e408ad.x707d72c3570dbf2d == SaveFormat.Odt || xb36c250515e408ad.x707d72c3570dbf2d == SaveFormat.Epub || xb36c250515e408ad.x707d72c3570dbf2d == SaveFormat.Html || xb36c250515e408ad.x707d72c3570dbf2d == SaveFormat.Mhtml || xb36c250515e408ad.x707d72c3570dbf2d == SaveFormat.Doc || xb36c250515e408ad.x707d72c3570dbf2d == SaveFormat.WordML || xb36c250515e408ad.x707d72c3570dbf2d == SaveFormat.XamlFlow || xb36c250515e408ad.x707d72c3570dbf2d == SaveFormat.XamlFlowPack)
		{
			if (!x09cc870d1acede7b(drawingML))
			{
				x1056c53fc7967a3d(drawingML);
				xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.DrawingML, $"DrawingML is not supported in {FileFormatUtil.x92e978705943edc1(xb36c250515e408ad.x707d72c3570dbf2d)} format and will be converted to shape.");
			}
		}
		else if (xb36c250515e408ad.xfa6c1a3e13a2b61b)
		{
			if (drawingML.xeedad81aaed42a76.xd3deb252d4974658 != null)
			{
				if (((OoxmlSaveOptions)xb36c250515e408ad.xf57de0fd37d5e97d).Compliance == OoxmlCompliance.Ecma376_2006)
				{
					x09cc870d1acede7b(drawingML);
				}
				else
				{
					drawingML.xeedad81aaed42a76.xd3deb252d4974658.x852c08d9d47ed9db.Accept(this);
				}
			}
		}
		else if (xb36c250515e408ad.x35d47c685b5fd0e6)
		{
			x09cc870d1acede7b(drawingML);
		}
		return VisitorAction.Continue;
	}

	private void x1056c53fc7967a3d(DrawingML xb3c5925d90ebc5f0)
	{
		if (xb3c5925d90ebc5f0.xcabd529f9ea6048f && x4e3ea0132f6ad8ef != null)
		{
			Shape x5770cdefd8931aa = x4e3ea0132f6ad8ef.x5b81632e5b71b64c(xb3c5925d90ebc5f0);
			x82ab1325891a98eb(xb3c5925d90ebc5f0, x5770cdefd8931aa);
		}
		else if (xb3c5925d90ebc5f0.x11deaa09f5931767)
		{
			ShapeRenderer shapeRenderer = new ShapeRenderer(xb3c5925d90ebc5f0);
			Shape shape = new Shape(xb3c5925d90ebc5f0.Document);
			shape.xf7125312c7ee115c = (xf7125312c7ee115c)xb3c5925d90ebc5f0.xf7125312c7ee115c.x8b61531c8ea35b85();
			shape.xeedad81aaed42a76 = (xeedad81aaed42a76)xb3c5925d90ebc5f0.xeedad81aaed42a76.x8b61531c8ea35b85();
			shape.x88d1b78392d1a0ab(ShapeType.Image);
			ImageSaveOptions saveOptions = new ImageSaveOptions(SaveFormat.Png);
			using MemoryStream memoryStream = new MemoryStream();
			shapeRenderer.Save(memoryStream, saveOptions);
			memoryStream.Position = 0L;
			shape.ImageData.ImageBytes = x0d299f323d241756.xa0aed4cd3b3d5d92(memoryStream);
			x82ab1325891a98eb(xb3c5925d90ebc5f0, shape);
		}
	}

	private void x82ab1325891a98eb(DrawingML xb3c5925d90ebc5f0, Shape x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9 != null)
		{
			xc44de28e9ee69a99(x5770cdefd8931aa9, xb3c5925d90ebc5f0);
			xb3c5925d90ebc5f0.Remove();
			x5770cdefd8931aa9.Accept(this);
			xc5a7fd62c8debf14.Add(xb3c5925d90ebc5f0, x5770cdefd8931aa9);
		}
	}

	private bool x09cc870d1acede7b(DrawingML xb3c5925d90ebc5f0)
	{
		if (xb3c5925d90ebc5f0.xeedad81aaed42a76.xd3deb252d4974658 == null)
		{
			return false;
		}
		Node x22bff10c3dd1f70f = xb3c5925d90ebc5f0;
		foreach (Node item in xb3c5925d90ebc5f0.xeedad81aaed42a76.xd3deb252d4974658.x852c08d9d47ed9db)
		{
			Node node2 = item.Clone(isCloneChildren: true);
			if (node2 is ShapeBase)
			{
				ShapeBase shapeBase = (ShapeBase)node2;
				shapeBase.xeedad81aaed42a76 = xb3c5925d90ebc5f0.xeedad81aaed42a76;
			}
			node2.x3e229cd2762a6ef5(xb3c5925d90ebc5f0.Document);
			xc44de28e9ee69a99(node2, x22bff10c3dd1f70f);
			node2.Accept(this);
			x22bff10c3dd1f70f = node2;
		}
		xb3c5925d90ebc5f0.Remove();
		return true;
	}

	private static void xc44de28e9ee69a99(Node x3f78448c92a523a5, Node x22bff10c3dd1f70f)
	{
		while (x22bff10c3dd1f70f.ParentNode != null && !x22bff10c3dd1f70f.ParentNode.x8a4414b7d9d4073f(x3f78448c92a523a5))
		{
			x22bff10c3dd1f70f = x22bff10c3dd1f70f.ParentNode;
		}
		if (x22bff10c3dd1f70f.ParentNode == null)
		{
			throw new NullReferenceException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jadnhbknfcbofbiolbpoobgphmmphaeacalamacbjajbhaacjahcclncbpedbpldjkceepjeipafmohfjoofikfg", 351851193)));
		}
		x22bff10c3dd1f70f.ParentNode.InsertAfter(x3f78448c92a523a5, x22bff10c3dd1f70f);
	}

	public override VisitorAction VisitOfficeMathStart(OfficeMath officeMath)
	{
		if (!xc88e48568bfcc76d(officeMath))
		{
			return x8f59c12073ee8d26.xe2d69851fb4d6421(officeMath);
		}
		return VisitorAction.SkipThisNode;
	}

	public override VisitorAction VisitOfficeMathEnd(OfficeMath officeMath)
	{
		return x8f59c12073ee8d26.xb678a1dd33952080(officeMath);
	}

	private bool xc88e48568bfcc76d(OfficeMath x203bd7b4a3be8d02)
	{
		if (xb36c250515e408ad.x707d72c3570dbf2d == SaveFormat.Epub || xb36c250515e408ad.x707d72c3570dbf2d == SaveFormat.Html || xb36c250515e408ad.x707d72c3570dbf2d == SaveFormat.Mhtml || xb36c250515e408ad.x707d72c3570dbf2d == SaveFormat.Doc || xb36c250515e408ad.x707d72c3570dbf2d == SaveFormat.WordML)
		{
			x30a8612e5702cae7 x30a8612e5702cae = new x30a8612e5702cae7();
			x57df270da83ea6de x57df270da83ea6de = x30a8612e5702cae.x5b81632e5b71b64c(x203bd7b4a3be8d02);
			Shape shape = Shape.x37dbdc5e220f1c5a((Document)x203bd7b4a3be8d02.Document, x57df270da83ea6de.xefb7a8f84373ac04, x57df270da83ea6de.x6ae4612a8469678e.Width, x57df270da83ea6de.x6ae4612a8469678e.Height);
			shape.WrapType = WrapType.Inline;
			xc44de28e9ee69a99(shape, x203bd7b4a3be8d02);
			x203bd7b4a3be8d02.Remove();
			x6e101250772d242a.Add(shape, x203bd7b4a3be8d02);
			if (xb36c250515e408ad.x707d72c3570dbf2d == SaveFormat.Doc || xb36c250515e408ad.x707d72c3570dbf2d == SaveFormat.WordML)
			{
				shape.x0817d5cde9e19bf6(780, xab9c9832b2867cea.xad06e5b7913f38fa(x203bd7b4a3be8d02));
			}
			shape.Accept(this);
			xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.OfficeMath, $"Office math is not supported in {FileFormatUtil.x92e978705943edc1(xb36c250515e408ad.x707d72c3570dbf2d)} format and will be converted to shape.");
			return true;
		}
		return false;
	}

	public override VisitorAction VisitRun(Run run)
	{
		if (run.Text == "")
		{
			run.Remove();
		}
		if (run.xadc83cc585a89881)
		{
			run.xeedad81aaed42a76.x52b190e626f65140(400);
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldStart(FieldStart fieldStart)
	{
		if (FieldType.FieldSection == fieldStart.FieldType)
		{
			Hashtable hashtable = xe25d778fe9f1252a.xaacd1adf784d6cb4(fieldStart.xdfa6ecc6f742f086);
			object obj = hashtable[fieldStart];
			if (obj is Field)
			{
				((Field)obj).Result = x26744015762c08e1.ToString();
			}
		}
		x953e86951da4f25a.xd4c0f67c01114dfe(fieldStart);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldEnd(FieldEnd fieldEnd)
	{
		x953e86951da4f25a.x55225d9815813a91(fieldEnd);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldSeparator(FieldSeparator fieldSeparator)
	{
		x71d39fdf56861cca x71d39fdf56861cca = fieldSeparator.x71d39fdf56861cca;
		if (x71d39fdf56861cca != null)
		{
			xb36c250515e408ad.x7c3f3666365efbc6[x71d39fdf56861cca.x85c663cff7276f51] = x71d39fdf56861cca.x6b73aa01aa019d3a;
		}
		x953e86951da4f25a.xd646d4760b5a81b9(fieldSeparator);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitBookmarkStart(BookmarkStart bookmarkStart)
	{
		return xddd176d72ca20434.xa2b18804731061bd(bookmarkStart, x391d7559b0955a1e);
	}

	public override VisitorAction VisitBookmarkEnd(BookmarkEnd bookmarkEnd)
	{
		return xddd176d72ca20434.x3c82d5a325e3a429(bookmarkEnd, x391d7559b0955a1e);
	}

	public override VisitorAction VisitSmartTagStart(SmartTag smartTag)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(smartTag.Uri))
		{
			smartTag.Uri = "urn:schemas-microsoft-com:office:smarttags";
		}
		x9c52aa38e445d52b(smartTag);
		xb234855ba09e56eb(smartTag.Uri, xa51e8396352175fe: false);
		xb234855ba09e56eb(smartTag.Properties, xa51e8396352175fe: false);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCustomXmlMarkupStart(CustomXmlMarkup customXmlMarkup)
	{
		xb234855ba09e56eb(customXmlMarkup.Uri, xa51e8396352175fe: true);
		xb234855ba09e56eb(customXmlMarkup.Properties, xa51e8396352175fe: true);
		if (customXmlMarkup.Level == MarkupLevel.Block && !customXmlMarkup.HasChildNodes)
		{
			customXmlMarkup.AppendChild(new Paragraph(xb36c250515e408ad.x2c8c6741422a1298));
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitStructuredDocumentTagStart(StructuredDocumentTag sdt)
	{
		sdt.x3c0af6fbd91b1638(x2e5cc5728d3cf72d: false);
		if (sdt.SdtType == SdtType.DropDownList || sdt.SdtType == SdtType.ComboBox)
		{
			xc82265f4f18f9e0b(sdt);
		}
		if (x757a5da0f267b35e(xaa6aac6156ffea29.xacd3ae65df275dc6) && !sdt.xfb009d7bb278ad02(xb36c250515e408ad.x2c8c6741422a1298.CustomXmlParts))
		{
			xbbf9a1ead81dd3a1(WarningType.DataLossCategory, WarningSource.Validator, "Data binding failed for StructuredDocumentTag.");
		}
		return VisitorAction.Continue;
	}

	private static void xc82265f4f18f9e0b(StructuredDocumentTag xabd8f8a3b7f099d3)
	{
		SdtListItemCollection listItems = xabd8f8a3b7f099d3.ListItems;
		if (listItems.SelectedValue != null)
		{
			xabd8f8a3b7f099d3.IsShowingPlaceholderText = false;
			xb267219cbd6be42f.x5c752e32f2d4a6b2(xabd8f8a3b7f099d3, new Run(xabd8f8a3b7f099d3.Document, listItems.SelectedValue.DisplayText));
		}
	}

	private void x9c52aa38e445d52b(SmartTag xdc6161a296532e34)
	{
		string key = xdc6161a296532e34.Uri + xdc6161a296532e34.Element;
		xb36c250515e408ad.x916244faa1c7ed9f[key] = xdc6161a296532e34;
	}

	private void xb234855ba09e56eb(string xbda579af315c6893, bool xa51e8396352175fe)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbda579af315c6893))
		{
			if (!xb36c250515e408ad.x688a25acd97815ab.Contains(xbda579af315c6893))
			{
				int num = xb36c250515e408ad.x688a25acd97815ab.Count + 1;
				xb36c250515e408ad.x688a25acd97815ab.Add(xbda579af315c6893, num);
			}
			if (xa51e8396352175fe)
			{
				xb36c250515e408ad.xf6915d468ae54ed1[xbda579af315c6893] = xbda579af315c6893;
			}
		}
	}

	private void xb234855ba09e56eb(CustomXmlPropertyCollection xe11545499171cc05, bool xa51e8396352175fe)
	{
		foreach (CustomXmlProperty item in xe11545499171cc05)
		{
			xb234855ba09e56eb(item.Uri, xa51e8396352175fe);
		}
	}

	private bool x435660966d08ad82(Node xda5bf54deb817e37)
	{
		if (x391d7559b0955a1e != StoryType.MainText)
		{
			xda5bf54deb817e37.Remove();
			xbbf9a1ead81dd3a1(WarningType.DataLoss, WarningSource.Validator, $"{Node.NodeTypeToString(xda5bf54deb817e37.NodeType)} is not in the main text story and shall be removed.");
			return true;
		}
		return false;
	}

	private void xc3b0ad6a8458eac6(StoryType xdbbf47b5e620c262)
	{
		x3c347579e9b06f74.Push(xdbbf47b5e620c262);
	}

	private void xbbb4501cf9ca0e39(StoryType xdbbf47b5e620c262)
	{
		x3c347579e9b06f74.Pop();
	}

	private void x378d2013f6ee1de9(Document x6beba47238e0ade6)
	{
		if (x6beba47238e0ade6.x92fa7c4d9fc66489 == null)
		{
			return;
		}
		foreach (xf5e19a19d8e0a0e6 item in x6beba47238e0ade6.x92fa7c4d9fc66489)
		{
			if (item.x7bc28568bfa1ae1c == x74c5a2d6929342db.x4d0b9d4447ba7566)
			{
				xbbf9a1ead81dd3a1(WarningType.DataLoss, WarningSource.Unknown, "Invalid allocated command changed to ApplyStyle Normal.");
				item.x7bc28568bfa1ae1c = x74c5a2d6929342db.x7136f75b05cd09ec;
				item.x09b3682d5c365bf7 = new byte[6] { 1, 0, 0, 0, 0, 0 };
			}
		}
	}

	private bool x757a5da0f267b35e(xaa6aac6156ffea29 x5593294f497d433a)
	{
		return (x243bb528d2faf578 & x5593294f497d433a) == x5593294f497d433a;
	}

	private void x0f20e5e0ffb8c02d(Document x6beba47238e0ade6)
	{
		x2f5330e0b9089bce x2f5330e0b9089bce = x6beba47238e0ade6.x2f5330e0b9089bce;
		if (!x2f5330e0b9089bce.x38921fc0c986c5d7)
		{
			GlossaryDocument glossaryDocument = x6beba47238e0ade6.GlossaryDocument;
			if (glossaryDocument != null && !glossaryDocument.x2f5330e0b9089bce.x38921fc0c986c5d7)
			{
				x2f5330e0b9089bce.xc36ccefedcea4870(glossaryDocument.x2f5330e0b9089bce.x411de88df75af925);
			}
			if (x2f5330e0b9089bce.x01c46e4ecd96057e())
			{
				xbbf9a1ead81dd3a1(WarningType.DataLoss, WarningSource.Validator, "One or more unused StructuredDocumentTag placeholder blocks were removed from Document Glossary.");
			}
		}
	}

	private void xbbf9a1ead81dd3a1(WarningType x43163d22e8cd5a71, WarningSource x337e217cb3ba0627, string xc2358fbac7da3d45)
	{
		if (xf69ca7a9bb4a4a51 != null)
		{
			xf69ca7a9bb4a4a51.Warning(new WarningInfo(x43163d22e8cd5a71, x337e217cb3ba0627, xc2358fbac7da3d45));
		}
	}

	private static xaa6aac6156ffea29 x43b74f70460e9c4f(SaveFormat xd003f66121eb36a0)
	{
		return (xaa6aac6156ffea29)x99721e76766a944c[xd003f66121eb36a0];
	}

	static xcc0b5baa75272714()
	{
		x99721e76766a944c = new Hashtable();
		x99721e76766a944c.Add(SaveFormat.Doc, xaa6aac6156ffea29.x5881838f2f95a8cd | xaa6aac6156ffea29.xd0c6b0cc823598c8 | xaa6aac6156ffea29.x30f96f66f1661e11 | xaa6aac6156ffea29.x62b106b481f1f656 | xaa6aac6156ffea29.x0bdddc147ee0a81f | xaa6aac6156ffea29.xacd3ae65df275dc6);
		x99721e76766a944c.Add(SaveFormat.Dot, xaa6aac6156ffea29.x5881838f2f95a8cd | xaa6aac6156ffea29.xd0c6b0cc823598c8 | xaa6aac6156ffea29.x30f96f66f1661e11 | xaa6aac6156ffea29.x62b106b481f1f656 | xaa6aac6156ffea29.x0bdddc147ee0a81f | xaa6aac6156ffea29.xacd3ae65df275dc6);
		x99721e76766a944c.Add(SaveFormat.Docx, xaa6aac6156ffea29.xdd7eca4a70bd2700);
		x99721e76766a944c.Add(SaveFormat.Dotx, xaa6aac6156ffea29.xdd7eca4a70bd2700);
		x99721e76766a944c.Add(SaveFormat.Docm, xaa6aac6156ffea29.xdd7eca4a70bd2700);
		x99721e76766a944c.Add(SaveFormat.Dotm, xaa6aac6156ffea29.xdd7eca4a70bd2700);
		x99721e76766a944c.Add(SaveFormat.FlatOpc, xaa6aac6156ffea29.xdd7eca4a70bd2700);
		x99721e76766a944c.Add(SaveFormat.FlatOpcMacroEnabled, xaa6aac6156ffea29.xdd7eca4a70bd2700);
		x99721e76766a944c.Add(SaveFormat.FlatOpcTemplate, xaa6aac6156ffea29.xdd7eca4a70bd2700);
		x99721e76766a944c.Add(SaveFormat.FlatOpcTemplateMacroEnabled, xaa6aac6156ffea29.xdd7eca4a70bd2700);
		x99721e76766a944c.Add(SaveFormat.Rtf, xaa6aac6156ffea29.x5881838f2f95a8cd | xaa6aac6156ffea29.xd0c6b0cc823598c8 | xaa6aac6156ffea29.x30f96f66f1661e11 | xaa6aac6156ffea29.x62b106b481f1f656 | xaa6aac6156ffea29.xb8f4fa4f62915b68 | xaa6aac6156ffea29.x0bdddc147ee0a81f | xaa6aac6156ffea29.xacd3ae65df275dc6);
		x99721e76766a944c.Add(SaveFormat.WordML, xaa6aac6156ffea29.x5881838f2f95a8cd | xaa6aac6156ffea29.x30f96f66f1661e11 | xaa6aac6156ffea29.xdd7eca4a70bd2700 | xaa6aac6156ffea29.x62b106b481f1f656 | xaa6aac6156ffea29.xb8f4fa4f62915b68 | xaa6aac6156ffea29.xacd3ae65df275dc6);
		x99721e76766a944c.Add(SaveFormat.Pdf, xaa6aac6156ffea29.x0606e0834cf971bf);
		x99721e76766a944c.Add(SaveFormat.Xps, xaa6aac6156ffea29.x0606e0834cf971bf);
		x99721e76766a944c.Add(SaveFormat.XamlFixed, xaa6aac6156ffea29.x0606e0834cf971bf);
		x99721e76766a944c.Add(SaveFormat.Swf, xaa6aac6156ffea29.x0606e0834cf971bf);
		x99721e76766a944c.Add(SaveFormat.Svg, xaa6aac6156ffea29.x0606e0834cf971bf);
		x99721e76766a944c.Add(SaveFormat.Html, xaa6aac6156ffea29.xb7584ed5889b1016);
		x99721e76766a944c.Add(SaveFormat.Mhtml, xaa6aac6156ffea29.xb7584ed5889b1016);
		x99721e76766a944c.Add(SaveFormat.Epub, xaa6aac6156ffea29.xb7584ed5889b1016);
		x99721e76766a944c.Add(SaveFormat.Odt, xaa6aac6156ffea29.xb7584ed5889b1016 | xaa6aac6156ffea29.x1dd92c14dc4b33b5);
		x99721e76766a944c.Add(SaveFormat.Ott, xaa6aac6156ffea29.xb7584ed5889b1016 | xaa6aac6156ffea29.x1dd92c14dc4b33b5);
		x99721e76766a944c.Add(SaveFormat.Text, xaa6aac6156ffea29.xb7584ed5889b1016);
		x99721e76766a944c.Add(SaveFormat.XamlFlow, xaa6aac6156ffea29.xb7584ed5889b1016);
		x99721e76766a944c.Add(SaveFormat.XamlFlowPack, xaa6aac6156ffea29.xb7584ed5889b1016);
	}
}
