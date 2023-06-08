using System.Xml;

namespace ns56;

internal class Class1742 : Class1351
{
	public delegate Class1742 Delegate1105();

	public delegate void Delegate1106(Class1742 elementData);

	public delegate void Delegate1107(Class1742 elementData);

	public const bool bool_0 = false;

	private uint uint_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private bool bool_1;

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

	public string DivId
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

	public string SourceObject
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

	public string DestinationFile
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

	public string Title
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public bool AutoRepublish
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
				case "id":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "divId":
					string_0 = reader.Value;
					break;
				case "sourceObject":
					string_1 = reader.Value;
					break;
				case "destinationFile":
					string_2 = reader.Value;
					break;
				case "title":
					string_3 = reader.Value;
					break;
				case "autoRepublish":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1742(XmlReader reader)
		: base(reader)
	{
	}

	public Class1742()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
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
		writer.WriteAttributeString("divId", string_0);
		if (string_1 != null)
		{
			writer.WriteAttributeString("sourceObject", string_1);
		}
		writer.WriteAttributeString("destinationFile", string_2);
		if (string_3 != null)
		{
			writer.WriteAttributeString("title", string_3);
		}
		if (bool_1)
		{
			writer.WriteAttributeString("autoRepublish", bool_1 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
