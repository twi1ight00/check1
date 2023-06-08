using System;
using System.Xml;

namespace ns56;

internal class Class1476 : Class1351
{
	public delegate void Delegate307(Class1476 elementData);

	public delegate Class1476 Delegate305();

	public delegate void Delegate306(Class1476 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public Class1480.Delegate317 delegate317_0;

	public Class1480.Delegate319 delegate319_0;

	private Enum194 enum194_0;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private Class1480 class1480_0;

	public static readonly Enum194 enum194_1 = Class2361.smethod_0("sum");

	public Enum194 Function
	{
		get
		{
			return enum194_0;
		}
		set
		{
			enum194_0 = value;
		}
	}

	public bool LeftLabels
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

	public bool TopLabels
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

	public bool Link
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

	public Class1480 DataRefs => class1480_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "dataRefs")
				{
					class1480_0 = new Class1480(reader);
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
				case "link":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "topLabels":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "leftLabels":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "function":
					enum194_0 = Class2361.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1476(XmlReader reader)
		: base(reader)
	{
	}

	public Class1476()
	{
	}

	protected override void vmethod_1()
	{
		enum194_0 = enum194_1;
		bool_3 = false;
		bool_4 = false;
		bool_5 = false;
	}

	protected override void vmethod_2()
	{
		delegate317_0 = method_3;
		delegate319_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum194_0 != enum194_1)
		{
			writer.WriteAttributeString("function", Class2361.smethod_1(enum194_0));
		}
		if (bool_3)
		{
			writer.WriteAttributeString("leftLabels", bool_3 ? "1" : "0");
		}
		if (bool_4)
		{
			writer.WriteAttributeString("topLabels", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("link", bool_5 ? "1" : "0");
		}
		if (class1480_0 != null)
		{
			class1480_0.vmethod_4("ssml", writer, "dataRefs");
		}
		writer.WriteEndElement();
	}

	private Class1480 method_3()
	{
		if (class1480_0 != null)
		{
			throw new Exception("Only one <dataRefs> element can be added.");
		}
		class1480_0 = new Class1480();
		return class1480_0;
	}

	private void method_4(Class1480 _dataRefs)
	{
		class1480_0 = _dataRefs;
	}
}
