using x28925c9b27b37a46;
using x9db5f2e5af3d596e;

namespace Aspose.Words.Tables;

[JavaGenericArguments("CompositeNode<Cell>")]
public class Row : CompositeNode, x8f424b921df6c21a
{
	private xedb0eb766e25e0c9 xe661c29834d8220f;

	private RowFormat x263f760f2f871aeb;

	private CellCollection x4e16d8e7db7d7db1;

	public override NodeType NodeType => NodeType.Row;

	public Table ParentTable => (Table)base.xdfa6ecc6f742f086;

	public bool IsFirstRow => this == ParentTable.FirstRow;

	public bool IsLastRow => this == ParentTable.LastRow;

	internal Row xebb8ac1152da9a1f => (Row)base.xa6890a1cb2b8896e;

	internal Row xc22e54d85f137f3e => (Row)base.x90463af0c741fac1;

	internal int x9b1baea4e485d168
	{
		get
		{
			if (ParentTable == null)
			{
				return -1;
			}
			return ParentTable.Rows.IndexOf(this);
		}
	}

	public Cell FirstCell => (Cell)base.xfe93db1ba6e25886;

	public Cell LastCell => (Cell)base.xc0f45b01af564b77;

	public CellCollection Cells
	{
		get
		{
			if (x4e16d8e7db7d7db1 == null)
			{
				x4e16d8e7db7d7db1 = new CellCollection(this);
			}
			return x4e16d8e7db7d7db1;
		}
	}

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

	internal xedb0eb766e25e0c9 xedb0eb766e25e0c9
	{
		get
		{
			return xe661c29834d8220f;
		}
		set
		{
			xe661c29834d8220f = value;
		}
	}

	public Row(DocumentBase doc)
		: this(doc, xedb0eb766e25e0c9.xf5b6851196debf5a())
	{
	}

	internal Row(DocumentBase doc, xedb0eb766e25e0c9 rowPr)
		: base(doc)
	{
		xe661c29834d8220f = rowPr;
	}

	internal void x29079397f840690c()
	{
		if (xedb0eb766e25e0c9.x263d579af1d0d43f(4005))
		{
			TableStyle tableStyle = base.Document.Styles.x1976fb6958cf7237(xedb0eb766e25e0c9.x8301ab10c226b0c2, x988fcf605f8efa7e: false) as TableStyle;
			if (tableStyle == null)
			{
				xedb0eb766e25e0c9.x8301ab10c226b0c2 = 11;
			}
		}
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		Row row = (Row)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		row.xe661c29834d8220f = (xedb0eb766e25e0c9)xe661c29834d8220f.x8b61531c8ea35b85();
		row.x263f760f2f871aeb = null;
		row.x4e16d8e7db7d7db1 = null;
		return row;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return xf7ae36cd24e0b11c(visitor);
	}

	internal override VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitRowStart(this);
	}

	internal override VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitRowEnd(this);
	}

	public override string GetText()
	{
		return base.GetText();
	}

	public void EnsureMinimum()
	{
		Cell cell = FirstCell;
		if (cell == null)
		{
			cell = (Cell)AppendChild(new Cell(base.Document));
		}
		cell.EnsureMinimum();
	}

	internal override string x0598f184f69953c1()
	{
		return ControlChar.Cell;
	}

	internal override bool x8a4414b7d9d4073f(Node x40e458b3a58f5782)
	{
		return x2b1ee3a87b36a988.x4d9a8ed501b3faff(x40e458b3a58f5782);
	}

	internal void x7fd07ffddcb70376(CellCollection x77bb6a53fbd162d0)
	{
		for (int i = 0; i < x77bb6a53fbd162d0.Count; i++)
		{
			xf8cef531dae89ea3 xf8cef531dae89ea = Cells[i].xf8cef531dae89ea3;
			if (xf8cef531dae89ea != null)
			{
				x77bb6a53fbd162d0[i].xf8cef531dae89ea3 = (xf8cef531dae89ea3)xf8cef531dae89ea.x8b61531c8ea35b85();
			}
		}
	}

	internal void x47ab0b351d6caf1e()
	{
		if (FirstCell != null)
		{
			Run run = (Run)FirstCell.GetChild(NodeType.Run, 0, isDeep: true);
			if (run != null && run.xeedad81aaed42a76.x263d579af1d0d43f(130))
			{
				xedb0eb766e25e0c9.xae20093bed1e48a8(4520, true);
			}
			else
			{
				xedb0eb766e25e0c9.x52b190e626f65140(4520);
			}
		}
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
		xe661c29834d8220f.ClearAttrs();
	}

	void x8f424b921df6c21a.x90c1c4b3135f8e2d()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x043911e06761033b
		this.x043911e06761033b();
	}

	private void x4c76b6f836b082bc()
	{
		xe661c29834d8220f.x7ac658ee35724fbe();
	}

	void x8f424b921df6c21a.x7ac658ee35724fbe()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x4c76b6f836b082bc
		this.x4c76b6f836b082bc();
	}
}
