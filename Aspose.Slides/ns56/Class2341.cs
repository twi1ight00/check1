using System;
using System.Xml;
using Aspose.Slides.Charts;

namespace ns56;

internal class Class2341 : Class2340
{
	public delegate Class2341 Delegate2765();

	internal delegate void Delegate2766(Class2341 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private Class2605 class2605_0;

	public Class2605 AxisDataSource
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
				case "strLit":
					class2605_0 = new Class2605("strLit", new Class2119(reader));
					break;
				case "strRef":
					class2605_0 = new Class2605("strRef", new Class2120(reader));
					break;
				case "numLit":
					class2605_0 = new Class2605("numLit", new Class2096(reader));
					break;
				case "numRef":
					class2605_0 = new Class2605("numRef", new Class2098(reader));
					break;
				case "multiLvlStrRef":
					class2605_0 = new Class2605("multiLvlStrRef", new Class2095(reader));
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
	}

	public override DataSourceType vmethod_5()
	{
		switch (AxisDataSource.Name)
		{
		case "strLit":
			return DataSourceType.StringLiterals;
		case "numLit":
			return DataSourceType.DoubleLiterals;
		default:
			throw new Exception("Unknown element \"" + AxisDataSource.Name + "\"");
		case "multiLvlStrRef":
		case "numRef":
		case "strRef":
			return DataSourceType.Worksheet;
		}
	}

	public override string vmethod_6()
	{
		string result = "";
		if (AxisDataSource == null)
		{
			return result;
		}
		switch (AxisDataSource.Name)
		{
		case "numLit":
		case "strLit":
			throw new Exception();
		case "strRef":
		{
			Class2120 class3 = (Class2120)AxisDataSource.Object;
			return class3.F;
		}
		case "numRef":
		{
			Class2098 class2 = (Class2098)AxisDataSource.Object;
			return class2.F;
		}
		case "multiLvlStrRef":
		{
			Class2095 @class = (Class2095)AxisDataSource.Object;
			return @class.F;
		}
		default:
			throw new Exception("Unknown element \"" + AxisDataSource.Name + "\"");
		}
	}

	public override string vmethod_7()
	{
		switch (AxisDataSource.Name)
		{
		case "numLit":
		{
			Class2096 class2 = (Class2096)AxisDataSource.Object;
			return class2.FormatCode;
		}
		case "numRef":
		{
			Class2098 @class = (Class2098)AxisDataSource.Object;
			if (@class.NumCache == null)
			{
				return "";
			}
			return @class.NumCache.FormatCode;
		}
		default:
			throw new Exception("Unknown element \"" + AxisDataSource.Name + "\"");
		case "multiLvlStrRef":
		case "strRef":
		case "strLit":
			return "";
		}
	}

	public override Class1885 vmethod_8()
	{
		switch (AxisDataSource.Name)
		{
		case "strLit":
		{
			Class2119 class5 = (Class2119)AxisDataSource.Object;
			return class5.ExtLst;
		}
		case "numLit":
		{
			Class2096 class4 = (Class2096)AxisDataSource.Object;
			return class4.ExtLst;
		}
		case "strRef":
		{
			Class2120 class3 = (Class2120)AxisDataSource.Object;
			return class3.ExtLst;
		}
		case "numRef":
		{
			Class2098 class2 = (Class2098)AxisDataSource.Object;
			return class2.ExtLst;
		}
		default:
			throw new Exception("Unknown element \"" + AxisDataSource.Name + "\"");
		case "multiLvlStrRef":
		{
			Class2095 @class = (Class2095)AxisDataSource.Object;
			return @class.ExtLst;
		}
		}
	}

	public override void vmethod_9(Class1885 extensionListElementData)
	{
		switch (AxisDataSource.Name)
		{
		case "strLit":
		{
			Class2119 class5 = (Class2119)AxisDataSource.Object;
			class5.delegate1535_0(extensionListElementData);
			break;
		}
		case "numLit":
		{
			Class2096 class4 = (Class2096)AxisDataSource.Object;
			class4.delegate1535_0(extensionListElementData);
			break;
		}
		case "strRef":
		{
			Class2120 class3 = (Class2120)AxisDataSource.Object;
			class3.delegate1535_0(extensionListElementData);
			break;
		}
		case "numRef":
		{
			Class2098 class2 = (Class2098)AxisDataSource.Object;
			class2.delegate1535_0(extensionListElementData);
			break;
		}
		default:
			throw new Exception("Unknown element \"" + AxisDataSource.Name + "\"");
		case "multiLvlStrRef":
		{
			Class2095 @class = (Class2095)AxisDataSource.Object;
			@class.delegate1535_0(extensionListElementData);
			break;
		}
		}
	}

	internal int method_3()
	{
		switch (AxisDataSource.Name)
		{
		case "numRef":
		case "strRef":
		case "numLit":
		case "strLit":
			return 1;
		case "multiLvlStrRef":
		{
			Class2095 @class = (Class2095)AxisDataSource.Object;
			if (@class.MultiLvlStrCache != null)
			{
				return @class.MultiLvlStrCache.LvlList.Length;
			}
			return 1;
		}
		default:
			throw new Exception("Unknown element \"" + AxisDataSource.Name + "\"");
		}
	}

	internal Class2341(XmlReader reader)
		: base(reader)
	{
	}

	internal Class2341()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2773_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "strLit":
				((Class2119)class2605_0.Object).vmethod_4("c", writer, class2605_0.Name);
				break;
			case "strRef":
				((Class2120)class2605_0.Object).vmethod_4("c", writer, class2605_0.Name);
				break;
			case "numLit":
				((Class2096)class2605_0.Object).vmethod_4("c", writer, class2605_0.Name);
				break;
			case "numRef":
				((Class2098)class2605_0.Object).vmethod_4("c", writer, class2605_0.Name);
				break;
			case "multiLvlStrRef":
				((Class2095)class2605_0.Object).vmethod_4("c", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_4(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("AxisDataSource already is initialized.");
		}
		switch (elementName)
		{
		case "strLit":
			class2605_0 = new Class2605("strLit", new Class2119());
			break;
		case "strRef":
			class2605_0 = new Class2605("strRef", new Class2120());
			break;
		case "numLit":
			class2605_0 = new Class2605("numLit", new Class2096());
			break;
		case "numRef":
			class2605_0 = new Class2605("numRef", new Class2098());
			break;
		case "multiLvlStrRef":
			class2605_0 = new Class2605("multiLvlStrRef", new Class2095());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
