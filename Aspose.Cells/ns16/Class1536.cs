using System.Collections;
using Aspose.Cells;

namespace ns16;

internal class Class1536
{
	internal ArrayList arrayList_0;

	internal Hashtable hashtable_0;

	internal Class1536()
	{
		arrayList_0 = new ArrayList();
		hashtable_0 = new Hashtable();
	}

	internal static Class1536 smethod_0(Workbook workbook_0)
	{
		Class1536 @class = new Class1536();
		ArrayList arrayList = workbook_0.Worksheets.method_52();
		foreach (Font item in arrayList)
		{
			bool flag = false;
			for (int i = 0; i < @class.arrayList_0.Count; i++)
			{
				Font font2 = (Font)@class.arrayList_0[i];
				if (item.method_18(font2) && item.method_23() == font2.method_23())
				{
					flag = true;
					if (!@class.hashtable_0.Contains(item.method_21()))
					{
						@class.hashtable_0.Add(item.method_21(), i);
					}
					break;
				}
			}
			if (!flag)
			{
				int num = @class.arrayList_0.Add(item);
				if (!@class.hashtable_0.Contains(item.method_21()))
				{
					@class.hashtable_0.Add(item.method_21(), num);
				}
			}
		}
		return @class;
	}
}
