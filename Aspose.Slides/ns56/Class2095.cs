using System;
using System.Xml;

namespace ns56;

internal class Class2095 : Class1351
{
	public delegate Class2095 Delegate2003();

	public delegate void Delegate2004(Class2095 elementData);

	public delegate void Delegate2005(Class2095 elementData);

	public Class2094.Delegate2000 delegate2000_0;

	public Class2094.Delegate2002 delegate2002_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private string string_0;

	private Class2094 class2094_0;

	private Class1887 class1887_0;

	public string F
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

	public Class2094 MultiLvlStrCache => class2094_0;

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
			case "multiLvlStrCache":
				class2094_0 = new Class2094(reader);
				break;
			case "f":
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

	public Class2095(XmlReader reader)
		: base(reader)
	{
	}

	public Class2095()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2000_0 = method_3;
		delegate2002_0 = method_4;
		delegate1534_0 = method_5;
		delegate1535_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		method_1("c", writer, "f", string_0);
		if (class2094_0 != null)
		{
			class2094_0.vmethod_4("c", writer, "multiLvlStrCache");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2094 method_3()
	{
		if (class2094_0 != null)
		{
			throw new Exception("Only one <multiLvlStrCache> element can be added.");
		}
		class2094_0 = new Class2094();
		return class2094_0;
	}

	private void method_4(Class2094 _multiLvlStrCache)
	{
		class2094_0 = _multiLvlStrCache;
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
