using System;
using System.Xml;

namespace ns56;

internal class Class1354 : Class1351
{
	public delegate Class1354 Delegate24();

	public delegate void Delegate25(Class1354 elementData);

	public delegate void Delegate26(Class1354 elementData);

	public Class1953.Delegate1726 delegate1726_0;

	public Class1953.Delegate1728 delegate1728_0;

	private Class1953 class1953_0;

	private string string_0;

	public Class1953 RPr => class1953_0;

	public string T
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
			switch (reader.LocalName)
			{
			case "t":
				string_0 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_0 += reader.ReadString();
					}
				}
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
	}

	public Class1354(XmlReader reader)
		: base(reader)
	{
	}

	public Class1354()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate1726_0 = method_3;
		delegate1728_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1953_0 != null)
		{
			class1953_0.vmethod_4("a", writer, "rPr");
		}
		method_1("a", writer, "t", string_0);
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
}
