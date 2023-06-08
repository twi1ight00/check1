using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1635 : Class1351
{
	public delegate Class1635 Delegate784();

	public delegate void Delegate785(Class1635 elementData);

	public delegate void Delegate786(Class1635 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = true;

	public const bool bool_4 = true;

	public const bool bool_5 = true;

	public const bool bool_6 = true;

	public const bool bool_7 = false;

	public const bool bool_8 = true;

	public const bool bool_9 = false;

	public Class1577.Delegate610 delegate610_0;

	public Class1577.Delegate612 delegate612_0;

	public Class1579.Delegate616 delegate616_0;

	public Class1579.Delegate617 delegate617_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private bool bool_14;

	private bool bool_15;

	private bool bool_16;

	private bool bool_17;

	private bool bool_18;

	private bool bool_19;

	private string string_0;

	private Class1577 class1577_0;

	private List<Class1579> list_0;

	private Class1502 class1502_0;

	public bool Outline
	{
		get
		{
			return bool_10;
		}
		set
		{
			bool_10 = value;
		}
	}

	public bool MultipleItemSelectionAllowed
	{
		get
		{
			return bool_11;
		}
		set
		{
			bool_11 = value;
		}
	}

	public bool SubtotalTop
	{
		get
		{
			return bool_12;
		}
		set
		{
			bool_12 = value;
		}
	}

	public bool ShowInFieldList
	{
		get
		{
			return bool_13;
		}
		set
		{
			bool_13 = value;
		}
	}

	public bool DragToRow
	{
		get
		{
			return bool_14;
		}
		set
		{
			bool_14 = value;
		}
	}

	public bool DragToCol
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

	public bool DragToPage
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

	public bool DragToData
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

	public bool DragOff
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

	public bool IncludeNewItemsInFilter
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

	public string Caption
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

	public Class1577 Mps => class1577_0;

	public Class1579[] MembersList => list_0.ToArray();

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
				case "members":
				{
					Class1579 item = new Class1579(reader);
					list_0.Add(item);
					break;
				}
				case "mps":
					class1577_0 = new Class1577(reader);
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
				case "outline":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "multipleItemSelectionAllowed":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "subtotalTop":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showInFieldList":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "dragToRow":
					bool_14 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "dragToCol":
					bool_15 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "dragToPage":
					bool_16 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "dragToData":
					bool_17 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "dragOff":
					bool_18 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "includeNewItemsInFilter":
					bool_19 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "caption":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1635(XmlReader reader)
		: base(reader)
	{
	}

	public Class1635()
	{
	}

	protected override void vmethod_1()
	{
		bool_10 = false;
		bool_11 = false;
		bool_12 = false;
		bool_13 = true;
		bool_14 = true;
		bool_15 = true;
		bool_16 = true;
		bool_17 = false;
		bool_18 = true;
		bool_19 = false;
		list_0 = new List<Class1579>();
	}

	protected override void vmethod_2()
	{
		delegate610_0 = method_3;
		delegate612_0 = method_4;
		delegate616_0 = method_5;
		delegate617_0 = method_6;
		delegate385_0 = method_7;
		delegate387_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (bool_10)
		{
			writer.WriteAttributeString("outline", bool_10 ? "1" : "0");
		}
		if (bool_11)
		{
			writer.WriteAttributeString("multipleItemSelectionAllowed", bool_11 ? "1" : "0");
		}
		if (bool_12)
		{
			writer.WriteAttributeString("subtotalTop", bool_12 ? "1" : "0");
		}
		if (!bool_13)
		{
			writer.WriteAttributeString("showInFieldList", bool_13 ? "1" : "0");
		}
		if (!bool_14)
		{
			writer.WriteAttributeString("dragToRow", bool_14 ? "1" : "0");
		}
		if (!bool_15)
		{
			writer.WriteAttributeString("dragToCol", bool_15 ? "1" : "0");
		}
		if (!bool_16)
		{
			writer.WriteAttributeString("dragToPage", bool_16 ? "1" : "0");
		}
		if (bool_17)
		{
			writer.WriteAttributeString("dragToData", bool_17 ? "1" : "0");
		}
		if (!bool_18)
		{
			writer.WriteAttributeString("dragOff", bool_18 ? "1" : "0");
		}
		if (bool_19)
		{
			writer.WriteAttributeString("includeNewItemsInFilter", bool_19 ? "1" : "0");
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("caption", string_0);
		}
		if (class1577_0 != null)
		{
			class1577_0.vmethod_4("ssml", writer, "mps");
		}
		foreach (Class1579 item in list_0)
		{
			item.vmethod_4("ssml", writer, "members");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1577 method_3()
	{
		if (class1577_0 != null)
		{
			throw new Exception("Only one <mps> element can be added.");
		}
		class1577_0 = new Class1577();
		return class1577_0;
	}

	private void method_4(Class1577 _mps)
	{
		class1577_0 = _mps;
	}

	private Class1579 method_5()
	{
		Class1579 @class = new Class1579();
		list_0.Add(@class);
		return @class;
	}

	private void method_6(Class1579 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1502 method_7()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_8(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
