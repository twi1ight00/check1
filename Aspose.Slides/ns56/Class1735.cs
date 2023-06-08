using System.Xml;

namespace ns56;

internal class Class1735 : Class1351
{
	public delegate Class1735 Delegate1084();

	public delegate void Delegate1085(Class1735 elementData);

	public delegate void Delegate1086(Class1735 elementData);

	private string string_0;

	private uint uint_0;

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

	public uint S
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
				case "s":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "r":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1735(XmlReader reader)
		: base(reader)
	{
	}

	public Class1735()
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
		writer.WriteAttributeString("r", string_0);
		writer.WriteAttributeString("s", XmlConvert.ToString(uint_0));
		writer.WriteEndElement();
	}
}
