using System.Xml;

namespace ns56;

internal class Class2247 : Class1351
{
	public delegate Class2247 Delegate2484();

	public delegate void Delegate2485(Class2247 elementData);

	public delegate void Delegate2486(Class2247 elementData);

	public const bool bool_0 = false;

	private string string_0;

	private bool bool_1;

	public string R_Id
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

	public bool Collapse
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
				case "collapse":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "r:id":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2247(XmlReader reader)
		: base(reader)
	{
	}

	public Class2247()
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
		writer.WriteAttributeString("r:id", string_0);
		if (bool_1)
		{
			writer.WriteAttributeString("collapse", bool_1 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
