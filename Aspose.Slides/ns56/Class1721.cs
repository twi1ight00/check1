using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1721 : Class1351
{
	public delegate void Delegate1044(Class1721 elementData);

	public delegate Class1721 Delegate1042();

	public delegate void Delegate1043(Class1721 elementData);

	public const uint uint_0 = uint.MaxValue;

	public Class1718.Delegate1033 delegate1033_0;

	public Class1718.Delegate1034 delegate1034_0;

	private uint uint_1;

	private string string_0;

	private string string_1;

	private List<Class1718> list_0;

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

	public string DefaultTableStyle
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

	public string DefaultPivotStyle
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

	public Class1718[] TableStyleList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "tableStyle")
				{
					Class1718 item = new Class1718(reader);
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
				case "defaultPivotStyle":
					string_1 = reader.Value;
					break;
				case "defaultTableStyle":
					string_0 = reader.Value;
					break;
				case "count":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1721(XmlReader reader)
		: base(reader)
	{
	}

	public Class1721()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = uint.MaxValue;
		list_0 = new List<Class1718>();
	}

	protected override void vmethod_2()
	{
		delegate1033_0 = method_3;
		delegate1034_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("count", XmlConvert.ToString(uint_1));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("defaultTableStyle", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("defaultPivotStyle", string_1);
		}
		foreach (Class1718 item in list_0)
		{
			item.vmethod_4("ssml", writer, "tableStyle");
		}
		writer.WriteEndElement();
	}

	private Class1718 method_3()
	{
		Class1718 @class = new Class1718();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1718 elementData)
	{
		list_0.Add(elementData);
	}
}
