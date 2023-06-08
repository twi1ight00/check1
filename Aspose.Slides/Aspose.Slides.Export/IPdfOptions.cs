using System.Runtime.InteropServices;

namespace Aspose.Slides.Export;

[ComVisible(true)]
[Guid("42c93c3e-8e38-43d0-af5e-72af1701d0e3")]
public interface IPdfOptions : ISaveOptions
{
	PdfTextCompression TextCompression { get; set; }

	bool EmbedTrueTypeFontsForASCII { get; set; }

	string[] AdditionalCommonFontFamilies { get; set; }

	bool EmbedFullFonts { get; set; }

	byte JpegQuality { get; set; }

	PdfCompliance Compliance { get; set; }

	string Password { get; set; }

	bool SaveMetafilesAsPng { get; set; }

	float SufficientResolution { get; set; }

	ISaveOptions AsISaveOptions { get; }
}
