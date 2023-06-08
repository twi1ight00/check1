using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2154 : Class1351
{
	public delegate Class2154 Delegate2194();

	public delegate void Delegate2195(Class2154 elementData);

	public delegate void Delegate2196(Class2154 elementData);

	public const string string_0 = "";

	public Class2191.Delegate2305 delegate2305_0;

	public Class2191.Delegate2306 delegate2306_0;

	public Class2176.Delegate2260 delegate2260_0;

	public Class2176.Delegate2262 delegate2262_0;

	private string string_1;

	private List<Class2191> list_0;

	private Class2176 class2176_0;

	public string Name
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public Class2191[] IfList => list_0.ToArray();

	public Class2176 Else => class2176_0;

	protected override void vmethod_0(XmlReader reader)
	{
		string localName = reader.LocalName;
		method_2(reader);
		if (reader.IsEmptyElement)
		{
			return;
		}
		bool flag = false;
		while (((flag && !reader.EOF) || reader.Read()) && (reader.NodeType != XmlNodeType.EndElement || !(reader.LocalName == localName)))
		{
			flag = false;
			if (reader.NodeType == XmlNodeType.Element)
			{
				switch (reader.LocalName)
				{
				case "else":
					class2176_0 = new Class2176(reader);
					break;
				case "if":
				{
					Class2191 item = new Class2191(reader);
					list_0.Add(item);
					break;
				}
				default:
					reader.Skip();
					flag = true;
					break;
				}
			}
		}
	}

	private void method_2(XmlReader reader)
	{
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "name")
			{
				string_1 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class2154(XmlReader reader)
		: base(reader)
	{
	}

	public Class2154()
	{
	}

	protected override void vmethod_1()
	{
		string_1 = "";
		list_0 = new List<Class2191>();
	}

	protected override void vmethod_2()
	{
		delegate2305_0 = method_3;
		delegate2306_0 = method_4;
		delegate2260_0 = method_5;
		delegate2262_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_1 != "")
		{
			writer.WriteAttributeString("name", string_1);
		}
		foreach (Class2191 item in list_0)
		{
			item.vmethod_4("dgm", writer, "if");
		}
		if (class2176_0 != null)
		{
			class2176_0.vmethod_4("dgm", writer, "else");
		}
		writer.WriteEndElement();
	}

	private Class2191 method_3()
	{
		Class2191 @class = new Class2191();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2191 elementData)
	{
		list_0.Add(elementData);
	}

	private Class2176 method_5()
	{
		if (class2176_0 != null)
		{
			throw new Exception("Only one <else> element can be added.");
		}
		class2176_0 = new Class2176();
		return class2176_0;
	}

	private void method_6(Class2176 _else)
	{
		class2176_0 = _else;
	}
}
