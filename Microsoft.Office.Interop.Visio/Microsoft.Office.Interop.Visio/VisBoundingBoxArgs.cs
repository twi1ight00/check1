using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C22-0000-0000-C000-000000000046")]
public enum VisBoundingBoxArgs
{
	visBBoxUprightWH = 1,
	visBBoxUprightText = 2,
	visBBoxExtents = 4,
	visBBoxIncludeHidden = 0x10,
	visBBoxIgnoreVisible = 0x20,
	visBBoxIncludeDataGraphics = 0x40,
	visBBoxIncludeGuides = 0x1000,
	visBBoxDrawingCoords = 0x2000,
	visBBoxNoNonPrint = 0x4000
}
