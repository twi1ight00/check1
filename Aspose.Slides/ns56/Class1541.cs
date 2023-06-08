using System;
using System.Xml;

namespace ns56;

internal class Class1541 : Class1351
{
	public delegate Class1541 Delegate502();

	public delegate void Delegate503(Class1541 elementData);

	public delegate void Delegate504(Class1541 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public Class1545.Delegate514 delegate514_0;

	public Class1545.Delegate516 delegate516_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private string string_0;

	private string string_1;

	private bool bool_2;

	private bool bool_3;

	private Class1545 class1545_0;

	private Class1502 class1502_0;

	public string UniqueName
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

	public string Caption
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

	public bool User
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool CustomRollUp
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public Class1545 Groups => class1545_0;

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
				case "groups":
					class1545_0 = new Class1545(reader);
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
				case "customRollUp":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "user":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "caption":
					string_1 = reader.Value;
					break;
				case "uniqueName":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1541(XmlReader reader)
		: base(reader)
	{
	}

	public Class1541()
	{
	}

	protected override void vmethod_1()
	{
		bool_2 = false;
		bool_3 = false;
	}

	protected override void vmethod_2()
	{
		delegate514_0 = method_3;
		delegate516_0 = method_4;
		delegate385_0 = method_5;
		delegate387_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("uniqueName", string_0);
		writer.WriteAttributeString("caption", string_1);
		if (bool_2)
		{
			writer.WriteAttributeString("user", bool_2 ? "1" : "0");
		}
		if (bool_3)
		{
			writer.WriteAttributeString("customRollUp", bool_3 ? "1" : "0");
		}
		if (class1545_0 != null)
		{
			class1545_0.vmethod_4("ssml", writer, "groups");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1545 method_3()
	{
		if (class1545_0 != null)
		{
			throw new Exception("Only one <groups> element can be added.");
		}
		class1545_0 = new Class1545();
		return class1545_0;
	}

	private void method_4(Class1545 _groups)
	{
		class1545_0 = _groups;
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
