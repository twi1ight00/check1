using System.Xml;

namespace ns56;

internal class Class1420 : Class1351
{
	public delegate Class1420 Delegate222();

	public delegate void Delegate223(Class1420 elementData);

	public delegate void Delegate224(Class1420 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const bool bool_0 = true;

	private uint uint_1;

	private bool bool_1;

	public uint DxfId
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

	public bool CellColor
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
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
				case "cellColor":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "dxfId":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1420(XmlReader reader)
		: base(reader)
	{
	}

	public Class1420()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = uint.MaxValue;
		bool_1 = true;
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
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("dxfId", XmlConvert.ToString(uint_1));
		}
		if (!bool_1)
		{
			writer.WriteAttributeString("cellColor", bool_1 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
