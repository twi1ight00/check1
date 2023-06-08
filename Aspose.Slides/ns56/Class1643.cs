using System;
using System.Xml;

namespace ns56;

internal class Class1643 : Class1351
{
	public delegate Class1643 Delegate808();

	public delegate void Delegate809(Class1643 elementData);

	public delegate void Delegate810(Class1643 elementData);

	public Class1728.Delegate1063 delegate1063_0;

	public Class1728.Delegate1065 delegate1065_0;

	private string string_0;

	private Class1728 class1728_0;

	public string Mdx
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

	public Class1728 Tpls => class1728_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "tpls")
				{
					class1728_0 = new Class1728(reader);
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "mdx")
			{
				string_0 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class1643(XmlReader reader)
		: base(reader)
	{
	}

	public Class1643()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1063_0 = method_3;
		delegate1065_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("mdx", string_0);
		if (class1728_0 != null)
		{
			class1728_0.vmethod_4("ssml", writer, "tpls");
		}
		writer.WriteEndElement();
	}

	private Class1728 method_3()
	{
		if (class1728_0 != null)
		{
			throw new Exception("Only one <tpls> element can be added.");
		}
		class1728_0 = new Class1728();
		return class1728_0;
	}

	private void method_4(Class1728 _tpls)
	{
		class1728_0 = _tpls;
	}
}
