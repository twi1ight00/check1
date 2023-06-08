using System;
using System.Collections.Generic;
using System.Xml;
using ns16;

namespace ns56;

internal class Class1894 : Class1351
{
	public delegate Class1894 Delegate1549();

	public delegate void Delegate1550(Class1894 elementData);

	public delegate void Delegate1551(Class1894 elementData);

	public const double double_0 = 0.0;

	public const double double_1 = 0.0;

	public const bool bool_0 = true;

	public const bool bool_1 = true;

	public Class2605.Delegate2773 delegate2773_0;

	private double double_2;

	private double double_3;

	private Enum271 enum271_0;

	private bool bool_2;

	private bool bool_3;

	private List<Class2605> list_0;

	public static readonly Enum271 enum271_1 = Class2541.smethod_0("norm");

	public double W
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public double H
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	public Enum271 Fill
	{
		get
		{
			return enum271_0;
		}
		set
		{
			enum271_0 = value;
		}
	}

	public bool Stroke
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

	public bool ExtrusionOk
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

	public Class2605[] Path2DCommandList => list_0.ToArray();

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
				switch (reader.LocalName)
				{
				case "close":
				{
					Class1892 obj6 = new Class1892(reader);
					list_0.Add(new Class2605("close", obj6));
					break;
				}
				case "moveTo":
				{
					Class1897 obj5 = new Class1897(reader);
					list_0.Add(new Class2605("moveTo", obj5));
					break;
				}
				case "lnTo":
				{
					Class1895 obj4 = new Class1895(reader);
					list_0.Add(new Class2605("lnTo", obj4));
					break;
				}
				case "arcTo":
				{
					Class1891 obj3 = new Class1891(reader);
					list_0.Add(new Class2605("arcTo", obj3));
					break;
				}
				case "quadBezTo":
				{
					Class1898 obj2 = new Class1898(reader);
					list_0.Add(new Class2605("quadBezTo", obj2));
					break;
				}
				case "cubicBezTo":
				{
					Class1893 obj = new Class1893(reader);
					list_0.Add(new Class2605("cubicBezTo", obj));
					break;
				}
				default:
					reader.Skip();
					flag = true;
					break;
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
				case "extrusionOk":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "stroke":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "fill":
					enum271_0 = Class2541.smethod_0(reader.Value);
					break;
				case "h":
					double_3 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "w":
					double_2 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1894(XmlReader reader)
		: base(reader)
	{
	}

	public Class1894()
	{
	}

	protected override void vmethod_1()
	{
		double_2 = 0.0;
		double_3 = 0.0;
		enum271_0 = enum271_1;
		bool_2 = true;
		bool_3 = true;
		list_0 = new List<Class2605>();
	}

	protected override void vmethod_2()
	{
		delegate2773_0 = method_3;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (double_2 != 0.0)
		{
			writer.WriteAttributeString("w", XmlConvert.ToString((long)Math.Round(double_2 * 12700.0)));
		}
		if (double_3 != 0.0)
		{
			writer.WriteAttributeString("h", XmlConvert.ToString((long)Math.Round(double_3 * 12700.0)));
		}
		if (enum271_0 != enum271_1)
		{
			writer.WriteAttributeString("fill", Class2541.smethod_1(enum271_0));
		}
		if (!bool_2)
		{
			writer.WriteAttributeString("stroke", bool_2 ? "1" : "0");
		}
		if (!bool_3)
		{
			writer.WriteAttributeString("extrusionOk", bool_3 ? "1" : "0");
		}
		foreach (Class2605 item in list_0)
		{
			switch (item.Name)
			{
			case "close":
				((Class1892)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "moveTo":
				((Class1897)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "lnTo":
				((Class1895)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "arcTo":
				((Class1891)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "quadBezTo":
				((Class1898)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "cubicBezTo":
				((Class1893)item.Object).vmethod_4("a", writer, item.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"close" => new Class2605("close", new Class1892()), 
			"moveTo" => new Class2605("moveTo", new Class1897()), 
			"lnTo" => new Class2605("lnTo", new Class1895()), 
			"arcTo" => new Class2605("arcTo", new Class1891()), 
			"quadBezTo" => new Class2605("quadBezTo", new Class1898()), 
			"cubicBezTo" => new Class2605("cubicBezTo", new Class1893()), 
			_ => throw new Exception("Wrong element: " + elementName), 
		};
		list_0.Add(@class);
		return @class;
	}

	public void method_4(Class2605 obj)
	{
		list_0.Add(obj);
	}
}
