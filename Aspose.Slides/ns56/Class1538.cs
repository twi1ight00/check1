using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1538 : Class1351
{
	public delegate Class1538 Delegate493();

	public delegate void Delegate494(Class1538 elementData);

	public delegate void Delegate495(Class1538 elementData);

	public const double double_0 = 0.0;

	public const double double_1 = 0.0;

	public const double double_2 = 0.0;

	public const double double_3 = 0.0;

	public const double double_4 = 0.0;

	public Class1539.Delegate496 delegate496_0;

	public Class1539.Delegate497 delegate497_0;

	private Enum210 enum210_0;

	private double double_5;

	private double double_6;

	private double double_7;

	private double double_8;

	private double double_9;

	private List<Class1539> list_0;

	public static readonly Enum210 enum210_1 = Class2377.smethod_0("linear");

	public Enum210 Type
	{
		get
		{
			return enum210_0;
		}
		set
		{
			enum210_0 = value;
		}
	}

	public double Degree
	{
		get
		{
			return double_5;
		}
		set
		{
			double_5 = value;
		}
	}

	public double Left
	{
		get
		{
			return double_6;
		}
		set
		{
			double_6 = value;
		}
	}

	public double Right
	{
		get
		{
			return double_7;
		}
		set
		{
			double_7 = value;
		}
	}

	public double Top
	{
		get
		{
			return double_8;
		}
		set
		{
			double_8 = value;
		}
	}

	public double Bottom
	{
		get
		{
			return double_9;
		}
		set
		{
			double_9 = value;
		}
	}

	public Class1539[] StopList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "stop")
				{
					Class1539 item = new Class1539(reader);
					list_0.Add(item);
				}
				else
				{
					reader.Skip();
					flag = true;
				}
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
				case "type":
					enum210_0 = Class2377.smethod_0(reader.Value);
					break;
				case "degree":
					double_5 = ToDouble(reader.Value);
					break;
				case "left":
					double_6 = ToDouble(reader.Value);
					break;
				case "right":
					double_7 = ToDouble(reader.Value);
					break;
				case "top":
					double_8 = ToDouble(reader.Value);
					break;
				case "bottom":
					double_9 = ToDouble(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1538(XmlReader reader)
		: base(reader)
	{
	}

	public Class1538()
	{
	}

	protected override void vmethod_1()
	{
		enum210_0 = enum210_1;
		double_5 = 0.0;
		double_6 = 0.0;
		double_7 = 0.0;
		double_8 = 0.0;
		double_9 = 0.0;
		list_0 = new List<Class1539>();
	}

	protected override void vmethod_2()
	{
		delegate496_0 = method_3;
		delegate497_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum210_0 != enum210_1)
		{
			writer.WriteAttributeString("type", Class2377.smethod_1(enum210_0));
		}
		if (double_5 != 0.0)
		{
			writer.WriteAttributeString("degree", XmlConvert.ToString(double_5));
		}
		if (double_6 != 0.0)
		{
			writer.WriteAttributeString("left", XmlConvert.ToString(double_6));
		}
		if (double_7 != 0.0)
		{
			writer.WriteAttributeString("right", XmlConvert.ToString(double_7));
		}
		if (double_8 != 0.0)
		{
			writer.WriteAttributeString("top", XmlConvert.ToString(double_8));
		}
		if (double_9 != 0.0)
		{
			writer.WriteAttributeString("bottom", XmlConvert.ToString(double_9));
		}
		foreach (Class1539 item in list_0)
		{
			item.vmethod_4("ssml", writer, "stop");
		}
		writer.WriteEndElement();
	}

	private Class1539 method_3()
	{
		Class1539 @class = new Class1539();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1539 elementData)
	{
		list_0.Add(elementData);
	}
}
