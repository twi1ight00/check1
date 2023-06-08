using System;
using System.Xml;

namespace ns56;

internal class Class1991 : Class1989
{
	public delegate void Delegate2448(Class1991 elementData);

	private Class1994 class1994_0;

	private Class1976 class1976_0;

	private Class2346 class2346_0;

	private Class1889 class1889_0;

	public override Class1992 NvGraphicFramePr => class1994_0;

	public override Class1976 Xfrm => class1976_0;

	public override Class2346 Graphic => class2346_0;

	public override Class1885 ExtLst => class1889_0;

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
					class1889_0 = new Class1889(reader);
					break;
				case "graphic":
					class2346_0 = new Class2346(reader);
					break;
				case "xfrm":
					class1976_0 = new Class1976(reader);
					break;
				case "nvGraphicFramePr":
					class1994_0 = new Class1994(reader);
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

	public Class1991(XmlReader reader)
		: base(reader)
	{
	}

	public Class1991()
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
		class1994_0 = new Class1994();
		class1976_0 = new Class1976();
		class2346_0 = new Class2346();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1994_0.vmethod_4("p", writer, "nvGraphicFramePr");
		class1976_0.vmethod_4("p", writer, "xfrm");
		class2346_0.vmethod_4("a", writer, "graphic");
		if (class1889_0 != null)
		{
			class1889_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1885 method_3()
	{
		if (class1889_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1889_0 = new Class1889();
		return class1889_0;
	}

	private void method_4(Class1885 _extLst)
	{
		class1889_0 = (Class1889)_extLst;
	}
}
