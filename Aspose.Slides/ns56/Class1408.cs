using System.Xml;

namespace ns56;

internal class Class1408 : Class1351
{
	public delegate Class1408 Delegate186();

	public delegate void Delegate187(Class1408 elementData);

	public delegate void Delegate188(Class1408 elementData);

	public const bool bool_0 = false;

	private uint uint_0;

	private uint uint_1;

	private bool bool_1;

	private Class1621 class1621_0;

	public uint Chart
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public uint Format
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public bool Series
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

	public Class1621 PivotArea => class1621_0;

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
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "pivotArea")
				{
					class1621_0 = new Class1621(reader);
					continue;
				}
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
				case "series":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "format":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "chart":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1408(XmlReader reader)
		: base(reader)
	{
	}

	public Class1408()
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
		class1621_0 = new Class1621();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("chart", XmlConvert.ToString(uint_0));
		writer.WriteAttributeString("format", XmlConvert.ToString(uint_1));
		if (bool_1)
		{
			writer.WriteAttributeString("series", bool_1 ? "1" : "0");
		}
		class1621_0.vmethod_4("ssml", writer, "pivotArea");
		writer.WriteEndElement();
	}
}
