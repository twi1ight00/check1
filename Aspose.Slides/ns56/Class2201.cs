using System.Xml;

namespace ns56;

internal class Class2201 : Class1351
{
	public delegate Class2201 Delegate2339();

	public delegate void Delegate2340(Class2201 elementData);

	public delegate void Delegate2341(Class2201 elementData);

	public const int int_0 = 0;

	public const int int_1 = 0;

	private int int_2;

	private int int_3;

	public int New
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public int Old
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
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
				case "old":
					int_3 = XmlConvert.ToInt32(reader.Value);
					break;
				case "new":
					int_2 = XmlConvert.ToInt32(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2201(XmlReader reader)
		: base(reader)
	{
	}

	public Class2201()
	{
	}

	protected override void vmethod_1()
	{
		int_2 = 0;
		int_3 = 0;
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
		if (int_2 != 0)
		{
			writer.WriteAttributeString("new", XmlConvert.ToString(int_2));
		}
		if (int_3 != 0)
		{
			writer.WriteAttributeString("old", XmlConvert.ToString(int_3));
		}
		writer.WriteEndElement();
	}
}
