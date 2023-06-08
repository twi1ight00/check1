using System.Collections;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns2;
using ns21;
using ns22;
using ns25;
using ns7;

namespace ns16;

internal class Class1604
{
	private XmlDocument xmlDocument_0;

	private Hashtable hashtable_0;

	private bool bool_0;

	private string string_0;

	private ArrayList arrayList_0;

	private int int_0;

	private Class1548 class1548_0;

	private Chart chart_0;

	private Class746 class746_0;

	private Workbook workbook_0;

	internal ShapeCollection shapeCollection_0;

	private bool bool_1;

	private bool bool_2;

	internal Class1604(Class1548 class1548_1, XmlDocument xmlDocument_1, Hashtable hashtable_1, Class746 class746_1)
	{
		xmlDocument_0 = xmlDocument_1;
		hashtable_0 = hashtable_1;
		bool_0 = false;
		string_0 = "http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing";
		class1548_0 = class1548_1;
		shapeCollection_0 = class1548_0.worksheet_0.Shapes;
		class746_0 = class746_1;
		workbook_0 = class1548_1.worksheet_0.Workbook;
		int_0 = workbook_0.Worksheets.method_75();
		arrayList_0 = new ArrayList();
	}

	internal Class1604(Class1548 class1548_1, Chart chart_1, XmlDocument xmlDocument_1, Hashtable hashtable_1, Class746 class746_1)
	{
		class1548_0 = class1548_1;
		xmlDocument_0 = xmlDocument_1;
		hashtable_0 = hashtable_1;
		bool_0 = true;
		string_0 = "http://schemas.openxmlformats.org/drawingml/2006/chartDrawing";
		chart_0 = chart_1;
		shapeCollection_0 = chart_0.Shapes;
		class746_0 = class746_1;
		workbook_0 = chart_1.method_14().Workbook;
		int_0 = workbook_0.Worksheets.method_75();
		arrayList_0 = new ArrayList();
	}

	internal void method_0()
	{
		int num = 0;
		IEnumerator enumerator = xmlDocument_0.DocumentElement.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			if (current is XmlElement)
			{
				Class1362 class1362_ = new Class1362();
				method_1((XmlElement)current, class1362_, num, bool_3: false);
			}
			num++;
		}
	}

	private void method_1(XmlElement xmlElement_0, Class1362 class1362_0, int int_1, bool bool_3)
	{
		class1362_0.bool_1 = bool_3;
		if (method_46(xmlElement_0, class1362_0))
		{
			string outerXml = xmlElement_0.OuterXml;
			new StringBuilder();
			XmlNodeList childNodes = xmlElement_0.ChildNodes;
			bool flag = false;
			for (int i = 0; i < childNodes.Count; i++)
			{
				if (!(childNodes[i] is XmlElement) || !(((XmlElement)childNodes[i]).LocalName == "AlternateContent"))
				{
					continue;
				}
				XmlElement xmlElement = (XmlElement)childNodes[i];
				childNodes = xmlElement.ChildNodes;
				for (i = 0; i < childNodes.Count; i++)
				{
					if (!(childNodes[i] is XmlElement) || !(((XmlElement)childNodes[i]).LocalName == "Fallback"))
					{
						continue;
					}
					XmlElement xmlElement2 = (XmlElement)childNodes[i];
					childNodes = xmlElement2.ChildNodes;
					for (i = 0; i < childNodes.Count; i++)
					{
						if (childNodes[i] is XmlElement && ((XmlElement)childNodes[i]).LocalName == "pic")
						{
							xmlElement_0.InsertBefore(childNodes[i], xmlElement);
							xmlElement_0.RemoveChild(xmlElement);
							flag = true;
							break;
						}
					}
					break;
				}
				break;
			}
			if (!flag)
			{
				method_34(class1362_0, outerXml, int_1);
				return;
			}
			class1362_0.Type = MsoDrawingType.Picture;
			method_40(xmlElement_0, class1362_0);
			method_39(xmlElement_0, class1362_0);
			if (class1362_0.Type == MsoDrawingType.Picture)
			{
				method_18(xmlElement_0, class1362_0);
				if (bool_0)
				{
					chart_0.class1549_0.arrayList_0.Add(class1362_0.string_3);
				}
			}
			if (class1362_0.shape_0 == null)
			{
				return;
			}
			class1362_0.shape_0.class1556_0 = new Class1556(bool_1: true);
			class1362_0.shape_0.class1556_0.int_1 = int_1;
			class1362_0.shape_0.class1556_0.string_3 = outerXml;
			if (class1362_0.string_3 != null)
			{
				try
				{
					class1362_0.shape_0.class1556_0.int_2 = Class1618.smethod_87(class1362_0.string_3);
				}
				catch
				{
				}
			}
			method_35(outerXml);
			class1362_0.shape_0.class1556_0.string_2 = class1362_0.string_2;
			if (class1362_0.string_3 != null)
			{
				if (class1362_0.string_4 != null)
				{
					class1362_0.shape_0.Name = class1362_0.string_4;
				}
				if (class1362_0.string_5 != null)
				{
					class1362_0.shape_0.AlternativeText = class1362_0.string_5;
				}
				if (class1362_0.string_6 != null)
				{
					class1362_0.shape_0.Title = class1362_0.string_6;
				}
				try
				{
					class1362_0.shape_0.class1556_0.int_2 = Class1618.smethod_87(class1362_0.string_3);
				}
				catch
				{
				}
			}
			class1362_0.shape_0.class1556_0.class1230_0.method_2();
			return;
		}
		method_40(xmlElement_0, class1362_0);
		if (class1362_0.string_3 == null)
		{
			method_39(xmlElement_0, class1362_0);
		}
		if (!method_38(class1362_0))
		{
			method_34(class1362_0, xmlElement_0.OuterXml, int_1);
			return;
		}
		if (class1362_0.Type == MsoDrawingType.Picture)
		{
			method_18(xmlElement_0, class1362_0);
			if (bool_0)
			{
				chart_0.class1549_0.arrayList_0.Add(class1362_0.string_3);
			}
		}
		else if (class1362_0.Type == MsoDrawingType.Chart)
		{
			method_16(xmlElement_0, class1362_0);
		}
		else if (class1362_0.Type != MsoDrawingType.TextBox && class1362_0.enum186_0 == Enum186.const_187 && class1362_0.autoShapeType_0 == AutoShapeType.Unknown)
		{
			if (class1362_0.Type == MsoDrawingType.Group)
			{
				method_2(xmlElement_0, class1362_0);
			}
		}
		else
		{
			method_6(xmlElement_0, class1362_0);
		}
		if (class1362_0.shape_0 == null)
		{
			return;
		}
		class1362_0.shape_0.class1556_0.int_1 = int_1;
		class1362_0.shape_0.class1556_0.string_2 = class1362_0.string_2;
		if (class1362_0.string_3 != null && !class1362_0.shape_0.IsGroup)
		{
			if (class1362_0.string_4 != null)
			{
				class1362_0.shape_0.Name = class1362_0.string_4;
			}
			if (class1362_0.string_5 != null)
			{
				class1362_0.shape_0.AlternativeText = class1362_0.string_5;
			}
			if (class1362_0.string_6 != null)
			{
				class1362_0.shape_0.Title = class1362_0.string_6;
			}
			try
			{
				class1362_0.shape_0.class1556_0.int_2 = Class1618.smethod_87(class1362_0.string_3);
			}
			catch
			{
			}
		}
		class1362_0.shape_0.class1556_0.class1230_0.method_2();
	}

	private void method_2(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		method_5(class1362_0);
		Class1230 class1230_ = class1362_0.shape_0.class1556_0.class1230_0;
		if (class1362_0.bool_1)
		{
			class1230_.class1234_0 = new Class1234();
			class1230_.class1234_0.bool_1 = true;
			method_3(xmlElement_0, class1362_0);
			return;
		}
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (childNodes[i] is XmlElement)
			{
				XmlElement xmlElement = (XmlElement)childNodes[i];
				string localName = xmlElement.LocalName;
				if (localName == "grpSp")
				{
					class1230_.class1234_0 = new Class1234();
					class1230_.class1234_0.bool_1 = true;
					method_3(xmlElement, class1362_0);
				}
				else if (localName == "clientData")
				{
					class1230_.string_2 = Class536.smethod_1(xmlElement);
				}
			}
		}
	}

	private void method_3(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		Class1234 class1234_ = class1362_0.shape_0.class1556_0.class1230_0.class1234_0;
		ArrayList arrayList = new ArrayList();
		int num = 0;
		IEnumerator enumerator = xmlElement_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			if (!(current is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)current;
			string localName = xmlElement.LocalName;
			if (localName == "nvGrpSpPr")
			{
				class1234_.class1233_0 = new Class1233();
				method_10(xmlElement, class1362_0);
				continue;
			}
			if (localName == "grpSpPr")
			{
				class1234_.class1235_0 = new Class1235();
				method_27(xmlElement, class1362_0);
				continue;
			}
			Class1362 @class = new Class1362();
			method_1(xmlElement, @class, num++, bool_3: true);
			if (@class.shape_0 != null)
			{
				arrayList.Add(@class.shape_0);
			}
		}
		int count = arrayList.Count;
		if (count <= 0)
		{
			return;
		}
		Shape[] array = new Shape[count];
		int num2 = 0;
		foreach (object item in arrayList)
		{
			array[num2++] = (Shape)item;
		}
		shapeCollection_0.method_13((GroupShape)class1362_0.shape_0, array);
	}

	internal Shape method_4(Shape shape_0)
	{
		GroupShape groupShape = (GroupShape)shapeCollection_0.method_41(MsoDrawingType.Group);
		groupShape.method_27().method_8(shape_0.method_27().method_7());
		groupShape.method_69().int_0 = (int)((double)shape_0.method_38() / (double)shapeCollection_0.method_36().method_75() * 72.0 * Class1391.double_0);
		groupShape.method_69().int_2 = (int)((double)shape_0.method_36() / (double)shapeCollection_0.method_36().method_75() * 72.0 * Class1391.double_0);
		groupShape.method_69().int_1 = (int)((double)shape_0.Width / (double)shapeCollection_0.method_36().method_75() * 72.0 * Class1391.double_0);
		groupShape.method_69().int_3 = (int)((double)shape_0.Height / (double)shapeCollection_0.method_36().method_75() * 72.0 * Class1391.double_0);
		ArrayList arrayList = new ArrayList();
		int num = 0;
		XmlNode xmlNode = null;
		IEnumerator enumerator = xmlDocument_0.DocumentElement.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			if (current is XmlElement)
			{
				xmlNode = (XmlNode)current;
				break;
			}
		}
		IEnumerator enumerator2 = xmlNode.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			object current2 = enumerator2.Current;
			if (!(current2 is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)current2;
			string localName = xmlElement.LocalName;
			if (!(localName == "nvGrpSpPr") && !(localName == "grpSpPr"))
			{
				Class1362 @class = new Class1362();
				method_1(xmlElement, @class, num++, bool_3: true);
				if (@class.shape_0 != null)
				{
					arrayList.Add(@class.shape_0);
				}
			}
		}
		int count = arrayList.Count;
		if (count > 0)
		{
			Shape[] array = new Shape[count];
			int num2 = 0;
			foreach (object item in arrayList)
			{
				array[num2++] = (Shape)item;
			}
			shapeCollection_0.method_14(groupShape, array);
		}
		return groupShape;
	}

	private bool method_5(Class1362 class1362_0)
	{
		PlacementType placementType = PlacementType.MoveAndSize;
		if (class1362_0.string_0 != null)
		{
			placementType = Class1618.smethod_53(class1362_0.string_0);
		}
		Shape shape;
		if (class1362_0.AutoShapeType != AutoShapeType.Unknown)
		{
			if (class1362_0.string_2 == "freeFloating")
			{
				shape = (class1362_0.shape_0 = shapeCollection_0.method_7(class1362_0.AutoShapeType, 0, 0, 0, 0));
				class1362_0.method_0();
			}
			else if (bool_0)
			{
				shape = shapeCollection_0.AddAutoShapeInChart(class1362_0.AutoShapeType, (int)(class1362_0.double_1 * 4000.0), (int)(class1362_0.double_0 * 4000.0), (int)((class1362_0.double_3 - class1362_0.double_1) * 4000.0), (int)((class1362_0.double_2 - class1362_0.double_0) * 4000.0));
			}
			else if (class1362_0.string_2 == "oneCellAnchor")
			{
				shape = shapeCollection_0.AddAutoShape(class1362_0.AutoShapeType, class1362_0.int_2, class1362_0.int_3, class1362_0.int_0, class1362_0.int_1, class1362_0.int_9, class1362_0.int_8);
				shape.Placement = placementType;
			}
			else
			{
				if (class1362_0.int_2 > 1048575)
				{
					return false;
				}
				if (class1362_0.int_6 > 1048575)
				{
					class1362_0.int_6 = 1048575;
				}
				shape = shapeCollection_0.AddAutoShape(class1362_0.AutoShapeType, class1362_0.int_2, class1362_0.int_3, class1362_0.int_0, class1362_0.int_1, class1362_0.int_6, class1362_0.int_7, class1362_0.int_4, class1362_0.int_5);
				if (class1362_0.string_0 != null)
				{
					shape.Placement = placementType;
				}
			}
		}
		else if (class1362_0.string_2 == "freeFloating")
		{
			shape = (class1362_0.shape_0 = shapeCollection_0.method_41(class1362_0.Type));
			class1362_0.method_0();
		}
		else if (bool_0)
		{
			shape = shapeCollection_0.AddShapeInChart(class1362_0.Type, placementType, (int)(class1362_0.double_0 * 4000.0), (int)(class1362_0.double_1 * 4000.0), (int)(class1362_0.double_2 * 4000.0), (int)(class1362_0.double_3 * 4000.0));
		}
		else if (class1362_0.Type == MsoDrawingType.Group)
		{
			shape = (class1362_0.shape_0 = shapeCollection_0.method_41(MsoDrawingType.Group));
			class1362_0.method_0();
			shape.class1556_0 = new Class1556(bool_1: true);
		}
		else if (class1362_0.string_2 == "oneCellAnchor")
		{
			shape = shapeCollection_0.AddShape(class1362_0.Type, class1362_0.int_2, class1362_0.int_3, class1362_0.int_0, class1362_0.int_1, class1362_0.int_9, class1362_0.int_8);
			shape.Placement = placementType;
		}
		else
		{
			shape = shapeCollection_0.method_6(class1362_0.Type, placementType, class1362_0.int_2, class1362_0.int_3, class1362_0.int_0, class1362_0.int_1, class1362_0.int_6, class1362_0.int_7, class1362_0.int_4, class1362_0.int_5, null);
		}
		class1362_0.shape_0 = shape;
		shape.class1556_0 = new Class1556(bool_1: true);
		if (class1362_0.Type == MsoDrawingType.TextBox)
		{
			((TextBox)shape).method_63().method_7(bool_2: true);
		}
		return true;
	}

	private void method_6(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		if (!method_5(class1362_0))
		{
			return;
		}
		if (class1362_0.bool_1)
		{
			method_7(xmlElement_0, class1362_0);
			return;
		}
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (childNodes[i] is XmlElement)
			{
				method_7((XmlElement)childNodes[i], class1362_0);
			}
		}
	}

	private void method_7(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		Class1230 class1230_ = class1362_0.shape_0.class1556_0.class1230_0;
		switch (xmlElement_0.LocalName)
		{
		case "sp":
			class1230_.class1234_0 = new Class1234();
			method_8(xmlElement_0, class1362_0);
			break;
		case "cxnSp":
			class1230_.class1234_0 = new Class1234();
			class1230_.class1234_0.bool_0 = true;
			method_8(xmlElement_0, class1362_0);
			break;
		case "graphicFrame":
			class1230_.string_0 = Class536.smethod_1(xmlElement_0);
			break;
		case "pic":
			class1230_.string_1 = Class536.smethod_1(xmlElement_0);
			break;
		case "clientData":
			class1230_.string_2 = Class536.smethod_1(xmlElement_0);
			break;
		}
	}

	private void method_8(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		Class1234 class1234_ = class1362_0.shape_0.class1556_0.class1230_0.class1234_0;
		foreach (XmlAttribute attribute in xmlElement_0.Attributes)
		{
			string localName = attribute.LocalName;
			string value = attribute.Value;
			switch (localName)
			{
			case "fLocksText":
				class1234_.string_0 = value;
				break;
			case "macro":
				class1234_.string_1 = value;
				class1362_0.shape_0.method_1(value);
				break;
			case "textlink":
				class1234_.string_2 = value;
				class1362_0.shape_0.LinkedCell = value;
				break;
			case "fPublished":
				class1234_.string_3 = value;
				break;
			}
		}
		bool flag = false;
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (childNodes[i] is XmlElement)
			{
				XmlElement xmlElement = (XmlElement)childNodes[i];
				switch (xmlElement.LocalName)
				{
				case "spPr":
					class1234_.class1235_0 = new Class1235();
					method_27(xmlElement, class1362_0);
					break;
				case "txBody":
					class1234_.string_5 = Class536.smethod_1(xmlElement);
					method_12(xmlElement, class1362_0);
					method_35(class1234_.string_5);
					break;
				case "style":
					class1234_.string_4 = Class536.smethod_1(xmlElement);
					method_9(xmlElement, class1362_0);
					flag = true;
					break;
				case "nvSpPr":
				case "nvCxnSpPr":
					class1234_.class1233_0 = new Class1233();
					method_10(xmlElement, class1362_0);
					break;
				}
			}
		}
		if (!flag)
		{
			class1362_0.shape_0.method_4(null);
		}
	}

	private void method_9(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		Class1235 @class = null;
		if (class1362_0.shape_0.class1556_0.class1230_0.class1234_0 != null)
		{
			@class = class1362_0.shape_0.class1556_0.class1230_0.class1234_0.class1235_0;
		}
		if (class1362_0.shape_0.method_3() == null)
		{
			class1362_0.shape_0.method_4(new Class1110(class1362_0.shape_0.AutoShapeType));
		}
		Class1110 class2 = class1362_0.shape_0.method_3();
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			switch (xmlElement.LocalName)
			{
			case "lnRef":
			{
				XmlTextReader xmlTextReader2 = method_32(xmlElement);
				class2.class1111_0.string_0 = xmlTextReader2.GetAttribute("idx");
				Class923 class3 = new Class923();
				InternalColor internalColor = Class1238.smethod_0(xmlTextReader2, class3);
				class2.class1111_0.internalColor_0 = internalColor;
				bool flag = false;
				if (@class != null && @class.class1232_0 != null)
				{
					Class1232 class1232_ = @class.class1232_0;
					if (class1232_.string_4 != null || class1232_.string_6 != null || class1232_.string_7 != null || class1232_.string_5 != null)
					{
						flag = true;
					}
				}
				if (flag)
				{
					break;
				}
				MsoLineFormat lineFormat = class1362_0.shape_0.LineFormat;
				if (class2.class1111_0.string_0 == "0")
				{
					lineFormat.IsVisible = false;
					break;
				}
				lineFormat.ForeColor = Color.FromArgb(internalColor.method_7(workbook_0));
				object obj = class3.method_1(Enum230.const_10);
				if (obj != null)
				{
					lineFormat.method_3((double)(int)obj / 100000.0);
				}
				break;
			}
			case "fillRef":
			{
				XmlTextReader xmlTextReader4 = method_32(xmlElement);
				class2.class1111_2.string_0 = xmlTextReader4.GetAttribute("idx");
				if (!xmlTextReader4.IsEmptyElement)
				{
					Class923 class923_ = new Class923();
					InternalColor internalColor_ = Class1238.smethod_0(xmlTextReader4, class923_);
					class2.class1111_2.internalColor_0 = internalColor_;
				}
				break;
			}
			case "fontRef":
			{
				XmlTextReader xmlTextReader3 = method_32(xmlElement);
				string attribute = xmlTextReader3.GetAttribute("idx");
				class2.class1111_1.string_0 = attribute;
				Class1737 class4 = class1362_0.shape_0.method_63();
				if (attribute != null && attribute != "")
				{
					class4.Font.method_1(attribute);
				}
				if (!xmlTextReader3.IsEmptyElement)
				{
					InternalColor internalColor2 = Class1238.smethod_0(xmlTextReader3, null);
					class2.class1111_1.internalColor_0 = internalColor2;
					if (!class4.Font.IsModified(StyleModifyFlag.FontColor))
					{
						class4.Font.InternalColor = internalColor2;
					}
				}
				break;
			}
			case "effectRef":
			{
				XmlTextReader xmlTextReader = method_32(xmlElement);
				class2.class1111_3.string_0 = xmlTextReader.GetAttribute("idx");
				if (!xmlTextReader.IsEmptyElement)
				{
					class2.class1111_3.internalColor_0 = Class1238.smethod_0(xmlTextReader, null);
				}
				break;
			}
			}
		}
	}

	private void method_10(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		Class1233 @class = null;
		if (class1362_0.shape_0.class1556_0.class1230_0.class1234_0 != null)
		{
			@class = class1362_0.shape_0.class1556_0.class1230_0.class1234_0.class1233_0;
		}
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			switch (xmlElement.LocalName)
			{
			case "cNvPr":
				if (@class != null)
				{
					@class.class1231_0 = new Class1231();
				}
				method_24(xmlElement, class1362_0);
				break;
			case "cNvSpPr":
			case "cNvCxnSpPr":
			case "cNvGrpSpPr":
				if (@class != null)
				{
					@class.string_0 = Class536.smethod_1(xmlElement);
				}
				method_11(xmlElement, class1362_0);
				break;
			}
		}
	}

	private void method_11(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			string localName = xmlElement.LocalName;
			if (localName == "spLocks")
			{
				string text = Class1618.smethod_172(xmlElement, "noTextEdit");
				if (text == "1" && class1362_0.Type != MsoDrawingType.TextBox)
				{
				}
			}
		}
	}

	private void method_12(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		Class1737 class1737_ = class1362_0.shape_0.method_63();
		XmlElement xmlElement = Class1618.smethod_173(xmlElement_0, "bodyPr");
		if (xmlElement != null)
		{
			method_13(xmlElement, class1362_0);
		}
		bool flag = true;
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement2 = (XmlElement)childNodes[i];
			string localName = xmlElement2.LocalName;
			if (localName == "p")
			{
				Class1570 @class = new Class1570();
				XmlTextReader xmlTextReader = method_32(xmlElement2);
				xmlTextReader.WhitespaceHandling = WhitespaceHandling.All;
				Class1597.smethod_2(xmlTextReader, @class, flag);
				@class.method_10(class1737_, workbook_0.Worksheets);
				if (flag)
				{
					flag = false;
				}
			}
		}
	}

	private void method_13(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		Class1737 @class = class1362_0.shape_0.method_63();
		MsoTextFrame textFrame = class1362_0.shape_0.TextFrame;
		XmlAttributeCollection attributes = xmlElement_0.Attributes;
		for (int i = 0; i < attributes.Count; i++)
		{
			XmlAttribute xmlAttribute = attributes[i];
			if (xmlAttribute.LocalName == "lIns")
			{
				textFrame.method_2(Class1618.smethod_87(xmlAttribute.Value));
				textFrame.IsAutoMargin = false;
			}
			else if (xmlAttribute.LocalName == "tIns")
			{
				textFrame.method_6(Class1618.smethod_87(xmlAttribute.Value));
				textFrame.IsAutoMargin = false;
			}
			else if (xmlAttribute.LocalName == "rIns")
			{
				textFrame.method_4(Class1618.smethod_87(xmlAttribute.Value));
				textFrame.IsAutoMargin = false;
			}
			else if (xmlAttribute.LocalName == "bIns")
			{
				textFrame.method_8(Class1618.smethod_87(xmlAttribute.Value));
				textFrame.IsAutoMargin = false;
			}
			else if (xmlAttribute.LocalName == "vertOverflow")
			{
				class1362_0.shape_0.TextVerticalOverflow = Class1618.smethod_241(xmlAttribute.Value);
			}
			else if (xmlAttribute.LocalName == "horzOverflow")
			{
				class1362_0.shape_0.TextHorizontalOverflow = Class1618.smethod_241(xmlAttribute.Value);
			}
			else if (xmlAttribute.LocalName == "anchor")
			{
				@class.TextVerticalAlignment = Class1618.smethod_95(xmlAttribute.Value);
			}
			else if (xmlAttribute.LocalName == "vert")
			{
				@class.TextOrientationType = Class1618.smethod_197(xmlAttribute.Value);
			}
			else if (xmlAttribute.LocalName == "wrap")
			{
				@class.bool_1 = xmlAttribute.Value == null || xmlAttribute.Value != "none";
			}
			else if (xmlAttribute.LocalName == "upright")
			{
				@class.method_1(Class1618.smethod_87(xmlAttribute.Value));
			}
		}
		XmlElement xmlElement = Class1618.smethod_173(xmlElement_0, "spAutoFit");
		if (xmlElement != null)
		{
			textFrame.AutoSize = true;
		}
	}

	private void method_14(Class1362 class1362_0)
	{
		Class1564 @class = (Class1564)hashtable_0[class1362_0.string_1];
		XmlTextReader xmlTextReader = null;
		string text = null;
		text = ((!@class.string_3.StartsWith("/")) ? ("xl/charts/" + Path.GetFileName(@class.string_3)) : @class.string_3.Substring(1));
		xmlTextReader = Class1615.smethod_1(class746_0, text);
		Chart chart = null;
		Worksheet worksheet_ = class1548_0.worksheet_0;
		if (bool_0)
		{
			chart = new Chart(worksheet_, chart_0.Shapes);
			chart_0.Shapes.Add(chart.ChartObject);
		}
		else
		{
			if (worksheet_.Type == SheetType.Chart)
			{
				chart = worksheet_.Charts[0];
			}
			else
			{
				chart = new Chart(worksheet_);
				worksheet_.Charts.Add(chart);
			}
			worksheet_.Shapes.Add(chart.ChartObject);
		}
		chart.PlotArea.method_9();
		chart.class1549_0 = new Class1549();
		chart.class1549_0.string_1 = text;
		class1362_0.shape_0 = chart.ChartObject;
		class1362_0.shape_0.class1556_0 = new Class1556(bool_1: true);
		class1362_0.method_0();
		Hashtable hashtable_ = null;
		string string_ = "xl/charts/_rels/" + Path.GetFileName(text) + ".rels";
		if (class746_0.method_40(string_, bool_18: true) != -1)
		{
			XmlTextReader xmlTextReader2 = Class1615.smethod_1(class746_0, string_);
			hashtable_ = Class1608.Read(xmlTextReader2);
			xmlTextReader2.Close();
		}
		Class1597 class2 = new Class1597(class1548_0.class1547_0, class1548_0, chart, hashtable_);
		xmlTextReader = Class1615.smethod_1(class746_0, text);
		class2.method_1(xmlTextReader);
		xmlTextReader.Close();
		xmlTextReader = Class1615.smethod_1(class746_0, text);
		class2.Read(xmlTextReader);
		xmlTextReader.Close();
		workbook_0.class1558_0.method_4(text);
		if (chart.class1549_0.string_0 != null)
		{
			method_15(chart, text);
		}
	}

	private void method_15(Chart chart_1, string string_1)
	{
		string fileName = Path.GetFileName(string_1);
		string text = string_1.Substring(0, string_1.Length - fileName.Length);
		string text2 = text + "_rels/" + fileName + ".rels";
		XmlTextReader xmlTextReader = Class1615.smethod_1(class746_0, text2);
		Hashtable hashtable = Class1608.Read(xmlTextReader);
		xmlTextReader.Close();
		string text3 = chart_1.class1549_0.string_0;
		if (hashtable != null && hashtable.Count != 0)
		{
			if (!hashtable.ContainsKey(text3))
			{
				throw new CellsException(ExceptionType.InvalidData, text2 + " does not contains relId " + text3);
			}
			Class1564 @class = (Class1564)hashtable[text3];
			string text4 = Class1618.smethod_247(string_1, @class.string_3);
			string fileName2 = Path.GetFileName(text4);
			text = text4.Substring(0, text4.Length - fileName2.Length);
			string string_2 = text + "_rels/" + Path.GetFileName(text4) + ".rels";
			chart_1.class1549_0.string_2 = text4;
			Hashtable hashtable_ = null;
			if (class746_0.method_40(string_2, bool_18: true) != -1)
			{
				xmlTextReader = Class1615.smethod_1(class746_0, string_2);
				hashtable_ = Class1608.Read(xmlTextReader);
				xmlTextReader.Close();
			}
			Class744 class744_ = class746_0.method_38(text4);
			Stream stream = class746_0.method_39(class744_);
			XmlDocument xmlDocument_ = Class1188.smethod_2(stream);
			stream.Close();
			Class1604 class2 = new Class1604(class1548_0, chart_1, xmlDocument_, hashtable_, class746_0);
			class2.method_0();
			if (class2.arrayList_0.Count > 0)
			{
				chart_1.method_16().method_1(class2.arrayList_0);
			}
			workbook_0.class1558_0.method_4(text4);
			return;
		}
		throw new CellsException(ExceptionType.InvalidData, text2 + " does not exist or is empty");
	}

	private void method_16(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		method_14(class1362_0);
		XmlElement xmlElement = xmlElement_0;
		if (!class1362_0.bool_1)
		{
			xmlElement = Class1618.smethod_173(xmlElement_0, "graphicFrame");
		}
		class1362_0.shape_0.method_1(Class1618.smethod_172(xmlElement, "macro"));
		class1362_0.shape_0.class1556_0.string_4 = Class1618.smethod_172(xmlElement, "fPublished");
		XmlNodeList childNodes = xmlElement.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (childNodes[i] is XmlElement)
			{
				XmlElement xmlElement2 = (XmlElement)childNodes[i];
				string localName = xmlElement2.LocalName;
				if (localName == "nvGraphicFramePr")
				{
					method_17(xmlElement2, class1362_0);
				}
			}
		}
		if (class1362_0.bool_1)
		{
			return;
		}
		XmlElement xmlElement3 = Class1618.smethod_173(xmlElement_0, "clientData");
		if (xmlElement3 != null)
		{
			string text = Class1618.smethod_172(xmlElement3, "fPrintsWithSheet");
			if (text != null)
			{
				class1362_0.shape_0.IsPrintable = Class1618.smethod_201(text);
			}
			string text2 = Class1618.smethod_172(xmlElement3, "fLocksWithSheet");
			if (text2 != null)
			{
				class1362_0.shape_0.IsLocked = Class1618.smethod_201(text2);
			}
		}
	}

	private void method_17(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (childNodes[i] is XmlElement)
			{
				XmlElement xmlElement = (XmlElement)childNodes[i];
				string localName = xmlElement.LocalName;
				if (localName == "cNvPr")
				{
					method_24(xmlElement, class1362_0);
				}
			}
		}
	}

	private void method_18(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		try
		{
			method_33(class1362_0);
		}
		catch
		{
			return;
		}
		if (class1362_0.shape_0 == null)
		{
			return;
		}
		XmlElement xmlElement = xmlElement_0;
		if (!class1362_0.bool_1)
		{
			xmlElement = Class1618.smethod_173(xmlElement_0, "pic");
		}
		class1362_0.shape_0.method_1(Class1618.smethod_172(xmlElement, "macro"));
		class1362_0.shape_0.class1556_0.string_4 = Class1618.smethod_172(xmlElement, "fPublished");
		XmlNodeList childNodes = xmlElement.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (childNodes[i] is XmlElement)
			{
				XmlElement xmlElement2 = (XmlElement)childNodes[i];
				switch (xmlElement2.LocalName)
				{
				case "nvPicPr":
					method_23(xmlElement2, class1362_0);
					break;
				case "spPr":
					method_27(xmlElement2, class1362_0);
					break;
				case "blipFill":
					method_19(xmlElement2, class1362_0);
					break;
				}
			}
		}
	}

	private void method_19(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		bool flag = true;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (childNodes[i] is XmlElement)
			{
				XmlElement xmlElement = (XmlElement)childNodes[i];
				switch (xmlElement.LocalName)
				{
				case "srcRect":
					method_20(xmlElement, class1362_0);
					break;
				case "blip":
					method_21(xmlElement, class1362_0);
					break;
				case "stretch":
					flag = false;
					break;
				}
			}
		}
		if (flag)
		{
			class1362_0.shape_0.bool_0 = flag;
		}
	}

	private void method_20(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		MsoFormatPicture formatPicture = class1362_0.shape_0.FormatPicture;
		string text = Class1618.smethod_172(xmlElement_0, "l");
		double num = 0.0;
		if (text != null)
		{
			num = Class1618.smethod_85(text);
			formatPicture.LeftCrop = num / 100000.0;
		}
		text = Class1618.smethod_172(xmlElement_0, "b");
		if (text != null)
		{
			num = Class1618.smethod_85(text);
			formatPicture.BottomCrop = num / 100000.0;
		}
		text = Class1618.smethod_172(xmlElement_0, "r");
		if (text != null)
		{
			num = Class1618.smethod_85(text);
			formatPicture.RightCrop = num / 100000.0;
		}
		text = Class1618.smethod_172(xmlElement_0, "t");
		if (text != null)
		{
			num = Class1618.smethod_85(text);
			formatPicture.TopCrop = num / 100000.0;
		}
	}

	private void method_21(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			string localName = xmlElement.LocalName;
			if (localName == "clrChange")
			{
				method_22(xmlElement, class1362_0);
				continue;
			}
			if (class1362_0.shape_0.FormatPicture.arrayList_0 == null)
			{
				class1362_0.shape_0.FormatPicture.arrayList_0 = new ArrayList();
			}
			class1362_0.shape_0.FormatPicture.arrayList_0.Add(Class536.smethod_1(xmlElement));
		}
	}

	private void method_22(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		Class1109 @class = new Class1109();
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			string localName = xmlElement.LocalName;
			if (localName == "clrFrom")
			{
				XmlTextReader xmlTextReader_ = method_32(xmlElement);
				Class923 class2 = new Class923();
				@class.cellsColor_0 = new CellsColor(workbook_0);
				@class.cellsColor_0.internalColor_0 = Class1238.smethod_0(xmlTextReader_, class2);
				object obj = class2.method_1(Enum230.const_10);
				if (obj != null)
				{
					@class.int_0 = (int)obj;
				}
			}
			else if (localName == "clrTo")
			{
				XmlTextReader xmlTextReader_2 = method_32(xmlElement);
				Class923 class3 = new Class923();
				@class.cellsColor_1 = new CellsColor(workbook_0);
				@class.cellsColor_1.internalColor_0 = Class1238.smethod_0(xmlTextReader_2, class3);
				object obj2 = class3.method_1(Enum230.const_10);
				if (obj2 != null)
				{
					@class.int_1 = (int)obj2;
				}
			}
		}
		if (@class.cellsColor_0 != null && @class.cellsColor_1 != null)
		{
			class1362_0.shape_0.FormatPicture.class1109_0 = @class;
		}
	}

	private void method_23(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (childNodes[i] is XmlElement)
			{
				XmlElement xmlElement = (XmlElement)childNodes[i];
				string localName = xmlElement.LocalName;
				if (localName == "cNvPr")
				{
					method_24(xmlElement, class1362_0);
				}
			}
		}
	}

	private void method_24(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		Shape shape_ = class1362_0.shape_0;
		Class1231 @class = null;
		if (class1362_0.shape_0.class1556_0.class1230_0.class1234_0 != null)
		{
			@class = class1362_0.shape_0.class1556_0.class1230_0.class1234_0.class1233_0.class1231_0;
		}
		foreach (XmlAttribute attribute in xmlElement_0.Attributes)
		{
			string name = attribute.Name;
			string value = attribute.Value;
			switch (name)
			{
			case "name":
				shape_.Name = Class1618.smethod_8(value);
				break;
			case "id":
				if (@class != null)
				{
					@class.string_0 = value;
				}
				break;
			case "descr":
				shape_.AlternativeText = value;
				break;
			case "title":
				shape_.Title = value;
				break;
			case "hidden":
				if (value == "1")
				{
					shape_.IsHidden = true;
				}
				break;
			}
		}
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			string localName = xmlElement.LocalName;
			if (localName == "hlinkClick")
			{
				if (@class != null)
				{
					@class.string_1 = Class536.smethod_1(xmlElement);
				}
				string text = Class1618.smethod_172(xmlElement, "id");
				if (text == null)
				{
					continue;
				}
				object obj = hashtable_0[text];
				if (obj != null)
				{
					Class1564 class2 = (Class1564)obj;
					string text2 = class2.string_3;
					if (text2[0] == '#')
					{
						text2 = text2.Substring(1);
					}
					shape_.AddHyperlink(text2);
				}
			}
			else if (localName == "hlinkHover" && @class != null)
			{
				@class.string_2 = Class536.smethod_1(xmlElement);
			}
		}
	}

	private void method_25(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		Class1232 @class = null;
		if (class1362_0.shape_0.class1556_0.class1230_0.class1234_0 != null)
		{
			@class = class1362_0.shape_0.class1556_0.class1230_0.class1234_0.class1235_0.class1232_0;
		}
		MsoLineFormat lineFormat = class1362_0.shape_0.LineFormat;
		foreach (XmlAttribute attribute in xmlElement_0.Attributes)
		{
			string localName = attribute.LocalName;
			string value = attribute.Value;
			switch (localName)
			{
			case "w":
				if (@class != null)
				{
					@class.string_0 = value;
				}
				lineFormat.Weight = Class1618.smethod_49(Class1618.smethod_87(value));
				break;
			case "cmpd":
				if (@class != null)
				{
					@class.string_2 = value;
				}
				lineFormat.Style = Class1618.smethod_55(value);
				break;
			case "cap":
				if (@class != null)
				{
					@class.string_1 = value;
				}
				break;
			case "algn":
				if (@class != null)
				{
					@class.string_3 = value;
				}
				break;
			}
		}
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			switch (xmlElement.LocalName)
			{
			case "noFill":
				if (@class != null)
				{
					@class.string_4 = Class536.smethod_1(xmlElement);
				}
				lineFormat.IsVisible = false;
				break;
			case "solidFill":
			{
				if (@class != null)
				{
					@class.string_5 = Class536.smethod_1(xmlElement);
				}
				XmlTextReader xmlTextReader_ = method_32(xmlElement);
				Class923 class2 = new Class923();
				InternalColor internalColor = Class1238.smethod_0(xmlTextReader_, class2);
				lineFormat.ForeColor = Color.FromArgb(internalColor.method_7(workbook_0));
				object obj = class2.method_1(Enum230.const_10);
				if (obj != null)
				{
					lineFormat.method_3((double)(int)obj / 100000.0);
				}
				break;
			}
			case "gradFill":
				if (@class != null)
				{
					@class.string_6 = Class536.smethod_1(xmlElement);
				}
				break;
			case "pattFill":
				if (@class != null)
				{
					@class.string_7 = Class536.smethod_1(xmlElement);
				}
				break;
			case "custDash":
				if (@class != null)
				{
					@class.string_8 = Class536.smethod_1(xmlElement);
				}
				break;
			case "miter":
				if (@class != null)
				{
					@class.string_10 = Class536.smethod_1(xmlElement);
				}
				break;
			case "round":
				if (@class != null)
				{
					@class.string_11 = Class536.smethod_1(xmlElement);
				}
				break;
			case "bevel":
				if (@class != null)
				{
					@class.string_12 = Class536.smethod_1(xmlElement);
				}
				break;
			case "headEnd":
				if (@class != null)
				{
					@class.string_13 = Class536.smethod_1(xmlElement);
				}
				method_26(xmlElement, lineFormat, bool_3: true);
				break;
			case "tailEnd":
				if (@class != null)
				{
					@class.string_14 = Class536.smethod_1(xmlElement);
				}
				method_26(xmlElement, lineFormat, bool_3: false);
				break;
			case "prstDash":
			{
				if (@class != null)
				{
					@class.string_9 = Class536.smethod_1(xmlElement);
				}
				string text = Class1618.smethod_172(xmlElement, "val");
				if (text == "dot")
				{
					if (@class.string_1 != null && @class.string_1 == "rnd")
					{
						lineFormat.DashStyle = MsoLineDashStyle.RoundDot;
					}
					else
					{
						lineFormat.DashStyle = MsoLineDashStyle.SquareDot;
					}
				}
				else if (text != null)
				{
					lineFormat.DashStyle = Class1618.smethod_59(text);
				}
				break;
			}
			case "extLst":
				if (@class != null)
				{
					@class.string_15 = Class536.smethod_1(xmlElement);
				}
				break;
			}
		}
	}

	private void method_26(XmlElement xmlElement_0, MsoLineFormat msoLineFormat_0, bool bool_3)
	{
		foreach (XmlAttribute attribute in xmlElement_0.Attributes)
		{
			string localName = attribute.LocalName;
			string value = attribute.Value;
			switch (localName)
			{
			case "len":
				if (bool_3)
				{
					msoLineFormat_0.BeginArrowheadLength = Class1618.smethod_166(value);
				}
				else
				{
					msoLineFormat_0.EndArrowheadLength = Class1618.smethod_166(value);
				}
				break;
			case "type":
				if (bool_3)
				{
					msoLineFormat_0.BeginArrowheadStyle = Class1618.smethod_168(value);
				}
				else
				{
					msoLineFormat_0.EndArrowheadStyle = Class1618.smethod_168(value);
				}
				break;
			case "w":
				if (bool_3)
				{
					msoLineFormat_0.BeginArrowheadWidth = Class1618.smethod_170(value);
				}
				else
				{
					msoLineFormat_0.EndArrowheadWidth = Class1618.smethod_170(value);
				}
				break;
			}
		}
	}

	private void method_27(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		Class1235 @class = null;
		if (class1362_0.shape_0.class1556_0.class1230_0.class1234_0 != null)
		{
			@class = class1362_0.shape_0.class1556_0.class1230_0.class1234_0.class1235_0;
		}
		FillFormat fill = class1362_0.shape_0.Fill;
		bool flag = false;
		bool flag2 = false;
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		if (@class != null)
		{
			@class.string_0 = Class1618.smethod_172(xmlElement_0, "bwMode");
		}
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			switch (xmlElement.LocalName)
			{
			case "xfrm":
				if (@class != null)
				{
					@class.string_1 = Class536.smethod_1(xmlElement);
				}
				method_28(xmlElement, class1362_0);
				break;
			case "custGeom":
				if (@class != null)
				{
					@class.string_2 = Class536.smethod_1(xmlElement);
				}
				method_29(xmlElement, class1362_0);
				break;
			case "prstGeom":
				if (@class != null)
				{
					@class.string_3 = Class536.smethod_1(xmlElement);
				}
				method_31(xmlElement, class1362_0);
				break;
			case "noFill":
				if (@class != null)
				{
					@class.string_4 = Class536.smethod_1(xmlElement);
				}
				fill.Type = FillType.None;
				flag = true;
				break;
			case "solidFill":
				if (@class != null)
				{
					@class.string_5 = Class536.smethod_1(xmlElement);
				}
				if (!Class1188.smethod_4(xmlElement))
				{
					Class923 class3 = new Class923();
					InternalColor internalColor = Class1238.smethod_0(method_32(xmlElement), class3);
					fill.Type = FillType.Solid;
					fill.SolidFill.Color = Color.FromArgb(internalColor.method_7(workbook_0));
					object obj = class3.method_1(Enum230.const_10);
					if (obj != null)
					{
						fill.SolidFill.method_1((int)obj);
					}
					flag = true;
				}
				break;
			case "gradFill":
			{
				if (@class != null)
				{
					@class.string_6 = Class536.smethod_1(xmlElement);
				}
				fill.Type = FillType.Gradient;
				GradientFill gradientFill = fill.GradientFill;
				Class1238 class5 = new Class1238(class1548_0, hashtable_0);
				class5.method_20(method_32(xmlElement), gradientFill);
				flag = true;
				break;
			}
			case "pattFill":
			{
				if (@class != null)
				{
					@class.string_7 = Class536.smethod_1(xmlElement);
				}
				Class1238 class4 = new Class1238(class1548_0, hashtable_0);
				class4.method_24(method_32(xmlElement), fill);
				flag = true;
				break;
			}
			case "blipFill":
			{
				if (@class != null)
				{
					@class.string_8 = Class536.smethod_1(xmlElement);
				}
				Class1238 class2 = new Class1238(class1548_0, hashtable_0);
				class2.method_16(method_32(xmlElement), fill);
				flag = true;
				break;
			}
			case "grpFill":
				if (@class != null)
				{
					@class.string_9 = Class536.smethod_1(xmlElement);
				}
				break;
			case "scene3d":
				if (@class != null)
				{
					@class.string_10 = Class536.smethod_1(xmlElement);
				}
				break;
			case "effectDag":
				if (@class != null)
				{
					@class.string_11 = Class536.smethod_1(xmlElement);
				}
				break;
			case "effectLst":
				if (@class != null)
				{
					@class.string_12 = Class536.smethod_1(xmlElement);
				}
				break;
			case "sp3d":
				if (@class != null)
				{
					@class.string_13 = Class536.smethod_1(xmlElement);
				}
				break;
			case "ln":
				if (@class != null)
				{
					@class.class1232_0 = new Class1232();
				}
				method_25(xmlElement, class1362_0);
				flag2 = true;
				break;
			case "extLst":
				if (@class != null)
				{
					@class.string_14 = Class536.smethod_1(xmlElement);
				}
				break;
			}
		}
		if (class1362_0.Type == MsoDrawingType.TextBox && !flag2)
		{
			class1362_0.shape_0.LineFormat.IsVisible = false;
		}
		if (!flag)
		{
			fill.Type = FillType.Automatic;
			fill.bool_0 = false;
		}
		bool_1 = flag;
		bool_2 = flag2;
	}

	private void method_28(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		string text = Class1618.smethod_172(xmlElement_0, "flipV");
		if (text != null)
		{
			class1362_0.shape_0.method_27().method_9().method_10(Class1618.smethod_201(text));
		}
		string text2 = Class1618.smethod_172(xmlElement_0, "flipH");
		if (text2 != null)
		{
			class1362_0.shape_0.method_27().method_9().method_12(Class1618.smethod_201(text2));
		}
		string text3 = Class1618.smethod_172(xmlElement_0, "rot");
		if (text3 != null && text3.Length > 0)
		{
			double double_ = Class1618.smethod_85(text3) / 60000.0;
			class1362_0.shape_0.method_12(double_);
		}
		if (class1362_0.Type != 0)
		{
			return;
		}
		GroupShape groupShape = (GroupShape)class1362_0.shape_0;
		XmlElement xmlElement = Class1618.smethod_173(xmlElement_0, "chOff");
		if (xmlElement != null)
		{
			string text4 = Class1618.smethod_172(xmlElement, "x");
			if (text4 != null)
			{
				groupShape.method_69().int_0 = Class1618.smethod_87(text4);
			}
			string text5 = Class1618.smethod_172(xmlElement, "y");
			if (text5 != null)
			{
				groupShape.method_69().int_2 = Class1618.smethod_87(text5);
			}
		}
		XmlElement xmlElement2 = Class1618.smethod_173(xmlElement_0, "chExt");
		if (xmlElement2 != null)
		{
			string text6 = Class1618.smethod_172(xmlElement2, "cx");
			if (text6 != null)
			{
				groupShape.method_69().int_1 = Class1618.smethod_87(text6);
			}
			string text7 = Class1618.smethod_172(xmlElement2, "cy");
			if (text7 != null)
			{
				groupShape.method_69().int_3 = Class1618.smethod_87(text7);
			}
		}
	}

	private void method_29(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		XmlElement xmlElement = Class1618.smethod_173(xmlElement_0, "pathLst");
		if (xmlElement == null)
		{
			return;
		}
		XmlNodeList childNodes = xmlElement.ChildNodes;
		GeomPathsInfo pathsInfo = ((CellsDrawing)class1362_0.shape_0).PathsInfo;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement2 = (XmlElement)childNodes[i];
			string localName = xmlElement2.LocalName;
			if (!(localName == "path"))
			{
				continue;
			}
			GeomPathInfo geomPathInfo = new GeomPathInfo();
			string text = Class1618.smethod_172(xmlElement2, "extrusionOk");
			if (text != null && text == "1")
			{
				geomPathInfo.bool_0 = true;
			}
			text = Class1618.smethod_172(xmlElement2, "fill");
			if (text != null)
			{
				geomPathInfo.enum131_0 = Class1673.smethod_17(text);
			}
			text = Class1618.smethod_172(xmlElement2, "stroke");
			if (text != null && text == "0")
			{
				geomPathInfo.bool_1 = false;
			}
			text = Class1618.smethod_172(xmlElement2, "h");
			if (text != null)
			{
				geomPathInfo.long_0 = long.Parse(text, CultureInfo.InvariantCulture);
			}
			else
			{
				geomPathInfo.long_0 = class1362_0.int_13;
			}
			text = Class1618.smethod_172(xmlElement2, "w");
			if (text != null)
			{
				geomPathInfo.long_1 = long.Parse(text, CultureInfo.InvariantCulture);
			}
			else
			{
				geomPathInfo.long_1 = class1362_0.int_12;
			}
			_ = pathsInfo.PathList;
			XmlNodeList childNodes2 = xmlElement2.ChildNodes;
			Point point = Point.Empty;
			MsoPathInfo msoPathInfo;
			for (int j = 0; j < childNodes2.Count; j++)
			{
				if (!(childNodes2[j] is XmlElement))
				{
					continue;
				}
				XmlElement xmlElement3 = (XmlElement)childNodes2[j];
				if (xmlElement3.LocalName == "moveTo")
				{
					if (xmlElement3.ChildNodes.Count == 1)
					{
						msoPathInfo = new MsoPathInfo(MsoPathType.MsopathMoveTo);
						point = method_30((XmlElement)xmlElement3.ChildNodes[0]);
						msoPathInfo.PointList.Add(point);
						geomPathInfo.AddSegment(msoPathInfo);
					}
				}
				else if (xmlElement3.LocalName == "cubicBezTo")
				{
					if (xmlElement3.ChildNodes.Count == 3)
					{
						msoPathInfo = new MsoPathInfo(MsoPathType.MsopathCurveTo);
						msoPathInfo.PointList.Add(point);
						msoPathInfo.PointList.Add(method_30((XmlElement)xmlElement3.ChildNodes[0]));
						msoPathInfo.PointList.Add(method_30((XmlElement)xmlElement3.ChildNodes[1]));
						point = method_30((XmlElement)xmlElement3.ChildNodes[2]);
						msoPathInfo.PointList.Add(point);
						geomPathInfo.AddSegment(msoPathInfo);
					}
				}
				else if (xmlElement3.LocalName == "arcTo")
				{
					int x = 0;
					int y = 0;
					int x2 = 0;
					int y2 = 0;
					text = Class1618.smethod_172(xmlElement3, "wR");
					if (text != null)
					{
						x = Class1618.smethod_87(text);
					}
					text = Class1618.smethod_172(xmlElement3, "hR");
					if (text != null)
					{
						y = Class1618.smethod_87(text);
					}
					text = Class1618.smethod_172(xmlElement3, "stAng");
					if (text != null)
					{
						x2 = Class1618.smethod_87(text);
					}
					text = Class1618.smethod_172(xmlElement3, "swAng");
					if (text != null)
					{
						y2 = Class1618.smethod_87(text);
					}
					msoPathInfo = new MsoPathInfo(MsoPathType.MsopathArcTo);
					msoPathInfo.PointList.Add(new Point(class1362_0.int_10, class1362_0.int_11));
					msoPathInfo.PointList.Add(new Point(x, y));
					msoPathInfo.PointList.Add(new Point(x2, y2));
					geomPathInfo.AddSegment(msoPathInfo);
				}
				else if (xmlElement3.LocalName == "lnTo")
				{
					if (xmlElement3.ChildNodes.Count == 1)
					{
						msoPathInfo = new MsoPathInfo(MsoPathType.MsopathLineTo);
						msoPathInfo.PointList.Add(point);
						point = method_30((XmlElement)xmlElement3.ChildNodes[0]);
						msoPathInfo.PointList.Add(point);
						geomPathInfo.AddSegment(msoPathInfo);
					}
				}
				else if (xmlElement3.LocalName == "close")
				{
					msoPathInfo = new MsoPathInfo(MsoPathType.MsopathClose);
					geomPathInfo.AddSegment(msoPathInfo);
				}
			}
			msoPathInfo = new MsoPathInfo(MsoPathType.MsopathEnd);
			geomPathInfo.AddSegment(msoPathInfo);
			pathsInfo.PathList.Add(geomPathInfo);
		}
	}

	private Point method_30(XmlElement xmlElement_0)
	{
		string s = Class1618.smethod_172(xmlElement_0, "x");
		string s2 = Class1618.smethod_172(xmlElement_0, "y");
		return new Point(int.Parse(s), int.Parse(s2));
	}

	private void method_31(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		string text = Class1618.smethod_172(xmlElement_0, "prst");
		if (text != null)
		{
			Enum186 enum186_ = Class1618.smethod_229(text);
			_ = class1362_0.shape_0.MsoDrawingType;
			class1362_0.shape_0.method_27().method_9().method_1((short)Class1618.smethod_232(enum186_));
		}
		XmlElement xmlElement = Class1618.smethod_173(xmlElement_0, "avLst");
		if (xmlElement == null)
		{
			return;
		}
		XmlNodeList childNodes = xmlElement.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (childNodes[i] is XmlElement)
			{
				XmlElement xmlElement2 = (XmlElement)childNodes[i];
				if (!(xmlElement2.LocalName != "gd"))
				{
					Class1244 @class = new Class1244();
					@class.string_0 = xmlElement2.GetAttribute("name");
					@class.string_1 = xmlElement2.GetAttribute("fmla");
					class1362_0.shape_0.method_9().method_0().Add(@class);
				}
			}
		}
	}

	[Attribute0(true)]
	private XmlTextReader method_32(XmlElement xmlElement_0)
	{
		string outerXml = xmlElement_0.OuterXml;
		XmlTextReader xmlTextReader = Class1029.smethod_3(outerXml, XmlNodeType.Element, null);
		xmlTextReader.WhitespaceHandling = WhitespaceHandling.None;
		xmlTextReader.Read();
		return xmlTextReader;
	}

	private void method_33(Class1362 class1362_0)
	{
		Class1564 @class = (Class1564)hashtable_0[class1362_0.string_1];
		if (class1362_0.bool_0)
		{
			Shape shape = (class1362_0.shape_0 = shapeCollection_0.AddLinkedPicture(0, 0, 0, 0, @class.string_3));
			class1362_0.method_0();
			shape.class1556_0 = new Class1556(bool_1: true);
			return;
		}
		int num = 0;
		if (@class.string_3 != "NULL")
		{
			string text = Class1618.smethod_212(@class.string_3);
			object obj = class1548_0.class1547_0.hashtable_5[text];
			if (obj == null)
			{
				Class744 class2 = class746_0.method_38(text);
				if (class2 != null)
				{
					Stream stream = class746_0.method_39(class2);
					byte[] array = new byte[(int)class2.Size];
					if (array.Length <= 0)
					{
						workbook_0.class1558_0.arrayList_2.Add(Path.GetFileName(@class.string_3));
						return;
					}
					stream.Read(array, 0, (int)class2.Size);
					num = workbook_0.Worksheets.method_84().method_7(new MemoryStream(array));
					class1548_0.class1547_0.hashtable_5.Add(text, num);
				}
			}
			else
			{
				num = (int)obj;
				workbook_0.Worksheets.method_84().method_0()[num - 1].method_7();
			}
		}
		PlacementType placementType = PlacementType.MoveAndSize;
		if (class1362_0.string_0 != null)
		{
			placementType = Class1618.smethod_53(class1362_0.string_0);
		}
		Shape shape2 = null;
		if (class1362_0.string_2 == "freeFloating")
		{
			shape2 = (class1362_0.shape_0 = shapeCollection_0.AddFreeFloatingShape(MsoDrawingType.Picture, 0, 0, 0, 0, null, isOriginalSize: false));
			class1362_0.method_0();
		}
		else if (bool_0)
		{
			shape2 = (class1362_0.shape_0 = shapeCollection_0.AddShapeInChart(MsoDrawingType.Picture, placementType, (int)(class1362_0.double_0 * 4000.0), (int)(class1362_0.double_1 * 4000.0), (int)(class1362_0.double_2 * 4000.0), (int)(class1362_0.double_3 * 4000.0)));
		}
		else
		{
			shape2 = (class1362_0.shape_0 = shapeCollection_0.method_6(MsoDrawingType.Picture, placementType, class1362_0.int_2, class1362_0.int_3, class1362_0.int_0, class1362_0.int_1, class1362_0.int_6, class1362_0.int_7, class1362_0.int_4, class1362_0.int_5, null));
			if (class1362_0.string_2 == "oneCellAnchor")
			{
				shape2.Width = class1362_0.int_8;
				shape2.Height = class1362_0.int_9;
			}
			else if (class1362_0.string_2 == "absoluteAnchor")
			{
				shape2.method_17(class1362_0.int_10, class1362_0.int_11, class1362_0.int_8, class1362_0.int_9);
			}
		}
		((Picture)shape2).method_71(num);
		shape2.class1556_0 = new Class1556(bool_1: true);
		workbook_0.class1558_0.arrayList_2.Add(Path.GetFileName(@class.string_3));
	}

	private void method_34(Class1362 class1362_0, string string_1, int int_1)
	{
		MsoDrawingType msoDrawingType = MsoDrawingType.Unknown;
		bool flag = class1362_0.shape_0 == null;
		if (class1362_0.shape_0 == null)
		{
			if (class1362_0.bool_1)
			{
				class1362_0.shape_0 = shapeCollection_0.method_41(msoDrawingType);
				class1362_0.method_0();
			}
			else if (bool_0)
			{
				class1362_0.shape_0 = shapeCollection_0.AddShapeInChart(msoDrawingType, PlacementType.Move, 0, 0, 0, 0);
			}
			else
			{
				class1362_0.shape_0 = shapeCollection_0.AddShape(msoDrawingType, 0, 0, 0, 0, 0, 0);
				class1362_0.method_0();
			}
		}
		class1362_0.shape_0.class1556_0 = new Class1556(bool_1: true);
		class1362_0.shape_0.class1556_0.int_1 = int_1;
		class1362_0.shape_0.class1556_0.string_3 = string_1;
		if (class1362_0.string_3 != null)
		{
			try
			{
				class1362_0.shape_0.class1556_0.int_2 = Class1618.smethod_87(class1362_0.string_3);
			}
			catch
			{
			}
		}
		if (flag)
		{
			method_35(class1362_0.shape_0.class1556_0.string_3);
		}
	}

	private void method_35(string string_1)
	{
		if (hashtable_0 == null)
		{
			return;
		}
		IDictionaryEnumerator enumerator = hashtable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string value = (string)enumerator.Key;
			if (string_1.IndexOf(value) != -1 && !arrayList_0.Contains(enumerator.Value))
			{
				arrayList_0.Add(enumerator.Value);
			}
		}
	}

	private void method_36(string string_1)
	{
		if (hashtable_0 != null)
		{
			object obj = hashtable_0[string_1];
			if (obj != null && !arrayList_0.Contains(obj))
			{
				arrayList_0.Add(obj);
			}
		}
	}

	private void method_37(XmlElement xmlElement_0, string string_1)
	{
		if (hashtable_0 == null)
		{
			return;
		}
		method_36(Class1618.smethod_172(xmlElement_0, "dm"));
		method_36(Class1618.smethod_172(xmlElement_0, "lo"));
		method_36(Class1618.smethod_172(xmlElement_0, "qs"));
		method_36(Class1618.smethod_172(xmlElement_0, "cs"));
		IDictionaryEnumerator enumerator = hashtable_0.GetEnumerator();
		Class1564 @class;
		do
		{
			if (enumerator.MoveNext())
			{
				@class = (Class1564)enumerator.Value;
				continue;
			}
			return;
		}
		while (!(@class.string_2 == "http://schemas.microsoft.com/office/2007/relationships/diagramDrawing") || !@class.string_3.EndsWith(string_1));
		if (!arrayList_0.Contains(enumerator.Value))
		{
			arrayList_0.Add(enumerator.Value);
		}
	}

	private bool method_38(Class1362 class1362_0)
	{
		_ = class1362_0.Type;
		switch (class1362_0.Type)
		{
		default:
			if (class1362_0.AutoShapeType == AutoShapeType.NotPrimitive)
			{
				return true;
			}
			if (class1362_0.enum186_0 != Enum186.const_187)
			{
				AutoShapeType autoShapeType = Class1618.smethod_232(class1362_0.enum186_0);
				if (autoShapeType == AutoShapeType.Unknown)
				{
					return false;
				}
				Enum186 @enum = Class1618.smethod_231(autoShapeType);
				if (@enum == class1362_0.enum186_0)
				{
					return true;
				}
			}
			if (class1362_0.Type == MsoDrawingType.Group)
			{
				return true;
			}
			return false;
		case MsoDrawingType.Line:
		case MsoDrawingType.Chart:
		case MsoDrawingType.TextBox:
		case MsoDrawingType.Picture:
			return true;
		}
	}

	private void method_39(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		XmlNodeList xmlNodeList = Class1188.smethod_5(xmlElement_0, "cNvPr", string_0);
		for (int i = 0; i < xmlNodeList.Count; i++)
		{
			XmlElement xmlElement = (XmlElement)xmlNodeList[i];
			if (xmlElement != null)
			{
				string string_ = Class1618.smethod_172(xmlElement, "id");
				class1362_0.string_3 = string_;
				class1362_0.string_5 = Class1618.smethod_172(xmlElement, "descr");
				class1362_0.string_4 = Class1618.smethod_172(xmlElement, "name");
				class1362_0.string_6 = Class1618.smethod_172(xmlElement, "title");
			}
		}
	}

	private void method_40(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		if (!class1362_0.bool_1)
		{
			IEnumerator enumerator = xmlElement_0.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (current is XmlElement && method_41((XmlElement)current, class1362_0))
				{
					break;
				}
			}
		}
		else
		{
			method_41(xmlElement_0, class1362_0);
		}
	}

	private bool method_41(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		switch (xmlElement_0.LocalName)
		{
		case "pic":
			method_45(xmlElement_0, class1362_0);
			goto IL_0077;
		case "graphicFrame":
			method_43(xmlElement_0, class1362_0);
			goto IL_0077;
		case "sp":
			method_42(xmlElement_0, class1362_0);
			goto IL_0077;
		case "grpSp":
			class1362_0.Type = MsoDrawingType.Group;
			goto IL_0077;
		case "cxnSp":
			method_42(xmlElement_0, class1362_0);
			goto IL_0077;
		default:
			{
				return false;
			}
			IL_0077:
			return true;
		}
	}

	private void method_42(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		XmlElement xmlElement = Class1618.smethod_173(xmlElement_0, "nvSpPr");
		if (xmlElement != null)
		{
			XmlElement xmlElement2 = Class1618.smethod_173(xmlElement, "cNvSpPr");
			if (xmlElement2 != null)
			{
				string text = Class1618.smethod_172(xmlElement2, "txBox");
				if (text == "1")
				{
					class1362_0.Type = MsoDrawingType.TextBox;
					return;
				}
			}
		}
		XmlElement xmlElement3 = Class1618.smethod_173(xmlElement_0, "spPr");
		if (xmlElement3 == null)
		{
			return;
		}
		XmlElement xmlElement4 = Class1618.smethod_173(xmlElement3, "prstGeom");
		if (xmlElement4 != null)
		{
			string text2 = Class1618.smethod_172(xmlElement4, "prst");
			if (text2 != null)
			{
				class1362_0.enum186_0 = Class1618.smethod_229(text2);
				if (class1362_0.enum186_0 == Enum186.const_0)
				{
					class1362_0.Type = MsoDrawingType.Line;
				}
			}
		}
		XmlElement xmlElement5 = Class1618.smethod_173(xmlElement3, "custGeom");
		if (xmlElement5 != null)
		{
			class1362_0.AutoShapeType = AutoShapeType.NotPrimitive;
		}
	}

	private void method_43(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		IEnumerator enumerator = xmlElement_0.GetEnumerator();
		XmlElement xmlElement;
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			object current = enumerator.Current;
			if (!(current is XmlElement))
			{
				continue;
			}
			xmlElement = (XmlElement)current;
			if (xmlElement.LocalName == "graphic")
			{
				break;
			}
			if (!(xmlElement.LocalName == "nvGraphicFramePr"))
			{
				continue;
			}
			IEnumerator enumerator2 = xmlElement.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				current = enumerator2.Current;
				if (current is XmlElement)
				{
					XmlNode xmlNode = (XmlNode)current;
					if (xmlNode.LocalName == "cNvPr")
					{
						string string_ = Class1618.smethod_172(xmlNode, "id");
						class1362_0.string_3 = string_;
						class1362_0.string_5 = Class1618.smethod_172(xmlNode, "descr");
						class1362_0.string_4 = Class1618.smethod_172(xmlNode, "name");
						class1362_0.string_6 = Class1618.smethod_172(xmlNode, "title");
						break;
					}
				}
			}
		}
		IEnumerator enumerator3 = xmlElement.GetEnumerator();
		XmlNode xmlNode2;
		while (true)
		{
			if (!enumerator3.MoveNext())
			{
				return;
			}
			object current = enumerator3.Current;
			if (current is XmlElement)
			{
				xmlNode2 = (XmlNode)current;
				if (xmlNode2.LocalName == "graphicData")
				{
					break;
				}
			}
		}
		IEnumerator enumerator4 = xmlNode2.GetEnumerator();
		while (enumerator4.MoveNext())
		{
			object current = enumerator4.Current;
			if (!(current is XmlElement))
			{
				continue;
			}
			XmlNode xmlNode3 = (XmlNode)current;
			if (xmlNode3.LocalName == "chart")
			{
				class1362_0.string_1 = Class1618.smethod_172(xmlNode3, "id");
				if (method_44(class1362_0.string_1))
				{
					class1362_0.Type = MsoDrawingType.Chart;
				}
			}
			else if (xmlNode3.LocalName == "relIds")
			{
				class1362_0.shape_0 = shapeCollection_0.AddShape(MsoDrawingType.Unknown, 0, 0, 0, 0, 0, 0);
				class1362_0.method_0();
				string key = Class1618.smethod_172(xmlNode3, "dm");
				Class1564 @class = (Class1564)hashtable_0[key];
				string text = Class1185.smethod_1(@class.string_3).Replace("data", "drawing");
				string string_2 = Class1618.smethod_212(Class1185.smethod_2(@class.string_3) + "/" + text);
				class1362_0.shape_0.string_1 = string_2;
				method_37((XmlElement)xmlNode3, text);
			}
		}
	}

	private bool method_44(string string_1)
	{
		if (string_1 != null && hashtable_0 != null)
		{
			return hashtable_0.ContainsKey(string_1);
		}
		return false;
	}

	private void method_45(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		XmlElement xmlElement = Class1618.smethod_173(xmlElement_0, "blipFill");
		if (xmlElement == null)
		{
			return;
		}
		XmlElement xmlElement2 = Class1618.smethod_173(xmlElement, "blip");
		if (xmlElement2 != null)
		{
			class1362_0.string_1 = Class1618.smethod_172(xmlElement2, "embed");
			if (class1362_0.string_1 == null)
			{
				class1362_0.string_1 = Class1618.smethod_172(xmlElement2, "link");
				class1362_0.bool_0 = class1362_0.string_1 != null;
			}
			if (method_44(class1362_0.string_1))
			{
				class1362_0.Type = MsoDrawingType.Picture;
			}
		}
	}

	private bool method_46(XmlElement xmlElement_0, Class1362 class1362_0)
	{
		bool result = false;
		if (!class1362_0.bool_1)
		{
			class1362_0.string_2 = xmlElement_0.LocalName;
			class1362_0.string_0 = Class1618.smethod_172(xmlElement_0, "editAs");
			XmlNodeList childNodes = xmlElement_0.ChildNodes;
			for (int i = 0; i < childNodes.Count; i++)
			{
				if (!(childNodes[i] is XmlElement))
				{
					continue;
				}
				XmlElement xmlElement = (XmlElement)childNodes[i];
				string localName = xmlElement.LocalName;
				switch (localName)
				{
				case "from":
					method_47(xmlElement, class1362_0, bool_3: true);
					continue;
				case "to":
					method_47(xmlElement, class1362_0, bool_3: false);
					continue;
				case "ext":
				{
					string text3 = Class1618.smethod_172(xmlElement, "cx");
					if (text3 != null)
					{
						int num3 = Class1618.smethod_87(text3);
						class1362_0.int_8 = Class1618.smethod_48(num3, int_0);
					}
					string text4 = Class1618.smethod_172(xmlElement, "cy");
					if (text4 != null)
					{
						int num4 = Class1618.smethod_87(text4);
						class1362_0.int_9 = Class1618.smethod_48(num4, int_0);
					}
					continue;
				}
				case "pos":
					if (class1362_0.int_10 == 0)
					{
						string text = Class1618.smethod_172(xmlElement, "x");
						if (text != null)
						{
							int num = Class1618.smethod_87(text);
							class1362_0.int_10 = Class1618.smethod_48(num, int_0);
						}
						string text2 = Class1618.smethod_172(xmlElement, "y");
						if (text2 != null)
						{
							int num2 = Class1618.smethod_87(text2);
							class1362_0.int_11 = Class1618.smethod_48(num2, int_0);
						}
						continue;
					}
					break;
				}
				if (localName == "AlternateContent")
				{
					result = true;
				}
			}
		}
		else
		{
			class1362_0.string_2 = "freeFloating";
			XmlElement xmlElement2 = null;
			if (xmlElement_0.LocalName == "graphicFrame")
			{
				xmlElement2 = Class1618.smethod_173(xmlElement_0, "xfrm");
			}
			else
			{
				XmlElement xmlElement3 = Class1618.smethod_173(xmlElement_0, "spPr");
				if (xmlElement3 == null)
				{
					xmlElement3 = Class1618.smethod_173(xmlElement_0, "grpSpPr");
				}
				if (xmlElement3 != null)
				{
					xmlElement2 = Class1618.smethod_173(xmlElement3, "xfrm");
				}
			}
			if (xmlElement2 == null)
			{
				return result;
			}
			XmlElement xmlElement4 = Class1618.smethod_173(xmlElement2, "off");
			try
			{
				if (xmlElement4 != null)
				{
					string text5 = Class1618.smethod_172(xmlElement4, "x");
					if (text5 != null)
					{
						class1362_0.int_10 = Class1618.smethod_87(text5);
					}
					string string_ = Class1618.smethod_172(xmlElement4, "y");
					double num5 = Class1618.smethod_85(string_);
					if (num5 < 2147483647.0)
					{
						class1362_0.int_11 = (int)num5;
					}
				}
			}
			catch
			{
			}
			XmlElement xmlElement5 = Class1618.smethod_173(xmlElement2, "ext");
			if (xmlElement5 != null)
			{
				string text6 = Class1618.smethod_172(xmlElement5, "cx");
				if (text6 != null)
				{
					class1362_0.int_12 = Class1618.smethod_87(text6);
				}
				string text7 = Class1618.smethod_172(xmlElement5, "cy");
				if (text7 != null)
				{
					class1362_0.int_13 = Class1618.smethod_87(text7);
				}
			}
		}
		return result;
	}

	private void method_47(XmlElement xmlElement_0, Class1362 class1362_0, bool bool_3)
	{
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		for (int i = 0; i < childNodes.Count; i++)
		{
			if (!(childNodes[i] is XmlElement))
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)childNodes[i];
			string localName = xmlElement.LocalName;
			string string_ = Class1188.smethod_13(xmlElement);
			switch (localName)
			{
			case "col":
			{
				int int_ = Class1618.smethod_87(string_);
				if (bool_3)
				{
					class1362_0.int_0 = int_;
				}
				else
				{
					class1362_0.int_4 = int_;
				}
				break;
			}
			case "colOff":
			{
				int num3 = Class1618.smethod_48(Class1618.smethod_87(string_), int_0);
				if (bool_3)
				{
					class1362_0.int_1 = num3;
				}
				else
				{
					class1362_0.int_5 = num3;
				}
				break;
			}
			case "row":
			{
				int num5 = Class1618.smethod_87(string_);
				if (bool_3)
				{
					class1362_0.int_2 = num5;
				}
				else
				{
					class1362_0.int_6 = num5;
				}
				break;
			}
			case "rowOff":
			{
				int num2 = Class1618.smethod_48(Class1618.smethod_87(string_), int_0);
				if (bool_3)
				{
					class1362_0.int_3 = num2;
				}
				else
				{
					class1362_0.int_7 = num2;
				}
				break;
			}
			case "x":
			{
				double num4 = Class1618.smethod_85(string_);
				if (bool_3)
				{
					class1362_0.double_0 = num4;
				}
				else
				{
					class1362_0.double_2 = num4;
				}
				break;
			}
			case "y":
			{
				double num = Class1618.smethod_85(string_);
				if (bool_3)
				{
					class1362_0.double_1 = num;
				}
				else
				{
					class1362_0.double_3 = num;
				}
				break;
			}
			}
		}
	}

	internal ArrayList method_48()
	{
		return arrayList_0;
	}
}
