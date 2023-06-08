using System.Collections;
using System.IO;

namespace ns8;

internal class Class1465
{
	private Class1478 class1478_0;

	internal Class1465(Class1478 class1478_1)
	{
		class1478_0 = class1478_1;
	}

	internal void Write(Class1487 class1487_0, string string_0, string string_1, string string_2, string string_3)
	{
		ArrayList arrayList = method_0();
		Class1487 @class = class1478_0.method_12(class1487_0, string_0, string_1, string_2, string_3);
		try
		{
			@class.Write((string)arrayList[0]);
			for (int i = 1; i < arrayList.Count; i++)
			{
				string string_4 = (string)arrayList[i];
				@class.method_8(string_4);
			}
			@class.Flush();
		}
		finally
		{
			if (@class != null && class1487_0 == null)
			{
				for (int j = 0; j < class1478_0.arrayList_2.Count; j++)
				{
					Stream stream = (Stream)class1478_0.arrayList_2[j];
					class1478_0.istreamProvider_0.Close(null, stream);
				}
			}
		}
	}

	private ArrayList method_0()
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add("<xml xmlns:o=\"urn:schemas-microsoft-com:office:office\">");
		arrayList.Add(" <o:MainFile HRef=\"../" + class1478_0.string_2 + "\"/>");
		arrayList.Add(" <o:File HRef=\"editdata.mso\"/>");
		arrayList.Add(" <o:File HRef=\"stylesheet.css\"/>");
		arrayList.Add(" <o:File HRef=\"tabstrip.htm\"/>");
		for (int i = 0; i < class1478_0.arrayList_1.Count; i++)
		{
			string text = "sheet" + Class1486.smethod_1(i + 1, 3) + ".htm";
			arrayList.Add(" <o:File HRef=\"" + text + "\"/>");
		}
		arrayList.Add(" <o:File HRef=\"filelist.xml\"/>");
		arrayList.Add("</xml>");
		return arrayList;
	}
}
