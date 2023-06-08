using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1678 : Class1351
{
	public delegate void Delegate915(Class1678 elementData);

	public delegate Class1678 Delegate913();

	public delegate void Delegate914(Class1678 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = uint.MaxValue;

	public Class1677.Delegate910 delegate910_0;

	public Class1677.Delegate911 delegate911_0;

	private uint uint_2;

	private uint uint_3;

	private string string_0;

	private List<Class1677> list_0;

	public uint Current
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

	public uint Show
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

	public string Sqref
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

	public Class1677[] ScenarioList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "scenario")
				{
					Class1677 item = new Class1677(reader);
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
				case "sqref":
					string_0 = reader.Value;
					break;
				case "show":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "current":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1678(XmlReader reader)
		: base(reader)
	{
	}

	public Class1678()
	{
	}

	protected override void vmethod_1()
	{
		uint_2 = uint.MaxValue;
		uint_3 = uint.MaxValue;
		list_0 = new List<Class1677>();
	}

	protected override void vmethod_2()
	{
		delegate910_0 = method_3;
		delegate911_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_2 != uint.MaxValue)
		{
			writer.WriteAttributeString("current", XmlConvert.ToString(uint_2));
		}
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("show", XmlConvert.ToString(uint_3));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("sqref", string_0);
		}
		foreach (Class1677 item in list_0)
		{
			item.vmethod_4("ssml", writer, "scenario");
		}
		writer.WriteEndElement();
	}

	private Class1677 method_3()
	{
		Class1677 @class = new Class1677();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1677 elementData)
	{
		list_0.Add(elementData);
	}
}
