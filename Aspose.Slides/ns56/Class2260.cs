using System;
using System.Xml;

namespace ns56;

internal class Class2260 : Class1351
{
	public delegate Class2260 Delegate2527();

	public delegate void Delegate2529(Class2260 elementData);

	public delegate void Delegate2528(Class2260 elementData);

	public const bool bool_0 = true;

	public const uint uint_0 = uint.MaxValue;

	public Class2309.Delegate2674 delegate2674_0;

	public Class2309.Delegate2676 delegate2676_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2605.Delegate2773 delegate2773_0;

	private Enum360 enum360_0;

	private bool bool_1;

	private uint uint_1;

	private string string_0;

	private Class2605 class2605_0;

	private Class2309 class2309_0;

	private Class1889 class1889_0;

	public static readonly Enum360 enum360_1 = Class2496.smethod_0("fast");

	public Enum360 Spd
	{
		get
		{
			return enum360_0;
		}
		set
		{
			enum360_0 = value;
		}
	}

	public bool AdvClick
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

	public uint AdvTm
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

	public string P14_Dur
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

	public Class2605 Transition
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

	public Class2309 SndAc => class2309_0;

	public Class1885 ExtLst => class1889_0;

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
				case "blinds":
					class2605_0 = new Class2605("blinds", new Class2245(reader));
					break;
				case "checker":
					class2605_0 = new Class2605("checker", new Class2245(reader));
					break;
				case "circle":
					class2605_0 = new Class2605("circle", new Class2235(reader));
					break;
				case "dissolve":
					class2605_0 = new Class2605("dissolve", new Class2235(reader));
					break;
				case "comb":
					class2605_0 = new Class2605("comb", new Class2245(reader));
					break;
				case "cover":
					class2605_0 = new Class2605("cover", new Class2233(reader));
					break;
				case "cut":
					class2605_0 = new Class2605("cut", new Class2244(reader));
					break;
				case "diamond":
					class2605_0 = new Class2605("diamond", new Class2235(reader));
					break;
				case "fade":
					class2605_0 = new Class2605("fade", new Class2244(reader));
					break;
				case "newsflash":
					class2605_0 = new Class2605("newsflash", new Class2235(reader));
					break;
				case "plus":
					class2605_0 = new Class2605("plus", new Class2235(reader));
					break;
				case "pull":
					class2605_0 = new Class2605("pull", new Class2233(reader));
					break;
				case "push":
					class2605_0 = new Class2605("push", new Class2250(reader));
					break;
				case "random":
					class2605_0 = new Class2605("random", new Class2235(reader));
					break;
				case "randomBar":
					class2605_0 = new Class2605("randomBar", new Class2245(reader));
					break;
				case "split":
					class2605_0 = new Class2605("split", new Class2261(reader));
					break;
				case "strips":
					class2605_0 = new Class2605("strips", new Class2230(reader));
					break;
				case "wedge":
					class2605_0 = new Class2605("wedge", new Class2235(reader));
					break;
				case "wheel":
					class2605_0 = new Class2605("wheel", new Class2311(reader));
					break;
				case "wipe":
					class2605_0 = new Class2605("wipe", new Class2250(reader));
					break;
				case "zoom":
					class2605_0 = new Class2605("zoom", new Class2240(reader));
					break;
				case "vortex":
					class2605_0 = new Class2605("vortex", new Class2250(reader));
					break;
				case "switch":
					class2605_0 = new Class2605("switch", new Class1360(reader));
					break;
				case "flip":
					class2605_0 = new Class2605("flip", new Class1360(reader));
					break;
				case "ripple":
					class2605_0 = new Class2605("ripple", new Class1364(reader));
					break;
				case "honeycomb":
					class2605_0 = new Class2605("honeycomb", new Class2235(reader));
					break;
				case "prism":
					class2605_0 = new Class2605("prism", new Class1362(reader));
					break;
				case "doors":
					class2605_0 = new Class2605("doors", new Class2245(reader));
					break;
				case "window":
					class2605_0 = new Class2605("window", new Class2245(reader));
					break;
				case "ferris":
					class2605_0 = new Class2605("ferris", new Class1360(reader));
					break;
				case "gallery":
					class2605_0 = new Class2605("gallery", new Class1360(reader));
					break;
				case "conveyor":
					class2605_0 = new Class2605("conveyor", new Class1360(reader));
					break;
				case "pan":
					class2605_0 = new Class2605("pan", new Class2250(reader));
					break;
				case "glitter":
					class2605_0 = new Class2605("glitter", new Class1359(reader));
					break;
				case "warp":
					class2605_0 = new Class2605("warp", new Class2240(reader));
					break;
				case "flythrough":
					class2605_0 = new Class2605("flythrough", new Class1358(reader));
					break;
				case "flash":
					class2605_0 = new Class2605("flash", new Class2235(reader));
					break;
				case "shred":
					class2605_0 = new Class2605("shred", new Class1365(reader));
					break;
				case "reveal":
					class2605_0 = new Class2605("reveal", new Class1363(reader));
					break;
				case "wheelReverse":
					class2605_0 = new Class2605("wheelReverse", new Class2311(reader));
					break;
				case "prstTrans":
					class2605_0 = new Class2605("prstTrans", new Class1366(reader));
					break;
				case "sndAc":
					class2309_0 = new Class2309(reader);
					break;
				case "extLst":
					class1889_0 = new Class1889(reader);
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
				case "p14:dur":
					string_0 = reader.Value;
					break;
				case "advTm":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "advClick":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "spd":
					enum360_0 = Class2496.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2260(XmlReader reader)
		: base(reader)
	{
	}

	public Class2260()
	{
	}

	protected override void vmethod_1()
	{
		enum360_0 = enum360_1;
		bool_1 = true;
		uint_1 = uint.MaxValue;
	}

	protected override void vmethod_2()
	{
		delegate2773_0 = method_7;
		delegate2674_0 = method_3;
		delegate2676_0 = method_4;
		delegate1534_0 = method_5;
		delegate1535_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum360_0 != enum360_1)
		{
			writer.WriteAttributeString("spd", Class2496.smethod_1(enum360_0));
		}
		if (!bool_1)
		{
			writer.WriteAttributeString("advClick", bool_1 ? "1" : "0");
		}
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("advTm", XmlConvert.ToString(uint_1));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("p14:dur", string_0);
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "blinds":
				((Class2245)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "checker":
				((Class2245)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "circle":
				((Class2235)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "dissolve":
				((Class2235)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "comb":
				((Class2245)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "cover":
				((Class2233)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "cut":
				((Class2244)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "diamond":
				((Class2235)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "fade":
				((Class2244)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "newsflash":
				((Class2235)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "plus":
				((Class2235)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "pull":
				((Class2233)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "push":
				((Class2250)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "random":
				((Class2235)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "randomBar":
				((Class2245)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "split":
				((Class2261)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "strips":
				((Class2230)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "wedge":
				((Class2235)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "wheel":
				((Class2311)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "wipe":
				((Class2250)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "zoom":
				((Class2240)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "vortex":
				((Class2250)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "switch":
				((Class1360)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "flip":
				((Class1360)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "ripple":
				((Class1364)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "honeycomb":
				((Class2235)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "prism":
				((Class1362)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "doors":
				((Class2245)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "window":
				((Class2245)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "ferris":
				((Class1360)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "gallery":
				((Class1360)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "conveyor":
				((Class1360)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "pan":
				((Class2250)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "glitter":
				((Class1359)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "warp":
				((Class2240)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "flythrough":
				((Class1358)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "flash":
				((Class2235)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "shred":
				((Class1365)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "reveal":
				((Class1363)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "wheelReverse":
				((Class2311)class2605_0.Object).vmethod_4("p14", writer, class2605_0.Name);
				break;
			case "prstTrans":
				((Class1366)class2605_0.Object).vmethod_4("p15", writer, class2605_0.Name);
				break;
			}
		}
		if (class2309_0 != null)
		{
			class2309_0.vmethod_4("p", writer, "sndAc");
		}
		if (class1889_0 != null)
		{
			class1889_0.vmethod_4("p", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2309 method_3()
	{
		if (class2309_0 != null)
		{
			throw new Exception("Only one <sndAc> element can be added.");
		}
		class2309_0 = new Class2309();
		return class2309_0;
	}

	private void method_4(Class2309 _sndAc)
	{
		class2309_0 = _sndAc;
	}

	private Class1885 method_5()
	{
		if (class1889_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1889_0 = new Class1889();
		return class1889_0;
	}

	private void method_6(Class1885 _extLst)
	{
		class1889_0 = (Class1889)_extLst;
	}

	private Class2605 method_7(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("Transition already is initialized.");
		}
		switch (elementName)
		{
		case "blinds":
			class2605_0 = new Class2605("blinds", new Class2245());
			break;
		case "checker":
			class2605_0 = new Class2605("checker", new Class2245());
			break;
		case "circle":
			class2605_0 = new Class2605("circle", new Class2235());
			break;
		case "dissolve":
			class2605_0 = new Class2605("dissolve", new Class2235());
			break;
		case "comb":
			class2605_0 = new Class2605("comb", new Class2245());
			break;
		case "cover":
			class2605_0 = new Class2605("cover", new Class2233());
			break;
		case "cut":
			class2605_0 = new Class2605("cut", new Class2244());
			break;
		case "diamond":
			class2605_0 = new Class2605("diamond", new Class2235());
			break;
		case "fade":
			class2605_0 = new Class2605("fade", new Class2244());
			break;
		case "newsflash":
			class2605_0 = new Class2605("newsflash", new Class2235());
			break;
		case "plus":
			class2605_0 = new Class2605("plus", new Class2235());
			break;
		case "pull":
			class2605_0 = new Class2605("pull", new Class2233());
			break;
		case "push":
			class2605_0 = new Class2605("push", new Class2250());
			break;
		case "random":
			class2605_0 = new Class2605("random", new Class2235());
			break;
		case "randomBar":
			class2605_0 = new Class2605("randomBar", new Class2245());
			break;
		case "split":
			class2605_0 = new Class2605("split", new Class2261());
			break;
		case "strips":
			class2605_0 = new Class2605("strips", new Class2230());
			break;
		case "wedge":
			class2605_0 = new Class2605("wedge", new Class2235());
			break;
		case "wheel":
			class2605_0 = new Class2605("wheel", new Class2311());
			break;
		case "wipe":
			class2605_0 = new Class2605("wipe", new Class2250());
			break;
		case "zoom":
			class2605_0 = new Class2605("zoom", new Class2240());
			break;
		case "vortex":
			class2605_0 = new Class2605("vortex", new Class2250());
			break;
		case "switch":
			class2605_0 = new Class2605("switch", new Class1360());
			break;
		case "flip":
			class2605_0 = new Class2605("flip", new Class1360());
			break;
		case "ripple":
			class2605_0 = new Class2605("ripple", new Class1364());
			break;
		case "honeycomb":
			class2605_0 = new Class2605("honeycomb", new Class2235());
			break;
		case "prism":
			class2605_0 = new Class2605("prism", new Class1362());
			break;
		case "doors":
			class2605_0 = new Class2605("doors", new Class2245());
			break;
		case "window":
			class2605_0 = new Class2605("window", new Class2245());
			break;
		case "ferris":
			class2605_0 = new Class2605("ferris", new Class1360());
			break;
		case "gallery":
			class2605_0 = new Class2605("gallery", new Class1360());
			break;
		case "conveyor":
			class2605_0 = new Class2605("conveyor", new Class1360());
			break;
		case "pan":
			class2605_0 = new Class2605("pan", new Class2250());
			break;
		case "glitter":
			class2605_0 = new Class2605("glitter", new Class1359());
			break;
		case "warp":
			class2605_0 = new Class2605("warp", new Class2240());
			break;
		case "flythrough":
			class2605_0 = new Class2605("flythrough", new Class1358());
			break;
		case "flash":
			class2605_0 = new Class2605("flash", new Class2235());
			break;
		case "shred":
			class2605_0 = new Class2605("shred", new Class1365());
			break;
		case "reveal":
			class2605_0 = new Class2605("reveal", new Class1363());
			break;
		case "wheelReverse":
			class2605_0 = new Class2605("wheelReverse", new Class2311());
			break;
		case "prstTrans":
			class2605_0 = new Class2605("prstTrans", new Class1366());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
