using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1510 : Class1351
{
	public delegate Class1510 Delegate409();

	public delegate void Delegate410(Class1510 elementData);

	public delegate void Delegate411(Class1510 elementData);

	public Class1504.Delegate391 delegate391_0;

	public Class1504.Delegate392 delegate392_0;

	private uint uint_0;

	private List<Class1504> list_0;

	public uint R
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public Class1504[] CellList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "cell")
				{
					Class1504 item = new Class1504(reader);
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
				uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1510(XmlReader reader)
		: base(reader)
	{
	}

	public Class1510()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class1504>();
	}

	protected override void vmethod_2()
	{
		delegate391_0 = method_3;
		delegate392_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("r", XmlConvert.ToString(uint_0));
		foreach (Class1504 item in list_0)
		{
			item.vmethod_4("ssml", writer, "cell");
		}
		writer.WriteEndElement();
	}

	private Class1504 method_3()
	{
		Class1504 @class = new Class1504();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1504 elementData)
	{
		list_0.Add(elementData);
	}
}
