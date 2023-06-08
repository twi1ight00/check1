using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using ns33;
using ns55;

namespace ns53;

internal class Class1349
{
	private const string string_0 = "/[Content_Types].xml";

	public static void smethod_0(SortedList<string, Class1342> parts)
	{
		parts.TryGetValue("/[Content_Types].xml", out var value);
		if (value == null)
		{
			throw new Exception5("Can't find part \"/[Content_Types].xml\".");
		}
		MemoryStream memoryStream = value.method_0();
		if (memoryStream == null)
		{
			throw new Exception5("contentTypesStream is null when reading \"/[Content_Types].xml\" relationships part");
		}
		try
		{
			Class1295 @class = new Class1295();
			XmlReader xmlReader = Class1181.smethod_0(new StreamReader(memoryStream, detectEncodingFromByteOrderMarks: true), @class.SchemaCollection, @class.ImplicitNamespaces);
			while (xmlReader.Read())
			{
				if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.NamespaceURI == "http://schemas.openxmlformats.org/package/2006/content-types" && xmlReader.LocalName == "Types")
				{
					while (xmlReader.Read() && (xmlReader.NodeType != XmlNodeType.EndElement || !(xmlReader.LocalName == "Types")))
					{
						smethod_1(xmlReader, parts);
						smethod_2(xmlReader, parts);
					}
				}
			}
		}
		catch (Exception exception)
		{
			throw new Exception5("Error reading \"/[Content_Types].xml\" relationships part", exception);
		}
		value.method_5(new Class1295());
		value.Processed = true;
	}

	private static void smethod_1(XmlReader reader, SortedList<string, Class1342> parts)
	{
		if (reader.NodeType != XmlNodeType.Element || !(reader.LocalName == "Override"))
		{
			return;
		}
		string text = null;
		string text2 = null;
		while (reader.MoveToNextAttribute())
		{
			switch (reader.LocalName)
			{
			case "ContentType":
				text2 = reader.Value;
				break;
			case "PartName":
				text = reader.Value;
				break;
			}
		}
		if (text != null && text2 != null)
		{
			Class1342 @class = parts[text];
			@class.method_5(Class1223.smethod_0(text2));
		}
		reader.MoveToElement();
	}

	private static void smethod_2(XmlReader reader, SortedList<string, Class1342> parts)
	{
		if (reader.NodeType != XmlNodeType.Element || !(reader.LocalName == "Default"))
		{
			return;
		}
		string text = null;
		string text2 = null;
		while (reader.MoveToNextAttribute())
		{
			switch (reader.LocalName)
			{
			case "ContentType":
				text2 = reader.Value;
				break;
			case "Extension":
				text = reader.Value.ToLower();
				break;
			}
		}
		if (text != null && text2 != null)
		{
			string value = "." + text;
			string type = text2;
			foreach (Class1342 value2 in parts.Values)
			{
				if (value2.ContentType == null && value2.PartPath.ToLower().EndsWith(value))
				{
					value2.method_5(Class1223.smethod_0(type));
				}
			}
		}
		reader.MoveToElement();
	}

	public static void Write(Class1183 package)
	{
		using MemoryStream memoryStream = new MemoryStream();
		XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
		xmlTextWriter.Indentation = 4;
		xmlTextWriter.Formatting = (package.Indentation ? Formatting.Indented : Formatting.None);
		xmlTextWriter.WriteStartDocument();
		xmlTextWriter.WriteStartElement("Types");
		xmlTextWriter.WriteAttributeString("xmlns", "http://schemas.openxmlformats.org/package/2006/content-types");
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		Class1342[] parts = package.Parts;
		foreach (Class1342 @class in parts)
		{
			string partPath = @class.PartPath;
			int num = partPath.LastIndexOf('.');
			if (num >= 0)
			{
				string key = partPath.Substring(num).ToLower();
				if (!dictionary.TryGetValue(key, out var value))
				{
					dictionary[key] = @class.ContentType.ContentType;
				}
				else if (value != "" && !(value == @class.ContentType.ContentType))
				{
					dictionary[key] = "";
				}
			}
		}
		foreach (KeyValuePair<string, string> item in dictionary)
		{
			string value2 = item.Value;
			if (value2 != "")
			{
				xmlTextWriter.WriteStartElement("Default");
				xmlTextWriter.WriteAttributeString("Extension", item.Key.Substring(1));
				xmlTextWriter.WriteAttributeString("ContentType", value2);
				xmlTextWriter.WriteEndElement();
			}
		}
		Class1342[] parts2 = package.Parts;
		foreach (Class1342 class2 in parts2)
		{
			string partPath2 = class2.PartPath;
			int num2 = partPath2.LastIndexOf('.');
			if (num2 >= 0)
			{
				string key2 = partPath2.Substring(num2).ToLower();
				string text = dictionary[key2];
				if (text != class2.ContentType.ContentType)
				{
					xmlTextWriter.WriteStartElement("Override");
					xmlTextWriter.WriteAttributeString("PartName", partPath2);
					xmlTextWriter.WriteAttributeString("ContentType", class2.ContentType.ContentType);
					xmlTextWriter.WriteEndElement();
				}
			}
		}
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndDocument();
		xmlTextWriter.Flush();
		Class1342 class3 = package.method_4("/[Content_Types].xml", null, new Class1295());
		class3.Data = memoryStream.ToArray();
	}
}
