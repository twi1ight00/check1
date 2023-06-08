using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2229 : Class1351
{
	public delegate Class2229 Delegate2425();

	public delegate void Delegate2427(Class2229 elementData);

	public delegate void Delegate2426(Class2229 elementData);

	public Class1778.Delegate1213 delegate1213_0;

	public Class1778.Delegate1214 delegate1214_0;

	private List<Class1778> list_0;

	public Class1778[] ControlList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "control")
				{
					Class1778 item = new Class1778(reader);
					list_0.Add(item);
				}
				else
				{
					reader.Skip();
					flag = true;
				}
			}
		}
	}

	private void method_2(XmlReader reader)
	{
	}

	public Class2229(XmlReader reader)
		: base(reader)
	{
	}

	public Class2229()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1778>();
	}

	protected override void vmethod_2()
	{
		delegate1213_0 = method_3;
		delegate1214_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1778 item in list_0)
		{
			item.vmethod_4("p", writer, "control");
		}
		writer.WriteEndElement();
	}

	private Class1778 method_3()
	{
		Class1778 @class = new Class1778();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1778 elementData)
	{
		list_0.Add(elementData);
	}
}
