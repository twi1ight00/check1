using System.Xml;
using ns57;

namespace ns56;

internal class Class1794 : Class1351
{
	public delegate Class1794 Delegate1261();

	public delegate void Delegate1262(Class1794 elementData);

	public delegate void Delegate1263(Class1794 elementData);

	public const int int_0 = -1;

	public const int int_1 = -1;

	private int int_2;

	private int int_3;

	private Enum290 enum290_0;

	public int SeriesIdx
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

	public int CategoryIdx
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

	public Enum290 BldStep
	{
		get
		{
			return enum290_0;
		}
		set
		{
			enum290_0 = value;
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
				case "bldStep":
					enum290_0 = Class2520.smethod_0(reader.Value);
					break;
				case "categoryIdx":
					int_3 = XmlConvert.ToInt32(reader.Value);
					break;
				case "seriesIdx":
					int_2 = XmlConvert.ToInt32(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1794(XmlReader reader)
		: base(reader)
	{
	}

	public Class1794()
	{
	}

	protected override void vmethod_1()
	{
		int_2 = -1;
		int_3 = -1;
		enum290_0 = Enum290.const_5;
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
		if (int_2 != -1)
		{
			writer.WriteAttributeString("seriesIdx", XmlConvert.ToString(int_2));
		}
		if (int_3 != -1)
		{
			writer.WriteAttributeString("categoryIdx", XmlConvert.ToString(int_3));
		}
		writer.WriteAttributeString("bldStep", Class2520.smethod_1(enum290_0));
		writer.WriteEndElement();
	}
}
