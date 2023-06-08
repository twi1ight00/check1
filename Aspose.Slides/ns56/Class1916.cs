using System;
using System.Xml;

namespace ns56;

internal class Class1916 : Class1351
{
	public delegate Class1916 Delegate1615();

	public delegate void Delegate1617(Class1916 elementData);

	public delegate void Delegate1616(Class1916 elementData);

	public Class1802.Delegate1285 delegate1285_0;

	public Class1802.Delegate1287 delegate1287_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class1812 class1812_0;

	private Class1869 class1869_0;

	private Class1802 class1802_0;

	private Class1886 class1886_0;

	public Class1812 Camera => class1812_0;

	public Class1869 LightRig => class1869_0;

	public Class1802 Backdrop => class1802_0;

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
				case "backdrop":
					class1802_0 = new Class1802(reader);
					break;
				case "lightRig":
					class1869_0 = new Class1869(reader);
					break;
				case "camera":
					class1812_0 = new Class1812(reader);
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
	}

	public Class1916(XmlReader reader)
		: base(reader)
	{
	}

	public Class1916()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1285_0 = method_3;
		delegate1287_0 = method_4;
		delegate1534_0 = method_5;
		delegate1535_0 = method_6;
	}

	protected override void vmethod_3()
	{
		class1812_0 = new Class1812();
		class1869_0 = new Class1869();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1812_0.vmethod_4("a", writer, "camera");
		class1869_0.vmethod_4("a", writer, "lightRig");
		if (class1802_0 != null)
		{
			class1802_0.vmethod_4("a", writer, "backdrop");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1802 method_3()
	{
		if (class1802_0 != null)
		{
			throw new Exception("Only one <backdrop> element can be added.");
		}
		class1802_0 = new Class1802();
		return class1802_0;
	}

	private void method_4(Class1802 _backdrop)
	{
		class1802_0 = _backdrop;
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
