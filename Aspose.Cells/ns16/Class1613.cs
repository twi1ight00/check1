using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns1;
using ns2;
using ns22;

namespace ns16;

internal class Class1613
{
	private Class1547 class1547_0;

	private Class1548 class1548_0;

	private Class746 class746_0;

	private XmlDocument xmlDocument_0;

	private Hashtable hashtable_0;

	private int int_0;

	private ArrayList arrayList_0 = new ArrayList();

	internal Class1613(Class1548 class1548_1, Hashtable hashtable_1, Class746 class746_1, string string_0)
	{
		class1548_0 = class1548_1;
		class1547_0 = class1548_1.class1547_0;
		hashtable_0 = hashtable_1;
		class746_0 = class746_1;
		int_0 = class1547_0.workbook_0.Worksheets.method_75();
		xmlDocument_0 = smethod_0(class746_1, string_0);
	}

	internal static XmlDocument smethod_0(Class746 class746_1, string string_0)
	{
		XmlDocument xmlDocument = null;
		Class744 @class = class746_1.method_38(string_0);
		int num = (int)@class.Size;
		Stream stream = class746_1.method_39(@class);
		byte[] array = new byte[num];
		stream.Read(array, 0, num);
		int index = 0;
		int count = num;
		if (num > 3 && array[0] == 239)
		{
			index = 3;
			count = num - 3;
		}
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		string @string = uTF8Encoding.GetString(array, index, count);
		try
		{
			xmlDocument = Class1188.smethod_1(@string);
		}
		catch
		{
		}
		if (xmlDocument == null)
		{
			@string = @string.Replace("<br>", "<br></br>");
			@string = @string.Replace("&nbsp;", " ");
			int num2 = @string.IndexOf("<v:fill ");
			int num3 = 0;
			while (num2 != -1)
			{
				num3 = @string.IndexOf("/>", num2 + 8);
				if (num3 == -1)
				{
					break;
				}
				int num4 = @string.IndexOf("o:relid=\"rId", num2 + 8);
				if (num4 != -1 && num4 < num3)
				{
					int num5 = @string.IndexOf("\"", num4 + 12);
					if (num5 != -1 && num5 < num3)
					{
						int num6 = @string.IndexOf("o:title", num5 + 1);
						if (num6 != -1 && num6 < num3)
						{
							@string = @string.Substring(0, num5 + 2) + @string.Substring(num6);
						}
					}
				}
				num2 = @string.IndexOf("<v:fill ", num2 + 8);
			}
			try
			{
				xmlDocument = Class1188.smethod_1(@string);
			}
			catch
			{
			}
		}
		stream.Close();
		return xmlDocument;
	}

	internal void Read()
	{
		if (xmlDocument_0 == null)
		{
			return;
		}
		XmlElement documentElement = xmlDocument_0.DocumentElement;
		IEnumerator enumerator = documentElement.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			if (current is XmlElement)
			{
				XmlElement xmlElement = (XmlElement)current;
				if (xmlElement.LocalName == "shape")
				{
					method_0(xmlElement);
				}
				else
				{
					method_1(xmlElement);
				}
			}
		}
	}

	private void method_0(XmlElement xmlElement_0)
	{
		Shape shape = method_3(xmlElement_0);
		if (shape == null)
		{
			method_1(xmlElement_0);
			if (shape == null)
			{
				return;
			}
		}
		method_2(xmlElement_0, shape);
		method_9(xmlElement_0, shape);
	}

	private void method_1(XmlElement xmlElement_0)
	{
		if (hashtable_0 == null)
		{
			return;
		}
		string outerXml = xmlElement_0.OuterXml;
		IDictionaryEnumerator enumerator = hashtable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string value = (string)enumerator.Key;
			if (outerXml.IndexOf(value) != -1 && !arrayList_0.Contains(enumerator.Value))
			{
				arrayList_0.Add(enumerator.Value);
			}
		}
	}

	private void method_2(XmlElement xmlElement_0, Shape shape_0)
	{
		string text = null;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		string text5 = null;
		foreach (XmlAttribute attribute in xmlElement_0.Attributes)
		{
			string localName = attribute.LocalName;
			string text6 = Class1618.smethod_8(attribute.Value);
			if (localName.Equals("id"))
			{
				shape_0.Name = text6;
				if (shape_0.MsoDrawingType != MsoDrawingType.Comment && shape_0.MsoDrawingType != MsoDrawingType.Picture)
				{
					class1548_0.worksheet_0.class1557_0.arrayList_7.Add(text6);
				}
				shape_0.class1556_0.string_0 = text6;
			}
			else if (localName.Equals("spid"))
			{
				shape_0.class1556_0.string_1 = text6;
			}
			else if (localName.Equals("alt"))
			{
				shape_0.AlternativeText = text6;
			}
			else if (localName.Equals("style"))
			{
				method_7(text6, shape_0);
			}
			else if (localName.Equals("href"))
			{
				shape_0.AddHyperlink(text6);
			}
			else if (localName.Equals("filled"))
			{
				if (text6.Equals("f"))
				{
					shape_0.FillFormat.IsVisible = false;
				}
				else if (text6.Equals("t"))
				{
					shape_0.FillFormat.IsVisible = true;
				}
				text4 = text6;
			}
			else if (localName.Equals("fillcolor"))
			{
				text = text6;
			}
			else if (localName.Equals("stroked"))
			{
				if (text6.Equals("f"))
				{
					shape_0.LineFormat.IsVisible = false;
				}
				else if (text6.Equals("t"))
				{
					shape_0.LineFormat.IsVisible = true;
				}
				text5 = text6;
			}
			else if (localName.Equals("strokecolor"))
			{
				text2 = text6;
			}
			else if (localName.Equals("strokeweight"))
			{
				text3 = text6;
			}
			else if (localName.Equals("insetmode") && text6 == "auto")
			{
				shape_0.bool_1 = true;
			}
		}
		if (shape_0.class1556_0.string_1 != null)
		{
			class1548_0.worksheet_0.class1557_0.arrayList_8.Add(shape_0.class1556_0.string_1);
		}
		else if (shape_0.class1556_0.string_0 != null)
		{
			class1548_0.worksheet_0.class1557_0.arrayList_8.Add(shape_0.class1556_0.string_0);
		}
		if (shape_0.MsoDrawingType == MsoDrawingType.CheckBox || shape_0.MsoDrawingType == MsoDrawingType.RadioButton)
		{
			if (text4 == null)
			{
				shape_0.FillFormat.IsVisible = true;
			}
			if (text5 == null)
			{
				shape_0.LineFormat.IsVisible = true;
			}
		}
		if (shape_0.MsoDrawingType == MsoDrawingType.OleObject && text5 == null)
		{
			shape_0.LineFormat.IsVisible = false;
		}
		if (shape_0.FillFormat.IsVisible && text != null && text.IndexOf("window") == -1)
		{
			Color color = GetColor(text, class1547_0.workbook_0.Worksheets);
			if (!color.IsEmpty)
			{
				shape_0.Fill.Type = FillType.Solid;
				shape_0.Fill.SolidFill.Color = color;
			}
		}
		if (!shape_0.LineFormat.IsVisible)
		{
			return;
		}
		if (text2 != null && text2.IndexOf("window") == -1)
		{
			Color color2 = GetColor(text2, class1547_0.workbook_0.Worksheets);
			if (!color2.IsEmpty)
			{
				shape_0.LineFormat.ForeColor = color2;
			}
		}
		if (text3 != null)
		{
			shape_0.LineFormat.Weight = smethod_1(text3, "pt", int_0);
		}
	}

	private Shape method_3(XmlElement xmlElement_0)
	{
		Shape shape = null;
		ShapeCollection shapes = class1548_0.worksheet_0.Shapes;
		XmlElement xmlElement = Class1618.smethod_173(xmlElement_0, "ClientData");
		if (xmlElement != null)
		{
			string value = Class1618.smethod_172(xmlElement, "ObjectType");
			if ("Note".Equals(value))
			{
				XmlElement xmlElement2 = Class1618.smethod_173(xmlElement, "Row");
				XmlElement xmlElement3 = Class1618.smethod_173(xmlElement, "Column");
				if (xmlElement2 != null && xmlElement3 != null)
				{
					string text = Class1618.smethod_8(Class1188.smethod_13(xmlElement2));
					string text2 = Class1618.smethod_8(Class1188.smethod_13(xmlElement3));
					if (text != null && text2 != null)
					{
						int num = Class1618.smethod_87(text);
						int num2 = Class1618.smethod_87(text2);
						CommentCollection comments = class1548_0.worksheet_0.Comments;
						int count = comments.Count;
						for (int i = 0; i < count; i++)
						{
							Comment comment = comments[i];
							if (comment.Row == num && comment.Column == num2)
							{
								shape = comment.CommentShape;
								break;
							}
						}
					}
				}
			}
			else if ("Pict".Equals(value))
			{
				shape = method_6(xmlElement_0);
				if (shape == null)
				{
					shape = method_4(xmlElement_0);
				}
			}
			else if ("Checkbox".Equals(value))
			{
				shape = shapes.AddCheckBox(0, 0, 0, 0, 0, 0);
			}
			else if ("Label".Equals(value))
			{
				shape = shapes.AddLabel(0, 0, 0, 0, 0, 0);
			}
			else if ("Button".Equals(value))
			{
				shape = shapes.AddButton(0, 0, 0, 0, 0, 0);
			}
			else if ("Drop".Equals(value))
			{
				shape = shapes.AddComboBox(0, 0, 0, 0, 0, 0);
			}
			else if ("Spin".Equals(value))
			{
				shape = shapes.AddSpinner(0, 0, 0, 0, 0, 0);
			}
			else if ("List".Equals(value))
			{
				shape = shapes.AddListBox(0, 0, 0, 0, 0, 0);
			}
			else if ("Radio".Equals(value))
			{
				shape = shapes.AddRadioButton(0, 0, 0, 0, 0, 0);
			}
			else if ("GBox".Equals(value))
			{
				shape = shapes.AddGroupBox(0, 0, 0, 0, 0, 0);
			}
			else if ("Scroll".Equals(value))
			{
				shape = shapes.AddScrollBar(0, 0, 0, 0, 0, 0);
			}
		}
		if (shape != null)
		{
			shape.class1556_0 = new Class1556();
		}
		return shape;
	}

	private Shape method_4(XmlElement xmlElement_0)
	{
		string text = null;
		string text2 = null;
		int num = -1;
		int num2 = -1;
		foreach (XmlAttribute attribute in xmlElement_0.Attributes)
		{
			string localName = attribute.LocalName;
			string value = attribute.Value;
			if (localName.Equals("id"))
			{
				text = Class1618.smethod_8(value);
				num = Class1618.smethod_145(value);
			}
			else if (localName.Equals("spid"))
			{
				text2 = Class1618.smethod_8(value);
				num2 = Class1618.smethod_145(value);
			}
		}
		if (num == -1 && num2 == -1)
		{
			return null;
		}
		string string_ = null;
		XmlElement xmlElement = Class1618.smethod_173(xmlElement_0, "imagedata");
		if (xmlElement != null)
		{
			string_ = Class1618.smethod_172(xmlElement, "relid");
		}
		byte[] array = method_5(string_);
		if (array != null)
		{
			Shape result = class1548_0.worksheet_0.Shapes.method_6(MsoDrawingType.Picture, PlacementType.FreeFloating, 0, 0, 0, 0, 0, 0, 0, 0, array);
			class1548_0.worksheet_0.class1557_0.arrayList_9.Add(text + "|" + text2);
			return result;
		}
		return null;
	}

	private byte[] method_5(string string_0)
	{
		byte[] array = null;
		if (string_0 != null)
		{
			Class1564 @class = Class1608.smethod_5(hashtable_0, string_0);
			if (@class != null)
			{
				string string_ = "xl" + @class.string_3.Substring(2);
				Class744 class2 = class746_0.method_38(string_);
				if (class2 == null)
				{
					return null;
				}
				Stream stream = class746_0.method_39(class2);
				array = new byte[(int)class2.Size];
				stream.Read(array, 0, (int)class2.Size);
			}
		}
		return array;
	}

	private OleObject method_6(XmlElement xmlElement_0)
	{
		int num = -1;
		int num2 = -1;
		foreach (XmlAttribute attribute in xmlElement_0.Attributes)
		{
			string localName = attribute.LocalName;
			string value = attribute.Value;
			if (localName.Equals("id"))
			{
				num = Class1618.smethod_145(value);
			}
			else if (localName.Equals("spid"))
			{
				num2 = Class1618.smethod_145(value);
			}
		}
		if (num == -1 && num2 == -1)
		{
			return null;
		}
		string text = null;
		XmlElement xmlElement = Class1618.smethod_173(xmlElement_0, "imagedata");
		if (xmlElement != null)
		{
			text = Class1618.smethod_172(xmlElement, "relid");
		}
		Class1552 @class = null;
		ArrayList arrayList_ = class1548_0.arrayList_1;
		int count = arrayList_.Count;
		for (int i = 0; i < count; i++)
		{
			Class1552 class2 = (Class1552)arrayList_[i];
			if (class2.string_1 == Class1618.smethod_80(num) || class2.string_1 == Class1618.smethod_80(num2))
			{
				@class = class2;
				break;
			}
		}
		if (@class == null)
		{
			return null;
		}
		byte[] array = null;
		string text2 = null;
		if (text != null)
		{
			Class1564 class3 = Class1608.smethod_5(hashtable_0, text);
			if (class3 != null)
			{
				text2 = "xl" + class3.string_3.Substring(2);
				Class744 class4 = class746_0.method_38(text2);
				if (class4 == null)
				{
					return null;
				}
				Stream stream = class746_0.method_39(class4);
				array = new byte[(int)class4.Size];
				stream.Read(array, 0, (int)class4.Size);
			}
		}
		int index = class1548_0.worksheet_0.OleObjects.Add(1, 1, 1, 1, array);
		OleObject oleObject = class1548_0.worksheet_0.OleObjects[index];
		if (@class.string_2 != null)
		{
			string string_ = @class.string_2;
			string_ = "xl" + string_.Substring(2);
			Class744 class5 = class746_0.method_38(string_);
			if (class5 == null)
			{
				return null;
			}
			Stream stream2 = class746_0.method_39(class5);
			byte[] array2 = new byte[(int)class5.Size];
			stream2.Read(array2, 0, (int)class5.Size);
			oleObject.method_81(array2);
			if (!oleObject.method_85())
			{
				oleObject.method_88(Path.GetFileName(string_), bool_6: true, bool_7: true);
			}
			class1547_0.workbook_0.class1558_0.arrayList_1.Add(Path.GetFileName(string_));
		}
		if (@class.string_4 != null)
		{
			oleObject.method_92(@class.string_4);
			if (@class.string_5 == "OLEUPDATE_ALWAYS")
			{
				oleObject.method_96(bool_6: true);
			}
			else if (@class.string_5 == "OLEUPDATE_ONCALL")
			{
				oleObject.method_96(bool_6: false);
			}
		}
		else
		{
			oleObject.method_96(@class.bool_1);
			oleObject.method_73(@class.bool_0);
			if (@class.byte_0 != null)
			{
				oleObject.method_94(@class.byte_0);
			}
		}
		if (@class.string_0 != null)
		{
			oleObject.ProgID = @class.string_0;
		}
		if (@class.string_6 == "DVASPECT_ICON")
		{
			oleObject.DisplayAsIcon = true;
		}
		arrayList_.Remove(@class);
		if (text2 != null)
		{
			class1547_0.workbook_0.class1558_0.arrayList_2.Add(Path.GetFileName(text2));
		}
		return oleObject;
	}

	private void method_7(string string_0, Shape shape_0)
	{
		short num = -1;
		short num2 = -1;
		short num3 = 0;
		short num4 = 0;
		string[] array = string_0.Split(';');
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Split(':');
			if (array2.Length != 2)
			{
				continue;
			}
			string value = array2[0].Trim();
			if ("margin-left".Equals(value))
			{
				num = (short)smethod_1(array2[1], "px", int_0);
			}
			else if ("margin-top".Equals(value))
			{
				num2 = (short)smethod_1(array2[1], "px", int_0);
			}
			else if ("width".Equals(value))
			{
				num3 = (short)smethod_1(array2[1], "px", int_0);
			}
			else if ("height".Equals(value))
			{
				num4 = (short)smethod_1(array2[1], "px", int_0);
			}
			else if ("z-index".Equals(value))
			{
				try
				{
					shape_0.class1556_0.int_0 = Class1618.smethod_87(array2[1]);
				}
				catch
				{
				}
			}
			else
			{
				if (!"visibility".Equals(value))
				{
					continue;
				}
				if (shape_0.MsoDrawingType == MsoDrawingType.Comment)
				{
					if (array2[1].Trim().Equals("visible"))
					{
						((CommentShape)shape_0).method_69().IsVisible = true;
					}
				}
				else if (array2[1].Trim().Equals("hidden"))
				{
					shape_0.IsHidden = true;
				}
			}
		}
		if (num >= 0 && num2 >= 0)
		{
			shape_0.method_17(num, num2, num3, num4);
			return;
		}
		if (num3 > 0)
		{
			shape_0.Width = num3;
		}
		if (num4 > 0)
		{
			shape_0.Height = num4;
		}
	}

	internal static double smethod_1(string string_0, string string_1, int int_1)
	{
		string value = "px";
		if (string_0.Length > 2)
		{
			string text = string_0.Substring(string_0.Length - 2);
			char c = text[0];
			char c2 = text[1];
			if (c < '0' || c > '9' || c2 < '0' || c2 > '9')
			{
				value = text;
				string_0 = string_0.Substring(0, string_0.Length - 2);
			}
		}
		double num = Class1618.smethod_85(string_0);
		if ("px".Equals(value))
		{
			num = num * 72.0 / (double)int_1;
		}
		else if (!"pt".Equals(value))
		{
			if ("in".Equals(value))
			{
				num *= 72.0;
			}
			else if ("mm".Equals(value))
			{
				num = num / 10.0 / 2.54 * 72.0;
			}
			else if ("cm".Equals(value))
			{
				num = num / 2.54 * 72.0;
			}
		}
		if ("px".Equals(string_1))
		{
			num = num * (double)int_1 / 72.0;
		}
		else if ("in".Equals(string_1))
		{
			num /= 72.0;
		}
		else if ("mm".Equals(string_1))
		{
			num = num / 72.0 * 2.54 * 10.0;
		}
		else if ("cm".Equals(string_1))
		{
			num = num / 72.0 * 2.54;
		}
		return num;
	}

	private void method_8(XmlElement xmlElement_0, Shape shape_0)
	{
		foreach (XmlAttribute attribute in xmlElement_0.Attributes)
		{
			string localName = attribute.LocalName;
			string string_ = Class1618.smethod_8(attribute.Value);
			if (localName.Equals("opacity"))
			{
				if (!shape_0.FillFormat.IsVisible)
				{
					continue;
				}
				double num = smethod_2(string_);
				if (num > -1.0)
				{
					if (shape_0.Fill.Type == FillType.Automatic)
					{
						shape_0.Fill.Type = FillType.Solid;
					}
					shape_0.FillFormat.method_1(num);
				}
			}
			else if (localName.Equals("relid"))
			{
				byte[] array = method_5(string_);
				if (array != null)
				{
					shape_0.FillFormat.ImageData = array;
				}
			}
		}
	}

	private static double smethod_2(string string_0)
	{
		try
		{
			if (string_0.EndsWith("f"))
			{
				string_0 = string_0.Substring(0, string_0.Length - 1);
				int num = Class1618.smethod_87(string_0);
				return (double)num / 65536.0;
			}
			return Class1618.smethod_85(string_0);
		}
		catch
		{
			return -1.0;
		}
	}

	private void method_9(XmlElement xmlElement_0, Shape shape_0)
	{
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (childNodes[i] is XmlElement)
			{
				XmlElement xmlElement = (XmlElement)childNodes[i];
				string localName = xmlElement.LocalName;
				if (localName.Equals("fill"))
				{
					method_8(xmlElement, shape_0);
				}
				else if (localName.Equals("stroke"))
				{
					method_25(xmlElement, shape_0);
				}
				else if (localName.Equals("imagedata"))
				{
					method_10(xmlElement, shape_0);
				}
				else if (localName.Equals("ClientData"))
				{
					method_13(xmlElement, shape_0);
				}
				else if (localName.Equals("textbox"))
				{
					XmlElement xmlElement_ = Class1618.smethod_173(xmlElement_0, "ClientData");
					method_11(xmlElement, xmlElement_, shape_0);
				}
			}
		}
	}

	private void method_10(XmlElement xmlElement_0, Shape shape_0)
	{
		foreach (XmlAttribute attribute in xmlElement_0.Attributes)
		{
			string name = attribute.Name;
			string string_ = Class1618.smethod_8(attribute.Value);
			if (name.Equals("cropleft"))
			{
				shape_0.FormatPicture.LeftCrop = Class1606.smethod_1(string_);
			}
			else if (name.Equals("cropright"))
			{
				shape_0.FormatPicture.RightCrop = Class1606.smethod_1(string_);
			}
			else if (name.Equals("croptop"))
			{
				shape_0.FormatPicture.TopCrop = Class1606.smethod_1(string_);
			}
			else if (name.Equals("cropbottom"))
			{
				shape_0.FormatPicture.BottomCrop = Class1606.smethod_1(string_);
			}
		}
	}

	private void method_11(XmlElement xmlElement_0, XmlElement xmlElement_1, Shape shape_0)
	{
		Class1737 @class = null;
		if (shape_0.MsoDrawingType == MsoDrawingType.CheckBox)
		{
			@class = ((CheckBox)shape_0).method_63();
		}
		else if (shape_0.MsoDrawingType == MsoDrawingType.Label)
		{
			@class = ((Label)shape_0).method_63();
		}
		else if (shape_0.MsoDrawingType == MsoDrawingType.Button)
		{
			@class = ((Button)shape_0).method_63();
		}
		else if (shape_0.MsoDrawingType == MsoDrawingType.RadioButton)
		{
			@class = ((RadioButton)shape_0).method_63();
		}
		else
		{
			if (shape_0.MsoDrawingType != MsoDrawingType.GroupBox)
			{
				return;
			}
			@class = ((GroupBox)shape_0).method_63();
		}
		if (xmlElement_1 != null)
		{
			XmlElement xmlElement = Class1618.smethod_173(xmlElement_1, "TextVAlign");
			if (xmlElement != null)
			{
				string string_ = Class1618.smethod_8(Class1188.smethod_13(xmlElement));
				@class.TextVerticalAlignment = Class1618.smethod_158(string_);
			}
			XmlElement xmlElement2 = Class1618.smethod_173(xmlElement_1, "TextHAlign");
			if (xmlElement2 != null)
			{
				string string_2 = Class1618.smethod_8(Class1188.smethod_13(xmlElement2));
				@class.TextHorizontalAlignment = Class1618.smethod_158(string_2);
			}
		}
		XmlElement xmlElement3 = Class1618.smethod_173(xmlElement_0, "div");
		if (xmlElement3 != null)
		{
			int num = 0;
			StringBuilder stringBuilder = new StringBuilder();
			XmlNodeList childNodes = xmlElement3.ChildNodes;
			for (int i = 0; i < childNodes.Count; i++)
			{
				if (!(childNodes[i] is XmlElement))
				{
					continue;
				}
				XmlElement xmlElement4 = (XmlElement)childNodes[i];
				string localName = xmlElement4.LocalName;
				if (localName.Equals("font"))
				{
					Class1565 class2 = method_12(xmlElement4);
					stringBuilder.Append(class2.string_0);
					int length = class2.string_0.Length;
					FontSetting fontSetting = @class.Characters(num, length);
					if (class2.class1542_0 != null)
					{
						class2.class1542_0.method_19(fontSetting.Font);
					}
					num += length;
				}
			}
			@class.method_4(stringBuilder.ToString());
		}
		string text = Class1618.smethod_172(xmlElement_0, "inset");
		if (text != null)
		{
			string[] array = text.Split(',');
			if (array.Length == 4)
			{
				MsoTextFrame textFrame = shape_0.TextFrame;
				textFrame.LeftMarginPt = smethod_1(array[0], "pt", shape_0.method_25().method_75());
				textFrame.TopMarginPt = smethod_1(array[1], "pt", shape_0.method_25().method_75());
				textFrame.RightMarginPt = smethod_1(array[2], "pt", shape_0.method_25().method_75());
				textFrame.BottomMarginPt = smethod_1(array[3], "pt", shape_0.method_25().method_75());
				textFrame.IsAutoMargin = false;
			}
		}
		string text2 = Class1618.smethod_172(xmlElement_0, "style");
		if (text2 != null && text2.IndexOf("mso-fit-shape-to-text:t") != -1)
		{
			shape_0.TextFrame.AutoSize = true;
		}
	}

	[Attribute0(true)]
	private Class1565 method_12(XmlElement xmlElement_0)
	{
		Class1565 @class = new Class1565();
		@class.class1542_0 = new Class1542();
		string text = Class1618.smethod_172(xmlElement_0, "face");
		if (text != null)
		{
			@class.class1542_0.Name = text;
		}
		string text2 = Class1618.smethod_172(xmlElement_0, "size");
		if (text2 != null)
		{
			@class.class1542_0.Size = (int)(Class1618.smethod_85(text2) / 20.0);
		}
		string text3 = Class1618.smethod_172(xmlElement_0, "color");
		if (text3 != null && text3 != "auto")
		{
			try
			{
				if (text3.StartsWith("#"))
				{
					int num = int.Parse(text3.Substring(1), NumberStyles.HexNumber);
					InternalColor internalColor = new InternalColor(bool_0: false);
					internalColor.SetColor(ColorType.RGB, num);
					@class.class1542_0.method_11(internalColor);
				}
				else
				{
					int num2 = Class1618.smethod_87(text3);
					InternalColor internalColor2 = new InternalColor(bool_0: false);
					internalColor2.SetColor(ColorType.RGB, class1547_0.workbook_0.Worksheets.method_24().method_7(num2).ToArgb());
					@class.class1542_0.method_11(internalColor2);
				}
			}
			catch
			{
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		smethod_3(stringBuilder, xmlElement_0);
		@class.string_0 = stringBuilder.ToString();
		return @class;
	}

	private static void smethod_3(StringBuilder stringBuilder_0, XmlElement xmlElement_0)
	{
		IEnumerator enumerator = xmlElement_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			XmlNode xmlNode = (XmlNode)enumerator.Current;
			switch (xmlNode.NodeType)
			{
			case XmlNodeType.Element:
			{
				string localName;
				if ((localName = xmlNode.LocalName) != null && localName == "br")
				{
					stringBuilder_0.Append("\r\n");
				}
				else
				{
					smethod_3(stringBuilder_0, (XmlElement)xmlNode);
				}
				break;
			}
			case XmlNodeType.Text:
			case XmlNodeType.SignificantWhitespace:
			{
				string value = xmlNode.Value;
				if (value == null)
				{
					break;
				}
				char[] array = value.ToCharArray();
				for (int i = 0; i < array.Length; i++)
				{
					switch (array[i])
					{
					default:
						stringBuilder_0.Append(array[i]);
						break;
					case ' ':
					case '\u00a0':
					{
						stringBuilder_0.Append(' ');
						bool flag = true;
						i++;
						while (i < array.Length && flag)
						{
							switch (array[i])
							{
							default:
								stringBuilder_0.Append(array[i]);
								flag = false;
								break;
							case '\n':
							case '\r':
							case ' ':
							case '\u00a0':
								i++;
								break;
							}
						}
						break;
					}
					case '\n':
					case '\r':
						break;
					}
				}
				break;
			}
			}
		}
	}

	private void method_13(XmlElement xmlElement_0, Shape shape_0)
	{
		method_23(xmlElement_0, shape_0);
		switch (shape_0.MsoDrawingType)
		{
		case MsoDrawingType.Button:
			method_21(xmlElement_0, (Button)shape_0);
			break;
		case MsoDrawingType.CheckBox:
			method_24(xmlElement_0, (CheckBox)shape_0);
			break;
		case MsoDrawingType.RadioButton:
			method_16(xmlElement_0, (RadioButton)shape_0);
			break;
		case MsoDrawingType.Label:
			method_22(xmlElement_0, (Label)shape_0);
			break;
		case MsoDrawingType.Spinner:
			method_18(xmlElement_0, (Spinner)shape_0);
			break;
		case MsoDrawingType.ScrollBar:
			method_19(xmlElement_0, (ScrollBar)shape_0);
			break;
		case MsoDrawingType.ListBox:
			method_17(xmlElement_0, (ListBox)shape_0);
			break;
		case MsoDrawingType.GroupBox:
			method_15(xmlElement_0, (GroupBox)shape_0);
			break;
		case MsoDrawingType.ComboBox:
			method_20(xmlElement_0, (ComboBox)shape_0);
			break;
		case MsoDrawingType.OleObject:
			method_14(xmlElement_0, (OleObject)shape_0);
			break;
		case MsoDrawingType.Picture:
		case MsoDrawingType.Polygon:
		case (MsoDrawingType)10:
		case (MsoDrawingType)13:
		case MsoDrawingType.DialogBox:
		case (MsoDrawingType)21:
		case (MsoDrawingType)22:
		case (MsoDrawingType)23:
			break;
		}
	}

	private void method_14(XmlElement xmlElement_0, OleObject oleObject_0)
	{
		bool isAutoSize = false;
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (childNodes[i] is XmlElement)
			{
				XmlElement xmlElement = (XmlElement)childNodes[i];
				string localName = xmlElement.LocalName;
				string text = Class1618.smethod_8(Class1188.smethod_13(xmlElement));
				if (localName.Equals("AutoPict"))
				{
					isAutoSize = text == null || text == "" || Class1618.smethod_201(text);
				}
			}
		}
		oleObject_0.IsAutoSize = isAutoSize;
	}

	private void method_15(XmlElement xmlElement_0, GroupBox groupBox_0)
	{
		bool shadow = true;
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			string localName = xmlElement.LocalName;
			string text = Class1618.smethod_8(Class1188.smethod_13(xmlElement));
			if (!localName.Equals("NoThreeD") && !localName.Equals("NoThreeD2"))
			{
				if (localName.Equals("FmlaTxbx"))
				{
					groupBox_0.LinkedCell = text;
				}
			}
			else if (!Class1618.smethod_201(text))
			{
				shadow = false;
			}
		}
		groupBox_0.Shadow = shadow;
	}

	private void method_16(XmlElement xmlElement_0, RadioButton radioButton_0)
	{
		bool shadow = true;
		bool bool_ = false;
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			string localName = xmlElement.LocalName;
			string string_ = Class1618.smethod_8(Class1188.smethod_13(xmlElement));
			if (!localName.Equals("NoThreeD") && !localName.Equals("NoThreeD2"))
			{
				if (localName.Equals("FmlaLink"))
				{
					radioButton_0.method_61(string_);
				}
				else if (localName.Equals("Checked") && Class1618.smethod_201(string_))
				{
					bool_ = true;
				}
			}
			else if (!Class1618.smethod_201(string_))
			{
				shadow = false;
			}
		}
		radioButton_0.Shadow = shadow;
		radioButton_0.method_69(bool_);
	}

	private void method_17(XmlElement xmlElement_0, ListBox listBox_0)
	{
		bool shadow = true;
		bool flag = false;
		int num = -1;
		string text = null;
		string text2 = null;
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			string localName = xmlElement.LocalName;
			string text3 = Class1618.smethod_8(Class1188.smethod_13(xmlElement));
			if (!localName.Equals("NoThreeD") && !localName.Equals("NoThreeD2"))
			{
				if (localName.Equals("FmlaLink"))
				{
					text2 = text3;
				}
				else if (localName.Equals("Val"))
				{
					listBox_0.method_75(Class1618.smethod_87(text3));
				}
				else if (localName.Equals("Min"))
				{
					listBox_0.method_77(Class1618.smethod_87(text3));
				}
				else if (localName.Equals("Max"))
				{
					listBox_0.method_79(Class1618.smethod_87(text3));
				}
				else if (localName.Equals("Inc"))
				{
					listBox_0.IncrementalChange = Class1618.smethod_87(text3);
				}
				else if (localName.Equals("Page"))
				{
					listBox_0.PageChange = Class1618.smethod_87(text3);
				}
				else if (localName.Equals("FmlaRange"))
				{
					if (text3.IndexOf("#REF") == -1)
					{
						listBox_0.InputRange = text3;
						flag = true;
					}
				}
				else if (localName.Equals("Sel"))
				{
					num = Class1618.smethod_87(text3);
				}
				else if (localName.Equals("MultiSel"))
				{
					text = text3;
				}
				else if (localName.Equals("SelType"))
				{
					listBox_0.SelectionType = Class1618.smethod_200(text3);
				}
			}
			else if (!Class1618.smethod_201(text3))
			{
				shadow = false;
			}
		}
		listBox_0.Shadow = shadow;
		if (!flag)
		{
			return;
		}
		switch (listBox_0.SelectionType)
		{
		case SelectionType.Single:
			if (num > 0)
			{
				listBox_0.SelectedIndex = num - 1;
			}
			break;
		case SelectionType.Multi:
			if (text != null)
			{
				string[] array2 = text.Split(',');
				ArrayList arrayList2 = new ArrayList(array2.Length);
				for (int k = 0; k < array2.Length; k++)
				{
					arrayList2.Add((ushort)(ushort.Parse(array2[k].Trim(), CultureInfo.InvariantCulture) - 1));
				}
				listBox_0.method_73(arrayList2);
			}
			break;
		case SelectionType.Extend:
			if (num > 0)
			{
				listBox_0.SelectedIndex = num - 1;
			}
			if (text != null)
			{
				string[] array = text.Split(',');
				ArrayList arrayList = new ArrayList(array.Length);
				for (int j = 0; j < array.Length; j++)
				{
					arrayList.Add((ushort)(ushort.Parse(array[j].Trim(), CultureInfo.InvariantCulture) - 1));
				}
				listBox_0.method_73(arrayList);
			}
			break;
		}
		if (text2 != null)
		{
			listBox_0.LinkedCell = text2;
		}
	}

	private void method_18(XmlElement xmlElement_0, Spinner spinner_0)
	{
		bool shadow = true;
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			string localName = xmlElement.LocalName;
			string text = Class1618.smethod_8(Class1188.smethod_13(xmlElement));
			if (!localName.Equals("NoThreeD") && !localName.Equals("NoThreeD2"))
			{
				if (localName.Equals("FmlaLink"))
				{
					spinner_0.LinkedCell = text;
				}
				else if (localName.Equals("Val"))
				{
					spinner_0.CurrentValue = Class1618.smethod_87(text);
				}
				else if (localName.Equals("Min"))
				{
					spinner_0.Min = Class1618.smethod_87(text);
				}
				else if (localName.Equals("Max"))
				{
					spinner_0.Max = Class1618.smethod_87(text);
				}
				else if (localName.Equals("Inc"))
				{
					spinner_0.IncrementalChange = Class1618.smethod_87(text);
				}
				else if (localName.Equals("Page"))
				{
					spinner_0.PageChange = Class1618.smethod_87(text);
				}
			}
			else if (!Class1618.smethod_201(text))
			{
				shadow = false;
			}
		}
		spinner_0.Shadow = shadow;
	}

	private void method_19(XmlElement xmlElement_0, ScrollBar scrollBar_0)
	{
		bool shadow = true;
		string text = null;
		string text2 = null;
		string text3 = null;
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			string localName = xmlElement.LocalName;
			string text4 = Class1618.smethod_8(Class1188.smethod_13(xmlElement));
			if (!localName.Equals("NoThreeD") && !localName.Equals("NoThreeD2"))
			{
				if (localName.Equals("FmlaLink"))
				{
					scrollBar_0.LinkedCell = text4;
				}
				else if (localName.Equals("Val"))
				{
					text = text4;
				}
				else if (localName.Equals("Min"))
				{
					text2 = text4;
				}
				else if (localName.Equals("Max"))
				{
					text3 = text4;
				}
				else if (localName.Equals("Inc"))
				{
					scrollBar_0.IncrementalChange = Class1618.smethod_87(text4);
				}
				else if (localName.Equals("Page"))
				{
					scrollBar_0.PageChange = Class1618.smethod_87(text4);
				}
				else if (localName.Equals("Horiz"))
				{
					scrollBar_0.IsHorizontal = true;
				}
			}
			else if (!Class1618.smethod_201(text4))
			{
				shadow = false;
			}
		}
		scrollBar_0.Shadow = shadow;
		if (text3 != null)
		{
			scrollBar_0.Max = Class1618.smethod_87(text3);
		}
		if (text2 != null)
		{
			scrollBar_0.Min = Class1618.smethod_87(text2);
		}
		if (text != null)
		{
			scrollBar_0.CurrentValue = Class1618.smethod_87(text);
		}
	}

	private void method_20(XmlElement xmlElement_0, ComboBox comboBox_0)
	{
		bool shadow = true;
		bool flag = false;
		int num = -1;
		string text = null;
		ArrayList arrayList = new ArrayList();
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			string localName = xmlElement.LocalName;
			string text2 = Class1618.smethod_8(Class1188.smethod_13(xmlElement));
			if (!localName.Equals("NoThreeD") && !localName.Equals("NoThreeD2"))
			{
				if (localName.Equals("FmlaLink"))
				{
					text = text2;
				}
				else if (localName.Equals("FmlaRange"))
				{
					if (text2.IndexOf("#REF") == -1)
					{
						comboBox_0.InputRange = text2;
						flag = true;
					}
				}
				else if (localName.Equals("Sel"))
				{
					num = Class1618.smethod_87(text2);
				}
				else if (localName.Equals("DropLines"))
				{
					comboBox_0.DropDownLines = Class1618.smethod_87(text2);
				}
				else if (localName.Equals("ListItem"))
				{
					arrayList.Add(text2);
				}
			}
			else if (!Class1618.smethod_201(text2))
			{
				shadow = false;
			}
		}
		comboBox_0.Shadow = shadow;
		if (flag && num > 0)
		{
			comboBox_0.method_73(num - 1);
		}
		int count = arrayList.Count;
		if (count > 0)
		{
			comboBox_0.string_4 = new string[count];
			for (int j = 0; j < count; j++)
			{
				string text3 = (string)arrayList[j];
				comboBox_0.string_4[j] = text3;
			}
			if (num > 0)
			{
				comboBox_0.method_73(num - 1);
			}
		}
		if (text != null)
		{
			comboBox_0.LinkedCell = text;
		}
	}

	private void method_21(XmlElement xmlElement_0, Button button_0)
	{
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (childNodes[i] is XmlElement)
			{
				XmlElement xmlElement = (XmlElement)childNodes[i];
				string localName = xmlElement.LocalName;
				string linkedCell = Class1618.smethod_8(Class1188.smethod_13(xmlElement));
				if (localName.Equals("FmlaTxbx"))
				{
					button_0.LinkedCell = linkedCell;
				}
			}
		}
	}

	private void method_22(XmlElement xmlElement_0, Label label_0)
	{
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (childNodes[i] is XmlElement)
			{
				XmlElement xmlElement = (XmlElement)childNodes[i];
				string localName = xmlElement.LocalName;
				string linkedCell = Class1618.smethod_8(Class1188.smethod_13(xmlElement));
				if (localName.Equals("FmlaLink"))
				{
					label_0.LinkedCell = linkedCell;
				}
			}
		}
	}

	private void method_23(XmlElement xmlElement_0, Shape shape_0)
	{
		bool flag = true;
		bool flag2 = true;
		string[] array = null;
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			string localName = xmlElement.LocalName;
			string text = Class1188.smethod_13(xmlElement).Trim();
			if (localName.Equals("Anchor"))
			{
				array = text.Split(',');
			}
			else if (localName.Equals("MoveWithCells"))
			{
				flag = text != null && !(text == "") && !Class1618.smethod_201(text);
			}
			else if (localName.Equals("SizeWithCells"))
			{
				flag2 = text != null && !(text == "") && !Class1618.smethod_201(text);
			}
			else if (localName.Equals("Locked"))
			{
				if ("False".Equals(text))
				{
					shape_0.IsLocked = false;
				}
			}
			else if (localName.Equals("PrintObject"))
			{
				if ("False".Equals(text))
				{
					shape_0.IsPrintable = false;
				}
			}
			else if (localName.Equals("FmlaMacro"))
			{
				shape_0.method_1(text);
			}
			else if (localName.Equals("FmlaPict"))
			{
				shape_0.method_66(text);
			}
		}
		if (shape_0.MsoDrawingType == MsoDrawingType.Comment)
		{
			return;
		}
		if (flag)
		{
			if (flag2)
			{
				shape_0.Placement = PlacementType.MoveAndSize;
			}
			else
			{
				shape_0.Placement = PlacementType.Move;
			}
		}
		else if (flag2)
		{
			shape_0.Placement = PlacementType.MoveAndSize;
		}
		else
		{
			shape_0.Placement = PlacementType.FreeFloating;
		}
		shape_0.method_22(Class1618.smethod_87(array[2]), Class1618.smethod_87(array[3]), Class1618.smethod_87(array[0]), Class1618.smethod_87(array[1]), Class1618.smethod_87(array[6]), Class1618.smethod_87(array[7]), Class1618.smethod_87(array[4]), Class1618.smethod_87(array[5]));
	}

	private void method_24(XmlElement xmlElement_0, CheckBox checkBox_0)
	{
		bool shadow = true;
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			string localName = xmlElement.LocalName;
			string text = Class1618.smethod_8(Class1188.smethod_13(xmlElement));
			if (localName.Equals("Checked"))
			{
				if ("1".Equals(text))
				{
					checkBox_0.method_69(CheckValueType.Checked);
				}
				else if ("0".Equals(text))
				{
					checkBox_0.method_69(CheckValueType.UnChecked);
				}
				else if ("2".Equals(text))
				{
					checkBox_0.method_69(CheckValueType.Mixed);
				}
			}
			else if (!localName.Equals("NoThreeD") && !localName.Equals("NoThreeD2"))
			{
				if (localName.Equals("FmlaLink"))
				{
					checkBox_0.LinkedCell = text;
				}
			}
			else if (!Class1618.smethod_201(text))
			{
				shadow = false;
			}
		}
		checkBox_0.Shadow = shadow;
	}

	private void method_25(XmlElement xmlElement_0, Shape shape_0)
	{
		string text = Class1618.smethod_172(xmlElement_0, "dashstyle");
		string text2 = Class1618.smethod_172(xmlElement_0, "linestyle");
		MsoLineFormat lineFormat = shape_0.LineFormat;
		if (!lineFormat.IsVisible)
		{
			return;
		}
		if (text2 != null)
		{
			lineFormat.Style = Class1618.smethod_57(text2);
		}
		if (text != null)
		{
			if (text.IndexOf(' ') == -1)
			{
				lineFormat.DashStyle = Class1618.smethod_61(text);
			}
			else if (text == "1 1")
			{
				lineFormat.DashStyle = MsoLineDashStyle.SquareDot;
			}
			else if (text == "0 2")
			{
				lineFormat.DashStyle = MsoLineDashStyle.RoundDot;
			}
		}
	}

	private Color GetColor(string string_0, WorksheetCollection worksheetCollection_0)
	{
		Color result = Color.Empty;
		try
		{
			int num = string_0.IndexOf('[');
			int num2 = string_0.IndexOf(']');
			if (num != -1 && num2 != -1 && worksheetCollection_0 != null)
			{
				int num3 = Class1618.smethod_87(string_0.Substring(num + 1, num2 - num - 1));
				result = worksheetCollection_0.method_24().method_7(num3);
			}
			else
			{
				if (string_0[0] != '#')
				{
					string key;
					if ((key = string_0.ToLower()) != null)
					{
						if (Class1742.dictionary_139 == null)
						{
							Class1742.dictionary_139 = new Dictionary<string, int>(16)
							{
								{ "black", 0 },
								{ "silver", 1 },
								{ "gray", 2 },
								{ "white", 3 },
								{ "maroon", 4 },
								{ "red", 5 },
								{ "purple", 6 },
								{ "fuchsia", 7 },
								{ "green", 8 },
								{ "lime", 9 },
								{ "olive", 10 },
								{ "yellow", 11 },
								{ "navy", 12 },
								{ "blue", 13 },
								{ "teal", 14 },
								{ "aqua", 15 }
							};
						}
						if (Class1742.dictionary_139.TryGetValue(key, out var value))
						{
							switch (value)
							{
							case 0:
								return Color.Black;
							case 1:
								return Color.Silver;
							case 2:
								return Color.Gray;
							case 3:
								return Color.White;
							case 4:
								return Color.Maroon;
							case 5:
								return Color.Red;
							case 6:
								return Color.Purple;
							case 7:
								return Color.Fuchsia;
							case 8:
								return Color.Green;
							case 9:
								return Color.Lime;
							case 10:
								return Color.Olive;
							case 11:
								return Color.Yellow;
							case 12:
								return Color.Navy;
							case 13:
								return Color.Blue;
							case 14:
								return Color.Teal;
							case 15:
								return Color.Aqua;
							}
						}
					}
					return Color.Empty;
				}
				if (string_0.Length == 4)
				{
					string_0 = "#" + string_0[1] + string_0[1] + string_0[2] + string_0[2] + string_0[3] + string_0[3];
				}
				result = Class1618.smethod_63(string_0.Substring(1));
			}
		}
		catch
		{
		}
		return result;
	}

	internal ArrayList method_26()
	{
		return arrayList_0;
	}
}
