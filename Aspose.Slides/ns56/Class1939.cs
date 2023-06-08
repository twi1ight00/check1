using System;
using System.Xml;

namespace ns56;

internal class Class1939 : Class1351
{
	public delegate Class1939 Delegate1684();

	public delegate void Delegate1685(Class1939 elementData);

	public delegate void Delegate1686(Class1939 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const bool bool_4 = false;

	public const bool bool_5 = false;

	public const bool bool_6 = false;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2605.Delegate2773 delegate2773_0;

	public Class2605.Delegate2773 delegate2773_1;

	public Class2605.Delegate2773 delegate2773_2;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private Class2605 class2605_0;

	private Class2605 class2605_1;

	private Class2605 class2605_2;

	private Class1886 class1886_0;

	public bool Rtl
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

	public bool FirstRow
	{
		get
		{
			return bool_8;
		}
		set
		{
			bool_8 = value;
		}
	}

	public bool FirstCol
	{
		get
		{
			return bool_9;
		}
		set
		{
			bool_9 = value;
		}
	}

	public bool LastRow
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

	public bool LastCol
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

	public bool BandRow
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

	public bool BandCol
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

	public Class2605 FillProperties
	{
		get
		{
			return class2605_0;
		}
		set
		{
			class2605_0 = value;
		}
	}

	public Class2605 EffectProperties
	{
		get
		{
			return class2605_1;
		}
		set
		{
			class2605_1 = value;
		}
	}

	public Class2605 TableStyle
	{
		get
		{
			return class2605_2;
		}
		set
		{
			class2605_2 = value;
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
				switch (reader.LocalName)
				{
				case "noFill":
					class2605_0 = new Class2605("noFill", new Class1878(reader));
					break;
				case "solidFill":
					class2605_0 = new Class2605("solidFill", new Class1924(reader));
					break;
				case "gradFill":
					class2605_0 = new Class2605("gradFill", new Class1853(reader));
					break;
				case "blipFill":
					class2605_0 = new Class2605("blipFill", new Class1810(reader));
					break;
				case "pattFill":
					class2605_0 = new Class2605("pattFill", new Class1900(reader));
					break;
				case "grpFill":
					class2605_0 = new Class2605("grpFill", new Class1859(reader));
					break;
				case "effectLst":
					class2605_1 = new Class2605("effectLst", new Class1833(reader));
					break;
				case "effectDag":
					class2605_1 = new Class2605("effectDag", new Class1832(reader));
					break;
				case "tableStyle":
					class2605_2 = new Class2605("tableStyle", new Class1942(reader));
					break;
				case "tableStyleId":
					reader.Read();
					class2605_2 = new Class2605("tableStyleId", new Guid(reader.Value));
					break;
				case "extLst":
					class1886_0 = new Class1886(reader);
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
				case "rtl":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "firstRow":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "firstCol":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "lastRow":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "lastCol":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "bandRow":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "bandCol":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1939(XmlReader reader)
		: base(reader)
	{
	}

	public Class1939()
	{
	}

	protected override void vmethod_1()
	{
		bool_7 = false;
		bool_8 = false;
		bool_9 = false;
		bool_10 = false;
		bool_11 = false;
		bool_12 = false;
		bool_13 = false;
	}

	protected override void vmethod_2()
	{
		delegate2773_1 = method_6;
		delegate2773_0 = method_5;
		delegate2773_2 = method_7;
		delegate1534_0 = method_3;
		delegate1535_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (bool_7)
		{
			writer.WriteAttributeString("rtl", bool_7 ? "1" : "0");
		}
		if (bool_8)
		{
			writer.WriteAttributeString("firstRow", bool_8 ? "1" : "0");
		}
		if (bool_9)
		{
			writer.WriteAttributeString("firstCol", bool_9 ? "1" : "0");
		}
		if (bool_10)
		{
			writer.WriteAttributeString("lastRow", bool_10 ? "1" : "0");
		}
		if (bool_11)
		{
			writer.WriteAttributeString("lastCol", bool_11 ? "1" : "0");
		}
		if (bool_12)
		{
			writer.WriteAttributeString("bandRow", bool_12 ? "1" : "0");
		}
		if (bool_13)
		{
			writer.WriteAttributeString("bandCol", bool_13 ? "1" : "0");
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "noFill":
				((Class1878)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "solidFill":
				((Class1924)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "gradFill":
				((Class1853)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "blipFill":
				((Class1810)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "pattFill":
				((Class1900)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "grpFill":
				((Class1859)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			}
		}
		if (class2605_1 != null)
		{
			switch (class2605_1.Name)
			{
			case "effectDag":
				((Class1832)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			case "effectLst":
				((Class1833)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			}
		}
		if (class2605_2 != null)
		{
			switch (class2605_2.Name)
			{
			case "tableStyleId":
				method_1("a", writer, "tableStyleId", "{" + XmlConvert.ToString((Guid)class2605_2.Object).ToUpper() + "}");
				break;
			case "tableStyle":
				((Class1942)class2605_2.Object).vmethod_4("a", writer, class2605_2.Name);
				break;
			}
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

	private Class2605 method_5(string elementName)
	{
		if (class2605_1 != null)
		{
			throw new Exception("EffectProperties already is initialized.");
		}
		switch (elementName)
		{
		case "effectDag":
			class2605_1 = new Class2605("effectDag", new Class1832());
			break;
		case "effectLst":
			class2605_1 = new Class2605("effectLst", new Class1833());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_1;
	}

	private Class2605 method_6(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("FillProperties already is initialized.");
		}
		switch (elementName)
		{
		case "noFill":
			class2605_0 = new Class2605("noFill", new Class1878());
			break;
		case "solidFill":
			class2605_0 = new Class2605("solidFill", new Class1924());
			break;
		case "gradFill":
			class2605_0 = new Class2605("gradFill", new Class1853());
			break;
		case "blipFill":
			class2605_0 = new Class2605("blipFill", new Class1810());
			break;
		case "pattFill":
			class2605_0 = new Class2605("pattFill", new Class1900());
			break;
		case "grpFill":
			class2605_0 = new Class2605("grpFill", new Class1859());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}

	private Class2605 method_7(string elementName)
	{
		if (class2605_2 != null)
		{
			throw new Exception("TableStyle already is initialized.");
		}
		switch (elementName)
		{
		case "tableStyleId":
			class2605_2 = new Class2605("tableStyleId", default(Guid));
			break;
		case "tableStyle":
			class2605_2 = new Class2605("tableStyle", new Class1942());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_2;
	}
}
