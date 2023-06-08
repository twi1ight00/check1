using System;
using System.Xml;

namespace ns56;

internal class Class1818 : Class1351
{
	public delegate Class1818 Delegate1333();

	public delegate void Delegate1334(Class1818 elementData);

	public delegate void Delegate1335(Class1818 elementData);

	public Class1815.Delegate1324 delegate1324_0;

	public Class1815.Delegate1326 delegate1326_0;

	private Class1819 class1819_0;

	private Class1815 class1815_0;

	public Class1819 ClrScheme => class1819_0;

	public Class1815 ClrMap => class1815_0;

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
				case "clrMap":
					class1815_0 = new Class1815(reader);
					break;
				case "clrScheme":
					class1819_0 = new Class1819(reader);
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

	public Class1818(XmlReader reader)
		: base(reader)
	{
	}

	public Class1818()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1324_0 = method_3;
		delegate1326_0 = method_4;
	}

	protected override void vmethod_3()
	{
		class1819_0 = new Class1819();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1819_0.vmethod_4("a", writer, "clrScheme");
		if (class1815_0 != null)
		{
			class1815_0.vmethod_4("a", writer, "clrMap");
		}
		writer.WriteEndElement();
	}

	private Class1815 method_3()
	{
		if (class1815_0 != null)
		{
			throw new Exception("Only one <clrMap> element can be added.");
		}
		class1815_0 = new Class1815();
		return class1815_0;
	}

	private void method_4(Class1815 _clrMap)
	{
		class1815_0 = _clrMap;
	}
}
