using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class2324 : Class1351
{
	public delegate Class2324 Delegate2719();

	public delegate void Delegate2720(Class2324 elementData);

	public delegate void Delegate2721(Class2324 elementData);

	public const Enum371 enum371_0 = Enum371.const_0;

	public const Enum352 enum352_0 = Enum352.const_0;

	public const int int_0 = 0;

	public const Enum352 enum352_1 = Enum352.const_0;

	public const Enum352 enum352_2 = Enum352.const_0;

	public const Enum352 enum352_3 = Enum352.const_0;

	public const Enum352 enum352_4 = Enum352.const_0;

	public const Enum352 enum352_5 = Enum352.const_0;

	public const Enum352 enum352_6 = Enum352.const_0;

	public const Enum352 enum352_7 = Enum352.const_0;

	public const float float_0 = float.NaN;

	public const Enum348 enum348_0 = Enum348.const_0;

	public const Enum352 enum352_8 = Enum352.const_0;

	public const Enum352 enum352_9 = Enum352.const_0;

	public const Enum352 enum352_10 = Enum352.const_0;

	public const int int_1 = 0;

	public const int int_2 = 0;

	public const int int_3 = 0;

	public const Enum349 enum349_0 = Enum349.const_0;

	public const Enum371 enum371_1 = Enum371.const_0;

	public const Enum371 enum371_2 = Enum371.const_0;

	public const Enum371 enum371_3 = Enum371.const_0;

	public const float float_1 = float.NaN;

	public const Enum341 enum341_0 = Enum341.const_0;

	public const Enum308 enum308_0 = Enum308.const_0;

	public const Enum308 enum308_1 = Enum308.const_0;

	public const Enum308 enum308_2 = Enum308.const_0;

	public const Enum352 enum352_11 = Enum352.const_0;

	public const Enum352 enum352_12 = Enum352.const_0;

	public const Enum351 enum351_0 = Enum351.const_0;

	public const Enum352 enum352_13 = Enum352.const_0;

	public const Enum352 enum352_14 = Enum352.const_0;

	public const Enum352 enum352_15 = Enum352.const_0;

	public Class2200.Delegate2336 delegate2336_0;

	public Class2200.Delegate2338 delegate2338_0;

	public Class2605.Delegate2773 delegate2773_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	private string string_7;

	private string string_8;

	private string string_9;

	private Enum371 enum371_4;

	private string string_10;

	private Enum352 enum352_16;

	private int int_4;

	private Enum352 enum352_17;

	private Enum352 enum352_18;

	private Enum352 enum352_19;

	private Enum352 enum352_20;

	private Enum352 enum352_21;

	private Enum352 enum352_22;

	private Enum352 enum352_23;

	private float float_2;

	private Enum348 enum348_1;

	private Enum352 enum352_24;

	private Enum352 enum352_25;

	private Enum352 enum352_26;

	private string string_11;

	private string string_12;

	private string string_13;

	private string string_14;

	private int int_5;

	private int int_6;

	private int int_7;

	private Enum349 enum349_1;

	private string string_15;

	private Enum371 enum371_5;

	private string string_16;

	private string string_17;

	private Enum371 enum371_6;

	private string string_18;

	private string string_19;

	private Enum371 enum371_7;

	private float float_3;

	private Enum341 enum341_1;

	private Enum308 enum308_3;

	private Enum308 enum308_4;

	private Enum308 enum308_5;

	private Enum352 enum352_27;

	private Enum352 enum352_28;

	private Enum351 enum351_1;

	private Enum352 enum352_29;

	private Enum352 enum352_30;

	private Enum352 enum352_31;

	private string string_20;

	private string string_21;

	private string string_22;

	private List<Class2605> list_0;

	private Class2200 class2200_0;

	public string Id
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

	public string Style
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public string Href
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

	public string Target
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

	public string Class
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public string Title
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public string Alt
	{
		get
		{
			return string_6;
		}
		set
		{
			string_6 = value;
		}
	}

	public string Coordsize
	{
		get
		{
			return string_7;
		}
		set
		{
			string_7 = value;
		}
	}

	public string Coordorigin
	{
		get
		{
			return string_8;
		}
		set
		{
			string_8 = value;
		}
	}

	public string Wrapcoords
	{
		get
		{
			return string_9;
		}
		set
		{
			string_9 = value;
		}
	}

	public Enum371 Print
	{
		get
		{
			return enum371_4;
		}
		set
		{
			enum371_4 = value;
		}
	}

	public string O_Spid
	{
		get
		{
			return string_10;
		}
		set
		{
			string_10 = value;
		}
	}

	public Enum352 O_Oned
	{
		get
		{
			return enum352_16;
		}
		set
		{
			enum352_16 = value;
		}
	}

	public int O_Regroupid
	{
		get
		{
			return int_4;
		}
		set
		{
			int_4 = value;
		}
	}

	public Enum352 O_Doubleclicknotify
	{
		get
		{
			return enum352_17;
		}
		set
		{
			enum352_17 = value;
		}
	}

	public Enum352 O_Button
	{
		get
		{
			return enum352_18;
		}
		set
		{
			enum352_18 = value;
		}
	}

	public Enum352 O_Userhidden
	{
		get
		{
			return enum352_19;
		}
		set
		{
			enum352_19 = value;
		}
	}

	public Enum352 O_Bullet
	{
		get
		{
			return enum352_20;
		}
		set
		{
			enum352_20 = value;
		}
	}

	public Enum352 O_Hr
	{
		get
		{
			return enum352_21;
		}
		set
		{
			enum352_21 = value;
		}
	}

	public Enum352 O_Hrstd
	{
		get
		{
			return enum352_22;
		}
		set
		{
			enum352_22 = value;
		}
	}

	public Enum352 O_Hrnoshade
	{
		get
		{
			return enum352_23;
		}
		set
		{
			enum352_23 = value;
		}
	}

	public float O_Hrpct
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	public Enum348 O_Hralign
	{
		get
		{
			return enum348_1;
		}
		set
		{
			enum348_1 = value;
		}
	}

	public Enum352 O_Allowincell
	{
		get
		{
			return enum352_24;
		}
		set
		{
			enum352_24 = value;
		}
	}

	public Enum352 O_Allowoverlap
	{
		get
		{
			return enum352_25;
		}
		set
		{
			enum352_25 = value;
		}
	}

	public Enum352 O_Userdrawn
	{
		get
		{
			return enum352_26;
		}
		set
		{
			enum352_26 = value;
		}
	}

	public string O_Bordertopcolor
	{
		get
		{
			return string_11;
		}
		set
		{
			string_11 = value;
		}
	}

	public string O_Borderleftcolor
	{
		get
		{
			return string_12;
		}
		set
		{
			string_12 = value;
		}
	}

	public string O_Borderbottomcolor
	{
		get
		{
			return string_13;
		}
		set
		{
			string_13 = value;
		}
	}

	public string O_Borderrightcolor
	{
		get
		{
			return string_14;
		}
		set
		{
			string_14 = value;
		}
	}

	public int O_Dgmlayout
	{
		get
		{
			return int_5;
		}
		set
		{
			int_5 = value;
		}
	}

	public int O_Dgmnodekind
	{
		get
		{
			return int_6;
		}
		set
		{
			int_6 = value;
		}
	}

	public int O_Dgmlayoutmru
	{
		get
		{
			return int_7;
		}
		set
		{
			int_7 = value;
		}
	}

	public Enum349 O_Insetmode
	{
		get
		{
			return enum349_1;
		}
		set
		{
			enum349_1 = value;
		}
	}

	public string Chromakey
	{
		get
		{
			return string_15;
		}
		set
		{
			string_15 = value;
		}
	}

	public Enum371 Filled
	{
		get
		{
			return enum371_5;
		}
		set
		{
			enum371_5 = value;
		}
	}

	public string Fillcolor
	{
		get
		{
			return string_16;
		}
		set
		{
			string_16 = value;
		}
	}

	public string Opacity
	{
		get
		{
			return string_17;
		}
		set
		{
			string_17 = value;
		}
	}

	public Enum371 Stroked
	{
		get
		{
			return enum371_6;
		}
		set
		{
			enum371_6 = value;
		}
	}

	public string Strokecolor
	{
		get
		{
			return string_18;
		}
		set
		{
			string_18 = value;
		}
	}

	public string Strokeweight
	{
		get
		{
			return string_19;
		}
		set
		{
			string_19 = value;
		}
	}

	public Enum371 Insetpen
	{
		get
		{
			return enum371_7;
		}
		set
		{
			enum371_7 = value;
		}
	}

	public float O_Spt
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	public Enum341 O_Connectortype
	{
		get
		{
			return enum341_1;
		}
		set
		{
			enum341_1 = value;
		}
	}

	public Enum308 O_Bwmode
	{
		get
		{
			return enum308_3;
		}
		set
		{
			enum308_3 = value;
		}
	}

	public Enum308 O_Bwpure
	{
		get
		{
			return enum308_4;
		}
		set
		{
			enum308_4 = value;
		}
	}

	public Enum308 O_Bwnormal
	{
		get
		{
			return enum308_5;
		}
		set
		{
			enum308_5 = value;
		}
	}

	public Enum352 O_Forcedash
	{
		get
		{
			return enum352_27;
		}
		set
		{
			enum352_27 = value;
		}
	}

	public Enum352 O_Oleicon
	{
		get
		{
			return enum352_28;
		}
		set
		{
			enum352_28 = value;
		}
	}

	public Enum351 O_Ole
	{
		get
		{
			return enum351_1;
		}
		set
		{
			enum351_1 = value;
		}
	}

	public Enum352 O_Preferrelative
	{
		get
		{
			return enum352_29;
		}
		set
		{
			enum352_29 = value;
		}
	}

	public Enum352 O_Cliptowrap
	{
		get
		{
			return enum352_30;
		}
		set
		{
			enum352_30 = value;
		}
	}

	public Enum352 O_Clip
	{
		get
		{
			return enum352_31;
		}
		set
		{
			enum352_31 = value;
		}
	}

	public string Adj
	{
		get
		{
			return string_20;
		}
		set
		{
			string_20 = value;
		}
	}

	public string Path
	{
		get
		{
			return string_21;
		}
		set
		{
			string_21 = value;
		}
	}

	public string O_Master
	{
		get
		{
			return string_22;
		}
		set
		{
			string_22 = value;
		}
	}

	public Class2605[] ShapeElementsList => list_0.ToArray();

	public Class2200 Complex => class2200_0;

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
				case "path":
				{
					Class2331 obj24 = new Class2331(reader);
					list_0.Add(new Class2605("path", obj24));
					break;
				}
				case "formulas":
				{
					Class2327 obj23 = new Class2327(reader);
					list_0.Add(new Class2605("formulas", obj23));
					break;
				}
				case "handles":
				{
					Class2328 obj22 = new Class2328(reader);
					list_0.Add(new Class2605("handles", obj22));
					break;
				}
				case "fill":
				{
					Class2326 obj21 = new Class2326(reader);
					list_0.Add(new Class2605("fill", obj21));
					break;
				}
				case "stroke":
				{
					Class2333 obj20 = new Class2333(reader);
					list_0.Add(new Class2605("stroke", obj20));
					break;
				}
				case "shadow":
				{
					Class2332 obj19 = new Class2332(reader);
					list_0.Add(new Class2605("shadow", obj19));
					break;
				}
				case "textbox":
				{
					Class1473 obj18 = new Class1473(reader);
					list_0.Add(new Class2605("textbox", obj18));
					flag = true;
					break;
				}
				case "textpath":
				{
					Class2334 obj17 = new Class2334(reader);
					list_0.Add(new Class2605("textpath", obj17));
					break;
				}
				case "imagedata":
				{
					Class2330 obj16 = new Class2330(reader);
					list_0.Add(new Class2605("imagedata", obj16));
					break;
				}
				case "skew":
				{
					Class2212 obj15 = new Class2212(reader);
					list_0.Add(new Class2605("skew", obj15));
					break;
				}
				case "extrusion":
				{
					Class2202 obj14 = new Class2202(reader);
					list_0.Add(new Class2605("extrusion", obj14));
					break;
				}
				case "callout":
				{
					Class2198 obj13 = new Class2198(reader);
					list_0.Add(new Class2605("callout", obj13));
					break;
				}
				case "lock":
				{
					Class2206 obj12 = new Class2206(reader);
					list_0.Add(new Class2605("lock", obj12));
					break;
				}
				case "clippath":
				{
					Class2199 obj11 = new Class2199(reader);
					list_0.Add(new Class2605("clippath", obj11));
					break;
				}
				case "signatureline":
				{
					Class2211 obj10 = new Class2211(reader);
					list_0.Add(new Class2605("signatureline", obj10));
					break;
				}
				case "wrap":
				{
					Class2337 obj9 = new Class2337(reader);
					list_0.Add(new Class2605("wrap", obj9));
					break;
				}
				case "anchorlock":
				{
					Class2335 obj8 = new Class2335(reader);
					list_0.Add(new Class2605("anchorlock", obj8));
					break;
				}
				case "bordertop":
				{
					Class2336 obj7 = new Class2336(reader);
					list_0.Add(new Class2605("bordertop", obj7));
					break;
				}
				case "borderbottom":
				{
					Class2336 obj6 = new Class2336(reader);
					list_0.Add(new Class2605("borderbottom", obj6));
					break;
				}
				case "borderleft":
				{
					Class2336 obj5 = new Class2336(reader);
					list_0.Add(new Class2605("borderleft", obj5));
					break;
				}
				case "borderright":
				{
					Class2336 obj4 = new Class2336(reader);
					list_0.Add(new Class2605("borderright", obj4));
					break;
				}
				case "ClientData":
				{
					Class1475 obj3 = new Class1475(reader);
					list_0.Add(new Class2605("ClientData", obj3));
					flag = true;
					break;
				}
				case "textdata":
				{
					Class2219 obj2 = new Class2219(reader);
					list_0.Add(new Class2605("textdata", obj2));
					break;
				}
				case "recolorinfo":
				{
					Class2217 obj = new Class2217(reader);
					list_0.Add(new Class2605("recolorinfo", obj));
					break;
				}
				case "complex":
					class2200_0 = new Class2200(reader);
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
				case "id":
					string_0 = reader.Value;
					break;
				case "style":
					string_1 = reader.Value;
					break;
				case "href":
					string_2 = reader.Value;
					break;
				case "target":
					string_3 = reader.Value;
					break;
				case "class":
					string_4 = reader.Value;
					break;
				case "title":
					string_5 = reader.Value;
					break;
				case "alt":
					string_6 = reader.Value;
					break;
				case "coordsize":
					string_7 = reader.Value;
					break;
				case "coordorigin":
					string_8 = reader.Value;
					break;
				case "wrapcoords":
					string_9 = reader.Value;
					break;
				case "print":
					enum371_4 = Class2507.smethod_0(reader.Value);
					break;
				case "o:spid":
					string_10 = reader.Value;
					break;
				case "o:oned":
					enum352_16 = Class2488.smethod_0(reader.Value);
					break;
				case "o:regroupid":
					int_4 = XmlConvert.ToInt32(reader.Value);
					break;
				case "o:doubleclicknotify":
					enum352_17 = Class2488.smethod_0(reader.Value);
					break;
				case "o:button":
					enum352_18 = Class2488.smethod_0(reader.Value);
					break;
				case "o:userhidden":
					enum352_19 = Class2488.smethod_0(reader.Value);
					break;
				case "o:bullet":
					enum352_20 = Class2488.smethod_0(reader.Value);
					break;
				case "o:hr":
					enum352_21 = Class2488.smethod_0(reader.Value);
					break;
				case "o:hrstd":
					enum352_22 = Class2488.smethod_0(reader.Value);
					break;
				case "o:hrnoshade":
					enum352_23 = Class2488.smethod_0(reader.Value);
					break;
				case "o:hrpct":
					float_2 = (float)ToDouble(reader.Value);
					break;
				case "o:hralign":
					enum348_1 = Class2484.smethod_0(reader.Value);
					break;
				case "o:allowincell":
					enum352_24 = Class2488.smethod_0(reader.Value);
					break;
				case "o:allowoverlap":
					enum352_25 = Class2488.smethod_0(reader.Value);
					break;
				case "o:userdrawn":
					enum352_26 = Class2488.smethod_0(reader.Value);
					break;
				case "o:bordertopcolor":
					string_11 = reader.Value;
					break;
				case "o:borderleftcolor":
					string_12 = reader.Value;
					break;
				case "o:borderbottomcolor":
					string_13 = reader.Value;
					break;
				case "o:borderrightcolor":
					string_14 = reader.Value;
					break;
				case "o:dgmlayout":
					int_5 = XmlConvert.ToInt32(reader.Value);
					break;
				case "o:dgmnodekind":
					int_6 = XmlConvert.ToInt32(reader.Value);
					break;
				case "o:dgmlayoutmru":
					int_7 = XmlConvert.ToInt32(reader.Value);
					break;
				case "o:insetmode":
					enum349_1 = Class2485.smethod_0(reader.Value);
					break;
				case "chromakey":
					string_15 = reader.Value;
					break;
				case "filled":
					enum371_5 = Class2507.smethod_0(reader.Value);
					break;
				case "fillcolor":
					string_16 = reader.Value;
					break;
				case "opacity":
					string_17 = reader.Value;
					break;
				case "stroked":
					enum371_6 = Class2507.smethod_0(reader.Value);
					break;
				case "strokecolor":
					string_18 = reader.Value;
					break;
				case "strokeweight":
					string_19 = reader.Value;
					break;
				case "insetpen":
					enum371_7 = Class2507.smethod_0(reader.Value);
					break;
				case "o:spt":
					float_3 = (float)ToDouble(reader.Value);
					break;
				case "o:connectortype":
					enum341_1 = Class2477.smethod_0(reader.Value);
					break;
				case "o:bwmode":
					enum308_3 = Class2475.smethod_0(reader.Value);
					break;
				case "o:bwpure":
					enum308_4 = Class2475.smethod_0(reader.Value);
					break;
				case "o:bwnormal":
					enum308_5 = Class2475.smethod_0(reader.Value);
					break;
				case "o:forcedash":
					enum352_27 = Class2488.smethod_0(reader.Value);
					break;
				case "o:oleicon":
					enum352_28 = Class2488.smethod_0(reader.Value);
					break;
				case "o:ole":
					enum351_1 = Class2487.smethod_0(reader.Value);
					break;
				case "o:preferrelative":
					enum352_29 = Class2488.smethod_0(reader.Value);
					break;
				case "o:cliptowrap":
					enum352_30 = Class2488.smethod_0(reader.Value);
					break;
				case "o:clip":
					enum352_31 = Class2488.smethod_0(reader.Value);
					break;
				case "adj":
					string_20 = reader.Value;
					break;
				case "path":
					string_21 = reader.Value;
					break;
				case "o:master":
					string_22 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2324(XmlReader reader)
		: base(reader)
	{
	}

	public Class2324()
	{
	}

	protected override void vmethod_1()
	{
		enum371_4 = Enum371.const_0;
		enum352_16 = Enum352.const_0;
		int_4 = 0;
		enum352_17 = Enum352.const_0;
		enum352_18 = Enum352.const_0;
		enum352_19 = Enum352.const_0;
		enum352_20 = Enum352.const_0;
		enum352_21 = Enum352.const_0;
		enum352_22 = Enum352.const_0;
		enum352_23 = Enum352.const_0;
		float_2 = float.NaN;
		enum348_1 = Enum348.const_0;
		enum352_24 = Enum352.const_0;
		enum352_25 = Enum352.const_0;
		enum352_26 = Enum352.const_0;
		int_5 = 0;
		int_6 = 0;
		int_7 = 0;
		enum349_1 = Enum349.const_0;
		enum371_5 = Enum371.const_0;
		enum371_6 = Enum371.const_0;
		enum371_7 = Enum371.const_0;
		float_3 = float.NaN;
		enum341_1 = Enum341.const_0;
		enum308_3 = Enum308.const_0;
		enum308_4 = Enum308.const_0;
		enum308_5 = Enum308.const_0;
		enum352_27 = Enum352.const_0;
		enum352_28 = Enum352.const_0;
		enum351_1 = Enum351.const_0;
		enum352_29 = Enum352.const_0;
		enum352_30 = Enum352.const_0;
		enum352_31 = Enum352.const_0;
		list_0 = new List<Class2605>();
	}

	protected override void vmethod_2()
	{
		delegate2773_0 = method_5;
		delegate2336_0 = method_3;
		delegate2338_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("v", elementName, "urn:schemas-microsoft-com:vml");
		if (writer.LookupPrefix("urn:schemas-microsoft-com:office:office") == null)
		{
			writer.WriteAttributeString("xmlns", "o", null, "urn:schemas-microsoft-com:office:office");
		}
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		if (writer.LookupPrefix("urn:schemas-microsoft-com:office:word") == null)
		{
			writer.WriteAttributeString("xmlns", "wvml", null, "urn:schemas-microsoft-com:office:word");
		}
		if (writer.LookupPrefix("urn:schemas-microsoft-com:office:excel") == null)
		{
			writer.WriteAttributeString("xmlns", "x", null, "urn:schemas-microsoft-com:office:excel");
		}
		if (writer.LookupPrefix("urn:schemas-microsoft-com:office:powerpoint") == null)
		{
			writer.WriteAttributeString("xmlns", "ppt", null, "urn:schemas-microsoft-com:office:powerpoint");
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("id", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("style", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("href", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("target", string_3);
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("class", string_4);
		}
		if (string_5 != null)
		{
			writer.WriteAttributeString("title", string_5);
		}
		if (string_6 != null)
		{
			writer.WriteAttributeString("alt", string_6);
		}
		if (string_7 != null)
		{
			writer.WriteAttributeString("coordsize", string_7);
		}
		if (string_8 != null)
		{
			writer.WriteAttributeString("coordorigin", string_8);
		}
		if (string_9 != null)
		{
			writer.WriteAttributeString("wrapcoords", string_9);
		}
		if (enum371_4 != 0)
		{
			writer.WriteAttributeString("print", Class2507.smethod_1(enum371_4));
		}
		if (string_10 != null)
		{
			writer.WriteAttributeString("o:spid", string_10);
		}
		if (enum352_16 != 0)
		{
			writer.WriteAttributeString("o:oned", Class2488.smethod_1(enum352_16));
		}
		if (int_4 != 0)
		{
			writer.WriteAttributeString("o:regroupid", XmlConvert.ToString(int_4));
		}
		if (enum352_17 != 0)
		{
			writer.WriteAttributeString("o:doubleclicknotify", Class2488.smethod_1(enum352_17));
		}
		if (enum352_18 != 0)
		{
			writer.WriteAttributeString("o:button", Class2488.smethod_1(enum352_18));
		}
		if (enum352_19 != 0)
		{
			writer.WriteAttributeString("o:userhidden", Class2488.smethod_1(enum352_19));
		}
		if (enum352_20 != 0)
		{
			writer.WriteAttributeString("o:bullet", Class2488.smethod_1(enum352_20));
		}
		if (enum352_21 != 0)
		{
			writer.WriteAttributeString("o:hr", Class2488.smethod_1(enum352_21));
		}
		if (enum352_22 != 0)
		{
			writer.WriteAttributeString("o:hrstd", Class2488.smethod_1(enum352_22));
		}
		if (enum352_23 != 0)
		{
			writer.WriteAttributeString("o:hrnoshade", Class2488.smethod_1(enum352_23));
		}
		if (!float.IsNaN(float_2))
		{
			writer.WriteAttributeString("o:hrpct", XmlConvert.ToString(float_2));
		}
		if (enum348_1 != 0)
		{
			writer.WriteAttributeString("o:hralign", Class2484.smethod_1(enum348_1));
		}
		if (enum352_24 != 0)
		{
			writer.WriteAttributeString("o:allowincell", Class2488.smethod_1(enum352_24));
		}
		if (enum352_25 != 0)
		{
			writer.WriteAttributeString("o:allowoverlap", Class2488.smethod_1(enum352_25));
		}
		if (enum352_26 != 0)
		{
			writer.WriteAttributeString("o:userdrawn", Class2488.smethod_1(enum352_26));
		}
		if (string_11 != null)
		{
			writer.WriteAttributeString("o:bordertopcolor", string_11);
		}
		if (string_12 != null)
		{
			writer.WriteAttributeString("o:borderleftcolor", string_12);
		}
		if (string_13 != null)
		{
			writer.WriteAttributeString("o:borderbottomcolor", string_13);
		}
		if (string_14 != null)
		{
			writer.WriteAttributeString("o:borderrightcolor", string_14);
		}
		if (int_5 != 0)
		{
			writer.WriteAttributeString("o:dgmlayout", XmlConvert.ToString(int_5));
		}
		if (int_6 != 0)
		{
			writer.WriteAttributeString("o:dgmnodekind", XmlConvert.ToString(int_6));
		}
		if (int_7 != 0)
		{
			writer.WriteAttributeString("o:dgmlayoutmru", XmlConvert.ToString(int_7));
		}
		if (enum349_1 != 0)
		{
			writer.WriteAttributeString("o:insetmode", Class2485.smethod_1(enum349_1));
		}
		if (string_15 != null)
		{
			writer.WriteAttributeString("chromakey", string_15);
		}
		if (enum371_5 != 0)
		{
			writer.WriteAttributeString("filled", Class2507.smethod_1(enum371_5));
		}
		if (string_16 != null)
		{
			writer.WriteAttributeString("fillcolor", string_16);
		}
		if (string_17 != null)
		{
			writer.WriteAttributeString("opacity", string_17);
		}
		if (enum371_6 != 0)
		{
			writer.WriteAttributeString("stroked", Class2507.smethod_1(enum371_6));
		}
		if (string_18 != null)
		{
			writer.WriteAttributeString("strokecolor", string_18);
		}
		if (string_19 != null)
		{
			writer.WriteAttributeString("strokeweight", string_19);
		}
		if (enum371_7 != 0)
		{
			writer.WriteAttributeString("insetpen", Class2507.smethod_1(enum371_7));
		}
		if (!float.IsNaN(float_3))
		{
			writer.WriteAttributeString("o:spt", XmlConvert.ToString(float_3));
		}
		if (enum341_1 != 0)
		{
			writer.WriteAttributeString("o:connectortype", Class2477.smethod_1(enum341_1));
		}
		if (enum308_3 != 0)
		{
			writer.WriteAttributeString("o:bwmode", Class2475.smethod_1(enum308_3));
		}
		if (enum308_4 != 0)
		{
			writer.WriteAttributeString("o:bwpure", Class2475.smethod_1(enum308_4));
		}
		if (enum308_5 != 0)
		{
			writer.WriteAttributeString("o:bwnormal", Class2475.smethod_1(enum308_5));
		}
		if (enum352_27 != 0)
		{
			writer.WriteAttributeString("o:forcedash", Class2488.smethod_1(enum352_27));
		}
		if (enum352_28 != 0)
		{
			writer.WriteAttributeString("o:oleicon", Class2488.smethod_1(enum352_28));
		}
		if (enum351_1 != 0)
		{
			writer.WriteAttributeString("o:ole", Class2487.smethod_1(enum351_1));
		}
		if (enum352_29 != 0)
		{
			writer.WriteAttributeString("o:preferrelative", Class2488.smethod_1(enum352_29));
		}
		if (enum352_30 != 0)
		{
			writer.WriteAttributeString("o:cliptowrap", Class2488.smethod_1(enum352_30));
		}
		if (enum352_31 != 0)
		{
			writer.WriteAttributeString("o:clip", Class2488.smethod_1(enum352_31));
		}
		if (string_20 != null)
		{
			writer.WriteAttributeString("adj", string_20);
		}
		if (string_21 != null)
		{
			writer.WriteAttributeString("path", string_21);
		}
		if (string_22 != null)
		{
			writer.WriteAttributeString("o:master", string_22);
		}
		if (list_0 != null)
		{
			foreach (Class2605 item in list_0)
			{
				switch (item.Name)
				{
				case "path":
					((Class2331)item.Object).vmethod_4("v", writer, item.Name);
					break;
				case "formulas":
					((Class2327)item.Object).vmethod_4("v", writer, item.Name);
					break;
				case "handles":
					((Class2328)item.Object).vmethod_4("v", writer, item.Name);
					break;
				case "fill":
					((Class2326)item.Object).vmethod_4("v", writer, item.Name);
					break;
				case "stroke":
					((Class2333)item.Object).vmethod_4("v", writer, item.Name);
					break;
				case "shadow":
					((Class2332)item.Object).vmethod_4("v", writer, item.Name);
					break;
				case "textbox":
					((Class1473)item.Object).vmethod_4("v", writer, item.Name);
					break;
				case "textpath":
					((Class2334)item.Object).vmethod_4("v", writer, item.Name);
					break;
				case "imagedata":
					((Class2330)item.Object).vmethod_4("v", writer, item.Name);
					break;
				case "skew":
					((Class2212)item.Object).vmethod_4("o", writer, item.Name);
					break;
				case "extrusion":
					((Class2202)item.Object).vmethod_4("o", writer, item.Name);
					break;
				case "callout":
					((Class2198)item.Object).vmethod_4("o", writer, item.Name);
					break;
				case "lock":
					((Class2206)item.Object).vmethod_4("o", writer, item.Name);
					break;
				case "clippath":
					((Class2199)item.Object).vmethod_4("o", writer, item.Name);
					break;
				case "signatureline":
					((Class2211)item.Object).vmethod_4("o", writer, item.Name);
					break;
				case "wrap":
					((Class2337)item.Object).vmethod_4("wvml", writer, item.Name);
					break;
				case "anchorlock":
					((Class2335)item.Object).vmethod_4("wvml", writer, item.Name);
					break;
				case "bordertop":
					((Class2336)item.Object).vmethod_4("wvml", writer, item.Name);
					break;
				case "borderbottom":
					((Class2336)item.Object).vmethod_4("wvml", writer, item.Name);
					break;
				case "borderleft":
					((Class2336)item.Object).vmethod_4("wvml", writer, item.Name);
					break;
				case "borderright":
					((Class2336)item.Object).vmethod_4("wvml", writer, item.Name);
					break;
				case "ClientData":
					((Class1475)item.Object).vmethod_4("x", writer, item.Name);
					break;
				case "textdata":
					((Class2219)item.Object).vmethod_4("ppt", writer, item.Name);
					break;
				case "recolorinfo":
					((Class2217)item.Object).vmethod_4("ppt", writer, item.Name);
					break;
				}
			}
		}
		if (class2200_0 != null)
		{
			class2200_0.vmethod_4("o", writer, "complex");
		}
		writer.WriteEndElement();
	}

	private Class2200 method_3()
	{
		if (class2200_0 != null)
		{
			throw new Exception("Only one <complex> element can be added.");
		}
		class2200_0 = new Class2200();
		return class2200_0;
	}

	private void method_4(Class2200 _complex)
	{
		class2200_0 = _complex;
	}

	private Class2605 method_5(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"path" => new Class2605("path", new Class2331()), 
			"formulas" => new Class2605("formulas", new Class2327()), 
			"handles" => new Class2605("handles", new Class2328()), 
			"fill" => new Class2605("fill", new Class2326()), 
			"stroke" => new Class2605("stroke", new Class2333()), 
			"shadow" => new Class2605("shadow", new Class2332()), 
			"textbox" => new Class2605("textbox", new Class1473()), 
			"textpath" => new Class2605("textpath", new Class2334()), 
			"imagedata" => new Class2605("imagedata", new Class2330()), 
			"skew" => new Class2605("skew", new Class2212()), 
			"extrusion" => new Class2605("extrusion", new Class2202()), 
			"callout" => new Class2605("callout", new Class2198()), 
			"lock" => new Class2605("lock", new Class2206()), 
			"clippath" => new Class2605("clippath", new Class2199()), 
			"signatureline" => new Class2605("signatureline", new Class2211()), 
			"wrap" => new Class2605("wrap", new Class2337()), 
			"anchorlock" => new Class2605("anchorlock", new Class2335()), 
			"bordertop" => new Class2605("bordertop", new Class2336()), 
			"borderbottom" => new Class2605("borderbottom", new Class2336()), 
			"borderleft" => new Class2605("borderleft", new Class2336()), 
			"borderright" => new Class2605("borderright", new Class2336()), 
			"ClientData" => new Class2605("ClientData", new Class1475()), 
			"textdata" => new Class2605("textdata", new Class2219()), 
			"recolorinfo" => new Class2605("recolorinfo", new Class2217()), 
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
