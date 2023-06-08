using System;
using System.Xml;

namespace ns56;

internal class Class2111 : Class1351
{
	public delegate Class2111 Delegate2057();

	public delegate void Delegate2058(Class2111 elementData);

	public delegate void Delegate2059(Class2111 elementData);

	public Class2088.Delegate1982 delegate1982_0;

	public Class2088.Delegate1984 delegate1984_0;

	public Class2102.Delegate2025 delegate2025_0;

	public Class2102.Delegate2027 delegate2027_0;

	public Class2070.Delegate1923 delegate1923_0;

	public Class2070.Delegate1925 delegate1925_0;

	public Class2070.Delegate1923 delegate1923_1;

	public Class2070.Delegate1925 delegate1925_1;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class2088 class2088_0;

	private Class2102 class2102_0;

	private Class2070 class2070_0;

	private Class2070 class2070_1;

	private Class1887 class1887_0;

	public Class2088 LogBase => class2088_0;

	public Class2102 Orientation => class2102_0;

	public Class2070 Max => class2070_0;

	public Class2070 Min => class2070_1;

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
				case "min":
					class2070_1 = new Class2070(reader);
					break;
				case "max":
					class2070_0 = new Class2070(reader);
					break;
				case "orientation":
					class2102_0 = new Class2102(reader);
					break;
				case "logBase":
					class2088_0 = new Class2088(reader);
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

	public Class2111(XmlReader reader)
		: base(reader)
	{
	}

	public Class2111()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1982_0 = method_3;
		delegate1984_0 = method_4;
		delegate2025_0 = method_5;
		delegate2027_0 = method_6;
		delegate1923_0 = method_7;
		delegate1925_0 = method_8;
		delegate1923_1 = method_9;
		delegate1925_1 = method_10;
		delegate1534_0 = method_11;
		delegate1535_0 = method_12;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2088_0 != null)
		{
			class2088_0.vmethod_4("c", writer, "logBase");
		}
		if (class2102_0 != null)
		{
			class2102_0.vmethod_4("c", writer, "orientation");
		}
		if (class2070_0 != null)
		{
			class2070_0.vmethod_4("c", writer, "max");
		}
		if (class2070_1 != null)
		{
			class2070_1.vmethod_4("c", writer, "min");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2088 method_3()
	{
		if (class2088_0 != null)
		{
			throw new Exception("Only one <logBase> element can be added.");
		}
		class2088_0 = new Class2088();
		return class2088_0;
	}

	private void method_4(Class2088 _logBase)
	{
		class2088_0 = _logBase;
	}

	private Class2102 method_5()
	{
		if (class2102_0 != null)
		{
			throw new Exception("Only one <orientation> element can be added.");
		}
		class2102_0 = new Class2102();
		return class2102_0;
	}

	private void method_6(Class2102 _orientation)
	{
		class2102_0 = _orientation;
	}

	private Class2070 method_7()
	{
		if (class2070_0 != null)
		{
			throw new Exception("Only one <max> element can be added.");
		}
		class2070_0 = new Class2070();
		return class2070_0;
	}

	private void method_8(Class2070 _max)
	{
		class2070_0 = _max;
	}

	private Class2070 method_9()
	{
		if (class2070_1 != null)
		{
			throw new Exception("Only one <min> element can be added.");
		}
		class2070_1 = new Class2070();
		return class2070_1;
	}

	private void method_10(Class2070 _min)
	{
		class2070_1 = _min;
	}

	private Class1885 method_11()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_12(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}
}
