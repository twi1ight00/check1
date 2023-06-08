using System;
using System.Collections.Generic;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1907 : Class1351
{
	public delegate Class1907 Delegate1588();

	public delegate void Delegate1589(Class1907 elementData);

	public delegate void Delegate1590(Class1907 elementData);

	public const PresetColor presetColor_0 = PresetColor.AliceBlue;

	public Class2605.Delegate2773 delegate2773_0;

	private PresetColor presetColor_1;

	private List<Class2605> list_0;

	public PresetColor Val
	{
		get
		{
			return presetColor_1;
		}
		set
		{
			presetColor_1 = value;
		}
	}

	public Class2605[] ColorTransformList => list_0.ToArray();

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
				case "tint":
				{
					Class1901 obj28 = new Class1901(reader);
					list_0.Add(new Class2605("tint", obj28));
					break;
				}
				case "shade":
				{
					Class1901 obj27 = new Class1901(reader);
					list_0.Add(new Class2605("shade", obj27));
					break;
				}
				case "comp":
				{
					Class1821 obj26 = new Class1821(reader);
					list_0.Add(new Class2605("comp", obj26));
					break;
				}
				case "inv":
				{
					Class1868 obj25 = new Class1868(reader);
					list_0.Add(new Class2605("inv", obj25));
					break;
				}
				case "gray":
				{
					Class1858 obj24 = new Class1858(reader);
					list_0.Add(new Class2605("gray", obj24));
					break;
				}
				case "alpha":
				{
					Class1901 obj23 = new Class1901(reader);
					list_0.Add(new Class2605("alpha", obj23));
					break;
				}
				case "alphaOff":
				{
					Class1901 obj22 = new Class1901(reader);
					list_0.Add(new Class2605("alphaOff", obj22));
					break;
				}
				case "alphaMod":
				{
					Class1901 obj21 = new Class1901(reader);
					list_0.Add(new Class2605("alphaMod", obj21));
					break;
				}
				case "hue":
				{
					Class1792 obj20 = new Class1792(reader);
					list_0.Add(new Class2605("hue", obj20));
					break;
				}
				case "hueOff":
				{
					Class1792 obj19 = new Class1792(reader);
					list_0.Add(new Class2605("hueOff", obj19));
					break;
				}
				case "hueMod":
				{
					Class1901 obj18 = new Class1901(reader);
					list_0.Add(new Class2605("hueMod", obj18));
					break;
				}
				case "sat":
				{
					Class1901 obj17 = new Class1901(reader);
					list_0.Add(new Class2605("sat", obj17));
					break;
				}
				case "satOff":
				{
					Class1901 obj16 = new Class1901(reader);
					list_0.Add(new Class2605("satOff", obj16));
					break;
				}
				case "satMod":
				{
					Class1901 obj15 = new Class1901(reader);
					list_0.Add(new Class2605("satMod", obj15));
					break;
				}
				case "lum":
				{
					Class1901 obj14 = new Class1901(reader);
					list_0.Add(new Class2605("lum", obj14));
					break;
				}
				case "lumOff":
				{
					Class1901 obj13 = new Class1901(reader);
					list_0.Add(new Class2605("lumOff", obj13));
					break;
				}
				case "lumMod":
				{
					Class1901 obj12 = new Class1901(reader);
					list_0.Add(new Class2605("lumMod", obj12));
					break;
				}
				case "red":
				{
					Class1901 obj11 = new Class1901(reader);
					list_0.Add(new Class2605("red", obj11));
					break;
				}
				case "redOff":
				{
					Class1901 obj10 = new Class1901(reader);
					list_0.Add(new Class2605("redOff", obj10));
					break;
				}
				case "redMod":
				{
					Class1901 obj9 = new Class1901(reader);
					list_0.Add(new Class2605("redMod", obj9));
					break;
				}
				case "green":
				{
					Class1901 obj8 = new Class1901(reader);
					list_0.Add(new Class2605("green", obj8));
					break;
				}
				case "greenOff":
				{
					Class1901 obj7 = new Class1901(reader);
					list_0.Add(new Class2605("greenOff", obj7));
					break;
				}
				case "greenMod":
				{
					Class1901 obj6 = new Class1901(reader);
					list_0.Add(new Class2605("greenMod", obj6));
					break;
				}
				case "blue":
				{
					Class1901 obj5 = new Class1901(reader);
					list_0.Add(new Class2605("blue", obj5));
					break;
				}
				case "blueOff":
				{
					Class1901 obj4 = new Class1901(reader);
					list_0.Add(new Class2605("blueOff", obj4));
					break;
				}
				case "blueMod":
				{
					Class1901 obj3 = new Class1901(reader);
					list_0.Add(new Class2605("blueMod", obj3));
					break;
				}
				case "gamma":
				{
					Class1848 obj2 = new Class1848(reader);
					list_0.Add(new Class2605("gamma", obj2));
					break;
				}
				case "invGamma":
				{
					Class1867 obj = new Class1867(reader);
					list_0.Add(new Class2605("invGamma", obj));
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
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "val")
			{
				presetColor_1 = Class2547.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1907(XmlReader reader)
		: base(reader)
	{
	}

	public Class1907()
	{
	}

	protected override void vmethod_1()
	{
		presetColor_1 = PresetColor.AliceBlue;
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
		if (presetColor_1 != 0)
		{
			writer.WriteAttributeString("val", Class2547.smethod_1(presetColor_1));
		}
		if (list_0 != null)
		{
			foreach (Class2605 item in list_0)
			{
				switch (item.Name)
				{
				case "tint":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "shade":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "comp":
					((Class1821)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "inv":
					((Class1868)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "gray":
					((Class1858)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "alpha":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "alphaOff":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "alphaMod":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "hue":
					((Class1792)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "hueOff":
					((Class1792)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "hueMod":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "sat":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "satOff":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "satMod":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "lum":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "lumOff":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "lumMod":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "red":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "redOff":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "redMod":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "green":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "greenOff":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "greenMod":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "blue":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "blueOff":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "blueMod":
					((Class1901)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "gamma":
					((Class1848)item.Object).vmethod_4("a", writer, item.Name);
					break;
				case "invGamma":
					((Class1867)item.Object).vmethod_4("a", writer, item.Name);
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
			"tint" => new Class2605("tint", new Class1901()), 
			"shade" => new Class2605("shade", new Class1901()), 
			"comp" => new Class2605("comp", new Class1821()), 
			"inv" => new Class2605("inv", new Class1868()), 
			"gray" => new Class2605("gray", new Class1858()), 
			"alpha" => new Class2605("alpha", new Class1901()), 
			"alphaOff" => new Class2605("alphaOff", new Class1901()), 
			"alphaMod" => new Class2605("alphaMod", new Class1901()), 
			"hue" => new Class2605("hue", new Class1792()), 
			"hueOff" => new Class2605("hueOff", new Class1792()), 
			"hueMod" => new Class2605("hueMod", new Class1901()), 
			"sat" => new Class2605("sat", new Class1901()), 
			"satOff" => new Class2605("satOff", new Class1901()), 
			"satMod" => new Class2605("satMod", new Class1901()), 
			"lum" => new Class2605("lum", new Class1901()), 
			"lumOff" => new Class2605("lumOff", new Class1901()), 
			"lumMod" => new Class2605("lumMod", new Class1901()), 
			"red" => new Class2605("red", new Class1901()), 
			"redOff" => new Class2605("redOff", new Class1901()), 
			"redMod" => new Class2605("redMod", new Class1901()), 
			"green" => new Class2605("green", new Class1901()), 
			"greenOff" => new Class2605("greenOff", new Class1901()), 
			"greenMod" => new Class2605("greenMod", new Class1901()), 
			"blue" => new Class2605("blue", new Class1901()), 
			"blueOff" => new Class2605("blueOff", new Class1901()), 
			"blueMod" => new Class2605("blueMod", new Class1901()), 
			"gamma" => new Class2605("gamma", new Class1848()), 
			"invGamma" => new Class2605("invGamma", new Class1867()), 
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
