using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1482 : Class1351
{
	public delegate void Delegate325(Class1482 elementData);

	public delegate Class1482 Delegate323();

	public delegate void Delegate324(Class1482 elementData);

	public const bool bool_0 = false;

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = uint.MaxValue;

	public const uint uint_2 = uint.MaxValue;

	public Class1481.Delegate320 delegate320_0;

	public Class1481.Delegate321 delegate321_0;

	private bool bool_1;

	private uint uint_3;

	private uint uint_4;

	private uint uint_5;

	private List<Class1481> list_0;

	public bool DisablePrompts
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public uint XWindow
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

	public uint YWindow
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

	public uint Count
	{
		get
		{
			return uint_5;
		}
		set
		{
			uint_5 = value;
		}
	}

	public Class1481[] DataValidationList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "dataValidation")
				{
					Class1481 item = new Class1481(reader);
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
				case "count":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "yWindow":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "xWindow":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "disablePrompts":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1482(XmlReader reader)
		: base(reader)
	{
	}

	public Class1482()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
		uint_3 = uint.MaxValue;
		uint_4 = uint.MaxValue;
		uint_5 = uint.MaxValue;
		list_0 = new List<Class1481>();
	}

	protected override void vmethod_2()
	{
		delegate320_0 = method_3;
		delegate321_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (bool_1)
		{
			writer.WriteAttributeString("disablePrompts", bool_1 ? "1" : "0");
		}
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("xWindow", XmlConvert.ToString(uint_3));
		}
		if (uint_4 != uint.MaxValue)
		{
			writer.WriteAttributeString("yWindow", XmlConvert.ToString(uint_4));
		}
		if (uint_5 != uint.MaxValue)
		{
			writer.WriteAttributeString("count", XmlConvert.ToString(uint_5));
		}
		foreach (Class1481 item in list_0)
		{
			item.vmethod_4("ssml", writer, "dataValidation");
		}
		writer.WriteEndElement();
	}

	private Class1481 method_3()
	{
		Class1481 @class = new Class1481();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1481 elementData)
	{
		list_0.Add(elementData);
	}
}
