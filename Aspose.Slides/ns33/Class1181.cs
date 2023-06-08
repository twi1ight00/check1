using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace ns33;

internal class Class1181
{
	internal static string string_0 = "";

	public static XmlReader smethod_0(TextReader reader, XmlSchemaCollection schemaCollection, SortedList<string, string> implicitNamespaces)
	{
		NameTable nameTable = new NameTable();
		XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(nameTable);
		if (implicitNamespaces != null)
		{
			foreach (KeyValuePair<string, string> implicitNamespace in implicitNamespaces)
			{
				xmlNamespaceManager.AddNamespace(implicitNamespace.Key, implicitNamespace.Value);
			}
		}
		XmlParserContext inputContext = new XmlParserContext(null, xmlNamespaceManager, null, XmlSpace.None);
		XmlReaderSettings settings = new XmlReaderSettings();
		XmlReader xmlReader = XmlReader.Create(reader, settings, inputContext);
		if (schemaCollection != null)
		{
			XmlValidatingReader xmlValidatingReader = new XmlValidatingReader(xmlReader);
			xmlValidatingReader.Schemas.Add(schemaCollection);
			xmlValidatingReader.ValidationEventHandler += smethod_1;
			xmlReader = xmlValidatingReader;
		}
		return xmlReader;
	}

	public static void smethod_1(object sender, ValidationEventArgs e)
	{
	}
}
