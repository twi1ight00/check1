using System;
using System.Runtime.InteropServices;
using ns12;

namespace Aspose.Slides.Export;

[ComVisible(true)]
[Guid("5c0c4aba-9234-48dd-afb3-3d5a56344e90")]
[ClassInterface(ClassInterfaceType.None)]
public class HtmlOptions : SaveOptions, ISaveOptions, IHtmlOptions
{
	private int int_0 = 85;

	private HtmlFormatter htmlFormatter_0;

	private SlideImageFormat slideImageFormat_0;

	private readonly ILinkEmbedController ilinkEmbedController_0;

	private static readonly HtmlFormatter htmlFormatter_1 = Aspose.Slides.Export.HtmlFormatter.CreateDocumentFormatter(null, showSlideTitle: true);

	private static readonly SlideImageFormat slideImageFormat_1 = Aspose.Slides.Export.SlideImageFormat.Svg(new SVGOptions());

	public IHtmlFormatter HtmlFormatter
	{
		get
		{
			return htmlFormatter_0;
		}
		set
		{
			htmlFormatter_0 = (HtmlFormatter)value;
		}
	}

	public ISlideImageFormat SlideImageFormat
	{
		get
		{
			return slideImageFormat_0;
		}
		set
		{
			slideImageFormat_0 = (SlideImageFormat)value;
		}
	}

	internal ILinkEmbedController LinkEmbedController => ilinkEmbedController_0;

	public byte JpegQuality
	{
		get
		{
			return (byte)int_0;
		}
		set
		{
			if (value < 0 || value > 100)
			{
				throw new ArgumentOutOfRangeException("value", "JpegQuality value must be between 0 and 100.");
			}
			int_0 = value;
		}
	}

	ISaveOptions IHtmlOptions.AsISaveOptions => this;

	public HtmlOptions(ILinkEmbedController linkEmbedController)
	{
		if (linkEmbedController == null)
		{
			linkEmbedController = Class2948.class2948_0;
		}
		ilinkEmbedController_0 = linkEmbedController;
	}

	public HtmlOptions()
		: this(null)
	{
	}

	internal HtmlFormatter method_0()
	{
		if (htmlFormatter_0 == null)
		{
			return htmlFormatter_1;
		}
		return htmlFormatter_0;
	}

	internal SlideImageFormat method_1()
	{
		if (slideImageFormat_0 == null)
		{
			return slideImageFormat_1;
		}
		return slideImageFormat_0;
	}
}
