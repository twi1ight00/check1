using System;
using System.Xml;

namespace ns56;

internal class Class1424 : Class1351
{
	public delegate Class1424 Delegate234();

	public delegate void Delegate235(Class1424 elementData);

	public delegate void Delegate236(Class1424 elementData);

	private string string_0;

	private uint uint_0;

	private Guid guid_0;

	private Class1676 class1676_0;

	public static readonly Guid guid_1 = Guid.Empty;

	public string Ref
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

	public uint AuthorId
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

	public Guid Guid
	{
		get
		{
			return guid_0;
		}
		set
		{
			guid_0 = value;
		}
	}

	public Class1676 Text => class1676_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "text")
				{
					class1676_0 = new Class1676(reader);
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
				case "guid":
					guid_0 = new Guid(reader.Value);
					break;
				case "authorId":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "ref":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1424(XmlReader reader)
		: base(reader)
	{
	}

	public Class1424()
	{
	}

	protected override void vmethod_1()
	{
		guid_0 = guid_1;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
		class1676_0 = new Class1676();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("ref", string_0);
		writer.WriteAttributeString("authorId", XmlConvert.ToString(uint_0));
		if (guid_0 != guid_1)
		{
			writer.WriteAttributeString("guid", "{" + XmlConvert.ToString(guid_0).ToUpper() + "}");
		}
		class1676_0.vmethod_4("ssml", writer, "text");
		writer.WriteEndElement();
	}
}
