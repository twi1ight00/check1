using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using Aspose.Cells.Markup;
using Aspose.Cells.Pivot;
using Aspose.Cells.Properties;
using Aspose.Cells.Rendering;
using Aspose.Cells.Tables;
using ns12;
using ns16;
using ns17;
using ns2;
using ns22;
using ns27;

namespace Aspose.Cells;

/// <summary>
///        Encapsulates the object that represents a single worksheet.
///        </summary>
/// <example>
///   <code>
///        [C#]
///
///        Workbook workbook = new Workbook();
///
///        Worksheet sheet = workbook.Worksheets[0];
///
///        //Freeze panes at "AS40" with 10 rows and 10 columns
///        sheet.FreezePanes("AS40", 10, 10);
///
///        //Add a hyperlink in Cell A1
///        sheet.Hyperlinks.Add("A1", 1, 1, "http://www.aspose.com");
///
///        [Visual Basic]
///
///        Dim workbook as Workbook = new Workbook()
///
///        Dim sheet as Worksheet = workbook.Worksheets(0)
///
///        'Freeze panes at "AS40" with 10 rows and 10 columns
///        sheet.FreezePanes("AS40", 10, 10)
///
///        'Add a hyperlink in Cell A1
///        sheet.Hyperlinks.Add("A1", 1, 1, "http://www.aspose.com")
///       </code>
/// </example>
public class Worksheet
{
	private SheetType sheetType_0 = SheetType.Worksheet;

	private string string_0;

	private Cells cells_0;

	private PaneCollection paneCollection_0;

	private Protection protection_0;

	private WorksheetCollection worksheetCollection_0;

	private CommentCollection commentCollection_0;

	internal QueryTableCollection queryTableCollection_0;

	internal PivotTableCollection pivotTableCollection_0;

	internal int int_0 = 1;

	private ushort ushort_0 = 182;

	private PictureCollection pictureCollection_0;

	private ListObjectCollection listObjectCollection_0;

	private TextBoxCollection textBoxCollection_0;

	private CheckBoxCollection checkBoxCollection_0;

	private OleObjectCollection oleObjectCollection_0;

	private int int_1;

	private ChartCollection chartCollection_0;

	private ArrayList arrayList_0;

	private AutoFilter autoFilter_0;

	internal short short_0;

	private byte byte_0;

	private ArrayList arrayList_1;

	private Class705 class705_0;

	internal Class1557 class1557_0;

	private Class1733 class1733_0;

	private ShapeCollection shapeCollection_0;

	private ValidationCollection validationCollection_0;

	private ProtectedRangeCollection protectedRangeCollection_0;

	internal ErrorCheckOptionCollection errorCheckOptionCollection_0;

	private Outline outline_0;

	private int int_2;

	private int int_3;

	private ViewType viewType_0;

	private int[] int_4 = new int[3] { 100, 60, 100 };

	private bool bool_0 = true;

	internal InternalColor internalColor_0;

	private int int_5 = 64;

	private string string_1;

	private ArrayList arrayList_2;

	private byte[] byte_1;

	internal ConditionalFormattingCollection conditionalFormattingCollection_0;

	private ArrayList arrayList_3;

	private CustomPropertyCollection customPropertyCollection_0;

	private SparklineGroupCollection sparklineGroupCollection_0;

	private SmartTagSetting smartTagSetting_0;

	/// <summary>
	///       Represents the various types of protection options available for a worksheet. Supports advanced protection options in ExcelXP and above version.
	///       </summary>
	/// <remarks>This property can protect worksheet in all versions of Excel file and support advanced protection options in ExcelXP and above version.
	///       </remarks>
	public Protection Protection
	{
		get
		{
			if (protection_0 == null)
			{
				protection_0 = new Protection();
			}
			return protection_0;
		}
	}

	/// <summary>
	///       Gets the workbook object which contains this sheet.
	///       </summary>
	public Workbook Workbook => worksheetCollection_0.Workbook;

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.CommentCollection" /> collection.
	///       </summary>
	public CommentCollection Comments => commentCollection_0;

	/// <summary>
	///       Gets the <see cref="P:Aspose.Cells.Worksheet.Cells" /> collection.
	///       </summary>
	public Cells Cells => cells_0;

	public QueryTableCollection QueryTables
	{
		get
		{
			if (queryTableCollection_0 == null)
			{
				queryTableCollection_0 = new QueryTableCollection();
			}
			return queryTableCollection_0;
		}
	}

	/// <summary>
	///       Gets the pivotTables in the worksheet.
	///       </summary>
	public PivotTableCollection PivotTables
	{
		get
		{
			if (pivotTableCollection_0 == null)
			{
				pivotTableCollection_0 = new PivotTableCollection(this);
			}
			return pivotTableCollection_0;
		}
	}

	/// <summary>
	///       Represents worksheet type
	///       </summary>
	/// <value>Excel worksheet type</value>
	public SheetType Type
	{
		get
		{
			return sheetType_0;
		}
		set
		{
			sheetType_0 = value;
		}
	}

	/// <summary>
	///       Gets or sets the name of the worksheet.
	///       </summary>
	/// <remarks>The max length of sheet name is 31. And you cannot assign same name(case insensitive) to two worksheets. 
	///       For example, you cannot set "SheetName1" to the first worksheet and set "SHEETNAME1" to the second worksheet.</remarks>
	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			if (value == null || value == "")
			{
				return;
			}
			string text = method_6(value);
			foreach (Worksheet item in worksheetCollection_0)
			{
				foreach (Chart item2 in item.chartCollection_0)
				{
					string pivotSource = item2.PivotSource;
					if (pivotSource == null)
					{
						continue;
					}
					int num = pivotSource.IndexOf("!");
					if (num != -1)
					{
						string text2 = pivotSource.Substring(0, num);
						if (text2.ToUpper().Equals(string_0.ToUpper()))
						{
							string text3 = pivotSource.Substring(num);
							item2.PivotSource = text + text3;
						}
					}
				}
			}
			string_0 = text;
			worksheetCollection_0.method_7();
			worksheetCollection_0.method_94();
		}
	}

	/// <summary>
	///       Gets or sets a value indicating whether the gridelines are visible.Default is true.
	///       </summary>
	public bool IsGridlinesVisible
	{
		get
		{
			return (ushort_0 & 2) != 0;
		}
		set
		{
			if (value)
			{
				ushort_0 |= 2;
			}
			else
			{
				ushort_0 &= 65533;
			}
		}
	}

	/// <summary>
	///       Gets or sets a value indicating whether the worksheet will display row and column headers.Default is true.
	///       </summary>
	public bool IsRowColumnHeadersVisible
	{
		get
		{
			return (ushort_0 & 4) != 0;
		}
		set
		{
			if (value)
			{
				ushort_0 |= 4;
			}
			else
			{
				ushort_0 &= 65531;
			}
		}
	}

	/// <summary>
	///       True if zero values are displayed. 
	///       </summary>
	public bool DisplayZeros
	{
		get
		{
			return (ushort_0 & 0x10) != 0;
		}
		set
		{
			if (value)
			{
				ushort_0 |= 16;
			}
			else
			{
				ushort_0 &= 65519;
			}
		}
	}

	/// <summary>
	///       Indicates if the specified worksheet is displayed from right to left instead of from left to right.
	///       Default is false.
	///       </summary>
	public bool DisplayRightToLeft
	{
		get
		{
			return (ushort_0 & 0x40) != 0;
		}
		set
		{
			if (value)
			{
				ushort_0 |= 64;
			}
			else
			{
				ushort_0 &= 65471;
			}
		}
	}

	public bool IsOutlineShown
	{
		get
		{
			return (ushort_0 & 0x80) != 0;
		}
		set
		{
			if (value)
			{
				ushort_0 |= 128;
			}
			else
			{
				ushort_0 &= 65407;
			}
		}
	}

	/// <summary>
	///       Indicates whether this worksheet is selected when the workbook is opened.
	///       </summary>
	public bool IsSelected
	{
		get
		{
			return (ushort_0 & 0x200) != 0;
		}
		set
		{
			if (value)
			{
				ushort_0 |= 1536;
			}
			else
			{
				ushort_0 &= 65023;
			}
		}
	}

	/// <summary>
	///       Gets a <see cref="P:Aspose.Cells.Worksheet.Pictures" /> collection.
	///       </summary>
	public PictureCollection Pictures
	{
		get
		{
			if (pictureCollection_0 == null)
			{
				pictureCollection_0 = new PictureCollection(Shapes);
			}
			return pictureCollection_0;
		}
	}

	/// <summary>
	///       Gets all ListObjects in this worksheet.
	///       </summary>
	public ListObjectCollection ListObjects
	{
		get
		{
			if (listObjectCollection_0 == null)
			{
				listObjectCollection_0 = new ListObjectCollection(this);
			}
			return listObjectCollection_0;
		}
	}

	/// <summary>
	///       Gets a <see cref="P:Aspose.Cells.Worksheet.TextBoxes" /> collection.
	///       </summary>
	public TextBoxCollection TextBoxes
	{
		get
		{
			if (textBoxCollection_0 == null)
			{
				textBoxCollection_0 = new TextBoxCollection(Shapes);
			}
			return textBoxCollection_0;
		}
	}

	/// <summary>
	///       Gets a <see cref="P:Aspose.Cells.Worksheet.CheckBoxes" /> collection.
	///       </summary>
	public CheckBoxCollection CheckBoxes
	{
		get
		{
			if (checkBoxCollection_0 == null)
			{
				checkBoxCollection_0 = new CheckBoxCollection(Shapes);
			}
			return checkBoxCollection_0;
		}
	}

	/// <summary>
	///       Represents a collection of <see cref="T:Aspose.Cells.Drawing.OleObject" /> in a worksheet.
	///       </summary>
	public OleObjectCollection OleObjects
	{
		get
		{
			if (oleObjectCollection_0 == null)
			{
				oleObjectCollection_0 = new OleObjectCollection(Shapes);
			}
			return oleObjectCollection_0;
		}
	}

	/// <summary>
	///       Gets a <see cref="T:Aspose.Cells.Charts.ChartCollection" /> collection
	///       </summary>
	public ChartCollection Charts => chartCollection_0;

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.HorizontalPageBreakCollection" /> collection. 
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Worksheet.HorizontalPageBreaks property.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Worksheet.HorizontalPageBreaks property instead.")]
	public HorizontalPageBreakCollection HPageBreaks => cells_0.HPageBreaks;

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.HorizontalPageBreakCollection" /> collection. 
	///       </summary>
	public HorizontalPageBreakCollection HorizontalPageBreaks => cells_0.HPageBreaks;

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.VerticalPageBreakCollection" /> collection.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Worksheet.VerticalPageBreaks property.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Worksheet.VerticalPageBreaks property instead.")]
	public VerticalPageBreakCollection VPageBreaks => cells_0.VPageBreaks;

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.VerticalPageBreakCollection" /> collection.
	///       </summary>
	public VerticalPageBreakCollection VerticalPageBreaks => cells_0.VPageBreaks;

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.HyperlinkCollection" /> collection.
	///       </summary>
	public HyperlinkCollection Hyperlinks => cells_0.Hyperlinks;

	/// <summary>
	///       Represents the page setup description in this sheet.
	///       </summary>
	public PageSetup PageSetup
	{
		get
		{
			if (sheetType_0 == SheetType.Chart && chartCollection_0.Count > 0)
			{
				return chartCollection_0[0].PageSetup;
			}
			return cells_0.PageSetup;
		}
	}

	/// <summary>
	///       Represents autofiltering for the specified worksheet.
	///       </summary>
	public AutoFilter AutoFilter
	{
		get
		{
			if (autoFilter_0 == null)
			{
				autoFilter_0 = new AutoFilter(this, this);
			}
			return autoFilter_0;
		}
	}

	/// <summary>
	///       Indicates whether worksheet has auto filter.
	///       </summary>
	public bool HasAutofilter => method_24() != 0;

	public bool TransitionEvaluation
	{
		get
		{
			return (short_0 & 0x4000) != 0;
		}
		set
		{
			if (value)
			{
				short_0 |= 16384;
			}
			else
			{
				short_0 &= -16385;
			}
		}
	}

	public bool TransitionEntry
	{
		get
		{
			return (short_0 & 0x2000) != 0;
		}
		set
		{
			if (value)
			{
				short_0 |= 8192;
			}
			else
			{
				short_0 &= -8193;
			}
		}
	}

	/// <summary>
	///       Indicates the state for this sheet visibility
	///       </summary>
	public VisibilityType VisibilityType
	{
		get
		{
			return byte_0 switch
			{
				0 => VisibilityType.Visible, 
				1 => VisibilityType.Hidden, 
				2 => VisibilityType.VeryHidden, 
				_ => VisibilityType.Visible, 
			};
		}
		set
		{
			if (value == VisibilityType.Visible)
			{
				byte_0 = 0;
				worksheetCollection_0.ActiveSheetIndex = Index;
			}
			else if (byte_0 == 0)
			{
				int num = -1;
				for (int i = Index + 1; i < worksheetCollection_0.Count; i++)
				{
					if (worksheetCollection_0[i].IsVisible)
					{
						num = i;
						break;
					}
				}
				if (num == -1)
				{
					int num2 = Index - 1;
					while (num2 >= 0)
					{
						if (!worksheetCollection_0[num2].IsVisible)
						{
							num2--;
							continue;
						}
						num = num2;
						break;
					}
				}
				if (num == -1)
				{
					throw new CellsException(ExceptionType.Limitation, "A workbook must contain at least a visible worksheet");
				}
				byte_0 = (byte)value;
				IsSelected = false;
				worksheetCollection_0.method_33(num);
				if (worksheetCollection_0.FirstVisibleTab == Index)
				{
					worksheetCollection_0.FirstVisibleTab = num;
				}
			}
			else
			{
				byte_0 = (byte)value;
			}
		}
	}

	/// <summary>
	///       Represents if the worksheet is visible.
	///       </summary>
	public bool IsVisible
	{
		get
		{
			if (byte_0 == 0)
			{
				return true;
			}
			return false;
		}
		set
		{
			if (IsVisible == value)
			{
				return;
			}
			if (value)
			{
				byte_0 = 0;
				worksheetCollection_0.ActiveSheetIndex = Index;
				return;
			}
			int num = -1;
			for (int i = Index + 1; i < worksheetCollection_0.Count; i++)
			{
				if (worksheetCollection_0[i].IsVisible)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				int num2 = Index - 1;
				while (num2 >= 0)
				{
					if (!worksheetCollection_0[num2].IsVisible)
					{
						num2--;
						continue;
					}
					num = num2;
					break;
				}
			}
			if (num == -1)
			{
				throw new CellsException(ExceptionType.Limitation, "A workbook must contain at least a visible worksheet");
			}
			byte_0 = 1;
			IsSelected = false;
			if (worksheetCollection_0.ActiveSheetIndex == Index)
			{
				worksheetCollection_0.method_33(num);
			}
			if (worksheetCollection_0.FirstVisibleTab == Index)
			{
				worksheetCollection_0.FirstVisibleTab = num;
			}
		}
	}

	/// <summary>
	///       Returns all drawing shapes in this worksheet.
	///       </summary>
	public ShapeCollection Shapes
	{
		get
		{
			if (shapeCollection_0 == null)
			{
				shapeCollection_0 = new ShapeCollection(worksheetCollection_0, this, worksheetCollection_0.method_84(), this, -1);
			}
			return shapeCollection_0;
		}
	}

	/// <summary>
	///       Gets the index of sheet in the worksheets collection.
	///       </summary>
	public int Index => int_1;

	/// <summary>
	///       Indicates if the worksheet is protected.
	///       </summary>
	public bool IsProtected
	{
		get
		{
			if (protection_0 != null)
			{
				return !protection_0.AllowEditingContent;
			}
			return false;
		}
	}

	/// <summary>
	///       Gets the data validation setting collection in the worksheet.
	///       </summary>
	public ValidationCollection Validations => validationCollection_0;

	/// <summary>
	///       Gets the allow edit range collection in the worksheet.
	///       </summary>
	public ProtectedRangeCollection AllowEditRanges => protectedRangeCollection_0;

	/// <summary>
	///       Represents error check setting applied on certain ranges.
	///       </summary>
	public ErrorCheckOptionCollection ErrorCheckOptions
	{
		get
		{
			if (errorCheckOptionCollection_0 == null)
			{
				errorCheckOptionCollection_0 = new ErrorCheckOptionCollection(this);
			}
			return errorCheckOptionCollection_0;
		}
	}

	/// <summary>
	///       Represents an outline on a worksheet.
	///       </summary>
	public Outline Outline => outline_0;

	/// <summary>
	///       Represents first visible row index.
	///       </summary>
	public int FirstVisibleRow
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	/// <summary>
	///       Represents first visible column index.
	///       </summary>
	public int FirstVisibleColumn
	{
		get
		{
			return int_3;
		}
		set
		{
			Class1677.smethod_25(value);
			int_3 = value;
		}
	}

	/// <summary>
	///       Represents the scaling factor in percent. It should be btween 10 and 400.
	///       </summary>
	/// <remarks>Please set the view type first.</remarks>
	public int Zoom
	{
		get
		{
			return viewType_0 switch
			{
				ViewType.NormalView => int_4[0], 
				ViewType.PageBreakPreview => int_4[1], 
				ViewType.PageLayoutView => int_4[2], 
				_ => 100, 
			};
		}
		set
		{
			if (value >= 10 && value <= 400)
			{
				switch (viewType_0)
				{
				case ViewType.NormalView:
					int_4[0] = value;
					break;
				case ViewType.PageBreakPreview:
					int_4[1] = value;
					break;
				case ViewType.PageLayoutView:
					int_4[2] = value;
					break;
				}
			}
		}
	}

	/// <summary>
	///       Gets and sets the view type.
	///       </summary>
	public ViewType ViewType
	{
		get
		{
			return viewType_0;
		}
		set
		{
			viewType_0 = value;
		}
	}

	/// <summary>
	///       Indications the specified worksheet is shown in normal view or page break preview.
	///       </summary>
	public bool IsPageBreakPreview
	{
		get
		{
			return viewType_0 == ViewType.PageBreakPreview;
		}
		set
		{
			if (value)
			{
				viewType_0 = ViewType.PageBreakPreview;
			}
			else
			{
				viewType_0 = ViewType.NormalView;
			}
		}
	}

	public bool IsRulerVisible
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	/// <summary>
	///       Represents worksheet tab color.
	///       </summary>
	/// <remarks>This feature is only supported in ExcelXP(Excel2002) and above version. If you save file as Excel97 or Excel2000 format, it will be omitted.</remarks>
	public Color TabColor
	{
		get
		{
			if (internalColor_0.method_2())
			{
				return Color.Empty;
			}
			return internalColor_0.method_6(worksheetCollection_0.Workbook);
		}
		set
		{
			if (Class1178.smethod_0(value))
			{
				internalColor_0.method_3(bool_0: true);
			}
			else
			{
				internalColor_0.SetColor(ColorType.RGB, value.ToArgb());
			}
		}
	}

	/// <summary>
	///       Represents worksheet code name.
	///       </summary>
	/// <remarks>You cannot change the code name while the template file contains VBA/macro.</remarks>
	public string CodeName
	{
		get
		{
			if (string_1 != null && !(string_1 == ""))
			{
				return string_1;
			}
			return string_0;
		}
	}

	public byte[] BackgroundImage
	{
		get
		{
			if (byte_1 != null)
			{
				return byte_1;
			}
			if (arrayList_2 != null)
			{
				byte[] array = (byte[])arrayList_2[0];
				int num = BitConverter.ToUInt16(array, 16);
				int num2 = BitConverter.ToUInt16(array, 18);
				int num3 = num * 3;
				int num4 = num3 % 4;
				if (num4 != 0)
				{
					num4 = 4 - num4;
					num3 += num4;
				}
				Bitmap bitmap = new Bitmap(num, num2);
				int num5 = 24;
				int num6 = 1;
				for (int num7 = num2 - 1; num7 >= 0; num7--)
				{
					for (int i = 0; i < num; i++)
					{
						if (num5 >= array.Length)
						{
							array = (byte[])arrayList_2[num6++];
							num5 = 4;
						}
						int blue = array[num5++];
						if (num5 >= array.Length)
						{
							array = (byte[])arrayList_2[num6++];
							num5 = 4;
						}
						int green = array[num5++];
						if (num5 >= array.Length)
						{
							array = (byte[])arrayList_2[num6++];
							num5 = 4;
						}
						int red = array[num5++];
						bitmap.SetPixel(i, num7, Color.FromArgb(red, green, blue));
					}
					num5 += num4;
					if (num7 != 0 && num5 >= array.Length)
					{
						array = (byte[])arrayList_2[num6++];
						num5 -= array.Length;
						num5 += 4;
					}
				}
				MemoryStream memoryStream = new MemoryStream();
				bitmap.Save(memoryStream, ImageFormat.Bmp);
				return memoryStream.ToArray();
			}
			return null;
		}
		set
		{
			arrayList_2 = null;
			byte_1 = value;
		}
	}

	/// <summary>
	///       Gets the ConditionalFormattings in the worksheet.
	///       </summary>
	public ConditionalFormattingCollection ConditionalFormattings
	{
		get
		{
			if (conditionalFormattingCollection_0 == null)
			{
				conditionalFormattingCollection_0 = new ConditionalFormattingCollection(this);
			}
			return conditionalFormattingCollection_0;
		}
	}

	/// <summary>
	///       Gets or sets the active cell in the worksheet. 
	///       </summary>
	public string ActiveCell
	{
		get
		{
			if (class1733_0 == null)
			{
				return "A1";
			}
			return class1733_0.method_1();
		}
		set
		{
			if (class1733_0 == null)
			{
				class1733_0 = new Class1733(this);
			}
			class1733_0.method_2(value);
		}
	}

	/// <summary>
	///       Gets an object representing 
	///       the identifier information associated with a worksheet. 
	///       </summary>
	/// <remarks>
	///       Worksheet.CustomProperties provide a preferred mechanism for storing arbitrary data. 
	///       It supports legacy third-party document components, as well as those situations that have a stringent need for binary parts. 
	///       </remarks>
	public CustomPropertyCollection CustomProperties
	{
		get
		{
			if (customPropertyCollection_0 == null)
			{
				customPropertyCollection_0 = new CustomPropertyCollection();
			}
			return customPropertyCollection_0;
		}
	}

	/// <summary>
	///       Gets the sparkline group collection in the worksheet.
	///       </summary>
	public SparklineGroupCollection SparklineGroupCollection
	{
		get
		{
			if (sparklineGroupCollection_0 == null)
			{
				sparklineGroupCollection_0 = new SparklineGroupCollection(this);
			}
			return sparklineGroupCollection_0;
		}
	}

	/// <summary>
	///       Gets all <see cref="T:Aspose.Cells.Markup.SmartTagCollection" /> objects of the worksheet.
	///       </summary>
	public SmartTagSetting SmartTagSetting
	{
		get
		{
			if (smartTagSetting_0 == null)
			{
				smartTagSetting_0 = new SmartTagSetting(this);
			}
			return smartTagSetting_0;
		}
	}

	internal int SheetIndex
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	internal Protection method_0()
	{
		return protection_0;
	}

	[SpecialName]
	internal PaneCollection method_1()
	{
		if (paneCollection_0 == null)
		{
			paneCollection_0 = new PaneCollection(this);
		}
		return paneCollection_0;
	}

	/// <summary>
	///       Gets the window panes.
	///       </summary>
	/// <remarks>
	///       If the window is not splitted or frozen.
	///       </remarks>
	public PaneCollection GetPanes()
	{
		return paneCollection_0;
	}

	internal Worksheet(Class1301 class1301_0, WorksheetCollection worksheetCollection_1)
	{
		int_1 = worksheetCollection_1.Count;
		worksheetCollection_0 = worksheetCollection_1;
		chartCollection_0 = new ChartCollection(this);
		commentCollection_0 = new CommentCollection(this);
		short_0 = 1217;
		cells_0 = new Cells(class1301_0, this);
		validationCollection_0 = new ValidationCollection(this);
		protectedRangeCollection_0 = new ProtectedRangeCollection(this);
		outline_0 = new Outline();
		string_0 = "";
		internalColor_0 = new InternalColor(bool_0: false);
		internalColor_0.method_3(bool_0: true);
	}

	internal Worksheet(Class1301 class1301_0, WorksheetCollection worksheetCollection_1, string string_2)
	{
		int_1 = worksheetCollection_1.Count;
		worksheetCollection_0 = worksheetCollection_1;
		chartCollection_0 = new ChartCollection(this);
		commentCollection_0 = new CommentCollection(this);
		short_0 = 1217;
		cells_0 = new Cells(class1301_0, this);
		validationCollection_0 = new ValidationCollection(this);
		protectedRangeCollection_0 = new ProtectedRangeCollection(this);
		outline_0 = new Outline();
		string_0 = string_2;
		internalColor_0 = new InternalColor(bool_0: false);
		internalColor_0.method_3(bool_0: true);
	}

	[SpecialName]
	internal WorksheetCollection method_2()
	{
		return worksheetCollection_0;
	}

	[SpecialName]
	internal int method_3()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_4(int int_6)
	{
		int_0 = int_6;
	}

	internal void method_5()
	{
		cells_0.method_6();
		if (commentCollection_0 != null && commentCollection_0.Count > 0)
		{
			Comment comment = null;
			for (int num = commentCollection_0.Count - 1; num >= 0; num--)
			{
				comment = commentCollection_0[num];
				if (comment.Row > 65535 || comment.Column > 255)
				{
					Shapes.method_26(comment.CommentShape);
				}
			}
		}
		if (paneCollection_0 != null && (paneCollection_0.Row > 65535 || paneCollection_0.Column > 255))
		{
			if (method_13())
			{
				UnFreezePanes();
			}
			else
			{
				RemoveSplit();
			}
		}
		if (class1733_0 != null && class1733_0.Count > 0)
		{
			for (int i = 0; i < class1733_0.Count; i++)
			{
				Class1732 @class = (Class1732)class1733_0[0];
				for (int num2 = @class.method_3().Count - 1; num2 >= 0; num2--)
				{
					CellArea cellArea = (CellArea)@class.method_3()[num2];
					if (cellArea.StartRow <= 65535 && cellArea.StartColumn <= 255)
					{
						if (cellArea.EndRow > 65535)
						{
							cellArea.EndRow = 65535;
						}
						if (cellArea.EndColumn > 255)
						{
							cellArea.EndColumn = 255;
						}
						@class.method_3()[num2] = cellArea;
					}
					else
					{
						if (@class.method_9() == num2)
						{
							if (paneCollection_0 != null)
							{
								switch (@class.method_1())
								{
								case 0:
									@class.method_0(paneCollection_0.Row, paneCollection_0.Column);
									break;
								case 1:
									@class.method_0(0, paneCollection_0.Column);
									break;
								case 2:
									@class.method_0(paneCollection_0.Row, 0);
									break;
								case 3:
									@class.method_0(0, 0);
									break;
								}
							}
							else
							{
								@class.method_0(0, 0);
							}
						}
						if (@class.method_9() > num2)
						{
							@class.method_10(@class.method_9() - 1);
						}
						@class.method_3().RemoveAt(num2);
					}
				}
				if (@class.method_5() > 65535)
				{
					@class.method_6(65535);
				}
				if (@class.method_7() > 255)
				{
					@class.method_8(255);
				}
			}
		}
		if (int_2 > 65535)
		{
			int_2 = 0;
		}
		if (int_3 > 255)
		{
			int_3 = 0;
		}
		if (validationCollection_0 != null && validationCollection_0.Count > 0)
		{
			for (int num3 = validationCollection_0.Count - 1; num3 >= 0; num3--)
			{
				ArrayList areaList = validationCollection_0[num3].AreaList;
				for (int num4 = areaList.Count - 1; num4 >= 0; num4--)
				{
					CellArea cellArea2 = (CellArea)areaList[num4];
					if (cellArea2.StartRow <= 65535 && cellArea2.StartColumn <= 255)
					{
						if (cellArea2.EndRow > 65535)
						{
							cellArea2.EndRow = 65535;
							if (cellArea2.EndColumn > 255)
							{
								cellArea2.EndColumn = 255;
							}
							areaList[num4] = cellArea2;
						}
						else if (cellArea2.EndColumn > 255)
						{
							cellArea2.EndColumn = 255;
							areaList[num4] = cellArea2;
						}
					}
					else
					{
						areaList.RemoveAt(num4);
					}
				}
				if (areaList.Count == 0)
				{
					validationCollection_0.RemoveAt(num3);
				}
			}
		}
		if (conditionalFormattingCollection_0 == null || conditionalFormattingCollection_0.Count <= 0)
		{
			return;
		}
		for (int num5 = conditionalFormattingCollection_0.Count - 1; num5 >= 0; num5--)
		{
			FormatConditionCollection formatConditionCollection = conditionalFormattingCollection_0[num5];
			ArrayList arrayList = formatConditionCollection.arrayList_1;
			for (int num6 = arrayList.Count - 1; num6 >= 0; num6--)
			{
				CellArea cellArea3 = (CellArea)arrayList[num6];
				if (cellArea3.StartRow <= 65535 && cellArea3.StartColumn <= 255)
				{
					if (cellArea3.EndRow > 65535)
					{
						cellArea3.EndRow = 65535;
						if (cellArea3.EndColumn > 255)
						{
							cellArea3.EndColumn = 255;
						}
						arrayList[num6] = cellArea3;
					}
					else if (cellArea3.EndColumn > 255)
					{
						cellArea3.EndColumn = 255;
						arrayList[num6] = cellArea3;
					}
				}
				else
				{
					arrayList.RemoveAt(num6);
				}
			}
			if (arrayList.Count == 0)
			{
				conditionalFormattingCollection_0.RemoveAt(num5);
			}
		}
	}

	internal string method_6(string string_2)
	{
		if (string_2.Length >= 32)
		{
			throw new CellsException(ExceptionType.InvalidData, "The max length of the sheet name is 31");
		}
		for (int i = 0; i < string_2.Length; i++)
		{
			switch (string_2[i])
			{
			case '*':
			case '/':
			case ':':
			case '?':
			case '[':
			case '\\':
			case ']':
				throw new CellsException(ExceptionType.InvalidData, "Worksheet name could not contain any following characters :  : \\ / ? * [  or ]");
			}
		}
		if (string_2.ToUpper() != string_0.ToUpper())
		{
			for (int j = 0; j < worksheetCollection_0.Count; j++)
			{
				string name = worksheetCollection_0[j].Name;
				if (name.ToUpper() == string_2.ToUpper())
				{
					throw new CellsException(ExceptionType.InvalidData, "The same worksheet name already exists");
				}
			}
		}
		return string_2;
	}

	internal void method_7(string string_2)
	{
		string_0 = string_2;
	}

	internal void method_8(ref int int_6)
	{
		int num = int_6;
		string text = ((num != -1) ? ("Evaluation Warning (" + int_6 + ")") : "Evaluation Warning");
		if (!(text != string_0))
		{
			return;
		}
		int num2 = 0;
		while (true)
		{
			if (num2 < worksheetCollection_0.Count)
			{
				if (worksheetCollection_0[num2].Name == text)
				{
					break;
				}
				num2++;
				continue;
			}
			string_0 = text;
			return;
		}
		int_6++;
		method_8(ref int_6);
	}

	[SpecialName]
	internal ushort method_9()
	{
		return ushort_0;
	}

	[SpecialName]
	internal void method_10(ushort ushort_1)
	{
		ushort_0 = ushort_1;
	}

	[SpecialName]
	internal bool method_11()
	{
		return (ushort_0 & 1) != 0;
	}

	[SpecialName]
	internal void method_12(bool bool_1)
	{
		if (bool_1)
		{
			ushort_0 |= 1;
		}
		else
		{
			ushort_0 &= 65534;
		}
	}

	[SpecialName]
	internal bool method_13()
	{
		return (ushort_0 & 8) != 0;
	}

	[SpecialName]
	internal void method_14(bool bool_1)
	{
		if (bool_1)
		{
			ushort_0 |= 8;
		}
		else
		{
			ushort_0 &= 65527;
		}
	}

	[SpecialName]
	internal void method_15(bool bool_1)
	{
		if (bool_1)
		{
			ushort_0 &= 65279;
		}
		else
		{
			ushort_0 |= 256;
		}
	}

	/// <summary>
	///       Freezes panes at the specified cell in the worksheet.
	///       </summary>
	/// <param name="row">Row index.</param>
	/// <param name="column">Column index.</param>
	/// <param name="freezedRows">Number of visible rows in top pane, no more than row index.</param>
	/// <param name="freezedColumns">Number of visible columns in left pane, no more than column index.</param>
	/// <remarks>
	///   <p>Row index and column index cannot all be zero. Number of rows and number of columns
	///       also cannot all be zero.</p>
	///   <p>The first two parameters specify the freezed position and the last two parameters specify the area freezed on the left top pane.</p>
	/// </remarks>
	public void FreezePanes(int row, int column, int freezedRows, int freezedColumns)
	{
		Class1677.CheckCell(row, column);
		if (freezedRows >= 0 && freezedColumns >= 0)
		{
			if (row == 0 && column == 0)
			{
				throw new ArgumentException("Row index and column index cannot all be zero.");
			}
			if (freezedRows == 0 && freezedColumns == 0)
			{
				throw new ArgumentException("Number of freezed rows and number of freezed columns cannot all be zero.");
			}
			if (paneCollection_0 == null)
			{
				paneCollection_0 = new PaneCollection(this);
				method_15(bool_1: false);
			}
			else if (!method_13())
			{
				method_15(bool_1: true);
			}
			paneCollection_0.method_10(row, column, freezedRows, freezedColumns);
			method_14(bool_1: true);
			return;
		}
		throw new ArgumentException("Row index and column index cannot all be zero.");
	}

	/// <summary>
	///       Gets the freeze panes.
	///       </summary>
	/// <param name="row">Row index.</param>
	/// <param name="column">Column index.</param>
	/// <param name="freezedRows">Number of visible rows in top pane, no more than row index.</param>
	/// <param name="freezedColumns">Number of visible columns in left pane, no more than column index.</param>
	/// <returns>Return whether the worksheet is frozen</returns>
	public bool GetFreezedPanes(out int row, out int column, out int freezedRows, out int freezedColumns)
	{
		freezedColumns = 0;
		freezedRows = 0;
		column = 0;
		row = 0;
		if (method_13() && paneCollection_0 != null)
		{
			row = int_2 + paneCollection_0.method_4();
			column = int_3 + paneCollection_0.method_6();
			freezedRows = paneCollection_0.method_4();
			freezedColumns = paneCollection_0.method_6();
			return true;
		}
		return false;
	}

	/// <summary>
	///       Splits window.
	///       </summary>
	public void Split()
	{
		string activeCell = ActiveCell;
		paneCollection_0 = new PaneCollection(this);
		method_14(bool_1: false);
		paneCollection_0.Split(activeCell);
	}

	/// <summary>
	///       Freezes panes at the specified cell in the worksheet.
	///       </summary>
	/// <param name="cellName">Cell name.</param>
	/// <param name="freezedRows">Number of visible rows in top pane, no more than row index.</param>
	/// <param name="freezedColumns">Number of visible columns in left pane, no more than column index.</param>
	/// <remarks>Row index and column index cannot all be zero. Number of rows and number of columns
	///       also cannot all be zero.</remarks>
	public void FreezePanes(string cellName, int freezedRows, int freezedColumns)
	{
		CellsHelper.CellNameToIndex(cellName, out var row, out var column);
		FreezePanes(row, column, freezedRows, freezedColumns);
	}

	/// <summary>
	///       Unfreezes panes in the worksheet.
	///       </summary>
	public void UnFreezePanes()
	{
		if (!method_13())
		{
			return;
		}
		paneCollection_0 = null;
		method_14(bool_1: false);
		method_15(bool_1: true);
		if (class1733_0 == null)
		{
			return;
		}
		for (int num = class1733_0.Count - 1; num >= 0; num--)
		{
			Class1732 @class = (Class1732)class1733_0[num];
			if (@class.method_1() != 3)
			{
				class1733_0.RemoveAt(num);
			}
		}
	}

	/// <summary>
	///       Removes splitted window.
	///       </summary>
	public void RemoveSplit()
	{
		if (!method_13())
		{
			paneCollection_0 = null;
			if (class1733_0 != null)
			{
				for (int num = class1733_0.Count - 1; num >= 0; num--)
				{
					Class1732 @class = (Class1732)class1733_0[num];
					if (@class.method_1() != 3)
					{
						class1733_0.RemoveAt(num);
					}
				}
			}
			method_15(bool_1: true);
		}
		else
		{
			method_15(bool_1: false);
		}
	}

	internal PictureCollection method_16()
	{
		return pictureCollection_0;
	}

	internal ListObjectCollection method_17()
	{
		return listObjectCollection_0;
	}

	internal OleObjectCollection method_18()
	{
		return oleObjectCollection_0;
	}

	/// <summary>
	///       Adds page break.
	///       </summary>
	/// <param name="cellName">
	/// </param>
	public void AddPageBreaks(string cellName)
	{
		CellsHelper.CellNameToIndex(cellName, out var row, out var column);
		HorizontalPageBreaks.Add(row, column);
		VerticalPageBreaks.Add(row, column);
	}

	private void method_19(Worksheet worksheet_0, CopyOptions copyOptions_0)
	{
		RemoveAllDrawingObjects();
		if (worksheet_0.sheetType_0 == SheetType.Chart)
		{
			Chart chart = new Chart(this);
			Chart chart2 = worksheet_0.chartCollection_0[0];
			chart.ChartObject.Copy(chart2.ChartObject, copyOptions_0);
			chartCollection_0.Add(chart);
			return;
		}
		if (worksheet_0.shapeCollection_0 != null && worksheet_0.shapeCollection_0.Count != 0)
		{
			Shapes.Copy(worksheet_0.Shapes, copyOptions_0);
		}
		if (worksheet_0.sparklineGroupCollection_0 != null && worksheet_0.sparklineGroupCollection_0.Count != 0)
		{
			SparklineGroupCollection.Copy(worksheet_0.SparklineGroupCollection, copyOptions_0);
		}
	}

	[SpecialName]
	internal ArrayList method_20()
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		return arrayList_0;
	}

	internal ArrayList method_21()
	{
		return arrayList_0;
	}

	/// <summary>
	///       Copies contents and formats from another worksheet.
	///       </summary>
	/// <param name="sourceSheet">Source worksheet.</param>
	public void Copy(Worksheet sourceSheet)
	{
		CopyOptions copyOptions = new CopyOptions(bool_6: false);
		copyOptions.CopyNames = true;
		Copy(sourceSheet, copyOptions);
		IsSelected = worksheetCollection_0.ActiveSheetIndex == Index;
	}

	/// <summary>
	///       Copies contents and formats from another worksheet.
	///       </summary>
	/// <param name="sourceSheet">Source worksheet.</param>
	/// <param name="copyOption">
	/// </param>
	/// <remarks>You can copy data from another worksheet in the same file or another file. However, this method does not support to copy drawing objects, such as comments, images and charts.</remarks>
	public void Copy(Worksheet sourceSheet, CopyOptions copyOption)
	{
		if (sourceSheet == null || this == sourceSheet)
		{
			return;
		}
		if (copyOption == null)
		{
			copyOption = new CopyOptions(bool_6: false);
		}
		if (copyOption.CopyInvalidFormulasAsValues)
		{
			copyOption.hashtable_2 = new Hashtable();
			for (int i = 0; i < sourceSheet.worksheetCollection_0.method_32().Count; i++)
			{
				Class1246 @class = sourceSheet.worksheetCollection_0.method_32()[i];
				if (@class.ushort_0 != sourceSheet.worksheetCollection_0.method_36() || @class.ushort_1 != @class.ushort_2 || @class.ushort_1 != sourceSheet.Index)
				{
					copyOption.hashtable_2.Add(i, i);
				}
			}
			copyOption.hashtable_3 = new Hashtable();
			for (int j = 0; j < sourceSheet.worksheetCollection_0.Names.Count; j++)
			{
				Name name = sourceSheet.worksheetCollection_0.Names[j];
				if (name.method_2() != null)
				{
					if (Class1674.smethod_13(name.method_2(), -1, -1, sourceSheet.worksheetCollection_0, copyOption.hashtable_2, copyOption.hashtable_3))
					{
						copyOption.hashtable_3[j] = true;
					}
					else
					{
						copyOption.hashtable_3[j] = false;
					}
				}
			}
		}
		if (worksheetCollection_0 == sourceSheet.worksheetCollection_0 && sourceSheet.class1557_0 != null && sourceSheet.class1557_0.string_2 != null)
		{
			class1557_0 = new Class1557(this);
			class1557_0.string_2 = sourceSheet.class1557_0.string_2;
			class1557_0.arrayList_7.AddRange(sourceSheet.class1557_0.arrayList_7);
			class1557_0.arrayList_9.AddRange(sourceSheet.class1557_0.arrayList_9);
			class1557_0.arrayList_10.AddRange(sourceSheet.class1557_0.arrayList_10);
		}
		cells_0 = new Cells(worksheetCollection_0.class1301_0, this);
		validationCollection_0 = new ValidationCollection(this);
		protectedRangeCollection_0 = new ProtectedRangeCollection(this);
		outline_0 = new Outline();
		if (copyOption.hashtable_4 == null)
		{
			int[] array = sourceSheet.method_2().method_32().method_9(sourceSheet.method_2().method_36(), sourceSheet.Index);
			int num = method_2().method_32().method_8(method_2().method_36(), Index);
			Hashtable hashtable = new Hashtable();
			for (int k = 0; k < array.Length; k++)
			{
				hashtable.Add(array[k], num);
			}
			array = sourceSheet.method_2().method_32().method_9(sourceSheet.method_2().method_36(), 65535);
			num = method_2().method_32().method_8(method_2().method_36(), 65535);
			for (int l = 0; l < array.Length; l++)
			{
				hashtable.Add(array[l], num);
			}
			array = sourceSheet.method_2().method_32().method_9(sourceSheet.method_2().method_36(), 65534);
			if (array != null)
			{
				num = method_2().method_32().method_11(method_2().method_36(), 65534, 65534, bool_0: true);
				for (int m = 0; m < array.Length; m++)
				{
					hashtable.Add(array[m], num);
				}
			}
			Hashtable hashtable_ = new Hashtable();
			copyOption.hashtable_4 = hashtable;
			copyOption.hashtable_5 = hashtable_;
			if (worksheetCollection_0 != sourceSheet.worksheetCollection_0 && copyOption.method_0())
			{
				for (int n = 0; n < sourceSheet.worksheetCollection_0.Count; n++)
				{
					Worksheet worksheet = sourceSheet.worksheetCollection_0[n];
					if (worksheet == sourceSheet)
					{
						continue;
					}
					Worksheet worksheet2 = worksheetCollection_0[worksheet.Name];
					if (worksheet2 != null)
					{
						array = sourceSheet.method_2().method_32().method_9(sourceSheet.method_2().method_36(), worksheet.Index);
						num = method_2().method_32().method_8(method_2().method_36(), worksheet2.Index);
						for (int num2 = 0; num2 < array.Length; num2++)
						{
							hashtable[array[num2]] = num;
						}
					}
				}
			}
		}
		if (sheetType_0 != SheetType.Chart)
		{
			if (!copyOption.bool_0 && copyOption.CopyNames)
			{
				Hashtable hashtable2 = new Hashtable();
				int count = sourceSheet.worksheetCollection_0.Names.Count;
				ArrayList arrayList = new ArrayList();
				for (int num3 = 0; num3 < count; num3++)
				{
					Name name2 = sourceSheet.worksheetCollection_0.Names[num3];
					string text = name2.Text;
					int num4 = name2.SheetIndex - 1;
					int num5 = 0;
					bool flag = false;
					if (num4 == -1)
					{
						num4 = name2.method_24();
						if (num4 == sourceSheet.Index)
						{
							flag = true;
							num5 = Index;
							if (worksheetCollection_0 != sourceSheet.worksheetCollection_0)
							{
								int num6 = worksheetCollection_0.Names.method_8(name2.Text, -1, bool_0: false);
								if (num6 == -1)
								{
									num5 = -1;
								}
								else if (num6 < count && sourceSheet.worksheetCollection_0.Names.method_8(name2.Text, num4, bool_0: false) != -1)
								{
									flag = false;
								}
							}
						}
						else if (name2.RefersTo == null)
						{
							flag = true;
							num5 = -1;
						}
					}
					else if (num4 == sourceSheet.Index)
					{
						flag = true;
						num5 = Index;
					}
					if (flag)
					{
						int num7 = worksheetCollection_0.Names.method_0(num5, text);
						Name name3 = method_2().Names[num7];
						if (!arrayList.Contains(name3))
						{
							name3.method_29(name2);
							hashtable2.Add(num3, num7);
							arrayList.Add(name3);
						}
					}
				}
				copyOption.hashtable_1 = hashtable2;
				sourceSheet.method_2().method_32().method_9(sourceSheet.method_2().method_36(), sourceSheet.Index);
				method_2().method_32().method_8(method_2().method_36(), Index);
				Hashtable hashtable_2 = copyOption.hashtable_4;
				int num8 = method_2().method_32().method_10(method_2().method_36(), 65535, 65535);
				if (num8 == -1)
				{
					num8 = method_2().method_32().method_3((ushort)method_2().method_36(), ushort.MaxValue, ushort.MaxValue);
				}
				Hashtable hashtable_3 = copyOption.hashtable_5;
				for (int num9 = 0; num9 < arrayList.Count; num9++)
				{
					Name name4 = (Name)arrayList[num9];
					byte[] array2 = name4.method_2();
					if (array2 != null && !Class1674.smethod_9(hashtable_2, hashtable2, sourceSheet, this, hashtable_3, num8, -1, -1, array2))
					{
						name4.RefersTo = null;
					}
				}
			}
			if (sourceSheet.listObjectCollection_0 != null)
			{
				listObjectCollection_0 = new ListObjectCollection(this);
				listObjectCollection_0.Copy(sourceSheet.listObjectCollection_0);
			}
			if (sourceSheet.smartTagSetting_0 != null)
			{
				smartTagSetting_0 = new SmartTagSetting(this);
				smartTagSetting_0.Copy(sourceSheet.smartTagSetting_0);
			}
			int_3 = sourceSheet.int_3;
			int_2 = sourceSheet.int_2;
			bool_0 = sourceSheet.bool_0;
			sheetType_0 = sourceSheet.sheetType_0;
			if (sourceSheet.autoFilter_0 != null)
			{
				AutoFilter.Copy(sourceSheet.autoFilter_0);
			}
			else
			{
				autoFilter_0 = null;
			}
			string_1 = sourceSheet.string_1;
			if (sourceSheet.conditionalFormattingCollection_0 != null)
			{
				conditionalFormattingCollection_0 = new ConditionalFormattingCollection(this);
				conditionalFormattingCollection_0.Copy(sourceSheet.conditionalFormattingCollection_0, copyOption);
			}
			else
			{
				conditionalFormattingCollection_0 = null;
			}
			if (sourceSheet.validationCollection_0.Count > 0)
			{
				validationCollection_0.Clear();
				validationCollection_0.Copy(sourceSheet.validationCollection_0, copyOption);
			}
			if (sourceSheet.protectedRangeCollection_0.Count > 0)
			{
				protectedRangeCollection_0.Clear();
				protectedRangeCollection_0.Copy(sourceSheet.protectedRangeCollection_0);
			}
			if (sourceSheet.paneCollection_0 != null)
			{
				paneCollection_0 = new PaneCollection(this);
				paneCollection_0.Copy(sourceSheet.paneCollection_0);
			}
			else
			{
				paneCollection_0 = null;
			}
			method_22(sourceSheet);
			ushort_0 = sourceSheet.ushort_0;
			if (!copyOption.bool_0 && worksheetCollection_0 == sourceSheet.worksheetCollection_0 && worksheetCollection_0.ActiveSheetIndex == sourceSheet.Index)
			{
				worksheetCollection_0.ActiveSheetIndex = Index;
			}
			if (sourceSheet.protection_0 != null)
			{
				protection_0 = new Protection();
				protection_0.Copy(sourceSheet.protection_0);
			}
			else
			{
				protection_0 = null;
			}
			cells_0.Copy(sourceSheet.cells_0, copyOption);
			if (sourceSheet.pivotTableCollection_0 != null && sourceSheet.pivotTableCollection_0.Count != 0)
			{
				pivotTableCollection_0 = new PivotTableCollection(this);
				PivotTables.Copy(sourceSheet.pivotTableCollection_0);
			}
			else
			{
				pivotTableCollection_0 = null;
			}
			outline_0 = sourceSheet.outline_0;
		}
		method_23(sourceSheet);
		method_19(sourceSheet, copyOption);
	}

	private void method_22(Worksheet worksheet_0)
	{
		class1733_0 = null;
		if (worksheet_0.class1733_0 != null && worksheet_0.class1733_0.Count > 0)
		{
			class1733_0 = new Class1733(this);
			for (int i = 0; i < worksheet_0.class1733_0.Count; i++)
			{
				Class1732 @class = (Class1732)worksheet_0.class1733_0[i];
				Class1732 class2 = new Class1732(@class.method_1());
				class2.Copy(@class);
				class1733_0.Add(class2);
			}
		}
	}

	private void method_23(Worksheet worksheet_0)
	{
		byte_0 = worksheet_0.byte_0;
		viewType_0 = worksheet_0.viewType_0;
		Array.Copy(worksheet_0.int_4, 0, int_4, 0, int_4.Length);
		internalColor_0.method_19(worksheet_0.internalColor_0);
		ushort_0 = worksheet_0.ushort_0;
		short_0 = worksheet_0.short_0;
	}

	/// <summary>
	///       Autofits the column width.
	///       </summary>
	/// <param name="columnIndex">Column index.</param>
	/// <param name="firstRow">First row index.</param>
	/// <param name="lastRow">Last row index.</param>
	/// <remarks>This method autofits a row based on content in a range of cells within the row.
	///       </remarks>
	public void AutoFitColumn(int columnIndex, int firstRow, int lastRow)
	{
		Class1677.smethod_25(columnIndex);
		Class1677.smethod_27(firstRow, lastRow);
		Class1190.AutoFitColumn(cells_0, firstRow, lastRow, columnIndex, columnIndex, null);
	}

	/// <summary>
	///       Autofits all columns in this worksheet.
	///       </summary>
	public void AutoFitColumns()
	{
		Class1190.AutoFitColumn(cells_0, 0, 1048575, 0, 16383, null);
	}

	public void AutoFitColumns(AutoFitterOptions options)
	{
		Class1190.AutoFitColumn(cells_0, 0, 1048575, 0, 16383, options);
	}

	/// <summary>
	///       Autofits the column width.
	///       </summary>
	/// <param name="columnIndex">Column index.</param>
	/// <remarks>AutoFitColumn is an imprecise function.</remarks>
	public void AutoFitColumn(int columnIndex)
	{
		Class1677.smethod_25(columnIndex);
		Class1190.AutoFitColumn(cells_0, 0, 1048575, columnIndex, columnIndex, null);
	}

	public void AutoFitColumns(int firstColumn, int lastColumn)
	{
		Class1677.smethod_25(firstColumn);
		Class1677.smethod_25(lastColumn);
		Class1190.AutoFitColumn(cells_0, 0, 1048575, firstColumn, lastColumn, null);
	}

	public void AutoFitColumns(int firstColumn, int lastColumn, AutoFitterOptions options)
	{
		Class1677.smethod_25(firstColumn);
		Class1677.smethod_25(lastColumn);
		Class1190.AutoFitColumn(cells_0, 0, 1048575, firstColumn, lastColumn, options);
	}

	public void AutoFitColumns(int firstRow, int firstColumn, int lastRow, int lastColumn)
	{
		Class1677.smethod_25(firstColumn);
		Class1677.smethod_25(lastColumn);
		Class1190.AutoFitColumn(cells_0, firstRow, lastRow, firstColumn, lastColumn, null);
	}

	/// <summary>
	///       Autofits the row height.
	///       </summary>
	/// <param name="rowIndex">Row index.</param>
	/// <param name="firstColumn">First column index.</param>
	/// <param name="lastColumn">Last column index.</param>
	/// <remarks>This method autofits a row based on content in a range of cells within the row.
	///       </remarks>
	public void AutoFitRow(int rowIndex, int firstColumn, int lastColumn)
	{
		Class1677.smethod_24(rowIndex);
		Class1677.smethod_28(firstColumn, lastColumn);
		AutoFitRow(rowIndex, rowIndex, firstColumn, lastColumn);
	}

	/// <summary>
	///       Autofits the row height.
	///       </summary>
	/// <param name="rowIndex">Row index.</param>
	/// <param name="firstColumn">First column index.</param>
	/// <param name="lastColumn">Last column index.</param>
	/// <param name="options">The auto fitter options</param>
	/// <remarks>This method autofits a row based on content in a range of cells within the row.
	///       </remarks>
	public void AutoFitRow(int rowIndex, int firstColumn, int lastColumn, AutoFitterOptions options)
	{
		Class1677.smethod_24(rowIndex);
		Class1677.smethod_28(firstColumn, lastColumn);
		Class1721.AutoFitRow(cells_0, rowIndex, rowIndex, firstColumn, lastColumn, options);
	}

	/// <summary>
	///       Autofits all rows in this worksheet.
	///       </summary>
	public void AutoFitRows()
	{
		if (cells_0.Rows.Count != 0)
		{
			Row rowByIndex = cells_0.Rows.GetRowByIndex(cells_0.Rows.Count - 1);
			AutoFitterOptions autoFitterOptions_ = new AutoFitterOptions();
			Class1721.AutoFitRow(cells_0, 0, rowByIndex.int_0, 0, cells_0.method_22(0), autoFitterOptions_);
		}
	}

	/// <summary>
	///       Autofits all rows in this worksheet.
	///       </summary>
	/// <param name="onlyAuto">
	///       True,only autofits the row height when row height is not customed.
	///       </param>
	public void AutoFitRows(bool onlyAuto)
	{
		if (cells_0.Rows.Count != 0)
		{
			Row rowByIndex = cells_0.Rows.GetRowByIndex(cells_0.Rows.Count - 1);
			AutoFitterOptions autoFitterOptions = new AutoFitterOptions();
			autoFitterOptions.OnlyAuto = onlyAuto;
			Class1721.AutoFitRow(cells_0, 0, rowByIndex.int_0, 0, cells_0.method_22(0), autoFitterOptions);
		}
	}

	/// <summary>
	///       Autofits all rows in this worksheet.
	///       </summary>
	/// <param name="options">The auto fitter options</param>
	public void AutoFitRows(AutoFitterOptions options)
	{
		if (cells_0.Rows.Count != 0)
		{
			Row rowByIndex = cells_0.Rows.GetRowByIndex(cells_0.Rows.Count - 1);
			Class1721.AutoFitRow(cells_0, 0, rowByIndex.int_0, 0, cells_0.method_22(0), options);
		}
	}

	public void AutoFitRows(int startRow, int endRow)
	{
		Class1677.smethod_24(startRow);
		Class1677.smethod_24(endRow);
		AutoFitterOptions autoFitterOptions = new AutoFitterOptions();
		autoFitterOptions.bool_3 = true;
		Class1721.AutoFitRow(cells_0, startRow, endRow, 0, 16383, autoFitterOptions);
	}

	/// <summary>
	///       Autofits row height in a rectangle range.
	///       </summary>
	/// <param name="startRow">Start row index.</param>
	/// <param name="endRow">End row index.</param>
	/// <param name="startColumn">Start column index.</param>
	/// <param name="endColumn">End column index.</param>
	public void AutoFitRow(int startRow, int endRow, int startColumn, int endColumn)
	{
		Class1677.smethod_26(startRow, startColumn, endRow, endColumn);
		AutoFitterOptions autoFitterOptions = new AutoFitterOptions();
		autoFitterOptions.bool_3 = startColumn == 0 && endColumn == 16383;
		Class1721.AutoFitRow(cells_0, startRow, endRow, startColumn, endColumn, autoFitterOptions);
	}

	/// <summary>
	///       Autofits the row height.
	///       </summary>
	/// <param name="rowIndex">Row index.</param>
	/// <remarks>AutoFitRow is an imprecise function.</remarks>
	public void AutoFitRow(int rowIndex)
	{
		Class1677.smethod_24(rowIndex);
		AutoFitterOptions autoFitterOptions = new AutoFitterOptions();
		autoFitterOptions.bool_3 = true;
		Class1721.AutoFitRow(cells_0, rowIndex, rowIndex, 0, 16383, autoFitterOptions);
	}

	[SpecialName]
	internal int method_24()
	{
		if (autoFilter_0 == null)
		{
			return 0;
		}
		return autoFilter_0.Count;
	}

	public void RemoveAutoFilter()
	{
		autoFilter_0 = null;
	}

	[SpecialName]
	internal bool method_25()
	{
		return (short_0 & 0x4000) != 0;
	}

	[SpecialName]
	internal byte method_26()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_27(byte byte_2)
	{
		byte_0 = byte_2;
	}

	/// <summary>
	///       Sets the visible options.
	///       </summary>
	/// <param name="isVisible">Whether the worksheet is visible</param>
	/// <param name="ignoreError">Whether ignore error if this option is not valid.</param>
	public void SetVisible(bool isVisible, bool ignoreError)
	{
		if (ignoreError)
		{
			if (isVisible)
			{
				byte_0 = 0;
				return;
			}
			byte_0 = 1;
			IsSelected = false;
		}
		else
		{
			IsVisible = isVisible;
		}
	}

	internal void method_28(bool bool_1, bool bool_2)
	{
		if (bool_1)
		{
			byte_0 = 0;
		}
		else if (bool_2)
		{
			byte_0 = 2;
		}
		else
		{
			byte_0 = 1;
		}
	}

	[SpecialName]
	internal bool method_29()
	{
		return byte_0 == 2;
	}

	[SpecialName]
	internal ArrayList method_30()
	{
		return arrayList_1;
	}

	[SpecialName]
	internal void method_31(ArrayList arrayList_4)
	{
		arrayList_1 = arrayList_4;
	}

	[SpecialName]
	internal Class705 method_32()
	{
		return class705_0;
	}

	[SpecialName]
	internal void method_33(Class705 class705_1)
	{
		class705_0 = class705_1;
	}

	[SpecialName]
	internal Class1733 method_34()
	{
		return class1733_0;
	}

	[SpecialName]
	internal void method_35(Class1733 class1733_1)
	{
		class1733_0 = class1733_1;
	}

	internal ShapeCollection method_36()
	{
		return shapeCollection_0;
	}

	internal void method_37(ShapeCollection shapeCollection_1)
	{
		shapeCollection_0 = shapeCollection_1;
	}

	private void method_38(ProtectionType protectionType_0)
	{
		Protection protection = Protection;
		switch (protectionType_0)
		{
		case ProtectionType.All:
			protection.AllowEditingContent = false;
			protection.AllowEditingObject = false;
			protection.AllowEditingScenario = false;
			break;
		case ProtectionType.Contents:
			protection.AllowEditingContent = false;
			break;
		case ProtectionType.Objects:
			protection.AllowEditingObject = false;
			break;
		case ProtectionType.Scenarios:
			protection.AllowEditingScenario = false;
			break;
		}
	}

	/// <summary>
	///        Protects worksheet.
	///        </summary>
	/// <param name="type">Protection type.</param>
	/// <remarks>This method protects worksheet without password. It can protect worksheet in all versions of Excel file. 
	///       </remarks>
	public void Protect(ProtectionType type)
	{
		if (protection_0 == null || protection_0.method_2() == 0)
		{
			method_38(type);
		}
	}

	/// <summary>
	///       Protects worksheet.
	///       </summary>
	/// <param name="type">Protection type.</param>
	/// <param name="password">Password.</param>
	/// <param name="oldPassword">If the worksheet is already protected by a password, please supply the old password.
	///       Otherwise, you can set a null value or blank string to this parameter.</param>
	/// <remarks>This method can protect worksheet in all versions of Excel file. 
	///       </remarks>
	/// <example>
	///   <code>
	///
	///       [C#]
	///
	///
	///
	///       //Creating a file stream containing the Excel file to be opened
	///       FileStream fstream = new FileStream("C:\\book1.xls", FileMode.Open);
	///       //Instantiating a Workbook object and Opening the Excel file through the file stream
	///       Workbook excel = new Workbook(fstream);
	///       //Accessing the first worksheet in the Excel file
	///       Worksheet worksheet = excel.Worksheets[0];
	///       //Protecting the worksheet with a password
	///       worksheet.Protect(ProtectionType.All, "aspose", null);
	///       //Saving the modified Excel file in default (that is Excel 20003) format
	///       excel.Save("C:\\output.xls");
	///       //Closing the file stream to free all resources
	///       fstream.Close();
	///
	///       [Visual Basic]
	///
	///       'Creating a file stream containing the Excel file to be opened
	///       Dim fstream As FileStream = New FileStream("C:\\book1.xls", FileMode.Open)
	///       'Instantiating a Workbook object and Opening the Excel file through the file stream
	///       Dim excel As Workbook = New Workbook(fstream)
	///       'Accessing the first worksheet in the Excel file
	///       Dim worksheet As Worksheet = excel.Worksheets(0)
	///       'Protecting the worksheet with a password
	///       worksheet.Protect(ProtectionType.All, "aspose", DBNull.Value.ToString())
	///       'Saving the modified Excel file in default (that is Excel 20003) format
	///       excel.Save("C:\\output.xls")
	///       'Closing the file stream to free all resources
	///       fstream.Close()
	///
	///       </code>
	/// </example>
	public void Protect(ProtectionType type, string password, string oldPassword)
	{
		if (protection_0 == null || protection_0.method_4(oldPassword))
		{
			method_38(type);
			Protection.method_3((ushort)Class1652.smethod_0(password));
		}
	}

	/// <summary>
	///       Unprotects worksheet.
	///       </summary>
	/// <remarks> This method unprotects worksheet which is protected without password.
	///       </remarks>
	public void Unprotect()
	{
		Unprotect(null);
	}

	/// <summary>
	///       Unprotects worksheet.
	///       </summary>
	/// <param name="password">Password</param>
	/// <remarks>If the worksheet is protected without a password, you can set a null value or blank string to password parameter.
	///       </remarks>
	public void Unprotect(string password)
	{
		if (protection_0 != null)
		{
			if (!protection_0.method_4(password))
			{
				throw new CellsException(ExceptionType.IncorrectPassword, "Invalid password for unprotecting the worksheet.");
			}
			protection_0 = null;
		}
	}

	/// <summary>
	///       Copies conditional formatting on a cell to another cell.
	///       </summary>
	/// <param name="sourceRow">Source cell row index.</param>
	/// <param name="sourceColumn">Source cell column index.</param>
	/// <param name="destRow">Destination cell row index.</param>
	/// <param name="destColumn">Destination cell column index.</param>
	/// <remarks>This method can only copy conditional formatting within the same worksheet. </remarks>
	public void CopyConditionalFormatting(int sourceRow, int sourceColumn, int destRow, int destColumn)
	{
		Class1677.CheckCell(sourceRow, sourceColumn);
		Class1677.CheckCell(destRow, destColumn);
		if (conditionalFormattingCollection_0 != null)
		{
			conditionalFormattingCollection_0.method_0(sourceRow, sourceColumn, destRow, destColumn);
		}
	}

	/// <summary>
	///       Moves the sheet to another location in the spreadsheet.
	///       </summary>
	/// <param name="index">Destination sheet index.</param>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use Worsheet.MoveTo(int) method instead.")]
	public void Move(int index)
	{
		MoveTo(index);
	}

	public void MoveTo(int index)
	{
		if (index != int_1)
		{
			worksheetCollection_0.Move(int_1, index);
		}
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			Worksheet worksheet = worksheetCollection_0[i];
			worksheet.int_1 = i;
		}
	}

	/// <summary>
	///       Replaces all cell's text with a new string.
	///       </summary>
	/// <param name="oldString">Old string value.</param>
	/// <param name="newString">New string value.</param>
	public int Replace(string oldString, string newString)
	{
		int num = 0;
		for (int i = 0; i < cells_0.Rows.Count; i++)
		{
			Row rowByIndex = cells_0.Rows.GetRowByIndex(i);
			for (int j = 0; j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.method_20() == Enum199.const_6 && cellByIndex.StringValue.IndexOf(oldString) != -1)
				{
					cellByIndex.PutValue(cellByIndex.StringValue.Replace(oldString, newString));
					num++;
				}
			}
		}
		return num;
	}

	[SpecialName]
	internal int[] method_39()
	{
		return int_4;
	}

	/// <summary>
	///       Removes all drawing objects in this worksheet.
	///       </summary>
	public void RemoveAllDrawingObjects()
	{
		if (pictureCollection_0 != null)
		{
			pictureCollection_0.Clear();
		}
		if (commentCollection_0 != null)
		{
			commentCollection_0.Clear();
		}
		if (chartCollection_0 != null)
		{
			chartCollection_0.method_7();
		}
		if (textBoxCollection_0 != null)
		{
			textBoxCollection_0.Clear();
		}
		if (checkBoxCollection_0 != null)
		{
			checkBoxCollection_0.Clear();
		}
		if (oleObjectCollection_0 != null)
		{
			oleObjectCollection_0.Clear();
		}
		if (shapeCollection_0 != null)
		{
			shapeCollection_0.Clear();
		}
	}

	/// <summary>
	///       Gets selected ranges of cells in the designer spreadsheet.
	///       </summary>
	/// <returns>An <see cref="T:System.Collections.ArrayList" /> which contains selected ranges.</returns>
	public ArrayList GetSelectedRanges()
	{
		if (class1733_0 != null && class1733_0.Count != 0)
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < class1733_0.Count; i++)
			{
				Class1732 @class = (Class1732)class1733_0[i];
				for (int j = 0; j < @class.method_3().Count; j++)
				{
					CellArea cellArea = (CellArea)@class.method_3()[j];
					Range value = cells_0.CreateRange(cellArea.StartRow, cellArea.StartColumn, cellArea.EndRow - cellArea.StartRow + 1, cellArea.EndColumn - cellArea.StartColumn + 1);
					arrayList.Add(value);
				}
			}
			return arrayList;
		}
		return null;
	}

	internal void method_40(int int_6)
	{
		if (int_6 >= 64)
		{
			internalColor_0.method_3(bool_0: true);
		}
		else
		{
			internalColor_0.SetColor(ColorType.IndexedColor, int_6);
		}
	}

	[SpecialName]
	internal int method_41()
	{
		if (internalColor_0.method_2())
		{
			return 64;
		}
		bool found = false;
		return internalColor_0.method_0(worksheetCollection_0, 64, out found);
	}

	[SpecialName]
	internal Color method_42()
	{
		if (int_5 >= 64)
		{
			return Color.Empty;
		}
		return worksheetCollection_0.method_24().GetColor(int_5);
	}

	[SpecialName]
	internal void method_43(Color color_0)
	{
		int num = worksheetCollection_0.method_24().method_2(color_0);
		if (num == -1)
		{
			throw new CellsException(ExceptionType.InvalidData, "This color is not in the palette. Please add it to palette first.");
		}
		int_5 = num;
	}

	[SpecialName]
	internal int method_44()
	{
		return int_5;
	}

	[SpecialName]
	internal void method_45(int int_6)
	{
		int_5 = int_6;
	}

	/// <summary>
	///       Clears all comments in designer spreadsheet.
	///       </summary>
	public void ClearComments()
	{
		if (commentCollection_0 != null)
		{
			commentCollection_0.Clear();
		}
	}

	internal void method_46(string string_2)
	{
		string_1 = string_2;
	}

	internal string method_47()
	{
		return string_1;
	}

	[SpecialName]
	internal void method_48(ArrayList arrayList_4)
	{
		arrayList_2 = arrayList_4;
	}

	/// <summary>
	///       Sets worksheet background image.
	///       </summary>
	/// <param name="pictureData">Picture data.</param>
	public void SetBackground(byte[] pictureData)
	{
		arrayList_2 = null;
		byte_1 = pictureData;
	}

	internal object method_49()
	{
		if (arrayList_2 != null)
		{
			return arrayList_2;
		}
		return byte_1;
	}

	[SpecialName]
	internal ArrayList method_50()
	{
		return arrayList_3;
	}

	[SpecialName]
	internal void method_51(ArrayList arrayList_4)
	{
		arrayList_3 = arrayList_4;
	}

	internal CustomPropertyCollection method_52()
	{
		return customPropertyCollection_0;
	}

	/// <summary>
	///       Get automatic page breaks.
	///       </summary>
	/// <param name="options">The print options</param>
	/// <returns>The automatic page breaks.</returns>
	/// <remarks>
	///       Each cell area represents a paper.
	///       </remarks>
	public CellArea[] GetPrintingPageBreaks(ImageOrPrintOptions options)
	{
		Class1241 @class = new Class1241(method_2().Workbook);
		@class.method_9(this, options);
		CellArea[] array = new CellArea[@class.arrayList_2.Count];
		for (int i = 0; i < @class.arrayList_2.Count; i++)
		{
			Class1623 class2 = (Class1623)@class.arrayList_2[i];
			array[i] = default(CellArea);
			array[i].StartRow = class2.struct88_0.int_0;
			array[i].StartColumn = class2.struct88_0.int_1;
			array[i].EndRow = class2.struct88_0.int_2;
			array[i].EndColumn = class2.struct88_0.int_3;
		}
		return array;
	}

	internal SmartTagSetting method_53()
	{
		return smartTagSetting_0;
	}

	/// <summary>
	///       Returns a string represents the current Worksheet object.
	///       </summary>
	/// <returns>
	/// </returns>
	public override string ToString()
	{
		return $"Aspose.Cells.Worksheet[ {Name} ]";
	}

	/// <summary>
	///       Calculates a formula.
	///       </summary>
	/// <param name="formula">
	/// </param>
	/// <returns>
	/// </returns>
	public object CalculateFormula(string formula)
	{
		Cell cell = new Cell(0, 0, cells_0);
		cell.method_40(formula);
		Class1658 @class = new Class1658(method_2().Workbook);
		@class.method_0(Enum47.const_1);
		return @class.method_3(cell);
	}

	/// <summary>
	///       Calculates all formulas in this worksheet.
	///       </summary>
	/// <param name="recursive">True means if the worksheet' cells depend on the cells of other worksheets,
	///        the dependant cells in other worksheets will be calculated too.
	///        False means all the formulas in the worksheet have been calculated and the values are right.</param>
	/// <param name="ignoreError">Indicates if hide the error in calculating formulas.
	///       The error may be unsupported function, external links, etc.</param>
	/// <param name="customFunction">The custom formula calculation functions to extend the calculation engine.</param>
	public void CalculateFormula(bool recursive, bool ignoreError, ICustomFunction customFunction)
	{
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			RowCollection rows = worksheetCollection_0[i].Cells.Rows;
			byte b = 0;
			if (i != Index && !recursive)
			{
				b = 2;
			}
			for (int j = 0; j < rows.Count; j++)
			{
				Row row = rows.method_4(j);
				for (int k = 0; k < row.method_0(); k++)
				{
					Cell cellByIndex = row.GetCellByIndex(k);
					if (cellByIndex.IsFormula)
					{
						cellByIndex.method_61(b);
					}
				}
			}
		}
		Class1658 @class = new Class1658(worksheetCollection_0.Workbook);
		@class.method_5(ignoreError, customFunction);
		RowCollection rows2 = cells_0.Rows;
		for (int l = 0; l < rows2.Count; l++)
		{
			Row row2 = rows2.method_4(l);
			for (int m = 0; m < row2.method_0(); m++)
			{
				Cell cellByIndex2 = row2.GetCellByIndex(m);
				if (cellByIndex2.method_20() != Enum199.const_4 || cellByIndex2.method_60() == 2)
				{
					continue;
				}
				try
				{
					Class1661 class2 = worksheetCollection_0.Formula.method_10(cellByIndex2);
					if (class2 != null)
					{
						cellByIndex2.method_61(1);
						object obj = @class.method_2(class2, cellByIndex2);
						if (cellByIndex2.method_62())
						{
							cellByIndex2.method_63(bool_0: false);
							cellByIndex2.method_61(2);
						}
						else if (cellByIndex2.IsArrayHeader)
						{
							Class1379.smethod_0(obj, cellByIndex2);
						}
						else
						{
							cellByIndex2.method_66(obj, 2);
						}
					}
				}
				catch (Exception exception_)
				{
					if (!ignoreError)
					{
						throw new CellsException(ExceptionType.Formula, Class1183.smethod_0(exception_) + "\nError in calculating cell " + cellByIndex2.Name + " in Worksheet " + Name);
					}
				}
			}
		}
	}
}
