using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using Aspose.Words.Saving;
using Aspose.Words.Tables;
using x381fb081d11d6275;
using x6c95d9cf46ff5f25;
using xe9865c3fb834da49;
using xf989f31a236ff98c;
using xf9a9481c3f63a419;

namespace xce0136f05681c5e9;

internal class xe194915df8ce65e3 : DocumentVisitor
{
	private const string x74837bbcb83c328e = "DocumentPartStream cannot be specified. When saving to EPUB format that is a container based on HTML, all document parts must be encapsulated into the output package.";

	private const string x5fe1741045613564 = "Document part file cannot be written. When saving the document either output file name should be specified or custom streams should be provided via DocumentPartSavingCallback. Please see documentation for details.";

	private readonly Document xd1424e1a0bb4a72b;

	private readonly string xb60ae86f79aa8262;

	private readonly Stream x83c94614e752b228;

	private readonly HtmlSaveOptions x1cb867f3d40f3203;

	private readonly x6868017fd9012087 x226a09a3303fed2e;

	private readonly x1cfc9afea06d5324 xb4ae0d7648678478;

	private readonly xc1973d08dacd6dfc x89e7ffdaa1e0fd25;

	private int x07039a23e5a61b4b;

	private readonly ArrayList x178ddd705e9f9e3a;

	private x49ab465c82380c81 x60b200fefb123ee4;

	private int xca0e746c514dd7e3;

	private readonly IDictionary x0ff58d9b755afe0e;

	private bool x4a2d5506d970bb38;

	private string xe088d3cf86c43aa1;

	private string xae9a3fc00c56b761;

	private string x4dcb8099f98de824;

	private static readonly Regex xf331e4940d063ac6 = new Regex("[^-_a-zA-Z0-9 ]*", RegexOptions.Singleline);

	internal x49ab465c82380c81 x87530f3910ac4212 => (x49ab465c82380c81)x178ddd705e9f9e3a[xca0e746c514dd7e3];

	internal x49ab465c82380c81 x35c77a54267dd680
	{
		get
		{
			if (xca0e746c514dd7e3 > 0)
			{
				return (x49ab465c82380c81)x178ddd705e9f9e3a[xca0e746c514dd7e3 - 1];
			}
			return null;
		}
	}

	private bool xa2c6a556769b86d3 => x07039a23e5a61b4b > 0;

	internal xe194915df8ce65e3(Document document, string fileName, Stream mainOutputStream, HtmlSaveOptions saveOptions, x6868017fd9012087 fieldWriter, x1cfc9afea06d5324 navigationPointCollector, xc1973d08dacd6dfc subsidiaryContentPartHandler)
	{
		xd1424e1a0bb4a72b = document;
		xb60ae86f79aa8262 = fileName;
		x83c94614e752b228 = mainOutputStream;
		x1cb867f3d40f3203 = saveOptions;
		x226a09a3303fed2e = fieldWriter;
		xb4ae0d7648678478 = navigationPointCollector;
		x89e7ffdaa1e0fd25 = subsidiaryContentPartHandler;
		x178ddd705e9f9e3a = new ArrayList();
		x0ff58d9b755afe0e = xd51c34d05311eee3.xdb04a310bbb29cff();
		x8ad1d37302506e09();
		xb1312d435a0ebbc2();
		xd1424e1a0bb4a72b.Accept(this);
		xd45e9bc773fcfa8b();
		xca0e746c514dd7e3 = -1;
	}

	internal bool xa16cce94188a69d4()
	{
		x259ca409802dc39e();
		int num = xca0e746c514dd7e3 + 1;
		bool flag = num < x178ddd705e9f9e3a.Count;
		if (flag)
		{
			xca0e746c514dd7e3 = num;
			xf1f873324be80b03();
		}
		else
		{
			xca0e746c514dd7e3 = -1;
		}
		return flag;
	}

	internal bool xb96865188f6d0634()
	{
		return xca0e746c514dd7e3 + 1 < x178ddd705e9f9e3a.Count;
	}

	private void xf1f873324be80b03()
	{
		x49ab465c82380c81 x49ab465c82380c82 = x87530f3910ac4212;
		if (xcf7bda835bcee807())
		{
			x49ab465c82380c82.x3d213ffad4d30370 = new x3d213ffad4d30370(new MemoryStream(), keepStreamOpen: true);
		}
		else if (x49ab465c82380c82.x3d213ffad4d30370 == null)
		{
			if (!x4a2d5506d970bb38)
			{
				throw new InvalidOperationException("Document part file cannot be written. When saving the document either output file name should be specified or custom streams should be provided via DocumentPartSavingCallback. Please see documentation for details.");
			}
			x49ab465c82380c82.x3d213ffad4d30370 = new x3d213ffad4d30370(File.Create(Path.Combine(xae9a3fc00c56b761, x49ab465c82380c82.xfc6140fa15b50714)), keepStreamOpen: false);
		}
	}

	internal void x259ca409802dc39e()
	{
		if (xca0e746c514dd7e3 >= 0)
		{
			x49ab465c82380c81 x49ab465c82380c82 = x87530f3910ac4212;
			x3d213ffad4d30370 x3d213ffad4d = x49ab465c82380c82.x3d213ffad4d30370;
			if (x89e7ffdaa1e0fd25 != null)
			{
				byte[] data = x0d299f323d241756.xa0aed4cd3b3d5d92(x3d213ffad4d.x59aa197935be8c77());
				x32626c54bb4e8c9e xd7e5673853e47af = new x32626c54bb4e8c9e(x1cb867f3d40f3203.Encoding, x1cb867f3d40f3203.xea0d040d38d75a91, x49ab465c82380c82.xfc6140fa15b50714, data);
				x89e7ffdaa1e0fd25.xbc4db1b9481c1d31(xd7e5673853e47af);
			}
			x3d213ffad4d?.x14e5354973c7740e();
			x49ab465c82380c82.x3d213ffad4d30370 = null;
			if (xb4ae0d7648678478 != null)
			{
				xb4ae0d7648678478.x8617c5c184975779(x49ab465c82380c82.xfc6140fa15b50714);
			}
		}
	}

	internal x49ab465c82380c81 xc928e65fed6bfe21(string xd17ec8f278d25c87)
	{
		return (x49ab465c82380c81)x0ff58d9b755afe0e[xd17ec8f278d25c87];
	}

	public override VisitorAction VisitSectionStart(Section section)
	{
		if (section.x65c77554c620f590)
		{
			x60b200fefb123ee4 = new x49ab465c82380c81();
			x60b200fefb123ee4.x7276106b7b402510 = section;
			x178ddd705e9f9e3a.Add(x60b200fefb123ee4);
		}
		else if (!base.x991897f13cf6aadc)
		{
			DocumentSplitCriteria documentSplitCriteria = x1cb867f3d40f3203.DocumentSplitCriteria;
			bool flag = (documentSplitCriteria & DocumentSplitCriteria.SectionBreak) != 0;
			if (!flag && (documentSplitCriteria & (DocumentSplitCriteria.PageBreak | DocumentSplitCriteria.ColumnBreak)) != 0)
			{
				SectionStart sectionStart = section.PageSetup.SectionStart;
				flag = ((documentSplitCriteria & DocumentSplitCriteria.PageBreak) != 0 && (sectionStart == SectionStart.NewPage || sectionStart == SectionStart.OddPage || sectionStart == SectionStart.EvenPage)) || ((documentSplitCriteria & DocumentSplitCriteria.ColumnBreak) != 0 && sectionStart == SectionStart.NewColumn);
			}
			if (flag)
			{
				x64f9593c54a8693b(section, 0, section, 0);
			}
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitParagraphStart(Paragraph paragraph)
	{
		if (!base.x991897f13cf6aadc && !xa2c6a556769b86d3)
		{
			DocumentSplitCriteria documentSplitCriteria = x1cb867f3d40f3203.DocumentSplitCriteria;
			if ((documentSplitCriteria & (DocumentSplitCriteria.PageBreak | DocumentSplitCriteria.HeadingParagraph)) != 0)
			{
				ParagraphFormat paragraphFormat = paragraph.ParagraphFormat;
				if (((documentSplitCriteria & DocumentSplitCriteria.PageBreak) != 0 && paragraphFormat.PageBreakBefore) || ((documentSplitCriteria & DocumentSplitCriteria.HeadingParagraph) != 0 && xc84bd5b4e08da5b2(paragraphFormat) && paragraph.xb0c453ec73ede97e().Trim().Length != 0))
				{
					x64f9593c54a8693b(paragraph, 0, paragraph, 0);
				}
			}
		}
		return VisitorAction.Continue;
	}

	private bool xc84bd5b4e08da5b2(ParagraphFormat xefceefc9504671df)
	{
		int x8301ab10c226b0c = xefceefc9504671df.x8301ab10c226b0c2;
		if (x8301ab10c226b0c >= 1 && x8301ab10c226b0c <= 9)
		{
			return x8301ab10c226b0c <= x1cb867f3d40f3203.DocumentSplitHeadingLevel;
		}
		return false;
	}

	public override VisitorAction VisitRun(Run run)
	{
		xbd8685c40137d1b5(run);
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitSpecialChar(SpecialChar specialChar)
	{
		xbd8685c40137d1b5(specialChar);
		return VisitorAction.Continue;
	}

	private void xbd8685c40137d1b5(Inline x31545d7c306a55e4)
	{
		if (base.x991897f13cf6aadc || xa2c6a556769b86d3)
		{
			return;
		}
		DocumentSplitCriteria documentSplitCriteria = x1cb867f3d40f3203.DocumentSplitCriteria;
		if ((documentSplitCriteria & (DocumentSplitCriteria.PageBreak | DocumentSplitCriteria.ColumnBreak)) == 0)
		{
			return;
		}
		string text = x31545d7c306a55e4.GetText();
		int length = text.Length;
		for (int i = 0; i < length; i++)
		{
			switch (text[i])
			{
			case '\f':
				if ((documentSplitCriteria & DocumentSplitCriteria.PageBreak) != 0)
				{
					x7e7ef002aba8a900(x31545d7c306a55e4, i, length);
				}
				break;
			case '\u000e':
				if ((documentSplitCriteria & DocumentSplitCriteria.ColumnBreak) != 0)
				{
					x7e7ef002aba8a900(x31545d7c306a55e4, i, length);
				}
				break;
			}
		}
	}

	public override VisitorAction VisitBookmarkStart(BookmarkStart bookmarkStart)
	{
		if (!base.x991897f13cf6aadc)
		{
			x0ff58d9b755afe0e[bookmarkStart.Name] = x60b200fefb123ee4;
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitBodyStart(Body body)
	{
		x6944d217299ddb8c();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitBodyEnd(Body body)
	{
		xb1312d435a0ebbc2();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitTableStart(Table table)
	{
		xb1312d435a0ebbc2();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitTableEnd(Table table)
	{
		x6944d217299ddb8c();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitShapeStart(Shape shape)
	{
		xb1312d435a0ebbc2();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitShapeEnd(Shape shape)
	{
		x6944d217299ddb8c();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFootnoteStart(Footnote footnote)
	{
		xb1312d435a0ebbc2();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFootnoteEnd(Footnote footnote)
	{
		x6944d217299ddb8c();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentStart(Comment comment)
	{
		xb1312d435a0ebbc2();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitCommentEnd(Comment comment)
	{
		x6944d217299ddb8c();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldStart(FieldStart fieldStart)
	{
		x75be698bf0c3a5c5();
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldSeparator(FieldSeparator fieldSeparator)
	{
		if (!x226a09a3303fed2e.xa29fb79ffcf5f9ba(fieldSeparator.FieldType))
		{
			x45277e5380a187db();
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitFieldEnd(FieldEnd fieldEnd)
	{
		if (fieldEnd.HasSeparator)
		{
			if (x226a09a3303fed2e.xa29fb79ffcf5f9ba(fieldEnd.FieldType))
			{
				x45277e5380a187db();
			}
		}
		else
		{
			x45277e5380a187db();
		}
		return VisitorAction.Continue;
	}

	private void x7e7ef002aba8a900(Node xda5bf54deb817e37, int xc0c4c459c6ccbd00, int x10f4d88af727adbc)
	{
		Node node = xda5bf54deb817e37;
		int num = xc0c4c459c6ccbd00 + 1;
		if (num >= x10f4d88af727adbc)
		{
			node = xda5bf54deb817e37.NextSibling;
			num = 0;
			Node node2 = xda5bf54deb817e37;
			while (node == null && (node2 = node2.ParentNode) != null)
			{
				node = node2.NextSibling;
			}
		}
		x64f9593c54a8693b(xda5bf54deb817e37, xc0c4c459c6ccbd00, node, num);
	}

	private void x64f9593c54a8693b(Node x58ec2292f54d48e1, int xd9cc3b5cba329795, Node x19efa92591d228ae, int x271d02c92e349dfc)
	{
		bool flag = true;
		if (xd9cc3b5cba329795 == 0 && x60b200fefb123ee4.xe4790ba9e7571be3 == 0)
		{
			Node xde860fba55c41d = x58ec2292f54d48e1;
			CompositeNode parentNode = x58ec2292f54d48e1.ParentNode;
			while (parentNode != null && x6a0522c18343ba9e(parentNode, xde860fba55c41d))
			{
				if (parentNode == x60b200fefb123ee4.x7276106b7b402510)
				{
					flag = false;
					break;
				}
				xde860fba55c41d = parentNode;
				parentNode = parentNode.ParentNode;
			}
		}
		if (flag)
		{
			x60b200fefb123ee4.x623e5421ca876274 = x58ec2292f54d48e1;
			x60b200fefb123ee4.x71a8a0811812e457 = xd9cc3b5cba329795;
			if (x19efa92591d228ae != null)
			{
				xd45e9bc773fcfa8b();
				x49ab465c82380c81 x49ab465c82380c82 = new x49ab465c82380c81();
				x49ab465c82380c82.x7276106b7b402510 = x19efa92591d228ae;
				x49ab465c82380c82.xe4790ba9e7571be3 = x271d02c92e349dfc;
				x60b200fefb123ee4 = x49ab465c82380c82;
				x178ddd705e9f9e3a.Add(x60b200fefb123ee4);
			}
		}
	}

	private static bool x6a0522c18343ba9e(CompositeNode xb6a159a84cb992d6, Node xde860fba55c41d76)
	{
		bool result = true;
		for (Node node = xb6a159a84cb992d6.FirstChild; node != xde860fba55c41d76; node = node.NextSibling)
		{
			NodeType nodeType = node.NodeType;
			if (nodeType == NodeType.Table || nodeType == NodeType.Paragraph || nodeType == NodeType.GroupShape || nodeType == NodeType.Shape || nodeType == NodeType.Run || nodeType == NodeType.SpecialChar || nodeType == NodeType.DrawingML)
			{
				result = false;
				break;
			}
		}
		return result;
	}

	private void xd45e9bc773fcfa8b()
	{
		bool flag = x178ddd705e9f9e3a.Count == 1;
		x60b200fefb123ee4.xfc6140fa15b50714 = (flag ? $"{xe088d3cf86c43aa1}{x4dcb8099f98de824}" : $"{xe088d3cf86c43aa1}-{x178ddd705e9f9e3a.Count - 1:D2}{x4dcb8099f98de824}");
		x3d213ffad4d30370 x3d213ffad4d = null;
		if (x1cb867f3d40f3203.DocumentPartSavingCallback != null)
		{
			DocumentPartSavingArgs documentPartSavingArgs = new DocumentPartSavingArgs(xd1424e1a0bb4a72b, x60b200fefb123ee4.xfc6140fa15b50714);
			x1cb867f3d40f3203.DocumentPartSavingCallback.DocumentPartSaving(documentPartSavingArgs);
			if (xcf7bda835bcee807() && documentPartSavingArgs.x3477a684b2bbe7b0)
			{
				throw new InvalidOperationException("DocumentPartStream cannot be specified. When saving to EPUB format that is a container based on HTML, all document parts must be encapsulated into the output package.");
			}
			x60b200fefb123ee4.xfc6140fa15b50714 = documentPartSavingArgs.DocumentPartFileName;
			if (documentPartSavingArgs.x3477a684b2bbe7b0)
			{
				x3d213ffad4d = documentPartSavingArgs.xd9984d5750dc6ac8();
			}
		}
		if (x3d213ffad4d == null && flag && x83c94614e752b228 != null)
		{
			x3d213ffad4d = new x3d213ffad4d30370(x83c94614e752b228, keepStreamOpen: true);
		}
		x60b200fefb123ee4.x3d213ffad4d30370 = x3d213ffad4d;
	}

	private void x8ad1d37302506e09()
	{
		x4a2d5506d970bb38 = x0d299f323d241756.x5959bccb67bbf051(xb60ae86f79aa8262);
		if (x4a2d5506d970bb38)
		{
			xe088d3cf86c43aa1 = Path.GetFileNameWithoutExtension(xb60ae86f79aa8262);
			xae9a3fc00c56b761 = Path.GetDirectoryName(xb60ae86f79aa8262);
			x4dcb8099f98de824 = Path.GetExtension(xb60ae86f79aa8262);
		}
		else
		{
			string input = xd1424e1a0bb4a72b.BuiltInDocumentProperties.Title.Trim();
			string text = xf331e4940d063ac6.Replace(input, string.Empty);
			xe088d3cf86c43aa1 = (x0d299f323d241756.x5959bccb67bbf051(text) ? text : "untitled");
		}
		if (!x0d299f323d241756.x5959bccb67bbf051(x4dcb8099f98de824))
		{
			x4dcb8099f98de824 = ".html";
		}
	}

	private void xb1312d435a0ebbc2()
	{
		x07039a23e5a61b4b++;
	}

	private void x6944d217299ddb8c()
	{
		x07039a23e5a61b4b--;
	}

	private bool xcf7bda835bcee807()
	{
		return x89e7ffdaa1e0fd25 != null;
	}
}
