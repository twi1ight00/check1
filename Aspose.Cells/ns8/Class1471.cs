using System.IO;
using Aspose.Cells;

namespace ns8;

internal class Class1471
{
	private Class1478 class1478_0;

	internal Class1471(Class1478 class1478_1)
	{
		class1478_0 = class1478_1;
	}

	internal void Write(Class1487 class1487_0, string string_0, string string_1, string string_2, string string_3)
	{
		Class1487 @class = class1478_0.method_9(class1487_0, string_0, string_1, string_2, string_3);
		try
		{
			@class.Write("<html>");
			@class.method_8("<head>");
			@class.method_8("<meta http-equiv=Content-Type content=\"text/html; charset=gb2312\">");
			@class.method_8("<meta name=ProgId content=Excel.Sheet>");
			@class.method_8("<meta name=Generator content=\"Microsoft Excel 11\">");
			@class.method_8("<link id=Main-File rel=Main-File href=\"../" + class1478_0.string_2 + "\">");
			@class.method_8("");
			@class.method_8("<script language=\"JavaScript\">");
			@class.method_8("<!--");
			@class.method_8("if (window.name!=\"frTabs\")");
			@class.method_8(" window.location.replace(document.all.item(\"Main-File\").href);");
			@class.method_8("//-->");
			@class.method_8("</script>");
			@class.method_8("<style>");
			@class.method_8("<!--");
			@class.method_8("A {");
			@class.method_8("    text-decoration:none;");
			@class.method_8("    color:#000000;");
			@class.method_8("    font-size:9pt;");
			@class.method_8("}");
			@class.method_8("-->");
			@class.method_8("</style>");
			@class.method_8("</head>");
			@class.method_8("<body topmargin=0 leftmargin=0 bgcolor=\"#808080\">");
			@class.method_8("<table border=0 cellspacing=1>");
			@class.method_8(" <tr>");
			for (int i = 0; i < class1478_0.arrayList_1.Count; i++)
			{
				Worksheet worksheet = (Worksheet)class1478_0.arrayList_1[i];
				if (worksheet.IsVisible)
				{
					@class.method_8(" <td bgcolor=\"#FFFFFF\" nowrap><b><small><small>&nbsp;<a href=\"sheet" + Class1486.smethod_1(i + 1, 3) + ".htm\" target=\"frSheet\"><font face=\"Arial\" color=\"#000000\">" + worksheet.Name + "</font></a>&nbsp;</small></small></b></td>");
				}
			}
			@class.method_9();
			@class.method_8(" </tr>");
			@class.method_8("</table>");
			@class.method_8("</body>");
			@class.method_8("</html>");
			@class.method_9();
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
}
