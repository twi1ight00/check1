using System;
using System.Xml;

namespace ns56;

internal class Class2074 : Class1351
{
	public delegate void Delegate1939(Class2074 elementData);

	public delegate Class2074 Delegate1937();

	public delegate void Delegate1938(Class2074 elementData);

	public Class2339.Delegate2763 delegate2763_0;

	public Class2339.Delegate2764 delegate2764_0;

	private string string_0;

	private Class2339 class2339_0;

	public string R_Id
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class2339 AutoUpdate => class2339_0;

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
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "autoUpdate")
				{
					class2339_0 = new Class2339(reader);
					continue;
				}
				reader.Skip();
				flag = true;
			}
		}
	}

	private void method_2(XmlReader reader)
	{
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "r:id")
			{
				string_0 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class2074(XmlReader reader)
		: base(reader)
	{
	}

	public Class2074()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2763_0 = method_3;
		delegate2764_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("r:id", string_0);
		if (class2339_0 != null)
		{
			class2339_0.vmethod_4("c", writer, "autoUpdate");
		}
		writer.WriteEndElement();
	}

	private Class2339 method_3()
	{
		if (class2339_0 != null)
		{
			throw new Exception("Only one <autoUpdate> element can be added.");
		}
		class2339_0 = new Class2339();
		return class2339_0;
	}

	private void method_4(Class2339 _autoUpdate)
	{
		class2339_0 = _autoUpdate;
	}
}
