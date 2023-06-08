using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2209 : Class1351
{
	public delegate Class2209 Delegate2363();

	public delegate void Delegate2364(Class2209 elementData);

	public delegate void Delegate2365(Class2209 elementData);

	public const Enum350 enum350_0 = Enum350.const_0;

	public const Enum347 enum347_0 = Enum347.const_0;

	public Class2207.Delegate2357 delegate2357_0;

	public Class2207.Delegate2358 delegate2358_0;

	private string string_0;

	private Enum350 enum350_1;

	private Enum347 enum347_1;

	private string string_1;

	private List<Class2207> list_0;

	public string Id
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

	public Enum350 Type
	{
		get
		{
			return enum350_1;
		}
		set
		{
			enum350_1 = value;
		}
	}

	public Enum347 How
	{
		get
		{
			return enum347_1;
		}
		set
		{
			enum347_1 = value;
		}
	}

	public string Idref
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

	public Class2207[] ProxyList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "proxy")
				{
					Class2207 item = new Class2207(reader);
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
				case "idref":
					string_1 = reader.Value;
					break;
				case "how":
					enum347_1 = Class2483.smethod_0(reader.Value);
					break;
				case "type":
					enum350_1 = Class2486.smethod_0(reader.Value);
					break;
				case "id":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2209(XmlReader reader)
		: base(reader)
	{
	}

	public Class2209()
	{
	}

	protected override void vmethod_1()
	{
		enum350_1 = Enum350.const_0;
		enum347_1 = Enum347.const_0;
		list_0 = new List<Class2207>();
	}

	protected override void vmethod_2()
	{
		delegate2357_0 = method_3;
		delegate2358_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("id", string_0);
		if (enum350_1 != 0)
		{
			writer.WriteAttributeString("type", Class2486.smethod_1(enum350_1));
		}
		if (enum347_1 != 0)
		{
			writer.WriteAttributeString("how", Class2483.smethod_1(enum347_1));
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("idref", string_1);
		}
		foreach (Class2207 item in list_0)
		{
			item.vmethod_4("o", writer, "proxy");
		}
		writer.WriteEndElement();
	}

	private Class2207 method_3()
	{
		Class2207 @class = new Class2207();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class2207 elementData)
	{
		list_0.Add(elementData);
	}
}
