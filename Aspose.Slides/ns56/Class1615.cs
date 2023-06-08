using System.Xml;

namespace ns56;

internal class Class1615 : Class1351
{
	public delegate Class1615 Delegate724();

	public delegate void Delegate725(Class1615 elementData);

	public delegate void Delegate726(Class1615 elementData);

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	private string string_7;

	private string string_8;

	private string string_9;

	private string string_10;

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

	public string Caption
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

	public string DisplayFolder
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

	public string MeasureGroup
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

	public string Parent
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public string Value
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public string Goal
	{
		get
		{
			return string_6;
		}
		set
		{
			string_6 = value;
		}
	}

	public string Status
	{
		get
		{
			return string_7;
		}
		set
		{
			string_7 = value;
		}
	}

	public string Trend
	{
		get
		{
			return string_8;
		}
		set
		{
			string_8 = value;
		}
	}

	public string Weight
	{
		get
		{
			return string_9;
		}
		set
		{
			string_9 = value;
		}
	}

	public string Time
	{
		get
		{
			return string_10;
		}
		set
		{
			string_10 = value;
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
				case "uniqueName":
					string_0 = reader.Value;
					break;
				case "caption":
					string_1 = reader.Value;
					break;
				case "displayFolder":
					string_2 = reader.Value;
					break;
				case "measureGroup":
					string_3 = reader.Value;
					break;
				case "parent":
					string_4 = reader.Value;
					break;
				case "value":
					string_5 = reader.Value;
					break;
				case "goal":
					string_6 = reader.Value;
					break;
				case "status":
					string_7 = reader.Value;
					break;
				case "trend":
					string_8 = reader.Value;
					break;
				case "weight":
					string_9 = reader.Value;
					break;
				case "time":
					string_10 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1615(XmlReader reader)
		: base(reader)
	{
	}

	public Class1615()
	{
	}

	protected override void vmethod_1()
	{
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
		if (string_1 != null)
		{
			writer.WriteAttributeString("caption", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("displayFolder", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("measureGroup", string_3);
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("parent", string_4);
		}
		writer.WriteAttributeString("value", string_5);
		if (string_6 != null)
		{
			writer.WriteAttributeString("goal", string_6);
		}
		if (string_7 != null)
		{
			writer.WriteAttributeString("status", string_7);
		}
		if (string_8 != null)
		{
			writer.WriteAttributeString("trend", string_8);
		}
		if (string_9 != null)
		{
			writer.WriteAttributeString("weight", string_9);
		}
		if (string_10 != null)
		{
			writer.WriteAttributeString("time", string_10);
		}
		writer.WriteEndElement();
	}
}
