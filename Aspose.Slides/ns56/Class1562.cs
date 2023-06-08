using System.Xml;

namespace ns56;

internal class Class1562 : Class1351
{
	public delegate Class1562 Delegate565();

	public delegate void Delegate566(Class1562 elementData);

	public delegate void Delegate567(Class1562 elementData);

	public const int int_0 = 0;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private int int_1;

	private Class1544 class1544_0;

	public string Name
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

	public string UniqueName
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

	public string Caption
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

	public string UniqueParent
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public int Id
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

	public Class1544 GroupMembers => class1544_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "groupMembers")
				{
					class1544_0 = new Class1544(reader);
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
				case "id":
					int_1 = XmlConvert.ToInt32(reader.Value);
					break;
				case "uniqueParent":
					string_3 = reader.Value;
					break;
				case "caption":
					string_2 = reader.Value;
					break;
				case "uniqueName":
					string_1 = reader.Value;
					break;
				case "name":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1562(XmlReader reader)
		: base(reader)
	{
	}

	public Class1562()
	{
	}

	protected override void vmethod_1()
	{
		int_1 = 0;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
		class1544_0 = new Class1544();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("name", string_0);
		writer.WriteAttributeString("uniqueName", string_1);
		writer.WriteAttributeString("caption", string_2);
		if (string_3 != null)
		{
			writer.WriteAttributeString("uniqueParent", string_3);
		}
		if (int_1 != 0)
		{
			writer.WriteAttributeString("id", XmlConvert.ToString(int_1));
		}
		class1544_0.vmethod_4("ssml", writer, "groupMembers");
		writer.WriteEndElement();
	}
}
