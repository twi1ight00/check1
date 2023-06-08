using System.Collections.Generic;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1375 : Class1351
{
	public delegate Class1375 Delegate87();

	public delegate void Delegate88(Class1375 elementData);

	public delegate void Delegate89(Class1375 elementData);

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const NullableBool nullableBool_1 = NullableBool.NotDefined;

	public const uint uint_0 = uint.MaxValue;

	public Class1749.Delegate1126 delegate1126_0;

	public Class1749.Delegate1127 delegate1127_0;

	private bool bool_0;

	private NullableBool nullableBool_2;

	private NullableBool nullableBool_3;

	private string string_0;

	private uint uint_1;

	private List<Class1749> list_0;

	public bool V
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public NullableBool U
	{
		get
		{
			return nullableBool_2;
		}
		set
		{
			nullableBool_2 = value;
		}
	}

	public NullableBool F
	{
		get
		{
			return nullableBool_3;
		}
		set
		{
			nullableBool_3 = value;
		}
	}

	public string C
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

	public uint Cp
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

	public Class1749[] XList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "x")
				{
					Class1749 item = new Class1749(reader);
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
				case "cp":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "c":
					string_0 = reader.Value;
					break;
				case "f":
					nullableBool_3 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "u":
					nullableBool_2 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "v":
					bool_0 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1375(XmlReader reader)
		: base(reader)
	{
	}

	public Class1375()
	{
	}

	protected override void vmethod_1()
	{
		nullableBool_2 = NullableBool.NotDefined;
		nullableBool_3 = NullableBool.NotDefined;
		uint_1 = uint.MaxValue;
		list_0 = new List<Class1749>();
	}

	protected override void vmethod_2()
	{
		delegate1126_0 = method_3;
		delegate1127_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("v", bool_0 ? "1" : "0");
		if (nullableBool_2 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("u", (nullableBool_2 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_3 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("f", (nullableBool_3 == NullableBool.True) ? "1" : "0");
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("c", string_0);
		}
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("cp", XmlConvert.ToString(uint_1));
		}
		foreach (Class1749 item in list_0)
		{
			item.vmethod_4("ssml", writer, "x");
		}
		writer.WriteEndElement();
	}

	private Class1749 method_3()
	{
		Class1749 @class = new Class1749();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1749 elementData)
	{
		list_0.Add(elementData);
	}
}
