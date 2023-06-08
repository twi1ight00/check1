using System.Xml;

namespace ns56;

internal class Class1838 : Class1351
{
	public delegate Class1838 Delegate1393();

	public delegate void Delegate1394(Class1838 elementData);

	public delegate void Delegate1395(Class1838 elementData);

	public const string string_0 = "";

	public const bool bool_0 = false;

	private string string_1;

	private string string_2;

	private bool bool_1;

	public string R_Embed
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

	public string Name
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

	public bool BuiltIn
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
				case "builtIn":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "name":
					string_2 = reader.Value;
					break;
				case "r:embed":
					string_1 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1838(XmlReader reader)
		: base(reader)
	{
	}

	public Class1838()
	{
	}

	protected override void vmethod_1()
	{
		string_2 = "";
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
		writer.WriteAttributeString("r:embed", string_1);
		if (string_2 != "")
		{
			writer.WriteAttributeString("name", string_2);
		}
		if (bool_1)
		{
			writer.WriteAttributeString("builtIn", bool_1 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
