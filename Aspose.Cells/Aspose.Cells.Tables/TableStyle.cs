using System.Runtime.CompilerServices;

namespace Aspose.Cells.Tables;

/// <summary>
///       Represents the table style.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       Workbook workbook = new Workbook();
///       Style firstColumnStyle = workbook.CreateStyle();
///       firstColumnStyle.Pattern = BackgroundType.Solid;
///       firstColumnStyle.BackgroundColor = System.Drawing.Color.Red;
///
///       Style lastColumnStyle = workbook.CreateStyle();
///       lastColumnStyle.Font.IsBold = true;
///       lastColumnStyle.Pattern = BackgroundType.Solid;
///       lastColumnStyle.BackgroundColor = System.Drawing.Color.Red;
///       string tableStyleName = "Custom1";
///       TableStyleCollection tableStyles = workbook.Worksheets.TableStyles;
///       int index1 = tableStyles.AddTableStyle(tableStyleName);
///       TableStyle tableStyle = tableStyles[index1];
///       TableStyleElementCollection elements = tableStyle.TableStyleElements;
///       index1 = elements.Add(TableStyleElementType.FirstColumn);
///       TableStyleElement element = elements[index1];
///       element.SetElementStyle(firstColumnStyle);
///       index1 = elements.Add(TableStyleElementType.LastColumn);
///       element = elements[index1];
///       element.SetElementStyle(lastColumnStyle);
///       Cells cells = workbook.Worksheets[0].Cells;
///       for (int i = 0; i  &lt;5; i++)
///       {
///           cells[0, i].PutValue(CellsHelper.ColumnIndexToName(i));
///       }
///       for (int row = 1; row  &lt;10; row++)
///       {
///           for (int column = 0; column  &lt;5; column++)
///           {
///               cells[row, column].PutValue(row * column);
///           }
///        }
///       ListObjectCollection tables = workbook.Worksheets[0].ListObjects;
///       int index = tables.Add(0, 0, 9, 4, true);
///       ListObject table = tables[0];
///       table.ShowTableStyleFirstColumn = true;
///       table.ShowTableStyleLastColumn = true;
///       table.TableStyleName = tableStyleName;
///       workbook.Save(@"C:\Book1.xlsx");
///
///       [Visual Basic]
///
///         Dim workbook As Workbook = New Workbook()
///       Dim firstColumnStyle As Style = workbook.CreateStyle()
///       firstColumnStyle.Pattern = BackgroundType.Solid
///       firstColumnStyle.BackgroundColor = System.Drawing.Color.Red
///       Dim lastColumnStyle As Style = workbook.CreateStyle()
///
///       lastColumnStyle.Font.IsBold = True
///       lastColumnStyle.Pattern = BackgroundType.Solid
///       lastColumnStyle.BackgroundColor = System.Drawing.Color.Red
///       Dim tableStyleName As String = "Custom1"
///
///       Dim tableStyles As TableStyleCollection = workbook.Worksheets.TableStyles
///       Dim index1 As Int32 = tableStyles.AddTableStyle(tableStyleName)
///       Dim tableStyle As TableStyle = tableStyles(index1)
///       Dim elements As TableStyleElementCollection = tableStyle.TableStyleElements
///       index1 = elements.Add(TableStyleElementType.FirstColumn)
///       Dim element As TableStyleElement = elements(index1)
///       element.SetElementStyle(firstColumnStyle)
///       index1 = elements.Add(TableStyleElementType.LastColumn)
///       element = elements(index1)
///       element.SetElementStyle(lastColumnStyle)
///       Dim cells As Cells = workbook.Worksheets(0).Cells
///       For i As Int32 = 0 To 4
///           cells(0, i).PutValue(CellsHelper.ColumnIndexToName(i))
///       Next
///       For row As Int32 = 1 To 9
///           For column As Int32 = 0 To 4
///               cells(row, column).PutValue(row * column)
///           Next
///       Next
///       Dim tables As ListObjectCollection = workbook.Worksheets(0).ListObjects
///       Dim index As Int32 = tables.Add(0, 0, 9, 4, True)
///       Dim table As ListObject = tables(0)
///       table.ShowTableStyleFirstColumn = True
///       table.ShowTableStyleLastColumn = True
///       table.TableStyleName = tableStyleName
///       workbook.Save("C:\Book1.xlsx")
///       </code>
/// </example>
public class TableStyle
{
	private string string_0;

	private TableStyleCollection tableStyleCollection_0;

	private TableStyleElementCollection tableStyleElementCollection_0;

	private bool bool_0 = true;

	private bool bool_1 = true;

	/// <summary>
	///       Gets the name of table style.
	///       </summary>
	public string Name => string_0;

	/// <summary>
	///       Gets all elements of the table style.
	///       </summary>
	public TableStyleElementCollection TableStyleElements => tableStyleElementCollection_0;

	[SpecialName]
	internal TableStyleCollection method_0()
	{
		return tableStyleCollection_0;
	}

	internal TableStyle(TableStyleCollection tableStyleCollection_1, string string_1)
	{
		string_0 = string_1;
		tableStyleCollection_0 = tableStyleCollection_1;
		tableStyleElementCollection_0 = new TableStyleElementCollection(this);
	}

	internal void Copy(TableStyle tableStyle_0)
	{
		string_0 = tableStyle_0.string_0;
		bool_0 = tableStyle_0.bool_0;
		bool_1 = tableStyle_0.bool_1;
		tableStyleElementCollection_0 = new TableStyleElementCollection(this);
		tableStyleElementCollection_0.Copy(tableStyle_0.tableStyleElementCollection_0);
	}

	internal void method_1(TableStyleElementCollection tableStyleElementCollection_1)
	{
		tableStyleElementCollection_0 = tableStyleElementCollection_1;
	}

	[SpecialName]
	internal bool method_2()
	{
		return bool_0;
	}

	[SpecialName]
	internal void method_3(bool bool_2)
	{
		bool_0 = bool_2;
	}

	[SpecialName]
	internal bool method_4()
	{
		return bool_1;
	}

	[SpecialName]
	internal void method_5(bool bool_2)
	{
		bool_1 = bool_2;
	}

	internal void Add(TableStyleElementType tableStyleElementType_0, int int_0, Style style_0)
	{
		if (tableStyleElementCollection_0 == null)
		{
			tableStyleElementCollection_0 = new TableStyleElementCollection(this);
		}
		TableStyleElement tableStyleElement = new TableStyleElement(tableStyleElementCollection_0, tableStyleElementType_0);
		tableStyleElement.Size = int_0;
		tableStyleElement.method_2(style_0);
		tableStyleElementCollection_0.Add(tableStyleElement);
	}
}
