using System.Xml;
using Aspose.Cells;

namespace ns16;

internal class Class449
{
	private Class1548 class1548_0;

	private Worksheet worksheet_0;

	private string string_0;

	private XmlDocument xmlDocument_0;

	internal Class449(Class1548 class1548_1, string string_1)
	{
		class1548_0 = class1548_1;
		worksheet_0 = class1548_1.worksheet_0;
		string_0 = string_1;
	}

	internal void Read(XmlDocument xmlDocument_1)
	{
		xmlDocument_0 = xmlDocument_1;
		method_0();
	}

	private void method_0()
	{
		QueryTable queryTable = new QueryTable();
		queryTable.string_0 = string_0;
		worksheet_0.QueryTables.Add(queryTable);
		XmlNodeList elementsByTagName = xmlDocument_0.GetElementsByTagName("queryTable");
		if (elementsByTagName != null && elementsByTagName.Count == 1)
		{
			XmlElement xmlNode_ = (XmlElement)elementsByTagName[0];
			string text = Class1618.smethod_172(xmlNode_, "preserveFormatting");
			if (text == "0")
			{
				queryTable.bool_1 = false;
			}
			string text2 = Class1618.smethod_172(xmlNode_, "adjustColumnWidth");
			if (text2 == "0")
			{
				queryTable.bool_0 = false;
			}
		}
	}
}
