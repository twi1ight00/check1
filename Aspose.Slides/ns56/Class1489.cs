using System.Xml;

namespace ns56;

internal class Class1489 : Class1351
{
	public delegate Class1489 Delegate344();

	public delegate void Delegate345(Class1489 elementData);

	public delegate void Delegate346(Class1489 elementData);

	private Enum200 enum200_0;

	private string string_0;

	public static readonly Enum200 enum200_1 = Class2367.smethod_0("n");

	public Enum200 T
	{
		get
		{
			return enum200_0;
		}
		set
		{
			enum200_0 = value;
		}
	}

	public string Val
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
			if ((localName2 = reader.LocalName) != null && localName2 == "val")
			{
				string_0 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_0 += reader.ReadString();
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
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "t")
			{
				enum200_0 = Class2367.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1489(XmlReader reader)
		: base(reader)
	{
	}

	public Class1489()
	{
	}

	protected override void vmethod_1()
	{
		enum200_0 = enum200_1;
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
		if (enum200_0 != enum200_1)
		{
			writer.WriteAttributeString("t", Class2367.smethod_1(enum200_0));
		}
		method_1("ssml", writer, "val", string_0);
		writer.WriteEndElement();
	}
}
