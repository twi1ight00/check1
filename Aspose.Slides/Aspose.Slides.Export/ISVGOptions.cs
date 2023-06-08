using System.Runtime.InteropServices;

namespace Aspose.Slides.Export;

[Guid("2d9c9a99-9c45-4331-a02a-b5bd688fd924")]
[ComVisible(true)]
public interface ISVGOptions : ISaveOptions
{
	bool VectorizeText { get; set; }

	int MetafileRasterizationDpi { get; set; }

	bool Disable3DText { get; set; }

	bool DisableGradientSplit { get; set; }

	bool DisableLineEndCropping { get; set; }

	int JpegQuality { get; set; }

	ISvgShapeFormattingController ShapeFormattingController { get; set; }

	ISaveOptions AsISaveOptions { get; }
}
