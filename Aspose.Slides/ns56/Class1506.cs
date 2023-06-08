using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1506 : Class1351
{
	public delegate Class1506 Delegate397();

	public delegate void Delegate399(Class1506 elementData);

	public delegate void Delegate398(Class1506 elementData);

	public Class1505.Delegate394 delegate394_0;

	public Class1505.Delegate395 delegate395_0;

	private List<Class1505> list_0;

	public Class1505[] DefinedNameList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "definedName")
				{
					Class1505 item = new Class1505(reader);
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

	public Class1506(XmlReader reader)
		: base(reader)
	{
	}

	public Class1506()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1505>();
	}

	protected override void vmethod_2()
	{
		delegate394_0 = method_3;
		delegate395_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		foreach (Class1505 item in list_0)
		{
			item.vmethod_4("ssml", writer, "definedName");
		}
		writer.WriteEndElement();
	}

	private Class1505 method_3()
	{
		Class1505 @class = new Class1505();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1505 elementData)
	{
		list_0.Add(elementData);
	}
}
