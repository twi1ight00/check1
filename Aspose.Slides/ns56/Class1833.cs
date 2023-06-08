using System;
using System.Xml;

namespace ns56;

internal class Class1833 : Class1351
{
	public delegate Class1833 Delegate1378();

	public delegate void Delegate1379(Class1833 elementData);

	public delegate void Delegate1380(Class1833 elementData);

	public Class1811.Delegate1312 delegate1312_0;

	public Class1811.Delegate1314 delegate1314_0;

	public Class1841.Delegate1402 delegate1402_0;

	public Class1841.Delegate1404 delegate1404_0;

	public Class1852.Delegate1435 delegate1435_0;

	public Class1852.Delegate1437 delegate1437_0;

	public Class1866.Delegate1477 delegate1477_0;

	public Class1866.Delegate1479 delegate1479_0;

	public Class1890.Delegate1537 delegate1537_0;

	public Class1890.Delegate1539 delegate1539_0;

	public Class1910.Delegate1597 delegate1597_0;

	public Class1910.Delegate1599 delegate1599_0;

	public Class1913.Delegate1606 delegate1606_0;

	public Class1913.Delegate1608 delegate1608_0;

	public Class1923.Delegate1636 delegate1636_0;

	public Class1923.Delegate1638 delegate1638_0;

	private Class1811 class1811_0;

	private Class1841 class1841_0;

	private Class1852 class1852_0;

	private Class1866 class1866_0;

	private Class1890 class1890_0;

	private Class1910 class1910_0;

	private Class1913 class1913_0;

	private Class1923 class1923_0;

	public Class1811 Blur => class1811_0;

	public Class1841 FillOverlay => class1841_0;

	public Class1852 Glow => class1852_0;

	public Class1866 InnerShdw => class1866_0;

	public Class1890 OuterShdw => class1890_0;

	public Class1910 PrstShdw => class1910_0;

	public Class1913 Reflection => class1913_0;

	public Class1923 SoftEdge => class1923_0;

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
				case "blur":
					class1811_0 = new Class1811(reader);
					break;
				case "fillOverlay":
					class1841_0 = new Class1841(reader);
					break;
				case "glow":
					class1852_0 = new Class1852(reader);
					break;
				case "innerShdw":
					class1866_0 = new Class1866(reader);
					break;
				case "outerShdw":
					class1890_0 = new Class1890(reader);
					break;
				case "prstShdw":
					class1910_0 = new Class1910(reader);
					break;
				case "reflection":
					class1913_0 = new Class1913(reader);
					break;
				case "softEdge":
					class1923_0 = new Class1923(reader);
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

	public Class1833(XmlReader reader)
		: base(reader)
	{
	}

	public Class1833()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1312_0 = method_3;
		delegate1314_0 = method_4;
		delegate1402_0 = method_5;
		delegate1404_0 = method_6;
		delegate1435_0 = method_7;
		delegate1437_0 = method_8;
		delegate1477_0 = method_9;
		delegate1479_0 = method_10;
		delegate1537_0 = method_11;
		delegate1539_0 = method_12;
		delegate1597_0 = method_13;
		delegate1599_0 = method_14;
		delegate1606_0 = method_15;
		delegate1608_0 = method_16;
		delegate1636_0 = method_17;
		delegate1638_0 = method_18;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1811_0 != null)
		{
			class1811_0.vmethod_4("a", writer, "blur");
		}
		if (class1841_0 != null)
		{
			class1841_0.vmethod_4("a", writer, "fillOverlay");
		}
		if (class1852_0 != null)
		{
			class1852_0.vmethod_4("a", writer, "glow");
		}
		if (class1866_0 != null)
		{
			class1866_0.vmethod_4("a", writer, "innerShdw");
		}
		if (class1890_0 != null)
		{
			class1890_0.vmethod_4("a", writer, "outerShdw");
		}
		if (class1910_0 != null)
		{
			class1910_0.vmethod_4("a", writer, "prstShdw");
		}
		if (class1913_0 != null)
		{
			class1913_0.vmethod_4("a", writer, "reflection");
		}
		if (class1923_0 != null)
		{
			class1923_0.vmethod_4("a", writer, "softEdge");
		}
		writer.WriteEndElement();
	}

	private Class1811 method_3()
	{
		if (class1811_0 != null)
		{
			throw new Exception("Only one <blur> element can be added.");
		}
		class1811_0 = new Class1811();
		return class1811_0;
	}

	private void method_4(Class1811 _blur)
	{
		class1811_0 = _blur;
	}

	private Class1841 method_5()
	{
		if (class1841_0 != null)
		{
			throw new Exception("Only one <fillOverlay> element can be added.");
		}
		class1841_0 = new Class1841();
		return class1841_0;
	}

	private void method_6(Class1841 _fillOverlay)
	{
		class1841_0 = _fillOverlay;
	}

	private Class1852 method_7()
	{
		if (class1852_0 != null)
		{
			throw new Exception("Only one <glow> element can be added.");
		}
		class1852_0 = new Class1852();
		return class1852_0;
	}

	private void method_8(Class1852 _glow)
	{
		class1852_0 = _glow;
	}

	private Class1866 method_9()
	{
		if (class1866_0 != null)
		{
			throw new Exception("Only one <innerShdw> element can be added.");
		}
		class1866_0 = new Class1866();
		return class1866_0;
	}

	private void method_10(Class1866 _innerShdw)
	{
		class1866_0 = _innerShdw;
	}

	private Class1890 method_11()
	{
		if (class1890_0 != null)
		{
			throw new Exception("Only one <outerShdw> element can be added.");
		}
		class1890_0 = new Class1890();
		return class1890_0;
	}

	private void method_12(Class1890 _outerShdw)
	{
		class1890_0 = _outerShdw;
	}

	private Class1910 method_13()
	{
		if (class1910_0 != null)
		{
			throw new Exception("Only one <prstShdw> element can be added.");
		}
		class1910_0 = new Class1910();
		return class1910_0;
	}

	private void method_14(Class1910 _prstShdw)
	{
		class1910_0 = _prstShdw;
	}

	private Class1913 method_15()
	{
		if (class1913_0 != null)
		{
			throw new Exception("Only one <reflection> element can be added.");
		}
		class1913_0 = new Class1913();
		return class1913_0;
	}

	private void method_16(Class1913 _reflection)
	{
		class1913_0 = _reflection;
	}

	private Class1923 method_17()
	{
		if (class1923_0 != null)
		{
			throw new Exception("Only one <softEdge> element can be added.");
		}
		class1923_0 = new Class1923();
		return class1923_0;
	}

	private void method_18(Class1923 _softEdge)
	{
		class1923_0 = _softEdge;
	}
}
