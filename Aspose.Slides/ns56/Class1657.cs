using System;
using System.Xml;

namespace ns56;

internal class Class1657 : Class1351
{
	public delegate Class1657 Delegate850();

	public delegate void Delegate851(Class1657 elementData);

	public delegate void Delegate852(Class1657 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const uint uint_0 = 0u;

	public const uint uint_1 = 0u;

	private uint uint_2;

	private string string_0;

	private Guid guid_0;

	private Enum235 enum235_0;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private string string_1;

	private uint uint_3;

	private uint uint_4;

	public static readonly Enum235 enum235_1 = Class2402.smethod_0("add");

	public uint SheetId
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

	public string Cell
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

	public Guid Guid
	{
		get
		{
			return guid_0;
		}
		set
		{
			guid_0 = value;
		}
	}

	public Enum235 Action
	{
		get
		{
			return enum235_0;
		}
		set
		{
			enum235_0 = value;
		}
	}

	public bool AlwaysShow
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

	public bool Old
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

	public bool HiddenRow
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public bool HiddenColumn
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

	public string Author
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

	public uint OldLength
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

	public uint NewLength
	{
		get
		{
			return uint_4;
		}
		set
		{
			uint_4 = value;
		}
	}

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
				_ = reader.LocalName;
				reader.Skip();
				flag = true;
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
				case "sheetId":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "cell":
					string_0 = reader.Value;
					break;
				case "guid":
					guid_0 = new Guid(reader.Value);
					break;
				case "action":
					enum235_0 = Class2402.smethod_0(reader.Value);
					break;
				case "alwaysShow":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "old":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "hiddenRow":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "hiddenColumn":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "author":
					string_1 = reader.Value;
					break;
				case "oldLength":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "newLength":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1657(XmlReader reader)
		: base(reader)
	{
	}

	public Class1657()
	{
	}

	protected override void vmethod_1()
	{
		guid_0 = Guid.Empty;
		enum235_0 = enum235_1;
		bool_4 = false;
		bool_5 = false;
		bool_6 = false;
		bool_7 = false;
		uint_3 = 0u;
		uint_4 = 0u;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("sheetId", XmlConvert.ToString(uint_2));
		writer.WriteAttributeString("cell", string_0);
		writer.WriteAttributeString("guid", "{" + XmlConvert.ToString(guid_0).ToUpper() + "}");
		if (enum235_0 != enum235_1)
		{
			writer.WriteAttributeString("action", Class2402.smethod_1(enum235_0));
		}
		if (bool_4)
		{
			writer.WriteAttributeString("alwaysShow", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("old", bool_5 ? "1" : "0");
		}
		if (bool_6)
		{
			writer.WriteAttributeString("hiddenRow", bool_6 ? "1" : "0");
		}
		if (bool_7)
		{
			writer.WriteAttributeString("hiddenColumn", bool_7 ? "1" : "0");
		}
		writer.WriteAttributeString("author", string_1);
		if (uint_3 != 0)
		{
			writer.WriteAttributeString("oldLength", XmlConvert.ToString(uint_3));
		}
		if (uint_4 != 0)
		{
			writer.WriteAttributeString("newLength", XmlConvert.ToString(uint_4));
		}
		writer.WriteEndElement();
	}
}
