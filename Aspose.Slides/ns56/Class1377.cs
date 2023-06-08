using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1377 : Class1351
{
	public delegate Class1377 Delegate93();

	public delegate void Delegate94(Class1377 elementData);

	public delegate void Delegate95(Class1377 elementData);

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const NullableBool nullableBool_1 = NullableBool.NotDefined;

	public const bool bool_0 = true;

	public Class1378.Delegate96 delegate96_0;

	public Class1378.Delegate98 delegate98_0;

	public Class1378.Delegate96 delegate96_1;

	public Class1378.Delegate98 delegate98_1;

	public Class1378.Delegate96 delegate96_2;

	public Class1378.Delegate98 delegate98_2;

	public Class1378.Delegate96 delegate96_3;

	public Class1378.Delegate98 delegate98_3;

	public Class1378.Delegate96 delegate96_4;

	public Class1378.Delegate98 delegate98_4;

	public Class1378.Delegate96 delegate96_5;

	public Class1378.Delegate98 delegate98_5;

	public Class1378.Delegate96 delegate96_6;

	public Class1378.Delegate98 delegate98_6;

	private NullableBool nullableBool_2;

	private NullableBool nullableBool_3;

	private bool bool_1;

	private Class1378 class1378_0;

	private Class1378 class1378_1;

	private Class1378 class1378_2;

	private Class1378 class1378_3;

	private Class1378 class1378_4;

	private Class1378 class1378_5;

	private Class1378 class1378_6;

	public NullableBool DiagonalUp
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

	public NullableBool DiagonalDown
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

	public bool Outline
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Class1378 Left => class1378_0;

	public Class1378 Right => class1378_1;

	public Class1378 Top => class1378_2;

	public Class1378 Bottom => class1378_3;

	public Class1378 Diagonal => class1378_4;

	public Class1378 Vertical => class1378_5;

	public Class1378 Horizontal => class1378_6;

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
				case "left":
					class1378_0 = new Class1378(reader);
					break;
				case "right":
					class1378_1 = new Class1378(reader);
					break;
				case "top":
					class1378_2 = new Class1378(reader);
					break;
				case "bottom":
					class1378_3 = new Class1378(reader);
					break;
				case "diagonal":
					class1378_4 = new Class1378(reader);
					break;
				case "vertical":
					class1378_5 = new Class1378(reader);
					break;
				case "horizontal":
					class1378_6 = new Class1378(reader);
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
				case "outline":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "diagonalDown":
					nullableBool_3 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "diagonalUp":
					nullableBool_2 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1377(XmlReader reader)
		: base(reader)
	{
	}

	public Class1377()
	{
	}

	protected override void vmethod_1()
	{
		nullableBool_2 = NullableBool.NotDefined;
		nullableBool_3 = NullableBool.NotDefined;
		bool_1 = true;
	}

	protected override void vmethod_2()
	{
		delegate96_0 = method_3;
		delegate98_0 = method_4;
		delegate96_1 = method_5;
		delegate98_1 = method_6;
		delegate96_2 = method_7;
		delegate98_2 = method_8;
		delegate96_3 = method_9;
		delegate98_3 = method_10;
		delegate96_4 = method_11;
		delegate98_4 = method_12;
		delegate96_5 = method_13;
		delegate98_5 = method_14;
		delegate96_6 = method_15;
		delegate98_6 = method_16;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (nullableBool_2 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("diagonalUp", (nullableBool_2 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_3 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("diagonalDown", (nullableBool_3 == NullableBool.True) ? "1" : "0");
		}
		if (!bool_1)
		{
			writer.WriteAttributeString("outline", bool_1 ? "1" : "0");
		}
		if (class1378_0 != null)
		{
			class1378_0.vmethod_4("ssml", writer, "left");
		}
		if (class1378_1 != null)
		{
			class1378_1.vmethod_4("ssml", writer, "right");
		}
		if (class1378_2 != null)
		{
			class1378_2.vmethod_4("ssml", writer, "top");
		}
		if (class1378_3 != null)
		{
			class1378_3.vmethod_4("ssml", writer, "bottom");
		}
		if (class1378_4 != null)
		{
			class1378_4.vmethod_4("ssml", writer, "diagonal");
		}
		if (class1378_5 != null)
		{
			class1378_5.vmethod_4("ssml", writer, "vertical");
		}
		if (class1378_6 != null)
		{
			class1378_6.vmethod_4("ssml", writer, "horizontal");
		}
		writer.WriteEndElement();
	}

	private Class1378 method_3()
	{
		if (class1378_0 != null)
		{
			throw new Exception("Only one <left> element can be added.");
		}
		class1378_0 = new Class1378();
		return class1378_0;
	}

	private void method_4(Class1378 _left)
	{
		class1378_0 = _left;
	}

	private Class1378 method_5()
	{
		if (class1378_1 != null)
		{
			throw new Exception("Only one <right> element can be added.");
		}
		class1378_1 = new Class1378();
		return class1378_1;
	}

	private void method_6(Class1378 _right)
	{
		class1378_1 = _right;
	}

	private Class1378 method_7()
	{
		if (class1378_2 != null)
		{
			throw new Exception("Only one <top> element can be added.");
		}
		class1378_2 = new Class1378();
		return class1378_2;
	}

	private void method_8(Class1378 _top)
	{
		class1378_2 = _top;
	}

	private Class1378 method_9()
	{
		if (class1378_3 != null)
		{
			throw new Exception("Only one <bottom> element can be added.");
		}
		class1378_3 = new Class1378();
		return class1378_3;
	}

	private void method_10(Class1378 _bottom)
	{
		class1378_3 = _bottom;
	}

	private Class1378 method_11()
	{
		if (class1378_4 != null)
		{
			throw new Exception("Only one <diagonal> element can be added.");
		}
		class1378_4 = new Class1378();
		return class1378_4;
	}

	private void method_12(Class1378 _diagonal)
	{
		class1378_4 = _diagonal;
	}

	private Class1378 method_13()
	{
		if (class1378_5 != null)
		{
			throw new Exception("Only one <vertical> element can be added.");
		}
		class1378_5 = new Class1378();
		return class1378_5;
	}

	private void method_14(Class1378 _vertical)
	{
		class1378_5 = _vertical;
	}

	private Class1378 method_15()
	{
		if (class1378_6 != null)
		{
			throw new Exception("Only one <horizontal> element can be added.");
		}
		class1378_6 = new Class1378();
		return class1378_6;
	}

	private void method_16(Class1378 _horizontal)
	{
		class1378_6 = _horizontal;
	}
}
