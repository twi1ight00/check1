using System;
using System.Xml;

namespace ns56;

internal class Class1927 : Class1351
{
	public delegate Class1927 Delegate1648();

	public delegate void Delegate1649(Class1927 elementData);

	public delegate void Delegate1650(Class1927 elementData);

	public Class1915.Delegate1612 delegate1612_0;

	public Class1915.Delegate1614 delegate1614_0;

	private Class1915 class1915_0;

	public Class1915 FillRect => class1915_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "fillRect")
				{
					class1915_0 = new Class1915(reader);
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

	public Class1927(XmlReader reader)
		: base(reader)
	{
	}

	public Class1927()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1612_0 = method_3;
		delegate1614_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1915_0 != null)
		{
			class1915_0.vmethod_4("a", writer, "fillRect");
		}
		writer.WriteEndElement();
	}

	private Class1915 method_3()
	{
		if (class1915_0 != null)
		{
			throw new Exception("Only one <fillRect> element can be added.");
		}
		class1915_0 = new Class1915();
		return class1915_0;
	}

	private void method_4(Class1915 _fillRect)
	{
		class1915_0 = _fillRect;
	}
}
