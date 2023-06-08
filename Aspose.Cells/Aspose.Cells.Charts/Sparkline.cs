using System.Drawing;
using System.IO;
using Aspose.Cells.Rendering;
using ns16;
using ns2;
using ns23;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///       A sparkline represents a tiny chart or graphic in a worksheet cell that provides a visual representation of data.
///       </summary>
public class Sparkline
{
	private SparklineCollection sparklineCollection_0;

	private Class1309 class1309_0;

	private int int_0;

	private short short_0;

	/// <summary>
	///       Represents the data range of the sparkline.
	///       </summary>
	public string DataRange
	{
		get
		{
			if (class1309_0 == null)
			{
				return null;
			}
			return Class1618.smethod_93(class1309_0.Values);
		}
		set
		{
			Worksheet worksheet_ = sparklineCollection_0.method_1().SparklineGroupCollection.method_0();
			class1309_0 = new Class1309(worksheet_);
			class1309_0.Values = value;
			class1309_0.GetRange();
			if (class1309_0.int_1 == class1309_0.int_3)
			{
				if (class1309_0.bool_2 != class1309_0.bool_3)
				{
					throw new CellsException(ExceptionType.Sparkline, "The reference for the data range is invalid");
				}
				return;
			}
			if (class1309_0.int_0 == class1309_0.int_2)
			{
				if (class1309_0.bool_0 != class1309_0.bool_1)
				{
					throw new CellsException(ExceptionType.Sparkline, "The reference for the data range is invalid");
				}
				return;
			}
			throw new CellsException(ExceptionType.Sparkline, "Data range cells must in same column or row");
		}
	}

	/// <summary>
	///       Gets the row index of the sparkline.
	///       </summary>
	public int Row => int_0;

	/// <summary>
	///       Gets the column index of the sparkline.
	///       </summary>
	public int Column => short_0;

	internal Sparkline(SparklineCollection sparklineCollection_1)
	{
		sparklineCollection_0 = sparklineCollection_1;
	}

	internal Class1309 method_0()
	{
		return class1309_0;
	}

	internal Class1310[] method_1()
	{
		if (class1309_0 != null)
		{
			return class1309_0.method_0();
		}
		return null;
	}

	internal void method_2(int int_1)
	{
		int_0 = int_1;
	}

	/// <summary>
	///       Converts a sparkline to an image.
	///       </summary>
	/// <param name="options">The image options</param>
	/// <returns>Returns a <see cref="T:System.Drawing.Bitmap" /> object.</returns>
	public Bitmap ToImage(ImageOrPrintOptions options)
	{
		Worksheet worksheet = sparklineCollection_0.method_1().SparklineGroupCollection.method_0();
		int columnWidthPixel = worksheet.Cells.GetColumnWidthPixel(short_0);
		int rowHeightPixel = worksheet.Cells.GetRowHeightPixel(int_0);
		return Class1304.ToImage(options, sparklineCollection_0.method_1(), this, columnWidthPixel, rowHeightPixel);
	}

	/// <summary>
	///       Converts a sparkline to an image.
	///       </summary>
	/// <param name="fileName">The image file name.</param>
	/// <param name="options">The image options</param>
	public void ToImage(string fileName, ImageOrPrintOptions options)
	{
		if (options == null)
		{
			options = new ImageOrPrintOptions();
		}
		Worksheet worksheet = sparklineCollection_0.method_1().SparklineGroupCollection.method_0();
		int columnWidthPixel = worksheet.Cells.GetColumnWidthPixel(short_0);
		int rowHeightPixel = worksheet.Cells.GetRowHeightPixel(int_0);
		Class1304.ToImage(fileName, options, sparklineCollection_0.method_1(), this, columnWidthPixel, rowHeightPixel);
	}

	/// <summary>
	///       Converts a sparkline to an image.
	///       </summary>
	/// <param name="stream">The image stream.</param>
	/// <param name="options">The image options.</param>
	public void ToImage(Stream stream, ImageOrPrintOptions options)
	{
		Worksheet worksheet = sparklineCollection_0.method_1().SparklineGroupCollection.method_0();
		int columnWidthPixel = worksheet.Cells.GetColumnWidthPixel(short_0);
		int rowHeightPixel = worksheet.Cells.GetRowHeightPixel(int_0);
		Class1304.ToImage(stream, options, sparklineCollection_0.method_1(), this, columnWidthPixel, rowHeightPixel);
	}

	internal void method_3(int int_1)
	{
		short_0 = (short)int_1;
	}

	internal bool method_4(CellArea cellArea_0)
	{
		if (int_0 >= cellArea_0.StartRow && int_0 <= cellArea_0.EndRow && short_0 >= cellArea_0.StartColumn && short_0 <= cellArea_0.EndColumn)
		{
			return true;
		}
		return false;
	}

	internal bool InsertRows(Cells cells_0, int int_1, int int_2, bool bool_0)
	{
		if (int_2 < 0 && int_0 >= int_1 && int_0 < int_1 - int_2)
		{
			return true;
		}
		int int_3 = int_0;
		if (bool_0 && int_0 >= int_1)
		{
			int_0 += int_2;
		}
		int int_4 = int_0;
		if (class1309_0.string_1.Equals(cells_0.method_3().Name))
		{
			if (class1309_0.int_0 >= int_1 && class1309_0.int_2 < int_1 - int_2)
			{
				return true;
			}
			class1309_0.int_0 += int_2;
			class1309_0.int_2 += int_2;
			if (class1309_0.byte_0 != null)
			{
				Class1674.InsertRows(cells_0.method_3(), bool_0, int_1, int_2, int_3, int_4, -1, -1, class1309_0.byte_0);
			}
		}
		return false;
	}

	internal bool InsertColumns(Cells cells_0, int int_1, int int_2, bool bool_0)
	{
		if (int_2 < 0 && short_0 >= int_1 && short_0 < int_1 - int_2)
		{
			return true;
		}
		int int_3 = short_0;
		if (bool_0 && short_0 >= int_1)
		{
			short_0 += (short)int_2;
		}
		int int_4 = short_0;
		if (class1309_0.string_1.Equals(cells_0.method_3().Name))
		{
			if (class1309_0.int_1 >= int_1 && class1309_0.int_3 < int_1 - int_2)
			{
				return true;
			}
			class1309_0.int_1 += int_2;
			class1309_0.int_3 += int_2;
			if (class1309_0.byte_0 != null)
			{
				Class1674.InsertColumns(cells_0.method_3(), bool_0, int_1, int_2, int_3, int_4, -1, -1, class1309_0.byte_0);
			}
		}
		return false;
	}

	internal void Copy(Sparkline sparkline_0, CopyOptions copyOptions_0)
	{
		short_0 = sparkline_0.short_0;
		int_0 = sparkline_0.int_0;
		if (sparkline_0.class1309_0 != null)
		{
			class1309_0 = new Class1309(sparklineCollection_0.method_3());
			if (!copyOptions_0.bool_0)
			{
				DataRange = sparkline_0.DataRange;
			}
			else
			{
				class1309_0.byte_0 = Class1379.Copy(sparkline_0.sparklineCollection_0.method_4(), sparklineCollection_0.method_4(), sparkline_0.class1309_0.byte_0, -1, 0, 0);
			}
		}
	}
}
