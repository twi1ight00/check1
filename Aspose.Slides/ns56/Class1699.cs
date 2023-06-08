using System;
using System.Xml;

namespace ns56;

internal class Class1699 : Class1351
{
	public delegate Class1699 Delegate976();

	public delegate void Delegate977(Class1699 elementData);

	public delegate void Delegate978(Class1699 elementData);

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private uint uint_0;

	private string string_0;

	private uint uint_1;

	private Class1751 class1751_0;

	private Class1502 class1502_0;

	public uint Id
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

	public string R
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

	public uint ConnectionId
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public Class1751 XmlCellPr => class1751_0;

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
				case "xmlCellPr":
					class1751_0 = new Class1751(reader);
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
				case "connectionId":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "r":
					string_0 = reader.Value;
					break;
				case "id":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1699(XmlReader reader)
		: base(reader)
	{
	}

	public Class1699()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate385_0 = method_3;
		delegate387_0 = method_4;
	}

	protected override void vmethod_3()
	{
		class1751_0 = new Class1751();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("id", XmlConvert.ToString(uint_0));
		writer.WriteAttributeString("r", string_0);
		writer.WriteAttributeString("connectionId", XmlConvert.ToString(uint_1));
		class1751_0.vmethod_4("ssml", writer, "xmlCellPr");
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
