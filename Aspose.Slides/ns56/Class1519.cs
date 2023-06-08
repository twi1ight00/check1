using System.Xml;

namespace ns56;

internal class Class1519 : Class1351
{
	public delegate void Delegate437(Class1519 elementData);

	public delegate Class1519 Delegate436();

	public delegate void Delegate438(Class1519 elementData);

	public const bool bool_0 = true;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	public bool AutoRecover
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

	public bool CrashSave
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

	public bool DataExtractLoad
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public bool RepairLoad
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
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
				case "repairLoad":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "dataExtractLoad":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "crashSave":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "autoRecover":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1519(XmlReader reader)
		: base(reader)
	{
	}

	public Class1519()
	{
	}

	protected override void vmethod_1()
	{
		bool_4 = true;
		bool_5 = false;
		bool_6 = false;
		bool_7 = false;
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
		if (!bool_4)
		{
			writer.WriteAttributeString("autoRecover", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("crashSave", bool_5 ? "1" : "0");
		}
		if (bool_6)
		{
			writer.WriteAttributeString("dataExtractLoad", bool_6 ? "1" : "0");
		}
		if (bool_7)
		{
			writer.WriteAttributeString("repairLoad", bool_7 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
