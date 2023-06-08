using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1446 : Class1351
{
	public delegate Class1446 Delegate300();

	public delegate void Delegate302(Class1446 elementData);

	public delegate void Delegate301(Class1446 elementData);

	public const uint uint_0 = 10u;

	public const uint uint_1 = 90u;

	public const bool bool_0 = true;

	private uint uint_2;

	private uint uint_3;

	private bool bool_1;

	private List<Class1407> list_0;

	private Class1419 class1419_0;

	public uint MinLength
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

	public uint MaxLength
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

	public bool ShowValue
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

	public Class1407 Cfvo1 => list_0[0];

	public Class1407 Cfvo2 => list_0[1];

	public Class1419 Color => class1419_0;

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
				case "color":
					class1419_0 = new Class1419(reader);
					break;
				case "cfvo":
				{
					Class1407 item = new Class1407(reader);
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
				case "showValue":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "maxLength":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "minLength":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1446(XmlReader reader)
		: base(reader)
	{
	}

	public Class1446()
	{
	}

	protected override void vmethod_1()
	{
		uint_2 = 10u;
		uint_3 = 90u;
		bool_1 = true;
		list_0 = new List<Class1407>();
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
		list_0.Add(new Class1407());
		list_0.Add(new Class1407());
		class1419_0 = new Class1419();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_2 != 10)
		{
			writer.WriteAttributeString("minLength", XmlConvert.ToString(uint_2));
		}
		if (uint_3 != 90)
		{
			writer.WriteAttributeString("maxLength", XmlConvert.ToString(uint_3));
		}
		if (!bool_1)
		{
			writer.WriteAttributeString("showValue", bool_1 ? "1" : "0");
		}
		Cfvo1.vmethod_4("ssml", writer, "cfvo");
		Cfvo2.vmethod_4("ssml", writer, "cfvo");
		class1419_0.vmethod_4("ssml", writer, "color");
		writer.WriteEndElement();
	}
}
