using System;
using System.Xml;

namespace ns56;

internal class Class2278 : Class1351
{
	public delegate Class2278 Delegate2581();

	public delegate void Delegate2582(Class2278 elementData);

	public delegate void Delegate2583(Class2278 elementData);

	public const bool bool_0 = false;

	public const uint uint_0 = 1u;

	public const bool bool_1 = false;

	public const bool bool_2 = true;

	public const bool bool_3 = false;

	public const string string_0 = "indefinite";

	public Class2297.Delegate2638 delegate2638_0;

	public Class2297.Delegate2640 delegate2640_0;

	private string string_1;

	private uint uint_1;

	private bool bool_4;

	private Enum359 enum359_0;

	private uint uint_2;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private string string_2;

	private Class2297 class2297_0;

	public static readonly Enum359 enum359_1 = Class2495.smethod_0("whole");

	public string Spid
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

	public uint GrpId
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

	public bool UiExpand
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public Enum359 Build
	{
		get
		{
			return enum359_0;
		}
		set
		{
			enum359_0 = value;
		}
	}

	public uint BldLvl
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

	public bool AnimBg
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public bool AutoUpdateAnimBg
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public bool Rev
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
		}
	}

	public string AdvAuto
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

	public Class2297 TmplLst => class2297_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "tmplLst")
				{
					class2297_0 = new Class2297(reader);
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
				case "spid":
					string_1 = reader.Value;
					break;
				case "grpId":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "uiExpand":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "build":
					enum359_0 = Class2495.smethod_0(reader.Value);
					break;
				case "bldLvl":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "animBg":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "autoUpdateAnimBg":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "rev":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "advAuto":
					string_2 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2278(XmlReader reader)
		: base(reader)
	{
	}

	public Class2278()
	{
	}

	protected override void vmethod_1()
	{
		bool_4 = false;
		enum359_0 = enum359_1;
		uint_2 = 1u;
		bool_5 = false;
		bool_6 = true;
		bool_7 = false;
		string_2 = "indefinite";
	}

	protected override void vmethod_2()
	{
		delegate2638_0 = method_3;
		delegate2640_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("spid", string_1);
		writer.WriteAttributeString("grpId", XmlConvert.ToString(uint_1));
		if (bool_4)
		{
			writer.WriteAttributeString("uiExpand", bool_4 ? "1" : "0");
		}
		if (enum359_0 != enum359_1)
		{
			writer.WriteAttributeString("build", Class2495.smethod_1(enum359_0));
		}
		if (uint_2 != 1)
		{
			writer.WriteAttributeString("bldLvl", XmlConvert.ToString(uint_2));
		}
		if (bool_5)
		{
			writer.WriteAttributeString("animBg", bool_5 ? "1" : "0");
		}
		if (!bool_6)
		{
			writer.WriteAttributeString("autoUpdateAnimBg", bool_6 ? "1" : "0");
		}
		if (bool_7)
		{
			writer.WriteAttributeString("rev", bool_7 ? "1" : "0");
		}
		if (string_2 != "indefinite")
		{
			writer.WriteAttributeString("advAuto", string_2);
		}
		if (class2297_0 != null)
		{
			class2297_0.vmethod_4("p", writer, "tmplLst");
		}
		writer.WriteEndElement();
	}

	private Class2297 method_3()
	{
		if (class2297_0 != null)
		{
			throw new Exception("Only one <tmplLst> element can be added.");
		}
		class2297_0 = new Class2297();
		return class2297_0;
	}

	private void method_4(Class2297 _tmplLst)
	{
		class2297_0 = _tmplLst;
	}
}
