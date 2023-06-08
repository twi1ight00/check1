using System;
using System.IO;
using System.Xml;

namespace ns178;

internal class Class4930 : Class4927
{
	private XmlDocument xmlDocument_0;

	private XmlNode xmlNode_0;

	private Stream stream_0;

	public Class4930(Stream stream)
	{
		stream_0 = stream;
	}

	public override void imethod_1()
	{
		xmlDocument_0 = new XmlDocument();
		xmlNode_0 = xmlDocument_0;
	}

	public override void imethod_2()
	{
		xmlDocument_0.Save(stream_0);
	}

	public override void imethod_6(string uri, string name, string qName, Interface236 attrs)
	{
		XmlElement xmlElement = xmlDocument_0.CreateElement(qName, uri);
		for (int i = 0; i < attrs.imethod_0(); i++)
		{
			string qualifiedName = attrs.imethod_1(i);
			string value = attrs.imethod_4(i);
			XmlAttribute xmlAttribute = xmlDocument_0.CreateAttribute(qualifiedName, uri);
			xmlAttribute.Value = value;
			xmlElement.SetAttributeNode(xmlAttribute);
		}
		xmlNode_0.AppendChild(xmlElement);
		xmlNode_0 = xmlElement;
	}

	public override void imethod_7(string uri, string name, string qName)
	{
		xmlNode_0 = xmlNode_0.ParentNode;
	}

	public override void imethod_8(char[] ch, int start, int length)
	{
		string text = new string(ch, start, length);
		XmlText newChild = xmlDocument_0.CreateTextNode(text);
		xmlNode_0.AppendChild(newChild);
	}

	public override void imethod_9(char[] ch, int start, int length)
	{
		string text = new string(ch, start, length);
		XmlText newChild = xmlDocument_0.CreateTextNode(text);
		xmlNode_0.AppendChild(newChild);
	}

	public override void imethod_3(string target, string data)
	{
		XmlProcessingInstruction newChild = xmlDocument_0.CreateProcessingInstruction(target, data);
		xmlNode_0.AppendChild(newChild);
	}

	public override void imethod_12(Exception56 e)
	{
		Console.Out.WriteLine("Erreur non fatale  (ligne " + e.method_0() + ") : " + e.method_2());
	}

	public override void imethod_13(Exception56 e)
	{
		Console.Out.WriteLine("Erreur fatale : " + e.method_2());
	}

	public override void imethod_11(Exception56 e)
	{
		Console.Out.WriteLine("Warning : " + e.method_2());
	}
}
