using System.Xml;
using Aspose.Cells;

namespace ns16;

internal class Class447
{
	private Class1547 class1547_0;

	private Workbook workbook_0;

	private string string_0;

	private XmlDocument xmlDocument_0;

	internal Class447(Class1547 class1547_1, string string_1)
	{
		class1547_0 = class1547_1;
		workbook_0 = class1547_1.workbook_0;
		string_0 = string_1;
	}

	internal void Read(XmlDocument xmlDocument_1)
	{
		xmlDocument_0 = xmlDocument_1;
		method_0();
	}

	private void method_0()
	{
		XmlElement documentElement = xmlDocument_0.DocumentElement;
		if (documentElement == null)
		{
			return;
		}
		Class442 @class = new Class442();
		@class.string_0 = documentElement.NamespaceURI;
		foreach (object childNode in documentElement.ChildNodes)
		{
			if (childNode is XmlElement)
			{
				XmlElement xmlElement = (XmlElement)childNode;
				string outerXml = xmlElement.OuterXml;
				@class.arrayList_0.Add(outerXml);
			}
		}
		workbook_0.class442_0 = @class;
	}
}
