using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using Aspose.Words.Math;
using Aspose.Words.Saving;
using Aspose.Words.Tables;
using x011d489fb9df7027;
using x28925c9b27b37a46;
using x55b2bd426d41d30c;
using xbe73d5820f7f4ae3;
using xe5b37aee2c2a4d4e;

namespace xa2462df43988ffad;

internal class xdb0bf9f81de4b38c : DocumentVisitor, x3d2908992e1d1667
{
	private bool xfa795991b0dc3bbb;

	private Hashtable x547e9be6cb0431d4;

	private x15dbebd260eeec6e x8f7e280e288438b3;

	private Node x5628e7e410d610cb;

	private Paragraph x193b6b0745ef5f60;

	private xb08af07e0a146853 x7e24ae8042d3886b;

	private x8556eed81191af11 xb36c250515e408ad;

	private Section x4702d9f8ac682342;

	private x9c77c7e782b62883 x800085dd555f7711;

	private x14bf6f47128e4438 x2e82d21f2a38abd2;

	private int x8dab1b7574a50067;

	private int xf000aa0d4963394a;

	private int x157be9812f46e104;

	private int xfc2e498430d2b064;

	private int x248f775e92345925;

	private int x2ac464cb0242f491;

	private int xb420599737547d9e;

	private int x86750cf5028bbb66;

	private int x9c8e465a79bff887;

	private int xe55137f2e976e51a;

	private int x7c648a0adec8ace8;

	private int x9e81aeedc22c87e3;

	private int xb8e39487489600ac;

	private int xb1df4f8de8641174;

	private ArrayList x83720d6a857eefea;

	private ArrayList x1a81e78ac933d592;

	private ArrayList x476565d5fc777d3c;

	private ArrayList x6c5491e414050c53;

	private bool x18b5fe6405f4bb84;

	private bool x4a8a06f89827e27b;

	private bool xb06e624f18fffcbd;

	private bool x456ba8ebabdf44d0;

	private bool xbe61c2282a976ec3;

	private bool x7b363f1a498ec818;

	private bool xf79b9da5eb082037;

	private x08afc512f69acef1 x27f6d12a7d7d77a8;

	private x08afc512f69acef1 x1157eea8ad743221;

	private x08afc512f69acef1 xae20e48563deec0f;

	private xb4b2fa9e83be9a55 x226a09a3303fed2e;

	private x00718c1b6df413d3 x50fd2f87dafc0d07;

	private x09b79d8a30000f4d x07f7735addeb2f9d;

	private xdf53f299023d287d xc6c1b6f066619dd3;

	private x3f151365c926402f x26fe7a226df36e74;

	private xda1eaa1e5cc1a653 x4af07f520b56f886;

	private x747b118e77fb5f2c x0748d303ac001bdc;

	private x352c232b6aeb5bd5 xfa63fcde755461b2;

	private x1bcc78025b074707 xa243116959ae93e9;

	private x9884289168bac01e x12954a224495d3c0;

	private xb445834e58f7e37d xb9e6b034b22e403e;

	private xd191b8547552c43b x7a0793fcaf20c7b3;

	private xd52f4e7d89553b9d x06092aa410188eaa;

	private bool xd3fbe5ebd09b05f6;

	private int x1eec26597e29be3d;

	private bool xfdbbc545eaaaacb7;

	private bool xa4affb5c989874af;

	internal xb08af07e0a146853 x39c7aeeec1af9dd0 => x7e24ae8042d3886b;

	internal OdtSaveOptions xf57de0fd37d5e97d => (OdtSaveOptions)xb36c250515e408ad.xf57de0fd37d5e97d;

	internal Document x2c8c6741422a1298 => xb36c250515e408ad.x2c8c6741422a1298;

	internal Section x10d7a1cae426b158
	{
		get
		{
			return x4702d9f8ac682342;
		}
		set
		{
			x4702d9f8ac682342 = value;
		}
	}

	internal x9c77c7e782b62883 xe1410f585439c7d4
	{
		get
		{
			return x800085dd555f7711;
		}
		set
		{
			x800085dd555f7711 = value;
		}
	}

	internal bool x68e1404b914783c1
	{
		get
		{
			if (x2e82d21f2a38abd2 != 0)
			{
				return x2e82d21f2a38abd2 == x14bf6f47128e4438.x04e4ed301f6f3a72;
			}
			return true;
		}
	}

	internal bool xb872fbc83a2cb9a6
	{
		get
		{
			if (x2e82d21f2a38abd2 != 0)
			{
				return x2e82d21f2a38abd2 == x14bf6f47128e4438.x05a725d9893e5a35;
			}
			return true;
		}
	}

	internal bool x6c4e1bc3d49e75d1
	{
		get
		{
			if (x2e82d21f2a38abd2 != x14bf6f47128e4438.x62af77d3c3af0871)
			{
				return x2e82d21f2a38abd2 == x14bf6f47128e4438.x04e4ed301f6f3a72;
			}
			return true;
		}
	}

	internal x14bf6f47128e4438 x05ee8ce4d7312eb5
	{
		get
		{
			return x2e82d21f2a38abd2;
		}
		set
		{
			x2e82d21f2a38abd2 = value;
		}
	}

	internal int xaa7785f730d8dd15
	{
		get
		{
			return x8dab1b7574a50067;
		}
		set
		{
			x8dab1b7574a50067 = value;
		}
	}

	internal int x9ccf4cb9c6099e0a
	{
		get
		{
			return xf000aa0d4963394a;
		}
		set
		{
			xf000aa0d4963394a = value;
		}
	}

	internal int x970d128a5aa17a0a
	{
		get
		{
			return x157be9812f46e104;
		}
		set
		{
			x157be9812f46e104 = value;
		}
	}

	internal int x5417a7be6b5ed8a2
	{
		get
		{
			return xb420599737547d9e;
		}
		set
		{
			xb420599737547d9e = value;
		}
	}

	internal int xa0c811de7638c8b1
	{
		get
		{
			return xfc2e498430d2b064;
		}
		set
		{
			xfc2e498430d2b064 = value;
		}
	}

	internal int x84e55246091c35af
	{
		get
		{
			return x248f775e92345925;
		}
		set
		{
			x248f775e92345925 = value;
		}
	}

	internal int x7eccda4aecb5dc9f
	{
		get
		{
			return x2ac464cb0242f491;
		}
		set
		{
			x2ac464cb0242f491 = value;
		}
	}

	internal int xf6985ded5d8720ef
	{
		get
		{
			return x86750cf5028bbb66;
		}
		set
		{
			x86750cf5028bbb66 = value;
		}
	}

	internal int x59bc0096de497989
	{
		get
		{
			return x9c8e465a79bff887;
		}
		set
		{
			x9c8e465a79bff887 = value;
		}
	}

	internal int x9b1baea4e485d168
	{
		get
		{
			return xe55137f2e976e51a;
		}
		set
		{
			xe55137f2e976e51a = value;
		}
	}

	internal int xc4cd358aeebe0ff5
	{
		get
		{
			return x7c648a0adec8ace8;
		}
		set
		{
			x7c648a0adec8ace8 = value;
		}
	}

	internal int xc6722b414f454e78
	{
		get
		{
			return x9e81aeedc22c87e3;
		}
		set
		{
			x9e81aeedc22c87e3 = value;
		}
	}

	internal int x9b244e0cae8e9ee1
	{
		get
		{
			return xb1df4f8de8641174;
		}
		set
		{
			xb1df4f8de8641174 = value;
		}
	}

	internal int x48858fea1f761971
	{
		get
		{
			return xb8e39487489600ac;
		}
		set
		{
			xb8e39487489600ac = value;
		}
	}

	internal ArrayList x862b4148836ee29c
	{
		get
		{
			return x83720d6a857eefea;
		}
		set
		{
			x83720d6a857eefea = value;
		}
	}

	internal ArrayList x23c93f2a46f812b5
	{
		get
		{
			return x1a81e78ac933d592;
		}
		set
		{
			x1a81e78ac933d592 = value;
		}
	}

	internal ArrayList xdb9a725c50caafe9
	{
		get
		{
			return x476565d5fc777d3c;
		}
		set
		{
			x476565d5fc777d3c = value;
		}
	}

	internal ArrayList x7bbab8fe28f5c2f0
	{
		get
		{
			return x6c5491e414050c53;
		}
		set
		{
			x6c5491e414050c53 = value;
		}
	}

	internal bool x2b4379ecf88129a1
	{
		get
		{
			return xbe61c2282a976ec3;
		}
		set
		{
			xbe61c2282a976ec3 = value;
		}
	}

	internal bool x386588ea37d49369
	{
		get
		{
			return x7b363f1a498ec818;
		}
		set
		{
			x7b363f1a498ec818 = value;
		}
	}

	internal bool x52320ec9c1034d1f
	{
		get
		{
			return x18b5fe6405f4bb84;
		}
		set
		{
			x18b5fe6405f4bb84 = value;
		}
	}

	internal bool x1339fb7786d0cc44
	{
		get
		{
			return x4a8a06f89827e27b;
		}
		set
		{
			x4a8a06f89827e27b = value;
		}
	}

	internal int xae1859ea8541d5a4
	{
		get
		{
			return x1eec26597e29be3d;
		}
		set
		{
			x1eec26597e29be3d = value;
		}
	}

	internal bool x1c807e6130619b41
	{
		get
		{
			return xd3fbe5ebd09b05f6;
		}
		set
		{
			xd3fbe5ebd09b05f6 = value;
		}
	}

	internal bool x918fb62389d96551
	{
		get
		{
			return xb06e624f18fffcbd;
		}
		set
		{
			xb06e624f18fffcbd = value;
		}
	}

	internal bool xcfbb77d2d3868462
	{
		get
		{
			return x456ba8ebabdf44d0;
		}
		set
		{
			x456ba8ebabdf44d0 = value;
		}
	}

	internal bool x8197188ddb6f93d3
	{
		get
		{
			return xf79b9da5eb082037;
		}
		set
		{
			xf79b9da5eb082037 = value;
		}
	}

	internal x08afc512f69acef1 xa74e18b54d0273fb
	{
		get
		{
			return x27f6d12a7d7d77a8;
		}
		set
		{
			x27f6d12a7d7d77a8 = value;
		}
	}

	internal x08afc512f69acef1 xe80a456c411edf35
	{
		get
		{
			return x1157eea8ad743221;
		}
		set
		{
			x1157eea8ad743221 = value;
		}
	}

	internal x08afc512f69acef1 x9de31f20dd54f2d6
	{
		get
		{
			return xae20e48563deec0f;
		}
		set
		{
			xae20e48563deec0f = value;
		}
	}

	internal Node x1f3ed48ef81a3a47
	{
		get
		{
			return x5628e7e410d610cb;
		}
		set
		{
			x5628e7e410d610cb = value;
		}
	}

	internal Paragraph xef47796674b8012f
	{
		get
		{
			return x193b6b0745ef5f60;
		}
		set
		{
			x193b6b0745ef5f60 = value;
		}
	}

	internal x15dbebd260eeec6e x883eea81d91d4029
	{
		get
		{
			return x8f7e280e288438b3;
		}
		set
		{
			x8f7e280e288438b3 = value;
		}
	}

	internal Hashtable x010e51d18aa06ecc
	{
		get
		{
			return x547e9be6cb0431d4;
		}
		set
		{
			x547e9be6cb0431d4 = value;
		}
	}

	internal bool xc907f222971a2a50
	{
		get
		{
			return xfa795991b0dc3bbb;
		}
		set
		{
			xfa795991b0dc3bbb = value;
		}
	}

	internal bool x3939850b09f0d40e
	{
		get
		{
			return xfdbbc545eaaaacb7;
		}
		set
		{
			xfdbbc545eaaaacb7 = value;
		}
	}

	private IWarningCallback xf69ca7a9bb4a4a51 => xb36c250515e408ad.xf57de0fd37d5e97d.WarningCallback;

	internal bool x80bda3177714fd50
	{
		get
		{
			return xa4affb5c989874af;
		}
		set
		{
			xa4affb5c989874af = value;
		}
	}

	internal x9c77c7e782b62883 x082c3925d43afdad(string x6f018798bcfd4ae8)
	{
		x0ca5e8b532953a51 x0ca5e8b532953a = new x0ca5e8b532953a51(x6f018798bcfd4ae8);
		x800085dd555f7711 = new x9c77c7e782b62883(x0ca5e8b532953a, xf57de0fd37d5e97d.PrettyFormat);
		x7e24ae8042d3886b.xd6abb2ab950b4d22.xd6b6ed77479ef68c(x0ca5e8b532953a);
		return x800085dd555f7711;
	}

	private SaveOutputParameters x8cac5adfe79bc025(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		xd5fbde092e394621(x5ac1382edb7bf2c2);
		x18b5fe6405f4bb84 = false;
		xb06e624f18fffcbd = false;
		x456ba8ebabdf44d0 = false;
		x8f7e280e288438b3 = new x15dbebd260eeec6e();
		xa453af9abf9a7b95();
		return new SaveOutputParameters(x6d7e93096186c0df());
	}

	SaveOutputParameters x3d2908992e1d1667.xa2e0b7f7da663553(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x8cac5adfe79bc025
		return this.x8cac5adfe79bc025(x5ac1382edb7bf2c2);
	}

	private void xd5fbde092e394621(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		xb36c250515e408ad = x5ac1382edb7bf2c2;
		if (xb36c250515e408ad.x2c8c6741422a1298.HasRevisions)
		{
			Document document = (Document)xb36c250515e408ad.x2c8c6741422a1298.Clone(isCloneChildren: true);
			document.AcceptAllRevisions();
			xb36c250515e408ad.x2c8c6741422a1298 = document;
		}
	}

	private string x6d7e93096186c0df()
	{
		return xb36c250515e408ad.x707d72c3570dbf2d switch
		{
			SaveFormat.Odt => "application/vnd.oasis.opendocument.text", 
			SaveFormat.Ott => "application/vnd.oasis.opendocument.text-template", 
			_ => throw new InvalidOperationException("Unexpected save format type."), 
		};
	}

	private void xa453af9abf9a7b95()
	{
		x1157eea8ad743221 = new x08afc512f69acef1();
		x27f6d12a7d7d77a8 = new x08afc512f69acef1();
		xae20e48563deec0f = new x08afc512f69acef1();
		x83720d6a857eefea = new ArrayList();
		x1a81e78ac933d592 = new ArrayList();
		x476565d5fc777d3c = new ArrayList();
		x6c5491e414050c53 = new ArrayList();
		x226a09a3303fed2e = new xb4b2fa9e83be9a55(this);
		x50fd2f87dafc0d07 = new x00718c1b6df413d3(this);
		x07f7735addeb2f9d = new x09b79d8a30000f4d(this);
		xc6c1b6f066619dd3 = new xdf53f299023d287d(this);
		x26fe7a226df36e74 = new x3f151365c926402f(this);
		x4af07f520b56f886 = new xda1eaa1e5cc1a653(this);
		x0748d303ac001bdc = new x747b118e77fb5f2c(this);
		xfa63fcde755461b2 = new x352c232b6aeb5bd5(this);
		x12954a224495d3c0 = new x9884289168bac01e(this);
		xb9e6b034b22e403e = new xb445834e58f7e37d(this);
		xa243116959ae93e9 = new x1bcc78025b074707(this);
		x547e9be6cb0431d4 = new Hashtable();
		x7e24ae8042d3886b = new xb08af07e0a146853();
		x7a0793fcaf20c7b3 = new xd191b8547552c43b(this);
		x7a0793fcaf20c7b3.x6210059f049f0d48();
		x28b2814e1e172112 x28b2814e1e172113 = new x28b2814e1e172112(this);
		x28b2814e1e172113.x6210059f049f0d48();
		x6c5491e414050c53.Clear();
		x0d683b24120656b0 x0d683b24120656b = new x0d683b24120656b0(this);
		x0d683b24120656b.x6210059f049f0d48();
		x2e82d21f2a38abd2 = x14bf6f47128e4438.x62896619d90ad964;
		x2c8c6741422a1298.Accept(this);
		xbfe05cd8a52fce3d xbfe05cd8a52fce3d2 = new xbfe05cd8a52fce3d(this);
		xbfe05cd8a52fce3d2.x6210059f049f0d48(x6d7e93096186c0df());
		x3e35b4ed0ef536b4 x3e35b4ed0ef536b5 = new x3e35b4ed0ef536b4(this);
		x3e35b4ed0ef536b5.x6210059f049f0d48();
		x7e24ae8042d3886b.x0acd3c2012ea2ee8(xb36c250515e408ad.xb8a774e0111d0fbe, x6d7e93096186c0df());
	}

	internal void x553875efa602203e()
	{
		x1eec26597e29be3d = 0;
		xf000aa0d4963394a = 0;
		xb420599737547d9e = 0;
		xfc2e498430d2b064 = 0;
		x248f775e92345925 = 0;
		x2ac464cb0242f491 = 0;
		x86750cf5028bbb66 = 0;
		x9c8e465a79bff887 = 0;
		xe55137f2e976e51a = 0;
		x7c648a0adec8ace8 = 0;
		x9e81aeedc22c87e3 = 0;
		x157be9812f46e104 = 0;
		xb8e39487489600ac = 0;
		xb1df4f8de8641174 = 0;
	}

	public override VisitorAction VisitDocumentStart(Document doc)
	{
		x8f7e280e288438b3.Clear();
		return x7a0793fcaf20c7b3.x5d0e2a54495c06dc();
	}

	public override VisitorAction VisitDocumentEnd(Document doc)
	{
		return x07f7735addeb2f9d.x648a8aa88d1bbe19();
	}

	public override VisitorAction VisitBodyStart(Body body)
	{
		xb06e624f18fffcbd = body.ParentSection.PageSetup.SectionStart == SectionStart.NewPage;
		x5628e7e410d610cb = null;
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitBodyEnd(Body body)
	{
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitSectionStart(Section section)
	{
		return xc6c1b6f066619dd3.xd812884be22e7fdc(section);
	}

	public override VisitorAction VisitSectionEnd(Section section)
	{
		return xc6c1b6f066619dd3.xcc371383c18fe22c(section);
	}

	public override VisitorAction VisitParagraphStart(Paragraph paragraph)
	{
		return x26fe7a226df36e74.x57a5d79d9b9d67f5(paragraph);
	}

	public override VisitorAction VisitParagraphEnd(Paragraph paragraph)
	{
		return x26fe7a226df36e74.x250b22e8996b97fb(paragraph);
	}

	public override VisitorAction VisitBookmarkStart(BookmarkStart bookmarkStart)
	{
		return x4af07f520b56f886.xa2b18804731061bd(bookmarkStart);
	}

	public override VisitorAction VisitBookmarkEnd(BookmarkEnd bookmarkEnd)
	{
		return x4af07f520b56f886.x3c82d5a325e3a429(bookmarkEnd);
	}

	public override VisitorAction VisitFootnoteStart(Footnote footnote)
	{
		return x0748d303ac001bdc.x22e173d9569cebf2(footnote);
	}

	public override VisitorAction VisitFootnoteEnd(Footnote footnote)
	{
		return x0748d303ac001bdc.xd46bfa3d7ed1b78e(footnote);
	}

	public override VisitorAction VisitHeaderFooterStart(HeaderFooter headerFooter)
	{
		return xfa63fcde755461b2.xad7a29fa75b79356(headerFooter);
	}

	public override VisitorAction VisitHeaderFooterEnd(HeaderFooter headerFooter)
	{
		return xfa63fcde755461b2.xf2ddc0e9840f4570(headerFooter);
	}

	public override VisitorAction VisitCommentStart(Comment comment)
	{
		return xa243116959ae93e9.xbe1a55c816d0949a(comment);
	}

	public override VisitorAction VisitCommentEnd(Comment comment)
	{
		return xa243116959ae93e9.x4a40a6d0b2ee1c7b(comment);
	}

	public override VisitorAction VisitRun(Run run)
	{
		return x2b65e8c50e10e0bb(run);
	}

	public override VisitorAction VisitSpecialChar(SpecialChar specialChar)
	{
		return x2b65e8c50e10e0bb(specialChar);
	}

	private VisitorAction x2b65e8c50e10e0bb(Inline x31545d7c306a55e4)
	{
		if (x06092aa410188eaa != null)
		{
			if (x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
			{
				x06092aa410188eaa.x9d26deb82e84d9e6(x31545d7c306a55e4);
			}
			return VisitorAction.Continue;
		}
		if (x31545d7c306a55e4.ParentNode.NodeType == NodeType.OfficeMath)
		{
			return VisitorAction.Continue;
		}
		return x12954a224495d3c0.xdc0a84c0e3e375cb(x31545d7c306a55e4);
	}

	public override VisitorAction VisitTableStart(Table table)
	{
		return xb9e6b034b22e403e.xe35e18fbd2d5ad9e(table);
	}

	public override VisitorAction VisitTableEnd(Table table)
	{
		return xb9e6b034b22e403e.x49cd8bac108971e1(table);
	}

	public override VisitorAction VisitRowStart(Row row)
	{
		return xb9e6b034b22e403e.xf7a3d740c38d9959(row);
	}

	public override VisitorAction VisitRowEnd(Row row)
	{
		return xb9e6b034b22e403e.x73486983017b4ba2(row);
	}

	public override VisitorAction VisitCellStart(Cell cell)
	{
		return xb9e6b034b22e403e.x37f46648998425f0(cell);
	}

	public override VisitorAction VisitCellEnd(Cell cell)
	{
		return xb9e6b034b22e403e.x60d13e8235b3d083(cell);
	}

	public override VisitorAction VisitShapeStart(Shape shape)
	{
		return x50fd2f87dafc0d07.x1f70c910ab814928(shape);
	}

	public override VisitorAction VisitShapeEnd(Shape shape)
	{
		return x50fd2f87dafc0d07.xd96c4f9a469ee575(shape);
	}

	public override VisitorAction VisitGroupShapeStart(GroupShape groupShape)
	{
		return x50fd2f87dafc0d07.x1f70c910ab814928(groupShape);
	}

	public override VisitorAction VisitGroupShapeEnd(GroupShape groupShape)
	{
		return x50fd2f87dafc0d07.xd96c4f9a469ee575(groupShape);
	}

	public override VisitorAction VisitFieldStart(FieldStart fieldStart)
	{
		return x226a09a3303fed2e.xd4c0f67c01114dfe(fieldStart);
	}

	public override VisitorAction VisitFieldSeparator(FieldSeparator fieldSeparator)
	{
		return x226a09a3303fed2e.xd646d4760b5a81b9(fieldSeparator);
	}

	public override VisitorAction VisitFieldEnd(FieldEnd fieldEnd)
	{
		return x226a09a3303fed2e.x55225d9815813a91(fieldEnd);
	}

	public override VisitorAction VisitOfficeMathStart(OfficeMath officeMath)
	{
		if (x2e82d21f2a38abd2 == x14bf6f47128e4438.x62896619d90ad964)
		{
			if (officeMath.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x977976895b35c83c)
			{
				x06092aa410188eaa = new xd52f4e7d89553b9d(this, officeMath);
			}
			if (x06092aa410188eaa != null)
			{
				return x06092aa410188eaa.xf29854ceb92cf300(officeMath);
			}
		}
		if (officeMath.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x977976895b35c83c)
		{
			if (xb872fbc83a2cb9a6 || x6c4e1bc3d49e75d1)
			{
				NodeCollection childNodes = officeMath.GetChildNodes(NodeType.Comment, isDeep: true);
				xa4affb5c989874af = true;
				foreach (Comment item in childNodes)
				{
					item.Accept(this);
				}
				xa4affb5c989874af = false;
			}
			if (x6c4e1bc3d49e75d1)
			{
				xe1410f585439c7d4.xd52401bdf5aacef6("<draw:frame>");
				xe1410f585439c7d4.x5a3f5d78674f78e4("draw:object");
				xe1410f585439c7d4.x53e7651cce580e9f("xlink:href", officeMath.x5881d3d5b8b306d3());
			}
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitOfficeMathEnd(OfficeMath officeMath)
	{
		if (officeMath.x52642f91ccdeeb35.x3e68720d12325f49 == x3e68720d12325f49.x977976895b35c83c)
		{
			if (x2e82d21f2a38abd2 == x14bf6f47128e4438.x62896619d90ad964)
			{
				x800085dd555f7711.xa0dfc102c691b11f();
				x06092aa410188eaa = null;
				return VisitorAction.Continue;
			}
			if (x6c4e1bc3d49e75d1)
			{
				xe1410f585439c7d4.xf3cbeec41f083290("draw:object");
				xe1410f585439c7d4.xf3cbeec41f083290("draw:frame");
			}
		}
		return VisitorAction.Continue;
	}

	public override VisitorAction VisitAbsolutePositionTab(AbsolutePositionTab tab)
	{
		xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, "Absolute position tabs are not supported in ODT, using regular tab character.");
		return base.VisitAbsolutePositionTab(tab);
	}

	internal string xc7311acd2a09d757()
	{
		x7eccda4aecb5dc9f++;
		return $"CT{x7eccda4aecb5dc9f}";
	}

	internal void x3460ec740e098e72(Node xda5bf54deb817e37, Section x6ba355b8c75852cd)
	{
		if (xda5bf54deb817e37.x16479f42fe4547f2)
		{
			if (xda5bf54deb817e37.ParentNode is Body && x6ba355b8c75852cd.ParentNode != null && !x6ba355b8c75852cd.x16479f42fe4547f2)
			{
				x5628e7e410d610cb = null;
			}
			else
			{
				x5628e7e410d610cb = xda5bf54deb817e37.ParentNode;
			}
		}
		else
		{
			x5628e7e410d610cb = xda5bf54deb817e37;
		}
	}

	internal static bool x7fcd4a3e93426c63(object x1a84eefd5d3e114a, bool xaab0c5f1acc303e5)
	{
		if (!(x1a84eefd5d3e114a is Style))
		{
			return false;
		}
		Style style = (Style)x1a84eefd5d3e114a;
		if (!xaab0c5f1acc303e5 && (style.Type == StyleType.Paragraph || style.Type == StyleType.List))
		{
			return style.xe709b224f455b863 == 4095;
		}
		return false;
	}

	internal static bool xc8d1bb1390d5266d(Node xda5bf54deb817e37)
	{
		Story story = (Story)xda5bf54deb817e37.GetAncestor(typeof(Story));
		if (story != null)
		{
			return story.StoryType == StoryType.MainText;
		}
		return false;
	}

	internal string xd402537927b451df(xf7125312c7ee115c xa5e8b8b5991a4e1d, ArrowType xb0638b203214e481, bool xa59013d234619c58)
	{
		if (xb0638b203214e481 == ArrowType.None)
		{
			return null;
		}
		xcb29cf976b7ec398 xcb29cf976b7ec = xbb857c9fc36f5054.xf689386ff4e793c3(xa5e8b8b5991a4e1d, xb0638b203214e481, xa59013d234619c58);
		if (x1157eea8ad743221.get_xe6d4b1b411ed94b5(xcb29cf976b7ec.x759aa16c2016a289, (string)null, x0bfe184ad871a4c2: false, xafd04c36a00d5bcf: false) == null)
		{
			x1157eea8ad743221.xd6b6ed77479ef68c(xcb29cf976b7ec, x0bfe184ad871a4c2: false, xafd04c36a00d5bcf: false);
		}
		return xcb29cf976b7ec.x759aa16c2016a289;
	}

	internal void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		if (xf69ca7a9bb4a4a51 != null)
		{
			xf69ca7a9bb4a4a51.Warning(new WarningInfo(x9f91de645a9fe01a, WarningSource.Odt, xc2358fbac7da3d45));
		}
	}

	internal void x3dc950453374051a(string xc2358fbac7da3d45)
	{
		xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, xc2358fbac7da3d45);
	}
}
