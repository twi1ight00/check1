using System.Xml;

namespace ns56;

internal class Class2202 : Class1351
{
	public delegate Class2202 Delegate2342();

	public delegate void Delegate2343(Class2202 elementData);

	public delegate void Delegate2344(Class2202 elementData);

	public const Enum362 enum362_0 = Enum362.const_0;

	public const Enum352 enum352_0 = Enum352.const_0;

	public const float float_0 = float.NaN;

	public const float float_1 = float.NaN;

	public const Enum352 enum352_1 = Enum352.const_0;

	public const Enum352 enum352_2 = Enum352.const_0;

	public const Enum340 enum340_0 = Enum340.const_0;

	public const float float_2 = float.NaN;

	public const Enum352 enum352_3 = Enum352.const_0;

	public const Enum352 enum352_4 = Enum352.const_0;

	public const Enum352 enum352_5 = Enum352.const_0;

	public const Enum352 enum352_6 = Enum352.const_0;

	private Enum362 enum362_1;

	private Enum352 enum352_7;

	private Enum345 enum345_0;

	private Enum344 enum344_0;

	private string string_0;

	private string string_1;

	private Enum343 enum343_0;

	private float float_3;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private float float_4;

	private Enum352 enum352_8;

	private Enum352 enum352_9;

	private string string_6;

	private string string_7;

	private Enum340 enum340_1;

	private string string_8;

	private float float_5;

	private string string_9;

	private string string_10;

	private Enum352 enum352_10;

	private string string_11;

	private string string_12;

	private Enum352 enum352_11;

	private string string_13;

	private string string_14;

	private string string_15;

	private Enum352 enum352_12;

	private string string_16;

	private string string_17;

	private Enum352 enum352_13;

	public static readonly Enum345 enum345_1 = Class2481.smethod_0("parallel");

	public static readonly Enum344 enum344_1 = Class2480.smethod_0("solid");

	public static readonly Enum343 enum343_1 = Class2479.smethod_0("XY");

	public Enum362 V_Ext
	{
		get
		{
			return enum362_1;
		}
		set
		{
			enum362_1 = value;
		}
	}

	public Enum352 On
	{
		get
		{
			return enum352_7;
		}
		set
		{
			enum352_7 = value;
		}
	}

	public Enum345 Type
	{
		get
		{
			return enum345_0;
		}
		set
		{
			enum345_0 = value;
		}
	}

	public Enum344 Render
	{
		get
		{
			return enum344_0;
		}
		set
		{
			enum344_0 = value;
		}
	}

	public string Viewpointorigin
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

	public string Viewpoint
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

	public Enum343 Plane
	{
		get
		{
			return enum343_0;
		}
		set
		{
			enum343_0 = value;
		}
	}

	public float Skewangle
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

	public string Skewamt
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

	public string Foredepth
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

	public string Backdepth
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

	public string Orientation
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

	public float Orientationangle
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
		}
	}

	public Enum352 Lockrotationcenter
	{
		get
		{
			return enum352_8;
		}
		set
		{
			enum352_8 = value;
		}
	}

	public Enum352 Autorotationcenter
	{
		get
		{
			return enum352_9;
		}
		set
		{
			enum352_9 = value;
		}
	}

	public string Rotationcenter
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

	public string Rotationangle
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

	public Enum340 Colormode
	{
		get
		{
			return enum340_1;
		}
		set
		{
			enum340_1 = value;
		}
	}

	public string Color
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

	public float Shininess
	{
		get
		{
			return float_5;
		}
		set
		{
			float_5 = value;
		}
	}

	public string Specularity
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

	public string Diffusity
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

	public Enum352 Metal
	{
		get
		{
			return enum352_10;
		}
		set
		{
			enum352_10 = value;
		}
	}

	public string Edge
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

	public string Facet
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

	public Enum352 Lightface
	{
		get
		{
			return enum352_11;
		}
		set
		{
			enum352_11 = value;
		}
	}

	public string Brightness
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

	public string Lightposition
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

	public string Lightlevel
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

	public Enum352 Lightharsh
	{
		get
		{
			return enum352_12;
		}
		set
		{
			enum352_12 = value;
		}
	}

	public string Lightposition2
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

	public string Lightlevel2
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

	public Enum352 Lightharsh2
	{
		get
		{
			return enum352_13;
		}
		set
		{
			enum352_13 = value;
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
				_ = reader.LocalName;
				reader.Skip();
				flag = true;
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
				case "v:ext":
					enum362_1 = Class2498.smethod_0(reader.Value);
					break;
				case "on":
					enum352_7 = Class2488.smethod_0(reader.Value);
					break;
				case "type":
					enum345_0 = Class2481.smethod_0(reader.Value);
					break;
				case "render":
					enum344_0 = Class2480.smethod_0(reader.Value);
					break;
				case "viewpointorigin":
					string_0 = reader.Value;
					break;
				case "viewpoint":
					string_1 = reader.Value;
					break;
				case "plane":
					enum343_0 = Class2479.smethod_0(reader.Value);
					break;
				case "skewangle":
					float_3 = (float)ToDouble(reader.Value);
					break;
				case "skewamt":
					string_2 = reader.Value;
					break;
				case "foredepth":
					string_3 = reader.Value;
					break;
				case "backdepth":
					string_4 = reader.Value;
					break;
				case "orientation":
					string_5 = reader.Value;
					break;
				case "orientationangle":
					float_4 = (float)ToDouble(reader.Value);
					break;
				case "lockrotationcenter":
					enum352_8 = Class2488.smethod_0(reader.Value);
					break;
				case "autorotationcenter":
					enum352_9 = Class2488.smethod_0(reader.Value);
					break;
				case "rotationcenter":
					string_6 = reader.Value;
					break;
				case "rotationangle":
					string_7 = reader.Value;
					break;
				case "colormode":
					enum340_1 = Class2476.smethod_0(reader.Value);
					break;
				case "color":
					string_8 = reader.Value;
					break;
				case "shininess":
					float_5 = (float)ToDouble(reader.Value);
					break;
				case "specularity":
					string_9 = reader.Value;
					break;
				case "diffusity":
					string_10 = reader.Value;
					break;
				case "metal":
					enum352_10 = Class2488.smethod_0(reader.Value);
					break;
				case "edge":
					string_11 = reader.Value;
					break;
				case "facet":
					string_12 = reader.Value;
					break;
				case "lightface":
					enum352_11 = Class2488.smethod_0(reader.Value);
					break;
				case "brightness":
					string_13 = reader.Value;
					break;
				case "lightposition":
					string_14 = reader.Value;
					break;
				case "lightlevel":
					string_15 = reader.Value;
					break;
				case "lightharsh":
					enum352_12 = Class2488.smethod_0(reader.Value);
					break;
				case "lightposition2":
					string_16 = reader.Value;
					break;
				case "lightlevel2":
					string_17 = reader.Value;
					break;
				case "lightharsh2":
					enum352_13 = Class2488.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2202(XmlReader reader)
		: base(reader)
	{
	}

	public Class2202()
	{
	}

	protected override void vmethod_1()
	{
		enum362_1 = Enum362.const_0;
		enum352_7 = Enum352.const_0;
		enum345_0 = enum345_1;
		enum344_0 = enum344_1;
		enum343_0 = enum343_1;
		float_3 = float.NaN;
		float_4 = float.NaN;
		enum352_8 = Enum352.const_0;
		enum352_9 = Enum352.const_0;
		enum340_1 = Enum340.const_0;
		float_5 = float.NaN;
		enum352_10 = Enum352.const_0;
		enum352_11 = Enum352.const_0;
		enum352_12 = Enum352.const_0;
		enum352_13 = Enum352.const_0;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum362_1 != 0)
		{
			writer.WriteAttributeString("v:ext", Class2498.smethod_1(enum362_1));
		}
		if (enum352_7 != 0)
		{
			writer.WriteAttributeString("on", Class2488.smethod_1(enum352_7));
		}
		if (enum345_0 != enum345_1)
		{
			writer.WriteAttributeString("type", Class2481.smethod_1(enum345_0));
		}
		if (enum344_0 != enum344_1)
		{
			writer.WriteAttributeString("render", Class2480.smethod_1(enum344_0));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("viewpointorigin", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("viewpoint", string_1);
		}
		if (enum343_0 != enum343_1)
		{
			writer.WriteAttributeString("plane", Class2479.smethod_1(enum343_0));
		}
		if (!float.IsNaN(float_3))
		{
			writer.WriteAttributeString("skewangle", XmlConvert.ToString(float_3));
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("skewamt", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("foredepth", string_3);
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("backdepth", string_4);
		}
		if (string_5 != null)
		{
			writer.WriteAttributeString("orientation", string_5);
		}
		if (!float.IsNaN(float_4))
		{
			writer.WriteAttributeString("orientationangle", XmlConvert.ToString(float_4));
		}
		if (enum352_8 != 0)
		{
			writer.WriteAttributeString("lockrotationcenter", Class2488.smethod_1(enum352_8));
		}
		if (enum352_9 != 0)
		{
			writer.WriteAttributeString("autorotationcenter", Class2488.smethod_1(enum352_9));
		}
		if (string_6 != null)
		{
			writer.WriteAttributeString("rotationcenter", string_6);
		}
		if (string_7 != null)
		{
			writer.WriteAttributeString("rotationangle", string_7);
		}
		if (enum340_1 != 0)
		{
			writer.WriteAttributeString("colormode", Class2476.smethod_1(enum340_1));
		}
		if (string_8 != null)
		{
			writer.WriteAttributeString("color", string_8);
		}
		if (!float.IsNaN(float_5))
		{
			writer.WriteAttributeString("shininess", XmlConvert.ToString(float_5));
		}
		if (string_9 != null)
		{
			writer.WriteAttributeString("specularity", string_9);
		}
		if (string_10 != null)
		{
			writer.WriteAttributeString("diffusity", string_10);
		}
		if (enum352_10 != 0)
		{
			writer.WriteAttributeString("metal", Class2488.smethod_1(enum352_10));
		}
		if (string_11 != null)
		{
			writer.WriteAttributeString("edge", string_11);
		}
		if (string_12 != null)
		{
			writer.WriteAttributeString("facet", string_12);
		}
		if (enum352_11 != 0)
		{
			writer.WriteAttributeString("lightface", Class2488.smethod_1(enum352_11));
		}
		if (string_13 != null)
		{
			writer.WriteAttributeString("brightness", string_13);
		}
		if (string_14 != null)
		{
			writer.WriteAttributeString("lightposition", string_14);
		}
		if (string_15 != null)
		{
			writer.WriteAttributeString("lightlevel", string_15);
		}
		if (enum352_12 != 0)
		{
			writer.WriteAttributeString("lightharsh", Class2488.smethod_1(enum352_12));
		}
		if (string_16 != null)
		{
			writer.WriteAttributeString("lightposition2", string_16);
		}
		if (string_17 != null)
		{
			writer.WriteAttributeString("lightlevel2", string_17);
		}
		if (enum352_13 != 0)
		{
			writer.WriteAttributeString("lightharsh2", Class2488.smethod_1(enum352_13));
		}
		writer.WriteEndElement();
	}
}
