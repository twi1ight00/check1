using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using Aspose.Slides;
using ns24;
using ns32;
using ns33;
using ns4;
using ns60;
using ns62;
using ns63;

namespace ns15;

[Guid("82bdf870-2570-4c78-ad9b-a684e1de1c4d")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
internal class Class232
{
	private delegate void Delegate6(float width, float height, Class341[] adjustments, int[] srcValues);

	private delegate int[] Delegate7(float width, float height, Class341[] domAdjustments);

	private static readonly Class1155 class1155_0;

	private static readonly Class1155 class1155_1;

	private static readonly Class1155 class1155_2;

	private static readonly Class1155 class1155_3;

	private static readonly Class1155 class1155_4;

	private static readonly ShapeType[] shapeType_0;

	private static readonly object[] object_0;

	private static readonly Class1155 class1155_5;

	private static readonly Class1155 class1155_6;

	private static readonly Class1155 class1155_7;

	private static readonly Class1155 class1155_8;

	private static readonly SchemeColor[] schemeColor_0;

	internal static readonly Class1155 class1155_9;

	internal static readonly Class1155 class1155_10;

	internal static readonly Class1155 class1155_11;

	internal static readonly Class1155 class1155_12;

	internal static Class1155 class1155_13;

	private static Class1155 class1155_14;

	private static Class1155 class1155_15;

	private static readonly Class1155 class1155_16;

	private static readonly Class1155 class1155_17;

	private static readonly Dictionary<ShapeType, Delegate6> dictionary_0;

	private static readonly Dictionary<ShapeType, Delegate7> dictionary_1;

	internal static NumberedBulletStyle smethod_0(Enum444 scheme)
	{
		return (NumberedBulletStyle)scheme;
	}

	internal static Enum444 smethod_1(NumberedBulletStyle style)
	{
		return (Enum444)style;
	}

	internal static void smethod_2(Enum384 placeholderType, out PlaceholderType typeEx, out Orientation orienataionEx)
	{
		typeEx = (PlaceholderType)class1155_0[placeholderType];
		switch (placeholderType)
		{
		default:
			orienataionEx = Orientation.Horizontal;
			break;
		case Enum384.const_17:
		case Enum384.const_18:
			orienataionEx = Orientation.Vertical;
			break;
		}
	}

	internal static Enum384 smethod_3(PlaceholderType domType)
	{
		object obj = class1155_1[domType];
		if (obj != null)
		{
			return (Enum384)obj;
		}
		return Enum384.const_0;
	}

	internal static Enum384 smethod_4(PlaceholderType domType)
	{
		object obj = class1155_2[domType];
		if (obj != null)
		{
			return (Enum384)obj;
		}
		return Enum384.const_0;
	}

	internal static Enum384 smethod_5(PlaceholderType domType, Orientation domOrientation)
	{
		object obj = null;
		obj = ((domOrientation != 0) ? class1155_4[domType] : class1155_3[domType]);
		if (obj != null)
		{
			return (Enum384)obj;
		}
		return Enum384.const_0;
	}

	internal static ShapeType smethod_6(int type)
	{
		if (type >= 0 && type < shapeType_0.Length)
		{
			return shapeType_0[type];
		}
		return ShapeType.NotDefined;
	}

	internal static LineJoinStyle smethod_7(ShapeType shapetype)
	{
		switch (shapetype)
		{
		default:
			return LineJoinStyle.Miter;
		case ShapeType.FoldedCorner:
		case ShapeType.LeftBrace:
		case ShapeType.RightBrace:
		case ShapeType.BracePair:
		case ShapeType.Ribbon:
		case ShapeType.Ribbon2:
		case ShapeType.EllipseRibbon:
		case ShapeType.EllipseRibbon2:
		case ShapeType.Wave:
		case ShapeType.DoubleWave:
			return LineJoinStyle.Round;
		}
	}

	internal static void smethod_8(Size slideSize, Enum453 slideSizeType, out SizeF slideSizeEx, out SlideSizeType slideSizeTypeEx)
	{
		slideSizeTypeEx = (SlideSizeType)class1155_5[slideSizeType];
		slideSizeEx = new SizeF((float)slideSize.Width / 8f, (float)slideSize.Height / 8f);
	}

	internal static void smethod_9(Class2864 documentAtom, SlideSize domSlideSize)
	{
		domSlideSize.slideSizeType_0 = (SlideSizeType)class1155_5[documentAtom.SlideSizeType];
		Size slideSize = documentAtom.SlideSize;
		domSlideSize.long_0 = (long)Math.Round((float)(slideSize.Width * 12700L) / 8f);
		domSlideSize.long_1 = (long)Math.Round((float)(slideSize.Height * 12700L) / 8f);
	}

	internal static void smethod_10(SlideSize domSlideSize, Class2864 documentAtom)
	{
		documentAtom.SlideSizeType = (Enum453)class1155_6[domSlideSize.slideSizeType_0];
		documentAtom.SlideSize = new Size((int)(domSlideSize.long_0 * 8L / 12700L), (int)(domSlideSize.long_1 * 8L / 12700L));
	}

	internal static SlideLayoutType smethod_11(Enum451 layout)
	{
		object obj = class1155_7[layout];
		if (obj != null)
		{
			return (SlideLayoutType)obj;
		}
		return SlideLayoutType.Blank;
	}

	internal static Enum451 smethod_12(SlideLayoutType layout)
	{
		object obj = class1155_8[layout];
		if (obj != null)
		{
			return (Enum451)obj;
		}
		return Enum451.const_11;
	}

	public static SchemeColor smethod_13(int pptColorIndex)
	{
		if (pptColorIndex < 0)
		{
			pptColorIndex = 0;
		}
		else if (pptColorIndex > 7)
		{
			pptColorIndex = 7;
		}
		return schemeColor_0[pptColorIndex];
	}

	internal static LineDashStyle smethod_14(Enum393 dashStyle)
	{
		return (LineDashStyle)class1155_10[dashStyle];
	}

	internal static Enum393 smethod_15(LineDashStyle dashStyle)
	{
		return (Enum393)class1155_9[dashStyle];
	}

	internal static LineJoinStyle smethod_16(Enum392 joinStyle)
	{
		return (LineJoinStyle)class1155_11[joinStyle];
	}

	internal static Enum392 smethod_17(LineJoinStyle joinStyle)
	{
		return (Enum392)class1155_12[joinStyle];
	}

	internal static PatternStyle smethod_18(Enum21 patternStyle)
	{
		return (PatternStyle)class1155_13[patternStyle];
	}

	internal static Enum21 smethod_19(PatternStyle patternStyle)
	{
		return (Enum21)class1155_13[patternStyle];
	}

	internal static TabAlignment smethod_20(Enum456 align)
	{
		return (TabAlignment)align;
	}

	internal static TextAnchorType smethod_21(Enum391 pptAnchor)
	{
		return (TextAnchorType)class1155_14[pptAnchor];
	}

	internal static NullableBool smethod_22(Enum391 pptAnchor)
	{
		return (NullableBool)class1155_15[pptAnchor];
	}

	internal static Enum391 smethod_23(TextAnchorType domAnchorType, NullableBool domAnchorCentered)
	{
		object obj = null;
		obj = ((domAnchorCentered == NullableBool.True) ? class1155_17[domAnchorType] : class1155_16[domAnchorType]);
		if (obj == null)
		{
			throw new PptException(string.Concat("Wrong TextAnchorType, AnchorCenter values: ", domAnchorType, ", ", domAnchorCentered));
		}
		return (Enum391)obj;
	}

	internal static void smethod_24(Class341[] adjustments, ShapeType shapeType, int[] srcValues, float width, float height)
	{
		Delegate6 @delegate = null;
		if (dictionary_0.ContainsKey(shapeType))
		{
			@delegate = dictionary_0[shapeType];
		}
		if (@delegate != null)
		{
			@delegate(width, height, adjustments, srcValues);
		}
		else
		{
			smethod_32(width, height, adjustments, srcValues);
		}
		Class342 @class = Class542.smethod_0(shapeType);
		if (@class != null && @class.Adjustments != null)
		{
			for (int i = 0; i < @class.Adjustments.Length; i++)
			{
				adjustments[i].Name = @class.Adjustments[i].Name;
			}
		}
	}

	internal static int[] smethod_25(Class341[] adjustments, ShapeType shapeType, float width, float height)
	{
		Delegate7 @delegate = null;
		if (dictionary_1.ContainsKey(shapeType))
		{
			@delegate = dictionary_1[shapeType];
		}
		if (@delegate != null)
		{
			return @delegate(width, height, adjustments);
		}
		return smethod_33(width, height, adjustments);
	}

	internal static TextVerticalType smethod_26(uint value)
	{
		if (value != 0 && (value & 2) == 0)
		{
			return TextVerticalType.Vertical;
		}
		return TextVerticalType.Horizontal;
	}

	internal static uint smethod_27(TextVerticalType domTextVerticalType)
	{
		if (domTextVerticalType >= TextVerticalType.Vertical)
		{
			return 1u;
		}
		return 2u;
	}

	internal static string smethod_28(int index)
	{
		return index switch
		{
			0 => FieldType.DateTime1.InternalString, 
			1 => FieldType.DateTime2.InternalString, 
			2 => FieldType.DateTime3.InternalString, 
			3 => FieldType.DateTime4.InternalString, 
			5 => FieldType.DateTime5.InternalString, 
			9 => FieldType.DateTime6.InternalString, 
			10 => FieldType.DateTime7.InternalString, 
			11 => FieldType.DateTime8.InternalString, 
			12 => FieldType.DateTime9.InternalString, 
			13 => FieldType.DateTime12.InternalString, 
			14 => FieldType.DateTime13.InternalString, 
			15 => FieldType.DateTime10.InternalString, 
			16 => FieldType.DateTime11.InternalString, 
			_ => FieldType.DateTime.InternalString, 
		};
	}

	internal static byte smethod_29(string domFormat)
	{
		if (FieldType.DateTime1.InternalString.Equals(domFormat))
		{
			return 0;
		}
		if (FieldType.DateTime2.InternalString.Equals(domFormat))
		{
			return 1;
		}
		if (FieldType.DateTime3.InternalString.Equals(domFormat))
		{
			return 2;
		}
		if (FieldType.DateTime4.InternalString.Equals(domFormat))
		{
			return 3;
		}
		if (FieldType.DateTime5.InternalString.Equals(domFormat))
		{
			return 5;
		}
		if (FieldType.DateTime6.InternalString.Equals(domFormat))
		{
			return 9;
		}
		if (FieldType.DateTime7.InternalString.Equals(domFormat))
		{
			return 10;
		}
		if (FieldType.DateTime8.InternalString.Equals(domFormat))
		{
			return 11;
		}
		if (FieldType.DateTime9.InternalString.Equals(domFormat))
		{
			return 12;
		}
		if (FieldType.DateTime10.InternalString.Equals(domFormat))
		{
			return 15;
		}
		if (FieldType.DateTime11.InternalString.Equals(domFormat))
		{
			return 16;
		}
		if (FieldType.DateTime12.InternalString.Equals(domFormat))
		{
			return 13;
		}
		if (FieldType.DateTime13.InternalString.Equals(domFormat))
		{
			return 14;
		}
		return 0;
	}

	internal static Enum454 smethod_30(ViewType domViewType)
	{
		return domViewType switch
		{
			ViewType.NotDefined => Enum454.const_0, 
			ViewType.SlideView => Enum454.const_0, 
			ViewType.SlideMasterView => Enum454.const_1, 
			ViewType.NotesView => Enum454.const_2, 
			ViewType.HandoutView => Enum454.const_3, 
			ViewType.NotesMasterView => Enum454.const_4, 
			ViewType.OutlineView => Enum454.const_6, 
			ViewType.SlideSorterView => Enum454.const_7, 
			ViewType.SlideThumbnailView => Enum454.const_14, 
			_ => throw new PptEditException("Unknown view type: " + domViewType), 
		};
	}

	internal static ViewType smethod_31(Enum454 pViewType)
	{
		return pViewType switch
		{
			Enum454.const_0 => ViewType.SlideView, 
			Enum454.const_1 => ViewType.SlideMasterView, 
			Enum454.const_2 => ViewType.NotesView, 
			Enum454.const_3 => ViewType.HandoutView, 
			Enum454.const_4 => ViewType.NotesMasterView, 
			Enum454.const_6 => ViewType.OutlineView, 
			Enum454.const_7 => ViewType.SlideSorterView, 
			Enum454.const_14 => ViewType.SlideThumbnailView, 
			_ => ViewType.SlideView, 
		};
	}

	static Class232()
	{
		class1155_0 = new Class1155(Enum384.const_0, (PlaceholderType)(-1), Enum384.const_1, PlaceholderType.Title, Enum384.const_2, PlaceholderType.Body, Enum384.const_3, PlaceholderType.CenteredTitle, Enum384.const_4, PlaceholderType.Subtitle, Enum384.const_5, PlaceholderType.SlideImage, Enum384.const_6, PlaceholderType.Body, Enum384.const_7, PlaceholderType.DateAndTime, Enum384.const_8, PlaceholderType.SlideNumber, Enum384.const_9, PlaceholderType.Footer, Enum384.const_10, PlaceholderType.Header, Enum384.const_11, PlaceholderType.SlideImage, Enum384.const_12, PlaceholderType.Body, Enum384.const_13, PlaceholderType.Title, Enum384.const_14, PlaceholderType.Body, Enum384.const_15, PlaceholderType.CenteredTitle, Enum384.const_16, PlaceholderType.Subtitle, Enum384.const_17, PlaceholderType.Title, Enum384.const_18, PlaceholderType.Body, Enum384.const_19, PlaceholderType.Object, Enum384.const_20, PlaceholderType.Chart, Enum384.const_21, PlaceholderType.Table, Enum384.const_22, PlaceholderType.Diagram, Enum384.const_23, PlaceholderType.Diagram, Enum384.const_24, PlaceholderType.Media, Enum384.const_25, PlaceholderType.Object);
		class1155_1 = new Class1155(PlaceholderType.Title, Enum384.const_1, PlaceholderType.Body, Enum384.const_2, PlaceholderType.CenteredTitle, Enum384.const_3, PlaceholderType.Subtitle, Enum384.const_4, PlaceholderType.SlideImage, Enum384.const_5, PlaceholderType.Body, Enum384.const_6, PlaceholderType.DateAndTime, Enum384.const_7, PlaceholderType.SlideNumber, Enum384.const_8, PlaceholderType.Footer, Enum384.const_9, PlaceholderType.Header, Enum384.const_10);
		class1155_2 = new Class1155(PlaceholderType.SlideImage, Enum384.const_11, PlaceholderType.Body, Enum384.const_12);
		class1155_3 = new Class1155(PlaceholderType.Title, Enum384.const_13, PlaceholderType.Body, Enum384.const_14, PlaceholderType.CenteredTitle, Enum384.const_15, PlaceholderType.Subtitle, Enum384.const_16, PlaceholderType.Object, Enum384.const_19, PlaceholderType.Chart, Enum384.const_20, PlaceholderType.Table, Enum384.const_21, PlaceholderType.Diagram, Enum384.const_22, PlaceholderType.Media, Enum384.const_24);
		class1155_4 = new Class1155(PlaceholderType.Title, Enum384.const_17, PlaceholderType.Body, Enum384.const_18, PlaceholderType.Object, Enum384.const_25);
		shapeType_0 = new ShapeType[203];
		object_0 = new object[298]
		{
			0,
			ShapeType.Custom,
			1,
			ShapeType.Rectangle,
			2,
			ShapeType.RoundCornerRectangle,
			3,
			ShapeType.Ellipse,
			4,
			ShapeType.Diamond,
			5,
			ShapeType.Triangle,
			6,
			ShapeType.RightTriangle,
			7,
			ShapeType.Parallelogram,
			8,
			ShapeType.Custom,
			9,
			ShapeType.Hexagon,
			10,
			ShapeType.Octagon,
			11,
			ShapeType.Plus,
			12,
			ShapeType.FivePointedStar,
			13,
			ShapeType.RightArrow,
			15,
			ShapeType.HomePlate,
			16,
			ShapeType.Cube,
			19,
			ShapeType.CurvedArc,
			20,
			ShapeType.Line,
			21,
			ShapeType.Plaque,
			22,
			ShapeType.Can,
			23,
			ShapeType.Donut,
			32,
			ShapeType.Line,
			33,
			ShapeType.BentConnector2,
			34,
			ShapeType.BentConnector3,
			35,
			ShapeType.BentConnector4,
			36,
			ShapeType.BentConnector5,
			37,
			ShapeType.CurvedConnector2,
			38,
			ShapeType.CurvedConnector3,
			39,
			ShapeType.CurvedConnector4,
			40,
			ShapeType.CurvedConnector5,
			41,
			ShapeType.Callout1,
			42,
			ShapeType.Callout2,
			43,
			ShapeType.Callout3,
			44,
			ShapeType.Callout1WithAccent,
			45,
			ShapeType.Callout2WithAccent,
			46,
			ShapeType.Callout3WithAccent,
			47,
			ShapeType.Callout1WithBorder,
			48,
			ShapeType.Callout2WithBorder,
			49,
			ShapeType.Callout3WithBorder,
			50,
			ShapeType.Callout1WithBorderAndAccent,
			51,
			ShapeType.Callout2WithBorderAndAccent,
			52,
			ShapeType.Callout3WithBorderAndAccent,
			53,
			ShapeType.Ribbon,
			54,
			ShapeType.Ribbon2,
			55,
			ShapeType.Chevron,
			56,
			ShapeType.Pentagon,
			57,
			ShapeType.NoSmoking,
			58,
			ShapeType.EightPointedStar,
			59,
			ShapeType.SixteenPointedStar,
			60,
			ShapeType.ThirtyTwoPointedStar,
			61,
			ShapeType.CalloutWedgeRectangle,
			62,
			ShapeType.CalloutWedgeRoundRectangle,
			63,
			ShapeType.CalloutWedgeEllipse,
			64,
			ShapeType.Wave,
			65,
			ShapeType.FoldedCorner,
			66,
			ShapeType.LeftArrow,
			67,
			ShapeType.DownArrow,
			68,
			ShapeType.UpArrow,
			69,
			ShapeType.LeftRightArrow,
			70,
			ShapeType.UpDownArrow,
			71,
			ShapeType.IrregularSeal1,
			72,
			ShapeType.IrregularSeal2,
			73,
			ShapeType.LightningBolt,
			74,
			ShapeType.Custom,
			76,
			ShapeType.Custom,
			77,
			ShapeType.CalloutLeftArrow,
			78,
			ShapeType.CalloutRightArrow,
			79,
			ShapeType.CalloutUpArrow,
			80,
			ShapeType.CalloutDownArrow,
			81,
			ShapeType.CalloutLeftRightArrow,
			82,
			ShapeType.CalloutUpDownArrow,
			83,
			ShapeType.Custom,
			84,
			ShapeType.Bevel,
			85,
			ShapeType.LeftBracket,
			86,
			ShapeType.RightBracket,
			87,
			ShapeType.LeftBrace,
			88,
			ShapeType.RightBrace,
			89,
			ShapeType.Custom,
			90,
			ShapeType.Custom,
			91,
			ShapeType.Custom,
			92,
			ShapeType.TwentyFourPointedStar,
			93,
			ShapeType.Custom,
			94,
			ShapeType.NotchedRightArrow,
			95,
			ShapeType.BlockArc,
			96,
			ShapeType.SmileyFace,
			97,
			ShapeType.VerticalScroll,
			98,
			ShapeType.HorizontalScroll,
			99,
			ShapeType.Custom,
			100,
			ShapeType.Custom,
			101,
			ShapeType.Custom,
			102,
			ShapeType.CurvedRightArrow,
			103,
			ShapeType.CurvedLeftArrow,
			104,
			ShapeType.CurvedUpArrow,
			105,
			ShapeType.CurvedDownArrow,
			106,
			ShapeType.CalloutCloud,
			107,
			ShapeType.EllipseRibbon,
			108,
			ShapeType.EllipseRibbon2,
			109,
			ShapeType.ProcessFlow,
			110,
			ShapeType.DecisionFlow,
			111,
			ShapeType.InputOutputFlow,
			112,
			ShapeType.PredefinedProcessFlow,
			113,
			ShapeType.InternalStorageFlow,
			114,
			ShapeType.DocumentFlow,
			115,
			ShapeType.MultiDocumentFlow,
			116,
			ShapeType.TerminatorFlow,
			117,
			ShapeType.PreparationFlow,
			118,
			ShapeType.ManualInputFlow,
			119,
			ShapeType.ManualOperationFlow,
			120,
			ShapeType.ConnectorFlow,
			121,
			ShapeType.PunchedCardFlow,
			122,
			ShapeType.PunchedTapeFlow,
			123,
			ShapeType.SummingJunctionFlow,
			124,
			ShapeType.OrFlow,
			125,
			ShapeType.CollateFlow,
			126,
			ShapeType.SortFlow,
			127,
			ShapeType.ExtractFlow,
			128,
			ShapeType.MergeFlow,
			130,
			ShapeType.OnlineStorageFlow,
			131,
			ShapeType.MagneticTapeFlow,
			132,
			ShapeType.MagneticDiskFlow,
			133,
			ShapeType.MagneticDrumFlow,
			134,
			ShapeType.DisplayFlow,
			135,
			ShapeType.DelayFlow,
			176,
			ShapeType.AlternateProcessFlow,
			177,
			ShapeType.OffPageConnectorFlow,
			178,
			ShapeType.Callout1,
			179,
			ShapeType.Callout1,
			180,
			ShapeType.Callout1WithBorder,
			181,
			ShapeType.Callout1WithBorder,
			182,
			ShapeType.Custom,
			183,
			ShapeType.Sun,
			184,
			ShapeType.Moon,
			185,
			ShapeType.BracketPair,
			186,
			ShapeType.BracePair,
			187,
			ShapeType.FourPointedStar,
			188,
			ShapeType.DoubleWave,
			189,
			ShapeType.Custom,
			190,
			ShapeType.HomeButton,
			191,
			ShapeType.HelpButton,
			192,
			ShapeType.InformationButton,
			193,
			ShapeType.ForwardOrNextButton,
			194,
			ShapeType.BackOrPreviousButton,
			195,
			ShapeType.EndButton,
			196,
			ShapeType.BeginningButton,
			197,
			ShapeType.ReturnButton,
			198,
			ShapeType.DocumentButton,
			199,
			ShapeType.SoundButton,
			200,
			ShapeType.MovieButton,
			202,
			ShapeType.Rectangle
		};
		class1155_5 = new Class1155(SlideSizeType.OnScreen, Enum453.const_0, SlideSizeType.LetterPaper, Enum453.const_1, SlideSizeType.A4Paper, Enum453.const_2, SlideSizeType.Slide35mm, Enum453.const_3, SlideSizeType.Overhead, Enum453.const_4, SlideSizeType.Banner, Enum453.const_5, SlideSizeType.Custom, Enum453.const_6, SlideSizeType.Ledger, Enum453.const_6, SlideSizeType.A3Paper, Enum453.const_6, SlideSizeType.B4IsoPaper, Enum453.const_6, SlideSizeType.B5IsoPaper, Enum453.const_6, SlideSizeType.B4JisPaper, Enum453.const_6, SlideSizeType.B5JisPaper, Enum453.const_6, SlideSizeType.HagakiCard, Enum453.const_6, SlideSizeType.OnScreen16x9, Enum453.const_6, SlideSizeType.OnScreen16x10, Enum453.const_6);
		class1155_6 = new Class1155(Enum453.const_0, SlideSizeType.OnScreen, Enum453.const_1, SlideSizeType.LetterPaper, Enum453.const_2, SlideSizeType.A4Paper, Enum453.const_3, SlideSizeType.Slide35mm, Enum453.const_4, SlideSizeType.Overhead, Enum453.const_5, SlideSizeType.Banner, Enum453.const_6, SlideSizeType.Custom);
		class1155_7 = new Class1155(Enum451.const_0, SlideLayoutType.Title, Enum451.const_3, SlideLayoutType.TitleOnly, Enum451.const_1, SlideLayoutType.TitleAndObject, Enum451.const_4, SlideLayoutType.TwoObjects, Enum451.const_11, SlideLayoutType.Blank, Enum451.const_10, SlideLayoutType.Object, Enum451.const_6, SlideLayoutType.ObjectAndTwoObject, Enum451.const_7, SlideLayoutType.TwoObjectsAndObject, Enum451.const_9, SlideLayoutType.FourObjects, Enum451.const_4, SlideLayoutType.ObjectAndText, Enum451.const_6, SlideLayoutType.TextAndTwoObjects, Enum451.const_7, SlideLayoutType.TwoObjectsAndText, Enum451.const_5, SlideLayoutType.TextOverObject, Enum451.const_5, SlideLayoutType.ObjectOverText, Enum451.const_8, SlideLayoutType.TwoObjectsOverText, Enum451.const_4, SlideLayoutType.TextAndClipArt, Enum451.const_4, SlideLayoutType.ClipArtAndText, Enum451.const_4, SlideLayoutType.TextAndChart, Enum451.const_4, SlideLayoutType.ChartAndText, Enum451.const_4, SlideLayoutType.TextAndMedia, Enum451.const_4, SlideLayoutType.MediaAndText, Enum451.const_1, SlideLayoutType.Table, Enum451.const_1, SlideLayoutType.Diagram, Enum451.const_1, SlideLayoutType.Chart);
		class1155_8 = new Class1155(SlideLayoutType.Title, Enum451.const_0, SlideLayoutType.TitleOnly, Enum451.const_3, SlideLayoutType.TitleAndObject, Enum451.const_1, SlideLayoutType.TwoObjects, Enum451.const_4, SlideLayoutType.Blank, Enum451.const_11, SlideLayoutType.Object, Enum451.const_10, SlideLayoutType.ObjectAndTwoObject, Enum451.const_6, SlideLayoutType.TwoObjectsAndObject, Enum451.const_7, SlideLayoutType.FourObjects, Enum451.const_9, SlideLayoutType.ObjectAndText, Enum451.const_4, SlideLayoutType.TextAndTwoObjects, Enum451.const_6, SlideLayoutType.TwoObjectsAndText, Enum451.const_7, SlideLayoutType.TextOverObject, Enum451.const_5, SlideLayoutType.ObjectOverText, Enum451.const_5, SlideLayoutType.TwoObjectsOverText, Enum451.const_8, SlideLayoutType.TextAndClipArt, Enum451.const_4, SlideLayoutType.ClipArtAndText, Enum451.const_4, SlideLayoutType.TextAndChart, Enum451.const_4, SlideLayoutType.ChartAndText, Enum451.const_4, SlideLayoutType.TextAndMedia, Enum451.const_4, SlideLayoutType.MediaAndText, Enum451.const_4, SlideLayoutType.Table, Enum451.const_1, SlideLayoutType.Diagram, Enum451.const_1, SlideLayoutType.Chart, Enum451.const_1);
		schemeColor_0 = new SchemeColor[8]
		{
			SchemeColor.Background1,
			SchemeColor.Text1,
			SchemeColor.Background2,
			SchemeColor.Text2,
			SchemeColor.Accent1,
			SchemeColor.Accent2,
			SchemeColor.Hyperlink,
			SchemeColor.FollowedHyperlink
		};
		class1155_9 = new Class1155(LineDashStyle.Dash, Enum393.const_6, LineDashStyle.DashDot, Enum393.const_8, LineDashStyle.Dot, Enum393.const_5, LineDashStyle.LargeDash, Enum393.const_7, LineDashStyle.LargeDashDot, Enum393.const_9, LineDashStyle.LargeDashDotDot, Enum393.const_10, LineDashStyle.Solid, Enum393.const_0, LineDashStyle.SystemDot, Enum393.const_2, LineDashStyle.SystemDash, Enum393.const_1, LineDashStyle.SystemDashDot, Enum393.const_3, LineDashStyle.SystemDashDotDot, Enum393.const_4);
		class1155_10 = new Class1155(Enum393.const_6, LineDashStyle.Dash, Enum393.const_8, LineDashStyle.DashDot, Enum393.const_5, LineDashStyle.Dot, Enum393.const_7, LineDashStyle.LargeDash, Enum393.const_9, LineDashStyle.LargeDashDot, Enum393.const_10, LineDashStyle.LargeDashDotDot, Enum393.const_0, LineDashStyle.Solid, Enum393.const_2, LineDashStyle.SystemDot, Enum393.const_1, LineDashStyle.SystemDash, Enum393.const_3, LineDashStyle.SystemDashDot, Enum393.const_4, LineDashStyle.SystemDashDotDot);
		class1155_11 = new Class1155(LineJoinStyle.Bevel, Enum392.const_0, LineJoinStyle.Miter, Enum392.const_1, LineJoinStyle.Round, Enum392.const_2);
		class1155_12 = new Class1155(Enum392.const_0, LineJoinStyle.Bevel, Enum392.const_1, LineJoinStyle.Miter, Enum392.const_2, LineJoinStyle.Round);
		class1155_13 = new Class1155(PatternStyle.Unknown, Enum21.const_0, PatternStyle.Percent05, Enum21.const_1, PatternStyle.Percent10, Enum21.const_2, PatternStyle.Percent20, Enum21.const_3, PatternStyle.Percent25, Enum21.const_4, PatternStyle.Percent30, Enum21.const_5, PatternStyle.Percent40, Enum21.const_6, PatternStyle.Percent50, Enum21.const_7, PatternStyle.Percent60, Enum21.const_8, PatternStyle.Percent70, Enum21.const_9, PatternStyle.Percent75, Enum21.const_10, PatternStyle.Percent80, Enum21.const_11, PatternStyle.Percent90, Enum21.const_12, PatternStyle.DarkHorizontal, Enum21.const_13, PatternStyle.DarkVertical, Enum21.const_14, PatternStyle.DarkDownwardDiagonal, Enum21.const_15, PatternStyle.DarkUpwardDiagonal, Enum21.const_16, PatternStyle.SmallCheckerBoard, Enum21.const_17, PatternStyle.Trellis, Enum21.const_18, PatternStyle.LightHorizontal, Enum21.const_19, PatternStyle.LightVertical, Enum21.const_20, PatternStyle.LightDownwardDiagonal, Enum21.const_21, PatternStyle.LightUpwardDiagonal, Enum21.const_22, PatternStyle.SmallGrid, Enum21.const_23, PatternStyle.DottedDiamond, Enum21.const_24, PatternStyle.WideDownwardDiagonal, Enum21.const_25, PatternStyle.WideUpwardDiagonal, Enum21.const_26, PatternStyle.DashedDownwardDiagonal, Enum21.const_27, PatternStyle.DashedUpwardDiagonal, Enum21.const_28, PatternStyle.NarrowVertical, Enum21.const_29, PatternStyle.NarrowHorizontal, Enum21.const_30, PatternStyle.DashedVertical, Enum21.const_31, PatternStyle.DashedHorizontal, Enum21.const_32, PatternStyle.LargeConfetti, Enum21.const_33, PatternStyle.LargeGrid, Enum21.const_34, PatternStyle.HorizontalBrick, Enum21.const_35, PatternStyle.LargeCheckerBoard, Enum21.const_36, PatternStyle.SmallConfetti, Enum21.const_37, PatternStyle.Zigzag, Enum21.const_38, PatternStyle.SolidDiamond, Enum21.const_39, PatternStyle.DiagonalBrick, Enum21.const_40, PatternStyle.OutlinedDiamond, Enum21.const_41, PatternStyle.Plaid, Enum21.const_42, PatternStyle.Sphere, Enum21.const_43, PatternStyle.Weave, Enum21.const_44, PatternStyle.DottedGrid, Enum21.const_45, PatternStyle.Divot, Enum21.const_46, PatternStyle.Shingle, Enum21.const_47, PatternStyle.Wave, Enum21.const_48, PatternStyle.Horizontal, Enum21.const_13, PatternStyle.Vertical, Enum21.const_14, PatternStyle.Cross, Enum21.const_0, PatternStyle.DownwardDiagonal, Enum21.const_15, PatternStyle.UpwardDiagonal, Enum21.const_16, PatternStyle.DiagonalCross, Enum21.const_0);
		class1155_14 = new Class1155(Enum391.const_0, TextAnchorType.Top, Enum391.const_1, TextAnchorType.Center, Enum391.const_2, TextAnchorType.Bottom, Enum391.const_3, TextAnchorType.Top, Enum391.const_8, TextAnchorType.Top, Enum391.const_6, TextAnchorType.Top, Enum391.const_4, TextAnchorType.Center, Enum391.const_5, TextAnchorType.Bottom, Enum391.const_7, TextAnchorType.Bottom, Enum391.const_9, TextAnchorType.Bottom);
		class1155_15 = new Class1155(Enum391.const_0, NullableBool.False, Enum391.const_3, NullableBool.True, Enum391.const_1, NullableBool.False, Enum391.const_2, NullableBool.False, Enum391.const_8, NullableBool.True, Enum391.const_6, NullableBool.False, Enum391.const_4, NullableBool.True, Enum391.const_5, NullableBool.True, Enum391.const_7, NullableBool.False, Enum391.const_9, NullableBool.True);
		class1155_16 = new Class1155(TextAnchorType.Top, Enum391.const_0, TextAnchorType.Center, Enum391.const_1, TextAnchorType.Bottom, Enum391.const_2);
		class1155_17 = new Class1155(TextAnchorType.NotDefined, Enum391.const_3, TextAnchorType.Top, Enum391.const_3, TextAnchorType.Center, Enum391.const_4, TextAnchorType.Bottom, Enum391.const_5);
		for (int i = 0; i < shapeType_0.Length; i++)
		{
			shapeType_0[i] = ShapeType.NotDefined;
		}
		for (int j = 0; j < object_0.Length; j += 2)
		{
			int num = (int)object_0[j];
			ShapeType shapeType = (ShapeType)object_0[j + 1];
			shapeType_0[num] = shapeType;
		}
		dictionary_0 = new Dictionary<ShapeType, Delegate6>();
		dictionary_1 = new Dictionary<ShapeType, Delegate7>();
		dictionary_0.Add(ShapeType.CurvedArc, smethod_42);
		dictionary_1.Add(ShapeType.CurvedArc, smethod_43);
		dictionary_0.Add(ShapeType.FoldedCorner, smethod_34);
		dictionary_1.Add(ShapeType.FoldedCorner, smethod_35);
		dictionary_0.Add(ShapeType.Can, smethod_36);
		dictionary_1.Add(ShapeType.Can, smethod_37);
		dictionary_0.Add(ShapeType.Parallelogram, smethod_38);
		dictionary_1.Add(ShapeType.Parallelogram, smethod_39);
		dictionary_0.Add(ShapeType.LeftBracket, smethod_36);
		dictionary_1.Add(ShapeType.LeftBracket, smethod_37);
		dictionary_0.Add(ShapeType.RightBracket, smethod_36);
		dictionary_1.Add(ShapeType.RightBracket, smethod_37);
		dictionary_0.Add(ShapeType.SmileyFace, smethod_44);
		dictionary_1.Add(ShapeType.SmileyFace, smethod_45);
		dictionary_0.Add(ShapeType.BlockArc, smethod_46);
		dictionary_1.Add(ShapeType.BlockArc, smethod_47);
		dictionary_0.Add(ShapeType.CircularArrow, smethod_48);
		dictionary_1.Add(ShapeType.CircularArrow, smethod_49);
		dictionary_0.Add(ShapeType.LeftBrace, smethod_50);
		dictionary_1.Add(ShapeType.LeftBrace, smethod_51);
		dictionary_0.Add(ShapeType.RightBrace, smethod_50);
		dictionary_1.Add(ShapeType.RightBrace, smethod_51);
		dictionary_0.Add(ShapeType.RightArrow, smethod_52);
		dictionary_1.Add(ShapeType.RightArrow, smethod_53);
		dictionary_0.Add(ShapeType.NotchedRightArrow, smethod_52);
		dictionary_1.Add(ShapeType.NotchedRightArrow, smethod_53);
		dictionary_0.Add(ShapeType.LeftArrow, smethod_54);
		dictionary_1.Add(ShapeType.LeftArrow, smethod_55);
		dictionary_0.Add(ShapeType.DownArrow, smethod_56);
		dictionary_1.Add(ShapeType.DownArrow, smethod_57);
		dictionary_0.Add(ShapeType.UpArrow, smethod_58);
		dictionary_1.Add(ShapeType.UpArrow, smethod_59);
		dictionary_0.Add(ShapeType.Hexagon, smethod_60);
		dictionary_1.Add(ShapeType.Hexagon, smethod_61);
		dictionary_0.Add(ShapeType.Pentagon, smethod_62);
		dictionary_1.Add(ShapeType.Pentagon, smethod_63);
		dictionary_0.Add(ShapeType.LeftRightArrow, smethod_54);
		dictionary_1.Add(ShapeType.LeftRightArrow, smethod_55);
		dictionary_0.Add(ShapeType.UpDownArrow, smethod_64);
		dictionary_1.Add(ShapeType.UpDownArrow, smethod_65);
		dictionary_0.Add(ShapeType.HomePlate, smethod_40);
		dictionary_1.Add(ShapeType.HomePlate, smethod_41);
		dictionary_0.Add(ShapeType.Chevron, smethod_40);
		dictionary_1.Add(ShapeType.Chevron, smethod_41);
		dictionary_0.Add(ShapeType.CurvedLeftArrow, smethod_66);
		dictionary_1.Add(ShapeType.CurvedLeftArrow, smethod_67);
		dictionary_0.Add(ShapeType.CurvedRightArrow, smethod_68);
		dictionary_1.Add(ShapeType.CurvedRightArrow, smethod_69);
		dictionary_0.Add(ShapeType.CurvedUpArrow, smethod_70);
		dictionary_1.Add(ShapeType.CurvedUpArrow, smethod_71);
		dictionary_0.Add(ShapeType.CurvedDownArrow, smethod_72);
		dictionary_1.Add(ShapeType.CurvedDownArrow, smethod_73);
		dictionary_0.Add(ShapeType.Wave, smethod_74);
		dictionary_1.Add(ShapeType.Wave, smethod_75);
		dictionary_0.Add(ShapeType.DoubleWave, smethod_74);
		dictionary_1.Add(ShapeType.DoubleWave, smethod_75);
		dictionary_0.Add(ShapeType.CalloutRightArrow, smethod_76);
		dictionary_1.Add(ShapeType.CalloutRightArrow, smethod_77);
		dictionary_0.Add(ShapeType.CalloutLeftArrow, smethod_78);
		dictionary_1.Add(ShapeType.CalloutLeftArrow, smethod_79);
		dictionary_0.Add(ShapeType.CalloutDownArrow, smethod_80);
		dictionary_1.Add(ShapeType.CalloutDownArrow, smethod_81);
		dictionary_0.Add(ShapeType.CalloutUpArrow, smethod_82);
		dictionary_1.Add(ShapeType.CalloutUpArrow, smethod_83);
		dictionary_0.Add(ShapeType.CalloutLeftRightArrow, smethod_106);
		dictionary_1.Add(ShapeType.CalloutLeftRightArrow, smethod_107);
		dictionary_0.Add(ShapeType.CalloutUpDownArrow, smethod_108);
		dictionary_1.Add(ShapeType.CalloutUpDownArrow, smethod_109);
		dictionary_0.Add(ShapeType.FourPointedStar, smethod_84);
		dictionary_1.Add(ShapeType.FourPointedStar, smethod_85);
		dictionary_0.Add(ShapeType.FivePointedStar, smethod_86);
		dictionary_1.Add(ShapeType.FivePointedStar, smethod_87);
		dictionary_0.Add(ShapeType.SixPointedStar, smethod_84);
		dictionary_1.Add(ShapeType.SixPointedStar, smethod_85);
		dictionary_0.Add(ShapeType.EightPointedStar, smethod_84);
		dictionary_1.Add(ShapeType.EightPointedStar, smethod_85);
		dictionary_0.Add(ShapeType.TwelvePointedStar, smethod_84);
		dictionary_1.Add(ShapeType.TwelvePointedStar, smethod_85);
		dictionary_0.Add(ShapeType.SixteenPointedStar, smethod_84);
		dictionary_1.Add(ShapeType.SixteenPointedStar, smethod_85);
		dictionary_0.Add(ShapeType.TwentyFourPointedStar, smethod_84);
		dictionary_1.Add(ShapeType.TwentyFourPointedStar, smethod_85);
		dictionary_0.Add(ShapeType.ThirtyTwoPointedStar, smethod_84);
		dictionary_1.Add(ShapeType.ThirtyTwoPointedStar, smethod_85);
		dictionary_0.Add(ShapeType.EllipseRibbon, smethod_88);
		dictionary_1.Add(ShapeType.EllipseRibbon, smethod_89);
		dictionary_0.Add(ShapeType.EllipseRibbon2, smethod_90);
		dictionary_1.Add(ShapeType.EllipseRibbon2, smethod_91);
		dictionary_0.Add(ShapeType.Ribbon, smethod_92);
		dictionary_1.Add(ShapeType.Ribbon, smethod_93);
		dictionary_0.Add(ShapeType.Ribbon2, smethod_94);
		dictionary_1.Add(ShapeType.Ribbon2, smethod_95);
		dictionary_0.Add(ShapeType.CalloutWedgeEllipse, smethod_96);
		dictionary_1.Add(ShapeType.CalloutWedgeEllipse, smethod_97);
		dictionary_0.Add(ShapeType.CalloutWedgeRoundRectangle, smethod_98);
		dictionary_1.Add(ShapeType.CalloutWedgeRoundRectangle, smethod_99);
		dictionary_0.Add(ShapeType.CalloutWedgeRectangle, smethod_96);
		dictionary_1.Add(ShapeType.CalloutWedgeRectangle, smethod_97);
		dictionary_0.Add(ShapeType.CalloutCloud, smethod_96);
		dictionary_1.Add(ShapeType.CalloutCloud, smethod_97);
		dictionary_0.Add(ShapeType.Callout1, smethod_100);
		dictionary_1.Add(ShapeType.Callout1, smethod_101);
		dictionary_0.Add(ShapeType.Callout1WithBorder, smethod_100);
		dictionary_1.Add(ShapeType.Callout1WithBorder, smethod_101);
		dictionary_0.Add(ShapeType.Callout1WithAccent, smethod_100);
		dictionary_1.Add(ShapeType.Callout1WithAccent, smethod_101);
		dictionary_0.Add(ShapeType.Callout1WithBorderAndAccent, smethod_100);
		dictionary_1.Add(ShapeType.Callout1WithBorderAndAccent, smethod_101);
		dictionary_0.Add(ShapeType.Callout2, smethod_102);
		dictionary_1.Add(ShapeType.Callout2, smethod_103);
		dictionary_0.Add(ShapeType.Callout2WithBorder, smethod_102);
		dictionary_1.Add(ShapeType.Callout2WithBorder, smethod_103);
		dictionary_0.Add(ShapeType.Callout2WithAccent, smethod_102);
		dictionary_1.Add(ShapeType.Callout2WithAccent, smethod_103);
		dictionary_0.Add(ShapeType.Callout2WithBorderAndAccent, smethod_102);
		dictionary_1.Add(ShapeType.Callout2WithBorderAndAccent, smethod_103);
		dictionary_0.Add(ShapeType.Callout3, smethod_104);
		dictionary_1.Add(ShapeType.Callout3, smethod_105);
		dictionary_0.Add(ShapeType.Callout3WithBorder, smethod_104);
		dictionary_1.Add(ShapeType.Callout3WithBorder, smethod_105);
		dictionary_0.Add(ShapeType.Callout3WithAccent, smethod_104);
		dictionary_1.Add(ShapeType.Callout3WithAccent, smethod_105);
		dictionary_0.Add(ShapeType.Callout3WithBorderAndAccent, smethod_104);
		dictionary_1.Add(ShapeType.Callout3WithBorderAndAccent, smethod_105);
	}

	private static void smethod_32(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		int num = Math.Min(adjustments.Length, srcValues.Length);
		for (int i = 0; i < num; i++)
		{
			adjustments[i].RawValue = (long)Math.Round((double)srcValues[i] * 1000.0 / 216.0);
		}
	}

	private static int[] smethod_33(float width, float height, Class341[] domAdjustments)
	{
		int num = Math.Min(domAdjustments.Length, 8);
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = (int)Math.Round((float)(domAdjustments[i].RawValue * 216L) / 1000f);
		}
		return array;
	}

	private static void smethod_34(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		int num = Math.Min(adjustments.Length, srcValues.Length);
		for (int i = 0; i < num; i++)
		{
			adjustments[i].RawValue = (long)Math.Round((double)(21600 - srcValues[i]) * 1000.0 / 216.0);
		}
	}

	private static int[] smethod_35(float width, float height, Class341[] domAdjustments)
	{
		int num = Math.Min(domAdjustments.Length, 8);
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = (int)Math.Round(21600f - (float)domAdjustments[i].RawValue * 216f / 1000f);
		}
		return array;
	}

	private static void smethod_36(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		int num = Math.Min(adjustments.Length, srcValues.Length);
		for (int i = 0; i < num; i++)
		{
			adjustments[i].RawValue = (long)Math.Round((double)srcValues[i] * 1000.0 / 216.0 * (double)height / (double)Math.Min(height, width));
		}
	}

	private static int[] smethod_37(float width, float height, Class341[] domAdjustments)
	{
		int num = Math.Min(domAdjustments.Length, 8);
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = (int)Math.Round((float)domAdjustments[i].RawValue / 1000f * 216f / height * Math.Min(height, width));
		}
		return array;
	}

	private static void smethod_38(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		int num = Math.Min(adjustments.Length, srcValues.Length);
		for (int i = 0; i < num; i++)
		{
			adjustments[i].RawValue = (long)Math.Round((double)srcValues[i] * 1000.0 / 216.0 * (double)width / (double)Math.Min(height, width));
		}
	}

	private static int[] smethod_39(float width, float height, Class341[] domAdjustments)
	{
		int num = Math.Min(domAdjustments.Length, 8);
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = (int)Math.Round((float)domAdjustments[i].RawValue / 1000f * 216f / width * Math.Min(height, width));
		}
		return array;
	}

	private static void smethod_40(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		int num = Math.Min(adjustments.Length, srcValues.Length);
		for (int i = 0; i < num; i++)
		{
			adjustments[i].RawValue = (long)Math.Round((double)(21600 - srcValues[i]) * 1000.0 / 216.0 * (double)width / (double)Math.Min(height, width));
		}
	}

	private static int[] smethod_41(float width, float height, Class341[] domAdjustments)
	{
		int num = Math.Min(domAdjustments.Length, 8);
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = (int)Math.Round(21600f - (float)domAdjustments[i].RawValue / 1000f * 216f / width * Math.Min(height, width));
		}
		return array;
	}

	private static void smethod_42(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		int num = Math.Min(adjustments.Length, srcValues.Length);
		for (int i = 0; i < num; i++)
		{
			adjustments[i].AngleValue = (long)Math.Round((float)srcValues[i] / 65536f % 360f);
			if (adjustments[i].AngleValue < 0f)
			{
				adjustments[i].AngleValue += 360f;
			}
		}
	}

	private static int[] smethod_43(float width, float height, Class341[] domAdjustments)
	{
		int num = Math.Min(domAdjustments.Length, 8);
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = (int)(domAdjustments[i].AngleValue * 65536f);
		}
		return array;
	}

	private static void smethod_44(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		int num = Math.Min(adjustments.Length, srcValues.Length);
		for (int i = 0; i < num; i++)
		{
			adjustments[i].RawValue = (long)Math.Round((double)(srcValues[i] - 15510) * 500.0 / 216.0);
		}
	}

	private static int[] smethod_45(float width, float height, Class341[] domAdjustments)
	{
		int num = Math.Min(domAdjustments.Length, 8);
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = (int)Math.Round((float)domAdjustments[i].RawValue / 500f * 216f + 15510f);
		}
		return array;
	}

	private static void smethod_46(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		double num = (double)((float)srcValues[0] / 65536f / 180f) * Math.PI;
		adjustments[0].AngleValue = (long)Math.Round(Math.Atan2(Math.Sin(num) * (double)height, Math.Cos(num) * (double)width) / Math.PI * 180.0);
		if (adjustments[0].AngleValue < 0f)
		{
			adjustments[0].AngleValue += 360f;
		}
		adjustments[1].AngleValue = 180f - adjustments[0].AngleValue;
		if (adjustments[1].AngleValue < 0f)
		{
			adjustments[1].AngleValue += 360f;
		}
		adjustments[2].RawValue = (long)Math.Round((double)srcValues[1] * 1000.0 / 216.0);
	}

	private static int[] smethod_47(float width, float height, Class341[] domAdjustments)
	{
		return new int[2]
		{
			(int)(Math.Round(Math.Atan(Math.Tan((double)(domAdjustments[0].AngleValue / 180f) * 3.141592653589793) / (double)height * (double)width)) * 65536.0 * 180.0 / 3.141592653589793),
			(int)Math.Round((float)domAdjustments[2].RawValue / 1000f * 216f)
		};
	}

	private static void smethod_48(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		double num = (double)((float)srcValues[0] / 65536f / 180f) * Math.PI;
		adjustments[0].AngleValue = (long)Math.Round(Math.Atan2(Math.Sin(num) * (double)height, Math.Cos(num) * (double)width) / Math.PI * 180.0);
		if (adjustments[0].AngleValue < 0f)
		{
			adjustments[0].AngleValue += 360f;
		}
		num = (double)((float)srcValues[1] / 65536f / 180f) * Math.PI;
		adjustments[1].AngleValue = (long)Math.Round(Math.Atan2(Math.Sin(num) * (double)height, Math.Cos(num) * (double)width) / Math.PI * 180.0);
		if (adjustments[1].AngleValue < 0f)
		{
			adjustments[1].AngleValue += 360f;
		}
		adjustments[2].RawValue = (long)Math.Round((double)srcValues[1] * 1000.0 / 216.0);
	}

	private static int[] smethod_49(float width, float height, Class341[] domAdjustments)
	{
		return new int[2]
		{
			(int)(Math.Round(Math.Atan(Math.Tan((double)(domAdjustments[0].AngleValue / 180f) * 3.141592653589793) / (double)height * (double)width)) * 65536.0 * 180.0 / 3.141592653589793),
			(int)Math.Round((float)(domAdjustments[2].RawValue * 216L) / 1000f)
		};
	}

	private static void smethod_50(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)srcValues[0] * 1000.0 / 216.0 * (double)height / (double)Math.Min(height, width));
		adjustments[1].RawValue = (long)Math.Round((double)srcValues[1] * 1000.0 / 216.0);
	}

	private static int[] smethod_51(float width, float height, Class341[] domAdjustments)
	{
		return new int[2]
		{
			(int)Math.Round((float)domAdjustments[0].RawValue / 1000f * 216f / height * Math.Min(height, width)),
			(int)Math.Round((float)(domAdjustments[1].RawValue * 216L) / 1000f)
		};
	}

	private static void smethod_52(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)(10800 - srcValues[1]) * 2000.0 / 216.0);
		adjustments[1].RawValue = (long)Math.Round((double)(21600 - srcValues[0]) * 1000.0 / 216.0 * (double)width / (double)Math.Min(height, width));
	}

	private static int[] smethod_53(float width, float height, Class341[] domAdjustments)
	{
		return new int[2]
		{
			(int)Math.Round(21600f - (float)domAdjustments[1].RawValue / 1000f * 215f / width * Math.Min(height, width)),
			(int)Math.Round(10800f - (float)domAdjustments[0].RawValue / 2000f * 216f)
		};
	}

	private static void smethod_54(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)(10800 - srcValues[1]) * 2000.0 / 216.0);
		adjustments[1].RawValue = (long)Math.Round((double)srcValues[0] * 1000.0 / 216.0 * (double)width / (double)Math.Min(height, width));
	}

	private static int[] smethod_55(float width, float height, Class341[] domAdjustments)
	{
		return new int[2]
		{
			(int)Math.Round((float)domAdjustments[1].RawValue / 1000f * 216f / width * Math.Min(height, width)),
			(int)Math.Round(10800f - (float)domAdjustments[0].RawValue / 2000f * 216f)
		};
	}

	private static void smethod_56(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)(10800 - srcValues[1]) * 2000.0 / 216.0);
		adjustments[1].RawValue = (long)Math.Round((double)(21600 - srcValues[0]) * 1000.0 / 216.0 * (double)height / (double)Math.Min(height, width));
	}

	private static int[] smethod_57(float width, float height, Class341[] domAdjustments)
	{
		return new int[2]
		{
			(int)Math.Round(21600f - (float)domAdjustments[1].RawValue / 1000f * 216f / height * Math.Min(height, width)),
			(int)Math.Round(10800f - (float)domAdjustments[0].RawValue / 2000f * 216f)
		};
	}

	private static void smethod_58(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)(10800 - srcValues[1]) * 2000.0 / 216.0);
		adjustments[1].RawValue = (long)Math.Round((double)srcValues[0] * 1000.0 / 216.0 * (double)height / (double)Math.Min(height, width));
	}

	private static int[] smethod_59(float width, float height, Class341[] domAdjustments)
	{
		return new int[2]
		{
			(int)Math.Round((float)domAdjustments[1].RawValue / 1000f * 216f / height * Math.Min(height, width)),
			(int)Math.Round(10800f - (float)domAdjustments[0].RawValue / 2000f * 216f)
		};
	}

	private static void smethod_60(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)srcValues[0] * 1000.0 / 216.0 * (double)width / (double)Math.Min(height, width));
		adjustments[1].RawValue = 115470L;
	}

	private static int[] smethod_61(float width, float height, Class341[] domAdjustments)
	{
		return new int[1] { (int)Math.Round((float)domAdjustments[0].RawValue / 1000f * 216f / width * Math.Min(height, width)) };
	}

	private static void smethod_62(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = 105146L;
		adjustments[1].RawValue = 110557L;
	}

	private static int[] smethod_63(float width, float height, Class341[] domAdjustments)
	{
		return new int[0];
	}

	private static void smethod_64(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)(10800 - srcValues[0]) * 2000.0 / 216.0);
		adjustments[1].RawValue = (long)Math.Round((double)srcValues[1] * 1000.0 / 216.0 * (double)height / (double)Math.Min(height, width));
	}

	private static int[] smethod_65(float width, float height, Class341[] domAdjustments)
	{
		return new int[2]
		{
			(int)Math.Round(10800f - (float)domAdjustments[0].RawValue / 2000f * 216f),
			(int)Math.Round((float)domAdjustments[1].RawValue / 1000f * 216f / height * Math.Min(height, width))
		};
	}

	private static void smethod_66(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		double num = Math.Min(width, height);
		adjustments[0].RawValue = (long)Math.Round((double)(2 * srcValues[1] - srcValues[0] - 21600) * 1000.0 / 216.0 * (double)height / num);
		adjustments[1].RawValue = (long)Math.Round((double)(2 * (srcValues[1] - srcValues[0])) * 1000.0 / 216.0 * (double)height / num) - adjustments[0].RawValue;
		double num2 = 21600 - srcValues[2];
		double num3 = (Math.Sqrt(466560000.0 - num2 * num2) / 21600.0 + 1.0) * (double)(srcValues[0] + 21600 - srcValues[1]) / 2.0;
		double num4 = ((double)(srcValues[0] - srcValues[1]) + 21600.0) / 2.0;
		double num5 = (num4 - num3) / num4;
		adjustments[2].RawValue = (long)Math.Round(Math.Sqrt(1.0 - num5 * num5) * 100000.0 / 2.0 * (double)width / num);
	}

	private static int[] smethod_67(float width, float height, Class341[] domAdjustments)
	{
		double num = (float)domAdjustments[0].RawValue / 1000f * 216f / height * Math.Min(width, height) + 21600f;
		double num2 = (float)((domAdjustments[0].RawValue + domAdjustments[1].RawValue) / 2L / 1000L * 216L) / height * Math.Min(width, height);
		int[] array = new int[2];
		array[0] = (int)Math.Round(num - 2.0 * num2);
		array[1] = (int)Math.Round((double)array[0] + num2);
		return array;
	}

	private static void smethod_68(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		double num = Math.Min(width, height);
		adjustments[0].RawValue = (long)Math.Round((double)(2 * srcValues[1] - srcValues[0] - 21600) * 1000.0 / 216.0 * (double)height / num);
		adjustments[1].RawValue = (long)Math.Round((double)(2 * (srcValues[1] - srcValues[0])) * 1000.0 / 216.0 * (double)height / num) - adjustments[0].RawValue;
		double num2 = srcValues[2];
		double num3 = (Math.Sqrt(466560000.0 - num2 * num2) / 21600.0 + 1.0) * (double)(srcValues[0] + 21600 - srcValues[1]) / 2.0;
		double num4 = ((double)(srcValues[0] - srcValues[1]) + 21600.0) / 2.0;
		double num5 = (num4 - num3) / num4;
		adjustments[2].RawValue = (long)Math.Round(Math.Sqrt(1.0 - num5 * num5) * 100000.0 / 2.0 * (double)width / num);
	}

	private static int[] smethod_69(float width, float height, Class341[] domAdjustments)
	{
		double num = (float)domAdjustments[0].RawValue / 1000f * 216f / height * Math.Min(width, height) + 21600f;
		double num2 = (float)((domAdjustments[0].RawValue + domAdjustments[1].RawValue) / 2L / 1000L * 216L) / height * Math.Min(width, height);
		int[] array = new int[2];
		array[0] = (int)Math.Round(num - 2.0 * num2);
		array[1] = (int)Math.Round((double)array[0] + num2);
		return array;
	}

	private static void smethod_70(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		double num = Math.Min(width, height);
		adjustments[0].RawValue = (long)Math.Round((double)(2 * srcValues[1] - srcValues[0] - 21600) * 1000.0 / 216.0 * (double)width / num);
		adjustments[1].RawValue = (long)Math.Round((double)(2 * (srcValues[1] - srcValues[0])) * 1000.0 / 216.0 * (double)width / num) - adjustments[0].RawValue;
		double num2 = 21600 - srcValues[2];
		double num3 = (Math.Sqrt(466560000.0 - num2 * num2) / 21600.0 + 1.0) * (double)(srcValues[0] + 21600 - srcValues[1]) / 2.0;
		double num4 = ((double)(srcValues[0] - srcValues[1]) + 21600.0) / 2.0;
		double num5 = (num4 - num3) / num4;
		adjustments[2].RawValue = (long)Math.Round(Math.Sqrt(1.0 - num5 * num5) * 100000.0 / 2.0 * (double)height / num);
	}

	private static int[] smethod_71(float width, float height, Class341[] domAdjustments)
	{
		double num = (float)domAdjustments[0].RawValue / 1000f * 216f / height * Math.Min(width, height) + 21600f;
		double num2 = (float)((domAdjustments[0].RawValue + domAdjustments[1].RawValue) / 2L / 1000L * 216L) / width * Math.Min(width, height);
		int[] array = new int[2];
		array[0] = (int)Math.Round(num - 2.0 * num2);
		array[1] = (int)Math.Round((double)array[0] + num2);
		return array;
	}

	private static void smethod_72(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		double num = Math.Min(width, height);
		adjustments[0].RawValue = (long)Math.Round((double)(2 * srcValues[1] - srcValues[0] - 21600) * 1000.0 / 216.0 * (double)width / num);
		adjustments[1].RawValue = (long)Math.Round((double)(2 * (srcValues[1] - srcValues[0])) * 1000.0 / 216.0 * (double)width / num) - adjustments[0].RawValue;
		double num2 = srcValues[2];
		double num3 = (Math.Sqrt(466560000.0 - num2 * num2) / 21600.0 + 1.0) * (double)(srcValues[0] + 21600 - srcValues[1]) / 2.0;
		double num4 = ((double)(srcValues[0] - srcValues[1]) + 21600.0) / 2.0;
		double num5 = (num4 - num3) / num4;
		adjustments[2].RawValue = (long)Math.Round(Math.Sqrt(1.0 - num5 * num5) * 100000.0 / 2.0 * (double)height / num);
	}

	private static int[] smethod_73(float width, float height, Class341[] domAdjustments)
	{
		double num = (float)domAdjustments[0].RawValue / 1000f * 216f / height * Math.Min(width, height) + 21600f;
		double num2 = (float)((domAdjustments[0].RawValue + domAdjustments[1].RawValue) / 2L / 1000L * 216L) / width * Math.Min(width, height);
		int[] array = new int[2];
		array[0] = (int)Math.Round(num - 2.0 * num2);
		array[1] = (int)Math.Round((double)array[0] + num2);
		return array;
	}

	private static void smethod_74(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)srcValues[0] * 1000.0 / 216.0);
		adjustments[1].RawValue = (long)Math.Round((double)(srcValues[1] - 10800) * 1000.0 / 216.0);
	}

	private static int[] smethod_75(float width, float height, Class341[] domAdjustments)
	{
		return new int[2]
		{
			(int)Math.Round((float)domAdjustments[0].RawValue / 1000f * 216f),
			(int)Math.Round((float)domAdjustments[1].RawValue / 1000f * 216f + 10800f)
		};
	}

	private static void smethod_76(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)(10800 - srcValues[3]) * 2000.0 / 216.0 * (double)height / (double)Math.Min(height, width));
		adjustments[1].RawValue = (long)Math.Round((double)(10800 - srcValues[1]) * 1000.0 / 216.0 * (double)height / (double)Math.Min(height, width));
		adjustments[2].RawValue = (long)Math.Round((double)(21600 - srcValues[2]) * 1000.0 / 216.0 * (double)width / (double)Math.Min(height, width));
		adjustments[3].RawValue = (long)Math.Round((double)srcValues[0] * 1000.0 / 216.0);
	}

	private static int[] smethod_77(float width, float height, Class341[] domAdjustments)
	{
		return new int[4]
		{
			(int)Math.Round((float)domAdjustments[3].RawValue / 1000f * 216f),
			10800 - (int)Math.Round((float)domAdjustments[1].RawValue / 1000f * 216f / height * Math.Min(width, height)),
			21600 - (int)Math.Round((float)domAdjustments[2].RawValue / 1000f * 216f / width * Math.Min(width, height)),
			10800 - (int)Math.Round((float)domAdjustments[0].RawValue / 2000f * 216f / height * Math.Min(width, height))
		};
	}

	private static void smethod_78(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)(10800 - srcValues[3]) * 2000.0 / 216.0 * (double)height / (double)Math.Min(height, width));
		adjustments[1].RawValue = (long)Math.Round((double)(10800 - srcValues[1]) * 1000.0 / 216.0 * (double)height / (double)Math.Min(height, width));
		adjustments[2].RawValue = (long)Math.Round((double)srcValues[2] * 1000.0 / 216.0 * (double)width / (double)Math.Min(height, width));
		adjustments[3].RawValue = (long)Math.Round((double)(21600 - srcValues[0]) * 1000.0 / 216.0);
	}

	private static int[] smethod_79(float width, float height, Class341[] domAdjustments)
	{
		return new int[4]
		{
			21600 - (int)Math.Round((float)domAdjustments[3].RawValue / 1000f * 216f),
			10800 - (int)Math.Round((float)domAdjustments[1].RawValue / 1000f * 216f / height * Math.Min(width, height)),
			(int)Math.Round((float)domAdjustments[2].RawValue / 1000f * 216f / width * Math.Min(width, height)),
			10800 - (int)Math.Round((float)domAdjustments[0].RawValue / 2000f * 216f / height * Math.Min(width, height))
		};
	}

	private static void smethod_80(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)(10800 - srcValues[3]) * 2000.0 / 216.0 * (double)width / (double)Math.Min(height, width));
		adjustments[1].RawValue = (long)Math.Round((double)(10800 - srcValues[1]) * 1000.0 / 216.0 * (double)width / (double)Math.Min(height, width));
		adjustments[2].RawValue = (long)Math.Round((double)(21600 - srcValues[2]) * 1000.0 / 216.0 * (double)height / (double)Math.Min(height, width));
		adjustments[3].RawValue = (long)Math.Round((double)srcValues[0] * 1000.0 / 216.0);
	}

	private static int[] smethod_81(float width, float height, Class341[] domAdjustments)
	{
		return new int[4]
		{
			(int)Math.Round((float)domAdjustments[3].RawValue / 1000f * 216f),
			10800 - (int)Math.Round((float)domAdjustments[1].RawValue / 1000f * 216f / width * Math.Min(width, height)),
			21600 - (int)Math.Round((float)domAdjustments[2].RawValue / 1000f * 216f / height * Math.Min(width, height)),
			10800 - (int)Math.Round((float)domAdjustments[0].RawValue / 2000f * 216f / width * Math.Min(width, height))
		};
	}

	private static void smethod_82(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)(10800 - srcValues[3]) * 2000.0 / 216.0 * (double)width / (double)Math.Min(height, width));
		adjustments[1].RawValue = (long)Math.Round((double)(10800 - srcValues[1]) * 1000.0 / 216.0 * (double)width / (double)Math.Min(height, width));
		adjustments[2].RawValue = (long)Math.Round((double)srcValues[2] * 1000.0 / 216.0 * (double)height / (double)Math.Min(height, width));
		adjustments[3].RawValue = (long)Math.Round((double)(21600 - srcValues[0]) * 1000.0 / 216.0);
	}

	private static int[] smethod_83(float width, float height, Class341[] domAdjustments)
	{
		return new int[4]
		{
			21600 - (int)Math.Round((float)domAdjustments[3].RawValue / 1000f * 216f),
			10800 - (int)Math.Round((float)domAdjustments[1].RawValue / 1000f * 216f / width * Math.Min(width, height)),
			(int)Math.Round((float)domAdjustments[2].RawValue / 1000f * 216f / height * Math.Min(width, height)),
			10800 - (int)Math.Round((float)domAdjustments[0].RawValue / 2000f * 216f / width * Math.Min(width, height))
		};
	}

	private static void smethod_84(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)(10800 - srcValues[0]) * 1000.0 / 216.0);
	}

	private static int[] smethod_85(float width, float height, Class341[] domAdjustments)
	{
		return new int[1] { 10800 - (int)Math.Round((float)domAdjustments[0].RawValue / 1000f * 216f) };
	}

	private static void smethod_86(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = 19098L;
		adjustments[1].RawValue = 105146L;
		adjustments[2].RawValue = 110557L;
	}

	private static int[] smethod_87(float width, float height, Class341[] domAdjustments)
	{
		return new int[0];
	}

	private static void smethod_88(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)srcValues[0] * 1000.0 / 216.0);
		adjustments[1].RawValue = (long)Math.Round((double)srcValues[1] * 2000.0 / 216.0);
		adjustments[2].RawValue = (long)Math.Round((double)(21600 - srcValues[2]) * 1000.0 / 216.0);
	}

	private static int[] smethod_89(float width, float height, Class341[] domAdjustments)
	{
		return new int[3]
		{
			(int)Math.Round((float)domAdjustments[0].RawValue / 1000f * 216f),
			(int)Math.Round((float)domAdjustments[1].RawValue / 2000f * 216f),
			21600 - (int)Math.Round((float)domAdjustments[2].RawValue / 1000f * 216f)
		};
	}

	private static void smethod_90(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)srcValues[0] * 1000.0 / 216.0);
		adjustments[1].RawValue = (long)Math.Round((double)(21600 - srcValues[1]) * 2000.0 / 216.0);
		adjustments[2].RawValue = (long)Math.Round((double)srcValues[2] * 1000.0 / 216.0);
	}

	private static int[] smethod_91(float width, float height, Class341[] domAdjustments)
	{
		return new int[3]
		{
			(int)Math.Round((float)domAdjustments[0].RawValue / 1000f * 216f),
			21600 - (int)Math.Round((float)domAdjustments[1].RawValue / 2000f * 216f),
			(int)Math.Round((float)domAdjustments[2].RawValue / 1000f * 216f)
		};
	}

	private static void smethod_92(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)srcValues[1] * 1000.0 / 216.0);
		adjustments[1].RawValue = (long)Math.Round((double)(10800 - srcValues[0]) * 2000.0 / 216.0);
	}

	private static int[] smethod_93(float width, float height, Class341[] domAdjustments)
	{
		return new int[2]
		{
			10800 - (int)Math.Round((float)domAdjustments[1].RawValue / 2000f * 216f),
			(int)Math.Round((float)domAdjustments[0].RawValue / 1000f * 216f)
		};
	}

	private static void smethod_94(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)(21600 - srcValues[1]) * 1000.0 / 216.0);
		adjustments[1].RawValue = (long)Math.Round((double)(10800 - srcValues[0]) * 2000.0 / 216.0);
	}

	private static int[] smethod_95(float width, float height, Class341[] domAdjustments)
	{
		return new int[2]
		{
			10800 - (int)Math.Round((float)domAdjustments[1].RawValue / 2000f * 216f),
			21600 - (int)Math.Round((float)domAdjustments[0].RawValue / 1000f * 216f)
		};
	}

	private static void smethod_96(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)(srcValues[0] - 10800) * 1000.0 / 216.0);
		adjustments[1].RawValue = (long)Math.Round((double)(srcValues[1] - 10800) * 1000.0 / 216.0);
	}

	private static int[] smethod_97(float width, float height, Class341[] domAdjustments)
	{
		return new int[2]
		{
			(int)Math.Round((float)domAdjustments[0].RawValue / 1000f * 216f) + 10800,
			(int)Math.Round((float)domAdjustments[1].RawValue / 1000f * 216f) + 10800
		};
	}

	private static void smethod_98(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)(srcValues[0] - 10800) * 1000.0 / 216.0);
		adjustments[1].RawValue = (long)Math.Round((double)(srcValues[1] - 10800) * 1000.0 / 216.0);
		adjustments[2].RawValue = 16667L;
	}

	private static int[] smethod_99(float width, float height, Class341[] domAdjustments)
	{
		return new int[2]
		{
			(int)Math.Round((float)domAdjustments[0].RawValue / 1000f * 216f) + 10800,
			(int)Math.Round((float)domAdjustments[1].RawValue / 1000f * 216f) + 10800
		};
	}

	private static void smethod_100(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)srcValues[3] * 1000.0 / 216.0);
		adjustments[1].RawValue = (long)Math.Round((double)srcValues[2] * 1000.0 / 216.0);
		adjustments[2].RawValue = (long)Math.Round((double)srcValues[1] * 1000.0 / 216.0);
		adjustments[3].RawValue = (long)Math.Round((double)srcValues[0] * 1000.0 / 216.0);
	}

	private static int[] smethod_101(float width, float height, Class341[] domAdjustments)
	{
		int[] array = new int[4];
		for (int i = 0; i < 4; i++)
		{
			array[i] = (int)Math.Round((float)domAdjustments[3 - i].RawValue / 1000f * 216f);
		}
		return array;
	}

	private static void smethod_102(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)srcValues[5] * 1000.0 / 216.0);
		adjustments[1].RawValue = (long)Math.Round((double)srcValues[4] * 1000.0 / 216.0);
		adjustments[2].RawValue = (long)Math.Round((double)srcValues[3] * 1000.0 / 216.0);
		adjustments[3].RawValue = (long)Math.Round((double)srcValues[2] * 1000.0 / 216.0);
		adjustments[4].RawValue = (long)Math.Round((double)srcValues[1] * 1000.0 / 216.0);
		adjustments[5].RawValue = (long)Math.Round((double)srcValues[0] * 1000.0 / 216.0);
	}

	private static int[] smethod_103(float width, float height, Class341[] domAdjustments)
	{
		int[] array = new int[6];
		for (int i = 0; i < 6; i++)
		{
			array[i] = (int)Math.Round((float)domAdjustments[5 - i].RawValue / 1000f * 216f);
		}
		return array;
	}

	private static void smethod_104(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)srcValues[7] * 1000.0 / 216.0);
		adjustments[1].RawValue = (long)Math.Round((double)srcValues[6] * 1000.0 / 216.0);
		adjustments[2].RawValue = (long)Math.Round((double)srcValues[5] * 1000.0 / 216.0);
		adjustments[3].RawValue = (long)Math.Round((double)srcValues[4] * 1000.0 / 216.0);
		adjustments[4].RawValue = (long)Math.Round((double)srcValues[3] * 1000.0 / 216.0);
		adjustments[5].RawValue = (long)Math.Round((double)srcValues[2] * 1000.0 / 216.0);
		adjustments[6].RawValue = (long)Math.Round((double)srcValues[1] * 1000.0 / 216.0);
		adjustments[7].RawValue = (long)Math.Round((double)srcValues[0] * 1000.0 / 216.0);
	}

	private static int[] smethod_105(float width, float height, Class341[] domAdjustments)
	{
		int[] array = new int[8];
		for (int i = 0; i < 8; i++)
		{
			array[i] = (int)Math.Round((float)domAdjustments[7 - i].RawValue / 1000f * 216f);
		}
		return array;
	}

	private static void smethod_106(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)(10800 - srcValues[3]) * 2000.0 / 216.0 * (double)height / (double)Math.Min(height, width));
		adjustments[1].RawValue = (long)Math.Round((double)(10800 - srcValues[1]) * 1000.0 / 216.0 * (double)height / (double)Math.Min(height, width));
		adjustments[2].RawValue = (long)Math.Round((double)srcValues[2] * 1000.0 / 216.0 * (double)width / (double)Math.Min(height, width));
		adjustments[3].RawValue = (long)Math.Round((double)(10800 - srcValues[0]) * 2000.0 / 216.0);
	}

	private static int[] smethod_107(float width, float height, Class341[] domAdjustments)
	{
		return new int[4]
		{
			10800 - (int)Math.Round((float)domAdjustments[3].RawValue / 2000f * 216f),
			10800 - (int)Math.Round((float)domAdjustments[1].RawValue / 1000f * 216f / height * Math.Min(width, height)),
			(int)Math.Round((float)domAdjustments[2].RawValue / 1000f * 216f / width * Math.Min(width, height)),
			10800 - (int)Math.Round((float)domAdjustments[0].RawValue / 2000f * 216f / height * Math.Min(height, width))
		};
	}

	private static void smethod_108(float width, float height, Class341[] adjustments, int[] srcValues)
	{
		adjustments[0].RawValue = (long)Math.Round((double)(10800 - srcValues[3]) * 2000.0 / 216.0 * (double)width / (double)Math.Min(height, width));
		adjustments[1].RawValue = (long)Math.Round((double)(10800 - srcValues[1]) * 1000.0 / 216.0 * (double)width / (double)Math.Min(height, width));
		adjustments[2].RawValue = (long)Math.Round((double)srcValues[2] * 1000.0 / 216.0 * (double)height / (double)Math.Min(height, width));
		adjustments[3].RawValue = (long)Math.Round((double)(10800 - srcValues[0]) * 2000.0 / 216.0);
	}

	private static int[] smethod_109(float width, float height, Class341[] domAdjustments)
	{
		return new int[4]
		{
			10800 - (int)Math.Round((float)domAdjustments[3].RawValue / 2000f * 216f),
			10800 - (int)Math.Round((float)domAdjustments[1].RawValue / 1000f * 216f / width * Math.Min(width, height)),
			(int)Math.Round((float)domAdjustments[2].RawValue / 1000f * 216f / height * Math.Min(width, height)),
			10800 - (int)Math.Round((float)domAdjustments[0].RawValue / 2000f * 216f / width * Math.Min(width, height))
		};
	}
}
