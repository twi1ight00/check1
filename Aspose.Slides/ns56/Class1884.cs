using System;
using System.Xml;

namespace ns56;

internal class Class1884 : Class1351
{
	public delegate Class1884 Delegate1531();

	public delegate void Delegate1532(Class1884 elementData);

	public delegate void Delegate1533(Class1884 elementData);

	public const bool bool_0 = true;

	public Class1902.Delegate1573 delegate1573_0;

	public Class1902.Delegate1575 delegate1575_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private bool bool_1;

	private Class1902 class1902_0;

	private Class1886 class1886_0;

	public bool PreferRelativeResize
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Class1902 PicLocks => class1902_0;

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
				case "picLocks":
					class1902_0 = new Class1902(reader);
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
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "preferRelativeResize")
			{
				bool_1 = XmlConvert.ToBoolean(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1884(XmlReader reader)
		: base(reader)
	{
	}

	public Class1884()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = true;
	}

	protected override void vmethod_2()
	{
		delegate1573_0 = method_3;
		delegate1575_0 = method_4;
		delegate1534_0 = method_5;
		delegate1535_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (!bool_1)
		{
			writer.WriteAttributeString("preferRelativeResize", bool_1 ? "1" : "0");
		}
		if (class1902_0 != null)
		{
			class1902_0.vmethod_4("a", writer, "picLocks");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1902 method_3()
	{
		if (class1902_0 != null)
		{
			throw new Exception("Only one <picLocks> element can be added.");
		}
		class1902_0 = new Class1902();
		return class1902_0;
	}

	private void method_4(Class1902 _picLocks)
	{
		class1902_0 = _picLocks;
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
