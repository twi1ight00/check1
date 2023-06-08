using System;
using System.Xml;

namespace ns56;

internal class Class1753 : Class1351
{
	public delegate Class1753 Delegate1138();

	public delegate void Delegate1139(Class1753 elementData);

	public delegate void Delegate1140(Class1753 elementData);

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private uint uint_0;

	private string string_0;

	private Enum260 enum260_0;

	private Class1502 class1502_0;

	public uint MapId
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public string Xpath
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

	public Enum260 XmlDataType
	{
		get
		{
			return enum260_0;
		}
		set
		{
			enum260_0 = value;
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
				case "xmlDataType":
					enum260_0 = Class2427.smethod_0(reader.Value);
					break;
				case "xpath":
					string_0 = reader.Value;
					break;
				case "mapId":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1753(XmlReader reader)
		: base(reader)
	{
	}

	public Class1753()
	{
	}

	protected override void vmethod_1()
	{
		enum260_0 = Enum260.const_0;
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
		writer.WriteAttributeString("mapId", XmlConvert.ToString(uint_0));
		writer.WriteAttributeString("xpath", string_0);
		writer.WriteAttributeString("xmlDataType", Class2427.smethod_1(enum260_0));
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
