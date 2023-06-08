using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1429 : Class1351
{
	public delegate void Delegate250(Class1429 elementData);

	public delegate Class1429 Delegate249();

	public delegate void Delegate251(Class1429 elementData);

	public const bool bool_0 = false;

	public Class1406.Delegate180 delegate180_0;

	public Class1406.Delegate181 delegate181_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private bool bool_1;

	private string string_0;

	private List<Class1406> list_0;

	private Class1502 class1502_0;

	public bool Pivot
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public string Sqref
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

	public Class1406[] CfRuleList => list_0.ToArray();

	public Class1502 ExtLst => class1502_0;

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
				case "extLst":
					class1502_0 = new Class1502(reader);
					break;
				case "cfRule":
				{
					Class1406 item = new Class1406(reader);
					list_0.Add(item);
					break;
				}
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
				case "sqref":
					string_0 = reader.Value;
					break;
				case "pivot":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1429(XmlReader reader)
		: base(reader)
	{
	}

	public Class1429()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
		list_0 = new List<Class1406>();
	}

	protected override void vmethod_2()
	{
		delegate180_0 = method_3;
		delegate181_0 = method_4;
		delegate385_0 = method_5;
		delegate387_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (bool_1)
		{
			writer.WriteAttributeString("pivot", bool_1 ? "1" : "0");
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("sqref", string_0);
		}
		foreach (Class1406 item in list_0)
		{
			item.vmethod_4("ssml", writer, "cfRule");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1406 method_3()
	{
		Class1406 @class = new Class1406();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1406 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1502 method_5()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_6(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
