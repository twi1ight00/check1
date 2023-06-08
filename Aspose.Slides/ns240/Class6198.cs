using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using ns224;
using ns233;
using ns235;

namespace ns240;

internal class Class6198 : Class6176
{
	private const string string_0 = "http://www.w3.org/2000/svg";

	private const string string_1 = "http://www.w3.org/1999/xlink";

	private Class6685 class6685_0;

	private XmlTextWriter xmlTextWriter_0;

	public void method_0(Class6204 node, string fileName)
	{
		using Stream stream = File.Create(fileName);
		method_2(node, stream, fileName);
	}

	public void method_1(Class6204 node, Stream stream)
	{
		method_2(node, stream, null);
	}

	private void method_2(Class6204 node, Stream stream, string fileName)
	{
		class6685_0 = new Class6685(fileName);
		xmlTextWriter_0 = new XmlTextWriter(stream, Encoding.UTF8);
		xmlTextWriter_0.Namespaces = true;
		xmlTextWriter_0.Formatting = Formatting.Indented;
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("svg");
		xmlTextWriter_0.WriteAttributeString("xmlns", "http://www.w3.org/2000/svg");
		xmlTextWriter_0.WriteAttributeString("xmlns:xlink", "http://www.w3.org/1999/xlink");
		xmlTextWriter_0.WriteStartElement("g");
		xmlTextWriter_0.WriteAttributeString("transform", "scale(1.33333)");
		node.vmethod_0(this);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	public override void vmethod_0(Class6216 page)
	{
		xmlTextWriter_0.WriteStartElement("g");
	}

	public override void vmethod_1(Class6216 page)
	{
		xmlTextWriter_0.WriteEndElement();
	}

	public override void vmethod_2(Class6213 canvas)
	{
		xmlTextWriter_0.WriteStartElement("g");
		Class6002 renderTransform = canvas.RenderTransform;
		method_5("transform", $"matrix({smethod_0(renderTransform.M11)},{smethod_0(renderTransform.M12)},{smethod_0(renderTransform.M21)},{smethod_0(renderTransform.M22)},{smethod_0(renderTransform.M31)},{smethod_0(renderTransform.M32)})");
	}

	public override void vmethod_3(Class6213 canvas)
	{
		xmlTextWriter_0.WriteEndElement();
	}

	public override void vmethod_4(Class6219 glyphs)
	{
		xmlTextWriter_0.WriteStartElement("text");
		method_3("x", glyphs.Origin.X);
		method_3("y", glyphs.Origin.Y);
		Class5999 font = glyphs.Font;
		method_5("font-family", font.FamilyName);
		method_3("font-size", font.SizePoints);
		method_4("fill", glyphs.Color);
		if (font.IsBold)
		{
			method_5("font-weight", "bold");
		}
		if (font.IsItalic)
		{
			method_5("font-style", "italic");
		}
		xmlTextWriter_0.WriteString(glyphs.Text);
		xmlTextWriter_0.WriteEndElement();
	}

	public override void vmethod_11(Class6220 image)
	{
		switch (image.ImageType)
		{
		case Enum788.const_0:
		case Enum788.const_4:
		case Enum788.const_5:
		case Enum788.const_6:
		case Enum788.const_7:
		case Enum788.const_8:
		{
			xmlTextWriter_0.WriteStartElement("image");
			method_3("x", image.Origin.X);
			method_3("y", image.Origin.Y);
			method_3("width", image.Size.Width);
			method_3("height", image.Size.Height);
			string text = class6685_0.method_0(image.ImageType);
			using (Stream stream = File.Create(text))
			{
				stream.Write(image.ImageBytes, 0, image.ImageBytes.Length);
			}
			method_5("xlink:href", class6685_0.method_1(text));
			xmlTextWriter_0.WriteEndElement();
			break;
		}
		case Enum788.const_1:
		case Enum788.const_2:
		case Enum788.const_3:
			break;
		}
	}

	private void method_3(string name, float value)
	{
		xmlTextWriter_0.WriteAttributeString(name, smethod_0(value));
	}

	private void method_4(string name, Class5998 value)
	{
		xmlTextWriter_0.WriteAttributeString(name, smethod_1(value));
	}

	private void method_5(string name, string value)
	{
		xmlTextWriter_0.WriteAttributeString(name, value);
	}

	private static string smethod_0(float value)
	{
		return value.ToString("0.##", CultureInfo.InvariantCulture);
	}

	private static string smethod_1(Class5998 value)
	{
		return $"#{value.R:x2}{value.G:x2}{value.B:x2}";
	}
}
