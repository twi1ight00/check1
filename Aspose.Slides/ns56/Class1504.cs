using System.Xml;

namespace ns56;

internal class Class1504 : Class1351
{
	public delegate Class1504 Delegate391();

	public delegate void Delegate392(Class1504 elementData);

	public delegate void Delegate393(Class1504 elementData);

	public const uint uint_0 = 0u;

	private string string_0;

	private Enum262 enum262_0;

	private uint uint_1;

	private string string_1;

	public static readonly Enum262 enum262_1 = Class2355.smethod_0("n");

	public string R
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

	public Enum262 T
	{
		get
		{
			return enum262_0;
		}
		set
		{
			enum262_0 = value;
		}
	}

	public uint Vm
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

	public string V
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
			if (reader.NodeType != XmlNodeType.Element)
			{
				continue;
			}
			string localName2;
			if ((localName2 = reader.LocalName) != null && localName2 == "v")
			{
				string_1 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_1 += reader.ReadString();
					}
				}
			}
			else
			{
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
				case "vm":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "t":
					enum262_0 = Class2355.smethod_0(reader.Value);
					break;
				case "r":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1504(XmlReader reader)
		: base(reader)
	{
	}

	public Class1504()
	{
	}

	protected override void vmethod_1()
	{
		enum262_0 = enum262_1;
		uint_1 = 0u;
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
		if (string_0 != null)
		{
			writer.WriteAttributeString("r", string_0);
		}
		if (enum262_0 != enum262_1)
		{
			writer.WriteAttributeString("t", Class2355.smethod_1(enum262_0));
		}
		if (uint_1 != 0)
		{
			writer.WriteAttributeString("vm", XmlConvert.ToString(uint_1));
		}
		if (string_1 != null)
		{
			method_1("ssml", writer, "v", string_1);
		}
		writer.WriteEndElement();
	}
}
