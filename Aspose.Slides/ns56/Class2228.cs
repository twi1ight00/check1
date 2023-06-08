using System;
using System.Xml;

namespace ns56;

internal class Class2228 : Class1351
{
	public delegate Class2228 Delegate2422();

	public delegate void Delegate2424(Class2228 elementData);

	public delegate void Delegate2423(Class2228 elementData);

	public const string string_0 = "";

	public const bool bool_0 = false;

	public const double double_0 = double.NaN;

	public const double double_1 = double.NaN;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2004.Delegate1833 delegate1833_0;

	public Class2004.Delegate1834 delegate1834_0;

	private string string_1;

	private string string_2;

	private bool bool_1;

	private string string_3;

	private double double_2;

	private double double_3;

	private Class1888 class1888_0;

	private Class2006 class2006_0;

	public string Spid
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

	public string Name
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

	public bool ShowAsIcon
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

	public string R_Id
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

	public double ImgW
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

	public double ImgH
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

	public Class1885 ExtLst => class1888_0;

	public Class2004 Pic => class2006_0;

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
				case "pic":
					class2006_0 = new Class2006(reader);
					break;
				case "extLst":
					class1888_0 = new Class1888(reader);
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
				case "spid":
					string_1 = reader.Value;
					break;
				case "name":
					string_2 = reader.Value;
					break;
				case "showAsIcon":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "r:id":
					string_3 = reader.Value;
					break;
				case "imgW":
					double_2 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "imgH":
					double_3 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2228(XmlReader reader)
		: base(reader)
	{
	}

	public Class2228()
	{
	}

	protected override void vmethod_1()
	{
		string_2 = "";
		bool_1 = false;
		double_2 = double.NaN;
		double_3 = double.NaN;
	}

	protected override void vmethod_2()
	{
		delegate1534_0 = method_3;
		delegate1535_0 = method_4;
		delegate1833_0 = method_5;
		delegate1834_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_1 != null)
		{
			writer.WriteAttributeString("spid", string_1);
		}
		if (string_2 != "")
		{
			writer.WriteAttributeString("name", string_2);
		}
		if (bool_1)
		{
			writer.WriteAttributeString("showAsIcon", bool_1 ? "1" : "0");
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("r:id", string_3);
		}
		if (!double.IsNaN(double_2))
		{
			writer.WriteAttributeString("imgW", XmlConvert.ToString((long)Math.Round(double_2 * 12700.0)));
		}
		if (!double.IsNaN(double_3))
		{
			writer.WriteAttributeString("imgH", XmlConvert.ToString((long)Math.Round(double_3 * 12700.0)));
		}
		if (class1888_0 != null)
		{
			class1888_0.vmethod_4("p", writer, "extLst");
		}
		if (class2006_0 != null)
		{
			class2006_0.vmethod_4("p", writer, "pic");
		}
		writer.WriteEndElement();
	}

	private Class1885 method_3()
	{
		if (class1888_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1888_0 = new Class1888();
		return class1888_0;
	}

	private void method_4(Class1885 _extLst)
	{
		class1888_0 = (Class1888)_extLst;
	}

	private Class2004 method_5()
	{
		if (class2006_0 != null)
		{
			throw new Exception("Only one <pic> element can be added.");
		}
		class2006_0 = new Class2006();
		return class2006_0;
	}

	private void method_6(Class2004 _pic)
	{
		class2006_0 = (Class2006)_pic;
	}
}
