using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1544 : Class1351
{
	public delegate Class1544 Delegate511();

	public delegate void Delegate512(Class1544 elementData);

	public delegate void Delegate513(Class1544 elementData);

	public const uint uint_0 = uint.MaxValue;

	public Class1543.Delegate508 delegate508_0;

	public Class1543.Delegate509 delegate509_0;

	private uint uint_1;

	private List<Class1543> list_0;

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

	public Class1543[] GroupMemberList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "groupMember")
				{
					Class1543 item = new Class1543(reader);
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

	public Class1544(XmlReader reader)
		: base(reader)
	{
	}

	public Class1544()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = uint.MaxValue;
		list_0 = new List<Class1543>();
	}

	protected override void vmethod_2()
	{
		delegate508_0 = method_3;
		delegate509_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("count", XmlConvert.ToString(uint_1));
		}
		foreach (Class1543 item in list_0)
		{
			item.vmethod_4("ssml", writer, "groupMember");
		}
		writer.WriteEndElement();
	}

	private Class1543 method_3()
	{
		Class1543 @class = new Class1543();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1543 elementData)
	{
		list_0.Add(elementData);
	}
}
