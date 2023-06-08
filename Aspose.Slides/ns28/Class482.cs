using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using Aspose.Slides.Odp;

namespace ns28;

internal class Class482
{
	private SortedList<string, ConstructorInfo> sortedList_0 = new SortedList<string, ConstructorInfo>();

	private string string_0 = "";

	private static readonly Type[] type_0 = new Type[4]
	{
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(XmlDocument)
	};

	public void Add(string namespaceURI, string[] localNames, Type type)
	{
		foreach (string localName in localNames)
		{
			Add(namespaceURI, localName, type);
		}
	}

	public void Add(string localName, Type type)
	{
		Add(string_0, localName, type);
	}

	public void Add(string namespaceURI, string localName, Type type)
	{
		ConstructorInfo constructor = type.GetConstructor(type_0);
		if (constructor == null)
		{
			throw new OdpException($"Internal error: class {type.Name} haven't required constructor.");
		}
		string text = namespaceURI;
		if (localName != null && localName.Length != 0)
		{
			text = text + '#' + localName;
		}
		sortedList_0[text] = constructor;
	}

	public XmlElement CreateElement(string prefix, string localName, string namespaceURI, XmlDocument doc)
	{
		string key = namespaceURI + '#' + localName;
		int num = sortedList_0.IndexOfKey(key);
		if (num < 0)
		{
			num = sortedList_0.IndexOfKey(namespaceURI);
		}
		if (num < 0)
		{
			num = sortedList_0.IndexOfKey(string.Empty);
		}
		if (num >= 0)
		{
			ConstructorInfo constructorInfo = sortedList_0.Values[num];
			return (XmlElement)constructorInfo.Invoke(new object[4] { prefix, localName, namespaceURI, doc });
		}
		return new Class369(prefix, localName, namespaceURI, doc);
	}

	public Class482(string defaultNamespaceURI)
	{
		string_0 = defaultNamespaceURI;
	}
}
