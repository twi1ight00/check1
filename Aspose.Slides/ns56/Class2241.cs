using System.Xml;

namespace ns56;

internal class Class2241 : Class1351
{
	public delegate void Delegate2469(Class2241 elementData);

	public delegate Class2241 Delegate2467();

	public delegate void Delegate2468(Class2241 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = uint.MaxValue;

	private Enum356 enum356_0;

	private Enum354 enum354_0;

	private Enum355 enum355_0;

	private uint uint_2;

	private uint uint_3;

	private string string_0;

	private string string_1;

	private string string_2;

	private uint uint_4;

	private string string_3;

	private uint uint_5;

	private string string_4;

	public Enum356 CryptProviderType
	{
		get
		{
			return enum356_0;
		}
		set
		{
			enum356_0 = value;
		}
	}

	public Enum354 CryptAlgorithmClass
	{
		get
		{
			return enum354_0;
		}
		set
		{
			enum354_0 = value;
		}
	}

	public Enum355 CryptAlgorithmType
	{
		get
		{
			return enum355_0;
		}
		set
		{
			enum355_0 = value;
		}
	}

	public uint CryptAlgorithmSid
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

	public uint SpinCount
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

	public string SaltData
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

	public string HashData
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

	public string CryptProvider
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

	public uint AlgIdExt
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

	public string AlgIdExtSource
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

	public uint CryptProviderTypeExt
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

	public string CryptProviderTypeExtSource
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
				_ = reader.LocalName;
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
				case "cryptProviderType":
					enum356_0 = Class2492.smethod_0(reader.Value);
					break;
				case "cryptAlgorithmClass":
					enum354_0 = Class2490.smethod_0(reader.Value);
					break;
				case "cryptAlgorithmType":
					enum355_0 = Class2491.smethod_0(reader.Value);
					break;
				case "cryptAlgorithmSid":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "spinCount":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "saltData":
					string_0 = reader.Value;
					break;
				case "hashData":
					string_1 = reader.Value;
					break;
				case "cryptProvider":
					string_2 = reader.Value;
					break;
				case "algIdExt":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "algIdExtSource":
					string_3 = reader.Value;
					break;
				case "cryptProviderTypeExt":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "cryptProviderTypeExtSource":
					string_4 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2241(XmlReader reader)
		: base(reader)
	{
	}

	public Class2241()
	{
	}

	protected override void vmethod_1()
	{
		enum356_0 = Enum356.const_0;
		enum354_0 = Enum354.const_0;
		enum355_0 = Enum355.const_0;
		uint_4 = uint.MaxValue;
		uint_5 = uint.MaxValue;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("cryptProviderType", Class2492.smethod_1(enum356_0));
		writer.WriteAttributeString("cryptAlgorithmClass", Class2490.smethod_1(enum354_0));
		writer.WriteAttributeString("cryptAlgorithmType", Class2491.smethod_1(enum355_0));
		writer.WriteAttributeString("cryptAlgorithmSid", XmlConvert.ToString(uint_2));
		writer.WriteAttributeString("spinCount", XmlConvert.ToString(uint_3));
		writer.WriteAttributeString("saltData", string_0);
		writer.WriteAttributeString("hashData", string_1);
		if (string_2 != null)
		{
			writer.WriteAttributeString("cryptProvider", string_2);
		}
		if (uint_4 != uint.MaxValue)
		{
			writer.WriteAttributeString("algIdExt", XmlConvert.ToString(uint_4));
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("algIdExtSource", string_3);
		}
		if (uint_5 != uint.MaxValue)
		{
			writer.WriteAttributeString("cryptProviderTypeExt", XmlConvert.ToString(uint_5));
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("cryptProviderTypeExtSource", string_4);
		}
		writer.WriteEndElement();
	}
}
