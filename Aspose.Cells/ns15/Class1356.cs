using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns1;
using ns16;
using ns2;
using ns21;
using ns22;
using ns25;
using ns26;

namespace ns15;

internal class Class1356
{
	private XmlTextReader xmlTextReader_0;

	private Class1489 class1489_0;

	private Hashtable hashtable_0;

	private bool bool_0;

	private Hashtable hashtable_1;

	internal Class1356(Class1489 class1489_1)
	{
		class1489_0 = class1489_1;
		hashtable_0 = new Hashtable();
		bool_0 = true;
		hashtable_1 = new Hashtable();
	}

	internal void method_0(Worksheet worksheet_0, string string_0, int int_0, int int_1, XmlTextReader xmlTextReader_1)
	{
		hashtable_0.Clear();
		xmlTextReader_0 = xmlTextReader_1;
		if (xmlTextReader_1.HasAttributes)
		{
			while (xmlTextReader_1.MoveToNextAttribute())
			{
				string localName;
				if ((localName = xmlTextReader_1.LocalName) == null)
				{
					continue;
				}
				if (Class1742.dictionary_98 == null)
				{
					Class1742.dictionary_98 = new Dictionary<string, int>(9)
					{
						{ "style-name", 0 },
						{ "text-style-name", 1 },
						{ "name", 2 },
						{ "z-index", 3 },
						{ "x", 4 },
						{ "y", 5 },
						{ "width", 6 },
						{ "height", 7 },
						{ "end-cell-address", 8 }
					};
				}
				if (Class1742.dictionary_98.TryGetValue(localName, out var value))
				{
					switch (value)
					{
					case 0:
						hashtable_0.Add("styleName", xmlTextReader_1.Value);
						break;
					case 1:
						hashtable_0.Add("textStyleName", xmlTextReader_1.Value);
						break;
					case 2:
						hashtable_0.Add("name", xmlTextReader_1.Value);
						break;
					case 3:
						hashtable_0.Add("zIndex", xmlTextReader_1.Value);
						break;
					case 4:
						hashtable_0.Add("x", Class1516.smethod_1(class1489_0.double_0, xmlTextReader_1.Value));
						break;
					case 5:
						hashtable_0.Add("y", Class1516.smethod_1(class1489_0.double_0, xmlTextReader_1.Value));
						break;
					case 6:
						hashtable_0.Add("width", Class1516.smethod_1(class1489_0.double_0, xmlTextReader_1.Value));
						break;
					case 7:
						hashtable_0.Add("height", Class1516.smethod_1(class1489_0.double_0, xmlTextReader_1.Value));
						break;
					case 8:
						hashtable_0.Add("end-cell-address", xmlTextReader_1.Value);
						break;
					}
				}
			}
			xmlTextReader_1.MoveToElement();
		}
		if (string_0 != null)
		{
			Shape shape_ = worksheet_0.Shapes.AddAutoShape(Class1515.smethod_5(string_0), int_0, (int)hashtable_0["y"], int_1, (int)hashtable_0["x"], (int)hashtable_0["height"], (int)hashtable_0["width"]);
			method_2(shape_, hashtable_0, xmlTextReader_1);
			return;
		}
		if (xmlTextReader_1.IsEmptyElement)
		{
			xmlTextReader_1.Skip();
			return;
		}
		bool flag = false;
		xmlTextReader_1.Read();
		while (Class536.smethod_4(xmlTextReader_1))
		{
			switch (xmlTextReader_1.LocalName.ToLower())
			{
			case "object-ole":
			case "image":
				if (flag)
				{
					xmlTextReader_1.Skip();
				}
				else
				{
					method_1(worksheet_0, xmlTextReader_1.LocalName.ToLower(), int_0, int_1, hashtable_0);
				}
				break;
			case "object":
			{
				flag = true;
				Class526 @class = new Class526(class1489_0);
				try
				{
					@class.method_0(worksheet_0, int_0, int_1, hashtable_0, xmlTextReader_0);
				}
				catch (Exception)
				{
					xmlTextReader_1.Skip();
				}
				break;
			}
			case "text-box":
			{
				TextBox shape_2 = worksheet_0.Shapes.AddTextBox(int_0, (int)hashtable_0["y"], int_1, (int)hashtable_0["x"], (int)hashtable_0["height"], (int)hashtable_0["width"]);
				method_2(shape_2, hashtable_0, xmlTextReader_1);
				break;
			}
			default:
				xmlTextReader_1.Skip();
				break;
			}
		}
	}

	internal void method_1(Worksheet worksheet_0, string string_0, int int_0, int int_1, Hashtable hashtable_2)
	{
		Class1096 @class = new Class1096();
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName.ToLower())
				{
				case "actuate":
					@class.method_4(Class1515.smethod_3(xmlTextReader_0.Value));
					break;
				case "show":
					@class.ShowType = Class1515.smethod_2(xmlTextReader_0.Value);
					break;
				case "href":
					@class.method_3(Class1516.smethod_30(xmlTextReader_0.Value));
					break;
				case "class-id":
					@class.method_1(xmlTextReader_0.Value);
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (string_0 == "object-ole" || string_0 == "object")
		{
			bool_0 = false;
			hashtable_1.Add("classId", @class.method_0());
			hashtable_1.Add("oleObject", method_9(@class.method_2()));
			hashtable_1.Add("href", @class.method_2());
			if (xmlTextReader_0.IsEmptyElement)
			{
				xmlTextReader_0.Skip();
				return;
			}
			xmlTextReader_0.Read();
			while (Class536.smethod_4(xmlTextReader_0))
			{
				xmlTextReader_0.LocalName.ToLower();
				xmlTextReader_0.Skip();
			}
		}
		if (bool_0)
		{
			Picture picture = null;
			if (@class.method_2() != null && @class.method_2().Trim() != "")
			{
				try
				{
					Stream stream = method_8(@class.method_2());
					picture = worksheet_0.Shapes.AddPicture(int_0, int_1, stream, 100, 100);
					if (picture != null)
					{
						picture.Placement = PlacementType.Move;
						picture.method_20(int_0, (int)hashtable_2["y"], int_1, (int)hashtable_2["x"], (int)hashtable_2["height"], (int)hashtable_2["width"]);
					}
				}
				catch (Exception)
				{
					xmlTextReader_0.Skip();
					return;
				}
			}
			if (xmlTextReader_0.IsEmptyElement)
			{
				xmlTextReader_0.Skip();
				return;
			}
			xmlTextReader_0.Read();
			Font font_ = class1489_0.workbook_0.Worksheets.method_53(0);
			ArrayList arrayList = new ArrayList();
			while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
			{
				xmlTextReader_0.MoveToContent();
				string text;
				if (xmlTextReader_0.NodeType != XmlNodeType.Element)
				{
					if (xmlTextReader_0.NodeType == XmlNodeType.Text)
					{
						Class1353 class2 = new Class1353();
						class2.string_0 = xmlTextReader_0.Value;
						arrayList.Add(class2);
					}
					xmlTextReader_0.Skip();
				}
				else if ((text = xmlTextReader_0.LocalName.ToLower()) != null && text == "p")
				{
					method_3(arrayList);
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
			xmlTextReader_0.ReadEndElement();
			if (picture != null && arrayList.Count != 0)
			{
				method_13(arrayList, picture.method_63(), font_);
			}
			return;
		}
		if (string_0 == "image" && hashtable_1["oleObject"] != null)
		{
			try
			{
				byte[] array = method_9(@class.method_2());
				if (method_10(array))
				{
					array = Class1186.smethod_6();
				}
				OleObject oleObject = worksheet_0.Shapes.AddOleObject(int_0, (int)hashtable_2["y"], int_1, (int)hashtable_2["x"], (int)hashtable_2["height"], (int)hashtable_2["width"], array);
				if (oleObject != null)
				{
					if (hashtable_1["classId"] != null)
					{
						oleObject.method_100(new Guid((string)hashtable_1["classId"]));
					}
					oleObject.ObjectData = (byte[])hashtable_1["oleObject"];
					oleObject.ProgID = "Word.OpenDocumentText.12";
					hashtable_1.Clear();
				}
			}
			catch (Exception)
			{
				xmlTextReader_0.Skip();
				return;
			}
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			xmlTextReader_0.LocalName.ToLower();
			xmlTextReader_0.Skip();
		}
	}

	internal void method_2(Shape shape_0, Hashtable hashtable_2, XmlTextReader xmlTextReader_1)
	{
		if (xmlTextReader_1.IsEmptyElement)
		{
			xmlTextReader_1.Skip();
			return;
		}
		xmlTextReader_1.Read();
		if (hashtable_2["styleName"] != null)
		{
			Class1355 @class = (Class1355)class1489_0.hashtable_6[hashtable_2["styleName"]];
			if (shape_0 != null && @class != null)
			{
				method_6(shape_0, @class);
			}
		}
		Font font = null;
		if (hashtable_2["textStyleName"] != null)
		{
			Class1352 class2 = (Class1352)class1489_0.hashtable_5[hashtable_2["textStyleName"]];
			font = ((class2 == null || class2.font_0 == null) ? class1489_0.workbook_0.Worksheets.method_53(0) : class2.font_0);
		}
		else
		{
			font = class1489_0.workbook_0.Worksheets.method_53(0);
		}
		if (hashtable_2["name"] != null)
		{
			shape_0.Name = (string)hashtable_2["name"];
		}
		if (hashtable_2["zIndex"] != null)
		{
			shape_0.ZOrderPosition = int.Parse((string)hashtable_2["zIndex"]);
		}
		ArrayList arrayList = new ArrayList();
		while (xmlTextReader_1.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_1.MoveToContent();
			string text;
			if (xmlTextReader_1.NodeType != XmlNodeType.Element)
			{
				if (xmlTextReader_1.NodeType == XmlNodeType.Text)
				{
					Class1353 class3 = new Class1353();
					class3.string_0 = xmlTextReader_1.Value;
					arrayList.Add(class3);
				}
				xmlTextReader_1.Skip();
			}
			else if ((text = xmlTextReader_1.LocalName.ToLower()) != null && text == "p")
			{
				method_3(arrayList);
			}
			else
			{
				xmlTextReader_1.Skip();
			}
		}
		xmlTextReader_1.ReadEndElement();
		if (arrayList.Count != 0)
		{
			method_13(arrayList, shape_0.method_63(), font);
		}
	}

	[Attribute0(true)]
	internal void method_3(ArrayList arrayList_0)
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
		xmlTextReader_0.Read();
		Font font_ = null;
		if (text != null)
		{
			Class1352 class2 = (Class1352)class1489_0.hashtable_5[text];
			if (class2 != null)
			{
				font_ = class2.font_0;
			}
		}
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
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
				method_4(arrayList_0, font_);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	internal void method_4(ArrayList arrayList_0, Font font_0)
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
		StringBuilder stringBuilder = new StringBuilder();
		method_5(stringBuilder, xmlTextReader_0);
		@class.string_0 = stringBuilder.ToString();
		arrayList_0.Add(@class);
	}

	[Attribute0(true)]
	private void method_5(StringBuilder stringBuilder_0, XmlTextReader xmlTextReader_1)
	{
		if (xmlTextReader_1.IsEmptyElement)
		{
			xmlTextReader_1.Skip();
			return;
		}
		xmlTextReader_1.Read();
		while (xmlTextReader_1.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_1.MoveToContent();
			if (xmlTextReader_1.NodeType == XmlNodeType.Text)
			{
				stringBuilder_0.Append(xmlTextReader_1.Value);
				xmlTextReader_1.Skip();
			}
			else if (xmlTextReader_1.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_1.Skip();
			}
			else if (xmlTextReader_1.IsEmptyElement)
			{
				xmlTextReader_1.Skip();
			}
			else
			{
				method_5(stringBuilder_0, xmlTextReader_1);
			}
		}
		xmlTextReader_1.ReadEndElement();
	}

	private void method_6(Shape shape_0, Class1355 class1355_0)
	{
		Class1098 class1098_ = class1355_0.class1098_0;
		if (class1098_.string_0 != null)
		{
			shape_0.IsTextWrapped = Class1516.smethod_28(class1098_.string_0);
		}
		string string_;
		if (class1098_.string_9 != null && (string_ = class1098_.string_9) != null && string_ == "stretch")
		{
			shape_0.bool_0 = false;
		}
		if (class1098_.string_1 != null || class1098_.string_2 != null || class1098_.string_3 != null || class1098_.string_4 != null)
		{
			MsoTextFrame textFrame = shape_0.TextFrame;
			textFrame.method_6(Class1516.smethod_1(class1489_0.double_0, class1098_.string_1));
			textFrame.method_8(Class1516.smethod_1(class1489_0.double_0, class1098_.string_2));
			textFrame.method_2(Class1516.smethod_1(class1489_0.double_0, class1098_.string_3));
			textFrame.method_4(Class1516.smethod_1(class1489_0.double_0, class1098_.string_4));
			textFrame.IsAutoMargin = false;
		}
		if (class1098_.string_5 != null && class1098_.string_6 != null)
		{
			Class1737 @class = shape_0.method_63();
			@class.TextVerticalAlignment = Class1516.smethod_23(class1098_.string_5);
			@class.TextHorizontalAlignment = Class1516.smethod_25(class1098_.string_6);
		}
		if (class1489_0.hashtable_7 != null && class1489_0.hashtable_7.Count > 0)
		{
			string string_2;
			if ((string_2 = class1098_.string_7) != null && string_2 == "bitmap")
			{
				shape_0.Fill.Type = FillType.Texture;
			}
			if (class1098_.string_8 != null)
			{
				Class1096 class2 = (Class1096)class1489_0.hashtable_7[class1098_.string_8];
				if (class2 != null)
				{
					method_7(shape_0, class2);
				}
			}
		}
		if (class1098_.string_10 != null && class1098_.string_10 != "none")
		{
			shape_0.LineFormat.Pattern = Class1515.smethod_4(class1098_.string_10);
			shape_0.LineFormat.Weight = Class1516.smethod_1(class1489_0.double_0, class1098_.string_11);
			shape_0.LineFormat.ForeColor = class1098_.color_0;
			if (class1098_.string_12 != null)
			{
				shape_0.LineFormat.method_3(Class1516.smethod_26(class1098_.string_12));
			}
			shape_0.LineFormat.IsVisible = true;
		}
		else
		{
			shape_0.LineFormat.IsVisible = false;
		}
	}

	private void method_7(Shape shape_0, Class1096 class1096_0)
	{
		Class746 class746_ = class1489_0.class746_0;
		Class744 @class = class746_.method_38(class1096_0.method_2());
		Stream stream = class746_.method_39(@class);
		byte[] array = new byte[(int)@class.Size];
		stream.Read(array, 0, (int)@class.Size);
		shape_0.FillFormat.ImageData = array;
		shape_0.FillFormat.method_5(Enum174.const_2);
		shape_0.FillFormat.method_3(class1096_0.method_2());
	}

	private Stream method_8(string string_0)
	{
		Class746 class746_ = class1489_0.class746_0;
		Class744 @class = class746_.method_38(string_0);
		if (@class == null)
		{
			return null;
		}
		return class746_.method_39(@class);
	}

	private byte[] method_9(string string_0)
	{
		Class746 class746_ = class1489_0.class746_0;
		Class744 @class = class746_.method_38(string_0);
		byte[] array = null;
		if (@class == null)
		{
			MemoryStream memoryStream = new MemoryStream();
			Stream6 stream = new Stream6(memoryStream);
			stream.method_6(Enum42.const_4);
			stream.method_10(Enum32.const_0);
			ArrayList arrayList = new ArrayList();
			bool flag = false;
			for (int i = 0; i < class746_.Count; i++)
			{
				string name = class746_[i].Name;
				if (!name.StartsWith(string_0 + "/"))
				{
					continue;
				}
				if (!flag)
				{
					Class1504 value = new Class1504("text/xml", "META-INF/manifest.xml");
					arrayList.Add(value);
				}
				if (name == string_0 + "/")
				{
					Class1504 value2 = new Class1504("application/vnd.oasis.opendocument.text", "/");
					arrayList.Add(value2);
					continue;
				}
				if (class746_[i].method_18())
				{
					Class744 class2 = stream.method_18(class746_[i].Name.Substring(string_0.Length + 1));
					class2.method_5(DateTime.Now);
					stream.Flush();
				}
				else
				{
					method_11(class746_[i], class746_, stream, string_0.Length + 1);
				}
				Class1504 value3 = new Class1504("text/xml", class746_[i].Name.Substring(string_0.Length + 1));
				arrayList.Add(value3);
			}
			if (arrayList.Count > 0)
			{
				method_12(arrayList, stream);
			}
			stream.method_22();
			stream.Close();
			if (arrayList.Count > 0)
			{
				array = memoryStream.ToArray();
			}
			memoryStream.Close();
		}
		else
		{
			Stream stream2 = class746_.method_39(@class);
			array = new byte[(int)@class.Size];
			stream2.Read(array, 0, (int)@class.Size);
			stream2.Close();
		}
		return array;
	}

	private bool method_10(byte[] byte_0)
	{
		if (byte_0 == null)
		{
			return true;
		}
		if (byte_0.Length > 6 && byte_0[0] == 86 && byte_0[1] == 67 && byte_0[2] == 76 && byte_0[3] == 77 && byte_0[4] == 84 && byte_0[5] == 70)
		{
			return true;
		}
		return false;
	}

	private void method_11(Class744 class744_0, Class746 class746_0, Stream6 stream6_0, int int_0)
	{
		Stream stream = class746_0.method_39(class744_0);
		byte[] array = new byte[(int)class744_0.Size];
		stream.Read(array, 0, (int)class744_0.Size);
		stream.Close();
		Class744 @class = stream6_0.method_18(class744_0.Name.Substring(int_0));
		@class.method_5(DateTime.Now);
		stream6_0.Write(array, 0, array.Length);
		stream6_0.Flush();
	}

	private void method_12(ArrayList arrayList_0, Stream6 stream6_0)
	{
		XmlTextWriter xmlTextWriter = Class1522.smethod_1("META-INF/manifest.xml", stream6_0);
		xmlTextWriter.WriteStartDocument();
		xmlTextWriter.WriteStartElement("manifest:manifest");
		xmlTextWriter.WriteAttributeString("xmlns", "manifest", null, "urn:oasis:names:tc:opendocument:xmlns:manifest:1.0");
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1504 @class = (Class1504)arrayList_0[i];
			xmlTextWriter.WriteStartElement("manifest:file-entry");
			xmlTextWriter.WriteAttributeString("manifest", "media-type", null, @class.method_0());
			xmlTextWriter.WriteAttributeString("manifest", "full-path", null, @class.method_1());
			xmlTextWriter.WriteEndElement();
		}
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndDocument();
		xmlTextWriter.Formatting = Formatting.Indented;
		xmlTextWriter.Flush();
	}

	private void method_13(ArrayList arrayList_0, Class1737 class1737_0, Font font_0)
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
