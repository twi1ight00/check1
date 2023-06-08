using System;
using System.Xml;

namespace ns56;

internal class Class1825 : Class1351
{
	public delegate Class1825 Delegate1354();

	public delegate void Delegate1355(Class1825 elementData);

	public delegate void Delegate1356(Class1825 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const bool bool_4 = false;

	public const bool bool_5 = false;

	public const bool bool_6 = false;

	public const bool bool_7 = false;

	public const bool bool_8 = false;

	public const bool bool_9 = false;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private bool bool_14;

	private bool bool_15;

	private bool bool_16;

	private bool bool_17;

	private bool bool_18;

	private bool bool_19;

	private Class1886 class1886_0;

	public bool NoGrp
	{
		get
		{
			return bool_10;
		}
		set
		{
			bool_10 = value;
		}
	}

	public bool NoSelect
	{
		get
		{
			return bool_11;
		}
		set
		{
			bool_11 = value;
		}
	}

	public bool NoRot
	{
		get
		{
			return bool_12;
		}
		set
		{
			bool_12 = value;
		}
	}

	public bool NoChangeAspect
	{
		get
		{
			return bool_13;
		}
		set
		{
			bool_13 = value;
		}
	}

	public bool NoMove
	{
		get
		{
			return bool_14;
		}
		set
		{
			bool_14 = value;
		}
	}

	public bool NoResize
	{
		get
		{
			return bool_15;
		}
		set
		{
			bool_15 = value;
		}
	}

	public bool NoEditPoints
	{
		get
		{
			return bool_16;
		}
		set
		{
			bool_16 = value;
		}
	}

	public bool NoAdjustHandles
	{
		get
		{
			return bool_17;
		}
		set
		{
			bool_17 = value;
		}
	}

	public bool NoChangeArrowheads
	{
		get
		{
			return bool_18;
		}
		set
		{
			bool_18 = value;
		}
	}

	public bool NoChangeShapeType
	{
		get
		{
			return bool_19;
		}
		set
		{
			bool_19 = value;
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
				case "noGrp":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "noSelect":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "noRot":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "noChangeAspect":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "noMove":
					bool_14 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "noResize":
					bool_15 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "noEditPoints":
					bool_16 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "noAdjustHandles":
					bool_17 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "noChangeArrowheads":
					bool_18 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "noChangeShapeType":
					bool_19 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1825(XmlReader reader)
		: base(reader)
	{
	}

	public Class1825()
	{
	}

	protected override void vmethod_1()
	{
		bool_10 = false;
		bool_11 = false;
		bool_12 = false;
		bool_13 = false;
		bool_14 = false;
		bool_15 = false;
		bool_16 = false;
		bool_17 = false;
		bool_18 = false;
		bool_19 = false;
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
		if (bool_10)
		{
			writer.WriteAttributeString("noGrp", bool_10 ? "1" : "0");
		}
		if (bool_11)
		{
			writer.WriteAttributeString("noSelect", bool_11 ? "1" : "0");
		}
		if (bool_12)
		{
			writer.WriteAttributeString("noRot", bool_12 ? "1" : "0");
		}
		if (bool_13)
		{
			writer.WriteAttributeString("noChangeAspect", bool_13 ? "1" : "0");
		}
		if (bool_14)
		{
			writer.WriteAttributeString("noMove", bool_14 ? "1" : "0");
		}
		if (bool_15)
		{
			writer.WriteAttributeString("noResize", bool_15 ? "1" : "0");
		}
		if (bool_16)
		{
			writer.WriteAttributeString("noEditPoints", bool_16 ? "1" : "0");
		}
		if (bool_17)
		{
			writer.WriteAttributeString("noAdjustHandles", bool_17 ? "1" : "0");
		}
		if (bool_18)
		{
			writer.WriteAttributeString("noChangeArrowheads", bool_18 ? "1" : "0");
		}
		if (bool_19)
		{
			writer.WriteAttributeString("noChangeShapeType", bool_19 ? "1" : "0");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
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