using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using ns16;
using ns52;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Encapsulates the object that represents a single picture in a spreadsheet.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///       //Instantiating a Workbook object
///       Workbook workbook = new Workbook();
///       //Adding a new worksheet to the Workbook object
///       int sheetIndex = workbook.Worksheets.Add();
///       //Obtaining the reference of the newly added worksheet by passing its sheet index
///       Worksheet worksheet = workbook.Worksheets[sheetIndex];
///       //Adding a picture at the location of a cell whose row and column indices
///       //are 5 in the worksheet. It is "F6" cell
///       worksheet.Pictures.Add(5, 5, "C:\\image.gif");
///       //Saving the Excel file
///       workbook.Save(saveFileDialog1.FileName, SaveFormat.Excel97To2003);
///
///       [Visual Basic]
///
///       'Instantiating a Workbook object
///       Dim workbook As Workbook = New Workbook()
///       'Adding a new worksheet to the Workbook object
///       Dim sheetIndex As Integer = workbook.Worksheets.Add()
///       'Obtaining the reference of the newly added worksheet by passing its sheet index
///       Dim worksheet As Worksheet = workbook.Worksheets(sheetIndex)
///       'Adding a picture at the location of a cell whose row and column indices
///       'are 5 in the worksheet. It is "F6" cell
///       worksheet.Pictures.Add(5, 5, "C:\image.gif")
///       'Saving the Excel file
///       workbook.Save("C:\book1.xls", SaveFormat.Excel97To2003)
///       </code>
/// </example>
public class Picture : Shape
{
	private byte byte_0 = 1;

	/// <summary>
	///       Gets the original height of the picture.
	///       </summary>
	public int OriginalHeight => method_69().Height;

	/// <summary>
	///       Gets the original width of the picture.
	///       </summary>
	public int OriginalWidth => method_69().Width;

	/// <summary>
	///       Represents the <see cref="T:System.Drawing.Color" /> of the border line of a picture.
	///       </summary>
	public Color BorderLineColor
	{
		get
		{
			return base.LineFormat.ForeColor;
		}
		set
		{
			base.LineFormat.ForeColor = value;
		}
	}

	/// <summary>
	///       Gets or sets the weight of the border line of a picture in units of pt.
	///       </summary>
	public double BorderWeight
	{
		get
		{
			return base.LineFormat.Weight;
		}
		set
		{
			base.LineFormat.Weight = value;
		}
	}

	/// <summary>
	///       Gets the data of the picture.
	///       </summary>
	public byte[] Data
	{
		get
		{
			if (method_70() <= 0)
			{
				return null;
			}
			Class1696 @class = method_69();
			return @class.ImageData;
		}
		set
		{
			if (method_70() != -1)
			{
				int int_ = method_70();
				method_71(0);
				base.Shapes.method_27(int_);
			}
			if (value != null)
			{
				MemoryStream stream_ = new MemoryStream(value);
				method_71(base.Shapes.method_5().method_0().Add(stream_) + 1);
			}
		}
	}

	/// <summary>
	///       Gets or sets the path and name of the source file for the linked image. 
	///       </summary>
	/// <remarks>
	///       The default value is an empty string.
	///       If SourceFullName is not an empty string, the image is linked.
	///       If SourceFullName is not an empty string, but Data is null, then the image is linked and not stored in the file.
	///       </remarks>
	public string SourceFullName
	{
		get
		{
			if (((uint)method_72() & 0xAu) != 0)
			{
				return method_27().method_2().GetStringValue(49413);
			}
			return null;
		}
		set
		{
			method_27().method_2().method_1(49413, Enum183.const_2, value);
			method_73(14);
			if (method_27().method_2()[16644] != null)
			{
				method_69().method_8();
				method_27().method_2().Remove(16644);
			}
		}
	}

	/// <summary>
	///       Gets the image format of the picture.
	///       </summary>
	public ImageFormat ImageFormat
	{
		get
		{
			Class1696 @class = method_69();
			if (@class != null && @class.method_4() != null && @class.method_4().method_6() != null)
			{
				return @class.ImageFormat;
			}
			return ImageFormat.Bmp;
		}
	}

	public double OriginalHeightCM => method_51(OriginalHeight);

	public double OriginalWidthCM => method_51(OriginalWidth);

	public double OriginalHeightInch => method_49(OriginalHeight);

	public double OriginalWidthInch => method_49(OriginalWidth);

	internal Picture(ShapeCollection shapeCollection_1)
		: base(shapeCollection_1, MsoDrawingType.Picture, shapeCollection_1)
	{
	}

	internal void Copy(Picture picture_0, CopyOptions copyOptions_0)
	{
		bool flag = picture_0.method_25() == method_25();
		if (picture_0.class1556_0 != null)
		{
			class1556_0 = new Class1556();
			class1556_0.string_0 = picture_0.class1556_0.string_0;
			class1556_0.string_1 = picture_0.class1556_0.string_1;
			class1556_0.int_0 = picture_0.class1556_0.int_0;
		}
		method_66(picture_0.method_65());
		method_27().Copy(picture_0.method_27());
		if (picture_0.method_28() != null)
		{
			method_28().Copy(picture_0.method_28());
		}
		if (!flag && !copyOptions_0.bool_0)
		{
			method_28().arrayList_0 = null;
		}
		if (picture_0.method_69() != null)
		{
			method_71(base.Shapes.method_5().method_0().Copy(picture_0.method_69(), picture_0.method_70(), flag));
		}
	}

	/// <summary>
	///       Moves the picture to a specified location.
	///       </summary>
	/// <param name="upperLeftRow">Upper left row index.</param>
	/// <param name="upperLeftColumn">Upper left column index.</param>
	public void Move(int upperLeftRow, int upperLeftColumn)
	{
		if (upperLeftColumn >= 0 && upperLeftColumn <= 255 && upperLeftRow >= 0 && upperLeftRow <= 65535)
		{
			method_15(upperLeftRow, 0, upperLeftColumn, 0);
		}
	}

	/// <summary>
	///       Moves the picture to the top-right corner.
	///       </summary>
	/// <param name="row">the row index.</param>
	/// <param name="column">the column index.</param>
	public void AlignTopRightCorner(int row, int column)
	{
		PlacementType placement = base.Placement;
		base.Placement = PlacementType.Move;
		method_27().method_7().Top = 0;
		method_27().method_7().method_6(row);
		int right = method_27().method_7().Right;
		int[] array = method_47(column + 1, 0, right);
		method_27().method_7().method_8(array[0]);
		method_27().method_7().Left = array[1];
		base.Placement = placement;
	}

	[SpecialName]
	internal Class1696 method_69()
	{
		if (method_70() < 1)
		{
			return null;
		}
		return base.Shapes.method_5().method_0()[method_70() - 1];
	}

	[SpecialName]
	internal int method_70()
	{
		return method_27().method_2().method_4(16644, 0);
	}

	[SpecialName]
	internal void method_71(int int_0)
	{
		method_27().method_2().method_1(16644, Enum183.const_0, int_0);
	}

	[SpecialName]
	internal int method_72()
	{
		return method_27().method_2().method_4(262, 0);
	}

	[SpecialName]
	internal void method_73(int int_0)
	{
		method_27().method_2().method_1(262, Enum183.const_0, int_0);
	}

	[SpecialName]
	internal bool method_74()
	{
		return (method_72() & 8) != 0;
	}

	[SpecialName]
	internal byte method_75()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_76(byte byte_1)
	{
		byte_0 = byte_1;
	}
}
