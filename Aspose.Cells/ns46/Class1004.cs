using System;
using System.Collections;
using System.Xml;
using ns16;

namespace ns46;

internal class Class1004 : Class999
{
	internal Class1004(string string_1)
	{
		string_0 = string_1;
	}

	internal override void vmethod_1(ref string string_1)
	{
	}

	internal override void vmethod_0(Class1008 class1008_0)
	{
		Class744 @class = class1008_0.stream6_0.method_18(string_0);
		@class.method_5(DateTime.Now);
		class1008_0.string_0 = "";
		foreach (Class999 item in arrayList_0)
		{
			item.vmethod_0(class1008_0);
		}
		class1008_0.method_0(class1008_0.string_0);
	}

	internal void method_0(Class746 class746_0, string string_1)
	{
		XmlDocument xmlDocument = new XmlDocument();
		Class744 @class = class746_0[string_1];
		if (@class != null)
		{
			Class1000 class999_ = new Class1000();
			xmlDocument.Load(class746_0.method_39(@class));
			Add(class999_);
			method_3(xmlDocument, class999_);
		}
	}

	internal Class999 method_1(Class999 class999_0, ArrayList arrayList_1)
	{
		foreach (Class999 item in class999_0.arrayList_0)
		{
			if (item.string_0 == (string)arrayList_1[arrayList_1.Count - 1])
			{
				if (arrayList_1.Count >= 2)
				{
					arrayList_1.RemoveAt(arrayList_1.Count - 1);
					return method_1(class999_0, arrayList_1);
				}
				return item;
			}
		}
		return null;
	}

	internal void method_2(string string_1, Class999 class999_0)
	{
		string[] array = string_1.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);
		ArrayList arrayList = new ArrayList();
		Array.Reverse(array);
		string[] array2 = array;
		foreach (string value in array2)
		{
			arrayList.Add(value);
		}
		Class1000 class999_ = (Class1000)arrayList_0[0];
		method_1(class999_, arrayList)?.Add(class999_0);
	}

	internal void method_3(XmlNode xmlNode_0, Class999 class999_0)
	{
		foreach (XmlNode childNode in xmlNode_0.ChildNodes)
		{
			switch (childNode.NodeType)
			{
			case XmlNodeType.Document:
			case XmlNodeType.XmlDeclaration:
			{
				Class1000 class2 = (Class1000)class999_0;
				class2.string_1 = childNode.OuterXml;
				method_3(childNode, class2);
				break;
			}
			case XmlNodeType.Element:
			{
				Class999 @class = null;
				if (childNode.OuterXml.EndsWith("/>"))
				{
					@class = new Class1001(childNode.Name);
					foreach (XmlAttribute attribute in childNode.Attributes)
					{
						((Class1001)@class).arrayList_1.Add(new Class998(attribute.Name, attribute.Value));
					}
				}
				else
				{
					@class = new Class1003(childNode.Name, childNode.Value);
					foreach (XmlAttribute attribute2 in childNode.Attributes)
					{
						((Class1003)@class).arrayList_1.Add(new Class998(attribute2.Name, attribute2.Value));
					}
				}
				class999_0.Add(@class);
				method_3(childNode, @class);
				break;
			}
			}
		}
	}

	internal void method_4(string string_1, Class999 class999_0)
	{
		string[] array = string_1.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);
		ArrayList arrayList = new ArrayList();
		Array.Reverse(array);
		string[] array2 = array;
		foreach (string value in array2)
		{
			arrayList.Add(value);
		}
		Class1000 class999_ = (Class1000)arrayList_0[0];
		Class999 @class = method_1(class999_, arrayList);
		if (@class == null)
		{
			return;
		}
		if (class999_0 is Class1001)
		{
			Class1001 class2 = (Class1001)class999_0;
			foreach (Class998 item in class2.arrayList_1)
			{
				if (item.string_0 == "Id")
				{
					item.string_1 += @class.arrayList_0.Count + 1;
				}
			}
		}
		else if (class999_0 is Class1003)
		{
			Class1003 class4 = (Class1003)class999_0;
			foreach (Class998 item2 in class4.arrayList_1)
			{
				if (item2.string_0 == "Id")
				{
					item2.string_1 += @class.arrayList_0.Count + 1;
				}
			}
		}
		@class.Add(class999_0);
	}
}
