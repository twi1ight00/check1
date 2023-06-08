using System;
using System.Xml;

namespace ns56;

internal class Class2242 : Class1351
{
	public delegate Class2242 Delegate2470();

	public delegate void Delegate2472(Class2242 elementData);

	public delegate void Delegate2471(Class2242 elementData);

	public Class2243.Delegate2473 delegate2473_0;

	public Class2243.Delegate2475 delegate2475_0;

	private Class2243 class2243_0;

	public Class2243 NotesMasterId => class2243_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "notesMasterId")
				{
					class2243_0 = new Class2243(reader);
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

	public Class2242(XmlReader reader)
		: base(reader)
	{
	}

	public Class2242()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2473_0 = method_3;
		delegate2475_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2243_0 != null)
		{
			class2243_0.vmethod_4("p", writer, "notesMasterId");
		}
		writer.WriteEndElement();
	}

	private Class2243 method_3()
	{
		if (class2243_0 != null)
		{
			throw new Exception("Only one <notesMasterId> element can be added.");
		}
		class2243_0 = new Class2243();
		return class2243_0;
	}

	private void method_4(Class2243 _notesMasterId)
	{
		class2243_0 = _notesMasterId;
	}
}
