using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1677 : Class1351
{
	public delegate Class1677 Delegate910();

	public delegate void Delegate911(Class1677 elementData);

	public delegate void Delegate912(Class1677 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const uint uint_0 = uint.MaxValue;

	public Class1557.Delegate550 delegate550_0;

	public Class1557.Delegate551 delegate551_0;

	private string string_0;

	private bool bool_2;

	private bool bool_3;

	private uint uint_1;

	private string string_1;

	private string string_2;

	private List<Class1557> list_0;

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

	public bool Locked
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool Hidden
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

	public uint Count
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

	public string User
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

	public string Comment
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

	public Class1557[] InputCellsList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "inputCells")
				{
					Class1557 item = new Class1557(reader);
					list_0.Add(item);
				}
				else
				{
					reader.Skip();
					flag = true;
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
				case "name":
					string_0 = reader.Value;
					break;
				case "locked":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "hidden":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "count":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "user":
					string_1 = reader.Value;
					break;
				case "comment":
					string_2 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1677(XmlReader reader)
		: base(reader)
	{
	}

	public Class1677()
	{
	}

	protected override void vmethod_1()
	{
		bool_2 = false;
		bool_3 = false;
		uint_1 = uint.MaxValue;
		list_0 = new List<Class1557>();
	}

	protected override void vmethod_2()
	{
		delegate550_0 = method_3;
		delegate551_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("name", string_0);
		if (bool_2)
		{
			writer.WriteAttributeString("locked", bool_2 ? "1" : "0");
		}
		if (bool_3)
		{
			writer.WriteAttributeString("hidden", bool_3 ? "1" : "0");
		}
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("count", XmlConvert.ToString(uint_1));
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("user", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("comment", string_2);
		}
		foreach (Class1557 item in list_0)
		{
			item.vmethod_4("ssml", writer, "inputCells");
		}
		writer.WriteEndElement();
	}

	private Class1557 method_3()
	{
		Class1557 @class = new Class1557();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1557 elementData)
	{
		list_0.Add(elementData);
	}
}
