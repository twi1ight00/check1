using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1622 : Class1351
{
	public delegate Class1622 Delegate745();

	public delegate void Delegate746(Class1622 elementData);

	public delegate void Delegate747(Class1622 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = uint.MaxValue;

	public const bool bool_0 = true;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const bool bool_4 = false;

	public const bool bool_5 = false;

	public const bool bool_6 = false;

	public const bool bool_7 = false;

	public const bool bool_8 = false;

	public const bool bool_9 = false;

	public const bool bool_10 = false;

	public const bool bool_11 = false;

	public const bool bool_12 = false;

	public const bool bool_13 = false;

	public const bool bool_14 = false;

	public Class1556.Delegate547 delegate547_0;

	public Class1556.Delegate548 delegate548_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private uint uint_2;

	private uint uint_3;

	private bool bool_15;

	private bool bool_16;

	private bool bool_17;

	private bool bool_18;

	private bool bool_19;

	private bool bool_20;

	private bool bool_21;

	private bool bool_22;

	private bool bool_23;

	private bool bool_24;

	private bool bool_25;

	private bool bool_26;

	private bool bool_27;

	private bool bool_28;

	private bool bool_29;

	private List<Class1556> list_0;

	private Class1502 class1502_0;

	public uint Field
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	public uint Count
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	public bool Selected
	{
		get
		{
			return bool_15;
		}
		set
		{
			bool_15 = value;
		}
	}

	public bool ByPosition
	{
		get
		{
			return bool_16;
		}
		set
		{
			bool_16 = value;
		}
	}

	public bool Relative
	{
		get
		{
			return bool_17;
		}
		set
		{
			bool_17 = value;
		}
	}

	public bool DefaultSubtotal
	{
		get
		{
			return bool_18;
		}
		set
		{
			bool_18 = value;
		}
	}

	public bool SumSubtotal
	{
		get
		{
			return bool_19;
		}
		set
		{
			bool_19 = value;
		}
	}

	public bool CountASubtotal
	{
		get
		{
			return bool_20;
		}
		set
		{
			bool_20 = value;
		}
	}

	public bool AvgSubtotal
	{
		get
		{
			return bool_21;
		}
		set
		{
			bool_21 = value;
		}
	}

	public bool MaxSubtotal
	{
		get
		{
			return bool_22;
		}
		set
		{
			bool_22 = value;
		}
	}

	public bool MinSubtotal
	{
		get
		{
			return bool_23;
		}
		set
		{
			bool_23 = value;
		}
	}

	public bool ProductSubtotal
	{
		get
		{
			return bool_24;
		}
		set
		{
			bool_24 = value;
		}
	}

	public bool CountSubtotal
	{
		get
		{
			return bool_25;
		}
		set
		{
			bool_25 = value;
		}
	}

	public bool StdDevSubtotal
	{
		get
		{
			return bool_26;
		}
		set
		{
			bool_26 = value;
		}
	}

	public bool StdDevPSubtotal
	{
		get
		{
			return bool_27;
		}
		set
		{
			bool_27 = value;
		}
	}

	public bool VarSubtotal
	{
		get
		{
			return bool_28;
		}
		set
		{
			bool_28 = value;
		}
	}

	public bool VarPSubtotal
	{
		get
		{
			return bool_29;
		}
		set
		{
			bool_29 = value;
		}
	}

	public Class1556[] XList => list_0.ToArray();

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
				case "x":
				{
					Class1556 item = new Class1556(reader);
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
				case "field":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "count":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "selected":
					bool_15 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "byPosition":
					bool_16 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "relative":
					bool_17 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "defaultSubtotal":
					bool_18 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "sumSubtotal":
					bool_19 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "countASubtotal":
					bool_20 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "avgSubtotal":
					bool_21 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "maxSubtotal":
					bool_22 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "minSubtotal":
					bool_23 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "productSubtotal":
					bool_24 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "countSubtotal":
					bool_25 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "stdDevSubtotal":
					bool_26 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "stdDevPSubtotal":
					bool_27 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "varSubtotal":
					bool_28 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "varPSubtotal":
					bool_29 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1622(XmlReader reader)
		: base(reader)
	{
	}

	public Class1622()
	{
	}

	protected override void vmethod_1()
	{
		uint_2 = uint.MaxValue;
		uint_3 = uint.MaxValue;
		bool_15 = true;
		bool_16 = false;
		bool_17 = false;
		bool_18 = false;
		bool_19 = false;
		bool_20 = false;
		bool_21 = false;
		bool_22 = false;
		bool_23 = false;
		bool_24 = false;
		bool_25 = false;
		bool_26 = false;
		bool_27 = false;
		bool_28 = false;
		bool_29 = false;
		list_0 = new List<Class1556>();
	}

	protected override void vmethod_2()
	{
		delegate547_0 = method_3;
		delegate548_0 = method_4;
		delegate385_0 = method_5;
		delegate387_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_2 != uint.MaxValue)
		{
			writer.WriteAttributeString("field", XmlConvert.ToString(uint_2));
		}
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("count", XmlConvert.ToString(uint_3));
		}
		if (!bool_15)
		{
			writer.WriteAttributeString("selected", bool_15 ? "1" : "0");
		}
		if (bool_16)
		{
			writer.WriteAttributeString("byPosition", bool_16 ? "1" : "0");
		}
		if (bool_17)
		{
			writer.WriteAttributeString("relative", bool_17 ? "1" : "0");
		}
		if (bool_18)
		{
			writer.WriteAttributeString("defaultSubtotal", bool_18 ? "1" : "0");
		}
		if (bool_19)
		{
			writer.WriteAttributeString("sumSubtotal", bool_19 ? "1" : "0");
		}
		if (bool_20)
		{
			writer.WriteAttributeString("countASubtotal", bool_20 ? "1" : "0");
		}
		if (bool_21)
		{
			writer.WriteAttributeString("avgSubtotal", bool_21 ? "1" : "0");
		}
		if (bool_22)
		{
			writer.WriteAttributeString("maxSubtotal", bool_22 ? "1" : "0");
		}
		if (bool_23)
		{
			writer.WriteAttributeString("minSubtotal", bool_23 ? "1" : "0");
		}
		if (bool_24)
		{
			writer.WriteAttributeString("productSubtotal", bool_24 ? "1" : "0");
		}
		if (bool_25)
		{
			writer.WriteAttributeString("countSubtotal", bool_25 ? "1" : "0");
		}
		if (bool_26)
		{
			writer.WriteAttributeString("stdDevSubtotal", bool_26 ? "1" : "0");
		}
		if (bool_27)
		{
			writer.WriteAttributeString("stdDevPSubtotal", bool_27 ? "1" : "0");
		}
		if (bool_28)
		{
			writer.WriteAttributeString("varSubtotal", bool_28 ? "1" : "0");
		}
		if (bool_29)
		{
			writer.WriteAttributeString("varPSubtotal", bool_29 ? "1" : "0");
		}
		foreach (Class1556 item in list_0)
		{
			item.vmethod_4("ssml", writer, "x");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1556 method_3()
	{
		Class1556 @class = new Class1556();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1556 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1502 method_5()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_6(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
