using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using Aspose.Slides;

namespace ns42;

internal class Class1096
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

	public Class1096(string defaultNamespaceURI)
	{
		string_0 = defaultNamespaceURI;
	}

	public Class1096(string defaultNamespaceURI, Type defaultType)
	{
		string_0 = defaultNamespaceURI;
		Add(string.Empty, string.Empty, defaultType);
	}

	public void method_0(string defaultNamespaceURI)
	{
		string_0 = defaultNamespaceURI;
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
			throw new PptxException($"Internal error: class {type.Name} haven't required constructor.");
		}
		string text = namespaceURI;
		if (localName != null && localName.Length != 0)
		{
			text = text + '#' + localName;
		}
		sortedList_0[text] = constructor;
	}

	public void Add(string[] localNames, Type type)
	{
		Add(string_0, localNames, type);
	}

	public void Add(string namespaceURI, string[] localNames, Type type)
	{
		foreach (string localName in localNames)
		{
			Add(namespaceURI, localName, type);
		}
	}

	public XmlElement CreateElement(string prefix, string localName, string namespaceURI, XmlDocument doc)
	{
		if (sortedList_0.Count > 0)
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
		}
		return new Class810(prefix, localName, namespaceURI, doc);
	}
}
