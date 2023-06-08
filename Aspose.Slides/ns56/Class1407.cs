using System;
using System.Xml;

namespace ns56;

internal class Class1407 : Class1351
{
	public delegate Class1407 Delegate183();

	public delegate void Delegate184(Class1407 elementData);

	public delegate void Delegate185(Class1407 elementData);

	public const bool bool_0 = true;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private Enum190 enum190_0;

	private string string_0;

	private bool bool_1;

	private Class1502 class1502_0;

	public Enum190 Type
	{
		get
		{
			return enum190_0;
		}
		set
		{
			enum190_0 = value;
		}
	}

	public string Val
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

	public bool Gte
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
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "extLst")
				{
					class1502_0 = new Class1502(reader);
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
				case "gte":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "val":
					string_0 = reader.Value;
					break;
				case "type":
					enum190_0 = Class2357.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1407(XmlReader reader)
		: base(reader)
	{
	}

	public Class1407()
	{
	}

	protected override void vmethod_1()
	{
		enum190_0 = Enum190.const_0;
		bool_1 = true;
	}

	protected override void vmethod_2()
	{
		delegate385_0 = method_3;
		delegate387_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("type", Class2357.smethod_1(enum190_0));
		if (string_0 != null)
		{
			writer.WriteAttributeString("val", string_0);
		}
		if (!bool_1)
		{
			writer.WriteAttributeString("gte", bool_1 ? "1" : "0");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1502 method_3()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_4(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
