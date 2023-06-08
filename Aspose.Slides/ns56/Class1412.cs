using System.Globalization;
using System.Xml;

namespace ns56;

internal class Class1412 : Class1351
{
	public delegate Class1412 Delegate198();

	public delegate void Delegate200(Class1412 elementData);

	public delegate void Delegate199(Class1412 elementData);

	public const ushort ushort_0 = ushort.MaxValue;

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	private ushort ushort_1;

	private bool bool_2;

	private bool bool_3;

	public ushort Password
	{
		get
		{
			return ushort_1;
		}
		set
		{
			ushort_1 = value;
		}
	}

	public bool Content
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool Objects
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
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
				case "objects":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "content":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "password":
					ushort_1 = ushort.Parse(reader.Value, NumberStyles.HexNumber);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1412(XmlReader reader)
		: base(reader)
	{
	}

	public Class1412()
	{
	}

	protected override void vmethod_1()
	{
		ushort_1 = ushort.MaxValue;
		bool_2 = false;
		bool_3 = false;
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
		if (ushort_1 != ushort.MaxValue)
		{
			writer.WriteAttributeString("password", (ushort_1 & 0xFFFF).ToString("X4"));
		}
		if (bool_2)
		{
			writer.WriteAttributeString("content", bool_2 ? "1" : "0");
		}
		if (bool_3)
		{
			writer.WriteAttributeString("objects", bool_3 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
