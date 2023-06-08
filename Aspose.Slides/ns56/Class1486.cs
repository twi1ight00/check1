using System;
using System.Xml;

namespace ns56;

internal class Class1486 : Class1351
{
	public delegate Class1486 Delegate335();

	public delegate void Delegate336(Class1486 elementData);

	public delegate void Delegate337(Class1486 elementData);

	public const string string_0 = "0";

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public Class1490.Delegate347 delegate347_0;

	public Class1490.Delegate349 delegate349_0;

	private string string_1;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private Class1490 class1490_0;

	public string Name
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

	public bool Ole
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

	public bool Advise
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool PreferPic
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public Class1490 Values => class1490_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "values")
				{
					class1490_0 = new Class1490(reader);
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
				case "preferPic":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "advise":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "ole":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "name":
					string_1 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1486(XmlReader reader)
		: base(reader)
	{
	}

	public Class1486()
	{
	}

	protected override void vmethod_1()
	{
		string_1 = "0";
		bool_3 = false;
		bool_4 = false;
		bool_5 = false;
	}

	protected override void vmethod_2()
	{
		delegate347_0 = method_3;
		delegate349_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_1 != "0")
		{
			writer.WriteAttributeString("name", string_1);
		}
		if (bool_3)
		{
			writer.WriteAttributeString("ole", bool_3 ? "1" : "0");
		}
		if (bool_4)
		{
			writer.WriteAttributeString("advise", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("preferPic", bool_5 ? "1" : "0");
		}
		if (class1490_0 != null)
		{
			class1490_0.vmethod_4("ssml", writer, "values");
		}
		writer.WriteEndElement();
	}

	private Class1490 method_3()
	{
		if (class1490_0 != null)
		{
			throw new Exception("Only one <values> element can be added.");
		}
		class1490_0 = new Class1490();
		return class1490_0;
	}

	private void method_4(Class1490 _values)
	{
		class1490_0 = _values;
	}
}
