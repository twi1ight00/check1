using System.Collections;
using System.Text;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns2;
using ns22;
using ns26;

namespace ns15;

internal class Class1100
{
	private XmlTextReader xmlTextReader_0;

	private Class1489 class1489_0;

	internal Class1100(Class1489 class1489_1)
	{
		class1489_0 = class1489_1;
	}

	[Attribute0(true)]
	internal void method_0(Shape shape_0, XmlTextReader xmlTextReader_1)
	{
		xmlTextReader_0 = xmlTextReader_1;
		string text = null;
		int int_ = 0;
		int int_2 = 0;
		int int_3 = 0;
		int int_4 = 0;
		if (xmlTextReader_1.HasAttributes)
		{
			while (xmlTextReader_1.MoveToNextAttribute())
			{
				switch (xmlTextReader_1.LocalName)
				{
				case "height":
					int_4 = Class1516.smethod_1(class1489_0.double_0, xmlTextReader_1.Value);
					break;
				case "width":
					int_3 = Class1516.smethod_1(class1489_0.double_0, xmlTextReader_1.Value);
					break;
				case "y":
					int_2 = Class1516.smethod_1(class1489_0.double_0, xmlTextReader_1.Value);
					break;
				case "x":
					int_ = Class1516.smethod_1(class1489_0.double_0, xmlTextReader_1.Value);
					break;
				case "text-style-name":
					text = xmlTextReader_1.Value;
					break;
				case "style-name":
					_ = xmlTextReader_1.Value;
					break;
				}
			}
			xmlTextReader_1.MoveToElement();
		}
		shape_0.method_17(int_, int_2, int_3, int_4);
		if (xmlTextReader_1.IsEmptyElement)
		{
			xmlTextReader_1.Skip();
			return;
		}
		xmlTextReader_1.Read();
		Font font = null;
		if (text != null)
		{
			Class1352 @class = (Class1352)class1489_0.hashtable_5[text];
			font = ((@class == null || @class.font_0 == null) ? class1489_0.workbook_0.Worksheets.method_53(0) : @class.font_0);
		}
		else
		{
			font = class1489_0.workbook_0.Worksheets.method_53(0);
		}
		ArrayList arrayList = new ArrayList();
		while (xmlTextReader_1.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_1.MoveToContent();
			if (xmlTextReader_1.NodeType == XmlNodeType.EndElement)
			{
				break;
			}
			if (xmlTextReader_1.NodeType != XmlNodeType.Element)
			{
				if (xmlTextReader_1.NodeType == XmlNodeType.Text)
				{
					Class1353 class2 = new Class1353();
					class2.string_0 = xmlTextReader_1.Value;
					arrayList.Add(class2);
				}
				xmlTextReader_1.Skip();
				continue;
			}
			switch (xmlTextReader_1.LocalName.ToLower())
			{
			case "span":
				method_2(arrayList, font);
				break;
			case "p":
				method_1(arrayList);
				break;
			default:
				xmlTextReader_1.Skip();
				break;
			}
		}
		xmlTextReader_1.ReadEndElement();
		if (arrayList.Count != 0 && text != null)
		{
			MsoDrawingType msoDrawingType = shape_0.MsoDrawingType;
			if (msoDrawingType == MsoDrawingType.Comment)
			{
				method_3(arrayList, ((CommentShape)shape_0).method_69().method_2(), font);
			}
		}
	}

	internal void method_1(ArrayList arrayList_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		string text = null;
		if (arrayList_0.Count != 0)
		{
			Class1353 @class = (Class1353)arrayList_0[arrayList_0.Count - 1];
			@class.string_0 += "\n";
			arrayList_0[arrayList_0.Count - 1] = @class;
		}
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if ((localName = xmlTextReader_0.LocalName) != null && localName == "style-name")
				{
					text = xmlTextReader_0.Value;
				}
			}
		}
		Font font_ = null;
		if (text != null && text != "")
		{
			Class1352 class2 = (Class1352)class1489_0.hashtable_5[text];
			font_ = class2.font_0;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.EndElement)
			{
				break;
			}
			string text2;
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				if (xmlTextReader_0.NodeType == XmlNodeType.Text)
				{
					Class1353 class3 = new Class1353();
					class3.string_0 = xmlTextReader_0.Value;
					class3.font_0 = font_;
					arrayList_0.Add(class3);
				}
				xmlTextReader_0.Skip();
			}
			else if ((text2 = xmlTextReader_0.LocalName.ToLower()) != null && text2 == "span")
			{
				method_2(arrayList_0, font_);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	internal void method_2(ArrayList arrayList_0, Font font_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		Class1353 @class = new Class1353();
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if ((localName = xmlTextReader_0.LocalName) != null && localName == "style-name")
				{
					@class.font_0 = (Font)class1489_0.hashtable_4[xmlTextReader_0.Value];
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Text)
			{
				@class = new Class1353();
				@class.string_0 = xmlTextReader_0.Value;
				@class.font_0 = font_0;
				arrayList_0.Add(@class);
			}
			xmlTextReader_0.Skip();
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_3(ArrayList arrayList_0, Class1737 class1737_0, Font font_0)
	{
		if (arrayList_0.Count < 0)
		{
			class1737_0.Font = font_0;
			return;
		}
		if (arrayList_0.Count == 1)
		{
			Class1353 @class = (Class1353)arrayList_0[0];
			class1737_0.Text = @class.string_0;
			class1737_0.Font = ((@class.font_0 == null) ? font_0 : @class.font_0);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1353 class2 = (Class1353)arrayList_0[i];
			FontSetting fontSetting = new FontSetting(stringBuilder.Length, class2.string_0.Length, class1489_0.workbook_0.Worksheets, bool_1: true);
			stringBuilder.Append(class2.string_0);
			if (class2.font_0 == null)
			{
				fontSetting.Font.Copy(font_0);
			}
			else
			{
				fontSetting.Font.Copy(class2.font_0);
			}
			arrayList.Add(fontSetting);
		}
		class1737_0.Text = stringBuilder.ToString();
		class1737_0.Font = font_0;
		class1737_0.method_13(arrayList);
	}
}
