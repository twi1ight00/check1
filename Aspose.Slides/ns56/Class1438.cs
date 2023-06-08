using System.Xml;

namespace ns56;

internal class Class1438 : Class1351
{
	public delegate Class1438 Delegate276();

	public delegate void Delegate277(Class1438 elementData);

	public delegate void Delegate278(Class1438 elementData);

	private Enum206 enum206_0;

	private string string_0;

	public static readonly Enum206 enum206_1 = Class2373.smethod_0("equal");

	public Enum206 Operator
	{
		get
		{
			return enum206_0;
		}
		set
		{
			enum206_0 = value;
		}
	}

	public string Val
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
				case "val":
					string_0 = reader.Value;
					break;
				case "operator":
					enum206_0 = Class2373.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1438(XmlReader reader)
		: base(reader)
	{
	}

	public Class1438()
	{
	}

	protected override void vmethod_1()
	{
		enum206_0 = enum206_1;
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
		if (enum206_0 != enum206_1)
		{
			writer.WriteAttributeString("operator", Class2373.smethod_1(enum206_0));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("val", string_0);
		}
		writer.WriteEndElement();
	}
}
