using System.Collections;
using System.Collections.Generic;
using ns34;
using ns42;
using ns43;

namespace Aspose.Slides.Charts;

public class ChartDataWorksheet : IChartDataWorksheet
{
	internal const string string_0 = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";

	internal const string string_1 = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet";

	private readonly ChartDataWorkbook chartDataWorkbook_0;

	internal Class827 class827_0;

	private uint uint_0;

	private string string_2 = "*";

	private Class738 class738_0;

	private List<Class812> list_0 = new List<Class812>();

	private int int_0;

	internal Class809 class809_0;

	private Class799 class799_0 = new Class799();

	internal bool IsSelected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public string Name => string_2;

	internal string NameInternal
	{
		set
		{
			string_2 = value;
		}
	}

	internal Class738 Cells => class738_0;

	internal uint SheetId
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public int Index => int_0;

	internal int IndexInternal
	{
		set
		{
			int_0 = value;
		}
	}

	internal ChartDataWorkbook ParentWorkbook => chartDataWorkbook_0;

	internal Class799 SheetPartXLSXUnsupportedProps => class799_0;

	internal ChartDataWorksheet(ChartDataWorkbook parent)
	{
		chartDataWorkbook_0 = parent;
		class738_0 = new Class738(this);
		class809_0 = new Class809(this);
	}

	internal ChartDataWorksheet(ChartDataWorkbook parent, Class819 elem, Class808 sst)
	{
		chartDataWorkbook_0 = parent;
		class738_0 = new Class738(this);
		class809_0 = new Class809(this);
		method_0(elem, sst);
	}

	internal void method_0(Class819 elem, Class808 sst)
	{
		class827_0 = (Class827)elem.OwnerDocument;
		class827_0.class1086_0.object_0 = this;
		Class810 @class = elem.method_57("sheetData", Class827.string_12);
		Class810 class2 = elem.method_57("cols", Class827.string_12);
		if (class2 != null)
		{
			Class810[] array = class2.method_56("col", Class827.string_12);
			Class810[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				Class812 item = (Class812)array2[i];
				list_0.Add(item);
			}
		}
		if (@class != null)
		{
			class738_0.method_0(@class, list_0);
		}
		Class810 class3 = class827_0.WorkSheetElement.method_57("tableParts", Class827.string_12);
		if (class3 == null)
		{
			return;
		}
		Class810[] array3 = class3.method_56("tablePart", Class827.string_12);
		Class810[] array4 = array3;
		foreach (Class810 class4 in array4)
		{
			string attribute = class4.GetAttribute("id", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
			foreach (object item2 in class827_0.class1090_0)
			{
				Class1089 class5 = (Class1089)item2;
				if (class5.Type == Class825.string_12 && attribute == class5.Id)
				{
					Class1086 class6 = chartDataWorkbook_0.class834_0.sortedList_0[class5.Target];
					Class1097 value = new Class1097(this, (Class825)class6.class822_0);
					class809_0.Add(value);
					break;
				}
			}
		}
	}

	internal void method_1(Class1087 context)
	{
		Class810 @class = class827_0.WorkSheetElement.method_57("sheetData", Class827.string_12);
		if (Cells.Count > 0)
		{
			class827_0.WorkSheetElement.method_54("tableParts", Class827.string_12);
			Class810 class2 = class827_0.WorkSheetElement.method_57("extLst", Class827.string_12);
			Class810 class3 = ((class2 == null) ? class827_0.WorkSheetElement.method_0("tableParts", Class827.string_12) : class2.method_1("tableParts", Class827.string_12));
			if (class3 != null)
			{
				foreach (Class810 item in class3)
				{
					string attribute = item.GetAttribute("id", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
					foreach (object item2 in class827_0.class1090_0)
					{
						Class1089 class5 = (Class1089)item2;
						if (class5.Type == Class825.string_12 && attribute == class5.Id)
						{
							chartDataWorkbook_0.class834_0.sortedList_0.Remove(class5.Target);
							break;
						}
					}
				}
			}
			class3.Prefix = "";
			foreach (Class1097 item3 in class809_0)
			{
				Class810 class7 = class3.method_0("tablePart", Class827.string_12);
				Class1089 class8 = class827_0.Relationships.method_0(Class825.string_12, item3.class825_0.class1086_0.string_0);
				class7.SetAttribute("id", "http://schemas.openxmlformats.org/officeDocument/2006/relationships", class8.Id);
				class7.Prefix = "";
				item3.method_0();
			}
		}
		@class.RemoveAll();
		SortedList sortedList = new SortedList();
		foreach (SortedList value in Cells.sortedList_0.Values)
		{
			foreach (SortedList value2 in value.Values)
			{
				foreach (ChartDataCell value3 in value2.Values)
				{
					if (sortedList[value3.Row + 1] == null)
					{
						sortedList.Add(value3.Row + 1, new SortedList());
					}
					(sortedList[value3.Row + 1] as SortedList).Add(value3.Column, value3);
				}
			}
		}
		foreach (int key in sortedList.Keys)
		{
			Class815 class9 = (Class815)@class.method_0(Class815.string_1, @class.NamespaceURI);
			class9.Prefix = "";
			class9.RowIndex = key;
			if ((sortedList[key] as SortedList).Count > 0 && ((sortedList[key] as SortedList).GetByIndex(0) as ChartDataCell).IsHidden)
			{
				class9.IsHidden = true;
			}
			foreach (ChartDataCell value4 in (sortedList[key] as SortedList).Values)
			{
				value4.method_7(class9);
			}
		}
	}

	internal void method_2()
	{
		class738_0.Clear();
	}
}
