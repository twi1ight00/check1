using System;
using System.Xml;

namespace ns56;

internal class Class1780 : Class1351
{
	public delegate Class1780 Delegate1219();

	public delegate void Delegate1220(Class1780 elementData);

	public delegate void Delegate1221(Class1780 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private string string_0;

	private string string_1;

	private Class2605 class2605_0;

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

	public string Value
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

	public Class2605 FontOrPicture
	{
		get
		{
			return class2605_0;
		}
		set
		{
			class2605_0 = value;
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
			if (reader.NodeType == XmlNodeType.Element)
			{
				switch (reader.LocalName)
				{
				case "picture":
					class2605_0 = new Class2605("picture", new Class1781(reader));
					break;
				case "font":
					class2605_0 = new Class2605("font", new Class1779(reader));
					break;
				default:
					reader.Skip();
					flag = true;
					break;
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
				case "value":
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

	public Class1780(XmlReader reader)
		: base(reader)
	{
	}

	public Class1780()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2773_0 = method_3;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("name", string_0);
		if (string_1 != null)
		{
			writer.WriteAttributeString("value", string_1);
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "picture":
				((Class1781)class2605_0.Object).vmethod_4("ax", writer, class2605_0.Name);
				break;
			case "font":
				((Class1779)class2605_0.Object).vmethod_4("ax", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("FontOrPicture already is initialized.");
		}
		switch (elementName)
		{
		case "picture":
			class2605_0 = new Class2605("picture", new Class1781());
			break;
		case "font":
			class2605_0 = new Class2605("font", new Class1779());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
