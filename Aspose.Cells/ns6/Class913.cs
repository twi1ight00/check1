using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns19;
using ns5;

namespace ns6;

internal class Class913 : Interface6
{
	private Class911 class911_0;

	private Enum121 enum121_0;

	private AutoShapeType autoShapeType_0;

	private bool bool_0;

	private Workbook workbook_0;

	private Worksheet worksheet_0;

	private Class903 class903_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private int int_0;

	private Class900 class900_0;

	private Class906 class906_0;

	private System.Drawing.Font font_0 = Struct72.font_0;

	private Color color_0 = Color.Black;

	private Enum104 enum104_0 = Enum104.const_7;

	private Enum104 enum104_1 = Enum104.const_9;

	private Enum105 enum105_0;

	private Enum107 enum107_0 = Enum107.const_2;

	private int int_1;

	private bool bool_1 = true;

	private Class312 class312_0;

	private RectangleF rectangleF_0 = new RectangleF(0f, 0f, 0f, 0f);

	private GraphicsPath graphicsPath_0;

	private string string_0 = "";

	private ArrayList arrayList_0 = new ArrayList();

	private PointF pointF_0 = PointF.Empty;

	private Enum120 enum120_0;

	private IList ilist_0 = new ArrayList();

	private IList ilist_1 = new ArrayList();

	private string string_1 = "";

	private int int_2;

	private bool bool_2;

	private bool bool_3;

	public int int_3 = 1;

	public ArrayList arrayList_1 = new ArrayList();

	public Class913 class913_0;

	public bool bool_4;

	public bool bool_5;

	public bool bool_6;

	public Chart chart_0;

	public Shape shape_0;

	public PointF pointF_1 = PointF.Empty;

	public PointF pointF_2 = PointF.Empty;

	internal RectangleF rectangleF_1 = new RectangleF(0f, 0f, 0f, 0f);

	internal RectangleF rectangleF_2 = new RectangleF(0f, 0f, 0f, 0f);

	private bool bool_7;

	public Class901 class901_0;

	private Interface42 interface42_0;

	internal Class312 TextFrame => class312_0;

	public Enum121 Type => enum121_0;

	public AutoShapeType AutoShapeType
	{
		get
		{
			return autoShapeType_0;
		}
		set
		{
			autoShapeType_0 = value;
		}
	}

	public float Width
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

	public float Height
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

	public float X
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

	public float Y
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

	public int Rotation
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value < 0)
			{
				int_0 = 360 + value % 360;
			}
			else if (value > 360)
			{
				int_0 = value % 360;
			}
			else
			{
				int_0 = value;
			}
		}
	}

	public Class900 Fill => class900_0;

	public Class906 Line => class906_0;

	public System.Drawing.Font Font
	{
		get
		{
			return font_0;
		}
		set
		{
			font_0 = value;
		}
	}

	public Color FontColor
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

	public Enum104 TextHorizontalAlignment
	{
		get
		{
			return enum104_0;
		}
		set
		{
			enum104_0 = value;
		}
	}

	public Enum104 TextVerticalAlignment
	{
		get
		{
			return enum104_1;
		}
		set
		{
			enum104_1 = value;
		}
	}

	public Enum105 TextDirection => enum105_0;

	public string Text
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

	public string SelectedValue => string_1;

	[SpecialName]
	internal void method_0(bool bool_8)
	{
		bool_0 = bool_8;
	}

	[SpecialName]
	internal void method_1(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
	}

	[SpecialName]
	internal void method_2(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
	}

	[SpecialName]
	internal Class903 method_3()
	{
		return class903_0;
	}

	[SpecialName]
	internal void method_4(Class903 class903_1)
	{
		class903_0 = class903_1;
	}

	[SpecialName]
	internal void method_5(Class312 class312_1)
	{
		class312_0 = class312_1;
	}

	[SpecialName]
	internal RectangleF method_6()
	{
		return rectangleF_0;
	}

	[SpecialName]
	internal void method_7(GraphicsPath graphicsPath_1)
	{
		graphicsPath_0 = graphicsPath_1;
	}

	public Class913(Class911 class911_1, Enum121 enum121_1)
	{
		class911_0 = class911_1;
		enum121_0 = enum121_1;
		bool_7 = false;
		class900_0 = new Class900(this);
		class906_0 = new Class906(this);
	}

	public Class913(Enum121 enum121_1)
		: this(null, enum121_1)
	{
	}

	[SpecialName]
	public RectangleF method_8()
	{
		return new RectangleF(float_2, float_3, float_0, float_1);
	}

	[SpecialName]
	public Enum107 method_9()
	{
		return enum107_0;
	}

	[SpecialName]
	public void method_10(Enum107 enum107_1)
	{
		enum107_0 = enum107_1;
	}

	[SpecialName]
	public int method_11()
	{
		return int_1;
	}

	[SpecialName]
	public void method_12(int int_4)
	{
		int_1 = int_4;
	}

	[SpecialName]
	public ArrayList method_13()
	{
		return arrayList_0;
	}

	[SpecialName]
	public Enum120 method_14()
	{
		return enum120_0;
	}

	[SpecialName]
	public void method_15(Enum120 enum120_1)
	{
		enum120_0 = enum120_1;
	}

	[SpecialName]
	public IList method_16()
	{
		return ilist_0;
	}

	[SpecialName]
	public int method_17()
	{
		return int_2;
	}

	[SpecialName]
	public IList method_18()
	{
		return ilist_1;
	}

	[SpecialName]
	public void method_19(IList ilist_2)
	{
		ilist_1 = ilist_2;
	}

	[SpecialName]
	public void method_20(string string_2)
	{
		string_1 = string_2;
	}

	[SpecialName]
	public bool method_21()
	{
		return bool_2;
	}

	[SpecialName]
	public void method_22(bool bool_8)
	{
		bool_2 = bool_8;
	}

	[SpecialName]
	public bool method_23()
	{
		return bool_3;
	}

	[SpecialName]
	public void method_24(bool bool_8)
	{
		bool_3 = bool_8;
	}

	[SpecialName]
	internal RectangleF method_25()
	{
		if (!bool_7)
		{
			method_27();
		}
		return rectangleF_2;
	}

	[SpecialName]
	internal RectangleF method_26()
	{
		if (!bool_7)
		{
			method_31();
		}
		return rectangleF_1;
	}

	public virtual void vmethod_0(Interface42 interface42_1, bool bool_8)
	{
		if (!bool_7)
		{
			method_27();
		}
		if (bool_8)
		{
			method_28();
		}
		interface42_1.ResetTransform();
		switch (Type)
		{
		case Enum121.const_1:
		{
			for (int i = 0; i < arrayList_1.Count; i++)
			{
				Class913 @class = (Class913)arrayList_1[i];
				if (@class.bool_5)
				{
					Chart chart = @class.chart_0;
					MemoryStream memoryStream = new MemoryStream();
					chart.ToImage(memoryStream, ImageFormat.Emf);
					Image image = Image.FromStream(memoryStream);
					RectangleF rectangleF = new RectangleF(-1f, -1f, image.Width + 1, image.Height + 1);
					RectangleF rectangleF2 = @class.method_8();
					if (rectangleF2.X <= 2f)
					{
						rectangleF2.X = 2f;
					}
					if (rectangleF2.Y <= 2f)
					{
						rectangleF2.Y = 2f;
					}
					interface42_1.imethod_14(image, rectangleF2, rectangleF, GraphicsUnit.Pixel);
					memoryStream.Close();
					image.Dispose();
				}
				else
				{
					@class.vmethod_0(interface42_1, bool_8: false);
				}
			}
			break;
		}
		case Enum121.const_2:
			Struct71.smethod_0(interface42_1, this);
			break;
		case Enum121.const_3:
			Struct71.smethod_17(interface42_1, this);
			break;
		case Enum121.const_4:
			Struct71.smethod_1(interface42_1, this);
			break;
		case Enum121.const_7:
			Struct71.smethod_18(interface42_1, this);
			break;
		case Enum121.const_8:
			Struct71.smethod_4(interface42_1, this);
			break;
		case Enum121.const_9:
			Struct71.smethod_10(interface42_1, this);
			break;
		case Enum121.const_11:
			Struct71.smethod_5(interface42_1, this);
			break;
		case Enum121.const_12:
			Struct71.smethod_6(interface42_1, this);
			break;
		case Enum121.const_13:
			Struct71.smethod_2(interface42_1, this);
			break;
		case Enum121.const_17:
			Struct71.smethod_7(interface42_1, this);
			break;
		case Enum121.const_18:
			Struct71.smethod_3(interface42_1, this);
			break;
		case Enum121.const_19:
			Struct71.smethod_8(interface42_1, this);
			break;
		case Enum121.const_21:
			Struct71.smethod_11(interface42_1, this);
			break;
		case Enum121.const_20:
			Struct71.smethod_9(interface42_1, this);
			break;
		case Enum121.const_22:
			switch (AutoShapeType)
			{
			case AutoShapeType.Heptagon:
				Struct71.smethod_68(interface42_1, this);
				break;
			case AutoShapeType.Decagon:
				Struct71.smethod_69(interface42_1, this);
				break;
			case AutoShapeType.Dodecagon:
				Struct71.smethod_70(interface42_1, this);
				break;
			case AutoShapeType.Star6:
				Struct71.smethod_118(interface42_1, this);
				break;
			case AutoShapeType.Star7:
				Struct71.smethod_119(interface42_1, this);
				break;
			case AutoShapeType.Star10:
				Struct71.smethod_121(interface42_1, this);
				break;
			case AutoShapeType.Star12:
				Struct71.smethod_122(interface42_1, this);
				break;
			case AutoShapeType.RoundSingleCornerRectangle:
				Struct71.smethod_33(interface42_1, this);
				break;
			case AutoShapeType.RoundSameSideCornerRectangle:
				Struct71.smethod_34(interface42_1, this);
				break;
			case AutoShapeType.RoundDiagonalCornerRectangle:
				Struct71.smethod_35(interface42_1, this);
				break;
			case AutoShapeType.SnipRoundSingleCornerRectangle:
				Struct71.smethod_32(interface42_1, this);
				break;
			case AutoShapeType.SnipSingleCornerRectangle:
				Struct71.smethod_21(interface42_1, this);
				break;
			case AutoShapeType.SnipSameSideCornerRectangle:
				Struct71.smethod_30(interface42_1, this);
				break;
			case AutoShapeType.SnipDiagonalCornerRectangle:
				Struct71.smethod_31(interface42_1, this);
				break;
			case AutoShapeType.Teardrop:
				Struct71.smethod_73(interface42_1, this);
				break;
			case AutoShapeType.Pie:
				Struct71.smethod_71(interface42_1, this);
				break;
			case AutoShapeType.Frame:
				Struct71.smethod_50(interface42_1, this);
				break;
			case AutoShapeType.HalfFrame:
				Struct71.smethod_54(interface42_1, this);
				break;
			case AutoShapeType.L_Shape:
				Struct71.smethod_53(interface42_1, this);
				break;
			case AutoShapeType.DiagonalStripe:
				Struct71.smethod_49(interface42_1, this);
				break;
			case AutoShapeType.Chord:
				Struct71.smethod_72(interface42_1, this);
				break;
			case AutoShapeType.Cloud:
				Struct71.smethod_102(interface42_1, this);
				break;
			case AutoShapeType.MathPlus:
				Struct71.smethod_61(interface42_1, this);
				break;
			case AutoShapeType.MathMinus:
				Struct71.smethod_62(interface42_1, this);
				break;
			case AutoShapeType.MathMultiply:
				Struct71.smethod_63(interface42_1, this);
				break;
			case AutoShapeType.MathDivide:
				Struct71.smethod_65(interface42_1, this);
				break;
			case AutoShapeType.MathEqual:
				Struct71.smethod_64(interface42_1, this);
				break;
			case AutoShapeType.MathNotEqual:
				Struct71.smethod_131(interface42_1, this);
				break;
			case AutoShapeType.NotPrimitive:
				Struct71.smethod_160(interface42_1, this);
				break;
			case AutoShapeType.Rectangle:
				Struct71.smethod_80(interface42_1, this);
				break;
			case AutoShapeType.RoundedRectangle:
				Struct71.smethod_20(interface42_1, this);
				break;
			case AutoShapeType.Diamond:
				Struct71.smethod_26(interface42_1, this);
				break;
			case AutoShapeType.IsoscelesTriangle:
				Struct71.smethod_22(interface42_1, this);
				break;
			case AutoShapeType.RightTriangle:
				Struct71.smethod_23(interface42_1, this);
				break;
			case AutoShapeType.Parallelogram:
				Struct71.smethod_24(interface42_1, this);
				break;
			case AutoShapeType.Trapezoid:
				Struct71.smethod_25(interface42_1, this);
				break;
			case AutoShapeType.Hexagon:
				Struct71.smethod_28(interface42_1, this);
				break;
			case AutoShapeType.Octagon:
				Struct71.smethod_29(interface42_1, this);
				break;
			case AutoShapeType.Cross:
				Struct71.smethod_48(interface42_1, this);
				break;
			case AutoShapeType.Star5:
				Struct71.smethod_117(interface42_1, this);
				break;
			case AutoShapeType.RightArrow:
				Struct71.smethod_39(interface42_1, this);
				break;
			case AutoShapeType.HomePlate:
				Struct71.smethod_111(interface42_1, this);
				break;
			case AutoShapeType.Cube:
				Struct71.smethod_45(interface42_1, this);
				break;
			case AutoShapeType.Arc:
				Struct71.smethod_52(interface42_1, this);
				break;
			case AutoShapeType.Line:
				Struct71.smethod_36(interface42_1, this);
				break;
			case AutoShapeType.Plaque:
				Struct71.smethod_51(interface42_1, this);
				break;
			case AutoShapeType.Can:
				Struct71.smethod_46(interface42_1, this);
				break;
			case AutoShapeType.Donut:
				Struct71.smethod_77(interface42_1, this);
				break;
			case AutoShapeType.StraightConnector:
				Struct71.smethod_36(interface42_1, this);
				break;
			case AutoShapeType.BentConnector2:
				Struct71.smethod_56(interface42_1, this);
				break;
			case AutoShapeType.ElbowConnector:
				Struct71.smethod_55(interface42_1, this);
				break;
			case AutoShapeType.BentConnector4:
				Struct71.smethod_57(interface42_1, this);
				break;
			case AutoShapeType.BentConnector5:
				Struct71.smethod_58(interface42_1, this);
				break;
			case AutoShapeType.CurvedConnector:
				Struct71.smethod_156(interface42_1, this);
				break;
			case AutoShapeType.CurvedConnector4:
				Struct71.smethod_164(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutNoBorder3:
				Struct71.smethod_140(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutNoBorder4:
				Struct71.smethod_142(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithAccentBar2:
				Struct71.smethod_144(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithAccentBar3:
				Struct71.smethod_146(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithAccentBar4:
				Struct71.smethod_148(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithBorder3:
				Struct71.smethod_139(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithBorder4:
				Struct71.smethod_141(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithBorderAndAccentBar2:
				Struct71.smethod_143(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithBorderAndAccentBar3:
				Struct71.smethod_145(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithBorderAndAccentBar4:
				Struct71.smethod_147(interface42_1, this);
				break;
			case AutoShapeType.DownRibbon:
				Struct71.smethod_153(interface42_1, this);
				break;
			case AutoShapeType.UpRibbon:
				Struct71.smethod_152(interface42_1, this);
				break;
			case AutoShapeType.Chevron:
				Struct71.smethod_112(interface42_1, this);
				break;
			case AutoShapeType.RegularPentagon:
				Struct71.smethod_27(interface42_1, this);
				break;
			case AutoShapeType.NoSymbol:
				Struct71.smethod_130(interface42_1, this);
				break;
			case AutoShapeType.Star8:
				Struct71.smethod_120(interface42_1, this);
				break;
			case AutoShapeType.Star16:
				Struct71.smethod_123(interface42_1, this);
				break;
			case AutoShapeType.Star32:
				Struct71.smethod_125(interface42_1, this);
				break;
			case AutoShapeType.RectangularCallout:
				Struct71.smethod_37(interface42_1, this);
				break;
			case AutoShapeType.RoundedRectangularCallout:
				Struct71.smethod_126(interface42_1, this);
				break;
			case AutoShapeType.OvalCallout:
				Struct71.smethod_38(interface42_1, this);
				break;
			case AutoShapeType.Wave:
				Struct71.smethod_154(interface42_1, this);
				break;
			case AutoShapeType.FoldedCorner:
				Struct71.smethod_79(interface42_1, this);
				break;
			case AutoShapeType.LeftArrow:
				Struct71.smethod_40(interface42_1, this);
				break;
			case AutoShapeType.DownArrow:
				Struct71.smethod_42(interface42_1, this);
				break;
			case AutoShapeType.UpArrow:
				Struct71.smethod_41(interface42_1, this);
				break;
			case AutoShapeType.LeftRightArrow:
				Struct71.smethod_43(interface42_1, this);
				break;
			case AutoShapeType.UpDownArrow:
				Struct71.smethod_44(interface42_1, this);
				break;
			case AutoShapeType.Explosion1:
				Struct71.smethod_99(interface42_1, this);
				break;
			case AutoShapeType.Explosion2:
				Struct71.smethod_100(interface42_1, this);
				break;
			case AutoShapeType.LightningBolt:
				Struct71.smethod_75(interface42_1, this);
				break;
			case AutoShapeType.Heart:
				Struct71.smethod_74(interface42_1, this);
				break;
			case AutoShapeType.QuadArrow:
				Struct71.smethod_101(interface42_1, this);
				break;
			case AutoShapeType.LeftArrowCallout:
				Struct71.smethod_132(interface42_1, this);
				break;
			case AutoShapeType.RightArrowCallout:
				Struct71.smethod_113(interface42_1, this);
				break;
			case AutoShapeType.UpArrowCallout:
				Struct71.smethod_133(interface42_1, this);
				break;
			case AutoShapeType.DownArrowCallout:
				Struct71.smethod_114(interface42_1, this);
				break;
			case AutoShapeType.LeftRightArrowCallout:
				Struct71.smethod_134(interface42_1, this);
				break;
			case AutoShapeType.QuadArrowCallout:
				Struct71.smethod_135(interface42_1, this);
				break;
			case AutoShapeType.Bevel:
				Struct71.smethod_76(interface42_1, this);
				break;
			case AutoShapeType.LeftBracket:
				Struct71.smethod_161(interface42_1, this);
				break;
			case AutoShapeType.RightBracket:
				Struct71.smethod_162(interface42_1, this);
				break;
			case AutoShapeType.LeftBrace:
				Struct71.smethod_66(interface42_1, this);
				break;
			case AutoShapeType.RightBrace:
				Struct71.smethod_67(interface42_1, this);
				break;
			case AutoShapeType.LeftUpArrow:
				Struct71.smethod_107(interface42_1, this);
				break;
			case AutoShapeType.BentUpArrow:
				Struct71.smethod_108(interface42_1, this);
				break;
			case AutoShapeType.BentArrow:
				Struct71.smethod_105(interface42_1, this);
				break;
			case AutoShapeType.Star24:
				Struct71.smethod_124(interface42_1, this);
				break;
			case AutoShapeType.StripedRightArrow:
				Struct71.smethod_136(interface42_1, this);
				break;
			case AutoShapeType.NotchedRightArrow:
				Struct71.smethod_110(interface42_1, this);
				break;
			case AutoShapeType.BlockArc:
				Struct71.smethod_78(interface42_1, this);
				break;
			case AutoShapeType.SmileyFace:
				Struct71.smethod_19(interface42_1, this);
				break;
			case AutoShapeType.VerticalScroll:
				Struct71.smethod_150(interface42_1, this);
				break;
			case AutoShapeType.HorizontalScroll:
				Struct71.smethod_151(interface42_1, this);
				break;
			case AutoShapeType.CircularArrow:
				Struct71.smethod_163(interface42_1, this);
				break;
			case AutoShapeType.UTurnArrow:
				Struct71.smethod_106(interface42_1, this);
				break;
			case AutoShapeType.CurvedRightArrow:
				Struct71.smethod_109(interface42_1, this);
				break;
			case AutoShapeType.CurvedLeftArrow:
				Struct71.smethod_159(interface42_1, this);
				break;
			case AutoShapeType.CurvedUpArrow:
				Struct71.smethod_157(interface42_1, this);
				break;
			case AutoShapeType.CurvedDownArrow:
				Struct71.smethod_158(interface42_1, this);
				break;
			case AutoShapeType.CloudCallout:
				Struct71.smethod_149(interface42_1, this);
				break;
			case AutoShapeType.FlowChartProcess:
				Struct71.smethod_80(interface42_1, this);
				break;
			case AutoShapeType.FlowChartDecision:
				Struct71.smethod_26(interface42_1, this);
				break;
			case AutoShapeType.FlowChartData:
				Struct71.smethod_129(interface42_1, this);
				break;
			case AutoShapeType.FlowChartPredefinedProcess:
				Struct71.smethod_81(interface42_1, this);
				break;
			case AutoShapeType.FlowChartInternalStorage:
				Struct71.smethod_82(interface42_1, this);
				break;
			case AutoShapeType.FlowChartDocument:
				Struct71.smethod_127(interface42_1, this);
				break;
			case AutoShapeType.FlowChartMultidocument:
				Struct71.smethod_128(interface42_1, this);
				break;
			case AutoShapeType.FlowChartTerminator:
				Struct71.smethod_83(interface42_1, this);
				break;
			case AutoShapeType.FlowChartPreparation:
				Struct71.smethod_28(interface42_1, this);
				break;
			case AutoShapeType.FlowChartManualInput:
				Struct71.smethod_84(interface42_1, this);
				break;
			case AutoShapeType.FlowChartManualOperation:
				Struct71.smethod_85(interface42_1, this);
				break;
			case AutoShapeType.FlowChartConnector:
				Struct71.smethod_1(interface42_1, this);
				break;
			case AutoShapeType.FlowChartCard:
				Struct71.smethod_87(interface42_1, this);
				break;
			case AutoShapeType.FlowChartPunchedTape:
				Struct71.smethod_88(interface42_1, this);
				break;
			case AutoShapeType.FlowChartSummingJunction:
				Struct71.smethod_89(interface42_1, this);
				break;
			case AutoShapeType.FlowChartOr:
				Struct71.smethod_47(interface42_1, this);
				break;
			case AutoShapeType.FlowChartCollate:
				Struct71.smethod_90(interface42_1, this);
				break;
			case AutoShapeType.FlowChartSort:
				Struct71.smethod_91(interface42_1, this);
				break;
			case AutoShapeType.FlowChartExtract:
				Struct71.smethod_22(interface42_1, this);
				break;
			case AutoShapeType.FlowChartMerge:
				Struct71.smethod_92(interface42_1, this);
				break;
			case AutoShapeType.FlowChartStoredData:
				Struct71.smethod_93(interface42_1, this);
				break;
			case AutoShapeType.FlowChartSequentialAccessStorage:
				Struct71.smethod_95(interface42_1, this);
				break;
			case AutoShapeType.FlowChartMagneticDisk:
				Struct71.smethod_96(interface42_1, this);
				break;
			case AutoShapeType.FlowChartDirectAccessStorage:
				Struct71.smethod_97(interface42_1, this);
				break;
			case AutoShapeType.FlowChartDisplay:
				Struct71.smethod_98(interface42_1, this);
				break;
			case AutoShapeType.FlowChartDelay:
				Struct71.smethod_94(interface42_1, this);
				break;
			case AutoShapeType.FlowChartAlternateProcess:
				Struct71.smethod_20(interface42_1, this);
				break;
			case AutoShapeType.FlowChartOffpageConnector:
				Struct71.smethod_86(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutNoBorder1:
				Struct71.smethod_138(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithBorder1:
				Struct71.smethod_137(interface42_1, this);
				break;
			case AutoShapeType.LeftRightUpArrow:
				Struct71.smethod_104(interface42_1, this);
				break;
			case AutoShapeType.Sun:
				Struct71.smethod_103(interface42_1, this);
				break;
			case AutoShapeType.Moon:
				Struct71.smethod_115(interface42_1, this);
				break;
			case AutoShapeType.DoubleBracket:
				Struct71.smethod_59(interface42_1, this);
				break;
			case AutoShapeType.DoubleBrace:
				Struct71.smethod_60(interface42_1, this);
				break;
			case AutoShapeType.Star4:
				Struct71.smethod_116(interface42_1, this);
				break;
			case AutoShapeType.DoubleWave:
				Struct71.smethod_155(interface42_1, this);
				break;
			}
			break;
		case Enum121.const_5:
		case Enum121.const_6:
		case Enum121.const_10:
		case (Enum121)10:
		case (Enum121)13:
		case Enum121.const_14:
		case Enum121.const_15:
		case Enum121.const_16:
		case (Enum121)21:
		case (Enum121)22:
		case (Enum121)23:
		case (Enum121)26:
		case (Enum121)27:
		case (Enum121)28:
		case Enum121.const_23:
			break;
		}
	}

	private void method_27()
	{
		rectangleF_2 = method_8();
		switch (Type)
		{
		case Enum121.const_22:
		{
			RectangleF rectangleF;
			switch (AutoShapeType)
			{
			case AutoShapeType.Line:
				rectangleF = ((!(Line.Weight <= 1f)) ? Struct72.smethod_10(this) : Struct72.smethod_11(this));
				if (bool_4 && (Rotation == 90 || Rotation == 270))
				{
					float height2 = rectangleF.Height;
					float width2 = rectangleF.Width;
					rectangleF.Width = height2;
					rectangleF.Height = width2;
				}
				break;
			case AutoShapeType.StraightConnector:
				rectangleF = ((!(Line.Weight <= 1f)) ? Struct72.smethod_10(this) : Struct72.smethod_11(this));
				if (bool_4 && (Rotation == 90 || Rotation == 270))
				{
					float height = rectangleF.Height;
					float width = rectangleF.Width;
					rectangleF.Width = height;
					rectangleF.Height = width;
				}
				break;
			case AutoShapeType.ElbowConnector:
				rectangleF = rectangleF_2;
				if (Width <= 1f)
				{
					rectangleF.Width += 2f;
					float_0 += 2f;
				}
				if (Height <= 1f)
				{
					rectangleF.Height += 2f;
					float_1 += 2f;
				}
				if (Rotation > 0 && Rotation != 180)
				{
					rectangleF = (rectangleF_0 = Struct72.smethod_16(this));
					break;
				}
				rectangleF = (rectangleF_0 = Struct72.smethod_32(this));
				rectangleF = new RectangleF(0f, 0f, rectangleF.Width, rectangleF.Height + 5f);
				break;
			case AutoShapeType.BentConnector4:
				rectangleF = rectangleF_2;
				if (Width <= 1f)
				{
					rectangleF.Width += 2f;
					float_0 += 2f;
				}
				if (Height <= 1f)
				{
					rectangleF.Height += 2f;
					float_1 += 2f;
				}
				rectangleF = ((Rotation <= 0) ? (rectangleF_0 = Struct72.smethod_33(this)) : (rectangleF_0 = Struct72.smethod_17(this)));
				break;
			case AutoShapeType.BentConnector2:
			case AutoShapeType.BentConnector5:
				rectangleF = rectangleF_2;
				if (Width <= 1f)
				{
					rectangleF.Width += 2f;
					float_0 += 2f;
				}
				if (Height <= 1f)
				{
					rectangleF.Height += 2f;
					float_1 += 2f;
				}
				rectangleF = ((Rotation <= 0) ? (rectangleF_0 = Struct72.smethod_32(this)) : (rectangleF_0 = Struct72.smethod_16(this)));
				break;
			case AutoShapeType.CurvedConnector2:
			case AutoShapeType.CurvedConnector:
			case AutoShapeType.CurvedConnector4:
			case AutoShapeType.CurvedConnector5:
				rectangleF = rectangleF_2;
				if (Width <= 1f)
				{
					rectangleF.Width += 2f;
					float_0 += 2f;
				}
				if (Height <= 1f)
				{
					rectangleF.Height += 2f;
					float_1 += 2f;
				}
				rectangleF = ((Rotation > 0 && Rotation != 180) ? (rectangleF_0 = Struct72.smethod_16(this)) : (rectangleF_0 = Struct72.smethod_12(this)));
				break;
			case AutoShapeType.LineCalloutNoBorder3:
			case AutoShapeType.LineCalloutWithBorder3:
				rectangleF = Struct72.smethod_23(this);
				break;
			case AutoShapeType.LineCalloutNoBorder4:
			case AutoShapeType.LineCalloutWithBorder4:
				rectangleF = Struct72.smethod_24(this);
				break;
			case AutoShapeType.LineCalloutWithAccentBar2:
			case AutoShapeType.LineCalloutWithBorderAndAccentBar2:
				rectangleF = Struct72.smethod_25(this);
				break;
			case AutoShapeType.LineCalloutWithAccentBar3:
			case AutoShapeType.LineCalloutWithBorderAndAccentBar3:
				rectangleF = Struct72.smethod_26(this);
				break;
			case AutoShapeType.LineCalloutWithAccentBar4:
			case AutoShapeType.LineCalloutWithBorderAndAccentBar4:
				rectangleF = Struct72.smethod_27(this);
				break;
			case AutoShapeType.RectangularCallout:
			case AutoShapeType.RoundedRectangularCallout:
			case AutoShapeType.OvalCallout:
				rectangleF = Struct72.smethod_14(this);
				break;
			case AutoShapeType.NotPrimitive:
				rectangleF = rectangleF_2;
				if (Width == 0f)
				{
					rectangleF.Width += 1f;
					float_0 += 1f;
				}
				if (Height == 0f)
				{
					rectangleF.Height += 1f;
					float_1 += 1f;
				}
				rectangleF_2.Inflate(class906_0.Weight / 2f, class906_0.Weight / 2f);
				rectangleF = rectangleF_2;
				break;
			default:
				rectangleF_2.Inflate(class906_0.Weight / 2f, class906_0.Weight / 2f);
				rectangleF = rectangleF_2;
				break;
			case AutoShapeType.LineCalloutNoBorder1:
			case AutoShapeType.LineCalloutWithBorder1:
				rectangleF = Struct72.smethod_22(this);
				break;
			case AutoShapeType.CloudCallout:
				rectangleF = Struct72.smethod_28(this);
				break;
			}
			rectangleF_2 = rectangleF;
			break;
		}
		case Enum121.const_1:
			rectangleF_2 = new RectangleF(method_8().X, method_8().Y, method_8().Width + class906_0.Weight, method_8().Height + class906_0.Weight);
			rectangleF_2.Inflate(class906_0.Weight / 2f, class906_0.Weight / 2f);
			break;
		case Enum121.const_2:
			rectangleF_2 = Struct72.smethod_10(this);
			break;
		case Enum121.const_3:
		case Enum121.const_4:
		case Enum121.const_7:
		case Enum121.const_11:
		case Enum121.const_12:
			if (!Line.method_0())
			{
				rectangleF_2.Inflate(class906_0.Weight / 2f, class906_0.Weight / 2f);
			}
			break;
		case Enum121.const_18:
		{
			float num = 0f;
			if (Text != null && Text != "" && Text != string.Empty)
			{
				num = Font.Height;
			}
			rectangleF_2.Inflate(0.5f, 0.5f);
			rectangleF_2.Y -= num / 2f;
			rectangleF_2.Height += num / 2f;
			break;
		}
		case Enum121.const_8:
		case Enum121.const_17:
		case Enum121.const_19:
			rectangleF_2.Inflate(0.5f, 0.5f);
			break;
		case Enum121.const_9:
		case Enum121.const_21:
			if (!Line.method_0())
			{
				rectangleF_2.Inflate(class906_0.Weight, class906_0.Weight);
			}
			break;
		}
		bool_7 = true;
	}

	private void method_28()
	{
		float num = X - method_25().X;
		float num2 = Y - method_25().Y;
		X += num;
		Y += num2;
		rectangleF_2.X += num;
		rectangleF_2.Y += num2;
	}

	public void method_29()
	{
		if (!bool_7)
		{
			method_31();
		}
	}

	[SpecialName]
	public Interface42 imethod_0()
	{
		return interface42_0;
	}

	[SpecialName]
	public void imethod_1(Interface42 interface42_1)
	{
		interface42_0 = interface42_1;
	}

	public void imethod_2()
	{
		vmethod_0(imethod_0(), bool_8: true);
	}

	internal bool method_30()
	{
		if (AutoShapeType != AutoShapeType.Line && AutoShapeType != AutoShapeType.StraightConnector && AutoShapeType != AutoShapeType.ElbowConnector)
		{
			if (AutoShapeType == AutoShapeType.NotPrimitive)
			{
				rectangleF_2.Width += 1f;
				rectangleF_2.Height += 1f;
				Width += 1f;
				Height += 1f;
			}
			if (method_25().Width <= 0f || method_25().Height <= 0f)
			{
				return false;
			}
		}
		return true;
	}

	private void method_31()
	{
		rectangleF_1 = method_8();
		switch (Type)
		{
		case Enum121.const_22:
		{
			RectangleF rectangleF;
			switch (AutoShapeType)
			{
			case AutoShapeType.Line:
				rectangleF = ((!(Line.Weight <= 1f)) ? Struct72.smethod_10(this) : Struct72.smethod_11(this));
				if (bool_4 && (Rotation == 90 || Rotation == 270))
				{
					float height = rectangleF.Height;
					float width = rectangleF.Width;
					rectangleF.Width = height;
					rectangleF.Height = width;
				}
				break;
			case AutoShapeType.StraightConnector:
				rectangleF = ((!(Line.Weight <= 1f)) ? Struct72.smethod_10(this) : Struct72.smethod_11(this));
				if (bool_4 && (Rotation == 90 || Rotation == 270))
				{
					float height2 = rectangleF.Height;
					float width2 = rectangleF.Width;
					rectangleF.Width = height2;
					rectangleF.Height = width2;
				}
				break;
			case AutoShapeType.BentConnector2:
			case AutoShapeType.ElbowConnector:
			case AutoShapeType.BentConnector4:
			case AutoShapeType.BentConnector5:
				rectangleF = rectangleF_1;
				if (Width <= 1f)
				{
					rectangleF.Width += 2f;
					float_0 += 2f;
				}
				if (Height <= 1f)
				{
					rectangleF.Height += 2f;
					float_1 += 2f;
				}
				rectangleF = Struct72.smethod_15(this);
				break;
			case AutoShapeType.CurvedConnector2:
			case AutoShapeType.CurvedConnector:
			case AutoShapeType.CurvedConnector4:
			case AutoShapeType.CurvedConnector5:
				rectangleF = rectangleF_1;
				if (Width <= 1f)
				{
					rectangleF.Width += 2f;
					float_0 += 2f;
				}
				if (Height <= 1f)
				{
					rectangleF.Height += 2f;
					float_1 += 2f;
				}
				rectangleF = Struct72.smethod_15(this);
				break;
			case AutoShapeType.LineCalloutNoBorder3:
			case AutoShapeType.LineCalloutWithBorder3:
				rectangleF = Struct72.smethod_23(this);
				break;
			case AutoShapeType.LineCalloutNoBorder4:
			case AutoShapeType.LineCalloutWithBorder4:
				rectangleF = Struct72.smethod_24(this);
				break;
			case AutoShapeType.LineCalloutWithAccentBar2:
			case AutoShapeType.LineCalloutWithBorderAndAccentBar2:
				rectangleF = Struct72.smethod_25(this);
				break;
			case AutoShapeType.LineCalloutWithAccentBar3:
			case AutoShapeType.LineCalloutWithBorderAndAccentBar3:
				rectangleF = Struct72.smethod_26(this);
				break;
			case AutoShapeType.LineCalloutWithAccentBar4:
			case AutoShapeType.LineCalloutWithBorderAndAccentBar4:
				rectangleF = Struct72.smethod_27(this);
				break;
			case AutoShapeType.RectangularCallout:
			case AutoShapeType.RoundedRectangularCallout:
			case AutoShapeType.OvalCallout:
				rectangleF = Struct72.smethod_14(this);
				break;
			case AutoShapeType.NotPrimitive:
				rectangleF = rectangleF_1;
				if (Width == 0f)
				{
					rectangleF.Width += 1f;
					float_0 += 1f;
				}
				if (Height == 0f)
				{
					rectangleF.Height += 1f;
					float_1 += 1f;
				}
				rectangleF_1.Inflate(class906_0.Weight / 2f, class906_0.Weight / 2f);
				rectangleF = rectangleF_1;
				break;
			default:
				rectangleF_1.Inflate(class906_0.Weight / 2f, class906_0.Weight / 2f);
				rectangleF = rectangleF_1;
				break;
			case AutoShapeType.LineCalloutNoBorder1:
			case AutoShapeType.LineCalloutWithBorder1:
				rectangleF = Struct72.smethod_22(this);
				break;
			case AutoShapeType.CloudCallout:
				rectangleF = Struct72.smethod_28(this);
				break;
			}
			rectangleF_1 = rectangleF;
			if (AutoShapeType != AutoShapeType.Line && AutoShapeType != AutoShapeType.StraightConnector)
			{
				break;
			}
			if (float_1 <= 1f)
			{
				if (class906_0.Weight <= 1f)
				{
					RectangleF rectangleF2 = new RectangleF(rectangleF.X, rectangleF.Y - rectangleF.Height / 2f, rectangleF.Width, rectangleF.Height);
					rectangleF_1 = rectangleF2;
				}
				else
				{
					rectangleF_1 = rectangleF;
				}
			}
			if (float_0 <= 1f)
			{
				if (class906_0.Weight <= 1f)
				{
					RectangleF rectangleF3 = new RectangleF(rectangleF.X - rectangleF.Width / 2f, rectangleF.Y, rectangleF.Width, rectangleF.Height);
					rectangleF_1 = rectangleF3;
				}
				else
				{
					rectangleF_1 = rectangleF;
				}
			}
			break;
		}
		case Enum121.const_1:
			rectangleF_1 = new RectangleF(method_8().X, method_8().Y, method_8().Width + class906_0.Weight, method_8().Height + class906_0.Weight);
			rectangleF_1.Inflate(class906_0.Weight / 2f, class906_0.Weight / 2f);
			break;
		case Enum121.const_2:
			rectangleF_1 = Struct72.smethod_10(this);
			break;
		case Enum121.const_3:
		case Enum121.const_4:
		case Enum121.const_7:
		case Enum121.const_11:
		case Enum121.const_12:
			if (!Line.method_0())
			{
				rectangleF_1.Inflate(class906_0.Weight / 2f, class906_0.Weight / 2f);
			}
			break;
		case Enum121.const_18:
		{
			float num = 0f;
			if (Text != null && Text != "" && Text != string.Empty)
			{
				num = Font.Height;
			}
			rectangleF_1.Inflate(0.5f, 0.5f);
			rectangleF_1.Y -= num / 2f;
			rectangleF_1.Height += num / 2f;
			break;
		}
		case Enum121.const_8:
		case Enum121.const_17:
		case Enum121.const_19:
			rectangleF_1.Inflate(0.5f, 0.5f);
			break;
		case Enum121.const_9:
		case Enum121.const_21:
			if (!Line.method_0())
			{
				rectangleF_1.Inflate(class906_0.Weight, class906_0.Weight);
			}
			break;
		}
		bool_7 = true;
	}
}
