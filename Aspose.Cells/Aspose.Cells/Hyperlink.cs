using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using ns2;

namespace Aspose.Cells;

/// <summary>
///       Encapsulates the object that represents a hyperlink.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Instantiating a Workbook object
///       Workbook workbook = new Workbook();
///       //Adding a new worksheet to the Workbook object
///       workbook.Worksheets.Add();
///       //Obtaining the reference of the newly added worksheet by passing its sheet index
///       Worksheet worksheet = workbook.Worksheets[0];
///       //Adding a hyperlink to a URL at "A1" cell
///       worksheet.Hyperlinks.Add("A1", 1, 1, "http://www.aspose.com");
///       //Saving the Excel file
///       workbook.Save("C:\\book1.xls");
///
///       [Visual Basic]
///
///       'Instantiating a Workbook object
///       Dim workbook As Workbook = New Workbook()
///       'Adding a new worksheet to the Workbook object
///       workbook.Worksheets.Add()
///       'Obtaining the reference of the newly added worksheet by passing its sheet index
///       Dim worksheet As Worksheet = workbook.Worksheets(0)
///       'Adding a hyperlink to a URL at "A1" cell
///       worksheet.Hyperlinks.Add("A1", 1, 1, "http://www.aspose.com")
///       'Saving the Excel file
///       workbook.Save("C:\book1.xls")
///       </code>
/// </example>
public class Hyperlink
{
	private HyperlinkCollection hyperlinkCollection_0;

	private bool bool_0;

	private bool bool_1;

	private string string_0;

	private string string_1;

	private CellArea cellArea_0;

	private string string_2;

	/// <summary>
	///       Represents the address of a hyperlink.
	///       </summary>
	public string Address
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

	/// <summary>
	///       Represents the text to be displayed for the specified hyperlink. The default value is the address of the hyperlink. 
	///       </summary>
	public string TextToDisplay
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
			Worksheet worksheet = hyperlinkCollection_0.Worksheet;
			if (worksheet != null)
			{
				Cells cells = worksheet.Cells;
				Cell cell = cells.GetCell(cellArea_0.StartRow, cellArea_0.StartColumn, bool_2: false);
				Enum199 @enum = cell.method_20();
				if (@enum == Enum199.const_7 || @enum == Enum199.const_6)
				{
					cell.PutValue(value);
				}
				Font defaultFont = worksheet.method_2().DefaultFont;
				Style style = cell.method_28();
				style.Font.method_13(defaultFont.Name);
				style.Font.Size = defaultFont.Size;
				style.Font.IsBold = false;
				style.Font.IsItalic = false;
				style.Font.Color = Color.Blue;
				style.Font.Underline = FontUnderlineType.Single;
				cell.method_30(style);
			}
		}
	}

	/// <summary>
	///       Gets the range of hyperlink.
	///       </summary>
	public CellArea Area => cellArea_0;

	/// <summary>
	///       Returns or sets the ScreenTip text for the specified hyperlink.
	///       </summary>
	public string ScreenTip
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

	internal Hyperlink(HyperlinkCollection hyperlinkCollection_1, CellArea cellArea_1)
	{
		hyperlinkCollection_0 = hyperlinkCollection_1;
		cellArea_0 = cellArea_1;
	}

	[SpecialName]
	internal void method_0(bool bool_2)
	{
		bool_0 = bool_2;
	}

	[SpecialName]
	internal void method_1(bool bool_2)
	{
		bool_1 = bool_2;
	}

	internal void method_2(string string_3)
	{
		Worksheet worksheet = hyperlinkCollection_0.Worksheet;
		if (worksheet != null)
		{
			Cells cells = worksheet.Cells;
			Cell cell = cells.GetCell(cellArea_0.StartRow, cellArea_0.StartColumn, bool_2: false);
			switch (cell.method_20())
			{
			case Enum199.const_7:
				cell.PutValue(string_3);
				string_1 = string_3;
				break;
			case Enum199.const_6:
				string_1 = cell.StringValue;
				break;
			}
			Font defaultFont = worksheet.method_2().DefaultFont;
			Style style = cell.method_28();
			style.Font.method_13(defaultFont.Name);
			style.Font.Size = defaultFont.Size;
			style.Font.IsBold = false;
			style.Font.IsItalic = false;
			style.Font.Color = Color.Blue;
			style.Font.Underline = FontUnderlineType.Single;
			cell.method_30(style);
		}
	}

	internal void method_3(string string_3)
	{
		string_1 = string_3;
	}

	internal void method_4(CellArea cellArea_1)
	{
		cellArea_0 = cellArea_1;
	}

	internal Hyperlink()
	{
	}

	internal void Copy(Hyperlink hyperlink_0)
	{
		string_0 = hyperlink_0.string_0;
		cellArea_0 = CellArea.CreateCellArea(hyperlink_0.cellArea_0);
		string_2 = hyperlink_0.string_2;
		string_1 = hyperlink_0.string_1;
	}

	internal void CopyData(Hyperlink hyperlink_0)
	{
		string_0 = hyperlink_0.string_0;
		string_2 = hyperlink_0.string_2;
		string_1 = hyperlink_0.string_1;
	}

	internal int method_5(WorksheetCollection worksheetCollection_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			string text = string_0.ToLower();
			if (!text.StartsWith("http:") && !text.StartsWith("www.") && !text.StartsWith("https:") && !text.StartsWith("mailto:"))
			{
				if ((text.Length > 1 && text[1] == ':') || text.StartsWith("\\\\"))
				{
					return 1;
				}
				Match match = Regex.Match(text, "^\\w+:", RegexOptions.IgnoreCase);
				if (match.Success)
				{
					return 0;
				}
				if (string_0.IndexOf("!") != -1)
				{
					string[] array = string_0.Split('!');
					if (array.Length == 2)
					{
						string text2 = array[0];
						if (text2.IndexOf('\\') == -1 && text2.IndexOf('/') == -1 && text2.IndexOf("file:///") == -1)
						{
							return 2;
						}
						text2 = text2.Trim('\'');
						if (Class1677.smethod_40(worksheetCollection_0, text2))
						{
							return 2;
						}
					}
				}
				else
				{
					string_0 = string_0.Trim('\'');
					for (int i = 0; i < worksheetCollection_0.Names.Count; i++)
					{
						Name name = worksheetCollection_0.Names[i];
						if (name.Text.Equals(string_0))
						{
							return 2;
						}
					}
				}
				return 1;
			}
			return 0;
		}
		return -1;
	}
}
