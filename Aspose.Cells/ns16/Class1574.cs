using System.Collections;
using System.Xml;
using Aspose.Cells;
using ns22;

namespace ns16;

internal class Class1574
{
	private Class1541 class1541_0;

	private Hashtable hashtable_0;

	private ArrayList arrayList_0;

	internal Class1574(Class1541 class1541_1)
	{
		class1541_0 = class1541_1;
		hashtable_0 = new Hashtable();
		arrayList_0 = new ArrayList();
		for (int i = 0; i < class1541_0.worksheet_0.Comments.Count; i++)
		{
			Comment comment = class1541_0.worksheet_0.Comments[i];
			if (hashtable_0[comment.Author] == null)
			{
				hashtable_0.Add(comment.Author, Class1618.smethod_80(arrayList_0.Count));
				arrayList_0.Add(comment.Author);
			}
		}
	}

	[Attribute0(true)]
	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("comments");
		if (Class1618.bool_0)
		{
			xmlTextWriter_0.WriteAttributeString("xmlns", Class1618.string_0);
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("xmlns", Class1618.string_1);
		}
		xmlTextWriter_0.WriteStartElement("authors");
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			xmlTextWriter_0.WriteStartElement("author");
			xmlTextWriter_0.WriteString((string)arrayList_0[i]);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("commentList");
		for (int j = 0; j < class1541_0.worksheet_0.Comments.Count; j++)
		{
			Comment comment_ = class1541_0.worksheet_0.Comments[j];
			method_0(xmlTextWriter_0, comment_);
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	[Attribute0(true)]
	private void method_0(XmlTextWriter xmlTextWriter_0, Comment comment_0)
	{
		xmlTextWriter_0.WriteStartElement("comment");
		string value = CellsHelper.ColumnIndexToName(comment_0.Column) + (comment_0.Row + 1);
		xmlTextWriter_0.WriteAttributeString("ref", value);
		xmlTextWriter_0.WriteAttributeString("authorId", (string)hashtable_0[comment_0.Author]);
		xmlTextWriter_0.WriteStartElement("text");
		Font font = comment_0.method_6();
		if (comment_0.method_2().method_12() != null && comment_0.method_2().method_12().Count != 0)
		{
			int count = comment_0.method_2().method_12().Count;
			for (int i = 0; i < count; i++)
			{
				FontSetting fontSetting = (FontSetting)comment_0.method_2().method_12()[i];
				Font font2 = fontSetting.method_2();
				if (font2 == null)
				{
					font2 = font;
				}
				string string_ = comment_0.method_2().Text.Substring(fontSetting.StartIndex, fontSetting.Length);
				method_1(xmlTextWriter_0, font2, string_);
			}
		}
		else
		{
			method_1(xmlTextWriter_0, font, comment_0.method_2().Text);
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_1(XmlTextWriter xmlTextWriter_0, Font font_0, string string_0)
	{
		xmlTextWriter_0.WriteStartElement("r");
		if (font_0 != null)
		{
			xmlTextWriter_0.WriteStartElement("rPr");
			Class1590.smethod_0(font_0, xmlTextWriter_0, "rFont");
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteStartElement("t");
		if (string_0 != null && Class1618.smethod_177(string_0))
		{
			xmlTextWriter_0.WriteAttributeString("xml:space", null, "preserve");
		}
		string text = Class1618.smethod_4(string_0);
		xmlTextWriter_0.WriteString(text);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}
}
