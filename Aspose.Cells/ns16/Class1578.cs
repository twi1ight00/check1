using System;
using System.Globalization;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Properties;
using ns22;

namespace ns16;

internal class Class1578
{
	private Workbook workbook_0;

	private Class1540 class1540_0;

	internal Class1578(Class1540 class1540_1)
	{
		workbook_0 = class1540_1.workbook_0;
		class1540_0 = class1540_1;
	}

	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("Properties");
		xmlTextWriter_0.WriteAttributeString("xmlns", null, "http://schemas.openxmlformats.org/officeDocument/2006/custom-properties");
		xmlTextWriter_0.WriteAttributeString("xmlns", "vt", null, "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
		CustomDocumentPropertyCollection customDocumentProperties = workbook_0.Worksheets.CustomDocumentProperties;
		int num = 2;
		for (int i = 0; i < customDocumentProperties.Count; i++)
		{
			DocumentProperty documentProperty = customDocumentProperties[i];
			if (documentProperty.Type != PropertyType.Blob && !(documentProperty.Name.ToUpper() == "_PID_LINKBASE") && !documentProperty.IsLink)
			{
				method_0(xmlTextWriter_0, documentProperty, num++);
			}
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	[Attribute0(true)]
	private void method_0(XmlTextWriter xmlTextWriter_0, DocumentProperty documentProperty_0, int int_0)
	{
		xmlTextWriter_0.WriteStartElement("property");
		xmlTextWriter_0.WriteAttributeString("fmtid", "{D5CDD505-2E9C-101B-9397-08002B2CF9AE}");
		xmlTextWriter_0.WriteAttributeString("pid", Class1618.smethod_80(int_0));
		xmlTextWriter_0.WriteAttributeString("name", documentProperty_0.Name);
		if (documentProperty_0.IsLinkedToContent)
		{
			xmlTextWriter_0.WriteAttributeString("linkTarget", documentProperty_0.Source);
		}
		string text = "lpwstr";
		string string_ = null;
		switch (documentProperty_0.Type)
		{
		case PropertyType.Boolean:
			text = "bool";
			string_ = (documentProperty_0.ToBool() ? "true" : "false");
			break;
		case PropertyType.DateTime:
			text = "filetime";
			string_ = ((DateTime)documentProperty_0.Value).ToString("yyyy-MM-dd\\THH:mm:ss\\Z", CultureInfo.InvariantCulture);
			break;
		case PropertyType.Double:
			text = "r8";
			string_ = documentProperty_0.ToString();
			break;
		case PropertyType.Number:
		{
			long num = documentProperty_0.method_2();
			if (num < int.MaxValue)
			{
				text = "i4";
			}
			string_ = documentProperty_0.ToString();
			break;
		}
		case PropertyType.String:
			string_ = documentProperty_0.ToString();
			break;
		}
		xmlTextWriter_0.WriteStartElement("vt:" + text);
		xmlTextWriter_0.WriteString(Class1618.smethod_4(string_));
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}
}
