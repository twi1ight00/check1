using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using ns16;
using ns22;

namespace ns25;

internal abstract class Class536
{
	internal static string smethod_0(string string_0)
	{
		string_0 = string_0.Replace("xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\"", "");
		string_0 = string_0.Replace("xmlns:a=\"http://schemas.openxmlformats.org/drawingml/2006/main\"", "");
		string_0 = string_0.Replace("xmlns:xdr=\"http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing\"", "");
		string_0 = string_0.Replace("xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\"", "");
		return string_0;
	}

	internal static string smethod_1(XmlElement xmlElement_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
		smethod_2(xmlTextWriter, xmlElement_0);
		xmlTextWriter.Flush();
		memoryStream.Flush();
		int num = (int)memoryStream.Length;
		byte[] buffer = memoryStream.GetBuffer();
		memoryStream.Close();
		xmlTextWriter = null;
		memoryStream = null;
		return Encoding.UTF8.GetString(buffer, 3, num - 3);
	}

	private static void smethod_2(XmlTextWriter xmlTextWriter_0, XmlElement xmlElement_0)
	{
		xmlTextWriter_0.WriteStartElement(xmlElement_0.Name);
		if (xmlElement_0.HasAttributes)
		{
			XmlAttributeCollection attributes = xmlElement_0.Attributes;
			for (int i = 0; i < attributes.Count; i++)
			{
				switch (attributes[i].Name)
				{
				case "xmlns:xdr":
				case "xmlns:a":
				case "xmlns:r":
				case "xmlns":
				case "xmlns:mc":
					continue;
				}
				attributes[i].WriteTo(xmlTextWriter_0);
			}
		}
		if (xmlElement_0.IsEmpty)
		{
			xmlTextWriter_0.WriteEndElement();
			return;
		}
		smethod_3(xmlTextWriter_0, xmlElement_0);
		xmlTextWriter_0.WriteFullEndElement();
	}

	private static void smethod_3(XmlTextWriter xmlTextWriter_0, XmlElement xmlElement_0)
	{
		IEnumerator enumerator = xmlElement_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			XmlNode xmlNode = (XmlNode)enumerator.Current;
			if (xmlNode is XmlElement)
			{
				smethod_2(xmlTextWriter_0, (XmlElement)xmlNode);
			}
			else
			{
				xmlNode.WriteTo(xmlTextWriter_0);
			}
		}
	}

	internal static bool smethod_4(XmlTextReader xmlTextReader_0)
	{
		return Class1188.smethod_15(xmlTextReader_0);
	}

	internal static XmlTextReader smethod_5(Class746 class746_0, string string_0)
	{
		return Class1029.smethod_4(class746_0, string_0);
	}
}
