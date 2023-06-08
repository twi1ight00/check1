using System.Xml;

namespace ns56;

internal class Class1823 : Class1351
{
	public delegate Class1823 Delegate1348();

	public delegate void Delegate1349(Class1823 elementData);

	public delegate void Delegate1350(Class1823 elementData);

	private string string_0;

	private Class1782 class1782_0;

	public string Ang
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

	public Class1782 Pos => class1782_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "pos")
				{
					class1782_0 = new Class1782(reader);
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
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "ang")
			{
				string_0 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class1823(XmlReader reader)
		: base(reader)
	{
	}

	public Class1823()
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
		class1782_0 = new Class1782();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("ang", string_0);
		class1782_0.vmethod_4("a", writer, "pos");
		writer.WriteEndElement();
	}
}
