using System.Runtime.CompilerServices;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using ns16;
using ns18;
using ns24;
using ns53;
using ns56;

namespace ns8;

internal class Class1073
{
	private Class2179 class2179_0;

	private readonly AutoShape autoShape_0;

	private uint uint_0;

	public TextFrame TextBody
	{
		get
		{
			return autoShape_0.TextFrameInternal;
		}
		set
		{
			autoShape_0.TextFrameInternal = value;
		}
	}

	public Class2168 PropertySet
	{
		get
		{
			if (class2179_0.PrSet == null)
			{
				class2179_0.delegate2236_0();
			}
			return class2179_0.PrSet;
		}
	}

	public string ConnectionId
	{
		get
		{
			return class2179_0.CxnId;
		}
		set
		{
			class2179_0.CxnId = value;
		}
	}

	public string ModelId
	{
		get
		{
			return class2179_0.ModelId;
		}
		set
		{
			class2179_0.ModelId = value;
		}
	}

	public Enum337 Type
	{
		get
		{
			return class2179_0.Type;
		}
		set
		{
			class2179_0.Type = value;
		}
	}

	public ShapeType ShapeType
	{
		get
		{
			return autoShape_0.ShapeType;
		}
		set
		{
			autoShape_0.ShapeType = value;
		}
	}

	public bool IsTextChanged_OldMode => ((ParagraphCollection)autoShape_0.TextFrameInternal.Paragraphs).Version_OldMode != uint_0;

	public Class1073(Class2179 ptElementData, SmartArt parent, Class1341 deserializationContext)
	{
		class2179_0 = ptElementData;
		autoShape_0 = new AutoShape(parent.Slide);
		autoShape_0.AddTextFrame(string.Empty);
		Class1002.smethod_0(autoShape_0.TextFrameInternal, ptElementData.T, deserializationContext);
		uint_0 = ((ParagraphCollection)autoShape_0.TextFrameInternal.Paragraphs).Version_OldMode;
		if (ptElementData.SpPr == null)
		{
			ptElementData.delegate1630_0();
		}
		Class956.smethod_0(autoShape_0, ptElementData.SpPr, deserializationContext);
		if (ptElementData.SpPr.Ln != null && autoShape_0.LineFormat.FillFormat.FillType == FillType.NotDefined)
		{
			autoShape_0.LineFormat.FillFormat.FillType = FillType.Solid;
		}
		if (class2179_0.ExtLst != null)
		{
			Class1880 @class = Class2472.smethod_2(class2179_0.ExtLst);
			if (@class != null)
			{
				Class964.smethod_0(autoShape_0, @class.HlinkClick, @class.HlinkHover, deserializationContext);
				autoShape_0.Hidden = @class.Hidden;
				autoShape_0.AlternativeText = @class.Descr;
				autoShape_0.Name = @class.Name;
			}
		}
	}

	public void method_0(SmartArtShape dest)
	{
		if (PropertySet.Style != null)
		{
			Class984.smethod_0(dest.AutoShapeInternal, class2179_0.PrSet.Style);
		}
		smethod_0(autoShape_0, dest.AutoShapeInternal);
		if (autoShape_0.fillFormat_0.FillType != FillType.NotDefined)
		{
			dest.AutoShapeInternal.fillFormat_0.method_0(autoShape_0.fillFormat_0);
		}
		if (autoShape_0.lineFormat_0.FillFormat.FillType != FillType.NotDefined)
		{
			dest.AutoShapeInternal.lineFormat_0.method_0(autoShape_0.lineFormat_0);
		}
		dest.AutoShapeInternal.threeDFormat_0.method_1(autoShape_0.threeDFormat_0);
		dest.AutoShapeInternal.effectFormat_0.method_0(autoShape_0.effectFormat_0);
	}

	public void method_1(SmartArtShape src)
	{
		smethod_0(src, autoShape_0);
		if (src.IsFillFormatChanged)
		{
			autoShape_0.fillFormat_0.method_0((FillFormat)src.FillFormat);
		}
		if (src.IsLineFillFormatChanged)
		{
			autoShape_0.lineFormat_0.method_0((LineFormat)src.LineFormat);
		}
		if (src.IsThreeDFormatChanged)
		{
			autoShape_0.threeDFormat_0.method_1((ThreeDFormat)src.ThreeDFormat);
		}
		if (src.IsEffectFormatChanged)
		{
			autoShape_0.effectFormat_0.method_0((EffectFormat)src.EffectFormat);
		}
	}

	public void method_2(AutoShape drawingXmlShape, AutoShape renderingShape)
	{
		if (autoShape_0.fillFormat_0.FillType == FillType.NotDefined)
		{
			renderingShape.fillFormat_0.method_0(drawingXmlShape.fillFormat_0);
		}
		if (autoShape_0.lineFormat_0.FillFormat.FillType != FillType.NotDefined)
		{
			renderingShape.lineFormat_0.method_0(drawingXmlShape.lineFormat_0);
		}
	}

	public void method_3(Class1346 serializationContext)
	{
		class2179_0.delegate1707_0(new Class1946());
		if (autoShape_0.TextFrameInternal.Text != string.Empty)
		{
			class2179_0.PrSet.Phldr = NullableBool.NotDefined;
		}
		Class1002.smethod_2(autoShape_0.TextFrameInternal, class2179_0.T, serializationContext);
		class2179_0.SpPr.Geometry = null;
		if (autoShape_0.ShapeType != ShapeType.NotDefined && autoShape_0.ShapeType != 0)
		{
			Class954.smethod_5(autoShape_0, class2179_0.SpPr);
		}
		class2179_0.SpPr.FillProperties = null;
		if (autoShape_0.FillFormat.FillType != FillType.NotDefined)
		{
			Class949.smethod_1(autoShape_0.FillFormat, class2179_0.SpPr.delegate2773_1, serializationContext);
		}
		class2179_0.SpPr.delegate1506_0(null);
		if (!autoShape_0.LineFormat.IsFormatNotDefined)
		{
			Class968.smethod_2(autoShape_0.LineFormat, class2179_0.SpPr.delegate1504_0);
		}
		class2179_0.SpPr.EffectProperties = null;
		if (!autoShape_0.EffectFormat.IsNoEffects)
		{
			Class939.smethod_1(autoShape_0.EffectFormat, class2179_0.SpPr.delegate2773_0, serializationContext);
		}
		class2179_0.SpPr.delegate1626_0(null);
		class2179_0.SpPr.delegate1617_0(null);
		if (autoShape_0.threeDFormat_0.method_0(shape3d: true))
		{
			Class1007.smethod_1(autoShape_0.threeDFormat_0, class2179_0.SpPr.delegate1615_0, class2179_0.SpPr.delegate1624_0, null);
		}
		if (method_4())
		{
			if (class2179_0.ExtLst == null)
			{
				class2179_0.delegate1534_0();
			}
			Class1880 @class = new Class1880();
			@class.Name = autoShape_0.Name;
			@class.Descr = autoShape_0.AlternativeText;
			@class.Hidden = autoShape_0.Hidden;
			if (autoShape_0.HyperlinkClick != null)
			{
				@class.delegate1474_0();
				smethod_1(autoShape_0.HyperlinkClick, @class.HlinkClick, serializationContext);
			}
			if (autoShape_0.HyperlinkMouseOver != null)
			{
				@class.delegate1474_1();
				smethod_1(autoShape_0.HyperlinkMouseOver, @class.HlinkHover, serializationContext);
			}
			Class2472.smethod_3(class2179_0.ExtLst, @class);
		}
		else
		{
			class2179_0.delegate1535_0(null);
		}
	}

	public override string ToString()
	{
		return ModelId;
	}

	private bool method_4()
	{
		if (string.IsNullOrEmpty(autoShape_0.Name) && string.IsNullOrEmpty(autoShape_0.AlternativeText) && autoShape_0.HyperlinkClick == null && autoShape_0.HyperlinkMouseOver == null)
		{
			return false;
		}
		return true;
	}

	private static void smethod_0(IShape src, IShape dest)
	{
		dest.Hidden = src.Hidden;
		dest.AlternativeText = src.AlternativeText;
		dest.Name = src.Name;
		dest.HyperlinkClick = src.HyperlinkClick;
		dest.HyperlinkMouseOver = src.HyperlinkMouseOver;
	}

	private static void smethod_1(IHyperlink hyperlink, Class1865 hyperlinkElementData, Class1346 serializationContext)
	{
		Class343 pPTXUnsupportedProps = ((Hyperlink)hyperlink).PPTXUnsupportedProps;
		if (hyperlink.ExternalUrl != null)
		{
			hyperlinkElementData.R_Id = serializationContext.RelationshipsOfCurrentPartEntry.method_6("http://schemas.openxmlformats.org/officeDocument/2006/relationships/hyperlink", hyperlink.ExternalUrl, Enum180.const_2).Id;
		}
		else if (hyperlink.TargetSlide != null)
		{
			if (hyperlink.TargetSlide.Presentation == serializationContext.Presentation && serializationContext.Mode != Enum167.const_2)
			{
				hyperlinkElementData.R_Id = serializationContext.RelationshipsOfCurrentPartEntry.method_6("http://schemas.openxmlformats.org/officeDocument/2006/relationships/slide", serializationContext.SlideToSlidePartPath[hyperlink.TargetSlide], Enum180.const_1).Id;
			}
			else
			{
				hyperlinkElementData.Action = "ppaction://noaction";
			}
		}
		else if (pPTXUnsupportedProps.InternalUrl != null)
		{
			hyperlinkElementData.R_Id = serializationContext.RelationshipsOfCurrentPartEntry.method_6("http://schemas.openxmlformats.org/officeDocument/2006/relationships/hyperlink", pPTXUnsupportedProps.InternalUrl, Enum180.const_1).Id;
		}
	}

	[SpecialName]
	public static Class2179 smethod_2(Class1073 point)
	{
		return point.class2179_0;
	}
}
