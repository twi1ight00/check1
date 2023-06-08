using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C56-0000-0000-C000-000000000046")]
public enum VisTypeSelectionTypes
{
	visTypeSelGroup = 1,
	visTypeSelShape = 2,
	visTypeSelGuide = 4,
	visTypeSelMetafile = 8,
	visTypeSelBitmap = 0x10,
	visTypeSelInk = 0x20,
	visTypeSelOLE = 0x40
}
