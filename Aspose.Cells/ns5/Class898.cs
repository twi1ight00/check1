using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns19;

namespace ns5;

internal class Class898 : Interface6
{
	private Class895 class895_0;

	private Enum103 enum103_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private int int_0;

	private Class884 class884_0;

	private Class889 class889_0;

	private Font font_0 = Struct69.font_0;

	private Color color_0 = Color.Black;

	private Enum104 enum104_0 = Enum104.const_7;

	private Enum104 enum104_1 = Enum104.const_9;

	private Enum105 enum105_0;

	private Enum107 enum107_0 = Enum107.const_2;

	private bool bool_0 = true;

	private Class896 class896_0;

	private Class894 class894_0;

	private Class887 class887_0;

	private Class158 class158_0;

	private string string_0 = "";

	private ArrayList arrayList_0 = new ArrayList();

	private PointF pointF_0 = PointF.Empty;

	private Enum101 enum101_0;

	private IList ilist_0 = new ArrayList();

	private IList ilist_1 = new ArrayList();

	private string string_1 = "";

	private int int_1;

	private bool bool_1;

	private bool bool_2;

	private RectangleF rectangleF_0 = new RectangleF(0f, 0f, 0f, 0f);

	public int int_2 = 1;

	public ArrayList arrayList_1 = new ArrayList();

	public Class898 class898_0;

	public bool bool_3;

	public bool bool_4;

	public bool bool_5;

	public Chart chart_0;

	public Shape shape_0;

	public PointF pointF_1 = PointF.Empty;

	public PointF pointF_2 = PointF.Empty;

	internal RectangleF rectangleF_1 = new RectangleF(0f, 0f, 0f, 0f);

	private RectangleF rectangleF_2;

	private bool bool_6;

	public Class885 class885_0;

	private AutoShapeType autoShapeType_0;

	private Interface42 interface42_0;

	internal Class158 TextFrame => class158_0;

	public Enum103 Type => enum103_0;

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

	public Class884 Fill => class884_0;

	public Class889 Line => class889_0;

	public Font Font
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

	[SpecialName]
	internal Class896 method_0()
	{
		return class896_0;
	}

	[SpecialName]
	internal void method_1(Class896 class896_1)
	{
		class896_0 = class896_1;
	}

	[SpecialName]
	internal Class894 method_2()
	{
		return class894_0;
	}

	[SpecialName]
	internal void method_3(Class894 class894_1)
	{
		class894_0 = class894_1;
	}

	[SpecialName]
	internal Class887 method_4()
	{
		return class887_0;
	}

	[SpecialName]
	internal void method_5(Class887 class887_1)
	{
		class887_0 = class887_1;
	}

	[SpecialName]
	internal void method_6(Class158 class158_1)
	{
		class158_0 = class158_1;
	}

	public Class898(Class895 class895_1, Enum103 enum103_1)
	{
		class895_0 = class895_1;
		enum103_0 = enum103_1;
		class884_0 = new Class884(this);
		class889_0 = new Class889(this);
	}

	public Class898(Enum103 enum103_1)
		: this(null, enum103_1)
	{
	}

	[SpecialName]
	public RectangleF method_7()
	{
		return new RectangleF(float_2, float_3, float_0, float_1);
	}

	[SpecialName]
	public Enum107 method_8()
	{
		return enum107_0;
	}

	[SpecialName]
	public void method_9(Enum107 enum107_1)
	{
		enum107_0 = enum107_1;
	}

	[SpecialName]
	public ArrayList method_10()
	{
		return arrayList_0;
	}

	[SpecialName]
	public Enum101 method_11()
	{
		return enum101_0;
	}

	[SpecialName]
	public void method_12(Enum101 enum101_1)
	{
		enum101_0 = enum101_1;
	}

	[SpecialName]
	public IList method_13()
	{
		return ilist_0;
	}

	[SpecialName]
	public int method_14()
	{
		return int_1;
	}

	[SpecialName]
	public IList method_15()
	{
		return ilist_1;
	}

	[SpecialName]
	public void method_16(IList ilist_2)
	{
		ilist_1 = ilist_2;
	}

	[SpecialName]
	public void method_17(string string_2)
	{
		string_1 = string_2;
	}

	[SpecialName]
	public bool method_18()
	{
		return bool_1;
	}

	[SpecialName]
	public void method_19(bool bool_7)
	{
		bool_1 = bool_7;
	}

	[SpecialName]
	public bool method_20()
	{
		return bool_2;
	}

	[SpecialName]
	public void method_21(bool bool_7)
	{
		bool_2 = bool_7;
	}

	[SpecialName]
	internal RectangleF method_22()
	{
		if (!bool_6)
		{
			method_23();
		}
		return rectangleF_2;
	}

	public virtual void vmethod_0(Interface42 interface42_1, bool bool_7)
	{
		if (!bool_6)
		{
			method_23();
		}
		if (bool_7)
		{
			method_24();
		}
		interface42_1.ResetTransform();
		switch (Type)
		{
		case Enum103.const_1:
		{
			for (int i = 0; i < arrayList_1.Count; i++)
			{
				Class898 @class = (Class898)arrayList_1[i];
				if (@class.bool_4)
				{
					Chart chart = @class.chart_0;
					MemoryStream memoryStream = new MemoryStream();
					chart.ToImage(memoryStream, ImageFormat.Emf);
					Image image = Image.FromStream(memoryStream);
					RectangleF rectangleF = new RectangleF(0f, 0f, image.Width, image.Height);
					RectangleF rectangleF2 = @class.method_7();
					interface42_1.imethod_14(image, rectangleF2, rectangleF, GraphicsUnit.Pixel);
					memoryStream.Close();
					image.Dispose();
				}
				else
				{
					@class.vmethod_0(interface42_1, bool_7: false);
				}
			}
			break;
		}
		case Enum103.const_2:
			Struct68.smethod_1(interface42_1, this);
			break;
		case Enum103.const_3:
			Struct68.smethod_80(interface42_1, this);
			break;
		case Enum103.const_4:
			Struct68.smethod_3(interface42_1, this);
			break;
		case Enum103.const_7:
			Struct68.smethod_0(interface42_1, this);
			break;
		case Enum103.const_8:
			Struct68.smethod_6(interface42_1, this);
			break;
		case Enum103.const_9:
			Struct68.smethod_13(interface42_1, this);
			break;
		case Enum103.const_10:
			Struct68.smethod_22(interface42_1, this);
			break;
		case Enum103.const_11:
			Struct68.smethod_7(interface42_1, this);
			break;
		case Enum103.const_12:
			Struct68.smethod_8(interface42_1, this);
			break;
		case Enum103.const_13:
			Struct68.smethod_4(interface42_1, this);
			break;
		case Enum103.const_17:
			Struct68.smethod_9(interface42_1, this);
			break;
		case Enum103.const_18:
			Struct68.smethod_5(interface42_1, this);
			break;
		case Enum103.const_19:
			Struct68.smethod_11(interface42_1, this);
			break;
		case Enum103.const_21:
			Struct68.smethod_15(interface42_1, this);
			break;
		case Enum103.const_20:
			Struct68.smethod_12(interface42_1, this);
			break;
		case Enum103.const_22:
			switch (AutoShapeType)
			{
			case AutoShapeType.NotPrimitive:
				Struct68.smethod_22(interface42_1, this);
				break;
			case AutoShapeType.Rectangle:
				Struct68.smethod_2(interface42_1, this);
				break;
			case AutoShapeType.RoundedRectangle:
				Struct68.smethod_84(interface42_1, this);
				break;
			case AutoShapeType.Oval:
				Struct68.smethod_88(interface42_1, this);
				break;
			case AutoShapeType.Diamond:
				Struct68.smethod_83(interface42_1, this);
				break;
			case AutoShapeType.IsoscelesTriangle:
				Struct68.smethod_86(interface42_1, this);
				break;
			case AutoShapeType.RightTriangle:
				Struct68.smethod_87(interface42_1, this);
				break;
			case AutoShapeType.Parallelogram:
				Struct68.smethod_81(interface42_1, this);
				break;
			case AutoShapeType.Trapezoid:
				Struct68.smethod_82(interface42_1, this);
				break;
			case AutoShapeType.Hexagon:
				Struct68.smethod_89(interface42_1, this);
				break;
			case AutoShapeType.Octagon:
				Struct68.smethod_85(interface42_1, this);
				break;
			case AutoShapeType.Cross:
				Struct68.smethod_90(interface42_1, this);
				break;
			case AutoShapeType.Star5:
				Struct68.smethod_122(interface42_1, this);
				break;
			case AutoShapeType.RightArrow:
				Struct68.smethod_30(interface42_1, this);
				break;
			case AutoShapeType.HomePlate:
				Struct68.smethod_41(interface42_1, this);
				break;
			case AutoShapeType.Cube:
				Struct68.smethod_93(interface42_1, this);
				break;
			case AutoShapeType.Arc:
				Struct68.smethod_104(interface42_1, this);
				break;
			case AutoShapeType.Line:
				Struct68.smethod_1(interface42_1, this);
				break;
			case AutoShapeType.Plaque:
				Struct68.smethod_100(interface42_1, this);
				break;
			case AutoShapeType.Can:
				Struct68.smethod_92(interface42_1, this);
				break;
			case AutoShapeType.Donut:
				Struct68.smethod_97(interface42_1, this);
				break;
			case AutoShapeType.StraightConnector:
				Struct68.smethod_20(interface42_1, this);
				break;
			case AutoShapeType.BentConnector2:
				Struct68.smethod_25(interface42_1, this);
				break;
			case AutoShapeType.ElbowConnector:
				Struct68.smethod_21(interface42_1, this);
				break;
			case AutoShapeType.BentConnector4:
				Struct68.smethod_23(interface42_1, this);
				break;
			case AutoShapeType.BentConnector5:
				Struct68.smethod_24(interface42_1, this);
				break;
			case AutoShapeType.CurvedConnector2:
				Struct68.smethod_27(interface42_1, this);
				break;
			case AutoShapeType.CurvedConnector:
				Struct68.smethod_26(interface42_1, this);
				break;
			case AutoShapeType.CurvedConnector4:
				Struct68.smethod_28(interface42_1, this);
				break;
			case AutoShapeType.CurvedConnector5:
				Struct68.smethod_29(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutNoBorder2:
				Struct68.smethod_151(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutNoBorder3:
				Struct68.smethod_152(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutNoBorder4:
				Struct68.smethod_153(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithAccentBar2:
				Struct68.smethod_147(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithAccentBar3:
				Struct68.smethod_148(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithAccentBar4:
				Struct68.smethod_149(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithBorder2:
				Struct68.smethod_139(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithBorder3:
				Struct68.smethod_140(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithBorder4:
				Struct68.smethod_141(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithBorderAndAccentBar2:
				Struct68.smethod_143(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithBorderAndAccentBar3:
				Struct68.smethod_144(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithBorderAndAccentBar4:
				Struct68.smethod_145(interface42_1, this);
				break;
			case AutoShapeType.DownRibbon:
				Struct68.smethod_107(interface42_1, this);
				break;
			case AutoShapeType.UpRibbon:
				Struct68.smethod_106(interface42_1, this);
				break;
			case AutoShapeType.Chevron:
				Struct68.smethod_42(interface42_1, this);
				break;
			case AutoShapeType.RegularPentagon:
				Struct68.smethod_91(interface42_1, this);
				break;
			case AutoShapeType.NoSymbol:
				Struct68.smethod_116(interface42_1, this);
				break;
			case AutoShapeType.Star8:
				Struct68.smethod_123(interface42_1, this);
				break;
			case AutoShapeType.Star16:
				Struct68.smethod_124(interface42_1, this);
				break;
			case AutoShapeType.Star32:
				Struct68.smethod_126(interface42_1, this);
				break;
			case AutoShapeType.RectangularCallout:
				Struct68.smethod_135(interface42_1, this);
				break;
			case AutoShapeType.RoundedRectangularCallout:
				Struct68.smethod_136(interface42_1, this);
				break;
			case AutoShapeType.OvalCallout:
				Struct68.smethod_137(interface42_1, this);
				break;
			case AutoShapeType.Wave:
				Struct68.smethod_129(interface42_1, this);
				break;
			case AutoShapeType.FoldedCorner:
				Struct68.smethod_95(interface42_1, this);
				break;
			case AutoShapeType.LeftArrow:
				Struct68.smethod_31(interface42_1, this);
				break;
			case AutoShapeType.DownArrow:
				Struct68.smethod_33(interface42_1, this);
				break;
			case AutoShapeType.UpArrow:
				Struct68.smethod_34(interface42_1, this);
				break;
			case AutoShapeType.LeftRightArrow:
				Struct68.smethod_32(interface42_1, this);
				break;
			case AutoShapeType.UpDownArrow:
				Struct68.smethod_35(interface42_1, this);
				break;
			case AutoShapeType.Explosion1:
				Struct68.smethod_119(interface42_1, this);
				break;
			case AutoShapeType.Explosion2:
				Struct68.smethod_120(interface42_1, this);
				break;
			case AutoShapeType.LightningBolt:
				Struct68.smethod_98(interface42_1, this);
				break;
			case AutoShapeType.Heart:
				Struct68.smethod_110(interface42_1, this);
				break;
			case AutoShapeType.QuadArrow:
				Struct68.smethod_36(interface42_1, this);
				break;
			case AutoShapeType.LeftArrowCallout:
				Struct68.smethod_45(interface42_1, this);
				break;
			case AutoShapeType.RightArrowCallout:
				Struct68.smethod_44(interface42_1, this);
				break;
			case AutoShapeType.UpArrowCallout:
				Struct68.smethod_46(interface42_1, this);
				break;
			case AutoShapeType.DownArrowCallout:
				Struct68.smethod_47(interface42_1, this);
				break;
			case AutoShapeType.LeftRightArrowCallout:
				Struct68.smethod_48(interface42_1, this);
				break;
			case AutoShapeType.UpDownArrowCallout:
				Struct68.smethod_49(interface42_1, this);
				break;
			case AutoShapeType.QuadArrowCallout:
				Struct68.smethod_50(interface42_1, this);
				break;
			case AutoShapeType.Bevel:
				Struct68.smethod_94(interface42_1, this);
				break;
			case AutoShapeType.LeftBracket:
				Struct68.smethod_117(interface42_1, this);
				break;
			case AutoShapeType.RightBracket:
				Struct68.smethod_118(interface42_1, this);
				break;
			case AutoShapeType.LeftBrace:
				Struct68.smethod_101(interface42_1, this);
				break;
			case AutoShapeType.RightBrace:
				Struct68.smethod_102(interface42_1, this);
				break;
			case AutoShapeType.LeftUpArrow:
				Struct68.smethod_38(interface42_1, this);
				break;
			case AutoShapeType.BentUpArrow:
				Struct68.smethod_39(interface42_1, this);
				break;
			case AutoShapeType.BentArrow:
				Struct68.smethod_37(interface42_1, this);
				break;
			case AutoShapeType.Star24:
				Struct68.smethod_125(interface42_1, this);
				break;
			case AutoShapeType.StripedRightArrow:
				Struct68.smethod_43(interface42_1, this);
				break;
			case AutoShapeType.NotchedRightArrow:
				Struct68.smethod_40(interface42_1, this);
				break;
			case AutoShapeType.BlockArc:
				Struct68.smethod_108(interface42_1, this);
				break;
			case AutoShapeType.SmileyFace:
				Struct68.smethod_96(interface42_1, this);
				break;
			case AutoShapeType.VerticalScroll:
				Struct68.smethod_127(interface42_1, this);
				break;
			case AutoShapeType.HorizontalScroll:
				Struct68.smethod_128(interface42_1, this);
				break;
			case AutoShapeType.CircularArrow:
				Struct68.smethod_115(interface42_1, this);
				break;
			case AutoShapeType.UTurnArrow:
				Struct68.smethod_131(interface42_1, this);
				break;
			case AutoShapeType.CurvedRightArrow:
				Struct68.smethod_111(interface42_1, this);
				break;
			case AutoShapeType.CurvedLeftArrow:
				Struct68.smethod_112(interface42_1, this);
				break;
			case AutoShapeType.CurvedUpArrow:
				Struct68.smethod_114(interface42_1, this);
				break;
			case AutoShapeType.CurvedDownArrow:
				Struct68.smethod_113(interface42_1, this);
				break;
			case AutoShapeType.CloudCallout:
				Struct68.smethod_138(interface42_1, this);
				break;
			case AutoShapeType.CurvedDownRibbon:
				Struct68.smethod_132(interface42_1, this);
				break;
			case AutoShapeType.CurvedUpRibbon:
				Struct68.smethod_133(interface42_1, this);
				break;
			case AutoShapeType.FlowChartProcess:
				Struct68.smethod_52(interface42_1, this);
				break;
			case AutoShapeType.FlowChartDecision:
				Struct68.smethod_75(interface42_1, this);
				break;
			case AutoShapeType.FlowChartData:
				Struct68.smethod_55(interface42_1, this);
				break;
			case AutoShapeType.FlowChartPredefinedProcess:
				Struct68.smethod_67(interface42_1, this);
				break;
			case AutoShapeType.FlowChartInternalStorage:
				Struct68.smethod_60(interface42_1, this);
				break;
			case AutoShapeType.FlowChartDocument:
				Struct68.smethod_59(interface42_1, this);
				break;
			case AutoShapeType.FlowChartMultidocument:
				Struct68.smethod_65(interface42_1, this);
				break;
			case AutoShapeType.FlowChartTerminator:
				Struct68.smethod_72(interface42_1, this);
				break;
			case AutoShapeType.FlowChartPreparation:
				Struct68.smethod_78(interface42_1, this);
				break;
			case AutoShapeType.FlowChartManualInput:
				Struct68.smethod_62(interface42_1, this);
				break;
			case AutoShapeType.FlowChartManualOperation:
				Struct68.smethod_63(interface42_1, this);
				break;
			case AutoShapeType.FlowChartConnector:
				Struct68.smethod_79(interface42_1, this);
				break;
			case AutoShapeType.FlowChartCard:
				Struct68.smethod_53(interface42_1, this);
				break;
			case AutoShapeType.FlowChartPunchedTape:
				Struct68.smethod_68(interface42_1, this);
				break;
			case AutoShapeType.FlowChartSummingJunction:
				Struct68.smethod_74(interface42_1, this);
				break;
			case AutoShapeType.FlowChartOr:
				Struct68.smethod_73(interface42_1, this);
				break;
			case AutoShapeType.FlowChartCollate:
				Struct68.smethod_54(interface42_1, this);
				break;
			case AutoShapeType.FlowChartSort:
				Struct68.smethod_70(interface42_1, this);
				break;
			case AutoShapeType.FlowChartExtract:
				Struct68.smethod_77(interface42_1, this);
				break;
			case AutoShapeType.FlowChartMerge:
				Struct68.smethod_64(interface42_1, this);
				break;
			case AutoShapeType.FlowChartStoredData:
				Struct68.smethod_71(interface42_1, this);
				break;
			case AutoShapeType.FlowChartSequentialAccessStorage:
				Struct68.smethod_69(interface42_1, this);
				break;
			case AutoShapeType.FlowChartMagneticDisk:
				Struct68.smethod_61(interface42_1, this);
				break;
			case AutoShapeType.FlowChartDirectAccessStorage:
				Struct68.smethod_57(interface42_1, this);
				break;
			case AutoShapeType.FlowChartDisplay:
				Struct68.smethod_58(interface42_1, this);
				break;
			case AutoShapeType.FlowChartDelay:
				Struct68.smethod_56(interface42_1, this);
				break;
			case AutoShapeType.TextPlainText:
			case AutoShapeType.TextSlantUp:
				Struct68.smethod_154(interface42_1, this);
				break;
			case AutoShapeType.FlowChartAlternateProcess:
				Struct68.smethod_76(interface42_1, this);
				break;
			case AutoShapeType.FlowChartOffpageConnector:
				Struct68.smethod_66(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutNoBorder1:
				Struct68.smethod_150(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithAccentBar1:
				Struct68.smethod_146(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithBorder1:
				Struct68.smethod_134(interface42_1, this);
				break;
			case AutoShapeType.LineCalloutWithBorderAndAccentBar1:
				Struct68.smethod_142(interface42_1, this);
				break;
			case AutoShapeType.LeftRightUpArrow:
				Struct68.smethod_51(interface42_1, this);
				break;
			case AutoShapeType.Sun:
				Struct68.smethod_99(interface42_1, this);
				break;
			case AutoShapeType.Moon:
				Struct68.smethod_109(interface42_1, this);
				break;
			case AutoShapeType.DoubleBracket:
				Struct68.smethod_105(interface42_1, this);
				break;
			case AutoShapeType.DoubleBrace:
				Struct68.smethod_103(interface42_1, this);
				break;
			case AutoShapeType.Star4:
				Struct68.smethod_121(interface42_1, this);
				break;
			case AutoShapeType.DoubleWave:
				Struct68.smethod_130(interface42_1, this);
				break;
			default:
				if (method_4() != null && method_4().method_0().Count > 0)
				{
					Struct68.smethod_22(interface42_1, this);
				}
				break;
			case AutoShapeType.TextBox:
				Struct68.smethod_0(interface42_1, this);
				break;
			}
			break;
		case Enum103.const_5:
		case Enum103.const_6:
		case (Enum103)10:
		case (Enum103)13:
		case Enum103.const_14:
		case Enum103.const_15:
		case Enum103.const_16:
		case (Enum103)21:
		case (Enum103)22:
		case (Enum103)23:
		case (Enum103)26:
		case (Enum103)27:
		case (Enum103)28:
		case Enum103.const_23:
			break;
		}
	}

	private void method_23()
	{
		rectangleF_2 = method_7();
		switch (Type)
		{
		case Enum103.const_22:
		{
			RectangleF rectangleF;
			switch (AutoShapeType)
			{
			case AutoShapeType.RectangularCallout:
			case AutoShapeType.RoundedRectangularCallout:
			case AutoShapeType.OvalCallout:
				rectangleF = Struct69.smethod_17(this);
				break;
			case AutoShapeType.LeftArrow:
			case AutoShapeType.DownArrow:
			case AutoShapeType.UpArrow:
				rectangleF = new RectangleF(method_7().X, method_7().Y, method_7().Width + class889_0.Weight, method_7().Height + class889_0.Weight);
				break;
			case AutoShapeType.StraightConnector:
				rectangleF = ((!(Line.Weight <= 1f)) ? Struct69.smethod_13(this) : Struct69.smethod_20(this));
				break;
			case AutoShapeType.BentConnector2:
			case AutoShapeType.ElbowConnector:
			case AutoShapeType.BentConnector4:
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
				rectangleF = ((Rotation <= 0 || Rotation == 180) ? Struct69.smethod_21(this) : Struct69.smethod_22(this));
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
				rectangleF = ((Rotation <= 0 || Rotation == 180) ? Struct69.smethod_23(this) : Struct69.smethod_22(this));
				break;
			default:
				rectangleF_2 = new RectangleF(method_7().X, method_7().Y, method_7().Width + class889_0.Weight, method_7().Height + class889_0.Weight);
				rectangleF_2.Inflate(class889_0.Weight / 2f, class889_0.Weight / 2f);
				rectangleF = rectangleF_2;
				break;
			case AutoShapeType.LineCalloutWithBorder1:
				rectangleF = Struct69.smethod_25(this);
				break;
			case AutoShapeType.TextPlainText:
				rectangleF = new RectangleF(method_7().X, method_7().Y, method_7().Width + class889_0.Weight + 25f, method_7().Height + class889_0.Weight);
				break;
			}
			rectangleF_2 = rectangleF;
			break;
		}
		case Enum103.const_1:
			rectangleF_2 = new RectangleF(method_7().X, method_7().Y, method_7().Width + class889_0.Weight, method_7().Height + class889_0.Weight);
			rectangleF_2.Inflate(class889_0.Weight / 2f, class889_0.Weight / 2f);
			break;
		case Enum103.const_2:
			rectangleF_2 = Struct69.smethod_13(this);
			break;
		case Enum103.const_3:
			rectangleF_2 = new RectangleF(method_7().X, method_7().Y, method_7().Width + class889_0.Weight, method_7().Height + class889_0.Weight);
			rectangleF_2.Inflate(class889_0.Weight / 2f, class889_0.Weight / 2f);
			break;
		case Enum103.const_4:
		case Enum103.const_7:
		case Enum103.const_11:
		case Enum103.const_12:
			if (!Line.method_0())
			{
				rectangleF_2.Inflate(class889_0.Weight / 2f, class889_0.Weight / 2f);
			}
			break;
		case Enum103.const_18:
		{
			float num = 0f;
			if (Text != null && Text != "")
			{
				num = 12f;
			}
			rectangleF_2 = new RectangleF(method_7().X, method_7().Y, method_7().Width + class889_0.Weight, method_7().Height + class889_0.Weight);
			rectangleF_2.Inflate(0.5f, 0.5f);
			rectangleF_2.Y -= num / 2f;
			rectangleF_2.Height += num / 2f;
			break;
		}
		case Enum103.const_8:
		case Enum103.const_17:
		case Enum103.const_19:
			rectangleF_2 = new RectangleF(method_7().X, method_7().Y, method_7().Width + class889_0.Weight, method_7().Height + class889_0.Weight);
			rectangleF_2.Inflate(0.5f, 0.5f);
			break;
		case Enum103.const_9:
		case Enum103.const_21:
			if (!Line.method_0())
			{
				rectangleF_2.Inflate(class889_0.Weight, class889_0.Weight);
			}
			break;
		}
		bool_6 = true;
	}

	private void method_24()
	{
		float num = X - method_22().X;
		float num2 = Y - method_22().Y;
		X += num;
		Y += num2;
		rectangleF_2.X += num;
		rectangleF_2.Y += num;
	}

	public void method_25()
	{
		if (!bool_6)
		{
			method_28();
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
		if (method_26())
		{
			vmethod_0(imethod_0(), bool_7: true);
		}
	}

	internal bool method_26()
	{
		if (AutoShapeType != AutoShapeType.Line && AutoShapeType != AutoShapeType.StraightConnector && (method_22().Width <= 0f || method_22().Height <= 0f))
		{
			return false;
		}
		return true;
	}

	[SpecialName]
	internal RectangleF method_27()
	{
		if (!bool_6)
		{
			method_28();
		}
		return rectangleF_1;
	}

	private void method_28()
	{
		rectangleF_1 = method_7();
		switch (Type)
		{
		case Enum103.const_22:
		{
			RectangleF rectangleF;
			switch (AutoShapeType)
			{
			case AutoShapeType.RectangularCallout:
			case AutoShapeType.RoundedRectangularCallout:
			case AutoShapeType.OvalCallout:
				rectangleF = Struct69.smethod_17(this);
				break;
			case AutoShapeType.LeftArrow:
			case AutoShapeType.DownArrow:
			case AutoShapeType.UpArrow:
				rectangleF = new RectangleF(method_7().X, method_7().Y, method_7().Width + class889_0.Weight, method_7().Height + class889_0.Weight);
				break;
			case AutoShapeType.StraightConnector:
				rectangleF = ((!(Line.Weight <= 1f)) ? Struct69.smethod_13(this) : Struct69.smethod_20(this));
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
				rectangleF = ((Rotation <= 0 || Rotation == 180) ? Struct69.smethod_21(this) : Struct69.smethod_22(this));
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
				rectangleF = ((Rotation <= 0 || Rotation == 180) ? Struct69.smethod_23(this) : Struct69.smethod_22(this));
				break;
			default:
				rectangleF_1 = new RectangleF(method_7().X, method_7().Y, method_7().Width + class889_0.Weight, method_7().Height + class889_0.Weight);
				rectangleF_1.Inflate(class889_0.Weight / 2f, class889_0.Weight / 2f);
				rectangleF = rectangleF_1;
				break;
			case AutoShapeType.LineCalloutWithBorder1:
				rectangleF = Struct69.smethod_25(this);
				break;
			case AutoShapeType.TextPlainText:
				rectangleF = new RectangleF(method_7().X, method_7().Y, method_7().Width + class889_0.Weight + 25f, method_7().Height + class889_0.Weight);
				break;
			}
			rectangleF_1 = rectangleF;
			if (AutoShapeType != AutoShapeType.Line && AutoShapeType != AutoShapeType.StraightConnector)
			{
				break;
			}
			if (float_1 <= 1f)
			{
				if (class889_0.Weight <= 1f)
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
				if (class889_0.Weight <= 1f)
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
		case Enum103.const_1:
			rectangleF_1 = new RectangleF(method_7().X, method_7().Y, method_7().Width + class889_0.Weight, method_7().Height + class889_0.Weight);
			rectangleF_1.Inflate(class889_0.Weight / 2f, class889_0.Weight / 2f);
			break;
		case Enum103.const_2:
			rectangleF_1 = Struct69.smethod_13(this);
			break;
		case Enum103.const_3:
			rectangleF_1 = new RectangleF(method_7().X, method_7().Y, method_7().Width + class889_0.Weight, method_7().Height + class889_0.Weight);
			rectangleF_1.Inflate(class889_0.Weight / 2f, class889_0.Weight / 2f);
			break;
		case Enum103.const_4:
		case Enum103.const_7:
		case Enum103.const_11:
		case Enum103.const_12:
			if (!Line.method_0())
			{
				rectangleF_1.Inflate(class889_0.Weight / 2f, class889_0.Weight / 2f);
			}
			break;
		case Enum103.const_18:
		{
			float num = 0f;
			if (Text != null && Text != "")
			{
				num = 12f;
			}
			rectangleF_1 = new RectangleF(method_7().X, method_7().Y, method_7().Width + class889_0.Weight, method_7().Height + class889_0.Weight);
			rectangleF_1.Inflate(0.5f, 0.5f);
			rectangleF_1.Y -= num / 2f;
			rectangleF_1.Height += num / 2f;
			break;
		}
		case Enum103.const_8:
		case Enum103.const_17:
		case Enum103.const_19:
			rectangleF_1 = new RectangleF(method_7().X, method_7().Y, method_7().Width + class889_0.Weight, method_7().Height + class889_0.Weight);
			rectangleF_1.Inflate(0.5f, 0.5f);
			break;
		case Enum103.const_9:
		case Enum103.const_21:
			if (!Line.method_0())
			{
				rectangleF_1.Inflate(class889_0.Weight, class889_0.Weight);
			}
			break;
		}
		bool_6 = true;
	}
}
