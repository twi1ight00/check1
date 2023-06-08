using System.Xml;
using Aspose.Cells;
using ns22;

namespace ns16;

internal class Class446
{
	private Workbook workbook_0;

	private Class1540 class1540_0;

	internal Class446(Class1540 class1540_1)
	{
		workbook_0 = class1540_1.workbook_0;
		class1540_0 = class1540_1;
	}

	internal Class446(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
	}

	[Attribute0(true)]
	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("MapInfo ");
		XmlMapCollection xmlMaps = workbook_0.Worksheets.XmlMaps;
		if (xmlMaps.string_1 != null && xmlMaps.string_1.Length > 0)
		{
			xmlTextWriter_0.WriteAttributeString("xmlns", null, xmlMaps.string_1);
		}
		if (xmlMaps.string_0 != null)
		{
			xmlTextWriter_0.WriteAttributeString("SelectionNamespaces", null, xmlMaps.string_0);
		}
		for (int i = 0; i < xmlMaps.arrayList_0.Count; i++)
		{
			string data = (string)xmlMaps.arrayList_0[i];
			xmlTextWriter_0.WriteRaw(data);
		}
		for (int j = 0; j < xmlMaps.Count; j++)
		{
			XmlMap xmlMap_ = xmlMaps[j];
			method_0(xmlTextWriter_0, xmlMap_);
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	[Attribute0(true)]
	private void method_0(XmlTextWriter xmlTextWriter_0, XmlMap xmlMap_0)
	{
		XmlDataBinding xmlDataBinding_ = xmlMap_0.xmlDataBinding_0;
		xmlTextWriter_0.WriteStartElement("Map");
		xmlTextWriter_0.WriteAttributeString("ID", Class1618.smethod_80(xmlMap_0.int_0));
		xmlTextWriter_0.WriteAttributeString("Name", xmlMap_0.string_0);
		xmlTextWriter_0.WriteAttributeString("RootElement", xmlMap_0.string_1);
		xmlTextWriter_0.WriteAttributeString("SchemaID", xmlMap_0.string_2);
		xmlTextWriter_0.WriteAttributeString("ShowImportExportValidationErrors", xmlMap_0.bool_4 ? "true" : "false");
		xmlTextWriter_0.WriteAttributeString("AutoFit", xmlMap_0.bool_1 ? "true" : "false");
		xmlTextWriter_0.WriteAttributeString("Append", xmlMap_0.bool_0 ? "true" : "false");
		xmlTextWriter_0.WriteAttributeString("PreserveSortAFLayout", xmlMap_0.bool_3 ? "true" : "false");
		xmlTextWriter_0.WriteAttributeString("PreserveFormat", xmlMap_0.bool_2 ? "true" : "false");
		if (xmlDataBinding_ != null)
		{
			xmlTextWriter_0.WriteStartElement("DataBinding");
			xmlTextWriter_0.WriteAttributeString("FileBinding", xmlDataBinding_.bool_0 ? "1" : "0");
			xmlTextWriter_0.WriteAttributeString("ConnectionID", Class1618.smethod_80(xmlDataBinding_.int_0));
			xmlTextWriter_0.WriteAttributeString("DataBindingLoadMode", Class1618.smethod_242(xmlDataBinding_.enum22_0));
			if (xmlDataBinding_.string_1 != null && xmlDataBinding_.string_1.Length > 0)
			{
				xmlTextWriter_0.WriteAttributeString("FileBindingName", xmlDataBinding_.string_1);
			}
			if (xmlDataBinding_.string_0 != null && xmlDataBinding_.string_0.Length > 0)
			{
				xmlTextWriter_0.WriteAttributeString("DataBindingName", xmlDataBinding_.string_0);
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}
}
