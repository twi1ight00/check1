using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[Guid("000D0C36-0000-0000-C000-000000000046")]
public enum tagVisPaperSizes
{
	visPaperSizeUnknown = 0,
	visPaperSizeLetter = 1,
	visPaperSizeLegal = 5,
	visPaperSizeA3 = 8,
	visPaperSizeA4 = 9,
	visPaperSizeA5 = 11,
	visPaperSizeB4 = 12,
	visPaperSizeB5 = 13,
	visPaperSizeFolio = 14,
	visPaperSizeNote = 18,
	visPaperSizeC = 24,
	visPaperSizeD = 25,
	visPaperSizeE = 26
}
