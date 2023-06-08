using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1832 : Class1351
{
	public delegate Class1832 Delegate1375();

	public delegate void Delegate1376(Class1832 elementData);

	public delegate void Delegate1377(Class1832 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private Enum311 enum311_0;

	private string string_0;

	private List<Class2605> list_0;

	public static readonly Enum311 enum311_1 = Class2439.smethod_0("sib");

	public Enum311 Type
	{
		get
		{
			return enum311_0;
		}
		set
		{
			enum311_0 = value;
		}
	}

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class2605[] EffectList => list_0.ToArray();

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
				case "cont":
				{
					Class1832 obj30 = new Class1832(reader);
					list_0.Add(new Class2605("cont", obj30));
					break;
				}
				case "effect":
				{
					Class1835 obj29 = new Class1835(reader);
					list_0.Add(new Class2605("effect", obj29));
					break;
				}
				case "alphaBiLevel":
				{
					Class1784 obj28 = new Class1784(reader);
					list_0.Add(new Class2605("alphaBiLevel", obj28));
					break;
				}
				case "alphaCeiling":
				{
					Class1785 obj27 = new Class1785(reader);
					list_0.Add(new Class2605("alphaCeiling", obj27));
					break;
				}
				case "alphaFloor":
				{
					Class1786 obj26 = new Class1786(reader);
					list_0.Add(new Class2605("alphaFloor", obj26));
					break;
				}
				case "alphaInv":
				{
					Class1787 obj25 = new Class1787(reader);
					list_0.Add(new Class2605("alphaInv", obj25));
					break;
				}
				case "alphaMod":
				{
					Class1788 obj24 = new Class1788(reader);
					list_0.Add(new Class2605("alphaMod", obj24));
					break;
				}
				case "alphaModFix":
				{
					Class1789 obj23 = new Class1789(reader);
					list_0.Add(new Class2605("alphaModFix", obj23));
					break;
				}
				case "alphaOutset":
				{
					Class1790 obj22 = new Class1790(reader);
					list_0.Add(new Class2605("alphaOutset", obj22));
					break;
				}
				case "alphaRepl":
				{
					Class1791 obj21 = new Class1791(reader);
					list_0.Add(new Class2605("alphaRepl", obj21));
					break;
				}
				case "biLevel":
				{
					Class1807 obj20 = new Class1807(reader);
					list_0.Add(new Class2605("biLevel", obj20));
					break;
				}
				case "blend":
				{
					Class1808 obj19 = new Class1808(reader);
					list_0.Add(new Class2605("blend", obj19));
					break;
				}
				case "blur":
				{
					Class1811 obj18 = new Class1811(reader);
					list_0.Add(new Class2605("blur", obj18));
					break;
				}
				case "clrChange":
				{
					Class1813 obj17 = new Class1813(reader);
					list_0.Add(new Class2605("clrChange", obj17));
					break;
				}
				case "clrRepl":
				{
					Class1817 obj16 = new Class1817(reader);
					list_0.Add(new Class2605("clrRepl", obj16));
					break;
				}
				case "duotone":
				{
					Class1831 obj15 = new Class1831(reader);
					list_0.Add(new Class2605("duotone", obj15));
					break;
				}
				case "fill":
				{
					Class1840 obj14 = new Class1840(reader);
					list_0.Add(new Class2605("fill", obj14));
					break;
				}
				case "fillOverlay":
				{
					Class1841 obj13 = new Class1841(reader);
					list_0.Add(new Class2605("fillOverlay", obj13));
					break;
				}
				case "glow":
				{
					Class1852 obj12 = new Class1852(reader);
					list_0.Add(new Class2605("glow", obj12));
					break;
				}
				case "grayscl":
				{
					Class1857 obj11 = new Class1857(reader);
					list_0.Add(new Class2605("grayscl", obj11));
					break;
				}
				case "hsl":
				{
					Class1864 obj10 = new Class1864(reader);
					list_0.Add(new Class2605("hsl", obj10));
					break;
				}
				case "innerShdw":
				{
					Class1866 obj9 = new Class1866(reader);
					list_0.Add(new Class2605("innerShdw", obj9));
					break;
				}
				case "lum":
				{
					Class1877 obj8 = new Class1877(reader);
					list_0.Add(new Class2605("lum", obj8));
					break;
				}
				case "outerShdw":
				{
					Class1890 obj7 = new Class1890(reader);
					list_0.Add(new Class2605("outerShdw", obj7));
					break;
				}
				case "prstShdw":
				{
					Class1910 obj6 = new Class1910(reader);
					list_0.Add(new Class2605("prstShdw", obj6));
					break;
				}
				case "reflection":
				{
					Class1913 obj5 = new Class1913(reader);
					list_0.Add(new Class2605("reflection", obj5));
					break;
				}
				case "relOff":
				{
					Class1914 obj4 = new Class1914(reader);
					list_0.Add(new Class2605("relOff", obj4));
					break;
				}
				case "softEdge":
				{
					Class1923 obj3 = new Class1923(reader);
					list_0.Add(new Class2605("softEdge", obj3));
					break;
				}
				case "tint":
				{
					Class1975 obj2 = new Class1975(reader);
					list_0.Add(new Class2605("tint", obj2));
					break;
				}
				case "xfrm":
				{
					Class1977 obj = new Class1977(reader);
					list_0.Add(new Class2605("xfrm", obj));
					break;
				}
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
				case "name":
					string_0 = reader.Value;
					break;
				case "type":
					enum311_0 = Class2439.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1832(XmlReader reader)
		: base(reader)
	{
	}

	public Class1832()
	{
	}

	protected override void vmethod_1()
	{
		enum311_0 = enum311_1;
		list_0 = new List<Class2605>();
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
		if (enum311_0 != enum311_1)
		{
			writer.WriteAttributeString("type", Class2439.smethod_1(enum311_0));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("name", string_0);
		}
		if (list_0 != null)
		{
			foreach (Class2605 item in list_0)
			{
				switch (item.Name)
				{
				case "cont":
					((Class1832)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "effect":
					((Class1835)item.Object).vmethod_4("a", writer, item.Name);
					break;
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
				case "alphaOutset":
					((Class1790)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "alphaRepl":
					((Class1791)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "biLevel":
					((Class1807)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "blend":
					((Class1808)item.Object).vmethod_4("a", writer, item.Name);
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
				case "fill":
					((Class1840)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "fillOverlay":
					((Class1841)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "glow":
					((Class1852)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "grayscl":
					((Class1857)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "hsl":
					((Class1864)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "innerShdw":
					((Class1866)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "lum":
					((Class1877)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "outerShdw":
					((Class1890)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "prstShdw":
					((Class1910)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "reflection":
					((Class1913)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "relOff":
					((Class1914)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "softEdge":
					((Class1923)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "tint":
					((Class1975)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "xfrm":
					((Class1977)item.Object).vmethod_4("a", writer, item.Name);
					break;
				}
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"cont" => new Class2605("cont", new Class1832()), 
			"effect" => new Class2605("effect", new Class1835()), 
			"alphaBiLevel" => new Class2605("alphaBiLevel", new Class1784()), 
			"alphaCeiling" => new Class2605("alphaCeiling", new Class1785()), 
			"alphaFloor" => new Class2605("alphaFloor", new Class1786()), 
			"alphaInv" => new Class2605("alphaInv", new Class1787()), 
			"alphaMod" => new Class2605("alphaMod", new Class1788()), 
			"alphaModFix" => new Class2605("alphaModFix", new Class1789()), 
			"alphaOutset" => new Class2605("alphaOutset", new Class1790()), 
			"alphaRepl" => new Class2605("alphaRepl", new Class1791()), 
			"biLevel" => new Class2605("biLevel", new Class1807()), 
			"blend" => new Class2605("blend", new Class1808()), 
			"blur" => new Class2605("blur", new Class1811()), 
			"clrChange" => new Class2605("clrChange", new Class1813()), 
			"clrRepl" => new Class2605("clrRepl", new Class1817()), 
			"duotone" => new Class2605("duotone", new Class1831()), 
			"fill" => new Class2605("fill", new Class1840()), 
			"fillOverlay" => new Class2605("fillOverlay", new Class1841()), 
			"glow" => new Class2605("glow", new Class1852()), 
			"grayscl" => new Class2605("grayscl", new Class1857()), 
			"hsl" => new Class2605("hsl", new Class1864()), 
			"innerShdw" => new Class2605("innerShdw", new Class1866()), 
			"lum" => new Class2605("lum", new Class1877()), 
			"outerShdw" => new Class2605("outerShdw", new Class1890()), 
			"prstShdw" => new Class2605("prstShdw", new Class1910()), 
			"reflection" => new Class2605("reflection", new Class1913()), 
			"relOff" => new Class2605("relOff", new Class1914()), 
			"softEdge" => new Class2605("softEdge", new Class1923()), 
			"tint" => new Class2605("tint", new Class1975()), 
			"xfrm" => new Class2605("xfrm", new Class1977()), 
			_ => throw new Exception("Wrong element: " + elementName), 
		};
		list_0.Add(@class);
		return @class;
	}

	public void method_4(Class2605 obj)
	{
		list_0.Add(obj);
	}
}
