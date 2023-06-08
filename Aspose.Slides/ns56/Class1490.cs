using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1490 : Class1351
{
	public delegate Class1490 Delegate347();

	public delegate void Delegate349(Class1490 elementData);

	public delegate void Delegate348(Class1490 elementData);

	public const uint uint_0 = 1u;

	public const uint uint_1 = 1u;

	public Class1489.Delegate344 delegate344_0;

	public Class1489.Delegate345 delegate345_0;

	private uint uint_2;

	private uint uint_3;

	private List<Class1489> list_0;

	public uint Rows
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

	public uint Cols
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

	public Class1489[] ValueList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "value")
				{
					Class1489 item = new Class1489(reader);
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
				case "cols":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "rows":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1490(XmlReader reader)
		: base(reader)
	{
	}

	public Class1490()
	{
	}

	protected override void vmethod_1()
	{
		uint_2 = 1u;
		uint_3 = 1u;
		list_0 = new List<Class1489>();
	}

	protected override void vmethod_2()
	{
		delegate344_0 = method_3;
		delegate345_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_2 != 1)
		{
			writer.WriteAttributeString("rows", XmlConvert.ToString(uint_2));
		}
		if (uint_3 != 1)
		{
			writer.WriteAttributeString("cols", XmlConvert.ToString(uint_3));
		}
		foreach (Class1489 item in list_0)
		{
			item.vmethod_4("ssml", writer, "value");
		}
		writer.WriteEndElement();
	}

	private Class1489 method_3()
	{
		Class1489 @class = new Class1489();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1489 elementData)
	{
		list_0.Add(elementData);
	}
}
