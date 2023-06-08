using System;
using System.Text;
using x6c95d9cf46ff5f25;
using xf989f31a236ff98c;

namespace Aspose.Words.Saving;

public class HtmlSaveOptions : SaveOptions
{
	private readonly xcd1c64d43058619d xa93fd26e0d062c89 = new xcd1c64d43058619d();

	private SaveFormat xdeadbdaa7eaefd95;

	private bool xb052d6c156e95914 = true;

	private bool x44e08e1e3b512a35;

	private string x282240c41fd6d480 = string.Empty;

	private string xb21f9ec81fe60f6f = string.Empty;

	private string x8af14d27c27357e7 = string.Empty;

	private ICssSavingCallback x175316cf8f567afa;

	private bool x3c7a0acbe0f94ed5;

	private ExportHeadersFootersMode x0c1a4c0c654d9c55 = ExportHeadersFootersMode.PerSection;

	private bool xd4989c6e92af387a;

	private bool x35924913756fcc9e;

	private bool x70abcfa3b1a1e905;

	private CssStyleSheetType x40476c16106d0614;

	private HtmlElementSizeOutputMode x179b1c7be7c551e4;

	private bool x2d590f23780a9daf;

	private Encoding xcce637b6f486a407 = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

	private bool x347d5ce4f90c9df8;

	private bool x78a62b6c82dffcaf;

	private int x33b51cfe3d0be9f3;

	private string xba1cdd4ada350d5a = string.Empty;

	private string xf689fd2d1f22f8c7 = string.Empty;

	private DocumentSplitCriteria xb50ae65e95baf15a;

	private int x93aafd0f087296ca = 2;

	private IFontSavingCallback x832fcd20c0795a73;

	private IDocumentPartSavingCallback x55c89640bacd0565;

	private bool xcfbeca09e1c9f8be;

	private bool x7b12f8789765bb0c = true;

	private int xe3716328270c0218 = 3;

	private string x1d53704f4895e6d5 = "text/html";

	private bool xce303370c7ab5679;

	private bool xa374a83c6c37abcc;

	private bool x9e44a5089e11f806;

	public override SaveFormat SaveFormat
	{
		get
		{
			return xdeadbdaa7eaefd95;
		}
		set
		{
			x144c0b7717868eb8(value);
		}
	}

	internal override bool x49451109f9415aa0
	{
		get
		{
			if (SaveFormat == SaveFormat.Html)
			{
				return DocumentSplitCriteria != DocumentSplitCriteria.None;
			}
			return false;
		}
	}

	public bool AllowNegativeIndent
	{
		get
		{
			return xd4989c6e92af387a;
		}
		set
		{
			xd4989c6e92af387a = value;
		}
	}

	[Obsolete("Use AllowNegativeIndent")]
	public bool AllowNegativeLeftIndent
	{
		get
		{
			return xd4989c6e92af387a;
		}
		set
		{
			xd4989c6e92af387a = value;
		}
	}

	public string CssStyleSheetFileName
	{
		get
		{
			return x8af14d27c27357e7;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "CssStyleSheetFileName");
			x8af14d27c27357e7 = value;
		}
	}

	public CssStyleSheetType CssStyleSheetType
	{
		get
		{
			return x40476c16106d0614;
		}
		set
		{
			x40476c16106d0614 = value;
		}
	}

	public ICssSavingCallback CssSavingCallback
	{
		get
		{
			return x175316cf8f567afa;
		}
		set
		{
			x175316cf8f567afa = value;
		}
	}

	public DocumentSplitCriteria DocumentSplitCriteria
	{
		get
		{
			return xb50ae65e95baf15a;
		}
		set
		{
			xb50ae65e95baf15a = value;
		}
	}

	public int DocumentSplitHeadingLevel
	{
		get
		{
			return x93aafd0f087296ca;
		}
		set
		{
			x0d299f323d241756.x9f9950877f77fc71(value, 0, 9, "DocumentSplitHeadingLevel");
			x93aafd0f087296ca = value;
		}
	}

	public IDocumentPartSavingCallback DocumentPartSavingCallback
	{
		get
		{
			return x55c89640bacd0565;
		}
		set
		{
			x55c89640bacd0565 = value;
		}
	}

	public Encoding Encoding
	{
		get
		{
			return xcce637b6f486a407;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			xcce637b6f486a407 = value;
		}
	}

	public int EpubNavigationMapLevel
	{
		get
		{
			return xe3716328270c0218;
		}
		set
		{
			x0d299f323d241756.x9f9950877f77fc71(value, 0, 9, "EpubNavigationMapLevel");
			xe3716328270c0218 = value;
		}
	}

	public bool ExportDocumentProperties
	{
		get
		{
			return x70abcfa3b1a1e905;
		}
		set
		{
			x70abcfa3b1a1e905 = value;
		}
	}

	public bool ExportFontResources
	{
		get
		{
			return x78a62b6c82dffcaf;
		}
		set
		{
			x78a62b6c82dffcaf = value;
		}
	}

	[Obsolete("Use ExportHeadersFootersMode property")]
	public bool ExportHeadersFooters
	{
		get
		{
			return x0c1a4c0c654d9c55 == ExportHeadersFootersMode.PerSection;
		}
		set
		{
			x0c1a4c0c654d9c55 = (value ? ExportHeadersFootersMode.PerSection : ExportHeadersFootersMode.None);
		}
	}

	public ExportHeadersFootersMode ExportHeadersFootersMode
	{
		get
		{
			return x0c1a4c0c654d9c55;
		}
		set
		{
			x0c1a4c0c654d9c55 = value;
		}
	}

	public bool ExportImagesAsBase64
	{
		get
		{
			return xa93fd26e0d062c89.x5835d7994902857b;
		}
		set
		{
			xa93fd26e0d062c89.x5835d7994902857b = value;
		}
	}

	public bool ExportLanguageInformation
	{
		get
		{
			return x44e08e1e3b512a35;
		}
		set
		{
			x44e08e1e3b512a35 = value;
		}
	}

	public bool ExportMetafileAsRaster
	{
		get
		{
			return xa93fd26e0d062c89.x2de5889cbc39c38e;
		}
		set
		{
			xa93fd26e0d062c89.x2de5889cbc39c38e = value;
		}
	}

	public bool ExportPageSetup
	{
		get
		{
			return x2d590f23780a9daf;
		}
		set
		{
			x2d590f23780a9daf = value;
		}
	}

	public bool ExportRelativeFontSize
	{
		get
		{
			return x347d5ce4f90c9df8;
		}
		set
		{
			x347d5ce4f90c9df8 = value;
		}
	}

	public bool ExportTextInputFormFieldAsText
	{
		get
		{
			return x3c7a0acbe0f94ed5;
		}
		set
		{
			x3c7a0acbe0f94ed5 = value;
		}
	}

	public bool ExportTocPageNumbers
	{
		get
		{
			return xcfbeca09e1c9f8be;
		}
		set
		{
			xcfbeca09e1c9f8be = value;
		}
	}

	public bool ExportXhtmlTransitional
	{
		get
		{
			return x35924913756fcc9e;
		}
		set
		{
			x35924913756fcc9e = value;
		}
	}

	public int FontResourcesSubsettingSizeThreshold
	{
		get
		{
			return x33b51cfe3d0be9f3;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			x33b51cfe3d0be9f3 = value;
		}
	}

	public string FontsFolder
	{
		get
		{
			return xba1cdd4ada350d5a;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "FontsFolder");
			xba1cdd4ada350d5a = value;
		}
	}

	public string FontsFolderAlias
	{
		get
		{
			return xf689fd2d1f22f8c7;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "FontsFolderAlias");
			xf689fd2d1f22f8c7 = value;
		}
	}

	public IFontSavingCallback FontSavingCallback
	{
		get
		{
			return x832fcd20c0795a73;
		}
		set
		{
			x832fcd20c0795a73 = value;
		}
	}

	public string ImagesFolder
	{
		get
		{
			return x282240c41fd6d480;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "ImagesFolder");
			x282240c41fd6d480 = value;
		}
	}

	public string ImagesFolderAlias
	{
		get
		{
			return xb21f9ec81fe60f6f;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "ImagesFolderAlias");
			xb21f9ec81fe60f6f = value;
		}
	}

	public int ImageResolution
	{
		get
		{
			return xa93fd26e0d062c89.xfb7a4eb022a84f48;
		}
		set
		{
			x0d299f323d241756.x14b71bdc94c08892(value, "ImageResolution");
			xa93fd26e0d062c89.xfb7a4eb022a84f48 = value;
		}
	}

	public IImageSavingCallback ImageSavingCallback
	{
		get
		{
			return xa93fd26e0d062c89.x16f7934b184a9d0a;
		}
		set
		{
			xa93fd26e0d062c89.x16f7934b184a9d0a = value;
		}
	}

	public bool ScaleImageToShapeSize
	{
		get
		{
			return xa93fd26e0d062c89.x9411afdd2481f8e3;
		}
		set
		{
			xa93fd26e0d062c89.x9411afdd2481f8e3 = value;
		}
	}

	public HtmlElementSizeOutputMode TableWidthOutputMode
	{
		get
		{
			return x179b1c7be7c551e4;
		}
		set
		{
			x179b1c7be7c551e4 = value;
		}
	}

	internal bool xa0d41f9ce07d80f7
	{
		get
		{
			return xce303370c7ab5679;
		}
		set
		{
			xce303370c7ab5679 = value;
		}
	}

	internal bool x5e55119260398f2a
	{
		get
		{
			return xa374a83c6c37abcc;
		}
		set
		{
			xa374a83c6c37abcc = value;
		}
	}

	internal bool x259fc7094d171627
	{
		get
		{
			return xb052d6c156e95914;
		}
		set
		{
			xb052d6c156e95914 = value;
		}
	}

	internal bool x73268d8924ff940d
	{
		get
		{
			return x7b12f8789765bb0c;
		}
		set
		{
			x7b12f8789765bb0c = value;
		}
	}

	internal string xea0d040d38d75a91
	{
		get
		{
			return x1d53704f4895e6d5;
		}
		set
		{
			x1d53704f4895e6d5 = value;
		}
	}

	internal bool x4e3c1d16eaf20ef3
	{
		get
		{
			return x9e44a5089e11f806;
		}
		set
		{
			x9e44a5089e11f806 = value;
		}
	}

	internal xcd1c64d43058619d xcd1c64d43058619d => xa93fd26e0d062c89;

	public HtmlSaveOptions()
		: this(SaveFormat.Html)
	{
	}

	public HtmlSaveOptions(SaveFormat saveFormat)
	{
		xa93fd26e0d062c89.x2de5889cbc39c38e = true;
		xa93fd26e0d062c89.x9411afdd2481f8e3 = true;
		xa93fd26e0d062c89.xfb7a4eb022a84f48 = 96;
		xa93fd26e0d062c89.x5835d7994902857b = false;
		x144c0b7717868eb8(saveFormat);
		if (saveFormat == SaveFormat.Epub)
		{
			ExportHeadersFootersMode = ExportHeadersFootersMode.None;
			CssStyleSheetType = CssStyleSheetType.External;
			DocumentSplitCriteria = DocumentSplitCriteria.HeadingParagraph;
		}
	}

	internal static HtmlSaveOptions x18b62f13f9c822a8()
	{
		HtmlSaveOptions htmlSaveOptions = new HtmlSaveOptions();
		htmlSaveOptions.ExportImagesAsBase64 = true;
		htmlSaveOptions.CssStyleSheetType = CssStyleSheetType.Inline;
		htmlSaveOptions.ExportFontResources = false;
		return htmlSaveOptions;
	}

	private void x144c0b7717868eb8(SaveFormat xd003f66121eb36a0)
	{
		switch (xd003f66121eb36a0)
		{
		case SaveFormat.Html:
		case SaveFormat.Mhtml:
		case SaveFormat.Epub:
			xdeadbdaa7eaefd95 = xd003f66121eb36a0;
			break;
		default:
			throw new ArgumentException("An invalid SaveFormat for this options type was chosen.");
		}
	}

	internal HtmlSaveOptions x8b61531c8ea35b85()
	{
		return (HtmlSaveOptions)MemberwiseClone();
	}

	internal override void x392c33ba8e976198()
	{
		base.x392c33ba8e976198();
		x259fc7094d171627 = false;
		ExportXhtmlTransitional = true;
	}
}
