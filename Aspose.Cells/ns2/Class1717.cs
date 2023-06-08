using System.Collections;
using Aspose.Cells;

namespace ns2;

internal class Class1717
{
	internal static Hashtable Sort(WorksheetCollection worksheetCollection_0)
	{
		SortedList sortedList = new SortedList();
		Hashtable hashtable = new Hashtable();
		NameCollection names = worksheetCollection_0.Names;
		for (int i = 0; i < names.Count; i++)
		{
			Name name = names[i];
			string key;
			if (name.SheetIndex == 0)
			{
				key = name.Text + "~";
			}
			else
			{
				string text = worksheetCollection_0[name.SheetIndex - 1].Name.ToUpper();
				key = name.Text + "!" + text;
			}
			Class1137 @class = new Class1137(name);
			@class.int_0 = i;
			sortedList[key] = @class;
		}
		names.method_6();
		for (int j = 0; j < sortedList.Count; j++)
		{
			Class1137 class2 = (Class1137)sortedList.GetByIndex(j);
			names.method_3(class2.name_0, bool_0: false);
			hashtable[class2.int_0] = j;
		}
		return hashtable;
	}
}
