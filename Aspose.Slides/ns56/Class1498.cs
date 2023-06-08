using System;
using System.Xml;

namespace ns56;

internal class Class1498 : Class1351
{
	public delegate Class1498 Delegate371();

	public delegate void Delegate372(Class1498 elementData);

	public delegate void Delegate373(Class1498 elementData);

	public Class1527.Delegate460 delegate460_0;

	public Class1527.Delegate462 delegate462_0;

	public Class1593.Delegate658 delegate658_0;

	public Class1593.Delegate660 delegate660_0;

	public Class1522.Delegate445 delegate445_0;

	public Class1522.Delegate447 delegate447_0;

	public Class1393.Delegate141 delegate141_0;

	public Class1393.Delegate143 delegate143_0;

	public Class1377.Delegate93 delegate93_0;

	public Class1377.Delegate95 delegate95_0;

	public Class1396.Delegate150 delegate150_0;

	public Class1396.Delegate152 delegate152_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private Class1527 class1527_0;

	private Class1593 class1593_0;

	private Class1522 class1522_0;

	private Class1393 class1393_0;

	private Class1377 class1377_0;

	private Class1396 class1396_0;

	private Class1502 class1502_0;

	public Class1527 Font => class1527_0;

	public Class1593 NumFmt => class1593_0;

	public Class1522 Fill => class1522_0;

	public Class1393 Alignment => class1393_0;

	public Class1377 Border => class1377_0;

	public Class1396 Protection => class1396_0;

	public Class1502 ExtLst => class1502_0;

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
				case "font":
					class1527_0 = new Class1527(reader);
					break;
				case "numFmt":
					class1593_0 = new Class1593(reader);
					break;
				case "fill":
					class1522_0 = new Class1522(reader);
					break;
				case "alignment":
					class1393_0 = new Class1393(reader);
					break;
				case "border":
					class1377_0 = new Class1377(reader);
					break;
				case "protection":
					class1396_0 = new Class1396(reader);
					break;
				case "extLst":
					class1502_0 = new Class1502(reader);
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

	public Class1498(XmlReader reader)
		: base(reader)
	{
	}

	public Class1498()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate460_0 = method_3;
		delegate462_0 = method_4;
		delegate658_0 = method_5;
		delegate660_0 = method_6;
		delegate445_0 = method_7;
		delegate447_0 = method_8;
		delegate141_0 = method_9;
		delegate143_0 = method_10;
		delegate93_0 = method_11;
		delegate95_0 = method_12;
		delegate150_0 = method_13;
		delegate152_0 = method_14;
		delegate385_0 = method_15;
		delegate387_0 = method_16;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class1527_0 != null)
		{
			class1527_0.vmethod_4("ssml", writer, "font");
		}
		if (class1593_0 != null)
		{
			class1593_0.vmethod_4("ssml", writer, "numFmt");
		}
		if (class1522_0 != null)
		{
			class1522_0.vmethod_4("ssml", writer, "fill");
		}
		if (class1393_0 != null)
		{
			class1393_0.vmethod_4("ssml", writer, "alignment");
		}
		if (class1377_0 != null)
		{
			class1377_0.vmethod_4("ssml", writer, "border");
		}
		if (class1396_0 != null)
		{
			class1396_0.vmethod_4("ssml", writer, "protection");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1527 method_3()
	{
		if (class1527_0 != null)
		{
			throw new Exception("Only one <font> element can be added.");
		}
		class1527_0 = new Class1527();
		return class1527_0;
	}

	private void method_4(Class1527 _font)
	{
		class1527_0 = _font;
	}

	private Class1593 method_5()
	{
		if (class1593_0 != null)
		{
			throw new Exception("Only one <numFmt> element can be added.");
		}
		class1593_0 = new Class1593();
		return class1593_0;
	}

	private void method_6(Class1593 _numFmt)
	{
		class1593_0 = _numFmt;
	}

	private Class1522 method_7()
	{
		if (class1522_0 != null)
		{
			throw new Exception("Only one <fill> element can be added.");
		}
		class1522_0 = new Class1522();
		return class1522_0;
	}

	private void method_8(Class1522 _fill)
	{
		class1522_0 = _fill;
	}

	private Class1393 method_9()
	{
		if (class1393_0 != null)
		{
			throw new Exception("Only one <alignment> element can be added.");
		}
		class1393_0 = new Class1393();
		return class1393_0;
	}

	private void method_10(Class1393 _alignment)
	{
		class1393_0 = _alignment;
	}

	private Class1377 method_11()
	{
		if (class1377_0 != null)
		{
			throw new Exception("Only one <border> element can be added.");
		}
		class1377_0 = new Class1377();
		return class1377_0;
	}

	private void method_12(Class1377 _border)
	{
		class1377_0 = _border;
	}

	private Class1396 method_13()
	{
		if (class1396_0 != null)
		{
			throw new Exception("Only one <protection> element can be added.");
		}
		class1396_0 = new Class1396();
		return class1396_0;
	}

	private void method_14(Class1396 _protection)
	{
		class1396_0 = _protection;
	}

	private Class1502 method_15()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_16(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
