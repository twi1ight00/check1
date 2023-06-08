using System.Collections;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns16;
using ns21;
using ns22;
using ns26;

namespace ns15;

internal class Class1520
{
	private XmlTextWriter xmlTextWriter_0;

	private Class1498 class1498_0;

	public Class1520(Class1498 class1498_1)
	{
		class1498_0 = class1498_1;
	}

	internal void Write(ArrayList arrayList_0, Stream6 stream6_0)
	{
		xmlTextWriter_0 = Class1522.smethod_1("styles.xml", stream6_0);
		Class1504 value = new Class1504("text/xml", "styles.xml");
		arrayList_0.Add(value);
		xmlTextWriter_0.WriteStartDocument();
		xmlTextWriter_0.WriteStartElement("office:document-styles");
		xmlTextWriter_0.WriteAttributeString("xmlns", "office", null, "urn:oasis:names:tc:opendocument:xmlns:office:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "style", null, "urn:oasis:names:tc:opendocument:xmlns:style:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "text", null, "urn:oasis:names:tc:opendocument:xmlns:text:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "table", null, "urn:oasis:names:tc:opendocument:xmlns:table:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "draw", null, "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "fo", null, "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "xlink", null, "http://www.w3.org/1999/xlink");
		xmlTextWriter_0.WriteAttributeString("xmlns", "dc", null, "http://purl.org/dc/elements/1.1/");
		xmlTextWriter_0.WriteAttributeString("xmlns", "meta", null, "urn:oasis:names:tc:opendocument:xmlns:meta:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "number", null, "urn:oasis:names:tc:opendocument:xmlns:datastyle:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "svg", null, "urn:oasis:names:tc:opendocument:xmlns:svg-compatible:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "chart", null, "urn:oasis:names:tc:opendocument:xmlns:chart:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "dr3d", null, "urn:oasis:names:tc:opendocument:xmlns:dr3d:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "math", null, "http://www.w3.org/1998/Math/MathML");
		xmlTextWriter_0.WriteAttributeString("xmlns", "form", null, "urn:oasis:names:tc:opendocument:xmlns:form:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "script", null, "urn:oasis:names:tc:opendocument:xmlns:script:1.0");
		xmlTextWriter_0.WriteAttributeString("xmlns", "ooo", null, "http://openoffice.org/2004/office");
		xmlTextWriter_0.WriteAttributeString("xmlns", "ooow", null, "http://openoffice.org/2004/writer");
		xmlTextWriter_0.WriteAttributeString("xmlns", "oooc", null, "http://openoffice.org/2004/calc");
		xmlTextWriter_0.WriteAttributeString("xmlns", "dom", null, "http://www.w3.org/2001/xml-events");
		xmlTextWriter_0.WriteAttributeString("office", "version", null, "1.1");
		method_0();
		method_1();
		Class1495 @class = new Class1495(class1498_0);
		@class.Write(xmlTextWriter_0);
		Class1509 class2 = new Class1509(class1498_0);
		class2.Write(xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	[Attribute0(true)]
	private void method_0()
	{
		xmlTextWriter_0.WriteStartElement("office:font-face-decls");
		foreach (Class1500 item in class1498_0.arrayList_0)
		{
			method_3(item);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_1()
	{
		xmlTextWriter_0.WriteStartElement("office:styles");
		foreach (Class1502 item in class1498_0.arrayList_3)
		{
			method_5(item);
		}
		Class1519 @class = new Class1519(class1498_0, xmlTextWriter_0);
		foreach (Class1496 item2 in class1498_0.arrayList_4)
		{
			if (item2.style_0.Name != null)
			{
				@class.method_11(item2);
			}
		}
		if (class1498_0.workbook_0.Worksheets != null && class1498_0.workbook_0.Worksheets.Count > 0)
		{
			foreach (Worksheet worksheet in class1498_0.workbook_0.Worksheets)
			{
				if (worksheet.Shapes == null || worksheet.Shapes.Count <= 0)
				{
					continue;
				}
				foreach (Shape shape in worksheet.Shapes)
				{
					method_2(shape);
				}
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_2(Shape shape_0)
	{
		if (shape_0 != null)
		{
			xmlTextWriter_0.WriteStartElement("draw:fill-image");
			int num = shape_0.method_26().Index + shape_0.Index + 1;
			xmlTextWriter_0.WriteAttributeString("draw", "name", null, "D" + num);
			MsoFillFormat fillFormat = shape_0.FillFormat;
			Enum174 @enum = fillFormat.method_4();
			if (@enum == Enum174.const_2)
			{
				xmlTextWriter_0.WriteAttributeString("xlink", "href", null, fillFormat.method_2());
			}
			xmlTextWriter_0.WriteAttributeString("xlink", "show", null, "embed");
			xmlTextWriter_0.WriteAttributeString("xlink", "actuate", null, "onLoad");
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_3(Class1500 class1500_0)
	{
		xmlTextWriter_0.WriteStartElement("style:font-face ");
		xmlTextWriter_0.WriteAttributeString("style", "name", null, class1500_0.Name);
		xmlTextWriter_0.WriteAttributeString("svg", "font-family", null, class1500_0.Name);
		if (!Class1516.smethod_0(class1500_0.method_0()))
		{
			xmlTextWriter_0.WriteAttributeString("style", "font-family-generic", null, class1500_0.method_0());
		}
		if (!Class1516.smethod_0(class1500_0.method_1()))
		{
			xmlTextWriter_0.WriteAttributeString("style", "font-pitch", null, class1500_0.method_1());
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_4(Class1506 class1506_0, string string_0)
	{
		for (int i = 0; i < class1506_0.arrayList_0.Count; i++)
		{
			string[] array = (string[])class1506_0.arrayList_0[i];
			xmlTextWriter_0.WriteAttributeString(string_0, array[0], null, array[1]);
		}
	}

	[Attribute0(true)]
	private void method_5(Class1502 class1502_0)
	{
		string localName = null;
		switch (class1502_0.enum214_0)
		{
		case Enum214.const_0:
			localName = "number:currency-style";
			break;
		case Enum214.const_1:
			localName = "number:number-style";
			break;
		case Enum214.const_2:
			localName = "number:date-style";
			break;
		case Enum214.const_3:
			localName = "number:time-style";
			break;
		case Enum214.const_4:
			localName = "boolean-style";
			break;
		case Enum214.const_5:
			localName = "number:text-style";
			break;
		case Enum214.const_6:
			localName = "number:percentage-style";
			break;
		case Enum214.const_7:
			localName = "number:text-style";
			break;
		}
		xmlTextWriter_0.WriteStartElement(localName);
		xmlTextWriter_0.WriteAttributeString("style", "name", null, class1502_0.string_0);
		for (int i = 0; i < class1502_0.arrayList_0.Count; i++)
		{
			string[] array = (string[])class1502_0.arrayList_0[i];
			string[] array2 = array[0].Split(':');
			xmlTextWriter_0.WriteAttributeString(array2[0], array2[1], null, array[1]);
		}
		for (int j = 0; j < class1502_0.arrayList_1.Count; j++)
		{
			Class1506 @class = (Class1506)class1502_0.arrayList_1[j];
			switch (@class.enum213_0)
			{
			case Enum213.const_0:
				xmlTextWriter_0.WriteStartElement("number:text");
				if (!Class1516.smethod_0(@class.string_0))
				{
					xmlTextWriter_0.WriteString(@class.string_0);
				}
				xmlTextWriter_0.WriteEndElement();
				break;
			case Enum213.const_1:
				xmlTextWriter_0.WriteStartElement("number:text-content");
				xmlTextWriter_0.WriteEndElement();
				break;
			case Enum213.const_2:
				xmlTextWriter_0.WriteStartElement("style:text-properties");
				method_4(@class, "fo");
				xmlTextWriter_0.WriteEndElement();
				break;
			case Enum213.const_3:
				xmlTextWriter_0.WriteStartElement("number:currency-symbol");
				xmlTextWriter_0.WriteEndElement();
				break;
			case Enum213.const_4:
				xmlTextWriter_0.WriteStartElement("number:number");
				method_4(@class, "number");
				xmlTextWriter_0.WriteEndElement();
				break;
			case Enum213.const_5:
				xmlTextWriter_0.WriteStartElement("style:map");
				method_4(@class, "style");
				xmlTextWriter_0.WriteEndElement();
				break;
			case Enum213.const_6:
				xmlTextWriter_0.WriteStartElement("number:year");
				method_4(@class, "number");
				xmlTextWriter_0.WriteEndElement();
				break;
			case Enum213.const_7:
				xmlTextWriter_0.WriteStartElement("number:month");
				method_4(@class, "number");
				xmlTextWriter_0.WriteEndElement();
				break;
			case Enum213.const_8:
				xmlTextWriter_0.WriteStartElement("number:day");
				method_4(@class, "number");
				xmlTextWriter_0.WriteEndElement();
				break;
			case Enum213.const_9:
				xmlTextWriter_0.WriteStartElement("number:hours");
				method_4(@class, "number");
				xmlTextWriter_0.WriteEndElement();
				break;
			case Enum213.const_10:
				xmlTextWriter_0.WriteStartElement("number:minutes");
				method_4(@class, "number");
				xmlTextWriter_0.WriteEndElement();
				break;
			case Enum213.const_11:
				xmlTextWriter_0.WriteStartElement("number:seconds");
				method_4(@class, "number");
				xmlTextWriter_0.WriteEndElement();
				break;
			case Enum213.const_12:
				xmlTextWriter_0.WriteStartElement("number:am-pm");
				xmlTextWriter_0.WriteEndElement();
				break;
			case Enum213.const_13:
				xmlTextWriter_0.WriteStartElement("number:fraction");
				method_4(@class, "number");
				xmlTextWriter_0.WriteEndElement();
				break;
			case Enum213.const_14:
				xmlTextWriter_0.WriteStartElement("number:scientific-number");
				method_4(@class, "number");
				xmlTextWriter_0.WriteEndElement();
				break;
			case Enum213.const_15:
				xmlTextWriter_0.WriteStartElement("number:day-of-week");
				method_4(@class, "number");
				xmlTextWriter_0.WriteEndElement();
				break;
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}
}
