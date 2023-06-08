using System.Xml;

namespace ns56;

internal class Class1543 : Class1351
{
	public delegate Class1543 Delegate508();

	public delegate void Delegate509(Class1543 elementData);

	public delegate void Delegate510(Class1543 elementData);

	public const bool bool_0 = false;

	private string string_0;

	private bool bool_1;

	public string UniqueName
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

	public bool Group
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
				case "group":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "uniqueName":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1543(XmlReader reader)
		: base(reader)
	{
	}

	public Class1543()
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
		writer.WriteAttributeString("uniqueName", string_0);
		if (bool_1)
		{
			writer.WriteAttributeString("group", bool_1 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
