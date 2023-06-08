using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1399 : Class1351
{
	public delegate Class1399 Delegate159();

	public delegate void Delegate160(Class1399 elementData);

	public delegate void Delegate161(Class1399 elementData);

	public Class1397.Delegate153 delegate153_0;

	public Class1397.Delegate154 delegate154_0;

	private string string_0;

	private List<Class1397> list_0;

	public string R
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class1397[] CellSmartTagList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "cellSmartTag")
				{
					Class1397 item = new Class1397(reader);
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "r")
			{
				string_0 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class1399(XmlReader reader)
		: base(reader)
	{
	}

	public Class1399()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1397>();
	}

	protected override void vmethod_2()
	{
		delegate153_0 = method_3;
		delegate154_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("r", string_0);
		foreach (Class1397 item in list_0)
		{
			item.vmethod_4("ssml", writer, "cellSmartTag");
		}
		writer.WriteEndElement();
	}

	private Class1397 method_3()
	{
		Class1397 @class = new Class1397();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1397 elementData)
	{
		list_0.Add(elementData);
	}
}
