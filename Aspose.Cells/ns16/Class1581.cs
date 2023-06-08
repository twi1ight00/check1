using System.Collections;
using System.Xml;
using Aspose.Cells;
using ns2;
using ns22;

namespace ns16;

internal class Class1581
{
	private Class1718 class1718_0;

	private Class1540 class1540_0;

	internal Class1581(Class1540 class1540_1, Class1718 class1718_1)
	{
		class1540_0 = class1540_1;
		class1718_0 = class1718_1;
	}

	[Attribute0(true)]
	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("externalLink");
		xmlTextWriter_0.WriteAttributeString("xmlns", Class1618.string_0);
		if (class1718_0.Type == Enum194.const_0)
		{
			method_0(xmlTextWriter_0);
		}
		else if (class1718_0.Type == Enum194.const_3)
		{
			method_5(xmlTextWriter_0);
		}
		else
		{
			if (class1718_0.Type != Enum194.const_4)
			{
				throw new CellsException(ExceptionType.InvalidData, "Invalid SupBook Type " + class1718_0.Type);
			}
			method_7(xmlTextWriter_0);
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	[Attribute0(true)]
	private void method_0(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("externalBook");
		xmlTextWriter_0.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		xmlTextWriter_0.WriteAttributeString("r:id", "rId1");
		method_3(xmlTextWriter_0);
		method_4(xmlTextWriter_0);
		method_1(xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_1(XmlTextWriter xmlTextWriter_0)
	{
		string[] array = class1718_0.method_4();
		if (array == null || array.Length == 0)
		{
			return;
		}
		int num = array.Length;
		bool flag = false;
		for (int i = 0; i < num; i++)
		{
			Class1373 @class = class1718_0.method_11(array[i]);
			if (@class != null)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("sheetDataSet");
		for (int j = 0; j < num; j++)
		{
			Class1373 class2 = class1718_0.method_11(array[j]);
			if (class2 == null)
			{
				continue;
			}
			xmlTextWriter_0.WriteStartElement("sheetData");
			xmlTextWriter_0.WriteAttributeString("sheetId", Class1618.smethod_80(j));
			if (class2.class1363_0 != null)
			{
				object obj = class2.class1363_0.method_0(Enum129.const_2);
				if (obj != null)
				{
					xmlTextWriter_0.WriteAttributeString("refreshError", (string)obj);
				}
			}
			if (class2.method_1())
			{
				ArrayList arrayList_ = class2.arrayList_0;
				int count = arrayList_.Count;
				for (int k = 0; k < count; k++)
				{
					Class1117 class3 = (Class1117)arrayList_[k];
					xmlTextWriter_0.WriteStartElement("row");
					xmlTextWriter_0.WriteAttributeString("r", Class1618.smethod_80(class3.Index + 1));
					if (class3.method_3())
					{
						ArrayList arrayList = class3.method_7();
						int count2 = arrayList.Count;
						for (int l = 0; l < count2; l++)
						{
							Class1116 class4 = (Class1116)arrayList[l];
							xmlTextWriter_0.WriteStartElement("cell");
							xmlTextWriter_0.WriteAttributeString("r", CellsHelper.CellIndexToName(class3.Index, class4.int_0));
							string t = null;
							string v = null;
							method_2(class4, out t, out v);
							if (t != "n")
							{
								xmlTextWriter_0.WriteAttributeString("t", t);
							}
							xmlTextWriter_0.WriteElementString("v", v);
							xmlTextWriter_0.WriteEndElement();
						}
					}
					xmlTextWriter_0.WriteEndElement();
				}
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_2(Class1116 cell, out string t, out string v)
	{
		object object_ = cell.object_0;
		switch (cell.Type)
		{
		case CellValueType.IsBool:
			t = "b";
			v = (((bool)object_) ? "1" : "0");
			break;
		case CellValueType.IsError:
			t = "e";
			v = Class1673.smethod_4((ErrorType)object_);
			break;
		default:
			t = "str";
			v = object_.ToString();
			break;
		case CellValueType.IsDateTime:
		case CellValueType.IsNumeric:
			t = "n";
			v = Class1618.smethod_79((double)object_);
			break;
		case CellValueType.IsString:
			t = "str";
			v = (string)object_;
			break;
		}
	}

	[Attribute0(true)]
	private void method_3(XmlTextWriter xmlTextWriter_0)
	{
		string[] array = class1718_0.method_4();
		if (array != null && array.Length != 0)
		{
			xmlTextWriter_0.WriteStartElement("sheetNames");
			foreach (string value in array)
			{
				xmlTextWriter_0.WriteStartElement("sheetName");
				xmlTextWriter_0.WriteAttributeString("val", value);
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_4(XmlTextWriter xmlTextWriter_0)
	{
		ArrayList arrayList = class1718_0.method_0();
		if (arrayList.Count == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("definedNames");
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1653 @class = (Class1653)arrayList[i];
			xmlTextWriter_0.WriteStartElement("definedName");
			xmlTextWriter_0.WriteAttributeString("name", @class.Name);
			if (@class.SheetIndex < 65535 && @class.SheetIndex > 0)
			{
				xmlTextWriter_0.WriteAttributeString("sheetId", Class1618.smethod_80(@class.SheetIndex - 1));
			}
			string text = @class.method_7(class1540_0.workbook_0.Worksheets);
			if (text != null && text != "")
			{
				xmlTextWriter_0.WriteAttributeString("refersTo", text);
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_5(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("ddeLink");
		class1718_0.method_20(out var progId, out var fileName);
		xmlTextWriter_0.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		xmlTextWriter_0.WriteAttributeString("ddeService", progId);
		xmlTextWriter_0.WriteAttributeString("ddeTopic", fileName);
		method_6(xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_6(XmlTextWriter xmlTextWriter_0)
	{
		ArrayList arrayList = class1718_0.method_0();
		if (arrayList.Count == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("ddeItems");
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1653 @class = (Class1653)arrayList[i];
			xmlTextWriter_0.WriteStartElement("ddeItem");
			xmlTextWriter_0.WriteAttributeString("name", @class.Name);
			if (@class.method_15())
			{
				xmlTextWriter_0.WriteAttributeString("ole", "1");
			}
			if (@class.method_17())
			{
				xmlTextWriter_0.WriteAttributeString("advise", "1");
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_7(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("oleLink");
		class1718_0.method_20(out var progId, out var _);
		xmlTextWriter_0.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		xmlTextWriter_0.WriteAttributeString("r:id", "rId1");
		xmlTextWriter_0.WriteAttributeString("progId", progId);
		method_8(xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_8(XmlTextWriter xmlTextWriter_0)
	{
		ArrayList arrayList = class1718_0.method_0();
		if (arrayList.Count == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("oleItems");
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1653 @class = (Class1653)arrayList[i];
			xmlTextWriter_0.WriteStartElement("oleItem");
			xmlTextWriter_0.WriteAttributeString("name", @class.Name);
			if (@class.method_17())
			{
				xmlTextWriter_0.WriteAttributeString("advise", "1");
			}
			if (@class.method_19())
			{
				xmlTextWriter_0.WriteAttributeString("preferPic", "1");
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}
}
