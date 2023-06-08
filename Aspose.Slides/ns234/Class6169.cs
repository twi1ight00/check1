using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using ns221;

namespace ns234;

internal static class Class6169
{
	public static XmlTextWriter smethod_0(Stream stream, Encoding encoding)
	{
		StreamWriter streamWriter = new StreamWriter(stream, encoding);
		streamWriter.NewLine = "\r\n";
		return new XmlTextWriter(streamWriter);
	}

	public static XmlTextReader smethod_1(Stream stream)
	{
		XmlTextReader xmlTextReader = new XmlTextReader(stream);
		xmlTextReader.XmlResolver = null;
		return xmlTextReader;
	}

	public static XmlTextReader smethod_2(string xml, Hashtable namespaces)
	{
		NameTable nameTable = new NameTable();
		XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(nameTable);
		if (namespaces != null)
		{
			foreach (DictionaryEntry @namespace in namespaces)
			{
				xmlNamespaceManager.AddNamespace((string)@namespace.Key, (string)@namespace.Value);
			}
		}
		XmlParserContext context = new XmlParserContext(nameTable, xmlNamespaceManager, null, XmlSpace.Default);
		XmlTextReader xmlTextReader = new XmlTextReader(xml, XmlNodeType.Document, context);
		xmlTextReader.XmlResolver = null;
		return xmlTextReader;
	}

	[Attribute7(true)]
	public static XmlDocument smethod_3(string xml, bool preserveWhitespace)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.PreserveWhitespace = preserveWhitespace;
		xmlDocument.LoadXml(xml);
		return xmlDocument;
	}

	[Attribute7(true)]
	public static XmlDocument smethod_4(Stream stream)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.PreserveWhitespace = true;
		xmlDocument.Load(stream);
		return xmlDocument;
	}

	[Attribute7(true)]
	public static void smethod_5(string fileName)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.XmlResolver = null;
		xmlDocument.Load(fileName);
	}

	[Attribute7(true)]
	public static void smethod_6(XmlDocument doc, Stream stream)
	{
		doc.Save(stream);
	}

	[Attribute7(true)]
	public static string smethod_7(XmlDocument doc)
	{
		return doc.OuterXml;
	}

	public static IList smethod_8(XmlElement element, string xPath, Hashtable namespaces)
	{
		XmlNodeList xmlNodeList;
		if (namespaces != null)
		{
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
			foreach (DictionaryEntry @namespace in namespaces)
			{
				xmlNamespaceManager.AddNamespace((string)@namespace.Key, (string)@namespace.Value);
			}
			xmlNodeList = element.SelectNodes(xPath, xmlNamespaceManager);
		}
		else
		{
			xmlNodeList = element.SelectNodes(xPath);
		}
		List<XmlNode> list = new List<XmlNode>();
		foreach (XmlNode item in xmlNodeList)
		{
			list.Add(item);
		}
		return list;
	}
}
