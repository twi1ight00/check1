using System;
using System.Xml;

namespace ns56;

internal class Class1883 : Class1351
{
	public delegate Class1883 Delegate1528();

	public delegate void Delegate1529(Class1883 elementData);

	public delegate void Delegate1530(Class1883 elementData);

	public Class1860.Delegate1459 delegate1459_0;

	public Class1860.Delegate1461 delegate1461_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class1860 class1860_0;

	private Class1886 class1886_0;

	public Class1860 GrpSpLocks => class1860_0;

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
				case "grpSpLocks":
					class1860_0 = new Class1860(reader);
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

	public Class1883(XmlReader reader)
		: base(reader)
	{
	}

	public Class1883()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1459_0 = method_3;
		delegate1461_0 = method_4;
		delegate1534_0 = method_5;
		delegate1535_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1860_0 != null)
		{
			class1860_0.vmethod_4("a", writer, "grpSpLocks");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1860 method_3()
	{
		if (class1860_0 != null)
		{
			throw new Exception("Only one <grpSpLocks> element can be added.");
		}
		class1860_0 = new Class1860();
		return class1860_0;
	}

	private void method_4(Class1860 _grpSpLocks)
	{
		class1860_0 = _grpSpLocks;
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
