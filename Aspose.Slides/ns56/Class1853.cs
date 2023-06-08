using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1853 : Class1351
{
	public delegate Class1853 Delegate1438();

	public delegate void Delegate1439(Class1853 elementData);

	public delegate void Delegate1440(Class1853 elementData);

	public const TileFlip tileFlip_0 = TileFlip.NotDefined;

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public Class1855.Delegate1444 delegate1444_0;

	public Class1855.Delegate1446 delegate1446_0;

	public Class1915.Delegate1612 delegate1612_0;

	public Class1915.Delegate1614 delegate1614_0;

	public Class2605.Delegate2773 delegate2773_0;

	private TileFlip tileFlip_1;

	private NullableBool nullableBool_1;

	private Class1855 class1855_0;

	private Class2605 class2605_0;

	private Class1915 class1915_0;

	public TileFlip Flip
	{
		get
		{
			return tileFlip_1;
		}
		set
		{
			tileFlip_1 = value;
		}
	}

	public NullableBool RotWithShape
	{
		get
		{
			return nullableBool_1;
		}
		set
		{
			nullableBool_1 = value;
		}
	}

	public Class1855 GsLst => class1855_0;

	public Class2605 ShadeProperties
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

	public Class1915 TileRect => class1915_0;

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
				case "tileRect":
					class1915_0 = new Class1915(reader);
					break;
				case "path":
					class2605_0 = new Class2605("path", new Class1899(reader));
					break;
				case "lin":
					class2605_0 = new Class2605("lin", new Class1870(reader));
					break;
				case "gsLst":
					class1855_0 = new Class1855(reader);
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
				case "rotWithShape":
					nullableBool_1 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "flip":
					tileFlip_1 = Class2577.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1853(XmlReader reader)
		: base(reader)
	{
	}

	public Class1853()
	{
	}

	protected override void vmethod_1()
	{
		tileFlip_1 = TileFlip.NotDefined;
		nullableBool_1 = NullableBool.NotDefined;
	}

	protected override void vmethod_2()
	{
		delegate1444_0 = method_3;
		delegate1446_0 = method_4;
		delegate2773_0 = method_7;
		delegate1612_0 = method_5;
		delegate1614_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (tileFlip_1 != TileFlip.NotDefined)
		{
			writer.WriteAttributeString("flip", Class2577.smethod_1(tileFlip_1));
		}
		if (nullableBool_1 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("rotWithShape", (nullableBool_1 == NullableBool.True) ? "1" : "0");
		}
		if (class1855_0 != null)
		{
			class1855_0.vmethod_4("a", writer, "gsLst");
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "path":
				((Class1899)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "lin":
				((Class1870)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			}
		}
		if (class1915_0 != null)
		{
			class1915_0.vmethod_4("a", writer, "tileRect");
		}
		writer.WriteEndElement();
	}

	private Class1855 method_3()
	{
		if (class1855_0 != null)
		{
			throw new Exception("Only one <gsLst> element can be added.");
		}
		class1855_0 = new Class1855();
		return class1855_0;
	}

	private void method_4(Class1855 _gsLst)
	{
		class1855_0 = _gsLst;
	}

	private Class1915 method_5()
	{
		if (class1915_0 != null)
		{
			throw new Exception("Only one <tileRect> element can be added.");
		}
		class1915_0 = new Class1915();
		return class1915_0;
	}

	private void method_6(Class1915 _tileRect)
	{
		class1915_0 = _tileRect;
	}

	private Class2605 method_7(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("ShadeProperties already is initialized.");
		}
		switch (elementName)
		{
		case "path":
			class2605_0 = new Class2605("path", new Class1899());
			break;
		case "lin":
			class2605_0 = new Class2605("lin", new Class1870());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
