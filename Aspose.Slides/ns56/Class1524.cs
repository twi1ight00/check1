using System;
using System.Xml;

namespace ns56;

internal class Class1524 : Class1351
{
	public delegate Class1524 Delegate451();

	public delegate void Delegate452(Class1524 elementData);

	public delegate void Delegate453(Class1524 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = true;

	public Class2605.Delegate2773 delegate2773_0;

	private uint uint_0;

	private bool bool_2;

	private bool bool_3;

	private Class2605 class2605_0;

	public uint ColId
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

	public bool HiddenButton
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

	public bool ShowButton
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

	public Class2605 Filter
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
				case "filters":
					class2605_0 = new Class2605("filters", new Class1526(reader));
					break;
				case "top10":
					class2605_0 = new Class2605("top10", new Class1725(reader));
					break;
				case "customFilters":
					class2605_0 = new Class2605("customFilters", new Class1439(reader));
					break;
				case "dynamicFilter":
					class2605_0 = new Class2605("dynamicFilter", new Class1500(reader));
					break;
				case "colorFilter":
					class2605_0 = new Class2605("colorFilter", new Class1420(reader));
					break;
				case "iconFilter":
					class2605_0 = new Class2605("iconFilter", new Class1550(reader));
					break;
				case "extLst":
					class2605_0 = new Class2605("extLst", new Class1502(reader));
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
				case "showButton":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "hiddenButton":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "colId":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1524(XmlReader reader)
		: base(reader)
	{
	}

	public Class1524()
	{
	}

	protected override void vmethod_1()
	{
		bool_2 = false;
		bool_3 = true;
	}

	protected override void vmethod_2()
	{
		delegate2773_0 = method_3;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("colId", XmlConvert.ToString(uint_0));
		if (bool_2)
		{
			writer.WriteAttributeString("hiddenButton", bool_2 ? "1" : "0");
		}
		if (!bool_3)
		{
			writer.WriteAttributeString("showButton", bool_3 ? "1" : "0");
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "filters":
				((Class1526)class2605_0.Object).vmethod_4("ssml", writer, class2605_0.Name);
				break;
			case "top10":
				((Class1725)class2605_0.Object).vmethod_4("ssml", writer, class2605_0.Name);
				break;
			case "customFilters":
				((Class1439)class2605_0.Object).vmethod_4("ssml", writer, class2605_0.Name);
				break;
			case "dynamicFilter":
				((Class1500)class2605_0.Object).vmethod_4("ssml", writer, class2605_0.Name);
				break;
			case "colorFilter":
				((Class1420)class2605_0.Object).vmethod_4("ssml", writer, class2605_0.Name);
				break;
			case "iconFilter":
				((Class1550)class2605_0.Object).vmethod_4("ssml", writer, class2605_0.Name);
				break;
			case "extLst":
				((Class1502)class2605_0.Object).vmethod_4("ssml", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("Filter already is initialized.");
		}
		switch (elementName)
		{
		case "filters":
			class2605_0 = new Class2605("filters", new Class1526());
			break;
		case "top10":
			class2605_0 = new Class2605("top10", new Class1725());
			break;
		case "customFilters":
			class2605_0 = new Class2605("customFilters", new Class1439());
			break;
		case "dynamicFilter":
			class2605_0 = new Class2605("dynamicFilter", new Class1500());
			break;
		case "colorFilter":
			class2605_0 = new Class2605("colorFilter", new Class1420());
			break;
		case "iconFilter":
			class2605_0 = new Class2605("iconFilter", new Class1550());
			break;
		case "extLst":
			class2605_0 = new Class2605("extLst", new Class1502());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
