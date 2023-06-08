using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1551 : Class1351
{
	public delegate Class1551 Delegate532();

	public delegate void Delegate534(Class1551 elementData);

	public delegate void Delegate533(Class1551 elementData);

	public const bool bool_0 = true;

	public const bool bool_1 = true;

	public const bool bool_2 = false;

	public Class1407.Delegate183 delegate183_0;

	public Class1407.Delegate184 delegate184_0;

	private Enum215 enum215_0;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private List<Class1407> list_0;

	public static readonly Enum215 enum215_1 = Class2382.smethod_0("3TrafficLights1");

	public Enum215 IconSet
	{
		get
		{
			return enum215_0;
		}
		set
		{
			enum215_0 = value;
		}
	}

	public bool ShowValue
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

	public bool Percent
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

	public bool Reverse
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

	public Class1407[] CfvoList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "cfvo")
				{
					Class1407 item = new Class1407(reader);
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
				case "reverse":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "percent":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showValue":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "iconSet":
					enum215_0 = Class2382.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1551(XmlReader reader)
		: base(reader)
	{
	}

	public Class1551()
	{
	}

	protected override void vmethod_1()
	{
		enum215_0 = enum215_1;
		bool_3 = true;
		bool_4 = true;
		bool_5 = false;
		list_0 = new List<Class1407>();
	}

	protected override void vmethod_2()
	{
		delegate183_0 = method_3;
		delegate184_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum215_0 != enum215_1)
		{
			writer.WriteAttributeString("iconSet", Class2382.smethod_1(enum215_0));
		}
		if (!bool_3)
		{
			writer.WriteAttributeString("showValue", bool_3 ? "1" : "0");
		}
		if (!bool_4)
		{
			writer.WriteAttributeString("percent", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("reverse", bool_5 ? "1" : "0");
		}
		foreach (Class1407 item in list_0)
		{
			item.vmethod_4("ssml", writer, "cfvo");
		}
		writer.WriteEndElement();
	}

	private Class1407 method_3()
	{
		Class1407 @class = new Class1407();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1407 elementData)
	{
		list_0.Add(elementData);
	}
}
