using System;
using System.Xml;

namespace ns56;

internal class Class1488 : Class1351
{
	public delegate Class1488 Delegate341();

	public delegate void Delegate342(Class1488 elementData);

	public delegate void Delegate343(Class1488 elementData);

	public Class1487.Delegate338 delegate338_0;

	public Class1487.Delegate340 delegate340_0;

	private string string_0;

	private string string_1;

	private Class1487 class1487_0;

	public string DdeService
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

	public string DdeTopic
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

	public Class1487 DdeItems => class1487_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "ddeItems")
				{
					class1487_0 = new Class1487(reader);
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
				case "ddeTopic":
					string_1 = reader.Value;
					break;
				case "ddeService":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1488(XmlReader reader)
		: base(reader)
	{
	}

	public Class1488()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate338_0 = method_3;
		delegate340_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("ddeService", string_0);
		writer.WriteAttributeString("ddeTopic", string_1);
		if (class1487_0 != null)
		{
			class1487_0.vmethod_4("ssml", writer, "ddeItems");
		}
		writer.WriteEndElement();
	}

	private Class1487 method_3()
	{
		if (class1487_0 != null)
		{
			throw new Exception("Only one <ddeItems> element can be added.");
		}
		class1487_0 = new Class1487();
		return class1487_0;
	}

	private void method_4(Class1487 _ddeItems)
	{
		class1487_0 = _ddeItems;
	}
}
