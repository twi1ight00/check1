using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Cells.Drawing;
using ns29;
using ns52;

namespace Aspose.Cells;

/// <summary>
///       Encapsulates the object that represents the page setup description. 
///       The PageSetup object contains all page setup options.
///       </summary>
/// <example>
///   <code>
///       [C#]
///       sheet.PageSetup.PrintArea = "D1:K13";
///       sheet.PageSetup.PrintTitleRows = "$5:$7";
///       sheet.PageSetup.PrintTitleColumns = "$A:$B";
///
///       [Visual Basic]
///       sheet.PageSetup.PrintArea = "D1:K13"
///       sheet.PageSetup.PrintTitleRows = "$5:$7"
///       sheet.PageSetup.PrintTitleColumns = "$A:$B"
///       </code>
/// </example>
public class PageSetup
{
	private string string_0;

	private string string_1;

	private bool bool_0;

	private bool bool_1;

	private static Regex regex_0;

	private Worksheet worksheet_0;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private double double_0 = 0.5;

	private double double_1 = 0.5;

	private byte[] byte_0;

	private double double_2 = 0.75;

	private double double_3 = 0.75;

	private double double_4 = 1.0;

	private double double_5 = 1.0;

	private int int_0 = 1;

	private int int_1 = 1;

	private int int_2 = 1;

	private bool bool_6 = true;

	private PrintOrderType printOrderType_0;

	private PageOrientationType pageOrientationType_0 = PageOrientationType.Portrait;

	private bool bool_7;

	private PrintCommentsType printCommentsType_0 = PrintCommentsType.PrintNoComments;

	private PrintErrorsType printErrorsType_0 = PrintErrorsType.PrintErrorsDisplayed;

	private bool bool_8;

	private bool bool_9;

	private int int_3 = 100;

	private int int_4;

	private bool bool_10 = true;

	private bool bool_11 = true;

	internal bool bool_12 = true;

	private int int_5 = 300;

	private int int_6 = 300;

	private int int_7 = 1;

	internal string[] string_2;

	internal string[] string_3;

	internal string[] string_4;

	internal string[] string_5;

	internal string[] string_6;

	internal string[] string_7;

	private byte byte_1 = 4;

	private string string_8;

	private bool bool_13;

	private ShapeCollection shapeCollection_0;

	/// <summary>
	///       Represents the columns that contain the cells to be repeated on the left side of each page.
	///       </summary>
	/// <example>
	///   <code>
	///       [C#]
	///
	///       cells.PageSetup.PrintTitleColumns = "$A:$A";
	///
	///       [Visula Basic]
	///
	///       cells.PageSetup.PrintTitleColumns = "$A:$A"
	///       </code>
	/// </example>
	public string PrintTitleColumns
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			bool_0 = true;
		}
	}

	/// <summary>
	///       Represents the rows that contain the cells to be repeated at the top of each page.
	///       </summary>
	/// <example>
	///   <code>
	///       [C#]
	///
	///       cells.PageSetup.PrintTitleRows = "$1:$1";
	///
	///       [Visula Basic]
	///
	///       cells.PageSetup.PrintTitleRows = "$1:$1"
	///       </code>
	/// </example>
	public string PrintTitleRows
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
			bool_0 = true;
		}
	}

	/// <summary>
	///       Represents if elements of the document will be printed in black and white.
	///       </summary>
	public bool BlackAndWhite
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	/// <summary>
	///       Represent if the sheet is printed centered horizontally.
	///       </summary>
	public bool CenterHorizontally
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	/// <summary>
	///       Represent if the sheet is printed centered vertically.
	///       </summary>
	public bool CenterVertically
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	/// <summary>
	///       Represents if the sheet will be printed without graphics.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use PageSetup.PrintDraft property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use PageSetup.PrintDraft property instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool Draft
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	/// <summary>
	///       Represents if the sheet will be printed without graphics.
	///       </summary>
	public bool PrintDraft
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	/// <summary>
	///       Represents the distance from the bottom of the page to the footer, in unit of centimeters.
	///       </summary>
	public double FooterMargin
	{
		get
		{
			return double_0 * 2.54;
		}
		set
		{
			double_0 = value / 2.54;
		}
	}

	/// <summary>
	///       Represents the distance from the bottom of the page to the footer, in unit of inches.
	///       </summary>
	public double FooterMarginInch
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	/// <summary>
	///       Represents the distance from the top of the page to the header, in unit of centimeters.
	///       </summary>
	public double HeaderMargin
	{
		get
		{
			return double_1 * 2.54;
		}
		set
		{
			double_1 = value / 2.54;
		}
	}

	/// <summary>
	///       Represents the distance from the top of the page to the header, in unit of inches.
	///       </summary>
	public double HeaderMarginInch
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	/// <summary>
	///       Represents the size of the left margin, in unit of centimeters.
	///       </summary>
	public double LeftMargin
	{
		get
		{
			return double_2 * 2.54;
		}
		set
		{
			double_2 = value / 2.54;
		}
	}

	/// <summary>
	///       Represents the size of the left margin, in unit of inches.
	///       </summary>
	public double LeftMarginInch
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	/// <summary>
	///       Represents the size of the right margin, in unit of centimeters.
	///       </summary>
	public double RightMargin
	{
		get
		{
			return double_3 * 2.54;
		}
		set
		{
			double_3 = value / 2.54;
		}
	}

	/// <summary>
	///       Represents the size of the right margin, in unit of inches.
	///       </summary>
	public double RightMarginInch
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	/// <summary>
	///       Represents the size of the top margin, in unit of centimeters.
	///       </summary>
	public double TopMargin
	{
		get
		{
			return double_4 * 2.54;
		}
		set
		{
			double_4 = value / 2.54;
		}
	}

	/// <summary>
	///       Represents the size of the top margin, in unit of inches.
	///       </summary>
	public double TopMarginInch
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
		}
	}

	/// <summary>
	///       Represents the size of the bottom margin, in unit of centimeters.
	///       </summary>
	public double BottomMargin
	{
		get
		{
			return double_5 * 2.54;
		}
		set
		{
			double_5 = value / 2.54;
		}
	}

	/// <summary>
	///       Represents the size of the bottom margin, in unit of inches.
	///       </summary>
	public double BottomMarginInch
	{
		get
		{
			return double_5;
		}
		set
		{
			double_5 = value;
		}
	}

	/// <summary>
	///       Represents the first page number that will be used when this sheet is printed.
	///       </summary>
	public int FirstPageNumber
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			bool_10 = false;
		}
	}

	/// <summary>
	///       Represents  the number of pages tall the worksheet will be scaled to when it's printed.
	///       </summary>
	public int FitToPagesTall
	{
		get
		{
			return int_1;
		}
		set
		{
			if (value >= 0 && value <= 65535)
			{
				method_14(bool_14: true);
				int_1 = value;
				bool_6 = false;
			}
		}
	}

	/// <summary>
	///       Represents the number of pages wide the worksheet will be scaled to when it's printed.
	///       </summary>
	public int FitToPagesWide
	{
		get
		{
			return int_2;
		}
		set
		{
			if (value >= 0 && value <= 65535)
			{
				method_14(bool_14: true);
				int_2 = value;
				bool_6 = false;
			}
		}
	}

	/// <summary>
	///       If this property is False, the FitToPagesWide and FitToPagesTall properties control how the worksheet is scaled.
	///       </summary>
	public bool IsPercentScale
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	/// <summary>
	///       Represents the order that Microsoft Excel uses to number pages when printing a large worksheet.
	///       </summary>
	public PrintOrderType Order
	{
		get
		{
			return printOrderType_0;
		}
		set
		{
			printOrderType_0 = value;
		}
	}

	/// <summary>
	///       Represents the size of the paper.
	///       </summary>
	public PaperSizeType PaperSize
	{
		get
		{
			if (int_4 > 0 && int_4 <= 118)
			{
				return (PaperSizeType)int_4;
			}
			return PaperSizeType.PaperA4;
		}
		set
		{
			method_14(bool_14: true);
			int_4 = (int)value;
		}
	}

	/// <summary>
	///       Represents page print orientation.
	///       </summary>
	public PageOrientationType Orientation
	{
		get
		{
			return pageOrientationType_0;
		}
		set
		{
			method_14(bool_14: true);
			pageOrientationType_0 = value;
			bool_7 = false;
		}
	}

	/// <summary>
	///       Represents the way comments are printed with the sheet.
	///       </summary>
	public PrintCommentsType PrintComments
	{
		get
		{
			return printCommentsType_0;
		}
		set
		{
			printCommentsType_0 = value;
		}
	}

	/// <summary>
	///       Specifies the type of print error displayed.
	///       </summary>
	public PrintErrorsType PrintErrors
	{
		get
		{
			return printErrorsType_0;
		}
		set
		{
			printErrorsType_0 = value;
		}
	}

	/// <summary>
	///       Represents if row and column headings are printed with this page.
	///       </summary>
	public bool PrintHeadings
	{
		get
		{
			return bool_8;
		}
		set
		{
			bool_8 = value;
		}
	}

	/// <summary>
	///       Represents if cell gridlines are printed on the page.
	///       </summary>
	public bool PrintGridlines
	{
		get
		{
			return bool_9;
		}
		set
		{
			bool_9 = value;
		}
	}

	/// <summary>
	///       Represents the scaling factor in percent. It should be between 10 and 400.
	///       </summary>
	public int Zoom
	{
		get
		{
			return int_3;
		}
		set
		{
			if (value < 10 || value > 400)
			{
				throw new ArgumentException("Zoom value should be between 10 and 400.");
			}
			method_14(bool_14: true);
			int_3 = value;
			bool_6 = true;
		}
	}

	public bool IsAutoFirstPageNumber
	{
		get
		{
			return bool_10;
		}
		set
		{
			bool_10 = value;
		}
	}

	/// <summary>
	///       Represents the print quality.
	///       </summary>
	public int PrintQuality
	{
		get
		{
			return int_5;
		}
		set
		{
			if (value > 0)
			{
				int_5 = value;
				int_6 = value;
				bool_12 = false;
			}
		}
	}

	/// <summary>
	///       Get and sets number of copies to print.
	///       </summary>
	public int PrintCopies
	{
		get
		{
			return int_7;
		}
		set
		{
			int_7 = value;
		}
	}

	/// <summary>
	///       True means that the header/footer of the odd pages is different with odd pages.
	///       </summary>
	public bool IsHFDiffOddEven
	{
		get
		{
			return (byte_1 & 1) != 0;
		}
		set
		{
			if (value)
			{
				byte_1 |= 1;
			}
			else
			{
				byte_1 &= 254;
			}
		}
	}

	/// <summary>
	///       True means that the header/footer of the first page is different with other pages.
	///       </summary>
	public bool IsHFDiffFirst
	{
		get
		{
			return (byte_1 & 2) != 0;
		}
		set
		{
			if (value)
			{
				byte_1 |= 2;
			}
			else
			{
				byte_1 &= 253;
			}
		}
	}

	/// <summary>
	///       Indicates whether header and footer are scaled with document scaling.
	///       Only applies for Excel 2007.
	///       </summary>
	public bool IsHFScaleWithDoc
	{
		get
		{
			return (byte_1 & 4) != 0;
		}
		set
		{
			if (value)
			{
				byte_1 |= 4;
			}
			else
			{
				byte_1 &= 251;
			}
		}
	}

	/// <summary>
	///       Indicates whether header and footer margins are aligned with the page margins.
	///       Only applies for Excel 2007.
	///       </summary>
	public bool IsHFAlignMargins
	{
		get
		{
			return (byte_1 & 8) != 0;
		}
		set
		{
			if (value)
			{
				byte_1 |= 8;
			}
			else
			{
				byte_1 &= 247;
			}
		}
	}

	/// <summary>
	///       Represents the range to be printed.
	///       </summary>
	public string PrintArea
	{
		get
		{
			return string_8;
		}
		set
		{
			string_8 = value;
			bool_13 = true;
		}
	}

	internal ShapeCollection Shapes
	{
		get
		{
			if (shapeCollection_0 == null)
			{
				shapeCollection_0 = new ShapeCollection(worksheet_0.method_2(), worksheet_0, worksheet_0.method_2().method_87(), this, -1);
			}
			return shapeCollection_0;
		}
	}

	[SpecialName]
	private static Regex smethod_0()
	{
		if (regex_0 == null)
		{
			regex_0 = new Regex("(?<!&)(&[lLcCrR])");
		}
		return regex_0;
	}

	[SpecialName]
	internal bool method_0()
	{
		return bool_1;
	}

	[SpecialName]
	internal void method_1(bool bool_14)
	{
		bool_1 = bool_14;
	}

	internal void Copy(PageSetup pageSetup_0, CopyOptions copyOptions_0)
	{
		string_0 = pageSetup_0.string_0;
		string_1 = pageSetup_0.string_1;
		bool_0 = pageSetup_0.bool_0;
		bool_2 = pageSetup_0.bool_2;
		double_5 = pageSetup_0.double_5;
		bool_3 = pageSetup_0.bool_3;
		bool_4 = pageSetup_0.bool_4;
		bool_5 = pageSetup_0.bool_5;
		int_0 = pageSetup_0.int_0;
		int_1 = pageSetup_0.int_1;
		int_2 = pageSetup_0.int_2;
		bool_6 = pageSetup_0.bool_6;
		double_1 = pageSetup_0.double_1;
		double_0 = pageSetup_0.double_0;
		bool_10 = pageSetup_0.bool_10;
		double_2 = pageSetup_0.double_2;
		printOrderType_0 = pageSetup_0.printOrderType_0;
		pageOrientationType_0 = pageSetup_0.pageOrientationType_0;
		bool_7 = pageSetup_0.bool_7;
		int_4 = pageSetup_0.int_4;
		if (pageSetup_0.byte_0 != null && pageSetup_0.byte_0.Length > 0)
		{
			byte_0 = new byte[pageSetup_0.byte_0.Length];
			Array.Copy(pageSetup_0.byte_0, byte_0, pageSetup_0.byte_0.Length);
		}
		printCommentsType_0 = pageSetup_0.printCommentsType_0;
		printErrorsType_0 = pageSetup_0.printErrorsType_0;
		bool_9 = pageSetup_0.bool_9;
		bool_8 = pageSetup_0.bool_8;
		double_3 = pageSetup_0.double_3;
		double_4 = pageSetup_0.double_4;
		int_3 = pageSetup_0.int_3;
		byte_1 = pageSetup_0.byte_1;
		if (pageSetup_0.string_2 != null)
		{
			string_2 = new string[3];
			for (int i = 0; i < 3; i++)
			{
				string_2[i] = pageSetup_0.string_2[i];
			}
		}
		if (pageSetup_0.string_3 != null)
		{
			string_3 = new string[3];
			for (int j = 0; j < 3; j++)
			{
				string_3[j] = pageSetup_0.string_3[j];
			}
		}
		bool_13 = pageSetup_0.bool_13;
		string_8 = pageSetup_0.string_8;
		shapeCollection_0 = null;
		if (pageSetup_0.shapeCollection_0 != null && pageSetup_0.shapeCollection_0.Count != 0)
		{
			foreach (Shape item in pageSetup_0.shapeCollection_0)
			{
				Picture picture_ = (Picture)item;
				Picture picture = new Picture(Shapes);
				picture.Copy(picture_, copyOptions_0);
				Shapes.Add(picture);
			}
		}
		int_5 = pageSetup_0.int_5;
		int_6 = pageSetup_0.int_6;
		bool_12 = pageSetup_0.bool_12;
	}

	internal PageSetup(Worksheet worksheet_1)
	{
		string_2 = new string[3];
		string_3 = new string[3];
		worksheet_0 = worksheet_1;
		int_4 = 9;
	}

	internal void InsertColumns(int int_8, int int_9)
	{
		if (string_0 != null)
		{
			ArrayList arrayList = Class1678.smethod_10(string_0);
			for (int i = 0; i < arrayList.Count; i++)
			{
				CellArea cellArea_ = (CellArea)arrayList[i];
				bool flag = false;
				cellArea_ = Class1678.InsertColumns(cellArea_, int_8, int_9, ref flag);
				if (flag)
				{
					arrayList.RemoveAt(i--);
				}
				else
				{
					arrayList[i] = cellArea_;
				}
			}
			if (arrayList.Count == 0)
			{
				string_0 = null;
			}
			else
			{
				string_0 = Class1678.smethod_9(arrayList, bool_0: true);
				bool_0 = true;
			}
		}
		if (string_8 == null)
		{
			return;
		}
		ArrayList arrayList2 = Class1678.smethod_6(string_8);
		for (int j = 0; j < arrayList2.Count; j++)
		{
			CellArea cellArea_2 = (CellArea)arrayList2[j];
			if (cellArea_2.StartColumn != -1 && cellArea_2.EndColumn != -1)
			{
				bool flag2 = false;
				cellArea_2 = Class1678.InsertColumns(cellArea_2, int_8, int_9, ref flag2);
				if (flag2)
				{
					arrayList2.RemoveAt(j--);
				}
				else
				{
					arrayList2[j] = cellArea_2;
				}
			}
		}
		if (arrayList2.Count == 0)
		{
			string_8 = null;
			bool_13 = false;
		}
		else
		{
			string_8 = Class1678.smethod_7(arrayList2, bool_0: true);
			bool_13 = true;
		}
	}

	internal void InsertRows(int int_8, int int_9)
	{
		if (string_1 != null)
		{
			ArrayList arrayList = Class1678.smethod_12(string_1);
			for (int i = 0; i < arrayList.Count; i++)
			{
				CellArea cellArea_ = (CellArea)arrayList[i];
				if (cellArea_.StartRow != -1)
				{
					bool flag = false;
					cellArea_ = Class1678.InsertRows(cellArea_, int_8, int_9, ref flag);
					if (flag)
					{
						arrayList.RemoveAt(i--);
					}
					else
					{
						arrayList[i] = cellArea_;
					}
				}
			}
			if (arrayList.Count == 0)
			{
				string_1 = null;
			}
			else
			{
				string_1 = Class1678.smethod_11(arrayList, bool_0: true);
				bool_0 = true;
			}
		}
		if (string_8 == null)
		{
			return;
		}
		ArrayList arrayList2 = Class1678.smethod_6(string_8);
		for (int j = 0; j < arrayList2.Count; j++)
		{
			CellArea cellArea_2 = (CellArea)arrayList2[j];
			if (cellArea_2.StartRow != -1)
			{
				bool flag2 = false;
				cellArea_2 = Class1678.InsertRows(cellArea_2, int_8, int_9, ref flag2);
				if (flag2)
				{
					arrayList2.RemoveAt(j--);
				}
				else
				{
					arrayList2[j] = cellArea_2;
				}
			}
		}
		if (arrayList2.Count == 0)
		{
			string_8 = null;
			bool_13 = false;
		}
		else
		{
			string_8 = Class1678.smethod_7(arrayList2, bool_0: true);
			bool_13 = true;
		}
	}

	[SpecialName]
	internal bool method_2()
	{
		return bool_0;
	}

	[SpecialName]
	internal void method_3(bool bool_14)
	{
		bool_0 = bool_14;
	}

	[SpecialName]
	internal byte[] method_4()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_5(byte[] byte_2)
	{
		byte_0 = byte_2;
	}

	internal void method_6(int int_8)
	{
		int_1 = int_8;
	}

	internal void method_7(int int_8)
	{
		int_2 = int_8;
	}

	internal void method_8()
	{
		pageOrientationType_0 = PageOrientationType.Landscape;
		bool_7 = false;
	}

	[SpecialName]
	internal int method_9()
	{
		return int_4;
	}

	internal void method_10(int int_8)
	{
		int_3 = int_8;
	}

	internal void method_11(byte[] byte_2)
	{
		if (byte_2.Length < 34)
		{
			return;
		}
		int_4 = BitConverter.ToUInt16(byte_2, 0);
		int_0 = BitConverter.ToInt16(byte_2, 4);
		int_2 = BitConverter.ToUInt16(byte_2, 6);
		int_1 = BitConverter.ToUInt16(byte_2, 8);
		if ((byte_2[10] & 1) == 0)
		{
			printOrderType_0 = PrintOrderType.DownThenOver;
		}
		else
		{
			printOrderType_0 = PrintOrderType.OverThenDown;
		}
		if ((byte_2[10] & 2) == 0)
		{
			pageOrientationType_0 = PageOrientationType.Landscape;
		}
		else
		{
			pageOrientationType_0 = PageOrientationType.Portrait;
		}
		if ((byte_2[10] & 4u) != 0)
		{
			bool_11 = false;
			if (worksheet_0 != null && worksheet_0.Type != SheetType.Chart)
			{
				pageOrientationType_0 = PageOrientationType.Portrait;
			}
		}
		else
		{
			bool_11 = true;
			ushort num = BitConverter.ToUInt16(byte_2, 2);
			if (num >= 10 && num <= 400)
			{
				int_3 = num;
			}
		}
		if ((byte_2[10] & 8) == 0)
		{
			bool_2 = false;
		}
		else
		{
			bool_2 = true;
		}
		if ((byte_2[10] & 0x10) == 0)
		{
			bool_5 = false;
		}
		else
		{
			bool_5 = true;
		}
		if ((byte_2[10] & 0x80) == 0)
		{
			bool_10 = true;
		}
		else
		{
			bool_10 = false;
		}
		bool_7 = (byte_2[10] & 0x40) != 0;
		if (bool_7)
		{
			pageOrientationType_0 = PageOrientationType.Portrait;
		}
		int num2 = byte_2[10] & 0x20;
		int num3 = byte_2[11] & 2;
		if (num2 == 0)
		{
			printCommentsType_0 = PrintCommentsType.PrintNoComments;
		}
		else if (num3 == 0)
		{
			printCommentsType_0 = PrintCommentsType.PrintInPlace;
		}
		else
		{
			printCommentsType_0 = PrintCommentsType.PrintSheetEnd;
		}
		switch ((byte_2[11] & 0xC) >> 2)
		{
		case 0:
			printErrorsType_0 = PrintErrorsType.PrintErrorsDisplayed;
			break;
		case 1:
			printErrorsType_0 = PrintErrorsType.PrintErrorsBlank;
			break;
		case 2:
			printErrorsType_0 = PrintErrorsType.PrintErrorsDash;
			break;
		case 3:
			printErrorsType_0 = PrintErrorsType.PrintErrorsNA;
			break;
		}
		int num4 = BitConverter.ToInt16(byte_2, 12);
		if (num4 > 0)
		{
			bool_12 = !bool_11;
			int_5 = num4;
		}
		num4 = BitConverter.ToInt16(byte_2, 14);
		if (num4 > 0)
		{
			bool_12 = !bool_11;
			int_6 = num4;
		}
		double_1 = BitConverter.ToDouble(byte_2, 16);
		double_0 = BitConverter.ToDouble(byte_2, 24);
		int_7 = BitConverter.ToUInt16(byte_2, 32);
	}

	internal byte[] method_12()
	{
		byte[] array = new byte[34];
		ushort value = (ushort)int_4;
		Array.Copy(BitConverter.GetBytes(value), 0, array, 0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)int_3), 0, array, 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, array, 4, 2);
		Array.Copy(BitConverter.GetBytes((ushort)int_2), 0, array, 6, 2);
		Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, array, 8, 2);
		if (printOrderType_0 == PrintOrderType.OverThenDown)
		{
			array[10] |= 1;
		}
		if (pageOrientationType_0 == PageOrientationType.Portrait)
		{
			array[10] |= 2;
		}
		if (!method_13())
		{
			array[10] |= 4;
		}
		if (bool_2)
		{
			array[10] |= 8;
		}
		if (bool_5)
		{
			array[10] |= 16;
		}
		if (printCommentsType_0 != PrintCommentsType.PrintNoComments)
		{
			array[10] |= 32;
		}
		if (bool_7)
		{
			array[10] |= 64;
		}
		if (!bool_10 || int_0 != 1)
		{
			array[10] |= 128;
		}
		if (printCommentsType_0 == PrintCommentsType.PrintSheetEnd)
		{
			array[11] |= 2;
		}
		switch (printErrorsType_0)
		{
		case PrintErrorsType.PrintErrorsBlank:
			array[11] |= 4;
			break;
		case PrintErrorsType.PrintErrorsDash:
			array[11] |= 8;
			break;
		case PrintErrorsType.PrintErrorsNA:
			array[11] |= 12;
			break;
		}
		Array.Copy(BitConverter.GetBytes((ushort)int_5), 0, array, 12, 2);
		Array.Copy(BitConverter.GetBytes((ushort)int_6), 0, array, 14, 2);
		Array.Copy(BitConverter.GetBytes(double_1), 0, array, 16, 8);
		Array.Copy(BitConverter.GetBytes(double_0), 0, array, 24, 8);
		Array.Copy(BitConverter.GetBytes((ushort)int_7), 0, array, 32, 2);
		return array;
	}

	[SpecialName]
	internal bool method_13()
	{
		return bool_11;
	}

	[SpecialName]
	internal void method_14(bool bool_14)
	{
		if (bool_11 != bool_14 && !bool_11)
		{
			int_4 = 9;
			int_7 = 1;
			int_6 = 300;
			int_5 = 300;
		}
		bool_11 = bool_14;
	}

	[SpecialName]
	internal int method_15()
	{
		return int_5;
	}

	[SpecialName]
	internal void method_16(int int_8)
	{
		int_5 = int_8;
	}

	[SpecialName]
	internal int method_17()
	{
		return int_6;
	}

	[SpecialName]
	internal void method_18(int int_8)
	{
		int_6 = int_8;
	}

	/// <summary>
	///       Clears header and footer setting.
	///       </summary>
	public void ClearHeaderFooter()
	{
		string_2 = new string[3];
		string_3 = new string[3];
	}

	/// <summary>
	///        Gets a script formatting the header of an Excel file.
	///       </summary>
	/// <param name="section">
	///   <p>0:Left Section.</p>
	///   <p>1:Center Section</p>
	///   <p>2:Right Section</p>
	/// </param>
	public string GetHeader(int section)
	{
		if (section >= 0 && section <= 2)
		{
			if (string_2 == null)
			{
				return null;
			}
			return string_2[section];
		}
		throw new ArgumentException("The section number is out of range.");
	}

	public HeaderFooterCommand[] GetCommands(string headerFooterScript)
	{
		if (headerFooterScript != null && headerFooterScript.Length != 0)
		{
			int num = 0;
			while (num + 2 < headerFooterScript.Length)
			{
				if (headerFooterScript[num] == '&')
				{
					bool flag = false;
					switch (headerFooterScript[num + 1])
					{
					case 'C':
					case 'L':
					case 'R':
					case 'c':
					case 'l':
					case 'r':
						flag = true;
						num += 2;
						break;
					}
					if (!flag)
					{
						break;
					}
				}
			}
			if (num != 0)
			{
				headerFooterScript = headerFooterScript.Substring(num);
			}
			if (headerFooterScript.Length == 0)
			{
				return null;
			}
			ArrayList arrayList = HeaderFooterCommand.smethod_0(worksheet_0.method_2().Workbook, headerFooterScript);
			HeaderFooterCommand[] array = new HeaderFooterCommand[arrayList.Count];
			Font font = new Font(worksheet_0.method_2(), null, bool_0: false);
			font.Copy(worksheet_0.method_2().DefaultFont);
			for (int i = 0; i < arrayList.Count; i++)
			{
				array[i] = (HeaderFooterCommand)arrayList[i];
				if (array[i].Font == null && array[i].Type != HeaderFooterCommandType.Picture)
				{
					array[i].font_0 = font;
				}
			}
			return array;
		}
		return null;
	}

	internal string method_19(int int_8)
	{
		if (int_8 >= 0 && int_8 <= 2)
		{
			if (string_2 == null)
			{
				return null;
			}
			string text = string_2[int_8];
			if (text != null)
			{
				text = smethod_0().Replace(text, "");
			}
			return text;
		}
		throw new ArgumentException("The section number is out of range.");
	}

	/// <summary>
	///        Gets a script formatting the footer of an Excel file.
	///       </summary>
	/// <param name="section">
	///   <p>0:Left Section.</p>
	///   <p>1:Center Section</p>
	///   <p>2:Right Section</p>
	/// </param>
	public string GetFooter(int section)
	{
		if (section >= 0 && section <= 2)
		{
			if (string_3 == null)
			{
				return null;
			}
			return string_3[section];
		}
		throw new ArgumentException("The section number is out of range.");
	}

	internal string method_20(int int_8)
	{
		if (int_8 >= 0 && int_8 <= 2)
		{
			if (string_3 == null)
			{
				return null;
			}
			string text = string_3[int_8];
			if (text != null)
			{
				text = smethod_0().Replace(text, "");
			}
			return text;
		}
		throw new ArgumentException("The section number is out of range.");
	}

	/// <summary>
	///        Sets a script formatting the header of an Excel file.
	///        </summary>
	/// <param name="section">
	///   <p>0:Left Section.</p>
	///   <p>1:Center Section</p>
	///   <p>2:Right Section</p>
	/// </param>
	/// <param name="headerScript">Header format script.</param>
	/// <remarks>
	///   <p>Script commands:</p>
	///   <table class="dtTABLE" cellspacing="0">
	///     <tr>
	///       <td width="25%">
	///         <font color="gray">
	///           <b>Command</b>
	///         </font>　</td>
	///       <td width="75%">
	///         <font color="gray">
	///           <b>Description</b>
	///         </font>　</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;P</td>
	///       <td width="75%">Current page number　</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;N</td>
	///       <td width="75%">Page count　</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;D</td>
	///       <td width="75%">Current date　</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;T</td>
	///       <td width="75%">Current time</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;A</td>
	///       <td width="75%">Sheet name</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;F</td>
	///       <td width="75%">File name without path</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;"&lt;FontName&gt;"</td>
	///       <td width="75%">Font name, for exampe: &amp;"Arial"</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;"&lt;FontName&gt;, &lt;FontStyle&gt;"</td>
	///       <td width="75%">Font name and font style, for exampe: &amp;"Arial,Bold"</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;&lt;FontSize&gt;</td>
	///       <td width="75%">Font size.If this command is followed by a plain number to be printed in the header, it will be separated from the font height with a space character.</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;"&lt;K"</td>
	///       <td width="75%">Font color, for exampe(RED): &amp;FF0000</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;G</td>
	///       <td width="75%">Image script</td>
	///     </tr>
	///   </table>
	///       For example: "&amp;Arial,Bold&amp;8Header Note"
	///        </remarks>
	public void SetHeader(int section, string headerScript)
	{
		if (section >= 0 && section <= 2)
		{
			if (headerScript != null && !(headerScript == ""))
			{
				switch (section)
				{
				case 0:
					if (headerScript.IndexOf("&L") == 0)
					{
						string_2[0] = headerScript;
					}
					else
					{
						string_2[0] = "&L" + headerScript;
					}
					break;
				case 1:
					if (headerScript.IndexOf("&C") == 0)
					{
						string_2[1] = headerScript;
					}
					else
					{
						string_2[1] = "&C" + headerScript;
					}
					break;
				case 2:
					if (headerScript.IndexOf("&R") == 0)
					{
						string_2[2] = headerScript;
					}
					else
					{
						string_2[2] = "&R" + headerScript;
					}
					break;
				}
			}
			else
			{
				string_2[section] = null;
			}
			return;
		}
		throw new ArgumentException("The section number is out of range.");
	}

	/// <summary>
	///        Sets a script formatting the footer of an Excel file.
	///        </summary>
	/// <param name="section">
	///   <p>0:Left Section.</p>
	///   <p>1:Center Section</p>
	///   <p>2:Right Section</p>
	/// </param>
	/// <param name="footerScript">Footer format script.</param>
	/// <remarks>
	///   <p>Script commands:</p>
	///   <table class="dtTABLE" cellspacing="0">
	///     <tr>
	///       <td width="25%">
	///         <font color="gray">
	///           <b>Command</b>
	///         </font>　</td>
	///       <td width="75%">
	///         <font color="gray">
	///           <b>Description</b>
	///         </font>　</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;P</td>
	///       <td width="75%">Current page number　</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;N</td>
	///       <td width="75%">Page count　</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;D</td>
	///       <td width="75%">Current date　</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;T</td>
	///       <td width="75%">Current time</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;A</td>
	///       <td width="75%">Sheet name</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;F</td>
	///       <td width="75%">File name without path</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;"&lt;FontName&gt;"</td>
	///       <td width="75%">Font name, for exampe: &amp;"Arial"</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;"&lt;FontName&gt;, &lt;FontStyle&gt;"</td>
	///       <td width="75%">Font name and font style, for exampe: &amp;"Arial,Bold"</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;&lt;FontSize&gt;</td>
	///       <td width="75%">Font size.If this command is followed by a plain number to be printed in the header, it will be separated from the font height with a space character.</td>
	///     </tr>
	///     <tr>
	///       <td width="25%">&amp;G</td>
	///       <td width="75%">Image script</td>
	///     </tr>
	///   </table>
	///       For example: "&amp;Arial,Bold&amp;8Footer Note"
	///        </remarks>
	public void SetFooter(int section, string footerScript)
	{
		if (section >= 0 && section <= 2)
		{
			if (footerScript != null && !(footerScript == ""))
			{
				switch (section)
				{
				case 0:
					if (footerScript.IndexOf("&L") == 0)
					{
						string_3[0] = footerScript;
					}
					else
					{
						string_3[0] = "&L" + footerScript;
					}
					break;
				case 1:
					if (footerScript.IndexOf("&C") == 0)
					{
						string_3[1] = footerScript;
					}
					else
					{
						string_3[1] = "&C" + footerScript;
					}
					break;
				case 2:
					if (footerScript.IndexOf("&R") == 0)
					{
						string_3[2] = footerScript;
					}
					else
					{
						string_3[2] = "&R" + footerScript;
					}
					break;
				}
			}
			else
			{
				string_3[section] = null;
			}
			return;
		}
		throw new ArgumentException("The section number is out of range.");
	}

	[SpecialName]
	internal byte method_21()
	{
		return byte_1;
	}

	[SpecialName]
	internal void method_22(byte byte_2)
	{
		byte_1 = byte_2;
	}

	/// <summary>
	///        Sets a script formatting the even page header of an Excel file.
	///       Only effect in Excel 2007 when IsHFDiffOddEven is true.
	///       </summary>
	/// <param name="section">
	///   <p>0:Left Section.</p>
	///   <p>1:Center Section</p>
	///   <p>2:Right Section</p>
	/// </param>
	/// <param name="headerScript">Header format script.</param>
	public void SetEvenHeader(int section, string headerScript)
	{
		if (section >= 0 && section <= 2)
		{
			if (headerScript != null && !(headerScript == ""))
			{
				if (string_4 == null)
				{
					string_4 = new string[3];
				}
				switch (section)
				{
				case 0:
					if (headerScript.IndexOf("&L") == 0)
					{
						string_4[0] = headerScript;
					}
					else
					{
						string_4[0] = "&L" + headerScript;
					}
					break;
				case 1:
					if (headerScript.IndexOf("&C") == 0)
					{
						string_4[1] = headerScript;
					}
					else
					{
						string_4[1] = "&C" + headerScript;
					}
					break;
				case 2:
					if (headerScript.IndexOf("&R") == 0)
					{
						string_4[2] = headerScript;
					}
					else
					{
						string_4[2] = "&R" + headerScript;
					}
					break;
				}
			}
			else
			{
				string_2[section] = null;
			}
			return;
		}
		throw new ArgumentException("The section number is out of range.");
	}

	internal string method_23(int int_8)
	{
		if (int_8 >= 0 && int_8 <= 2)
		{
			if (string_4 == null)
			{
				return null;
			}
			string text = string_4[int_8];
			if (text != null)
			{
				text = smethod_0().Replace(text, "");
			}
			return text;
		}
		throw new ArgumentException("The section number is out of range.");
	}

	/// <summary>
	///        Gets a script formatting the even header of an Excel file.
	///       </summary>
	/// <param name="section">
	///   <p>0:Left Section.</p>
	///   <p>1:Center Section</p>
	///   <p>2:Right Section</p>
	/// </param>
	public string GetEvenHeader(int section)
	{
		if (section >= 0 && section <= 2)
		{
			if (string_4 == null)
			{
				return null;
			}
			return string_4[section];
		}
		throw new ArgumentException("The section number is out of range.");
	}

	internal string method_24(int int_8)
	{
		if (int_8 >= 0 && int_8 <= 2)
		{
			if (string_5 == null)
			{
				return null;
			}
			string text = string_5[int_8];
			if (text != null)
			{
				text = smethod_0().Replace(text, "");
			}
			return text;
		}
		throw new ArgumentException("The section number is out of range.");
	}

	/// <summary>
	///        Sets a script formatting the even page footer of an Excel file.
	///       Only effect in Excel 2007 when IsHFDiffOddEven is true.
	///       </summary>
	/// <param name="section">
	///   <p>0:Left Section.</p>
	///   <p>1:Center Section</p>
	///   <p>2:Right Section</p>
	/// </param>
	/// <param name="footerScript">Footer format script.</param>
	public void SetEvenFooter(int section, string footerScript)
	{
		if (section >= 0 && section <= 2)
		{
			if (string_5 == null)
			{
				string_5 = new string[3];
			}
			if (footerScript != null && !(footerScript == ""))
			{
				switch (section)
				{
				case 0:
					if (footerScript.IndexOf("&L") == 0)
					{
						string_5[0] = footerScript;
					}
					else
					{
						string_5[0] = "&L" + footerScript;
					}
					break;
				case 1:
					if (footerScript.IndexOf("&C") == 0)
					{
						string_5[1] = footerScript;
					}
					else
					{
						string_5[1] = "&C" + footerScript;
					}
					break;
				case 2:
					if (footerScript.IndexOf("&R") == 0)
					{
						string_5[2] = footerScript;
					}
					else
					{
						string_5[2] = "&R" + footerScript;
					}
					break;
				}
			}
			else
			{
				string_5[section] = null;
			}
			return;
		}
		throw new ArgumentException("The section number is out of range.");
	}

	/// <summary>
	///        Gets a script formatting the even footer of an Excel file.
	///       </summary>
	/// <param name="section">
	///   <p>0:Left Section.</p>
	///   <p>1:Center Section</p>
	///   <p>2:Right Section</p>
	/// </param>
	public string GetEvenFooter(int section)
	{
		if (section >= 0 && section <= 2)
		{
			if (string_5 == null)
			{
				return null;
			}
			return string_5[section];
		}
		throw new ArgumentException("The section number is out of range.");
	}

	/// <summary>
	///        Sets a script formatting the first page header of an Excel file.
	///       Only effect in Excel 2007 when IsHFDiffFirst is true.
	///       </summary>
	/// <param name="section">
	///   <p>0:Left Section.</p>
	///   <p>1:Center Section</p>
	///   <p>2:Right Section</p>
	/// </param>
	/// <param name="headerScript">Header format script.</param>
	public void SetFirstPageHeader(int section, string headerScript)
	{
		if (section >= 0 && section <= 2)
		{
			if (headerScript != null && !(headerScript == ""))
			{
				if (string_7 == null)
				{
					string_7 = new string[3];
				}
				switch (section)
				{
				case 0:
					if (headerScript.IndexOf("&L") == 0)
					{
						string_7[0] = headerScript;
					}
					else
					{
						string_7[0] = "&L" + headerScript;
					}
					break;
				case 1:
					if (headerScript.IndexOf("&C") == 0)
					{
						string_7[1] = headerScript;
					}
					else
					{
						string_7[1] = "&C" + headerScript;
					}
					break;
				case 2:
					if (headerScript.IndexOf("&R") == 0)
					{
						string_7[2] = headerScript;
					}
					else
					{
						string_7[2] = "&R" + headerScript;
					}
					break;
				}
			}
			else
			{
				string_2[section] = null;
			}
			return;
		}
		throw new ArgumentException("The section number is out of range.");
	}

	/// <summary>
	///        Gets a script formatting the first page header of an Excel file.
	///       </summary>
	/// <param name="section">
	///   <p>0:Left Section.</p>
	///   <p>1:Center Section</p>
	///   <p>2:Right Section</p>
	/// </param>
	public string GetFirstPageHeader(int section)
	{
		if (section >= 0 && section <= 2)
		{
			if (string_7 == null)
			{
				return null;
			}
			return string_7[section];
		}
		throw new ArgumentException("The section number is out of range.");
	}

	/// <summary>
	///        Sets a script formatting the first page footer of an Excel file.
	///       </summary>
	/// <param name="section">
	///   <p>0:Left Section.</p>
	///   <p>1:Center Section</p>
	///   <p>2:Right Section</p>
	/// </param>
	/// <param name="footerScript">Footer format script.</param>
	public void SetFirstPageFooter(int section, string footerScript)
	{
		if (section >= 0 && section <= 2)
		{
			if (string_6 == null)
			{
				string_6 = new string[3];
			}
			if (footerScript != null && !(footerScript == ""))
			{
				switch (section)
				{
				case 0:
					if (footerScript.IndexOf("&L") == 0)
					{
						string_6[0] = footerScript;
					}
					else
					{
						string_6[0] = "&L" + footerScript;
					}
					break;
				case 1:
					if (footerScript.IndexOf("&C") == 0)
					{
						string_6[1] = footerScript;
					}
					else
					{
						string_6[1] = "&C" + footerScript;
					}
					break;
				case 2:
					if (footerScript.IndexOf("&R") == 0)
					{
						string_6[2] = footerScript;
					}
					else
					{
						string_6[2] = "&R" + footerScript;
					}
					break;
				}
			}
			else
			{
				string_6[section] = null;
			}
			return;
		}
		throw new ArgumentException("The section number is out of range.");
	}

	internal string method_25(int int_8)
	{
		if (int_8 >= 0 && int_8 <= 2)
		{
			if (string_6 == null)
			{
				return null;
			}
			string text = string_6[int_8];
			if (text != null)
			{
				text = smethod_0().Replace(text, "");
			}
			return text;
		}
		throw new ArgumentException("The section number is out of range.");
	}

	internal string method_26(int int_8)
	{
		if (int_8 >= 0 && int_8 <= 2)
		{
			if (string_7 == null)
			{
				return null;
			}
			string text = string_7[int_8];
			if (text != null)
			{
				text = smethod_0().Replace(text, "");
			}
			return text;
		}
		throw new ArgumentException("The section number is out of range.");
	}

	/// <summary>
	///        Gets a script formatting the first page footer of an Excel file.
	///       </summary>
	/// <param name="section">
	///   <p>0:Left Section.</p>
	///   <p>1:Center Section</p>
	///   <p>2:Right Section</p>
	/// </param>
	public string GetFirstPageFooter(int section)
	{
		if (section >= 0 && section <= 2)
		{
			if (string_6 == null)
			{
				return null;
			}
			return string_6[section];
		}
		throw new ArgumentException("The section number is out of range.");
	}

	internal static void smethod_1(string string_9, string[] string_10)
	{
		int num = -1;
		int num2 = 0;
		for (int i = 0; i < string_9.Length; i++)
		{
			if (string_9[i] != '&' || i + 1 >= string_9.Length)
			{
				continue;
			}
			int num3 = 1;
			char c = string_9[i + 1];
			if (c <= 'L')
			{
				if (c != '&')
				{
					if (c == 'C')
					{
						goto IL_0068;
					}
					if (c != 'L')
					{
						continue;
					}
					goto IL_007e;
				}
				i++;
				continue;
			}
			if (c <= 'c')
			{
				if (c != 'R')
				{
					if (c != 'c')
					{
						continue;
					}
					goto IL_0068;
				}
			}
			else
			{
				if (c == 'l')
				{
					goto IL_007e;
				}
				if (c != 'r')
				{
					continue;
				}
			}
			num3 = 2;
			goto IL_0080;
			IL_0080:
			if (i - num2 > 0)
			{
				if (num2 == 0 && num == -1)
				{
					num = ((num3 - 1 >= 0) ? (num3 - 1) : 0);
				}
				string_10[num] = string_9.Substring(num2, i - num2);
			}
			num = num3;
			num2 = i;
			continue;
			IL_007e:
			num3 = 0;
			goto IL_0080;
			IL_0068:
			num3 = 1;
			goto IL_0080;
		}
		if (num2 < string_9.Length)
		{
			string_10[(num == -1) ? 1 : num] = string_9.Substring(num2);
		}
	}

	internal void method_27(byte[] byte_2)
	{
		if (byte_2.Length <= 2)
		{
			return;
		}
		string @string;
		if (byte_2[2] == 0)
		{
			byte[] array = new byte[(byte_2.Length - 3) * 2];
			for (int i = 0; i < array.Length / 2; i++)
			{
				array[2 * i] = byte_2[3 + i];
			}
			@string = Encoding.Unicode.GetString(array);
		}
		else
		{
			@string = Encoding.Unicode.GetString(byte_2, 3, byte_2.Length - 3);
		}
		if (string_2 == null)
		{
			string_2 = new string[3];
		}
		smethod_1(@string, string_2);
	}

	internal void method_28(byte[] byte_2)
	{
		if (byte_2.Length <= 2)
		{
			return;
		}
		if (string_3 == null)
		{
			string_3 = new string[3];
		}
		string @string;
		if (byte_2[2] == 0)
		{
			byte[] array = new byte[(byte_2.Length - 3) * 2];
			for (int i = 0; i < array.Length / 2; i++)
			{
				array[2 * i] = byte_2[3 + i];
			}
			@string = Encoding.Unicode.GetString(array);
		}
		else
		{
			@string = Encoding.Unicode.GetString(byte_2, 3, byte_2.Length - 3);
		}
		smethod_1(@string, string_3);
	}

	[SpecialName]
	internal bool method_29()
	{
		return bool_13;
	}

	[SpecialName]
	internal void method_30(bool bool_14)
	{
		bool_13 = bool_14;
	}

	internal void method_31(ShapeCollection shapeCollection_1)
	{
		shapeCollection_0 = shapeCollection_1;
	}

	internal ShapeCollection method_32()
	{
		return shapeCollection_0;
	}

	internal static char smethod_2(int int_8)
	{
		return int_8 switch
		{
			0 => 'L', 
			1 => 'C', 
			2 => 'R', 
			_ => throw new ArgumentException("The section number is out of range."), 
		};
	}

	/// <summary>
	///       Sets an image in the header of a worksheet.
	///       </summary>
	/// <param name="section">
	///   <p>0:Left Section.</p>
	///   <p>1:Center Section</p>
	///   <p>2:Right Section</p>
	/// </param>
	/// <param name="headerPicture">Image data.</param>
	/// <returns>Returns <see cref="T:Aspose.Cells.Drawing.Picture" /> object.</returns>
	public Picture SetHeaderPicture(int section, byte[] headerPicture)
	{
		string string_ = smethod_2(section) + "H";
		int num = method_34(string_);
		if (num != -1)
		{
			Shapes.method_15(num);
		}
		return AddPicture(string_, headerPicture);
	}

	/// <summary>
	///       Sets an image in the footer of a worksheet.
	///       </summary>
	/// <param name="section">
	///   <p>0:Left Section.</p>
	///   <p>1:Center Section</p>
	///   <p>2:Right Section</p>
	/// </param>
	/// <param name="footerPicture">Image data.</param>
	/// <returns>Returns <see cref="T:Aspose.Cells.Drawing.Picture" /> object.</returns>
	public Picture SetFooterPicture(int section, byte[] footerPicture)
	{
		string string_ = smethod_2(section) + "F";
		int num = method_34(string_);
		if (num != -1)
		{
			Shapes.method_15(num);
		}
		return AddPicture(string_, footerPicture);
	}

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.Drawing.Picture" /> object of the header / footer.
	///       </summary>
	/// <param name="isHeader">Indicates whether it is in the header or footer.</param>
	/// <param name="section">
	///   <p>0:Left Section.</p>
	///   <p>1:Center Section</p>
	///   <p>2:Right Section</p>
	/// </param>
	/// <returns>Returns <see cref="T:Aspose.Cells.Drawing.Picture" /> object.
	///       Returns null if there is no picture.</returns>
	public Picture GetPicture(bool isHeader, int section)
	{
		string text = "" + smethod_2(section);
		text = ((!isHeader) ? (text + "F") : (text + "H"));
		int num = method_34(text);
		if (num != -1)
		{
			return (Picture)Shapes[num];
		}
		return null;
	}

	internal Picture AddPicture(string string_9, byte[] byte_2)
	{
		Picture picture = new Picture(Shapes);
		MemoryStream memoryStream = new MemoryStream(byte_2);
		picture.method_71(Shapes.Add(picture, memoryStream));
		picture.method_29(null);
		memoryStream.Close();
		picture.method_27().method_2().method_1(50048, Enum183.const_2, string_9);
		picture.method_27().method_7().method_4(PlacementType.FreeFloating);
		picture.method_27().method_7().Left = 0;
		picture.method_27().method_7().Top = 0;
		picture.method_27().method_7().Right = picture.method_69().Width;
		picture.method_27().method_7().Bottom = picture.method_69().Height;
		return picture;
	}

	internal int method_33(bool bool_14, int int_8)
	{
		string text = "" + smethod_2(int_8);
		text = ((!bool_14) ? (text + "F") : (text + "H"));
		return method_34(text);
	}

	internal int method_34(string string_9)
	{
		if (shapeCollection_0 != null && shapeCollection_0.Count != 0)
		{
			int num = 0;
			foreach (Shape item in shapeCollection_0)
			{
				string stringValue = item.method_27().method_2().GetStringValue(50048);
				if (stringValue == null || stringValue == "")
				{
					stringValue = item.method_27().method_2().GetStringValue(33664);
				}
				if (!(stringValue == string_9))
				{
					num++;
					continue;
				}
				return num;
			}
			return -1;
		}
		return -1;
	}
}
