using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1400 : Class1351
{
	public delegate Class1400 Delegate162();

	public delegate void Delegate163(Class1400 elementData);

	public delegate void Delegate164(Class1400 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = uint.MaxValue;

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const NullableBool nullableBool_1 = NullableBool.NotDefined;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private string string_0;

	private uint uint_2;

	private uint uint_3;

	private uint uint_4;

	private NullableBool nullableBool_2;

	private NullableBool nullableBool_3;

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

	public uint XfId
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

	public uint BuiltinId
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

	public uint ILevel
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

	public NullableBool Hidden
	{
		get
		{
			return nullableBool_2;
		}
		set
		{
			nullableBool_2 = value;
		}
	}

	public NullableBool CustomBuiltin
	{
		get
		{
			return nullableBool_3;
		}
		set
		{
			nullableBool_3 = value;
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
				case "name":
					string_0 = reader.Value;
					break;
				case "xfId":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "builtinId":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "iLevel":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "hidden":
					nullableBool_2 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "customBuiltin":
					nullableBool_3 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1400(XmlReader reader)
		: base(reader)
	{
	}

	public Class1400()
	{
	}

	protected override void vmethod_1()
	{
		uint_3 = uint.MaxValue;
		uint_4 = uint.MaxValue;
		nullableBool_2 = NullableBool.NotDefined;
		nullableBool_3 = NullableBool.NotDefined;
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
		if (string_0 != null)
		{
			writer.WriteAttributeString("name", string_0);
		}
		writer.WriteAttributeString("xfId", XmlConvert.ToString(uint_2));
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("builtinId", XmlConvert.ToString(uint_3));
		}
		if (uint_4 != uint.MaxValue)
		{
			writer.WriteAttributeString("iLevel", XmlConvert.ToString(uint_4));
		}
		if (nullableBool_2 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("hidden", (nullableBool_2 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_3 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("customBuiltin", (nullableBool_3 == NullableBool.True) ? "1" : "0");
		}
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
