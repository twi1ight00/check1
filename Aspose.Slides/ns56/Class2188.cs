using System;
using System.Xml;

namespace ns56;

internal class Class2188 : Class1351
{
	public delegate Class2188 Delegate2296();

	public delegate void Delegate2297(Class2188 elementData);

	public delegate void Delegate2298(Class2188 elementData);

	public const double double_0 = 0.0;

	public const string string_0 = "none";

	public const int int_0 = 0;

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public Class2145.Delegate2167 delegate2167_0;

	public Class2145.Delegate2169 delegate2169_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private double double_1;

	private string string_1;

	private string string_2;

	private int int_1;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private Class2145 class2145_0;

	private Class1886 class1886_0;

	public double Rot
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public string Type
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

	public string R_Blip
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

	public int ZOrderOff
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public bool HideGeom
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

	public bool LkTxEntry
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

	public bool BlipPhldr
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

	public Class2145 AdjLst => class2145_0;

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
				case "adjLst":
					class2145_0 = new Class2145(reader);
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
				case "rot":
					double_1 = ToDouble(reader.Value);
					break;
				case "type":
					string_1 = reader.Value;
					break;
				case "r:blip":
					string_2 = reader.Value;
					break;
				case "zOrderOff":
					int_1 = XmlConvert.ToInt32(reader.Value);
					break;
				case "hideGeom":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "lkTxEntry":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "blipPhldr":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2188(XmlReader reader)
		: base(reader)
	{
	}

	public Class2188()
	{
	}

	protected override void vmethod_1()
	{
		double_1 = 0.0;
		string_1 = "none";
		int_1 = 0;
		bool_3 = false;
		bool_4 = false;
		bool_5 = false;
	}

	protected override void vmethod_2()
	{
		delegate2167_0 = method_3;
		delegate2169_0 = method_4;
		delegate1534_0 = method_5;
		delegate1535_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (double_1 != 0.0)
		{
			writer.WriteAttributeString("rot", XmlConvert.ToString(double_1));
		}
		if (string_1 != "none")
		{
			writer.WriteAttributeString("type", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("r:blip", string_2);
		}
		if (int_1 != 0)
		{
			writer.WriteAttributeString("zOrderOff", XmlConvert.ToString(int_1));
		}
		if (bool_3)
		{
			writer.WriteAttributeString("hideGeom", bool_3 ? "1" : "0");
		}
		if (bool_4)
		{
			writer.WriteAttributeString("lkTxEntry", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("blipPhldr", bool_5 ? "1" : "0");
		}
		if (class2145_0 != null)
		{
			class2145_0.vmethod_4("dgm", writer, "adjLst");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("dgm", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2145 method_3()
	{
		if (class2145_0 != null)
		{
			throw new Exception("Only one <adjLst> element can be added.");
		}
		class2145_0 = new Class2145();
		return class2145_0;
	}

	private void method_4(Class2145 _adjLst)
	{
		class2145_0 = _adjLst;
	}

	private Class1885 method_5()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_6(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
