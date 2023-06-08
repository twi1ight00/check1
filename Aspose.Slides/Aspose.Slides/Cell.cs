using System;
using ns16;
using ns24;
using ns4;

namespace Aspose.Slides;

public class Cell : IPresentationComponent, ISlideComponent, ICell
{
	private Class305 class305_0 = new Class305();

	internal TextFrame textFrame_0;

	private Row row_0;

	private Column column_0;

	internal int int_0 = 1;

	internal int int_1 = 1;

	private LineFormat lineFormat_0;

	private LineFormat lineFormat_1;

	private LineFormat lineFormat_2;

	private LineFormat lineFormat_3;

	private LineFormat lineFormat_4;

	private LineFormat lineFormat_5;

	private FillFormat fillFormat_0;

	private double double_0 = 7.2;

	private double double_1 = 7.2;

	private double double_2 = 3.6;

	private double double_3 = 3.6;

	internal Cell cell_0;

	private TextVerticalType textVerticalType_0;

	private TextAnchorType textAnchorType_0;

	private Enum378 enum378_0 = Enum378.const_2;

	private bool bool_0;

	private bool bool_1;

	internal Class305 PPTXUnsupportedProps => class305_0;

	internal bool IsSingleCell
	{
		get
		{
			if (int_0 < 2)
			{
				return int_1 < 2;
			}
			return false;
		}
	}

	internal bool IsSlaveCell => cell_0 != null;

	internal Cell BaseCell
	{
		get
		{
			if (!IsSlaveCell)
			{
				return this;
			}
			return cell_0;
		}
	}

	public double OffsetX => BaseCell.ParentColumnInternal.ColumnOffset;

	public double OffsetY
	{
		get
		{
			if (TableInternal != null && TableInternal.shapeCollection_0 != null && TableInternal.shapeCollection_0.ParentGroup != null)
			{
				((Table)Table).vmethod_6();
			}
			return BaseCell.ParentRowInternal.RowOffset;
		}
	}

	public int FirstRowIndex => BaseCell.ParentRowInternal.RowIndex;

	public int FirstColumnIndex => BaseCell.ParentColumnInternal.ColumnIndex;

	public double Width
	{
		get
		{
			Cell baseCell = BaseCell;
			Column column = ParentColumnInternal.ParentColumnsCollection.method_0(baseCell.ParentColumnInternal.ColumnIndex + baseCell.ColSpan - 1);
			if (baseCell.ColSpan == 1)
			{
				return column.Width;
			}
			return column.ColumnOffset + column.Width - baseCell.ParentColumnInternal.ColumnOffset;
		}
	}

	public double Height
	{
		get
		{
			Cell baseCell = BaseCell;
			Row row = ParentRowInternal.ParentRowsCollection.method_0(baseCell.ParentRowInternal.RowIndex + baseCell.RowSpan - 1);
			if (baseCell.RowSpan == 1)
			{
				return row.Height;
			}
			return row.RowOffset + row.Height - baseCell.ParentRowInternal.RowOffset;
		}
	}

	internal int NextColumnIndex => BaseCell.ParentColumnInternal.ColumnIndex + BaseCell.ColSpan;

	internal int NextRowIndex => BaseCell.ParentRowInternal.RowIndex + BaseCell.RowSpan;

	public double MinimalHeight
	{
		get
		{
			int firstRowIndex = FirstRowIndex;
			RowCollection parentRowsCollection = ParentRowInternal.ParentRowsCollection;
			double num = 0.0;
			for (int i = 0; i < int_0; i++)
			{
				num += parentRowsCollection.method_0(firstRowIndex + i).MinimalHeight;
			}
			return num;
		}
	}

	public ILineFormat BorderLeft => lineFormat_0;

	public ILineFormat BorderTop => lineFormat_1;

	public ILineFormat BorderRight => lineFormat_2;

	public ILineFormat BorderBottom => lineFormat_3;

	public ILineFormat BorderDiagonalDown => lineFormat_4;

	public ILineFormat BorderDiagonalUp => lineFormat_5;

	public IFillFormat FillFormat => fillFormat_0;

	public double MarginLeft
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
			NeedToUpdateSize = true;
		}
	}

	public double MarginRight
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
			NeedToUpdateSize = true;
		}
	}

	public double MarginTop
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
			NeedToUpdateSize = true;
		}
	}

	public double MarginBottom
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
			NeedToUpdateSize = true;
		}
	}

	public TextVerticalType TextVerticalType
	{
		get
		{
			return textVerticalType_0;
		}
		set
		{
			if (value == TextVerticalType.NotDefined)
			{
				throw new Exception("Value of Cell.TextVerticalType property cannot be TextVerticalType.NotDefined. Set TextVerticalType.Horizontal default value instead.");
			}
			textVerticalType_0 = value;
			NeedToUpdateSize = true;
		}
	}

	public TextAnchorType TextAnchorType
	{
		get
		{
			return textAnchorType_0;
		}
		set
		{
			if (value == TextAnchorType.NotDefined)
			{
				throw new Exception("Value of Cell.TextAnchorType property cannot be TextAnchorType.NotDefined. Set TextAnchorType.Top default value instead.");
			}
			textAnchorType_0 = value;
			NeedToUpdateSize = true;
		}
	}

	internal Enum378 TextHorizontalOverflow
	{
		get
		{
			return enum378_0;
		}
		set
		{
			enum378_0 = value;
			NeedToUpdateSize = true;
		}
	}

	public bool AnchorCenter
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			NeedToUpdateSize = true;
		}
	}

	internal Cell MergedTo => cell_0;

	public int ColSpan => int_1;

	public int RowSpan => int_0;

	public ITextFrame TextFrame => textFrame_0;

	public IRow FirstRow => BaseCell.ParentRowInternal;

	public IColumn FirstColumn => BaseCell.ParentColumnInternal;

	public ITable Table => TableInternal;

	internal Table TableInternal => ParentRowInternal.ParentTable;

	internal Column ParentColumnInternal => column_0;

	internal Row ParentRowInternal => row_0;

	internal Class142 TextStyleCache => TableInternal.CellStylesCache[FirstRowIndex, FirstColumnIndex].class142_0;

	internal Class149[] BorderStylesCachePVITemp
	{
		get
		{
			Class149[] array = new Class149[6];
			for (int i = 0; i < 6; i++)
			{
				array[i] = TableInternal.BorderStylesCachePVITemp[FirstRowIndex, FirstColumnIndex, i];
			}
			return array;
		}
	}

	internal Class148 FillStyleCachePVITemp => TableInternal.CellFillStylesCachePVITemp[FirstRowIndex, FirstColumnIndex];

	internal Class142 TextStyleCachePVITemp => TableInternal.CellTextStylesCachePVITemp[FirstRowIndex, FirstColumnIndex];

	internal bool NeedToUpdateSize
	{
		get
		{
			return bool_1;
		}
		set
		{
			if (ParentRowInternal != null && TableInternal != null)
			{
				bool_1 = value;
				if (value)
				{
					TableInternal.bool_1 = false;
				}
			}
		}
	}

	ISlideComponent ICell.AsISlideComponent => this;

	public IBaseSlide Slide => ParentRowInternal.Slide;

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	public IPresentation Presentation => ParentRowInternal.Presentation;

	internal Cell(Row parentRow, Column parentColumn)
	{
		row_0 = parentRow;
		column_0 = parentColumn;
		textFrame_0 = new TextFrame(this);
		textFrame_0.textFrameFormat_0.delegate12_0 = method_8;
		lineFormat_0 = new LineFormat(this);
		lineFormat_1 = new LineFormat(this);
		lineFormat_2 = new LineFormat(this);
		lineFormat_3 = new LineFormat(this);
		lineFormat_4 = new LineFormat(this);
		lineFormat_5 = new LineFormat(this);
		fillFormat_0 = new FillFormat(this);
		bool_1 = true;
	}

	internal void method_0()
	{
		cell_0 = null;
		row_0 = null;
		column_0 = null;
	}

	internal void method_1(bool mergeText)
	{
		if (IsSingleCell)
		{
			return;
		}
		cell_0 = null;
		int firstRowIndex = FirstRowIndex;
		int firstColumnIndex = FirstColumnIndex;
		Row row = ParentRowInternal.ParentRowsCollection.method_0(firstRowIndex);
		for (int i = 1; i < int_1; i++)
		{
			method_2(row.vmethod_3(firstColumnIndex + i), mergeText);
		}
		for (int j = 1; j < int_0; j++)
		{
			row = ParentRowInternal.ParentRowsCollection.method_0(firstRowIndex + j);
			for (int k = 0; k < int_1; k++)
			{
				method_2(row.vmethod_3(firstColumnIndex + k), mergeText);
			}
		}
	}

	private void method_2(Cell mergedCell, bool mergeText)
	{
		if (mergeText && ((TextFrame)mergedCell.TextFrame).TextInternal != "")
		{
			TextFrame.Paragraphs.Add(mergedCell.TextFrame.Paragraphs);
			((TextFrame)mergedCell.TextFrame).TextInternal = "";
		}
		mergedCell.cell_0 = this;
	}

	internal void method_3(Cell source)
	{
		textFrame_0.method_0(source.textFrame_0);
		lineFormat_0.method_0(source.lineFormat_0);
		lineFormat_1.method_0(source.lineFormat_1);
		lineFormat_2.method_0(source.lineFormat_2);
		lineFormat_3.method_0(source.lineFormat_3);
		lineFormat_4.method_0(source.lineFormat_4);
		lineFormat_5.method_0(source.lineFormat_5);
		fillFormat_0.method_0(source.fillFormat_0);
		double_0 = source.double_0;
		double_1 = source.double_1;
		double_2 = source.double_2;
		double_3 = source.double_3;
		textVerticalType_0 = source.textVerticalType_0;
		textAnchorType_0 = source.textAnchorType_0;
		bool_0 = source.bool_0;
		PPTXUnsupportedProps.method_0(source.PPTXUnsupportedProps);
	}

	public void SplitByColSpan(int index)
	{
		if (index < 1 || index >= int_1)
		{
			throw new ArgumentOutOfRangeException("Index must be grater than 0 and less than ColSpan.");
		}
		method_4(index);
	}

	internal Cell method_4(int newColSpan)
	{
		Cell cell = ParentColumnInternal.vmethod_3(FirstColumnIndex + newColSpan);
		cell.int_0 = int_0;
		cell.int_1 = int_1 - newColSpan;
		int_1 = newColSpan;
		cell.method_1(mergeText: false);
		cell.method_3(this);
		((TextFrame)cell.TextFrame).TextInternal = "";
		TableInternal.method_16();
		return cell;
	}

	public void SplitByRowSpan(int index)
	{
		if (index < 1 || index >= int_0)
		{
			throw new ArgumentOutOfRangeException("Index must be greater than 0 and less than RowSpan.");
		}
		method_5(index);
	}

	internal Cell method_5(int newRowSpan)
	{
		Cell cell = ParentRowInternal.vmethod_3(FirstRowIndex + newRowSpan);
		cell.int_1 = int_1;
		cell.int_0 = int_0 - newRowSpan;
		int_0 = newRowSpan;
		cell.method_1(mergeText: false);
		cell.method_3(this);
		((TextFrame)cell.TextFrame).TextInternal = "";
		TableInternal.method_16();
		return cell;
	}

	public void SplitByHeight(double height)
	{
		height = Math.Round(height * 12700.0) / 12700.0;
		double minimalHeight = MinimalHeight;
		if (!(height <= 0.0) && height < minimalHeight)
		{
			RowCollection parentRowsCollection = ParentRowInternal.ParentRowsCollection;
			int firstRowIndex = FirstRowIndex;
			int i;
			for (i = firstRowIndex; parentRowsCollection[i].MinimalHeight <= height; i++)
			{
				height -= parentRowsCollection[i].MinimalHeight;
			}
			if (height > 3.937007874015748E-05)
			{
				parentRowsCollection.method_5(i, height);
				i++;
			}
			method_5(i - firstRowIndex);
			return;
		}
		throw new ArgumentOutOfRangeException("Splitting height must be in greater than 0 and less than cell's minimal height");
	}

	public void SplitByWidth(double width)
	{
		double width2 = Width;
		if (width <= 0.0 || width >= width2)
		{
			throw new ArgumentOutOfRangeException("Splitting width must be in greater than 0 and less than cell's width");
		}
		ColumnCollection parentColumnsCollection = ParentColumnInternal.ParentColumnsCollection;
		double targetOffset = OffsetX + width;
		int num = ParentColumnInternal.ParentColumnsCollection.method_1(targetOffset);
		parentColumnsCollection.method_5(FirstColumnIndex, width);
		method_4(num - FirstColumnIndex);
	}

	internal void method_6()
	{
		method_7(BorderLeft);
		method_7(BorderTop);
		method_7(BorderRight);
		method_7(BorderBottom);
		method_7(BorderDiagonalDown);
		method_7(BorderDiagonalUp);
	}

	private void method_7(ILineFormat targetFormat)
	{
		if (targetFormat != null && !targetFormat.IsFormatNotDefined)
		{
			targetFormat.CapStyle = LineCapStyle.Flat;
			targetFormat.Style = LineStyle.Single;
			targetFormat.Alignment = LineAlignment.Center;
			if (targetFormat.DashStyle == LineDashStyle.NotDefined)
			{
				targetFormat.DashStyle = LineDashStyle.Solid;
			}
			targetFormat.JoinStyle = LineJoinStyle.Round;
			targetFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
			targetFormat.BeginArrowheadWidth = LineArrowheadWidth.Medium;
			targetFormat.BeginArrowheadLength = LineArrowheadLength.Medium;
			targetFormat.EndArrowheadStyle = LineArrowheadStyle.None;
			targetFormat.EndArrowheadWidth = LineArrowheadWidth.Medium;
			targetFormat.EndArrowheadLength = LineArrowheadLength.Medium;
		}
	}

	private void method_8()
	{
		NeedToUpdateSize = true;
		TableInternal.method_16();
	}
}
