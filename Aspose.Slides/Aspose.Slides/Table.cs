using System;
using System.Drawing;
using Aspose.Slides.Theme;
using ns11;
using ns16;
using ns224;
using ns24;
using ns4;
using ns7;

namespace Aspose.Slides;

public sealed class Table : GraphicalObject, IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGraphicalObject, ITable
{
	internal enum Enum10
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6
	}

	private const string string_4 = "Can't break merged cells";

	internal const double double_0 = 3.937007874015748E-05;

	private const double double_1 = 1.0;

	private byte byte_0;

	internal RowCollection rowCollection_0;

	internal ColumnCollection columnCollection_0;

	private Class141[,] class141_0;

	private Class140[,] class140_0;

	private Class140[,] class140_1;

	internal Guid guid_0 = Guid.Empty;

	private Class149[,,] class149_0;

	private Class148[,] class148_0;

	private Class142[,] class142_0;

	internal Paragraph.Class514 class514_0 = new Paragraph.Class514();

	internal bool bool_1;

	private bool bool_2;

	internal new Class291 PPTXUnsupportedProps => (Class291)base.PPTXUnsupportedProps;

	internal Class144 TableStyle
	{
		get
		{
			return PPTXUnsupportedProps.TableStyle;
		}
		set
		{
			PPTXUnsupportedProps.TableStyle = value;
		}
	}

	public TableStylePreset StylePreset
	{
		get
		{
			if (guid_0 == Guid.Empty)
			{
				if (TableStyle == null)
				{
					return TableStylePreset.None;
				}
				return TableStylePreset.Custom;
			}
			return ((Presentation)base.Presentation).TableStyles.method_1(guid_0);
		}
		set
		{
			switch (value)
			{
			case TableStylePreset.None:
				TableStyle = null;
				guid_0 = Guid.Empty;
				break;
			case TableStylePreset.Custom:
				if (TableStyle == null)
				{
					TableStyle = new Class144(this, Guid.Empty, null);
				}
				guid_0 = Guid.Empty;
				break;
			default:
			{
				Guid guid = ((Presentation)base.Presentation).TableStyles.method_2(value);
				if (guid == Guid.Empty)
				{
					return;
				}
				guid_0 = guid;
				TableStyle = ((Presentation)base.Presentation).TableStyles.method_0(guid);
				break;
			}
			}
			method_16();
		}
	}

	public ICell this[int columnIndex, int rowIndex] => rowCollection_0[rowIndex][columnIndex];

	public IRowCollection Rows => rowCollection_0;

	public IColumnCollection Columns => columnCollection_0;

	public bool RightToLeft
	{
		get
		{
			return (byte_0 & 1) != 0;
		}
		set
		{
			if (value)
			{
				byte_0 |= 1;
			}
			else
			{
				byte_0 &= 254;
			}
		}
	}

	public bool FirstRow
	{
		get
		{
			return (byte_0 & 2) != 0;
		}
		set
		{
			if (value)
			{
				byte_0 |= 2;
			}
			else
			{
				byte_0 &= 253;
			}
			method_16();
		}
	}

	public bool FirstCol
	{
		get
		{
			return (byte_0 & 4) != 0;
		}
		set
		{
			if (value)
			{
				byte_0 |= 4;
			}
			else
			{
				byte_0 &= 251;
			}
			method_16();
		}
	}

	public bool LastRow
	{
		get
		{
			return (byte_0 & 8) != 0;
		}
		set
		{
			if (value)
			{
				byte_0 |= 8;
			}
			else
			{
				byte_0 &= 247;
			}
			method_16();
		}
	}

	public bool LastCol
	{
		get
		{
			return (byte_0 & 0x10) != 0;
		}
		set
		{
			if (value)
			{
				byte_0 |= 16;
			}
			else
			{
				byte_0 &= 239;
			}
			method_16();
		}
	}

	public bool HorizontalBanding
	{
		get
		{
			return (byte_0 & 0x20) != 0;
		}
		set
		{
			if (value)
			{
				byte_0 |= 32;
			}
			else
			{
				byte_0 &= 223;
			}
			method_16();
		}
	}

	public bool VerticalBanding
	{
		get
		{
			return (byte_0 & 0x40) != 0;
		}
		set
		{
			if (value)
			{
				byte_0 |= 64;
			}
			else
			{
				byte_0 &= 191;
			}
			method_16();
		}
	}

	internal override Class154 RawFrameImpl
	{
		get
		{
			return base.RawFrameImpl;
		}
		set
		{
			base.RawFrameImpl = value;
			bool_1 = false;
		}
	}

	internal Class141[,] CellStylesCache
	{
		get
		{
			if (class141_0 != null)
			{
				return class141_0;
			}
			method_17(new Class6002(), null, withBorders: false);
			return class141_0;
		}
	}

	internal Class149[,,] BorderStylesCachePVITemp
	{
		get
		{
			if (class149_0 == null)
			{
				method_19(out class149_0, out class148_0, out class142_0);
			}
			return class149_0;
		}
	}

	internal Class148[,] CellFillStylesCachePVITemp
	{
		get
		{
			if (class148_0 == null)
			{
				method_19(out class149_0, out class148_0, out class142_0);
			}
			return class148_0;
		}
	}

	internal Class142[,] CellTextStylesCachePVITemp
	{
		get
		{
			if (class142_0 == null)
			{
				method_19(out class149_0, out class148_0, out class142_0);
			}
			return class142_0;
		}
	}

	IGraphicalObject ITable.AsIGraphicalObject => this;

	internal Table(IBaseSlide parent)
		: base(parent, new Class291())
	{
		rowCollection_0 = new RowCollection(this);
		columnCollection_0 = rowCollection_0.columnCollection_0;
		effectFormat_0 = new EffectFormat(this);
	}

	public ICell MergeCells(ICell cell1, ICell cell2, bool allowSplitting)
	{
		Cell cell3 = (Cell)cell1;
		Cell cell4 = (Cell)cell2;
		if (cell3 == cell4)
		{
			return cell3;
		}
		int num = Math.Min(cell3.FirstColumnIndex, cell4.FirstColumnIndex);
		int num2 = Math.Min(cell3.FirstRowIndex, cell4.FirstRowIndex);
		int num3 = Math.Max(cell3.NextColumnIndex, cell4.NextColumnIndex);
		int num4 = Math.Max(cell3.NextRowIndex, cell4.NextRowIndex);
		int num5 = num;
		Cell cell5;
		while (true)
		{
			if (num5 < num3)
			{
				IColumn column = columnCollection_0[num5];
				cell5 = (Cell)column[num2];
				int firstRowIndex = cell5.FirstRowIndex;
				if (firstRowIndex < num2)
				{
					if (!allowSplitting)
					{
						throw new PptxEditException("Can't break merged cells");
					}
					cell5.method_5(num2 - firstRowIndex);
				}
				cell5 = (Cell)column[num4 - 1];
				int firstRowIndex2 = cell5.FirstRowIndex;
				if (firstRowIndex2 + cell5.RowSpan > num4)
				{
					if (!allowSplitting)
					{
						throw new PptxEditException("Can't break merged cells");
					}
					cell5.method_5(num4 - firstRowIndex2);
				}
				num5 += cell5.ColSpan;
				continue;
			}
			for (int i = num2; i < num4; i += cell5.RowSpan)
			{
				Row row = rowCollection_0.method_0(i);
				cell5 = (Cell)row[num];
				int firstColumnIndex = cell5.FirstColumnIndex;
				if (firstColumnIndex < num)
				{
					if (!allowSplitting)
					{
						throw new PptxEditException("Can't break merged cells");
					}
					cell5.method_4(num - firstColumnIndex);
				}
				cell5 = (Cell)row[num3 - 1];
				int firstColumnIndex2 = cell5.FirstColumnIndex;
				if (firstColumnIndex2 + cell5.ColSpan > num3)
				{
					if (!allowSplitting)
					{
						throw new PptxEditException("Can't break merged cells");
					}
					cell5.method_4(num4 - firstColumnIndex2);
				}
			}
			break;
		}
		cell5 = GetCell(num, num2);
		cell5.cell_0 = null;
		cell5.int_1 = num3 - num;
		cell5.int_0 = num4 - num2;
		cell5.method_1(mergeText: true);
		rowCollection_0.method_8(num2, num4 - num2);
		columnCollection_0.method_8(num, num3 - num);
		method_16();
		return cell5;
	}

	internal void method_14(int[] colSplitIndexes, int colStartIndex, int colIndexCount, int[] rowSplitIndexes, int rowStartIndex, int rowIndexCount)
	{
		int num = colStartIndex + colIndexCount;
		int num2 = rowStartIndex + rowIndexCount;
		int num3 = colSplitIndexes[colStartIndex];
		for (int i = colStartIndex + 1; i < num; i++)
		{
			int num4 = colSplitIndexes[i];
			int num5 = rowSplitIndexes[rowStartIndex];
			for (int j = rowStartIndex + 1; j < num2; j++)
			{
				int num6 = rowSplitIndexes[j];
				Cell cell = GetCell(num3, num5);
				cell.int_1 = num4 - num3;
				cell.int_0 = num6 - num5;
				cell.method_1(mergeText: true);
			}
			num3 = num4;
		}
		rowCollection_0.method_8(colSplitIndexes[colStartIndex], colSplitIndexes[num - 1] - colSplitIndexes[colStartIndex]);
		columnCollection_0.method_8(colSplitIndexes[colStartIndex], colSplitIndexes[num - 1] - colSplitIndexes[colStartIndex]);
	}

	internal void Clear()
	{
		rowCollection_0.Clear();
		columnCollection_0.Clear();
	}

	internal void method_15(double[] colWidths, double[] rowHeights)
	{
		Clear();
		double num = 0.0;
		for (int i = 0; i < colWidths.Length; i++)
		{
			columnCollection_0.method_2(colWidths[i]);
			num += colWidths[i];
		}
		num = 0.0;
		for (int j = 0; j < rowHeights.Length; j++)
		{
			rowCollection_0.method_2(Math.Max(rowHeights[j], 1.0));
			num += Math.Max(rowHeights[j], 1.0);
		}
		method_16();
	}

	internal Cell GetCell(int columnIndex, int rowIndex)
	{
		return rowCollection_0.method_0(rowIndex).vmethod_3(columnIndex);
	}

	internal void method_16()
	{
		class141_0 = null;
		bool_1 = false;
		class149_0 = null;
		class148_0 = null;
		class142_0 = null;
	}

	internal static ILineFormat smethod_2(Cell firstCell, Cell secondCell, bool vertical)
	{
		if (firstCell == null && secondCell == null)
		{
			return null;
		}
		if (firstCell == null)
		{
			ILineFormat lineFormat = secondCell.BorderTop;
			if (vertical)
			{
				lineFormat = secondCell.BorderLeft;
			}
			if (lineFormat.IsFormatNotDefined)
			{
				lineFormat = secondCell.BaseCell.BorderTop;
				if (vertical)
				{
					lineFormat = secondCell.BaseCell.BorderLeft;
				}
			}
			return lineFormat;
		}
		if (secondCell == null)
		{
			ILineFormat lineFormat = firstCell.BorderBottom;
			if (vertical)
			{
				lineFormat = firstCell.BorderRight;
			}
			if (lineFormat.IsFormatNotDefined)
			{
				lineFormat = firstCell.BaseCell.BorderBottom;
				if (vertical)
				{
					lineFormat = firstCell.BaseCell.BorderRight;
				}
			}
			return lineFormat;
		}
		if (secondCell.IsSlaveCell && secondCell.BaseCell == firstCell.BaseCell)
		{
			return null;
		}
		ILineFormat lineFormat2 = firstCell.BorderBottom;
		if (vertical)
		{
			lineFormat2 = firstCell.BorderRight;
		}
		ILineFormat lineFormat3 = secondCell.BorderTop;
		if (vertical)
		{
			lineFormat3 = secondCell.BorderLeft;
		}
		bool isFormatNotDefined = lineFormat2.IsFormatNotDefined;
		bool isFormatNotDefined2 = lineFormat3.IsFormatNotDefined;
		if (isFormatNotDefined && isFormatNotDefined2)
		{
			lineFormat2 = firstCell.BaseCell.BorderBottom;
			if (vertical)
			{
				lineFormat2 = firstCell.BaseCell.BorderRight;
			}
			lineFormat3 = secondCell.BaseCell.BorderTop;
			if (vertical)
			{
				lineFormat3 = secondCell.BaseCell.BorderLeft;
			}
			if (lineFormat3.IsFormatNotDefined)
			{
				return lineFormat2;
			}
			return lineFormat3;
		}
		if (isFormatNotDefined2)
		{
			return lineFormat2;
		}
		return lineFormat3;
	}

	internal void method_17(Class6002 userToDevice, Class169 rc, bool withBorders)
	{
		bool flag = class141_0 == null;
		if (withBorders && (class140_0 == null || class140_1 == null))
		{
			flag = true;
		}
		if (!flag)
		{
			return;
		}
		int count = rowCollection_0.Count;
		int count2 = columnCollection_0.Count;
		Class145 supportWrapper = new Class145(base.Slide, rc, null, null, null, Enum9.const_0);
		Class141[,] array = new Class141[count, count2];
		Class140[,] array2 = new Class140[count, count2 + 1];
		Class140[,] array3 = new Class140[count + 1, count2];
		if (class141_0 == null)
		{
			for (int i = 0; i < count; i++)
			{
				Row row = rowCollection_0.method_0(i);
				int num = 0;
				while (num < count2)
				{
					Cell cell = row.vmethod_3(num);
					if (cell.IsSlaveCell)
					{
						if (i != 0)
						{
							for (int num2 = cell.BaseCell.ColSpan; num2 > 0; num2--)
							{
								array[i, num] = array[i - 1, num];
								num++;
							}
							continue;
						}
						throw new Exception("Slave cell in first row on the " + num + " column!");
					}
					array[i, num] = new Class141(cell, userToDevice, supportWrapper);
					if (cell.ColSpan > 1)
					{
						for (int num3 = cell.ColSpan - 1; num3 > 0; num3--)
						{
							array[i, num + 1] = array[i, num];
							num++;
						}
					}
					num++;
				}
			}
			class140_0 = null;
			class140_1 = null;
		}
		if (withBorders && class140_0 == null)
		{
			for (int num = 0; num <= count2; num++)
			{
				for (int i = 0; i < count; i++)
				{
					Row row2 = rowCollection_0.method_0(i);
					Cell firstCell = null;
					Cell secondCell = null;
					if (num > 0)
					{
						firstCell = row2.vmethod_3(num - 1);
					}
					if (num < count2)
					{
						secondCell = row2.vmethod_3(num);
					}
					ILineFormat lineFormat = smethod_2(firstCell, secondCell, vertical: true);
					if (lineFormat != null)
					{
						array2[i, num] = new Class140(lineFormat, userToDevice, supportWrapper);
					}
				}
			}
		}
		if (withBorders && class140_1 == null)
		{
			for (int i = 0; i <= count; i++)
			{
				Row row3 = null;
				Row row4 = null;
				if (i > 0)
				{
					row3 = rowCollection_0.method_0(i - 1);
				}
				if (i < count)
				{
					row4 = rowCollection_0.method_0(i);
				}
				for (int num = 0; num < count2; num++)
				{
					Cell firstCell2 = null;
					Cell secondCell2 = null;
					if (row3 != null)
					{
						firstCell2 = row3.vmethod_3(num);
					}
					if (row4 != null)
					{
						secondCell2 = row4.vmethod_3(num);
					}
					ILineFormat lineFormat2 = smethod_2(firstCell2, secondCell2, vertical: false);
					if (lineFormat2 != null)
					{
						array3[i, num] = new Class140(lineFormat2, userToDevice, supportWrapper);
					}
				}
			}
		}
		if (TableStyle != null)
		{
			IThemeEffectiveData theme = ((BaseSlide)base.Slide).CreateThemeEffective();
			bool firstRow = FirstRow;
			bool firstCol = FirstCol;
			bool lastRow = LastRow;
			bool lastCol = LastCol;
			bool verticalBanding = VerticalBanding;
			bool horizontalBanding = HorizontalBanding;
			Class145 sourceStyle = new Class145(base.Slide, rc, theme, TableStyle.WholeTbl, TableStyle.WholeTblText, Enum9.const_0);
			Class145 sourceStyle2 = null;
			Class145 sourceStyle3 = null;
			Class145 sourceStyle4 = null;
			Class145 sourceStyle5 = null;
			Class145 @class = null;
			Class145 class2 = null;
			Class145 class3 = null;
			Class145 class4 = null;
			if (verticalBanding)
			{
				sourceStyle2 = new Class145(base.Slide, rc, theme, TableStyle.Band1V, TableStyle.Band1VText, Enum9.const_1);
				sourceStyle3 = new Class145(base.Slide, rc, theme, TableStyle.Band2V, TableStyle.Band2VText, Enum9.const_2);
			}
			if (horizontalBanding)
			{
				sourceStyle4 = new Class145(base.Slide, rc, theme, TableStyle.Band1H, TableStyle.Band1HText, Enum9.const_3);
				sourceStyle5 = new Class145(base.Slide, rc, theme, TableStyle.Band2H, TableStyle.Band2HText, Enum9.const_4);
			}
			if (firstRow)
			{
				@class = new Class145(base.Slide, rc, theme, TableStyle.FirstRow, TableStyle.FirstRowText, Enum9.const_5);
			}
			if (lastRow)
			{
				class2 = new Class145(base.Slide, rc, theme, TableStyle.LastRow, TableStyle.LastRowText, Enum9.const_6);
			}
			if (firstCol)
			{
				class3 = new Class145(base.Slide, rc, theme, TableStyle.FirstCol, TableStyle.FirstColText, Enum9.const_7);
			}
			if (lastCol)
			{
				class4 = new Class145(base.Slide, rc, theme, TableStyle.LastCol, TableStyle.LastColText, Enum9.const_8);
			}
			for (int i = 0; i < count; i++)
			{
				Row row5 = rowCollection_0.method_0(i);
				bool flag2 = i == 0;
				bool flag3 = firstRow == ((i & 1) != 0);
				int num = 0;
				while (num < count2)
				{
					Cell cell2 = row5.vmethod_3(num);
					if (cell2.IsSlaveCell)
					{
						num += cell2.BaseCell.ColSpan;
						continue;
					}
					bool flag4 = num == 0;
					bool flag5 = cell2.NextRowIndex == count;
					bool flag6 = cell2.NextColumnIndex == count2;
					array[i, num].method_0(sourceStyle);
					if (verticalBanding && (!flag4 || !firstCol) && (!flag6 || !lastCol))
					{
						if (firstCol == ((num & 1) != 0))
						{
							array[i, num].method_0(sourceStyle2);
						}
						else
						{
							array[i, num].method_0(sourceStyle3);
						}
					}
					if (horizontalBanding && (!flag2 || !firstRow) && (!flag5 || !lastRow))
					{
						if (flag3)
						{
							array[i, num].method_0(sourceStyle4);
						}
						else
						{
							array[i, num].method_0(sourceStyle5);
						}
					}
					if (firstCol && flag4)
					{
						array[i, num].method_0(class3);
					}
					if (lastCol && flag6)
					{
						array[i, num].method_0(class4);
					}
					if (firstRow && flag2)
					{
						array[i, num].method_0(@class);
					}
					if (lastRow && flag5)
					{
						array[i, num].method_0(class2);
					}
					num += cell2.ColSpan;
				}
			}
			if (firstCol && firstRow)
			{
				array[0, 0].method_0(new Class145(base.Slide, rc, theme, TableStyle.NwCell, TableStyle.NwCellText, Enum9.const_9));
			}
			if (lastCol && firstRow)
			{
				array[0, GetCell(count2 - 1, 0).FirstColumnIndex].method_0(new Class145(base.Slide, rc, theme, TableStyle.NeCell, TableStyle.NeCellText, Enum9.const_10));
			}
			if (firstCol && lastRow)
			{
				array[GetCell(0, count - 1).FirstRowIndex, 0].method_0(new Class145(base.Slide, rc, theme, TableStyle.SwCell, TableStyle.SwCellText, Enum9.const_11));
			}
			if (lastCol && lastRow)
			{
				Cell cell3 = GetCell(count2 - 1, count - 1);
				array[cell3.FirstRowIndex, cell3.FirstColumnIndex].method_0(new Class145(base.Slide, rc, theme, TableStyle.SeCell, TableStyle.SeCellText, Enum9.const_12));
			}
			if (withBorders)
			{
				for (int num = 0; num <= count2; num++)
				{
					bool flag7 = num == 0;
					bool flag8 = num == count2;
					for (int i = 0; i < count; i++)
					{
						Class140 class5 = array2[i, num];
						if (class5 == null)
						{
							continue;
						}
						Class141 class6 = null;
						Class141 class7 = null;
						if (num > 0)
						{
							class6 = array[i, num - 1];
							foreach (Class145 item in class6.OverwrittenBy)
							{
								if (flag8)
								{
									class5.method_0(item.RightBorder);
								}
								else
								{
									class5.method_0(item.InsideV);
								}
							}
						}
						if (num < count2)
						{
							class7 = array[i, num];
							foreach (Class145 item2 in class7.OverwrittenBy)
							{
								if (flag7)
								{
									class5.method_0(item2.LeftBorder);
								}
								else
								{
									class5.method_0(item2.InsideV);
								}
							}
						}
						if (class6 != null && class7 != null)
						{
							if (class6.bool_3 != class7.bool_3)
							{
								class5.method_0(class3.RightBorder);
							}
							if (class6.bool_2 != class7.bool_2)
							{
								class5.method_0(class4.LeftBorder);
							}
							if (class6.bool_1 != class7.bool_1)
							{
								class5.method_0(@class.BottomBorder);
							}
							if (class6.bool_0 != class7.bool_0)
							{
								class5.method_0(class2.TopBorder);
							}
						}
					}
				}
				for (int i = 0; i <= count; i++)
				{
					bool flag9 = i == 0;
					bool flag10 = i == count;
					for (int num = 0; num < count2; num++)
					{
						Class140 class8 = array3[i, num];
						if (class8 == null)
						{
							continue;
						}
						Class141 class9 = null;
						Class141 class10 = null;
						if (i > 0)
						{
							class9 = array[i - 1, num];
							foreach (Class145 item3 in class9.OverwrittenBy)
							{
								if (flag10)
								{
									class8.method_0(item3.BottomBorder);
								}
								else
								{
									class8.method_0(item3.InsideH);
								}
							}
						}
						if (i < count)
						{
							class10 = array[i, num];
							foreach (Class145 item4 in class10.OverwrittenBy)
							{
								if (flag9)
								{
									class8.method_0(item4.TopBorder);
								}
								else
								{
									class8.method_0(item4.InsideH);
								}
							}
						}
						if (class9 != null && class10 != null)
						{
							if (class9.bool_3 != class10.bool_3)
							{
								class8.method_0(class3.RightBorder);
							}
							if (class9.bool_2 != class10.bool_2)
							{
								class8.method_0(class4.LeftBorder);
							}
							if (class9.bool_1 != class10.bool_1)
							{
								class8.method_0(@class.BottomBorder);
							}
							if (class9.bool_0 != class10.bool_0)
							{
								class8.method_0(class2.TopBorder);
							}
						}
					}
				}
			}
		}
		class141_0 = array;
		if (withBorders)
		{
			class140_0 = array2;
			class140_1 = array3;
		}
	}

	internal void method_18(Class6002 userToDevice, Class169 rc, out Class66[,,] borders, out Class63[,] cellFills, out Class142[,] cellTextStyles)
	{
		int count = rowCollection_0.Count;
		int count2 = columnCollection_0.Count;
		borders = new Class66[count + 1, count2 + 1, 6];
		cellFills = new Class63[count, count2];
		cellTextStyles = new Class142[count, count2];
		BaseSlide baseSlide = (BaseSlide)base.Slide;
		IThemeEffectiveData theme = baseSlide.CreateThemeEffective();
		ShapeFrame shapeFrame = new ShapeFrame(0f, 0f, 72f, 72f, NullableBool.False, NullableBool.False, 0f);
		Row row;
		Cell cell;
		if (TableStyle != null)
		{
			if (smethod_4(TableStyle.WholeTbl, TableStyle.WholeTblText, baseSlide, rc, theme, shapeFrame, out var cellFill, out var cellTextStyle, out var leftBorder, out var topBorder, out var rightBorder, out var bottomBorder, out var insideH, out var insideV, out var tl2rbBorder, out var tr2blBorder))
			{
				Class66 @class = topBorder;
				for (int i = 0; i < count; i++)
				{
					Class66 class2 = leftBorder;
					for (int j = 0; j < count2; j++)
					{
						cellFills[i, j] = cellFill;
						cellTextStyles[i, j] = cellTextStyle;
						borders[i, j, 4] = tl2rbBorder;
						borders[i, j, 5] = tr2blBorder;
						borders[i, j, 0] = class2;
						borders[i, j, 1] = @class;
						class2 = insideV;
					}
					borders[i, count2, 0] = rightBorder;
					@class = insideH;
				}
				for (int k = 0; k < count2; k++)
				{
					borders[count, k, 1] = bottomBorder;
				}
			}
			int num = (FirstRow ? 1 : 0);
			int endRow = (LastRow ? (count - 1) : count);
			int num2 = (FirstCol ? 1 : 0);
			int num3 = (LastCol ? (count2 - 1) : count2);
			if (HorizontalBanding)
			{
				if (smethod_4(TableStyle.Band1H, TableStyle.Band1HText, baseSlide, rc, theme, shapeFrame, out cellFill, out cellTextStyle, out leftBorder, out topBorder, out rightBorder, out bottomBorder, out insideH, out insideV, out tl2rbBorder, out tr2blBorder))
				{
					method_23(num, endRow, cellFills, cellTextStyles, borders, cellFill, cellTextStyle, leftBorder, topBorder, rightBorder, bottomBorder, insideH, insideV, tl2rbBorder, tr2blBorder);
				}
				if (smethod_4(TableStyle.Band2H, TableStyle.Band2HText, baseSlide, rc, theme, shapeFrame, out cellFill, out cellTextStyle, out leftBorder, out topBorder, out rightBorder, out bottomBorder, out insideH, out insideV, out tl2rbBorder, out tr2blBorder))
				{
					method_23(num + 1, endRow, cellFills, cellTextStyles, borders, cellFill, cellTextStyle, leftBorder, topBorder, rightBorder, bottomBorder, insideH, insideV, tl2rbBorder, tr2blBorder);
				}
			}
			if (VerticalBanding)
			{
				if (smethod_4(TableStyle.Band1V, TableStyle.Band1VText, baseSlide, rc, theme, shapeFrame, out cellFill, out cellTextStyle, out leftBorder, out topBorder, out rightBorder, out bottomBorder, out insideH, out insideV, out tl2rbBorder, out tr2blBorder))
				{
					method_24(num2, num3, cellFills, cellTextStyles, borders, cellFill, cellTextStyle, leftBorder, topBorder, rightBorder, bottomBorder, insideH, insideV, tl2rbBorder, tr2blBorder);
				}
				if (smethod_4(TableStyle.Band2V, TableStyle.Band2VText, baseSlide, rc, theme, shapeFrame, out cellFill, out cellTextStyle, out leftBorder, out topBorder, out rightBorder, out bottomBorder, out insideH, out insideV, out tl2rbBorder, out tr2blBorder))
				{
					method_23(num2 + 1, num3, cellFills, cellTextStyles, borders, cellFill, cellTextStyle, leftBorder, topBorder, rightBorder, bottomBorder, insideH, insideV, tl2rbBorder, tr2blBorder);
				}
			}
			if (LastCol && smethod_4(TableStyle.LastCol, TableStyle.LastColText, baseSlide, rc, theme, shapeFrame, out cellFill, out cellTextStyle, out leftBorder, out topBorder, out rightBorder, out bottomBorder, out insideH, out insideV, out tl2rbBorder, out tr2blBorder))
			{
				Column column = columnCollection_0.method_0(count2 - 1);
				int val = column[0].ColSpan;
				Class66 @class = topBorder;
				int num4 = 0;
				while (num4 < count)
				{
					cell = (Cell)column[num4];
					int colSpan = cell.ColSpan;
					int firstColumnIndex = cell.FirstColumnIndex;
					for (int l = 0; l < cell.RowSpan; l++)
					{
						if (leftBorder != null)
						{
							borders[num4 + l, firstColumnIndex, 0] = leftBorder;
						}
						if (bottomBorder != null)
						{
							borders[num4 + l, count2, 0] = rightBorder;
						}
					}
					if (cellFill != null)
					{
						cellFills[num4, firstColumnIndex] = cellFill;
					}
					if (cellTextStyle != null)
					{
						cellTextStyles[num4, firstColumnIndex] = cellTextStyle;
					}
					if (tl2rbBorder != null)
					{
						borders[num4, firstColumnIndex, 4] = tl2rbBorder;
					}
					if (tr2blBorder != null)
					{
						borders[num4, firstColumnIndex, 5] = tr2blBorder;
					}
					int num5 = num4 + cell.RowSpan;
					int num6 = Math.Min(val, colSpan);
					int num7 = Math.Max(val, colSpan);
					if (leftBorder != null)
					{
						for (int m = count2 - num7; m < count2 - num6; m++)
						{
							borders[num4, m, 1] = topBorder;
						}
					}
					if (@class != null)
					{
						for (int n = count2 - num6; n < count2; n++)
						{
							borders[num4, n, 0] = @class;
						}
					}
					@class = insideH;
					val = colSpan;
					num4 = num5;
				}
				if (bottomBorder != null)
				{
					cell = (Cell)column[count - 1];
					for (int num8 = count2 - cell.ColSpan; num8 < count2; num8++)
					{
						borders[count, num8, 1] = bottomBorder;
					}
				}
			}
			if (FirstCol && smethod_4(TableStyle.FirstCol, TableStyle.FirstColText, baseSlide, rc, theme, shapeFrame, out cellFill, out cellTextStyle, out leftBorder, out topBorder, out rightBorder, out bottomBorder, out insideH, out insideV, out tl2rbBorder, out tr2blBorder))
			{
				Column column2 = columnCollection_0.method_0(0);
				int val2 = column2.vmethod_3(0).ColSpan;
				Class66 @class = topBorder;
				int num9 = 0;
				while (num9 < count)
				{
					cell = column2.vmethod_3(num9);
					int colSpan2 = cell.ColSpan;
					for (int num10 = 0; num10 < cell.RowSpan; num10++)
					{
						if (leftBorder != null)
						{
							borders[num9 + num10, 0, 0] = leftBorder;
						}
						if (rightBorder != null)
						{
							borders[num9 + num10, colSpan2, 0] = rightBorder;
						}
					}
					if (cellFill != null)
					{
						cellFills[num9, 0] = cellFill;
					}
					if (cellTextStyle != null)
					{
						cellTextStyles[num9, 0] = cellTextStyle;
					}
					if (tl2rbBorder != null)
					{
						borders[num9, 0, 4] = tl2rbBorder;
					}
					if (tr2blBorder != null)
					{
						borders[num9, 0, 5] = tr2blBorder;
					}
					int num11 = num9 + cell.RowSpan;
					int num12 = Math.Min(val2, colSpan2);
					int num13 = Math.Max(val2, colSpan2);
					if (@class != null)
					{
						for (int num14 = 0; num14 < num12; num14++)
						{
							borders[num9, num14, 1] = @class;
						}
					}
					if (rightBorder != null)
					{
						for (int num15 = num12; num15 < num13; num15++)
						{
							borders[num9, num15, 1] = rightBorder;
						}
					}
					@class = insideH;
					val2 = colSpan2;
					num9 = num11;
				}
				if (bottomBorder != null)
				{
					cell = (Cell)column2[count - 1];
					for (int num16 = 0; num16 < cell.ColSpan; num16++)
					{
						borders[count, num16, 1] = bottomBorder;
					}
				}
			}
			if (LastRow && smethod_4(TableStyle.LastRow, TableStyle.LastRowText, baseSlide, rc, theme, shapeFrame, out cellFill, out cellTextStyle, out leftBorder, out topBorder, out rightBorder, out bottomBorder, out insideH, out insideV, out tl2rbBorder, out tr2blBorder))
			{
				row = rowCollection_0.method_0(count - 1);
				int val3 = row[0].RowSpan;
				Class66 class2 = leftBorder;
				int num17 = 0;
				while (num17 < count2)
				{
					cell = (Cell)row[num17];
					int rowSpan = cell.RowSpan;
					int firstRowIndex = cell.FirstRowIndex;
					for (int num18 = 0; num18 < cell.ColSpan; num18++)
					{
						if (topBorder != null)
						{
							borders[firstRowIndex, num17 + num18, 1] = topBorder;
						}
						if (bottomBorder != null)
						{
							borders[count, num17 + num18, 1] = bottomBorder;
						}
					}
					if (cellFill != null)
					{
						cellFills[firstRowIndex, num17] = cellFill;
					}
					if (cellTextStyle != null)
					{
						cellTextStyles[firstRowIndex, num17] = cellTextStyle;
					}
					if (tl2rbBorder != null)
					{
						borders[firstRowIndex, num17, 4] = tl2rbBorder;
					}
					if (tr2blBorder != null)
					{
						borders[firstRowIndex, num17, 5] = tr2blBorder;
					}
					int num19 = num17 + cell.ColSpan;
					int num20 = Math.Min(val3, rowSpan);
					int num21 = Math.Max(val3, rowSpan);
					if (topBorder != null)
					{
						for (int num22 = count - num21; num22 < count - num20; num22++)
						{
							borders[num22, num17, 0] = topBorder;
						}
					}
					if (class2 != null)
					{
						for (int num23 = count - num20; num23 < count; num23++)
						{
							borders[num23, num17, 0] = class2;
						}
					}
					class2 = insideV;
					val3 = rowSpan;
					num17 = num19;
				}
				if (rightBorder != null)
				{
					cell = (Cell)row[count2 - 1];
					for (int num24 = count - cell.RowSpan; num24 < count; num24++)
					{
						borders[num24, count2, 0] = rightBorder;
					}
				}
			}
			if (FirstRow && smethod_4(TableStyle.FirstRow, TableStyle.FirstRowText, baseSlide, rc, theme, shapeFrame, out cellFill, out cellTextStyle, out leftBorder, out topBorder, out rightBorder, out bottomBorder, out insideH, out insideV, out tl2rbBorder, out tr2blBorder))
			{
				row = rowCollection_0.method_0(0);
				int val4 = row.vmethod_3(0).RowSpan;
				Class66 class2 = leftBorder;
				int num25 = 0;
				while (num25 < count2)
				{
					cell = row.vmethod_3(num25);
					int rowSpan2 = cell.RowSpan;
					for (int num26 = 0; num26 < cell.ColSpan; num26++)
					{
						if (topBorder != null)
						{
							borders[0, num25 + num26, 1] = topBorder;
						}
						if (bottomBorder != null)
						{
							borders[rowSpan2, num25 + num26, 1] = bottomBorder;
						}
					}
					if (cellFill != null)
					{
						cellFills[0, num25] = cellFill;
					}
					if (cellTextStyle != null)
					{
						cellTextStyles[0, num25] = cellTextStyle;
					}
					if (tl2rbBorder != null)
					{
						borders[0, num25, 4] = tl2rbBorder;
					}
					if (tr2blBorder != null)
					{
						borders[0, num25, 5] = tr2blBorder;
					}
					int num27 = num25 + cell.ColSpan;
					int num28 = Math.Min(val4, rowSpan2);
					int num29 = Math.Max(val4, rowSpan2);
					if (class2 != null)
					{
						for (int num30 = 0; num30 < num28; num30++)
						{
							borders[num30, num25, 0] = class2;
						}
					}
					if (bottomBorder != null)
					{
						for (int num31 = num28; num31 < num29; num31++)
						{
							borders[num31, num25, 0] = bottomBorder;
						}
					}
					class2 = insideV;
					val4 = rowSpan2;
					num25 = num27;
				}
				if (rightBorder != null)
				{
					cell = (Cell)row[count2 - 1];
					for (int num32 = 0; num32 < cell.RowSpan; num32++)
					{
						borders[num32, count2, 0] = rightBorder;
					}
				}
			}
			if (FirstRow && FirstCol)
			{
				method_25(0, 0, cellFills, cellTextStyles, borders, TableStyle.NwCell, TableStyle.NwCellText, baseSlide, rc, theme, shapeFrame);
			}
			if (FirstRow && LastCol)
			{
				method_25(0, count2 - 1, cellFills, cellTextStyles, borders, TableStyle.NeCell, TableStyle.NeCellText, baseSlide, rc, theme, shapeFrame);
			}
			if (LastRow && FirstCol)
			{
				method_25(count - 1, 0, cellFills, cellTextStyles, borders, TableStyle.SwCell, TableStyle.SwCellText, baseSlide, rc, theme, shapeFrame);
			}
			if (LastRow && LastCol)
			{
				method_25(count - 1, count2 - 1, cellFills, cellTextStyles, borders, TableStyle.SeCell, TableStyle.SeCellText, baseSlide, rc, theme, shapeFrame);
			}
		}
		Row row2 = null;
		for (int num33 = 0; num33 < count; num33++)
		{
			row = rowCollection_0.method_0(num33);
			IColumn column3 = null;
			int num34 = 0;
			while (num34 < count2)
			{
				cell = row.vmethod_3(num34);
				if (cell.MergedTo == null)
				{
					if (((FillFormat)cell.FillFormat).fillType_0 != FillType.NotDefined)
					{
						cellFills[num33, num34] = new Class63(new Class67(shapeFrame, userToDevice, null, baseSlide, rc), cell.FillFormat);
					}
					if (cell.BorderDiagonalDown.FillFormat.FillType != FillType.NotDefined)
					{
						borders[num33, num34, 4] = new Class66(new Class67(shapeFrame, userToDevice, null, baseSlide, rc), (LineFormat)cell.BorderDiagonalDown);
					}
					if (cell.BorderDiagonalUp.FillFormat.FillType != FillType.NotDefined)
					{
						borders[num33, num34, 5] = new Class66(new Class67(shapeFrame, userToDevice, null, baseSlide, rc), (LineFormat)cell.BorderDiagonalUp);
					}
					if (cell.BorderTop.FillFormat.FillType != FillType.NotDefined)
					{
						borders[num33, num34, 1] = new Class66(new Class67(shapeFrame, userToDevice, null, baseSlide, rc), (LineFormat)cell.BorderTop);
					}
					if (row2 != null && cell.ColSpan > 1)
					{
						Cell cell2 = cell;
						int num35 = 0;
						while (num35 < cell.ColSpan)
						{
							Cell cell3 = (Cell)row2[num34 + num35];
							int val5 = cell3.FirstColumnIndex + cell3.ColSpan;
							int num36 = Math.Min(num34 + cell.ColSpan, val5);
							if (cell.BorderTop.FillFormat.FillType != FillType.NotDefined)
							{
								Class66 class3 = new Class66(new Class67(shapeFrame, userToDevice, null, baseSlide, rc), (LineFormat)cell2.BorderTop);
								for (int num37 = num34 + num35; num37 < num36; num37++)
								{
									borders[num33, num37, 1] = class3;
								}
							}
							num35 = num36 - num34;
							cell2 = row.vmethod_3(num36);
						}
					}
					else if (cell.BorderTop.FillFormat.FillType != FillType.NotDefined)
					{
						Class66 class4 = new Class66(new Class67(shapeFrame, userToDevice, null, baseSlide, rc), (LineFormat)cell.BorderTop);
						for (int num38 = 0; num38 < cell.ColSpan; num38++)
						{
							borders[num33, num34 + 1, 1] = class4;
						}
					}
					if (column3 != null && cell.RowSpan > 1)
					{
						Cell cell4 = cell;
						int num39 = 0;
						while (num39 < cell.RowSpan)
						{
							Cell cell5 = (Cell)column3[num33 + num39];
							int val6 = cell5.FirstRowIndex + cell5.RowSpan;
							int num40 = Math.Min(num33 + cell.RowSpan, val6);
							if (cell.BorderLeft.FillFormat.FillType != FillType.NotDefined)
							{
								Class66 class5 = new Class66(new Class67(shapeFrame, userToDevice, null, baseSlide, rc), (LineFormat)cell4.BorderLeft);
								for (int num41 = num33 + num39; num41 < num40; num41++)
								{
									borders[num41, num34, 0] = class5;
								}
							}
							num39 = num40 - num33;
							cell4 = ((Column)cell.FirstColumn).vmethod_3(num40);
						}
					}
					else if (cell.BorderLeft.FillFormat.FillType != FillType.NotDefined)
					{
						Class66 class6 = new Class66(new Class67(shapeFrame, userToDevice, null, baseSlide, rc), (LineFormat)cell.BorderLeft);
						for (int num42 = 0; num42 < cell.RowSpan; num42++)
						{
							borders[num33 + num42, num34, 0] = class6;
						}
					}
					num34 += cell.ColSpan;
					column3 = cell.FirstColumn;
				}
				else
				{
					num34 = cell.MergedTo.FirstColumnIndex + cell.MergedTo.ColSpan;
					column3 = cell.MergedTo.FirstColumn;
				}
			}
			cell = row.vmethod_3(count2 - 1);
			if (cell.BorderLeft.FillFormat.FillType != FillType.NotDefined)
			{
				borders[num33, count2, 0] = new Class66(new Class67(shapeFrame, userToDevice, null, baseSlide, rc), (LineFormat)cell.BorderRight);
			}
			if (cell.BorderTop.FillFormat.FillType != FillType.NotDefined)
			{
				borders[num33, count2, 1] = new Class66(new Class67(shapeFrame, userToDevice, null, baseSlide, rc), (LineFormat)cell.BorderBottom);
			}
			row2 = row;
		}
		row = ((RowCollection)Rows).method_0(count - 1);
		for (int num43 = 0; num43 < count2; num43 += cell.ColSpan)
		{
			cell = (Cell)row[num43];
			if (cell.BorderBottom.FillFormat.FillType != FillType.NotDefined)
			{
				borders[count, num43, 1] = new Class66(new Class67(shapeFrame, userToDevice, null, baseSlide, rc), (LineFormat)cell.BorderBottom);
			}
		}
	}

	internal void method_19(out Class149[,,] borders, out Class148[,] cellFills, out Class142[,] cellTextStyles)
	{
		int count = rowCollection_0.Count;
		int count2 = columnCollection_0.Count;
		borders = new Class149[count + 1, count2 + 1, 6];
		cellFills = new Class148[count, count2];
		cellTextStyles = new Class142[count, count2];
		if (TableStyle == null)
		{
			return;
		}
		if (smethod_3(TableStyle.WholeTbl, TableStyle.WholeTblText, out var cellFill, out var cellTextStyle, out var leftBorder, out var topBorder, out var rightBorder, out var bottomBorder, out var insideH, out var insideV, out var tl2rbBorder, out var tr2blBorder))
		{
			Class149 @class = topBorder;
			for (int i = 0; i < count; i++)
			{
				Class149 class2 = leftBorder;
				for (int j = 0; j < count2; j++)
				{
					cellFills[i, j] = cellFill;
					cellTextStyles[i, j] = cellTextStyle;
					borders[i, j, 4] = tl2rbBorder;
					borders[i, j, 5] = tr2blBorder;
					borders[i, j, 0] = class2;
					borders[i, j, 1] = @class;
					class2 = insideV;
				}
				borders[i, count2, 0] = rightBorder;
				@class = insideH;
			}
			for (int k = 0; k < count2; k++)
			{
				borders[count, k, 1] = bottomBorder;
			}
		}
		int num = (FirstRow ? 1 : 0);
		int endRow = (LastRow ? (count - 1) : count);
		int num2 = (FirstCol ? 1 : 0);
		int num3 = (LastCol ? (count2 - 1) : count2);
		if (HorizontalBanding)
		{
			if (smethod_3(TableStyle.Band1H, TableStyle.Band1HText, out cellFill, out cellTextStyle, out leftBorder, out topBorder, out rightBorder, out bottomBorder, out insideH, out insideV, out tl2rbBorder, out tr2blBorder))
			{
				method_20(num, endRow, cellFills, cellTextStyles, borders, cellFill, cellTextStyle, leftBorder, topBorder, rightBorder, bottomBorder, insideH, insideV, tl2rbBorder, tr2blBorder);
			}
			if (smethod_3(TableStyle.Band2H, TableStyle.Band2HText, out cellFill, out cellTextStyle, out leftBorder, out topBorder, out rightBorder, out bottomBorder, out insideH, out insideV, out tl2rbBorder, out tr2blBorder))
			{
				method_20(num + 1, endRow, cellFills, cellTextStyles, borders, cellFill, cellTextStyle, leftBorder, topBorder, rightBorder, bottomBorder, insideH, insideV, tl2rbBorder, tr2blBorder);
			}
		}
		if (VerticalBanding)
		{
			if (smethod_3(TableStyle.Band1V, TableStyle.Band1VText, out cellFill, out cellTextStyle, out leftBorder, out topBorder, out rightBorder, out bottomBorder, out insideH, out insideV, out tl2rbBorder, out tr2blBorder))
			{
				method_21(num2, num3, cellFills, cellTextStyles, borders, cellFill, cellTextStyle, leftBorder, topBorder, rightBorder, bottomBorder, insideH, insideV, tl2rbBorder, tr2blBorder);
			}
			if (smethod_3(TableStyle.Band2V, TableStyle.Band2VText, out cellFill, out cellTextStyle, out leftBorder, out topBorder, out rightBorder, out bottomBorder, out insideH, out insideV, out tl2rbBorder, out tr2blBorder))
			{
				method_20(num2 + 1, num3, cellFills, cellTextStyles, borders, cellFill, cellTextStyle, leftBorder, topBorder, rightBorder, bottomBorder, insideH, insideV, tl2rbBorder, tr2blBorder);
			}
		}
		if (LastCol && smethod_3(TableStyle.LastCol, TableStyle.LastColText, out cellFill, out cellTextStyle, out leftBorder, out topBorder, out rightBorder, out bottomBorder, out insideH, out insideV, out tl2rbBorder, out tr2blBorder))
		{
			Column column = columnCollection_0.method_0(count2 - 1);
			int val = column[0].ColSpan;
			Class149 @class = topBorder;
			int num4 = 0;
			while (num4 < count)
			{
				Cell cell = (Cell)column[num4];
				int colSpan = cell.ColSpan;
				int firstColumnIndex = cell.FirstColumnIndex;
				for (int l = 0; l < cell.RowSpan; l++)
				{
					if (leftBorder != null)
					{
						borders[num4 + l, firstColumnIndex, 0] = leftBorder;
					}
					if (bottomBorder != null)
					{
						borders[num4 + l, count2, 0] = rightBorder;
					}
				}
				if (cellFill != null)
				{
					cellFills[num4, firstColumnIndex] = cellFill;
				}
				if (cellTextStyle != null)
				{
					cellTextStyles[num4, firstColumnIndex] = cellTextStyle;
				}
				if (tl2rbBorder != null)
				{
					borders[num4, firstColumnIndex, 4] = tl2rbBorder;
				}
				if (tr2blBorder != null)
				{
					borders[num4, firstColumnIndex, 5] = tr2blBorder;
				}
				int num5 = num4 + cell.RowSpan;
				int num6 = Math.Min(val, colSpan);
				int num7 = Math.Max(val, colSpan);
				if (leftBorder != null)
				{
					for (int m = count2 - num7; m < count2 - num6; m++)
					{
						borders[num4, m, 1] = topBorder;
					}
				}
				if (@class != null)
				{
					for (int n = count2 - num6; n < count2; n++)
					{
						borders[num4, n, 0] = @class;
					}
				}
				@class = insideH;
				val = colSpan;
				num4 = num5;
			}
			if (bottomBorder != null)
			{
				Cell cell = (Cell)column[count - 1];
				for (int num8 = count2 - cell.ColSpan; num8 < count2; num8++)
				{
					borders[count, num8, 1] = bottomBorder;
				}
			}
		}
		if (FirstCol && smethod_3(TableStyle.FirstCol, TableStyle.FirstColText, out cellFill, out cellTextStyle, out leftBorder, out topBorder, out rightBorder, out bottomBorder, out insideH, out insideV, out tl2rbBorder, out tr2blBorder))
		{
			Column column2 = columnCollection_0.method_0(0);
			int val2 = column2.vmethod_3(0).ColSpan;
			Class149 @class = topBorder;
			int num9 = 0;
			while (num9 < count)
			{
				Cell cell = column2.vmethod_3(num9);
				int colSpan2 = cell.ColSpan;
				for (int num10 = 0; num10 < cell.RowSpan; num10++)
				{
					if (leftBorder != null)
					{
						borders[num9 + num10, 0, 0] = leftBorder;
					}
					if (rightBorder != null)
					{
						borders[num9 + num10, colSpan2, 0] = rightBorder;
					}
				}
				if (cellFill != null)
				{
					cellFills[num9, 0] = cellFill;
				}
				if (cellTextStyle != null)
				{
					cellTextStyles[num9, 0] = cellTextStyle;
				}
				if (tl2rbBorder != null)
				{
					borders[num9, 0, 4] = tl2rbBorder;
				}
				if (tr2blBorder != null)
				{
					borders[num9, 0, 5] = tr2blBorder;
				}
				int num11 = num9 + cell.RowSpan;
				int num12 = Math.Min(val2, colSpan2);
				int num13 = Math.Max(val2, colSpan2);
				if (@class != null)
				{
					for (int num14 = 0; num14 < num12; num14++)
					{
						borders[num9, num14, 1] = @class;
					}
				}
				if (rightBorder != null)
				{
					for (int num15 = num12; num15 < num13; num15++)
					{
						borders[num9, num15, 1] = rightBorder;
					}
				}
				@class = insideH;
				val2 = colSpan2;
				num9 = num11;
			}
			if (bottomBorder != null)
			{
				Cell cell = (Cell)column2[count - 1];
				for (int num16 = 0; num16 < cell.ColSpan; num16++)
				{
					borders[count, num16, 1] = bottomBorder;
				}
			}
		}
		if (LastRow && smethod_3(TableStyle.LastRow, TableStyle.LastRowText, out cellFill, out cellTextStyle, out leftBorder, out topBorder, out rightBorder, out bottomBorder, out insideH, out insideV, out tl2rbBorder, out tr2blBorder))
		{
			Row row = rowCollection_0.method_0(count - 1);
			int val3 = row[0].RowSpan;
			Class149 class2 = leftBorder;
			int num17 = 0;
			while (num17 < count2)
			{
				Cell cell = (Cell)row[num17];
				int rowSpan = cell.RowSpan;
				int firstRowIndex = cell.FirstRowIndex;
				for (int num18 = 0; num18 < cell.ColSpan; num18++)
				{
					if (topBorder != null)
					{
						borders[firstRowIndex, num17 + num18, 1] = topBorder;
					}
					if (bottomBorder != null)
					{
						borders[count, num17 + num18, 1] = bottomBorder;
					}
				}
				if (cellFill != null)
				{
					cellFills[firstRowIndex, num17] = cellFill;
				}
				if (cellTextStyle != null)
				{
					cellTextStyles[firstRowIndex, num17] = cellTextStyle;
				}
				if (tl2rbBorder != null)
				{
					borders[firstRowIndex, num17, 4] = tl2rbBorder;
				}
				if (tr2blBorder != null)
				{
					borders[firstRowIndex, num17, 5] = tr2blBorder;
				}
				int num19 = num17 + cell.ColSpan;
				int num20 = Math.Min(val3, rowSpan);
				int num21 = Math.Max(val3, rowSpan);
				if (topBorder != null)
				{
					for (int num22 = count - num21; num22 < count - num20; num22++)
					{
						borders[num22, num17, 0] = topBorder;
					}
				}
				if (class2 != null)
				{
					for (int num23 = count - num20; num23 < count; num23++)
					{
						borders[num23, num17, 0] = class2;
					}
				}
				class2 = insideV;
				val3 = rowSpan;
				num17 = num19;
			}
			if (rightBorder != null)
			{
				Cell cell = (Cell)row[count2 - 1];
				for (int num24 = count - cell.RowSpan; num24 < count; num24++)
				{
					borders[num24, count2, 0] = rightBorder;
				}
			}
		}
		if (FirstRow && smethod_3(TableStyle.FirstRow, TableStyle.FirstRowText, out cellFill, out cellTextStyle, out leftBorder, out topBorder, out rightBorder, out bottomBorder, out insideH, out insideV, out tl2rbBorder, out tr2blBorder))
		{
			Row row = rowCollection_0.method_0(0);
			int val4 = row.vmethod_3(0).RowSpan;
			Class149 class2 = leftBorder;
			int num25 = 0;
			while (num25 < count2)
			{
				Cell cell = row.vmethod_3(num25);
				int rowSpan2 = cell.RowSpan;
				for (int num26 = 0; num26 < cell.ColSpan; num26++)
				{
					if (topBorder != null)
					{
						borders[0, num25 + num26, 1] = topBorder;
					}
					if (bottomBorder != null)
					{
						borders[rowSpan2, num25 + num26, 1] = bottomBorder;
					}
				}
				if (cellFill != null)
				{
					cellFills[0, num25] = cellFill;
				}
				if (cellTextStyle != null)
				{
					cellTextStyles[0, num25] = cellTextStyle;
				}
				if (tl2rbBorder != null)
				{
					borders[0, num25, 4] = tl2rbBorder;
				}
				if (tr2blBorder != null)
				{
					borders[0, num25, 5] = tr2blBorder;
				}
				int num27 = num25 + cell.ColSpan;
				int num28 = Math.Min(val4, rowSpan2);
				int num29 = Math.Max(val4, rowSpan2);
				if (class2 != null)
				{
					for (int num30 = 0; num30 < num28; num30++)
					{
						borders[num30, num25, 0] = class2;
					}
				}
				if (bottomBorder != null)
				{
					for (int num31 = num28; num31 < num29; num31++)
					{
						borders[num31, num25, 0] = bottomBorder;
					}
				}
				class2 = insideV;
				val4 = rowSpan2;
				num25 = num27;
			}
			if (rightBorder != null)
			{
				Cell cell = (Cell)row[count2 - 1];
				for (int num32 = 0; num32 < cell.RowSpan; num32++)
				{
					borders[num32, count2, 0] = rightBorder;
				}
			}
		}
		if (FirstRow && FirstCol)
		{
			method_22(0, 0, cellFills, cellTextStyles, borders, TableStyle.NwCell, TableStyle.NwCellText);
		}
		if (FirstRow && LastCol)
		{
			method_22(0, count2 - 1, cellFills, cellTextStyles, borders, TableStyle.NeCell, TableStyle.NeCellText);
		}
		if (LastRow && FirstCol)
		{
			method_22(count - 1, 0, cellFills, cellTextStyles, borders, TableStyle.SwCell, TableStyle.SwCellText);
		}
		if (LastRow && LastCol)
		{
			method_22(count - 1, count2 - 1, cellFills, cellTextStyles, borders, TableStyle.SeCell, TableStyle.SeCellText);
		}
	}

	internal static bool smethod_3(Class143 partStyle, Class142 textStyle, out Class148 cellFill, out Class142 cellTextStyle, out Class149 leftBorder, out Class149 topBorder, out Class149 rightBorder, out Class149 bottomBorder, out Class149 insideH, out Class149 insideV, out Class149 tl2rbBorder, out Class149 tr2blBorder)
	{
		bool result = false;
		if (partStyle.FillFormat.Source == Enum273.const_0)
		{
			cellFill = null;
		}
		else
		{
			cellFill = partStyle.FillFormat;
			result = true;
		}
		if (partStyle.LeftBorder.Source == Enum275.const_0)
		{
			leftBorder = null;
		}
		else
		{
			leftBorder = partStyle.LeftBorder;
			result = true;
		}
		if (partStyle.TopBorder.Source == Enum275.const_0)
		{
			topBorder = null;
		}
		else
		{
			topBorder = partStyle.TopBorder;
			result = true;
		}
		if (partStyle.RightBorder.Source == Enum275.const_0)
		{
			rightBorder = null;
		}
		else
		{
			rightBorder = partStyle.RightBorder;
			result = true;
		}
		if (partStyle.BottomBorder.Source == Enum275.const_0)
		{
			bottomBorder = null;
		}
		else
		{
			bottomBorder = partStyle.BottomBorder;
			result = true;
		}
		if (partStyle.InsideHorizontalBorder.Source == Enum275.const_0)
		{
			insideH = null;
		}
		else
		{
			insideH = partStyle.InsideHorizontalBorder;
			result = true;
		}
		if (partStyle.InsideVerticalBorder.Source == Enum275.const_0)
		{
			insideV = null;
		}
		else
		{
			insideV = partStyle.InsideVerticalBorder;
			result = true;
		}
		if (partStyle.TopLeftToBottomRightBorder.Source == Enum275.const_0)
		{
			tl2rbBorder = null;
		}
		else
		{
			tl2rbBorder = partStyle.TopLeftToBottomRightBorder;
			result = true;
		}
		if (partStyle.TopRightToBottomLeftBorder.Source == Enum275.const_0)
		{
			tr2blBorder = null;
		}
		else
		{
			tr2blBorder = partStyle.TopRightToBottomLeftBorder;
			result = true;
		}
		if (textStyle.FontSource != 0)
		{
			cellTextStyle = textStyle;
			result = true;
		}
		else
		{
			cellTextStyle = null;
		}
		return result;
	}

	private void method_20(int startRow, int endRow, Class148[,] cellFills, Class142[,] cellTextStyles, Class149[,,] borders, Class148 fp, Class142 textStyle, Class149 left, Class149 top, Class149 right, Class149 bottom, Class149 insideH, Class149 insideV, Class149 tl2rb, Class149 tr2lb)
	{
		int count = Columns.Count;
		int num = startRow & 1;
		Row row = null;
		for (int i = startRow; i < endRow; i += 2)
		{
			Row row2 = rowCollection_0.method_0(i);
			int num2 = 0;
			while (num2 < count)
			{
				Cell cell = row2.vmethod_3(num2);
				if (cell.MergedTo == null && i + cell.RowSpan <= endRow)
				{
					int rowSpan = cell.RowSpan;
					int colSpan = cell.ColSpan;
					for (int j = 0; j < colSpan; j++)
					{
						if (row != null && (row[num2 + j].RowSpan & 1) != 1)
						{
							if (insideH != null)
							{
								borders[i, num2 + j, 1] = insideH;
							}
						}
						else if (top != null)
						{
							borders[i, num2 + j, 1] = top;
						}
						if (bottom != null && (rowSpan & 1) == 1)
						{
							borders[i + rowSpan, num2 + j, 1] = bottom;
						}
					}
					Column column = ((num2 > 0) ? columnCollection_0.method_0(num2 - 1) : null);
					Column column2 = ((num2 + colSpan < count) ? columnCollection_0.method_0(num2 + colSpan) : null);
					for (int k = 0; k < rowSpan; k++)
					{
						if (column != null && (column[i + k].FirstRowIndex & 1) == num)
						{
							if (insideV != null)
							{
								borders[i, num2 + k, 0] = insideV;
							}
						}
						else if (left != null)
						{
							borders[i + k, num2, 0] = left;
						}
						if (right != null && (column2 == null || (column2[i + k].FirstRowIndex & 1) != num))
						{
							borders[i + k, num2 + colSpan, 0] = right;
						}
					}
					if (fp != null)
					{
						cellFills[i, num2] = fp;
					}
					if (textStyle != null)
					{
						cellTextStyles[i, num2] = textStyle;
					}
					if (tl2rb != null)
					{
						borders[i, num2, 4] = tl2rb;
					}
					if (tr2lb != null)
					{
						borders[i, num2, 5] = tr2lb;
					}
					num2 += colSpan;
				}
				else
				{
					num2 += ((cell.MergedTo == null) ? cell.ColSpan : cell.MergedTo.ColSpan);
				}
			}
			row = row2;
		}
	}

	private void method_21(int startColumn, int endColumn, Class148[,] cellFills, Class142[,] cellTextStyles, Class149[,,] borders, Class148 fp, Class142 textStyle, Class149 left, Class149 top, Class149 right, Class149 bottom, Class149 insideH, Class149 insideV, Class149 tl2rb, Class149 tr2lb)
	{
		int count = Rows.Count;
		int num = startColumn & 1;
		Column column = null;
		for (int i = startColumn; i < endColumn; i += 2)
		{
			Column column2 = columnCollection_0.method_0(i);
			int num2 = 0;
			while (num2 < count)
			{
				Cell cell = column2.vmethod_3(num2);
				if (cell.MergedTo == null && i + cell.ColSpan <= endColumn)
				{
					int colSpan = cell.ColSpan;
					int rowSpan = cell.RowSpan;
					for (int j = 0; j < colSpan; j++)
					{
						if (column != null && (column[num2 + j].ColSpan & 1) != 1)
						{
							if (insideV != null)
							{
								borders[num2 + j, i, 0] = insideV;
							}
						}
						else if (left != null)
						{
							borders[num2 + j, i, 0] = left;
						}
						if (right != null && (colSpan & 1) == 1)
						{
							borders[num2 + j, i + colSpan, 0] = right;
						}
					}
					Row row = ((num2 > 0) ? rowCollection_0.method_0(num2 - 1) : null);
					Row row2 = ((num2 + colSpan < count) ? rowCollection_0.method_0(num2 + rowSpan) : null);
					for (int k = 0; k < colSpan; k++)
					{
						if (row != null && (row[i + k].FirstColumnIndex & 1) == num)
						{
							if (insideH != null)
							{
								borders[num2 + k, i, 1] = insideH;
							}
						}
						else if (top != null)
						{
							borders[num2, i + k, 1] = top;
						}
						if (bottom != null && (row2 == null || (row2[i + k].FirstColumnIndex & 1) != num))
						{
							borders[num2 + rowSpan, i + k, 1] = bottom;
						}
					}
					if (fp != null)
					{
						cellFills[num2, i] = fp;
					}
					if (textStyle != null)
					{
						cellTextStyles[num2, i] = textStyle;
					}
					if (tl2rb != null)
					{
						borders[num2, i, 4] = tl2rb;
					}
					if (tr2lb != null)
					{
						borders[num2, i, 5] = tr2lb;
					}
					num2 += rowSpan;
				}
				else
				{
					num2 += ((cell.MergedTo == null) ? cell.RowSpan : cell.MergedTo.RowSpan);
				}
			}
			column = column2;
		}
	}

	private void method_22(int rowIndex, int columnIndex, Class148[,] cellFills, Class142[,] cellTextStyles, Class149[,,] borders, Class143 cellStyle, Class142 cellTextStyle)
	{
		if (!smethod_3(cellStyle, cellTextStyle, out var cellFill, out var cellTextStyle2, out var leftBorder, out var topBorder, out var rightBorder, out var bottomBorder, out var _, out var _, out var tl2rbBorder, out var tr2blBorder))
		{
			return;
		}
		ICell cell = this[columnIndex, rowIndex];
		columnIndex = cell.FirstColumnIndex;
		rowIndex = cell.FirstRowIndex;
		for (int i = 0; i < cell.ColSpan; i++)
		{
			if (topBorder != null)
			{
				borders[rowIndex, columnIndex + i, 1] = topBorder;
			}
			if (bottomBorder != null)
			{
				borders[rowIndex + cell.RowSpan, columnIndex + i, 1] = bottomBorder;
			}
		}
		for (int j = 0; j < cell.RowSpan; j++)
		{
			if (leftBorder != null)
			{
				borders[rowIndex + j, columnIndex, 0] = leftBorder;
			}
			if (rightBorder != null)
			{
				borders[rowIndex + j, columnIndex + cell.ColSpan, 0] = rightBorder;
			}
		}
		if (cellFill != null)
		{
			cellFills[rowIndex, columnIndex] = cellFill;
		}
		if (cellTextStyle2 != null)
		{
			cellTextStyles[rowIndex, columnIndex] = cellTextStyle2;
		}
		if (tl2rbBorder != null)
		{
			borders[rowIndex, columnIndex, 4] = tl2rbBorder;
		}
		if (tr2blBorder != null)
		{
			borders[rowIndex, columnIndex, 5] = tr2blBorder;
		}
	}

	private void method_23(int startRow, int endRow, Class63[,] cellFills, Class142[,] cellTextStyles, Class66[,,] borders, Class63 fp, Class142 textStyle, Class66 left, Class66 top, Class66 right, Class66 bottom, Class66 insideH, Class66 insideV, Class66 tl2rb, Class66 tr2lb)
	{
		int count = Columns.Count;
		int num = startRow & 1;
		Row row = null;
		for (int i = startRow; i < endRow; i += 2)
		{
			Row row2 = rowCollection_0.method_0(i);
			int num2 = 0;
			while (num2 < count)
			{
				Cell cell = row2.vmethod_3(num2);
				if (cell.MergedTo == null && i + cell.RowSpan <= endRow)
				{
					int rowSpan = cell.RowSpan;
					int colSpan = cell.ColSpan;
					for (int j = 0; j < colSpan; j++)
					{
						if (row != null && (row[num2 + j].RowSpan & 1) != 1)
						{
							if (insideH != null)
							{
								borders[i, num2 + j, 1] = insideH;
							}
						}
						else if (top != null)
						{
							borders[i, num2 + j, 1] = top;
						}
						if (bottom != null && (rowSpan & 1) == 1)
						{
							borders[i + rowSpan, num2 + j, 1] = bottom;
						}
					}
					Column column = ((num2 > 0) ? columnCollection_0.method_0(num2 - 1) : null);
					Column column2 = ((num2 + colSpan < count) ? columnCollection_0.method_0(num2 + colSpan) : null);
					for (int k = 0; k < rowSpan; k++)
					{
						if (column != null && (column[i + k].FirstRowIndex & 1) == num)
						{
							if (insideV != null)
							{
								borders[i, num2 + k, 0] = insideV;
							}
						}
						else if (left != null)
						{
							borders[i + k, num2, 0] = left;
						}
						if (right != null && (column2 == null || (column2[i + k].FirstRowIndex & 1) != num))
						{
							borders[i + k, num2 + colSpan, 0] = right;
						}
					}
					if (fp != null)
					{
						cellFills[i, num2] = fp;
					}
					if (textStyle != null)
					{
						cellTextStyles[i, num2] = textStyle;
					}
					if (tl2rb != null)
					{
						borders[i, num2, 4] = tl2rb;
					}
					if (tr2lb != null)
					{
						borders[i, num2, 5] = tr2lb;
					}
					num2 += colSpan;
				}
				else
				{
					num2 += ((cell.MergedTo == null) ? cell.ColSpan : cell.MergedTo.ColSpan);
				}
			}
			row = row2;
		}
	}

	private void method_24(int startColumn, int endColumn, Class63[,] cellFills, Class142[,] cellTextStyles, Class66[,,] borders, Class63 fp, Class142 textStyle, Class66 left, Class66 top, Class66 right, Class66 bottom, Class66 insideH, Class66 insideV, Class66 tl2rb, Class66 tr2lb)
	{
		int count = Rows.Count;
		int num = startColumn & 1;
		Column column = null;
		for (int i = startColumn; i < endColumn; i += 2)
		{
			Column column2 = columnCollection_0.method_0(i);
			int num2 = 0;
			while (num2 < count)
			{
				Cell cell = column2.vmethod_3(num2);
				if (cell.MergedTo == null && i + cell.ColSpan <= endColumn)
				{
					int colSpan = cell.ColSpan;
					int rowSpan = cell.RowSpan;
					for (int j = 0; j < colSpan; j++)
					{
						if (column != null && (column[num2 + j].ColSpan & 1) != 1)
						{
							if (insideV != null)
							{
								borders[num2 + j, i, 0] = insideV;
							}
						}
						else if (left != null)
						{
							borders[num2 + j, i, 0] = left;
						}
						if (right != null && (colSpan & 1) == 1)
						{
							borders[num2 + j, i + colSpan, 0] = right;
						}
					}
					Row row = ((num2 > 0) ? rowCollection_0.method_0(num2 - 1) : null);
					Row row2 = ((num2 + colSpan < count) ? rowCollection_0.method_0(num2 + rowSpan) : null);
					for (int k = 0; k < colSpan; k++)
					{
						if (row != null && (row[i + k].FirstColumnIndex & 1) == num)
						{
							if (insideH != null)
							{
								borders[num2 + k, i, 1] = insideH;
							}
						}
						else if (top != null)
						{
							borders[num2, i + k, 1] = top;
						}
						if (bottom != null && (row2 == null || (row2[i + k].FirstColumnIndex & 1) != num))
						{
							borders[num2 + rowSpan, i + k, 1] = bottom;
						}
					}
					if (fp != null)
					{
						cellFills[num2, i] = fp;
					}
					if (textStyle != null)
					{
						cellTextStyles[num2, i] = textStyle;
					}
					if (tl2rb != null)
					{
						borders[num2, i, 4] = tl2rb;
					}
					if (tr2lb != null)
					{
						borders[num2, i, 5] = tr2lb;
					}
					num2 += rowSpan;
				}
				else
				{
					num2 += ((cell.MergedTo == null) ? cell.RowSpan : cell.MergedTo.RowSpan);
				}
			}
			column = column2;
		}
	}

	private void method_25(int rowIndex, int columnIndex, Class63[,] cellFills, Class142[,] cellTextStyles, Class66[,,] borders, Class143 cellStyle, Class142 cellTextStyle, BaseSlide slide, Class169 rc, IThemeEffectiveData theme, ShapeFrame frame)
	{
		if (!smethod_4(cellStyle, cellTextStyle, slide, rc, theme, frame, out var cellFill, out var cellTextStyle2, out var leftBorder, out var topBorder, out var rightBorder, out var bottomBorder, out var _, out var _, out var tl2rbBorder, out var tr2blBorder))
		{
			return;
		}
		ICell cell = this[columnIndex, rowIndex];
		columnIndex = cell.FirstColumnIndex;
		rowIndex = cell.FirstRowIndex;
		for (int i = 0; i < cell.ColSpan; i++)
		{
			if (topBorder != null)
			{
				borders[rowIndex, columnIndex + i, 1] = topBorder;
			}
			if (bottomBorder != null)
			{
				borders[rowIndex + cell.RowSpan, columnIndex + i, 1] = bottomBorder;
			}
		}
		for (int j = 0; j < cell.RowSpan; j++)
		{
			if (leftBorder != null)
			{
				borders[rowIndex + j, columnIndex, 0] = leftBorder;
			}
			if (rightBorder != null)
			{
				borders[rowIndex + j, columnIndex + cell.ColSpan, 0] = rightBorder;
			}
		}
		if (cellFill != null)
		{
			cellFills[rowIndex, columnIndex] = cellFill;
		}
		if (cellTextStyle2 != null)
		{
			cellTextStyles[rowIndex, columnIndex] = cellTextStyle2;
		}
		if (tl2rbBorder != null)
		{
			borders[rowIndex, columnIndex, 4] = tl2rbBorder;
		}
		if (tr2blBorder != null)
		{
			borders[rowIndex, columnIndex, 5] = tr2blBorder;
		}
	}

	internal static bool smethod_4(Class143 partStyle, Class142 textStyle, BaseSlide slide, Class169 rc, IThemeEffectiveData theme, ShapeFrame shapeFrame, out Class63 cellFill, out Class142 cellTextStyle, out Class66 leftBorder, out Class66 topBorder, out Class66 rightBorder, out Class66 bottomBorder, out Class66 insideH, out Class66 insideV, out Class66 tl2rbBorder, out Class66 tr2blBorder)
	{
		bool result = false;
		cellFill = null;
		leftBorder = null;
		topBorder = null;
		rightBorder = null;
		bottomBorder = null;
		insideH = null;
		insideV = null;
		tl2rbBorder = null;
		tr2blBorder = null;
		cellTextStyle = null;
		if (partStyle.FillFormat.Source != 0)
		{
			cellFill = new Class63(new Class67(shapeFrame, null, null, slide, rc), partStyle.FillFormat.method_0(slide, theme));
			result = true;
		}
		if (partStyle.LeftBorder.Source != 0)
		{
			leftBorder = new Class66(new Class67(shapeFrame, null, null, slide, rc), partStyle.LeftBorder.method_0(slide, theme));
			result = true;
		}
		if (partStyle.TopBorder.Source != 0)
		{
			topBorder = new Class66(new Class67(shapeFrame, null, null, slide, rc), partStyle.TopBorder.method_0(slide, theme));
			result = true;
		}
		if (partStyle.RightBorder.Source != 0)
		{
			rightBorder = new Class66(new Class67(shapeFrame, null, null, slide, rc), partStyle.RightBorder.method_0(slide, theme));
			result = true;
		}
		if (partStyle.BottomBorder.Source != 0)
		{
			bottomBorder = new Class66(new Class67(shapeFrame, null, null, slide, rc), partStyle.BottomBorder.method_0(slide, theme));
			result = true;
		}
		if (partStyle.InsideHorizontalBorder.Source != 0)
		{
			insideH = new Class66(new Class67(shapeFrame, null, null, slide, rc), partStyle.InsideHorizontalBorder.method_0(slide, theme));
			result = true;
		}
		if (partStyle.InsideVerticalBorder.Source != 0)
		{
			insideV = new Class66(new Class67(shapeFrame, null, null, slide, rc), partStyle.InsideVerticalBorder.method_0(slide, theme));
			result = true;
		}
		if (partStyle.TopLeftToBottomRightBorder.Source != 0)
		{
			tl2rbBorder = new Class66(new Class67(shapeFrame, null, null, slide, rc), partStyle.TopLeftToBottomRightBorder.method_0(slide, theme));
			result = true;
		}
		if (partStyle.TopRightToBottomLeftBorder.Source != 0)
		{
			tr2blBorder = new Class66(new Class67(shapeFrame, null, null, slide, rc), partStyle.TopRightToBottomLeftBorder.method_0(slide, theme));
			result = true;
		}
		if (textStyle.FontSource != 0)
		{
			cellTextStyle = textStyle;
			result = true;
		}
		return result;
	}

	internal override void vmethod_4(Class159 canvas, Class169 rc)
	{
		if (base.Hidden)
		{
			return;
		}
		ShapeFrame shapeFrame = method_4();
		float x = shapeFrame.X;
		float y = shapeFrame.Y;
		float width = shapeFrame.Width;
		float height = shapeFrame.Height;
		if (float.IsNaN(x) || float.IsNaN(y) || float.IsNaN(width) || float.IsNaN(height))
		{
			return;
		}
		Class6002 @class = Shape.smethod_0(shapeFrame);
		@class.method_8(x, y);
		canvas.Transform = @class;
		int count = rowCollection_0.Count;
		int count2 = columnCollection_0.Count;
		int num = 0;
		int num2 = 0;
		BaseSlide baseSlide = (BaseSlide)base.Slide;
		IThemeEffectiveData theme = baseSlide.CreateThemeEffective();
		class141_0 = null;
		method_17(canvas.Transform, null, withBorders: true);
		method_26(rc);
		Class144 tableStyle = TableStyle;
		Class63 class2 = null;
		if (tableStyle != null && tableStyle.TblBackgroundStyle.FillFormat.Source != 0)
		{
			class2 = new Class63(new Class67(new ShapeFrame(0f, 0f, shapeFrame.Width, shapeFrame.Height, shapeFrame.FlipH, shapeFrame.FlipV, shapeFrame.Rotation), null, null, baseSlide, rc), tableStyle.TblBackgroundStyle.FillFormat.method_0(baseSlide, theme));
		}
		canvas.vmethod_7(new RectangleF(0f, 0f, shapeFrame.Width, shapeFrame.Height), null, class2);
		for (num = 0; num < count; num++)
		{
			Row row = rowCollection_0.method_0(num);
			double rowOffset = row.RowOffset;
			num2 = 0;
			while (num2 < count2)
			{
				Cell cell = row.vmethod_3(num2);
				if (cell.IsSlaveCell)
				{
					num2 += cell.BaseCell.ColSpan;
					continue;
				}
				ShapeFrame shapeFrame2 = new ShapeFrame(cell.OffsetX, rowOffset, cell.Width, cell.Height, NullableBool.False, NullableBool.False, 0f);
				RectangleF rectangle = shapeFrame2.Rectangle;
				Class63 class63_ = class141_0[num, num2].class63_0;
				class63_ = ((class63_ == null) ? class2 : class63_.method_2(shapeFrame2));
				canvas.vmethod_7(rectangle, null, class63_);
				num2 += cell.ColSpan;
			}
		}
		float num3 = 0f;
		for (num2 = 0; num2 <= count2; num2++)
		{
			Class66 class3 = null;
			float x2 = (float)((num2 < count2) ? columnCollection_0.method_0(num2).ColumnOffset : columnCollection_0.TotalWidth);
			for (num = 0; num < count; num++)
			{
				float num4 = (float)rowCollection_0.method_0(num).RowOffset;
				Class66 class4 = null;
				if (class140_0[num, num2] != null)
				{
					class4 = class140_0[num, num2].class66_0;
				}
				if (class4 != class3)
				{
					if (class3 != null)
					{
						canvas.vmethod_11(class3, new PointF(x2, num3), new PointF(x2, num4));
					}
					class3 = class4;
					num3 = num4;
				}
			}
			if (class3 != null)
			{
				canvas.vmethod_11(class3, new PointF(x2, num3), new PointF(x2, (float)rowCollection_0.TotalHeight));
			}
		}
		for (num = 0; num <= count; num++)
		{
			Class66 class3 = null;
			float y2 = (float)((num < count) ? rowCollection_0.method_0(num).RowOffset : rowCollection_0.TotalHeight);
			for (num2 = 0; num2 < count2; num2++)
			{
				float num5 = (float)columnCollection_0.method_0(num2).ColumnOffset;
				Class66 class5 = null;
				if (class140_1[num, num2] != null)
				{
					class5 = class140_1[num, num2].class66_0;
				}
				if (class5 != class3)
				{
					if (class3 != null)
					{
						canvas.vmethod_11(class3, new PointF(num3, y2), new PointF(num5, y2));
					}
					class3 = class5;
					num3 = num5;
				}
			}
			if (class3 != null)
			{
				canvas.vmethod_11(class3, new PointF(num3, y2), new PointF((float)columnCollection_0.TotalWidth, y2));
			}
		}
		for (num = 0; num < count; num++)
		{
			Row row2 = rowCollection_0.method_0(num);
			double rowOffset2 = row2.RowOffset;
			num2 = 0;
			while (num2 < count2)
			{
				Cell cell2 = row2.vmethod_3(num2);
				if (cell2.IsSlaveCell)
				{
					num2 += cell2.BaseCell.ColSpan;
					continue;
				}
				ShapeFrame shapeFrame3 = new ShapeFrame(cell2.OffsetX, rowOffset2, cell2.Width, cell2.Height, NullableBool.False, NullableBool.False, 0f);
				RectangleF rectangle2 = shapeFrame3.Rectangle;
				Class66 class66_ = class141_0[num, num2].class66_0;
				if (class66_ != null)
				{
					canvas.vmethod_11(class66_, new PointF(rectangle2.Left, rectangle2.Top), new PointF(rectangle2.Right, rectangle2.Bottom));
				}
				class66_ = class141_0[num, num2].class66_1;
				if (class66_ != null)
				{
					canvas.vmethod_11(class66_, new PointF(rectangle2.Right, rectangle2.Top), new PointF(rectangle2.Left, rectangle2.Bottom));
				}
				Class6002 transform = canvas.Transform;
				switch (cell2.TextVerticalType)
				{
				case TextVerticalType.Vertical270:
					transform.method_8(rectangle2.X + (float)cell2.MarginLeft, rectangle2.Y + rectangle2.Height - (float)cell2.MarginBottom);
					transform.method_12(270f);
					break;
				default:
					transform.method_8(rectangle2.X + (float)cell2.MarginLeft, rectangle2.Y + (float)cell2.MarginTop);
					break;
				case TextVerticalType.Vertical:
				case TextVerticalType.EastAsianVertical:
				case TextVerticalType.MongolianVertical:
					transform.method_8(rectangle2.X + rectangle2.Width - (float)cell2.MarginRight, rectangle2.Y + (float)cell2.MarginTop);
					transform.method_12(90f);
					break;
				}
				canvas.Transform = transform;
				((TextFrame)cell2.TextFrame).method_10(canvas, rc);
				canvas.Transform = @class;
				num2 += cell2.ColSpan;
			}
		}
	}

	private void method_26(Class169 rc)
	{
		Class141[,] cellStylesCache = CellStylesCache;
		int count = rowCollection_0.Count;
		int count2 = columnCollection_0.Count;
		if (count < 1)
		{
			return;
		}
		double[] array = new double[count + 1];
		bool[] array2 = new bool[count];
		for (int i = 0; i <= count; i++)
		{
			array[i] = 0.0;
		}
		for (int j = 0; j < count; j++)
		{
			double num = array[j] + Math.Max(rowCollection_0.method_0(j).MinimalHeight, 1.0);
			if (array[j + 1] < num)
			{
				array[j + 1] = num;
			}
			Row row = rowCollection_0.method_0(j);
			int num2 = 0;
			while (num2 < count2)
			{
				Cell cell = row.vmethod_3(num2);
				if (cell.IsSlaveCell)
				{
					num2 += cell.BaseCell.ColSpan;
					continue;
				}
				TextFrame textFrame = (TextFrame)cell.TextFrame;
				switch (cell.TextVerticalType)
				{
				default:
					if (cell.NeedToUpdateSize || textFrame.class532_0 == null)
					{
						Class142 cellTextStyle = cellStylesCache[j, num2].class142_0;
						textFrame.method_6((float)(cell.Width - cell.MarginLeft - cell.MarginRight), 0f, cellTextStyle, rc);
					}
					break;
				case TextVerticalType.Vertical:
				case TextVerticalType.Vertical270:
				case TextVerticalType.EastAsianVertical:
				case TextVerticalType.MongolianVertical:
					textFrame.class532_0 = null;
					array2[j] = true;
					break;
				}
				num2 += cell.ColSpan;
				cell.NeedToUpdateSize = false;
				if (textFrame.class532_0 != null)
				{
					num = array[j] + (double)textFrame.class532_0.TextHeight + cell.MarginTop + cell.MarginBottom;
					int nextRowIndex = cell.NextRowIndex;
					if (array[nextRowIndex] < num)
					{
						array[nextRowIndex] = num;
					}
					textFrame.class532_0.method_0((float)(array[nextRowIndex] - array[j] - cell.MarginTop - cell.MarginBottom), 0f);
				}
			}
		}
		for (int k = 0; k < count; k++)
		{
			Row row2 = rowCollection_0.method_0(k);
			row2.double_1 = array[k];
			row2.ActualHeightInternal = array[k + 1] - array[k];
			if (!array2[k])
			{
				continue;
			}
			int num3 = 0;
			while (num3 < count2)
			{
				Cell cell2 = row2.vmethod_3(num3);
				if (cell2.IsSlaveCell)
				{
					num3 += cell2.BaseCell.ColSpan;
					continue;
				}
				switch (cell2.TextVerticalType)
				{
				case TextVerticalType.Vertical:
				case TextVerticalType.Vertical270:
				case TextVerticalType.EastAsianVertical:
				case TextVerticalType.MongolianVertical:
				{
					int nextRowIndex2 = cell2.NextRowIndex;
					Class142 cellTextStyle2 = cellStylesCache[k, num3].class142_0;
					((TextFrame)cell2.TextFrame).method_6((float)(array[nextRowIndex2] - array[k] - cell2.MarginTop - cell2.MarginBottom), (float)(cell2.Width - cell2.MarginLeft - cell2.MarginRight), cellTextStyle2, rc);
					break;
				}
				}
				num3 += cell2.ColSpan;
			}
		}
		rowCollection_0.double_0 = array[count];
		rowCollection_0.bool_1 = true;
	}

	internal override void vmethod_6()
	{
		if (!bool_1 && !bool_2)
		{
			bool_2 = true;
			method_26(null);
			ShapeFrame shapeFrame = method_4();
			method_6(new ShapeFrame(shapeFrame.X, shapeFrame.Y, columnCollection_0.TotalWidth, rowCollection_0.TotalHeight, shapeFrame.FlipH, shapeFrame.FlipV, shapeFrame.Rotation));
			bool_1 = true;
			bool_2 = false;
		}
	}
}
