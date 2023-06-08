using System;
using System.Xml;

namespace ns56;

internal class Class2321 : Class1351
{
	public delegate Class2321 Delegate2710();

	public delegate void Delegate2711(Class2321 elementData);

	public delegate void Delegate2712(Class2321 elementData);

	public const bool bool_0 = true;

	public Class1447.Delegate303 delegate303_0;

	public Class1447.Delegate304 delegate304_0;

	public Class1447.Delegate303 delegate303_1;

	public Class1447.Delegate304 delegate304_1;

	public Class2246.Delegate2482 delegate2482_0;

	public Class2246.Delegate2483 delegate2483_0;

	public Class1447.Delegate303 delegate303_2;

	public Class1447.Delegate304 delegate304_2;

	public Class1447.Delegate303 delegate303_3;

	public Class1447.Delegate304 delegate304_3;

	public Class1447.Delegate303 delegate303_4;

	public Class1447.Delegate304 delegate304_4;

	public Class1906.Delegate1585 delegate1585_0;

	public Class1906.Delegate1587 delegate1587_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Enum361 enum361_0;

	private bool bool_1;

	private Class1466 class1466_0;

	private Class1471 class1471_0;

	private Class2246 class2246_0;

	private Class1467 class1467_0;

	private Class1470 class1470_0;

	private Class1468 class1468_0;

	private Class1906 class1906_0;

	private Class1888 class1888_0;

	public static readonly Enum361 enum361_1 = Class2497.smethod_0("sldView");

	public Enum361 LastView
	{
		get
		{
			return enum361_0;
		}
		set
		{
			enum361_0 = value;
		}
	}

	public bool ShowComments
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

	public Class1466 NormalViewPr => class1466_0;

	public Class1471 SlideViewPr => class1471_0;

	public Class2246 OutlineViewPr => class2246_0;

	public Class1467 NotesTextViewPr => class1467_0;

	public Class1470 SorterViewPr => class1470_0;

	public Class1468 NotesViewPr => class1468_0;

	public Class1906 GridSpacing => class1906_0;

	public Class1885 ExtLst => class1888_0;

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
				case "normalViewPr":
					class1466_0 = new Class1466(reader);
					flag = true;
					break;
				case "slideViewPr":
					class1471_0 = new Class1471(reader);
					flag = true;
					break;
				case "outlineViewPr":
					class2246_0 = new Class2246(reader);
					break;
				case "notesTextViewPr":
					class1467_0 = new Class1467(reader);
					flag = true;
					break;
				case "sorterViewPr":
					class1470_0 = new Class1470(reader);
					flag = true;
					break;
				case "notesViewPr":
					class1468_0 = new Class1468(reader);
					flag = true;
					break;
				case "gridSpacing":
					class1906_0 = new Class1906(reader);
					break;
				case "extLst":
					class1888_0 = new Class1888(reader);
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
				case "showComments":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "lastView":
					enum361_0 = Class2497.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2321(XmlReader reader)
		: base(reader)
	{
	}

	public Class2321()
	{
	}

	protected override void vmethod_1()
	{
		enum361_0 = enum361_1;
		bool_1 = true;
	}

	protected override void vmethod_2()
	{
		delegate303_0 = method_3;
		delegate304_0 = method_4;
		delegate303_1 = method_5;
		delegate304_1 = method_6;
		delegate2482_0 = method_7;
		delegate2483_0 = method_8;
		delegate303_2 = method_9;
		delegate304_2 = method_10;
		delegate303_3 = method_11;
		delegate304_3 = method_12;
		delegate303_4 = method_13;
		delegate304_4 = method_14;
		delegate1585_0 = method_15;
		delegate1587_0 = method_16;
		delegate1534_0 = method_17;
		delegate1535_0 = method_18;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("p", elementName, "http://schemas.openxmlformats.org/presentationml/2006/main");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/drawingml/2006/main") == null)
		{
			writer.WriteAttributeString("xmlns", "a", null, "http://schemas.openxmlformats.org/drawingml/2006/main");
		}
		if (enum361_0 != enum361_1)
		{
			writer.WriteAttributeString("lastView", Class2497.smethod_1(enum361_0));
		}
		if (!bool_1)
		{
			writer.WriteAttributeString("showComments", bool_1 ? "1" : "0");
		}
		if (class1466_0 != null)
		{
			class1466_0.vmethod_4("p", writer, "normalViewPr");
		}
		if (class1471_0 != null)
		{
			class1471_0.vmethod_4("p", writer, "slideViewPr");
		}
		if (class2246_0 != null)
		{
			class2246_0.vmethod_4("p", writer, "outlineViewPr");
		}
		if (class1467_0 != null)
		{
			class1467_0.vmethod_4("p", writer, "notesTextViewPr");
		}
		if (class1470_0 != null)
		{
			class1470_0.vmethod_4("p", writer, "sorterViewPr");
		}
		if (class1468_0 != null)
		{
			class1468_0.vmethod_4("p", writer, "notesViewPr");
		}
		if (class1906_0 != null)
		{
			class1906_0.vmethod_4("p", writer, "gridSpacing");
		}
		if (class1888_0 != null)
		{
			class1888_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1447 method_3()
	{
		if (class1466_0 != null)
		{
			throw new Exception("Only one <normalViewPr> element can be added.");
		}
		class1466_0 = new Class1466();
		return class1466_0;
	}

	private void method_4(Class1447 _normalViewPr)
	{
		class1466_0 = (Class1466)_normalViewPr;
	}

	private Class1447 method_5()
	{
		if (class1471_0 != null)
		{
			throw new Exception("Only one <slideViewPr> element can be added.");
		}
		class1471_0 = new Class1471();
		return class1471_0;
	}

	private void method_6(Class1447 _slideViewPr)
	{
		class1471_0 = (Class1471)_slideViewPr;
	}

	private Class2246 method_7()
	{
		if (class2246_0 != null)
		{
			throw new Exception("Only one <outlineViewPr> element can be added.");
		}
		class2246_0 = new Class2246();
		return class2246_0;
	}

	private void method_8(Class2246 _outlineViewPr)
	{
		class2246_0 = _outlineViewPr;
	}

	private Class1447 method_9()
	{
		if (class1467_0 != null)
		{
			throw new Exception("Only one <notesTextViewPr> element can be added.");
		}
		class1467_0 = new Class1467();
		return class1467_0;
	}

	private void method_10(Class1447 _notesTextViewPr)
	{
		class1467_0 = (Class1467)_notesTextViewPr;
	}

	private Class1447 method_11()
	{
		if (class1470_0 != null)
		{
			throw new Exception("Only one <sorterViewPr> element can be added.");
		}
		class1470_0 = new Class1470();
		return class1470_0;
	}

	private void method_12(Class1447 _sorterViewPr)
	{
		class1470_0 = (Class1470)_sorterViewPr;
	}

	private Class1447 method_13()
	{
		if (class1468_0 != null)
		{
			throw new Exception("Only one <notesViewPr> element can be added.");
		}
		class1468_0 = new Class1468();
		return class1468_0;
	}

	private void method_14(Class1447 _notesViewPr)
	{
		class1468_0 = (Class1468)_notesViewPr;
	}

	private Class1906 method_15()
	{
		if (class1906_0 != null)
		{
			throw new Exception("Only one <gridSpacing> element can be added.");
		}
		class1906_0 = new Class1906();
		return class1906_0;
	}

	private void method_16(Class1906 _gridSpacing)
	{
		class1906_0 = _gridSpacing;
	}

	private Class1885 method_17()
	{
		if (class1888_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1888_0 = new Class1888();
		return class1888_0;
	}

	private void method_18(Class1885 _extLst)
	{
		class1888_0 = (Class1888)_extLst;
	}
}
