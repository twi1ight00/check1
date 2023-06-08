using System;
using System.Xml;

namespace ns56;

internal class Class1955 : Class1351
{
	public delegate Class1955 Delegate1732();

	public delegate void Delegate1733(Class1955 elementData);

	public delegate void Delegate1734(Class1955 elementData);

	public Class1953.Delegate1726 delegate1726_0;

	public Class1953.Delegate1728 delegate1728_0;

	public Class1963.Delegate1756 delegate1756_0;

	public Class1963.Delegate1758 delegate1758_0;

	private Guid guid_0;

	private string string_0;

	private Class1953 class1953_0;

	private Class1963 class1963_0;

	private string string_1;

	public Guid Id
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

	public string Type
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

	public Class1953 RPr => class1953_0;

	public Class1963 PPr => class1963_0;

	public string T
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
			switch (reader.LocalName)
			{
			case "t":
				string_1 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_1 += reader.ReadString();
					}
				}
				break;
			case "pPr":
				class1963_0 = new Class1963(reader);
				break;
			case "rPr":
				class1953_0 = new Class1953(reader);
				break;
			default:
				reader.Skip();
				flag = true;
				break;
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
				case "type":
					string_0 = reader.Value;
					break;
				case "id":
					guid_0 = new Guid(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1955(XmlReader reader)
		: base(reader)
	{
	}

	public Class1955()
	{
	}

	protected override void vmethod_1()
	{
		guid_0 = Guid.Empty;
	}

	protected override void vmethod_2()
	{
		delegate1726_0 = method_3;
		delegate1728_0 = method_4;
		delegate1756_0 = method_5;
		delegate1758_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("id", "{" + XmlConvert.ToString(guid_0).ToUpper() + "}");
		if (string_0 != null)
		{
			writer.WriteAttributeString("type", string_0);
		}
		if (class1953_0 != null)
		{
			class1953_0.vmethod_4("a", writer, "rPr");
		}
		if (class1963_0 != null)
		{
			class1963_0.vmethod_4("a", writer, "pPr");
		}
		if (string_1 != null)
		{
			method_1("a", writer, "t", string_1);
		}
		writer.WriteEndElement();
	}

	private Class1953 method_3()
	{
		if (class1953_0 != null)
		{
			throw new Exception("Only one <rPr> element can be added.");
		}
		class1953_0 = new Class1953();
		return class1953_0;
	}

	private void method_4(Class1953 _rPr)
	{
		class1953_0 = _rPr;
	}

	private Class1963 method_5()
	{
		if (class1963_0 != null)
		{
			throw new Exception("Only one <pPr> element can be added.");
		}
		class1963_0 = new Class1963();
		return class1963_0;
	}

	private void method_6(Class1963 _pPr)
	{
		class1963_0 = _pPr;
	}
}
