using System;
using System.Xml;

namespace ns56;

internal class Class2257 : Class1351
{
	public delegate Class2257 Delegate2518();

	public delegate void Delegate2519(Class2257 elementData);

	public delegate void Delegate2520(Class2257 elementData);

	public Class1958.Delegate1741 delegate1741_0;

	public Class1958.Delegate1743 delegate1743_0;

	public Class1958.Delegate1741 delegate1741_1;

	public Class1958.Delegate1743 delegate1743_1;

	public Class1958.Delegate1741 delegate1741_2;

	public Class1958.Delegate1743 delegate1743_2;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class1958 class1958_0;

	private Class1958 class1958_1;

	private Class1958 class1958_2;

	private Class1888 class1888_0;

	public Class1958 TitleStyle => class1958_0;

	public Class1958 BodyStyle => class1958_1;

	public Class1958 OtherStyle => class1958_2;

	public Class1885 ExtLst => class1888_0;

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
					class1888_0 = new Class1888(reader);
					break;
				case "otherStyle":
					class1958_2 = new Class1958(reader);
					break;
				case "bodyStyle":
					class1958_1 = new Class1958(reader);
					break;
				case "titleStyle":
					class1958_0 = new Class1958(reader);
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

	public Class2257(XmlReader reader)
		: base(reader)
	{
	}

	public Class2257()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1741_0 = method_3;
		delegate1743_0 = method_4;
		delegate1741_1 = method_5;
		delegate1743_1 = method_6;
		delegate1741_2 = method_7;
		delegate1743_2 = method_8;
		delegate1534_0 = method_9;
		delegate1535_0 = method_10;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1958_0 != null)
		{
			class1958_0.vmethod_4("p", writer, "titleStyle");
		}
		if (class1958_1 != null)
		{
			class1958_1.vmethod_4("p", writer, "bodyStyle");
		}
		if (class1958_2 != null)
		{
			class1958_2.vmethod_4("p", writer, "otherStyle");
		}
		if (class1888_0 != null)
		{
			class1888_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1958 method_3()
	{
		if (class1958_0 != null)
		{
			throw new Exception("Only one <titleStyle> element can be added.");
		}
		class1958_0 = new Class1958();
		return class1958_0;
	}

	private void method_4(Class1958 _titleStyle)
	{
		class1958_0 = _titleStyle;
	}

	private Class1958 method_5()
	{
		if (class1958_1 != null)
		{
			throw new Exception("Only one <bodyStyle> element can be added.");
		}
		class1958_1 = new Class1958();
		return class1958_1;
	}

	private void method_6(Class1958 _bodyStyle)
	{
		class1958_1 = _bodyStyle;
	}

	private Class1958 method_7()
	{
		if (class1958_2 != null)
		{
			throw new Exception("Only one <otherStyle> element can be added.");
		}
		class1958_2 = new Class1958();
		return class1958_2;
	}

	private void method_8(Class1958 _otherStyle)
	{
		class1958_2 = _otherStyle;
	}

	private Class1885 method_9()
	{
		if (class1888_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1888_0 = new Class1888();
		return class1888_0;
	}

	private void method_10(Class1885 _extLst)
	{
		class1888_0 = (Class1888)_extLst;
	}
}
