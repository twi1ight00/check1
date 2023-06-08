using System;
using System.Xml;

namespace ns56;

internal class Class2236 : Class1351
{
	public delegate Class2236 Delegate2452();

	public delegate void Delegate2454(Class2236 elementData);

	public delegate void Delegate2453(Class2236 elementData);

	public Class2237.Delegate2455 delegate2455_0;

	public Class2237.Delegate2457 delegate2457_0;

	private Class2237 class2237_0;

	public Class2237 HandoutMasterId => class2237_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "handoutMasterId")
				{
					class2237_0 = new Class2237(reader);
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

	public Class2236(XmlReader reader)
		: base(reader)
	{
	}

	public Class2236()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2455_0 = method_3;
		delegate2457_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2237_0 != null)
		{
			class2237_0.vmethod_4("p", writer, "handoutMasterId");
		}
		writer.WriteEndElement();
	}

	private Class2237 method_3()
	{
		if (class2237_0 != null)
		{
			throw new Exception("Only one <handoutMasterId> element can be added.");
		}
		class2237_0 = new Class2237();
		return class2237_0;
	}

	private void method_4(Class2237 _handoutMasterId)
	{
		class2237_0 = _handoutMasterId;
	}
}
