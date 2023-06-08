using System.Xml;
using ns57;

namespace ns56;

internal class Class2280 : Class1351
{
	public delegate Class2280 Delegate2587();

	public delegate void Delegate2588(Class2280 elementData);

	public delegate void Delegate2589(Class2280 elementData);

	public const Enum288 enum288_0 = Enum288.const_0;

	private Enum288 enum288_1;

	private string string_0;

	private Class2281 class2281_0;

	public Enum288 Type
	{
		get
		{
			return enum288_1;
		}
		set
		{
			enum288_1 = value;
		}
	}

	public string Cmd
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

	public Class2281 CBhvr => class2281_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "cBhvr")
				{
					class2281_0 = new Class2281(reader);
					continue;
				}
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
				case "cmd":
					string_0 = reader.Value;
					break;
				case "type":
					enum288_1 = Class2591.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2280(XmlReader reader)
		: base(reader)
	{
	}

	public Class2280()
	{
	}

	protected override void vmethod_1()
	{
		enum288_1 = Enum288.const_0;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
		class2281_0 = new Class2281();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum288_1 != Enum288.const_0)
		{
			writer.WriteAttributeString("type", Class2591.smethod_1(enum288_1));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("cmd", string_0);
		}
		class2281_0.vmethod_4("p", writer, "cBhvr");
		writer.WriteEndElement();
	}
}
