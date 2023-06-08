using System;
using System.Xml;

namespace ns56;

internal class Class2071 : Class1351
{
	public delegate Class2071 Delegate1927();

	public delegate void Delegate1928(Class2071 elementData);

	public delegate void Delegate1929(Class2071 elementData);

	public Class2339.Delegate2763 delegate2763_0;

	public Class2339.Delegate2764 delegate2764_0;

	public Class2091.Delegate1991 delegate1991_0;

	public Class2091.Delegate1993 delegate1993_0;

	public Class2339.Delegate2763 delegate2763_1;

	public Class2339.Delegate2764 delegate2764_1;

	public Class2135.Delegate2136 delegate2136_0;

	public Class2135.Delegate2138 delegate2138_0;

	public Class1921.Delegate1630 delegate1630_0;

	public Class1921.Delegate1632 delegate1632_0;

	public Class1449.Delegate383 delegate383_0;

	public Class1449.Delegate384 delegate384_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class2135 class2135_0;

	private Class2339 class2339_0;

	private Class2091 class2091_0;

	private Class2339 class2339_1;

	private Class2135 class2135_1;

	private Class1921 class1921_0;

	private Class1453 class1453_0;

	private Class1887 class1887_0;

	public Class2135 Idx => class2135_0;

	public Class2339 InvertIfNegative => class2339_0;

	public Class2091 Marker => class2091_0;

	public Class2339 Bubble3D => class2339_1;

	public Class2135 Explosion => class2135_1;

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
				case "idx":
					class2135_0 = new Class2135(reader);
					break;
				case "invertIfNegative":
					class2339_0 = new Class2339(reader);
					break;
				case "marker":
					class2091_0 = new Class2091(reader);
					break;
				case "bubble3D":
					class2339_1 = new Class2339(reader);
					break;
				case "explosion":
					class2135_1 = new Class2135(reader);
					break;
				case "spPr":
					class1921_0 = new Class1921(reader);
					break;
				case "pictureOptions":
					class1453_0 = new Class1453(reader);
					flag = true;
					break;
				case "extLst":
					class1887_0 = new Class1887(reader);
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

	public Class2071(XmlReader reader)
		: base(reader)
	{
	}

	public Class2071()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2763_0 = method_3;
		delegate2764_0 = method_4;
		delegate1991_0 = method_5;
		delegate1993_0 = method_6;
		delegate2763_1 = method_7;
		delegate2764_1 = method_8;
		delegate2136_0 = method_9;
		delegate2138_0 = method_10;
		delegate1630_0 = method_11;
		delegate1632_0 = method_12;
		delegate383_0 = method_13;
		delegate384_0 = method_14;
		delegate1534_0 = method_15;
		delegate1535_0 = method_16;
	}

	protected override void vmethod_3()
	{
		class2135_0 = new Class2135();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class2135_0.vmethod_4("c", writer, "idx");
		if (class2339_0 != null)
		{
			class2339_0.vmethod_4("c", writer, "invertIfNegative");
		}
		if (class2091_0 != null)
		{
			class2091_0.vmethod_4("c", writer, "marker");
		}
		if (class2339_1 != null)
		{
			class2339_1.vmethod_4("c", writer, "bubble3D");
		}
		if (class2135_1 != null)
		{
			class2135_1.vmethod_4("c", writer, "explosion");
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

	private Class2339 method_3()
	{
		if (class2339_0 != null)
		{
			throw new Exception("Only one <invertIfNegative> element can be added.");
		}
		class2339_0 = new Class2339();
		return class2339_0;
	}

	private void method_4(Class2339 _invertIfNegative)
	{
		class2339_0 = _invertIfNegative;
	}

	private Class2091 method_5()
	{
		if (class2091_0 != null)
		{
			throw new Exception("Only one <marker> element can be added.");
		}
		class2091_0 = new Class2091();
		return class2091_0;
	}

	private void method_6(Class2091 _marker)
	{
		class2091_0 = _marker;
	}

	private Class2339 method_7()
	{
		if (class2339_1 != null)
		{
			throw new Exception("Only one <bubble3D> element can be added.");
		}
		class2339_1 = new Class2339();
		return class2339_1;
	}

	private void method_8(Class2339 _bubble3D)
	{
		class2339_1 = _bubble3D;
	}

	private Class2135 method_9()
	{
		if (class2135_1 != null)
		{
			throw new Exception("Only one <explosion> element can be added.");
		}
		class2135_1 = new Class2135();
		return class2135_1;
	}

	private void method_10(Class2135 _explosion)
	{
		class2135_1 = _explosion;
	}

	private Class1921 method_11()
	{
		if (class1921_0 != null)
		{
			throw new Exception("Only one <spPr> element can be added.");
		}
		class1921_0 = new Class1921();
		return class1921_0;
	}

	private void method_12(Class1921 _spPr)
	{
		class1921_0 = _spPr;
	}

	private Class1449 method_13()
	{
		if (class1453_0 != null)
		{
			throw new Exception("Only one <pictureOptions> element can be added.");
		}
		class1453_0 = new Class1453();
		return class1453_0;
	}

	private void method_14(Class1449 _pictureOptions)
	{
		class1453_0 = (Class1453)_pictureOptions;
	}

	private Class1885 method_15()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_16(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}
}
