using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("69e86485-b290-445a-bc6f-25bfc460859b")]
[ComVisible(true)]
public interface ICell : IPresentationComponent, ISlideComponent
{
	double OffsetX { get; }

	double OffsetY { get; }

	int FirstRowIndex { get; }

	int FirstColumnIndex { get; }

	double Width { get; }

	double Height { get; }

	double MinimalHeight { get; }

	ILineFormat BorderLeft { get; }

	ILineFormat BorderTop { get; }

	ILineFormat BorderRight { get; }

	ILineFormat BorderBottom { get; }

	ILineFormat BorderDiagonalDown { get; }

	ILineFormat BorderDiagonalUp { get; }

	IFillFormat FillFormat { get; }

	double MarginLeft { get; set; }

	double MarginRight { get; set; }

	double MarginTop { get; set; }

	double MarginBottom { get; set; }

	TextVerticalType TextVerticalType { get; set; }

	TextAnchorType TextAnchorType { get; set; }

	bool AnchorCenter { get; set; }

	IColumn FirstColumn { get; }

	IRow FirstRow { get; }

	int ColSpan { get; }

	int RowSpan { get; }

	ITextFrame TextFrame { get; }

	ITable Table { get; }

	ISlideComponent AsISlideComponent { get; }

	void SplitByColSpan(int index);

	void SplitByRowSpan(int index);

	void SplitByHeight(double height);

	void SplitByWidth(double width);
}
