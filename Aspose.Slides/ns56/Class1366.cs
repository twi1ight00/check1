using System.Xml;

namespace ns56;

internal class Class1366 : Class1351
{
	public delegate Class1366 Delegate60();

	public delegate void Delegate61(Class1366 elementData);

	public delegate void Delegate62(Class1366 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	private string string_0;

	private bool bool_2;

	private bool bool_3;

	public string Prst
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

	public bool InvX
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

	public bool InvY
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
				case "invY":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "invX":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "prst":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1366(XmlReader reader)
		: base(reader)
	{
	}

	public Class1366()
	{
	}

	protected override void vmethod_1()
	{
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
		if (string_0 != null)
		{
			writer.WriteAttributeString("prst", string_0);
		}
		if (bool_2)
		{
			writer.WriteAttributeString("invX", bool_2 ? "1" : "0");
		}
		if (bool_3)
		{
			writer.WriteAttributeString("invY", bool_3 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
