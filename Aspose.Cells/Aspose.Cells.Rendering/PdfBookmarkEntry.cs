using System.Collections;
using System.Drawing;

namespace Aspose.Cells.Rendering;

/// <summary>
///        PdfBookmarkEntry is an entry in pdf bookmark.
///        </summary>
/// <example>
///   <code>
///        [C#]    
///       Workbook workbook = new Workbook();
///       workbook.Worksheets.Add();
///       workbook.Worksheets.Add();
///       Cell cellInPage1 = workbook.Worksheets[0].Cells["A0"];
///       Cell cellInPage2 = workbook.Worksheets[1].Cells["A0"];
///       Cell cellInPage3 = workbook.Worksheets[2].Cells["A0"];
///       cellInPage1.PutValue("page1");
///       cellInPage2.PutValue("page2");
///       cellInPage3.PutValue("page3");
///
///       PdfBookmarkEntry pbeRoot = new PdfBookmarkEntry();
///       pbeRoot.Text = "root";
///       pbeRoot.Destination = cellInPage1;
///       pbeRoot.SubEntry = new ArrayList();
///       pbeRoot.IsOpen = false;
///
///       PdfBookmarkEntry subPbe1 = new PdfBookmarkEntry();
///       subPbe1.Text = "section1";
///       subPbe1.Destination = cellInPage2;
///
///       PdfBookmarkEntry subPbe2 = new PdfBookmarkEntry();
///       subPbe2.Text = "section2";
///       subPbe2.Destination = cellInPage3;
///
///       pbeRoot.SubEntry.Add(subPbe1);
///       pbeRoot.SubEntry.Add(subPbe2);
///
///       workbook.SaveOptions.PdfBookmark = pbeRoot;
///       workbook.Save("c:\\Test.pdf");
///
///        [VB]    
///       Dim workbook As Workbook = New Workbook
///       workbook.Worksheets.Add("sheet2")
///       workbook.Worksheets.Add("sheet3")
///
///       Dim cells As Cells = workbook.Worksheets(0).Cells
///       Dim cellInPage1 As Cell = cells("A0")
///       cellInPage1.PutValue("Page1")
///
///       cells = workbook.Worksheets(1).Cells
///       Dim cellInPage2 As Cell = cells("A0")
///       cellInPage2.PutValue("Page2")
///
///       cells = workbook.Worksheets(2).Cells
///       Dim cellInPage3 As Cell = cells("A0")
///       cellInPage3.PutValue("Page3")
///
///       Dim pbeRoot As PdfBookmarkEntry = New PdfBookmarkEntry()
///       pbeRoot.Text = "root"
///       pbeRoot.Destination = cellInPage1
///       pbeRoot.SubEntry = New ArrayList
///       pbeRoot.IsOpen = False
///
///       Dim subPbe1 As PdfBookmarkEntry = New PdfBookmarkEntry()
///       subPbe1.Text = "section1"
///       subPbe1.Destination = cellInPage2
///
///       Dim subPbe2 As PdfBookmarkEntry = New PdfBookmarkEntry()
///       subPbe2.Text = "section2"
///       subPbe2.Destination = cellInPage3
///
///       pbeRoot.SubEntry.Add(subPbe1)
///       pbeRoot.SubEntry.Add(subPbe2)
///
///       workbook.SaveOptions.PdfBookmark = pbeRoot
///       workbook.Save("c:\\Test.pdf")
///        </code>
/// </example>
public class PdfBookmarkEntry
{
	private string string_0;

	private Cell cell_0;

	private ArrayList arrayList_0;

	internal int int_0 = -1;

	internal PointF pointF_0 = default(PointF);

	private bool bool_0;

	/// <summary>
	///       Title of a bookmark.
	///       </summary>
	public string Text
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
	///       The cell to which the bookmark link.
	///       </summary>
	public Cell Destination
	{
		get
		{
			return cell_0;
		}
		set
		{
			cell_0 = value;
		}
	}

	/// <summary>
	///       SubEntry of a bookmark.
	///       </summary>
	public ArrayList SubEntry
	{
		get
		{
			return arrayList_0;
		}
		set
		{
			arrayList_0 = value;
		}
	}

	/// <summary>
	///       When this property is true, the bookmarkentry will expand, otherwise it will collapse.
	///       </summary>
	public bool IsOpen
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
	///       When this property is true, the bookmarkentry will collapse, otherwise it will expand.
	///       </summary>
	public bool IsCollapse
	{
		get
		{
			return !bool_0;
		}
		set
		{
			bool_0 = !value;
		}
	}

	internal void method_0(int int_1, PointF pointF_1)
	{
		int_0 = int_1;
		pointF_0 = pointF_1;
	}

	internal bool method_1()
	{
		return int_0 != -1;
	}
}
