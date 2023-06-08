using System;
using System.Xml;
using ns57;

namespace ns56;

internal class Class2266 : Class1351
{
	public delegate Class2266 Delegate2545();

	public delegate void Delegate2546(Class2266 elementData);

	public delegate void Delegate2547(Class2266 elementData);

	public const Enum279 enum279_0 = Enum279.const_0;

	public const Enum280 enum280_0 = Enum280.const_0;

	public Class2279.Delegate2584 delegate2584_0;

	public Class2279.Delegate2586 delegate2586_0;

	public Class1814.Delegate1321 delegate1321_0;

	public Class1814.Delegate1323 delegate1323_0;

	public Class1814.Delegate1321 delegate1321_1;

	public Class1814.Delegate1323 delegate1323_1;

	private Enum279 enum279_1;

	private Enum280 enum280_1;

	private Class2281 class2281_0;

	private Class2279 class2279_0;

	private Class1814 class1814_0;

	private Class1814 class1814_1;

	public Enum279 ClrSpc
	{
		get
		{
			return enum279_1;
		}
		set
		{
			enum279_1 = value;
		}
	}

	public Enum280 Dir
	{
		get
		{
			return enum280_1;
		}
		set
		{
			enum280_1 = value;
		}
	}

	public Class2281 CBhvr => class2281_0;

	public Class2279 By => class2279_0;

	public Class1814 From => class1814_0;

	public Class1814 To => class1814_1;

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
				case "to":
					class1814_1 = new Class1814(reader);
					break;
				case "from":
					class1814_0 = new Class1814(reader);
					break;
				case "by":
					class2279_0 = new Class2279(reader);
					break;
				case "cBhvr":
					class2281_0 = new Class2281(reader);
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
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "dir":
					enum280_1 = Class2581.smethod_0(reader.Value);
					break;
				case "clrSpc":
					enum279_1 = Class2582.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2266(XmlReader reader)
		: base(reader)
	{
	}

	public Class2266()
	{
	}

	protected override void vmethod_1()
	{
		enum279_1 = Enum279.const_0;
		enum280_1 = Enum280.const_0;
	}

	protected override void vmethod_2()
	{
		delegate2584_0 = method_3;
		delegate2586_0 = method_4;
		delegate1321_0 = method_5;
		delegate1323_0 = method_6;
		delegate1321_1 = method_7;
		delegate1323_1 = method_8;
	}

	protected override void vmethod_3()
	{
		class2281_0 = new Class2281();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum279_1 != Enum279.const_0)
		{
			writer.WriteAttributeString("clrSpc", Class2582.smethod_1(enum279_1));
		}
		if (enum280_1 != Enum280.const_0)
		{
			writer.WriteAttributeString("dir", Class2581.smethod_1(enum280_1));
		}
		class2281_0.vmethod_4("p", writer, "cBhvr");
		if (class2279_0 != null)
		{
			class2279_0.vmethod_4("p", writer, "by");
		}
		if (class1814_0 != null)
		{
			class1814_0.vmethod_4("p", writer, "from");
		}
		if (class1814_1 != null)
		{
			class1814_1.vmethod_4("p", writer, "to");
		}
		writer.WriteEndElement();
	}

	private Class2279 method_3()
	{
		if (class2279_0 != null)
		{
			throw new Exception("Only one <by> element can be added.");
		}
		class2279_0 = new Class2279();
		return class2279_0;
	}

	private void method_4(Class2279 _by)
	{
		class2279_0 = _by;
	}

	private Class1814 method_5()
	{
		if (class1814_0 != null)
		{
			throw new Exception("Only one <from> element can be added.");
		}
		class1814_0 = new Class1814();
		return class1814_0;
	}

	private void method_6(Class1814 _from)
	{
		class1814_0 = _from;
	}

	private Class1814 method_7()
	{
		if (class1814_1 != null)
		{
			throw new Exception("Only one <to> element can be added.");
		}
		class1814_1 = new Class1814();
		return class1814_1;
	}

	private void method_8(Class1814 _to)
	{
		class1814_1 = _to;
	}
}
