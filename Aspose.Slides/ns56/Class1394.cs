using System;
using System.Xml;

namespace ns56;

internal class Class1394 : Class1351
{
	public delegate Class1394 Delegate144();

	public delegate void Delegate145(Class1394 elementData);

	public delegate void Delegate146(Class1394 elementData);

	public const uint uint_0 = 0u;

	public const uint uint_1 = 0u;

	public const uint uint_2 = 0u;

	public const bool bool_0 = false;

	public Class1395.Delegate147 delegate147_0;

	public Class1395.Delegate149 delegate149_0;

	public Class1676.Delegate907 delegate907_0;

	public Class1676.Delegate909 delegate909_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private string string_0;

	private uint uint_3;

	private Enum262 enum262_0;

	private uint uint_4;

	private uint uint_5;

	private bool bool_1;

	private Class1395 class1395_0;

	private string string_1;

	private Class1676 class1676_0;

	private Class1502 class1502_0;

	public static readonly Enum262 enum262_1 = Class2355.smethod_0("n");

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

	public uint S
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

	public Enum262 T
	{
		get
		{
			return enum262_0;
		}
		set
		{
			enum262_0 = value;
		}
	}

	public uint Cm
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

	public uint Vm
	{
		get
		{
			return uint_5;
		}
		set
		{
			uint_5 = value;
		}
	}

	public bool Ph
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

	public Class1395 F => class1395_0;

	public string V
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

	public Class1676 Is => class1676_0;

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
			if (reader.NodeType != XmlNodeType.Element)
			{
				continue;
			}
			switch (reader.LocalName)
			{
			case "extLst":
				class1502_0 = new Class1502(reader);
				break;
			case "is":
				class1676_0 = new Class1676(reader);
				break;
			case "v":
				string_1 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_1 += reader.ReadString();
					}
				}
				break;
			case "f":
				class1395_0 = new Class1395(reader);
				break;
			default:
				reader.Skip();
				flag = true;
				break;
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
				case "r":
					string_0 = reader.Value;
					break;
				case "s":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "t":
					enum262_0 = Class2355.smethod_0(reader.Value);
					break;
				case "cm":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "vm":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "ph":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1394(XmlReader reader)
		: base(reader)
	{
	}

	public Class1394()
	{
	}

	protected override void vmethod_1()
	{
		uint_3 = 0u;
		enum262_0 = enum262_1;
		uint_4 = 0u;
		uint_5 = 0u;
		bool_1 = false;
	}

	protected override void vmethod_2()
	{
		delegate147_0 = method_3;
		delegate149_0 = method_4;
		delegate907_0 = method_5;
		delegate909_0 = method_6;
		delegate385_0 = method_7;
		delegate387_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_0 != null)
		{
			writer.WriteAttributeString("r", string_0);
		}
		if (uint_3 != 0)
		{
			writer.WriteAttributeString("s", XmlConvert.ToString(uint_3));
		}
		if (enum262_0 != enum262_1)
		{
			writer.WriteAttributeString("t", Class2355.smethod_1(enum262_0));
		}
		if (uint_4 != 0)
		{
			writer.WriteAttributeString("cm", XmlConvert.ToString(uint_4));
		}
		if (uint_5 != 0)
		{
			writer.WriteAttributeString("vm", XmlConvert.ToString(uint_5));
		}
		if (bool_1)
		{
			writer.WriteAttributeString("ph", bool_1 ? "1" : "0");
		}
		if (class1395_0 != null)
		{
			class1395_0.vmethod_4("ssml", writer, "f");
		}
		if (string_1 != null)
		{
			method_1("ssml", writer, "v", string_1);
		}
		if (class1676_0 != null)
		{
			class1676_0.vmethod_4("ssml", writer, "is");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1395 method_3()
	{
		if (class1395_0 != null)
		{
			throw new Exception("Only one <f> element can be added.");
		}
		class1395_0 = new Class1395();
		return class1395_0;
	}

	private void method_4(Class1395 _f)
	{
		class1395_0 = _f;
	}

	private Class1676 method_5()
	{
		if (class1676_0 != null)
		{
			throw new Exception("Only one <is> element can be added.");
		}
		class1676_0 = new Class1676();
		return class1676_0;
	}

	private void method_6(Class1676 _is)
	{
		class1676_0 = _is;
	}

	private Class1502 method_7()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_8(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
