using System;
using System.Xml;

namespace ns56;

internal class Class2123 : Class1351
{
	public delegate Class2123 Delegate2099();

	public delegate void Delegate2101(Class2123 elementData);

	public delegate void Delegate2100(Class2123 elementData);

	public Class2135.Delegate2136 delegate2136_0;

	public Class2135.Delegate2138 delegate2138_0;

	public Class1921.Delegate1630 delegate1630_0;

	public Class1921.Delegate1632 delegate1632_0;

	public Class1449.Delegate383 delegate383_0;

	public Class1449.Delegate384 delegate384_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class2135 class2135_0;

	private Class1921 class1921_0;

	private Class1453 class1453_0;

	private Class1887 class1887_0;

	public Class2135 Thickness => class2135_0;

	public Class1921 SpPr => class1921_0;

	public Class1453 PictureOptions => class1453_0;

	public Class1885 ExtLst => class1887_0;

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
					class1887_0 = new Class1887(reader);
					break;
				case "pictureOptions":
					class1453_0 = new Class1453(reader);
					flag = true;
					break;
				case "spPr":
					class1921_0 = new Class1921(reader);
					break;
				case "thickness":
					class2135_0 = new Class2135(reader);
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

	public Class2123(XmlReader reader)
		: base(reader)
	{
	}

	public Class2123()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2136_0 = method_3;
		delegate2138_0 = method_4;
		delegate1630_0 = method_5;
		delegate1632_0 = method_6;
		delegate383_0 = method_7;
		delegate384_0 = method_8;
		delegate1534_0 = method_9;
		delegate1535_0 = method_10;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2135_0 != null)
		{
			class2135_0.vmethod_4("c", writer, "thickness");
		}
		if (class1921_0 != null)
		{
			class1921_0.vmethod_4("c", writer, "spPr");
		}
		if (class1453_0 != null)
		{
			class1453_0.vmethod_4("c", writer, "pictureOptions");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2135 method_3()
	{
		if (class2135_0 != null)
		{
			throw new Exception("Only one <thickness> element can be added.");
		}
		class2135_0 = new Class2135();
		return class2135_0;
	}

	private void method_4(Class2135 _thickness)
	{
		class2135_0 = _thickness;
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

	private Class1449 method_7()
	{
		if (class1453_0 != null)
		{
			throw new Exception("Only one <pictureOptions> element can be added.");
		}
		class1453_0 = new Class1453();
		return class1453_0;
	}

	private void method_8(Class1449 _pictureOptions)
	{
		class1453_0 = (Class1453)_pictureOptions;
	}

	private Class1885 method_9()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_10(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}
}
