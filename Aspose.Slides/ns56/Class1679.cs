using System.Xml;

namespace ns56;

internal class Class1679 : Class1351
{
	public delegate Class1679 Delegate916();

	public delegate void Delegate918(Class1679 elementData);

	public delegate void Delegate917(Class1679 elementData);

	public const uint uint_0 = 0u;

	public const string string_0 = "A1";

	private Enum224 enum224_0;

	private string string_1;

	private uint uint_1;

	private string string_2;

	public static readonly Enum224 enum224_1 = Class2391.smethod_0("topLeft");

	public Enum224 Pane
	{
		get
		{
			return enum224_0;
		}
		set
		{
			enum224_0 = value;
		}
	}

	public string ActiveCell
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

	public uint ActiveCellId
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

	public string Sqref
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
				case "sqref":
					string_2 = reader.Value;
					break;
				case "activeCellId":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "activeCell":
					string_1 = reader.Value;
					break;
				case "pane":
					enum224_0 = Class2391.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1679(XmlReader reader)
		: base(reader)
	{
	}

	public Class1679()
	{
	}

	protected override void vmethod_1()
	{
		enum224_0 = enum224_1;
		uint_1 = 0u;
		string_2 = "A1";
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
		if (enum224_0 != enum224_1)
		{
			writer.WriteAttributeString("pane", Class2391.smethod_1(enum224_0));
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("activeCell", string_1);
		}
		if (uint_1 != 0)
		{
			writer.WriteAttributeString("activeCellId", XmlConvert.ToString(uint_1));
		}
		if (string_2 != "A1")
		{
			writer.WriteAttributeString("sqref", string_2);
		}
		writer.WriteEndElement();
	}
}
