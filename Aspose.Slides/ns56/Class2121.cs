using System.Xml;

namespace ns56;

internal class Class2121 : Class1351
{
	public delegate Class2121 Delegate2091();

	public delegate void Delegate2092(Class2121 elementData);

	public delegate void Delegate2093(Class2121 elementData);

	private uint uint_0;

	private string string_0;

	public uint Idx
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public string V
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
			if ((localName2 = reader.LocalName) != null && localName2 == "v")
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "idx")
			{
				uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2121(XmlReader reader)
		: base(reader)
	{
	}

	public Class2121()
	{
	}

	protected override void vmethod_1()
	{
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
		writer.WriteAttributeString("idx", XmlConvert.ToString(uint_0));
		method_1("c", writer, "v", string_0);
		writer.WriteEndElement();
	}
}
