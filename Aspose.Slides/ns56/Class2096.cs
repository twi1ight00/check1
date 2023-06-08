using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2096 : Class1351
{
	public delegate Class2096 Delegate2006();

	public delegate void Delegate2007(Class2096 elementData);

	public delegate void Delegate2008(Class2096 elementData);

	public Class2135.Delegate2136 delegate2136_0;

	public Class2135.Delegate2138 delegate2138_0;

	public Class2099.Delegate2015 delegate2015_0;

	public Class2099.Delegate2016 delegate2016_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private string string_0;

	private Class2135 class2135_0;

	private List<Class2099> list_0;

	private Class1887 class1887_0;

	public string FormatCode
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class2135 PtCount => class2135_0;

	public Class2099[] PtList => list_0.ToArray();

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
			if (reader.NodeType != XmlNodeType.Element)
			{
				continue;
			}
			switch (reader.LocalName)
			{
			case "extLst":
				class1887_0 = new Class1887(reader);
				break;
			case "pt":
			{
				Class2099 item = new Class2099(reader);
				list_0.Add(item);
				break;
			}
			case "ptCount":
				class2135_0 = new Class2135(reader);
				break;
			case "formatCode":
				string_0 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_0 += reader.ReadString();
					}
				}
				break;
			default:
				reader.Skip();
				flag = true;
				break;
			}
		}
	}

	private void method_2(XmlReader reader)
	{
	}

	public Class2096(XmlReader reader)
		: base(reader)
	{
	}

	public Class2096()
	{
	}

	protected override void vmethod_1()
	{
		list_0 = new List<Class2099>();
	}

	protected override void vmethod_2()
	{
		delegate2136_0 = method_3;
		delegate2138_0 = method_4;
		delegate2015_0 = method_5;
		delegate2016_0 = method_6;
		delegate1534_0 = method_7;
		delegate1535_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_0 != null)
		{
			method_1("c", writer, "formatCode", string_0);
		}
		if (class2135_0 != null)
		{
			class2135_0.vmethod_4("c", writer, "ptCount");
		}
		foreach (Class2099 item in list_0)
		{
			item.vmethod_4("c", writer, "pt");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2135 method_3()
	{
		if (class2135_0 != null)
		{
			throw new Exception("Only one <ptCount> element can be added.");
		}
		class2135_0 = new Class2135();
		return class2135_0;
	}

	private void method_4(Class2135 _ptCount)
	{
		class2135_0 = _ptCount;
	}

	private Class2099 method_5()
	{
		Class2099 @class = new Class2099();
		list_0.Add(@class);
		return @class;
	}

	private void method_6(Class2099 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1885 method_7()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_8(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}
}
