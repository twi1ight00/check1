using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1809 : Class1351
{
	public delegate Class1809 Delegate1306();

	public delegate void Delegate1307(Class1809 elementData);

	public delegate void Delegate1308(Class1809 elementData);

	public const string string_0 = "";

	public const string string_1 = "";

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2605.Delegate2773 delegate2773_0;

	private string string_2;

	private string string_3;

	private Enum310 enum310_0;

	private List<Class2605> list_0;

	private Class1886 class1886_0;

	public static readonly Enum310 enum310_1 = Class2438.smethod_0("none");

	public string R_Embed
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public string R_Link
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public Enum310 Cstate
	{
		get
		{
			return enum310_0;
		}
		set
		{
			enum310_0 = value;
		}
	}

	public Class2605[] EffectList => list_0.ToArray();

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
				case "alphaBiLevel":
				{
					Class1784 obj17 = new Class1784(reader);
					list_0.Add(new Class2605("alphaBiLevel", obj17));
					break;
				}
				case "alphaCeiling":
				{
					Class1785 obj16 = new Class1785(reader);
					list_0.Add(new Class2605("alphaCeiling", obj16));
					break;
				}
				case "alphaFloor":
				{
					Class1786 obj15 = new Class1786(reader);
					list_0.Add(new Class2605("alphaFloor", obj15));
					break;
				}
				case "alphaInv":
				{
					Class1787 obj14 = new Class1787(reader);
					list_0.Add(new Class2605("alphaInv", obj14));
					break;
				}
				case "alphaMod":
				{
					Class1788 obj13 = new Class1788(reader);
					list_0.Add(new Class2605("alphaMod", obj13));
					break;
				}
				case "alphaModFix":
				{
					Class1789 obj12 = new Class1789(reader);
					list_0.Add(new Class2605("alphaModFix", obj12));
					break;
				}
				case "alphaRepl":
				{
					Class1791 obj11 = new Class1791(reader);
					list_0.Add(new Class2605("alphaRepl", obj11));
					break;
				}
				case "biLevel":
				{
					Class1807 obj10 = new Class1807(reader);
					list_0.Add(new Class2605("biLevel", obj10));
					break;
				}
				case "blur":
				{
					Class1811 obj9 = new Class1811(reader);
					list_0.Add(new Class2605("blur", obj9));
					break;
				}
				case "clrChange":
				{
					Class1813 obj8 = new Class1813(reader);
					list_0.Add(new Class2605("clrChange", obj8));
					break;
				}
				case "clrRepl":
				{
					Class1817 obj7 = new Class1817(reader);
					list_0.Add(new Class2605("clrRepl", obj7));
					break;
				}
				case "duotone":
				{
					Class1831 obj6 = new Class1831(reader);
					list_0.Add(new Class2605("duotone", obj6));
					break;
				}
				case "fillOverlay":
				{
					Class1841 obj5 = new Class1841(reader);
					list_0.Add(new Class2605("fillOverlay", obj5));
					break;
				}
				case "grayscl":
				{
					Class1857 obj4 = new Class1857(reader);
					list_0.Add(new Class2605("grayscl", obj4));
					break;
				}
				case "hsl":
				{
					Class1864 obj3 = new Class1864(reader);
					list_0.Add(new Class2605("hsl", obj3));
					break;
				}
				case "lum":
				{
					Class1877 obj2 = new Class1877(reader);
					list_0.Add(new Class2605("lum", obj2));
					break;
				}
				case "tint":
				{
					Class1975 obj = new Class1975(reader);
					list_0.Add(new Class2605("tint", obj));
					break;
				}
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
				case "cstate":
					enum310_0 = Class2438.smethod_0(reader.Value);
					break;
				case "r:link":
					string_3 = reader.Value;
					break;
				case "r:embed":
					string_2 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1809(XmlReader reader)
		: base(reader)
	{
	}

	public Class1809()
	{
	}

	protected override void vmethod_1()
	{
		string_2 = "";
		string_3 = "";
		enum310_0 = enum310_1;
		list_0 = new List<Class2605>();
	}

	protected override void vmethod_2()
	{
		delegate2773_0 = method_5;
		delegate1534_0 = method_3;
		delegate1535_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (string_2 != "")
		{
			writer.WriteAttributeString("r:embed", string_2);
		}
		if (string_3 != "")
		{
			writer.WriteAttributeString("r:link", string_3);
		}
		if (enum310_0 != enum310_1)
		{
			writer.WriteAttributeString("cstate", Class2438.smethod_1(enum310_0));
		}
		foreach (Class2605 item in list_0)
		{
			switch (item.Name)
			{
			case "alphaBiLevel":
				((Class1784)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "alphaCeiling":
				((Class1785)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "alphaFloor":
				((Class1786)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "alphaInv":
				((Class1787)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "alphaMod":
				((Class1788)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "alphaModFix":
				((Class1789)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "alphaRepl":
				((Class1791)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "biLevel":
				((Class1807)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "blur":
				((Class1811)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "clrChange":
				((Class1813)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "clrRepl":
				((Class1817)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "duotone":
				((Class1831)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "fillOverlay":
				((Class1841)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "grayscl":
				((Class1857)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "hsl":
				((Class1864)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "lum":
				((Class1877)item.Object).vmethod_4("a", writer, item.Name);
				break;
			case "tint":
				((Class1975)item.Object).vmethod_4("a", writer, item.Name);
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
		Class2605 @class = elementName switch
		{
			"alphaBiLevel" => new Class2605("alphaBiLevel", new Class1784()), 
			"alphaCeiling" => new Class2605("alphaCeiling", new Class1785()), 
			"alphaFloor" => new Class2605("alphaFloor", new Class1786()), 
			"alphaInv" => new Class2605("alphaInv", new Class1787()), 
			"alphaMod" => new Class2605("alphaMod", new Class1788()), 
			"alphaModFix" => new Class2605("alphaModFix", new Class1789()), 
			"alphaRepl" => new Class2605("alphaRepl", new Class1791()), 
			"biLevel" => new Class2605("biLevel", new Class1807()), 
			"blur" => new Class2605("blur", new Class1811()), 
			"clrChange" => new Class2605("clrChange", new Class1813()), 
			"clrRepl" => new Class2605("clrRepl", new Class1817()), 
			"duotone" => new Class2605("duotone", new Class1831()), 
			"fillOverlay" => new Class2605("fillOverlay", new Class1841()), 
			"grayscl" => new Class2605("grayscl", new Class1857()), 
			"hsl" => new Class2605("hsl", new Class1864()), 
			"lum" => new Class2605("lum", new Class1877()), 
			"tint" => new Class2605("tint", new Class1975()), 
			_ => throw new Exception("Wrong element: " + elementName), 
		};
		list_0.Add(@class);
		return @class;
	}

	public void method_6(Class2605 obj)
	{
		list_0.Add(obj);
	}
}
