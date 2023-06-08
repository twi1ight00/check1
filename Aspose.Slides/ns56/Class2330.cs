using System.Xml;

namespace ns56;

internal class Class2330 : Class1351
{
	public delegate Class2330 Delegate2737();

	public delegate void Delegate2738(Class2330 elementData);

	public delegate void Delegate2739(Class2330 elementData);

	public const Enum371 enum371_0 = Enum371.const_0;

	public const Enum371 enum371_1 = Enum371.const_0;

	public const float float_0 = float.NaN;

	public const Enum352 enum352_0 = Enum352.const_0;

	public const float float_1 = float.NaN;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	private string string_7;

	private string string_8;

	private Enum371 enum371_2;

	private Enum371 enum371_3;

	private string string_9;

	private string string_10;

	private string string_11;

	private string string_12;

	private string string_13;

	private string string_14;

	private float float_2;

	private Enum352 enum352_1;

	private float float_3;

	private string string_15;

	private string string_16;

	private string string_17;

	private string string_18;

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

	public string Src
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

	public string Cropleft
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

	public string Croptop
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

	public string Cropright
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

	public string Cropbottom
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

	public string Gain
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

	public string Blacklevel
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

	public string Gamma
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

	public Enum371 Grayscale
	{
		get
		{
			return enum371_2;
		}
		set
		{
			enum371_2 = value;
		}
	}

	public Enum371 Bilevel
	{
		get
		{
			return enum371_3;
		}
		set
		{
			enum371_3 = value;
		}
	}

	public string Chromakey
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

	public string Embosscolor
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

	public string Recolortarget
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

	public string O_Href
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

	public string O_Althref
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

	public string O_Title
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

	public float O_Oleid
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

	public Enum352 O_Detectmouseclick
	{
		get
		{
			return enum352_1;
		}
		set
		{
			enum352_1 = value;
		}
	}

	public float O_Movie
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

	public string O_Relid
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

	public string R_Id
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

	public string R_Pict
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

	public string R_Href
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
				case "id":
					string_0 = reader.Value;
					break;
				case "src":
					string_1 = reader.Value;
					break;
				case "cropleft":
					string_2 = reader.Value;
					break;
				case "croptop":
					string_3 = reader.Value;
					break;
				case "cropright":
					string_4 = reader.Value;
					break;
				case "cropbottom":
					string_5 = reader.Value;
					break;
				case "gain":
					string_6 = reader.Value;
					break;
				case "blacklevel":
					string_7 = reader.Value;
					break;
				case "gamma":
					string_8 = reader.Value;
					break;
				case "grayscale":
					enum371_2 = Class2507.smethod_0(reader.Value);
					break;
				case "bilevel":
					enum371_3 = Class2507.smethod_0(reader.Value);
					break;
				case "chromakey":
					string_9 = reader.Value;
					break;
				case "embosscolor":
					string_10 = reader.Value;
					break;
				case "recolortarget":
					string_11 = reader.Value;
					break;
				case "o:href":
					string_12 = reader.Value;
					break;
				case "o:althref":
					string_13 = reader.Value;
					break;
				case "o:title":
					string_14 = reader.Value;
					break;
				case "o:oleid":
					float_2 = (float)ToDouble(reader.Value);
					break;
				case "o:detectmouseclick":
					enum352_1 = Class2488.smethod_0(reader.Value);
					break;
				case "o:movie":
					float_3 = (float)ToDouble(reader.Value);
					break;
				case "o:relid":
					string_15 = reader.Value;
					break;
				case "r:id":
					string_16 = reader.Value;
					break;
				case "r:pict":
					string_17 = reader.Value;
					break;
				case "r:href":
					string_18 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2330(XmlReader reader)
		: base(reader)
	{
	}

	public Class2330()
	{
	}

	protected override void vmethod_1()
	{
		enum371_2 = Enum371.const_0;
		enum371_3 = Enum371.const_0;
		float_2 = float.NaN;
		enum352_1 = Enum352.const_0;
		float_3 = float.NaN;
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
		if (string_0 != null)
		{
			writer.WriteAttributeString("id", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("src", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("cropleft", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("croptop", string_3);
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("cropright", string_4);
		}
		if (string_5 != null)
		{
			writer.WriteAttributeString("cropbottom", string_5);
		}
		if (string_6 != null)
		{
			writer.WriteAttributeString("gain", string_6);
		}
		if (string_7 != null)
		{
			writer.WriteAttributeString("blacklevel", string_7);
		}
		if (string_8 != null)
		{
			writer.WriteAttributeString("gamma", string_8);
		}
		if (enum371_2 != 0)
		{
			writer.WriteAttributeString("grayscale", Class2507.smethod_1(enum371_2));
		}
		if (enum371_3 != 0)
		{
			writer.WriteAttributeString("bilevel", Class2507.smethod_1(enum371_3));
		}
		if (string_9 != null)
		{
			writer.WriteAttributeString("chromakey", string_9);
		}
		if (string_10 != null)
		{
			writer.WriteAttributeString("embosscolor", string_10);
		}
		if (string_11 != null)
		{
			writer.WriteAttributeString("recolortarget", string_11);
		}
		if (string_12 != null)
		{
			writer.WriteAttributeString("o:href", string_12);
		}
		if (string_13 != null)
		{
			writer.WriteAttributeString("o:althref", string_13);
		}
		if (string_14 != null)
		{
			writer.WriteAttributeString("o:title", string_14);
		}
		if (!float.IsNaN(float_2))
		{
			writer.WriteAttributeString("o:oleid", XmlConvert.ToString(float_2));
		}
		if (enum352_1 != 0)
		{
			writer.WriteAttributeString("o:detectmouseclick", Class2488.smethod_1(enum352_1));
		}
		if (!float.IsNaN(float_3))
		{
			writer.WriteAttributeString("o:movie", XmlConvert.ToString(float_3));
		}
		if (string_15 != null)
		{
			writer.WriteAttributeString("o:relid", string_15);
		}
		if (string_16 != null)
		{
			writer.WriteAttributeString("r:id", string_16);
		}
		if (string_17 != null)
		{
			writer.WriteAttributeString("r:pict", string_17);
		}
		if (string_18 != null)
		{
			writer.WriteAttributeString("r:href", string_18);
		}
		writer.WriteEndElement();
	}
}
