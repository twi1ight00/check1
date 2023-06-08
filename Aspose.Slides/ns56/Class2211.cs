using System;
using System.Xml;

namespace ns56;

internal class Class2211 : Class1351
{
	public delegate Class2211 Delegate2369();

	public delegate void Delegate2370(Class2211 elementData);

	public delegate void Delegate2371(Class2211 elementData);

	public const Enum362 enum362_0 = Enum362.const_0;

	public const Enum352 enum352_0 = Enum352.const_0;

	public const Enum352 enum352_1 = Enum352.const_0;

	public const Enum352 enum352_2 = Enum352.const_0;

	public const Enum352 enum352_3 = Enum352.const_0;

	private Enum362 enum362_1;

	private Enum352 enum352_4;

	private Guid guid_0;

	private Guid guid_1;

	private Enum352 enum352_5;

	private Enum352 enum352_6;

	private Enum352 enum352_7;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	public static readonly Guid guid_2 = Guid.Empty;

	public static readonly Guid guid_3 = Guid.Empty;

	public Enum362 V_Ext
	{
		get
		{
			return enum362_1;
		}
		set
		{
			enum362_1 = value;
		}
	}

	public Enum352 Issignatureline
	{
		get
		{
			return enum352_4;
		}
		set
		{
			enum352_4 = value;
		}
	}

	public Guid Id
	{
		get
		{
			return guid_0;
		}
		set
		{
			guid_0 = value;
		}
	}

	public Guid Provid
	{
		get
		{
			return guid_1;
		}
		set
		{
			guid_1 = value;
		}
	}

	public Enum352 Signinginstructionsset
	{
		get
		{
			return enum352_5;
		}
		set
		{
			enum352_5 = value;
		}
	}

	public Enum352 Allowcomments
	{
		get
		{
			return enum352_6;
		}
		set
		{
			enum352_6 = value;
		}
	}

	public Enum352 Showsigndate
	{
		get
		{
			return enum352_7;
		}
		set
		{
			enum352_7 = value;
		}
	}

	public string Suggestedsigner
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

	public string Suggestedsigner2
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

	public string Suggestedsigneremail
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

	public string Signinginstructions
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

	public string Addlxml
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

	public string Sigprovurl
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
				case "v:ext":
					enum362_1 = Class2498.smethod_0(reader.Value);
					break;
				case "issignatureline":
					enum352_4 = Class2488.smethod_0(reader.Value);
					break;
				case "id":
					guid_0 = new Guid(reader.Value);
					break;
				case "provid":
					guid_1 = new Guid(reader.Value);
					break;
				case "signinginstructionsset":
					enum352_5 = Class2488.smethod_0(reader.Value);
					break;
				case "allowcomments":
					enum352_6 = Class2488.smethod_0(reader.Value);
					break;
				case "showsigndate":
					enum352_7 = Class2488.smethod_0(reader.Value);
					break;
				case "suggestedsigner":
					string_0 = reader.Value;
					break;
				case "suggestedsigner2":
					string_1 = reader.Value;
					break;
				case "suggestedsigneremail":
					string_2 = reader.Value;
					break;
				case "signinginstructions":
					string_3 = reader.Value;
					break;
				case "addlxml":
					string_4 = reader.Value;
					break;
				case "sigprovurl":
					string_5 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2211(XmlReader reader)
		: base(reader)
	{
	}

	public Class2211()
	{
	}

	protected override void vmethod_1()
	{
		enum362_1 = Enum362.const_0;
		enum352_4 = Enum352.const_0;
		guid_0 = guid_2;
		guid_1 = guid_3;
		enum352_5 = Enum352.const_0;
		enum352_6 = Enum352.const_0;
		enum352_7 = Enum352.const_0;
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
		if (enum362_1 != 0)
		{
			writer.WriteAttributeString("v:ext", Class2498.smethod_1(enum362_1));
		}
		if (enum352_4 != 0)
		{
			writer.WriteAttributeString("issignatureline", Class2488.smethod_1(enum352_4));
		}
		if (guid_0 != guid_2)
		{
			writer.WriteAttributeString("id", "{" + XmlConvert.ToString(guid_0).ToUpper() + "}");
		}
		if (guid_1 != guid_3)
		{
			writer.WriteAttributeString("provid", "{" + XmlConvert.ToString(guid_1).ToUpper() + "}");
		}
		if (enum352_5 != 0)
		{
			writer.WriteAttributeString("signinginstructionsset", Class2488.smethod_1(enum352_5));
		}
		if (enum352_6 != 0)
		{
			writer.WriteAttributeString("allowcomments", Class2488.smethod_1(enum352_6));
		}
		if (enum352_7 != 0)
		{
			writer.WriteAttributeString("showsigndate", Class2488.smethod_1(enum352_7));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("suggestedsigner", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("suggestedsigner2", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("suggestedsigneremail", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("signinginstructions", string_3);
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("addlxml", string_4);
		}
		if (string_5 != null)
		{
			writer.WriteAttributeString("sigprovurl", string_5);
		}
		writer.WriteEndElement();
	}
}
