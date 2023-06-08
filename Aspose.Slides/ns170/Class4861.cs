using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using ns161;
using ns218;
using ns224;
using ns235;
using ns271;

namespace ns170;

internal class Class4861 : Interface148
{
	private string string_0;

	private int int_0;

	private XmlTextWriter xmlTextWriter_0;

	private string string_1;

	private StringBuilder stringBuilder_0 = new StringBuilder();

	private ArrayList arrayList_0;

	private StringBuilder stringBuilder_1 = new StringBuilder();

	public Class4861(string fileName, ArrayList fonts)
	{
		arrayList_0 = fonts;
		string_0 = fileName;
		string_1 = fileName.Replace(".html", string.Empty);
		if (!Directory.Exists(string_1))
		{
			Directory.CreateDirectory(string_1);
		}
	}

	public void imethod_0(float width, float height)
	{
		FileStream w = new FileStream($"{string_0}_{++int_0}.html", FileMode.Create);
		xmlTextWriter_0 = new XmlTextWriter(w, Encoding.UTF8);
		xmlTextWriter_0.Formatting = Formatting.Indented;
		xmlTextWriter_0.WriteStartDocument();
		xmlTextWriter_0.WriteStartElement("html");
		xmlTextWriter_0.WriteStartElement("head");
		xmlTextWriter_0.WriteStartElement("link");
		xmlTextWriter_0.WriteAttributeString("href", "./" + Path.GetFileNameWithoutExtension(string_0) + "/style.css");
		xmlTextWriter_0.WriteAttributeString("type", "text/css");
		xmlTextWriter_0.WriteAttributeString("rel", "Stylesheet");
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteStartElement("body");
	}

	public void imethod_1()
	{
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Close();
		using StreamWriter streamWriter = new StreamWriter(string_1 + "\\style.css");
		streamWriter.Write(stringBuilder_0.ToString());
	}

	public void imethod_2(float marginTop, float maxWidth, float lineHeight)
	{
		xmlTextWriter_0.WriteStartElement("p");
		xmlTextWriter_0.WriteAttributeString("style", string.Format(CultureInfo.InvariantCulture, "line-height:{0}pt; max-width:{1}pt; margin-top:{2}", new object[3] { lineHeight, maxWidth, marginTop }));
	}

	public void imethod_3()
	{
		xmlTextWriter_0.WriteEndElement();
	}

	public void imethod_4()
	{
		stringBuilder_1 = new StringBuilder();
	}

	public void imethod_5(float rightSpace)
	{
		rightSpace -= 4.7f;
		if (rightSpace > 0f)
		{
			stringBuilder_1.Append("<span style=\"margin-left:").Append(rightSpace.ToString(CultureInfo.InvariantCulture)).Append("pt\">")
				.Append(" ")
				.Append("</span>");
		}
		xmlTextWriter_0.WriteRaw(stringBuilder_1.Append("\n").ToString());
	}

	public void imethod_6(Class6730 font, string fontName, float fontSize, FontStyle style, Class5998 color, float leftMargin, string text)
	{
		string path = string_1 + "\\" + fontName;
		if (!arrayList_0.Contains(fontName))
		{
			using (FileStream dstStream = new FileStream(path, FileMode.Create))
			{
				using Stream stream = font.Data.vmethod_0();
				stream.Seek(0L, SeekOrigin.Begin);
				Class5964.smethod_9(stream, dstStream);
			}
			stringBuilder_0.Append("@font-face\n{\nfont-family: '").Append(font.FullFontName).Append("';\n")
				.Append("src: url(./")
				.Append(fontName)
				.Append(");\n}");
			arrayList_0.Add(fontName);
		}
		stringBuilder_1.Append("<span style=\"").Append(string.Format(CultureInfo.InvariantCulture, "font-family:'{0}'; font-size:{1}pt; margin-left:{2}pt", new object[3] { font.FullFontName, fontSize, leftMargin }));
		stringBuilder_1.Append("\">").Append(text).Append("</span>");
	}

	public void imethod_7(Class6730 font, string fontName, float fontSize, FontStyle style, Class5998 color, string text, string href)
	{
		throw new NotImplementedException();
	}

	public void method_0(Class5998 color, string text)
	{
	}

	public void imethod_8(float indentLeft, float indentTop, Class6220 image, string name)
	{
	}
}
