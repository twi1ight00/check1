using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using Aspose.Words.Loading;
using Aspose.Words.Markup;
using Aspose.Words.Tables;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x9b5b1a17490bd5f3;
using x9db5f2e5af3d596e;
using xf9a9481c3f63a419;
using xfbd1009a0cbb9842;

namespace Aspose.Words;

public class DocumentBuilder : xf5ecf429e74b1c04, x8f424b921df6c21a, xf516b6b0dd7e0d14
{
	private Document x232be220f517f721;

	private Node x5b1159568297e3a9;

	private xeedad81aaed42a76 xd0c44e5ae0011daa;

	private Font x83cd810ab70afec3;

	private Stack xf4b77a6b3844f133;

	private bool x7824d145f30b8548;

	private xedb0eb766e25e0c9 xe661c29834d8220f;

	private xf8cef531dae89ea3 xede608e9bc344cf9;

	private RowFormat x263f760f2f871aeb;

	private CellFormat x161e03c9585c73c3;

	private Stack x480924248556eb68;

	public Document Document
	{
		get
		{
			return x232be220f517f721;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			if (value != x232be220f517f721)
			{
				x232be220f517f721 = value;
				x5b1159568297e3a9 = null;
				xd0c44e5ae0011daa = new xeedad81aaed42a76();
				xf4b77a6b3844f133 = null;
				x83cd810ab70afec3 = null;
				xd0a822ebcb83ac91(x0d0bfe1511f626d9: false);
				x480924248556eb68 = new Stack();
				MoveToDocumentStart();
			}
		}
	}

	public Font Font
	{
		get
		{
			if (x83cd810ab70afec3 == null)
			{
				x83cd810ab70afec3 = new Font(this, Document.Styles);
			}
			return x83cd810ab70afec3;
		}
	}

	public bool Bold
	{
		get
		{
			return Font.Bold;
		}
		set
		{
			Font.Bold = value;
		}
	}

	public bool Italic
	{
		get
		{
			return Font.Italic;
		}
		set
		{
			Font.Italic = value;
		}
	}

	public Underline Underline
	{
		get
		{
			return Font.Underline;
		}
		set
		{
			Font.Underline = value;
		}
	}

	public ParagraphFormat ParagraphFormat => CurrentParagraph.ParagraphFormat;

	public ListFormat ListFormat => CurrentParagraph.ListFormat;

	public PageSetup PageSetup => CurrentSection.PageSetup;

	public RowFormat RowFormat
	{
		get
		{
			if (x263f760f2f871aeb == null)
			{
				x263f760f2f871aeb = new RowFormat(this);
			}
			return x263f760f2f871aeb;
		}
	}

	public CellFormat CellFormat
	{
		get
		{
			if (x161e03c9585c73c3 == null)
			{
				x161e03c9585c73c3 = new CellFormat(this);
			}
			return x161e03c9585c73c3;
		}
	}

	public bool IsAtStartOfParagraph
	{
		get
		{
			Node node = CurrentParagraph.FirstChild;
			while (node != null && node != x5b1159568297e3a9)
			{
				if (node.NodeType == NodeType.BookmarkStart || node.NodeType == NodeType.BookmarkEnd)
				{
					node = node.NextSibling;
					continue;
				}
				return false;
			}
			return true;
		}
	}

	public bool IsAtEndOfParagraph => x5b1159568297e3a9.NodeType == NodeType.Paragraph;

	public Node CurrentNode
	{
		get
		{
			if (!IsAtEndOfParagraph)
			{
				return x5b1159568297e3a9;
			}
			return null;
		}
	}

	public Paragraph CurrentParagraph
	{
		get
		{
			if (IsAtEndOfParagraph)
			{
				return (Paragraph)x5b1159568297e3a9;
			}
			return (Paragraph)x5b1159568297e3a9.GetAncestor(NodeType.Paragraph);
		}
	}

	public Story CurrentStory => CurrentParagraph.ParentStory;

	public Section CurrentSection => (Section)CurrentStory.ParentNode;

	private x8e63dd35709cb9ab xdefa75d57fc6655d
	{
		get
		{
			if (x480924248556eb68.Count <= 0)
			{
				return null;
			}
			return x480924248556eb68.Peek() as x8e63dd35709cb9ab;
		}
	}

	private Stack xe431734ecddf91e4
	{
		get
		{
			if (xf4b77a6b3844f133 == null)
			{
				xf4b77a6b3844f133 = new Stack();
			}
			return xf4b77a6b3844f133;
		}
	}

	int xf5ecf429e74b1c04.x5b8c6010012a5955 => xd0c44e5ae0011daa.xd44988f225497f3a;

	public DocumentBuilder()
	{
		Document = new Document();
	}

	public DocumentBuilder(Document doc)
	{
		Document = doc;
	}

	public void MoveToDocumentStart()
	{
		x01b2723108ff3dfe(0, StoryType.MainText, 0, 0);
	}

	public void MoveToDocumentEnd()
	{
		x01b2723108ff3dfe(-1, StoryType.MainText, -1, -1);
	}

	public void MoveToSection(int sectionIndex)
	{
		x01b2723108ff3dfe(sectionIndex, StoryType.MainText, 0, 0);
	}

	public void MoveToHeaderFooter(HeaderFooterType headerFooterType)
	{
		x01b2723108ff3dfe(CurrentSection, xb7dbd7bb3ed97d5b.x3bcc8e857eb29ca0(headerFooterType), 0, 0);
	}

	private void x01b2723108ff3dfe(int xab1fa5fa43793205, StoryType xdbbf47b5e620c262, int xc2def3789754b9d6, int x0f8e703e2bee7a11)
	{
		x232be220f517f721.EnsureMinimum();
		Section section = (Section)x232be220f517f721.GetChild(NodeType.Section, xab1fa5fa43793205, isDeep: false);
		if (section == null)
		{
			throw new ArgumentOutOfRangeException("sectionIdx");
		}
		x01b2723108ff3dfe(section, xdbbf47b5e620c262, xc2def3789754b9d6, x0f8e703e2bee7a11);
	}

	private void x01b2723108ff3dfe(Section xb32f8dd719a105db, StoryType xdbbf47b5e620c262, int xc2def3789754b9d6, int x0f8e703e2bee7a11)
	{
		xb32f8dd719a105db.EnsureMinimum();
		Story story;
		if (xdbbf47b5e620c262 == StoryType.MainText)
		{
			story = xb32f8dd719a105db.Body;
		}
		else
		{
			HeaderFooterType headerFooterType = xb7dbd7bb3ed97d5b.x442f5a91105f9e6a(xdbbf47b5e620c262);
			story = xb32f8dd719a105db.HeadersFooters[headerFooterType];
			if (story == null)
			{
				story = (HeaderFooter)xb32f8dd719a105db.AppendChild(new HeaderFooter(x232be220f517f721, headerFooterType));
			}
			if (story.FirstParagraph == null)
			{
				story.AppendChild(new Paragraph(x232be220f517f721));
			}
		}
		x01b2723108ff3dfe(story, xc2def3789754b9d6, x0f8e703e2bee7a11);
	}

	private void x01b2723108ff3dfe(Story x93d8434f027afd5a, int xc2def3789754b9d6, int x0f8e703e2bee7a11)
	{
		Paragraph paragraph = (Paragraph)x93d8434f027afd5a.GetChild(NodeType.Paragraph, xc2def3789754b9d6, isDeep: true);
		if (paragraph == null)
		{
			throw new ArgumentOutOfRangeException("paraIdx");
		}
		x01b2723108ff3dfe(paragraph, x0f8e703e2bee7a11);
	}

	internal void x01b2723108ff3dfe(Paragraph x41baca1d6c0c2e8e, int x0f8e703e2bee7a11)
	{
		switch (x0f8e703e2bee7a11)
		{
		case 0:
			x01b2723108ff3dfe(x41baca1d6c0c2e8e, x41baca1d6c0c2e8e.FirstChild);
			break;
		case -1:
			x01b2723108ff3dfe(x41baca1d6c0c2e8e, null);
			break;
		}
	}

	public bool MoveToMergeField(string fieldName)
	{
		return MoveToMergeField(fieldName, isAfter: true, isDeleteField: true);
	}

	public bool MoveToMergeField(string fieldName, bool isAfter, bool isDeleteField)
	{
		if (fieldName == null)
		{
			throw new ArgumentNullException("fieldName");
		}
		x561fa53c007d3597 x561fa53c007d = x128b204e99444601.x0fb4c65f43184ed5(x232be220f517f721, fieldName);
		if (x561fa53c007d == null)
		{
			return false;
		}
		MoveToField(x561fa53c007d, isAfter);
		if (isDeleteField)
		{
			x561fa53c007d.Remove();
		}
		return true;
	}

	public void MoveToField(Field field, bool isAfter)
	{
		Node node;
		if (isAfter)
		{
			node = field.End.NextSibling;
			if (node == null)
			{
				node = field.Start.ParentParagraph;
			}
		}
		else
		{
			node = field.Start;
		}
		MoveTo(node);
		x04c0e061352aeb47 x04c0e061352aeb = field.xa890d2fd18bed2bc.xab1a64aa04b401a0();
		Inline inline = x04c0e061352aeb.xf39c106b43956987();
		if (inline != null)
		{
			x77184348a27ba1e6(inline.xeedad81aaed42a76, x692ced34f50137f2: true);
		}
	}

	public bool MoveToBookmark(string bookmarkName)
	{
		return MoveToBookmark(bookmarkName, isStart: true, isAfter: true);
	}

	public bool MoveToBookmark(string bookmarkName, bool isStart, bool isAfter)
	{
		if (bookmarkName == null)
		{
			throw new ArgumentNullException("bookmarkName");
		}
		Node node = ((!isStart) ? ((Node)xfcbee4820570241e.x1c27bfd94cd10eef(x232be220f517f721, bookmarkName)) : ((Node)xfcbee4820570241e.x7dff5baaa927f80f(x232be220f517f721, bookmarkName)));
		if (node == null)
		{
			return false;
		}
		x01b2723108ff3dfe((Paragraph)node.xdfa6ecc6f742f086, isAfter ? node.NextSibling : node);
		return true;
	}

	public void MoveToParagraph(int paragraphIndex, int characterIndex)
	{
		x01b2723108ff3dfe(CurrentStory, paragraphIndex, characterIndex);
	}

	public void MoveToCell(int tableIndex, int rowIndex, int columnIndex, int characterIndex)
	{
		if (characterIndex != 0 && characterIndex != -1)
		{
			throw new ArgumentOutOfRangeException("characterIndex");
		}
		Row row = xeb3e9f2179b3f2cb(tableIndex, rowIndex);
		Cell cell = (Cell)row.GetChild(NodeType.Cell, columnIndex, isDeep: false);
		if (cell == null)
		{
			throw new ArgumentOutOfRangeException("columnIndex");
		}
		cell.EnsureMinimum();
		switch (characterIndex)
		{
		case 0:
			x01b2723108ff3dfe(cell.FirstParagraph, 0);
			break;
		case -1:
			x01b2723108ff3dfe(cell.LastParagraph, -1);
			break;
		}
	}

	internal void x01b2723108ff3dfe(Paragraph x41baca1d6c0c2e8e, Node x31545d7c306a55e4)
	{
		if (x31545d7c306a55e4 != null)
		{
			MoveTo(x31545d7c306a55e4);
		}
		else
		{
			MoveTo(x41baca1d6c0c2e8e);
		}
	}

	public void MoveTo(Node node)
	{
		if (node == null)
		{
			throw new ArgumentNullException("node");
		}
		if (node.Document != Document)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kpcelakefabfnlhfiapfgaggipmggpdhokkhnobinoiibppibpgjnonjdoekmolkgjclhojlpnamnihmlmomhifnimmnkmdoemkobmbpnliphmpphlganlnaamebjglbkkcccljcdkadclhdhkodmjfeckmefkdfmfkf", 1042956966)));
		}
		if (node.ParentNode == null)
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ncmflddgjekgjdbhpdihcephlofilcnigcejadljnccklcjkncalgnglfbolfbfmnmlmibdnmbknabbonaiommoo", 1699896285)));
		}
		if (node.NodeType != NodeType.Paragraph && !x2b1ee3a87b36a988.x15bc008974f7d712(node))
		{
			throw new InvalidOperationException("The node must be a paragraph or an inline node.");
		}
		x5b1159568297e3a9 = node;
		if (CurrentParagraph.IsInCell)
		{
			xb6d4b9c06ff42757();
		}
		else
		{
			xf466d4a1b1e62ec8(x0d0bfe1511f626d9: false);
		}
		if (IsAtEndOfParagraph)
		{
			x2ac4ffc6691ec3ea();
		}
		else if (!xa4c9425668e60059())
		{
			x2ac4ffc6691ec3ea();
		}
	}

	private bool xa4c9425668e60059()
	{
		Node nextSibling = x5b1159568297e3a9;
		while (nextSibling != null && !(nextSibling is xcf3b0f04424de818))
		{
			nextSibling = nextSibling.NextSibling;
		}
		if (nextSibling != null)
		{
			xcf3b0f04424de818 xcf3b0f04424de = (xcf3b0f04424de818)nextSibling;
			x77184348a27ba1e6(xcf3b0f04424de.xc87649c48f7756d2, x692ced34f50137f2: true);
			return true;
		}
		return false;
	}

	private void x2ac4ffc6691ec3ea()
	{
		x77184348a27ba1e6(CurrentParagraph.x344511c4e4ce09da, x692ced34f50137f2: true);
	}

	private void xb6d4b9c06ff42757()
	{
		Cell xc5464084edc8e = CurrentParagraph.xc5464084edc8e226;
		Row parentRow = xc5464084edc8e.ParentRow;
		xe661c29834d8220f = parentRow.xedb0eb766e25e0c9;
		xede608e9bc344cf9 = xc5464084edc8e.xf8cef531dae89ea3;
		x7824d145f30b8548 = true;
	}

	internal void xf466d4a1b1e62ec8(bool x0d0bfe1511f626d9)
	{
		if (x7824d145f30b8548)
		{
			xd0a822ebcb83ac91(x0d0bfe1511f626d9);
		}
	}

	private void xd0a822ebcb83ac91(bool x0d0bfe1511f626d9)
	{
		x7824d145f30b8548 = false;
		xe661c29834d8220f = (x0d0bfe1511f626d9 ? ((xedb0eb766e25e0c9)xe661c29834d8220f.x8b61531c8ea35b85()) : xedb0eb766e25e0c9.xf5b6851196debf5a());
		xede608e9bc344cf9 = (x0d0bfe1511f626d9 ? ((xf8cef531dae89ea3)xede608e9bc344cf9.x8b61531c8ea35b85()) : new xf8cef531dae89ea3());
	}

	public Row DeleteRow(int tableIndex, int rowIndex)
	{
		Row row = xeb3e9f2179b3f2cb(tableIndex, rowIndex);
		Table parentTable = row.ParentTable;
		if (xdefa75d57fc6655d != null)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hlgecnnemnefjnlfhncgjnjgciahdmhhbmohfmfillmihmdjflkjngbklkikhgpkilglcknlakemhklmnjcnffjnekaoojhodkoojefpnjmplidajikajibbphibhdpbghgcginchhedhhldmgceogjeahafgghfmbofkffggbmghgdhbfkhpebigfiimepicbgj", 435242612)));
		}
		if (x5b1159568297e3a9.xd5b26cfce8730b50(row))
		{
			if (row != parentTable.LastRow)
			{
				MoveToCell(tableIndex, rowIndex + 1, 0, 0);
			}
			else
			{
				Paragraph x41baca1d6c0c2e8e = (Paragraph)parentTable.xa6890a1cb2b8896e;
				x01b2723108ff3dfe(x41baca1d6c0c2e8e, 0);
			}
		}
		row.Remove();
		if (!parentTable.x73db39780c76cb8d)
		{
			parentTable.Remove();
		}
		return row;
	}

	public void Write(string text)
	{
		xf69e3cf19f0625a0(text, x567002813fadecac: false);
	}

	public void Writeln(string text)
	{
		xf69e3cf19f0625a0(text, x567002813fadecac: true);
	}

	public void Writeln()
	{
		InsertParagraph();
	}

	public Paragraph InsertParagraph()
	{
		Paragraph paragraph = new Paragraph(x232be220f517f721, x87c38d4df0b94981(), xdbd6535b15eacda9());
		CurrentParagraph.ParentNode.InsertAfter(paragraph, CurrentParagraph);
		if (IsAtEndOfParagraph)
		{
			MoveTo(paragraph);
		}
		else
		{
			paragraph.x2729186e1a0b4aeb(x5b1159568297e3a9, null, paragraph.LastChild);
		}
		return CurrentParagraph;
	}

	public void InsertBreak(BreakType breakType)
	{
		xb41fed203ad7c94f(breakType, x291fabf8727e1df6: true);
	}

	internal void xb41fed203ad7c94f(BreakType xb2209df87371abbb, bool x291fabf8727e1df6)
	{
		switch (xb2209df87371abbb)
		{
		case BreakType.ParagraphBreak:
			InsertParagraph();
			break;
		case BreakType.PageBreak:
			if (x0792239c9312065a(x291fabf8727e1df6))
			{
				x111a0f8160906fa7(ControlChar.PageBreak);
			}
			break;
		case BreakType.ColumnBreak:
			if (x0792239c9312065a(x291fabf8727e1df6))
			{
				x111a0f8160906fa7(ControlChar.ColumnBreak);
			}
			break;
		case BreakType.SectionBreakNewColumn:
			x421182dbe4852822(SectionStart.NewColumn);
			break;
		case BreakType.SectionBreakNewPage:
			x421182dbe4852822(SectionStart.NewPage);
			break;
		case BreakType.SectionBreakContinuous:
			x421182dbe4852822(SectionStart.Continuous);
			break;
		case BreakType.SectionBreakEvenPage:
			x421182dbe4852822(SectionStart.EvenPage);
			break;
		case BreakType.SectionBreakOddPage:
			x421182dbe4852822(SectionStart.OddPage);
			break;
		case BreakType.LineBreak:
			x111a0f8160906fa7(ControlChar.LineBreak);
			break;
		default:
			if (x291fabf8727e1df6)
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("nkfmdmmmnldnnlknllboamioelpodggpcknppkeapjlaijcbpjjbbfacckhcekocijfdkimdafde", 747947352)));
			}
			break;
		}
	}

	public Field InsertTableOfContents(string switches)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(switches))
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kjemljlmkicncjjnohaoaihokhoofifppcmpfhdamhkagcbbfhibfgpboggcpgncagedggldgfcecfjejbaf", 1509671975)));
		}
		return InsertField($"TOC {switches}", "");
	}

	public Field InsertField(string fieldCode)
	{
		Field field = InsertField(fieldCode, null);
		field.Update();
		return field;
	}

	public Field InsertField(string fieldCode, string fieldValue)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(fieldCode))
		{
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ghgjghnjpgekdhlkigcleejlngampfhmnfomfbfnlfmncgdomakolfbpleipefppffgagenameebmdlbidccppic", 837785104)));
		}
		FieldType x77ce91e5324df = x5c29822913be33c1.x3cfb5b1d26d86f4a(fieldCode);
		FieldStart x10aaa7cdfa38f = xb03cd6cf2fed9d7f(x77ce91e5324df);
		xd2dd4bae56c47a6c(fieldCode);
		FieldSeparator x3de314ab70bbd9bf;
		FieldEnd xca09b6c2b5b;
		if (x5c29822913be33c1.xd668adf9377c05ee(x77ce91e5324df) == x5576a2206c3fc746.xd4d82c4665f71358)
		{
			x3de314ab70bbd9bf = x8d879f7e82ddb431(x77ce91e5324df);
			if (fieldValue != null)
			{
				x111a0f8160906fa7(fieldValue);
			}
			xca09b6c2b5b = xa71e06bbe7cdb1a2(x77ce91e5324df, x5dfdce3c3b2a672a: true);
		}
		else
		{
			x3de314ab70bbd9bf = null;
			xca09b6c2b5b = xa71e06bbe7cdb1a2(x77ce91e5324df, x5dfdce3c3b2a672a: false);
		}
		return x3759c06a3a4cf5d1.x43fef3435fba7a66(x10aaa7cdfa38f, x3de314ab70bbd9bf, xca09b6c2b5b);
	}

	public Field InsertHyperlink(string displayText, string urlOrBookmark, bool isBookmark)
	{
		x0d299f323d241756.x0aaaea7864a53f26(displayText, "displayText");
		x0d299f323d241756.x0aaaea7864a53f26(urlOrBookmark, "hrefOrBookmark");
		x928b31adb20d5cc6 x928b31adb20d5cc = xb67b015f1a2f38a7(urlOrBookmark, isBookmark, "");
		Write(displayText);
		x928b31adb20d5cc.x9fd888e65466818c = xbfa3ad37f5032b4f();
		return x3759c06a3a4cf5d1.x43fef3435fba7a66(x928b31adb20d5cc.x12cb12b5d2cad53d, x928b31adb20d5cc.x43604484a3deae4f, x928b31adb20d5cc.x9fd888e65466818c);
	}

	public FormField InsertTextInput(string name, TextFormFieldType type, string format, string fieldValue, int maxLength)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		if (format == null)
		{
			throw new ArgumentNullException("format");
		}
		if (fieldValue == null)
		{
			throw new ArgumentNullException("fieldValue");
		}
		if (maxLength < 0)
		{
			throw new ArgumentOutOfRangeException("maxLength");
		}
		xb03cd6cf2fed9d7f(FieldType.FieldFormTextInput);
		if (x0d299f323d241756.x5959bccb67bbf051(name))
		{
			StartBookmark(name);
		}
		xd2dd4bae56c47a6c(" FORMTEXT ");
		Node x9ee886d5d4b7e3fe = x8d879f7e82ddb431(FieldType.FieldFormTextInput);
		string text = (x0d299f323d241756.x5959bccb67bbf051(fieldValue) ? fieldValue : FormField.xb8fa1e789c415fba);
		Run node = new Run(x232be220f517f721, text, xdbd6535b15eacda9());
		InsertNode(node);
		xa71e06bbe7cdb1a2(FieldType.FieldFormTextInput, x5dfdce3c3b2a672a: true);
		if (x0d299f323d241756.x5959bccb67bbf051(name))
		{
			EndBookmark(name);
		}
		FormField formField = x4fe6838d3feb674b(x9ee886d5d4b7e3fe);
		formField.Name = name;
		formField.TextInputType = type;
		formField.TextInputFormat = format;
		formField.Result = fieldValue;
		formField.MaxLength = maxLength;
		return formField;
	}

	public FormField InsertCheckBox(string name, bool defaultValue, int size)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		if (size < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		xb03cd6cf2fed9d7f(FieldType.FieldFormCheckBox);
		if (x0d299f323d241756.x5959bccb67bbf051(name))
		{
			StartBookmark(name);
		}
		xd2dd4bae56c47a6c(" FORMCHECKBOX ");
		Node x9ee886d5d4b7e3fe = xa71e06bbe7cdb1a2(FieldType.FieldFormCheckBox, x5dfdce3c3b2a672a: false);
		if (x0d299f323d241756.x5959bccb67bbf051(name))
		{
			EndBookmark(name);
		}
		FormField formField = x4fe6838d3feb674b(x9ee886d5d4b7e3fe);
		formField.Name = name;
		formField.Checked = defaultValue;
		if (size != 0)
		{
			formField.IsCheckBoxExactSize = true;
			formField.CheckBoxSize = size;
		}
		else
		{
			formField.IsCheckBoxExactSize = false;
			formField.CheckBoxSize = 10.0;
		}
		return formField;
	}

	public FormField InsertComboBox(string name, string[] items, int selectedIndex)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		if (items == null)
		{
			throw new ArgumentNullException("items");
		}
		if (items.Length > 25)
		{
			throw new ArgumentException("items");
		}
		if (selectedIndex < 0 || selectedIndex >= items.Length)
		{
			throw new ArgumentOutOfRangeException("selectedIndex");
		}
		xb03cd6cf2fed9d7f(FieldType.FieldFormDropDown);
		if (x0d299f323d241756.x5959bccb67bbf051(name))
		{
			StartBookmark(name);
		}
		xd2dd4bae56c47a6c(" FORMDROPDOWN ");
		Node x9ee886d5d4b7e3fe = xa71e06bbe7cdb1a2(FieldType.FieldFormDropDown, x5dfdce3c3b2a672a: false);
		if (x0d299f323d241756.x5959bccb67bbf051(name))
		{
			EndBookmark(name);
		}
		FormField formField = x4fe6838d3feb674b(x9ee886d5d4b7e3fe);
		formField.Name = name;
		formField.DropDownSelectedIndex = selectedIndex;
		for (int i = 0; i < items.Length; i++)
		{
			formField.DropDownItems.Add(items[i]);
		}
		return formField;
	}

	public Footnote InsertFootnote(FootnoteType footnoteType, string footnoteText)
	{
		bool flag = footnoteType == FootnoteType.Footnote;
		Footnote footnote = new Footnote(x232be220f517f721, footnoteType);
		footnote.Font.StyleIdentifier = (flag ? StyleIdentifier.FootnoteReference : StyleIdentifier.EndnoteReference);
		InsertNode(footnote);
		Paragraph paragraph = new Paragraph(x232be220f517f721);
		paragraph.ParagraphFormat.StyleIdentifier = (flag ? StyleIdentifier.FootnoteText : StyleIdentifier.EndnoteText);
		footnote.Paragraphs.Add(paragraph);
		SpecialChar specialChar = new SpecialChar(x232be220f517f721, '\u0002', new xeedad81aaed42a76());
		specialChar.Font.StyleIdentifier = (flag ? StyleIdentifier.FootnoteReference : StyleIdentifier.EndnoteReference);
		paragraph.AppendChild(specialChar);
		if (x0d299f323d241756.x5959bccb67bbf051(footnoteText))
		{
			Node node = x5b1159568297e3a9;
			MoveTo(paragraph);
			Write(" ");
			Write(footnoteText);
			x5b1159568297e3a9 = node;
		}
		return footnote;
	}

	public Shape InsertImage(Image image)
	{
		return InsertImage(image, -1.0, -1.0);
	}

	public Shape InsertImage(string fileName)
	{
		return InsertImage(fileName, -1.0, -1.0);
	}

	public Shape InsertImage(Stream stream)
	{
		return InsertImage(stream, -1.0, -1.0);
	}

	public Shape InsertImage(byte[] imageBytes)
	{
		return InsertImage(imageBytes, -1.0, -1.0);
	}

	public Shape InsertImage(Image image, double width, double height)
	{
		return InsertImage(image, RelativeHorizontalPosition.Column, 0.0, RelativeVerticalPosition.Paragraph, 0.0, width, height, WrapType.Inline);
	}

	public Shape InsertImage(string fileName, double width, double height)
	{
		return InsertImage(fileName, RelativeHorizontalPosition.Column, 0.0, RelativeVerticalPosition.Paragraph, 0.0, width, height, WrapType.Inline);
	}

	public Shape InsertImage(Stream stream, double width, double height)
	{
		return InsertImage(stream, RelativeHorizontalPosition.Column, 0.0, RelativeVerticalPosition.Paragraph, 0.0, width, height, WrapType.Inline);
	}

	public Shape InsertImage(byte[] imageBytes, double width, double height)
	{
		return InsertImage(imageBytes, RelativeHorizontalPosition.Column, 0.0, RelativeVerticalPosition.Paragraph, 0.0, width, height, WrapType.Inline);
	}

	public Shape InsertImage(Image image, RelativeHorizontalPosition horzPos, double left, RelativeVerticalPosition vertPos, double top, double width, double height, WrapType wrapType)
	{
		if (image == null)
		{
			throw new ArgumentNullException("image");
		}
		using MemoryStream memoryStream = new MemoryStream();
		x3cd5d648729cd9b6.x367bb145e7fa9226(image, memoryStream);
		return InsertImage(memoryStream, horzPos, left, vertPos, top, width, height, wrapType);
	}

	public Shape InsertImage(string fileName, RelativeHorizontalPosition horzPos, double left, RelativeVerticalPosition vertPos, double top, double width, double height, WrapType wrapType)
	{
		x0d299f323d241756.x48501aec8e48c869(fileName, "fileName");
		if (Document.ResourceLoadingCallback != null)
		{
			ResourceLoadingArgs resourceLoadingArgs = new ResourceLoadingArgs("", fileName, ResourceType.Image);
			switch (Document.ResourceLoadingCallback.ResourceLoading(resourceLoadingArgs))
			{
			case ResourceLoadingAction.Skip:
				return null;
			case ResourceLoadingAction.UserProvided:
				return InsertImage(resourceLoadingArgs.xd378208b5267f7e2(), horzPos, left, vertPos, top, width, height, wrapType);
			default:
				return null;
			case ResourceLoadingAction.Default:
				break;
			}
		}
		using Stream stream = xed747ca236d86aa0.xb93ba02d7ec640e0(fileName);
		return InsertImage(stream, horzPos, left, vertPos, top, width, height, wrapType);
	}

	public Shape InsertImage(Stream stream, RelativeHorizontalPosition horzPos, double left, RelativeVerticalPosition vertPos, double top, double width, double height, WrapType wrapType)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		byte[] imageBytes = x0d299f323d241756.xa0aed4cd3b3d5d92(stream);
		return InsertImage(imageBytes, horzPos, left, vertPos, top, width, height, wrapType);
	}

	public Shape InsertImage(byte[] imageBytes, RelativeHorizontalPosition horzPos, double left, RelativeVerticalPosition vertPos, double top, double width, double height, WrapType wrapType)
	{
		if (imageBytes == null)
		{
			throw new ArgumentNullException("imageBytes");
		}
		Shape shape = new Shape(x232be220f517f721, ShapeType.Image);
		shape.xeedad81aaed42a76 = xdbd6535b15eacda9();
		shape.ImageData.ImageBytes = imageBytes;
		shape.RelativeHorizontalPosition = horzPos;
		shape.Left = left;
		shape.RelativeVerticalPosition = vertPos;
		shape.Top = top;
		shape.WrapType = wrapType;
		InsertNode(shape);
		ImageSize imageSize = shape.ImageData.ImageSize;
		shape.x2a1d93e8568f66ed((width < 0.0) ? imageSize.WidthPoints : width, (height < 0.0) ? imageSize.HeightPoints : height);
		return shape;
	}

	public void InsertHtml(string html)
	{
		if (x65899751d73722fd())
		{
			DocumentBuilder documentBuilder = new DocumentBuilder();
			documentBuilder.InsertHtml(html);
			Write(xdc389408c5e1ae97(documentBuilder.Document.ToString(SaveFormat.Text)));
		}
		else
		{
			xc5f6f2ca0aafd220 xc5f6f2ca0aafd = new xc5f6f2ca0aafd220(Document.ResourceLoadingCallback);
			xc5f6f2ca0aafd.x06b0e25aa6ad68a9(html, this);
		}
	}

	private bool x65899751d73722fd()
	{
		bool result = false;
		if (x5b1159568297e3a9.ParentNode.NodeType == NodeType.StructuredDocumentTag)
		{
			StructuredDocumentTag structuredDocumentTag = (StructuredDocumentTag)x5b1159568297e3a9.ParentNode;
			switch (structuredDocumentTag.SdtType)
			{
			case SdtType.ComboBox:
			case SdtType.Date:
			case SdtType.PlainText:
				result = true;
				break;
			case SdtType.DropDownList:
			case SdtType.Checkbox:
				throw new InvalidOperationException("Can not insert text into this StructuredDocumentTag.");
			}
		}
		return result;
	}

	private static string xdc389408c5e1ae97(string xa34812994d16a83e)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in xa34812994d16a83e)
		{
			if (c != '\v' && c != '\n' && c != '\f' && c != '\r' && c != '\f')
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	public Cell InsertCell()
	{
		if (xdefa75d57fc6655d == null)
		{
			StartTable();
		}
		if (xdefa75d57fc6655d.xcf0e7d2892f7a07d == xcf0e7d2892f7a07d.x2d6a2917055d6f8b)
		{
			xdefa75d57fc6655d.x5e3f44647fcfb8fc();
		}
		if (xdefa75d57fc6655d.xcf0e7d2892f7a07d == xcf0e7d2892f7a07d.x2f05f7a24ceff75c)
		{
			xdefa75d57fc6655d.x2a78a52ede7f4385();
		}
		return xdefa75d57fc6655d.xcbc713eb2e22657d();
	}

	public Table StartTable()
	{
		x480924248556eb68.Push(new x8e63dd35709cb9ab(this));
		return xdefa75d57fc6655d.x35ee6077b3c26c9f();
	}

	public Table EndTable()
	{
		if (xdefa75d57fc6655d == null)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("aoaklphkfapkcaglaanlcaemlkkmnobndpingopnpjgonnnojjepkolpencacnjajnabpmhbhioblnfcjmmchmddhmkdnlbefhieampeolgfamnfjgegiklgilchjkjhjkaiojhiakoickfjijmjoedkmikkiebljjildiplbigmiinmoheneeln", 1531027613)));
		}
		Table result = xdefa75d57fc6655d.xee69ee8848255726();
		x480924248556eb68.Pop();
		return result;
	}

	public Row EndRow()
	{
		if (xdefa75d57fc6655d == null)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("eljppmaajnhagnoaenfbgnmbphdcbmkchmbdkliddhpdblgengnemlefgllfllcgbgjgflahdkhhbkohbkfihjmipedjkjkjijbkkjikdepkciglcjnldiemdilmihcnkhjnmhaochhoicooggfpccmpdhdanfkalfbbcgibifpbobgc", 1976826225)));
		}
		return xdefa75d57fc6655d.xbdbbc98113b6b783();
	}

	public BookmarkStart StartBookmark(string bookmarkName)
	{
		BookmarkStart bookmarkStart = new BookmarkStart(x232be220f517f721, bookmarkName, 0);
		InsertNode(bookmarkStart);
		return bookmarkStart;
	}

	public BookmarkEnd EndBookmark(string bookmarkName)
	{
		BookmarkEnd bookmarkEnd = new BookmarkEnd(x232be220f517f721, bookmarkName);
		InsertNode(bookmarkEnd);
		return bookmarkEnd;
	}

	internal void xd6a6fa519f3374ab(Node xda5bf54deb817e37)
	{
		CurrentParagraph.ParentNode.InsertBefore(xda5bf54deb817e37, CurrentParagraph);
	}

	public void PushFont()
	{
		xe431734ecddf91e4.Push(xdbd6535b15eacda9());
	}

	public void PopFont()
	{
		if (xe431734ecddf91e4.Count > 0)
		{
			x77184348a27ba1e6((xeedad81aaed42a76)xe431734ecddf91e4.Pop(), x692ced34f50137f2: false);
		}
	}

	internal x928b31adb20d5cc6 xb67b015f1a2f38a7(string x49515e04d4ad451f, bool x097745643e3f274b, string x11d58b056c032b03)
	{
		FieldStart start = xb03cd6cf2fed9d7f(FieldType.FieldHyperlink);
		xdfac57ec3a49a3fc xdfac57ec3a49a3fc = new xdfac57ec3a49a3fc();
		xdfac57ec3a49a3fc.x42f4c234c9358072 = x11d58b056c032b03;
		if (x097745643e3f274b)
		{
			xdfac57ec3a49a3fc.x2141cbc5929f5173 = x49515e04d4ad451f;
		}
		else
		{
			xdfac57ec3a49a3fc.x1d5cfa3bffdfb042 = x0d4d45882065c63e.xc8c8ca56669559a3(x49515e04d4ad451f);
			xdfac57ec3a49a3fc.x2141cbc5929f5173 = x0d4d45882065c63e.x358b45b4ddbfa57c(x49515e04d4ad451f);
		}
		xd2dd4bae56c47a6c(xdfac57ec3a49a3fc.ToString());
		FieldSeparator separator = x8d879f7e82ddb431(FieldType.FieldHyperlink);
		return new x928b31adb20d5cc6(start, separator, null);
	}

	internal x928b31adb20d5cc6 xb67b015f1a2f38a7(string x585da4d9795fa783, string x11d58b056c032b03)
	{
		bool flag = x0d4d45882065c63e.xbf8774d82d777b9e(x585da4d9795fa783);
		string x49515e04d4ad451f = (flag ? x0d4d45882065c63e.x358b45b4ddbfa57c(x585da4d9795fa783) : x585da4d9795fa783);
		return xb67b015f1a2f38a7(x49515e04d4ad451f, flag, x11d58b056c032b03);
	}

	internal FieldEnd xbfa3ad37f5032b4f()
	{
		return xa71e06bbe7cdb1a2(FieldType.FieldHyperlink, x5dfdce3c3b2a672a: true);
	}

	internal xeedad81aaed42a76 xdbd6535b15eacda9()
	{
		return (xeedad81aaed42a76)xd0c44e5ae0011daa.x8b61531c8ea35b85();
	}

	internal x1a78664fa10a3755 x87c38d4df0b94981()
	{
		return (x1a78664fa10a3755)CurrentParagraph.x1a78664fa10a3755.x8b61531c8ea35b85();
	}

	internal xedb0eb766e25e0c9 x79f94b97ce762fc2()
	{
		return (xedb0eb766e25e0c9)xe661c29834d8220f.x8b61531c8ea35b85();
	}

	internal xf8cef531dae89ea3 x292670b7c408ce0a()
	{
		return (xf8cef531dae89ea3)xede608e9bc344cf9.x8b61531c8ea35b85();
	}

	private void xf69e3cf19f0625a0(string xb41faee6912a2313, bool x567002813fadecac)
	{
		if (xb41faee6912a2313 == null)
		{
			throw new ArgumentNullException("text");
		}
		string text = xb7dbd7bb3ed97d5b.x6007a6ce1e15de6a(xb41faee6912a2313);
		int num = 0;
		while (num <= text.Length)
		{
			int num2 = text.IndexOf('\r', num);
			if (num2 != -1)
			{
				int num3 = num2 - num;
				if (num3 > 0)
				{
					x111a0f8160906fa7(text.Substring(num, num3));
				}
				InsertParagraph();
				num = num2 + 1;
				continue;
			}
			int num4 = text.Length - num;
			if (num4 > 0)
			{
				x111a0f8160906fa7(text.Substring(num, num4));
			}
			if (x567002813fadecac)
			{
				InsertParagraph();
			}
			break;
		}
	}

	private Run x111a0f8160906fa7(string xb41faee6912a2313)
	{
		Run run = new Run(x232be220f517f721, xb41faee6912a2313, xdbd6535b15eacda9());
		InsertNode(run);
		return run;
	}

	public void InsertNode(Node node)
	{
		if (xdefa75d57fc6655d != null && xdefa75d57fc6655d.xcf0e7d2892f7a07d == xcf0e7d2892f7a07d.x2d6a2917055d6f8b)
		{
			EndTable();
		}
		if (IsAtEndOfParagraph)
		{
			CurrentParagraph.AppendChild(node);
		}
		else
		{
			x5b1159568297e3a9.ParentNode.InsertBefore(node, x5b1159568297e3a9);
		}
	}

	internal void x421182dbe4852822(SectionStart x87221e340ea6bd08)
	{
		x0792239c9312065a(x291fabf8727e1df6: true);
		InsertParagraph();
		xfc72d4c9b765cad7 sectPr = (xfc72d4c9b765cad7)CurrentSection.xfc72d4c9b765cad7.x8b61531c8ea35b85();
		Section section = new Section(x232be220f517f721, sectPr);
		section.PageSetup.SectionStart = x87221e340ea6bd08;
		section.AppendChild(new Body(x232be220f517f721));
		x232be220f517f721.InsertAfter(section, CurrentSection);
		section.Body.x2729186e1a0b4aeb(CurrentParagraph, null, section.Body.LastChild);
	}

	private FieldStart xb03cd6cf2fed9d7f(FieldType x77ce91e5324df734)
	{
		FieldStart fieldStart = new FieldStart(x232be220f517f721, xdbd6535b15eacda9(), x77ce91e5324df734);
		InsertNode(fieldStart);
		return fieldStart;
	}

	private Run xd2dd4bae56c47a6c(string x0e59413709b18038)
	{
		return x111a0f8160906fa7(x0e59413709b18038);
	}

	private FieldEnd xa71e06bbe7cdb1a2(FieldType x77ce91e5324df734, bool x5dfdce3c3b2a672a)
	{
		FieldEnd fieldEnd = new FieldEnd(x232be220f517f721, xdbd6535b15eacda9(), x77ce91e5324df734, x5dfdce3c3b2a672a);
		InsertNode(fieldEnd);
		return fieldEnd;
	}

	private FieldSeparator x8d879f7e82ddb431(FieldType x77ce91e5324df734)
	{
		FieldSeparator fieldSeparator = new FieldSeparator(x232be220f517f721, xdbd6535b15eacda9(), x77ce91e5324df734);
		InsertNode(fieldSeparator);
		return fieldSeparator;
	}

	private FormField x4fe6838d3feb674b(Node x9ee886d5d4b7e3fe)
	{
		FormField formField = new FormField(x232be220f517f721, new x58bf2a36f9adf9a9(), xdbd6535b15eacda9());
		CurrentParagraph.InsertBefore(formField, x9ee886d5d4b7e3fe);
		return formField;
	}

	private bool x0792239c9312065a(bool x291fabf8727e1df6)
	{
		bool flag = CurrentParagraph.ParentStory.StoryType != StoryType.MainText;
		bool flag2 = xdefa75d57fc6655d != null;
		if (x291fabf8727e1df6)
		{
			if (flag)
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("enlnpocojpjogpapephpgpoppjfafomahodbjokbinbccoicbopckigdlnndmmeegmleohcfnmjfnlaggmhghmogelfhplmhnldilkkihkbjagijpjpjmkgkmjnkfjelmjlloecmkjjmnjanjjhnfjoniifoaimoohdpgdkpcibaghiancpaohgbpgnbjgecbclclgcdmfjdbgaedghecboecgffagmfifdgifkgmfbhoaih", 2012011409)));
			}
			if (flag2)
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cdabnehbhfobeffccfmcefddnpjddebefeiehepegdgfaenfpdegiokgjdchkcjhecaimngilcoilbfjecmjfcdkcbkknbbllbiljaplfagmolmmnpdnkalnkpbodpiokppomkgpcpnpepeagplajocbbojbpnachjhcfnocbjfdcomdmmdekmkebnbfhmifnipf", 667881455)));
			}
		}
		if (!x291fabf8727e1df6)
		{
			if (!flag)
			{
				return !flag2;
			}
			return false;
		}
		return true;
	}

	private Row xeb3e9f2179b3f2cb(int x5eb83ef8cc1e4dd4, int x78a7603cacf2ae22)
	{
		NodeCollection childNodes = CurrentStory.GetChildNodes(NodeType.Table, isDeep: true);
		Table table = (Table)childNodes[x5eb83ef8cc1e4dd4];
		if (table == null)
		{
			throw new ArgumentOutOfRangeException("tableIndex");
		}
		Row row = (Row)table.GetChild(NodeType.Row, x78a7603cacf2ae22, isDeep: false);
		if (row == null)
		{
			throw new ArgumentOutOfRangeException("rowIndex");
		}
		return row;
	}

	internal void x77184348a27ba1e6(xeedad81aaed42a76 x789564759d365819, bool x692ced34f50137f2)
	{
		xd0c44e5ae0011daa = (x692ced34f50137f2 ? ((xeedad81aaed42a76)x789564759d365819.x8b61531c8ea35b85()) : x789564759d365819);
	}

	private object x93e461c176ca1e50(int x6cc530a2cd983862)
	{
		return xd0c44e5ae0011daa.xf7866f89640a29a3(x6cc530a2cd983862);
	}

	object xf5ecf429e74b1c04.x9bd0b4c41657450b(int x6cc530a2cd983862)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x93e461c176ca1e50
		return this.x93e461c176ca1e50(x6cc530a2cd983862);
	}

	private void x9939815f86bdcfc3(int xc0c4c459c6ccbd00, out int xba08ce632055a1d9, out object xbcea506a33cf9111)
	{
		xba08ce632055a1d9 = xd0c44e5ae0011daa.xf15263674eb297bb(xc0c4c459c6ccbd00);
		xbcea506a33cf9111 = xd0c44e5ae0011daa.x6d3720b962bd3112(xc0c4c459c6ccbd00);
	}

	void xf5ecf429e74b1c04.x16b3a875e7cc38ed(int xc0c4c459c6ccbd00, out int xba08ce632055a1d9, out object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x9939815f86bdcfc3
		this.x9939815f86bdcfc3(xc0c4c459c6ccbd00, out xba08ce632055a1d9, out xbcea506a33cf9111);
	}

	private object xa49e661f5cc91e49(int x6cc530a2cd983862)
	{
		object obj = Font.Style.x61d8cd76508e76c3(x6cc530a2cd983862, x9ee6c2f047893ddc: false);
		if (obj != null)
		{
			return obj;
		}
		return ParagraphFormat.Style.x61d8cd76508e76c3(x6cc530a2cd983862, x9ee6c2f047893ddc: true);
	}

	object xf5ecf429e74b1c04.x2685f947206319cf(int x6cc530a2cd983862)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa49e661f5cc91e49
		return this.xa49e661f5cc91e49(x6cc530a2cd983862);
	}

	private void x09376e92b9e1f394(int x6cc530a2cd983862, object xbcea506a33cf9111)
	{
		xd0c44e5ae0011daa.xae20093bed1e48a8(x6cc530a2cd983862, xbcea506a33cf9111);
	}

	void xf5ecf429e74b1c04.xd00aa8389522ce53(int x6cc530a2cd983862, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x09376e92b9e1f394
		this.x09376e92b9e1f394(x6cc530a2cd983862, xbcea506a33cf9111);
	}

	private void x69045f836de92891()
	{
		xd0c44e5ae0011daa.ClearAttrs();
	}

	void xf5ecf429e74b1c04.xe80983f2918b2568()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x69045f836de92891
		this.x69045f836de92891();
	}

	private object x38350614ed832813(int xba08ce632055a1d9)
	{
		return xe661c29834d8220f.xf7866f89640a29a3(xba08ce632055a1d9);
	}

	object x8f424b921df6c21a.xdc39376725eb2ee7(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x38350614ed832813
		return this.x38350614ed832813(xba08ce632055a1d9);
	}

	private object x9859e656c862dafa(int xba08ce632055a1d9)
	{
		return xe661c29834d8220f.xdafa1f94b023b665(xba08ce632055a1d9);
	}

	object x8f424b921df6c21a.x75cd79b986a36485(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x9859e656c862dafa
		return this.x9859e656c862dafa(xba08ce632055a1d9);
	}

	private void xc909a3bd082ef02c(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		xe661c29834d8220f.xae20093bed1e48a8(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	void x8f424b921df6c21a.x422daa4ae9c73301(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xc909a3bd082ef02c
		this.xc909a3bd082ef02c(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	private void x043911e06761033b()
	{
		xe661c29834d8220f.x90c1c4b3135f8e2d();
	}

	void x8f424b921df6c21a.x90c1c4b3135f8e2d()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x043911e06761033b
		this.x043911e06761033b();
	}

	private void x4c76b6f836b082bc()
	{
		xe661c29834d8220f = xedb0eb766e25e0c9.xf5b6851196debf5a();
	}

	void x8f424b921df6c21a.x7ac658ee35724fbe()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x4c76b6f836b082bc
		this.x4c76b6f836b082bc();
	}

	private object x175b9f6288698c0f(int xba08ce632055a1d9)
	{
		return xede608e9bc344cf9.xf7866f89640a29a3(xba08ce632055a1d9);
	}

	object xf516b6b0dd7e0d14.x34f1b0fbc88f0b8a(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x175b9f6288698c0f
		return this.x175b9f6288698c0f(xba08ce632055a1d9);
	}

	private object x27adc70014c00091(int xba08ce632055a1d9)
	{
		return xede608e9bc344cf9.xdafa1f94b023b665(xba08ce632055a1d9);
	}

	object xf516b6b0dd7e0d14.x4c5c531cd5714601(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x27adc70014c00091
		return this.x27adc70014c00091(xba08ce632055a1d9);
	}

	private void xc5014b3eeb127093(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		xede608e9bc344cf9.xae20093bed1e48a8(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	void xf516b6b0dd7e0d14.xad3f776eaf7a915d(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xc5014b3eeb127093
		this.xc5014b3eeb127093(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	private void x3ed91c4f1eb96524()
	{
		xede608e9bc344cf9.ClearAttrs();
	}

	void xf516b6b0dd7e0d14.xff94bebb1f5a007f()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x3ed91c4f1eb96524
		this.x3ed91c4f1eb96524();
	}
}
