using System.Xml;

namespace ns56;

internal class Class1568 : Class1351
{
	public delegate Class1568 Delegate583();

	public delegate void Delegate584(Class1568 elementData);

	public delegate void Delegate585(Class1568 elementData);

	private uint uint_0;

	private uint uint_1;

	public uint N
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

	public uint Np
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
				case "np":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "n":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1568(XmlReader reader)
		: base(reader)
	{
	}

	public Class1568()
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
		writer.WriteAttributeString("n", XmlConvert.ToString(uint_0));
		writer.WriteAttributeString("np", XmlConvert.ToString(uint_1));
		writer.WriteEndElement();
	}
}
