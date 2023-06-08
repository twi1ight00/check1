using System;
using System.Xml;

namespace ns56;

internal class Class1598 : Class1351
{
	public delegate Class1598 Delegate673();

	public delegate void Delegate674(Class1598 elementData);

	public delegate void Delegate675(Class1598 elementData);

	public Class1597.Delegate670 delegate670_0;

	public Class1597.Delegate672 delegate672_0;

	private string string_0;

	private string string_1;

	private Class1597 class1597_0;

	public string R_Id
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

	public string ProgId
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

	public Class1597 OleItems => class1597_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "oleItems")
				{
					class1597_0 = new Class1597(reader);
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
				case "progId":
					string_1 = reader.Value;
					break;
				case "r:id":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1598(XmlReader reader)
		: base(reader)
	{
	}

	public Class1598()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate670_0 = method_3;
		delegate672_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("r:id", string_0);
		writer.WriteAttributeString("progId", string_1);
		if (class1597_0 != null)
		{
			class1597_0.vmethod_4("ssml", writer, "oleItems");
		}
		writer.WriteEndElement();
	}

	private Class1597 method_3()
	{
		if (class1597_0 != null)
		{
			throw new Exception("Only one <oleItems> element can be added.");
		}
		class1597_0 = new Class1597();
		return class1597_0;
	}

	private void method_4(Class1597 _oleItems)
	{
		class1597_0 = _oleItems;
	}
}
