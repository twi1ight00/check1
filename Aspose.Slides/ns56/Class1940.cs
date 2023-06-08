using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1940 : Class1351
{
	public delegate Class1940 Delegate1687();

	public delegate void Delegate1688(Class1940 elementData);

	public delegate void Delegate1689(Class1940 elementData);

	public Class1934.Delegate1669 delegate1669_0;

	public Class1934.Delegate1670 delegate1670_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private double double_0;

	private List<Class1934> list_0;

	private Class1886 class1886_0;

	public double H
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public Class1934[] TcList => list_0.ToArray();

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
				case "tc":
				{
					Class1934 item = new Class1934(reader);
					list_0.Add(item);
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
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "h")
			{
				double_0 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
			}
		}
		reader.MoveToElement();
	}

	public Class1940(XmlReader reader)
		: base(reader)
	{
	}

	public Class1940()
	{
	}

	protected override void vmethod_1()
	{
		double_0 = double.NaN;
		list_0 = new List<Class1934>();
	}

	protected override void vmethod_2()
	{
		delegate1669_0 = method_3;
		delegate1670_0 = method_4;
		delegate1534_0 = method_5;
		delegate1535_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("h", XmlConvert.ToString((long)Math.Round(double_0 * 12700.0)));
		foreach (Class1934 item in list_0)
		{
			item.vmethod_4("a", writer, "tc");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1934 method_3()
	{
		Class1934 @class = new Class1934();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1934 elementData)
	{
		list_0.Add(elementData);
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
