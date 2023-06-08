using System;
using System.Collections;
using System.Text;
using System.Xml;
using Aspose.Cells;
using ns22;

namespace ns16;

internal class Class1599
{
	private Class1547 class1547_0;

	private string string_0;

	private Class1548 class1548_0;

	private Palette palette_0;

	private ArrayList arrayList_0;

	internal Class1599(Class1547 class1547_1, Class1548 class1548_1)
	{
		class1547_0 = class1547_1;
		class1548_0 = class1548_1;
		palette_0 = class1547_0.workbook_0.Worksheets.method_24();
		arrayList_0 = new ArrayList();
	}

	internal void Read(XmlTextReader xmlTextReader_0)
	{
		method_5(xmlTextReader_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && !xmlTextReader_0.IsEmptyElement && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "commentList")
				{
					method_1(xmlTextReader_0);
				}
				else if (xmlTextReader_0.LocalName == "authors")
				{
					method_0(xmlTextReader_0);
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	[Attribute0(true)]
	private void method_0(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && !xmlTextReader_0.IsEmptyElement && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "author")
				{
					arrayList_0.Add(xmlTextReader_0.ReadElementString());
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_1(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && !xmlTextReader_0.IsEmptyElement && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "comment")
				{
					method_2(xmlTextReader_0);
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_2(XmlTextReader xmlTextReader_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("ref");
		if (attribute != null && attribute.Length != 0)
		{
			int num = Class1618.smethod_87(xmlTextReader_0.GetAttribute("authorId"));
			if (xmlTextReader_0.IsEmptyElement)
			{
				xmlTextReader_0.Skip();
				return;
			}
			int index = class1548_0.worksheet_0.Comments.method_1(attribute);
			Comment comment = class1548_0.worksheet_0.Comments[index];
			if (num < arrayList_0.Count && num >= 0)
			{
				comment.Author = (string)arrayList_0[num];
			}
			xmlTextReader_0.Read();
			while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
			{
				xmlTextReader_0.MoveToContent();
				if (xmlTextReader_0.NodeType == XmlNodeType.Element && !xmlTextReader_0.IsEmptyElement && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
				{
					if (xmlTextReader_0.LocalName == "text")
					{
						method_3(xmlTextReader_0, comment);
					}
					else
					{
						xmlTextReader_0.Skip();
					}
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
			xmlTextReader_0.ReadEndElement();
			return;
		}
		throw new CellsException(ExceptionType.InvalidData, "Invalid comment element");
	}

	private void method_3(XmlTextReader xmlTextReader_0, Comment comment_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		ArrayList arrayList = new ArrayList();
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && !xmlTextReader_0.IsEmptyElement && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "r")
				{
					Class1565 value = method_4(xmlTextReader_0);
					arrayList.Add(value);
				}
				else if (xmlTextReader_0.LocalName == "t")
				{
					Class1565 @class = new Class1565();
					@class.string_0 = Class1618.smethod_8(xmlTextReader_0.ReadElementString());
					arrayList.Add(@class);
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		comment_0.method_2().method_13(new ArrayList());
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1565 class2 = (Class1565)arrayList[i];
			if (class2.string_0 != null)
			{
				int length = class2.string_0.Length;
				FontSetting fontSetting = new FontSetting(num, length, class1548_0.worksheet_0.method_2(), bool_1: true);
				Font font = null;
				if (class2.class1542_0 != null)
				{
					font = new Font(class1548_0.worksheet_0.method_2(), null, bool_0: true);
					class2.class1542_0.method_19(font);
					fontSetting.method_3(font);
				}
				num += length;
				stringBuilder.Append(class2.string_0);
				comment_0.method_2().method_12().Add(fontSetting);
			}
		}
		comment_0.method_2().method_4(stringBuilder.ToString());
	}

	private Class1565 method_4(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid r element");
		}
		Class1565 @class = new Class1565();
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "rPr" && !xmlTextReader_0.IsEmptyElement)
			{
				@class.class1542_0 = Class1611.smethod_1(xmlTextReader_0, class1547_0, "rFont");
			}
			else if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "t" && !xmlTextReader_0.IsEmptyElement)
			{
				@class.string_0 = Class1618.smethod_8(xmlTextReader_0.ReadElementString());
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return @class;
	}

	private void method_5(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		xmlTextReader_0.MoveToContent();
		string namespaceURI = xmlTextReader_0.NamespaceURI;
		if (!Class1618.smethod_0(namespaceURI))
		{
			throw new CellsException(ExceptionType.InvalidData, "Error xml namespace " + namespaceURI);
		}
		if (xmlTextReader_0.NodeType != XmlNodeType.Element || xmlTextReader_0.LocalName != "comments")
		{
			throw new ApplicationException("comments root element eror");
		}
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		string_0 = nameTable.Add(namespaceURI);
	}
}
