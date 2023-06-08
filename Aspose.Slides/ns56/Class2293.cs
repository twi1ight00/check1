using System;
using System.Xml;

namespace ns56;

internal class Class2293 : Class1351
{
	public delegate Class2293 Delegate2626();

	public delegate void Delegate2627(Class2293 elementData);

	public delegate void Delegate2628(Class2293 elementData);

	public Class2272.Delegate2563 delegate2563_0;

	public Class2272.Delegate2565 delegate2565_0;

	private Class2281 class2281_0;

	private Class2272 class2272_0;

	public Class2281 CBhvr => class2281_0;

	public Class2272 To => class2272_0;

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
				case "to":
					class2272_0 = new Class2272(reader);
					break;
				case "cBhvr":
					class2281_0 = new Class2281(reader);
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

	public Class2293(XmlReader reader)
		: base(reader)
	{
	}

	public Class2293()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2563_0 = method_3;
		delegate2565_0 = method_4;
	}

	protected override void vmethod_3()
	{
		class2281_0 = new Class2281();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class2281_0.vmethod_4("p", writer, "cBhvr");
		if (class2272_0 != null)
		{
			class2272_0.vmethod_4("p", writer, "to");
		}
		writer.WriteEndElement();
	}

	private Class2272 method_3()
	{
		if (class2272_0 != null)
		{
			throw new Exception("Only one <to> element can be added.");
		}
		class2272_0 = new Class2272();
		return class2272_0;
	}

	private void method_4(Class2272 _to)
	{
		class2272_0 = _to;
	}
}
