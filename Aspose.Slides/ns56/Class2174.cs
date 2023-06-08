using System;
using System.Xml;

namespace ns56;

internal class Class2174 : Class1351
{
	public delegate Class2174 Delegate2254();

	public delegate void Delegate2255(Class2174 elementData);

	public delegate void Delegate2256(Class2174 elementData);

	public const string string_0 = "";

	public const double double_0 = double.NaN;

	public const double double_1 = double.NaN;

	public const double double_2 = double.NaN;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Enum305 enum305_0;

	private Enum329 enum329_0;

	private string string_1;

	private Enum332 enum332_0;

	private double double_3;

	private double double_4;

	private double double_5;

	private Class1886 class1886_0;

	public static readonly Enum329 enum329_1 = Class2459.smethod_0("self");

	public static readonly Enum332 enum332_1 = Class2463.smethod_0("all");

	public Enum305 Type
	{
		get
		{
			return enum305_0;
		}
		set
		{
			enum305_0 = value;
		}
	}

	public Enum329 For
	{
		get
		{
			return enum329_0;
		}
		set
		{
			enum329_0 = value;
		}
	}

	public string ForName
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

	public Enum332 PtType
	{
		get
		{
			return enum332_0;
		}
		set
		{
			enum332_0 = value;
		}
	}

	public double Val
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

	public double Fact
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
		}
	}

	public double Max
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

	public Class1885 ExtLst => class1886_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "extLst")
				{
					class1886_0 = new Class1886(reader);
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
				case "type":
					enum305_0 = Class2460.smethod_0(reader.Value);
					break;
				case "for":
					enum329_0 = Class2459.smethod_0(reader.Value);
					break;
				case "forName":
					string_1 = reader.Value;
					break;
				case "ptType":
					enum332_0 = Class2463.smethod_0(reader.Value);
					break;
				case "val":
					double_3 = ToDouble(reader.Value);
					break;
				case "fact":
					double_4 = ToDouble(reader.Value);
					break;
				case "max":
					double_5 = ToDouble(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2174(XmlReader reader)
		: base(reader)
	{
	}

	public Class2174()
	{
	}

	protected override void vmethod_1()
	{
		enum305_0 = Enum305.const_0;
		enum329_0 = enum329_1;
		string_1 = "";
		enum332_0 = enum332_1;
		double_3 = double.NaN;
		double_4 = double.NaN;
		double_5 = double.NaN;
	}

	protected override void vmethod_2()
	{
		delegate1534_0 = method_3;
		delegate1535_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("type", Class2460.smethod_1(enum305_0));
		if (enum329_0 != enum329_1)
		{
			writer.WriteAttributeString("for", Class2459.smethod_1(enum329_0));
		}
		if (string_1 != "")
		{
			writer.WriteAttributeString("forName", string_1);
		}
		if (enum332_0 != enum332_1)
		{
			writer.WriteAttributeString("ptType", Class2463.smethod_1(enum332_0));
		}
		if (!double.IsNaN(double_3))
		{
			writer.WriteAttributeString("val", XmlConvert.ToString(double_3));
		}
		if (!double.IsNaN(double_4))
		{
			writer.WriteAttributeString("fact", XmlConvert.ToString(double_4));
		}
		if (!double.IsNaN(double_5))
		{
			writer.WriteAttributeString("max", XmlConvert.ToString(double_5));
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("dgm", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1885 method_3()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_4(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
