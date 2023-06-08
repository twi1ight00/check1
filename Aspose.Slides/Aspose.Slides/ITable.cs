using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("fb809552-527c-47d1-a5e0-734f860c0481")]
[ComVisible(true)]
public interface ITable : IPresentationComponent, ISlideComponent, IHyperlinkContainer, IShape, IGraphicalObject
{
	TableStylePreset StylePreset { get; set; }

	ICell this[int columnIndex, int rowIndex] { get; }

	IRowCollection Rows { get; }

	IColumnCollection Columns { get; }

	bool RightToLeft { get; set; }

	bool FirstRow { get; set; }

	bool FirstCol { get; set; }

	bool LastRow { get; set; }

	bool LastCol { get; set; }

	bool HorizontalBanding { get; set; }

	bool VerticalBanding { get; set; }

	IGraphicalObject AsIGraphicalObject { get; }

	ICell MergeCells(ICell cell1, ICell cell2, bool allowSplitting);
}
