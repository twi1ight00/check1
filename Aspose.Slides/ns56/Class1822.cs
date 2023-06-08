using System.Xml;

namespace ns56;

internal class Class1822 : Class1351
{
	public delegate Class1822 Delegate1345();

	public delegate void Delegate1346(Class1822 elementData);

	public delegate void Delegate1347(Class1822 elementData);

	private uint uint_0;

	private uint uint_1;

	public uint Id
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

	public uint Idx
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
				_ = reader.LocalName;
				reader.Skip();
				flag = true;
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
				case "idx":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "id":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1822(XmlReader reader)
		: base(reader)
	{
	}

	public Class1822()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("id", XmlConvert.ToString(uint_0));
		writer.WriteAttributeString("idx", XmlConvert.ToString(uint_1));
		writer.WriteEndElement();
	}
}
