using System;
using System.Xml;

namespace ns56;

internal class Class1694 : Class1351
{
	public delegate void Delegate963(Class1694 elementData);

	public delegate Class1694 Delegate961();

	public delegate void Delegate962(Class1694 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const bool bool_4 = true;

	public const bool bool_5 = false;

	public const bool bool_6 = true;

	public Class1419.Delegate219 delegate219_0;

	public Class1419.Delegate221 delegate221_0;

	public Class1602.Delegate685 delegate685_0;

	public Class1602.Delegate687 delegate687_0;

	public Class1610.Delegate709 delegate709_0;

	public Class1610.Delegate711 delegate711_0;

	private bool bool_7;

	private bool bool_8;

	private string string_0;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private string string_1;

	private bool bool_12;

	private bool bool_13;

	private Class1419 class1419_0;

	private Class1602 class1602_0;

	private Class1610 class1610_0;

	public bool SyncHorizontal
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
		}
	}

	public bool SyncVertical
	{
		get
		{
			return bool_8;
		}
		set
		{
			bool_8 = value;
		}
	}

	public string SyncRef
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

	public bool TransitionEvaluation
	{
		get
		{
			return bool_9;
		}
		set
		{
			bool_9 = value;
		}
	}

	public bool TransitionEntry
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

	public bool Published
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

	public string CodeName
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

	public bool FilterMode
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

	public bool EnableFormatConditionsCalculation
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

	public Class1419 TabColor => class1419_0;

	public Class1602 OutlinePr => class1602_0;

	public Class1610 PageSetUpPr => class1610_0;

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
				case "pageSetUpPr":
					class1610_0 = new Class1610(reader);
					break;
				case "outlinePr":
					class1602_0 = new Class1602(reader);
					break;
				case "tabColor":
					class1419_0 = new Class1419(reader);
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
				case "syncHorizontal":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "syncVertical":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "syncRef":
					string_0 = reader.Value;
					break;
				case "transitionEvaluation":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "transitionEntry":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "published":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "codeName":
					string_1 = reader.Value;
					break;
				case "filterMode":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "enableFormatConditionsCalculation":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1694(XmlReader reader)
		: base(reader)
	{
	}

	public Class1694()
	{
	}

	protected override void vmethod_1()
	{
		bool_7 = false;
		bool_8 = false;
		bool_9 = false;
		bool_10 = false;
		bool_11 = true;
		bool_12 = false;
		bool_13 = true;
	}

	protected override void vmethod_2()
	{
		delegate219_0 = method_3;
		delegate221_0 = method_4;
		delegate685_0 = method_5;
		delegate687_0 = method_6;
		delegate709_0 = method_7;
		delegate711_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (bool_7)
		{
			writer.WriteAttributeString("syncHorizontal", bool_7 ? "1" : "0");
		}
		if (bool_8)
		{
			writer.WriteAttributeString("syncVertical", bool_8 ? "1" : "0");
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("syncRef", string_0);
		}
		if (bool_9)
		{
			writer.WriteAttributeString("transitionEvaluation", bool_9 ? "1" : "0");
		}
		if (bool_10)
		{
			writer.WriteAttributeString("transitionEntry", bool_10 ? "1" : "0");
		}
		if (!bool_11)
		{
			writer.WriteAttributeString("published", bool_11 ? "1" : "0");
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("codeName", string_1);
		}
		if (bool_12)
		{
			writer.WriteAttributeString("filterMode", bool_12 ? "1" : "0");
		}
		if (!bool_13)
		{
			writer.WriteAttributeString("enableFormatConditionsCalculation", bool_13 ? "1" : "0");
		}
		if (class1419_0 != null)
		{
			class1419_0.vmethod_4("ssml", writer, "tabColor");
		}
		if (class1602_0 != null)
		{
			class1602_0.vmethod_4("ssml", writer, "outlinePr");
		}
		if (class1610_0 != null)
		{
			class1610_0.vmethod_4("ssml", writer, "pageSetUpPr");
		}
		writer.WriteEndElement();
	}

	private Class1419 method_3()
	{
		if (class1419_0 != null)
		{
			throw new Exception("Only one <tabColor> element can be added.");
		}
		class1419_0 = new Class1419();
		return class1419_0;
	}

	private void method_4(Class1419 _tabColor)
	{
		class1419_0 = _tabColor;
	}

	private Class1602 method_5()
	{
		if (class1602_0 != null)
		{
			throw new Exception("Only one <outlinePr> element can be added.");
		}
		class1602_0 = new Class1602();
		return class1602_0;
	}

	private void method_6(Class1602 _outlinePr)
	{
		class1602_0 = _outlinePr;
	}

	private Class1610 method_7()
	{
		if (class1610_0 != null)
		{
			throw new Exception("Only one <pageSetUpPr> element can be added.");
		}
		class1610_0 = new Class1610();
		return class1610_0;
	}

	private void method_8(Class1610 _pageSetUpPr)
	{
		class1610_0 = _pageSetUpPr;
	}
}
