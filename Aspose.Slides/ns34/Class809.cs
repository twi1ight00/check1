using System;
using System.Collections;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns21;
using ns42;
using ns43;
using ns56;

namespace ns34;

internal sealed class Class809 : ICollection, IEnumerable, IEnumerable<Class1097>
{
	private List<Class1097> list_0;

	private ChartDataWorksheet chartDataWorksheet_0;

	private string string_0 = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><table xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\" totalsRowShown=\"0\"><tableColumns/><tableStyleInfo showFirstColumn=\"0\" showLastColumn=\"0\" showRowStripes=\"1\" showColumnStripes=\"0\" /></table>";

	public int Count => list_0.Count;

	public Class1097 this[int index] => list_0[index];

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal Class809(ChartDataWorksheet parent)
	{
		list_0 = new List<Class1097>();
		chartDataWorksheet_0 = parent;
	}

	internal void Add(Class1097 value)
	{
		list_0.Add(value);
	}

	public Class1097 Add()
	{
		Class1097 class3;
		if (Class257.bool_0)
		{
			uint num = method_0();
			Class1086 @class = new Class1086("/xl/tables/table" + num + ".xml");
			Class834 class834_ = chartDataWorksheet_0.ParentWorkbook.class834_0;
			@class.class822_0 = new Class825(class834_);
			@class.class822_0.class1086_0 = @class;
			@class.class822_0.class1090_0 = new Class1090();
			class834_.sortedList_0.Add(@class.string_0, @class);
			@class.string_1 = "application/vnd.openxmlformats-officedocument.spreadsheetml.table+xml";
			Class825 class2 = (Class825)@class.class822_0;
			class2.InnerXml = string_0;
			class2.TableElement.DisplayName = "Table" + num;
			class2.TableElement.TableName = "Table" + num;
			class2.TableElement.Id = num;
			class3 = new Class1097(chartDataWorksheet_0, class2);
		}
		else
		{
			class3 = new Class1097(chartDataWorksheet_0);
			uint num2 = (uint)list_0.Count;
			bool flag = true;
			while (flag)
			{
				num2++;
				flag = false;
				foreach (Class1097 item in list_0)
				{
					if (item.TablePartXLSXUnsupportedProps.DisplayName == "Table" + num2 || item.TablePartXLSXUnsupportedProps.Name == "Table" + num2 || item.TablePartXLSXUnsupportedProps.Id == num2)
					{
						flag = true;
						break;
					}
				}
			}
			class3.TablePartXLSXUnsupportedProps.DisplayName = "Table" + num2;
			class3.TablePartXLSXUnsupportedProps.Name = "Table" + num2;
			class3.TablePartXLSXUnsupportedProps.Id = num2;
			class3.TablePartXLSXUnsupportedProps.TableColumns = new Class1712();
			class3.TablePartXLSXUnsupportedProps.TableStyleInfo = new Class1720();
			class3.TablePartXLSXUnsupportedProps.TableStyleInfo.ShowFirstColumn = NullableBool.False;
			class3.TablePartXLSXUnsupportedProps.TableStyleInfo.ShowLastColumn = NullableBool.False;
			class3.TablePartXLSXUnsupportedProps.TableStyleInfo.ShowRowStripes = NullableBool.True;
			class3.TablePartXLSXUnsupportedProps.TableStyleInfo.ShowColumnStripes = NullableBool.False;
		}
		list_0.Add(class3);
		return class3;
	}

	public void Clear()
	{
		if (Class257.bool_0)
		{
			foreach (Class1097 item in list_0)
			{
				chartDataWorksheet_0.ParentWorkbook.class834_0.sortedList_0.Remove(item.class825_0.class1086_0.string_0);
			}
		}
		list_0.Clear();
	}

	IEnumerator<Class1097> IEnumerable<Class1097>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}

	internal uint method_0()
	{
		uint num = 1u;
		while (true)
		{
			string key = "/xl/tables/table" + num + ".xml";
			if (!chartDataWorksheet_0.ParentWorkbook.class834_0.sortedList_0.ContainsKey(key))
			{
				break;
			}
			num++;
		}
		return num;
	}
}
