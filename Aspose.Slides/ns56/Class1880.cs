using System;
using System.Xml;

namespace ns56;

internal class Class1880 : Class1351
{
	public delegate Class1880 Delegate1519();

	public delegate void Delegate1520(Class1880 elementData);

	public delegate void Delegate1521(Class1880 elementData);

	public const string string_0 = "";

	public const bool bool_0 = false;

	public Class1865.Delegate1474 delegate1474_0;

	public Class1865.Delegate1476 delegate1476_0;

	public Class1865.Delegate1474 delegate1474_1;

	public Class1865.Delegate1476 delegate1476_1;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private uint uint_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private bool bool_1;

	private Class1865 class1865_0;

	private Class1865 class1865_1;

	private Class1886 class1886_0;

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

	public string Descr
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public string Title
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public bool Hidden
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

	public Class1865 HlinkClick => class1865_0;

	public Class1865 HlinkHover => class1865_1;

	public Class1885 ExtLst => class1886_0;

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
					class1886_0 = new Class1886(reader);
					break;
				case "hlinkHover":
					class1865_1 = new Class1865(reader);
					break;
				case "hlinkClick":
					class1865_0 = new Class1865(reader);
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
				case "hidden":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "title":
					string_3 = reader.Value;
					break;
				case "descr":
					string_2 = reader.Value;
					break;
				case "name":
					string_1 = reader.Value;
					break;
				case "id":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1880(XmlReader reader)
		: base(reader)
	{
	}

	public Class1880()
	{
	}

	protected override void vmethod_1()
	{
		string_2 = "";
		bool_1 = false;
	}

	protected override void vmethod_2()
	{
		delegate1474_0 = method_3;
		delegate1476_0 = method_4;
		delegate1474_1 = method_5;
		delegate1476_1 = method_6;
		delegate1534_0 = method_7;
		delegate1535_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("id", XmlConvert.ToString(uint_0));
		writer.WriteAttributeString("name", string_1);
		if (string_2 != "")
		{
			writer.WriteAttributeString("descr", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("title", string_3);
		}
		if (bool_1)
		{
			writer.WriteAttributeString("hidden", bool_1 ? "1" : "0");
		}
		if (class1865_0 != null)
		{
			class1865_0.vmethod_4("a", writer, "hlinkClick");
		}
		if (class1865_1 != null)
		{
			class1865_1.vmethod_4("a", writer, "hlinkHover");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1865 method_3()
	{
		if (class1865_0 != null)
		{
			throw new Exception("Only one <hlinkClick> element can be added.");
		}
		class1865_0 = new Class1865();
		return class1865_0;
	}

	private void method_4(Class1865 _hlinkClick)
	{
		class1865_0 = _hlinkClick;
	}

	private Class1865 method_5()
	{
		if (class1865_1 != null)
		{
			throw new Exception("Only one <hlinkHover> element can be added.");
		}
		class1865_1 = new Class1865();
		return class1865_1;
	}

	private void method_6(Class1865 _hlinkHover)
	{
		class1865_1 = _hlinkHover;
	}

	private Class1885 method_7()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_8(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
