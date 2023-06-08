using System;
using System.Xml;
using ns57;

namespace ns56;

internal class Class2281 : Class1351
{
	public delegate Class2281 Delegate2590();

	public delegate void Delegate2591(Class2281 elementData);

	public delegate void Delegate2592(Class2281 elementData);

	public const Enum285 enum285_0 = Enum285.const_0;

	public const Enum284 enum284_0 = Enum284.const_0;

	public const Enum287 enum287_0 = Enum287.const_0;

	public const Enum286 enum286_0 = Enum286.const_0;

	public Class2276.Delegate2575 delegate2575_0;

	public Class2276.Delegate2577 delegate2577_0;

	private Enum285 enum285_1;

	private Enum284 enum284_1;

	private Enum287 enum287_1;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private Enum286 enum286_1;

	private Class2283 class2283_0;

	private Class2306 class2306_0;

	private Class2276 class2276_0;

	public Enum285 Additive
	{
		get
		{
			return enum285_1;
		}
		set
		{
			enum285_1 = value;
		}
	}

	public Enum284 Accumulate
	{
		get
		{
			return enum284_1;
		}
		set
		{
			enum284_1 = value;
		}
	}

	public Enum287 XfrmType
	{
		get
		{
			return enum287_1;
		}
		set
		{
			enum287_1 = value;
		}
	}

	public string From
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

	public string To
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

	public string By
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public string Rctx
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public Enum286 Override
	{
		get
		{
			return enum286_1;
		}
		set
		{
			enum286_1 = value;
		}
	}

	public Class2283 CTn => class2283_0;

	public Class2306 TgtEl => class2306_0;

	public Class2276 AttrNameLst => class2276_0;

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
				case "attrNameLst":
					class2276_0 = new Class2276(reader);
					break;
				case "tgtEl":
					class2306_0 = new Class2306(reader);
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
				case "additive":
					enum285_1 = Class2587.smethod_0(reader.Value);
					break;
				case "accumulate":
					enum284_1 = Class2586.smethod_0(reader.Value);
					break;
				case "xfrmType":
					enum287_1 = Class2589.smethod_0(reader.Value);
					break;
				case "from":
					string_0 = reader.Value;
					break;
				case "to":
					string_1 = reader.Value;
					break;
				case "by":
					string_2 = reader.Value;
					break;
				case "rctx":
					string_3 = reader.Value;
					break;
				case "override":
					enum286_1 = Class2588.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2281(XmlReader reader)
		: base(reader)
	{
	}

	public Class2281()
	{
	}

	protected override void vmethod_1()
	{
		enum285_1 = Enum285.const_0;
		enum284_1 = Enum284.const_0;
		enum287_1 = Enum287.const_0;
		enum286_1 = Enum286.const_0;
	}

	protected override void vmethod_2()
	{
		delegate2575_0 = method_3;
		delegate2577_0 = method_4;
	}

	protected override void vmethod_3()
	{
		class2283_0 = new Class2283();
		class2306_0 = new Class2306();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum285_1 != Enum285.const_0)
		{
			writer.WriteAttributeString("additive", Class2587.smethod_1(enum285_1));
		}
		if (enum284_1 != Enum284.const_0)
		{
			writer.WriteAttributeString("accumulate", Class2586.smethod_1(enum284_1));
		}
		if (enum287_1 != Enum287.const_0)
		{
			writer.WriteAttributeString("xfrmType", Class2589.smethod_1(enum287_1));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("from", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("to", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("by", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("rctx", string_3);
		}
		if (enum286_1 != Enum286.const_0)
		{
			writer.WriteAttributeString("override", Class2588.smethod_1(enum286_1));
		}
		class2283_0.vmethod_4("p", writer, "cTn");
		class2306_0.vmethod_4("p", writer, "tgtEl");
		if (class2276_0 != null)
		{
			class2276_0.vmethod_4("p", writer, "attrNameLst");
		}
		writer.WriteEndElement();
	}

	private Class2276 method_3()
	{
		if (class2276_0 != null)
		{
			throw new Exception("Only one <attrNameLst> element can be added.");
		}
		class2276_0 = new Class2276();
		return class2276_0;
	}

	private void method_4(Class2276 _attrNameLst)
	{
		class2276_0 = _attrNameLst;
	}
}
