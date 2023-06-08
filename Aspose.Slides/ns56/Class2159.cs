using System.Xml;

namespace ns56;

internal class Class2159 : Class1351
{
	public delegate Class2159 Delegate2209();

	public delegate void Delegate2210(Class2159 elementData);

	public delegate void Delegate2211(Class2159 elementData);

	private string string_0;

	private uint uint_0;

	public string Type
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

	public uint Pri
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
				case "pri":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "type":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2159(XmlReader reader)
		: base(reader)
	{
	}

	public Class2159()
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
		writer.WriteAttributeString("type", string_0);
		writer.WriteAttributeString("pri", XmlConvert.ToString(uint_0));
		writer.WriteEndElement();
	}
}
