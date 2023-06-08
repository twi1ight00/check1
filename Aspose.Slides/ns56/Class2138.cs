using System;
using System.Xml;

namespace ns56;

internal class Class2138 : Class1351
{
	public delegate Class2138 Delegate2146();

	public delegate void Delegate2148(Class2138 elementData);

	public delegate void Delegate2147(Class2138 elementData);

	public Class2109.Delegate2051 delegate2051_0;

	public Class2109.Delegate2053 delegate2053_0;

	public Class2079.Delegate1952 delegate1952_0;

	public Class2079.Delegate1954 delegate1954_0;

	public Class2110.Delegate2054 delegate2054_0;

	public Class2110.Delegate2056 delegate2056_0;

	public Class2063.Delegate1902 delegate1902_0;

	public Class2063.Delegate1904 delegate1904_0;

	public Class2339.Delegate2763 delegate2763_0;

	public Class2339.Delegate2764 delegate2764_0;

	public Class2105.Delegate2034 delegate2034_0;

	public Class2105.Delegate2036 delegate2036_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class2109 class2109_0;

	private Class2079 class2079_0;

	private Class2110 class2110_0;

	private Class2063 class2063_0;

	private Class2339 class2339_0;

	private Class2105 class2105_0;

	private Class1887 class1887_0;

	public Class2109 RotX => class2109_0;

	public Class2079 HPercent => class2079_0;

	public Class2110 RotY => class2110_0;

	public Class2063 DepthPercent => class2063_0;

	public Class2339 RAngAx => class2339_0;

	public Class2105 Perspective => class2105_0;

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
				case "rotX":
					class2109_0 = new Class2109(reader);
					break;
				case "hPercent":
					class2079_0 = new Class2079(reader);
					break;
				case "rotY":
					class2110_0 = new Class2110(reader);
					break;
				case "depthPercent":
					class2063_0 = new Class2063(reader);
					break;
				case "rAngAx":
					class2339_0 = new Class2339(reader);
					break;
				case "perspective":
					class2105_0 = new Class2105(reader);
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

	public Class2138(XmlReader reader)
		: base(reader)
	{
	}

	public Class2138()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2051_0 = method_3;
		delegate2053_0 = method_4;
		delegate1952_0 = method_5;
		delegate1954_0 = method_6;
		delegate2054_0 = method_7;
		delegate2056_0 = method_8;
		delegate1902_0 = method_9;
		delegate1904_0 = method_10;
		delegate2763_0 = method_11;
		delegate2764_0 = method_12;
		delegate2034_0 = method_13;
		delegate2036_0 = method_14;
		delegate1534_0 = method_15;
		delegate1535_0 = method_16;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2109_0 != null)
		{
			class2109_0.vmethod_4("c", writer, "rotX");
		}
		if (class2079_0 != null)
		{
			class2079_0.vmethod_4("c", writer, "hPercent");
		}
		if (class2110_0 != null)
		{
			class2110_0.vmethod_4("c", writer, "rotY");
		}
		if (class2063_0 != null)
		{
			class2063_0.vmethod_4("c", writer, "depthPercent");
		}
		if (class2339_0 != null)
		{
			class2339_0.vmethod_4("c", writer, "rAngAx");
		}
		if (class2105_0 != null)
		{
			class2105_0.vmethod_4("c", writer, "perspective");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2109 method_3()
	{
		if (class2109_0 != null)
		{
			throw new Exception("Only one <rotX> element can be added.");
		}
		class2109_0 = new Class2109();
		return class2109_0;
	}

	private void method_4(Class2109 _rotX)
	{
		class2109_0 = _rotX;
	}

	private Class2079 method_5()
	{
		if (class2079_0 != null)
		{
			throw new Exception("Only one <hPercent> element can be added.");
		}
		class2079_0 = new Class2079();
		return class2079_0;
	}

	private void method_6(Class2079 _hPercent)
	{
		class2079_0 = _hPercent;
	}

	private Class2110 method_7()
	{
		if (class2110_0 != null)
		{
			throw new Exception("Only one <rotY> element can be added.");
		}
		class2110_0 = new Class2110();
		return class2110_0;
	}

	private void method_8(Class2110 _rotY)
	{
		class2110_0 = _rotY;
	}

	private Class2063 method_9()
	{
		if (class2063_0 != null)
		{
			throw new Exception("Only one <depthPercent> element can be added.");
		}
		class2063_0 = new Class2063();
		return class2063_0;
	}

	private void method_10(Class2063 _depthPercent)
	{
		class2063_0 = _depthPercent;
	}

	private Class2339 method_11()
	{
		if (class2339_0 != null)
		{
			throw new Exception("Only one <rAngAx> element can be added.");
		}
		class2339_0 = new Class2339();
		return class2339_0;
	}

	private void method_12(Class2339 _rAngAx)
	{
		class2339_0 = _rAngAx;
	}

	private Class2105 method_13()
	{
		if (class2105_0 != null)
		{
			throw new Exception("Only one <perspective> element can be added.");
		}
		class2105_0 = new Class2105();
		return class2105_0;
	}

	private void method_14(Class2105 _perspective)
	{
		class2105_0 = _perspective;
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
