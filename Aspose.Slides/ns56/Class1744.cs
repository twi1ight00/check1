using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1744 : Class1351
{
	public delegate Class1744 Delegate1111();

	public delegate void Delegate1112(Class1744 elementData);

	public delegate void Delegate1113(Class1744 elementData);

	public Class1521.Delegate442 delegate442_0;

	public Class1521.Delegate444 delegate444_0;

	public Class1520.Delegate439 delegate439_0;

	public Class1520.Delegate441 delegate441_0;

	public Class1745.Delegate1114 delegate1114_0;

	public Class1745.Delegate1116 delegate1116_0;

	public Class1746.Delegate1117 delegate1117_0;

	public Class1746.Delegate1119 delegate1119_0;

	public Class1374.Delegate84 delegate84_0;

	public Class1374.Delegate86 delegate86_0;

	public Class1535.Delegate484 delegate484_0;

	public Class1535.Delegate486 delegate486_0;

	public Class1509.Delegate406 delegate406_0;

	public Class1509.Delegate408 delegate408_0;

	public Class1492.Delegate353 delegate353_0;

	public Class1492.Delegate355 delegate355_0;

	public Class1388.Delegate126 delegate126_0;

	public Class1388.Delegate128 delegate128_0;

	public Class1601.Delegate682 delegate682_0;

	public Class1601.Delegate684 delegate684_0;

	public Class1445.Delegate297 delegate297_0;

	public Class1445.Delegate299 delegate299_0;

	public Class1628.Delegate763 delegate763_0;

	public Class1628.Delegate765 delegate765_0;

	public Class1701.Delegate982 delegate982_0;

	public Class1701.Delegate984 delegate984_0;

	public Class1704.Delegate991 delegate991_0;

	public Class1704.Delegate993 delegate993_0;

	public Class1739.Delegate1096 delegate1096_0;

	public Class1739.Delegate1098 delegate1098_0;

	public Class1519.Delegate436 delegate436_0;

	public Class1519.Delegate437 delegate437_0;

	public Class1743.Delegate1108 delegate1108_0;

	public Class1743.Delegate1110 delegate1110_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private Class1521 class1521_0;

	private Class1520 class1520_0;

	private Class1745 class1745_0;

	private Class1746 class1746_0;

	private Class1374 class1374_0;

	private Class1696 class1696_0;

	private Class1535 class1535_0;

	private Class1509 class1509_0;

	private Class1492 class1492_0;

	private Class1388 class1388_0;

	private Class1601 class1601_0;

	private Class1445 class1445_0;

	private Class1628 class1628_0;

	private Class1701 class1701_0;

	private Class1704 class1704_0;

	private Class1739 class1739_0;

	private List<Class1519> list_0;

	private Class1743 class1743_0;

	private Class1502 class1502_0;

	public Class1521 FileVersion => class1521_0;

	public Class1520 FileSharing => class1520_0;

	public Class1745 WorkbookPr => class1745_0;

	public Class1746 WorkbookProtection => class1746_0;

	public Class1374 BookViews => class1374_0;

	public Class1696 Sheets => class1696_0;

	public Class1535 FunctionGroups => class1535_0;

	public Class1509 ExternalReferences => class1509_0;

	public Class1492 DefinedNames => class1492_0;

	public Class1388 CalcPr => class1388_0;

	public Class1601 OleSize => class1601_0;

	public Class1445 CustomWorkbookViews => class1445_0;

	public Class1628 PivotCaches => class1628_0;

	public Class1701 SmartTagPr => class1701_0;

	public Class1704 SmartTagTypes => class1704_0;

	public Class1739 WebPublishing => class1739_0;

	public Class1519[] FileRecoveryPrList => list_0.ToArray();

	public Class1743 WebPublishObjects => class1743_0;

	public Class1502 ExtLst => class1502_0;

	protected override void vmethod_0(XmlReader reader)
	{
		string localName = reader.LocalName;
		method_2(reader);
		if (reader.IsEmptyElement)
		{
			return;
		}
		bool flag = false;
		while (((flag && !reader.EOF) || reader.Read()) && (reader.NodeType != XmlNodeType.EndElement || !(reader.LocalName == localName)))
		{
			flag = false;
			if (reader.NodeType == XmlNodeType.Element)
			{
				switch (reader.LocalName)
				{
				case "fileVersion":
					class1521_0 = new Class1521(reader);
					break;
				case "fileSharing":
					class1520_0 = new Class1520(reader);
					break;
				case "workbookPr":
					class1745_0 = new Class1745(reader);
					break;
				case "workbookProtection":
					class1746_0 = new Class1746(reader);
					break;
				case "bookViews":
					class1374_0 = new Class1374(reader);
					break;
				case "sheets":
					class1696_0 = new Class1696(reader);
					break;
				case "functionGroups":
					class1535_0 = new Class1535(reader);
					break;
				case "externalReferences":
					class1509_0 = new Class1509(reader);
					break;
				case "definedNames":
					class1492_0 = new Class1492(reader);
					break;
				case "calcPr":
					class1388_0 = new Class1388(reader);
					break;
				case "oleSize":
					class1601_0 = new Class1601(reader);
					break;
				case "customWorkbookViews":
					class1445_0 = new Class1445(reader);
					break;
				case "pivotCaches":
					class1628_0 = new Class1628(reader);
					break;
				case "smartTagPr":
					class1701_0 = new Class1701(reader);
					break;
				case "smartTagTypes":
					class1704_0 = new Class1704(reader);
					break;
				case "webPublishing":
					class1739_0 = new Class1739(reader);
					break;
				case "fileRecoveryPr":
				{
					Class1519 item = new Class1519(reader);
					list_0.Add(item);
					break;
				}
				case "webPublishObjects":
					class1743_0 = new Class1743(reader);
					break;
				case "extLst":
					class1502_0 = new Class1502(reader);
					break;
				default:
					reader.Skip();
					flag = true;
					break;
				}
			}
		}
	}

	private void method_2(XmlReader reader)
	{
	}

	public Class1744(XmlReader reader)
		: base(reader)
	{
	}

	public Class1744()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1519>();
	}

	protected override void vmethod_2()
	{
		delegate442_0 = method_3;
		delegate444_0 = method_4;
		delegate439_0 = method_5;
		delegate441_0 = method_6;
		delegate1114_0 = method_7;
		delegate1116_0 = method_8;
		delegate1117_0 = method_9;
		delegate1119_0 = method_10;
		delegate84_0 = method_11;
		delegate86_0 = method_12;
		delegate484_0 = method_13;
		delegate486_0 = method_14;
		delegate406_0 = method_15;
		delegate408_0 = method_16;
		delegate353_0 = method_17;
		delegate355_0 = method_18;
		delegate126_0 = method_19;
		delegate128_0 = method_20;
		delegate682_0 = method_21;
		delegate684_0 = method_22;
		delegate297_0 = method_23;
		delegate299_0 = method_24;
		delegate763_0 = method_25;
		delegate765_0 = method_26;
		delegate982_0 = method_27;
		delegate984_0 = method_28;
		delegate991_0 = method_29;
		delegate993_0 = method_30;
		delegate1096_0 = method_31;
		delegate1098_0 = method_32;
		delegate436_0 = method_33;
		delegate437_0 = method_34;
		delegate1108_0 = method_35;
		delegate1110_0 = method_36;
		delegate385_0 = method_37;
		delegate387_0 = method_38;
	}

	protected override void vmethod_3()
	{
		class1696_0 = new Class1696();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("ssml", elementName, "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		if (class1521_0 != null)
		{
			class1521_0.vmethod_4("ssml", writer, "fileVersion");
		}
		if (class1520_0 != null)
		{
			class1520_0.vmethod_4("ssml", writer, "fileSharing");
		}
		if (class1745_0 != null)
		{
			class1745_0.vmethod_4("ssml", writer, "workbookPr");
		}
		if (class1746_0 != null)
		{
			class1746_0.vmethod_4("ssml", writer, "workbookProtection");
		}
		if (class1374_0 != null)
		{
			class1374_0.vmethod_4("ssml", writer, "bookViews");
		}
		class1696_0.vmethod_4("ssml", writer, "sheets");
		if (class1535_0 != null)
		{
			class1535_0.vmethod_4("ssml", writer, "functionGroups");
		}
		if (class1509_0 != null)
		{
			class1509_0.vmethod_4("ssml", writer, "externalReferences");
		}
		if (class1492_0 != null)
		{
			class1492_0.vmethod_4("ssml", writer, "definedNames");
		}
		if (class1388_0 != null)
		{
			class1388_0.vmethod_4("ssml", writer, "calcPr");
		}
		if (class1601_0 != null)
		{
			class1601_0.vmethod_4("ssml", writer, "oleSize");
		}
		if (class1445_0 != null)
		{
			class1445_0.vmethod_4("ssml", writer, "customWorkbookViews");
		}
		if (class1628_0 != null)
		{
			class1628_0.vmethod_4("ssml", writer, "pivotCaches");
		}
		if (class1701_0 != null)
		{
			class1701_0.vmethod_4("ssml", writer, "smartTagPr");
		}
		if (class1704_0 != null)
		{
			class1704_0.vmethod_4("ssml", writer, "smartTagTypes");
		}
		if (class1739_0 != null)
		{
			class1739_0.vmethod_4("ssml", writer, "webPublishing");
		}
		foreach (Class1519 item in list_0)
		{
			item.vmethod_4("ssml", writer, "fileRecoveryPr");
		}
		if (class1743_0 != null)
		{
			class1743_0.vmethod_4("ssml", writer, "webPublishObjects");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1521 method_3()
	{
		if (class1521_0 != null)
		{
			throw new Exception("Only one <fileVersion> element can be added.");
		}
		class1521_0 = new Class1521();
		return class1521_0;
	}

	private void method_4(Class1521 _fileVersion)
	{
		class1521_0 = _fileVersion;
	}

	private Class1520 method_5()
	{
		if (class1520_0 != null)
		{
			throw new Exception("Only one <fileSharing> element can be added.");
		}
		class1520_0 = new Class1520();
		return class1520_0;
	}

	private void method_6(Class1520 _fileSharing)
	{
		class1520_0 = _fileSharing;
	}

	private Class1745 method_7()
	{
		if (class1745_0 != null)
		{
			throw new Exception("Only one <workbookPr> element can be added.");
		}
		class1745_0 = new Class1745();
		return class1745_0;
	}

	private void method_8(Class1745 _workbookPr)
	{
		class1745_0 = _workbookPr;
	}

	private Class1746 method_9()
	{
		if (class1746_0 != null)
		{
			throw new Exception("Only one <workbookProtection> element can be added.");
		}
		class1746_0 = new Class1746();
		return class1746_0;
	}

	private void method_10(Class1746 _workbookProtection)
	{
		class1746_0 = _workbookProtection;
	}

	private Class1374 method_11()
	{
		if (class1374_0 != null)
		{
			throw new Exception("Only one <bookViews> element can be added.");
		}
		class1374_0 = new Class1374();
		return class1374_0;
	}

	private void method_12(Class1374 _bookViews)
	{
		class1374_0 = _bookViews;
	}

	private Class1535 method_13()
	{
		if (class1535_0 != null)
		{
			throw new Exception("Only one <functionGroups> element can be added.");
		}
		class1535_0 = new Class1535();
		return class1535_0;
	}

	private void method_14(Class1535 _functionGroups)
	{
		class1535_0 = _functionGroups;
	}

	private Class1509 method_15()
	{
		if (class1509_0 != null)
		{
			throw new Exception("Only one <externalReferences> element can be added.");
		}
		class1509_0 = new Class1509();
		return class1509_0;
	}

	private void method_16(Class1509 _externalReferences)
	{
		class1509_0 = _externalReferences;
	}

	private Class1492 method_17()
	{
		if (class1492_0 != null)
		{
			throw new Exception("Only one <definedNames> element can be added.");
		}
		class1492_0 = new Class1492();
		return class1492_0;
	}

	private void method_18(Class1492 _definedNames)
	{
		class1492_0 = _definedNames;
	}

	private Class1388 method_19()
	{
		if (class1388_0 != null)
		{
			throw new Exception("Only one <calcPr> element can be added.");
		}
		class1388_0 = new Class1388();
		return class1388_0;
	}

	private void method_20(Class1388 _calcPr)
	{
		class1388_0 = _calcPr;
	}

	private Class1601 method_21()
	{
		if (class1601_0 != null)
		{
			throw new Exception("Only one <oleSize> element can be added.");
		}
		class1601_0 = new Class1601();
		return class1601_0;
	}

	private void method_22(Class1601 _oleSize)
	{
		class1601_0 = _oleSize;
	}

	private Class1445 method_23()
	{
		if (class1445_0 != null)
		{
			throw new Exception("Only one <customWorkbookViews> element can be added.");
		}
		class1445_0 = new Class1445();
		return class1445_0;
	}

	private void method_24(Class1445 _customWorkbookViews)
	{
		class1445_0 = _customWorkbookViews;
	}

	private Class1628 method_25()
	{
		if (class1628_0 != null)
		{
			throw new Exception("Only one <pivotCaches> element can be added.");
		}
		class1628_0 = new Class1628();
		return class1628_0;
	}

	private void method_26(Class1628 _pivotCaches)
	{
		class1628_0 = _pivotCaches;
	}

	private Class1701 method_27()
	{
		if (class1701_0 != null)
		{
			throw new Exception("Only one <smartTagPr> element can be added.");
		}
		class1701_0 = new Class1701();
		return class1701_0;
	}

	private void method_28(Class1701 _smartTagPr)
	{
		class1701_0 = _smartTagPr;
	}

	private Class1704 method_29()
	{
		if (class1704_0 != null)
		{
			throw new Exception("Only one <smartTagTypes> element can be added.");
		}
		class1704_0 = new Class1704();
		return class1704_0;
	}

	private void method_30(Class1704 _smartTagTypes)
	{
		class1704_0 = _smartTagTypes;
	}

	private Class1739 method_31()
	{
		if (class1739_0 != null)
		{
			throw new Exception("Only one <webPublishing> element can be added.");
		}
		class1739_0 = new Class1739();
		return class1739_0;
	}

	private void method_32(Class1739 _webPublishing)
	{
		class1739_0 = _webPublishing;
	}

	private Class1519 method_33()
	{
		Class1519 @class = new Class1519();
		list_0.Add(@class);
		return @class;
	}

	private void method_34(Class1519 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1743 method_35()
	{
		if (class1743_0 != null)
		{
			throw new Exception("Only one <webPublishObjects> element can be added.");
		}
		class1743_0 = new Class1743();
		return class1743_0;
	}

	private void method_36(Class1743 _webPublishObjects)
	{
		class1743_0 = _webPublishObjects;
	}

	private Class1502 method_37()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_38(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
