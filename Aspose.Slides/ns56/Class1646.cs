using System;
using System.Xml;

namespace ns56;

internal class Class1646 : Class1351
{
	public delegate Class1646 Delegate817();

	public delegate void Delegate818(Class1646 elementData);

	public delegate void Delegate819(Class1646 elementData);

	public const bool bool_0 = true;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const uint uint_0 = 0u;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private uint uint_1;

	private string string_0;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private uint uint_2;

	private Class1502 class1502_0;

	public uint Id
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public string Name
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

	public bool DataBound
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

	public bool RowNumbers
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

	public bool FillFormulas
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

	public bool Clipped
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

	public uint TableColumnId
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
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "extLst")
				{
					class1502_0 = new Class1502(reader);
					continue;
				}
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
				case "id":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "name":
					string_0 = reader.Value;
					break;
				case "dataBound":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "rowNumbers":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "fillFormulas":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "clipped":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "tableColumnId":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1646(XmlReader reader)
		: base(reader)
	{
	}

	public Class1646()
	{
	}

	protected override void vmethod_1()
	{
		bool_4 = true;
		bool_5 = false;
		bool_6 = false;
		bool_7 = false;
		uint_2 = 0u;
	}

	protected override void vmethod_2()
	{
		delegate385_0 = method_3;
		delegate387_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("id", XmlConvert.ToString(uint_1));
		if (string_0 != null)
		{
			writer.WriteAttributeString("name", string_0);
		}
		if (!bool_4)
		{
			writer.WriteAttributeString("dataBound", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("rowNumbers", bool_5 ? "1" : "0");
		}
		if (bool_6)
		{
			writer.WriteAttributeString("fillFormulas", bool_6 ? "1" : "0");
		}
		if (bool_7)
		{
			writer.WriteAttributeString("clipped", bool_7 ? "1" : "0");
		}
		if (uint_2 != 0)
		{
			writer.WriteAttributeString("tableColumnId", XmlConvert.ToString(uint_2));
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1502 method_3()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_4(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
