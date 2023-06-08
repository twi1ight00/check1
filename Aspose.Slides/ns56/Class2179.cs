using System;
using System.Xml;

namespace ns56;

internal class Class2179 : Class1351
{
	public delegate void Delegate2270(Class2179 elementData);

	public delegate Class2179 Delegate2269();

	public delegate void Delegate2271(Class2179 elementData);

	public const string string_0 = "0";

	public Class2168.Delegate2236 delegate2236_0;

	public Class2168.Delegate2238 delegate2238_0;

	public Class1921.Delegate1630 delegate1630_0;

	public Class1921.Delegate1632 delegate1632_0;

	public Class1946.Delegate1705 delegate1705_0;

	public Class1946.Delegate1707 delegate1707_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private string string_1;

	private Enum337 enum337_0;

	private string string_2;

	private Class2168 class2168_0;

	private Class1921 class1921_0;

	private Class1946 class1946_0;

	private Class1886 class1886_0;

	public static readonly Enum337 enum337_1 = Class2469.smethod_0("node");

	public string ModelId
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

	public Enum337 Type
	{
		get
		{
			return enum337_0;
		}
		set
		{
			enum337_0 = value;
		}
	}

	public string CxnId
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

	public Class2168 PrSet => class2168_0;

	public Class1921 SpPr => class1921_0;

	public Class1946 T => class1946_0;

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
				switch (reader.LocalName)
				{
				case "extLst":
					class1886_0 = new Class1886(reader);
					break;
				case "t":
					class1946_0 = new Class1946(reader);
					break;
				case "spPr":
					class1921_0 = new Class1921(reader);
					break;
				case "prSet":
					class2168_0 = new Class2168(reader);
					break;
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
				case "cxnId":
					string_2 = reader.Value;
					break;
				case "type":
					enum337_0 = Class2469.smethod_0(reader.Value);
					break;
				case "modelId":
					string_1 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2179(XmlReader reader)
		: base(reader)
	{
	}

	public Class2179()
	{
	}

	protected override void vmethod_1()
	{
		enum337_0 = enum337_1;
		string_2 = "0";
	}

	protected override void vmethod_2()
	{
		delegate2236_0 = method_3;
		delegate2238_0 = method_4;
		delegate1630_0 = method_5;
		delegate1632_0 = method_6;
		delegate1705_0 = method_7;
		delegate1707_0 = method_8;
		delegate1534_0 = method_9;
		delegate1535_0 = method_10;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("modelId", string_1);
		if (enum337_0 != enum337_1)
		{
			writer.WriteAttributeString("type", Class2469.smethod_1(enum337_0));
		}
		if (string_2 != "0")
		{
			writer.WriteAttributeString("cxnId", string_2);
		}
		if (class2168_0 != null)
		{
			class2168_0.vmethod_4("dgm", writer, "prSet");
		}
		if (class1921_0 != null)
		{
			class1921_0.vmethod_4("dgm", writer, "spPr");
		}
		if (class1946_0 != null)
		{
			class1946_0.vmethod_4("dgm", writer, "t");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("dgm", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2168 method_3()
	{
		if (class2168_0 != null)
		{
			throw new Exception("Only one <prSet> element can be added.");
		}
		class2168_0 = new Class2168();
		return class2168_0;
	}

	private void method_4(Class2168 _prSet)
	{
		class2168_0 = _prSet;
	}

	private Class1921 method_5()
	{
		if (class1921_0 != null)
		{
			throw new Exception("Only one <spPr> element can be added.");
		}
		class1921_0 = new Class1921();
		return class1921_0;
	}

	private void method_6(Class1921 _spPr)
	{
		class1921_0 = _spPr;
	}

	private Class1946 method_7()
	{
		if (class1946_0 != null)
		{
			throw new Exception("Only one <t> element can be added.");
		}
		class1946_0 = new Class1946();
		return class1946_0;
	}

	private void method_8(Class1946 _t)
	{
		class1946_0 = _t;
	}

	private Class1885 method_9()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_10(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
