using System;
using System.Drawing;
using ns301;

namespace ns284;

internal abstract class Class6895 : ICloneable, Interface329
{
	private const string string_0 = "Times New Roman";

	private FontStyle fontStyle_0;

	private float float_0;

	private int int_0;

	private string string_1;

	private bool bool_0;

	private Enum952 enum952_0;

	private Enum953 enum953_0;

	private Enum954 enum954_0;

	private Enum935 enum935_0;

	private Enum956 enum956_0;

	private Color color_0;

	private string string_2;

	private Rectangle rectangle_0;

	private Color color_1;

	private Color color_2 = Color.Empty;

	private Color color_3 = Color.Empty;

	private Enum957 enum957_0;

	private Enum958 enum958_0;

	private Enum948 enum948_0;

	private Enum959 enum959_0;

	private float float_1;

	private Class6959 class6959_0;

	private Class6959 class6959_1;

	private Class6959 class6959_2;

	private Class6959 class6959_3;

	private Class6959 class6959_4;

	private Class6959 class6959_5;

	private Class6959 class6959_6;

	private Class6959 class6959_7;

	private Class6959 class6959_8;

	private Class6959 class6959_9;

	private Class6959 class6959_10;

	private Class6959 class6959_11;

	private Class6959 class6959_12 = new Class6959(isAuto: true);

	private Class6959 class6959_13 = new Class6959(isAuto: true);

	private Class6959 class6959_14 = new Class6959(isAuto: true);

	private Class6959 class6959_15 = new Class6959(isAuto: true);

	private Enum951 enum951_0;

	private Enum951 enum951_1;

	private Enum951 enum951_2;

	private Enum951 enum951_3;

	private Enum951 enum951_4;

	private Enum951 enum951_5;

	private Enum951 enum951_6;

	private Enum951 enum951_7;

	private Color color_4;

	private Color color_5;

	private Color color_6;

	private Color color_7;

	private Color color_8;

	private Color color_9;

	private Color color_10;

	private Color color_11;

	private Class6959 class6959_16;

	private Class6959 class6959_17;

	private Class6959 class6959_18;

	private Class6959 class6959_19;

	private int int_1;

	private Class6959 class6959_20;

	protected Class6959 class6959_21;

	protected Class6959 class6959_22;

	protected Class6959 class6959_23;

	protected Class6959 class6959_24;

	protected Class6959 class6959_25;

	protected Class6959 class6959_26;

	protected Class6959 class6959_27;

	protected Class6959 class6959_28;

	protected Class6959 class6959_29;

	protected Class6959 class6959_30;

	protected Class6959 class6959_31;

	protected Class6959 class6959_32;

	protected Class6959 class6959_33;

	private float float_2;

	private float float_3;

	private Enum940 enum940_0;

	private Class6959 class6959_34;

	private Class6959 class6959_35;

	private Enum939 enum939_0;

	private int int_2;

	private int int_3;

	private Enum933 enum933_0;

	private Enum937 enum937_0;

	private Class6959 class6959_36;

	private Class6959 class6959_37;

	private Class6959 class6959_38;

	private Class6959 class6959_39;

	private int int_4;

	private Enum938 enum938_0;

	private int int_5;

	private bool bool_1;

	private string string_3;

	private Enum936 enum936_0;

	private Enum960 enum960_0;

	private Interface329 interface329_0;

	private Interface329 interface329_1;

	private Enum950 enum950_0;

	private Enum950 enum950_1;

	private Enum950 enum950_2;

	private static int int_6 = 2;

	private int int_7 = int_6;

	private int int_8 = int_6;

	private bool bool_2 = true;

	public FontStyle FontStyle
	{
		get
		{
			return fontStyle_0;
		}
		set
		{
			fontStyle_0 = value;
		}
	}

	public float FontSize
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public int FontLarger
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public string FontFamilyName
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

	public bool IsTextOverlined
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public float CharSpace
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public Color Color
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	public Color BackgroundColor
	{
		get
		{
			return color_1;
		}
		set
		{
			color_1 = value;
		}
	}

	public Color FirstLineColor
	{
		get
		{
			return color_2;
		}
		set
		{
			color_2 = value;
		}
	}

	public Color FirstLetterColor
	{
		get
		{
			return color_3;
		}
		set
		{
			color_3 = value;
		}
	}

	public Enum957 TextAlign
	{
		get
		{
			return enum957_0;
		}
		set
		{
			enum957_0 = value;
		}
	}

	public Enum958 TextVAlign
	{
		get
		{
			return enum958_0;
		}
		set
		{
			enum958_0 = value;
		}
	}

	public Enum959 WhiteSpace
	{
		get
		{
			return enum959_0;
		}
		set
		{
			enum959_0 = value;
		}
	}

	public Enum948 Align
	{
		get
		{
			return enum948_0;
		}
		set
		{
			enum948_0 = value;
		}
	}

	public Enum940 TextTransform
	{
		get
		{
			return enum940_0;
		}
		set
		{
			enum940_0 = value;
		}
	}

	public Class6959 TextIndent
	{
		get
		{
			return class6959_34;
		}
		set
		{
			class6959_34 = value;
		}
	}

	public Class6959 WordSpacing
	{
		get
		{
			return class6959_35;
		}
		set
		{
			class6959_35 = value;
		}
	}

	public float LineSpacing
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

	public float LineHeight
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

	public Enum951 BorderStyleTop
	{
		get
		{
			return enum951_0;
		}
		set
		{
			enum951_0 = value;
		}
	}

	public Enum951 BorderStyleRight
	{
		get
		{
			return enum951_1;
		}
		set
		{
			enum951_1 = value;
		}
	}

	public Enum951 BorderStyleBottom
	{
		get
		{
			return enum951_2;
		}
		set
		{
			enum951_2 = value;
		}
	}

	public Enum951 BorderStyleLeft
	{
		get
		{
			return enum951_3;
		}
		set
		{
			enum951_3 = value;
		}
	}

	public Enum951 BorderTableStyleTop
	{
		get
		{
			return enum951_4;
		}
		set
		{
			enum951_4 = value;
		}
	}

	public Enum951 BorderTableStyleRight
	{
		get
		{
			return enum951_5;
		}
		set
		{
			enum951_5 = value;
		}
	}

	public Enum951 BorderTableStyleBottom
	{
		get
		{
			return enum951_6;
		}
		set
		{
			enum951_6 = value;
		}
	}

	public Enum951 BorderTableStyleLeft
	{
		get
		{
			return enum951_7;
		}
		set
		{
			enum951_7 = value;
		}
	}

	public Color BorderColorTop
	{
		get
		{
			return color_4;
		}
		set
		{
			color_4 = value;
		}
	}

	public Color BorderColorRight
	{
		get
		{
			return color_5;
		}
		set
		{
			color_5 = value;
		}
	}

	public Color BorderColorLeft
	{
		get
		{
			return color_7;
		}
		set
		{
			color_7 = value;
		}
	}

	public Color BorderColorBottom
	{
		get
		{
			return color_6;
		}
		set
		{
			color_6 = value;
		}
	}

	public Color BorderTableColorTop
	{
		get
		{
			return color_8;
		}
		set
		{
			color_8 = value;
		}
	}

	public Color BorderTableColorRight
	{
		get
		{
			return color_9;
		}
		set
		{
			color_9 = value;
		}
	}

	public Color BorderTableColorBottom
	{
		get
		{
			return color_10;
		}
		set
		{
			color_10 = value;
		}
	}

	public Color BorderTableColorLeft
	{
		get
		{
			return color_11;
		}
		set
		{
			color_11 = value;
		}
	}

	public Enum939 TableLayout
	{
		get
		{
			return enum939_0;
		}
		set
		{
			enum939_0 = value;
		}
	}

	public int Colspan
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public string Content
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

	public int Rowspan
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public Enum933 BorderCollapse
	{
		get
		{
			return enum933_0;
		}
		set
		{
			enum933_0 = value;
		}
	}

	public Enum937 EmptyCells
	{
		get
		{
			return enum937_0;
		}
		set
		{
			enum937_0 = value;
		}
	}

	public Class6959 BorderSpacingHorisontal
	{
		get
		{
			return class6959_36;
		}
		set
		{
			class6959_36 = value;
		}
	}

	public Class6959 BorderSpacingVertical
	{
		get
		{
			return class6959_37;
		}
		set
		{
			class6959_37 = value;
		}
	}

	public Class6959 CellPadding
	{
		get
		{
			return class6959_38;
		}
		set
		{
			class6959_38 = value;
		}
	}

	public int ListStyle
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

	public Enum938 ListStylePosition
	{
		get
		{
			return enum938_0;
		}
		set
		{
			enum938_0 = value;
		}
	}

	public Class6959 CounterValue
	{
		get
		{
			return class6959_39;
		}
		set
		{
			class6959_39 = value;
		}
	}

	public int CounterIncrementValue
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

	public bool IsBordered
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

	public Rectangle Clip
	{
		get
		{
			return rectangle_0;
		}
		set
		{
			rectangle_0 = value;
		}
	}

	public virtual Class6959 Height
	{
		get
		{
			return class6959_21;
		}
		set
		{
			class6959_21 = value;
		}
	}

	public Class6959 PaddingLeft
	{
		get
		{
			return class6959_0;
		}
		set
		{
			class6959_0 = value;
		}
	}

	public Class6959 PaddingRight
	{
		get
		{
			return class6959_1;
		}
		set
		{
			class6959_1 = value;
		}
	}

	public Class6959 PaddingTop
	{
		get
		{
			return class6959_2;
		}
		set
		{
			class6959_2 = value;
		}
	}

	public Class6959 PaddingBottom
	{
		get
		{
			return class6959_3;
		}
		set
		{
			class6959_3 = value;
		}
	}

	public Class6959 MarginLeft
	{
		get
		{
			return class6959_4;
		}
		set
		{
			class6959_4 = value;
		}
	}

	public Class6959 MarginRight
	{
		get
		{
			return class6959_5;
		}
		set
		{
			class6959_5 = value;
		}
	}

	public Class6959 MarginTop
	{
		get
		{
			return class6959_6;
		}
		set
		{
			class6959_6 = value;
		}
	}

	public Class6959 MarginBottom
	{
		get
		{
			return class6959_7;
		}
		set
		{
			class6959_7 = value;
		}
	}

	public Class6959 BorderWidthLeft
	{
		get
		{
			return class6959_8;
		}
		set
		{
			class6959_8 = value;
		}
	}

	public Class6959 BorderWidthRight
	{
		get
		{
			return class6959_9;
		}
		set
		{
			class6959_9 = value;
		}
	}

	public Class6959 BorderWidthTop
	{
		get
		{
			return class6959_10;
		}
		set
		{
			class6959_10 = value;
		}
	}

	public Class6959 BorderWidthBottom
	{
		get
		{
			return class6959_11;
		}
		set
		{
			class6959_11 = value;
		}
	}

	public Class6959 BorderTableWidthLeft
	{
		get
		{
			return class6959_12;
		}
		set
		{
			class6959_12 = value;
		}
	}

	public Class6959 BorderTableWidthRight
	{
		get
		{
			return class6959_13;
		}
		set
		{
			class6959_13 = value;
		}
	}

	public Class6959 BorderTableWidthTop
	{
		get
		{
			return class6959_14;
		}
		set
		{
			class6959_14 = value;
		}
	}

	public Class6959 BorderTableWidthBottom
	{
		get
		{
			return class6959_15;
		}
		set
		{
			class6959_15 = value;
		}
	}

	public Enum952 Display
	{
		get
		{
			return enum952_0;
		}
		set
		{
			enum952_0 = value;
		}
	}

	public Enum953 Overflow
	{
		get
		{
			return enum953_0;
		}
		set
		{
			enum953_0 = value;
		}
	}

	public Enum954 Float
	{
		get
		{
			return enum954_0;
		}
		set
		{
			enum954_0 = value;
		}
	}

	public Enum935 Clear
	{
		get
		{
			return enum935_0;
		}
		set
		{
			enum935_0 = value;
		}
	}

	public Enum956 Position
	{
		get
		{
			return enum956_0;
		}
		set
		{
			enum956_0 = value;
		}
	}

	public Class6959 Left
	{
		get
		{
			return class6959_16;
		}
		set
		{
			class6959_16 = value;
		}
	}

	public Class6959 Top
	{
		get
		{
			return class6959_17;
		}
		set
		{
			class6959_17 = value;
		}
	}

	public Class6959 Bottom
	{
		get
		{
			return class6959_18;
		}
		set
		{
			class6959_18 = value;
		}
	}

	public Class6959 Right
	{
		get
		{
			return class6959_19;
		}
		set
		{
			class6959_19 = value;
		}
	}

	public int ZIndex
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public Class6959 Width
	{
		get
		{
			return class6959_20;
		}
		set
		{
			class6959_20 = value;
		}
	}

	public Class6959 PageFirstMarginLeft
	{
		get
		{
			return class6959_22;
		}
		set
		{
			class6959_22 = value;
		}
	}

	public Class6959 PageFirstMarginRight
	{
		get
		{
			return class6959_23;
		}
		set
		{
			class6959_23 = value;
		}
	}

	public Class6959 PageFirstMarginTop
	{
		get
		{
			return class6959_24;
		}
		set
		{
			class6959_24 = value;
		}
	}

	public Class6959 PageFirstMarginBottom
	{
		get
		{
			return class6959_25;
		}
		set
		{
			class6959_25 = value;
		}
	}

	public Class6959 PageLeftMarginTop
	{
		get
		{
			return class6959_26;
		}
		set
		{
			class6959_26 = value;
		}
	}

	public Class6959 PageLeftMarginBottom
	{
		get
		{
			return class6959_27;
		}
		set
		{
			class6959_27 = value;
		}
	}

	public Class6959 PageLeftMarginLeft
	{
		get
		{
			return class6959_28;
		}
		set
		{
			class6959_28 = value;
		}
	}

	public Class6959 PageLeftMarginRight
	{
		get
		{
			return class6959_29;
		}
		set
		{
			class6959_29 = value;
		}
	}

	public Class6959 PageRightMarginTop
	{
		get
		{
			return class6959_30;
		}
		set
		{
			class6959_30 = value;
		}
	}

	public Class6959 PageRightMarginBottom
	{
		get
		{
			return class6959_31;
		}
		set
		{
			class6959_31 = value;
		}
	}

	public Class6959 PageRightMarginLeft
	{
		get
		{
			return class6959_32;
		}
		set
		{
			class6959_32 = value;
		}
	}

	public Class6959 PageRightMarginRight
	{
		get
		{
			return class6959_33;
		}
		set
		{
			class6959_33 = value;
		}
	}

	public string BackgroundImage
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

	public Enum936 Direction
	{
		get
		{
			return enum936_0;
		}
		set
		{
			enum936_0 = value;
		}
	}

	public Enum960 Visibility
	{
		get
		{
			return enum960_0;
		}
		set
		{
			enum960_0 = value;
		}
	}

	public Interface329 Before
	{
		get
		{
			return interface329_0;
		}
		set
		{
			interface329_0 = value;
		}
	}

	public Interface329 After
	{
		get
		{
			return interface329_1;
		}
		set
		{
			interface329_1 = value;
		}
	}

	public Enum950 PageBreakBefore
	{
		get
		{
			return enum950_0;
		}
		set
		{
			enum950_0 = value;
		}
	}

	public Enum950 PageBreakAfter
	{
		get
		{
			return enum950_1;
		}
		set
		{
			enum950_1 = value;
		}
	}

	public Enum950 PageBreakInside
	{
		get
		{
			return enum950_2;
		}
		set
		{
			enum950_2 = value;
		}
	}

	public int Orphans
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

	public int Windows
	{
		get
		{
			return int_8;
		}
		set
		{
			int_8 = value;
		}
	}

	public bool TextWrapType
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	protected Class6895()
	{
		string_1 = "Times New Roman";
		float_0 = 14f;
		float_2 = 1.3f;
		class6959_4 = new Class6959(isAuto: true);
		class6959_5 = new Class6959(isAuto: true);
		class6959_6 = new Class6959(isAuto: true);
		class6959_7 = new Class6959(isAuto: true);
		class6959_34 = new Class6959(isAuto: true);
		class6959_36 = new Class6959(isAuto: true);
		class6959_37 = new Class6959(isAuto: true);
		class6959_38 = new Class6959(isAuto: true);
		class6959_16 = new Class6959(isAuto: true);
		class6959_19 = new Class6959(isAuto: true);
		class6959_20 = new Class6959(isAuto: true);
		class6959_21 = new Class6959(isAuto: true);
		class6959_18 = new Class6959(isAuto: true);
		class6959_17 = new Class6959(isAuto: true);
		class6959_35 = new Class6959(isAuto: true);
		class6959_11 = (class6959_8 = (class6959_10 = (class6959_9 = new Class6959(Class6969.smethod_6(5f)))));
		int_2 = 1;
		int_3 = 1;
		class6959_3 = (class6959_0 = (class6959_1 = (class6959_2 = new Class6959(isAuto: true))));
		CounterIncrementValue = 1;
		CounterValue = new Class6959(isAuto: true);
	}

	public abstract object Clone();

	public abstract Interface329 imethod_0(string tagName);

	protected void method_0(Interface329 clone)
	{
		clone.BackgroundColor = BackgroundColor;
		clone.CharSpace = CharSpace;
		clone.Color = Color;
		clone.Display = Display;
		clone.Float = Float;
		clone.Clear = Clear;
		clone.FontFamilyName = FontFamilyName;
		clone.FontSize = FontSize;
		clone.FontStyle = FontStyle;
		clone.Left = Left;
		clone.Position = Position;
		clone.Top = Top;
		clone.TextAlign = TextAlign;
		clone.Height = Height;
		clone.IsTextOverlined = IsTextOverlined;
		clone.TextVAlign = TextVAlign;
		clone.WhiteSpace = WhiteSpace;
		clone.TextIndent = TextIndent;
		clone.WordSpacing = WordSpacing;
		clone.BorderStyleBottom = BorderStyleBottom;
		clone.BorderStyleLeft = BorderStyleLeft;
		clone.BorderStyleRight = BorderStyleRight;
		clone.BorderStyleTop = BorderStyleTop;
		clone.BorderColorBottom = BorderColorBottom;
		clone.BorderColorLeft = BorderColorLeft;
		clone.BorderColorRight = BorderColorRight;
		clone.BorderColorTop = BorderColorTop;
		clone.BorderWidthLeft = BorderWidthLeft;
		clone.BorderWidthRight = BorderWidthRight;
		clone.BorderWidthTop = BorderWidthTop;
		clone.BorderWidthBottom = BorderWidthBottom;
		clone.BorderTableColorBottom = BorderTableColorBottom;
		clone.BorderTableColorLeft = BorderTableColorLeft;
		clone.BorderTableColorRight = BorderTableColorRight;
		clone.BorderTableColorTop = BorderTableColorTop;
		clone.BorderTableWidthLeft = BorderTableWidthLeft;
		clone.BorderTableWidthRight = BorderTableWidthRight;
		clone.BorderTableWidthTop = BorderTableWidthTop;
		clone.BorderTableWidthBottom = BorderTableWidthBottom;
		clone.PaddingBottom = PaddingBottom;
		clone.PaddingLeft = PaddingLeft;
		clone.PaddingRight = PaddingRight;
		clone.PaddingTop = PaddingTop;
		clone.MarginBottom = MarginBottom;
		clone.MarginLeft = MarginLeft;
		clone.MarginRight = MarginRight;
		clone.MarginTop = MarginTop;
		clone.LineSpacing = LineSpacing;
		clone.TableLayout = TableLayout;
		clone.Rowspan = Rowspan;
		clone.Colspan = Colspan;
		clone.BorderCollapse = BorderCollapse;
		clone.BorderSpacingHorisontal = BorderSpacingHorisontal;
		clone.BorderSpacingVertical = BorderSpacingVertical;
		clone.EmptyCells = EmptyCells;
		clone.CellPadding = CellPadding;
		clone.ListStylePosition = ListStylePosition;
		clone.ListStyle = ListStyle;
		clone.CounterValue = CounterValue;
		clone.CounterIncrementValue = CounterIncrementValue;
		clone.IsBordered = IsBordered;
		clone.BackgroundImage = BackgroundImage;
		clone.Direction = Direction;
		clone.PageFirstMarginBottom = PageFirstMarginBottom;
		clone.PageFirstMarginLeft = PageFirstMarginLeft;
		clone.PageFirstMarginRight = PageFirstMarginRight;
		clone.PageFirstMarginTop = PageFirstMarginTop;
		clone.PageLeftMarginBottom = PageLeftMarginBottom;
		clone.PageLeftMarginLeft = PageLeftMarginLeft;
		clone.PageLeftMarginRight = PageLeftMarginRight;
		clone.PageLeftMarginTop = PageLeftMarginTop;
		clone.PageRightMarginBottom = PageRightMarginBottom;
		clone.PageRightMarginLeft = PageRightMarginLeft;
		clone.PageRightMarginRight = PageRightMarginRight;
		clone.PageRightMarginTop = PageRightMarginTop;
	}
}
