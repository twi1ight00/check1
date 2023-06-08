using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1603 : Class1351
{
	public delegate void Delegate690(Class1603 elementData);

	public delegate Class1603 Delegate688();

	public delegate void Delegate689(Class1603 elementData);

	public const uint uint_0 = 0u;

	public const uint uint_1 = 0u;

	public Class1380.Delegate102 delegate102_0;

	public Class1380.Delegate103 delegate103_0;

	private uint uint_2;

	private uint uint_3;

	private List<Class1380> list_0;

	public uint Count
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	public uint ManualBreakCount
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	public Class1380[] BrkList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "brk")
				{
					Class1380 item = new Class1380(reader);
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
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "manualBreakCount":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "count":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1603(XmlReader reader)
		: base(reader)
	{
	}

	public Class1603()
	{
	}

	protected override void vmethod_1()
	{
		uint_2 = 0u;
		uint_3 = 0u;
		list_0 = new List<Class1380>();
	}

	protected override void vmethod_2()
	{
		delegate102_0 = method_3;
		delegate103_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_2 != 0)
		{
			writer.WriteAttributeString("count", XmlConvert.ToString(uint_2));
		}
		if (uint_3 != 0)
		{
			writer.WriteAttributeString("manualBreakCount", XmlConvert.ToString(uint_3));
		}
		foreach (Class1380 item in list_0)
		{
			item.vmethod_4("ssml", writer, "brk");
		}
		writer.WriteEndElement();
	}

	private Class1380 method_3()
	{
		Class1380 @class = new Class1380();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1380 elementData)
	{
		list_0.Add(elementData);
	}
}
