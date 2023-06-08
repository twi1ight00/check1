using System.Xml;
using Aspose.Cells.Drawing;
using ns22;

namespace ns16;

internal class Class1582
{
	private Class1541 class1541_0;

	private int int_0;

	private int int_1 = 1;

	internal Class1582(Class1541 class1541_1)
	{
		class1541_0 = class1541_1;
		int_0 = class1541_0.workbook_0.Worksheets.method_75();
	}

	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("xml");
		xmlTextWriter_0.WriteAttributeString("xmlns", "v", null, "urn:schemas-microsoft-com:vml");
		xmlTextWriter_0.WriteAttributeString("xmlns", "o", null, "urn:schemas-microsoft-com:office:office");
		xmlTextWriter_0.WriteAttributeString("xmlns", "x", null, "urn:schemas-microsoft-com:office:excel");
		method_0(xmlTextWriter_0);
		method_1(xmlTextWriter_0);
		ShapeCollection shapeCollection = class1541_0.worksheet_0.PageSetup.method_32();
		for (int i = 0; i < shapeCollection.Count; i++)
		{
			Picture picture_ = (Picture)shapeCollection[i];
			method_5(xmlTextWriter_0, picture_);
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.Flush();
	}

	[Attribute0(true)]
	private void method_0(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("o:shapelayout", null);
		xmlTextWriter_0.WriteAttributeString("v:ext", null, "edit");
		xmlTextWriter_0.WriteStartElement("o:idmap", null);
		xmlTextWriter_0.WriteAttributeString("v:ext", null, "edit");
		xmlTextWriter_0.WriteAttributeString("data", "1");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_1(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("v:shapetype", null);
		xmlTextWriter_0.WriteAttributeString("id", "_x0000_t75");
		xmlTextWriter_0.WriteAttributeString("coordsize", "21600,21600");
		xmlTextWriter_0.WriteAttributeString("o:spt", null, "75");
		xmlTextWriter_0.WriteAttributeString("o:preferrelative", null, "t");
		xmlTextWriter_0.WriteAttributeString("path", "m@4@5l@4@11@9@11@9@5xe");
		xmlTextWriter_0.WriteAttributeString("filled", "f");
		xmlTextWriter_0.WriteAttributeString("stroked", "f");
		xmlTextWriter_0.WriteStartElement("v:stroke", null);
		xmlTextWriter_0.WriteAttributeString("joinstyle", "miter");
		xmlTextWriter_0.WriteEndElement();
		method_3(xmlTextWriter_0);
		xmlTextWriter_0.WriteStartElement("v:path", null);
		xmlTextWriter_0.WriteAttributeString("o:extrusionok", null, "f");
		xmlTextWriter_0.WriteAttributeString("gradientshapeok", "t");
		xmlTextWriter_0.WriteAttributeString("o:connecttype", null, "rect");
		xmlTextWriter_0.WriteEndElement();
		method_2(xmlTextWriter_0, bool_0: true);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_2(XmlTextWriter xmlTextWriter_0, bool bool_0)
	{
		xmlTextWriter_0.WriteStartElement("o:lock", null);
		xmlTextWriter_0.WriteAttributeString("v:ext", null, "edit");
		if (bool_0)
		{
			xmlTextWriter_0.WriteAttributeString("aspectratio", "t");
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("rotation", "t");
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_3(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("v:formulas", null);
		method_4(xmlTextWriter_0, "if lineDrawn pixelLineWidth 0");
		method_4(xmlTextWriter_0, "sum @0 1 0");
		method_4(xmlTextWriter_0, "sum 0 0 @1");
		method_4(xmlTextWriter_0, "prod @2 1 2");
		method_4(xmlTextWriter_0, "prod @3 21600 pixelWidth");
		method_4(xmlTextWriter_0, "prod @3 21600 pixelHeight");
		method_4(xmlTextWriter_0, "sum @0 0 1");
		method_4(xmlTextWriter_0, "prod @6 1 2");
		method_4(xmlTextWriter_0, "prod @7 21600 pixelWidth");
		method_4(xmlTextWriter_0, "sum @8 21600 0");
		method_4(xmlTextWriter_0, "prod @7 21600 pixelHeight");
		method_4(xmlTextWriter_0, "sum @10 21600 0");
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_4(XmlTextWriter xmlTextWriter_0, string string_0)
	{
		xmlTextWriter_0.WriteStartElement("v:f", null);
		xmlTextWriter_0.WriteAttributeString("eqn", string_0);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_5(XmlTextWriter xmlTextWriter_0, Picture picture_0)
	{
		xmlTextWriter_0.WriteStartElement("v:shape", null);
		xmlTextWriter_0.WriteAttributeString("id", picture_0.Name);
		xmlTextWriter_0.WriteAttributeString("type", "#_x0000_t75");
		xmlTextWriter_0.WriteAttributeString("style", method_6(picture_0));
		xmlTextWriter_0.WriteStartElement("v:imagedata", null);
		string value = (string)class1541_0.class1534_0.hashtable_0[picture_0.method_70()];
		xmlTextWriter_0.WriteAttributeString("o:relid", null, value);
		if (picture_0.FormatPicture.TopCrop > 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("croptop", Class1618.smethod_79(picture_0.FormatPicture.TopCrop * 65536.0) + "f");
		}
		if (picture_0.FormatPicture.BottomCrop > 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("cropbottom", Class1618.smethod_79(picture_0.FormatPicture.BottomCrop * 65536.0) + "f");
		}
		if (picture_0.FormatPicture.LeftCrop > 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("cropleft", Class1618.smethod_79(picture_0.FormatPicture.LeftCrop * 65536.0) + "f");
		}
		if (picture_0.FormatPicture.RightCrop > 0.0)
		{
			xmlTextWriter_0.WriteAttributeString("cropright", Class1618.smethod_79(picture_0.FormatPicture.RightCrop * 65536.0) + "f");
		}
		xmlTextWriter_0.WriteEndElement();
		method_2(xmlTextWriter_0, bool_0: false);
		xmlTextWriter_0.WriteEndElement();
	}

	private string method_6(Shape shape_0)
	{
		string result = "position:absolute;margin-left:" + shape_0.method_38() + "px;margin-top:" + shape_0.method_36() + "px;width:" + Class1618.smethod_80(shape_0.Width) + "px;height:" + Class1618.smethod_80(shape_0.Height) + "px;z-index:" + int_1 + ";";
		int_1++;
		return result;
	}
}
