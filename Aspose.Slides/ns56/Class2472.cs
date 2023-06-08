using System;
using System.IO;
using System.Text;
using System.Xml;
using ns33;

namespace ns56;

internal class Class2472
{
	private const string string_0 = "{E40237B7-FDA0-4F09-8148-C483321AD2D9}";

	private const string string_1 = "http://schemas.microsoft.com/office/drawing/2008/diagram";

	private const string string_2 = "http://schemas.openxmlformats.org/drawingml/2006/main";

	private const string string_3 = "http://schemas.microsoft.com/office/drawing/2010/diagram";

	public static Class1451 smethod_0(Class1885 extensions)
	{
		return smethod_7(extensions, "http://schemas.microsoft.com/office/drawing/2008/diagram");
	}

	public static void smethod_1(Class1885 extensions, string relId)
	{
		Class1451 @class = smethod_6(extensions, "http://schemas.microsoft.com/office/drawing/2008/diagram");
		XmlElement xmlElement = @class.XmlDocument.CreateElement("dsp", "dataModelExt", "http://schemas.microsoft.com/office/drawing/2008/diagram");
		xmlElement.SetAttribute("relId", relId);
		xmlElement.SetAttribute("minVer", "http://schemas.openxmlformats.org/drawingml/2006/main");
		@class.XmlDocument.DocumentElement.AppendChild(xmlElement);
	}

	public static Class1880 smethod_2(Class1885 extensions)
	{
		Class1451 @class = smethod_7(extensions, "{E40237B7-FDA0-4F09-8148-C483321AD2D9}");
		try
		{
			if (@class != null)
			{
				using StringReader input = new StringReader(@class.XmlDocument.DocumentElement.InnerXml);
				using XmlTextReader xmlTextReader = new XmlTextReader(input);
				while (!xmlTextReader.EOF && xmlTextReader.NodeType != XmlNodeType.Element)
				{
					xmlTextReader.Read();
				}
				if (!xmlTextReader.EOF)
				{
					return new Class1880(xmlTextReader);
				}
			}
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
		}
		return null;
	}

	public static void smethod_3(Class1885 extensions, Class1880 nonDrawingProps)
	{
		Class1451 @class = smethod_6(extensions, "{E40237B7-FDA0-4F09-8148-C483321AD2D9}");
		try
		{
			using MemoryStream memoryStream = new MemoryStream();
			using XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
			xmlTextWriter.WriteStartElement("a", "ext", "http://schemas.openxmlformats.org/drawingml/2006/main");
			xmlTextWriter.WriteAttributeString("uri", "{E40237B7-FDA0-4F09-8148-C483321AD2D9}");
			smethod_4(xmlTextWriter, nonDrawingProps);
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.Flush();
			memoryStream.Position = 0L;
			@class.XmlDocument.Load(memoryStream);
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
		}
	}

	private static void smethod_4(XmlWriter writer, Class1880 nonDrawingProps)
	{
		writer.WriteStartElement("dgm14", "cNvPr", "http://schemas.microsoft.com/office/drawing/2010/diagram");
		writer.WriteAttributeString("id", XmlConvert.ToString(nonDrawingProps.Id));
		writer.WriteAttributeString("name", nonDrawingProps.Name);
		if (nonDrawingProps.Descr != "")
		{
			writer.WriteAttributeString("descr", nonDrawingProps.Descr);
		}
		if (nonDrawingProps.Title != null)
		{
			writer.WriteAttributeString("title", nonDrawingProps.Title);
		}
		if (nonDrawingProps.Hidden)
		{
			writer.WriteAttributeString("hidden", nonDrawingProps.Hidden ? "1" : "0");
		}
		if (nonDrawingProps.HlinkClick != null)
		{
			smethod_5(writer, "hlinkClick", nonDrawingProps.HlinkClick);
		}
		if (nonDrawingProps.HlinkHover != null)
		{
			smethod_5(writer, "hlinkHover", nonDrawingProps.HlinkHover);
		}
		writer.WriteEndElement();
	}

	private static void smethod_5(XmlWriter writer, string elementName, Class1865 hyperlink)
	{
		writer.WriteStartElement("a", elementName, null);
		writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		if (hyperlink.R_Id != null)
		{
			writer.WriteAttributeString("r", "id", null, hyperlink.R_Id);
		}
		if (hyperlink.InvalidUrl != "")
		{
			writer.WriteAttributeString("invalidUrl", hyperlink.InvalidUrl);
		}
		if (hyperlink.Action != "")
		{
			writer.WriteAttributeString("action", hyperlink.Action);
		}
		if (hyperlink.TgtFrame != "")
		{
			writer.WriteAttributeString("tgtFrame", hyperlink.TgtFrame);
		}
		if (hyperlink.Tooltip != "")
		{
			writer.WriteAttributeString("tooltip", hyperlink.Tooltip);
		}
		if (!hyperlink.History)
		{
			writer.WriteAttributeString("history", hyperlink.History ? "1" : "0");
		}
		if (hyperlink.HighlightClick)
		{
			writer.WriteAttributeString("highlightClick", hyperlink.HighlightClick ? "1" : "0");
		}
		if (hyperlink.EndSnd)
		{
			writer.WriteAttributeString("endSnd", hyperlink.EndSnd ? "1" : "0");
		}
		if (hyperlink.Snd != null)
		{
			writer.WriteStartElement("a", "snd", null);
			writer.WriteAttributeString("r", "embed", hyperlink.Snd.R_Embed);
			if (hyperlink.Snd.Name != "")
			{
				writer.WriteAttributeString("name", hyperlink.Snd.Name);
			}
			if (hyperlink.Snd.BuiltIn)
			{
				writer.WriteAttributeString("builtIn", hyperlink.Snd.BuiltIn ? "1" : "0");
			}
			writer.WriteEndElement();
		}
		writer.WriteEndElement();
	}

	private static Class1451 smethod_6(Class1885 extensions, string uri)
	{
		Class1451 @class = smethod_7(extensions, uri);
		if (@class == null)
		{
			@class = (Class1451)extensions.delegate383_0();
			@class.OuterXml = string.Format("<a:ext uri=\"{0}\" xmlns:a=\"{1}\"></a:ext>", uri, "http://schemas.openxmlformats.org/drawingml/2006/main");
		}
		return @class;
	}

	private static Class1451 smethod_7(Class1885 extensions, string uri)
	{
		if (extensions == null)
		{
			return null;
		}
		Class1449[] extList = extensions.ExtList;
		int num = 0;
		Class1451 @class;
		while (true)
		{
			if (num < extList.Length)
			{
				@class = (Class1451)extList[num];
				XmlAttribute xmlAttribute = @class.XmlDocument.DocumentElement.Attributes["uri"];
				if (xmlAttribute != null && xmlAttribute.Value == uri)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class;
	}
}
