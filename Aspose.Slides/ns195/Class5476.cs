using System.Collections;
using System.Xml;
using ns178;

namespace ns195;

internal class Class5476
{
	private static string string_0 = string.Empty;

	private static string string_1 = "xmlns";

	private Interface153 interface153_0;

	private Interface203 interface203_0;

	private Hashtable hashtable_0 = new Hashtable();

	public Class5476(Interface153 handler)
	{
		interface153_0 = handler;
		if (handler is Interface203)
		{
			interface203_0 = (Interface203)handler;
		}
	}

	public void method_0(XmlDocument doc, bool fragment)
	{
		if (!fragment)
		{
			interface153_0.imethod_1();
		}
		for (XmlNode xmlNode = doc.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
		{
			method_4(xmlNode);
		}
		if (!fragment)
		{
			interface153_0.imethod_2();
		}
	}

	public void method_1(XmlNode node)
	{
		method_4(node);
	}

	private bool method_2(string prefix, string uri)
	{
		bool result = true;
		Stack stack = (Stack)hashtable_0[prefix];
		if (stack != null)
		{
			if (stack.Count == 0)
			{
				interface153_0.imethod_4(prefix, uri);
				stack.Push(uri);
			}
			else
			{
				string text = (string)stack.Peek();
				if (!text.Equals(uri))
				{
					interface153_0.imethod_4(prefix, uri);
					stack.Push(uri);
				}
				else
				{
					result = false;
				}
			}
		}
		else
		{
			interface153_0.imethod_4(prefix, uri);
			stack = new Stack();
			hashtable_0.Add(prefix, stack);
			stack.Push(uri);
		}
		return result;
	}

	private void method_3(string prefix)
	{
		Stack stack = (Stack)hashtable_0[prefix];
		if (stack != null)
		{
			interface153_0.imethod_5(prefix);
			stack.Pop();
		}
	}

	private static string smethod_0(XmlNode node)
	{
		string localName = node.LocalName;
		if (string.IsNullOrEmpty(localName))
		{
			string name = node.Name;
			int num = name.LastIndexOf(':');
			if (num <= 0)
			{
				return name;
			}
			return name.Substring(num + 1);
		}
		return localName;
	}

	private void method_4(XmlNode node)
	{
		if (node == null || node is XmlAttribute || node is XmlDocumentFragment || node is XmlDocumentType || node is XmlEntity || node is XmlEntityReference || node is XmlNotation)
		{
			return;
		}
		if (node is XmlCDataSection)
		{
			string value = node.Value;
			if (interface203_0 != null)
			{
				interface203_0.imethod_3();
				interface153_0.imethod_8(value.ToCharArray(), 0, value.Length);
				interface203_0.imethod_4();
			}
			else
			{
				interface153_0.imethod_8(value.ToCharArray(), 0, value.Length);
			}
		}
		else if (node is XmlComment)
		{
			if (interface203_0 != null)
			{
				string value2 = node.Value;
				interface203_0.imethod_5(value2.ToCharArray(), 0, value2.Length);
			}
		}
		else if (node is XmlDocument)
		{
			interface153_0.imethod_1();
			for (XmlNode xmlNode = node.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
			{
				method_4(xmlNode);
			}
			interface153_0.imethod_2();
		}
		else if (node is XmlElement)
		{
			ArrayList arrayList = new ArrayList();
			Class5699 @class = new Class5699();
			XmlAttributeCollection attributes = node.Attributes;
			int count = attributes.Count;
			for (int i = 0; i < count; i++)
			{
				XmlNode xmlNode2 = attributes[i];
				string name = xmlNode2.Name;
				if (name.StartsWith(string_1))
				{
					string value3 = xmlNode2.Value;
					int num = name.LastIndexOf(':');
					string text = ((num > 0) ? name.Substring(num + 1) : string_0);
					if (method_2(text, value3))
					{
						arrayList.Add(text);
					}
				}
			}
			for (int j = 0; j < count; j++)
			{
				XmlNode xmlNode3 = attributes[j];
				string name2 = xmlNode3.Name;
				if (name2.StartsWith(string_1))
				{
					continue;
				}
				string namespaceURI = xmlNode3.NamespaceURI;
				if (namespaceURI != null)
				{
					int num2 = name2.LastIndexOf(':');
					string text = ((num2 > 0) ? Class5479.smethod_0(name2, 0, num2) : string_0);
					if (method_2(text, namespaceURI))
					{
						arrayList.Add(text);
					}
				}
				@class.method_1(xmlNode3.NamespaceURI, smethod_0(xmlNode3), name2, "CDATA", xmlNode3.Value);
			}
			string name3 = node.Name;
			string namespaceURI2 = node.NamespaceURI;
			string localName = smethod_0(node);
			if (namespaceURI2 != null)
			{
				int num3 = name3.LastIndexOf(':');
				string text = ((num3 > 0) ? Class5479.smethod_0(name3, 0, num3) : string_0);
				if (method_2(text, namespaceURI2))
				{
					arrayList.Add(text);
				}
			}
			interface153_0.imethod_6(namespaceURI2, localName, name3, @class);
			for (XmlNode xmlNode4 = node.FirstChild; xmlNode4 != null; xmlNode4 = xmlNode4.NextSibling)
			{
				method_4(xmlNode4);
			}
			interface153_0.imethod_7(namespaceURI2, localName, name3);
			int count2 = arrayList.Count;
			for (int k = 0; k < count2; k++)
			{
				method_3((string)arrayList[k]);
			}
		}
		else if (node is XmlProcessingInstruction)
		{
			interface153_0.imethod_3(node.Name, node.Value);
		}
		else if (node is XmlText)
		{
			string value4 = node.Value;
			interface153_0.imethod_8(value4.ToCharArray(), 0, value4.Length);
		}
	}
}
