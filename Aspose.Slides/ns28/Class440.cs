using System.Drawing;
using System.Xml;

namespace ns28;

internal class Class440 : Class369
{
	internal static readonly Class467 class467_0 = new Class467("lr-tb", "rl-tb", "tb-rl", "tb-lr", "lr", "rl", "tb", "page");

	internal static readonly Class467 class467_1 = new Class467("normal", "strict");

	internal static readonly Class467 class467_2 = new Class467("fix", "value-type");

	internal static readonly Class467 class467_3 = new Class467("none");

	internal static readonly Class467 class467_4 = new Class467("none", "bottom", "center", "top");

	internal static readonly Class467 class467_5 = new Class467("ltr", "ttb");

	internal static readonly Class467 class467_6 = new Class467("none", "formula-hidden", "hidden-and-protected", "protected", "protected formula-hidden");

	internal static readonly Class467 class467_7 = new Class467("wrap", "no-wrap");

	internal static readonly string string_0 = "table-cell-properties";

	internal static readonly string string_1 = "urn:oasis:names:tc:opendocument:xmlns:xsl-fo-compatible:1.0";

	protected Class460 class460_0;

	protected Class460 class460_1;

	protected Class460 class460_2;

	protected Class460 class460_3;

	protected Class460 class460_4;

	protected Class459 class459_0;

	protected Class459 class459_1;

	protected Class459 class459_2;

	protected Class459 class459_3;

	protected Class459 class459_4;

	public Color BackgroundColor
	{
		get
		{
			return method_16("background-color", string_1, ColorTranslator.FromWin32(0));
		}
		set
		{
			method_17("background-color", string_1, value);
		}
	}

	public Class460 Border
	{
		get
		{
			return class460_0;
		}
		set
		{
			class460_0 = value;
		}
	}

	public Class460 BorderLeft
	{
		get
		{
			return class460_3;
		}
		set
		{
			class460_3 = value;
		}
	}

	public Class460 BorderRight
	{
		get
		{
			return class460_4;
		}
		set
		{
			class460_4 = value;
		}
	}

	public Class460 BorderTop
	{
		get
		{
			return class460_1;
		}
		set
		{
			class460_1 = value;
		}
	}

	public Class460 BorderBottom
	{
		get
		{
			return class460_2;
		}
		set
		{
			class460_2 = value;
		}
	}

	public Class459 BorderLineWidth
	{
		get
		{
			return class459_0;
		}
		set
		{
			class459_0 = value;
		}
	}

	public Class459 BorderLineWidthTop
	{
		get
		{
			return class459_1;
		}
		set
		{
			class459_1 = value;
		}
	}

	public Class459 BorderLineWidthBottom
	{
		get
		{
			return class459_2;
		}
		set
		{
			class459_2 = value;
		}
	}

	public Class459 BorderLineWidthLeft
	{
		get
		{
			return class459_3;
		}
		set
		{
			class459_3 = value;
		}
	}

	public Class459 BorderLineWidthRight
	{
		get
		{
			return class459_4;
		}
		set
		{
			class459_4 = value;
		}
	}

	public int Padding
	{
		get
		{
			return method_13("padding", string_1, 0);
		}
		set
		{
			method_15("padding", string_1, value);
		}
	}

	public int PaddingTop
	{
		get
		{
			return method_13("padding-top", string_1, 0);
		}
		set
		{
			method_15("padding-top", string_1, value);
		}
	}

	public int PaddingBottom
	{
		get
		{
			return method_13("padding-bottom", string_1, 0);
		}
		set
		{
			method_15("padding-bottom", string_1, value);
		}
	}

	public int PaddingLeft
	{
		get
		{
			return method_13("padding-left", string_1, 0);
		}
		set
		{
			method_15("padding-left", string_1, value);
		}
	}

	public int PaddingRight
	{
		get
		{
			return method_13("padding-right", string_1, 0);
		}
		set
		{
			method_15("padding-right", string_1, value);
		}
	}

	public Enum27 CellProtect
	{
		get
		{
			return (Enum27)method_9(class467_6, "cell-protect", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_6, "cell-protect", NamespaceURI, (int)value);
		}
	}

	public int DecimalPlaces
	{
		get
		{
			return method_13("decimal-places", NamespaceURI, 0);
		}
		set
		{
			method_15("decimal-places", NamespaceURI, value);
		}
	}

	public string DiagonalBlTr
	{
		get
		{
			return method_0("diagonal-bl-tr", NamespaceURI, "");
		}
		set
		{
			SetAttribute("diagonal-bl-tr", NamespaceURI, value);
		}
	}

	public double DiagonalBlTrWidths
	{
		get
		{
			return method_7("diagonal-bl-tr-widths", NamespaceURI, 0.0);
		}
		set
		{
			method_8("diagonal-bl-tr-widths", NamespaceURI, value);
		}
	}

	public string DiagonalTlBr
	{
		get
		{
			return method_0("diagonal-tl-br", NamespaceURI, "");
		}
		set
		{
			SetAttribute("diagonal-tl-br", NamespaceURI, value);
		}
	}

	public double DiagonalTlBrWidths
	{
		get
		{
			return method_7("diagonal-tl-br-widths", NamespaceURI, 0.0);
		}
		set
		{
			method_8("diagonal-tl-br-widths", NamespaceURI, value);
		}
	}

	public Enum32 Direction
	{
		get
		{
			return (Enum32)method_9(class467_5, "direction", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_5, "direction", NamespaceURI, (int)value);
		}
	}

	public bool PrintContent
	{
		get
		{
			return method_3("print-content", NamespaceURI, defaultValue: true);
		}
		set
		{
			method_4("print-content", NamespaceURI, value);
		}
	}

	public bool RepeatContent
	{
		get
		{
			return method_3("repeat-content", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("repeat-content", NamespaceURI, value);
		}
	}

	public Enum71 RotationAlign
	{
		get
		{
			return (Enum71)method_9(class467_4, "direction", NamespaceURI, 3);
		}
		set
		{
			method_10(class467_4, "direction", NamespaceURI, (int)value);
		}
	}

	public double RotationAngle
	{
		get
		{
			return method_25("rotation-angle", NamespaceURI, 0.0);
		}
		set
		{
			method_26("rotation-angle", NamespaceURI, value);
		}
	}

	public Enum79 Shadow
	{
		get
		{
			return (Enum79)method_9(class467_3, "shadow", string_1, 0);
		}
		set
		{
			method_10(class467_3, "shadow", string_1, (int)value);
		}
	}

	public bool ShrinkToFit
	{
		get
		{
			return method_3("shrink-to-fit", NamespaceURI, defaultValue: false);
		}
		set
		{
			method_4("shrink-to-fit", NamespaceURI, value);
		}
	}

	public Enum90 TextAlignSource
	{
		get
		{
			return (Enum90)method_9(class467_2, "text-align-source", NamespaceURI, 0);
		}
		set
		{
			method_10(class467_2, "text-align-source", NamespaceURI, (int)value);
		}
	}

	public Enum105 VerticalAlign
	{
		get
		{
			return (Enum105)method_9(class467_1, "vertical-align", NamespaceURI, 3);
		}
		set
		{
			method_10(class467_1, "vertical-align", NamespaceURI, (int)value);
		}
	}

	public Enum109 WritingMode
	{
		get
		{
			return (Enum109)method_9(class467_0, "writing-mode", NamespaceURI, 7);
		}
		set
		{
			method_10(class467_0, "writing-mode", NamespaceURI, (int)value);
		}
	}

	public Class440(string prefix, string localName, string namespaceURI, XmlDocument doc)
		: base(prefix, localName, namespaceURI, doc)
	{
	}

	internal override void vmethod_0()
	{
		base.vmethod_0();
		class460_0 = new Class460(this, "border", string_1);
		class460_1 = new Class460(this, "border-top", string_1);
		class460_2 = new Class460(this, "border-bottom", string_1);
		class460_3 = new Class460(this, "border-left", string_1);
		class460_4 = new Class460(this, "border-right", string_1);
		class459_0 = new Class459(this, "border-line-width");
		class459_1 = new Class459(this, "border-line-width-top");
		class459_2 = new Class459(this, "border-line-width-bottom");
		class459_3 = new Class459(this, "border-line-width-left");
		class459_4 = new Class459(this, "border-line-width-right");
	}

	internal override void vmethod_1()
	{
		class460_0.Write(this, "border", string_1);
		class460_1.Write(this, "border-top", string_1);
		class460_2.Write(this, "border-bottom", string_1);
		class460_3.Write(this, "border-left", string_1);
		class460_4.Write(this, "border-right", string_1);
		class459_0.Write(this, "border-line-width");
		class459_1.Write(this, "border-line-width-top");
		class459_2.Write(this, "border-line-width-bottom");
		class459_3.Write(this, "border-line-width-left");
		class459_4.Write(this, "border-line-width-right");
		base.vmethod_1();
	}
}
