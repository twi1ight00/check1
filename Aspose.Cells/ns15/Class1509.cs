using System;
using System.Collections;
using System.Xml;
using Aspose.Cells;
using ns22;
using ns26;

namespace ns15;

internal class Class1509
{
	private XmlTextWriter xmlTextWriter_0;

	private Class1498 class1498_0;

	public Class1509(Class1498 class1498_1)
	{
		class1498_0 = class1498_1;
	}

	[Attribute0(true)]
	internal void Write(XmlTextWriter xmlTextWriter_1)
	{
		xmlTextWriter_0 = xmlTextWriter_1;
		xmlTextWriter_1.WriteStartElement("office:master-styles");
		for (int i = 0; i < class1498_0.arrayList_5.Count; i++)
		{
			Class1499 class1499_ = (Class1499)class1498_0.arrayList_5[i];
			method_0(class1499_);
		}
		xmlTextWriter_1.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_0(Class1499 class1499_0)
	{
		xmlTextWriter_0.WriteStartElement("style:master-page");
		xmlTextWriter_0.WriteAttributeString("style", "name", null, "PageStyle_5f_" + class1499_0.string_0);
		xmlTextWriter_0.WriteAttributeString("style", "display-name", null, "PageStyle_" + class1499_0.string_0);
		xmlTextWriter_0.WriteAttributeString("style", "page-layout-name", null, "pm" + (class1499_0.worksheet_0.Index + 1));
		method_1(class1499_0);
		method_2(class1499_0);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_1(Class1499 class1499_0)
	{
		if (class1499_0.arrayList_5 != null)
		{
			xmlTextWriter_0.WriteStartElement("style:header");
			method_3("style:region-left", class1499_0.arrayList_5[0]);
			method_3("style:region-center", class1499_0.arrayList_5[1]);
			method_3("style:region-right", class1499_0.arrayList_5[2]);
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteStartElement("style:header-left");
			if (class1499_0.bool_1)
			{
				method_3("style:region-left", class1499_0.arrayList_3[0]);
				method_3("style:region-center", class1499_0.arrayList_3[1]);
				method_3("style:region-right", class1499_0.arrayList_3[2]);
			}
			else
			{
				xmlTextWriter_0.WriteAttributeString("style", "display", null, "false");
			}
			xmlTextWriter_0.WriteEndElement();
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("style:header");
			xmlTextWriter_0.WriteAttributeString("style", "display", null, "false");
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteStartElement("style:header-left");
			xmlTextWriter_0.WriteAttributeString("style", "display", null, "false");
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_2(Class1499 class1499_0)
	{
		if (class1499_0.arrayList_6 != null)
		{
			xmlTextWriter_0.WriteStartElement("style:footer");
			method_3("style:region-left", class1499_0.arrayList_6[0]);
			method_3("style:region-center", class1499_0.arrayList_6[1]);
			method_3("style:region-right", class1499_0.arrayList_6[2]);
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteStartElement("style:footer-left");
			if (class1499_0.bool_1)
			{
				method_3("style:region-left", class1499_0.arrayList_4[0]);
				method_3("style:region-center", class1499_0.arrayList_4[1]);
				method_3("style:region-right", class1499_0.arrayList_4[2]);
			}
			else
			{
				xmlTextWriter_0.WriteAttributeString("style", "display", null, "false");
			}
			xmlTextWriter_0.WriteEndElement();
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("style:footer");
			xmlTextWriter_0.WriteAttributeString("style", "display", null, "false");
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteStartElement("style:footer-left");
			xmlTextWriter_0.WriteAttributeString("style", "display", null, "false");
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_3(string string_0, ArrayList arrayList_0)
	{
		if (arrayList_0 == null || arrayList_0.Count == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement(string_0);
		xmlTextWriter_0.WriteStartElement("text:p");
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			HeaderFooterCommand headerFooterCommand = (HeaderFooterCommand)arrayList_0[i];
			if (i != 0 && headerFooterCommand.Type == HeaderFooterCommandType.FileName)
			{
				HeaderFooterCommand headerFooterCommand2 = (HeaderFooterCommand)arrayList_0[i - 1];
				if (headerFooterCommand2.Type == HeaderFooterCommandType.FilePath)
				{
					continue;
				}
			}
			method_4(headerFooterCommand);
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_4(HeaderFooterCommand headerFooterCommand_0)
	{
		xmlTextWriter_0.WriteStartElement("text:span");
		xmlTextWriter_0.WriteAttributeString("text", "style-name", null, (headerFooterCommand_0.Font == null) ? "T1" : ("T" + headerFooterCommand_0.Font.method_21()));
		switch (headerFooterCommand_0.Type)
		{
		case HeaderFooterCommandType.Text:
		{
			string text = headerFooterCommand_0.Text;
			string[] array = text.Split('\n');
			if (array.Length == 1)
			{
				xmlTextWriter_0.WriteString(headerFooterCommand_0.Text);
				break;
			}
			xmlTextWriter_0.WriteString(array[0]);
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
			for (int i = 1; i < array.Length; i++)
			{
				xmlTextWriter_0.WriteStartElement("text:p");
				xmlTextWriter_0.WriteStartElement("text:span");
				xmlTextWriter_0.WriteAttributeString("text", "style-name", null, (headerFooterCommand_0.Font == null) ? "T1" : ("T" + headerFooterCommand_0.Font.method_21()));
				xmlTextWriter_0.WriteString(array[i]);
				if (i < array.Length - 1)
				{
					xmlTextWriter_0.WriteEndElement();
					xmlTextWriter_0.WriteEndElement();
				}
			}
			break;
		}
		case HeaderFooterCommandType.CurrentPage:
			xmlTextWriter_0.WriteStartElement("text:page-number");
			xmlTextWriter_0.WriteString("1");
			xmlTextWriter_0.WriteEndElement();
			break;
		case HeaderFooterCommandType.Pagecount:
			xmlTextWriter_0.WriteStartElement("text:page-count");
			xmlTextWriter_0.WriteString("99");
			xmlTextWriter_0.WriteEndElement();
			break;
		case HeaderFooterCommandType.CurrentDate:
		{
			DateTime now2 = DateTime.Now;
			xmlTextWriter_0.WriteStartElement("text:date");
			xmlTextWriter_0.WriteAttributeString("style", "date-value", null, now2.ToString("yyyy-MM-dd"));
			xmlTextWriter_0.WriteString(now2.ToString("MM/d/yy"));
			xmlTextWriter_0.WriteEndElement();
			break;
		}
		case HeaderFooterCommandType.CurrentTime:
		{
			DateTime now = DateTime.Now;
			xmlTextWriter_0.WriteStartElement("text:time");
			xmlTextWriter_0.WriteString(now.ToString("hh:mm:ss"));
			xmlTextWriter_0.WriteEndElement();
			break;
		}
		case HeaderFooterCommandType.SheetName:
			xmlTextWriter_0.WriteStartElement("text:sheet-name");
			xmlTextWriter_0.WriteString("???");
			xmlTextWriter_0.WriteEndElement();
			break;
		case HeaderFooterCommandType.FileName:
			xmlTextWriter_0.WriteStartElement("text:file-name");
			xmlTextWriter_0.WriteAttributeString("text", "display", null, "name-and-extension");
			xmlTextWriter_0.WriteString("???");
			xmlTextWriter_0.WriteEndElement();
			break;
		case HeaderFooterCommandType.FilePath:
			xmlTextWriter_0.WriteStartElement("text:file-name");
			xmlTextWriter_0.WriteAttributeString("text", "display", null, "full");
			xmlTextWriter_0.WriteString("???");
			xmlTextWriter_0.WriteEndElement();
			break;
		}
		xmlTextWriter_0.WriteEndElement();
	}
}
