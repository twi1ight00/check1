using System;
using System.Xml;

namespace ns56;

internal class Class1881 : Class1351
{
	public delegate Class1881 Delegate1522();

	public delegate void Delegate1523(Class1881 elementData);

	public delegate void Delegate1524(Class1881 elementData);

	public const bool bool_0 = false;

	public Class1920.Delegate1627 delegate1627_0;

	public Class1920.Delegate1629 delegate1629_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private bool bool_1;

	private Class1920 class1920_0;

	private Class1886 class1886_0;

	public bool TxBox
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

	public Class1920 SpLocks => class1920_0;

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
				case "spLocks":
					class1920_0 = new Class1920(reader);
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "txBox")
			{
				bool_1 = XmlConvert.ToBoolean(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1881(XmlReader reader)
		: base(reader)
	{
	}

	public Class1881()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
	}

	protected override void vmethod_2()
	{
		delegate1627_0 = method_3;
		delegate1629_0 = method_4;
		delegate1534_0 = method_5;
		delegate1535_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (bool_1)
		{
			writer.WriteAttributeString("txBox", bool_1 ? "1" : "0");
		}
		if (class1920_0 != null)
		{
			class1920_0.vmethod_4("a", writer, "spLocks");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1920 method_3()
	{
		if (class1920_0 != null)
		{
			throw new Exception("Only one <spLocks> element can be added.");
		}
		class1920_0 = new Class1920();
		return class1920_0;
	}

	private void method_4(Class1920 _spLocks)
	{
		class1920_0 = _spLocks;
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
