using System.Xml;

namespace ns56;

internal class Class1596 : Class1351
{
	public delegate Class1596 Delegate667();

	public delegate void Delegate668(Class1596 elementData);

	public delegate void Delegate669(Class1596 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	private string string_0;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	public string Name
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

	public bool Icon
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

	public bool Advise
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool PreferPic
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
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
				case "preferPic":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "advise":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "icon":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "name":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1596(XmlReader reader)
		: base(reader)
	{
	}

	public Class1596()
	{
	}

	protected override void vmethod_1()
	{
		bool_3 = false;
		bool_4 = false;
		bool_5 = false;
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
		writer.WriteAttributeString("name", string_0);
		if (bool_3)
		{
			writer.WriteAttributeString("icon", bool_3 ? "1" : "0");
		}
		if (bool_4)
		{
			writer.WriteAttributeString("advise", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("preferPic", bool_5 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
