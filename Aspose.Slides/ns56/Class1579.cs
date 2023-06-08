using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1579 : Class1351
{
	public delegate Class1579 Delegate616();

	public delegate void Delegate617(Class1579 elementData);

	public delegate void Delegate618(Class1579 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = uint.MaxValue;

	public Class1576.Delegate607 delegate607_0;

	public Class1576.Delegate608 delegate608_0;

	private uint uint_2;

	private uint uint_3;

	private List<Class1576> list_0;

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

	public uint Level
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

	public Class1576[] MemberList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "member")
				{
					Class1576 item = new Class1576(reader);
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
				case "level":
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

	public Class1579(XmlReader reader)
		: base(reader)
	{
	}

	public Class1579()
	{
	}

	protected override void vmethod_1()
	{
		uint_2 = uint.MaxValue;
		uint_3 = uint.MaxValue;
		list_0 = new List<Class1576>();
	}

	protected override void vmethod_2()
	{
		delegate607_0 = method_3;
		delegate608_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_2 != uint.MaxValue)
		{
			writer.WriteAttributeString("count", XmlConvert.ToString(uint_2));
		}
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("level", XmlConvert.ToString(uint_3));
		}
		foreach (Class1576 item in list_0)
		{
			item.vmethod_4("ssml", writer, "member");
		}
		writer.WriteEndElement();
	}

	private Class1576 method_3()
	{
		Class1576 @class = new Class1576();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1576 elementData)
	{
		list_0.Add(elementData);
	}
}
