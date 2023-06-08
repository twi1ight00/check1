using System.Xml;

namespace ns56;

internal class Class2212 : Class1351
{
	public delegate Class2212 Delegate2372();

	public delegate void Delegate2373(Class2212 elementData);

	public delegate void Delegate2374(Class2212 elementData);

	public const Enum362 enum362_0 = Enum362.const_0;

	public const Enum352 enum352_0 = Enum352.const_0;

	private Enum362 enum362_1;

	private string string_0;

	private Enum352 enum352_1;

	private string string_1;

	private string string_2;

	private string string_3;

	public Enum362 V_Ext
	{
		get
		{
			return enum362_1;
		}
		set
		{
			enum362_1 = value;
		}
	}

	public string Id
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

	public Enum352 On
	{
		get
		{
			return enum352_1;
		}
		set
		{
			enum352_1 = value;
		}
	}

	public string Offset
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

	public string Origin
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

	public string Matrix
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
				case "v:ext":
					enum362_1 = Class2498.smethod_0(reader.Value);
					break;
				case "id":
					string_0 = reader.Value;
					break;
				case "on":
					enum352_1 = Class2488.smethod_0(reader.Value);
					break;
				case "offset":
					string_1 = reader.Value;
					break;
				case "origin":
					string_2 = reader.Value;
					break;
				case "matrix":
					string_3 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2212(XmlReader reader)
		: base(reader)
	{
	}

	public Class2212()
	{
	}

	protected override void vmethod_1()
	{
		enum362_1 = Enum362.const_0;
		enum352_1 = Enum352.const_0;
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
		if (enum362_1 != 0)
		{
			writer.WriteAttributeString("v:ext", Class2498.smethod_1(enum362_1));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("id", string_0);
		}
		if (enum352_1 != 0)
		{
			writer.WriteAttributeString("on", Class2488.smethod_1(enum352_1));
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("offset", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("origin", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("matrix", string_3);
		}
		writer.WriteEndElement();
	}
}
