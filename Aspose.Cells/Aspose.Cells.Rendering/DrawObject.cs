using System.Drawing;

namespace Aspose.Cells.Rendering;

/// <summary>
///       DrawObject will be initalized and returned when rendering
///       </summary>
public class DrawObject
{
	private Cell cell_0;

	private Image image_0;

	private DrawObjectEnum drawObjectEnum_0;

	private int int_0;

	private int int_1;

	private int int_2;

	/// <summary>
	///       Cell will be returned when rendering.
	///       All properties of cell can be accessed. 
	///       </summary>
	public Cell Cell => cell_0;

	/// <summary>
	///       Chart,shape will be returned when rendering.
	///       </summary>
	public Image Image => image_0;

	/// <summary>
	///       Indicate Cell or Image of DrawObject.
	///       </summary>
	public DrawObjectEnum Type => drawObjectEnum_0;

	/// <summary>
	///       Indicate the page index of DrawObject. 
	///       Page index is based on zero.
	///       One Sheet contains several pages when rendering.
	///       </summary>
	public int CurrentPage => int_0;

	/// <summary>
	///       Indicate total pages in current rendering. 
	///       </summary>
	public int TotalPages => int_1;

	/// <summary>
	///       Indicate current sheet index of DrawObject
	///       </summary>
	public int SheetIndex => int_2;

	internal DrawObject(Cell cell_1, int int_3, int int_4, int int_5)
	{
		drawObjectEnum_0 = DrawObjectEnum.Cell;
		cell_0 = cell_1;
		int_0 = int_3;
		int_1 = int_4;
		int_2 = int_5;
	}

	internal DrawObject(Image image_1, int int_3, int int_4, int int_5)
	{
		drawObjectEnum_0 = DrawObjectEnum.Image;
		image_0 = image_1;
		int_0 = int_3;
		int_1 = int_4;
		int_2 = int_5;
	}
}
