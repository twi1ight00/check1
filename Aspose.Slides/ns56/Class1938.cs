using System;
using System.Xml;

namespace ns56;

internal class Class1938 : Class1351
{
	public delegate Class1938 Delegate1681();

	public delegate void Delegate1682(Class1938 elementData);

	public delegate void Delegate1683(Class1938 elementData);

	public Class1943.Delegate1696 delegate1696_0;

	public Class1943.Delegate1698 delegate1698_0;

	public Class1941.Delegate1690 delegate1690_0;

	public Class1941.Delegate1692 delegate1692_0;

	private Class1943 class1943_0;

	private Class1941 class1941_0;

	public Class1943 TcTxStyle => class1943_0;

	public Class1941 TcStyle => class1941_0;

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
				case "tcStyle":
					class1941_0 = new Class1941(reader);
					break;
				case "tcTxStyle":
					class1943_0 = new Class1943(reader);
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

	public Class1938(XmlReader reader)
		: base(reader)
	{
	}

	public Class1938()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1696_0 = method_3;
		delegate1698_0 = method_4;
		delegate1690_0 = method_5;
		delegate1692_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1943_0 != null)
		{
			class1943_0.vmethod_4("a", writer, "tcTxStyle");
		}
		if (class1941_0 != null)
		{
			class1941_0.vmethod_4("a", writer, "tcStyle");
		}
		writer.WriteEndElement();
	}

	private Class1943 method_3()
	{
		if (class1943_0 != null)
		{
			throw new Exception("Only one <tcTxStyle> element can be added.");
		}
		class1943_0 = new Class1943();
		return class1943_0;
	}

	private void method_4(Class1943 _tcTxStyle)
	{
		class1943_0 = _tcTxStyle;
	}

	private Class1941 method_5()
	{
		if (class1941_0 != null)
		{
			throw new Exception("Only one <tcStyle> element can be added.");
		}
		class1941_0 = new Class1941();
		return class1941_0;
	}

	private void method_6(Class1941 _tcStyle)
	{
		class1941_0 = _tcStyle;
	}
}
