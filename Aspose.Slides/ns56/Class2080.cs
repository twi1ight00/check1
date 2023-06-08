using System;
using System.Xml;

namespace ns56;

internal class Class2080 : Class1351
{
	public delegate Class2080 Delegate1955();

	public delegate void Delegate1957(Class2080 elementData);

	public delegate void Delegate1956(Class2080 elementData);

	public Class2090.Delegate1988 delegate1988_0;

	public Class2090.Delegate1990 delegate1990_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class2090 class2090_0;

	private Class1887 class1887_0;

	public Class2090 ManualLayout => class2090_0;

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
				case "manualLayout":
					class2090_0 = new Class2090(reader);
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

	public Class2080(XmlReader reader)
		: base(reader)
	{
	}

	public Class2080()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1988_0 = method_3;
		delegate1990_0 = method_4;
		delegate1534_0 = method_5;
		delegate1535_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2090_0 != null)
		{
			class2090_0.vmethod_4("c", writer, "manualLayout");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2090 method_3()
	{
		if (class2090_0 != null)
		{
			throw new Exception("Only one <manualLayout> element can be added.");
		}
		class2090_0 = new Class2090();
		return class2090_0;
	}

	private void method_4(Class2090 _manualLayout)
	{
		class2090_0 = _manualLayout;
	}

	private Class1885 method_5()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_6(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}
}
