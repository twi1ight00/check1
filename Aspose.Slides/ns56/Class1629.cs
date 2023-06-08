using System.Xml;

namespace ns56;

internal class Class1629 : Class1351
{
	public delegate Class1629 Delegate766();

	public delegate void Delegate767(Class1629 elementData);

	public delegate void Delegate768(Class1629 elementData);

	public const bool bool_0 = false;

	private bool bool_1;

	private string string_0;

	private string string_1;

	private string string_2;

	public bool Measure
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

	public string UniqueName
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

	public string Caption
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
				case "caption":
					string_2 = reader.Value;
					break;
				case "uniqueName":
					string_1 = reader.Value;
					break;
				case "name":
					string_0 = reader.Value;
					break;
				case "measure":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1629(XmlReader reader)
		: base(reader)
	{
	}

	public Class1629()
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
		if (bool_1)
		{
			writer.WriteAttributeString("measure", bool_1 ? "1" : "0");
		}
		writer.WriteAttributeString("name", string_0);
		writer.WriteAttributeString("uniqueName", string_1);
		writer.WriteAttributeString("caption", string_2);
		writer.WriteEndElement();
	}
}
