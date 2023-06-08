using System;
using System.Xml;

namespace ns56;

internal class Class1865 : Class1351
{
	public delegate Class1865 Delegate1474();

	public delegate void Delegate1475(Class1865 elementData);

	public delegate void Delegate1476(Class1865 elementData);

	public const string string_0 = "";

	public const string string_1 = "";

	public const string string_2 = "";

	public const string string_3 = "";

	public const bool bool_0 = true;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public Class1838.Delegate1393 delegate1393_0;

	public Class1838.Delegate1395 delegate1395_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private string string_4;

	private string string_5;

	private string string_6;

	private string string_7;

	private string string_8;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private Class1838 class1838_0;

	private Class1886 class1886_0;

	public string R_Id
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public string InvalidUrl
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public string Action
	{
		get
		{
			return string_6;
		}
		set
		{
			string_6 = value;
		}
	}

	public string TgtFrame
	{
		get
		{
			return string_7;
		}
		set
		{
			string_7 = value;
		}
	}

	public string Tooltip
	{
		get
		{
			return string_8;
		}
		set
		{
			string_8 = value;
		}
	}

	public bool History
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public bool HighlightClick
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool EndSnd
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public Class1838 Snd => class1838_0;

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
				case "snd":
					class1838_0 = new Class1838(reader);
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
				case "r:id":
					string_4 = reader.Value;
					break;
				case "invalidUrl":
					string_5 = reader.Value;
					break;
				case "action":
					string_6 = reader.Value;
					break;
				case "tgtFrame":
					string_7 = reader.Value;
					break;
				case "tooltip":
					string_8 = reader.Value;
					break;
				case "history":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "highlightClick":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "endSnd":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1865(XmlReader reader)
		: base(reader)
	{
	}

	public Class1865()
	{
	}

	protected override void vmethod_1()
	{
		string_5 = "";
		string_6 = "";
		string_7 = "";
		string_8 = "";
		bool_3 = true;
		bool_4 = false;
		bool_5 = false;
	}

	protected override void vmethod_2()
	{
		delegate1393_0 = method_3;
		delegate1395_0 = method_4;
		delegate1534_0 = method_5;
		delegate1535_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_4 != null)
		{
			writer.WriteAttributeString("r:id", string_4);
		}
		if (string_5 != "")
		{
			writer.WriteAttributeString("invalidUrl", string_5);
		}
		if (string_6 != "")
		{
			writer.WriteAttributeString("action", string_6);
		}
		if (string_7 != "")
		{
			writer.WriteAttributeString("tgtFrame", string_7);
		}
		if (string_8 != "")
		{
			writer.WriteAttributeString("tooltip", string_8);
		}
		if (!bool_3)
		{
			writer.WriteAttributeString("history", bool_3 ? "1" : "0");
		}
		if (bool_4)
		{
			writer.WriteAttributeString("highlightClick", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("endSnd", bool_5 ? "1" : "0");
		}
		if (class1838_0 != null)
		{
			class1838_0.vmethod_4("a", writer, "snd");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1838 method_3()
	{
		if (class1838_0 != null)
		{
			throw new Exception("Only one <snd> element can be added.");
		}
		class1838_0 = new Class1838();
		return class1838_0;
	}

	private void method_4(Class1838 _snd)
	{
		class1838_0 = _snd;
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
