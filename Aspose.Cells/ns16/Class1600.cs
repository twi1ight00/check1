using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Aspose.Cells;
using ns1;
using ns22;

namespace ns16;

internal class Class1600
{
	private Class1547 class1547_0;

	private ArrayList arrayList_0;

	internal Class1600(Class1547 class1547_1)
	{
		class1547_0 = class1547_1;
		arrayList_0 = class1547_0.workbook_0.class1558_0.arrayList_0;
	}

	internal static FileFormatType DetectFileFormat(Class746 class746_0)
	{
		string string_ = "[Content_Types].xml";
		XmlTextReader xmlTextReader = Class1615.smethod_1(class746_0, string_);
		smethod_0(xmlTextReader);
		if (xmlTextReader.IsEmptyElement)
		{
			return FileFormatType.Xlsx;
		}
		xmlTextReader.Read();
		while (xmlTextReader.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader.MoveToContent();
			if (xmlTextReader.NodeType != XmlNodeType.Element)
			{
				xmlTextReader.Skip();
				continue;
			}
			if (xmlTextReader.LocalName == "Override")
			{
				string attribute = xmlTextReader.GetAttribute("PartName");
				string attribute2 = xmlTextReader.GetAttribute("ContentType");
				if (attribute.ToLower().Equals("/xl/workbook.xml"))
				{
					switch (attribute2)
					{
					case "application/vnd.ms-excel.template.macroEnabled.main+xml":
						return FileFormatType.Xltm;
					case "application/vnd.ms-excel.sheet.macroEnabled.main+xml":
						return FileFormatType.Xlsm;
					case "application/vnd.openxmlformats-officedocument.spreadsheetml.template.main+xml":
						return FileFormatType.Xltx;
					case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml":
						return FileFormatType.Xlsx;
					}
				}
			}
			xmlTextReader.Skip();
		}
		xmlTextReader.ReadEndElement();
		xmlTextReader.Close();
		return FileFormatType.Xlsx;
	}

	[Attribute0(true)]
	internal void Read(XmlTextReader xmlTextReader_0)
	{
		smethod_0(xmlTextReader_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
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
			else if (xmlTextReader_0.LocalName == "Override")
			{
				string attribute = xmlTextReader_0.GetAttribute("PartName");
				string attribute2 = xmlTextReader_0.GetAttribute("ContentType");
				xmlTextReader_0.Skip();
				method_0(attribute, attribute2);
			}
			else if (xmlTextReader_0.LocalName == "Default")
			{
				string string_ = xmlTextReader_0.GetAttribute("Extension").ToLower();
				string attribute3 = xmlTextReader_0.GetAttribute("ContentType");
				xmlTextReader_0.Skip();
				if (attribute3 != "application/xml" && attribute3 != "application/vnd.openxmlformats-package.relationships+xml")
				{
					method_1(bool_0: true, null, attribute3, string_);
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	private void method_0(string string_0, string string_1)
	{
		if (string_0 != null && string_1 != null && string_0.Length != 0 && string_1.Length != 0)
		{
			if (method_2(string_1))
			{
				method_1(bool_0: false, string_0, string_1, null);
			}
			switch (string_1.ToLower())
			{
			case "application/vnd.ms-excel.template.macroEnabled.main+xml":
				if (class1547_0.string_0 == null && !string_0.EndsWith("workbook.xml"))
				{
					class1547_0.string_0 = string_0;
					if (string_0[0] == '/')
					{
						class1547_0.string_0 = string_0.Substring(1);
					}
				}
				break;
			case "application/vnd.ms-excel.sheet.macroEnabled.main+xml":
				if (class1547_0.string_0 == null && !string_0.EndsWith("workbook.xml"))
				{
					class1547_0.string_0 = string_0;
					if (string_0[0] == '/')
					{
						class1547_0.string_0 = string_0.Substring(1);
					}
				}
				break;
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.template.main+xml":
				if (class1547_0.string_0 == null && !string_0.EndsWith("workbook.xml"))
				{
					class1547_0.string_0 = string_0;
					if (string_0[0] == '/')
					{
						class1547_0.string_0 = string_0.Substring(1);
					}
				}
				break;
			case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml":
				if (class1547_0.string_0 == null && !string_0.EndsWith("workbook.xml"))
				{
					class1547_0.string_0 = string_0;
					if (string_0[0] == '/')
					{
						class1547_0.string_0 = string_0.Substring(1);
					}
				}
				break;
			}
			if (string_0.ToLower().Equals("/xl/workbook.xml"))
			{
				if (string_1.ToLower().Equals("application/vnd.ms-excel.sheet.macroEnabled.main+xml".ToLower()) || string_1.ToLower().Equals("application/vnd.ms-excel.template.macroEnabled.main+xml".ToLower()))
				{
					class1547_0.workbook_0.class1558_0.bool_0 = true;
					class1547_0.workbook_0.fileFormatType_0 = FileFormatType.Xlsm;
				}
			}
			else if (string_1.ToLower().Equals("application/vnd.ms-office.vbaproject"))
			{
				string text = string_0.Trim();
				if (text[0] == '/')
				{
					text = text.Substring(1);
				}
				class1547_0.workbook_0.class1558_0.string_0 = text;
			}
			if (string_1.ToLower().Equals("application/vnd.openxmlformats-package.digital-signature-xmlsignature+xml"))
			{
				class1547_0.workbook_0.class1558_0.bool_3 = true;
			}
			return;
		}
		throw new CellsException(ExceptionType.InvalidData, "Override element eror");
	}

	private void method_1(bool bool_0, string string_0, string string_1, string string_2)
	{
		Class1530 @class = new Class1530();
		@class.bool_0 = bool_0;
		@class.string_1 = string_0;
		@class.string_0 = string_2;
		@class.string_2 = string_1;
		arrayList_0.Add(@class);
	}

	private bool method_2(string string_0)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_128 == null)
			{
				Class1742.dictionary_128 = new Dictionary<string, int>(26)
				{
					{ "application/vnd.ms-office.activeX+xml", 0 },
					{ "application/vnd.ms-office.activeX", 1 },
					{ "application/vnd.ms-excel.connections", 2 },
					{ "application/vnd.openxmlformats-officedocument.spreadsheetml.queryTable+xml", 3 },
					{ "application/vnd.ms-excel.queryTable", 4 },
					{ "application/vnd.ms-office.vbaProjectSignature", 5 },
					{ "application/vnd.openxmlformats-officedocument.drawingml.diagramColors+xml", 6 },
					{ "application/vnd.openxmlformats-officedocument.drawingml.diagramData+xml", 7 },
					{ "application/vnd.openxmlformats-officedocument.drawingml.diagramLayout+xml", 8 },
					{ "application/vnd.openxmlformats-officedocument.drawingml.diagramStyle+xml", 9 },
					{ "application/vnd.openxmlformats-officedocument.spreadsheetml.revisionLog+xml", 10 },
					{ "application/vnd.ms-excel.revisionLog", 11 },
					{ "application/vnd.openxmlformats-officedocument.spreadsheetml.userNames+xml", 12 },
					{ "application/vnd.ms-excel.userNames", 13 },
					{ "application/vnd.openxmlformats-officedocument.spreadsheetml.revisionHeaders+xml", 14 },
					{ "application/vnd.ms-excel.revisionHeaders", 15 },
					{ "application/vnd.openxmlformats-officedocument.spreadsheetml.slicerCache+xml", 16 },
					{ "application/vnd.openxmlformats-officedocument.spreadsheetml.slicer+xml", 17 },
					{ "application/vnd.ms-excel.slicer+xml", 18 },
					{ "application/vnd.ms-excel.slicerCache+xml", 19 },
					{ "application/vnd.ms-excel.controlproperties+xml", 20 },
					{ "application/vnd.openxmlformats-package.digital-signature-origin", 21 },
					{ "application/vnd.openxmlformats-package.digital-signature-xmlsignature+xml", 22 },
					{ "application/vnd.ms-excel.attachedToolbars", 23 },
					{ "application/inkml+xml", 24 },
					{ "application/vnd.ms-excel.customDataProperties+xml", 25 }
				};
			}
			if (Class1742.dictionary_128.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
				case 12:
				case 13:
				case 14:
				case 15:
				case 16:
				case 17:
				case 18:
				case 19:
				case 20:
				case 21:
				case 22:
				case 23:
				case 24:
				case 25:
					return true;
				}
			}
		}
		return false;
	}

	private static void smethod_0(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		xmlTextReader_0.MoveToContent();
		if (xmlTextReader_0.NodeType != XmlNodeType.Element || xmlTextReader_0.LocalName != "Types")
		{
			throw new CellsException(ExceptionType.InvalidData, "ContentTypes root element eror");
		}
	}
}
