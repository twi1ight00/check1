using System.Xml;
using Aspose.Cells;

namespace ns16;

internal class Class444
{
	private Class1540 class1540_0;

	private Workbook workbook_0;

	private string string_0 = "http://schemas.openxmlformats.org/drawingml/2006/main";

	internal Class444(Class1540 class1540_1)
	{
		class1540_0 = class1540_1;
		workbook_0 = class1540_1.workbook_0;
	}

	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		Class442 class442_ = workbook_0.class442_0;
		if (class442_ == null)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("connections");
		if (class442_.string_0.Length > 0)
		{
			xmlTextWriter_0.WriteAttributeString("xmlns", class442_.string_0);
		}
		foreach (string item in class442_.arrayList_0)
		{
			xmlTextWriter_0.WriteRaw(item);
		}
		xmlTextWriter_0.WriteEndElement();
	}
}
