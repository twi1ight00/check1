using System;
using System.ComponentModel;
using System.Text;
using Aspose.Words.Drawing;
using Aspose.Words.Lists;
using Aspose.Words.Tables;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xd2754ae26d400653;

namespace Aspose.Words;

public class Paragraph : CompositeNode, xf5ecf429e74b1c04, xac4d96a62eaba39e
{
	private x1a78664fa10a3755 x4379ee33a06c4648;

	private xeedad81aaed42a76 x17e193d05772fbbf;

	private ParagraphFormat x3d92d302c3950df6;

	private ListFormat xf7f3c633f29a1938;

	private ListLabel x8b5591cc40dfedff;

	private RunCollection xedc9b5bc46353c3d;

	public override NodeType NodeType => NodeType.Paragraph;

	public Story ParentStory => (Story)GetAncestor(typeof(Story));

	public Section ParentSection => (Section)GetAncestor(NodeType.Section);

	public bool IsInCell => base.xdfa6ecc6f742f086 is Cell;

	internal bool x7f316d7196a18aa6
	{
		get
		{
			CompositeNode parentNode = base.ParentNode;
			if (parentNode == null)
			{
				return false;
			}
			if (x2b1ee3a87b36a988.x0302c7317ec57e52(parentNode))
			{
				if (IsInCell)
				{
					return xd5b26cfce8730b50(base.xdfa6ecc6f742f086.FirstChild);
				}
				return false;
			}
			if (IsInCell)
			{
				return this == parentNode.FirstChild;
			}
			return false;
		}
	}

	public bool IsEndOfCell
	{
		get
		{
			CompositeNode compositeNode = base.xdfa6ecc6f742f086;
			if (compositeNode is Cell)
			{
				return compositeNode.xc0f45b01af564b77 == this;
			}
			return false;
		}
	}

	internal bool xf2fac726375cecab
	{
		get
		{
			if (x7f316d7196a18aa6)
			{
				return xc5464084edc8e226.IsFirstCell;
			}
			return false;
		}
	}

	internal bool xf858d9730ef207f0
	{
		get
		{
			if (IsEndOfCell)
			{
				return xc5464084edc8e226.IsLastCell;
			}
			return false;
		}
	}

	internal bool xd578ba07d624a7db
	{
		get
		{
			if (xf2fac726375cecab)
			{
				return x838c6c67b5953bb0.IsFirstRow;
			}
			return false;
		}
	}

	internal bool xbb9337da73a4b242
	{
		get
		{
			if (xf858d9730ef207f0)
			{
				return x838c6c67b5953bb0.IsLastRow;
			}
			return false;
		}
	}

	internal Cell xc5464084edc8e226 => (Cell)base.xdfa6ecc6f742f086;

	internal Row x838c6c67b5953bb0 => xc5464084edc8e226.ParentRow;

	internal Table x133f2db9e5b5690d => x838c6c67b5953bb0.ParentTable;

	internal bool xd2c86fb8ed7b1331 => base.xdfa6ecc6f742f086 is Shape;

	public bool IsEndOfSection
	{
		get
		{
			Story parentStory = ParentStory;
			if (parentStory != null && parentStory.StoryType == StoryType.MainText)
			{
				return this == parentStory.xc0f45b01af564b77;
			}
			return false;
		}
	}

	public bool IsEndOfHeaderFooter
	{
		get
		{
			Story parentStory = ParentStory;
			if (parentStory is HeaderFooter)
			{
				return parentStory.xc0f45b01af564b77 == this;
			}
			return false;
		}
	}

	public bool IsEndOfDocument
	{
		get
		{
			if (!IsEndOfSection)
			{
				return false;
			}
			for (Node node = base.Document.LastChild; node != null; node = node.PreviousSibling)
			{
				if (node is Section)
				{
					return node == ParentSection;
				}
			}
			return true;
		}
	}

	public ParagraphFormat ParagraphFormat
	{
		get
		{
			if (x3d92d302c3950df6 == null)
			{
				x3d92d302c3950df6 = new ParagraphFormat(this, base.Document.Styles);
			}
			return x3d92d302c3950df6;
		}
	}

	public ListFormat ListFormat
	{
		get
		{
			if (xf7f3c633f29a1938 == null)
			{
				xf7f3c633f29a1938 = new ListFormat(this, base.Document.Lists);
			}
			return xf7f3c633f29a1938;
		}
	}

	public ListLabel ListLabel
	{
		get
		{
			if (x8b5591cc40dfedff == null)
			{
				x8b5591cc40dfedff = new ListLabel(this);
			}
			return x8b5591cc40dfedff;
		}
	}

	public RunCollection Runs
	{
		get
		{
			if (xedc9b5bc46353c3d == null)
			{
				xedc9b5bc46353c3d = new RunCollection(this);
			}
			return xedc9b5bc46353c3d;
		}
	}

	public Font ParagraphBreakFont => new Font(this, base.Document.Styles);

	public bool IsInsertRevision => x17e193d05772fbbf.xba4e1d8a3e3316c8;

	public bool IsDeleteRevision => x17e193d05772fbbf.x0392c0938d22c790;

	internal Style xfcffbd79482d97c7 => base.Document.Styles.xf194004582627ed5(x4379ee33a06c4648.x8301ab10c226b0c2, 0);

	internal Style x881a9573ce116245 => base.Document.Styles.xf194004582627ed5(x17e193d05772fbbf.x8301ab10c226b0c2, 10);

	internal x1a78664fa10a3755 x1a78664fa10a3755
	{
		get
		{
			return x4379ee33a06c4648;
		}
		set
		{
			x4379ee33a06c4648 = value;
		}
	}

	internal xeedad81aaed42a76 x344511c4e4ce09da
	{
		get
		{
			return x17e193d05772fbbf;
		}
		set
		{
			x17e193d05772fbbf = value;
		}
	}

	internal bool xb1efbf98d540cbda
	{
		get
		{
			CompositeNode compositeNode = base.xdfa6ecc6f742f086;
			if (compositeNode is Comment)
			{
				return this == compositeNode.xc0f45b01af564b77;
			}
			return false;
		}
	}

	internal bool xd9de1b09bd43c824
	{
		get
		{
			CompositeNode compositeNode = base.xdfa6ecc6f742f086;
			if (compositeNode is Footnote)
			{
				return this == compositeNode.xc0f45b01af564b77;
			}
			return false;
		}
	}

	internal bool x591ed656a97f372e
	{
		get
		{
			CompositeNode compositeNode = base.xdfa6ecc6f742f086;
			if (compositeNode is xa1e2a8ed32a026dd)
			{
				return this == compositeNode.xc0f45b01af564b77;
			}
			return false;
		}
	}

	internal bool x65c41b4567f1d25e
	{
		get
		{
			CompositeNode compositeNode = base.xdfa6ecc6f742f086;
			if (compositeNode is Shape)
			{
				return compositeNode.xc0f45b01af564b77 == this;
			}
			return false;
		}
	}

	int xac4d96a62eaba39e.x91bf5a97a0401465 => x4379ee33a06c4648.xd44988f225497f3a;

	int xf5ecf429e74b1c04.x5b8c6010012a5955 => x17e193d05772fbbf.xd44988f225497f3a;

	internal Run x38453dde2dc1ee92 => (Run)GetChild(NodeType.Run, 0, isDeep: false);

	internal bool xc8d1bb1390d5266d
	{
		get
		{
			Story parentStory = ParentStory;
			if (parentStory != null)
			{
				return parentStory.StoryType == StoryType.MainText;
			}
			return false;
		}
	}

	public bool IsListItem => (int)xc3cc338a59c5293b(1120) != 0;

	internal bool xbc0119d7471ef12e
	{
		get
		{
			if (IsListItem)
			{
				return ListLabel.x5959bccb67bbf051;
			}
			return false;
		}
	}

	internal bool xcb78713836fcc98a
	{
		get
		{
			if (!x344511c4e4ce09da.xcb78713836fcc98a && !x1a78664fa10a3755.xcb78713836fcc98a)
			{
				return x1a78664fa10a3755.x054fe39eb479f67e;
			}
			return true;
		}
	}

	internal bool x2aea422a99819d44
	{
		get
		{
			foreach (Node childNode in base.ChildNodes)
			{
				if (childNode.NodeType == NodeType.Run)
				{
					if (!x0d299f323d241756.x70405672eb3bbb86(childNode.GetText()))
					{
						return true;
					}
				}
				else if (!x2b1ee3a87b36a988.x0f86e763fa9a14ff(childNode))
				{
					return true;
				}
			}
			return false;
		}
	}

	public Paragraph(DocumentBase doc)
		: this(doc, new x1a78664fa10a3755(), new xeedad81aaed42a76())
	{
	}

	internal Paragraph(DocumentBase doc, x1a78664fa10a3755 paraPr, xeedad81aaed42a76 runPr)
		: base(doc)
	{
		x4379ee33a06c4648 = paraPr;
		x17e193d05772fbbf = runPr;
	}

	internal void xb57cb507dbb2966a(string[] x5d9c3ec13853f2ad, xd269993cc48a63d2 x107ef6939bdd9979)
	{
		ListLabel.xc609abb1cfc9c20d(x5d9c3ec13853f2ad, x107ef6939bdd9979.xbd5d3ef61ea2956f());
	}

	internal void xd6d9cff1c02d8406()
	{
		if (x8b5591cc40dfedff != null)
		{
			ListLabel.xc609abb1cfc9c20d(null, null);
		}
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		Paragraph paragraph = (Paragraph)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		x1a78664fa10a3755 x1a78664fa10a = (x1a78664fa10a3755)x4379ee33a06c4648.x8b61531c8ea35b85();
		paragraph.x4379ee33a06c4648 = x1a78664fa10a;
		xeedad81aaed42a76 xeedad81aaed42a = (xeedad81aaed42a76)x17e193d05772fbbf.x8b61531c8ea35b85();
		paragraph.x17e193d05772fbbf = xeedad81aaed42a;
		paragraph.x3d92d302c3950df6 = null;
		paragraph.xf7f3c633f29a1938 = null;
		paragraph.x8b5591cc40dfedff = null;
		paragraph.xedc9b5bc46353c3d = null;
		return paragraph;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return xf7ae36cd24e0b11c(visitor);
	}

	internal override VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitParagraphStart(this);
	}

	internal override VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitParagraphEnd(this);
	}

	public override string GetText()
	{
		return base.GetText();
	}

	internal x1a78664fa10a3755 x2e12c5f9278ae233(xd9bc7f7e70d71e14 xebf45bdcaa1fd1e1)
	{
		x1a78664fa10a3755 x1a78664fa10a = new x1a78664fa10a3755();
		x7dbbdff0e18dae2c(x1a78664fa10a, xebf45bdcaa1fd1e1);
		return x1a78664fa10a;
	}

	internal void x7dbbdff0e18dae2c(x1a78664fa10a3755 xb3e285984f5ad9d1, xd9bc7f7e70d71e14 xebf45bdcaa1fd1e1)
	{
		if ((xebf45bdcaa1fd1e1 & xd9bc7f7e70d71e14.x2be08ba736aa04f0) != 0)
		{
			base.Document.Styles.xf4eb04b8b9073eeb.xab3af626b1405ee8(xb3e285984f5ad9d1);
		}
		if ((xebf45bdcaa1fd1e1 & xd9bc7f7e70d71e14.x5a060c44426263f6) != 0)
		{
			((Table)GetAncestor(NodeType.Table))?.Style.x7dbbdff0e18dae2c(xb3e285984f5ad9d1, xebf45bdcaa1fd1e1);
		}
		xfcffbd79482d97c7.x7dbbdff0e18dae2c(xb3e285984f5ad9d1, xebf45bdcaa1fd1e1);
		ListLevel listLevel = x258e8949280fcc37();
		if (listLevel != null)
		{
			listLevel.x1a78664fa10a3755.xab3af626b1405ee8(xb3e285984f5ad9d1);
		}
		else if (x4379ee33a06c4648.xc2f9bcf527ae907c)
		{
			xb3e285984f5ad9d1.xc7d7e186f0ace1e0 = 0;
			xb3e285984f5ad9d1.xc0741c7ff92cf1aa = 0;
		}
		x4379ee33a06c4648.xab3af626b1405ee8(xb3e285984f5ad9d1);
		if ((xebf45bdcaa1fd1e1 & xd9bc7f7e70d71e14.x3968babb3b57e478) != 0)
		{
			xb3e285984f5ad9d1.x3968babb3b57e478();
		}
	}

	private ListLevel x258e8949280fcc37()
	{
		int x71c63f7e57f7ede = x4379ee33a06c4648.x71c63f7e57f7ede5;
		if (x71c63f7e57f7ede == 0)
		{
			return null;
		}
		List list = base.Document.Lists.xceb66bfa0e6b60c7(x71c63f7e57f7ede);
		return list.x1fc16b41653eb571(x4379ee33a06c4648.xf13a626e550cef8f);
	}

	internal xeedad81aaed42a76 x3a7e67268c1cb407(xecac24b19ed3a2b7 xebf45bdcaa1fd1e1)
	{
		xeedad81aaed42a76 xeedad81aaed42a = new xeedad81aaed42a76();
		x3c24953856276101(xeedad81aaed42a, xebf45bdcaa1fd1e1);
		return xeedad81aaed42a;
	}

	internal void x3c24953856276101(xeedad81aaed42a76 x4ac4562403543b7a, xecac24b19ed3a2b7 xebf45bdcaa1fd1e1)
	{
		x684b09378db148f4.x5f851b1938defe5f(base.Document, xfcffbd79482d97c7, x881a9573ce116245, x17e193d05772fbbf, x4ac4562403543b7a, xebf45bdcaa1fd1e1);
	}

	internal void xdf27503bc6a15f75(out double x826b56145f41e87a, out double x966a98c86f220d2e, out bool x1cdce3c10464e54e)
	{
		x826b56145f41e87a = 2147483647.0;
		x966a98c86f220d2e = 0.0;
		x1cdce3c10464e54e = false;
		for (Node node = base.xfe93db1ba6e25886; node != null; node = node.xa6890a1cb2b8896e)
		{
			if (node is Inline)
			{
				x68e788622138e5ac((Inline)node, ref x826b56145f41e87a, ref x966a98c86f220d2e, ref x1cdce3c10464e54e);
			}
		}
		if (x966a98c86f220d2e == 0.0)
		{
			x68e788622138e5ac(this, ref x826b56145f41e87a, ref x966a98c86f220d2e, ref x1cdce3c10464e54e);
		}
	}

	private static void x68e788622138e5ac(xf5ecf429e74b1c04 x1a84eefd5d3e114a, ref double x826b56145f41e87a, ref double x966a98c86f220d2e, ref bool x1cdce3c10464e54e)
	{
		object obj = x1a84eefd5d3e114a.x9bd0b4c41657450b(190);
		double val = x4574ea26106f0edb.x4610495f80b4c267((int)((obj != null) ? obj : x1a84eefd5d3e114a.x2685f947206319cf(190)));
		x826b56145f41e87a = System.Math.Min(val, x826b56145f41e87a);
		x966a98c86f220d2e = System.Math.Max(val, x966a98c86f220d2e);
		if (!x1cdce3c10464e54e)
		{
			x1cdce3c10464e54e = obj != null;
			if (!x1cdce3c10464e54e)
			{
				object obj2 = x1a84eefd5d3e114a.x9bd0b4c41657450b(50);
				x1cdce3c10464e54e = obj2 != null && (int)obj2 != 10;
			}
		}
	}

	internal override string x0598f184f69953c1()
	{
		if (IsEndOfCell)
		{
			return ControlChar.Cell;
		}
		if (IsEndOfSection)
		{
			return ControlChar.SectionBreak;
		}
		return ControlChar.ParagraphBreak;
	}

	internal override bool x8a4414b7d9d4073f(Node x40e458b3a58f5782)
	{
		return x2b1ee3a87b36a988.x15bc008974f7d712(x40e458b3a58f5782);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public object xb86fdbeadec3b75c(int xba08ce632055a1d9)
	{
		return x4379ee33a06c4648.xf7866f89640a29a3(xba08ce632055a1d9);
	}

	private void x95cfb6ef0e888214(int xc0c4c459c6ccbd00, out int xba08ce632055a1d9, out object xbcea506a33cf9111)
	{
		xba08ce632055a1d9 = x4379ee33a06c4648.xf15263674eb297bb(xc0c4c459c6ccbd00);
		xbcea506a33cf9111 = x4379ee33a06c4648.x6d3720b962bd3112(xc0c4c459c6ccbd00);
	}

	void xac4d96a62eaba39e.xee440186ba45615a(int xc0c4c459c6ccbd00, out int xba08ce632055a1d9, out object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x95cfb6ef0e888214
		this.x95cfb6ef0e888214(xc0c4c459c6ccbd00, out xba08ce632055a1d9, out xbcea506a33cf9111);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public object x51ae400150847113(int xba08ce632055a1d9)
	{
		ListLevel listLevel = x258e8949280fcc37();
		if (listLevel != null)
		{
			object obj = listLevel.x1a78664fa10a3755.xf7866f89640a29a3(xba08ce632055a1d9);
			if (obj != null)
			{
				return obj;
			}
		}
		else if (x4379ee33a06c4648.xc2f9bcf527ae907c && (xba08ce632055a1d9 == 1160 || xba08ce632055a1d9 == 1170))
		{
			return 0;
		}
		return xfcffbd79482d97c7.xc3cc338a59c5293b(xba08ce632055a1d9);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public object xc3cc338a59c5293b(int xba08ce632055a1d9)
	{
		object obj = xb86fdbeadec3b75c(xba08ce632055a1d9);
		if (obj == null)
		{
			return x51ae400150847113(xba08ce632055a1d9);
		}
		return obj;
	}

	private void xc6355ea81dc1c54b(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		x4379ee33a06c4648.xae20093bed1e48a8(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	void xac4d96a62eaba39e.xb6157b6da9895c0d(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xc6355ea81dc1c54b
		this.xc6355ea81dc1c54b(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	private void x3ba5b0445ff0a9f8(int xba08ce632055a1d9)
	{
		x4379ee33a06c4648.x52b190e626f65140(xba08ce632055a1d9);
	}

	void xac4d96a62eaba39e.xb55a99e2e1381d7f(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x3ba5b0445ff0a9f8
		this.x3ba5b0445ff0a9f8(xba08ce632055a1d9);
	}

	private void xad212b340baad773()
	{
		x4379ee33a06c4648.ClearAttrs();
	}

	void xac4d96a62eaba39e.x6aea418c3f016cbd()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xad212b340baad773
		this.xad212b340baad773();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public object x9bd0b4c41657450b(int xba08ce632055a1d9)
	{
		return x17e193d05772fbbf.xf7866f89640a29a3(xba08ce632055a1d9);
	}

	private void x9939815f86bdcfc3(int xc0c4c459c6ccbd00, out int xba08ce632055a1d9, out object xbcea506a33cf9111)
	{
		xba08ce632055a1d9 = x17e193d05772fbbf.xf15263674eb297bb(xc0c4c459c6ccbd00);
		xbcea506a33cf9111 = x17e193d05772fbbf.x6d3720b962bd3112(xc0c4c459c6ccbd00);
	}

	void xf5ecf429e74b1c04.x16b3a875e7cc38ed(int xc0c4c459c6ccbd00, out int xba08ce632055a1d9, out object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x9939815f86bdcfc3
		this.x9939815f86bdcfc3(xc0c4c459c6ccbd00, out xba08ce632055a1d9, out xbcea506a33cf9111);
	}

	private object xa49e661f5cc91e49(int xba08ce632055a1d9)
	{
		object obj = x881a9573ce116245.x61d8cd76508e76c3(xba08ce632055a1d9, x9ee6c2f047893ddc: false);
		if (obj != null)
		{
			return obj;
		}
		return xfcffbd79482d97c7.x61d8cd76508e76c3(xba08ce632055a1d9, x9ee6c2f047893ddc: true);
	}

	object xf5ecf429e74b1c04.x2685f947206319cf(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa49e661f5cc91e49
		return this.xa49e661f5cc91e49(xba08ce632055a1d9);
	}

	private void x09376e92b9e1f394(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		x17e193d05772fbbf.xae20093bed1e48a8(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	void xf5ecf429e74b1c04.xd00aa8389522ce53(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x09376e92b9e1f394
		this.x09376e92b9e1f394(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	private void x69045f836de92891()
	{
		x17e193d05772fbbf.ClearAttrs();
	}

	void xf5ecf429e74b1c04.xe80983f2918b2568()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x69045f836de92891
		this.x69045f836de92891();
	}

	internal bool x560c050862d2f9c7()
	{
		Node node = base.xa6890a1cb2b8896e;
		if (!(node is Paragraph))
		{
			return false;
		}
		Paragraph paragraph = (Paragraph)node;
		ParagraphFormat paragraphFormat = ParagraphFormat;
		ParagraphFormat paragraphFormat2 = paragraph.ParagraphFormat;
		if (paragraphFormat2.PageBreakBefore)
		{
			return false;
		}
		double num = paragraphFormat.LeftIndent + System.Math.Min(paragraphFormat.FirstLineIndent, 0.0);
		double num2 = paragraphFormat2.LeftIndent + System.Math.Min(paragraphFormat2.FirstLineIndent, 0.0);
		if (num != num2)
		{
			return false;
		}
		if (paragraphFormat.RightIndent != paragraphFormat2.RightIndent)
		{
			return false;
		}
		if (!paragraphFormat.Borders[BorderType.Left].Equals(paragraphFormat2.Borders[BorderType.Left]))
		{
			return false;
		}
		if (!paragraphFormat.Borders[BorderType.Right].Equals(paragraphFormat2.Borders[BorderType.Right]))
		{
			return false;
		}
		if (!paragraphFormat.Borders[BorderType.Top].Equals(paragraphFormat2.Borders[BorderType.Top]))
		{
			return false;
		}
		if (!paragraphFormat.Borders[BorderType.Bottom].Equals(paragraphFormat2.Borders[BorderType.Bottom]))
		{
			return false;
		}
		if (!x44552e9e0078b0ae(paragraph))
		{
			return false;
		}
		return true;
	}

	internal bool x44552e9e0078b0ae(Paragraph xd6efc2d6e891a521)
	{
		return x4379ee33a06c4648.x44552e9e0078b0ae(xd6efc2d6e891a521.x1a78664fa10a3755);
	}

	internal Run xf562da51e0b3c429()
	{
		Run result = null;
		for (Node node = base.xfe93db1ba6e25886; node != null; node = node.xa6890a1cb2b8896e)
		{
			if (node.NodeType == NodeType.Run)
			{
				result = (Run)node;
			}
		}
		return result;
	}

	internal int x1ac00ce31ec4975d(StringBuilder xfef0c89324a5fd31)
	{
		int num = 0;
		Run run = null;
		for (Node node = base.FirstChild; node != null; node = node.NextSibling)
		{
			if (node.NodeType == NodeType.Run)
			{
				Run run2 = (Run)node;
				if (run != null)
				{
					if (run.xeedad81aaed42a76.Equals(run2.xeedad81aaed42a76, Run.xfc7b12804e684767))
					{
						if (xfef0c89324a5fd31.Length == 0)
						{
							xfef0c89324a5fd31.Append(run.Text);
						}
						xfef0c89324a5fd31.Append(run2.Text);
						num++;
						RemoveChild(run);
					}
					else
					{
						x72a994d4278af191(run, xfef0c89324a5fd31);
					}
				}
				run = run2;
			}
			else
			{
				x72a994d4278af191(run, xfef0c89324a5fd31);
				run = null;
			}
		}
		x72a994d4278af191(run, xfef0c89324a5fd31);
		return num;
	}

	private static void x72a994d4278af191(Run xb0e5d73738e62f9e, StringBuilder xfef0c89324a5fd31)
	{
		if (xb0e5d73738e62f9e != null && xfef0c89324a5fd31.Length != 0)
		{
			xb0e5d73738e62f9e.Text = xfef0c89324a5fd31.ToString();
			xfef0c89324a5fd31.Length = 0;
		}
	}
}
