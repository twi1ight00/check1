using System.Collections;
using System.Runtime.CompilerServices;
using ns2;

namespace Aspose.Cells;

/// <summary>
///       Represents external links collection in a workbook.
///       </summary>
/// <example>
///   <code>
///       [C#]
///       //Open a file with external links
///       Workbook workbook = new Workbook("d:\\book1.xls");
///
///       //Change external link data source
///       workbook.Worksheets.ExternalLinks[0].DataSource = "d:\\link.xls";
///
///
///       [Visual Basic]
///       'Open a file with external links
///       Dim workbook As Workbook =  New Workbook("d:\\book1.xls")
///
///       'Change external link data source
///       workbook.Worksheets.ExternalLinks(0).DataSource = "d:\\link.xls"
///       </code>
/// </example>
public class ExternalLinkCollection
{
	private WorksheetCollection worksheetCollection_0;

	private ArrayList arrayList_0;

	private int int_0;

	/// <summary>
	///       Gets the number of elements actually contained in the collection.
	///       </summary>
	public int Count => arrayList_0.Count;

	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.ExternalLink" /> element at the specified index.
	///        </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public ExternalLink this[int index] => (ExternalLink)arrayList_0[index];

	[SpecialName]
	internal WorksheetCollection method_0()
	{
		return worksheetCollection_0;
	}

	internal ExternalLinkCollection(WorksheetCollection worksheetCollection_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
		arrayList_0 = new ArrayList();
	}

	/// <summary>
	///       Adds an external link.
	///       </summary>
	/// <param name="fileName">The external file name.</param>
	/// <param name="sheetNames">All sheet names of the external file.</param>
	/// <returns>The position of the external name in this list. </returns>
	public int Add(string fileName, string[] sheetNames)
	{
		Class1718 @class = new Class1718();
		@class.method_24(fileName, sheetNames, Enum188.const_0);
		ExternalLink externalLink = new ExternalLink(this);
		externalLink.method_0(@class);
		int num = 0;
		while (true)
		{
			if (num < Count)
			{
				Class1718 class2 = this[num].method_1();
				if (string.Compare(class2.method_25(), fileName, ignoreCase: true) == 0)
				{
					break;
				}
				num++;
				continue;
			}
			worksheetCollection_0.method_39().Add(@class);
			return arrayList_0.Add(externalLink);
		}
		arrayList_0[num] = externalLink;
		return num;
	}

	/// <summary>
	///       Add an external link .
	///       </summary>
	/// <param name="directoryType">The directory type of the file name.</param>
	/// <param name="fileName">the file name.</param>
	/// <param name="sheetNames">All sheet names of the external file.</param>
	/// <returns>The position of the external name in this list. </returns>
	public int Add(DirectoryType directoryType, string fileName, string[] sheetNames)
	{
		Class1718 @class = new Class1718();
		switch (directoryType)
		{
		default:
			@class.method_24(fileName, sheetNames, Enum188.const_0);
			break;
		case DirectoryType.SameVolume:
			@class.method_24(fileName, sheetNames, Enum188.const_2);
			break;
		case DirectoryType.DownDirectory:
			@class.method_24(fileName, sheetNames, Enum188.const_3);
			break;
		case DirectoryType.UpDirectory:
			@class.method_24(fileName, sheetNames, Enum188.const_4);
			break;
		}
		ExternalLink externalLink = new ExternalLink(this);
		externalLink.method_0(@class);
		int num = 0;
		while (true)
		{
			if (num < Count)
			{
				Class1718 class2 = this[num].method_1();
				if (string.Compare(class2.method_25(), fileName, ignoreCase: true) == 0)
				{
					break;
				}
				num++;
				continue;
			}
			worksheetCollection_0.method_39().Add(@class);
			return arrayList_0.Add(externalLink);
		}
		arrayList_0[num] = externalLink;
		return num;
	}

	internal int Add(ExternalLink externalLink_0)
	{
		return arrayList_0.Add(externalLink_0);
	}

	internal void method_1(Class1303 class1303_0)
	{
		if (class1303_0 == null)
		{
			return;
		}
		for (int i = 0; i < class1303_0.Count; i++)
		{
			Class1718 @class = class1303_0[i];
			if (@class.method_12())
			{
				int_0 = i;
			}
			else if (@class.method_15())
			{
				ExternalLink externalLink = new ExternalLink(this);
				externalLink.method_0(@class);
				Add(externalLink);
			}
		}
	}
}
