using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2208 : Class1351
{
	public delegate Class2208 Delegate2360();

	public delegate void Delegate2361(Class2208 elementData);

	public delegate void Delegate2362(Class2208 elementData);

	public const Enum362 enum362_0 = Enum362.const_0;

	public Class2201.Delegate2339 delegate2339_0;

	public Class2201.Delegate2340 delegate2340_0;

	private Enum362 enum362_1;

	private List<Class2201> list_0;

	public Enum362 V_Ext
	{
		get
		{
			return enum362_1;
		}
		set
		{
			enum362_1 = value;
		}
	}

	public Class2201[] EntryList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "entry")
				{
					Class2201 item = new Class2201(reader);
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
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "v:ext")
			{
				enum362_1 = Class2498.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2208(XmlReader reader)
		: base(reader)
	{
	}

	public Class2208()
	{
	}

	protected override void vmethod_1()
	{
		enum362_1 = Enum362.const_0;
		list_0 = new List<Class2201>();
	}

	protected override void vmethod_2()
	{
		delegate2339_0 = method_3;
		delegate2340_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum362_1 != 0)
		{
			writer.WriteAttributeString("v:ext", Class2498.smethod_1(enum362_1));
		}
		foreach (Class2201 item in list_0)
		{
			item.vmethod_4("o", writer, "entry");
		}
		writer.WriteEndElement();
	}

	private Class2201 method_3()
	{
		Class2201 @class = new Class2201();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2201 elementData)
	{
		list_0.Add(elementData);
	}
}
