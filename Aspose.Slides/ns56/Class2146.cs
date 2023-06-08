using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2146 : Class1351
{
	public delegate Class2146 Delegate2170();

	public delegate void Delegate2171(Class2146 elementData);

	public delegate void Delegate2172(Class2146 elementData);

	public const uint uint_0 = 0u;

	public Class2177.Delegate2263 delegate2263_0;

	public Class2177.Delegate2264 delegate2264_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Enum306 enum306_0;

	private uint uint_1;

	private List<Class2177> list_0;

	private Class1886 class1886_0;

	public Enum306 Type
	{
		get
		{
			return enum306_0;
		}
		set
		{
			enum306_0 = value;
		}
	}

	public uint Rev
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public Class2177[] ParamList => list_0.ToArray();

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
				case "param":
				{
					Class2177 item = new Class2177(reader);
					list_0.Add(item);
					break;
				}
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
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "rev":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "type":
					enum306_0 = Class2453.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2146(XmlReader reader)
		: base(reader)
	{
	}

	public Class2146()
	{
	}

	protected override void vmethod_1()
	{
		enum306_0 = Enum306.const_0;
		uint_1 = 0u;
		list_0 = new List<Class2177>();
	}

	protected override void vmethod_2()
	{
		delegate2263_0 = method_3;
		delegate2264_0 = method_4;
		delegate1534_0 = method_5;
		delegate1535_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("type", Class2453.smethod_1(enum306_0));
		if (uint_1 != 0)
		{
			writer.WriteAttributeString("rev", XmlConvert.ToString(uint_1));
		}
		foreach (Class2177 item in list_0)
		{
			item.vmethod_4("dgm", writer, "param");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("dgm", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2177 method_3()
	{
		Class2177 @class = new Class2177();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2177 elementData)
	{
		list_0.Add(elementData);
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
