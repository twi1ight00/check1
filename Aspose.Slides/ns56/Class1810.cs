using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1810 : Class1351
{
	public delegate Class1810 Delegate1309();

	public delegate void Delegate1310(Class1810 elementData);

	public delegate void Delegate1311(Class1810 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public Class1809.Delegate1306 delegate1306_0;

	public Class1809.Delegate1308 delegate1308_0;

	public Class1915.Delegate1612 delegate1612_0;

	public Class1915.Delegate1614 delegate1614_0;

	public Class2605.Delegate2773 delegate2773_0;

	private uint uint_1;

	private NullableBool nullableBool_1;

	private Class1809 class1809_0;

	private Class1915 class1915_0;

	private Class2605 class2605_0;

	public uint Dpi
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

	public Class1809 Blip => class1809_0;

	public Class1915 SrcRect => class1915_0;

	public Class2605 FillModeProperties
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
				case "stretch":
					class2605_0 = new Class2605("stretch", new Class1927(reader));
					break;
				case "tile":
					class2605_0 = new Class2605("tile", new Class1974(reader));
					break;
				case "srcRect":
					class1915_0 = new Class1915(reader);
					break;
				case "blip":
					class1809_0 = new Class1809(reader);
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
				case "dpi":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1810(XmlReader reader)
		: base(reader)
	{
	}

	public Class1810()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = uint.MaxValue;
		nullableBool_1 = NullableBool.NotDefined;
	}

	protected override void vmethod_2()
	{
		delegate1306_0 = method_3;
		delegate1308_0 = method_4;
		delegate1612_0 = method_5;
		delegate1614_0 = method_6;
		delegate2773_0 = method_7;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("dpi", XmlConvert.ToString(uint_1));
		}
		if (nullableBool_1 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("rotWithShape", (nullableBool_1 == NullableBool.True) ? "1" : "0");
		}
		if (class1809_0 != null)
		{
			class1809_0.vmethod_4("a", writer, "blip");
		}
		if (class1915_0 != null)
		{
			class1915_0.vmethod_4("a", writer, "srcRect");
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "stretch":
				((Class1927)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "tile":
				((Class1974)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class1809 method_3()
	{
		if (class1809_0 != null)
		{
			throw new Exception("Only one <blip> element can be added.");
		}
		class1809_0 = new Class1809();
		return class1809_0;
	}

	private void method_4(Class1809 _blip)
	{
		class1809_0 = _blip;
	}

	private Class1915 method_5()
	{
		if (class1915_0 != null)
		{
			throw new Exception("Only one <srcRect> element can be added.");
		}
		class1915_0 = new Class1915();
		return class1915_0;
	}

	private void method_6(Class1915 _srcRect)
	{
		class1915_0 = _srcRect;
	}

	private Class2605 method_7(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("FillModeProperties already is initialized.");
		}
		switch (elementName)
		{
		case "stretch":
			class2605_0 = new Class2605("stretch", new Class1927());
			break;
		case "tile":
			class2605_0 = new Class2605("tile", new Class1974());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
