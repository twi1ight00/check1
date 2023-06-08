using System;
using System.Xml;

namespace ns56;

internal class Class2323 : Class1351
{
	public delegate Class2323 Delegate2716();

	public delegate void Delegate2717(Class2323 elementData);

	public delegate void Delegate2718(Class2323 elementData);

	public const Enum362 enum362_0 = Enum362.const_0;

	public Class2204.Delegate2348 delegate2348_0;

	public Class2204.Delegate2350 delegate2350_0;

	public Class2208.Delegate2360 delegate2360_0;

	public Class2208.Delegate2362 delegate2362_0;

	public Class2210.Delegate2366 delegate2366_0;

	public Class2210.Delegate2368 delegate2368_0;

	private Enum362 enum362_1;

	private Class2204 class2204_0;

	private Class2208 class2208_0;

	private Class2210 class2210_0;

	public Enum362 V_Ext
	{
		get
		{
			return enum362_1;
		}
		set
		{
			enum362_1 = value;
		}
	}

	public Class2204 Idmap => class2204_0;

	public Class2208 Regrouptable => class2208_0;

	public Class2210 Rules => class2210_0;

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
				case "rules":
					class2210_0 = new Class2210(reader);
					break;
				case "regrouptable":
					class2208_0 = new Class2208(reader);
					break;
				case "idmap":
					class2204_0 = new Class2204(reader);
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "v:ext")
			{
				enum362_1 = Class2498.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2323(XmlReader reader)
		: base(reader)
	{
	}

	public Class2323()
	{
	}

	protected override void vmethod_1()
	{
		enum362_1 = Enum362.const_0;
	}

	protected override void vmethod_2()
	{
		delegate2348_0 = method_3;
		delegate2350_0 = method_4;
		delegate2360_0 = method_5;
		delegate2362_0 = method_6;
		delegate2366_0 = method_7;
		delegate2368_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("o", elementName, "urn:schemas-microsoft-com:office:office");
		if (writer.LookupPrefix("urn:schemas-microsoft-com:vml") == null)
		{
			writer.WriteAttributeString("xmlns", "v", null, "urn:schemas-microsoft-com:vml");
		}
		if (enum362_1 != 0)
		{
			writer.WriteAttributeString("v:ext", Class2498.smethod_1(enum362_1));
		}
		if (class2204_0 != null)
		{
			class2204_0.vmethod_4("o", writer, "idmap");
		}
		if (class2208_0 != null)
		{
			class2208_0.vmethod_4("o", writer, "regrouptable");
		}
		if (class2210_0 != null)
		{
			class2210_0.vmethod_4("o", writer, "rules");
		}
		writer.WriteEndElement();
	}

	private Class2204 method_3()
	{
		if (class2204_0 != null)
		{
			throw new Exception("Only one <idmap> element can be added.");
		}
		class2204_0 = new Class2204();
		return class2204_0;
	}

	private void method_4(Class2204 _idmap)
	{
		class2204_0 = _idmap;
	}

	private Class2208 method_5()
	{
		if (class2208_0 != null)
		{
			throw new Exception("Only one <regrouptable> element can be added.");
		}
		class2208_0 = new Class2208();
		return class2208_0;
	}

	private void method_6(Class2208 _regrouptable)
	{
		class2208_0 = _regrouptable;
	}

	private Class2210 method_7()
	{
		if (class2210_0 != null)
		{
			throw new Exception("Only one <rules> element can be added.");
		}
		class2210_0 = new Class2210();
		return class2210_0;
	}

	private void method_8(Class2210 _rules)
	{
		class2210_0 = _rules;
	}
}
