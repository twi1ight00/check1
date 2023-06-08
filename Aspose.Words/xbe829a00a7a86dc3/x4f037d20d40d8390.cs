using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using Aspose.Words.Lists;
using Aspose.Words.Markup;
using Aspose.Words.Math;
using Aspose.Words.Saving;
using Aspose.Words.Tables;
using x011d489fb9df7027;
using x0a300997a0b66409;
using x13f1efc79617a47b;
using x1a3e96f4b89a7a77;
using x28925c9b27b37a46;
using x5af3f327d745698a;
using x650fee20d618512c;
using x6c95d9cf46ff5f25;
using x7c7a1dceb600404e;
using xa8550ea6ae4a81a5;
using xb92b7270f78a4e8d;
using xd2754ae26d400653;
using xda075892eccab2ad;
using xf989f31a236ff98c;
using xf9a9481c3f63a419;
using xfbd1009a0cbb9842;

namespace xbe829a00a7a86dc3;

internal class x4f037d20d40d8390 : DocumentVisitor, x3d2908992e1d1667, xfe11bbc13ba649c3
{
	private xf141024760662983 x5a7a1d229173bf5d;

	private x738c5c0b76a0e787 x8cedcaa9a62c6e39;

	private xf7173b82df2a4de7 x800085dd555f7711;

	private Paragraph x92add8e2556c5954;

	private Section xb823e70c83bd8abd;

	private IDictionary xbc4ea30fdf3f31af;

	private readonly Hashtable x80707bc8b89a10df = new Hashtable();

	private IDictionary xb6a1563d27b00661;

	private Stack x215f4deb55f3496c;

	private int x4825cc64be84ad61;

	private Document x232be220f517f721;

	private int x18730ec3a68983e6;

	private string x89f64afc54e173ca;

	private string x37712e332591d891;

	private bool x862813a0b365fc35;

	private IWarningCallback xa056586c1f99e199;

	private bool xb9357c70057ae515;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public x873451caae5ad4ae xe1410f585439c7d4 => x800085dd555f7711;

	bool xfe11bbc13ba649c3.x3ce730d73eb85c69 => false;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public DocumentBase x2c8c6741422a1298 => x232be220f517f721;

	internal string x8204ba5be8a516ae => x89f64afc54e173ca;

	internal string x412ac5cf0bbdaed3 => x37712e332591d891;

	internal bool xbbb9faf31c170b64
	{
		get
		{
			return xb9357c70057ae515;
		}
		set
		{
			xb9357c70057ae515 = value;
		}
	}

	private SaveOutputParameters x8cac5adfe79bc025(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		x5ac1382edb7bf2c2.xd65754175bfac027();
		x232be220f517f721 = x5ac1382edb7bf2c2.x2c8c6741422a1298;
		xa056586c1f99e199 = x5ac1382edb7bf2c2.xf57de0fd37d5e97d.WarningCallback;
		x800085dd555f7711 = new xf7173b82df2a4de7(x5ac1382edb7bf2c2.xb8a774e0111d0fbe, x5ac1382edb7bf2c2.xf57de0fd37d5e97d.PrettyFormat);
		x8cedcaa9a62c6e39 = new x738c5c0b76a0e787(x5ac1382edb7bf2c2, x800085dd555f7711);
		x5a7a1d229173bf5d = new xf141024760662983(this);
		x215f4deb55f3496c = new Stack();
		x4825cc64be84ad61 = 0;
		xb6a1563d27b00661 = xd51c34d05311eee3.xdb04a310bbb29cff();
		xbc4ea30fdf3f31af = xd51c34d05311eee3.xdb04a310bbb29cff();
		xe3d2f5ee6867cec8();
		return new SaveOutputParameters("text/xml");
	}

	SaveOutputParameters x3d2908992e1d1667.xa2e0b7f7da663553(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x8cac5adfe79bc025
		return this.x8cac5adfe79bc025(x5ac1382edb7bf2c2);
	}

	public void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(x9f91de645a9fe01a, WarningSource.WordML, xc2358fbac7da3d45));
		}
	}

	internal void x3dc950453374051a(string xc2358fbac7da3d45)
	{
		xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, xc2358fbac7da3d45);
	}

	private void xe3d2f5ee6867cec8()
	{
		x800085dd555f7711.x9b9ed0109b743e3b();
		x800085dd555f7711.xff520a0047c27122("xmlns:w", "http://schemas.microsoft.com/office/word/2003/wordml");
		x800085dd555f7711.xff520a0047c27122("xmlns:v", "urn:schemas-microsoft-com:vml");
		x800085dd555f7711.xff520a0047c27122("xmlns:w10", "urn:schemas-microsoft-com:office:word");
		x800085dd555f7711.xff520a0047c27122("xmlns:sl", "http://schemas.microsoft.com/schemaLibrary/2003/core");
		x800085dd555f7711.xff520a0047c27122("xmlns:aml", "http://schemas.microsoft.com/aml/2001/core");
		x800085dd555f7711.xff520a0047c27122("xmlns:wx", "http://schemas.microsoft.com/office/word/2003/auxHint");
		x800085dd555f7711.xff520a0047c27122("xmlns:o", "urn:schemas-microsoft-com:office:office");
		x800085dd555f7711.xff520a0047c27122("xmlns:dt", "uuid:C2F41010-65B3-11d1-A29F-00AA00C14882");
		if (xbbb9faf31c170b64)
		{
			x800085dd555f7711.xff520a0047c27122("xmlns:m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
		}
		x17e7a9bf3a859e5c();
		x800085dd555f7711.xff520a0047c27122("w:macrosPresent", x52d19714b8de76c2(x232be220f517f721) ? "yes" : "no");
		x800085dd555f7711.xff520a0047c27122("w:embeddedObjPresent", x8cedcaa9a62c6e39.x8556eed81191af11.x3a8dc2dec3d16d89 ? "yes" : "no");
		x800085dd555f7711.xff520a0047c27122("w:ocxPresent", x8cedcaa9a62c6e39.x8556eed81191af11.xdff795aea0409829 ? "yes" : "no");
		x800085dd555f7711.xff520a0047c27122("xml:space", "preserve");
		if (x8cedcaa9a62c6e39.xf57de0fd37d5e97d.xbfa4c2c3efbf56fd)
		{
			x800085dd555f7711.x5222f4285e37d66b.WriteComment(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hladlnhdgpodmpfeapmekpdfgokfgpbgeoigaopgjjghinnhmoeiajliiocjkjjjeoakeihk", 1227108503)), "Aspose.Words for .NET 11.9.0.0"));
		}
		x81015daaa1564ba9();
		x311bb10d5871a09f.xfb2c8e68dcdb7b29(x232be220f517f721, x800085dd555f7711, x5060af8676e106e7: false);
		x26b7a1d1ec03d3ee.x6210059f049f0d48(x232be220f517f721, x800085dd555f7711);
		x38aebc91d9dab52b.x6210059f049f0d48(x232be220f517f721, x800085dd555f7711, x5fbb1a9c98604ef5: false);
		x785545f7afb8428d();
		x6f126bc7f29ba4bf();
		x6a4fcdf470e50a7e();
		xbb861b5f922799cf();
		x409f6d17d51b0ce0(x232be220f517f721.BackgroundShape, x800085dd555f7711, x8cedcaa9a62c6e39);
		xb9542a0770aa21b0.x6210059f049f0d48(this);
		x800085dd555f7711.x2307058321cdb62f("w:body");
		for (Node node = x232be220f517f721.FirstChild; node != null; node = node.NextSibling)
		{
			x51ee56decc29a9da((Section)node);
		}
		x800085dd555f7711.x2dfde153f4ef96d0();
		x800085dd555f7711.xa0dfc102c691b11f();
	}

	private void x17e7a9bf3a859e5c()
	{
		foreach (DictionaryEntry item in x8cedcaa9a62c6e39.x8556eed81191af11.x688a25acd97815ab)
		{
			string text = (string)item.Key;
			int num = (int)item.Value;
			string arg = ((x8cedcaa9a62c6e39.x8556eed81191af11.xf6915d468ae54ed1[text] != null) ? "ns" : "st");
			x800085dd555f7711.xff520a0047c27122($"xmlns:{arg}{num}", text);
		}
	}

	private void x81015daaa1564ba9()
	{
		foreach (SmartTag value in x8cedcaa9a62c6e39.x8556eed81191af11.x916244faa1c7ed9f.GetValueList())
		{
			x800085dd555f7711.x2307058321cdb62f("o:SmartTagType");
			x800085dd555f7711.x943f6be3acf634db("o:namespaceuri", value.Uri);
			x800085dd555f7711.x943f6be3acf634db("o:name", value.Element);
			x800085dd555f7711.x2dfde153f4ef96d0();
		}
	}

	private void x51ee56decc29a9da(Section xb32f8dd719a105db)
	{
		xb823e70c83bd8abd = xb32f8dd719a105db;
		x92add8e2556c5954 = xb32f8dd719a105db.Body.LastParagraph;
		x800085dd555f7711.x2307058321cdb62f("wx:sect");
		xb32f8dd719a105db.Body.Accept(this);
		if (xb823e70c83bd8abd.x16479f42fe4547f2)
		{
			xce7f0abd6b3cc3be.x6210059f049f0d48(xb823e70c83bd8abd, this);
		}
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	public override VisitorAction VisitTableStart(Table table)
	{
		x800085dd555f7711.x2307058321cdb62f("w:tbl");
		x31b31073210f038b.x6210059f049f0d48(table.FirstRow.xedb0eb766e25e0c9, x97b4bbf66b3d8bc6: true, x37f701492043cfc5: false, this);
		x88fc04b3ff226822.x37ae3bbd6d2584f4(table);
		x88fc04b3ff226822.xd71f0ca619f1aa02(x800085dd555f7711, table);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitTableEnd(Table table)
	{
		x800085dd555f7711.x2dfde153f4ef96d0();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitRowStart(Row row)
	{
		x800085dd555f7711.x2307058321cdb62f("w:tr");
		x31b31073210f038b.x6210059f049f0d48(row.xedb0eb766e25e0c9, x97b4bbf66b3d8bc6: false, x37f701492043cfc5: false, this);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitRowEnd(Row row)
	{
		x800085dd555f7711.x2dfde153f4ef96d0();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCellStart(Cell cell)
	{
		x800085dd555f7711.x2307058321cdb62f("w:tc");
		x7142005363c1dbcf.x6210059f049f0d48(cell.xf8cef531dae89ea3, this);
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitOfficeMathStart(OfficeMath officeMath)
	{
		x0a5bbd4dccc0b802.xd29409f2ba9889e2(officeMath, this);
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitOfficeMathEnd(OfficeMath officeMath)
	{
		x0a5bbd4dccc0b802.x685b1e5a342b26d7(x800085dd555f7711);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCellEnd(Cell cell)
	{
		x800085dd555f7711.x2dfde153f4ef96d0();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitParagraphStart(Paragraph para)
	{
		x800085dd555f7711.x2307058321cdb62f("w:p");
		xfb80633b3fcbe371(para);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitParagraphEnd(Paragraph para)
	{
		x800085dd555f7711.x2dfde153f4ef96d0();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldStart(FieldStart fieldStart)
	{
		xfb78915a60b77e4b(fieldStart);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldSeparator(FieldSeparator fieldSeparator)
	{
		xfb78915a60b77e4b(fieldSeparator);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldEnd(FieldEnd fieldEnd)
	{
		xfb78915a60b77e4b(fieldEnd);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitBookmarkStart(BookmarkStart bookmarkStart)
	{
		int num = x28ee4b8b8f777b55();
		xbc4ea30fdf3f31af.Add(bookmarkStart.Name, num);
		x800085dd555f7711.x2307058321cdb62f("aml:annotation");
		x800085dd555f7711.x943f6be3acf634db("aml:id", num);
		x800085dd555f7711.x943f6be3acf634db("w:type", "Word.Bookmark.Start");
		x800085dd555f7711.xff520a0047c27122("w:name", bookmarkStart.Name);
		if (bookmarkStart.xf1b59c88b25f8eec)
		{
			xb6a1563d27b00661.Add(bookmarkStart.Name, bookmarkStart);
			x800085dd555f7711.x943f6be3acf634db("w:col-first", bookmarkStart.xb78c16d5f2d4f2f7);
			x800085dd555f7711.x943f6be3acf634db("w:col-last", bookmarkStart.x279da4adfba57f2d - 1);
		}
		x800085dd555f7711.x2dfde153f4ef96d0();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitBookmarkEnd(BookmarkEnd bookmarkEnd)
	{
		x800085dd555f7711.x2307058321cdb62f("aml:annotation");
		x800085dd555f7711.x943f6be3acf634db("aml:id", (int)xbc4ea30fdf3f31af[bookmarkEnd.Name]);
		x800085dd555f7711.x943f6be3acf634db("w:type", "Word.Bookmark.End");
		BookmarkStart bookmarkStart = (BookmarkStart)xb6a1563d27b00661[bookmarkEnd.Name];
		if (bookmarkStart != null)
		{
			x800085dd555f7711.x943f6be3acf634db("w:col-first", bookmarkStart.xb78c16d5f2d4f2f7);
			x800085dd555f7711.x943f6be3acf634db("w:col-last", bookmarkStart.x279da4adfba57f2d - 1);
		}
		x800085dd555f7711.x2dfde153f4ef96d0();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitSpecialChar(SpecialChar specialChar)
	{
		x5a7a1d229173bf5d.x1ad30cf176eb522c(specialChar);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitGroupShapeStart(GroupShape groupShape)
	{
		if (groupShape.IsTopLevel)
		{
			x73eee79ab9d615d9(groupShape);
		}
		xa25dec8c824ea182.x6210059f049f0d48(groupShape, x800085dd555f7711, x8cedcaa9a62c6e39);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitGroupShapeEnd(GroupShape groupShape)
	{
		xa25dec8c824ea182.xe9c9c7110892d4dc(groupShape, x800085dd555f7711);
		x800085dd555f7711.x2dfde153f4ef96d0();
		if (groupShape.IsTopLevel)
		{
			x4907259ee48e3d89();
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitShapeStart(Shape shape)
	{
		x7578ebaf879d79c6(shape.xeedad81aaed42a76);
		if (shape.x2e3d2d1def6f4dad)
		{
			x862813a0b365fc35 = true;
			shape.x88d1b78392d1a0ab(ShapeType.Image);
		}
		else
		{
			x862813a0b365fc35 = false;
		}
		if (shape.xe415f17cf389e946)
		{
			x4e44079093b28b81(shape);
		}
		if (shape.IsTopLevel)
		{
			x73eee79ab9d615d9(shape);
		}
		if (!xc2f8d84d0cae2fc2(shape))
		{
			xa25dec8c824ea182.x6210059f049f0d48(shape, x800085dd555f7711, x8cedcaa9a62c6e39);
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitShapeEnd(Shape shape)
	{
		if (shape.HasChildNodes)
		{
			x800085dd555f7711.x2dfde153f4ef96d0();
			x800085dd555f7711.x2dfde153f4ef96d0();
		}
		if (!xc2f8d84d0cae2fc2(shape))
		{
			xa25dec8c824ea182.xe9c9c7110892d4dc(shape, x800085dd555f7711);
			x800085dd555f7711.x2dfde153f4ef96d0();
		}
		if (shape.xa170cce2bc40bdf5)
		{
			x85c378f71aeff1d2(shape);
		}
		if (shape.IsTopLevel)
		{
			x4907259ee48e3d89();
		}
		if (shape.xe415f17cf389e946)
		{
			x1210e8a0b401d5a2();
		}
		if (x862813a0b365fc35)
		{
			shape.x88d1b78392d1a0ab(ShapeType.OleControl);
		}
		x7b1f332749aba8fe(shape.xeedad81aaed42a76);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitRun(Run run)
	{
		x7578ebaf879d79c6(run.xeedad81aaed42a76);
		x5a7a1d229173bf5d.x486167d7a74e8e88(run);
		x7b1f332749aba8fe(run.xeedad81aaed42a76);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitSubDocument(SubDocument subDocument)
	{
		x800085dd555f7711.x2307058321cdb62f("w:subDoc");
		x800085dd555f7711.x943f6be3acf634db("w:link", subDocument.xa39af5a82860a9a3);
		x800085dd555f7711.x2dfde153f4ef96d0("w:subDoc");
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentStart(Comment comment)
	{
		x7578ebaf879d79c6(comment.xeedad81aaed42a76);
		x5a7a1d229173bf5d.x32c9a0cbee7be23c(comment.xeedad81aaed42a76, comment.xeedad81aaed42a76, x8f19af4759cf8cd4: false);
		x800085dd555f7711.x2307058321cdb62f("aml:annotation");
		x800085dd555f7711.x943f6be3acf634db("aml:id", x9bb95fbbb3ee055a(comment.Id));
		x800085dd555f7711.x943f6be3acf634db("aml:author", comment.Author);
		x800085dd555f7711.x943f6be3acf634db("aml:createdate", comment.DateTime);
		x800085dd555f7711.x943f6be3acf634db("w:type", "Word.Comment");
		x800085dd555f7711.x943f6be3acf634db("w:initials", comment.Initial);
		x800085dd555f7711.x2307058321cdb62f("aml:content");
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentEnd(Comment comment)
	{
		x800085dd555f7711.x2dfde153f4ef96d0();
		x800085dd555f7711.x2dfde153f4ef96d0();
		x5a7a1d229173bf5d.xf0de1bdc2a5440b2();
		x7b1f332749aba8fe(comment.xeedad81aaed42a76);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentRangeStart(CommentRangeStart commentRangeStart)
	{
		x800085dd555f7711.x2307058321cdb62f("aml:annotation");
		x800085dd555f7711.x943f6be3acf634db("aml:id", x9bb95fbbb3ee055a(commentRangeStart.Id));
		x800085dd555f7711.x943f6be3acf634db("w:type", "Word.Comment.Start");
		x800085dd555f7711.x2dfde153f4ef96d0();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentRangeEnd(CommentRangeEnd commentRangeEnd)
	{
		x800085dd555f7711.x2307058321cdb62f("aml:annotation");
		x800085dd555f7711.x943f6be3acf634db("aml:id", x9bb95fbbb3ee055a(commentRangeEnd.Id));
		x800085dd555f7711.x943f6be3acf634db("w:type", "Word.Comment.End");
		x800085dd555f7711.x2dfde153f4ef96d0();
		return VisitorAction.Continue;
	}

	private int x9bb95fbbb3ee055a(int x95ba6348fe1fdbe4)
	{
		object obj = x80707bc8b89a10df[x95ba6348fe1fdbe4];
		if (obj != null)
		{
			return (int)obj;
		}
		int num = x28ee4b8b8f777b55();
		x80707bc8b89a10df[x95ba6348fe1fdbe4] = num;
		return num;
	}

	public override VisitorAction VisitFootnoteStart(Footnote footnote)
	{
		x7578ebaf879d79c6(footnote.xeedad81aaed42a76);
		x5a7a1d229173bf5d.x32c9a0cbee7be23c(footnote.xeedad81aaed42a76, footnote.xeedad81aaed42a76, x8f19af4759cf8cd4: false);
		switch (footnote.FootnoteType)
		{
		case FootnoteType.Footnote:
			x5a7a1d229173bf5d.xd7b3f218029cb4b8 = FootnoteType.Footnote;
			x800085dd555f7711.x2307058321cdb62f("w:footnote");
			break;
		case FootnoteType.Endnote:
			x5a7a1d229173bf5d.xd7b3f218029cb4b8 = FootnoteType.Endnote;
			x800085dd555f7711.x2307058321cdb62f("w:endnote");
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ghdjmikjgibkgiikeipkjiglnhnlmcempglmfhcnchjnehaolghojgoolgfpjfmpbbdacgkaegbbifibkepbabgc", 365925153)));
		}
		x800085dd555f7711.x0ea3ef8dd3ae2f3f("w:suppressRef", !footnote.xa72bf798a679c0aa);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFootnoteEnd(Footnote footnote)
	{
		x800085dd555f7711.x2dfde153f4ef96d0();
		if (!footnote.xa72bf798a679c0aa)
		{
			xaf66e8c590b2b553.x5294c7c09585b7b2(x800085dd555f7711, footnote);
		}
		x5a7a1d229173bf5d.xf0de1bdc2a5440b2();
		x7b1f332749aba8fe(footnote.xeedad81aaed42a76);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitSmartTagStart(SmartTag smartTag)
	{
		x800085dd555f7711.x2307058321cdb62f(xa9005f6d66fa82b4("st", smartTag.Uri, smartTag.Element));
		foreach (CustomXmlProperty property in smartTag.Properties)
		{
			x800085dd555f7711.x943f6be3acf634db(xa9005f6d66fa82b4("st", property.Uri, property.Name), property.Value);
		}
		x800085dd555f7711.x943f6be3acf634db("w:st", xbcea506a33cf9111: true);
		return VisitorAction.Continue;
	}

	private string xa9005f6d66fa82b4(string x05bcae9c376a7a50, string xbda579af315c6893, string xc15bd84e01929885)
	{
		object obj = x8cedcaa9a62c6e39.x8556eed81191af11.x688a25acd97815ab[xbda579af315c6893];
		if (obj == null)
		{
			return xc15bd84e01929885;
		}
		return $"{x05bcae9c376a7a50}{obj}:{xc15bd84e01929885}";
	}

	public override VisitorAction VisitSmartTagEnd(SmartTag smartTag)
	{
		x800085dd555f7711.x2dfde153f4ef96d0();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitAbsolutePositionTab(AbsolutePositionTab tab)
	{
		xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, "Absolute position tabs are not supported in WordML, using regular tab character.");
		return base.VisitAbsolutePositionTab(tab);
	}

	public override VisitorAction VisitCustomXmlMarkupStart(CustomXmlMarkup customXml)
	{
		x800085dd555f7711.x2307058321cdb62f(xa9005f6d66fa82b4("ns", customXml.Uri, customXml.Element));
		if (x0d299f323d241756.x5959bccb67bbf051(customXml.Placeholder))
		{
			x800085dd555f7711.x943f6be3acf634db("w:placeholder", customXml.Placeholder);
		}
		foreach (CustomXmlProperty property in customXml.Properties)
		{
			x800085dd555f7711.x943f6be3acf634db(xa9005f6d66fa82b4("ns", property.Uri, property.Name), property.Value);
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCustomXmlMarkupEnd(CustomXmlMarkup customXml)
	{
		x800085dd555f7711.x2dfde153f4ef96d0();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitStructuredDocumentTagStart(StructuredDocumentTag sdt)
	{
		xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, "Structured document tag is not supported in WordML format, during conversion only the plain content is retained.");
		return base.VisitStructuredDocumentTagStart(sdt);
	}

	private static void x409f6d17d51b0ce0(Shape x5770cdefd8931aa9, x873451caae5ad4ae xd07ce4b74c5774a7, x2cd1f1f5e07462a8 x0f7b23d1c393aed9)
	{
		if (Shape.x2e634d5c614a25de(x5770cdefd8931aa9))
		{
			xd07ce4b74c5774a7.x2307058321cdb62f("w:bgPict");
			xd07ce4b74c5774a7.x2307058321cdb62f("w:background");
			xd07ce4b74c5774a7.xff520a0047c27122("w:bgcolor", xd76179d16486fd56.xbe7cce711e45fa32(x5770cdefd8931aa9.Fill.x63b1a7c31a962459, x0dae4143cd874639: false, xeaf65170fc9ee55f: true));
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
			xa25dec8c824ea182.x6210059f049f0d48(x5770cdefd8931aa9, xe4b4fecd3c706380: true, xd07ce4b74c5774a7, x0f7b23d1c393aed9);
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		}
	}

	private void x6a4fcdf470e50a7e()
	{
		if (x8cedcaa9a62c6e39.x8556eed81191af11.x3a8dc2dec3d16d89)
		{
			x800085dd555f7711.x2307058321cdb62f("w:docOleData");
			x800085dd555f7711.x2307058321cdb62f("w:binData");
			x800085dd555f7711.x943f6be3acf634db("w:name", "oledata.mso");
			x800085dd555f7711.xe24c4103102bcb90(x8cedcaa9a62c6e39.xf673ee20dd3b9183);
			x800085dd555f7711.x2dfde153f4ef96d0();
			x800085dd555f7711.x2dfde153f4ef96d0();
		}
	}

	private void xbb861b5f922799cf()
	{
		if (!x52d19714b8de76c2(x232be220f517f721))
		{
			return;
		}
		x800085dd555f7711.x2307058321cdb62f("w:docSuppData");
		x800085dd555f7711.x2307058321cdb62f("w:binData");
		x800085dd555f7711.x943f6be3acf634db("w:name", "editdata.mso");
		MemoryStream memoryStream = new MemoryStream();
		x0d299f323d241756.x01a74f169007d206("ActiveMime", memoryStream);
		x0d299f323d241756.x244f57c2c3806fa8(4026597376u, memoryStream);
		x0d299f323d241756.x244f57c2c3806fa8(4u, memoryStream);
		x0d299f323d241756.x244f57c2c3806fa8(uint.MaxValue, memoryStream);
		if (x232be220f517f721.HasMacros)
		{
			x0d299f323d241756.x244f57c2c3806fa8(4026990592u, memoryStream);
			xd8c3135513b9115b xd8c3135513b9115b = new xd8c3135513b9115b(x232be220f517f721.x92e2e3377da135e8);
			MemoryStream memoryStream2 = new MemoryStream();
			xd8c3135513b9115b.x0acd3c2012ea2ee8(memoryStream2);
			memoryStream2.Seek(0L, SeekOrigin.Begin);
			byte[] array = xf1da3993f05a75b7.x575db3fedeadea6b(memoryStream2, x2e6ebe7013ab34b9.x1455a9a8b1cd9f39);
			byte[] array2 = x232be220f517f721.xd7b817e9f42390ee;
			if (array2 == null)
			{
				array2 = new byte[0];
			}
			x0d299f323d241756.x244f57c2c3806fa8((uint)(16 + array2.Length + 4 + array.Length), memoryStream);
			x0d299f323d241756.x244f57c2c3806fa8(4u, memoryStream);
			x0d299f323d241756.x244f57c2c3806fa8(4u, memoryStream);
			x0d299f323d241756.x244f57c2c3806fa8((uint)array2.Length, memoryStream);
			x0d299f323d241756.x244f57c2c3806fa8((uint)x232be220f517f721.xa0a845678e16cf58, memoryStream);
			memoryStream.Write(array2, 0, array2.Length);
			x0d299f323d241756.x244f57c2c3806fa8((uint)memoryStream2.Length, memoryStream);
			memoryStream.Write(array, 0, array.Length);
		}
		if (x52d19714b8de76c2(x232be220f517f721))
		{
			x0d299f323d241756.x244f57c2c3806fa8(4027383808u, memoryStream);
			byte[] array3 = x54f8736ac055fcaa();
			x0d299f323d241756.x244f57c2c3806fa8((uint)array3.Length, memoryStream);
			memoryStream.Write(array3, 0, array3.Length);
		}
		x0d299f323d241756.x244f57c2c3806fa8(4027252736u, memoryStream);
		x0d299f323d241756.x244f57c2c3806fa8(4u, memoryStream);
		x0d299f323d241756.x244f57c2c3806fa8(2018915346u, memoryStream);
		x800085dd555f7711.xe24c4103102bcb90(memoryStream);
		x800085dd555f7711.x2dfde153f4ef96d0();
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	private static bool x52d19714b8de76c2(Document x6beba47238e0ade6)
	{
		if (!x6beba47238e0ade6.HasMacros)
		{
			return x6beba47238e0ade6.x55676d6d0c3d48c0;
		}
		return true;
	}

	private byte[] x54f8736ac055fcaa()
	{
		MemoryStream memoryStream = new MemoryStream();
		xd579be970f60ebcb xd579be970f60ebcb = new xd579be970f60ebcb();
		memoryStream.Position = 16L;
		int xbcea506a33cf = xd579be970f60ebcb.x6210059f049f0d48(x232be220f517f721, new BinaryWriter(memoryStream));
		memoryStream.Position = 0L;
		x0d299f323d241756.x244f57c2c3806fa8(268u, memoryStream);
		x0d299f323d241756.x244f57c2c3806fa8((uint)xbcea506a33cf, memoryStream);
		x0d299f323d241756.x244f57c2c3806fa8(0u, memoryStream);
		x0d299f323d241756.x244f57c2c3806fa8(1033u, memoryStream);
		return memoryStream.ToArray();
	}

	private void x785545f7afb8428d()
	{
		if (x232be220f517f721.Lists.xddf1da3d36406847 != 0 || x232be220f517f721.Lists.Count != 0)
		{
			x800085dd555f7711.x2307058321cdb62f("w:lists");
			xa23a9cf7d03725c8();
			x2788ff87c749937c();
			xb95b48034d7dfbc5();
			x800085dd555f7711.x2dfde153f4ef96d0();
		}
	}

	private void xa23a9cf7d03725c8()
	{
		for (int i = 0; i < x232be220f517f721.Lists.xe10f375b4290d48f; i++)
		{
			Shape x5770cdefd8931aa = x232be220f517f721.Lists.x4916e8670feefe58(i);
			x800085dd555f7711.x2307058321cdb62f("w:listPicBullet");
			x800085dd555f7711.x943f6be3acf634db("w:listPicBulletId", i);
			x800085dd555f7711.x2307058321cdb62f("w:pict");
			xa25dec8c824ea182.x6210059f049f0d48(x5770cdefd8931aa, x800085dd555f7711, x8cedcaa9a62c6e39);
			x800085dd555f7711.x2dfde153f4ef96d0();
			x800085dd555f7711.x2dfde153f4ef96d0();
			x800085dd555f7711.x2dfde153f4ef96d0();
		}
	}

	private void x2788ff87c749937c()
	{
		for (int i = 0; i < x232be220f517f721.Lists.xddf1da3d36406847; i++)
		{
			x178ff6dcbf808c38 x178ff6dcbf808c = x232be220f517f721.Lists.x3bfa6064d69ac0da(i);
			x800085dd555f7711.x2307058321cdb62f("w:listDef");
			x800085dd555f7711.x943f6be3acf634db("w:listDefId", i);
			x800085dd555f7711.x547195bcc386fe66("w:lsid", xc1b08afa36bf580c.x0d28bf60e577f9e5(x178ff6dcbf808c.x1eac770549050632));
			x800085dd555f7711.x547195bcc386fe66("w:plt", x9b180425349f0e97.xead78d0a9a85d806(x178ff6dcbf808c.x902c8ac86fbaf048));
			x800085dd555f7711.x547195bcc386fe66("w:tmpl", xc1b08afa36bf580c.x0d28bf60e577f9e5(x178ff6dcbf808c.x18f9fc979b70e77f));
			x800085dd555f7711.x547195bcc386fe66("w:name", x178ff6dcbf808c.x759aa16c2016a289);
			if (x178ff6dcbf808c.xf81d0e09758457fe)
			{
				x800085dd555f7711.x547195bcc386fe66("w:styleLink", x8cedcaa9a62c6e39.x7af082eaf8e0caa4(x178ff6dcbf808c.xc657ea789af2c1f0));
			}
			if (x178ff6dcbf808c.x01381925b7dd551e)
			{
				x800085dd555f7711.x547195bcc386fe66("w:listStyleLink", x8cedcaa9a62c6e39.x7af082eaf8e0caa4(x178ff6dcbf808c.xc657ea789af2c1f0));
			}
			else
			{
				for (int j = 0; j < x178ff6dcbf808c.x438a2a8db4b2d07b.Count; j++)
				{
					x788718c529bf1726(x178ff6dcbf808c.x438a2a8db4b2d07b[j]);
				}
			}
			x800085dd555f7711.x2dfde153f4ef96d0();
		}
	}

	private void xb95b48034d7dfbc5()
	{
		foreach (List list in x232be220f517f721.Lists)
		{
			int num = x232be220f517f721.Lists.x19a9fba0f6b6b791(list.x1eac770549050632);
			if (num < 0)
			{
				continue;
			}
			x800085dd555f7711.x2307058321cdb62f("w:list");
			x800085dd555f7711.x943f6be3acf634db("w:ilfo", list.ListId);
			x800085dd555f7711.x547195bcc386fe66("w:ilst", num);
			foreach (x136abcf7d9c0eef3 item in list.x6047afa6812e47bc)
			{
				x800085dd555f7711.x2307058321cdb62f("w:lvlOverride");
				x800085dd555f7711.x943f6be3acf634db("w:ilvl", item.xf13a626e550cef8f.x008c23e8f687bbd3);
				if (item.x33160172e2e7ff13)
				{
					x800085dd555f7711.x547195bcc386fe66("w:startOverride", item.x6da6130e001c6962);
				}
				if (item.x178c863a9c967cd2)
				{
					x788718c529bf1726(item.xf13a626e550cef8f);
				}
				x800085dd555f7711.x2dfde153f4ef96d0();
			}
			x800085dd555f7711.x2dfde153f4ef96d0();
		}
	}

	private void x788718c529bf1726(ListLevel x66bbd7ed8c65740d)
	{
		x800085dd555f7711.x2307058321cdb62f("w:lvl");
		x800085dd555f7711.x943f6be3acf634db("w:ilvl", x66bbd7ed8c65740d.x008c23e8f687bbd3);
		x800085dd555f7711.x0ea3ef8dd3ae2f3f("w:tentative", x66bbd7ed8c65740d.x83b68d5fabfc1faa);
		x800085dd555f7711.x547195bcc386fe66("w:start", x66bbd7ed8c65740d.StartAt);
		if (x66bbd7ed8c65740d.NumberStyle != 0)
		{
			x800085dd555f7711.x547195bcc386fe66("w:nfc", (int)x66bbd7ed8c65740d.NumberStyle);
		}
		if (x66bbd7ed8c65740d.xfbad6d0650721048)
		{
			x800085dd555f7711.x547195bcc386fe66("w:lvlRestart", x66bbd7ed8c65740d.RestartAfterLevel + 1);
		}
		if (x66bbd7ed8c65740d.x4a1340b0df048976 != 4095)
		{
			x800085dd555f7711.x547195bcc386fe66("w:pStyle", x8cedcaa9a62c6e39.x7af082eaf8e0caa4(x66bbd7ed8c65740d.x4a1340b0df048976));
		}
		x800085dd555f7711.x9601fe92a1b73d3f("w:isLgl", x66bbd7ed8c65740d.IsLegal);
		if (x66bbd7ed8c65740d.TrailingCharacter != 0)
		{
			x800085dd555f7711.x547195bcc386fe66("w:suff", x9b180425349f0e97.xa01b2bd227f7b4da(x66bbd7ed8c65740d.TrailingCharacter));
		}
		if (x0d299f323d241756.x5959bccb67bbf051(x66bbd7ed8c65740d.NumberFormat))
		{
			x800085dd555f7711.x2307058321cdb62f("w:lvlText");
			x800085dd555f7711.xff520a0047c27122("w:val", xc1b08afa36bf580c.x0bd71ffeca440ed7(x66bbd7ed8c65740d.NumberFormat));
			x800085dd555f7711.x2dfde153f4ef96d0();
		}
		if (x66bbd7ed8c65740d.x44b52529222cea8a)
		{
			x800085dd555f7711.x547195bcc386fe66("w:lvlPicBulletId", x66bbd7ed8c65740d.x4d819daa8b29e86b);
		}
		if (x66bbd7ed8c65740d.xf9be1d0b8b44c7e8)
		{
			x800085dd555f7711.xc049ea80ee267201("w:legacy", "w:legacy", x66bbd7ed8c65740d.xf9be1d0b8b44c7e8, "w:legacySpace", x66bbd7ed8c65740d.x42bf8be828fc1b33, "w:legacyIndent", x66bbd7ed8c65740d.x5cf63f659ff5ee9f);
		}
		x800085dd555f7711.x547195bcc386fe66("w:lvlJc", x9b180425349f0e97.x2d34925176627bf2(x66bbd7ed8c65740d.Alignment));
		x2aa41ce9e83be7cd.x6210059f049f0d48(x66bbd7ed8c65740d.x1a78664fa10a3755, this);
		xc70f986e9535e88a.x064651cf6a5fbfbe(x66bbd7ed8c65740d.xeedad81aaed42a76, x66bbd7ed8c65740d.xeedad81aaed42a76, this);
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	private void x6f126bc7f29ba4bf()
	{
		x800085dd555f7711.x2307058321cdb62f("w:styles");
		x800085dd555f7711.x547195bcc386fe66("w:versionOfBuiltInStylenames", xca004f56614e2431.x754c3a5f03a2ce84(7));
		x36da930309c3ccad();
		StyleCollection styles = x8cedcaa9a62c6e39.x2c8c6741422a1298.Styles;
		for (int i = 0; i < styles.Count; i++)
		{
			xaedce5725e456ac5(styles[i]);
		}
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	private void x36da930309c3ccad()
	{
		Document document = x8cedcaa9a62c6e39.x2c8c6741422a1298;
		x90347bcd8deede01 x90347bcd8deede = document.Styles.x90347bcd8deede01;
		x800085dd555f7711.x2307058321cdb62f("w:latentStyles");
		x800085dd555f7711.x943f6be3acf634db("w:defLockedState", x90347bcd8deede.x799a64ee3b4ce806);
		x800085dd555f7711.x943f6be3acf634db("w:latentStyleCount", x90347bcd8deede.x6c7ca9aba118e7af);
		for (int i = 0; i < x90347bcd8deede.x31805fef2aff8b5f.xd44988f225497f3a; i++)
		{
			x565726a756595ed4 x565726a756595ed = x90347bcd8deede.x31805fef2aff8b5f.get_xe6d4b1b411ed94b5(i);
			string xbcea506a33cf = x72a0c846678ecaf9.x27d6a5b617edc9db(x565726a756595ed.x9a4aa9a3455eb440, "");
			if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf) && x565726a756595ed.x2d8aaa05bddcf40c != x90347bcd8deede.x799a64ee3b4ce806)
			{
				x800085dd555f7711.x2307058321cdb62f("w:lsdException");
				x800085dd555f7711.xff520a0047c27122("w:name", xbcea506a33cf);
				x800085dd555f7711.x943f6be3acf634db("w:locked", x565726a756595ed.x2d8aaa05bddcf40c);
				x800085dd555f7711.x2dfde153f4ef96d0();
			}
		}
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	private void xaedce5725e456ac5(Style x44ecfea61c937b8e)
	{
		x800085dd555f7711.x2307058321cdb62f("w:style");
		x800085dd555f7711.xff520a0047c27122("w:type", x0beb84bbfae8adcf.xcf63af15b56f35ef(x44ecfea61c937b8e.Type));
		switch (x44ecfea61c937b8e.StyleIdentifier)
		{
		case StyleIdentifier.Normal:
		case StyleIdentifier.DefaultParagraphFont:
		case StyleIdentifier.TableNormal:
		case StyleIdentifier.NoList:
			x800085dd555f7711.xff520a0047c27122("w:default", "on");
			break;
		}
		x800085dd555f7711.xff520a0047c27122("w:styleId", x8cedcaa9a62c6e39.x7af082eaf8e0caa4(x44ecfea61c937b8e.x8301ab10c226b0c2));
		string text = x72a0c846678ecaf9.x27d6a5b617edc9db(x44ecfea61c937b8e.StyleIdentifier, x44ecfea61c937b8e.Name);
		x800085dd555f7711.x547195bcc386fe66("w:name", text);
		x800085dd555f7711.x547195bcc386fe66("w:aliases", x8cedcaa9a62c6e39.x2c8c6741422a1298.Styles.x4c0f9b9b517a1ec4(x44ecfea61c937b8e, xe9f84f829511a789: false));
		if (x44ecfea61c937b8e.Name != text)
		{
			x800085dd555f7711.x547195bcc386fe66("wx:uiName", x44ecfea61c937b8e.Name);
		}
		x800085dd555f7711.x547195bcc386fe66("w:basedOn", x8cedcaa9a62c6e39.x7af082eaf8e0caa4(x44ecfea61c937b8e.xe709b224f455b863));
		if (x44ecfea61c937b8e.xfb77c9ea054ac31c != x44ecfea61c937b8e.x8301ab10c226b0c2)
		{
			x800085dd555f7711.x547195bcc386fe66("w:next", x8cedcaa9a62c6e39.x7af082eaf8e0caa4(x44ecfea61c937b8e.xfb77c9ea054ac31c));
		}
		x800085dd555f7711.x547195bcc386fe66("w:link", x8cedcaa9a62c6e39.x7af082eaf8e0caa4(x44ecfea61c937b8e.x4cf1854ef833220f));
		x800085dd555f7711.x9601fe92a1b73d3f("w:autoRedefine", x44ecfea61c937b8e.x913ff5916b187824);
		x800085dd555f7711.x9601fe92a1b73d3f("w:hidden", x44ecfea61c937b8e.x96e55b5d052d1279);
		x800085dd555f7711.x9601fe92a1b73d3f("w:semiHidden", x44ecfea61c937b8e.x45101ac87546632f);
		x800085dd555f7711.x9601fe92a1b73d3f("w:locked", x44ecfea61c937b8e.x2d8aaa05bddcf40c);
		x800085dd555f7711.x9601fe92a1b73d3f("w:personal", x44ecfea61c937b8e.xdf3672ec434b4524);
		x800085dd555f7711.x9601fe92a1b73d3f("w:personalCompose", x44ecfea61c937b8e.xde61abbe9514a1ee);
		x800085dd555f7711.x9601fe92a1b73d3f("w:personalReply", x44ecfea61c937b8e.x3bbb21ee843f081c);
		if (x44ecfea61c937b8e.xe12a6bc6d222e782 != 0)
		{
			x800085dd555f7711.x547195bcc386fe66("w:rsid", xc1b08afa36bf580c.x0d28bf60e577f9e5(x44ecfea61c937b8e.xe12a6bc6d222e782));
		}
		if (x44ecfea61c937b8e.Type != StyleType.Character)
		{
			x2aa41ce9e83be7cd.x6210059f049f0d48(x44ecfea61c937b8e.x1a78664fa10a3755, this);
		}
		xc70f986e9535e88a.x064651cf6a5fbfbe(x44ecfea61c937b8e.xeedad81aaed42a76, x44ecfea61c937b8e, this);
		if (x44ecfea61c937b8e.Type == StyleType.Table)
		{
			TableStyle tableStyle = (TableStyle)x44ecfea61c937b8e;
			x31b31073210f038b.x6210059f049f0d48(tableStyle.xedb0eb766e25e0c9, x97b4bbf66b3d8bc6: true, x37f701492043cfc5: true, this);
			x31b31073210f038b.x6210059f049f0d48(tableStyle.x511a581657d77f2b, x97b4bbf66b3d8bc6: false, x37f701492043cfc5: true, this);
			x7142005363c1dbcf.x6210059f049f0d48(tableStyle.xf8cef531dae89ea3, this);
			foreach (xe12ab2f55355c7f0 item in tableStyle.x7205cb42c2f994a4)
			{
				xd03779bae999fc47(item);
			}
		}
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	private void xd03779bae999fc47(xe12ab2f55355c7f0 x29a70965cdc631ed)
	{
		x800085dd555f7711.x2307058321cdb62f("w:tblStylePr");
		x800085dd555f7711.x943f6be3acf634db("w:type", x72a0c846678ecaf9.x1cc48fed2015ead6(x29a70965cdc631ed.x3146d638ec378671));
		x2aa41ce9e83be7cd.x6210059f049f0d48(x29a70965cdc631ed.x1a78664fa10a3755, this);
		xc70f986e9535e88a.x064651cf6a5fbfbe(x29a70965cdc631ed.xeedad81aaed42a76, x29a70965cdc631ed.xeedad81aaed42a76, this);
		x31b31073210f038b.x6210059f049f0d48(x29a70965cdc631ed.xedb0eb766e25e0c9, x97b4bbf66b3d8bc6: true, x37f701492043cfc5: true, this);
		x31b31073210f038b.x6210059f049f0d48(x29a70965cdc631ed.x511a581657d77f2b, x97b4bbf66b3d8bc6: false, x37f701492043cfc5: true, this);
		x7142005363c1dbcf.x6210059f049f0d48(x29a70965cdc631ed.xf8cef531dae89ea3, this);
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	private void x85c378f71aeff1d2(Shape x5770cdefd8931aa9)
	{
		switch (x5770cdefd8931aa9.ShapeType)
		{
		case ShapeType.OleObject:
			x0a2b8d053fe095ea(x5770cdefd8931aa9);
			break;
		case ShapeType.OleControl:
			x5b66beb61f01f410(x5770cdefd8931aa9);
			break;
		}
	}

	private void x0a2b8d053fe095ea(Shape x5770cdefd8931aa9)
	{
		OleFormat oleFormat = x5770cdefd8931aa9.OleFormat;
		x800085dd555f7711.x2307058321cdb62f("o:OLEObject");
		x800085dd555f7711.x943f6be3acf634db("Type", oleFormat.IsLink ? "Link" : "Embed");
		x800085dd555f7711.x943f6be3acf634db("ProgID", oleFormat.ProgId);
		x800085dd555f7711.x943f6be3acf634db("ShapeID", x64893267b789fd52.x6d02c598a7b8fc1f(x5770cdefd8931aa9));
		x800085dd555f7711.x943f6be3acf634db("DrawAspect", oleFormat.OleIcon ? "Icon" : "Content");
		if (oleFormat.IsLink)
		{
			string xbcea506a33cf = ((!x0d299f323d241756.x5959bccb67bbf051(oleFormat.SourceItem)) ? oleFormat.SourceFullName : $"{oleFormat.SourceFullName}!{oleFormat.SourceItem}");
			x800085dd555f7711.x943f6be3acf634db("Moniker", xbcea506a33cf);
			x800085dd555f7711.x943f6be3acf634db("UpdateMode", oleFormat.AutoUpdate ? "Always" : "OnCall");
			x800085dd555f7711.x6b73ce92fd8e3f2c("o:LinkType", xf4107e64edda7fac.x5da6f4d304ca0a6c(oleFormat.x2e7d767f7d782a7a));
			x800085dd555f7711.x9601fe92a1b73d3f("o:LockedField", oleFormat.IsLocked);
			x800085dd555f7711.x6b73ce92fd8e3f2c("o:WordFieldCodes", "\\f " + oleFormat.x577033bbed151076);
		}
		else
		{
			x800085dd555f7711.x943f6be3acf634db("ObjectID", oleFormat.x58932c7e6fa3b905.x85c663cff7276f51);
		}
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	private void x5b66beb61f01f410(Shape x5770cdefd8931aa9)
	{
		x71d39fdf56861cca x71d39fdf56861cca = x5770cdefd8931aa9.OleFormat.x71d39fdf56861cca;
		if (x71d39fdf56861cca == null)
		{
			return;
		}
		xd8c3135513b9115b xd8c3135513b9115b = new xd8c3135513b9115b(x5770cdefd8931aa9.OleFormat.Clsid);
		xe7be411416cfcd54 x6b73aa01aa019d3a = x71d39fdf56861cca.x6b73aa01aa019d3a;
		string x7418697d519d9ddc = new x432b11171adc04ec(x6b73aa01aa019d3a).x7418697d519d9ddc;
		foreach (DictionaryEntry item in x6b73aa01aa019d3a)
		{
			switch ((string)item.Key)
			{
			case "\u0003ObjInfo":
			case "\u0003OCXNAME":
			case "\u0003PRINT":
				continue;
			}
			xd8c3135513b9115b.x29e7ace4c90f74cd.Add(item.Key, item.Value);
		}
		MemoryStream xcf18e5243f8d5fd = new MemoryStream();
		xd8c3135513b9115b.x0acd3c2012ea2ee8(xcf18e5243f8d5fd);
		string xbcea506a33cf = x8cedcaa9a62c6e39.xf70a2b11a9bb19be("22", "mso", xcf18e5243f8d5fd);
		x800085dd555f7711.x2307058321cdb62f("w:ocx");
		x800085dd555f7711.x943f6be3acf634db("w:data", xbcea506a33cf);
		x800085dd555f7711.x943f6be3acf634db("w:id", x7418697d519d9ddc);
		x800085dd555f7711.x943f6be3acf634db("w:name", x7418697d519d9ddc);
		x800085dd555f7711.x943f6be3acf634db("w:classid", "CLSID:" + x6b73aa01aa019d3a.x933ed8cf24f04c67.ToString("D").ToUpper());
		if (!x5770cdefd8931aa9.IsInline)
		{
			x800085dd555f7711.x943f6be3acf634db("w:shapeid", x64893267b789fd52.x67581c842683a852(x5770cdefd8931aa9));
			x800085dd555f7711.x943f6be3acf634db("w:class", "shape");
		}
		x800085dd555f7711.x943f6be3acf634db("w:w", x4574ea26106f0edb.x1f1488a9109eace7(x5770cdefd8931aa9.Width));
		x800085dd555f7711.x943f6be3acf634db("w:h", x4574ea26106f0edb.x1f1488a9109eace7(x5770cdefd8931aa9.Height));
		x800085dd555f7711.x943f6be3acf634db("wx:iPersistPropertyBag", "true");
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	private void x4e44079093b28b81(Shape x5770cdefd8931aa9)
	{
		x4e44079093b28b81(x5770cdefd8931aa9.x8edafc3cf6e5431a, x5770cdefd8931aa9.xffd5ab6c569c488d, x5770cdefd8931aa9.Target, x5770cdefd8931aa9.ScreenTip);
	}

	private void x4e44079093b28b81(string x6b8e154b42d5c1e3, string xa490ad5ef1682691, string x11d58b056c032b03, string x90adc4150b5063b1)
	{
		x800085dd555f7711.x2307058321cdb62f("w:hlink");
		x800085dd555f7711.x943f6be3acf634db("w:dest", x6b8e154b42d5c1e3);
		x800085dd555f7711.x943f6be3acf634db("w:bookmark", xa490ad5ef1682691);
		x800085dd555f7711.x943f6be3acf634db("w:target", x11d58b056c032b03);
		x800085dd555f7711.x943f6be3acf634db("w:screenTip", x90adc4150b5063b1);
	}

	private void x1210e8a0b401d5a2()
	{
		x800085dd555f7711.x2dfde153f4ef96d0("w:hlink");
	}

	private void xfb78915a60b77e4b(FieldChar x2223f7db33837fbd)
	{
		x7578ebaf879d79c6(x2223f7db33837fbd.xeedad81aaed42a76);
		x5a7a1d229173bf5d.x32c9a0cbee7be23c(x2223f7db33837fbd.xeedad81aaed42a76, x2223f7db33837fbd, x8f19af4759cf8cd4: false);
		string text;
		switch (x2223f7db33837fbd.NodeType)
		{
		case NodeType.FieldStart:
			text = "begin";
			x215f4deb55f3496c.Push(text);
			x4825cc64be84ad61++;
			break;
		case NodeType.FieldSeparator:
			text = "separate";
			x215f4deb55f3496c.Pop();
			x215f4deb55f3496c.Push(text);
			x4825cc64be84ad61--;
			break;
		case NodeType.FieldEnd:
			text = "end";
			if ((string)x215f4deb55f3496c.Pop() == "begin")
			{
				x4825cc64be84ad61--;
			}
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("pomkpaeliallmacmbajmklpmlpgnjpnnnpeohploipcpbpjpjpaahohabpoamjfbonmboodcdokcfnbdanidonpdmmgeimnepief", 1339206825)));
		}
		x5a7a1d229173bf5d.x4a86e66e43e7143c = x4825cc64be84ad61 != 0;
		x800085dd555f7711.x4122f10182ac673a("w:fldChar", "w:fldCharType", text);
		if (x2223f7db33837fbd.NodeType == NodeType.FieldStart)
		{
			x800085dd555f7711.x0ea3ef8dd3ae2f3f("w:dirty", x2223f7db33837fbd.x6e94079169d5a06e);
			x800085dd555f7711.x0ea3ef8dd3ae2f3f("w:fldLock", x2223f7db33837fbd.IsLocked);
		}
		x62fa90f4824c7797(x2223f7db33837fbd);
		x800085dd555f7711.x2dfde153f4ef96d0();
		x5a7a1d229173bf5d.xf0de1bdc2a5440b2();
		x7b1f332749aba8fe(x2223f7db33837fbd.xeedad81aaed42a76);
	}

	private void x62fa90f4824c7797(FieldChar x2223f7db33837fbd)
	{
		if (x2223f7db33837fbd.NodeType == NodeType.FieldStart && x5c29822913be33c1.x7f8b7c1c90735bcf(x2223f7db33837fbd.FieldType))
		{
			FormField formField = (FormField)x2223f7db33837fbd.x03a9a1b8afdf52f9(NodeType.FormField);
			if (formField != null && formField.xd1b40af56a8385d4 != null)
			{
				x800085dd555f7711.x2307058321cdb62f("w:fldData");
				MemoryStream xcf18e5243f8d5fd = xf2b9ab75a7571713.xef5c5351bf6fb1a9(formField);
				x800085dd555f7711.xe24c4103102bcb90(xcf18e5243f8d5fd);
				x800085dd555f7711.x2dfde153f4ef96d0();
			}
		}
	}

	private void x73eee79ab9d615d9(ShapeBase x5770cdefd8931aa9)
	{
		x5a7a1d229173bf5d.x32c9a0cbee7be23c(x5770cdefd8931aa9.xeedad81aaed42a76, x5770cdefd8931aa9, x8f19af4759cf8cd4: false);
		x800085dd555f7711.x2307058321cdb62f("w:pict");
	}

	private void x4907259ee48e3d89()
	{
		x800085dd555f7711.x2dfde153f4ef96d0();
		x5a7a1d229173bf5d.xf0de1bdc2a5440b2();
	}

	private void xfb80633b3fcbe371(Paragraph x41baca1d6c0c2e8e)
	{
		x1a78664fa10a3755 x1a78664fa10a = x41baca1d6c0c2e8e.x1a78664fa10a3755;
		if (x41baca1d6c0c2e8e.xbc0119d7471ef12e && !x41baca1d6c0c2e8e.ListFormat.ListLevel.x44b52529222cea8a)
		{
			x89f64afc54e173ca = x09d499c483428bd1.xa8b9c2cfa706a303(x41baca1d6c0c2e8e.ListLabel.LabelString);
			x37712e332591d891 = x41baca1d6c0c2e8e.ListLabel.Font.Name;
		}
		bool flag = x2aa41ce9e83be7cd.xd29409f2ba9889e2(x1a78664fa10a, this);
		x89f64afc54e173ca = null;
		x37712e332591d891 = null;
		bool flag2 = xc70f986e9535e88a.xcb4a900bb4787522(x41baca1d6c0c2e8e.x344511c4e4ce09da, x41baca1d6c0c2e8e, !flag, this);
		flag = flag || flag2;
		if (x41baca1d6c0c2e8e == x92add8e2556c5954 && !xb823e70c83bd8abd.x16479f42fe4547f2)
		{
			if (!flag)
			{
				x800085dd555f7711.x2307058321cdb62f("w:pPr");
				flag = true;
			}
			xce7f0abd6b3cc3be.x6210059f049f0d48(xb823e70c83bd8abd, this);
		}
		if (flag)
		{
			x800085dd555f7711.x2dfde153f4ef96d0("w:pPr");
		}
	}

	private void x7578ebaf879d79c6(xeedad81aaed42a76 x789564759d365819)
	{
		if (x789564759d365819.xba4e1d8a3e3316c8)
		{
			x800085dd555f7711.xd0c5f01ab55153ce(x789564759d365819.x18bb4aa7903ffced, x28ee4b8b8f777b55());
		}
		if (x789564759d365819.x0392c0938d22c790)
		{
			x800085dd555f7711.xd0c5f01ab55153ce(x789564759d365819.x83da691dd3d974a6, x28ee4b8b8f777b55());
		}
	}

	private void x7b1f332749aba8fe(xeedad81aaed42a76 x789564759d365819)
	{
		if (x789564759d365819.xba4e1d8a3e3316c8)
		{
			x800085dd555f7711.x44d8d13f25d44840();
		}
		if (x789564759d365819.x0392c0938d22c790)
		{
			x800085dd555f7711.x44d8d13f25d44840();
		}
	}

	private static bool xc2f8d84d0cae2fc2(Shape x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.IsInline && x5770cdefd8931aa9.xa8228c6215bc2643)
		{
			return x5770cdefd8931aa9.OleFormat.x71d39fdf56861cca != null;
		}
		return false;
	}

	private string xcd2d2daf84fe7002(int xddd12ddd8b1e4a90)
	{
		return x8cedcaa9a62c6e39.x7af082eaf8e0caa4(xddd12ddd8b1e4a90);
	}

	string xfe11bbc13ba649c3.x7af082eaf8e0caa4(int xddd12ddd8b1e4a90)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xcd2d2daf84fe7002
		return this.xcd2d2daf84fe7002(xddd12ddd8b1e4a90);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public int x28ee4b8b8f777b55()
	{
		return x18730ec3a68983e6++;
	}

	private void xe18bf0a40e44bd2d(HeaderFooter x03e7e66b1eecc96f)
	{
		if (x03e7e66b1eecc96f.ParentSection.x59fc5ceeaaccb880 || !x03e7e66b1eecc96f.IsLinkedToPrevious)
		{
			x800085dd555f7711.x2307058321cdb62f(x03e7e66b1eecc96f.IsHeader ? "w:hdr" : "w:ftr");
			x800085dd555f7711.x943f6be3acf634db("w:type", x93625b0e8808b0cc.x9705b85b99f335f9(x03e7e66b1eecc96f.HeaderFooterType, x5fbb1a9c98604ef5: false));
			x03e7e66b1eecc96f.Accept(this);
			x800085dd555f7711.x2dfde153f4ef96d0();
		}
	}

	void xfe11bbc13ba649c3.x6075c9125351e131(HeaderFooter x03e7e66b1eecc96f)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xe18bf0a40e44bd2d
		this.xe18bf0a40e44bd2d(x03e7e66b1eecc96f);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void xf65c32ef4443c2c5(x4c1e058c67948d6a x873e775b892867cf, bool x28ee2f81ab05fedb)
	{
		if (x8cedcaa9a62c6e39.x8556eed81191af11.xd72e197c9500653f)
		{
			x3fd582703472b510.xf65c32ef4443c2c5(this, FootnoteType.Footnote, x873e775b892867cf, x28ee2f81ab05fedb);
		}
		if (x8cedcaa9a62c6e39.x8556eed81191af11.x427aee4dfcc89c31)
		{
			x3fd582703472b510.xf65c32ef4443c2c5(this, FootnoteType.Endnote, x873e775b892867cf, x28ee2f81ab05fedb);
		}
	}
}
