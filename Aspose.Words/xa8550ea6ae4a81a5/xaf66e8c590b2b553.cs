using System;
using System.Collections;
using System.ComponentModel;
using System.Text;
using Aspose;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using Aspose.Words.Markup;
using Aspose.Words.Math;
using Aspose.Words.Saving;
using Aspose.Words.Tables;
using x011d489fb9df7027;
using x13f1efc79617a47b;
using x1a3e96f4b89a7a77;
using x28925c9b27b37a46;
using x38a89dee67fc7a16;
using x5af3f327d745698a;
using x6c95d9cf46ff5f25;
using x7c7a1dceb600404e;
using x7e88666148babfd9;
using x909757d9fd2dd6ae;
using xb92b7270f78a4e8d;
using xda075892eccab2ad;
using xf9a9481c3f63a419;
using xfbd1009a0cbb9842;
using xfc5388ad7dff404f;

namespace xa8550ea6ae4a81a5;

internal abstract class xaf66e8c590b2b553 : DocumentVisitor, xfe11bbc13ba649c3, x2cd1f1f5e07462a8
{
	private const string x46f27e62b26d1d5e = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?><ax:ocx ax:classid=\"{{{0}}}\" ax:persistence=\"persistStorage\" r:id=\"rId1\" xmlns:ax=\"{1}\" xmlns:r=\"{2}\"/>";

	private readonly xe41cdb7a2a4611b4 x9b287b671d592594;

	private readonly DocumentBase x232be220f517f721;

	private readonly xbb6564a24d4c901a xbc33695753285351;

	private readonly x1d7762bff701525f x5a7a1d229173bf5d;

	private readonly Stack x215f4deb55f3496c = new Stack();

	private int x4825cc64be84ad61;

	private readonly IDictionary xbc4ea30fdf3f31af = xd51c34d05311eee3.xdb04a310bbb29cff();

	private readonly Hashtable x80707bc8b89a10df = new Hashtable();

	private readonly Stack x4bd2c30f9472d1cc = new Stack();

	private x8f3af96aa56f1e32 x800085dd555f7711;

	private xa2f1c3dcbd86f20a x336788c6a46ed27b;

	private x3d98b6688a363c8e xddfb1cb8c552ced1;

	private x1a295dcf467c0c9e x3bae55a357c42cd0;

	private x1a295dcf467c0c9e xeed27dc46b88b3ea;

	private int x18730ec3a68983e6;

	private Paragraph x92add8e2556c5954;

	private Section xb823e70c83bd8abd;

	private bool xf486629d2973656f;

	private int xccbb5683ddcbe0f8;

	private int xb3456a9ba4cb7a7b;

	private Hashtable xbd1cf65dfdae0e0b;

	private bool xb2afb418e467f0b0;

	private IWarningCallback xa056586c1f99e199;

	string x2cd1f1f5e07462a8.x85831763783af2f1 => "r:id";

	string x2cd1f1f5e07462a8.xb156cbeee0ea5277 => "r:href";

	ArrayList x2cd1f1f5e07462a8.xe3a0505c2452b0b0 => x800085dd555f7711.xa5a04b025492f124;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public x8556eed81191af11 x8556eed81191af11 => x9b287b671d592594.x8556eed81191af11;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public x873451caae5ad4ae xe1410f585439c7d4 => x800085dd555f7711;

	public bool x325f1926b78ae5cd => true;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public DocumentBase x2c8c6741422a1298 => x232be220f517f721;

	internal x8f3af96aa56f1e32 xca93abf9292cd4f1 => x800085dd555f7711;

	internal xa2f1c3dcbd86f20a x2a0bb2f6650f6a43 => x336788c6a46ed27b;

	internal bool x4a86e66e43e7143c
	{
		get
		{
			return xf486629d2973656f;
		}
		set
		{
			xf486629d2973656f = value;
		}
	}

	internal Section x875353c6f45c336d
	{
		get
		{
			return xb823e70c83bd8abd;
		}
		set
		{
			xb823e70c83bd8abd = value;
		}
	}

	internal xada461b17cdccac0 x39c7aeeec1af9dd0 => x9b287b671d592594.x39c7aeeec1af9dd0;

	internal OoxmlSaveOptions xf57de0fd37d5e97d => (OoxmlSaveOptions)x8556eed81191af11.xf57de0fd37d5e97d;

	internal OoxmlCompliance x0b744c5c26c5b3b3 => xf57de0fd37d5e97d.Compliance;

	protected xe41cdb7a2a4611b4 x5aa326f374b3d0ef => x9b287b671d592594;

	protected xaf66e8c590b2b553(xe41cdb7a2a4611b4 writer, DocumentBase doc, IWarningCallback warningCallback)
	{
		x9b287b671d592594 = writer;
		x232be220f517f721 = doc;
		xbc33695753285351 = new xbb6564a24d4c901a(x232be220f517f721.Styles);
		x5a7a1d229173bf5d = new x1d7762bff701525f(this);
		xa056586c1f99e199 = warningCallback;
	}

	internal void x6210059f049f0d48()
	{
		x336788c6a46ed27b = DoCreateDocumentPart();
		if (x8556eed81191af11.xd72e197c9500653f)
		{
			x3bae55a357c42cd0 = new x1a295dcf467c0c9e(FootnoteType.Footnote, this);
		}
		if (x8556eed81191af11.x427aee4dfcc89c31)
		{
			xeed27dc46b88b3ea = new x1a295dcf467c0c9e(FootnoteType.Endnote, this);
		}
		xef6e2bd6ea405b49.x6210059f049f0d48(this);
		x0da3ac431d3807fa.x6210059f049f0d48(this);
		xd2f1980a90556fcc.x6210059f049f0d48(this);
		xefc309b2831366cb(new x8f3af96aa56f1e32(x336788c6a46ed27b, xf57de0fd37d5e97d.PrettyFormat, x0b744c5c26c5b3b3));
		DoWrite();
		x952d29d37196da54.x6210059f049f0d48(this);
		x886e0a4fa166f53d.x6210059f049f0d48(this);
		if (xddfb1cb8c552ced1 != null)
		{
			xddfb1cb8c552ced1.x8ffe90e7fbccfccd();
		}
		if (x3bae55a357c42cd0 != null)
		{
			x3bae55a357c42cd0.x8ffe90e7fbccfccd();
		}
		if (xeed27dc46b88b3ea != null)
		{
			xeed27dc46b88b3ea.x8ffe90e7fbccfccd();
		}
		xa493f0b03338ab7a();
	}

	[JavaThrows(true)]
	protected abstract xa2f1c3dcbd86f20a DoCreateDocumentPart();

	[JavaThrows(true)]
	protected abstract void DoWrite();

	protected void x427772a8a25f1c7a(CompositeNode x06f7565413a01240)
	{
		for (Node node = x06f7565413a01240.FirstChild; node != null; node = node.NextSibling)
		{
			x875353c6f45c336d = (Section)node;
			x92add8e2556c5954 = x875353c6f45c336d.Body.LastParagraph;
			x875353c6f45c336d.Body.Accept(this);
		}
	}

	public void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(x9f91de645a9fe01a, WarningSource.WordML, xc2358fbac7da3d45));
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitTableStart(Table table)
	{
		x800085dd555f7711.x2307058321cdb62f("w:tbl");
		x31b31073210f038b.x6210059f049f0d48(table.FirstRow.xedb0eb766e25e0c9, x97b4bbf66b3d8bc6: true, x37f701492043cfc5: false, this, x0b744c5c26c5b3b3);
		x88fc04b3ff226822.x37ae3bbd6d2584f4(table);
		x88fc04b3ff226822.xd71f0ca619f1aa02(x800085dd555f7711, table);
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitTableEnd(Table table)
	{
		x800085dd555f7711.x2dfde153f4ef96d0("w:tbl");
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitRowStart(Row row)
	{
		x800085dd555f7711.x2307058321cdb62f("w:tr");
		x31b31073210f038b.x6210059f049f0d48(row.xedb0eb766e25e0c9, x97b4bbf66b3d8bc6: false, x37f701492043cfc5: false, this);
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitRowEnd(Row row)
	{
		x800085dd555f7711.x2dfde153f4ef96d0("w:tr");
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitCellStart(Cell cell)
	{
		x800085dd555f7711.x2307058321cdb62f("w:tc");
		x7142005363c1dbcf.x6210059f049f0d48(cell.xf8cef531dae89ea3, this);
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitCellEnd(Cell cell)
	{
		x800085dd555f7711.x2dfde153f4ef96d0("w:tc");
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitParagraphStart(Paragraph para)
	{
		x800085dd555f7711.x2307058321cdb62f("w:p");
		x800085dd555f7711.xb673df6aa8c79149 = xc1b08afa36bf580c.x0d28bf60e577f9e5(para.x344511c4e4ce09da.xf7866f89640a29a3(40));
		x800085dd555f7711.x943f6be3acf634db("w:rsidR", x800085dd555f7711.xb673df6aa8c79149);
		x800085dd555f7711.x943f6be3acf634db("w:rsidRPr", xc1b08afa36bf580c.x0d28bf60e577f9e5(para.x344511c4e4ce09da.xf7866f89640a29a3(30)));
		x800085dd555f7711.x943f6be3acf634db("w:rsidP", xc1b08afa36bf580c.x0d28bf60e577f9e5(para.x1a78664fa10a3755.xf7866f89640a29a3(1580)));
		xfb80633b3fcbe371(para);
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitParagraphEnd(Paragraph para)
	{
		x800085dd555f7711.x2dfde153f4ef96d0("w:p");
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitSmartTagStart(SmartTag smartTag)
	{
		x393a4ff0932c3ba7.xd29409f2ba9889e2(smartTag, x800085dd555f7711);
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitSmartTagEnd(SmartTag smartTag)
	{
		x393a4ff0932c3ba7.x685b1e5a342b26d7(smartTag, x800085dd555f7711);
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitStructuredDocumentTagStart(StructuredDocumentTag sdt)
	{
		xd81d2ff82d2388fb.xd29409f2ba9889e2(sdt, this);
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitStructuredDocumentTagEnd(StructuredDocumentTag sdt)
	{
		xd81d2ff82d2388fb.x685b1e5a342b26d7(x800085dd555f7711);
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitCustomXmlMarkupStart(CustomXmlMarkup customXmlMarkup)
	{
		x09cb3f74e33cfdfa.xd29409f2ba9889e2(customXmlMarkup, x800085dd555f7711);
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitCustomXmlMarkupEnd(CustomXmlMarkup customXmlMarkup)
	{
		x09cb3f74e33cfdfa.x685b1e5a342b26d7(x800085dd555f7711);
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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitRun(Run run)
	{
		x5a7a1d229173bf5d.x16474cfd0fac275f(run);
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitSpecialChar(SpecialChar specialChar)
	{
		x5a7a1d229173bf5d.x16474cfd0fac275f(specialChar);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitAbsolutePositionTab(AbsolutePositionTab tab)
	{
		x800085dd555f7711.x2307058321cdb62f("w:r");
		x800085dd555f7711.x2307058321cdb62f("w:ptab");
		x800085dd555f7711.x943f6be3acf634db("w:relativeTo", xc62574be95c1c918.x4abd682bab5e3bd1(tab.x7073c129de8d5e65));
		x800085dd555f7711.x943f6be3acf634db("w:alignment", xc62574be95c1c918.xce59b63420cae7bb(tab.x9ba359ff37a3a63b));
		x800085dd555f7711.x943f6be3acf634db("w:leader", xc62574be95c1c918.x2f778a9929d07da5(tab.x312ff11290b951a5));
		x800085dd555f7711.x2dfde153f4ef96d0("w:ptab");
		x800085dd555f7711.x2dfde153f4ef96d0("w:r");
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitFieldStart(FieldStart fieldStart)
	{
		xfb78915a60b77e4b(fieldStart);
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitFieldSeparator(FieldSeparator fieldSeparator)
	{
		xfb78915a60b77e4b(fieldSeparator);
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitFieldEnd(FieldEnd fieldEnd)
	{
		xfb78915a60b77e4b(fieldEnd);
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitBookmarkStart(BookmarkStart bookmarkStart)
	{
		int num = x28ee4b8b8f777b55();
		xbc4ea30fdf3f31af.Add(bookmarkStart.Name, num);
		x800085dd555f7711.x2307058321cdb62f("w:bookmarkStart");
		x800085dd555f7711.x943f6be3acf634db("w:id", num);
		x800085dd555f7711.xff520a0047c27122("w:name", bookmarkStart.Name);
		if (bookmarkStart.xf1b59c88b25f8eec)
		{
			x800085dd555f7711.x943f6be3acf634db("w:colFirst", bookmarkStart.xb78c16d5f2d4f2f7);
			x800085dd555f7711.x943f6be3acf634db("w:colLast", bookmarkStart.x279da4adfba57f2d - 1);
		}
		x800085dd555f7711.x2dfde153f4ef96d0("w:bookmarkStart");
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitBookmarkEnd(BookmarkEnd bookmarkEnd)
	{
		x800085dd555f7711.x2307058321cdb62f("w:bookmarkEnd");
		x800085dd555f7711.x943f6be3acf634db("w:id", (int)xbc4ea30fdf3f31af[bookmarkEnd.Name]);
		x800085dd555f7711.x2dfde153f4ef96d0("w:bookmarkEnd");
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitCommentStart(Comment comment)
	{
		int num = x9bb95fbbb3ee055a(comment.Id);
		x5a7a1d229173bf5d.x32c9a0cbee7be23c(comment.xeedad81aaed42a76, comment.xeedad81aaed42a76, x566ab42519f5da4a: true);
		x35c80635ff7a735b("w:commentReference", num);
		x5a7a1d229173bf5d.xf0de1bdc2a5440b2(comment.xeedad81aaed42a76);
		if (xddfb1cb8c552ced1 == null)
		{
			xddfb1cb8c552ced1 = new x3d98b6688a363c8e(this);
		}
		xddfb1cb8c552ced1.xd29409f2ba9889e2(comment, num);
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitCommentEnd(Comment comment)
	{
		xddfb1cb8c552ced1.x685b1e5a342b26d7();
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitCommentRangeStart(CommentRangeStart commentRangeStart)
	{
		x35c80635ff7a735b("w:commentRangeStart", x9bb95fbbb3ee055a(commentRangeStart.Id));
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitCommentRangeEnd(CommentRangeEnd commentRangeEnd)
	{
		x35c80635ff7a735b("w:commentRangeEnd", x9bb95fbbb3ee055a(commentRangeEnd.Id));
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitSubDocument(SubDocument subDocument)
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = x39c7aeeec1af9dd0.x4bfdbcbc6a51d705(null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument");
		string xc06e652f250a = xa2f1c3dcbd86f20a.xadb7000bed559a9a.xd6b6ed77479ef68c("http://schemas.openxmlformats.org/officeDocument/2006/relationships/subDocument", x0d4d45882065c63e.x8644581dcf469731(subDocument.xa39af5a82860a9a3), x1bc1cc5e4fd586bf: true);
		x800085dd555f7711.x942df950ff3fdafd("w:subDoc", xc06e652f250a);
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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitFootnoteStart(Footnote footnote)
	{
		x5a7a1d229173bf5d.x32c9a0cbee7be23c(footnote.xeedad81aaed42a76, footnote.xeedad81aaed42a76, x566ab42519f5da4a: false);
		switch (footnote.FootnoteType)
		{
		case FootnoteType.Footnote:
			x5a7a1d229173bf5d.xd7b3f218029cb4b8 = FootnoteType.Footnote;
			x3bae55a357c42cd0.x1b12ad7e0ad0df34(x101cddc73c4f8cc2.xe9e531d1a6725226);
			break;
		case FootnoteType.Endnote:
			x5a7a1d229173bf5d.xd7b3f218029cb4b8 = FootnoteType.Endnote;
			xeed27dc46b88b3ea.x1b12ad7e0ad0df34(x101cddc73c4f8cc2.xe9e531d1a6725226);
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cameibdfcbkfcbbgabigfbpgjaghilmhlpdibaliopbjaajjhppjfpgkhpnkfoelnjlloocmapjmeoangnhnmjon", 197020589)));
		}
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitFootnoteEnd(Footnote footnote)
	{
		x1a295dcf467c0c9e x1a295dcf467c0c9e2;
		string x121383aa;
		switch (footnote.FootnoteType)
		{
		case FootnoteType.Footnote:
			x1a295dcf467c0c9e2 = x3bae55a357c42cd0;
			x121383aa = "w:footnoteReference";
			break;
		case FootnoteType.Endnote:
			x1a295dcf467c0c9e2 = xeed27dc46b88b3ea;
			x121383aa = "w:endnoteReference";
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hkelnlllhlcmhljmflanklhnokonnffoakmogkdpdkkpfkbamjiakjpamjgbkinbceecdjlcfjcdjijdlhaebehe", 68990034)));
		}
		int xbcea506a33cf = x1a295dcf467c0c9e2.x29a51827c03d354b();
		x800085dd555f7711.x2307058321cdb62f(x121383aa);
		x800085dd555f7711.x0ea3ef8dd3ae2f3f("w:customMarkFollows", !footnote.xa72bf798a679c0aa);
		x800085dd555f7711.x943f6be3acf634db("w:id", xbcea506a33cf);
		x800085dd555f7711.x2dfde153f4ef96d0(x121383aa);
		if (!footnote.xa72bf798a679c0aa)
		{
			x5294c7c09585b7b2(x800085dd555f7711, footnote);
		}
		x5a7a1d229173bf5d.xf0de1bdc2a5440b2(footnote.xeedad81aaed42a76);
		return VisitorAction.Continue;
	}

	internal static void x5294c7c09585b7b2(x873451caae5ad4ae xd07ce4b74c5774a7, Footnote x897ec71a9f9588a0)
	{
		bool flag = false;
		if (x897ec71a9f9588a0.x715a8c5c33fdc1a6.Length == 1)
		{
			char c = x897ec71a9f9588a0.x715a8c5c33fdc1a6[0];
			if (c == '\v')
			{
				flag = true;
				xd07ce4b74c5774a7.x6b73ce92fd8e3f2c("w:br", x897ec71a9f9588a0.x715a8c5c33fdc1a6);
			}
			else if (xebb9db61691ea142.x1adf194ca8126a4d(c))
			{
				flag = true;
				xd07ce4b74c5774a7.xc049ea80ee267201("w:sym", "w:font", x897ec71a9f9588a0.xeedad81aaed42a76.x51cf23ce6e71b84c, "w:char", xca004f56614e2431.x7c1a0f9da8274fe8(c));
			}
		}
		if (!flag)
		{
			xd07ce4b74c5774a7.x6b73ce92fd8e3f2c("w:t", x897ec71a9f9588a0.x715a8c5c33fdc1a6);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitGroupShapeStart(GroupShape groupShape)
	{
		if (groupShape.IsTopLevel)
		{
			x73eee79ab9d615d9(groupShape);
		}
		xa25dec8c824ea182.x6210059f049f0d48(groupShape, x800085dd555f7711, this);
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitGroupShapeEnd(GroupShape groupShape)
	{
		xa25dec8c824ea182.xe9c9c7110892d4dc(groupShape, x800085dd555f7711);
		x800085dd555f7711.x2dfde153f4ef96d0("v:group");
		if (groupShape.IsTopLevel)
		{
			x4907259ee48e3d89(groupShape);
		}
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitShapeStart(Shape shape)
	{
		if (shape.xe415f17cf389e946)
		{
			x4e44079093b28b81(shape);
		}
		if (shape.IsTopLevel)
		{
			x73eee79ab9d615d9(shape);
		}
		xa25dec8c824ea182.x6210059f049f0d48(shape, x800085dd555f7711, this);
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitShapeEnd(Shape shape)
	{
		if (shape.HasChildNodes)
		{
			x800085dd555f7711.x2dfde153f4ef96d0("w:txbxContent");
			x800085dd555f7711.x2dfde153f4ef96d0("v:textbox");
		}
		xa25dec8c824ea182.xe9c9c7110892d4dc(shape, x800085dd555f7711);
		x800085dd555f7711.x2dfde153f4ef96d0();
		if (shape.xa170cce2bc40bdf5)
		{
			x85c378f71aeff1d2(shape);
		}
		if (shape.IsTopLevel)
		{
			x4907259ee48e3d89(shape);
		}
		if (shape.xe415f17cf389e946)
		{
			x1210e8a0b401d5a2();
		}
		return VisitorAction.Continue;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override VisitorAction VisitDrawingML(DrawingML drawingML)
	{
		x5a7a1d229173bf5d.x32c9a0cbee7be23c(drawingML.xeedad81aaed42a76, drawingML, x566ab42519f5da4a: true);
		if (drawingML.xeedad81aaed42a76.xd3deb252d4974658 != null)
		{
			x21d08cdb41374117(drawingML);
		}
		else
		{
			x2178cf07e2831ea7(drawingML);
		}
		x5a7a1d229173bf5d.xf0de1bdc2a5440b2(drawingML.xeedad81aaed42a76);
		return VisitorAction.Continue;
	}

	private void x21d08cdb41374117(DrawingML xb3c5925d90ebc5f0)
	{
		x800085dd555f7711.x2307058321cdb62f("mc:AlternateContent");
		x800085dd555f7711.x2307058321cdb62f("mc:Choice");
		x800085dd555f7711.x943f6be3acf634db("Requires", xb3c5925d90ebc5f0.xeedad81aaed42a76.xd3deb252d4974658.x410f604cf61abebe);
		x2178cf07e2831ea7(xb3c5925d90ebc5f0);
		x800085dd555f7711.x2dfde153f4ef96d0();
		x800085dd555f7711.x2307058321cdb62f("mc:Fallback");
		xb2afb418e467f0b0 = true;
		foreach (Node childNode in xb3c5925d90ebc5f0.xeedad81aaed42a76.xd3deb252d4974658.x852c08d9d47ed9db.ChildNodes)
		{
			childNode.Accept(this);
		}
		xb2afb418e467f0b0 = false;
		x800085dd555f7711.x2dfde153f4ef96d0();
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	private void x2178cf07e2831ea7(DrawingML xb3c5925d90ebc5f0)
	{
		x0a31990bebe3c214 x0a31990bebe3c = new x0a31990bebe3c214();
		x0a31990bebe3c.x6210059f049f0d48(xb3c5925d90ebc5f0, this);
	}

	private void x4262f5a1b4914602(CompositeNode x7d2f5467131bf6a7)
	{
		xb2afb418e467f0b0 = true;
		foreach (Node childNode in x7d2f5467131bf6a7.ChildNodes)
		{
			childNode.Accept(this);
		}
		xb2afb418e467f0b0 = false;
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
			string x7a6cd6daf4195b8a = ((!x0d299f323d241756.x5959bccb67bbf051(oleFormat.SourceItem)) ? oleFormat.SourceFullName : $"{oleFormat.SourceFullName}!{oleFormat.SourceItem}");
			string xbcea506a33cf = x800085dd555f7711.x398b3bd0acd94b61.xadb7000bed559a9a.xd6b6ed77479ef68c("http://schemas.openxmlformats.org/officeDocument/2006/relationships/oleObject", x7a6cd6daf4195b8a, x1bc1cc5e4fd586bf: true);
			x800085dd555f7711.x943f6be3acf634db("r:id", xbcea506a33cf);
			x800085dd555f7711.x943f6be3acf634db("UpdateMode", oleFormat.AutoUpdate ? "Always" : "OnCall");
			x800085dd555f7711.x6b73ce92fd8e3f2c("o:LinkType", xf4107e64edda7fac.x5da6f4d304ca0a6c(oleFormat.x2e7d767f7d782a7a));
			x800085dd555f7711.x9601fe92a1b73d3f("o:LockedField", oleFormat.IsLocked);
			x800085dd555f7711.x6b73ce92fd8e3f2c("o:FieldCodes", "\\f " + oleFormat.x577033bbed151076);
		}
		else
		{
			x800085dd555f7711.x943f6be3acf634db("ObjectID", oleFormat.x58932c7e6fa3b905.x85c663cff7276f51);
			if (oleFormat.x71d39fdf56861cca != null)
			{
				x2a13c70402fceb31(oleFormat);
			}
			else if (oleFormat.xb7e718098524b76c != null)
			{
				x48298508afb9c39f(oleFormat);
			}
		}
		x800085dd555f7711.x2dfde153f4ef96d0("o:OLEObject");
	}

	private void x2a13c70402fceb31(OleFormat x7b7c85f74f22d093)
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xc694420246c3a6d4(x7b7c85f74f22d093, "oleObject", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/oleObject");
		xd8c3135513b9115b xd8c3135513b9115b = new xd8c3135513b9115b(x7b7c85f74f22d093.x71d39fdf56861cca.x6b73aa01aa019d3a);
		xd8c3135513b9115b.x0acd3c2012ea2ee8(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe);
	}

	private void x48298508afb9c39f(OleFormat x7b7c85f74f22d093)
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xc694420246c3a6d4(x7b7c85f74f22d093, "ooxmlPackage", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/package");
		xa2f1c3dcbd86f20a.xb8a774e0111d0fbe = x7b7c85f74f22d093.xb7e718098524b76c.xb8a774e0111d0fbe;
		xa2f1c3dcbd86f20a.xb8a774e0111d0fbe.Position = 0L;
	}

	private xa2f1c3dcbd86f20a xc694420246c3a6d4(OleFormat x7b7c85f74f22d093, string x98bcc359cd835fcf, string x061610664b4c984f)
	{
		string xe1d3286d17e44a = x7b7c85f74f22d093.x58932c7e6fa3b905.x1dcf998e2740773a(x7b7c85f74f22d093.ProgId);
		string x95fb8866691eb6f = $"/word/embeddings/{x98bcc359cd835fcf}{x15789b8c2554f92e(x061610664b4c984f)}{xc62574be95c1c918.x7cfd9d683a359925(xe1d3286d17e44a)}";
		string xc06e652f250a;
		xa2f1c3dcbd86f20a result = x39c7aeeec1af9dd0.x42c5f80e2ed823ff(x800085dd555f7711.x398b3bd0acd94b61, x95fb8866691eb6f, xe1d3286d17e44a, x061610664b4c984f, out xc06e652f250a);
		x800085dd555f7711.x943f6be3acf634db("r:id", xc06e652f250a);
		return result;
	}

	private void x5b66beb61f01f410(Shape x5770cdefd8931aa9)
	{
		x800085dd555f7711.x2307058321cdb62f("w:control");
		int num = x15789b8c2554f92e("http://schemas.openxmlformats.org/officeDocument/2006/relationships/control");
		string xc06e652f250a;
		xa2f1c3dcbd86f20a xb6f33aded088c = x39c7aeeec1af9dd0.x42c5f80e2ed823ff(x800085dd555f7711.x398b3bd0acd94b61, $"/word/activeX/activeX{num}.xml", "application/vnd.ms-office.activeX+xml", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/control", out xc06e652f250a);
		string xbcea506a33cf = (x5770cdefd8931aa9.x2e3d2d1def6f4dad ? x8629d5694b1c94da(x5770cdefd8931aa9, xb6f33aded088c) : x38c2a63df0ea661e(x5770cdefd8931aa9, xb6f33aded088c, num));
		x800085dd555f7711.x943f6be3acf634db("r:id", xc06e652f250a);
		x800085dd555f7711.xff520a0047c27122("w:name", xbcea506a33cf);
		x800085dd555f7711.xff520a0047c27122("w:shapeid", x64893267b789fd52.x67581c842683a852(x5770cdefd8931aa9));
		x800085dd555f7711.x2dfde153f4ef96d0("w:control");
	}

	private static string x8629d5694b1c94da(Shape x5770cdefd8931aa9, xa2f1c3dcbd86f20a xb6f33aded088c276)
	{
		xb7e718098524b76c xb7e718098524b76c = x5770cdefd8931aa9.OleFormat.xb7e718098524b76c;
		xb7e718098524b76c.xb8a774e0111d0fbe.Position = 0L;
		x0d299f323d241756.x3ad8e53785c39acd(xb7e718098524b76c.xb8a774e0111d0fbe, xb6f33aded088c276.xb8a774e0111d0fbe);
		return xb7e718098524b76c.x759aa16c2016a289;
	}

	private string x38c2a63df0ea661e(Shape x5770cdefd8931aa9, xa2f1c3dcbd86f20a xb6f33aded088c276, int x9a75fb99b59c6e6e)
	{
		xd8c3135513b9115b xd8c3135513b9115b = new xd8c3135513b9115b(x5770cdefd8931aa9.OleFormat.x71d39fdf56861cca.x6b73aa01aa019d3a);
		xb6f33aded088c276.xadb7000bed559a9a.xd6b6ed77479ef68c("rId1", "http://schemas.microsoft.com/office/2006/relationships/activeXControlBinary", $"activeX{x9a75fb99b59c6e6e}.bin", x1bc1cc5e4fd586bf: false);
		string s = string.Format("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?><ax:ocx ax:classid=\"{{{0}}}\" ax:persistence=\"persistStorage\" r:id=\"rId1\" xmlns:ax=\"{1}\" xmlns:r=\"{2}\"/>", xd8c3135513b9115b.x29e7ace4c90f74cd.x933ed8cf24f04c67.ToString().ToUpper(), "http://schemas.microsoft.com/office/2006/activeX", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		xb6f33aded088c276.xb8a774e0111d0fbe.Write(bytes, 0, bytes.Length);
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = x39c7aeeec1af9dd0.x42c5f80e2ed823ff(xb6f33aded088c276, $"/word/activeX/activeX{x9a75fb99b59c6e6e}.bin", "application/vnd.ms-office.activeX", "http://schemas.microsoft.com/office/2006/relationships/activeXControlBinary");
		xd8c3135513b9115b.x0acd3c2012ea2ee8(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe);
		xa2f1c3dcbd86f20a.xb8a774e0111d0fbe.Position = 0L;
		return new x432b11171adc04ec(xd8c3135513b9115b.x29e7ace4c90f74cd).x7418697d519d9ddc;
	}

	private void xfb80633b3fcbe371(Paragraph x41baca1d6c0c2e8e)
	{
		x1a78664fa10a3755 x1a78664fa10a = x41baca1d6c0c2e8e.x1a78664fa10a3755;
		bool flag = x2aa41ce9e83be7cd.xd29409f2ba9889e2(x1a78664fa10a, this);
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

	private void xfb78915a60b77e4b(FieldChar x2223f7db33837fbd)
	{
		bool x566ab42519f5da4a = !x5c29822913be33c1.xc53b1fb81a461c42(x2223f7db33837fbd.FieldType);
		x5a7a1d229173bf5d.x32c9a0cbee7be23c(x2223f7db33837fbd.xeedad81aaed42a76, x2223f7db33837fbd, x566ab42519f5da4a);
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
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("nnbnnpingppnkpgoponoikepjolphocalojafoabgohbpnobhofcfnmcpnddkikdmmbemniebnpedmgfolnfmmegkllgglchnhjh", 305844631)));
		}
		xf486629d2973656f = x4825cc64be84ad61 != 0;
		x800085dd555f7711.x4122f10182ac673a("w:fldChar", "w:fldCharType", text);
		if (x2223f7db33837fbd.NodeType == NodeType.FieldStart)
		{
			x800085dd555f7711.x0ea3ef8dd3ae2f3f("w:fldLock", x2223f7db33837fbd.IsLocked);
		}
		x0e00a0b374dc1f7f(x2223f7db33837fbd);
		x800085dd555f7711.x2dfde153f4ef96d0("w:fldChar");
		x5a7a1d229173bf5d.xf0de1bdc2a5440b2(x2223f7db33837fbd.xeedad81aaed42a76);
	}

	private void x0e00a0b374dc1f7f(FieldChar x2223f7db33837fbd)
	{
		if (x2223f7db33837fbd.NodeType != NodeType.FieldStart || !x5c29822913be33c1.x7f8b7c1c90735bcf(x2223f7db33837fbd.FieldType))
		{
			return;
		}
		FormField formField = (FormField)x2223f7db33837fbd.x03a9a1b8afdf52f9(NodeType.FormField);
		if (formField != null && formField.xd1b40af56a8385d4 != null)
		{
			x800085dd555f7711.x2307058321cdb62f("w:ffData");
			x800085dd555f7711.xa639a651da945648("w:name", formField.Name);
			x800085dd555f7711.x547195bcc386fe66("w:enabled", formField.Enabled);
			x800085dd555f7711.x547195bcc386fe66("w:calcOnExit", formField.CalculateOnExit);
			x800085dd555f7711.x547195bcc386fe66("w:entryMacro", formField.EntryMacro);
			x800085dd555f7711.x547195bcc386fe66("w:exitMacro", formField.ExitMacro);
			xf16651f269eab13e("w:helpText", !formField.OwnHelp, formField.HelpText);
			xf16651f269eab13e("w:statusText", !formField.OwnStatus, formField.StatusText);
			switch (x2223f7db33837fbd.FieldType)
			{
			case FieldType.FieldFormTextInput:
				x4124f4263e86821b(formField.x58bf2a36f9adf9a9);
				break;
			case FieldType.FieldFormCheckBox:
				x22bcbaf653eebc31(formField.x58bf2a36f9adf9a9);
				break;
			case FieldType.FieldFormDropDown:
				xfb8acc6f8038a1a8(formField.x58bf2a36f9adf9a9);
				break;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kdfpafmpkedakekaiebbneibbepbapfcddncjdedjdldbdceboieecafechfnbofbcfggbmgpmchackhccbigbiiiapiomfj", 1450898661)));
			}
			x800085dd555f7711.x2dfde153f4ef96d0("w:ffData");
		}
	}

	private void x4124f4263e86821b(x58bf2a36f9adf9a9 x3db8cf25c83af70b)
	{
		x800085dd555f7711.x2307058321cdb62f("w:textInput");
		x800085dd555f7711.x547195bcc386fe66("w:type", xc62574be95c1c918.xef04f7c4a90f2a51(x3db8cf25c83af70b.x98ed2e2b5602a6f1));
		x800085dd555f7711.x547195bcc386fe66("w:default", x3db8cf25c83af70b.x5e1adcb28cb5f299);
		x800085dd555f7711.x67aa7400b293b13a("w:maxLength", Convert.ToInt16(x3db8cf25c83af70b.xc5c2fb4db5b8c3bd));
		x800085dd555f7711.x547195bcc386fe66("w:format", x3db8cf25c83af70b.xe8f8d8a7db32427b);
		x800085dd555f7711.x2dfde153f4ef96d0("w:textInput");
	}

	private void x22bcbaf653eebc31(x58bf2a36f9adf9a9 x3db8cf25c83af70b)
	{
		x800085dd555f7711.x2307058321cdb62f("w:checkBox");
		if (x3db8cf25c83af70b.xbd91bc7364251d6d)
		{
			x800085dd555f7711.xf68f9c3818e1f4b1("w:sizeAuto");
		}
		else
		{
			x800085dd555f7711.x547195bcc386fe66("w:size", xca004f56614e2431.x754c3a5f03a2ce84(x3db8cf25c83af70b.x4bdafa5e724a058a));
		}
		x800085dd555f7711.x2023716b7b909631("w:default", x3db8cf25c83af70b.x5e6597fb50c93e39);
		if (x3db8cf25c83af70b.x7c5abf7ed147c26c)
		{
			x800085dd555f7711.x2023716b7b909631("w:checked", x3db8cf25c83af70b.x4ac39a4f11664c6b);
		}
		x800085dd555f7711.x2dfde153f4ef96d0("w:checkBox");
	}

	private void xfb8acc6f8038a1a8(x58bf2a36f9adf9a9 x3db8cf25c83af70b)
	{
		x800085dd555f7711.x2307058321cdb62f("w:ddList");
		if (x3db8cf25c83af70b.x290a782f6c7cab2f != 0)
		{
			x800085dd555f7711.x547195bcc386fe66("w:default", x3db8cf25c83af70b.x290a782f6c7cab2f);
		}
		if (x3db8cf25c83af70b.x6cf648f1ac6f4032)
		{
			x800085dd555f7711.x547195bcc386fe66("w:result", x3db8cf25c83af70b.xfeefd92fb9bd0678);
		}
		foreach (string item in x3db8cf25c83af70b.xc055d178db9e8d17)
		{
			x800085dd555f7711.xa639a651da945648("w:listEntry", item);
		}
		x800085dd555f7711.x2dfde153f4ef96d0("w:ddList");
	}

	private void xf16651f269eab13e(string x121383aa64985888, bool x2b420b6d36637389, string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			x800085dd555f7711.x2307058321cdb62f(x121383aa64985888);
			x800085dd555f7711.xff520a0047c27122("w:type", x2b420b6d36637389 ? "autoText" : "text");
			x800085dd555f7711.xff520a0047c27122("w:val", xbcea506a33cf9111);
			x800085dd555f7711.x2dfde153f4ef96d0(x121383aa64985888);
		}
	}

	private void x4e44079093b28b81(Shape x5770cdefd8931aa9)
	{
		x4e44079093b28b81(x5770cdefd8931aa9.x8edafc3cf6e5431a, x5770cdefd8931aa9.xffd5ab6c569c488d, x5770cdefd8931aa9.Target, x5770cdefd8931aa9.ScreenTip);
	}

	private void x4e44079093b28b81(string x6b8e154b42d5c1e3, string xa490ad5ef1682691, string x11d58b056c032b03, string x90adc4150b5063b1)
	{
		x800085dd555f7711.x2307058321cdb62f("w:hyperlink");
		if (x0d299f323d241756.x5959bccb67bbf051(x6b8e154b42d5c1e3))
		{
			x800085dd555f7711.x943f6be3acf634db("r:id", xfa224738036f0894(x6b8e154b42d5c1e3));
		}
		x800085dd555f7711.x943f6be3acf634db("w:anchor", xa490ad5ef1682691);
		x800085dd555f7711.x943f6be3acf634db("w:tgtFrame", x11d58b056c032b03);
		x800085dd555f7711.x943f6be3acf634db("w:tooltip", x90adc4150b5063b1);
		x800085dd555f7711.x943f6be3acf634db("w:history", "1");
	}

	private void x1210e8a0b401d5a2()
	{
		x800085dd555f7711.x2dfde153f4ef96d0("w:hyperlink");
	}

	private void x73eee79ab9d615d9(ShapeBase x5770cdefd8931aa9)
	{
		if (!xb2afb418e467f0b0)
		{
			x5a7a1d229173bf5d.x32c9a0cbee7be23c(x5770cdefd8931aa9.xeedad81aaed42a76, x5770cdefd8931aa9, x566ab42519f5da4a: false);
		}
		if (x5770cdefd8931aa9.IsInline && (x5770cdefd8931aa9.xa8228c6215bc2643 || x5770cdefd8931aa9.x917b07206b752ba4))
		{
			x800085dd555f7711.x2307058321cdb62f("w:object");
		}
		else
		{
			x800085dd555f7711.x2307058321cdb62f("w:pict");
		}
	}

	private void x4907259ee48e3d89(ShapeBase x5770cdefd8931aa9)
	{
		x800085dd555f7711.x2dfde153f4ef96d0();
		if (!xb2afb418e467f0b0)
		{
			x5a7a1d229173bf5d.xf0de1bdc2a5440b2(x5770cdefd8931aa9.xeedad81aaed42a76);
		}
	}

	private static bool xc2f8d84d0cae2fc2(Shape x5770cdefd8931aa9)
	{
		if (x5770cdefd8931aa9.IsInline)
		{
			return x5770cdefd8931aa9.xa8228c6215bc2643;
		}
		return false;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public string x2f696e6403c110df(byte[] x43e181e083db6cdf)
	{
		string text = x9b287b671d592594.x4ce44a3c724a357f(x43e181e083db6cdf);
		if (!x0d299f323d241756.x5959bccb67bbf051(text))
		{
			xfe2ff3c162b47c70 xfe2ff3c162b47c = xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(x43e181e083db6cdf);
			string contentType = xb9015fe823e7e228.x0ad80fdc3fba643e(xfe2ff3c162b47c);
			string arg = xb9015fe823e7e228.xac88cb4f794761a9(xfe2ff3c162b47c);
			byte[] array = x43e181e083db6cdf;
			switch (xfe2ff3c162b47c)
			{
			case xfe2ff3c162b47c70.x26c36dd85013b919:
				arg = "pcz";
				contentType = "image/x-pcz";
				array = x64893267b789fd52.x7b2ace3ecba130d8(x43e181e083db6cdf);
				break;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ljkbblbcclicckpcnjgdgkndljeepjlehjcffkjfniagjihgceogiifhjimhkhdinhkiihbjadijbipjdigkhhnkjgelbclldgcmjgjmlfaneghnhgonnffoagmooedpifkpiebaeeianpoaodgbmenbgeeckdlcmdcdcdjdiopdjahebboecaffebmfjncglbkglcbhacihmbphmbgilbnicndj", 1640176198)));
			case xfe2ff3c162b47c70.xd69df86e2a88ddb2:
			case xfe2ff3c162b47c70.xb5fe04c34562f438:
			case xfe2ff3c162b47c70.x796ab23ce57ee1e0:
			case xfe2ff3c162b47c70.x6339cdb9e2b512c7:
			case xfe2ff3c162b47c70.xc2746d872ce402e9:
			case xfe2ff3c162b47c70.x15c106572f1e1fbf:
			case xfe2ff3c162b47c70.x8e716ec1cb703e9f:
			case xfe2ff3c162b47c70.x6fcc29eace04fce1:
				break;
			}
			text = string.Format("/word/media/image{0}.{1}", x15789b8c2554f92e("http://schemas.openxmlformats.org/officeDocument/2006/relationships/image"), arg);
			xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = new xa2f1c3dcbd86f20a(text, contentType);
			x39c7aeeec1af9dd0.xd6abb2ab950b4d22.xd6b6ed77479ef68c(xa2f1c3dcbd86f20a);
			xa2f1c3dcbd86f20a.xb8a774e0111d0fbe.Write(array, 0, array.Length);
			x9b287b671d592594.x7760c45a55261d34(x43e181e083db6cdf, text);
		}
		return x800085dd555f7711.x398b3bd0acd94b61.xadb7000bed559a9a.xd6b6ed77479ef68c("http://schemas.openxmlformats.org/officeDocument/2006/relationships/image", text, x1bc1cc5e4fd586bf: false);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public string xf1b629587cb7c15e(string xe9c763083b68a7ee)
	{
		return x800085dd555f7711.x398b3bd0acd94b61.xadb7000bed559a9a.xd6b6ed77479ef68c("http://schemas.openxmlformats.org/officeDocument/2006/relationships/image", xe9c763083b68a7ee, x1bc1cc5e4fd586bf: true);
	}

	private string x9636fc9f1575f1b5(int xba08ce632055a1d9)
	{
		if (xbd1cf65dfdae0e0b == null)
		{
			xbd1cf65dfdae0e0b = new Hashtable();
			foreach (ShapeBase childNode in x2c8c6741422a1298.GetChildNodes(NodeType.Shape, isDeep: true))
			{
				string name = childNode.Name;
				if (name.StartsWith("_s"))
				{
					xbd1cf65dfdae0e0b[x64893267b789fd52.x650d90d2e073ca99(name)] = name;
				}
			}
		}
		return (string)xbd1cf65dfdae0e0b[xba08ce632055a1d9];
	}

	string x2cd1f1f5e07462a8.xb60a89e8f071915f(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x9636fc9f1575f1b5
		return this.x9636fc9f1575f1b5(xba08ce632055a1d9);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public string x7af082eaf8e0caa4(int xddd12ddd8b1e4a90)
	{
		return xbc33695753285351.x7af082eaf8e0caa4(xddd12ddd8b1e4a90);
	}

	private void xe18bf0a40e44bd2d(HeaderFooter x03e7e66b1eecc96f)
	{
		string x69cb5ff2e6c23f;
		string xe1d3286d17e44a;
		string x766ce0458c;
		string x121383aa;
		if (x03e7e66b1eecc96f.IsHeader)
		{
			x69cb5ff2e6c23f = $"header{x661497a708497091()}.xml";
			xe1d3286d17e44a = "application/vnd.openxmlformats-officedocument.wordprocessingml.header+xml";
			x766ce0458c = "w:hdr";
			x121383aa = "w:headerReference";
		}
		else
		{
			x69cb5ff2e6c23f = $"footer{xb7941d80b788655a()}.xml";
			xe1d3286d17e44a = "application/vnd.openxmlformats-officedocument.wordprocessingml.footer+xml";
			x766ce0458c = "w:ftr";
			x121383aa = "w:footerReference";
		}
		if (x03e7e66b1eecc96f.ParentSection.x59fc5ceeaaccb880 || !x03e7e66b1eecc96f.IsLinkedToPrevious)
		{
			string x061610664b4c984f = (x03e7e66b1eecc96f.IsHeader ? "http://schemas.openxmlformats.org/officeDocument/2006/relationships/header" : "http://schemas.openxmlformats.org/officeDocument/2006/relationships/footer");
			string xc06e652f250a;
			x8f3af96aa56f1e32 x8f3af96aa56f1e33 = xa24813b526772a3b(x69cb5ff2e6c23f, xe1d3286d17e44a, x061610664b4c984f, out xc06e652f250a);
			if (x8f3af96aa56f1e33.xd115f8f0cdf9cf2f == OoxmlCompliance.Ecma376_2006)
			{
				x8f3af96aa56f1e33.x454da6e050647673(x766ce0458c);
			}
			else
			{
				x8f3af96aa56f1e33.x17784f246e4754b0(x766ce0458c);
			}
			xefc309b2831366cb(x8f3af96aa56f1e33);
			x03e7e66b1eecc96f.Accept(this);
			xa493f0b03338ab7a();
			x8f3af96aa56f1e33.xa0dfc102c691b11f();
			x873451caae5ad4ae x873451caae5ad4ae = xca93abf9292cd4f1;
			x873451caae5ad4ae.x2307058321cdb62f(x121383aa);
			x873451caae5ad4ae.xff520a0047c27122("w:type", x93625b0e8808b0cc.x9705b85b99f335f9(x03e7e66b1eecc96f.HeaderFooterType, x5fbb1a9c98604ef5: true));
			x873451caae5ad4ae.xff520a0047c27122("r:id", xc06e652f250a);
			x873451caae5ad4ae.x2dfde153f4ef96d0();
		}
	}

	void xfe11bbc13ba649c3.x6075c9125351e131(HeaderFooter x03e7e66b1eecc96f)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xe18bf0a40e44bd2d
		this.xe18bf0a40e44bd2d(x03e7e66b1eecc96f);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void xf65c32ef4443c2c5(x4c1e058c67948d6a xe9707cb1ec88db49, bool x28ee2f81ab05fedb)
	{
		if (x3bae55a357c42cd0 != null)
		{
			x3bae55a357c42cd0.xf65c32ef4443c2c5(xe9707cb1ec88db49, x28ee2f81ab05fedb);
		}
		if (xeed27dc46b88b3ea != null)
		{
			xeed27dc46b88b3ea.xf65c32ef4443c2c5(xe9707cb1ec88db49, x28ee2f81ab05fedb);
		}
	}

	internal void x35c80635ff7a735b(string x4c12babe29167a55, int xeaf1b27180c0557b)
	{
		x800085dd555f7711.x2307058321cdb62f(x4c12babe29167a55);
		x800085dd555f7711.x943f6be3acf634db("w:id", xeaf1b27180c0557b);
		x800085dd555f7711.x2dfde153f4ef96d0(x4c12babe29167a55);
	}

	internal int x661497a708497091()
	{
		xccbb5683ddcbe0f8++;
		return xccbb5683ddcbe0f8;
	}

	internal int xb7941d80b788655a()
	{
		xb3456a9ba4cb7a7b++;
		return xb3456a9ba4cb7a7b;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public int x28ee4b8b8f777b55()
	{
		return x18730ec3a68983e6++;
	}

	internal int x15789b8c2554f92e(string x061610664b4c984f)
	{
		return x9b287b671d592594.x15789b8c2554f92e(x061610664b4c984f);
	}

	internal string xfa224738036f0894(string x6b8e154b42d5c1e3)
	{
		return x800085dd555f7711.x398b3bd0acd94b61.xadb7000bed559a9a.xd6b6ed77479ef68c("http://schemas.openxmlformats.org/officeDocument/2006/relationships/hyperlink", x6b8e154b42d5c1e3, !x0d4d45882065c63e.xbf8774d82d777b9e(x6b8e154b42d5c1e3));
	}

	internal string xd7fff6bb685052ae(string x6b8e154b42d5c1e3)
	{
		return x800085dd555f7711.x398b3bd0acd94b61.xadb7000bed559a9a.xd6b6ed77479ef68c("http://schemas.openxmlformats.org/officeDocument/2006/relationships/oleObject", x6b8e154b42d5c1e3, x1bc1cc5e4fd586bf: true);
	}

	internal x8f3af96aa56f1e32 xa24813b526772a3b(string x69cb5ff2e6c23f47, string xe1d3286d17e44a37, string x061610664b4c984f)
	{
		string xc06e652f250a;
		return xa24813b526772a3b(x69cb5ff2e6c23f47, xe1d3286d17e44a37, x061610664b4c984f, out xc06e652f250a);
	}

	internal x8f3af96aa56f1e32 xa24813b526772a3b(string x69cb5ff2e6c23f47, string xe1d3286d17e44a37, string x061610664b4c984f, out string xc06e652f250a3786)
	{
		return xa24813b526772a3b(x336788c6a46ed27b, x69cb5ff2e6c23f47, xe1d3286d17e44a37, x061610664b4c984f, out xc06e652f250a3786);
	}

	internal x8f3af96aa56f1e32 xa24813b526772a3b(xa2f1c3dcbd86f20a x660bfbc29977d3c8, string x69cb5ff2e6c23f47, string xe1d3286d17e44a37, string x061610664b4c984f, out string xc06e652f250a3786)
	{
		xa2f1c3dcbd86f20a part = x39c7aeeec1af9dd0.x42c5f80e2ed823ff(x660bfbc29977d3c8, x69cb5ff2e6c23f47, xe1d3286d17e44a37, x061610664b4c984f, out xc06e652f250a3786);
		return new x8f3af96aa56f1e32(part, xf57de0fd37d5e97d.PrettyFormat, x0b744c5c26c5b3b3);
	}

	internal void xefc309b2831366cb(x8f3af96aa56f1e32 xd07ce4b74c5774a7)
	{
		x4bd2c30f9472d1cc.Push(x800085dd555f7711);
		x800085dd555f7711 = xd07ce4b74c5774a7;
	}

	internal void xa493f0b03338ab7a()
	{
		x800085dd555f7711 = (x8f3af96aa56f1e32)x4bd2c30f9472d1cc.Pop();
	}
}
