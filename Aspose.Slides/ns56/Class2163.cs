using System;
using System.Xml;

namespace ns56;

internal class Class2163 : Class1351
{
	public delegate void Delegate2222(Class2163 elementData);

	public delegate Class2163 Delegate2221();

	public delegate void Delegate2223(Class2163 elementData);

	public const string string_0 = "0";

	public const string string_1 = "0";

	public const string string_2 = "";

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private string string_3;

	private Enum330 enum330_0;

	private string string_4;

	private string string_5;

	private uint uint_0;

	private uint uint_1;

	private string string_6;

	private string string_7;

	private string string_8;

	private Class1886 class1886_0;

	public static readonly Enum330 enum330_1 = Class2461.smethod_0("parOf");

	public string ModelId
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

	public Enum330 Type
	{
		get
		{
			return enum330_0;
		}
		set
		{
			enum330_0 = value;
		}
	}

	public string SrcId
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public string DestId
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public uint SrcOrd
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

	public uint DestOrd
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

	public string ParTransId
	{
		get
		{
			return string_6;
		}
		set
		{
			string_6 = value;
		}
	}

	public string SibTransId
	{
		get
		{
			return string_7;
		}
		set
		{
			string_7 = value;
		}
	}

	public string PresId
	{
		get
		{
			return string_8;
		}
		set
		{
			string_8 = value;
		}
	}

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
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "extLst")
				{
					class1886_0 = new Class1886(reader);
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
				case "modelId":
					string_3 = reader.Value;
					break;
				case "type":
					enum330_0 = Class2461.smethod_0(reader.Value);
					break;
				case "srcId":
					string_4 = reader.Value;
					break;
				case "destId":
					string_5 = reader.Value;
					break;
				case "srcOrd":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "destOrd":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "parTransId":
					string_6 = reader.Value;
					break;
				case "sibTransId":
					string_7 = reader.Value;
					break;
				case "presId":
					string_8 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2163(XmlReader reader)
		: base(reader)
	{
	}

	public Class2163()
	{
	}

	protected override void vmethod_1()
	{
		enum330_0 = enum330_1;
		string_6 = "0";
		string_7 = "0";
		string_8 = "";
	}

	protected override void vmethod_2()
	{
		delegate1534_0 = method_3;
		delegate1535_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("modelId", string_3);
		if (enum330_0 != enum330_1)
		{
			writer.WriteAttributeString("type", Class2461.smethod_1(enum330_0));
		}
		writer.WriteAttributeString("srcId", string_4);
		writer.WriteAttributeString("destId", string_5);
		writer.WriteAttributeString("srcOrd", XmlConvert.ToString(uint_0));
		writer.WriteAttributeString("destOrd", XmlConvert.ToString(uint_1));
		if (string_6 != "0")
		{
			writer.WriteAttributeString("parTransId", string_6);
		}
		if (string_7 != "0")
		{
			writer.WriteAttributeString("sibTransId", string_7);
		}
		if (string_8 != "")
		{
			writer.WriteAttributeString("presId", string_8);
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("dgm", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1885 method_3()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_4(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}
}
