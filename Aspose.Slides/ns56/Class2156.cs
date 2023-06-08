using System;
using System.Xml;

namespace ns56;

internal class Class2156 : Class1351
{
	public delegate Class2156 Delegate2200();

	public delegate void Delegate2201(Class2156 elementData);

	public delegate void Delegate2202(Class2156 elementData);

	public const string string_0 = "";

	public const string string_1 = "";

	public const double double_0 = 0.0;

	public const double double_1 = 1.0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Enum305 enum305_0;

	private Enum329 enum329_0;

	private string string_2;

	private Enum332 enum332_0;

	private Enum305 enum305_1;

	private Enum329 enum329_1;

	private string string_3;

	private Enum332 enum332_1;

	private Enum326 enum326_0;

	private double double_2;

	private double double_3;

	private Class1886 class1886_0;

	public static readonly Enum329 enum329_2 = Class2459.smethod_0("self");

	public static readonly Enum332 enum332_2 = Class2463.smethod_0("all");

	public static readonly Enum305 enum305_2 = Class2460.smethod_0("none");

	public static readonly Enum329 enum329_3 = Class2459.smethod_0("self");

	public static readonly Enum332 enum332_3 = Class2463.smethod_0("all");

	public static readonly Enum326 enum326_1 = Class2456.smethod_0("none");

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
			return string_2;
		}
		set
		{
			string_2 = value;
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

	public Enum305 RefType
	{
		get
		{
			return enum305_1;
		}
		set
		{
			enum305_1 = value;
		}
	}

	public Enum329 RefFor
	{
		get
		{
			return enum329_1;
		}
		set
		{
			enum329_1 = value;
		}
	}

	public string RefForName
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

	public Enum332 RefPtType
	{
		get
		{
			return enum332_1;
		}
		set
		{
			enum332_1 = value;
		}
	}

	public Enum326 Op
	{
		get
		{
			return enum326_0;
		}
		set
		{
			enum326_0 = value;
		}
	}

	public double Val
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

	public double Fact
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
					string_2 = reader.Value;
					break;
				case "ptType":
					enum332_0 = Class2463.smethod_0(reader.Value);
					break;
				case "refType":
					enum305_1 = Class2460.smethod_0(reader.Value);
					break;
				case "refFor":
					enum329_1 = Class2459.smethod_0(reader.Value);
					break;
				case "refForName":
					string_3 = reader.Value;
					break;
				case "refPtType":
					enum332_1 = Class2463.smethod_0(reader.Value);
					break;
				case "op":
					enum326_0 = Class2456.smethod_0(reader.Value);
					break;
				case "val":
					double_2 = ToDouble(reader.Value);
					break;
				case "fact":
					double_3 = ToDouble(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2156(XmlReader reader)
		: base(reader)
	{
	}

	public Class2156()
	{
	}

	protected override void vmethod_1()
	{
		enum305_0 = Enum305.const_0;
		enum329_0 = enum329_2;
		string_2 = "";
		enum332_0 = enum332_2;
		enum305_1 = enum305_2;
		enum329_1 = enum329_3;
		string_3 = "";
		enum332_1 = enum332_3;
		enum326_0 = enum326_1;
		double_2 = 0.0;
		double_3 = 1.0;
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
		if (enum329_0 != enum329_2)
		{
			writer.WriteAttributeString("for", Class2459.smethod_1(enum329_0));
		}
		if (string_2 != "")
		{
			writer.WriteAttributeString("forName", string_2);
		}
		if (enum332_0 != enum332_2)
		{
			writer.WriteAttributeString("ptType", Class2463.smethod_1(enum332_0));
		}
		if (enum305_1 != enum305_2)
		{
			writer.WriteAttributeString("refType", Class2460.smethod_1(enum305_1));
		}
		if (enum329_1 != enum329_3)
		{
			writer.WriteAttributeString("refFor", Class2459.smethod_1(enum329_1));
		}
		if (string_3 != "")
		{
			writer.WriteAttributeString("refForName", string_3);
		}
		if (enum332_1 != enum332_3)
		{
			writer.WriteAttributeString("refPtType", Class2463.smethod_1(enum332_1));
		}
		if (enum326_0 != enum326_1)
		{
			writer.WriteAttributeString("op", Class2456.smethod_1(enum326_0));
		}
		if (double_2 != 0.0)
		{
			writer.WriteAttributeString("val", XmlConvert.ToString(double_2));
		}
		if (double_3 != 1.0)
		{
			writer.WriteAttributeString("fact", XmlConvert.ToString(double_3));
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
