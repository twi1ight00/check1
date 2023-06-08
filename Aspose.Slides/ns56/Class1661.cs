using System;
using System.Xml;

namespace ns56;

internal class Class1661 : Class1351
{
	public delegate Class1661 Delegate862();

	public delegate void Delegate863(Class1661 elementData);

	public delegate void Delegate864(Class1661 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = uint.MaxValue;

	public Class1498.Delegate371 delegate371_0;

	public Class1498.Delegate373 delegate373_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private uint uint_2;

	private bool bool_2;

	private bool bool_3;

	private string string_0;

	private uint uint_3;

	private uint uint_4;

	private Class1498 class1498_0;

	private Class1502 class1502_0;

	public uint SheetId
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	public bool XfDxf
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

	public bool S
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

	public uint Start
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	public uint Length
	{
		get
		{
			return uint_4;
		}
		set
		{
			uint_4 = value;
		}
	}

	public Class1498 Dxf => class1498_0;

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
				case "dxf":
					class1498_0 = new Class1498(reader);
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
				case "sheetId":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "xfDxf":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "s":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "sqref":
					string_0 = reader.Value;
					break;
				case "start":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "length":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1661(XmlReader reader)
		: base(reader)
	{
	}

	public Class1661()
	{
	}

	protected override void vmethod_1()
	{
		bool_2 = false;
		bool_3 = false;
		uint_3 = uint.MaxValue;
		uint_4 = uint.MaxValue;
	}

	protected override void vmethod_2()
	{
		delegate371_0 = method_3;
		delegate373_0 = method_4;
		delegate385_0 = method_5;
		delegate387_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("sheetId", XmlConvert.ToString(uint_2));
		if (bool_2)
		{
			writer.WriteAttributeString("xfDxf", bool_2 ? "1" : "0");
		}
		if (bool_3)
		{
			writer.WriteAttributeString("s", bool_3 ? "1" : "0");
		}
		writer.WriteAttributeString("sqref", string_0);
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("start", XmlConvert.ToString(uint_3));
		}
		if (uint_4 != uint.MaxValue)
		{
			writer.WriteAttributeString("length", XmlConvert.ToString(uint_4));
		}
		if (class1498_0 != null)
		{
			class1498_0.vmethod_4("ssml", writer, "dxf");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1498 method_3()
	{
		if (class1498_0 != null)
		{
			throw new Exception("Only one <dxf> element can be added.");
		}
		class1498_0 = new Class1498();
		return class1498_0;
	}

	private void method_4(Class1498 _dxf)
	{
		class1498_0 = _dxf;
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
