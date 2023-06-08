using System;
using System.Xml;
using ns57;

namespace ns56;

internal class Class2265 : Class1351
{
	public delegate Class2265 Delegate2542();

	public delegate void Delegate2543(Class2265 elementData);

	public delegate void Delegate2544(Class2265 elementData);

	public const Enum278 enum278_0 = Enum278.const_0;

	public const Enum379 enum379_0 = Enum379.const_0;

	public const float float_0 = float.NaN;

	public Class2300.Delegate2647 delegate2647_0;

	public Class2300.Delegate2649 delegate2649_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private Enum278 enum278_1;

	private Enum379 enum379_1;

	private float float_1;

	private Class2281 class2281_0;

	private Class2300 class2300_0;

	public string By
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

	public string From
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

	public string To
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

	public Enum278 Calcmode
	{
		get
		{
			return enum278_1;
		}
		set
		{
			enum278_1 = value;
		}
	}

	public Enum379 ValueType
	{
		get
		{
			return enum379_1;
		}
		set
		{
			enum379_1 = value;
		}
	}

	public float P14_BounceEnd
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public Class2281 CBhvr => class2281_0;

	public Class2300 TavLst => class2300_0;

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
				case "tavLst":
					class2300_0 = new Class2300(reader);
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
				case "by":
					string_0 = reader.Value;
					break;
				case "from":
					string_1 = reader.Value;
					break;
				case "to":
					string_2 = reader.Value;
					break;
				case "calcmode":
					enum278_1 = Class2579.smethod_0(reader.Value);
					break;
				case "valueType":
					enum379_1 = Class2580.smethod_0(reader.Value);
					break;
				case "p14:bounceEnd":
					float_1 = ((reader.Value[reader.Value.Length - 1] == '%') ? ((float)XmlConvert.ToDouble(reader.Value.Substring(0, reader.Value.Length - 1))) : ((float)XmlConvert.ToInt32(reader.Value) / 1000f));
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2265(XmlReader reader)
		: base(reader)
	{
	}

	public Class2265()
	{
	}

	protected override void vmethod_1()
	{
		enum278_1 = Enum278.const_0;
		enum379_1 = Enum379.const_0;
		float_1 = float.NaN;
	}

	protected override void vmethod_2()
	{
		delegate2647_0 = method_3;
		delegate2649_0 = method_4;
	}

	protected override void vmethod_3()
	{
		class2281_0 = new Class2281();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_0 != null)
		{
			writer.WriteAttributeString("by", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("from", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("to", string_2);
		}
		if (enum278_1 != Enum278.const_0)
		{
			writer.WriteAttributeString("calcmode", Class2579.smethod_1(enum278_1));
		}
		if (enum379_1 != Enum379.const_0)
		{
			writer.WriteAttributeString("valueType", Class2580.smethod_1(enum379_1));
		}
		if (!float.IsNaN(float_1))
		{
			writer.WriteAttributeString("p14:bounceEnd", XmlConvert.ToString((int)Math.Round(float_1 * 1000f)));
		}
		class2281_0.vmethod_4("p", writer, "cBhvr");
		if (class2300_0 != null)
		{
			class2300_0.vmethod_4("p", writer, "tavLst");
		}
		writer.WriteEndElement();
	}

	private Class2300 method_3()
	{
		if (class2300_0 != null)
		{
			throw new Exception("Only one <tavLst> element can be added.");
		}
		class2300_0 = new Class2300();
		return class2300_0;
	}

	private void method_4(Class2300 _tavLst)
	{
		class2300_0 = _tavLst;
	}
}
