using System.Drawing;
using System.Text;
using System.Xml;
using Aspose.Slides;
using Aspose.Slides.Theme;
using ns16;
using ns24;
using ns4;
using ns53;
using ns55;
using ns56;

namespace ns18;

internal class Class1196 : Class1190
{
	private const float float_0 = 504.8f;

	private const float float_1 = 123.6f;

	private static readonly string[][] string_0 = new string[6][]
	{
		new string[3]
		{
			"Evaluation only.",
			"Created with Aspose.Slides for .NET 4.0 15.1.0.0",
			"Copyright 2004-" + "2015.01.30".Substring(0, 4) + " Aspose Pty Ltd."
		},
		new string[3] { "Evaluation only.", "Created with Aspose.Slides.", "Copyright 2004-2011 Aspose Pty Ltd." },
		new string[3] { "Evaluation only.", "Created with Aspose.Slides.", "Copyright 2004-2010 Aspose Pty Ltd." },
		new string[3] { "Evaluation only.", "Created with Aspose.Slides.", "Copyright 2004-2009 Aspose Pty Ltd." },
		new string[3] { "Evaluation only.", "Created with Aspose.Slides.", "Copyright 2004-2008 Aspose Pty Ltd." },
		new string[3] { "Evaluation only.", "Created with Aspose.PowerPoint.", "Copyright 2004 Aspose Pty Ltd." }
	};

	internal static readonly string[] string_1 = smethod_1(string_0);

	internal void method_7(Slide slide)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "sld")
			{
				Class2312 @class = new Class2312(base.XmlPartReader);
				Class899.smethod_0(slide, @class.CSld, base.SlideDeserializationContext);
				Class931.smethod_2(slide.ThemeManager, @class.ClrMapOvr);
				Class992.smethod_0(slide.SlideShowTransition, @class.Transition, base.DeserializationContext);
				slide.Hidden = !@class.Show;
				method_8(slide);
				Class900.smethod_0(slide.ThemeManager, base.DeserializationContext);
				method_9(slide, @class);
			}
		}
		method_2();
	}

	private void method_8(Slide slide)
	{
		Class1347[] array = base.DeserializationContext.RelationshipsOfCurrentPartEntry.method_0(Class1242.class1338_0);
		if (array.Length > 0)
		{
			Class1199 @class = new Class1199(array[0].TargetPart, base.DeserializationContext);
			@class.method_5(slide);
		}
	}

	private void method_9(ISlide slide, Class2312 slideElementData)
	{
		Class302 pPTXUnsupportedProps = ((Slide)slide).PPTXUnsupportedProps;
		Class233 timelineDeserializationContext = new Class233(base.SlideDeserializationContext.DeserializationContext, base.SlideDeserializationContext.ShapeXmlIdToShape);
		if (slideElementData.Timing == null)
		{
			slideElementData.delegate2524_0();
		}
		pPTXUnsupportedProps.TimingElementData = slideElementData.Timing;
		Class1008.smethod_0(slide.Timeline, slideElementData.Timing, timelineDeserializationContext);
		pPTXUnsupportedProps.BuildListOfTiming = slideElementData.Timing.BldLst;
		pPTXUnsupportedProps.ExtensionListOfTiming = slideElementData.Timing.ExtLst;
		pPTXUnsupportedProps.ExtensionList = slideElementData.ExtLst;
		pPTXUnsupportedProps.ShowMasterShapes = slideElementData.ShowMasterSp;
		pPTXUnsupportedProps.ShowMasterPlaceholderAnimations = slideElementData.ShowMasterPhAnim;
	}

	internal void method_10(ISlide slide)
	{
		method_3();
		Class2312 @class = new Class2312();
		Class302 pPTXUnsupportedProps = ((Slide)slide).PPTXUnsupportedProps;
		base.SerializationContext.SlideToSlidePart.Add(slide, base.Part);
		method_6(slide.Shapes, base.SlideSerializationContext);
		if (@class.Timing == null)
		{
			@class.delegate2524_0();
		}
		Class234 timelineSerializationContext = new Class234(base.SlideSerializationContext.SerializationContext, base.SlideSerializationContext.ShapeToShapeXmlId);
		Class1008.smethod_2(slide.Timeline, slide.Shapes, @class.Timing, timelineSerializationContext);
		@class.Timing.delegate2410_0(pPTXUnsupportedProps.BuildListOfTiming);
		@class.Timing.delegate1535_0(pPTXUnsupportedProps.ExtensionListOfTiming);
		Class899.smethod_2(slide, @class.CSld, base.SlideSerializationContext);
		Class931.smethod_7(((BaseThemeManager)slide.ThemeManager).ColorMappingOverride, @class.delegate1327_0());
		Class992.smethod_1(slide.SlideShowTransition, @class.delegate21_0, base.SerializationContext);
		@class.Show = !slide.Hidden;
		@class.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		@class.ShowMasterSp = pPTXUnsupportedProps.ShowMasterShapes;
		@class.ShowMasterPhAnim = pPTXUnsupportedProps.ShowMasterPlaceholderAnimations;
		SizeF size = slide.Presentation.SlideSize.Size;
		smethod_0(@class.CSld.SpTree, size.Width, size.Height, "TextBox", base.SlideSerializationContext);
		@class.vmethod_4(null, base.XmlPartWriter, "sld");
		method_4();
	}

	public Class1196(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1196(Class1342 part, Class1346 serializationContext, IBaseSlide slide)
		: base(part, serializationContext, slide)
	{
	}

	private static void smethod_0(Class1995 groupShapeElementData, float width, float height, string name, Class1031 slideSerializationContext)
	{
		if (Class1179.smethod_1() == Enum179.const_0)
		{
			double x = (double)(width - 504.8f) / 2.0;
			double y = (double)(height - 123.6f) / 2.0;
			Class2014 @class = (Class2014)groupShapeElementData.delegate2773_0("sp").Object;
			@class.NvSpPr.CNvPr.Id = slideSerializationContext.method_0();
			@class.NvSpPr.CNvPr.Name = name;
			@class.NvSpPr.CNvSpPr.TxBox = true;
			@class.NvSpPr.CNvSpPr.delegate1627_0();
			@class.NvSpPr.CNvSpPr.SpLocks.NoSelect = true;
			@class.NvSpPr.CNvSpPr.SpLocks.NoRot = true;
			@class.NvSpPr.CNvSpPr.SpLocks.NoMove = true;
			@class.NvSpPr.CNvSpPr.SpLocks.NoGrp = true;
			@class.SpPr.delegate1795_0();
			@class.SpPr.Xfrm.delegate1576_0();
			@class.SpPr.Xfrm.Off.X = x;
			@class.SpPr.Xfrm.Off.Y = y;
			@class.SpPr.Xfrm.delegate1585_0();
			@class.SpPr.Xfrm.Ext.Cx = 504.8324409448819;
			@class.SpPr.Xfrm.Ext.Cy = 123.59527559055118;
			Class1908 class2 = (Class1908)@class.SpPr.delegate2773_2("prstGeom").Object;
			class2.Prst = ShapeType.Rectangle;
			class2.delegate1429_0();
			@class.SpPr.delegate2773_1("noFill");
			@class.delegate1705_0();
			@class.TxBody.BodyPr.Wrap = Enum314.const_1;
			@class.TxBody.BodyPr.RtlCol = NullableBool.False;
			@class.TxBody.BodyPr.Anchor = TextAnchorType.Center;
			@class.TxBody.BodyPr.AnchorCtr = NullableBool.True;
			@class.TxBody.BodyPr.delegate2773_1("spAutoFit");
			@class.TxBody.delegate1741_0();
			@class.TxBody.LstStyle.delegate1756_1();
			@class.TxBody.LstStyle.Lvl1pPr.Algn = Enum313.const_1;
			@class.TxBody.LstStyle.Lvl1pPr.delegate1762_0();
			((Class1966)@class.TxBody.LstStyle.Lvl1pPr.LnSpc.delegate2773_0("spcPct").Object).Val = 150f;
			@class.TxBody.LstStyle.Lvl1pPr.delegate1762_1();
			((Class1966)@class.TxBody.LstStyle.Lvl1pPr.SpcBef.delegate2773_0("spcPct").Object).Val = 0f;
			@class.TxBody.LstStyle.Lvl1pPr.delegate1762_2();
			((Class1966)@class.TxBody.LstStyle.Lvl1pPr.SpcAft.delegate2773_0("spcPct").Object).Val = 0f;
			@class.TxBody.LstStyle.Lvl1pPr.delegate1726_0();
			@class.TxBody.LstStyle.Lvl1pPr.DefRPr.Lang = "en-US";
			@class.TxBody.LstStyle.Lvl1pPr.DefRPr.Sz = 32f;
			@class.TxBody.LstStyle.Lvl1pPr.DefRPr.B = NullableBool.True;
			@class.TxBody.LstStyle.Lvl1pPr.DefRPr.Dirty = false;
			@class.TxBody.LstStyle.Lvl1pPr.DefRPr.Err = false;
			@class.TxBody.LstStyle.Lvl1pPr.DefRPr.NoProof = NullableBool.True;
			Class1924 class3 = (Class1924)@class.TxBody.LstStyle.Lvl1pPr.DefRPr.delegate2773_1("solidFill").Object;
			Class1907 class4 = (Class1907)class3.delegate2773_0("prstClr").Object;
			class4.Val = PresetColor.Red;
			((Class1901)class4.delegate2773_0("lumOff").Object).Val = 30f;
			((Class1901)class4.delegate2773_0("alpha").Object).Val = 40f;
			Class1833 class5 = (Class1833)@class.TxBody.LstStyle.Lvl1pPr.DefRPr.delegate2773_0("effectLst").Object;
			class5.delegate1537_0();
			class5.OuterShdw.BlurRad = 4.0;
			class5.OuterShdw.Dist = 3.0;
			class5.OuterShdw.Algn = RectangleAlignment.TopRight;
			class5.OuterShdw.RotWithShape = false;
			class4 = (Class1907)class5.OuterShdw.delegate2773_0("prstClr").Object;
			class4.Val = PresetColor.Black;
			((Class1901)class4.delegate2773_0("alpha").Object).Val = 80f;
			@class.TxBody.LstStyle.Lvl1pPr.DefRPr.delegate1735_0();
			@class.TxBody.LstStyle.Lvl1pPr.DefRPr.Latin.Typeface = "Calibri";
			@class.TxBody.LstStyle.Lvl1pPr.DefRPr.Latin.PitchFamily = 34;
			@class.TxBody.LstStyle.Lvl1pPr.DefRPr.Latin.Charset = 0;
			for (int i = 0; i < string_0[0].Length; i++)
			{
				string t = string_0[0][i];
				@class.TxBody.delegate1753_0();
				@class.TxBody.PList[i].delegate1756_0().Algn = Enum313.const_2;
				Class1354 class6 = (Class1354)@class.TxBody.PList[i].delegate2773_0("r").Object;
				class6.T = t;
			}
		}
	}

	private static string[] smethod_1(string[][] nags)
	{
		string[] array = new string[nags.Length];
		for (int i = 0; i < nags.Length; i++)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string[] array2 = nags[i];
			foreach (string value in array2)
			{
				stringBuilder.Append(value);
			}
			array[i] = stringBuilder.ToString();
		}
		return array;
	}
}
