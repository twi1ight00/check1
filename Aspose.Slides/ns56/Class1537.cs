using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1537 : Class1351
{
	public delegate Class1537 Delegate490();

	public delegate void Delegate491(Class1537 elementData);

	public delegate void Delegate492(Class1537 elementData);

	public const uint uint_0 = 0u;

	public Class1536.Delegate487 delegate487_0;

	public Class1536.Delegate488 delegate488_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private string string_0;

	private uint uint_1;

	private List<Class1536> list_0;

	private Class1502 class1502_0;

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

	public uint Count
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

	public Class1536[] BkList => list_0.ToArray();

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
				case "bk":
				{
					Class1536 item = new Class1536(reader);
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
				case "count":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "name":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1537(XmlReader reader)
		: base(reader)
	{
	}

	public Class1537()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = 0u;
		list_0 = new List<Class1536>();
	}

	protected override void vmethod_2()
	{
		delegate487_0 = method_3;
		delegate488_0 = method_4;
		delegate385_0 = method_5;
		delegate387_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("name", string_0);
		if (uint_1 != 0)
		{
			writer.WriteAttributeString("count", XmlConvert.ToString(uint_1));
		}
		foreach (Class1536 item in list_0)
		{
			item.vmethod_4("ssml", writer, "bk");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1536 method_3()
	{
		Class1536 @class = new Class1536();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1536 elementData)
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
