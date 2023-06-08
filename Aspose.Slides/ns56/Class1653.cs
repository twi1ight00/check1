using System;
using System.Xml;

namespace ns56;

internal class Class1653 : Class1351
{
	public delegate Class1653 Delegate838();

	public delegate void Delegate839(Class1653 elementData);

	public delegate void Delegate840(Class1653 elementData);

	public Class1675.Delegate904 delegate904_0;

	public Class1675.Delegate906 delegate906_0;

	private Class1675 class1675_0;

	private string string_0;

	public Class1675 RPr => class1675_0;

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
				class1675_0 = new Class1675(reader);
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

	public Class1653(XmlReader reader)
		: base(reader)
	{
	}

	public Class1653()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate904_0 = method_3;
		delegate906_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1675_0 != null)
		{
			class1675_0.vmethod_4("ssml", writer, "rPr");
		}
		method_1("ssml", writer, "t", string_0);
		writer.WriteEndElement();
	}

	private Class1675 method_3()
	{
		if (class1675_0 != null)
		{
			throw new Exception("Only one <rPr> element can be added.");
		}
		class1675_0 = new Class1675();
		return class1675_0;
	}

	private void method_4(Class1675 _rPr)
	{
		class1675_0 = _rPr;
	}
}
