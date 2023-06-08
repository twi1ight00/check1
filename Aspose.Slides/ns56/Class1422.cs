using System;
using System.Xml;

namespace ns56;

internal class Class1422 : Class1351
{
	public delegate void Delegate230(Class1422 elementData);

	public delegate Class1422 Delegate228();

	public delegate void Delegate229(Class1422 elementData);

	public Class1555.Delegate544 delegate544_0;

	public Class1555.Delegate546 delegate546_0;

	public Class1591.Delegate652 delegate652_0;

	public Class1591.Delegate654 delegate654_0;

	private Class1555 class1555_0;

	private Class1591 class1591_0;

	public Class1555 IndexedColors => class1555_0;

	public Class1591 MruColors => class1591_0;

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
				case "mruColors":
					class1591_0 = new Class1591(reader);
					break;
				case "indexedColors":
					class1555_0 = new Class1555(reader);
					break;
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
	}

	public Class1422(XmlReader reader)
		: base(reader)
	{
	}

	public Class1422()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate544_0 = method_3;
		delegate546_0 = method_4;
		delegate652_0 = method_5;
		delegate654_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1555_0 != null)
		{
			class1555_0.vmethod_4("ssml", writer, "indexedColors");
		}
		if (class1591_0 != null)
		{
			class1591_0.vmethod_4("ssml", writer, "mruColors");
		}
		writer.WriteEndElement();
	}

	private Class1555 method_3()
	{
		if (class1555_0 != null)
		{
			throw new Exception("Only one <indexedColors> element can be added.");
		}
		class1555_0 = new Class1555();
		return class1555_0;
	}

	private void method_4(Class1555 _indexedColors)
	{
		class1555_0 = _indexedColors;
	}

	private Class1591 method_5()
	{
		if (class1591_0 != null)
		{
			throw new Exception("Only one <mruColors> element can be added.");
		}
		class1591_0 = new Class1591();
		return class1591_0;
	}

	private void method_6(Class1591 _mruColors)
	{
		class1591_0 = _mruColors;
	}
}
