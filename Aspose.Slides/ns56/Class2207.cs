using System.Xml;

namespace ns56;

internal class Class2207 : Class1351
{
	public delegate Class2207 Delegate2357();

	public delegate void Delegate2358(Class2207 elementData);

	public delegate void Delegate2359(Class2207 elementData);

	public const int int_0 = 0;

	private Enum351 enum351_0;

	private Enum351 enum351_1;

	private string string_0;

	private int int_1;

	public static readonly Enum351 enum351_2 = Class2487.smethod_0("false");

	public static readonly Enum351 enum351_3 = Class2487.smethod_0("false");

	public Enum351 Start
	{
		get
		{
			return enum351_0;
		}
		set
		{
			enum351_0 = value;
		}
	}

	public Enum351 End
	{
		get
		{
			return enum351_1;
		}
		set
		{
			enum351_1 = value;
		}
	}

	public string Idref
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

	public int Connectloc
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
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
				case "connectloc":
					int_1 = XmlConvert.ToInt32(reader.Value);
					break;
				case "idref":
					string_0 = reader.Value;
					break;
				case "end":
					enum351_1 = Class2487.smethod_0(reader.Value);
					break;
				case "start":
					enum351_0 = Class2487.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2207(XmlReader reader)
		: base(reader)
	{
	}

	public Class2207()
	{
	}

	protected override void vmethod_1()
	{
		enum351_0 = enum351_2;
		enum351_1 = enum351_3;
		int_1 = 0;
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
		if (enum351_0 != enum351_2)
		{
			writer.WriteAttributeString("start", Class2487.smethod_1(enum351_0));
		}
		if (enum351_1 != enum351_3)
		{
			writer.WriteAttributeString("end", Class2487.smethod_1(enum351_1));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("idref", string_0);
		}
		if (int_1 != 0)
		{
			writer.WriteAttributeString("connectloc", XmlConvert.ToString(int_1));
		}
		writer.WriteEndElement();
	}
}
