using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1409 : Class1351
{
	public delegate Class1409 Delegate189();

	public delegate void Delegate190(Class1409 elementData);

	public delegate void Delegate191(Class1409 elementData);

	public const uint uint_0 = 0u;

	public Class1408.Delegate186 delegate186_0;

	public Class1408.Delegate187 delegate187_0;

	private uint uint_1;

	private List<Class1408> list_0;

	public uint Count
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public Class1408[] ChartFormatList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "chartFormat")
				{
					Class1408 item = new Class1408(reader);
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "count")
			{
				uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1409(XmlReader reader)
		: base(reader)
	{
	}

	public Class1409()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = 0u;
		list_0 = new List<Class1408>();
	}

	protected override void vmethod_2()
	{
		delegate186_0 = method_3;
		delegate187_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_1 != 0)
		{
			writer.WriteAttributeString("count", XmlConvert.ToString(uint_1));
		}
		foreach (Class1408 item in list_0)
		{
			item.vmethod_4("ssml", writer, "chartFormat");
		}
		writer.WriteEndElement();
	}

	private Class1408 method_3()
	{
		Class1408 @class = new Class1408();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1408 elementData)
	{
		list_0.Add(elementData);
	}
}
