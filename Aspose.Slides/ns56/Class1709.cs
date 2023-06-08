using System;
using System.Xml;

namespace ns56;

internal class Class1709 : Class1351
{
	public delegate Class1709 Delegate1006();

	public delegate void Delegate1007(Class1709 elementData);

	public delegate void Delegate1008(Class1709 elementData);

	public Class1594.Delegate661 delegate661_0;

	public Class1594.Delegate663 delegate663_0;

	public Class1530.Delegate469 delegate469_0;

	public Class1530.Delegate471 delegate471_0;

	public Class1523.Delegate448 delegate448_0;

	public Class1523.Delegate450 delegate450_0;

	public Class1379.Delegate99 delegate99_0;

	public Class1379.Delegate101 delegate101_0;

	public Class1402.Delegate168 delegate168_0;

	public Class1402.Delegate170 delegate170_0;

	public Class1405.Delegate177 delegate177_0;

	public Class1405.Delegate179 delegate179_0;

	public Class1401.Delegate165 delegate165_0;

	public Class1401.Delegate167 delegate167_0;

	public Class1499.Delegate374 delegate374_0;

	public Class1499.Delegate376 delegate376_0;

	public Class1721.Delegate1042 delegate1042_0;

	public Class1721.Delegate1044 delegate1044_0;

	public Class1422.Delegate228 delegate228_0;

	public Class1422.Delegate230 delegate230_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private Class1594 class1594_0;

	private Class1530 class1530_0;

	private Class1523 class1523_0;

	private Class1379 class1379_0;

	private Class1402 class1402_0;

	private Class1405 class1405_0;

	private Class1401 class1401_0;

	private Class1499 class1499_0;

	private Class1721 class1721_0;

	private Class1422 class1422_0;

	private Class1502 class1502_0;

	public Class1594 NumFmts => class1594_0;

	public Class1530 Fonts => class1530_0;

	public Class1523 Fills => class1523_0;

	public Class1379 Borders => class1379_0;

	public Class1402 CellStyleXfs => class1402_0;

	public Class1405 CellXfs => class1405_0;

	public Class1401 CellStyles => class1401_0;

	public Class1499 Dxfs => class1499_0;

	public Class1721 TableStyles => class1721_0;

	public Class1422 Colors => class1422_0;

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
				case "numFmts":
					class1594_0 = new Class1594(reader);
					break;
				case "fonts":
					class1530_0 = new Class1530(reader);
					break;
				case "fills":
					class1523_0 = new Class1523(reader);
					break;
				case "borders":
					class1379_0 = new Class1379(reader);
					break;
				case "cellStyleXfs":
					class1402_0 = new Class1402(reader);
					break;
				case "cellXfs":
					class1405_0 = new Class1405(reader);
					break;
				case "cellStyles":
					class1401_0 = new Class1401(reader);
					break;
				case "dxfs":
					class1499_0 = new Class1499(reader);
					break;
				case "tableStyles":
					class1721_0 = new Class1721(reader);
					break;
				case "colors":
					class1422_0 = new Class1422(reader);
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

	public Class1709(XmlReader reader)
		: base(reader)
	{
	}

	public Class1709()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate661_0 = method_3;
		delegate663_0 = method_4;
		delegate469_0 = method_5;
		delegate471_0 = method_6;
		delegate448_0 = method_7;
		delegate450_0 = method_8;
		delegate99_0 = method_9;
		delegate101_0 = method_10;
		delegate168_0 = method_11;
		delegate170_0 = method_12;
		delegate177_0 = method_13;
		delegate179_0 = method_14;
		delegate165_0 = method_15;
		delegate167_0 = method_16;
		delegate374_0 = method_17;
		delegate376_0 = method_18;
		delegate1042_0 = method_19;
		delegate1044_0 = method_20;
		delegate228_0 = method_21;
		delegate230_0 = method_22;
		delegate385_0 = method_23;
		delegate387_0 = method_24;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("ssml", elementName, "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
		if (class1594_0 != null)
		{
			class1594_0.vmethod_4("ssml", writer, "numFmts");
		}
		if (class1530_0 != null)
		{
			class1530_0.vmethod_4("ssml", writer, "fonts");
		}
		if (class1523_0 != null)
		{
			class1523_0.vmethod_4("ssml", writer, "fills");
		}
		if (class1379_0 != null)
		{
			class1379_0.vmethod_4("ssml", writer, "borders");
		}
		if (class1402_0 != null)
		{
			class1402_0.vmethod_4("ssml", writer, "cellStyleXfs");
		}
		if (class1405_0 != null)
		{
			class1405_0.vmethod_4("ssml", writer, "cellXfs");
		}
		if (class1401_0 != null)
		{
			class1401_0.vmethod_4("ssml", writer, "cellStyles");
		}
		if (class1499_0 != null)
		{
			class1499_0.vmethod_4("ssml", writer, "dxfs");
		}
		if (class1721_0 != null)
		{
			class1721_0.vmethod_4("ssml", writer, "tableStyles");
		}
		if (class1422_0 != null)
		{
			class1422_0.vmethod_4("ssml", writer, "colors");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1594 method_3()
	{
		if (class1594_0 != null)
		{
			throw new Exception("Only one <numFmts> element can be added.");
		}
		class1594_0 = new Class1594();
		return class1594_0;
	}

	private void method_4(Class1594 _numFmts)
	{
		class1594_0 = _numFmts;
	}

	private Class1530 method_5()
	{
		if (class1530_0 != null)
		{
			throw new Exception("Only one <fonts> element can be added.");
		}
		class1530_0 = new Class1530();
		return class1530_0;
	}

	private void method_6(Class1530 _fonts)
	{
		class1530_0 = _fonts;
	}

	private Class1523 method_7()
	{
		if (class1523_0 != null)
		{
			throw new Exception("Only one <fills> element can be added.");
		}
		class1523_0 = new Class1523();
		return class1523_0;
	}

	private void method_8(Class1523 _fills)
	{
		class1523_0 = _fills;
	}

	private Class1379 method_9()
	{
		if (class1379_0 != null)
		{
			throw new Exception("Only one <borders> element can be added.");
		}
		class1379_0 = new Class1379();
		return class1379_0;
	}

	private void method_10(Class1379 _borders)
	{
		class1379_0 = _borders;
	}

	private Class1402 method_11()
	{
		if (class1402_0 != null)
		{
			throw new Exception("Only one <cellStyleXfs> element can be added.");
		}
		class1402_0 = new Class1402();
		return class1402_0;
	}

	private void method_12(Class1402 _cellStyleXfs)
	{
		class1402_0 = _cellStyleXfs;
	}

	private Class1405 method_13()
	{
		if (class1405_0 != null)
		{
			throw new Exception("Only one <cellXfs> element can be added.");
		}
		class1405_0 = new Class1405();
		return class1405_0;
	}

	private void method_14(Class1405 _cellXfs)
	{
		class1405_0 = _cellXfs;
	}

	private Class1401 method_15()
	{
		if (class1401_0 != null)
		{
			throw new Exception("Only one <cellStyles> element can be added.");
		}
		class1401_0 = new Class1401();
		return class1401_0;
	}

	private void method_16(Class1401 _cellStyles)
	{
		class1401_0 = _cellStyles;
	}

	private Class1499 method_17()
	{
		if (class1499_0 != null)
		{
			throw new Exception("Only one <dxfs> element can be added.");
		}
		class1499_0 = new Class1499();
		return class1499_0;
	}

	private void method_18(Class1499 _dxfs)
	{
		class1499_0 = _dxfs;
	}

	private Class1721 method_19()
	{
		if (class1721_0 != null)
		{
			throw new Exception("Only one <tableStyles> element can be added.");
		}
		class1721_0 = new Class1721();
		return class1721_0;
	}

	private void method_20(Class1721 _tableStyles)
	{
		class1721_0 = _tableStyles;
	}

	private Class1422 method_21()
	{
		if (class1422_0 != null)
		{
			throw new Exception("Only one <colors> element can be added.");
		}
		class1422_0 = new Class1422();
		return class1422_0;
	}

	private void method_22(Class1422 _colors)
	{
		class1422_0 = _colors;
	}

	private Class1502 method_23()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_24(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
