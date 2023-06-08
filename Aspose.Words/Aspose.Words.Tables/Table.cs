using System;
using System.Collections;
using System.Drawing;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x9db5f2e5af3d596e;
using xde385359626e77eb;

namespace Aspose.Words.Tables;

[JavaGenericArguments("CompositeNode<Row>")]
public class Table : CompositeNode
{
	internal const int xf0a3523bf16ce322 = 63;

	private RowCollection x8b9f9162c01e0fa5;

	private xedb0eb766e25e0c9 xe661c29834d8220f;

	public override NodeType NodeType => NodeType.Table;

	public Row FirstRow => (Row)base.xfe93db1ba6e25886;

	public Row LastRow => (Row)base.xc0f45b01af564b77;

	public RowCollection Rows
	{
		get
		{
			if (x8b9f9162c01e0fa5 == null)
			{
				x8b9f9162c01e0fa5 = new RowCollection(this);
			}
			return x8b9f9162c01e0fa5;
		}
	}

	internal string xa062a601a9c3c2aa => (string)x40ae3bf9ca9cd06e(5000);

	internal string x3d235fc95c355365 => (string)x40ae3bf9ca9cd06e(5010);

	internal bool x752cfab9af626fd5 => base.xdfa6ecc6f742f086.NodeType == NodeType.Cell;

	public TableAlignment Alignment
	{
		get
		{
			return (TableAlignment)x40ae3bf9ca9cd06e(4010);
		}
		set
		{
			x8e0da74bbd276116(4010, value);
		}
	}

	public bool AllowAutoFit
	{
		get
		{
			return (bool)x40ae3bf9ca9cd06e(4240);
		}
		set
		{
			x8e0da74bbd276116(4240, value);
		}
	}

	public PreferredWidth PreferredWidth
	{
		get
		{
			return (PreferredWidth)x40ae3bf9ca9cd06e(4230);
		}
		set
		{
			x8e0da74bbd276116(4230, value);
		}
	}

	public bool Bidi
	{
		get
		{
			return (bool)x40ae3bf9ca9cd06e(4380);
		}
		set
		{
			x8e0da74bbd276116(4380, value);
		}
	}

	public double LeftPadding
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)x40ae3bf9ca9cd06e(4020));
		}
		set
		{
			x8e0da74bbd276116(4020, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double RightPadding
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)x40ae3bf9ca9cd06e(4320));
		}
		set
		{
			x8e0da74bbd276116(4320, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double TopPadding
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)x40ae3bf9ca9cd06e(4300));
		}
		set
		{
			x8e0da74bbd276116(4300, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double BottomPadding
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)x40ae3bf9ca9cd06e(4310));
		}
		set
		{
			x8e0da74bbd276116(4310, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double CellSpacing
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)x40ae3bf9ca9cd06e(4290));
		}
		set
		{
			x8e0da74bbd276116(4290, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public double LeftIndent
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2((int)x40ae3bf9ca9cd06e(4340));
		}
		set
		{
			x8e0da74bbd276116(4340, x4574ea26106f0edb.x88bf16f2386d633e(value));
		}
	}

	public TableStyleOptions StyleOptions
	{
		get
		{
			return (TableStyleOptions)x40ae3bf9ca9cd06e(4140);
		}
		set
		{
			x8e0da74bbd276116(4140, value);
		}
	}

	public Style Style
	{
		get
		{
			return base.Document.Styles.xf194004582627ed5(x8301ab10c226b0c2, 11);
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (value.Document != base.Document)
			{
				throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kbdilckijcbjadijknojkcgkicnkkcelkbllabcmimimhaanhahnlaonlafohamonpcpgakpalaabaiajpoahkfbfombbkdccokceobdonidlnpdhngebonebnefhnlfkncgdijgemahmmhhnlohmmfibmmigldjmlkjplbkghik", 1780253382)));
			}
			if (value.Type != StyleType.Table)
			{
				throw new ArgumentException("This style is not a table style.");
			}
			x8301ab10c226b0c2 = value.x8301ab10c226b0c2;
		}
	}

	public string StyleName
	{
		get
		{
			return Style.Name;
		}
		set
		{
			Style = base.Document.Styles.xfee6a7b399450516(value);
		}
	}

	public StyleIdentifier StyleIdentifier
	{
		get
		{
			return Style.StyleIdentifier;
		}
		set
		{
			Style = base.Document.Styles.x590d8ef356786501(value);
		}
	}

	internal int x8301ab10c226b0c2
	{
		get
		{
			return (int)x40ae3bf9ca9cd06e(4005);
		}
		set
		{
			x8e0da74bbd276116(4005, value);
		}
	}

	internal bool x6f6877b222ed4153
	{
		get
		{
			if (Rows.Count > 0)
			{
				return Rows[0].xedb0eb766e25e0c9.x6f6877b222ed4153;
			}
			return false;
		}
	}

	internal xedb0eb766e25e0c9 xedb0eb766e25e0c9
	{
		get
		{
			if (xe661c29834d8220f == null)
			{
				xe661c29834d8220f = new xedb0eb766e25e0c9();
			}
			return xe661c29834d8220f;
		}
	}

	internal bool x132be151ef3fb907
	{
		get
		{
			foreach (Row row in Rows)
			{
				if (row.xedb0eb766e25e0c9.xcb78713836fcc98a)
				{
					return true;
				}
			}
			return false;
		}
	}

	public Table(DocumentBase doc)
		: base(doc)
	{
	}

	internal override Node x8b61531c8ea35b85(bool x7a5f12b98e34a590, x15a33f6d96885286 xe870d6f33992ceb4)
	{
		Table table = (Table)base.x8b61531c8ea35b85(x7a5f12b98e34a590, xe870d6f33992ceb4);
		table.x8b9f9162c01e0fa5 = null;
		return table;
	}

	public override bool Accept(DocumentVisitor visitor)
	{
		return xf7ae36cd24e0b11c(visitor);
	}

	internal override VisitorAction x2449520719b1e37e(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitTableStart(this);
	}

	internal override VisitorAction x3bbb475596fa1de1(DocumentVisitor x672ff13faf031f3d)
	{
		return x672ff13faf031f3d.VisitTableEnd(this);
	}

	public void EnsureMinimum()
	{
		Row row = FirstRow;
		if (row == null)
		{
			row = (Row)AppendChild(new Row(base.Document));
		}
		row.EnsureMinimum();
	}

	internal Cell xfeb19f1007c0b581(int xbeb0e74fd1e3aefb, int x78a7603cacf2ae22)
	{
		if (x78a7603cacf2ae22 < 0 || x78a7603cacf2ae22 >= Rows.Count)
		{
			return null;
		}
		CellCollection cells = Rows[x78a7603cacf2ae22].Cells;
		if (xbeb0e74fd1e3aefb < 0 || xbeb0e74fd1e3aefb >= cells.Count)
		{
			return null;
		}
		return cells[xbeb0e74fd1e3aefb];
	}

	internal int xbd4adf8f33d07995()
	{
		int num = 0;
		for (Row row = FirstRow; row != null; row = row.xebb8ac1152da9a1f)
		{
			num = System.Math.Max(num, row.Cells.Count);
		}
		return num;
	}

	internal x66ed6507f98b1be8 xae19a615b411c9fa()
	{
		xdce5f72473519d4e xdce5f72473519d4e = new xdce5f72473519d4e(this);
		return xdce5f72473519d4e.xadbaf0fef5a4f7fb();
	}

	internal void xdd7eca4a70bd2700()
	{
		for (Row row = FirstRow; row != null; row = row.xebb8ac1152da9a1f)
		{
			Cell cell = row.FirstCell;
			Cell cell2 = null;
			while (cell != null)
			{
				switch (cell.xf8cef531dae89ea3.x338a5e6ab7c5595e)
				{
				case CellMerge.First:
					cell2 = cell;
					cell2.xf8cef531dae89ea3.x338a5e6ab7c5595e = CellMerge.None;
					break;
				case CellMerge.Previous:
					if (cell2 != null)
					{
						cell2.xf8cef531dae89ea3.xdc1bf80853046136 = cell2.xf8cef531dae89ea3.xdc1bf80853046136 + cell.xf8cef531dae89ea3.xdc1bf80853046136;
						if (cell2.xf8cef531dae89ea3.xce5b83b714f11fba.x08428aa3999da322 && cell.xf8cef531dae89ea3.xce5b83b714f11fba.x08428aa3999da322)
						{
							int xf6495da3f9ed2d9c = cell2.xf8cef531dae89ea3.xce5b83b714f11fba.xdf4645c89f0e47f6 + cell.xf8cef531dae89ea3.xce5b83b714f11fba.xdf4645c89f0e47f6;
							cell2.xf8cef531dae89ea3.xce5b83b714f11fba = PreferredWidth.xf6bcf515ffcb5cc9(xf6495da3f9ed2d9c);
						}
						cell.Remove();
						cell = cell2;
					}
					else
					{
						cell.xf8cef531dae89ea3.x338a5e6ab7c5595e = CellMerge.None;
					}
					break;
				case CellMerge.None:
					cell2 = null;
					break;
				default:
					throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mlejcnljmmckmmjkkmalpmhldmolchfmclmmbldnflknclbodgionkpockgpmknpojeajjlabfcbckjbekacijhckiocaffd", 257922151)));
				}
				cell = cell.xb2e852052ab1c1be;
			}
		}
	}

	internal void x148387b100b7e1c7()
	{
		if (!base.x73db39780c76cb8d)
		{
			return;
		}
		x66f2271ac271c2df x66f2271ac271c2df = new x66f2271ac271c2df(this);
		if (x66f2271ac271c2df.x7eab159619d586e1.Length == 0)
		{
			return;
		}
		Hashtable hashtable = new Hashtable();
		Hashtable hashtable2 = new Hashtable();
		for (Row row = FirstRow; row != null; row = row.xebb8ac1152da9a1f)
		{
			x66f2271ac271c2df.xebb8ac1152da9a1f(row);
			Hashtable hashtable3 = new Hashtable();
			Hashtable hashtable4 = new Hashtable();
			int num = x66f2271ac271c2df.x71e5b802707a5021;
			for (Cell cell = row.FirstCell; cell != null; cell = cell.xb2e852052ab1c1be)
			{
				int num2 = x66f2271ac271c2df.xb2e852052ab1c1be();
				if (cell.xf8cef531dae89ea3.x1a1dda35b3ae703d != 0)
				{
					object obj = hashtable[num];
					if (obj == null || (int)obj != num2)
					{
						cell.xf8cef531dae89ea3.x1a1dda35b3ae703d = CellMerge.First;
					}
					hashtable3[num] = num2;
					hashtable4[num] = cell;
				}
				num += num2;
			}
			foreach (DictionaryEntry item in hashtable2)
			{
				Cell cell2 = (Cell)item.Value;
				if (cell2.xf8cef531dae89ea3.x1a1dda35b3ae703d == CellMerge.First && hashtable4[item.Key] == null)
				{
					cell2.xf8cef531dae89ea3.x1a1dda35b3ae703d = CellMerge.None;
				}
			}
			hashtable = hashtable3;
			hashtable2 = hashtable4;
		}
		for (Cell cell3 = LastRow.FirstCell; cell3 != null; cell3 = cell3.xb2e852052ab1c1be)
		{
			if (cell3.xf8cef531dae89ea3.x1a1dda35b3ae703d == CellMerge.First)
			{
				cell3.xf8cef531dae89ea3.x1a1dda35b3ae703d = CellMerge.None;
			}
		}
	}

	internal int xe07e47b1653dcd90()
	{
		int num = 0;
		Row row = FirstRow;
		while (row != null && row.xedb0eb766e25e0c9.xfb66190d5f2f66ce)
		{
			num++;
			row = row.xebb8ac1152da9a1f;
		}
		return num;
	}

	internal int x7ffcb3c8df4c42b3()
	{
		Row firstRow = FirstRow;
		if (firstRow == null)
		{
			return 0;
		}
		xf8cef531dae89ea3 xf8cef531dae89ea = firstRow.FirstCell.xf8cef531dae89ea3;
		return firstRow.xedb0eb766e25e0c9.x7ffcb3c8df4c42b3(xf8cef531dae89ea, x752cfab9af626fd5);
	}

	internal override bool x8a4414b7d9d4073f(Node x40e458b3a58f5782)
	{
		return x2b1ee3a87b36a988.x1a81241312e9c0d5(x40e458b3a58f5782);
	}

	public void SetBorders(LineStyle lineStyle, double lineWidth, Color color)
	{
		foreach (BorderType key in xedb0eb766e25e0c9.x01e813efe52383e6.GetKeyList())
		{
			SetBorder(key, lineStyle, lineWidth, color, isOverrideCellBorders: true);
		}
	}

	public void SetBorder(BorderType borderType, LineStyle lineStyle, double lineWidth, Color color, bool isOverrideCellBorders)
	{
		if (isOverrideCellBorders)
		{
			x44ee3d47f70ed5d7(borderType);
		}
		for (Row row = FirstRow; row != null; row = row.xebb8ac1152da9a1f)
		{
			Border border = row.RowFormat.Borders[borderType];
			border.LineStyle = lineStyle;
			border.LineWidth = lineWidth;
			border.Color = color;
		}
	}

	public void ClearBorders()
	{
		for (Row row = FirstRow; row != null; row = row.xebb8ac1152da9a1f)
		{
			row.xedb0eb766e25e0c9.x42fc4ca1def92b26();
			for (Cell cell = row.FirstCell; cell != null; cell = cell.xb2e852052ab1c1be)
			{
				cell.xf8cef531dae89ea3.x42fc4ca1def92b26();
			}
		}
	}

	private void x44ee3d47f70ed5d7(BorderType xe6e655492739f7d2)
	{
		switch (xe6e655492739f7d2)
		{
		case BorderType.Top:
		{
			Row firstRow = FirstRow;
			if (firstRow != null)
			{
				for (Cell cell3 = firstRow.FirstCell; cell3 != null; cell3 = cell3.xb2e852052ab1c1be)
				{
					cell3.xf8cef531dae89ea3.x52b190e626f65140(3110);
				}
			}
			break;
		}
		case BorderType.Bottom:
		{
			Row lastRow = LastRow;
			if (lastRow != null)
			{
				for (Cell cell4 = lastRow.FirstCell; cell4 != null; cell4 = cell4.xb2e852052ab1c1be)
				{
					cell4.xf8cef531dae89ea3.x52b190e626f65140(3130);
				}
			}
			break;
		}
		case BorderType.Left:
		{
			for (Row row2 = FirstRow; row2 != null; row2 = row2.xebb8ac1152da9a1f)
			{
				row2.FirstCell?.xf8cef531dae89ea3.x52b190e626f65140(3120);
			}
			break;
		}
		case BorderType.Right:
		{
			for (Row row4 = FirstRow; row4 != null; row4 = row4.xebb8ac1152da9a1f)
			{
				row4.LastCell?.xf8cef531dae89ea3.x52b190e626f65140(3140);
			}
			break;
		}
		case BorderType.Horizontal:
		{
			for (Row row3 = FirstRow; row3 != null; row3 = row3.xebb8ac1152da9a1f)
			{
				bool flag3 = !row3.IsFirstRow;
				bool flag4 = !row3.IsLastRow;
				for (Cell cell2 = row3.FirstCell; cell2 != null; cell2 = cell2.xb2e852052ab1c1be)
				{
					if (flag3)
					{
						cell2.xf8cef531dae89ea3.x52b190e626f65140(3110);
					}
					if (flag4)
					{
						cell2.xf8cef531dae89ea3.x52b190e626f65140(3130);
					}
				}
			}
			break;
		}
		case BorderType.Vertical:
		{
			for (Row row = FirstRow; row != null; row = row.xebb8ac1152da9a1f)
			{
				for (Cell cell = row.FirstCell; cell != null; cell = cell.xb2e852052ab1c1be)
				{
					bool flag = !cell.IsFirstCell;
					bool flag2 = !cell.IsLastCell;
					if (flag)
					{
						cell.xf8cef531dae89ea3.x52b190e626f65140(3120);
					}
					if (flag2)
					{
						cell.xf8cef531dae89ea3.x52b190e626f65140(3140);
					}
				}
			}
			break;
		}
		default:
			throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kclpaecaedjaeeabjdhblcobgcfcedmcccddobkdhnaegbieacpeacgfpanfnaeghblgcmbhdbjhfbaijahilpnibmej", 1180302037)));
		}
	}

	public void SetShading(TextureIndex texture, Color foregroundColor, Color backgroundColor)
	{
		for (Row row = FirstRow; row != null; row = row.xebb8ac1152da9a1f)
		{
			for (Cell cell = row.FirstCell; cell != null; cell = cell.xb2e852052ab1c1be)
			{
				Shading shading = cell.CellFormat.Shading;
				shading.Texture = texture;
				shading.ForegroundPatternColor = foregroundColor;
				shading.BackgroundPatternColor = backgroundColor;
			}
		}
	}

	public void ClearShading()
	{
		for (Row row = FirstRow; row != null; row = row.xebb8ac1152da9a1f)
		{
			row.xedb0eb766e25e0c9.x023ddaca72a762d0();
			for (Cell cell = row.FirstCell; cell != null; cell = cell.xb2e852052ab1c1be)
			{
				cell.xf8cef531dae89ea3.x023ddaca72a762d0();
			}
		}
	}

	public void AutoFit(AutoFitBehavior behavior)
	{
		switch (behavior)
		{
		case AutoFitBehavior.AutoFitToContents:
			x7bac5615e65f6fcf();
			break;
		case AutoFitBehavior.AutoFitToWindow:
			x9f3f5dc6d77c1c6a();
			break;
		case AutoFitBehavior.FixedColumnWidths:
			xea4acecd4b281868();
			break;
		default:
			throw new ArgumentException("Unknown auto fit behavior.");
		}
	}

	internal int xabc668f72c127bc3()
	{
		if (Rows.Count == 0)
		{
			return 0;
		}
		int num = 0;
		foreach (Row row in Rows)
		{
			int num2 = 0;
			foreach (Cell cell in row.Cells)
			{
				num2 += cell.xf8cef531dae89ea3.xdc1bf80853046136;
			}
			num = System.Math.Max(num, num2);
		}
		return num;
	}

	private void x7bac5615e65f6fcf()
	{
		AllowAutoFit = true;
		x0adc21e30d6410b3(4230);
		xdb5170450c1d0fba(3020);
		xae19a615b411c9fa();
	}

	private void x9f3f5dc6d77c1c6a()
	{
		AllowAutoFit = true;
		x8e0da74bbd276116(4230, PreferredWidth.FromPercent(100.0));
		xdb5170450c1d0fba(3020);
		xae19a615b411c9fa();
	}

	private void xea4acecd4b281868()
	{
		AllowAutoFit = false;
		x0adc21e30d6410b3(4230);
	}

	private void xdb5170450c1d0fba(int xba08ce632055a1d9)
	{
		for (Row row = FirstRow; row != null; row = row.xebb8ac1152da9a1f)
		{
			for (Cell cell = row.FirstCell; cell != null; cell = cell.xb2e852052ab1c1be)
			{
				cell.xf8cef531dae89ea3.x52b190e626f65140(xba08ce632055a1d9);
			}
		}
	}

	private void x0adc21e30d6410b3(int xba08ce632055a1d9)
	{
		for (Row row = FirstRow; row != null; row = row.xebb8ac1152da9a1f)
		{
			row.xedb0eb766e25e0c9.x52b190e626f65140(xba08ce632055a1d9);
		}
	}

	private void x8e0da74bbd276116(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		if (FirstRow == null)
		{
			throw new InvalidOperationException("Formatting cannot be applied because the table is empty. Add at least one row to the table first.");
		}
		for (Row row = FirstRow; row != null; row = row.xebb8ac1152da9a1f)
		{
			row.xedb0eb766e25e0c9.xae20093bed1e48a8(xba08ce632055a1d9, xbcea506a33cf9111);
		}
	}

	private object x40ae3bf9ca9cd06e(int xba08ce632055a1d9)
	{
		Row firstRow = FirstRow;
		if (firstRow == null)
		{
			return xedb0eb766e25e0c9.x0095b789d636f3ae(xba08ce632055a1d9);
		}
		return firstRow.xedb0eb766e25e0c9.xfe91eeeafcb3026a(xba08ce632055a1d9);
	}
}
