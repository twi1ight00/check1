using System.Xml;

namespace ns56;

internal class Class1485 : Class1351
{
	public delegate Class1485 Delegate332();

	public delegate void Delegate334(Class1485 elementData);

	public delegate void Delegate333(Class1485 elementData);

	public const uint uint_0 = 2u;

	private string string_0;

	private string string_1;

	private string string_2;

	private uint uint_1;

	public string Connection
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

	public string Command
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public string ServerCommand
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public uint CommandType
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
				case "commandType":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "serverCommand":
					string_2 = reader.Value;
					break;
				case "command":
					string_1 = reader.Value;
					break;
				case "connection":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1485(XmlReader reader)
		: base(reader)
	{
	}

	public Class1485()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = 2u;
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
		writer.WriteAttributeString("connection", string_0);
		if (string_1 != null)
		{
			writer.WriteAttributeString("command", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("serverCommand", string_2);
		}
		if (uint_1 != 2)
		{
			writer.WriteAttributeString("commandType", XmlConvert.ToString(uint_1));
		}
		writer.WriteEndElement();
	}
}
