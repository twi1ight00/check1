using System;
using System.Xml;
using Aspose.Slides.Charts;

namespace ns56;

internal class Class2342 : Class2340
{
	public delegate Class2342 Delegate2767();

	public delegate void Delegate2768(Class2342 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private Class2605 class2605_0;

	public Class2605 DataSource
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
				case "numLit":
					class2605_0 = new Class2605("numLit", new Class2096(reader));
					break;
				case "numRef":
					class2605_0 = new Class2605("numRef", new Class2098(reader));
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
		return DataSource.Name switch
		{
			"numLit" => DataSourceType.DoubleLiterals, 
			"numRef" => DataSourceType.Worksheet, 
			_ => throw new Exception("Unknown element \"" + DataSource.Name + "\""), 
		};
	}

	public override string vmethod_6()
	{
		string result = "";
		if (DataSource == null)
		{
			return result;
		}
		switch (DataSource.Name)
		{
		case "numLit":
			throw new Exception();
		default:
			throw new Exception("Unknown element \"" + DataSource.Name + "\"");
		case "numRef":
		{
			Class2098 @class = (Class2098)DataSource.Object;
			return @class.F;
		}
		}
	}

	public override string vmethod_7()
	{
		switch (DataSource.Name)
		{
		case "numLit":
		{
			Class2096 class2 = (Class2096)DataSource.Object;
			return class2.FormatCode;
		}
		case "numRef":
		{
			Class2098 @class = (Class2098)DataSource.Object;
			if (@class.NumCache == null)
			{
				return "";
			}
			return @class.NumCache.FormatCode;
		}
		default:
			throw new Exception("Unknown element \"" + DataSource.Name + "\"");
		}
	}

	public override Class1885 vmethod_8()
	{
		switch (DataSource.Name)
		{
		case "numLit":
		{
			Class2096 class2 = (Class2096)DataSource.Object;
			return class2.ExtLst;
		}
		default:
			throw new Exception("Unknown element \"" + DataSource.Name + "\"");
		case "numRef":
		{
			Class2098 @class = (Class2098)DataSource.Object;
			return @class.ExtLst;
		}
		}
	}

	public override void vmethod_9(Class1885 extensionListElementData)
	{
		switch (DataSource.Name)
		{
		case "numLit":
		{
			Class2096 class2 = (Class2096)DataSource.Object;
			class2.delegate1535_0(extensionListElementData);
			break;
		}
		default:
			throw new Exception("Unknown element \"" + DataSource.Name + "\"");
		case "numRef":
		{
			Class2098 @class = (Class2098)DataSource.Object;
			@class.delegate1535_0(extensionListElementData);
			break;
		}
		}
	}

	internal Class2342(XmlReader reader)
		: base(reader)
	{
	}

	internal Class2342()
	{
	}

	protected override void vmethod_1()
	{
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
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "numLit":
				((Class2096)class2605_0.Object).vmethod_4("c", writer, class2605_0.Name);
				break;
			case "numRef":
				((Class2098)class2605_0.Object).vmethod_4("c", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("DataSource already is initialized.");
		}
		switch (elementName)
		{
		case "numLit":
			class2605_0 = new Class2605("numLit", new Class2096());
			break;
		case "numRef":
			class2605_0 = new Class2605("numRef", new Class2098());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
