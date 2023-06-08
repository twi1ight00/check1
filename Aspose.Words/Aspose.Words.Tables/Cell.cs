using System.ComponentModel;
using x28925c9b27b37a46;
using x9db5f2e5af3d596e;

namespace Aspose.Words.Tables;

public class Cell : CompositeNode, xf516b6b0dd7e0d14
{
	private xf8cef531dae89ea3 xede608e9bc344cf9;

	private CellFormat x161e03c9585c73c3;

	private ParagraphCollection x27eb3ed41aea96de;

	private TableCollection x14a2f87d74dbdad1;

	public override NodeType NodeType => NodeType.Cell;

	internal Table x133f2db9e5b5690d => ParentRow.ParentTable;

	internal Cell xb2e852052ab1c1be => (Cell)base.xa6890a1cb2b8896e;

	internal Cell x2f5fd09b3d327fb0 => (Cell)base.x90463af0c741fac1;

	public Row ParentRow => (Row)base.xdfa6ecc6f742f086;

	public Paragraph FirstParagraph => (Paragraph)GetChild(NodeType.Paragraph, 0, isDeep: false);

	public Paragraph LastParagraph => (Paragraph)GetChild(NodeType.Paragraph, -1, isDeep: false);

	public bool IsFirstCell
	{
		get
		{
			if (ParentRow != null)
			{
				return this == ParentRow.FirstCell;
			}
			return false;
		}
	}

	public bool IsLastCell
	{
		get
		{
			if (ParentRow != null)
			{
				return this == ParentRow.LastCell;
			}
			return false;
		}
	}

	internal int x59bc0096de497989
	{
		get
		{
			if (ParentRow == null)
			{
				return -1;
			}
			return ParentRow.Cells.IndexOf(this);
		}
	}

	internal int x9b1baea4e485d168
	{
		get
		{
			if (ParentRow == null)
			{
				return -1;
			}
			return ParentRow.x9b1baea4e485d168;
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

	public ParagraphCollection Paragraphs
	{
		get
		{
			if (x27eb3ed41aea96de == null)
			{
				x27eb3ed41aea96de = new ParagraphCollection(this);
			}
			return x27eb3ed41aea96de;
		}
	}

	public TableCollection Tables
	{
		get
		{
			if (x14a2f87d74dbdad1 == null)
			{
				x14a2f87d74dbdad1 = new TableCollection(this);
			}
			return x14a2f87d74dbdad1;
		}
	}

	internal xf8cef531dae89ea3 xf8cef531dae89ea3
	{
		get
		{
			return xede608e9bc344cf9;
		}
		set
		{
			xede608e9bc344cf9 = value;
		}
	}

	public Cell(DocumentBase doc)
		: this(doc, new xf8cef531dae89ea3())
	{
	}

	internal Cell(DocumentBase doc, xf8cef531dae89ea3 cellPr)
		: base(doc)
	{
		xede608e9bc344cf9 = cellPr;
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		Cell cell = (Cell)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		xf8cef531dae89ea3 xf8cef531dae89ea = (xf8cef531dae89ea3)xede608e9bc344cf9.x8b61531c8ea35b85();
		cell.xede608e9bc344cf9 = xf8cef531dae89ea;
		cell.x161e03c9585c73c3 = null;
		cell.x27eb3ed41aea96de = null;
		cell.x14a2f87d74dbdad1 = null;
		return cell;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return xf7ae36cd24e0b11c(visitor);
	}

	internal override VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitCellStart(this);
	}

	internal override VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitCellEnd(this);
	}

	public void EnsureMinimum()
	{
		xb7dbd7bb3ed97d5b.x9d7a28ea717302c8(this);
	}

	internal override bool x8a4414b7d9d4073f(Node x40e458b3a58f5782)
	{
		return x2b1ee3a87b36a988.xb6578aa94903986e(x40e458b3a58f5782);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public object x34f1b0fbc88f0b8a(int xba08ce632055a1d9)
	{
		return xede608e9bc344cf9.xf7866f89640a29a3(xba08ce632055a1d9);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public object x4c5c531cd5714601(int xba08ce632055a1d9)
	{
		if (ParentRow != null)
		{
			xedb0eb766e25e0c9 xedb0eb766e25e0c = ParentRow.xedb0eb766e25e0c9;
			switch (xba08ce632055a1d9)
			{
			case 3070:
				return xedb0eb766e25e0c.xfe91eeeafcb3026a(4300);
			case 3090:
				return xedb0eb766e25e0c.xfe91eeeafcb3026a(4020);
			case 3080:
				return xedb0eb766e25e0c.xfe91eeeafcb3026a(4310);
			case 3100:
				return xedb0eb766e25e0c.xfe91eeeafcb3026a(4320);
			case 3110:
				return xedb0eb766e25e0c.xfe91eeeafcb3026a(ParentRow.IsFirstRow ? 4050 : 4090);
			case 3120:
				return xedb0eb766e25e0c.xfe91eeeafcb3026a(IsFirstCell ? 4060 : 4100);
			case 3130:
				return xedb0eb766e25e0c.xfe91eeeafcb3026a(ParentRow.IsLastRow ? 4070 : 4090);
			case 3140:
				return xedb0eb766e25e0c.xfe91eeeafcb3026a(IsLastCell ? 4080 : 4100);
			}
		}
		return xede608e9bc344cf9.xdafa1f94b023b665(xba08ce632055a1d9);
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

	internal object x88f8929cb2b3ee50(int xba08ce632055a1d9)
	{
		object obj = xede608e9bc344cf9.xf7866f89640a29a3(xba08ce632055a1d9);
		if (obj == null)
		{
			return ((xf516b6b0dd7e0d14)this).x4c5c531cd5714601(xba08ce632055a1d9);
		}
		if (obj is x11e014059489ae95 x11e014059489ae && x11e014059489ae.xc8ea2954a6825f32)
		{
			return ((xf516b6b0dd7e0d14)this).x4c5c531cd5714601(xba08ce632055a1d9);
		}
		return obj;
	}

	internal xf8cef531dae89ea3 x0974156b728aa5fc()
	{
		xf8cef531dae89ea3 xf8cef531dae89ea = new xf8cef531dae89ea3();
		x7405537c568a1df8(3120, xf8cef531dae89ea);
		x7405537c568a1df8(3140, xf8cef531dae89ea);
		x7405537c568a1df8(3110, xf8cef531dae89ea);
		x7405537c568a1df8(3130, xf8cef531dae89ea);
		x7405537c568a1df8(3090, xf8cef531dae89ea);
		x7405537c568a1df8(3100, xf8cef531dae89ea);
		x7405537c568a1df8(3070, xf8cef531dae89ea);
		x7405537c568a1df8(3080, xf8cef531dae89ea);
		xede608e9bc344cf9.xab3af626b1405ee8(xf8cef531dae89ea);
		return xf8cef531dae89ea;
	}

	private void x7405537c568a1df8(int xba08ce632055a1d9, xf8cef531dae89ea3 x189ab8fa97bda223)
	{
		x189ab8fa97bda223.xae20093bed1e48a8(xba08ce632055a1d9, x4c5c531cd5714601(xba08ce632055a1d9));
	}
}
