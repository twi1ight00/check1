using System;
using System.Xml;

namespace ns56;

internal class Class1802 : Class1351
{
	public delegate Class1802 Delegate1285();

	public delegate void Delegate1286(Class1802 elementData);

	public delegate void Delegate1287(Class1802 elementData);

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class1904 class1904_0;

	private Class1978 class1978_0;

	private Class1978 class1978_1;

	private Class1886 class1886_0;

	public Class1904 Anchor => class1904_0;

	public Class1978 Norm => class1978_0;

	public Class1978 Up => class1978_1;

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
				case "up":
					class1978_1 = new Class1978(reader);
					break;
				case "norm":
					class1978_0 = new Class1978(reader);
					break;
				case "anchor":
					class1904_0 = new Class1904(reader);
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

	public Class1802(XmlReader reader)
		: base(reader)
	{
	}

	public Class1802()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1534_0 = method_3;
		delegate1535_0 = method_4;
	}

	protected override void vmethod_3()
	{
		class1904_0 = new Class1904();
		class1978_0 = new Class1978();
		class1978_1 = new Class1978();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1904_0.vmethod_4("a", writer, "anchor");
		class1978_0.vmethod_4("a", writer, "norm");
		class1978_1.vmethod_4("a", writer, "up");
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1885 method_3()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_4(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
