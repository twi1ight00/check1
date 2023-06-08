using System;
using System.Xml;

namespace ns56;

internal class Class2137 : Class1351
{
	public delegate Class2137 Delegate2142();

	public delegate void Delegate2144(Class2137 elementData);

	public delegate void Delegate2143(Class2137 elementData);

	public Class2076.Delegate1943 delegate1943_0;

	public Class2076.Delegate1945 delegate1945_0;

	public Class2136.Delegate2139 delegate2139_0;

	public Class2136.Delegate2141 delegate2141_0;

	public Class2136.Delegate2139 delegate2139_1;

	public Class2136.Delegate2141 delegate2141_1;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class2076 class2076_0;

	private Class2136 class2136_0;

	private Class2136 class2136_1;

	private Class1887 class1887_0;

	public Class2076 GapWidth => class2076_0;

	public Class2136 UpBars => class2136_0;

	public Class2136 DownBars => class2136_1;

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
				case "downBars":
					class2136_1 = new Class2136(reader);
					break;
				case "upBars":
					class2136_0 = new Class2136(reader);
					break;
				case "gapWidth":
					class2076_0 = new Class2076(reader);
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

	public Class2137(XmlReader reader)
		: base(reader)
	{
	}

	public Class2137()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1943_0 = method_3;
		delegate1945_0 = method_4;
		delegate2139_0 = method_5;
		delegate2141_0 = method_6;
		delegate2139_1 = method_7;
		delegate2141_1 = method_8;
		delegate1534_0 = method_9;
		delegate1535_0 = method_10;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2076_0 != null)
		{
			class2076_0.vmethod_4("c", writer, "gapWidth");
		}
		if (class2136_0 != null)
		{
			class2136_0.vmethod_4("c", writer, "upBars");
		}
		if (class2136_1 != null)
		{
			class2136_1.vmethod_4("c", writer, "downBars");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2076 method_3()
	{
		if (class2076_0 != null)
		{
			throw new Exception("Only one <gapWidth> element can be added.");
		}
		class2076_0 = new Class2076();
		return class2076_0;
	}

	private void method_4(Class2076 _gapWidth)
	{
		class2076_0 = _gapWidth;
	}

	private Class2136 method_5()
	{
		if (class2136_0 != null)
		{
			throw new Exception("Only one <upBars> element can be added.");
		}
		class2136_0 = new Class2136();
		return class2136_0;
	}

	private void method_6(Class2136 _upBars)
	{
		class2136_0 = _upBars;
	}

	private Class2136 method_7()
	{
		if (class2136_1 != null)
		{
			throw new Exception("Only one <downBars> element can be added.");
		}
		class2136_1 = new Class2136();
		return class2136_1;
	}

	private void method_8(Class2136 _downBars)
	{
		class2136_1 = _downBars;
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
