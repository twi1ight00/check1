using System;
using System.Xml;
using ns57;

namespace ns56;

internal class Class2267 : Class1351
{
	public delegate Class2267 Delegate2548();

	public delegate void Delegate2549(Class2267 elementData);

	public delegate void Delegate2550(Class2267 elementData);

	public const Enum281 enum281_0 = Enum281.const_0;

	public Class2272.Delegate2563 delegate2563_0;

	public Class2272.Delegate2565 delegate2565_0;

	private Enum281 enum281_1;

	private string string_0;

	private string string_1;

	private Class2281 class2281_0;

	private Class2272 class2272_0;

	public Enum281 Transition
	{
		get
		{
			return enum281_1;
		}
		set
		{
			enum281_1 = value;
		}
	}

	public string Filter
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

	public string PrLst
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public Class2281 CBhvr => class2281_0;

	public Class2272 Progress => class2272_0;

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
				case "progress":
					class2272_0 = new Class2272(reader);
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
				case "prLst":
					string_1 = reader.Value;
					break;
				case "filter":
					string_0 = reader.Value;
					break;
				case "transition":
					enum281_1 = Class2583.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2267(XmlReader reader)
		: base(reader)
	{
	}

	public Class2267()
	{
	}

	protected override void vmethod_1()
	{
		enum281_1 = Enum281.const_0;
	}

	protected override void vmethod_2()
	{
		delegate2563_0 = method_3;
		delegate2565_0 = method_4;
	}

	protected override void vmethod_3()
	{
		class2281_0 = new Class2281();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum281_1 != Enum281.const_0)
		{
			writer.WriteAttributeString("transition", Class2583.smethod_1(enum281_1));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("filter", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("prLst", string_1);
		}
		class2281_0.vmethod_4("p", writer, "cBhvr");
		if (class2272_0 != null)
		{
			class2272_0.vmethod_4("p", writer, "progress");
		}
		writer.WriteEndElement();
	}

	private Class2272 method_3()
	{
		if (class2272_0 != null)
		{
			throw new Exception("Only one <progress> element can be added.");
		}
		class2272_0 = new Class2272();
		return class2272_0;
	}

	private void method_4(Class2272 _progress)
	{
		class2272_0 = _progress;
	}
}
