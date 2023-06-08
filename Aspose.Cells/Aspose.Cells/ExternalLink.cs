using System.Collections;
using System.Runtime.CompilerServices;
using ns2;

namespace Aspose.Cells;

/// <summary>
///        Represents an external link in a workbook.
///        </summary>
/// <example>
///   <code>
///
///        [C#]
///
///        //Open a file with external links
///        Workbook workbook = new Workbook("d:\\book1.xls");
///
///        //Get External Link 
///        ExternalLink externalLink = workbook.Worksheets.ExternalLinks[0];
///
///        //Change External Link's Data Source
///        externalLink.DataSource = "d:\\link.xls";
///
///        [VB.NET]
///
///        'Open a file with external links
///        Dim workbook As New Workbook("d:\book1.xls")
///
///        'Get External Link 
///        Dim externalLink As ExternalLink = workbook.Worksheets.ExternalLinks(0)
///
///        'Change External Link's Data Source
///        externalLink.DataSource = "d:\link.xls"
///        </code>
/// </example>
public class ExternalLink
{
	private ExternalLinkCollection externalLinkCollection_0;

	private Class1718 class1718_0;

	/// <summary>
	///       Represents data source of the external link.
	///       </summary>
	public string DataSource
	{
		get
		{
			return class1718_0.method_19(externalLinkCollection_0.method_0().Workbook);
		}
		set
		{
			class1718_0.method_24(value, class1718_0.method_4(), Enum188.const_0);
		}
	}

	/// <summary>
	///       Indicates whether this external link is refered by others.
	///       </summary>
	public bool IsReferred
	{
		get
		{
			Hashtable hashtable = new Hashtable();
			WorksheetCollection worksheetCollection = externalLinkCollection_0.method_0();
			Class1303 @class = worksheetCollection.method_39();
			int num = -1;
			for (int i = 0; i < @class.Count; i++)
			{
				if (@class[i] == class1718_0)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				return false;
			}
			Class1118 class2 = worksheetCollection.method_32();
			for (int j = 0; j < class2.Count; j++)
			{
				Class1246 class3 = class2[j];
				if (class3.ushort_0 == num)
				{
					hashtable[j] = j;
				}
			}
			Cell cell = null;
			Hashtable hashtable_ = new Hashtable();
			int num2 = 0;
			while (true)
			{
				if (num2 < worksheetCollection.Names.Count)
				{
					Name name = worksheetCollection.Names[num2];
					if (name.method_2() != null && Class1674.smethod_13(name.method_2(), -1, -1, worksheetCollection, hashtable, hashtable_))
					{
						break;
					}
					num2++;
					continue;
				}
				for (int k = 0; k < worksheetCollection.Count; k++)
				{
					Cells cells = worksheetCollection[k].Cells;
					for (int l = 0; l < cells.Rows.Count; l++)
					{
						Row rowByIndex = cells.Rows.GetRowByIndex(l);
						for (int m = 0; m < rowByIndex.method_0(); m++)
						{
							cell = rowByIndex.GetCellByIndex(m);
							if (!cell.IsFormula)
							{
								continue;
							}
							if (cell.method_50() != null)
							{
								if (Class1674.smethod_13(cell.method_50().Formula, -1, -1, worksheetCollection, hashtable, hashtable_))
								{
									return true;
								}
							}
							else if (Class1674.smethod_13(cell.method_41(), -1, -1, worksheetCollection, hashtable, hashtable_))
							{
								return true;
							}
						}
					}
				}
				return false;
			}
			return true;
		}
	}

	internal ExternalLink(ExternalLinkCollection externalLinkCollection_1)
	{
		externalLinkCollection_0 = externalLinkCollection_1;
	}

	internal void method_0(Class1718 class1718_1)
	{
		class1718_0 = class1718_1;
	}

	[SpecialName]
	internal Class1718 method_1()
	{
		return class1718_0;
	}

	/// <summary>
	///       Adds an external name.
	///       </summary>
	/// <param name="text">The text of the external name.
	///       If the external name belongs to a worksheet, the text should be as Sheet1!Text.
	///       </param>
	/// <param name="referTo">The referTo of the external name. It must be a cell or the range.</param>
	public void AddExternalName(string text, string referTo)
	{
		int num = text.LastIndexOf('!');
		string text2 = null;
		int num2 = -1;
		if (num != -1)
		{
			text2 = text.Substring(0, num);
			if (text2[0] == '\'')
			{
				text2 = text2.Substring(1, text2.Length - 2);
			}
			num2 = class1718_0.method_6(text2);
			text = text.Substring(num + 1);
		}
		if (referTo == null || referTo.Length == 0)
		{
			return;
		}
		if (referTo[0] == '=')
		{
			referTo = referTo.Substring(1);
		}
		Class1653 @class = new Class1653(class1718_0);
		@class.Name = text;
		@class.SheetIndex = num2 + 1;
		@class.method_8(externalLinkCollection_0.method_0(), referTo);
		if (class1718_0.method_0() == null)
		{
			class1718_0.method_1(new ArrayList());
		}
		int num3 = 0;
		while (true)
		{
			if (num3 < class1718_0.method_0().Count)
			{
				Class1653 class2 = (Class1653)class1718_0.method_0()[num3];
				if (class2.SheetIndex == num2 + 1 && string.Compare(class2.Name, text, ignoreCase: true) == 0)
				{
					break;
				}
				num3++;
				continue;
			}
			class1718_0.method_0().Add(@class);
			return;
		}
		class1718_0.method_0()[num3] = @class;
	}
}
