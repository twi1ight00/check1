using System;
using System.Collections;
using Aspose;
using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x1495530f35d79681;
using x28925c9b27b37a46;
using x38a89dee67fc7a16;
using x6c95d9cf46ff5f25;
using x7c7a1dceb600404e;
using x909757d9fd2dd6ae;
using xb92b7270f78a4e8d;
using xf84318f571847613;
using xfbd1009a0cbb9842;
using xfc5388ad7dff404f;

namespace x79490184cecf12a1;

internal abstract class x11e1346c12ead315 : xdfce7f4f687956d7, xf721f41ceaf253ab
{
	private readonly xada461b17cdccac0 x7e24ae8042d3886b;

	private readonly xa2f1c3dcbd86f20a x336788c6a46ed27b;

	private x9ea8b270a83f04a0 xc3723d392789e04d;

	private readonly Stack x01670783beff2a53 = new Stack();

	private readonly Hashtable x1b214b38bd4b02f1 = new Hashtable();

	private x4334bc0eccfa7548 x9f4ab3ec936993da;

	private readonly ArrayList xae41d23dbab1f17a = new ArrayList();

	public override x3c85359e1389ad43 x3bcd232d01c14846 => xc3723d392789e04d;

	internal override bool x099487305e4675db
	{
		get
		{
			throw new InvalidOperationException("Not expected to call this.");
		}
	}

	internal override bool x3ee7f4bad5fbb600
	{
		get
		{
			throw new InvalidOperationException("Not expected to call this.");
		}
	}

	internal override bool x325f1926b78ae5cd => true;

	protected xada461b17cdccac0 x39c7aeeec1af9dd0 => x7e24ae8042d3886b;

	internal xa2f1c3dcbd86f20a x2a0bb2f6650f6a43 => x336788c6a46ed27b;

	protected x11e1346c12ead315(xada461b17cdccac0 package, xa2f1c3dcbd86f20a documentPart, DocumentBase doc, LoadOptions loadOptions)
		: base(doc, loadOptions, WarningSource.Docx)
	{
		x7e24ae8042d3886b = package;
		x336788c6a46ed27b = documentPart;
		xc3723d392789e04d = new x9ea8b270a83f04a0(x336788c6a46ed27b, loadOptions.WarningCallback, WarningSource.Docx);
	}

	internal void x06b0e25aa6ad68a9()
	{
		x5f1c415523b4e090.x06b0e25aa6ad68a9(this);
		xa193b87bb5ca0dde.x06b0e25aa6ad68a9(this);
		xd8ed588de8ef8335.x06b0e25aa6ad68a9(this);
		x703bc0db5f036bb2.x06b0e25aa6ad68a9(this);
		xaf984aed49d14880.x06b0e25aa6ad68a9(this);
		x24d47ad0d19873c2.x06b0e25aa6ad68a9(this);
		x9f4ab3ec936993da = new x4334bc0eccfa7548(this);
		DoRead();
		x7c0f41ccd8aba612();
		xffef7962a5775be8();
	}

	internal void xffef7962a5775be8()
	{
		if (xae41d23dbab1f17a.Count > 0)
		{
			for (int i = 0; i < xae41d23dbab1f17a.Count; i++)
			{
				x7c5f42d7c853beff x7c5f42d7c853beff = (x7c5f42d7c853beff)xae41d23dbab1f17a[i];
				Document x0e86d5d481d0b = x7c5f42d7c853beff.x0e86d5d481d0b364;
				Paragraph xf17dae34668ddbd = x7c5f42d7c853beff.xf17dae34668ddbd9;
				ImportFormatMode xcea1c437a94c4d = x7c5f42d7c853beff.xcea1c437a94c4d02;
				xee49c02028e1980c(x0e86d5d481d0b, xf17dae34668ddbd, xcea1c437a94c4d);
				x7e263f21a73a027a x5f36ad26e64b91c = new x7e263f21a73a027a(x0e86d5d481d0b.FirstSection.Body.FirstChild, x0e86d5d481d0b.LastSection.Body.LastChild);
				xa645a74f32ce7b5e xcbf24c118ac8aa0b = new xa645a74f32ce7b5e(x0e86d5d481d0b, xf17dae34668ddbd.Document, xcea1c437a94c4d);
				x0a28863c804404d7.x775521112ede5e6f(x5f36ad26e64b91c, xf17dae34668ddbd, xcbf24c118ac8aa0b);
				x63f7194c38071ef2(x0e86d5d481d0b, xf17dae34668ddbd, xcea1c437a94c4d);
				xf17dae34668ddbd.Remove();
				xbbf9a1ead81dd3a1(WarningType.DataLossCategory, WarningSource.Docx, "The altChunk is replaced with its content.");
			}
			xae41d23dbab1f17a.Clear();
		}
	}

	private static void xee49c02028e1980c(Document x562af9054b809d0f, Paragraph x0393bee8ef666351, ImportFormatMode xbddb8b51223ce9e8)
	{
		NodeImporter x6c0bee6311fedef = new NodeImporter(x562af9054b809d0f, x0393bee8ef666351.Document, xbddb8b51223ce9e8);
		Section section = (Section)x0393bee8ef666351.GetAncestor(NodeType.Section);
		if (x562af9054b809d0f.FirstSection.HeadersFooters.Count > 0)
		{
			xbfa527ce27e3770d(x562af9054b809d0f.FirstSection.HeadersFooters, section, x6c0bee6311fedef, xca9347ea88f7ea84: true);
		}
		if (x562af9054b809d0f.Sections.Count <= 1 || section.NextSibling == null)
		{
			return;
		}
		NodeImporter x6c0bee6311fedef2 = new NodeImporter(x0393bee8ef666351.Document, x562af9054b809d0f, xbddb8b51223ce9e8);
		Section section2 = (Section)section.NextSibling;
		foreach (Section section3 in x562af9054b809d0f.Sections)
		{
			if (!section3.x59fc5ceeaaccb880 && !section3.x16479f42fe4547f2)
			{
				xbfa527ce27e3770d(section2.HeadersFooters, section3, x6c0bee6311fedef2, xca9347ea88f7ea84: false);
			}
		}
	}

	private static void x63f7194c38071ef2(Document x562af9054b809d0f, Paragraph x0393bee8ef666351, ImportFormatMode xbddb8b51223ce9e8)
	{
		Section xdee76b639e4a = (Section)x0393bee8ef666351.GetAncestor(NodeType.Section);
		NodeImporter x6c0bee6311fedef = new NodeImporter(x562af9054b809d0f, x0393bee8ef666351.Document, xbddb8b51223ce9e8);
		xbfa527ce27e3770d(x562af9054b809d0f.LastSection.HeadersFooters, xdee76b639e4a, x6c0bee6311fedef, xca9347ea88f7ea84: true);
	}

	private static void xbfa527ce27e3770d(HeaderFooterCollection xe5df1f0834b1d294, Section xdee76b639e4a8874, NodeImporter x6c0bee6311fedef6, bool xca9347ea88f7ea84)
	{
		foreach (HeaderFooter item in xe5df1f0834b1d294)
		{
			HeaderFooter headerFooter2 = (HeaderFooter)x6c0bee6311fedef6.ImportNode(item, isImportChildren: true);
			HeaderFooter headerFooter3 = xdee76b639e4a8874.HeadersFooters[item.HeaderFooterType];
			if (headerFooter3 != null)
			{
				if (xca9347ea88f7ea84)
				{
					headerFooter3.AppendParagraph("");
					x6c0bee6311fedef6.xb7f923c74a5f39e0(item, headerFooter3);
					continue;
				}
				headerFooter3.PrependChild(new Paragraph(headerFooter3.Document));
				while (headerFooter2.HasChildNodes)
				{
					headerFooter3.PrependChild(headerFooter2.LastChild);
				}
			}
			else
			{
				xdee76b639e4a8874.HeadersFooters.Add(headerFooter2);
			}
		}
	}

	[JavaThrows(true)]
	protected abstract void DoRead();

	protected void x2dc551ee28d58aab(DocumentBase x6beba47238e0ade6)
	{
		xd50ca1549becd989(x6beba47238e0ade6);
		string xa66385d80d4d296f = x3bcd232d01c14846.xa66385d80d4d296f;
		while (x3bcd232d01c14846.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			if (x3bcd232d01c14846.xa66385d80d4d296f == "sectPr")
			{
				Body body = (Body)base.x0547ea8ef1ef19b1;
				xc0f8e03cabf3a123.x06b0e25aa6ad68a9(this, body.ParentSection);
			}
			else
			{
				xce4dd62ad1252b05.x152cbadbfa8061b1(this);
			}
		}
	}

	protected void xd50ca1549becd989(DocumentBase x6beba47238e0ade6)
	{
		if (base.x0547ea8ef1ef19b1.NodeType != NodeType.Body)
		{
			x490834a62c46f14d(new Section(x6beba47238e0ade6));
			x490834a62c46f14d(new Body(x6beba47238e0ade6));
		}
	}

	protected void x7c1337cdc8ca636c()
	{
		if (base.x0547ea8ef1ef19b1.NodeType == NodeType.Body)
		{
			xf5b0b9b6ff7ac462(NodeType.Body);
			xf5b0b9b6ff7ac462(NodeType.Section);
		}
	}

	private xa2f1c3dcbd86f20a xe45bcd2eb799a70a(string xc06e652f250a3786)
	{
		string text = x052a6c2e603b1662(xc06e652f250a3786);
		if (!x0d299f323d241756.x5959bccb67bbf051(text))
		{
			return null;
		}
		return x7e24ae8042d3886b.x7bd3b08f3e0470ca(text);
	}

	public override xd142dcacd7ddc9dd x36eb835297f7b346(string xeaf1b27180c0557b)
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xe45bcd2eb799a70a(xeaf1b27180c0557b);
		if (xa2f1c3dcbd86f20a == null)
		{
			return null;
		}
		if (xd8c3135513b9115b.x995d1a25f2eac7ea(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe))
		{
			xd8c3135513b9115b xd8c3135513b9115b = new xd8c3135513b9115b(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe);
			return new x71d39fdf56861cca(xd8c3135513b9115b.x29e7ace4c90f74cd);
		}
		return new xb7e718098524b76c(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe, xa2f1c3dcbd86f20a.x0b93856f95be30d0);
	}

	public override byte[] x7b29fad09d9101c5(string xc06e652f250a3786)
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xe45bcd2eb799a70a(xc06e652f250a3786);
		byte[] array;
		if (xa2f1c3dcbd86f20a == null)
		{
			array = x0d299f323d241756.xcd6c2a9742c9220a();
		}
		else
		{
			array = x0d299f323d241756.xa0aed4cd3b3d5d92(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe);
			if (xa2f1c3dcbd86f20a.x0b93856f95be30d0 == "image/x-pcz")
			{
				array = x64893267b789fd52.x0824a1a655b79c17(array);
			}
			if (xdd1b8f14cc8ba86d.xa112135733098ff7(array))
			{
				array = xdd1b8f14cc8ba86d.x300bc69d382eb52c(array, xdd1b8f14cc8ba86d.x59837dfeb1fc5a82(array));
			}
		}
		return x622213a14a0645f2(array);
	}

	internal byte[] xc0d748bf95efe833(string xc06e652f250a3786)
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = xe45bcd2eb799a70a(xc06e652f250a3786);
		if (xa2f1c3dcbd86f20a != null)
		{
			return x0d299f323d241756.xa0aed4cd3b3d5d92(xa2f1c3dcbd86f20a.xb8a774e0111d0fbe);
		}
		return null;
	}

	public override string x052a6c2e603b1662(string xc06e652f250a3786)
	{
		return xc3723d392789e04d.x398b3bd0acd94b61.x052a6c2e603b1662(xc06e652f250a3786);
	}

	public override bool x3d21050b1e731250(string x50a18ad2656e7181)
	{
		x5b6f1954712b741f x5b6f1954712b741f = xc3723d392789e04d.x398b3bd0acd94b61.xadb7000bed559a9a.x212c1a2c5130b96e(x50a18ad2656e7181);
		return x5b6f1954712b741f.x0552da4f5c09bde5;
	}

	internal bool x1ee3ea6f8381b669(string x50a18ad2656e7181)
	{
		x5b6f1954712b741f x5b6f1954712b741f = xc3723d392789e04d.x398b3bd0acd94b61.xadb7000bed559a9a.x212c1a2c5130b96e(x50a18ad2656e7181);
		return x5b6f1954712b741f.x0552da4f5c09bde5;
	}

	public override void x2b6e606d842be5f3()
	{
	}

	public override void x7a60e084fa9fb0e3(ShapeBase x5770cdefd8931aa9)
	{
		xce4dd62ad1252b05.x06b0e25aa6ad68a9(this, x5770cdefd8931aa9);
	}

	internal override Footnote x3e5f4bed8c6ef7e6(FootnoteType xd3526c7313d75391, int xeaf1b27180c0557b)
	{
		return x9f4ab3ec936993da.x3e5f4bed8c6ef7e6(xd3526c7313d75391, xeaf1b27180c0557b);
	}

	internal override void x2587cb0fe9d7f086(Comment x77c5a31ec0891f38)
	{
		x1b214b38bd4b02f1.Add(x77c5a31ec0891f38.Id, x77c5a31ec0891f38);
	}

	internal override Comment x8acb911280b864de(int xeaf1b27180c0557b)
	{
		return (Comment)x1b214b38bd4b02f1[xeaf1b27180c0557b];
	}

	internal override x9ea8b270a83f04a0 x663a863d790eefe8(string xc06e652f250a3786)
	{
		xa2f1c3dcbd86f20a part = xd4e2719ccf56f4d7(x052a6c2e603b1662(xc06e652f250a3786));
		x01670783beff2a53.Push(xc3723d392789e04d);
		xc3723d392789e04d = new x9ea8b270a83f04a0(part);
		return xc3723d392789e04d;
	}

	internal x9ea8b270a83f04a0 x1b1aeab2a2e668c4(string x061610664b4c984f)
	{
		xa2f1c3dcbd86f20a xa2f1c3dcbd86f20a = x4bfdbcbc6a51d705(x336788c6a46ed27b, x061610664b4c984f);
		if (xa2f1c3dcbd86f20a == null)
		{
			return null;
		}
		return x5f81a20b8dd0c3a7(new x9ea8b270a83f04a0(xa2f1c3dcbd86f20a, base.x1e4394fcb6d34948.WarningCallback, WarningSource.Docx));
	}

	internal override x9ea8b270a83f04a0 xc8ab4e294c74831b()
	{
		xc3723d392789e04d = (x9ea8b270a83f04a0)x01670783beff2a53.Pop();
		return xc3723d392789e04d;
	}

	internal override x9ea8b270a83f04a0 x5f81a20b8dd0c3a7(x9ea8b270a83f04a0 xe134235b3526fa75)
	{
		x01670783beff2a53.Push(xc3723d392789e04d);
		xc3723d392789e04d = xe134235b3526fa75;
		return xc3723d392789e04d;
	}

	internal xa2f1c3dcbd86f20a x4bfdbcbc6a51d705(xa2f1c3dcbd86f20a x660bfbc29977d3c8, string x061610664b4c984f)
	{
		return x7e24ae8042d3886b.x4bfdbcbc6a51d705(x660bfbc29977d3c8, x061610664b4c984f);
	}

	internal xa2f1c3dcbd86f20a xd4e2719ccf56f4d7(string xc15bd84e01929885)
	{
		return x7e24ae8042d3886b.xd4e2719ccf56f4d7(xc15bd84e01929885);
	}

	private void x5ec6421d09860bef(xeedad81aaed42a76 x789564759d365819)
	{
		x8f22b0507bb6c621 x8f22b0507bb6c = new x8f22b0507bb6c621();
		DrawingML drawingML = x8f22b0507bb6c.xd41ddc432f1bf535(this);
		if (drawingML != null)
		{
			drawingML.xeedad81aaed42a76 = x789564759d365819;
			x1fa9148f6731ff24(drawingML);
		}
	}

	void xf721f41ceaf253ab.xd41ddc432f1bf535(xeedad81aaed42a76 x789564759d365819)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x5ec6421d09860bef
		this.x5ec6421d09860bef(x789564759d365819);
	}

	internal void xd011607572e5ff1b(x7c5f42d7c853beff x962b4e83bcc275c3)
	{
		xae41d23dbab1f17a.Add(x962b4e83bcc275c3);
	}
}
