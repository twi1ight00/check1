using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells.Markup;
using ns14;
using ns16;
using ns2;
using ns47;

namespace Aspose.Cells;

/// <summary>
///       Represents all seetings of the workbook.
///       </summary>
public class WorkbookSettings
{
	private Workbook workbook_0;

	private Class516 class516_0;

	internal short short_0 = 1200;

	internal bool bool_0;

	private bool bool_1;

	private Palette palette_0;

	private bool bool_2;

	internal bool bool_3;

	private bool bool_4;

	internal byte byte_0 = 2;

	private bool bool_5;

	private DisplayDrawingObjects displayDrawingObjects_0;

	private bool bool_6;

	private int int_0 = 100;

	private double double_0 = 0.001;

	private CalcModeType calcModeType_0;

	private string string_0 = "145621";

	private int int_1 = 500;

	private bool bool_7;

	private bool bool_8 = true;

	private bool bool_9 = true;

	private short short_1 = 600;

	private bool bool_10 = true;

	private bool bool_11 = true;

	private CountryCode countryCode_0;

	private Encoding encoding_0 = Encoding.Default;

	internal bool bool_12 = true;

	private string string_1;

	private bool bool_13 = true;

	private bool bool_14;

	private ushort ushort_0;

	private bool bool_15;

	private Hashtable hashtable_0;

	private bool bool_16;

	private bool bool_17;

	private bool bool_18 = true;

	private int int_2 = 1048575;

	private int int_3 = 16383;

	internal bool bool_19;

	private bool bool_20 = true;

	private SmartTagOptions smartTagOptions_0;

	private string string_2 = "Arial";

	private ushort ushort_1 = 200;

	private ushort ushort_2 = 9225;

	private ushort ushort_3 = 14940;

	private ushort ushort_4 = 120;

	private ushort ushort_5 = 240;

	private bool bool_21 = true;

	internal bool bool_22;

	internal bool bool_23;

	private bool bool_24 = true;

	private bool bool_25 = true;

	private Class1551 class1551_0;

	/// <summary>
	///       Gets or sets a value which represents if the workbook uses the 1904 date system.
	///       </summary>
	public bool Date1904
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
			class516_0.Date1904 = value;
		}
	}

	/// <summary>
	///       Gets the protection type of the workbook.
	///       </summary>
	public ProtectionType ProtectionType => workbook_0.Worksheets.ProtectionType;

	/// <summary>
	///       True if calculations in this workbook will be done using only the precision of the numbers as they're displayed
	///       </summary>
	public bool PrecisionAsDisplayed
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
	///       Indicates whether re-calculate all formulas on opening file.
	///       </summary>
	public bool ReCalculateOnOpen
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
		}
	}

	public bool CreateCalcChain
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
	///       Indicates whether re-calculate all formulas on opening file.
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use WorkbookSettings.ReCalculateOnOpen property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[Obsolete("Use WorkbookSettings.ReCalculateOnOpen property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool ReCalcOnOpen
	{
		get
		{
			return (byte_0 & 2) != 0;
		}
		set
		{
			ReCalculateOnOpen = value;
		}
	}

	/// <summary>
	///       Indicates whether and how to show objects in the workbook.
	///       </summary>
	public DisplayDrawingObjects DisplayDrawingObjects
	{
		get
		{
			return displayDrawingObjects_0;
		}
		set
		{
			displayDrawingObjects_0 = value;
		}
	}

	/// <summary>
	///       Indicates if Aspose.Cells will use iteration to resolve circular references.
	///       </summary>
	public bool Iteration
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
	///       Returns or sets the maximum number of iterations that Aspose.Cells can use to resolve a circular reference.
	///       </summary>
	public int MaxIteration
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	/// <summary>
	///       Returns or sets the maximum number of change that Microsoft Excel can use to resolve a circular reference.
	///       </summary>
	public double MaxChange
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
	///       It specifies whether to calculate formulas manually,
	///       automatically or automatically except for multiple table operations.
	///       </summary>
	public CalcModeType CalcMode
	{
		get
		{
			return calcModeType_0;
		}
		set
		{
			calcModeType_0 = value;
		}
	}

	public string CalculationId
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public int CalcStackSize
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

	/// <summary>
	///       Indicates whether to recalculate before saving the document.
	///       </summary>
	public bool RecalculateBeforeSave
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

	public int SheetTabBarWidth
	{
		get
		{
			return short_1;
		}
		set
		{
			short_1 = (short)value;
		}
	}

	/// <summary>
	///       Get or sets a value whether the Workbook tabs are displayed.
	///       </summary>
	/// <remarks>The default value is true.</remarks>
	/// <example>The following code hides the Sheet Tabs and Tab Scrolling Buttons for the spreadsheet.
	///       <code>
	///       [C#]
	///       // Hide the spreadsheet tabs.
	///       workbook.ShowTabs = false;
	///
	///       [Visual Basic]
	///       ' Hide the spreadsheet tabs.
	///       workbook.ShowTabs = False
	///       </code></example>
	public bool ShowTabs
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
	///       Gets or sets the first visible worksheet tab.
	///       </summary>
	public int FirstVisibleTab
	{
		get
		{
			return workbook_0.Worksheets.FirstVisibleTab;
		}
		set
		{
			workbook_0.Worksheets.FirstVisibleTab = value;
		}
	}

	/// <summary>
	///       Gets or sets a value indicating whether the generated spreadsheet will contain a horizontal scroll bar.
	///       </summary>
	/// <remarks>The default value is true.</remarks>
	/// <example>
	///       The following code makes the horizontal scroll bar invisible for the spreadsheet.
	///       <code>
	///       [C#]
	///       // Hide the horizontal scroll bar of the Excel file.
	///       workbook.IsHScrollBarVisible = false;
	///
	///       [Visual Basic]
	///       ' Hide the horizontal scroll bar of the Excel file.
	///       workbook.IsHScrollBarVisible = False
	///       </code></example>
	public bool IsHScrollBarVisible
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
	///        Gets or sets a value indicating whether the generated spreadsheet will contain a vertical scroll bar.
	///        </summary>
	/// <remarks>The default value is true.</remarks>
	/// <example>The following code makes the vertical scroll bar invisible for the spreadsheet.
	///        <code>
	///        [C#]
	///       	// Hide the vertical scroll bar of the Excel file.
	///        workbook.IsVScrollBarVisible = false;
	///
	///        [Visual Basic]
	///        ' Hide the vertical scroll bar of the Excel file.
	///        workbook.IsVScrollBarVisible = False
	///       </code></example>
	public bool IsVScrollBarVisible
	{
		get
		{
			return bool_11;
		}
		set
		{
			bool_11 = value;
		}
	}

	/// <summary>
	///       Gets or sets a value that indicates whether the Workbook is shared. 
	///       </summary>
	/// <remarks>The default value is false.</remarks>
	public bool Shared
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	/// <summary>
	///       Gets or sets the user interface language of the Workbook version based on CountryCode that has saved the file. 
	///       </summary>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use WorkbookSettings.LanguageCode property. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use WorkbookSettings.LanguageCode property instead.")]
	public CountryCode Language
	{
		get
		{
			return countryCode_0;
		}
		set
		{
			countryCode_0 = value;
		}
	}

	/// <summary>
	///       Gets or sets the user interface language of the Workbook version based on CountryCode that has saved the file. 
	///       </summary>
	public CountryCode LanguageCode
	{
		get
		{
			return countryCode_0;
		}
		set
		{
			countryCode_0 = value;
		}
	}

	/// <summary>
	///       Gets or sets the system regional settings based on CountryCode at the time the file was saved. 
	///       </summary>
	/// <remarks>If you do not want to use the region  saved in the file, 
	///       please reset it after reading the file.</remarks>
	public CountryCode Region
	{
		get
		{
			return class516_0.Region;
		}
		set
		{
			class516_0.Region = value;
		}
	}

	/// <summary>
	///       Gets or sets the system culture info.
	///       </summary>
	/// <remarks>
	///       Returns null if culture info is not set and <see cref="P:Aspose.Cells.WorkbookSettings.Region" /> is not set. 
	///       </remarks>
	public CultureInfo CultureInfo
	{
		get
		{
			return class516_0.CultureInfo;
		}
		set
		{
			class516_0.CultureInfo = value;
		}
	}

	/// <summary>
	///       Gets and sets the default encoding.Only applies for csv file.
	///       </summary>
	public Encoding Encoding
	{
		get
		{
			return encoding_0;
		}
		set
		{
			encoding_0 = value;
			bool_12 = false;
		}
	}

	/// <summary>
	///       Represents Workbook file encryption password.
	///       </summary>
	public string Password
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
			if (workbook_0.Worksheets != null)
			{
				workbook_0.Worksheets.method_29(null);
			}
		}
	}

	/// <summary>
	///       Gets or sets a value that indicates whether the string in text file is converted to numeric data.
	///       </summary>
	/// <remarks>
	///       NOTE: This member is now obsolete. Instead, 
	///       please use TxtLoadOptions.ConvertNumericData property.
	///       This property will be removed 12 months later since December 2011. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use TxtLoadOptions.ConvertNumericData property instead.")]
	[Browsable(false)]
	public bool ConvertNumericData
	{
		get
		{
			return bool_13;
		}
		set
		{
			bool_13 = value;
		}
	}

	/// <summary>
	///       Indicates if the Read Only Recommended option is selected.
	///       </summary>
	public bool RecommendReadOnly
	{
		get
		{
			return bool_15;
		}
		set
		{
			bool_15 = value;
			if (value)
			{
				IsWriteProtected = true;
			}
		}
	}

	/// <summary>
	///       Indicates whether this workbook is write protected.
	///       </summary>
	public bool IsWriteProtected
	{
		get
		{
			return bool_14;
		}
		set
		{
			bool_14 = value;
		}
	}

	/// <summary>
	///       Sets the proected password to modify the file.
	///       </summary>
	public string WriteProtectedPassword
	{
		set
		{
			if (value != null && !(value == ""))
			{
				ushort_0 = (ushort)Class1652.smethod_0(value);
				bool_14 = true;
			}
			else
			{
				ushort_0 = 0;
				bool_14 = false;
			}
		}
	}

	/// <summary>
	///       Gets a value that indicates whether the Workbook is protected. 
	///       </summary>
	public bool IsProtected => workbook_0.Worksheets.IsProtected;

	public bool IsMinimized
	{
		get
		{
			return bool_16;
		}
		set
		{
			bool_16 = value;
		}
	}

	public bool IsHidden
	{
		get
		{
			return bool_17;
		}
		set
		{
			bool_17 = value;
		}
	}

	/// <summary>
	///       Indicates whether parsing the formula when reading the file.
	///       </summary>
	/// <remarks>
	///       Only applies for Excel Xlsx,Xltx, Xltm,Xlsm file
	///       because the formulas in the files are stored with a string formula.
	///       </remarks>
	public bool ParsingFormulaOnOpen
	{
		get
		{
			return bool_20;
		}
		set
		{
			bool_20 = value;
		}
	}

	public double WindowLeft
	{
		get
		{
			return (double)method_12() / 20.0;
		}
		set
		{
			method_13((int)(value * 20.0 + 0.5));
		}
	}

	/// <summary>
	///       The distance from the left edge of the client area to the left edge of the window.
	///       In unit of inch.
	///       </summary>
	public double WindowLeftInch
	{
		get
		{
			return (float)method_12() / 1440f;
		}
		set
		{
			method_13((int)(value * 20.0 * 72.0 + 0.5));
		}
	}

	/// <summary>
	///       The distance from the left edge of the client area to the left edge of the window.
	///       In unit of centimeter.
	///       </summary>
	public double WindowLeftCM
	{
		get
		{
			return WindowLeftInch * 2.54;
		}
		set
		{
			WindowLeftInch = value / 2.54;
		}
	}

	public double WindowTop
	{
		get
		{
			return (double)method_14() / 20.0;
		}
		set
		{
			method_15((int)(value * 20.0 + 0.5));
		}
	}

	/// <summary>
	///       The distance from the top edge of the client area to the top edge of the window,in unit of inch.
	///       </summary>
	public double WindowTopInch
	{
		get
		{
			return (float)method_14() / 1440f;
		}
		set
		{
			method_15((int)(value * 20.0 * 72.0 + 0.5));
		}
	}

	/// <summary>
	///       The distance from the top edge of the client area to the top edge of the window,in unit of centimeter.
	///       </summary>
	public double WindowTopCM
	{
		get
		{
			return WindowTopInch * 2.54;
		}
		set
		{
			WindowTopInch = value / 2.54;
		}
	}

	public double WindowWidth
	{
		get
		{
			return (double)method_16() / 20.0;
		}
		set
		{
			method_17((int)(value * 20.0 + 0.5));
		}
	}

	/// <summary>
	///       The width of the window,in unit of inch.
	///       </summary>
	public double WindowWidthInch
	{
		get
		{
			return (float)method_16() / 1440f;
		}
		set
		{
			method_17((int)(value * 20.0 * 72.0 + 0.5));
		}
	}

	/// <summary>
	///       The width of the window,in unit of centimeter.
	///       </summary>
	public double WindowWidthCM
	{
		get
		{
			return WindowWidthInch * 2.54;
		}
		set
		{
			WindowWidthInch = value / 2.54;
		}
	}

	public double WindowHeight
	{
		get
		{
			return (double)method_18() / 20.0;
		}
		set
		{
			method_19((int)(value * 20.0 + 0.5));
		}
	}

	/// <summary>
	///       The height of the window,in unit of inch.
	///       </summary>
	public double WindowHeightInch
	{
		get
		{
			return (float)method_18() / 1440f;
		}
		set
		{
			method_19((int)(value * 20.0 * 72.0 + 0.5));
		}
	}

	/// <summary>
	///       The height of the window,in unit of centimeter.
	///       </summary>
	public double WindowHeightCM
	{
		get
		{
			return WindowHeightInch * 2.54;
		}
		set
		{
			WindowHeightInch = value / 2.54;
		}
	}

	public bool UpdateAdjacentCellsBorder
	{
		get
		{
			return bool_21;
		}
		set
		{
			bool_21 = value;
		}
	}

	public bool CheckComptiliblity
	{
		get
		{
			return bool_24;
		}
		set
		{
			bool_24 = value;
		}
	}

	public bool CheckExcelRestriction
	{
		get
		{
			return bool_25;
		}
		set
		{
			bool_25 = value;
		}
	}

	public string BuildVersion
	{
		get
		{
			return method_21().string_3;
		}
		set
		{
			method_21().string_3 = value;
		}
	}

	internal string StandardFont
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	internal double StandardFontSize
	{
		set
		{
			ushort_1 = (ushort)(value * 20.0 + 0.5);
		}
	}

	[SpecialName]
	internal Palette method_0()
	{
		return palette_0;
	}

	internal WorkbookSettings(Workbook workbook_1, CountryCode countryCode_1)
	{
		workbook_0 = workbook_1;
		palette_0 = new Palette();
		class516_0 = new Class516(countryCode_1);
		class516_0.method_2(new Class508(palette_0));
		class516_0.Date1904 = bool_2;
		bool_14 = false;
		ushort_0 = 0;
		string_1 = null;
		new Class1462(bool_0: false);
	}

	[SpecialName]
	internal bool method_1()
	{
		return bool_7;
	}

	[SpecialName]
	internal void method_2(bool bool_26)
	{
		bool_7 = bool_26;
	}

	[SpecialName]
	internal Class516 method_3()
	{
		return class516_0;
	}

	[SpecialName]
	internal ushort method_4()
	{
		return ushort_0;
	}

	[SpecialName]
	internal void method_5(ushort ushort_6)
	{
		ushort_0 = ushort_6;
		IsWriteProtected = true;
	}

	[SpecialName]
	internal Hashtable method_6()
	{
		if (hashtable_0 == null)
		{
			hashtable_0 = new Hashtable();
			hashtable_0.Add("CG Times (W1)", "Times New Roman");
			hashtable_0.Add("CG Times", "Times New Roman");
		}
		return hashtable_0;
	}

	[SpecialName]
	internal bool method_7()
	{
		return bool_18;
	}

	[SpecialName]
	internal void method_8(bool bool_26)
	{
		bool_18 = bool_26;
	}

	internal void Copy(WorkbookSettings workbookSettings_0)
	{
		bool_18 = workbookSettings_0.bool_18;
		short_1 = workbookSettings_0.short_1;
		ushort_5 = workbookSettings_0.ushort_5;
		ushort_4 = workbookSettings_0.ushort_4;
		ushort_3 = workbookSettings_0.ushort_3;
		ushort_2 = workbookSettings_0.ushort_2;
		bool_17 = workbookSettings_0.bool_17;
		bool_16 = workbookSettings_0.bool_16;
		bool_10 = workbookSettings_0.bool_10;
		bool_11 = workbookSettings_0.bool_11;
		bool_1 = workbookSettings_0.bool_1;
		palette_0.Copy(workbookSettings_0.palette_0);
		short_0 = workbookSettings_0.short_0;
		bool_20 = workbookSettings_0.bool_20;
		bool_13 = workbookSettings_0.bool_13;
		bool_14 = workbookSettings_0.bool_14;
		ushort_0 = workbookSettings_0.ushort_0;
		RecommendReadOnly = workbookSettings_0.RecommendReadOnly;
		string_1 = workbookSettings_0.string_1;
		bool_2 = workbookSettings_0.bool_2;
		bool_4 = workbookSettings_0.bool_4;
		displayDrawingObjects_0 = workbookSettings_0.displayDrawingObjects_0;
		byte_0 = workbookSettings_0.byte_0;
		bool_6 = workbookSettings_0.bool_6;
		double_0 = workbookSettings_0.double_0;
		int_0 = workbookSettings_0.int_0;
		calcModeType_0 = workbookSettings_0.calcModeType_0;
		class516_0.Copy(workbookSettings_0.class516_0);
		countryCode_0 = workbookSettings_0.countryCode_0;
		encoding_0 = workbookSettings_0.encoding_0;
		bool_12 = workbookSettings_0.bool_12;
		int_2 = workbookSettings_0.int_2;
		int_3 = workbookSettings_0.int_3;
		if (workbookSettings_0.smartTagOptions_0 != null)
		{
			smartTagOptions_0 = new SmartTagOptions();
			smartTagOptions_0.Copy(workbookSettings_0.smartTagOptions_0);
		}
	}

	[SpecialName]
	internal SmartTagOptions method_9()
	{
		if (smartTagOptions_0 == null)
		{
			smartTagOptions_0 = new SmartTagOptions();
		}
		return smartTagOptions_0;
	}

	internal SmartTagOptions method_10()
	{
		return smartTagOptions_0;
	}

	[SpecialName]
	internal ushort method_11()
	{
		return ushort_1;
	}

	[SpecialName]
	internal int method_12()
	{
		return ushort_5;
	}

	[SpecialName]
	internal void method_13(int int_4)
	{
		ushort_5 = (ushort)int_4;
	}

	[SpecialName]
	internal int method_14()
	{
		return ushort_4;
	}

	[SpecialName]
	internal void method_15(int int_4)
	{
		ushort_4 = (ushort)int_4;
	}

	[SpecialName]
	internal int method_16()
	{
		return ushort_3;
	}

	[SpecialName]
	internal void method_17(int int_4)
	{
		ushort_3 = (ushort)int_4;
	}

	[SpecialName]
	internal int method_18()
	{
		return ushort_2;
	}

	[SpecialName]
	internal void method_19(int int_4)
	{
		ushort_2 = (ushort)int_4;
	}

	internal void method_20(FileFormatType fileFormatType_0, Enum187 enum187_0, bool bool_26)
	{
		if (bool_26)
		{
			switch (enum187_0)
			{
			case Enum187.const_0:
				int_3 = 255;
				int_2 = 65535;
				break;
			case Enum187.const_1:
				int_3 = 16383;
				int_2 = 1048575;
				break;
			}
			return;
		}
		bool_9 = true;
		short_1 = 600;
		bool_17 = false;
		bool_16 = false;
		bool_10 = true;
		bool_11 = true;
		bool_1 = false;
		ushort_2 = 9225;
		ushort_3 = 14940;
		ushort_4 = 120;
		ushort_5 = 240;
		palette_0 = new Palette();
		bool_19 = false;
		bool_14 = false;
		ushort_0 = 0;
		RecommendReadOnly = false;
		bool_2 = false;
		bool_4 = false;
		displayDrawingObjects_0 = DisplayDrawingObjects.DisplayShapes;
		byte_0 = 2;
		bool_6 = false;
		double_0 = 0.001;
		int_0 = 100;
		calcModeType_0 = CalcModeType.Automatic;
		smartTagOptions_0 = null;
		switch (fileFormatType_0)
		{
		case FileFormatType.Excel97:
		case FileFormatType.Excel2000:
		case FileFormatType.ExcelXP:
		case FileFormatType.Default:
			method_3().CultureInfo = null;
			LanguageCode = CountryCode.Default;
			break;
		}
	}

	[SpecialName]
	internal Class1551 method_21()
	{
		if (class1551_0 == null)
		{
			class1551_0 = new Class1551(bool_0: true);
		}
		return class1551_0;
	}

	[SpecialName]
	internal void method_22(Class1551 class1551_1)
	{
		class1551_0 = class1551_1;
	}

	internal Class1551 method_23()
	{
		return class1551_0;
	}
}
