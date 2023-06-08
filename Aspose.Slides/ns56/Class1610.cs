using System.Xml;

namespace ns56;

internal class Class1610 : Class1351
{
	public delegate Class1610 Delegate709();

	public delegate void Delegate710(Class1610 elementData);

	public delegate void Delegate711(Class1610 elementData);

	public const bool bool_0 = true;

	public const bool bool_1 = false;

	private bool bool_2;

	private bool bool_3;

	public bool AutoPageBreaks
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

	public bool FitToPage
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
				case "fitToPage":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "autoPageBreaks":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1610(XmlReader reader)
		: base(reader)
	{
	}

	public Class1610()
	{
	}

	protected override void vmethod_1()
	{
		bool_2 = true;
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
		if (!bool_2)
		{
			writer.WriteAttributeString("autoPageBreaks", bool_2 ? "1" : "0");
		}
		if (bool_3)
		{
			writer.WriteAttributeString("fitToPage", bool_3 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
