using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns16;
using ns2;
using ns22;
using ns26;

namespace ns15;

internal class Class1522
{
	internal ArrayList arrayList_0;

	private Stream6 stream6_0;

	private Workbook workbook_0;

	internal Class1498 class1498_0;

	private XmlTextWriter xmlTextWriter_0;

	private static void smethod_0(WorksheetCollection worksheetCollection_0)
	{
		if (Class972.smethod_0() == Enum134.const_0)
		{
			for (int i = 0; i < worksheetCollection_0.Count; i++)
			{
				worksheetCollection_0[i].IsSelected = false;
			}
			Worksheet worksheet_ = worksheetCollection_0[worksheetCollection_0.Add()];
			Class1677.smethod_36(worksheet_);
		}
	}

	public Class1522(Workbook workbook_1)
	{
		smethod_0(workbook_1.Worksheets);
		workbook_0 = workbook_1;
		class1498_0 = new Class1498(workbook_0);
		arrayList_0 = new ArrayList();
	}

	internal void Write(Stream stream_0)
	{
		stream6_0 = new Stream6(stream_0);
		stream6_0.method_6(Enum42.const_4);
		stream6_0.method_10(Enum32.const_0);
		method_8();
		class1498_0.method_2();
		Class1504 value = new Class1504("application/vnd.oasis.opendocument.spreadsheet", "/");
		arrayList_0.Add(value);
		method_0();
		Class1520 @class = new Class1520(class1498_0);
		@class.Write(arrayList_0, stream6_0);
		Class1517 class2 = new Class1517(class1498_0);
		class2.Write(arrayList_0, stream6_0);
		method_5();
		method_4();
		stream6_0.method_22();
		class1498_0.method_1();
	}

	internal void method_0()
	{
		xmlTextWriter_0 = smethod_1("content.xml", stream6_0);
		Class1504 value = new Class1504("text/xml", "content.xml");
		arrayList_0.Add(value);
		xmlTextWriter_0.WriteStartDocument();
		xmlTextWriter_0.WriteStartElement("office:document-content");
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
		xmlTextWriter_0.WriteAttributeString("xmlns", "xforms", null, "http://www.w3.org/2002/xforms");
		xmlTextWriter_0.WriteAttributeString("xmlns", "xsd", null, "http://www.w3.org/2001/XMLSchema");
		xmlTextWriter_0.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
		xmlTextWriter_0.WriteAttributeString("office", "version", null, "1.1");
		Class1519 @class = new Class1519(class1498_0);
		@class.Write(xmlTextWriter_0);
		method_1();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	private void method_1()
	{
		xmlTextWriter_0.WriteStartElement("office:body");
		method_2();
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_2()
	{
		xmlTextWriter_0.WriteStartElement("office:spreadsheet");
		for (int i = 0; i < class1498_0.arrayList_5.Count; i++)
		{
			workbook_0.method_30();
			Class1524 @class = new Class1524((Class1499)class1498_0.arrayList_5[i]);
			@class.Write(xmlTextWriter_0);
		}
		method_3();
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_3()
	{
		NameCollection names = workbook_0.Worksheets.Names;
		if (names.Count == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("table:named-expressions");
		for (int i = 0; i < names.Count; i++)
		{
			Name name = names[i];
			xmlTextWriter_0.WriteStartElement("table:named-expression");
			string value = name.Text;
			switch (name.method_25())
			{
			case 13:
				value = "Excel_BuiltIn__FilterDatabase_" + name.SheetIndex;
				break;
			case 6:
				value = "Excel_BuiltIn_Print_Area_" + name.SheetIndex;
				break;
			case 7:
				value = "Excel_BuiltIn_Print_Titles_" + name.SheetIndex;
				break;
			}
			xmlTextWriter_0.WriteAttributeString("table", "name", null, value);
			int num = name.SheetIndex - 1;
			if (num < 0)
			{
				num = name.method_24();
				if (num < 0 || num >= workbook_0.Worksheets.Count)
				{
					num = 0;
				}
			}
			xmlTextWriter_0.WriteAttributeString("table", "base-cell-address", null, "$" + workbook_0.Worksheets[num].Name + ".$A$1");
			string text = Class1516.smethod_32(workbook_0.Worksheets, name);
			if (text != null && text != "" && text[0] == '=')
			{
				text = text.Substring(1);
			}
			xmlTextWriter_0.WriteAttributeString("table", "expression", null, text);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	internal void method_4()
	{
		XmlTextWriter xmlTextWriter = smethod_1("META-INF/manifest.xml", stream6_0);
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

	internal void method_5()
	{
		Hashtable hashtable = new Hashtable();
		if (class1498_0.workbook_0.Worksheets == null || class1498_0.workbook_0.Worksheets.Count <= 0)
		{
			return;
		}
		foreach (Worksheet worksheet in class1498_0.workbook_0.Worksheets)
		{
			if (worksheet.Shapes == null || worksheet.Shapes.Count <= 0)
			{
				continue;
			}
			foreach (Shape shape in worksheet.Shapes)
			{
				switch (shape.MsoDrawingType)
				{
				case MsoDrawingType.OleObject:
				{
					OleObject oleObject = (OleObject)shape;
					string text3 = "MSO_OLE_OBJ" + Class1025.smethod_7(oleObject.method_97());
					if (!method_6(text3, oleObject.ObjectData))
					{
						method_7(text3, oleObject.ObjectData);
						arrayList_0.Add(new Class1504("application/vnd.sun.star.oleobject", text3));
					}
					else
					{
						arrayList_0.Add(new Class1504("application/vnd.oasis.opendocument.text", text3));
					}
					if (hashtable[oleObject.method_75()] == null)
					{
						method_7("ObjectReplacements/Object " + oleObject.method_75(), oleObject.ImageData);
						arrayList_0.Add(new Class1504("application/x-openoffice-wmf;windows_formatname=&quot;Image WMF&quot;", "ObjectReplacements/Object " + oleObject.method_75()));
						hashtable.Add(oleObject.method_75(), true);
					}
					break;
				}
				case MsoDrawingType.Chart:
				{
					string text = Class1516.smethod_50((ChartShape)shape);
					string text2 = "Object " + text;
					arrayList_0.Add(new Class1504("text/xml", text2 + "/content.xml"));
					arrayList_0.Add(new Class1504("text/xml", text2 + "/styles.xml"));
					arrayList_0.Add(new Class1504("text/xml", text2 + "/meta.xml"));
					arrayList_0.Add(new Class1504("application/vnd.oasis.opendocument.chart", text2));
					Class525 @class = new Class525(stream6_0, (ChartShape)shape, text);
					@class.Write();
					break;
				}
				case MsoDrawingType.TextBox:
				{
					MsoFillFormat fillFormat = shape.FillFormat;
					if (fillFormat.ImageData != null)
					{
						method_7(fillFormat.method_2(), fillFormat.ImageData);
					}
					arrayList_0.Add(new Class1504("image/jpeg", fillFormat.method_2()));
					break;
				}
				case MsoDrawingType.Picture:
				{
					Picture picture = (Picture)shape;
					if (hashtable[picture.method_70()] == null)
					{
						method_7("Pictures/" + picture.method_70() + "." + picture.ImageFormat, picture.Data);
						arrayList_0.Add(new Class1504("image/jpeg", "Pictures/" + picture.method_70() + "." + picture.ImageFormat));
						hashtable.Add(picture.method_70(), true);
					}
					break;
				}
				}
			}
		}
	}

	private bool method_6(string string_0, byte[] byte_0)
	{
		if (byte_0 == null)
		{
			return false;
		}
		MemoryStream memoryStream = new MemoryStream(byte_0);
		if (!Class1677.smethod_6(memoryStream))
		{
			return false;
		}
		Class746 @class = Class746.Read(memoryStream);
		IEnumerator enumerator = @class.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class744 class2 = (Class744)enumerator.Current;
			if (!class2.method_18() && !(class2.Name == "META-INF/manifest.xml"))
			{
				Stream stream = @class.method_39(class2);
				byte[] array = new byte[(int)class2.Size];
				stream.Read(array, 0, (int)class2.Size);
				stream.Close();
				Class744 class3 = stream6_0.method_18(string_0 + "/" + class2.Name);
				class3.method_5(DateTime.Now);
				stream6_0.Write(array, 0, array.Length);
				stream6_0.Flush();
				arrayList_0.Add(new Class1504("text/xml", string_0 + "/" + class2.Name));
			}
		}
		memoryStream.Close();
		@class.Close();
		return true;
	}

	private void method_7(string string_0, byte[] byte_0)
	{
		if (byte_0 != null)
		{
			Class744 @class = stream6_0.method_18(string_0);
			@class.method_5(DateTime.Now);
			stream6_0.Write(byte_0, 0, byte_0.Length);
			stream6_0.Flush();
		}
	}

	internal static XmlTextWriter smethod_1(string string_0, Stream6 stream6_1)
	{
		Class744 @class = stream6_1.method_18(string_0);
		@class.method_5(DateTime.Now);
		return new XmlTextWriter(stream6_1, Encoding.UTF8);
	}

	internal void method_8()
	{
		if (workbook_0.method_33().Count > 0)
		{
			IDictionaryEnumerator enumerator = workbook_0.method_33().GetEnumerator();
			while (enumerator.MoveNext())
			{
				byte[] array = (byte[])enumerator.Value;
				Class744 @class = stream6_0.method_18((string)enumerator.Key);
				@class.method_5(DateTime.Now);
				stream6_0.Write(array, 0, array.Length);
				Class1504 value = new Class1504("text/xml", (string)enumerator.Key);
				arrayList_0.Add(value);
			}
		}
	}
}
