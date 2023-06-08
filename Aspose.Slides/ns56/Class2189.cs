using System;
using System.Xml;

namespace ns56;

internal class Class2189 : Class1351
{
	public delegate Class2189 Delegate2299();

	public delegate void Delegate2300(Class2189 elementData);

	public delegate void Delegate2301(Class2189 elementData);

	public Class1916.Delegate1615 delegate1615_0;

	public Class1916.Delegate1617 delegate1617_0;

	public Class1919.Delegate1624 delegate1624_0;

	public Class1919.Delegate1626 delegate1626_0;

	public Class2190.Delegate2302 delegate2302_0;

	public Class2190.Delegate2304 delegate2304_0;

	public Class1922.Delegate1633 delegate1633_0;

	public Class1922.Delegate1635 delegate1635_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private string string_0;

	private Class1916 class1916_0;

	private Class1919 class1919_0;

	private Class2190 class2190_0;

	private Class1922 class1922_0;

	private Class1886 class1886_0;

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class1916 Scene3d => class1916_0;

	public Class1919 Sp3d => class1919_0;

	public Class2190 TxPr => class2190_0;

	public Class1922 Style => class1922_0;

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
				case "style":
					class1922_0 = new Class1922(reader);
					break;
				case "txPr":
					class2190_0 = new Class2190(reader);
					break;
				case "sp3d":
					class1919_0 = new Class1919(reader);
					break;
				case "scene3d":
					class1916_0 = new Class1916(reader);
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
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "name")
			{
				string_0 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class2189(XmlReader reader)
		: base(reader)
	{
	}

	public Class2189()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1615_0 = method_3;
		delegate1617_0 = method_4;
		delegate1624_0 = method_5;
		delegate1626_0 = method_6;
		delegate2302_0 = method_7;
		delegate2304_0 = method_8;
		delegate1633_0 = method_9;
		delegate1635_0 = method_10;
		delegate1534_0 = method_11;
		delegate1535_0 = method_12;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("name", string_0);
		if (class1916_0 != null)
		{
			class1916_0.vmethod_4("dgm", writer, "scene3d");
		}
		if (class1919_0 != null)
		{
			class1919_0.vmethod_4("dgm", writer, "sp3d");
		}
		if (class2190_0 != null)
		{
			class2190_0.vmethod_4("dgm", writer, "txPr");
		}
		if (class1922_0 != null)
		{
			class1922_0.vmethod_4("dgm", writer, "style");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("dgm", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1916 method_3()
	{
		if (class1916_0 != null)
		{
			throw new Exception("Only one <scene3d> element can be added.");
		}
		class1916_0 = new Class1916();
		return class1916_0;
	}

	private void method_4(Class1916 _scene3d)
	{
		class1916_0 = _scene3d;
	}

	private Class1919 method_5()
	{
		if (class1919_0 != null)
		{
			throw new Exception("Only one <sp3d> element can be added.");
		}
		class1919_0 = new Class1919();
		return class1919_0;
	}

	private void method_6(Class1919 _sp3d)
	{
		class1919_0 = _sp3d;
	}

	private Class2190 method_7()
	{
		if (class2190_0 != null)
		{
			throw new Exception("Only one <txPr> element can be added.");
		}
		class2190_0 = new Class2190();
		return class2190_0;
	}

	private void method_8(Class2190 _txPr)
	{
		class2190_0 = _txPr;
	}

	private Class1922 method_9()
	{
		if (class1922_0 != null)
		{
			throw new Exception("Only one <style> element can be added.");
		}
		class1922_0 = new Class1922();
		return class1922_0;
	}

	private void method_10(Class1922 _style)
	{
		class1922_0 = _style;
	}

	private Class1885 method_11()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_12(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
