using System;
using System.Xml;

namespace ns56;

internal class Class1726 : Class1351
{
	public delegate Class1726 Delegate1057();

	public delegate void Delegate1059(Class1726 elementData);

	public delegate void Delegate1058(Class1726 elementData);

	public Class1618.Delegate733 delegate733_0;

	public Class1618.Delegate735 delegate735_0;

	public Class1683.Delegate928 delegate928_0;

	public Class1683.Delegate930 delegate930_0;

	public Class1642.Delegate805 delegate805_0;

	public Class1642.Delegate807 delegate807_0;

	public Class1681.Delegate922 delegate922_0;

	public Class1681.Delegate924 delegate924_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private Class1618 class1618_0;

	private Class1683 class1683_0;

	private Class1642 class1642_0;

	private Class1681 class1681_0;

	private Class1502 class1502_0;

	public Class1618 Entries => class1618_0;

	public Class1683 Sets => class1683_0;

	public Class1642 QueryCache => class1642_0;

	public Class1681 ServerFormats => class1681_0;

	public Class1502 ExtLst => class1502_0;

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
					class1502_0 = new Class1502(reader);
					break;
				case "serverFormats":
					class1681_0 = new Class1681(reader);
					break;
				case "queryCache":
					class1642_0 = new Class1642(reader);
					break;
				case "sets":
					class1683_0 = new Class1683(reader);
					break;
				case "entries":
					class1618_0 = new Class1618(reader);
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

	public Class1726(XmlReader reader)
		: base(reader)
	{
	}

	public Class1726()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate733_0 = method_3;
		delegate735_0 = method_4;
		delegate928_0 = method_5;
		delegate930_0 = method_6;
		delegate805_0 = method_7;
		delegate807_0 = method_8;
		delegate922_0 = method_9;
		delegate924_0 = method_10;
		delegate385_0 = method_11;
		delegate387_0 = method_12;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1618_0 != null)
		{
			class1618_0.vmethod_4("ssml", writer, "entries");
		}
		if (class1683_0 != null)
		{
			class1683_0.vmethod_4("ssml", writer, "sets");
		}
		if (class1642_0 != null)
		{
			class1642_0.vmethod_4("ssml", writer, "queryCache");
		}
		if (class1681_0 != null)
		{
			class1681_0.vmethod_4("ssml", writer, "serverFormats");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1618 method_3()
	{
		if (class1618_0 != null)
		{
			throw new Exception("Only one <entries> element can be added.");
		}
		class1618_0 = new Class1618();
		return class1618_0;
	}

	private void method_4(Class1618 _entries)
	{
		class1618_0 = _entries;
	}

	private Class1683 method_5()
	{
		if (class1683_0 != null)
		{
			throw new Exception("Only one <sets> element can be added.");
		}
		class1683_0 = new Class1683();
		return class1683_0;
	}

	private void method_6(Class1683 _sets)
	{
		class1683_0 = _sets;
	}

	private Class1642 method_7()
	{
		if (class1642_0 != null)
		{
			throw new Exception("Only one <queryCache> element can be added.");
		}
		class1642_0 = new Class1642();
		return class1642_0;
	}

	private void method_8(Class1642 _queryCache)
	{
		class1642_0 = _queryCache;
	}

	private Class1681 method_9()
	{
		if (class1681_0 != null)
		{
			throw new Exception("Only one <serverFormats> element can be added.");
		}
		class1681_0 = new Class1681();
		return class1681_0;
	}

	private void method_10(Class1681 _serverFormats)
	{
		class1681_0 = _serverFormats;
	}

	private Class1502 method_11()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_12(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
