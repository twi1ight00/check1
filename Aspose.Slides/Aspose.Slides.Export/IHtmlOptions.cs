using System.Runtime.InteropServices;

namespace Aspose.Slides.Export;

[Guid("25f44504-eea1-4fc5-b20e-ebc8becb635d")]
[ComVisible(true)]
public interface IHtmlOptions : ISaveOptions
{
	IHtmlFormatter HtmlFormatter { get; set; }

	ISlideImageFormat SlideImageFormat { get; set; }

	byte JpegQuality { get; set; }

	ISaveOptions AsISaveOptions { get; }
}
