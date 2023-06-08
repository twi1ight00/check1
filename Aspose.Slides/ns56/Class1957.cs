using System;
using System.Xml;

namespace ns56;

internal class Class1957 : Class1351
{
	public delegate Class1957 Delegate1738();

	public delegate void Delegate1739(Class1957 elementData);

	public delegate void Delegate1740(Class1957 elementData);

	public Class1953.Delegate1726 delegate1726_0;

	public Class1953.Delegate1728 delegate1728_0;

	private Class1953 class1953_0;

	public Class1953 RPr => class1953_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "rPr")
				{
					class1953_0 = new Class1953(reader);
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

	public Class1957(XmlReader reader)
		: base(reader)
	{
	}

	public Class1957()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1726_0 = method_3;
		delegate1728_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1953_0 != null)
		{
			class1953_0.vmethod_4("a", writer, "rPr");
		}
		writer.WriteEndElement();
	}

	private Class1953 method_3()
	{
		if (class1953_0 != null)
		{
			throw new Exception("Only one <rPr> element can be added.");
		}
		class1953_0 = new Class1953();
		return class1953_0;
	}

	private void method_4(Class1953 _rPr)
	{
		class1953_0 = _rPr;
	}
}
