using System;
using System.Xml;
using Aspose.Slides;
using ns57;

namespace ns56;

internal class Class2305 : Class1351
{
	public delegate Class2305 Delegate2662();

	public delegate void Delegate2663(Class2305 elementData);

	public delegate void Delegate2664(Class2305 elementData);

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const Enum297 enum297_0 = Enum297.const_0;

	public const Enum294 enum294_0 = Enum294.const_0;

	public Class2302.Delegate2653 delegate2653_0;

	public Class2302.Delegate2655 delegate2655_0;

	public Class2302.Delegate2653 delegate2653_1;

	public Class2302.Delegate2655 delegate2655_1;

	private NullableBool nullableBool_1;

	private Enum297 enum297_1;

	private Enum294 enum294_1;

	private Class2283 class2283_0;

	private Class2302 class2302_0;

	private Class2302 class2302_1;

	public NullableBool Concurrent
	{
		get
		{
			return nullableBool_1;
		}
		set
		{
			nullableBool_1 = value;
		}
	}

	public Enum297 PrevAc
	{
		get
		{
			return enum297_1;
		}
		set
		{
			enum297_1 = value;
		}
	}

	public Enum294 NextAc
	{
		get
		{
			return enum294_1;
		}
		set
		{
			enum294_1 = value;
		}
	}

	public Class2283 CTn => class2283_0;

	public Class2302 PrevCondLst => class2302_0;

	public Class2302 NextCondLst => class2302_1;

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
				case "nextCondLst":
					class2302_1 = new Class2302(reader);
					break;
				case "prevCondLst":
					class2302_0 = new Class2302(reader);
					break;
				case "cTn":
					class2283_0 = new Class2283(reader);
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
				case "nextAc":
					enum294_1 = Class2592.smethod_0(reader.Value);
					break;
				case "prevAc":
					enum297_1 = Class2593.smethod_0(reader.Value);
					break;
				case "concurrent":
					nullableBool_1 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2305(XmlReader reader)
		: base(reader)
	{
	}

	public Class2305()
	{
	}

	protected override void vmethod_1()
	{
		nullableBool_1 = NullableBool.NotDefined;
		enum297_1 = Enum297.const_0;
		enum294_1 = Enum294.const_0;
	}

	protected override void vmethod_2()
	{
		delegate2653_0 = method_3;
		delegate2655_0 = method_4;
		delegate2653_1 = method_5;
		delegate2655_1 = method_6;
	}

	protected override void vmethod_3()
	{
		class2283_0 = new Class2283();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (nullableBool_1 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("concurrent", (nullableBool_1 == NullableBool.True) ? "1" : "0");
		}
		if (enum297_1 != Enum297.const_0)
		{
			writer.WriteAttributeString("prevAc", Class2593.smethod_1(enum297_1));
		}
		if (enum294_1 != Enum294.const_0)
		{
			writer.WriteAttributeString("nextAc", Class2592.smethod_1(enum294_1));
		}
		class2283_0.vmethod_4("p", writer, "cTn");
		if (class2302_0 != null)
		{
			class2302_0.vmethod_4("p", writer, "prevCondLst");
		}
		if (class2302_1 != null)
		{
			class2302_1.vmethod_4("p", writer, "nextCondLst");
		}
		writer.WriteEndElement();
	}

	private Class2302 method_3()
	{
		if (class2302_0 != null)
		{
			throw new Exception("Only one <prevCondLst> element can be added.");
		}
		class2302_0 = new Class2302();
		return class2302_0;
	}

	private void method_4(Class2302 _prevCondLst)
	{
		class2302_0 = _prevCondLst;
	}

	private Class2302 method_5()
	{
		if (class2302_1 != null)
		{
			throw new Exception("Only one <nextCondLst> element can be added.");
		}
		class2302_1 = new Class2302();
		return class2302_1;
	}

	private void method_6(Class2302 _nextCondLst)
	{
		class2302_1 = _nextCondLst;
	}
}
