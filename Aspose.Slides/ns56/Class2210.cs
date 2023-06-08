using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2210 : Class1351
{
	public delegate Class2210 Delegate2366();

	public delegate void Delegate2367(Class2210 elementData);

	public delegate void Delegate2368(Class2210 elementData);

	public const Enum362 enum362_0 = Enum362.const_0;

	public Class2209.Delegate2363 delegate2363_0;

	public Class2209.Delegate2364 delegate2364_0;

	private Enum362 enum362_1;

	private List<Class2209> list_0;

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

	public Class2209[] RList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "r")
				{
					Class2209 item = new Class2209(reader);
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

	public Class2210(XmlReader reader)
		: base(reader)
	{
	}

	public Class2210()
	{
	}

	protected override void vmethod_1()
	{
		enum362_1 = Enum362.const_0;
		list_0 = new List<Class2209>();
	}

	protected override void vmethod_2()
	{
		delegate2363_0 = method_3;
		delegate2364_0 = method_4;
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
		foreach (Class2209 item in list_0)
		{
			item.vmethod_4("o", writer, "r");
		}
		writer.WriteEndElement();
	}

	private Class2209 method_3()
	{
		Class2209 @class = new Class2209();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2209 elementData)
	{
		list_0.Add(elementData);
	}
}
