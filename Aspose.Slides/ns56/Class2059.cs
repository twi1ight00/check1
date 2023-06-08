using System;
using System.Xml;

namespace ns56;

internal class Class2059 : Class1351
{
	public delegate Class2059 Delegate1889();

	public delegate void Delegate1891(Class2059 elementData);

	public delegate void Delegate1890(Class2059 elementData);

	public Class1921.Delegate1630 delegate1630_0;

	public Class1921.Delegate1632 delegate1632_0;

	private Class1921 class1921_0;

	public Class1921 SpPr => class1921_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "spPr")
				{
					class1921_0 = new Class1921(reader);
					continue;
				}
				reader.Skip();
				flag = true;
			}
		}
	}

	private void method_2(XmlReader reader)
	{
	}

	public Class2059(XmlReader reader)
		: base(reader)
	{
	}

	public Class2059()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1630_0 = method_3;
		delegate1632_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1921_0 != null)
		{
			class1921_0.vmethod_4("c", writer, "spPr");
		}
		writer.WriteEndElement();
	}

	private Class1921 method_3()
	{
		if (class1921_0 != null)
		{
			throw new Exception("Only one <spPr> element can be added.");
		}
		class1921_0 = new Class1921();
		return class1921_0;
	}

	private void method_4(Class1921 _spPr)
	{
		class1921_0 = _spPr;
	}
}
