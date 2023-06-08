using System;
using System.Xml;
using Aspose.Cells;

namespace ns16;

internal class Class450
{
	private Class1547 class1547_0;

	private string string_0;

	internal Class450(Class1547 class1547_1)
	{
		class1547_0 = class1547_1;
	}

	internal void Read(XmlTextReader xmlTextReader_0)
	{
		method_2(xmlTextReader_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
			return;
		}
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName)
				{
				case "SelectionNamespaces":
					class1547_0.workbook_0.Worksheets.XmlMaps.string_0 = xmlTextReader_0.Value;
					break;
				case "xmlns":
					class1547_0.workbook_0.Worksheets.XmlMaps.string_1 = xmlTextReader_0.Value;
					break;
				}
			}
		}
		xmlTextReader_0.Read();
		try
		{
			while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
			{
				xmlTextReader_0.MoveToContent();
				if (xmlTextReader_0.NodeType != XmlNodeType.Element)
				{
					xmlTextReader_0.Skip();
				}
				else if (xmlTextReader_0.LocalName == "Schema" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
				{
					class1547_0.workbook_0.Worksheets.XmlMaps.arrayList_0.Add(xmlTextReader_0.ReadOuterXml());
				}
				else if (xmlTextReader_0.LocalName == "Map")
				{
					method_0(xmlTextReader_0);
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
		}
		catch
		{
		}
	}

	internal void method_0(XmlTextReader xmlTextReader_0)
	{
		XmlMap xmlMap = new XmlMap();
		class1547_0.workbook_0.Worksheets.XmlMaps.Add(xmlMap);
		if (!xmlTextReader_0.HasAttributes)
		{
			return;
		}
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (xmlTextReader_0.LocalName == "ID")
			{
				xmlMap.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "Name")
			{
				xmlMap.Name = xmlTextReader_0.Value;
			}
			else if (xmlTextReader_0.LocalName == "RootElement")
			{
				xmlMap.string_1 = xmlTextReader_0.Value;
			}
			else if (xmlTextReader_0.LocalName == "SchemaID")
			{
				xmlMap.string_2 = xmlTextReader_0.Value;
			}
			else if (xmlTextReader_0.LocalName == "ShowImportExportValidationErrors")
			{
				xmlMap.bool_4 = Class1618.smethod_201(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "AutoFit")
			{
				xmlMap.bool_1 = Class1618.smethod_201(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "Append")
			{
				xmlMap.bool_0 = Class1618.smethod_201(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "PreserveSortAFLayout")
			{
				xmlMap.bool_3 = Class1618.smethod_201(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "PreserveFormat")
			{
				xmlMap.bool_2 = Class1618.smethod_201(xmlTextReader_0.Value);
			}
		}
		xmlTextReader_0.MoveToElement();
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "DataBinding")
			{
				method_1(xmlTextReader_0, xmlMap.xmlDataBinding_0 = new XmlDataBinding());
				xmlTextReader_0.Skip();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_1(XmlTextReader xmlTextReader_0, XmlDataBinding xmlDataBinding_0)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			return;
		}
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (xmlTextReader_0.LocalName == "FileBinding")
			{
				xmlDataBinding_0.bool_0 = Class1618.smethod_201(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "FileBindingName")
			{
				xmlDataBinding_0.string_1 = xmlTextReader_0.Value;
			}
			else if (xmlTextReader_0.LocalName == "ConnectionID")
			{
				xmlDataBinding_0.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "DataBindingLoadMode")
			{
				xmlDataBinding_0.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "DataBindingName")
			{
				xmlDataBinding_0.DataBindingName = xmlTextReader_0.Value;
			}
			else
			{
				xmlDataBinding_0.enum22_0 = Class1618.smethod_243(xmlTextReader_0.Value);
			}
		}
		xmlTextReader_0.MoveToElement();
	}

	private void method_2(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		xmlTextReader_0.MoveToContent();
		string namespaceURI = xmlTextReader_0.NamespaceURI;
		if (!Class1618.smethod_0(namespaceURI))
		{
			throw new CellsException(ExceptionType.InvalidData, "Error xml namespace " + namespaceURI);
		}
		if (xmlTextReader_0.NodeType != XmlNodeType.Element || xmlTextReader_0.LocalName != "MapInfo")
		{
			throw new ApplicationException("Xml map root element eror");
		}
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		string_0 = nameTable.Add(namespaceURI);
	}
}
