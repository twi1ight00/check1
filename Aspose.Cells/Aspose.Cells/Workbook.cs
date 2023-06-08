using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using Aspose.Cells.Charts;
using Aspose.Cells.DigitalSignatures;
using Aspose.Cells.Properties;
using Aspose.Cells.Rendering;
using Aspose.Cells.Tables;
using ns10;
using ns11;
using ns12;
using ns15;
using ns16;
using ns17;
using ns2;
using ns20;
using ns22;
using ns24;
using ns46;
using ns50;
using ns57;
using ns59;
using ns7;
using ns8;

namespace Aspose.Cells;

/// <summary>
///        Represents a root object to create an Excel spreadsheet. 	
///        </summary>
/// <remarks>The Workbook class denotes an Excel spreadsheet. Each spreadsheet can contain multiple worksheets.
///        The basic feature of the class is to open and save native excel files.
///        The class has some advanced features like copying data from other Workbooks, combining two Workbooks and protecting the Excel spreadsheet.
///        </remarks>
/// <example>
///        The following example creates a Workbook, opens a file named designer.xls in it and makes the horizontal and vertical scroll bars invisible for the Workbook. It then replaces two string values with an Integer value and string value respectively within the spreadsheet and finally sends the updated file to the client browser. 
///        <code>
///        [C#]
///
///
///
///        //Open a designer file
///        string designerFile = MapPath("Designer") + "\\designer.xls";
///        Workbook workbook = new Workbook(designerFile);
///
///        //Set scroll bars
///        workbook.IsHScrollBarVisible = false;
///        workbook.IsVScrollBarVisible = false;
///
///        //Replace the placeholder string with new values
///        int newInt = 100;
///        workbook.Replace("OldInt", newInt);
///
///        string newString = "Hello!";
///        workbook.Replace("OldString", newString);
///        XlsSaveOptions saveOptions = new XlsSaveOptions();
///        workbook.Save(Response, "result.xls", ContentDisposition.Inline, saveOptions);
///
///        [Visual Basic]
///
///
///
///        'Open a designer file
///        Dim designerFile as String = MapPath("Designer") + "\designer.xls"
///        Dim workbook as Workbook = new Workbook(designerFile)
///
///        'Set scroll bars
///        workbook.IsHScrollBarVisible = False
///        workbook.IsVScrollBarVisible = False
///
///        'Replace the placeholder string with new values
///        Dim newInt as Integer = 100
///        workbook.Replace("OldInt", newInt)
///
///        Dim newString as String = "Hello!"
///        workbook.Replace("OldString", newString)
///        Dim saveOptions as XlsSaveOptions  = new XlsSaveOptions()
///        workbook.Save(Response, "result.xls", ContentDisposition.Inline, saveOptions)    
///        </code></example>
public class Workbook
{
	private WorkbookSettings workbookSettings_0;

	private WorksheetCollection worksheetCollection_0;

	internal bool bool_0;

	internal Class1380 class1380_0 = new Class1380();

	internal Class1382 class1382_0 = new Class1382();

	private string string_0 = "";

	private DataSorter dataSorter_0;

	internal Class1558 class1558_0;

	private EncryptionType encryptionType_0;

	private int int_0 = 128;

	private SaveOptions saveOptions_0;

	internal Class1569 class1569_0 = new Class1569();

	internal bool bool_1;

	private string string_1;

	internal FileFormatType fileFormatType_0 = FileFormatType.Xlsx;

	private Enum187 enum187_0 = Enum187.const_1;

	private InterruptMonitor interruptMonitor_0;

	private ContentTypePropertyCollection contentTypePropertyCollection_0;

	private string string_2;

	internal Class442 class442_0;

	private DigitalSignatureCollection digitalSignatureCollection_0;

	internal Class997 class997_0;

	private Hashtable hashtable_0 = new Hashtable();

	/// <summary>
	///       Gets the workbook settings.
	///       </summary>
	public WorkbookSettings Settings
	{
		get
		{
			return workbookSettings_0;
		}
		set
		{
			workbookSettings_0 = value;
		}
	}

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.WorksheetCollection" /> collection in the spreadsheet.
	///       </summary>
	/// <returns>
	///   <see cref="T:Aspose.Cells.WorksheetCollection" /> collection</returns>
	public WorksheetCollection Worksheets => worksheetCollection_0;

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.StyleCollection" /> collection.
	///       </summary>
	public StyleCollection Styles => worksheetCollection_0.Styles;

	/// <summary>
	///       Returns colors in the palette for the spreadsheet. 
	///       </summary>
	/// <remarks>The palette has 56 entries, each represented by an RGB value.</remarks>
	public Color[] Colors => workbookSettings_0.method_0().Colors;

	/// <summary>
	///        Gets or sets the default <see cref="T:Aspose.Cells.Style" /> object of the workbook.
	///        </summary>
	/// <remarks>
	///        The DefaultStyle property is useful to implement a Style for the whole Workbook. 
	///        </remarks>
	/// <example>
	///        The following code creates and instantiates a new Workbook and sets a default <see cref="T:Aspose.Cells.Style" /> to it.
	///        <code>
	///        [C#]
	///        Workbook workbook = new Workbook();
	///        Style defaultStyle = workbook.DefaultStyle;
	///        defaultStyle.Font.Name = "Tahoma";
	///        workbook.DefaultStyle = defaultStyle;
	///
	///        [Visual Basic]
	///        Dim workbook as Workbook = new Workbook()
	///        Dim defaultStyle as Style = workbook.DefaultStyle
	///        defaultStyle.Font.Name = "Tahoma"
	///        workbook.DefaultStyle = defaultStyle
	///        </code></example>
	public Style DefaultStyle
	{
		get
		{
			return worksheetCollection_0.DefaultStyle;
		}
		set
		{
			worksheetCollection_0.DefaultStyle = value;
		}
	}

	/// <summary>
	///       Gets a value that indicates whether the Workbook is protected. 
	///       </summary>
	/// <remarks>
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook.Settings.IsProtected property.
	///       This property will be removed 12 months later since February 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Workbook.Settings.IsProtected property instead.")]
	[Browsable(false)]
	public bool IsProtected => worksheetCollection_0.IsProtected;

	/// <summary>
	///       Gets or sets the user interface language of the Workbook version based on CountryCode that has saved the file. 
	///       </summary>
	/// <remarks>
	///       Please use Workbook.Settings.LanguageCode property.
	///       This property will be removed 12 months later since February 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Workbook.Settings.LanguageCode property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public CountryCode Language
	{
		get
		{
			return workbookSettings_0.LanguageCode;
		}
		set
		{
			workbookSettings_0.LanguageCode = value;
		}
	}

	/// <summary>
	///       Gets or sets the system regional settings based on CountryCode at the time the file was saved. 
	///       </summary>
	/// <remarks>If you do not want to use the region  saved in the file, 
	///       please reset it after reading the file.
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook.Settings.Region property.
	///       This property will be removed 12 months later since February 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Workbook.Settings.Region property instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public CountryCode Region
	{
		get
		{
			return workbookSettings_0.Region;
		}
		set
		{
			workbookSettings_0.Region = value;
		}
	}

	/// <summary>
	///       Indicates if this spreadsheet contains macro/VBA.
	///       </summary>
	public bool HasMacro
	{
		get
		{
			if (worksheetCollection_0.method_10() != null && worksheetCollection_0.method_10().method_9().Contains("_VBA_PROJECT_CUR") && worksheetCollection_0.HasMacro && !worksheetCollection_0.method_19())
			{
				return true;
			}
			if (class1558_0 != null && class1558_0.string_0 != null)
			{
				return true;
			}
			return false;
		}
	}

	/// <summary>
	///       Indicates if this spreadsheet is digitally signed.
	///       </summary>
	public bool IsDigitallySigned
	{
		get
		{
			if (class1558_0 != null)
			{
				return class1558_0.bool_3;
			}
			if (Worksheets.method_10() != null)
			{
				return Worksheets.method_10().method_9().ContainsKey("_signatures");
			}
			return false;
		}
	}

	/// <summary>
	///       Returns true if the workbook has any tracked changes
	///       </summary>
	public bool HasRevisions
	{
		get
		{
			Class1346 @class = new Class1346(this);
			return @class.HasRevisions;
		}
	}

	/// <summary>
	///       Gets and sets the current file name.
	///       </summary>
	/// <remarks>
	///       If the file is opened by stream and there are some external formula references,
	///       please set the file name.
	///       </remarks>
	public string FileName
	{
		get
		{
			return string_0;
		}
		set
		{
			method_10(value);
		}
	}

	/// <summary>
	///       Gets a DataSorter object to sort data.
	///       </summary>
	public DataSorter DataSorter
	{
		get
		{
			if (dataSorter_0 == null)
			{
				dataSorter_0 = new DataSorter(this);
			}
			return dataSorter_0;
		}
	}

	/// <summary>
	///       Gets the saving and printing options
	///       </summary>
	public SaveOptions SaveOptions
	{
		get
		{
			if (saveOptions_0 == null)
			{
				saveOptions_0 = new SaveOptions();
			}
			return saveOptions_0;
		}
	}

	/// <summary>
	///       Gets the theme name. 
	///       </summary>
	public string Theme => class1569_0.string_0;

	/// <summary>
	///       Returns a DocumentProperties collection that represents all the built-in document properties of the spreadsheet. 
	///       </summary>
	/// <remarks>A new property cannot be added to built-in document properties list. You can only get a built-in property and change its value.
	///       The following is the built-in properties name list:
	///       <p>Title</p><p>Subject</p><p>Author</p><p>Keywords</p><p>Comments</p><p>Template</p><p>Last Author</p><p>Revision Number</p><p>Application Name</p><p>Last Print Date</p><p>Creation Date</p><p>Last Save Time</p><p>Total Editing Time</p><p>Number of Pages</p><p>Number of Words</p><p>Number of Characters</p><p>Security</p><p>Category</p><p>Format</p><p>Manager</p><p>Company</p><p>Number of Bytes</p><p>Number of Lines</p><p>Number of Paragraphs</p><p>Number of Slides</p><p>Number of Notes</p><p>Number of Hidden Slides</p><p>Number of Multimedia Clips</p></remarks>
	/// <example>
	///   <code>
	///       [C#]
	///       DocumentProperty doc = workbook.BuiltInDocumentProperties["Author"];
	///       doc.Value = "John Smith";
	///
	///       [Visual Basic]
	///       Dim doc as DocumentProperty = workbook.BuiltInDocumentProperties("Author")
	///       doc.Value = "John Smith"
	///       </code>
	/// </example>
	public BuiltInDocumentPropertyCollection BuiltInDocumentProperties => Worksheets.BuiltInDocumentProperties;

	/// <summary>
	///       Returns a DocumentProperties collection that represents all the custom document properties of the spreadsheet. 
	///       </summary>
	/// <example>
	///   <code>
	///       [C#]
	///       excel.CustomDocumentProperties.Add("Checked by", "Jane");
	///
	///       [Visual Basic]
	///       excel.CustomDocumentProperties.Add("Checked by", "Jane")
	///       </code>
	/// </example>
	public CustomDocumentPropertyCollection CustomDocumentProperties => Worksheets.CustomDocumentProperties;

	/// <summary>
	///       Gets and sets the file format.
	///       </summary>
	public FileFormatType FileFormat
	{
		get
		{
			return fileFormatType_0;
		}
		set
		{
			fileFormatType_0 = value;
			Enum187 @enum = smethod_0(value, enum187_0, bool_2: true);
			if (@enum != enum187_0)
			{
				method_25(enum187_0, @enum);
			}
			enum187_0 = @enum;
		}
	}

	/// <summary>
	///       Gets and sets the interrupt monitor.
	///       </summary>
	public InterruptMonitor InterruptMonitor
	{
		get
		{
			return interruptMonitor_0;
		}
		set
		{
			interruptMonitor_0 = value;
		}
	}

	public ContentTypePropertyCollection ContentTypeProperties
	{
		get
		{
			if (contentTypePropertyCollection_0 == null)
			{
				contentTypePropertyCollection_0 = new ContentTypePropertyCollection();
			}
			return contentTypePropertyCollection_0;
		}
	}

	public string RibbonXml
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

	internal string method_0(string string_3)
	{
		string text = (string)Settings.method_6()[string_3];
		if (text == null)
		{
			return string_3;
		}
		return text;
	}

	/// <summary>
	///       Initializes a new instance of the <see cref="T:Aspose.Cells.Workbook" /> class.
	///       </summary>
	/// <example>
	///       The following code shows how to use the Workbook constructor to create and initialize a new instance of the class.
	///       <code>
	///       [C#]
	///
	///       Workbook workbook = new Workbook();
	///
	///
	///       [Visual Basic]
	///
	///       Dim workbook as Workbook = new Workbook()
	///
	///       </code></example>
	public Workbook()
	{
		method_22(FileFormatType.Default);
		workbookSettings_0 = new WorkbookSettings(this, CountryCode.Default);
		worksheetCollection_0 = new WorksheetCollection(this);
	}

	/// <summary>
	///       Initializes a new instance of the <see cref="T:Aspose.Cells.Workbook" /> class.
	///       </summary>
	/// <param name="fileFormatType">
	///       The new file format.
	///       </param>
	/// <example>
	///       The following code shows how to use the Workbook constructor to create and initialize a new instance of the class.
	///       <code>
	///       [C#]
	///
	///       Workbook workbook = new Workbook(FileFormatType.Excel2007Xlsx);
	///
	///
	///       [Visual Basic]
	///
	///       Dim workbook as Workbook = new Workbook(FileFormatType.Excel2007Xlsx)
	///
	///       </code></example>
	/// <remarks>
	///       The default file format type is Excel97To2003;
	///       </remarks>
	public Workbook(FileFormatType fileFormatType)
	{
		method_22(fileFormatType);
		workbookSettings_0 = new WorkbookSettings(this, CountryCode.Default);
		worksheetCollection_0 = new WorksheetCollection(this);
	}

	/// <summary>
	///        Initializes a new instance of the <see cref="T:Aspose.Cells.Workbook" /> class and open a file.
	///       </summary>
	/// <param name="file">The file name.</param>
	public Workbook(string file)
	{
		method_6(file, new LoadOptions());
	}

	/// <summary>
	///        Initializes a new instance of the <see cref="T:Aspose.Cells.Workbook" /> class and open a stream.
	///       </summary>
	/// <param name="stream">The stream.</param>
	public Workbook(Stream stream)
	{
		method_7(stream, new LoadOptions(), bool_2: true);
	}

	/// <summary>
	///        Initializes a new instance of the <see cref="T:Aspose.Cells.Workbook" /> class and open a file.
	///       </summary>
	/// <param name="file">The file name.</param>
	/// <param name="loadOptions">The load options</param>
	public Workbook(string file, LoadOptions loadOptions)
	{
		method_6(file, loadOptions);
	}

	/// <summary>
	///        Initializes a new instance of the <see cref="T:Aspose.Cells.Workbook" /> class and open stream.
	///       </summary>
	/// <param name="stream">The stream.</param>
	/// <param name="loadOptions">The load options</param>
	public Workbook(Stream stream, LoadOptions loadOptions)
	{
		method_7(stream, loadOptions, bool_2: true);
	}

	/// <summary>
	///       Initialize the workbook object.
	///       </summary>
	public void Initialize()
	{
		string_0 = "";
		string_1 = null;
		worksheetCollection_0.Clear();
		worksheetCollection_0 = null;
		workbookSettings_0 = new WorkbookSettings(this, CountryCode.Default);
		worksheetCollection_0 = new WorksheetCollection(this);
		class1558_0 = null;
		encryptionType_0 = EncryptionType.XOR;
		int_0 = 128;
		method_4();
		saveOptions_0 = null;
	}

	internal void method_1()
	{
	}

	private void method_2(FileFormatType fileFormatType_1, bool bool_2)
	{
		if (bool_2)
		{
			method_22(fileFormatType_1);
			workbookSettings_0.method_20(fileFormatType_1, enum187_0, bool_26: true);
			return;
		}
		saveOptions_0 = null;
		string_0 = "";
		string_1 = null;
		worksheetCollection_0 = new WorksheetCollection(this);
		method_22(fileFormatType_1);
		workbookSettings_0.method_20(fileFormatType_1, enum187_0, bool_26: false);
		class1558_0 = null;
		class1569_0 = new Class1569();
		bool_1 = false;
		method_4();
	}

	internal void method_3()
	{
		method_5();
		if (bool_0)
		{
			bool_0 = false;
			class1380_0.method_1();
			class1382_0.method_0();
		}
	}

	internal void method_4()
	{
		if (bool_0)
		{
			bool_0 = false;
			class1380_0.method_1();
			class1382_0.method_0();
		}
	}

	internal void method_5()
	{
		if (Settings.ParsingFormulaOnOpen || Settings.bool_19 || method_21() != Enum187.const_1)
		{
			return;
		}
		for (int i = 0; i < Worksheets.Count; i++)
		{
			Cells cells = Worksheets[i].Cells;
			IEnumerator rowEnumerator = cells.GetRowEnumerator();
			while (rowEnumerator.MoveNext())
			{
				Row row = (Row)rowEnumerator.Current;
				IEnumerator enumerator = row.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Cell cell = (Cell)enumerator.Current;
					if (cell.IsFormula && cell.method_17().byte_0 == null)
					{
						Worksheets.Formula.method_4(cell, cell.method_17().string_0, 0, bool_0: false);
					}
				}
			}
		}
		Settings.bool_19 = true;
	}

	private void method_6(string string_3, LoadOptions loadOptions_0)
	{
		workbookSettings_0 = new WorkbookSettings(this, loadOptions_0.Region);
		worksheetCollection_0 = new WorksheetCollection(this);
		Settings.Password = loadOptions_0.Password;
		Settings.ParsingFormulaOnOpen = loadOptions_0.ParsingFormulaOnOpen;
		Settings.LanguageCode = loadOptions_0.LanguageCode;
		if (loadOptions_0.bool_4)
		{
			Settings.StandardFont = loadOptions_0.StandardFont;
		}
		if (loadOptions_0.bool_5)
		{
			Settings.StandardFontSize = loadOptions_0.StandardFontSize;
		}
		workbookSettings_0.bool_22 = loadOptions_0.IgnoreNotPrinted;
		workbookSettings_0.bool_23 = loadOptions_0.method_1();
		interruptMonitor_0 = loadOptions_0.InterruptMonitor;
		Stream stream = null;
		try
		{
			stream = File.Open(string_3, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			if (stream.Length == 0)
			{
				return;
			}
			if (loadOptions_0.LoadFormat == LoadFormat.Auto)
			{
				bool isValid = false;
				int header = 0;
				loadOptions_0.method_0(Class1677.smethod_8(string_3, stream, out isValid, out header));
				if (!isValid)
				{
					switch (header)
					{
					case 521:
						throw new CellsException(ExceptionType.UnsupportedFeature, "This Excel files contains (Excel3.0 or earlier file format) records.");
					case 9:
						throw new CellsException(ExceptionType.UnsupportedFeature, "This Excel files contains (Excel2.1 or earlier file format) records.");
					case 2057:
						throw new CellsException(ExceptionType.UnsupportedFeature, "This Excel files contains (Excel95 or earlier file format) records.");
					default:
						throw new CellsException(ExceptionType.FileFormat, "This file's format is not supported or you don't specify a correct format.");
					case 1033:
						throw new CellsException(ExceptionType.UnsupportedFeature, "This Excel files contains (Excel4.0 or earlier file format) records.");
					}
				}
				if (loadOptions_0.LoadFormat == LoadFormat.MHtml)
				{
					Class433 istreamProvider_ = new Class433();
					Class439 @class = new Class439(istreamProvider_);
					@class.method_0(string_3, this, loadOptions_0);
					return;
				}
				if (loadOptions_0.LoadFormat == LoadFormat.Html)
				{
					Class431 istreamProvider_2 = new Class431();
					Class776 class2 = new Class776(istreamProvider_2);
					class2.method_0(string_3, this, loadOptions_0);
					return;
				}
				if (loadOptions_0.LoadFormat == LoadFormat.Excel97To2003)
				{
					Class1317 class3 = new Class1317(stream);
					if (class3.method_9().GetStream("EncryptionInfo") != null)
					{
						Stream stream_ = method_29(class3);
						LoadFormat loadFormat = LoadFormat.Xlsx;
						method_11(stream_);
						Class1558 class4 = class1558_0;
						Class746 class746_ = class4.class1553_0.class746_0;
						string string_4 = "xl/workbook.bin";
						if (class746_.method_40(string_4, bool_18: true) != -1)
						{
							loadFormat = LoadFormat.Xlsb;
						}
						LoadFormat loadFormat2 = loadFormat;
						if (loadFormat2 == LoadFormat.Xlsb)
						{
							method_2(FileFormatType.Xlsb, bool_2: true);
							class1558_0 = class4;
							Class1218 class5 = new Class1218(this);
							class5.Read();
						}
						else
						{
							method_2(FileFormatType.Xlsx, bool_2: true);
							if (loadOptions_0.LoadDataOnly)
							{
								Class1368.LoadData(this, class746_, loadOptions_0.LoadDataOptions);
							}
							else
							{
								class1558_0 = class4;
								Class1614.smethod_0(this);
							}
						}
					}
					else
					{
						if (class3.method_9().GetStream("Workbook") == null && class3.method_9().GetStream("WordDocument") != null)
						{
							throw new CellsException(ExceptionType.FileFormat, "This is a word doc file.");
						}
						method_2(FileFormatType.Default, bool_2: true);
						if (loadOptions_0.LoadDataOnly)
						{
							Class1724 class6 = new Class1724(this, loadOptions_0.LoadDataOptions);
							class6.method_39(class3);
						}
						else if (loadOptions_0.OnlyLoadDocumentProperties)
						{
							method_8(class3);
							Worksheets.method_11(class3);
						}
						else
						{
							Class1730 class7 = new Class1730(this);
							class7.Read(class3);
							Worksheets.method_11(class3);
						}
					}
				}
				else
				{
					method_7(stream, loadOptions_0, bool_2: false);
				}
			}
			else
			{
				method_7(stream, loadOptions_0, bool_2: false);
			}
		}
		finally
		{
			stream?.Close();
		}
		method_10(string_3);
	}

	private void method_7(Stream stream_0, LoadOptions loadOptions_0, bool bool_2)
	{
		if (bool_2)
		{
			workbookSettings_0 = new WorkbookSettings(this, loadOptions_0.Region);
			worksheetCollection_0 = new WorksheetCollection(this);
		}
		Settings.Password = loadOptions_0.Password;
		Settings.ParsingFormulaOnOpen = loadOptions_0.ParsingFormulaOnOpen;
		Settings.LanguageCode = loadOptions_0.LanguageCode;
		Settings.Region = loadOptions_0.Region;
		if (loadOptions_0.bool_4)
		{
			Settings.StandardFont = loadOptions_0.StandardFont;
		}
		if (loadOptions_0.bool_5)
		{
			Settings.StandardFontSize = loadOptions_0.StandardFontSize;
		}
		workbookSettings_0.bool_22 = loadOptions_0.IgnoreNotPrinted;
		workbookSettings_0.bool_23 = loadOptions_0.method_1();
		interruptMonitor_0 = loadOptions_0.InterruptMonitor;
		if (stream_0.Length == 0)
		{
			return;
		}
		if (loadOptions_0.LoadFormat == LoadFormat.Auto)
		{
			bool flag = false;
			if (!stream_0.CanSeek)
			{
				byte[] array = new byte[(int)stream_0.Length];
				int num = 0;
				int num2 = 0;
				while (num2 > 0)
				{
					num2 = stream_0.Read(array, num, array.Length - num);
					num += num2;
				}
				stream_0 = new MemoryStream(array);
				flag = true;
			}
			stream_0.Seek(0L, SeekOrigin.Begin);
			bool isValid = false;
			int header = 0;
			loadOptions_0.method_0(Class1677.smethod_8(null, stream_0, out isValid, out header));
			if (isValid)
			{
				if (loadOptions_0.LoadFormat == LoadFormat.Xlsx)
				{
					if (!flag)
					{
						MemoryStream memoryStream = new MemoryStream();
						Class1677.smethod_5(stream_0, memoryStream);
						memoryStream.Position = 0L;
						stream_0 = memoryStream;
					}
					method_11(stream_0);
					Class1558 @class = class1558_0;
					Class746 class746_ = @class.class1553_0.class746_0;
					if (class746_.method_40("xl/workbook.xml", bool_18: true) != -1)
					{
						method_2(FileFormatType.Xlsx, bool_2: true);
						if (loadOptions_0.LoadDataOnly)
						{
							Class1368.LoadData(this, class746_, loadOptions_0.LoadDataOptions);
							return;
						}
						class1558_0 = @class;
						Class1614.smethod_0(this);
						return;
					}
					if (class746_.method_40("xl/workbook.bin", bool_18: true) != -1)
					{
						method_2(FileFormatType.Xlsb, bool_2: true);
						class1558_0 = @class;
						Class1218 class2 = new Class1218(this);
						class2.Read();
						return;
					}
					if (class746_.method_40("content.xml", bool_18: true) != -1)
					{
						method_2(FileFormatType.ODS, bool_2: true);
						Class1521 class3 = new Class1521(this);
						class3.Read(class746_);
						return;
					}
				}
				else if (loadOptions_0.LoadFormat == LoadFormat.Excel97To2003)
				{
					Class1317 class4 = new Class1317(stream_0);
					if (class4.method_9().GetStream("EncryptionInfo") != null)
					{
						Stream stream_ = method_29(class4);
						LoadFormat loadFormat = LoadFormat.Xlsx;
						method_11(stream_);
						Class1558 class5 = class1558_0;
						Class746 class746_2 = class5.class1553_0.class746_0;
						string string_ = "xl/workbook.bin";
						if (class746_2.method_40(string_, bool_18: true) != -1)
						{
							loadFormat = LoadFormat.Xlsb;
						}
						LoadFormat loadFormat2 = loadFormat;
						if (loadFormat2 == LoadFormat.Xlsb)
						{
							method_2(FileFormatType.Xlsb, bool_2: true);
							class1558_0 = class5;
							Class1218 class6 = new Class1218(this);
							class6.Read();
							return;
						}
						method_2(FileFormatType.Xlsx, bool_2: true);
						if (loadOptions_0.LoadDataOnly)
						{
							Class1368.LoadData(this, class746_2, loadOptions_0.LoadDataOptions);
							return;
						}
						class1558_0 = class5;
						Class1614.smethod_0(this);
					}
					else
					{
						method_2(FileFormatType.Default, bool_2: true);
						if (loadOptions_0.LoadDataOnly)
						{
							Class1724 class7 = new Class1724(this, loadOptions_0.LoadDataOptions);
							class7.method_39(class4);
						}
						else if (loadOptions_0.OnlyLoadDocumentProperties)
						{
							method_8(class4);
							Worksheets.method_11(class4);
						}
						else
						{
							Class1730 class8 = new Class1730(this);
							class8.Read(class4);
							Worksheets.method_11(class4);
						}
					}
					return;
				}
			}
		}
		if (loadOptions_0 is TxtLoadOptions)
		{
			TxtLoadOptions txtLoadOptions = (TxtLoadOptions)loadOptions_0;
			method_2(FileFormatType.CSV, bool_2: true);
			if (!txtLoadOptions.bool_8)
			{
				Settings.Encoding = txtLoadOptions.Encoding;
			}
			StreamReader streamReader_ = (Settings.bool_12 ? new StreamReader(stream_0) : new StreamReader(stream_0, Settings.Encoding));
			Class1731.Read(streamReader_, worksheetCollection_0[0].Cells, 0, 0, txtLoadOptions);
			return;
		}
		switch (loadOptions_0.LoadFormat)
		{
		case LoadFormat.Xlsx:
		{
			method_2(FileFormatType.Xlsx, bool_2: true);
			BinaryReader binaryReader2 = new BinaryReader(stream_0);
			long num4 = binaryReader2.ReadInt64();
			stream_0.Seek(0L, SeekOrigin.Begin);
			if (num4 == -2226271756974174256L)
			{
				stream_0 = method_29(new Class1317(stream_0));
			}
			if (loadOptions_0.LoadDataOnly)
			{
				Class1368.LoadData(this, stream_0, loadOptions_0.LoadDataOptions);
				break;
			}
			method_11(stream_0);
			Class1614.smethod_0(this);
			break;
		}
		default:
			method_2(FileFormatType.Default, bool_2: true);
			if (loadOptions_0.LoadDataOnly)
			{
				Class1317 class1317_ = new Class1317(stream_0);
				Class1724 class12 = new Class1724(this, loadOptions_0.LoadDataOptions);
				class12.method_39(class1317_);
			}
			else if (loadOptions_0.OnlyLoadDocumentProperties)
			{
				Class1317 class13 = new Class1317(stream_0);
				method_8(class13);
				Worksheets.method_11(class13);
			}
			else
			{
				Class1730 class14 = new Class1730(this);
				Class1317 class1317_2 = class14.Read(stream_0);
				Worksheets.method_11(class1317_2);
			}
			break;
		case LoadFormat.TabDelimited:
		{
			method_2(FileFormatType.TabDelimited, bool_2: true);
			TxtLoadOptions txtLoadOptions3 = new TxtLoadOptions();
			txtLoadOptions3.ConvertNumericData = loadOptions_0.ConvertNumericData;
			StreamReader streamReader_;
			if (Settings.bool_12)
			{
				streamReader_ = new StreamReader(stream_0);
			}
			else
			{
				streamReader_ = new StreamReader(stream_0, Settings.Encoding);
				txtLoadOptions3.Encoding = Settings.Encoding;
			}
			txtLoadOptions3.Separator = '\t';
			Class1731.Read(streamReader_, worksheetCollection_0[0].Cells, 0, 0, txtLoadOptions3);
			break;
		}
		case LoadFormat.Html:
		{
			Class431 istreamProvider_ = new Class431();
			Class776 class9 = new Class776(istreamProvider_);
			class9.method_1(stream_0, this, loadOptions_0);
			break;
		}
		case LoadFormat.MHtml:
		{
			Class433 istreamProvider_2 = new Class433();
			Class439 class10 = new Class439(istreamProvider_2);
			class10.method_1(stream_0, this, loadOptions_0);
			break;
		}
		case LoadFormat.ODS:
		{
			method_2(FileFormatType.ODS, bool_2: true);
			Class1521 class16 = new Class1521(this);
			class16.Read(stream_0);
			break;
		}
		case LoadFormat.SpreadsheetML:
		{
			method_2(FileFormatType.Excel2003XML, bool_2: true);
			Class1105 class15 = new Class1105();
			class15.method_0(stream_0, this);
			break;
		}
		case LoadFormat.Xlsb:
		{
			method_2(FileFormatType.Xlsb, bool_2: true);
			BinaryReader binaryReader = new BinaryReader(stream_0);
			long num3 = binaryReader.ReadInt64();
			stream_0.Seek(0L, SeekOrigin.Begin);
			if (num3 == -2226271756974174256L)
			{
				stream_0 = method_29(new Class1317(stream_0));
			}
			method_11(stream_0);
			Class1218 class11 = new Class1218(this);
			class11.Read();
			break;
		}
		case LoadFormat.CSV:
		{
			method_2(FileFormatType.CSV, bool_2: true);
			TxtLoadOptions txtLoadOptions2 = new TxtLoadOptions();
			txtLoadOptions2.ConvertNumericData = loadOptions_0.ConvertNumericData;
			StreamReader streamReader_;
			if (Settings.bool_12)
			{
				streamReader_ = new StreamReader(stream_0);
			}
			else
			{
				streamReader_ = new StreamReader(stream_0, Settings.Encoding);
				txtLoadOptions2.Encoding = Settings.Encoding;
			}
			Class1731.Read(streamReader_, worksheetCollection_0[0].Cells, 0, 0, txtLoadOptions2);
			break;
		}
		}
	}

	private void method_8(Class1317 class1317_0)
	{
		ArrayList arrayList = new ArrayList();
		foreach (string key in class1317_0.method_9().Keys)
		{
			switch (key)
			{
			case "\u0005SummaryInformation":
			case "\u0005DocumentSummaryInformation":
				continue;
			}
			arrayList.Add(key);
		}
		for (int i = 0; i < arrayList.Count; i++)
		{
			class1317_0.method_9().Remove(arrayList[i]);
		}
	}

	/// <summary>
	///       Opens a preset designer spreadsheet from stream.
	///       </summary>
	/// <param name="stream">Stream which contains the preset designer spreadsheet.</param>
	/// <remarks>
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook(Stream) constructor.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Workbook(Stream) constructor method instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void Open(Stream stream)
	{
		if (stream.Length == 0)
		{
			return;
		}
		bool flag = false;
		if (!stream.CanSeek)
		{
			byte[] array = new byte[(int)stream.Length];
			int num = 0;
			int num2 = 0;
			while (num2 > 0)
			{
				num2 = stream.Read(array, num, array.Length - num);
				num += num2;
			}
			stream = new MemoryStream(array);
			flag = true;
		}
		stream.Seek(0L, SeekOrigin.Begin);
		bool isValid = false;
		int header = 0;
		FileFormatType fileFormatType = Class1677.smethod_7(null, stream, out isValid, out header);
		if (isValid)
		{
			if (fileFormatType == FileFormatType.Xlsx)
			{
				if (!flag)
				{
					MemoryStream memoryStream = new MemoryStream();
					Class1677.smethod_5(stream, memoryStream);
					memoryStream.Position = 0L;
					stream = memoryStream;
				}
				method_11(stream);
				Class1558 @class = class1558_0;
				Class746 class746_ = @class.class1553_0.class746_0;
				if (class746_.method_40("xl/workbook.xml", bool_18: true) != -1)
				{
					fileFormatType = FileFormatType.Xlsx;
					method_2(FileFormatType.Xlsx, bool_2: false);
					class1558_0 = @class;
					Class1614.smethod_0(this);
					return;
				}
				if (class746_.method_40("xl/workbook.bin", bool_18: true) != -1)
				{
					fileFormatType = FileFormatType.Xlsb;
					method_2(FileFormatType.Xlsb, bool_2: false);
					class1558_0 = @class;
					Class1218 class2 = new Class1218(this);
					class2.Read();
					return;
				}
				if (class746_.method_40("content.xml", bool_18: true) != -1)
				{
					fileFormatType = FileFormatType.ODS;
					method_2(FileFormatType.ODS, bool_2: false);
					Class1521 class3 = new Class1521(this);
					class3.Read(class746_);
					class1558_0 = null;
					return;
				}
			}
			Open(stream, fileFormatType);
			return;
		}
		switch (header)
		{
		case 1033:
			throw new CellsException(ExceptionType.UnsupportedFeature, "This Excel files contains (Excel4.0 or earlier file format) records.");
		default:
			throw new CellsException(ExceptionType.FileFormat, "This file's format is not supported or you don't specify a correct format.");
		case 521:
			throw new CellsException(ExceptionType.UnsupportedFeature, "This Excel files contains (Excel3.0 or earlier file format) records.");
		}
	}

	/// <summary>
	///       Opens a file and imports its data.
	///       </summary>
	/// <param name="stream">Stream which contains the file.</param>
	/// <param name="type">File type.</param>
	/// <remarks>
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook(Stream,LoadOptions) constructor.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[Obsolete("Use Workbook(Stream,LoadOptions) constructor method instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void Open(Stream stream, FileFormatType type)
	{
		if (stream.Length == 0)
		{
			return;
		}
		switch (type)
		{
		case FileFormatType.AsposePdf:
			throw new CellsException(ExceptionType.UnsupportedFeature, "Unsupported file format.");
		case FileFormatType.CSV:
		{
			method_2(type, bool_2: false);
			TxtLoadOptions txtLoadOptions = new TxtLoadOptions();
			txtLoadOptions.ConvertNumericData = Settings.ConvertNumericData;
			StreamReader streamReader_;
			if (Settings.bool_12)
			{
				streamReader_ = new StreamReader(stream);
			}
			else
			{
				streamReader_ = new StreamReader(stream, Settings.Encoding);
				txtLoadOptions.Encoding = Settings.Encoding;
			}
			Class1731.Read(streamReader_, worksheetCollection_0[0].Cells, 0, 0, txtLoadOptions);
			break;
		}
		case FileFormatType.Xlsx:
		case FileFormatType.Xlsm:
		case FileFormatType.Xltx:
		case FileFormatType.Xltm:
		{
			method_2(type, bool_2: false);
			BinaryReader binaryReader2 = new BinaryReader(stream);
			long num2 = binaryReader2.ReadInt64();
			stream.Seek(0L, SeekOrigin.Begin);
			if (num2 == -2226271756974174256L)
			{
				stream = method_29(new Class1317(stream));
			}
			method_11(stream);
			Class1614.smethod_0(this);
			break;
		}
		case FileFormatType.TabDelimited:
		{
			method_2(type, bool_2: false);
			TxtLoadOptions txtLoadOptions2 = new TxtLoadOptions();
			txtLoadOptions2.ConvertNumericData = Settings.ConvertNumericData;
			StreamReader streamReader_;
			if (Settings.bool_12)
			{
				streamReader_ = new StreamReader(stream);
			}
			else
			{
				streamReader_ = new StreamReader(stream, Settings.Encoding);
				txtLoadOptions2.Encoding = Settings.Encoding;
			}
			txtLoadOptions2.Separator = '\t';
			Class1731.Read(streamReader_, worksheetCollection_0[0].Cells, 0, 0, txtLoadOptions2);
			break;
		}
		default:
		{
			method_2(type, bool_2: false);
			Class1730 class4 = new Class1730(this);
			Class1317 class1317_ = class4.Read(stream);
			Worksheets.method_11(class1317_);
			break;
		}
		case FileFormatType.ODS:
		{
			method_2(type, bool_2: false);
			Class1521 class3 = new Class1521(this);
			class3.Read(stream);
			break;
		}
		case FileFormatType.SpreadsheetML:
		case FileFormatType.Excel2003XML:
		{
			method_2(type, bool_2: false);
			Class1105 class2 = new Class1105();
			class2.method_0(stream, this);
			break;
		}
		case FileFormatType.Xlsb:
		{
			method_2(type, bool_2: false);
			BinaryReader binaryReader = new BinaryReader(stream);
			long num = binaryReader.ReadInt64();
			stream.Seek(0L, SeekOrigin.Begin);
			if (num == -2226271756974174256L)
			{
				stream = method_29(new Class1317(stream));
			}
			method_11(stream);
			Class1218 @class = new Class1218(this);
			@class.Read();
			break;
		}
		}
	}

	/// <summary>
	///       Opens a file and imports its data.
	///       </summary>
	/// <param name="stream">Stream which contains the file.</param>
	/// <param name="type">File type.</param>
	/// <param name="password">File encryption password.</param>
	/// <remarks>
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook(Stream,LoadOptions) constructor.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Workbook(Stream,LoadOptions) constructor method instead.")]
	[Browsable(false)]
	public void Open(Stream stream, FileFormatType type, string password)
	{
		Settings.Password = password;
		Open(stream, type);
	}

	/// <summary>
	///       Opens text files stream with user defined separator.
	///       </summary>
	/// <param name="stream">Text file stream.</param>
	/// <param name="separator">Delimiter of text file.</param>
	/// <remarks>Some users want to open csv file which is separated with ';', not ','. 
	///       We provide this method to allow users to set their own separator. 
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook(Stream,LoadOptions) constructor.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Workbook(Stream,TxtLoadOptions) constructor method instead.")]
	public void Open(Stream stream, char separator)
	{
		method_2(FileFormatType.CSV, bool_2: false);
		TxtLoadOptions txtLoadOptions = new TxtLoadOptions();
		txtLoadOptions.ConvertNumericData = Settings.ConvertNumericData;
		txtLoadOptions.Separator = separator;
		StreamReader streamReader_;
		if (Settings.bool_12)
		{
			streamReader_ = new StreamReader(stream);
		}
		else
		{
			streamReader_ = new StreamReader(stream, Settings.Encoding);
			txtLoadOptions.Encoding = Settings.Encoding;
		}
		Class1731.Read(streamReader_, worksheetCollection_0[0].Cells, 0, 0, txtLoadOptions);
	}

	/// <summary>
	///       Opens a preset designer spreadsheet.
	///       </summary>
	/// <param name="fileName">The preset designer spreadsheet.</param>
	/// <remarks>
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook(string) constructor.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Workbook(string) constructor method instead.")]
	public void Open(string fileName)
	{
		FileStream fileStream = null;
		try
		{
			fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			if (fileStream.Length == 0)
			{
				return;
			}
			bool isValid = false;
			int header = 0;
			FileFormatType type = Class1677.smethod_7(fileName, fileStream, out isValid, out header);
			if (!isValid)
			{
				switch (header)
				{
				case 1033:
					throw new CellsException(ExceptionType.UnsupportedFeature, "This Excel files contains (Excel4.0 or earlier file format) records.");
				default:
					throw new CellsException(ExceptionType.FileFormat, "This file's format is not supported or you don't specify a correct format.");
				case 521:
					throw new CellsException(ExceptionType.UnsupportedFeature, "This Excel files contains (Excel3.0 or earlier file format) records.");
				}
			}
			Open(fileStream, type);
		}
		finally
		{
			fileStream?.Close();
		}
		method_10(fileName);
	}

	/// <summary>
	///       Opens a file and imports its data.
	///       </summary>
	/// <param name="fileName">Name of file to be imported.</param>
	/// <param name="type">File type.</param>
	/// <remarks>
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook(string,LoadOptions) constructor.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Workbook(string,LoadOptions) constructor method instead.")]
	[Browsable(false)]
	public void Open(string fileName, FileFormatType type)
	{
		method_10(fileName);
		switch (type)
		{
		case FileFormatType.AsposePdf:
			throw new CellsException(ExceptionType.UnsupportedFeature, "Unsupported file format.");
		case FileFormatType.CSV:
		{
			method_2(FileFormatType.CSV, bool_2: false);
			int num2 = fileName.LastIndexOf("\\");
			string[] array = fileName.Substring(num2 + 1).Split('.');
			if (array[0] != null && array[0] != "")
			{
				worksheetCollection_0[0].method_7(array[0]);
			}
			TxtLoadOptions txtLoadOptions2 = new TxtLoadOptions();
			txtLoadOptions2.ConvertNumericData = Settings.ConvertNumericData;
			if (!Settings.bool_12)
			{
				txtLoadOptions2.Encoding = Settings.Encoding;
			}
			Class1731.Read(fileName, worksheetCollection_0[0].Cells, 0, 0, txtLoadOptions2);
			return;
		}
		case FileFormatType.Xlsx:
		case FileFormatType.Xlsm:
		case FileFormatType.Xltx:
		case FileFormatType.Xltm:
		{
			method_2(type, bool_2: false);
			method_10(fileName);
			Stream stream3 = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			BinaryReader binaryReader2 = new BinaryReader(stream3);
			long num3 = binaryReader2.ReadInt64();
			stream3.Seek(0L, SeekOrigin.Begin);
			if (num3 == -2226271756974174256L)
			{
				Stream stream4 = method_29(new Class1317(stream3));
				stream3.Close();
				stream3 = stream4;
			}
			method_11(stream3);
			Class1614.smethod_0(this);
			stream3.Close();
			return;
		}
		case FileFormatType.TabDelimited:
		{
			method_2(type, bool_2: false);
			TxtLoadOptions txtLoadOptions = new TxtLoadOptions();
			txtLoadOptions.ConvertNumericData = Settings.ConvertNumericData;
			if (!Settings.bool_12)
			{
				txtLoadOptions.Encoding = Settings.Encoding;
			}
			txtLoadOptions.Separator = '\t';
			Class1731.Read(fileName, worksheetCollection_0[0].Cells, 0, 0, txtLoadOptions);
			return;
		}
		case FileFormatType.ODS:
		{
			method_2(type, bool_2: false);
			Class1521 class4 = new Class1521(this);
			class4.Read(fileName);
			return;
		}
		case FileFormatType.SpreadsheetML:
		case FileFormatType.Excel2003XML:
		{
			method_2(type, bool_2: false);
			FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			Class1105 class3 = new Class1105();
			try
			{
				class3.method_0(fileStream, this);
				return;
			}
			catch (Exception)
			{
				throw new CellsException(ExceptionType.Interrupted, "Error in opening SpreadsheetML file.");
			}
			finally
			{
				fileStream.Close();
			}
		}
		case FileFormatType.Xlsb:
		{
			method_2(type, bool_2: false);
			method_10(fileName);
			using Stream stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			BinaryReader binaryReader = new BinaryReader(stream);
			long num = binaryReader.ReadInt64();
			stream.Seek(0L, SeekOrigin.Begin);
			if (num == -2226271756974174256L)
			{
				Stream stream2 = method_29(new Class1317(stream));
				stream.Close();
				method_11(stream2);
				Class1218 @class = new Class1218(this);
				@class.Read();
				stream2.Close();
			}
			else
			{
				method_11(stream);
				Class1218 class2 = new Class1218(this);
				class2.Read();
				stream.Close();
			}
			return;
		}
		}
		FileStream fileStream2 = null;
		try
		{
			fileStream2 = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			if (fileStream2.Length != 0)
			{
				method_2(type, bool_2: false);
				method_10(fileName);
				Class1730 class5 = new Class1730(this);
				Class1317 class1317_ = class5.Read(fileStream2);
				Worksheets.method_11(class1317_);
			}
		}
		finally
		{
			fileStream2?.Close();
		}
	}

	/// <summary>
	///       Opens a file and imports its data.
	///       </summary>
	/// <param name="fileName">Name of file to be imported.</param>
	/// <param name="type">File type.</param>
	/// <param name="password">File encryption password.</param>
	/// <remarks>
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook(string,LoadOptions) constructor.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Workbook(string,TxtLoadOptions) constructor method instead.")]
	[Browsable(false)]
	public void Open(string fileName, FileFormatType type, string password)
	{
		Settings.Password = password;
		Open(fileName, type);
	}

	/// <summary>
	///       Opens text files with user defined separator.
	///       </summary>
	/// <param name="fileName">Text file name.</param>
	/// <param name="separator">Delimiter of text file.</param>
	/// <remarks>Some users want to open csv file which is separated with ';', not ','. 
	///       We provide this method to allow users to set their own separator. 
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook(string,LoadOptions) constructor.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Workbook(string,TxtLoadOptions) constructor method instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public void Open(string fileName, char separator)
	{
		method_10(fileName);
		method_2(FileFormatType.CSV, bool_2: false);
		TxtLoadOptions txtLoadOptions = new TxtLoadOptions();
		txtLoadOptions.ConvertNumericData = Settings.ConvertNumericData;
		txtLoadOptions.Separator = separator;
		if (!Settings.bool_12)
		{
			txtLoadOptions.Encoding = Settings.Encoding;
		}
		Class1731.Read(fileName, worksheetCollection_0[0].Cells, 0, 0, txtLoadOptions);
	}

	/// <summary>
	///       Opens text files with user defined separator.
	///       </summary>
	/// <param name="fileName">Name of file to be imported.</param>
	/// <param name="separator">Delimiter of text file.</param>
	/// <remarks>
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook(string,LoadOptions) constructor.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Workbook(string,TxtLoadOptions) constructor method instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public void Open(string fileName, string separator)
	{
		method_10(fileName);
		FileStream fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		Open(fileStream, separator);
		fileStream.Close();
	}

	/// <summary>
	///       Opens streams with user defined separator.
	///       </summary>
	/// <param name="stream">The stream to be imported.</param>
	/// <param name="separator">Delimiter of text file.</param>
	/// <remarks>
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook(string,LoadOptions) constructor.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Workbook(string,TxtLoadOptions) constructor method instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void Open(Stream stream, string separator)
	{
		method_2(FileFormatType.CSV, bool_2: false);
		StreamReader streamReader_ = (Settings.bool_12 ? new StreamReader(stream) : new StreamReader(stream, Settings.Encoding));
		TxtLoadOptions txtLoadOptions = new TxtLoadOptions();
		txtLoadOptions.ConvertNumericData = Settings.ConvertNumericData;
		txtLoadOptions.SeparatorString = separator;
		if (!Settings.bool_12)
		{
			txtLoadOptions.Encoding = Settings.Encoding;
		}
		Class1731.Read(streamReader_, worksheetCollection_0[0].Cells, 0, 0, txtLoadOptions);
	}

	/// <summary>
	///       Saves Excel file to a MemoryStream object and returns it.
	///       </summary>
	/// <returns>MemoryStream object which contains an Excel file.</returns>
	/// <remarks>
	///
	///       This method provides same function as Save method and only save the workbook as Excel97-2003 xls file. 
	///       It's mainly for calling from COM clients.</remarks>
	public MemoryStream SaveToStream()
	{
		MemoryStream memoryStream = new MemoryStream();
		Save(memoryStream, new XlsSaveOptions(SaveOptions));
		return memoryStream;
	}

	/// <summary>
	///       Creates the result spreadsheet to the stream.
	///       </summary>
	/// <param name="stream">Stream where to save the spreadsheet.</param>
	/// <param name="fileFormatType">Excel file format type.</param>
	/// <remarks>
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook.Save(Stream,SaveFormat) method.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Workbook.Save(Stream,SaveFormat) method instead.")]
	public void Save(Stream stream, FileFormatType fileFormatType)
	{
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			Worksheet worksheet = worksheetCollection_0[i];
			worksheet.SheetIndex = i;
		}
		FileFormat = fileFormatType;
		Save(stream, FileFormatUtil.smethod_3(fileFormatType, SaveOptions));
	}

	/// <summary>
	///       Creates text files with user defined separator.
	///       </summary>
	/// <param name="stream">Stream where to save the text file.</param>
	/// <param name="separator">Delimiter of text file.</param>
	/// <remarks>Some users want to create csv file which is separated with ';', not ','. 
	///       We provide this method to allow users to set their own separator. 
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook.Save(Stream,SaveFormat) method.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Workbook.Save(Stream,SaveFormat) method instead.")]
	[Browsable(false)]
	public void Save(Stream stream, char separator)
	{
		TxtSaveOptions txtSaveOptions = new TxtSaveOptions();
		txtSaveOptions.Separator = separator;
		Save(stream, txtSaveOptions);
	}

	/// <summary>
	///       Creates text files with user defined separator with specific text coding..
	///       </summary>
	/// <param name="stream">Stream where to save the text file.</param>
	/// <param name="separator">Delimiter of text file.</param>
	/// <param name="encoding">The text encoding.Ms Excel only support ASCII and Unicode.</param>
	/// <remarks>Some users want to create csv file which is separated with ';', not ','. 
	///       We provide this method to allow users to set their own separator.
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook.Save(Stream,SaveFormat) method.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Workbook.Save(Stream,SaveFormat) method instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public void Save(Stream stream, char separator, Encoding encoding)
	{
		TxtSaveOptions txtSaveOptions = new TxtSaveOptions();
		txtSaveOptions.Separator = separator;
		txtSaveOptions.Encoding = encoding;
		Save(stream, txtSaveOptions);
	}

	/// <summary>
	///       Creates and saves the specified file to the disk.
	///       </summary>
	/// <param name="fileName">The name of created file.</param>
	/// <remarks>
	///   <p>File format is according to file extension.</p>
	///       After calling Save method, data in Workbook instance will be reset.</remarks>
	public void Save(string fileName)
	{
		string extension = Path.GetExtension(fileName);
		FileFormatType fileFormatType = FileFormatUtil.smethod_2(extension, fileFormatType_0);
		Save(fileName, FileFormatUtil.smethod_3(fileFormatType, SaveOptions));
	}

	/// <summary>
	///        Creates and saves the specified to the disk.
	///        </summary>
	/// <param name="fileName">The name of created file.</param>
	/// <param name="fileFormatType">Excel file format type</param>
	/// <remarks>After calling Save method, data in Workbook instance will be reset.</remarks>
	/// <example>
	///   <code>
	///
	///       [C#]
	///
	///       Workbook workbook = new Workbook();
	///       Worksheets sheets = workbook.Worksheets;
	///       Cells cells = sheets[0].Cells;
	///       cells["A1"].PutValue("Hello world!");
	///       workbook.Save(@"D:\test.xls");
	///
	///       [Visual Basic]
	///
	///       Dim workbook As Workbook =  New Workbook() 
	///       Dim sheets As Worksheets =  workbook.Worksheets 
	///       Dim cells As Cells =  sheets(0).Cells 
	///       cells("A1").PutValue("Hello world!")
	///       workbook.Save("D:\test.xls")
	///       </code>
	/// </example>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///        please use Workbook.Save(string,SaveFormat) method.
	///        This property will be removed 12 months later since JULY 2010. 
	///        Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Workbook.Save(string,SaveFormat) method instead.")]
	public void Save(string fileName, FileFormatType fileFormatType)
	{
		Save(fileName, FileFormatUtil.smethod_3(fileFormatType, SaveOptions));
	}

	/// <summary>
	///        Creates the result spreadsheet and transfer it to the client then open it in the browser or MS Workbook.
	///        </summary>
	/// <param name="fileName">The name of created file.</param>
	/// <param name="fileFormatType">Excel file format type</param>
	/// <param name="saveType">Save type</param>
	/// <param name="response">Response object to return the spreadsheet to client.</param>
	/// <example>
	///   <code>
	///       [C#]
	///
	///       		Workbook workbook = new Workbook();
	///       		Worksheets sheets = workbook.Worksheets;
	///       		Cells cells = sheets[0].Cells;
	///       		cells["A1"].PutValue(1234);
	///       		workbook.Save("test.xls", FileFormatType.Excel97To2003, SaveType.OpenInWorkbook, Response);
	///
	///       [Visual Basic]
	///
	///        Dim workbook As Workbook =  New Workbook() 
	///        Dim sheets As Worksheets =  workbook.Worksheets 
	///        Dim cells As Cells =  sheets(0).Cells 
	///        cells("A1").PutValue(1234)
	///        workbook.Save("test.xls", FileFormatType.Excel97To2003, SaveType.OpenInWorkbook, Response)		
	///
	///        </code>
	/// </example>
	/// <remarks>
	///   <br>This method only send spreadsheets or CSV file to client. 
	///        If you want to convert the file to Aspose.Pdf xml format or SpreadsheetML format, please save it to disk or stream.</br>
	///        After calling Save method, data in Workbook instance will be reset.      
	///        NOTE: This member is now obsolete. Instead, 
	///        please use Workbook.Save(System.Web.HttpResponse, string, ContentDisposition, SaveOptions) method.
	///        This property will be removed 12 months later since JULY 2010. 
	///        Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Workbook.Save(System.Web.HttpResponse, string, ContentDisposition, SaveOptions) method instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public void Save(string fileName, FileFormatType fileFormatType, SaveType saveType, HttpResponse response)
	{
		Save(fileName, saveType, fileFormatType, response);
	}

	/// <summary>
	///       Creates the result spreadsheet and transfer it to the client then open it in the browser or MS Workbook.
	///       </summary>
	/// <param name="fileName">The name of created file.</param>
	/// <param name="fileFormatType">Excel file format type</param>
	/// <param name="saveType">Save type</param>
	/// <param name="response">Response object to return the spreadsheet to client.</param>
	/// <param name="encoding"> Only applies for CSV/TabDelimited file format type</param>
	/// <remarks>
	///   <br>This method only send spreadsheets or CSV file to client. 
	///       If you want to convert the file to Aspose.Pdf xml format or SpreadsheetML format, please save it to disk or stream.</br>
	///       After calling Save method, data in Workbook instance will be reset.
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook.Save(System.Web.HttpResponse, string, ContentDisposition, SaveOptions) method.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Workbook.Save(System.Web.HttpResponse, string, ContentDisposition, SaveOptions) method instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void Save(string fileName, FileFormatType fileFormatType, SaveType saveType, HttpResponse response, Encoding encoding)
	{
		Save(fileName, saveType, fileFormatType, response, encoding);
	}

	/// <summary>
	///        Creates the result spreadsheet and transfer it to the client then open it in the browser or MS Workbook.
	///        </summary>
	/// <param name="fileName">The name of created file.</param>
	/// <param name="saveType">Save type</param>
	/// <param name="fileFormatType">Excel file format type</param>
	/// <param name="response">Response object to return the spreadsheet to client.</param>
	/// <example>
	///   <code>
	///       [C#]
	///
	///       	Workbook workbook = new Workbook();
	///       	Worksheets sheets = workbook.Worksheets;
	///       	Cells cells = sheets[0].Cells;
	///       	cells["A1"].PutValue(1234);
	///       	workbook.Save("test.xls", SaveType.OpenInExcel, FileFormatType.Excel97To2003, Response);
	///
	///       [Visual Basic]
	///
	///        Dim workbook As Workbook =  New Workbook() 
	///        Dim sheets As Worksheets =  workbook.Worksheets 
	///        Dim cells As Cells =  sheets(0).Cells 
	///        cells("A1").PutValue(1234)
	///        workbook.Save("test.xls", SaveType.OpenInExcel, FileFormatType.Excel97To2003, Response)		///</code>
	/// </example>
	/// <remarks>
	///   <p>This method only send spreadsheets or CSV file to client. 
	///        If you want to convert the file to Aspose.Pdf xml format or SpreadsheetML format, please save it to disk or stream.</p>
	///        After calling Save method, data in Workbook instance will be reset.
	///        NOTE: This member is now obsolete. Instead, 
	///        please use Workbook.Save(System.Web.HttpResponse, string, ContentDisposition, SaveOptions) method.
	///        This property will be removed 12 months later since JULY 2010. 
	///        Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Workbook.Save(System.Web.HttpResponse, string, ContentDisposition, SaveOptions) method instead.")]
	[Browsable(false)]
	public void Save(string fileName, SaveType saveType, FileFormatType fileFormatType, HttpResponse response)
	{
		Save(fileName, saveType, fileFormatType, response, Settings.Encoding);
	}

	/// <summary>
	///       Creates the result spreadsheet and transfer it to the client then open it in the browser or MS Workbook.
	///       </summary>
	/// <param name="fileName">The name of created file.</param>
	/// <param name="saveType">Save type</param>
	/// <param name="fileFormatType">Excel file format type</param>
	/// <param name="response">Response object to return the spreadsheet to client.</param>
	/// <param name="encoding">Text encoding. Only applies for CSV/TabDelimited file format type</param>
	/// <remarks>
	///   <p>This method only send spreadsheets or CSV file to client. 
	///       If you want to convert the file to Aspose.Pdf xml format or SpreadsheetML format, please save it to disk or stream.</p>
	///       After calling Save method, data in Workbook instance will be reset.
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook.Save(System.Web.HttpResponse, string, ContentDisposition, SaveOptions) method.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Workbook.Save(System.Web.HttpResponse, string, ContentDisposition, SaveOptions) method instead.")]
	public void Save(string fileName, SaveType saveType, FileFormatType fileFormatType, HttpResponse response, Encoding encoding)
	{
		if (worksheetCollection_0.Count < 1)
		{
			throw new Exception("None worksheet exists.");
		}
		SaveOptions saveOptions = FileFormatUtil.smethod_3(fileFormatType, SaveOptions);
		if (saveOptions is TxtSaveOptions)
		{
			((TxtSaveOptions)saveOptions).Encoding = encoding;
		}
		if (saveType == SaveType.Default)
		{
			Save(fileName, saveOptions);
		}
		else
		{
			Save(response, fileName, (saveType != SaveType.OpenInBrowser) ? ContentDisposition.Attachment : ContentDisposition.Inline, saveOptions);
		}
	}

	/// <summary>
	///       Creates text files with user defined separator.
	///       </summary>
	/// <param name="fileName">Text file name.</param>
	/// <param name="separator">Delimiter of text file.</param>
	/// <remarks>Some users want to create csv file which is separated with ';', not ','. 
	///       We provide this method to allow users to set their own separator. 
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook.Save(string,SaveOptions) method.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Workbook.Save(string,SaveOptions) method instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void Save(string fileName, char separator)
	{
		TxtSaveOptions txtSaveOptions = new TxtSaveOptions();
		txtSaveOptions.Separator = separator;
		Save(fileName, txtSaveOptions);
	}

	/// <summary>
	///       Creates text files with user defined separator with specific text coding..
	///       </summary>
	/// <param name="fileName">Text file name.</param>
	/// <param name="separator">Delimiter of text file.</param>
	/// <param name="encoding">The text encoding.Ms Excel only support ASCII and Unicode.</param>
	/// <remarks>Some users want to create csv file which is separated with ';', not ','. 
	///       We provide this method to allow users to set their own separator. 
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook.Save(string,SaveOptions) method.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Workbook.Save(string,SaveOptions) method instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public void Save(string fileName, char separator, Encoding encoding)
	{
		TxtSaveOptions txtSaveOptions = new TxtSaveOptions();
		txtSaveOptions.Separator = separator;
		txtSaveOptions.Encoding = encoding;
		Save(fileName, txtSaveOptions);
	}

	/// <summary>
	///       Export the workbook to Html file.
	///       </summary>
	/// <param name="fileName">Text file name.</param>
	/// <param name="isWhole">Indicates whether export the whole workbook or only the active sheet.</param>
	/// <param name="title">The title of the html page.</param>
	/// <remarks>
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook.Save(string,SaveOptions) method.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use Workbook.Save(string,SaveOptions) method instead.")]
	public void Save(string fileName, bool isWhole, string title)
	{
		string text = null;
		if (!isWhole)
		{
			text = Worksheets[Worksheets.ActiveSheetIndex].Name;
		}
		HtmlSaveOptions htmlSaveOptions = new HtmlSaveOptions();
		htmlSaveOptions.PageTitle = title;
		Class1485 @class = new Class1485(this, fileName, text, htmlSaveOptions);
		@class.method_0();
		if (SaveOptions.ClearData)
		{
			Initialize();
		}
		else
		{
			method_1();
		}
	}

	/// <summary>
	///       Export the active worksheet to Html stream.
	///       </summary>
	/// <param name="stream">Text output stream</param>
	/// <param name="title">The title of the html page.</param>
	/// <remarks>
	///       Only export the active worksheet.
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook.Save(Stream,SaveOptions) method.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Workbook.Save(Stream,SaveOptions) method instead.")]
	[Browsable(false)]
	public void Save(Stream stream, string title)
	{
		string name = Worksheets[Worksheets.ActiveSheetIndex].Name;
		HtmlSaveOptions htmlSaveOptions = new HtmlSaveOptions();
		htmlSaveOptions.PageTitle = title;
		Class1485 @class = new Class1485(this, stream, name, htmlSaveOptions);
		@class.method_0();
		if (SaveOptions.ClearData)
		{
			Initialize();
		}
		else
		{
			method_1();
		}
	}

	/// <summary>
	///       Creates text files with user defined separator.
	///       </summary>
	/// <param name="fileName">Text file name.</param>
	/// <param name="separator">Delimiter of text file.</param>
	/// <remarks>Some users want to create csv file which is separated with ';', not ','. 
	///       We provide this method to allow users to set their own separator. 
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook.Save(string,SaveOptions) method.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Workbook.Save(string,SaveOptions) method instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public void SaveToCSV(string fileName, string separator)
	{
		TxtSaveOptions txtSaveOptions = new TxtSaveOptions();
		txtSaveOptions.SeparatorString = separator;
		Save(fileName, txtSaveOptions);
	}

	/// <summary>
	///       Creates text files with user defined separator.
	///       </summary>
	/// <param name="stream">Stream where to save the text file.</param>
	/// <param name="separator">Delimiter of text file.</param>
	/// <remarks>Some users want to create csv file which is separated with ';', not ','. 
	///       We provide this method to allow users to set their own separator. 
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook.Save(Stream,SaveOptions) method.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Workbook.Save(Stream,SaveOptions) method instead.")]
	public void SaveToCSV(Stream stream, string separator)
	{
		TxtSaveOptions txtSaveOptions = new TxtSaveOptions();
		txtSaveOptions.SeparatorString = separator;
		Save(stream, txtSaveOptions);
	}

	/// <summary>
	///       Save the workbook to the disk.
	///       </summary>
	/// <param name="fileName">The file name.</param>
	/// <param name="saveFormat">The save format type.</param>
	public void Save(string fileName, SaveFormat saveFormat)
	{
		SaveOptions saveOptions = FileFormatUtil.smethod_1(fileName, saveFormat, saveOptions_0);
		Save(fileName, saveOptions);
	}

	/// <summary>
	///       Save the workbook to the disk.
	///       </summary>
	/// <param name="fileName">The file name.</param>
	/// <param name="saveOptions">The save options.</param>
	public void Save(string fileName, SaveOptions saveOptions)
	{
		if (saveOptions.CreateDirectory)
		{
			string directoryName = Path.GetDirectoryName(fileName);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
		}
		if (saveOptions is HtmlSaveOptions)
		{
			saveOptions_0 = saveOptions;
			string text = null;
			HtmlSaveOptions htmlSaveOptions = (HtmlSaveOptions)saveOptions;
			if (htmlSaveOptions.ExportActiveWorksheetOnly)
			{
				text = Worksheets[Worksheets.ActiveSheetIndex].Name;
			}
			Class1485 @class = new Class1485(this, fileName, text, htmlSaveOptions);
			@class.method_0();
			return;
		}
		if (saveOptions is OoxmlSaveOptions)
		{
			SaveFormat saveFormat = FileFormatUtil.ExtensionToSaveFormat(Path.GetExtension(fileName));
			switch (saveFormat)
			{
			case SaveFormat.Xlsx:
			case SaveFormat.Xlsm:
			case SaveFormat.Xltx:
			case SaveFormat.Xltm:
				saveOptions.method_0(saveFormat);
				break;
			}
		}
		FileStream fileStream = File.Create(fileName);
		try
		{
			Save(fileStream, saveOptions);
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			fileStream?.Close();
		}
		if (string_0 == null || string_0 == "")
		{
			string_0 = fileName;
		}
	}

	/// <summary>
	///       Save the workbook to the stream.
	///       </summary>
	/// <param name="stream">The file stream.</param>
	/// <param name="saveFormat">The save file format type.</param>
	public void Save(Stream stream, SaveFormat saveFormat)
	{
		SaveOptions saveOptions = FileFormatUtil.smethod_1(null, saveFormat, saveOptions_0);
		saveOptions.Copy(saveOptions_0);
		Save(stream, saveOptions);
	}

	/// <summary>
	///       Save the workbook to the stream.
	///       </summary>
	/// <param name="stream">The file stream.</param>
	/// <param name="saveOptions">The save options.</param>
	public void Save(Stream stream, SaveOptions saveOptions)
	{
		saveOptions_0 = saveOptions;
		if (saveOptions.RefreshChartCache)
		{
			for (int i = 0; i < Worksheets.Count; i++)
			{
				Worksheet worksheet = Worksheets[i];
				for (int j = 0; j < worksheet.Charts.Count; j++)
				{
					worksheet.Charts[j].RefreshData();
				}
			}
		}
		for (int k = 0; k < worksheetCollection_0.Count; k++)
		{
			Worksheet worksheet2 = worksheetCollection_0[k];
			worksheet2.SheetIndex = k;
		}
		FileFormatType fileFormatType = FileFormatUtil.smethod_0(saveOptions.SaveFormat, fileFormatType_0);
		if (saveOptions is SpreadsheetML2003SaveOptions)
		{
			method_20(fileFormatType, ((SpreadsheetML2003SaveOptions)saveOptions).LimitAsXls);
		}
		else
		{
			FileFormat = fileFormatType;
		}
		switch (saveOptions.SaveFormat)
		{
		case SaveFormat.Xlsx:
		case SaveFormat.Xlsm:
		case SaveFormat.Xltx:
		case SaveFormat.Xltm:
			if ((Settings.Password == null || Settings.Password == "") && Settings.IsProtected && Worksheets.method_81() != 0)
			{
				Settings.Password = "VelvetSweatshop";
			}
			if (Settings.Password != null && Settings.Password != "")
			{
				MemoryStream memoryStream3 = new MemoryStream();
				Class1593.smethod_0(this, memoryStream3, fileFormatType, saveOptions);
				memoryStream3.Seek(0L, SeekOrigin.Begin);
				Class1636 class9 = new Class1636(Settings.Password, int_0);
				MemoryStream memoryStream_2 = class9.method_4();
				memoryStream3 = class9.method_5(memoryStream3);
				Class1317 class10 = new Class1317(WorksheetCollection.guid_0);
				class10.method_9().Add("EncryptionInfo", memoryStream_2);
				class10.method_9().Add("EncryptedPackage", memoryStream3);
				class10.Save(stream);
			}
			else
			{
				Class1593.smethod_0(this, stream, fileFormatType, saveOptions);
			}
			if (SaveOptions.ClearData)
			{
				Initialize();
			}
			else
			{
				method_1();
			}
			break;
		case SaveFormat.CSV:
		case SaveFormat.TabDelimited:
		{
			TxtSaveOptions txtSaveOptions_ = TxtSaveOptions.smethod_0(Settings, saveOptions.SaveFormat, saveOptions);
			Class1727.Write(stream, this, txtSaveOptions_);
			break;
		}
		case SaveFormat.Html:
		{
			HtmlSaveOptions htmlSaveOptions2 = (HtmlSaveOptions)saveOptions;
			string text = null;
			if (htmlSaveOptions2.bool_10 || htmlSaveOptions2.ExportActiveWorksheetOnly)
			{
				text = Worksheets[Worksheets.ActiveSheetIndex].Name;
			}
			Class1485 class3 = new Class1485(this, stream, text, htmlSaveOptions2);
			class3.method_0();
			if (SaveOptions.ClearData)
			{
				Initialize();
			}
			else
			{
				method_1();
			}
			break;
		}
		case SaveFormat.Pdf:
		{
			Class1243 class11 = new Class1243(this);
			class11.method_9(stream);
			if (SaveOptions.ClearData)
			{
				Initialize();
			}
			else
			{
				method_1();
			}
			break;
		}
		case SaveFormat.ODS:
		{
			method_5();
			Class1522 class4 = new Class1522(this);
			class4.Write(stream);
			if (SaveOptions.ClearData)
			{
				Initialize();
			}
			else
			{
				method_1();
			}
			break;
		}
		case SaveFormat.SpreadsheetML:
			Class1630.smethod_2(this, stream, saveOptions);
			if (SaveOptions.ClearData)
			{
				Initialize();
			}
			else
			{
				method_1();
			}
			break;
		case SaveFormat.Xlsb:
			if ((Settings.Password == null || Settings.Password == "") && Settings.IsProtected && Worksheets.method_81() != 0)
			{
				Settings.Password = "VelvetSweatshop";
			}
			if (Settings.Password != null && Settings.Password != "")
			{
				MemoryStream memoryStream2 = new MemoryStream();
				Class1229 class5 = new Class1229(this, HasMacro);
				class5.Write(memoryStream2);
				memoryStream2.Seek(0L, SeekOrigin.Begin);
				Class1636 class6 = new Class1636(Settings.Password, int_0);
				MemoryStream memoryStream_ = class6.method_4();
				memoryStream2 = class6.method_5(memoryStream2);
				Class1317 class7 = new Class1317(WorksheetCollection.guid_0);
				class7.method_9().Add("EncryptionInfo", memoryStream_);
				class7.method_9().Add("EncryptedPackage", memoryStream2);
				class7.Save(stream);
			}
			else
			{
				Class1229 class8 = new Class1229(this, HasMacro);
				class8.Write(stream);
			}
			if (SaveOptions.ClearData)
			{
				Initialize();
			}
			else
			{
				method_1();
			}
			break;
		case SaveFormat.MHtml:
		{
			HtmlSaveOptions htmlSaveOptions = (HtmlSaveOptions)saveOptions;
			if (htmlSaveOptions.ExportActiveWorksheetOnly)
			{
				_ = Worksheets[Worksheets.ActiveSheetIndex].Name;
			}
			Class435 class2 = new Class435(this, stream, htmlSaveOptions);
			class2.method_0(stream);
			if (SaveOptions.ClearData)
			{
				Initialize();
			}
			else
			{
				method_1();
			}
			break;
		}
		case SaveFormat.XPS:
		{
			XpsSaveOptions xpsSaveOptions = XpsSaveOptions.smethod_0(saveOptions);
			WorkbookRender workbookRender = new WorkbookRender(this, xpsSaveOptions.ImageOrPrintOptions);
			workbookRender.ToImage(stream);
			break;
		}
		case SaveFormat.TIFF:
		{
			ImageSaveOptions imageSaveOptions = ImageSaveOptions.smethod_0(saveOptions);
			WorkbookRender workbookRender2 = new WorkbookRender(this, imageSaveOptions.ImageOrPrintOptions);
			workbookRender2.ToImage(stream);
			break;
		}
		case SaveFormat.SVG:
		{
			SvgSaveOptions svgSaveOptions = SvgSaveOptions.smethod_1(saveOptions);
			Worksheet worksheet3 = Worksheets[(svgSaveOptions.SheetIndex == -1) ? Worksheets.ActiveSheetIndex : svgSaveOptions.SheetIndex];
			SheetRender sheetRender = new SheetRender(worksheet3, svgSaveOptions.ImageOrPrintOptions);
			for (int l = 0; l < sheetRender.PageCount; l++)
			{
				sheetRender.ToImage(l, stream);
			}
			break;
		}
		default:
			if (stream.CanSeek)
			{
				new Class722(this).Write(stream);
			}
			else
			{
				MemoryStream memoryStream = new MemoryStream();
				new Class722(this).Write(memoryStream);
				memoryStream.WriteTo(stream);
			}
			if (SaveOptions.ClearData)
			{
				Initialize();
			}
			else
			{
				method_1();
			}
			break;
		case SaveFormat.Dif:
		{
			Class514 @class = new Class514(this);
			@class.Write(stream);
			break;
		}
		}
	}

	/// <summary>
	///       Creates the result spreadsheet and transfer it to the client then open it in the browser or MS Workbook.
	///       </summary>
	/// <param name="response">Response object to return the spreadsheet to client.</param>
	/// <param name="fileName">The name of created file.</param>
	/// <param name="contentDisposition">The content dispostion type.</param>
	/// <param name="saveOptions">The save options.</param>
	public void Save(HttpResponse response, string fileName, ContentDisposition contentDisposition, SaveOptions saveOptions)
	{
		MemoryStream memoryStream = new MemoryStream();
		Save(memoryStream, saveOptions);
		FileFormatType fileFormatType_ = FileFormatUtil.smethod_0(saveOptions.SaveFormat, fileFormatType_0);
		WorksheetCollection.smethod_0(response, contentDisposition, fileName, fileFormatType_, memoryStream.Length, saveOptions.EnableHTTPCompression);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		memoryStream.WriteTo(response.OutputStream);
		response.Flush();
		memoryStream.Close();
	}

	/// <summary>
	///       Creates a new style.
	///       </summary>
	/// <returns>Returns a style object.</returns>
	public Style CreateStyle()
	{
		Style style = new Style(worksheetCollection_0);
		style.GetStyle(worksheetCollection_0, 15);
		return style;
	}

	/// <summary>
	///       Creates a <see cref="T:Aspose.Cells.CellsColor" /> object.
	///       </summary>
	/// <returns>Returns a <see cref="T:Aspose.Cells.CellsColor" /> object.</returns>
	public CellsColor CreateCellsColor()
	{
		return new CellsColor(this);
	}

	/// <summary>
	///        Replaces a cell's value with a new string.
	///       </summary>
	/// <example>
	///   <code>
	///        [C#]
	///
	///        Workbook workbook = new Workbook();
	///        ......
	///        workbook.Replace("AnOldValue", "NewValue");
	///
	///        [Visual Basic]
	///
	///        Dim workbook As Workbook =  New Workbook() 
	///         ........
	///       workbook.Replace("AnOldValue", "NewValue")
	///        </code>
	/// </example>
	/// <param name="placeHolder">Cell placeholder</param>
	/// <param name="newValue">String value to replace</param>
	public int Replace(string placeHolder, string newValue)
	{
		Class1654 @class = new Class1654(worksheetCollection_0);
		return @class.Replace(placeHolder, newValue);
	}

	/// <summary>
	///        Replaces a cell's value with a new integer.
	///       </summary>
	/// <example>
	///   <code>
	///        [C#]
	///
	///        Workbook workbook = new Workbook();
	///        ......
	///        int newValue = 100;
	///        workbook.Replace("AnOldValue", newValue);
	///
	///        [Visual Basic]
	///
	///        Dim workbook As Workbook =  New Workbook() 
	///       .........
	///       Dim NewValue As Integer =  100 
	///       workbook.Replace("AnOldValue", NewValue)
	///        </code>
	/// </example>
	/// <param name="placeHolder">Cell placeholder</param>
	/// <param name="newValue">Integer value to replace</param>
	public int Replace(string placeHolder, int newValue)
	{
		Class1654 @class = new Class1654(worksheetCollection_0);
		return @class.Replace(placeHolder, newValue);
	}

	/// <summary>
	///        Replaces a cell's value with a new double.
	///       </summary>
	/// <example>
	///   <code>
	///
	///        [C#]
	///
	///        Workbook workbook = new Workbook();
	///        ......
	///        double newValue = 100.0;
	///        workbook.Replace("AnOldValue", newValue);
	///
	///
	///        [Visual Basic]
	///
	///        Dim workbook As Workbook =  New Workbook() 
	///       .........
	///       Dim NewValue As Double =  100.0
	///       workbook.Replace("AnOldValue", NewValue)
	///        </code>
	/// </example>
	/// <param name="placeHolder">Cell placeholder</param>
	/// <param name="newValue">Double value to replace</param>
	public int Replace(string placeHolder, double newValue)
	{
		Class1654 @class = new Class1654(worksheetCollection_0);
		return @class.Replace(placeHolder, newValue);
	}

	/// <summary>
	///        Replaces a cell's value with a new string array.
	///       </summary>
	/// <example>
	///   <code>
	///
	///        [C#]
	///
	///        Workbook workbook = new Workbook();
	///        ......
	///        string[] newValues = new string[]{"Tom", "Alice", "Jerry"};
	///        workbook.Replace("AnOldValue", newValues, true);
	///
	///        [Visual Basic]
	///
	///        Dim workbook As Workbook =  New Workbook() 
	///        .............
	///       Dim NewValues() As String =  New String() {"Tom", "Alice", "Jerry"}		
	///       workbook.Replace("AnOldValue", NewValues, True)
	///        </code>
	/// </example>
	/// <param name="placeHolder">Cell placeholder</param>
	/// <param name="newValues">String array to replace</param>
	/// <param name="isVertical">True - Vertical, False - Horizontal</param>
	public int Replace(string placeHolder, string[] newValues, bool isVertical)
	{
		Class1654 @class = new Class1654(worksheetCollection_0);
		return @class.Replace(placeHolder, newValues, isVertical);
	}

	/// <summary>
	///        Replaces cells' values with an integer array.
	///       </summary>
	/// <example>
	///   <code>
	///        [C#]
	///
	///        Workbook workbook = new Workbook();
	///        ......
	///        int[] newValues = new int[]{1, 2, 3};
	///        workbook.Replace("AnOldValue", newValues, true);
	///
	///        [Visual Basic]
	///
	///        Dim workbook As Workbook =  New Workbook() 
	///       ...........
	///       Dim NewValues() As Integer =  New Integer() {1, 2, 3}
	///       workbook.Replace("AnOldValue", NewValues, True)
	///        </code>
	/// </example>
	/// <param name="placeHolder">Cell placeholder</param>
	/// <param name="newValues">Integer array to replace</param>
	/// <param name="isVertical">True - Vertical, False - Horizontal</param>
	public int Replace(string placeHolder, int[] newValues, bool isVertical)
	{
		Class1654 @class = new Class1654(worksheetCollection_0);
		return @class.Replace(placeHolder, newValues, isVertical);
	}

	/// <summary>
	///        Replaces cells' values with a double array.
	///       </summary>
	/// <example>
	///   <code>
	///
	///        [C#]
	///
	///        Workbook workbook = new Workbook();
	///        ......
	///        double[] newValues = new double[]{1.23, 2.56, 3.14159};
	///        workbook.Replace("AnOldValue", newValues, true);
	///
	///        [Visual Basic]
	///
	///        Dim workbook As Workbook =  New Workbook() 
	///        ...........
	///        Dim NewValues() As Double =  New Double() {1.23, 2.56, 3.14159}
	///        workbook.Replace("AnOldValue", NewValues, True)
	///        </code>
	/// </example>
	/// <param name="placeHolder">Cell placeholder</param>
	/// <param name="newValues">Double array to replace</param>
	/// <param name="isVertical">True - Vertical, False - Horizontal</param>
	public int Replace(string placeHolder, double[] newValues, bool isVertical)
	{
		Class1654 @class = new Class1654(worksheetCollection_0);
		return @class.Replace(placeHolder, newValues, isVertical);
	}

	/// <summary>
	///        Replaces cells' values with data from a <see cref="T:System.Data.DataTable" />.
	///       </summary>
	/// <example>
	///   <code>
	///        [C#]
	///
	///        Workbook workbook = new Workbook();
	///        DataTable myDataTable = new DataTable("Customers");
	///        // Adds data to myDataTable
	///        ........
	///        workbook.Replace("AnOldValue", myDataTable);
	///
	///        [Visual Basic]
	///
	///        Dim workbook As Workbook =  New Workbook() 
	///        Dim myDataTable As DataTable =  New DataTable("Customers") 
	///        ' Adds data to myDataTable
	///       .............
	///        workbook.Replace("AnOldValue", myDataTable)
	///        </code>
	/// </example>
	/// <param name="placeHolder">Cell placeholder</param>
	/// <param name="insertTable">DataTable to replace</param>
	public int Replace(string placeHolder, DataTable insertTable)
	{
		Class1654 @class = new Class1654(worksheetCollection_0);
		return @class.Replace(placeHolder, insertTable);
	}

	/// <summary>
	///       Replaces cells' values with new data.
	///       </summary>
	/// <param name="boolValue">The boolean value to be replaced.</param>
	/// <param name="newValue">New value. Can be string, integer, double or DateTime value.</param>
	public int Replace(bool boolValue, object newValue)
	{
		Class1654 @class = new Class1654(worksheetCollection_0);
		return @class.Replace(boolValue, newValue);
	}

	/// <summary>
	///       Replaces cells' values with new data.
	///       </summary>
	/// <param name="intValue">The integer value to be replaced.</param>
	/// <param name="newValue">New value. Can be string, integer, double or DateTime value.</param>
	public int Replace(int intValue, object newValue)
	{
		Class1654 @class = new Class1654(worksheetCollection_0);
		return @class.Replace(intValue, newValue);
	}

	/// <summary>
	///        Replaces a cell's value with a new string.
	///       </summary>
	/// <param name="placeHolder">Cell placeholder</param>
	/// <param name="newValue">String value to replace</param>
	/// <param name="options"> The replace options</param>
	public int Replace(string placeHolder, string newValue, ReplaceOptions options)
	{
		Class1654 @class = new Class1654(worksheetCollection_0, options);
		return @class.Replace(placeHolder, newValue);
	}

	/// <summary>
	///       Copies data from a source Workbook object.
	///       </summary>
	/// <param name="source">Source Workbook object.</param>
	public void Copy(Workbook source)
	{
		worksheetCollection_0.method_35();
		fileFormatType_0 = source.fileFormatType_0;
		enum187_0 = source.enum187_0;
		worksheetCollection_0.Copy(source.worksheetCollection_0);
		class1569_0.Copy(source.class1569_0);
		bool_1 = source.bool_1;
		workbookSettings_0.Copy(source.workbookSettings_0);
	}

	/// <summary>
	///       Combines another Workbook object.
	///       </summary>
	/// <param name="secondWorkbook">Another Workbook object.</param>
	/// <remarks>Currently, only cell data and cell style of the second Workbook object can be combined. Images, charts and other drawing objects are not supported.
	///       </remarks>
	public void Combine(Workbook secondWorkbook)
	{
		method_5();
		secondWorkbook.method_5();
		worksheetCollection_0.Combine(secondWorkbook.worksheetCollection_0);
	}

	public Style GetStyleInPool(int index)
	{
		return Worksheets.method_58()[index];
	}

	/// <summary>
	///        Changes the palette for the spreadsheet in the specified index.
	///        </summary>
	/// <param name="color">Color structure.</param>
	/// <param name="index">Palette index, 0 - 55.</param>
	/// <remarks>The palette has 56 entries, each represented by an RGB value. 
	///        If you set a color which is not in the palette, it will not take effect.
	///        So if you want to set a custom color, please change the palette at first.
	///        <p>The following is the standard color palette.</p><table class="dtTABLE" cellspacing="0"><tr><td width="25%"><font color="gray"><b>Color</b></font>　</td><td width="25%"><font color="gray"><b>Red</b></font>　</td><td width="25%"><font color="gray"><b>Green</b></font>　</td><td width="25%"><font color="gray"><b>Blue</b></font>　</td></tr><tr><td width="25%">Black　</td><td width="25%">0　</td><td width="25%">0　</td><td width="25%">0　</td></tr><tr><td width="25%">White　</td><td width="25%">255　</td><td width="25%">255　</td><td width="25%">255　</td></tr><tr><td width="25%">Red　</td><td width="25%">255　</td><td width="25%">0　</td><td width="25%">0　</td></tr><tr><td width="25%">Lime　</td><td width="25%">0　</td><td width="25%">255　</td><td width="25%">0　</td></tr><tr><td width="25%">Blue　</td><td width="25%">0　</td><td width="25%">0　</td><td width="25%">255　</td></tr><tr><td width="25%">Yellow　</td><td width="25%">255　</td><td width="25%">255　</td><td width="25%">0　</td></tr><tr><td width="25%">Magenta　</td><td width="25%">255　</td><td width="25%">0　</td><td width="25%">255　</td></tr><tr><td width="25%">Cyan　</td><td width="25%">0　</td><td width="25%">255　</td><td width="25%">255　</td></tr><tr><td width="25%">Maroon　</td><td width="25%">128　</td><td width="25%">0　</td><td width="25%">0　</td></tr><tr><td width="25%">Green　</td><td width="25%">0　</td><td width="25%">128　</td><td width="25%">0　</td></tr><tr><td width="25%">Navy　</td><td width="25%">0　</td><td width="25%">0　</td><td width="25%">128　</td></tr><tr><td width="25%">Olive　</td><td width="25%">128　</td><td width="25%">128　</td><td width="25%">0　</td></tr><tr><td width="25%">Purple　</td><td width="25%">128　</td><td width="25%">0　</td><td width="25%">128　</td></tr><tr><td width="25%">Teal　</td><td width="25%">0　</td><td width="25%">128　</td><td width="25%">128　</td></tr><tr><td width="25%">Silver　</td><td width="25%">192　</td><td width="25%">192　</td><td width="25%">192　</td></tr><tr><td width="25%">Gray　</td><td width="25%">128　</td><td width="25%">128　</td><td width="25%">128　</td></tr><tr><td width="25%">Color17　</td><td width="25%">153　</td><td width="25%">153　</td><td width="25%">255　</td></tr><tr><td width="25%">Color18　</td><td width="25%">153　</td><td width="25%">51　</td><td width="25%">102　</td></tr><tr><td width="25%">Color19　</td><td width="25%">255　</td><td width="25%">255　</td><td width="25%">204　</td></tr><tr><td width="25%">Color20　</td><td width="25%">204　</td><td width="25%">255　</td><td width="25%">255　</td></tr><tr><td width="25%">Color21　</td><td width="25%">102　</td><td width="25%">0　</td><td width="25%">102　</td></tr><tr><td width="25%">Color22　</td><td width="25%">255　</td><td width="25%">128　</td><td width="25%">128　</td></tr><tr><td width="25%">Color23　</td><td width="25%">0　</td><td width="25%">102　</td><td width="25%">204　</td></tr><tr><td width="25%">Color24　</td><td width="25%">204　</td><td width="25%">204　</td><td width="25%">255　</td></tr><tr><td width="25%">Color25　</td><td width="25%">0　</td><td width="25%">0　</td><td width="25%">128　</td></tr><tr><td width="25%">Color26　</td><td width="25%">255　</td><td width="25%">0　</td><td width="25%">255　</td></tr><tr><td width="25%">Color27　</td><td width="25%">255　</td><td width="25%">255　</td><td width="25%">0　</td></tr><tr><td width="25%">Color28　</td><td width="25%">0　</td><td width="25%">255　</td><td width="25%">255　</td></tr><tr><td width="25%">Color29　</td><td width="25%">128　</td><td width="25%">0　</td><td width="25%">128　</td></tr><tr><td width="25%">Color30　</td><td width="25%">128　</td><td width="25%">0　</td><td width="25%">0　</td></tr><tr><td width="25%">Color31　</td><td width="25%">0　</td><td width="25%">128　</td><td width="25%">128　</td></tr><tr><td width="25%">Color32　</td><td width="25%">0　</td><td width="25%">0　</td><td width="25%">255　</td></tr><tr><td width="25%">Color33　</td><td width="25%">0　</td><td width="25%">204　</td><td width="25%">255　</td></tr><tr><td width="25%">Color34　</td><td width="25%">204　</td><td width="25%">255　</td><td width="25%">255　</td></tr><tr><td width="25%">Color35　</td><td width="25%">204　</td><td width="25%">255　</td><td width="25%">204　</td></tr><tr><td width="25%">Color36　</td><td width="25%">255　</td><td width="25%">255　</td><td width="25%">153　</td></tr><tr><td width="25%">Color37　</td><td width="25%">153　</td><td width="25%">204　</td><td width="25%">255　</td></tr><tr><td width="25%">Color38　</td><td width="25%">255　</td><td width="25%">153　</td><td width="25%">204　</td></tr><tr><td width="25%">Color39　</td><td width="25%">204　</td><td width="25%">153　</td><td width="25%">255　</td></tr><tr><td width="25%">Color40　</td><td width="25%">255　</td><td width="25%">204　</td><td width="25%">153　</td></tr><tr><td width="25%">Color41　</td><td width="25%">51　</td><td width="25%">102　</td><td width="25%">255　</td></tr><tr><td width="25%">Color42　</td><td width="25%">51　</td><td width="25%">204　</td><td width="25%">204　</td></tr><tr><td width="25%">Color43　</td><td width="25%">153　</td><td width="25%">204　</td><td width="25%">0　</td></tr><tr><td width="25%">Color44　</td><td width="25%">255　</td><td width="25%">204　</td><td width="25%">0　</td></tr><tr><td width="25%">Color45　</td><td width="25%">255　</td><td width="25%">153　</td><td width="25%">0　</td></tr><tr><td width="25%">Color46　</td><td width="25%">255　</td><td width="25%">102　</td><td width="25%">0　</td></tr><tr><td width="25%">Color47　</td><td width="25%">102　</td><td width="25%">102　</td><td width="25%">153　</td></tr><tr><td width="25%">Color48　</td><td width="25%">150　</td><td width="25%">150　</td><td width="25%">150　</td></tr><tr><td width="25%">Color49　</td><td width="25%">0　</td><td width="25%">51　</td><td width="25%">102　</td></tr><tr><td width="25%">Color50　</td><td width="25%">51　</td><td width="25%">153　</td><td width="25%">102　</td></tr><tr><td width="25%">Color51　</td><td width="25%">0　</td><td width="25%">51　</td><td width="25%">0　</td></tr><tr><td width="25%">Color52　</td><td width="25%">51　</td><td width="25%">51　</td><td width="25%">0　</td></tr><tr><td width="25%">Color53　</td><td width="25%">153　</td><td width="25%">51　</td><td width="25%">0　</td></tr><tr><td width="25%">Color54　</td><td width="25%">153　</td><td width="25%">51　</td><td width="25%">102　</td></tr><tr><td width="25%">Color55　</td><td width="25%">51　</td><td width="25%">51　</td><td width="25%">153　</td></tr><tr><td width="25%">Color56　</td><td width="25%">51　</td><td width="25%">51　</td><td width="25%">51　</td></tr></table></remarks>
	public void ChangePalette(Color color, int index)
	{
		if (index < 0 || index > 55)
		{
			throw new ArgumentException("Index is out of range.");
		}
		workbookSettings_0.method_0().ChangePalette(color, index + 8);
	}

	/// <summary>
	///       Checks if a color is in the palette for the spreadsheet.
	///       </summary>
	/// <param name="color">Color structure.</param>
	/// <returns>Returns true if this color is in the palette. Otherwise, returns false</returns>
	public bool IsColorInPalette(Color color)
	{
		return workbookSettings_0.method_0().IsColorInPalette(color);
	}

	/// <summary>
	///        Calculates the result of formulas.
	///        </summary>
	/// <remarks>
	///   <p>Now Workbook built-in functions are not supported in this method:</p>
	///   <p>[A]</p>
	///   <p>ASC</p>
	///   <p>[B]</p>
	///   <p>BAHTTEXT</p>
	///   <p>[C]</p>
	///   <p>CALL, CLEAN, CODE, CONVERT, CUBEKPIMEMBER, CUBEMEMBER, CUBEMEMBERPROPERTY, CUBERANKEDMEMBER, CUBESET, CUBESETCOUNT, CUBEVALUE</p>
	///   <p>[E]</p>
	///   <p>EUROCONVERT</p>
	///   <p>[G]</p>
	///   <p>GETPIVOTDATA</p>
	///   <p>[I]</p>
	///   <p>INFO</p>
	///   <p>[J]</p>
	///   <p>JIS</p>
	///   <p>[P]</p>
	///   <p>PHONETIC</p>
	///   <p>[R]</p>
	///   <p>REGISTER.ID, RTD</p>
	///   <p>[S]</p>
	///   <p>SQL.REQUEST</p>
	///   <p>[Y]</p>
	///   <p>YIELD, YIELDDISC</p>
	/// </remarks>
	public void CalculateFormula()
	{
		CalculateFormula(ignoreError: false, null);
	}

	/// <summary>
	///       Calculates the result of formulas.
	///       </summary>
	/// <param name="ignoreError">Indicates if hide the error in calculating formulas. The error may be unsupported function, external links, etc.</param>
	public void CalculateFormula(bool ignoreError)
	{
		CalculateFormula(ignoreError, null);
	}

	/// <summary>
	///       Calculates the result of formulas.
	///       </summary>
	/// <param name="ignoreError">Indicates if hide the error in calculating formulas. The error may be unsupported function, external links, etc.</param>
	/// <param name="customFunction">The custom formula calculation functions to extend the calculation engine.</param>
	public void CalculateFormula(bool ignoreError, ICustomFunction customFunction)
	{
		method_5();
		if (!bool_0)
		{
			for (int i = 0; i < worksheetCollection_0.Count; i++)
			{
				RowCollection rows = worksheetCollection_0[i].Cells.Rows;
				for (int j = 0; j < rows.Count; j++)
				{
					Row row = rows.method_4(j);
					for (int k = 0; k < row.method_0(); k++)
					{
						Cell cellByIndex = row.GetCellByIndex(k);
						if (cellByIndex.IsFormula)
						{
							cellByIndex.method_61(0);
						}
					}
				}
			}
			Class1658 @class = new Class1658(this);
			@class.method_5(ignoreError, customFunction);
			for (int l = 0; l < worksheetCollection_0.Count; l++)
			{
				RowCollection rows2 = worksheetCollection_0[l].Cells.Rows;
				for (int m = 0; m < rows2.Count; m++)
				{
					Row row2 = rows2.method_4(m);
					for (int n = 0; n < row2.method_0(); n++)
					{
						Cell cellByIndex2 = row2.GetCellByIndex(n);
						if (cellByIndex2.method_20() != Enum199.const_4 || cellByIndex2.method_60() == 2)
						{
							continue;
						}
						try
						{
							@class.method_3(cellByIndex2);
						}
						catch (Exception0)
						{
							@class.method_4();
						}
						catch (Exception exception_)
						{
							if (!ignoreError)
							{
								throw new CellsException(ExceptionType.Formula, Class1183.smethod_0(exception_) + "\nError in calculating cell " + cellByIndex2.Name + " in Worksheet " + worksheetCollection_0[l].Name);
							}
						}
					}
				}
			}
			if (workbookSettings_0.CreateCalcChain)
			{
				bool_0 = true;
			}
			return;
		}
		Class1658 class2 = new Class1658(this);
		class2.method_5(ignoreError, customFunction);
		class1380_0.method_5();
		while (class1380_0.Count > 0)
		{
			Cell cell = class1380_0.method_4();
			if (cell.method_20() != Enum199.const_4 || cell.method_60() == 2)
			{
				continue;
			}
			try
			{
				Class1661 class3 = worksheetCollection_0.Formula.method_10(cell);
				if (class3 != null)
				{
					object obj = class2.method_2(class3, cell);
					if (cell.IsArrayHeader)
					{
						Class1379.smethod_0(obj, cell);
					}
					else
					{
						cell.method_66(obj, 2);
					}
				}
			}
			catch (Exception exception_2)
			{
				class1380_0.method_0();
				class1380_0.hashtable_1.Clear();
				if (!ignoreError)
				{
					throw new CellsException(ExceptionType.Formula, Class1183.smethod_0(exception_2) + "\nError in calculating cell " + cell.Name + " in Worksheet " + cell.method_4().method_3().Name);
				}
			}
		}
		class1380_0.method_0();
		bool_0 = true;
		class2.Clear();
	}

	/// <summary>
	///       Checks if a formula is valid.
	///       </summary>
	/// <param name="formula">Formula string.</param>
	/// <returns>True: valid formula. False: invalid formula or unsupported function.</returns>
	public bool ValidateFormula(string formula)
	{
		if (formula != null && formula.Length >= 2 && formula[0] == '=')
		{
			formula = formula.Substring(1);
			Class1343 @class = new Class1343(worksheetCollection_0);
			@class.bool_0 = true;
			try
			{
				@class.method_1(formula.ToUpper());
				@class.method_5();
				return @class.bool_0;
			}
			catch
			{
				return false;
			}
		}
		return false;
	}

	/// <summary>
	///       Find best matching Color in current palette.
	///       </summary>
	/// <param name="rawColor">Raw color.</param>
	/// <returns>Best matching color.</returns>
	public Color GetMatchingColor(Color rawColor)
	{
		Color result = rawColor;
		int num = int.MaxValue;
		int num2 = 0;
		Color[] colors = workbookSettings_0.method_0().Colors;
		foreach (Color color in colors)
		{
			num2 = Convert.ToInt32(Math.Pow(Class1178.smethod_1(color) - Class1178.smethod_1(rawColor), 2.0) + Math.Pow(Class1178.smethod_2(color) - Class1178.smethod_2(rawColor), 2.0) + Math.Pow(Class1178.smethod_3(color) - Class1178.smethod_3(rawColor), 2.0));
			if (num2 < num)
			{
				result = color;
				if (num2 == 0)
				{
					break;
				}
				num = num2;
			}
		}
		return result;
	}

	/// <summary>
	///       Protects a workbook.
	///       </summary>
	/// <param name="protectionType">Protection type.</param>
	/// <param name="password">Password to protect the workbook.</param>
	public void Protect(ProtectionType protectionType, string password)
	{
		worksheetCollection_0.Protect(protectionType, password);
	}

	/// <summary>
	///       Unprotects a workbook.
	///       </summary>
	/// <param name="password">Password to unprotect the workbook.</param>
	public void Unprotect(string password)
	{
		worksheetCollection_0.Unprotect(password);
	}

	/// <summary>
	///       Decrypts an Excel file.
	///       </summary>
	/// <param name="password">Password to decrypt the Excel file.</param>
	public void Decrypt(string password)
	{
		Worksheets.Decrypt(password);
	}

	/// <summary>
	///       Removes VBA/macro from this spreadsheet.
	///       </summary>
	public void RemoveMacro()
	{
		if (worksheetCollection_0.method_10() != null)
		{
			worksheetCollection_0.method_10().method_9().Remove("\u0001CompObj");
			worksheetCollection_0.method_10().method_9().Remove("_VBA_PROJECT_CUR");
			worksheetCollection_0.method_18(bool_4: false);
		}
		else if (class1558_0 != null)
		{
			class1558_0.string_0 = null;
		}
	}

	/// <summary>
	///       Removes digital signature from this spreadsheet.
	///       </summary>
	/// <returns>
	/// </returns>
	public void RemoveDigitallySign()
	{
		if (class1558_0 != null)
		{
			class1558_0.RemoveDigitallySign();
		}
		if (Worksheets.method_10() != null)
		{
			Worksheets.method_10().method_9().Remove("_signatures");
		}
		class997_0 = null;
		digitalSignatureCollection_0 = null;
	}

	/// <summary>
	///       Accepts all tracked changes in the workbook. 
	///       </summary>
	public void AcceptAllRevisions()
	{
		Class1346 @class = new Class1346(this);
		@class.AcceptAllRevisions();
	}

	[SpecialName]
	internal bool method_9()
	{
		if (worksheetCollection_0.method_10() != null && worksheetCollection_0.method_10().method_9().Contains("_VBA_PROJECT_CUR"))
		{
			return true;
		}
		if (class1558_0 != null && class1558_0.string_0 != null)
		{
			return true;
		}
		return false;
	}

	private void method_10(string string_3)
	{
		string_0 = string_3;
		string_3.LastIndexOf('\\');
		string_1 = Path.GetDirectoryName(string_3);
		if (string_1 != null)
		{
			string_1 += "\\";
		}
	}

	/// <summary>
	///       Removes all external links in the workbook.
	///       </summary>
	public void RemoveExternalLinks()
	{
		bool flag = false;
		int count = Worksheets.method_39().Count;
		bool[] array = new bool[count];
		for (int i = 0; i < count; i++)
		{
			Class1718 @class = Worksheets.method_39()[i];
			Enum194 type = @class.Type;
			if (type == Enum194.const_0 || type == Enum194.const_3)
			{
				array[i] = true;
				flag |= array[i];
				@class.method_8(null);
			}
		}
		if (!flag)
		{
			return;
		}
		ArrayList arrayList = new ArrayList();
		for (int j = 0; j < Worksheets.method_32().Count; j++)
		{
			ushort ushort_ = Worksheets.method_32()[j].ushort_0;
			if (array[ushort_])
			{
				arrayList.Add(j);
			}
		}
		if (arrayList.Count == 0)
		{
			return;
		}
		for (int k = 0; k < Worksheets.Count; k++)
		{
			Worksheets[k].Cells.Rows.RemoveExternalLinks(arrayList);
			Worksheets[k].Charts.RemoveExternalLinks();
		}
		for (int l = 0; l < Worksheets.Names.Count; l++)
		{
			Name name = Worksheets.Names[l];
			if (name.method_2() != null && Class1674.smethod_12(name.method_2(), -1, -1, Worksheets))
			{
				name.method_33();
				name.IsHidden = true;
			}
		}
	}

	/// <summary>
	///       Loads data from an Excel file.
	///       </summary>
	/// <param name="fileName">Name of imported Excel file.</param>
	/// <remarks>This method only loads data , formulas and formattings from an Excel file. 
	///       Other contents and settings are all discarded. 
	///       It runs faster and utilize less memory than <see cref="M:Aspose.Cells.Workbook.Open(System.String)" /> method 
	///       so it's better to be used for applications which only need to process data in Excel file.
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook(string,LoadOptions) constructor.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Workbook(string,LoadOptions) constructor method instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public void LoadData(string fileName)
	{
		LoadData(fileName, null);
	}

	/// <summary>
	///       Loads data from an Excel file.
	///       </summary>
	/// <param name="stream">Stream which contains imported Excel file.</param>
	/// <remarks>This method only loads data , formulas and formattings from an Excel file. 
	///       Other contents and settings are all discarded. 
	///       It runs faster and utilize less memory than <see cref="M:Aspose.Cells.Workbook.Open(System.IO.Stream)" /> method 
	///       so it's better to be used for applications which only need to process data in Excel file.
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook(Stream,LoadOptions) constructor.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Use Workbook(Stream,LoadOptions) constructor method instead.")]
	public void LoadData(Stream stream)
	{
		LoadData(stream, null);
	}

	/// <summary>
	///       Loads data from an Excel file according to loading data options.
	///       </summary>
	/// <param name="fileName">Name of imported Excel file.</param>
	/// <param name="option">The loading data options</param>
	/// <remarks>
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook(string,LoadOptions) constructor.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Workbook(string,LoadOptions) constructor method instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public void LoadData(string fileName, LoadDataOption option)
	{
		FileStream fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		bool isValid = false;
		int header = 0;
		FileFormatType fileFormatType = Class1677.smethod_7(fileName, fileStream, out isValid, out header);
		method_2(fileFormatType, bool_2: false);
		if (isValid)
		{
			switch (fileFormatType)
			{
			default:
				throw new CellsException(ExceptionType.UnsupportedFeature, "LoadData method does not support this file format:" + fileFormatType);
			case FileFormatType.Excel97:
			case FileFormatType.Excel2000:
			case FileFormatType.ExcelXP:
			case FileFormatType.Default:
			{
				Class1724 @class = new Class1724(this, option);
				Class1317 class1317_ = new Class1317(fileStream);
				@class.method_39(class1317_);
				break;
			}
			case FileFormatType.Xlsx:
			case FileFormatType.Xlsm:
			case FileFormatType.Xltx:
			case FileFormatType.Xltm:
				Class1368.LoadData(this, fileStream, option);
				break;
			}
			fileStream.Close();
			return;
		}
		fileStream.Close();
		switch (header)
		{
		case 1033:
			throw new CellsException(ExceptionType.UnsupportedFeature, "This Excel files contains (Excel4.0 or earlier file format) records.");
		default:
			throw new CellsException(ExceptionType.FileFormat, "This file's format is not supported or you don't specify a correct format.");
		case 521:
			throw new CellsException(ExceptionType.UnsupportedFeature, "This Excel files contains (Excel3.0 or earlier file format) records.");
		}
	}

	/// <summary>
	///       Loads data from an Excel file according to loading data options.
	///       </summary>
	/// <param name="stream">Stream which contains imported Excel file.</param>
	/// <param name="option">The loading data options.</param>
	/// <remarks>
	///       NOTE: This member is now obsolete. Instead, 
	///       please use Workbook(Stream,LoadOptions) constructor.
	///       This property will be removed 12 months later since JULY 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Obsolete("Use Workbook(Stream,LoadOptions) constructor method instead.")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void LoadData(Stream stream, LoadDataOption option)
	{
		bool isValid = false;
		int header = 0;
		FileFormatType fileFormatType = Class1677.smethod_7(null, stream, out isValid, out header);
		if (isValid)
		{
			switch (fileFormatType)
			{
			default:
				throw new CellsException(ExceptionType.UnsupportedFeature, "LoadData method does not support this file format:" + fileFormatType);
			case FileFormatType.Excel97:
			case FileFormatType.Excel2000:
			case FileFormatType.ExcelXP:
			case FileFormatType.Default:
			{
				Class1724 @class = new Class1724(this, option);
				Class1317 class1317_ = new Class1317(stream);
				@class.method_39(class1317_);
				break;
			}
			case FileFormatType.Xlsx:
			case FileFormatType.Xlsm:
			case FileFormatType.Xltx:
			case FileFormatType.Xltm:
				Class1368.LoadData(this, stream, option);
				break;
			}
			return;
		}
		switch (header)
		{
		case 1033:
			throw new CellsException(ExceptionType.UnsupportedFeature, "This Excel files contains (Excel4.0 or earlier file format) records.");
		default:
			throw new CellsException(ExceptionType.FileFormat, "This file's format is not supported or you don't specify a correct format.");
		case 521:
			throw new CellsException(ExceptionType.UnsupportedFeature, "This Excel files contains (Excel3.0 or earlier file format) records.");
		}
	}

	internal void method_11(Stream stream_0)
	{
		class1558_0 = new Class1558(this);
		class1558_0.class1553_0 = new Class1553();
		class1558_0.class1553_0.method_0(stream_0);
	}

	[SpecialName]
	internal EncryptionType method_12()
	{
		return encryptionType_0;
	}

	[SpecialName]
	internal void method_13(EncryptionType encryptionType_1)
	{
		encryptionType_0 = encryptionType_1;
	}

	[SpecialName]
	internal int method_14()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_15(int int_1)
	{
		int_0 = int_1;
	}

	/// <summary>
	///       Set Encryption Options.
	///       </summary>
	/// <param name="encryptionType">The encryption type.</param>
	/// <param name="keyLength">The key length.</param>
	public void SetEncryptionOptions(EncryptionType encryptionType, int keyLength)
	{
		encryptionType_0 = encryptionType;
		int_0 = keyLength;
	}

	internal SaveOptions method_16()
	{
		return saveOptions_0;
	}

	internal void method_17(SaveOptions saveOptions_1)
	{
		saveOptions_0 = saveOptions_1;
	}

	[SpecialName]
	internal bool method_18()
	{
		return bool_1;
	}

	/// <summary>
	///       Gets theme color.
	///       </summary>
	/// <param name="type">The theme color type.</param>
	/// <returns>The theme color.</returns>
	public Color GetThemeColor(ThemeColorType type)
	{
		return class1569_0.GetThemeColor((int)type);
	}

	/// <summary>
	///       Sets the theme color
	///       </summary>
	/// <param name="type">The theme color type.</param>
	/// <param name="color">the theme color</param>
	public void SetThemeColor(ThemeColorType type, Color color)
	{
		class1569_0.class928_0[(int)type].Color = color;
		bool_1 = true;
	}

	/// <summary>
	///       Customs the theme.
	///       </summary>
	/// <param name="themeName">The theme name</param>
	/// <param name="colors">The theme colors</param>
	/// <remarks>
	///       The length ofcolors should be 12.
	///       <table class="dtTABLE" cellspacing="0"><tr><td width="50%"><font color="gray"><b>Array index</b></font>　</td><td width="50%"><font color="gray"><b>Theme type</b></font>　</td></tr><tr><td width="50%"><font color="gray"><b>0</b></font>　</td><td width="50%"><font color="gray"><b>Backgournd1</b></font>　</td></tr><tr><td width="50%"><font color="gray"><b>1</b></font>　</td><td width="50%"><font color="gray"><b>Text1</b></font>　</td></tr><tr><td width="50%"><font color="gray"><b>2</b></font>　</td><td width="50%"><font color="gray"><b>Backgournd2</b></font>　</td></tr><tr><td width="50%"><font color="gray"><b>3</b></font>　</td><td width="50%"><font color="gray"><b>Text2</b></font>　</td></tr><tr><td width="50%"><font color="gray"><b>4</b></font>　</td><td width="50%"><font color="gray"><b>Accent1</b></font>　</td></tr><tr><td width="50%"><font color="gray"><b>5</b></font>　</td><td width="50%"><font color="gray"><b>Accent2</b></font>　</td></tr><tr><td width="50%"><font color="gray"><b>6</b></font>　</td><td width="50%"><font color="gray"><b>Accent3</b></font>　</td></tr><tr><td width="50%"><font color="gray"><b>7</b></font>　</td><td width="50%"><font color="gray"><b>Accent4</b></font>　</td></tr><tr><td width="50%"><font color="gray"><b>8</b></font>　</td><td width="50%"><font color="gray"><b>Accent5</b></font>　</td></tr><tr><td width="50%"><font color="gray"><b>9</b></font>　</td><td width="50%"><font color="gray"><b>Accent6</b></font>　</td></tr><tr><td width="50%"><font color="gray"><b>10</b></font>　</td><td width="50%"><font color="gray"><b>Hyperlink</b></font>　</td></tr><tr><td width="50%"><font color="gray"><b>11</b></font>　</td><td width="50%"><font color="gray"><b>Followed Hyperlink</b></font>　</td></tr></table></remarks>
	public void CustomTheme(string themeName, Color[] colors)
	{
		class1569_0 = new Class1569(themeName, colors);
		bool_1 = true;
	}

	[SpecialName]
	internal string method_19()
	{
		return string_1;
	}

	/// <summary>
	///       Indicates whether this workbook contains external links to other data source.
	///       </summary>
	/// <returns>Whether this workbook contains external links to other data source.</returns>
	public bool HasExernalLinks()
	{
		int num = 0;
		while (true)
		{
			if (num < Worksheets.method_39().Count)
			{
				Class1718 @class = Worksheets.method_39()[num];
				if (@class.Type == Enum194.const_0)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	/// <summary>
	///       If this workbook contains external links to other data source,
	///       Aspose.Cells will attempt to retrieve the latest data.
	///       </summary>
	/// <param name="exteralWorkbooks">
	///       External workbooks are refered by this workbook.
	///       If it's null, we will directly open the external linked files..
	///       If it's not null, 
	///       we will check whether the external link in the array first;
	///       if not, we will open the external linked files again.
	///       </param>
	/// <remarks>
	///       If the method is not called before calculating formulas,
	///       Aspose.Cells will use the previous information(cached in the file);
	///       Please set CellsHelper.StartupPath,CellsHelper.AltStartPath,CellsHelper.LibraryPath. 
	///       And please set Workbook.FilePath if this workbook is from a stream,
	///       otherwise Aspose.Cells could not get the external link full path sometimes.
	///       </remarks>
	public void UpdateLinkedDataSource(Workbook[] exteralWorkbooks)
	{
		if (!HasExernalLinks())
		{
			return;
		}
		method_3();
		for (int i = 0; i < Worksheets.method_39().Count; i++)
		{
			Class1718 @class = Worksheets.method_39()[i];
			switch (@class.Type)
			{
			case Enum194.const_0:
			{
				string text = @class.method_19(this);
				if (!File.Exists(text))
				{
					break;
				}
				Workbook workbook = null;
				if (exteralWorkbooks != null)
				{
					foreach (Workbook workbook2 in exteralWorkbooks)
					{
						if (workbook2.FileName.ToUpper() == text.ToUpper())
						{
							workbook = workbook2;
							break;
						}
					}
				}
				if (workbook == null)
				{
					LoadOptions loadOptions = new LoadOptions();
					loadOptions.LoadDataOnly = true;
					loadOptions.LoadDataOptions.ImportFormula = false;
					workbook = new Workbook(text, loadOptions);
				}
				@class.method_7()?.Clear();
				if (@class.method_4() == null)
				{
					@class.method_5(new string[workbook.Worksheets.Count]);
					for (int k = 0; k < workbook.Worksheets.Count; k++)
					{
						@class.method_4()[k] = workbook.Worksheets[k].Name;
					}
					for (int l = 0; l < @class.method_0().Count; l++)
					{
						Class1653 class2 = (Class1653)@class.method_0()[l];
						string text2 = class2.Name;
						if (class2.SheetIndex != 0)
						{
							text2 = workbook.Worksheets[class2.SheetIndex - 1].Name + "!" + text2;
						}
						Name name = workbook.Worksheets.Names[text2];
						if (name != null && name.RefersTo != null)
						{
							class2.method_8(Worksheets, name.RefersTo);
						}
						if (class2.method_5() != null)
						{
							Class1674.smethod_5(class2.method_5(), -1, -1, workbook.Worksheets, workbook.Worksheets, 0, @class, bool_0: true, this);
						}
					}
					break;
				}
				string[] array = @class.method_4();
				@class.method_5(new string[workbook.Worksheets.Count]);
				for (int m = 0; m < workbook.Worksheets.Count; m++)
				{
					@class.method_4()[m] = workbook.Worksheets[m].Name;
				}
				Hashtable hashtable = new Hashtable();
				for (int n = 0; n < array.Length; n++)
				{
					string text3 = array[n].ToUpper();
					for (int num = 0; num < workbook.Worksheets.Count; num++)
					{
						if (workbook.Worksheets[num].Name.ToUpper() == text3)
						{
							hashtable.Add(n, num);
							break;
						}
					}
				}
				Worksheets.method_32().method_14(i, hashtable);
				for (int num2 = 0; num2 < @class.method_0().Count; num2++)
				{
					Class1653 class3 = (Class1653)@class.method_0()[num2];
					string text4 = class3.Name;
					if (class3.SheetIndex != 0)
					{
						text4 = workbook.Worksheets[class3.SheetIndex - 1].Name + "!" + text4;
					}
					Name name2 = workbook.Worksheets.Names[text4];
					if (name2 != null && name2.RefersTo != null)
					{
						class3.method_8(Worksheets, name2.RefersTo);
					}
					if (class3.method_5() != null)
					{
						Class1674.smethod_5(class3.method_5(), -1, -1, workbook.Worksheets, workbook.Worksheets, 0, @class, bool_0: true, this);
					}
				}
				for (int num3 = 0; num3 < worksheetCollection_0.Count; num3++)
				{
					Cells cells = worksheetCollection_0[num3].Cells;
					Cell cell = null;
					for (int num4 = 0; num4 < cells.Rows.Count; num4++)
					{
						Row row = cells.Rows.method_4(num4);
						for (int num5 = 0; num5 < row.method_0(); num5++)
						{
							cell = row.GetCellByIndex(num5);
							if (cell.IsFormula)
							{
								Class1655 class4 = cell.method_17();
								Class1674.smethod_5(class4.byte_0, -1, -1, worksheetCollection_0, workbook.Worksheets, i, @class, bool_0: false, this);
								if (class4.method_0() != null)
								{
									Class1674.smethod_5(class4.method_0().Formula, -1, -1, worksheetCollection_0, workbook.Worksheets, i, @class, bool_0: false, this);
								}
							}
						}
					}
					ChartCollection charts = worksheetCollection_0[num3].Charts;
					for (int num6 = 0; num6 < charts.Count; num6++)
					{
						Chart chart = charts[num6];
						for (int num7 = 0; num7 < chart.NSeries.Count; num7++)
						{
							Interface45 @interface = chart.NSeries[num7].method_16();
							if (@interface != null)
							{
								byte[] array2 = @interface.imethod_4();
								if (array2 != null && Class1674.smethod_12(array2, -1, -1, worksheetCollection_0))
								{
									Class1674.smethod_5(array2, -1, -1, worksheetCollection_0, workbook.Worksheets, i, @class, bool_0: false, this);
								}
							}
						}
					}
				}
				for (int num8 = 0; num8 < worksheetCollection_0.Names.Count; num8++)
				{
					Name name3 = worksheetCollection_0.Names[num8];
					if (name3.method_2() != null)
					{
						Class1674.smethod_5(name3.method_2(), -1, -1, worksheetCollection_0, workbook.Worksheets, i, @class, bool_0: false, this);
					}
				}
				break;
			}
			}
		}
	}

	internal void method_20(FileFormatType fileFormatType_1, bool bool_2)
	{
		fileFormatType_0 = fileFormatType_1;
		Enum187 @enum = smethod_0(fileFormatType_1, enum187_0, bool_2);
		if (@enum != enum187_0)
		{
			method_25(enum187_0, @enum);
		}
		enum187_0 = @enum;
	}

	[SpecialName]
	internal Enum187 method_21()
	{
		return enum187_0;
	}

	private void method_22(FileFormatType fileFormatType_1)
	{
		fileFormatType_0 = fileFormatType_1;
		enum187_0 = smethod_0(fileFormatType_1, enum187_0, bool_2: true);
	}

	private static Enum187 smethod_0(FileFormatType fileFormatType_1, Enum187 enum187_1, bool bool_2)
	{
		switch (fileFormatType_1)
		{
		case FileFormatType.Excel97:
		case FileFormatType.Excel2000:
		case FileFormatType.ExcelXP:
		case FileFormatType.Default:
			return Enum187.const_0;
		default:
			return enum187_1;
		case FileFormatType.SpreadsheetML:
		case FileFormatType.Excel2003XML:
			if (bool_2)
			{
				return Enum187.const_0;
			}
			return enum187_1;
		case FileFormatType.Xlsx:
		case FileFormatType.Xlsm:
		case FileFormatType.Xltx:
		case FileFormatType.Xltm:
		case FileFormatType.Xlsb:
			return Enum187.const_1;
		}
	}

	[SpecialName]
	internal bool method_23()
	{
		return enum187_0 == Enum187.const_1;
	}

	[SpecialName]
	internal bool method_24()
	{
		return enum187_0 == Enum187.const_1;
	}

	private void method_25(Enum187 enum187_1, Enum187 enum187_2)
	{
		switch (enum187_1)
		{
		case Enum187.const_0:
			switch (enum187_2)
			{
			case Enum187.const_1:
				method_26();
				break;
			case Enum187.const_0:
				break;
			}
			break;
		case Enum187.const_1:
			switch (enum187_2)
			{
			case Enum187.const_0:
				method_27();
				break;
			case Enum187.const_1:
				break;
			}
			break;
		}
	}

	private void method_26()
	{
		worksheetCollection_0.class1658_0 = null;
		NameCollection names = worksheetCollection_0.Names;
		for (int i = 0; i < names.Count; i++)
		{
			Name name = names[i];
			byte[] array = name.method_2();
			if (array != null && array.Length > 2)
			{
				name.method_3(Class1247.smethod_1(array, -1, 0, 0, bool_0: true));
			}
		}
		foreach (Class1718 item in worksheetCollection_0.method_39())
		{
			if (item.method_0() != null && item.method_0().Count > 0)
			{
				for (int j = 0; j < item.method_0().Count; j++)
				{
					Class1653 class1653_ = (Class1653)item.method_0()[j];
					Class1247.smethod_0(class1653_);
				}
			}
		}
		for (int k = 0; k < worksheetCollection_0.Count; k++)
		{
			Worksheet worksheet = worksheetCollection_0[k];
			if (worksheet.Type == SheetType.Chart)
			{
				Chart chart = worksheet.Charts[0];
				chart.method_53();
				continue;
			}
			if (worksheet.method_36() != null && worksheet.method_36().Count > 0)
			{
				worksheet.Shapes.method_40();
			}
			Cells cells = worksheet.Cells;
			foreach (Row row3 in cells.Rows)
			{
				foreach (Cell cell in row3.Cells)
				{
					if (!cell.IsFormula)
					{
						continue;
					}
					byte[] array = cell.method_41();
					if (array != null)
					{
						cell.method_42(Class1247.smethod_1(array, -1, cell.Row, cell.Column, bool_0: false));
						if (cell.method_17().method_0() != null)
						{
							array = cell.method_17().method_0().Formula;
							cell.method_17().method_0().Formula = Class1247.smethod_1(array, -1, cell.Row, cell.Column, bool_0: false);
						}
					}
				}
			}
			ValidationCollection validations = worksheet.Validations;
			for (int l = 0; l < validations.Count; l++)
			{
				Validation validation = validations[l];
				validation.method_12(out var row2, out var column);
				if (validation.method_7() != null)
				{
					validation.method_8(Class1247.smethod_1(validation.method_7(), 0, row2, column, bool_0: true));
				}
				if (validation.method_9() != null)
				{
					validation.method_10(Class1247.smethod_1(validation.method_9(), 0, row2, column, bool_0: true));
				}
			}
			ConditionalFormattingCollection conditionalFormattingCollection_ = worksheet.conditionalFormattingCollection_0;
			if (conditionalFormattingCollection_ != null && conditionalFormattingCollection_.Count > 0)
			{
				for (int m = 0; m < conditionalFormattingCollection_.Count; m++)
				{
					FormatConditionCollection formatConditionCollection = conditionalFormattingCollection_[m];
					formatConditionCollection.method_12(bool_2: true);
				}
			}
			SparklineGroupCollection sparklineGroupCollection = worksheet.SparklineGroupCollection;
			if (sparklineGroupCollection.Count > 0)
			{
				sparklineGroupCollection.method_2();
			}
		}
	}

	private void method_27()
	{
		worksheetCollection_0.class1658_0 = null;
		method_5();
		NameCollection names = worksheetCollection_0.Names;
		for (int i = 0; i < names.Count; i++)
		{
			Name name = names[i];
			byte[] array = name.method_2();
			if (array != null && array.Length > 2)
			{
				name.method_3(Class1248.smethod_1(array, -1));
			}
		}
		foreach (Class1718 item in worksheetCollection_0.method_39())
		{
			if (item.method_0() != null && item.method_0().Count > 0)
			{
				for (int j = 0; j < item.method_0().Count; j++)
				{
					Class1653 class1653_ = (Class1653)item.method_0()[j];
					Class1248.smethod_0(class1653_);
				}
			}
		}
		for (int k = 0; k < worksheetCollection_0.Count; k++)
		{
			Worksheet worksheet = worksheetCollection_0[k];
			if (worksheet.Type == SheetType.Chart)
			{
				Chart chart = worksheet.Charts[0];
				chart.method_54();
				continue;
			}
			if (worksheet.method_36() != null && worksheet.method_36().Count > 0)
			{
				worksheet.method_36().method_39();
			}
			Cells cells = worksheet.Cells;
			foreach (Row row3 in cells.Rows)
			{
				foreach (Cell cell in row3.Cells)
				{
					if (!cell.IsFormula)
					{
						continue;
					}
					byte[] array = cell.method_41();
					if (array != null)
					{
						cell.method_42(Class1248.smethod_1(array, -1));
						if (cell.method_17().method_0() != null)
						{
							array = cell.method_17().method_0().Formula;
							cell.method_17().method_0().Formula = Class1248.smethod_1(array, -1);
						}
					}
				}
			}
			ValidationCollection validations = worksheet.Validations;
			for (int l = 0; l < validations.Count; l++)
			{
				Validation validation = validations[l];
				validation.method_12(out var _, out var _);
				if (validation.method_7() != null)
				{
					validation.method_8(Class1248.smethod_1(validation.method_7(), 0));
				}
				if (validation.method_9() != null)
				{
					validation.method_10(Class1248.smethod_1(validation.method_9(), 0));
				}
			}
			ConditionalFormattingCollection conditionalFormattingCollection_ = worksheet.conditionalFormattingCollection_0;
			if (conditionalFormattingCollection_ != null && conditionalFormattingCollection_.Count > 0)
			{
				for (int m = 0; m < conditionalFormattingCollection_.Count; m++)
				{
					FormatConditionCollection formatConditionCollection = conditionalFormattingCollection_[m];
					formatConditionCollection.method_12(bool_2: false);
				}
			}
			SparklineGroupCollection sparklineGroupCollection = worksheet.SparklineGroupCollection;
			if (sparklineGroupCollection.Count > 0)
			{
				sparklineGroupCollection.method_3();
			}
		}
	}

	private Stream method_28(Class1317 class1317_0, byte[] byte_0)
	{
		int num = 8;
		int num2 = BitConverter.ToInt32(byte_0, 8);
		uint uint_ = BitConverter.ToUInt32(byte_0, 8 + 12);
		uint uint_2 = BitConverter.ToUInt32(byte_0, 8 + 16);
		BitConverter.ToUInt32(byte_0, 8 + 20);
		uint uint_3 = BitConverter.ToUInt32(byte_0, 8 + 24);
		num = 12 + num2;
		num2 = BitConverter.ToInt32(byte_0, num);
		num += 4;
		byte[] array = new byte[num2];
		byte[] array2 = new byte[num2];
		Array.Copy(byte_0, num, array, 0, num2);
		num += num2;
		Array.Copy(byte_0, num, array2, 0, num2);
		num += num2;
		num += 4;
		byte[] array3 = new byte[byte_0.Length - num];
		Array.Copy(byte_0, num, array3, 0, array3.Length);
		num += num2;
		try
		{
			Class1636 @class = null;
			string text = Settings.Password;
			if (text == null || text == "")
			{
				text = "VelvetSweatshop";
			}
			@class = new Class1636(text, array, array2, array3, "", uint_3, 0u, uint_2, uint_);
			if (!@class.method_1())
			{
				throw new CellsException(ExceptionType.IncorrectPassword, "Invalid password.");
			}
			return @class.method_3(class1317_0.method_9().GetStream("EncryptedPackage"));
		}
		catch
		{
			if (Settings.Password != null && !(Settings.Password == ""))
			{
				throw new CellsException(ExceptionType.IncorrectPassword, "Invalid password.");
			}
			throw new CellsException(ExceptionType.IncorrectPassword, "Please provide password for the Workbook file.");
		}
	}

	private Stream method_29(Class1317 class1317_0)
	{
		MemoryStream stream = class1317_0.method_9().GetStream("EncryptionInfo");
		byte[] array = new byte[(int)stream.Length];
		stream.Read(array, 0, array.Length);
		if (array[0] == 4 && array[2] == 4)
		{
			string s = "VelvetSweatshop";
			if (Settings.Password != null && Settings.Password != "")
			{
				s = Settings.Password;
			}
			Class1115 @class = new Class1115(class1317_0, array, Encoding.Unicode.GetBytes(s));
			if (@class.method_2())
			{
				return @class.method_3();
			}
			throw new CellsException(ExceptionType.IncorrectPassword, "Invalid password.");
		}
		return method_28(class1317_0, array);
	}

	internal void method_30()
	{
		if (interruptMonitor_0 != null && interruptMonitor_0.bool_0)
		{
			throw new CellsException(ExceptionType.Interrupted, "Interrupted by user");
		}
	}

	public void ImportXml(string url, string sheetName, int row, int col)
	{
		class442_0 = new Class442();
		Class442 @class = class442_0;
		string value = Class1618.smethod_245(url, @class);
		@class.arrayList_0.Add(value);
		XmlMap xmlMap = new XmlMap();
		xmlMap.int_0 = Worksheets.XmlMaps.Count + 1;
		Worksheets.XmlMaps.arrayList_0.Add(Class1618.smethod_246(Worksheets.XmlMaps.Count + 1));
		Worksheets.XmlMaps.string_0 = "";
		xmlMap.string_2 = "Schema" + (Worksheets.XmlMaps.Count + 1);
		xmlMap.xmlDataBinding_0 = new XmlDataBinding();
		xmlMap.xmlDataBinding_0.bool_0 = true;
		Worksheets.XmlMaps.Add(xmlMap);
		Worksheet worksheet = Worksheets[sheetName];
		ListObject listObject = new ListObject(worksheet.ListObjects);
		listObject.DisplayName = "Table1";
		worksheet.ListObjects.Add(listObject);
		listObject.method_6(new ListColumnCollection(listObject));
		Class1741.smethod_7(xmlMap, url, worksheet, listObject, row, col);
	}

	/// <summary>
	///       Set digital signature to file.
	///       </summary>
	/// <param name="digitalSignatureCollection">
	/// </param>
	/// <remarks>Only support adding digital signature to OOXML file.</remarks>
	public void SetDigitalSignature(DigitalSignatureCollection digitalSignatureCollection)
	{
		digitalSignatureCollection_0 = digitalSignatureCollection;
	}

	/// <summary>
	///       Get digital signature from file.
	///       </summary>
	public DigitalSignatureCollection GetDigitalSignature()
	{
		return class997_0.method_0();
	}

	internal void method_31(Stream stream_0)
	{
		if (digitalSignatureCollection_0 != null && digitalSignatureCollection_0.arrayList_0.Count > 0)
		{
			stream_0.Position = 0L;
			Class1006 @class = new Class1006(digitalSignatureCollection_0);
			@class.method_0(stream_0);
		}
	}

	internal void method_32(Class1540 class1540_0)
	{
		if (digitalSignatureCollection_0 == null || digitalSignatureCollection_0.arrayList_0.Count <= 0)
		{
			return;
		}
		if (IsDigitallySigned)
		{
			if (class1558_0 != null)
			{
				class1558_0.RemoveDigitallySign();
			}
			if (Worksheets.method_10() != null)
			{
				Worksheets.method_10().method_9().Remove("_signatures");
			}
			class997_0 = null;
		}
		class1540_0.bool_2 = true;
	}

	[SpecialName]
	internal Hashtable method_33()
	{
		return hashtable_0;
	}
}
