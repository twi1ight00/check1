using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web;
using Aspose.Cells.Charts;
using Aspose.Cells.Pivot;
using Aspose.Cells.Properties;
using Aspose.Cells.Tables;
using ns11;
using ns16;
using ns2;
using ns22;
using ns27;
using ns29;
using ns30;
using ns45;
using ns52;
using ns56;
using ns57;

namespace Aspose.Cells;

/// <summary>
///       Encapsulates a collection of <see cref="T:Aspose.Cells.Worksheet" /> objects.
///       </summary>
/// <example>
///   <code>
///       [C#]
///
///       Workbook workbook = new Workbook();
///
///       WorksheetCollection sheets = workbook.Worksheets;
///
///       //Add a worksheet
///       sheets.Add();
///
///       //Change the name of a worksheet
///       sheets[0].Name = "First Sheet";
///
///       //Set the active sheet to the second worksheet
///       sheets.SetActiveSheet(1);
///
///
///       [Visual Basic]
///
///       Dim excel as Workbook = new Workbook()
///
///       Dim sheets as WorksheetCollection = excel.Worksheets
///
///       'Add a worksheet
///       sheets.Add()
///
///       'Change the name of a worksheet
///       sheets(0).Name = "First Sheet"
///
///       'Set the active sheet to the second worksheet
///       sheets.SetActiveSheet(1)
///       </code>
/// </example>
public class WorksheetCollection : CollectionBase
{
	private bool bool_0;

	private int int_0 = 1024;

	private object object_0;

	private Class1659 class1659_0;

	private Class1667 class1667_0;

	private Hashtable hashtable_0;

	private FileFormatType fileFormatType_0 = FileFormatType.Xlsx;

	private NameCollection nameCollection_0;

	private ushort ushort_0;

	private Class1317 class1317_0;

	private bool bool_1;

	private string string_0;

	private byte byte_0;

	private ArrayList arrayList_0;

	private int int_1;

	internal Class1301 class1301_0;

	private int int_2;

	private int int_3;

	internal static readonly Guid guid_0 = new Guid("00020820-0000-0000-c000-000000000046");

	private Class1647 class1647_0;

	private Class1638 class1638_0;

	private Class1118 class1118_0;

	private StyleCollection styleCollection_0;

	private int int_4;

	private Class1303 class1303_0;

	private ushort ushort_1;

	private Class1379 class1379_0;

	internal Class1658 class1658_0;

	private Class1734 class1734_0;

	private ArrayList arrayList_1;

	private ArrayList arrayList_2;

	private Class1337 class1337_0;

	private Class1683 class1683_0;

	private int int_5;

	private Style style_0;

	private XmlMapCollection xmlMapCollection_0;

	private BuiltInDocumentPropertyCollection builtInDocumentPropertyCollection_0;

	private CustomDocumentPropertyCollection customDocumentPropertyCollection_0;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9;

	private int int_10;

	private object object_1;

	private bool bool_2;

	private bool bool_3;

	private ushort ushort_2;

	private ExternalLinkCollection externalLinkCollection_0;

	private Class1703 class1703_0;

	private Class1703 class1703_1;

	private Class1142 class1142_0;

	private Workbook workbook_0;

	private TableStyleCollection tableStyleCollection_0;

	private Class1283 class1283_0;

	internal int int_11;

	private string string_1;

	/// <summary>
	///       Gets whether hide the field list for the PivotTable.
	///       </summary>
	public bool HidePivotFieldList
	{
		get
		{
			if (method_50() == null || method_50().method_7() == null)
			{
				method_49();
			}
			return (method_50().method_7()[16] & 2) != 0;
		}
		set
		{
			if (method_50() == null || method_50().method_7() == null)
			{
				method_49();
			}
			byte b = method_50().method_7()[16];
			b = (byte)(b & 0xFDu);
			b = (byte)(b | (byte)(value ? 2u : 0u));
			method_50().method_7()[16] = b;
		}
	}

	/// <summary>
	///       Indicates whether refresh all connections on opening file in MS Excel.
	///       </summary>
	public bool IsRefreshAllConnections
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
	///       Gets the collection of all the Name objects in the spreadsheet. 
	///       </summary>
	public NameCollection Names => nameCollection_0;

	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.Worksheet" /> element at the specified index.
	///        </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public Worksheet this[int index] => (Worksheet)base.InnerList[index];

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.Worksheet" /> element with the specified name.
	///       </summary>
	/// <param name="sheetName">Worksheet name</param>
	/// <returns>The element with the specified name.</returns>
	public Worksheet this[string sheetName]
	{
		get
		{
			int num = 0;
			Worksheet worksheet;
			while (true)
			{
				if (num < base.InnerList.Count)
				{
					worksheet = (Worksheet)base.InnerList[num];
					if (worksheet.Name.ToUpper() == sheetName.ToUpper())
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return worksheet;
		}
	}

	/// <summary>
	///       Indicates if http compression is to be used in user's IIS.
	///       </summary>
	/// <remarks>Please specify this property to true if http compression is used.</remarks>
	[Obsolete("Use SaveOptions.EnableHTTPCompression property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public bool EnableHTTPCompression
	{
		get
		{
			return Workbook.SaveOptions.bool_6;
		}
		set
		{
			Workbook.SaveOptions.bool_6 = value;
		}
	}

	/// <summary>
	///       Represents the index of active worksheet when the spreadsheet is opened.
	///       </summary>
	/// <remarks>Sheet index is zero based.</remarks>
	public int ActiveSheetIndex
	{
		get
		{
			return int_1;
		}
		set
		{
			if (value >= 0 && value < base.Count)
			{
				int_1 = value;
				if (value - 5 >= 0)
				{
					int_5 = value - 5;
					for (int i = int_5; i < base.Count; i++)
					{
						if (this[i].IsVisible)
						{
							int_5 = i;
							break;
						}
					}
				}
			}
			for (int j = 0; j < base.Count; j++)
			{
				if (value != j)
				{
					this[j].IsSelected = false;
				}
				else
				{
					this[j].IsSelected = true;
				}
			}
		}
	}

	/// <summary>
	///       Represents whether the generated spreadsheet will be opened Minimized.
	///       </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use Workbook.Settings.IsMinimized property instead.")]
	public bool IsMinimized
	{
		get
		{
			return Workbook.Settings.IsMinimized;
		}
		set
		{
			Workbook.Settings.IsMinimized = value;
		}
	}

	/// <summary>
	///       Indicates whether this workbook is hidden.
	///       </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Workbook.Settings.IsHidden property instead.")]
	public bool IsHidden
	{
		get
		{
			return Workbook.Settings.IsHidden;
		}
		set
		{
			Workbook.Settings.IsHidden = value;
		}
	}

	[Obsolete("Use Workbook.Settings.WindowLeft property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public double WindowLeft
	{
		get
		{
			return (double)Workbook.Settings.method_12() / 20.0;
		}
		set
		{
			Workbook.Settings.method_13((int)(value * 20.0 + 0.5));
		}
	}

	/// <summary>
	///       The distance from the left edge of the client area to the left edge of the window.
	///       In unit of inch.
	///       </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use Workbook.Settings.WindowLeftInch property instead.")]
	public double WindowLeftInch
	{
		get
		{
			return (float)Workbook.Settings.method_12() / 1440f;
		}
		set
		{
			Workbook.Settings.method_13((int)(value * 20.0 * 72.0 + 0.5));
		}
	}

	/// <summary>
	///       The distance from the left edge of the client area to the left edge of the window.
	///       In unit of centimeter.
	///       </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Workbook.Settings.WindowLeftCM property instead.")]
	public double WindowLeftCM
	{
		get
		{
			return Workbook.Settings.WindowLeftInch * 2.54;
		}
		set
		{
			Workbook.Settings.WindowLeftInch = value / 2.54;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use Workbook.Settings.WindowTop property instead.")]
	public double WindowTop
	{
		get
		{
			return (double)Workbook.Settings.method_14() / 20.0;
		}
		set
		{
			Workbook.Settings.method_15((int)(value * 20.0 + 0.5));
		}
	}

	/// <summary>
	///       The distance from the top edge of the client area to the top edge of the window,in unit of inch.
	///       </summary>
	[Obsolete("Use Workbook.Settings.WindowTopInch property instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public double WindowTopInch
	{
		get
		{
			return (float)Workbook.Settings.method_14() / 1440f;
		}
		set
		{
			Workbook.Settings.method_15((int)(value * 20.0 * 72.0 + 0.5));
		}
	}

	/// <summary>
	///       The distance from the top edge of the client area to the top edge of the window,in unit of centimeter.
	///       </summary>
	[Obsolete("Use Workbook.Settings.WindowTopCM property instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public double WindowTopCM
	{
		get
		{
			return Workbook.Settings.WindowTopInch * 2.54;
		}
		set
		{
			Workbook.Settings.WindowTopInch = value / 2.54;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use Workbook.Settings.WindowWidth property instead.")]
	public double WindowWidth
	{
		get
		{
			return (double)Workbook.Settings.method_16() / 20.0;
		}
		set
		{
			Workbook.Settings.method_17((int)(value * 20.0 + 0.5));
		}
	}

	/// <summary>
	///       The width of the window,in unit of inch.
	///       </summary>
	[Browsable(false)]
	[Obsolete("Use Workbook.Settings.WindowWidthInch property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public double WindowWidthInch
	{
		get
		{
			return (float)Workbook.Settings.method_16() / 1440f;
		}
		set
		{
			Workbook.Settings.method_17((int)(value * 20.0 * 72.0 + 0.5));
		}
	}

	/// <summary>
	///       The width of the window,in unit of centimeter.
	///       </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use Workbook.Settings.WindowWidthCM property instead.")]
	public double WindowWidthCM
	{
		get
		{
			return Workbook.Settings.WindowWidthInch * 2.54;
		}
		set
		{
			Workbook.Settings.WindowWidthInch = value / 2.54;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Workbook.Settings.WindowHeight property instead.")]
	public double WindowHeight
	{
		get
		{
			return (double)Workbook.Settings.method_18() / 20.0;
		}
		set
		{
			Workbook.Settings.method_19((int)(value * 20.0 + 0.5));
		}
	}

	/// <summary>
	///       The height of the window,in unit of inch.
	///       </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Workbook.Settings.WindowHeightInch property instead.")]
	public double WindowHeightInch
	{
		get
		{
			return (float)Workbook.Settings.method_18() / 1440f;
		}
		set
		{
			Workbook.Settings.method_19((int)(value * 20.0 * 72.0 + 0.5));
		}
	}

	/// <summary>
	///       The height of the window,in unit of centimeter.
	///       </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Workbook.Settings.WindowHeightCM property instead.")]
	[Browsable(false)]
	public double WindowHeightCM
	{
		get
		{
			return Workbook.Settings.WindowHeightInch * 2.54;
		}
		set
		{
			Workbook.Settings.WindowHeightInch = value / 2.54;
		}
	}

	/// <summary>
	///       Width of worksheet tab bar (in 1/1000 of window width).
	///       </summary>
	[Obsolete("Use Workbook.Settings.SheetTabBarWidth property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public int SheetTabBarWidth
	{
		get
		{
			return Workbook.Settings.SheetTabBarWidth;
		}
		set
		{
			Workbook.Settings.SheetTabBarWidth = value;
		}
	}

	public XmlMapCollection XmlMaps
	{
		get
		{
			if (xmlMapCollection_0 == null)
			{
				xmlMapCollection_0 = new XmlMapCollection();
			}
			return xmlMapCollection_0;
		}
		set
		{
			xmlMapCollection_0 = value;
		}
	}

	/// <summary>
	///       Returns a DocumentProperties collection that represents all the built-in document properties of the spreadsheet. 
	///       </summary>
	/// <remarks>A new property cannot be added to built-in document properties list. You can only get a built-in property and change its value.
	///       The following is the built-in properties name list:
	///       <p>Title</p><p>Subject</p><p>Author</p><p>Keywords</p><p>Comments</p><p>Template</p><p>Last Author</p><p>Revision Number</p><p>Application Name</p><p>Last Print Date</p><p>Creation Date</p><p>Last Save Time</p><p>Total Editing Time</p><p>Number of Pages</p><p>Number of Words</p><p>Number of Characters</p><p>Security</p><p>Category</p><p>Format</p><p>Manager</p><p>Company</p><p>Number of Bytes</p><p>Number of Lines</p><p>Number of Paragraphs</p><p>Number of Slides</p><p>Number of Notes</p><p>Number of Hidden Slides</p><p>Number of Multimedia Clips</p></remarks>
	/// <example>
	///   <code>
	///       [C#]
	///       DocumentProperty doc = workbook.Worksheets.BuiltInDocumentProperties["Author"];
	///       doc.Value = "John Smith";
	///
	///       [Visual Basic]
	///       Dim doc as DocumentProperty = workbook.Worksheets.BuiltInDocumentProperties("Author")
	///       doc.Value = "John Smith"
	///       </code>
	/// </example>
	public BuiltInDocumentPropertyCollection BuiltInDocumentProperties
	{
		get
		{
			if (builtInDocumentPropertyCollection_0 == null)
			{
				builtInDocumentPropertyCollection_0 = new BuiltInDocumentPropertyCollection();
				customDocumentPropertyCollection_0 = new CustomDocumentPropertyCollection(this);
				Class778.smethod_0(class1317_0, builtInDocumentPropertyCollection_0, customDocumentPropertyCollection_0);
			}
			return builtInDocumentPropertyCollection_0;
		}
	}

	/// <summary>
	///       Returns a DocumentProperties collection that represents all the custom document properties of the spreadsheet. 
	///       </summary>
	/// <example>
	///   <code>
	///       [C#]
	///       excel.Worksheets.CustomDocumentProperties.Add("Checked by", "Jane");
	///
	///       [Visual Basic]
	///       excel.Worksheets.CustomDocumentProperties.Add("Checked by", "Jane")
	///       </code>
	/// </example>
	public CustomDocumentPropertyCollection CustomDocumentProperties
	{
		get
		{
			if (customDocumentPropertyCollection_0 == null)
			{
				customDocumentPropertyCollection_0 = new CustomDocumentPropertyCollection(this);
				builtInDocumentPropertyCollection_0 = new BuiltInDocumentPropertyCollection();
				Class778.smethod_0(class1317_0, builtInDocumentPropertyCollection_0, customDocumentPropertyCollection_0);
			}
			return customDocumentPropertyCollection_0;
		}
	}

	/// <summary>
	///       Gets and Sets displayed size when Workbook file is used as an Ole object.
	///       </summary>
	/// <remarks>
	///       Null means no ole size setting.
	///       </remarks>
	public object OleSize
	{
		get
		{
			return object_1;
		}
		set
		{
			object_1 = value;
		}
	}

	/// <summary>
	///       Represents external links in a workbook.
	///       </summary>
	public ExternalLinkCollection ExternalLinks => externalLinkCollection_0;

	/// <summary>
	///       Gets <see cref="P:Aspose.Cells.WorksheetCollection.TableStyles" /> object.
	///       </summary>
	public TableStyleCollection TableStyles
	{
		get
		{
			if (tableStyleCollection_0 == null)
			{
				tableStyleCollection_0 = new TableStyleCollection(this);
			}
			return tableStyleCollection_0;
		}
	}

	internal string CodeName => string_0;

	internal bool HasMacro => (byte_0 & 1) != 0;

	internal Workbook Workbook => workbook_0;

	internal StyleCollection Styles => styleCollection_0;

	internal Class1379 Formula => class1379_0;

	internal int FirstVisibleTab
	{
		get
		{
			return int_5;
		}
		set
		{
			int_5 = value;
		}
	}

	internal Style DefaultStyle
	{
		get
		{
			if (style_0 == null)
			{
				style_0 = new Style(this);
				style_0.GetStyle(this, 15);
			}
			return style_0;
		}
		set
		{
			style_0 = value;
			class1683_0[15] = value;
			Style style = class1683_0[0];
			style.Copy(value);
			arrayList_1[0] = style.Font;
			style.method_11(bool_0: false);
			style.method_16(byte.MaxValue);
			style.method_13(4095);
			method_74();
		}
	}

	internal Font DefaultFont => class1683_0[15].Font;

	internal ProtectionType ProtectionType
	{
		get
		{
			if (bool_3)
			{
				if (bool_2)
				{
					return ProtectionType.All;
				}
				return ProtectionType.Structure;
			}
			if (bool_2)
			{
				return ProtectionType.Windows;
			}
			return ProtectionType.None;
		}
	}

	internal bool IsProtected
	{
		get
		{
			if (!bool_3)
			{
				return bool_2;
			}
			return true;
		}
	}

	internal string Author
	{
		get
		{
			if (string_1 == null)
			{
				string_1 = Class1182.smethod_0();
			}
			return string_1;
		}
	}

	[SpecialName]
	internal int method_0()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_1(int int_12)
	{
		int_0 = int_12;
	}

	[SpecialName]
	internal object method_2()
	{
		return object_0;
	}

	[SpecialName]
	internal void method_3(object object_2)
	{
		object_0 = object_2;
	}

	[SpecialName]
	internal Class1659 method_4()
	{
		if (class1659_0 == null)
		{
			class1659_0 = new Class1659(this);
		}
		return class1659_0;
	}

	[SpecialName]
	internal Class1667 method_5()
	{
		if (class1667_0 == null)
		{
			class1667_0 = new Class1667(this);
		}
		return class1667_0;
	}

	[SpecialName]
	internal Hashtable method_6()
	{
		if (hashtable_0 == null)
		{
			hashtable_0 = new Hashtable();
			for (int i = 0; i < base.Count; i++)
			{
				hashtable_0.Add(this[i].Name.ToUpper(), new int[2]
				{
					i,
					class1118_0.method_8(int_4, i)
				});
			}
		}
		return hashtable_0;
	}

	internal void method_7()
	{
		hashtable_0 = null;
	}

	[SpecialName]
	internal ushort method_8()
	{
		return ushort_0;
	}

	[SpecialName]
	internal void method_9(ushort ushort_3)
	{
		ushort_0 = ushort_3;
	}

	[SpecialName]
	internal Class1317 method_10()
	{
		return class1317_0;
	}

	[SpecialName]
	internal void method_11(Class1317 class1317_1)
	{
		class1317_0 = class1317_1;
	}

	internal Stream method_12()
	{
		Workbook workbook = workbook_0;
		if (workbook.class1558_0 != null && workbook.class1558_0.string_0 != null && workbook.class1558_0.class1553_0 != null)
		{
			workbook.class1558_0.class1553_0.method_1();
			Class746 class746_ = workbook.class1558_0.class1553_0.class746_0;
			Class744 @class = class746_.method_38(workbook.class1558_0.string_0);
			if (@class == null)
			{
				return null;
			}
			Stream stream_ = class746_.method_39(@class);
			MemoryStream memoryStream = new MemoryStream();
			Class936.smethod_0(stream_, memoryStream);
			return memoryStream;
		}
		return null;
	}

	internal Stream method_13()
	{
		if (class1317_0 != null)
		{
			Class1319 @class = class1317_0.method_9().method_0("_VBA_PROJECT_CUR");
			if (@class == null)
			{
				return null;
			}
			Class1317 class2 = new Class1317(@class);
			MemoryStream memoryStream = new MemoryStream();
			class2.Save(memoryStream);
			memoryStream.Position = 0L;
			return memoryStream;
		}
		return null;
	}

	[SpecialName]
	internal bool method_14()
	{
		return bool_1;
	}

	[SpecialName]
	internal void method_15(bool bool_4)
	{
		bool_1 = bool_4;
	}

	internal void method_16(string string_2)
	{
		string_0 = string_2;
	}

	[SpecialName]
	internal void method_17(string string_2)
	{
		string_0 = string_2;
	}

	[SpecialName]
	internal void method_18(bool bool_4)
	{
		if (bool_4)
		{
			byte_0 |= 1;
		}
		else
		{
			byte_0 &= 254;
		}
	}

	[SpecialName]
	internal bool method_19()
	{
		return (byte_0 & 2) != 0;
	}

	[SpecialName]
	internal void method_20(bool bool_4)
	{
		if (bool_4)
		{
			byte_0 |= 2;
		}
		else
		{
			byte_0 &= 253;
		}
	}

	[SpecialName]
	internal ArrayList method_21()
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		return arrayList_0;
	}

	internal ArrayList method_22()
	{
		return arrayList_0;
	}

	/// <summary>
	///       Deletes a defined name in the workbook.
	///       </summary>
	/// <param name="definedName">Defined name.</param>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Names.Remove() method. 
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Names.Remove() method instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void DeleteName(string definedName)
	{
		int num = 0;
		if (definedName.IndexOf("!") != -1)
		{
			string[] array = definedName.Split('!');
			string text = array[0];
			definedName = array[1];
			for (int i = 0; i < base.InnerList.Count; i++)
			{
				Worksheet worksheet = (Worksheet)base.InnerList[i];
				if (worksheet.Name.ToUpper() == text.ToUpper())
				{
					num = i + 1;
					break;
				}
			}
		}
		int num2 = 0;
		Name name;
		while (true)
		{
			if (num2 < nameCollection_0.Count)
			{
				name = nameCollection_0[num2];
				if (name.Text == definedName)
				{
					break;
				}
				num2++;
				continue;
			}
			return;
		}
		if (num == name.SheetIndex)
		{
			name.method_33();
		}
	}

	internal void Copy(WorksheetCollection worksheetCollection_0)
	{
		hashtable_0 = null;
		int_8 = worksheetCollection_0.int_8;
		int_6 = worksheetCollection_0.int_6;
		int_7 = worksheetCollection_0.int_7;
		ushort_0 = worksheetCollection_0.ushort_0;
		bool_2 = worksheetCollection_0.bool_2;
		bool_3 = worksheetCollection_0.bool_3;
		ushort_2 = worksheetCollection_0.ushort_2;
		bool_1 = worksheetCollection_0.bool_1;
		string_0 = worksheetCollection_0.string_0;
		byte_0 = worksheetCollection_0.byte_0;
		fileFormatType_0 = worksheetCollection_0.fileFormatType_0;
		if (worksheetCollection_0.class1734_0 != null)
		{
			class1734_0 = new Class1734();
			class1734_0.Copy(worksheetCollection_0.class1734_0);
		}
		else
		{
			class1734_0 = null;
		}
		if (worksheetCollection_0.class1703_0 != null)
		{
			class1703_0 = new Class1703(this, Enum181.const_0);
			class1703_0.Copy(worksheetCollection_0.class1703_0);
		}
		else
		{
			class1703_0 = null;
		}
		if (worksheetCollection_0.class1703_1 != null)
		{
			class1703_1 = new Class1703(this, Enum181.const_1);
			class1703_1.Copy(worksheetCollection_0.class1703_1);
		}
		else
		{
			class1703_1 = null;
		}
		ushort_1 = worksheetCollection_0.ushort_1;
		int_2 = worksheetCollection_0.int_2;
		int_3 = worksheetCollection_0.int_3;
		int_1 = worksheetCollection_0.int_1;
		int_5 = worksheetCollection_0.int_5;
		for (int i = 0; i < worksheetCollection_0.arrayList_1.Count; i++)
		{
			Font font = new Font(this, null, bool_0: false);
			Font font2 = (Font)worksheetCollection_0.arrayList_1[i];
			font.Copy(font2);
			font.method_22(font2.method_21());
			arrayList_1.Add(font);
		}
		for (int j = 0; j < worksheetCollection_0.arrayList_2.Count; j++)
		{
			Class639 @class = new Class639();
			Class639 class639_ = (Class639)worksheetCollection_0.arrayList_2[j];
			@class.Copy(class639_);
			arrayList_2.Add(@class);
		}
		class1683_0.Copy(worksheetCollection_0.class1683_0);
		if (worksheetCollection_0.styleCollection_0.Count > 0)
		{
			styleCollection_0.Copy(worksheetCollection_0.styleCollection_0);
		}
		for (int k = 0; k < worksheetCollection_0.method_56().Count; k++)
		{
			Style style = new Style(this);
			Style style2 = worksheetCollection_0.method_56()[k];
			style.Copy(style2);
			method_56().Add(style);
		}
		if (worksheetCollection_0.class1303_0 != null && worksheetCollection_0.class1303_0.Count > 0)
		{
			if (class1303_0 == null)
			{
				class1303_0 = new Class1303();
			}
			for (int l = 0; l < worksheetCollection_0.class1303_0.Count; l++)
			{
				Class1718 class1718_ = worksheetCollection_0.class1303_0[l];
				Class1718 class2 = new Class1718();
				class2.Copy(class1718_);
				class1303_0.Add(class2);
			}
		}
		base.InnerList.Clear();
		nameCollection_0.Copy(worksheetCollection_0.nameCollection_0);
		for (int m = 0; m < worksheetCollection_0.InnerList.Count; m++)
		{
			Worksheet worksheet = (Worksheet)worksheetCollection_0.InnerList[m];
			method_38(worksheet.Name);
		}
		class1118_0.Copy(worksheetCollection_0.class1118_0);
		int_4 = worksheetCollection_0.int_4;
		CopyOptions copyOptions = new CopyOptions(bool_6: true);
		for (int n = 0; n < worksheetCollection_0.InnerList.Count; n++)
		{
			Worksheet sourceSheet = (Worksheet)worksheetCollection_0.InnerList[n];
			Worksheet worksheet2 = this[n];
			copyOptions.CopyNames = false;
			worksheet2.Copy(sourceSheet, copyOptions);
		}
		class1317_0 = worksheetCollection_0.class1317_0;
	}

	[SpecialName]
	internal FileFormatType method_23()
	{
		return fileFormatType_0;
	}

	[SpecialName]
	internal Palette method_24()
	{
		return workbook_0.Settings.method_0();
	}

	internal WorksheetCollection(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
		nameCollection_0 = new NameCollection(this);
		int_2 = 1;
		styleCollection_0 = new StyleCollection(this);
		class1379_0 = new Class1379(this);
		arrayList_1 = new ArrayList();
		arrayList_2 = new ArrayList();
		class1683_0 = new Class1683(this);
		method_57(new Class1337(this));
		class1683_0.method_9();
		method_74();
		class1301_0 = new Class1301();
		Worksheet value = new Worksheet(class1301_0, this, "Sheet1")
		{
			IsSelected = true
		};
		base.InnerList.Add(value);
		class1118_0 = new Class1118();
		class1118_0.method_2(0, 0, 0);
		externalLinkCollection_0 = new ExternalLinkCollection(this);
		class1303_0 = new Class1303();
		Class1718 class1718_ = new Class1718(Enum194.const_1);
		class1303_0.Add(class1718_);
		ushort_2 = 0;
		bool_2 = false;
		bool_3 = false;
	}

	internal int method_25(string string_2)
	{
		int num = 0;
		while (true)
		{
			if (num < base.InnerList.Count)
			{
				Worksheet worksheet = (Worksheet)base.InnerList[num];
				if (worksheet.Name.ToUpper() == string_2.ToUpper())
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	internal void method_26()
	{
		if (Class972.smethod_0() != 0)
		{
			return;
		}
		if (base.Count < 65535)
		{
			Worksheet worksheet = new Worksheet(class1301_0, this);
			string text;
			bool flag;
			do
			{
				int_2++;
				text = "Sheet" + int_2;
				flag = false;
				for (int i = 0; i < base.Count; i++)
				{
					string name = this[i].Name;
					if (name == text)
					{
						flag = true;
					}
				}
			}
			while (flag);
			worksheet.method_7(text);
			int num2 = (worksheet.SheetIndex = base.InnerList.Add(worksheet));
			hashtable_0 = null;
			int num3 = 0;
			if (class1303_0 != null && class1303_0.Count != 0)
			{
				bool flag2 = false;
				for (int j = 0; j < class1303_0.Count; j++)
				{
					Class1718 @class = class1303_0[j];
					if (@class.method_12())
					{
						num3 = j;
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					num3 = class1303_0.Count;
				}
			}
			class1118_0.method_2((ushort)num3, (ushort)num2, (ushort)num2);
			Class1677.smethod_36(worksheet);
			return;
		}
		throw new CellsException(ExceptionType.Limitation, "Too much worksheet objects.");
	}

	internal void method_27()
	{
		int num = -1;
		for (int i = 0; i < base.Count; i++)
		{
			if (this[i].IsVisible)
			{
				num = i;
				break;
			}
		}
		if (num == -1)
		{
			throw new CellsException(ExceptionType.Limitation, "A workbook must contain at least a visible worksheet");
		}
		if (!this[ActiveSheetIndex].IsVisible)
		{
			ActiveSheetIndex = num;
		}
		method_60();
		method_68();
		if (workbook_0.SaveOptions.SortNames)
		{
			nameCollection_0.Sort();
		}
		else
		{
			nameCollection_0.method_16();
		}
		class1301_0.method_1(this);
		for (int j = 0; j < base.Count; j++)
		{
			Worksheet worksheet = this[j];
			if (workbook_0.SaveOptions.ValidateMergedAreas)
			{
				worksheet.Cells.method_5();
			}
			worksheet.ListObjects.UpdateColumnName();
			if (worksheet.conditionalFormattingCollection_0 != null)
			{
				worksheet.conditionalFormattingCollection_0.method_7();
			}
		}
	}

	[SpecialName]
	internal Class1647 method_28()
	{
		return class1647_0;
	}

	[SpecialName]
	internal void method_29(Class1647 class1647_1)
	{
		class1647_0 = class1647_1;
	}

	internal void Decrypt(string string_2)
	{
		Workbook.Settings.Password = null;
		method_29(null);
		if (ProtectionType != ProtectionType.None && method_81() != 0 && class1647_0 == null)
		{
			class1647_0 = Class1677.smethod_39();
		}
	}

	[SpecialName]
	internal Class1638 method_30()
	{
		return class1638_0;
	}

	[SpecialName]
	internal void method_31(Class1638 class1638_1)
	{
		class1638_0 = class1638_1;
	}

	/// <summary>
	///       Gets the worksheet by the code name.
	///       </summary>
	/// <param name="codeName">Worksheet code name.</param>
	/// <returns>The element with the specified code name.</returns>
	public Worksheet GetSheetByCodeName(string codeName)
	{
		codeName = codeName.ToUpper();
		int num = 0;
		Worksheet worksheet;
		while (true)
		{
			if (num < base.InnerList.Count)
			{
				worksheet = (Worksheet)base.InnerList[num];
				if (worksheet.CodeName != null && worksheet.CodeName.ToUpper() == codeName)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return worksheet;
	}

	internal static void smethod_0(HttpResponse httpResponse_0, ContentDisposition contentDisposition_0, string string_2, FileFormatType fileFormatType_1, long long_0, bool bool_4)
	{
		httpResponse_0.Clear();
		switch (fileFormatType_1)
		{
		case FileFormatType.CSV:
			httpResponse_0.ContentType = "application/csv";
			break;
		case FileFormatType.Xlsx:
		case FileFormatType.Xlsm:
		case FileFormatType.Xltx:
		case FileFormatType.Xltm:
			httpResponse_0.ContentType = "application/xlsx";
			break;
		case FileFormatType.TabDelimited:
			httpResponse_0.ContentType = "application/txt";
			break;
		default:
			httpResponse_0.ContentType = "application/vnd.ms-excel";
			break;
		case FileFormatType.Pdf:
			httpResponse_0.ContentType = "application/pdf";
			break;
		case FileFormatType.ODS:
			httpResponse_0.ContentType = "application/ods";
			break;
		}
		int num = string_2.LastIndexOf('\\');
		if (num >= 0)
		{
			throw new Exception("filename should not contain path");
		}
		if (bool_4)
		{
			HttpCachePolicy cache = httpResponse_0.Cache;
			cache.SetExpires(DateTime.Now - TimeSpan.FromMinutes(1.0));
			cache.SetCacheability(HttpCacheability.Private);
			httpResponse_0.AddHeader("pragma", "no-cache");
		}
		httpResponse_0.AddHeader("Content-Length", long_0.ToString());
		if (contentDisposition_0 == ContentDisposition.Attachment)
		{
			httpResponse_0.AddHeader("content-disposition", "attachment;  filename=\"" + string_2 + "\"");
		}
		else
		{
			httpResponse_0.AddHeader("content-disposition", "inline; filename=\"" + string_2 + "\"");
		}
	}

	[SpecialName]
	internal Class1118 method_32()
	{
		return class1118_0;
	}

	internal void method_33(int int_12)
	{
		int_1 = int_12;
	}

	/// <summary>
	///       Sorts defined names.
	///       </summary>
	/// <remarks>If you create a large amount of named ranges in the Excel file, 
	///       please call this method after all named ranges are created and before saving </remarks>
	public void SortNames()
	{
		Names.Sort();
	}

	internal void method_34(int int_12)
	{
		int_1 = int_12;
	}

	internal void method_35()
	{
		int_2 = 0;
		int_3 = 0;
		class1734_0 = new Class1734();
		base.InnerList.Clear();
		style_0 = null;
		class1118_0 = new Class1118();
		method_61();
		class1303_0.Clear();
	}

	/// <summary>
	///       Insert a worksheet.
	///       </summary>
	/// <param name="index">The sheet index</param>
	/// <param name="sheetType">The sheet type.</param>
	/// <returns>Returns an inserted worksheet.</returns>
	public Worksheet Insert(int index, SheetType sheetType)
	{
		hashtable_0 = null;
		string text;
		bool flag;
		do
		{
			int_2++;
			text = "Sheet" + int_2;
			flag = false;
			for (int i = 0; i < base.Count; i++)
			{
				string name = this[i].Name;
				if (name.ToUpper() == text.ToUpper())
				{
					flag = true;
				}
			}
		}
		while (flag);
		return Insert(index, sheetType, text);
	}

	/// <summary>
	///       Insert a worksheet.
	///       </summary>
	/// <param name="index">The sheet index</param>
	/// <param name="sheetType">The sheet type.</param>
	/// <param name="sheetName">The sheet name.</param>
	/// <returns>Returns an inserted worksheet.</returns>
	public Worksheet Insert(int index, SheetType sheetType, string sheetName)
	{
		hashtable_0 = null;
		Worksheet worksheet = null;
		if (index >= base.Count)
		{
			worksheet = Add(sheetName);
			worksheet.Type = sheetType;
			return worksheet;
		}
		worksheet = new Worksheet(class1301_0, this, sheetName);
		worksheet.method_6(sheetName);
		base.InnerList.Insert(index, worksheet);
		class1118_0.method_5(int_4, index, base.Count);
		Names.method_13(index);
		for (int i = 0; i < base.Count; i++)
		{
			Worksheet worksheet2 = this[i];
			worksheet2.SheetIndex = i;
		}
		ActiveSheetIndex = worksheet.SheetIndex;
		return worksheet;
	}

	/// <summary>
	///       Adds a worksheet to the collection.
	///       </summary>
	/// <param name="type">Worksheet type.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Worksheet" /> object index.</returns>
	/// <example>
	///   <code>
	///       [C#]
	///       Workbook workbook = new Workbook();
	///       workbook.Worksheets.Add(SheetType.Chart);
	///       Cells cells = workbook.Worksheets[0].Cells;
	///       cells["c2"].PutValue(5000);
	///       cells["c3"].PutValue(3000);
	///       cells["c4"].PutValue(4000);
	///       cells["c5"].PutValue(5000);
	///       cells["c6"].PutValue(6000);
	///       Charts charts = workbook.Worksheets[1].Charts;
	///       int chartIndex = charts.Add(ChartType.Column, 10,10,20,20);
	///       Chart chart = charts[chartIndex];
	///       chart.NSeries.Add("Sheet1!C2:C6", true);
	///
	///       [Visual Basic]
	///       Dim workbook As Workbook =  New Workbook() 
	///       workbook.Worksheets.Add(SheetType.Chart)
	///       Dim cells As Cells = workbook.Worksheets(0).Cells 
	///       cells("c2").PutValue(5000)
	///       cells("c3").PutValue(3000)
	///       cells("c4").PutValue(4000)
	///       cells("c5").PutValue(5000)
	///       cells("c6").PutValue(6000)
	///       Dim charts As Charts = workbook.Worksheets(1).Charts
	///       Dim chartIndex As Integer = charts.Add(ChartType.Column,10,10,20,20) 
	///       Dim chart As Chart = charts(chartIndex) 
	///       chart.NSeries.Add("Sheet1!C2:C6", True)
	///       </code>
	/// </example>
	public int Add(SheetType type)
	{
		switch (type)
		{
		default:
			throw new CellsException(ExceptionType.InvalidData, "Invalid worksheet type specified.");
		case SheetType.Worksheet:
			return Add();
		case SheetType.Chart:
			if (base.Count < 65535)
			{
				Worksheet worksheet = new Worksheet(class1301_0, this);
				string text;
				bool flag;
				do
				{
					int_3++;
					text = "Chart" + int_3;
					flag = false;
					for (int i = 0; i < base.Count; i++)
					{
						string name = this[i].Name;
						if (name == text)
						{
							flag = true;
						}
					}
				}
				while (flag);
				worksheet.method_7(text);
				int num = base.InnerList.Add(worksheet);
				worksheet.Type = SheetType.Chart;
				hashtable_0 = null;
				class1118_0.method_2((ushort)int_4, (ushort)num, (ushort)num);
				return num;
			}
			throw new CellsException(ExceptionType.Limitation, "Too much worksheet objects.");
		}
	}

	[SpecialName]
	internal int method_36()
	{
		return int_4;
	}

	[SpecialName]
	internal void method_37(int int_12)
	{
		int_4 = int_12;
	}

	internal void Move(int int_12, int int_13)
	{
		if (int_13 >= 0 && int_13 <= base.InnerList.Count - 1)
		{
			hashtable_0 = null;
			Worksheet value = this[int_12];
			if (int_13 > int_12)
			{
				base.InnerList.Insert(int_13 + 1, value);
				base.InnerList.RemoveAt(int_12);
			}
			else
			{
				base.InnerList.Insert(int_13, value);
				base.InnerList.RemoveAt(int_12 + 1);
			}
			nameCollection_0.method_14(int_12, int_13);
			class1118_0.method_6(int_4, int_12, int_13);
			return;
		}
		throw new ArgumentException();
	}

	public void SwapSheet(int sheetIndex1, int sheetIndex2)
	{
		if (sheetIndex1 < 0 || sheetIndex1 >= base.InnerList.Count || sheetIndex2 < 0 || sheetIndex2 >= base.InnerList.Count)
		{
			throw new ArgumentException();
		}
		Worksheet worksheet = this[sheetIndex1];
		Worksheet worksheet2 = this[sheetIndex2];
		worksheet.Move(sheetIndex2);
		worksheet2.Move(sheetIndex1);
	}

	/// <summary>
	///       Adds a worksheet to the collection.
	///       </summary>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Worksheet" /> object index.</returns>
	public int Add()
	{
		if (base.Count < 65535)
		{
			Worksheet worksheet = new Worksheet(class1301_0, this);
			string text;
			bool flag;
			do
			{
				int_2++;
				text = "Sheet" + int_2;
				flag = false;
				for (int i = 0; i < base.Count; i++)
				{
					string name = this[i].Name;
					if (name.ToUpper() == text.ToUpper())
					{
						flag = true;
					}
				}
			}
			while (flag);
			worksheet.method_7(text);
			int num = base.InnerList.Add(worksheet);
			hashtable_0 = null;
			int num2 = 0;
			if (class1303_0 != null && class1303_0.Count != 0)
			{
				bool flag2 = false;
				for (int j = 0; j < class1303_0.Count; j++)
				{
					Class1718 @class = class1303_0[j];
					if (@class.method_12())
					{
						num2 = j;
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					num2 = class1303_0.Count;
				}
			}
			class1118_0.method_2((ushort)num2, (ushort)num, (ushort)num);
			return num;
		}
		throw new CellsException(ExceptionType.Limitation, "Too much worksheet objects.");
	}

	/// <summary>
	///       Adds a worksheet to the collection.
	///       </summary>
	/// <param name="sheetName">Worksheet name</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Worksheet" /> object.</returns>
	public Worksheet Add(string sheetName)
	{
		int index = Add();
		this[index].Name = sheetName;
		hashtable_0 = null;
		return this[index];
	}

	internal int method_38(string string_2)
	{
		int num = Add();
		this[num].method_7(string_2);
		hashtable_0 = null;
		return num;
	}

	[SpecialName]
	internal Class1303 method_39()
	{
		return class1303_0;
	}

	[SpecialName]
	internal void method_40(Class1303 class1303_1)
	{
		class1303_0 = class1303_1;
	}

	[SpecialName]
	internal ushort method_41()
	{
		return ushort_1;
	}

	[SpecialName]
	internal void method_42(ushort ushort_3)
	{
		ushort_1 = ushort_3;
	}

	[SpecialName]
	internal Class1658 method_43()
	{
		if (class1658_0 == null)
		{
			class1658_0 = new Class1658(Workbook);
		}
		return class1658_0;
	}

	internal void method_44()
	{
		if (class1658_0 != null)
		{
			class1658_0.Clear();
		}
	}

	/// <summary>
	///       Removes the element at a specified name.
	///       </summary>
	/// <param name="name">The name of the element to remove.</param>
	public void RemoveAt(string name)
	{
		name = name.ToUpper();
		int num = 0;
		while (true)
		{
			if (num < base.InnerList.Count)
			{
				Worksheet worksheet = (Worksheet)base.InnerList[num];
				if (worksheet.Name.ToUpper() == name)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		RemoveAt(num);
	}

	/// <summary>
	///       Removes the element at a specified index.
	///       </summary>
	/// <param name="index">The index value of the element to remove.</param>
	public new void RemoveAt(int index)
	{
		hashtable_0 = null;
		int[] array = new int[method_89().Count];
		for (int i = 0; i < base.Count; i++)
		{
			if (i == index)
			{
				continue;
			}
			PivotTableCollection pivotTableCollection_ = this[i].pivotTableCollection_0;
			if (pivotTableCollection_ == null)
			{
				continue;
			}
			for (int j = 0; j < pivotTableCollection_.Count; j++)
			{
				PivotTable pivotTable = pivotTableCollection_[j];
				for (int k = 0; k < method_89().Count; k++)
				{
					if (pivotTable.class1141_0 == method_89()[k])
					{
						array[k]++;
					}
				}
			}
		}
		for (int l = 0; l < array.Length; l++)
		{
			if (array[l] == 0)
			{
				method_89().RemoveAt(l);
			}
		}
		int num = 0;
		if (class1303_0 != null && class1303_0.Count != 0)
		{
			for (int m = 0; m < class1303_0.Count; m++)
			{
				Class1718 @class = class1303_0[m];
				if (@class.method_12())
				{
					num = m;
					break;
				}
			}
		}
		for (int n = 0; n < base.InnerList.Count; n++)
		{
			_ = this[n];
			RowCollection rows = this[n].Cells.Rows;
			if (n != index)
			{
				continue;
			}
			for (int num2 = 0; num2 < rows.Count; num2++)
			{
				Row rowByIndex = rows.GetRowByIndex(num2);
				for (int num3 = 0; num3 < rowByIndex.method_0(); num3++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(num3);
					if (cellByIndex.method_20() == Enum199.const_6)
					{
						class1301_0.method_10(cellByIndex.method_57(), cellByIndex);
					}
				}
			}
		}
		class1118_0.method_4((ushort)index, num);
		base.InnerList.RemoveAt(index);
		nameCollection_0.method_12(index);
		if (workbook_0.class1558_0 != null)
		{
			workbook_0.class1558_0.method_8();
		}
		for (int num4 = index; num4 < base.Count; num4++)
		{
			this[num4].SheetIndex = num4;
		}
		if (base.Count == 0)
		{
			int_1 = 0;
		}
		else if (int_1 > base.Count - 1)
		{
			int_1 = base.Count - 1;
		}
		if (base.Count == 0)
		{
			int_5 = 0;
		}
		else if (int_5 > base.Count - 1)
		{
			int_5 = base.Count - 1;
		}
	}

	/// <summary>
	///       Clear all worksheets.
	///       </summary>
	/// <remarks>
	///       A workbook must contains a worksheet.
	///       </remarks>
	public new void Clear()
	{
		base.InnerList.Clear();
	}

	internal Style method_45(int int_12)
	{
		return class1683_0[int_12];
	}

	internal string method_46(int int_12)
	{
		int num = arrayList_2.Count - 1;
		Class639 @class;
		while (true)
		{
			if (num >= 0)
			{
				@class = (Class639)arrayList_2[num];
				if (int_12 == @class.Index)
				{
					break;
				}
				num--;
				continue;
			}
			return "";
		}
		return @class.Custom;
	}

	internal Class639 method_47(int int_12)
	{
		int num = arrayList_2.Count - 1;
		Class639 @class;
		while (true)
		{
			if (num >= 0)
			{
				@class = (Class639)arrayList_2[num];
				if (int_12 == @class.Index)
				{
					break;
				}
				num--;
				continue;
			}
			return null;
		}
		return @class;
	}

	/// <summary>
	///       Adds a worksheet to the collection and copies data from an existed worksheet.
	///       </summary>
	/// <param name="sheetName">Name of source worksheet.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Worksheet" /> object index.</returns>
	/// <exception cref="T:Aspose.Cells.CellsException">Specifies an invalid worksheet name.</exception>
	public int AddCopy(string sheetName)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				if (this[num].Name == sheetName)
				{
					break;
				}
				num++;
				continue;
			}
			throw new CellsException(ExceptionType.SheetName, "Invalid worksheet name.");
		}
		return AddCopy(num);
	}

	/// <summary>
	///       Adds a worksheet to the collection and copies data from an existed worksheet.
	///       </summary>
	/// <param name="sheetIndex">Index of source worksheet.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Worksheet" /> object index.</returns>
	public int AddCopy(int sheetIndex)
	{
		if (sheetIndex < 0 || sheetIndex > base.InnerList.Count - 1)
		{
			throw new ArgumentOutOfRangeException("Invalid sheet index.");
		}
		Workbook.method_3();
		int num = Add();
		Worksheet worksheet = this[num];
		Worksheet sourceSheet = (Worksheet)base.InnerList[sheetIndex];
		worksheet.Copy(sourceSheet);
		return num;
	}

	internal void Combine(WorksheetCollection worksheetCollection_0)
	{
		hashtable_0 = null;
		int count = base.Count;
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			string name = worksheetCollection_0[i].Name;
			if (this[name] == null)
			{
				method_38(name);
			}
			else
			{
				Add();
			}
		}
		Hashtable hashtable = new Hashtable();
		int num = method_32().method_10(method_36(), 65535, 65535);
		if (num == -1)
		{
			num = method_32().method_3((ushort)method_36(), ushort.MaxValue, ushort.MaxValue);
		}
		int[] array = worksheetCollection_0.method_32().method_9(worksheetCollection_0.method_36(), -1);
		for (int j = 0; j < array.Length; j++)
		{
			hashtable.Add(array[j], num);
		}
		for (int k = 0; k < worksheetCollection_0.Count; k++)
		{
			int num2 = k + count;
			array = worksheetCollection_0.method_32().method_9(worksheetCollection_0.method_36(), k);
			int num3 = method_32().method_8(method_36(), num2);
			for (int l = 0; l < array.Length; l++)
			{
				hashtable.Add(array[l], num3);
			}
		}
		Hashtable hashtable2 = new Hashtable();
		method_48(count, worksheetCollection_0, hashtable, num, hashtable2);
		CopyOptions copyOptions = new CopyOptions(bool_6: false);
		copyOptions.CopyNames = false;
		copyOptions.hashtable_4 = hashtable;
		copyOptions.hashtable_1 = hashtable2;
		for (int m = 0; m < worksheetCollection_0.Count; m++)
		{
			this[m + count].Copy(worksheetCollection_0[m], copyOptions);
		}
	}

	internal void method_48(int int_12, WorksheetCollection worksheetCollection_0, Hashtable hashtable_1, int int_13, Hashtable hashtable_2)
	{
		if (worksheetCollection_0.nameCollection_0 == null || worksheetCollection_0.nameCollection_0.Count <= 0)
		{
			return;
		}
		Hashtable hashtable = new Hashtable();
		hashtable.Add(-1, -1);
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			int num = i + int_12;
			hashtable.Add(i, num);
		}
		for (int j = 0; j < worksheetCollection_0.nameCollection_0.Count; j++)
		{
			Name name = worksheetCollection_0.nameCollection_0[j];
			int num2 = name.SheetIndex - 1;
			string text = name.Text;
			if (num2 == -1 && Names.method_8(text, num2, bool_0: false) != -1)
			{
				int num3 = name.method_24();
				if (num3 >= 0 && num3 < worksheetCollection_0.Count && num3 != num2)
				{
					num2 = num3;
				}
				else
				{
					text += "_1";
				}
			}
			int num4 = -1;
			if (num2 != -1)
			{
				num4 = (int)hashtable[num2];
			}
			int num5 = Names.method_0(num4, text);
			Name name2 = Names[num5];
			name2.method_30(name, hashtable_1, int_13);
			hashtable_2.Add(j, num5);
		}
	}

	internal void method_49()
	{
		if (class1734_0 == null)
		{
			class1734_0 = new Class1734();
		}
		if (class1734_0.method_7() == null)
		{
			class1734_0.method_8(new byte[21]
			{
				99, 8, 0, 0, 0, 0, 0, 0, 0, 0,
				0, 0, 21, 0, 0, 0, 0, 0, 0, 0,
				30
			});
		}
	}

	[SpecialName]
	internal Class1734 method_50()
	{
		return class1734_0;
	}

	[SpecialName]
	internal void method_51(Class1734 class1734_1)
	{
		class1734_0 = class1734_1;
	}

	[SpecialName]
	internal ArrayList method_52()
	{
		return arrayList_1;
	}

	internal Font method_53(int int_12)
	{
		return (Font)method_52()[(int_12 > 4) ? (int_12 - 1) : int_12];
	}

	internal Font method_54(int int_12)
	{
		if (int_12 < 0)
		{
			return null;
		}
		if (int_12 > 4)
		{
			int_12--;
		}
		if (int_12 >= arrayList_1.Count)
		{
			return null;
		}
		return (Font)method_52()[int_12];
	}

	[SpecialName]
	internal ArrayList method_55()
	{
		return arrayList_2;
	}

	[SpecialName]
	internal Class1337 method_56()
	{
		return class1337_0;
	}

	[SpecialName]
	internal void method_57(Class1337 class1337_1)
	{
		class1337_0 = class1337_1;
	}

	[SpecialName]
	internal Class1683 method_58()
	{
		return class1683_0;
	}

	internal int method_59(Style style_1)
	{
		return class1683_0.method_3(style_1);
	}

	private void method_60()
	{
		method_56().method_0();
		for (int i = 0; i < class1683_0.Count; i++)
		{
			Style style = class1683_0[i];
			method_62(style);
			if (style.Custom != null && style.Custom != "")
			{
				style.method_45(method_65(style.Custom));
			}
		}
		method_66();
		method_67();
	}

	private void method_61()
	{
		class1683_0.Clear();
		arrayList_1.Clear();
		arrayList_2.Clear();
		styleCollection_0.Clear();
	}

	private void method_62(Style style_1)
	{
		bool flag = false;
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			Font font_ = (Font)arrayList_1[i];
			if (style_1.Font.method_18(font_))
			{
				if (i < 4)
				{
					style_1.Font.method_22(i);
				}
				else
				{
					style_1.Font.method_22(i + 1);
				}
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			arrayList_1.Add(style_1.Font);
			style_1.Font.method_22(arrayList_1.Count);
		}
	}

	internal void method_63(Font font_0)
	{
		bool flag = false;
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			Font font_ = (Font)arrayList_1[i];
			if (font_0.method_18(font_))
			{
				if (i < 4)
				{
					font_0.method_22(i);
				}
				else
				{
					font_0.method_22(i + 1);
				}
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			arrayList_1.Add(font_0);
			font_0.method_22(arrayList_1.Count);
		}
	}

	internal int method_64(Font font_0)
	{
		int num = 0;
		while (true)
		{
			if (num < arrayList_1.Count)
			{
				Font font_ = (Font)arrayList_1[num];
				if (font_0.method_18(font_))
				{
					break;
				}
				num++;
				continue;
			}
			int num2 = arrayList_1.Add(font_0);
			if (num2 < 4)
			{
				return num2;
			}
			return num2 + 1;
		}
		if (num < 4)
		{
			return num;
		}
		return num + 1;
	}

	internal int method_65(string string_2)
	{
		int num = 0;
		Class639 @class;
		while (true)
		{
			if (num < arrayList_2.Count)
			{
				@class = (Class639)arrayList_2[num];
				if (string_2 == @class.Custom)
				{
					break;
				}
				num++;
				continue;
			}
			if (ushort_1 < 176)
			{
				ushort_1 = 176;
			}
			ushort_1++;
			Class639 class2 = new Class639();
			class2.method_4(string_2, ushort_1);
			arrayList_2.Add(class2);
			return ushort_1;
		}
		return @class.Index;
	}

	private void method_66()
	{
		for (int i = 0; i < base.Count; i++)
		{
			Worksheet worksheet = (Worksheet)base.InnerList[i];
			CommentCollection comments = worksheet.Comments;
			int num = 0;
			if (comments.Count != 0)
			{
				Font font = new Font(this, null, bool_0: true);
				font.Size = 8;
				font.IsBold = true;
				method_63(font);
				num = font.method_21();
			}
			for (int j = 0; j < comments.Count; j++)
			{
				Comment comment = comments[j];
				if (comment.method_6() != null)
				{
					Font font = comment.Font;
					method_63(font);
					comment.method_7(font.method_21());
				}
				else
				{
					comment.method_7(num);
				}
				if (comment.method_2().method_12() == null || comment.method_2().method_12().Count == 0)
				{
					continue;
				}
				foreach (FontSetting item in comment.method_2().method_12())
				{
					if (item.method_2() != null)
					{
						method_63(item.method_2());
					}
				}
			}
			if (worksheet.Type == SheetType.Chart)
			{
				worksheet.Charts[0].method_37(arrayList_1);
			}
			else if (worksheet.method_36() != null)
			{
				worksheet.Shapes.method_2();
			}
		}
	}

	private void method_67()
	{
		for (int i = 0; i < method_56().Count; i++)
		{
			Style style = method_56()[i];
			if (style.IsModified(StyleModifyFlag.NumberFormat))
			{
				string custom = style.Custom;
				if (custom != null && custom != "")
				{
					style.method_45(method_65(custom));
				}
			}
		}
		foreach (Worksheet inner in base.InnerList)
		{
			if (workbook_0.fileFormatType_0 != FileFormatType.Xlsx)
			{
				foreach (Chart chart in inner.Charts)
				{
					chart.method_48();
				}
			}
			if (inner.pivotTableCollection_0 == null || inner.pivotTableCollection_0.Count <= 0)
			{
				continue;
			}
			foreach (PivotTable item in inner.pivotTableCollection_0)
			{
				if (item.DataFields.Count > 0)
				{
					foreach (PivotField item2 in item.DataFields.arrayList_0)
					{
						string numberFormat = item2.NumberFormat;
						if (numberFormat != null && numberFormat != "")
						{
							item2.method_10(method_65(numberFormat));
						}
					}
				}
				if (item.BaseFields.Count <= 0)
				{
					continue;
				}
				foreach (PivotField item3 in item.BaseFields.arrayList_0)
				{
					string numberFormat2 = item3.NumberFormat;
					if (numberFormat2 != null && numberFormat2 != "")
					{
						item3.method_10(method_65(numberFormat2));
					}
				}
			}
		}
	}

	private void method_68()
	{
		Cells cells = null;
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			cells = this[i].Cells;
			RowCollection rows = cells.Rows;
			for (int j = 0; j < rows.Count; j++)
			{
				Row rowByIndex = rows.GetRowByIndex(j);
				for (int k = 0; k < rowByIndex.method_0(); k++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(k);
					cellByIndex.method_68();
					if (cells.PreserveString && cellByIndex.method_20() != Enum199.const_6)
					{
						cellByIndex.method_27();
					}
				}
			}
		}
	}

	/// <summary>
	///       Gets Range object by pre-defined name.
	///       </summary>
	/// <param name="rangeName">Name of range.</param>
	/// <returns>Range object.<p></p>Returns null if the named range does not exist.</returns>
	public Range GetRangeByName(string rangeName)
	{
		int num = -1;
		int num2 = rangeName.IndexOf("!");
		if (num2 != -1)
		{
			string text = rangeName.Substring(0, num2);
			if (text == null || text == "")
			{
				return null;
			}
			if (text[0] == '\'')
			{
				text = text.Substring(1, text.Length - 2);
			}
			for (int i = 0; i < base.Count; i++)
			{
				if (text == this[i].Name)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				return null;
			}
			rangeName = rangeName.Substring(num2 + 1);
			if (rangeName == null || rangeName == "")
			{
				return null;
			}
		}
		return nameCollection_0[rangeName, num]?.CreateRange();
	}

	/// <summary>
	///       Gets all pre-defined named ranges in the spreadsheet.
	///       </summary>
	/// <returns>An array of Range objects.<p></p>Returns null if the named range does not exist.</returns>
	public Range[] GetNamedRanges()
	{
		if (nameCollection_0.Count == 0)
		{
			return null;
		}
		return nameCollection_0.GetNamedRanges(this);
	}

	/// <summary>
	///       Gets all pre-defined named ranges in the spreadsheet.
	///       </summary>
	/// <returns>An array of Range objects.<p></p>Returns null if the named range does not exist.</returns>
	public Range[] GetNamedRangesAndTables()
	{
		ArrayList arrayList = new ArrayList();
		if (nameCollection_0.Count != 0)
		{
			Range[] namedRanges = nameCollection_0.GetNamedRanges(this);
			if (namedRanges != null)
			{
				arrayList.AddRange(namedRanges);
			}
		}
		for (int i = 0; i < base.Count; i++)
		{
			ListObjectCollection listObjects = this[i].ListObjects;
			if (listObjects.Count > 0)
			{
				for (int j = 0; j < listObjects.Count; j++)
				{
					ListObject listObject = listObjects[j];
					Range range = new Range(listObject.StartRow, listObject.StartColumn, listObject.EndRow - listObject.StartRow + 1, listObject.EndColumn - listObject.StartColumn + 1, this[i].Cells);
					range.method_0(listObject.Name);
					arrayList.Add(range);
				}
			}
		}
		if (arrayList.Count == 0)
		{
			return null;
		}
		Range[] array = new Range[arrayList.Count];
		arrayList.CopyTo(array);
		return array;
	}

	internal BuiltInDocumentPropertyCollection method_69()
	{
		return builtInDocumentPropertyCollection_0;
	}

	internal CustomDocumentPropertyCollection method_70()
	{
		return customDocumentPropertyCollection_0;
	}

	[SpecialName]
	internal int method_71()
	{
		return int_6;
	}

	[SpecialName]
	internal int method_72()
	{
		return int_7;
	}

	[SpecialName]
	internal int method_73()
	{
		return int_8;
	}

	internal void method_74()
	{
		int[] array = Class1679.smethod_2(this);
		int_9 = array[0];
		int_10 = array[1];
		int_7 = array[2];
		int_6 = array[3];
		int_8 = array[4];
	}

	[SpecialName]
	internal int method_75()
	{
		return int_9;
	}

	[SpecialName]
	internal int method_76()
	{
		return int_10;
	}

	/// <summary>
	///       Sets displayed size when Workbook file is used as an Ole object.
	///       </summary>
	/// <param name="startRow">Start row index.</param>
	/// <param name="endRow">End row index.</param>
	/// <param name="startColumn">Start column index.</param>
	/// <param name="endColumn">End column index.</param>
	/// <remarks>This method is generally used to adjust display size in ppt file or doc file.</remarks>
	public void SetOleSize(int startRow, int endRow, int startColumn, int endColumn)
	{
		CellArea cellArea = default(CellArea);
		cellArea.StartRow = startRow;
		cellArea.EndRow = endRow;
		cellArea.StartColumn = (byte)startColumn;
		cellArea.EndColumn = (byte)endColumn;
		object_1 = cellArea;
	}

	internal void Unprotect(string string_2)
	{
		if (string_2 != null && !(string_2 == ""))
		{
			if (ushort_2 == 0)
			{
				bool_3 = false;
				bool_2 = false;
				return;
			}
			ushort num = (ushort)Class1652.smethod_0(string_2);
			if (ushort_2 != num)
			{
				throw new CellsException(ExceptionType.IncorrectPassword, "Invalid password.");
			}
			bool_3 = false;
			bool_2 = false;
			if (class1647_0 != null && class1647_0.string_0 == "VelvetSweatshop")
			{
				class1647_0 = null;
			}
		}
		else
		{
			if (ushort_2 != 0)
			{
				throw new CellsException(ExceptionType.IncorrectPassword, "Invalid password");
			}
			bool_3 = false;
			bool_2 = false;
		}
	}

	[SpecialName]
	internal bool method_77()
	{
		return bool_2;
	}

	[SpecialName]
	internal void method_78(bool bool_4)
	{
		bool_2 = bool_4;
	}

	[SpecialName]
	internal bool method_79()
	{
		return bool_3;
	}

	[SpecialName]
	internal void method_80(bool bool_4)
	{
		bool_3 = bool_4;
	}

	[SpecialName]
	internal ushort method_81()
	{
		return ushort_2;
	}

	[SpecialName]
	internal void method_82(ushort ushort_3)
	{
		ushort_2 = ushort_3;
		if (ushort_3 != 0 && (workbook_0.Settings.Password == null || workbook_0.Settings.Password == "") && class1647_0 == null)
		{
			class1647_0 = Class1677.smethod_39();
		}
	}

	private void method_83(ProtectionType protectionType_0, string string_2)
	{
		if (string_2 != null && string_2 != "")
		{
			if (class1647_0 == null)
			{
				class1647_0 = Class1677.smethod_39();
			}
			ushort_2 = (ushort)Class1652.smethod_0(string_2);
		}
		else
		{
			ushort_2 = 0;
		}
		switch (protectionType_0)
		{
		case ProtectionType.Structure:
			bool_3 = true;
			bool_2 = false;
			break;
		case ProtectionType.Windows:
			bool_3 = false;
			bool_2 = true;
			break;
		case ProtectionType.All:
			bool_2 = true;
			bool_3 = true;
			break;
		}
	}

	internal void Protect(ProtectionType protectionType_0, string string_2)
	{
		switch (protectionType_0)
		{
		case ProtectionType.Contents:
		case ProtectionType.Objects:
		case ProtectionType.Scenarios:
			return;
		}
		if (ushort_2 != 0)
		{
			if (IsProtected)
			{
				throw new CellsException(ExceptionType.InvalidData, "Workbook is already protected, please uprotected it first.");
			}
			method_83(protectionType_0, string_2);
		}
		else
		{
			method_83(protectionType_0, string_2);
		}
	}

	[SpecialName]
	internal Class1703 method_84()
	{
		if (class1703_0 == null)
		{
			class1703_0 = new Class1703(this, Enum181.const_0);
		}
		return class1703_0;
	}

	internal Class1703 method_85()
	{
		return class1703_0;
	}

	internal void method_86(Class1703 class1703_2)
	{
		class1703_0 = class1703_2;
	}

	[SpecialName]
	internal Class1703 method_87()
	{
		if (class1703_1 == null)
		{
			class1703_1 = new Class1703(this, Enum181.const_1);
		}
		return class1703_1;
	}

	internal Class1703 method_88()
	{
		return class1703_1;
	}

	[SpecialName]
	internal Class1142 method_89()
	{
		if (class1142_0 == null)
		{
			class1142_0 = new Class1142(this);
		}
		return class1142_0;
	}

	internal Class1142 method_90()
	{
		return class1142_0;
	}

	internal TableStyleCollection method_91()
	{
		return tableStyleCollection_0;
	}

	[SpecialName]
	internal Class1283 method_92()
	{
		if (class1283_0 == null)
		{
			class1283_0 = new Class1283();
		}
		return class1283_0;
	}

	internal Class1283 method_93()
	{
		return class1283_0;
	}

	internal void method_94()
	{
		for (int i = 0; i < nameCollection_0.Count; i++)
		{
			Name name = nameCollection_0[i];
			name.method_23();
		}
		for (int j = 0; j < base.Count; j++)
		{
			Worksheet worksheet = this[j];
			Cells cells = worksheet.Cells;
			RowCollection rows = cells.Rows;
			for (int k = 0; k < rows.Count; k++)
			{
				Row rowByIndex = rows.GetRowByIndex(k);
				for (int l = 0; l < rowByIndex.method_0(); l++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(l);
					cellByIndex.method_75();
				}
			}
		}
	}

	internal ListObject method_95(string string_2)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Worksheet worksheet = this[i];
			if (worksheet.ListObjects == null || worksheet.ListObjects.Count <= 0)
			{
				continue;
			}
			for (int j = 0; j < worksheet.ListObjects.Count; j++)
			{
				ListObject listObject = worksheet.ListObjects[j];
				if (listObject.Name == string_2)
				{
					return listObject;
				}
			}
		}
		return null;
	}
}
