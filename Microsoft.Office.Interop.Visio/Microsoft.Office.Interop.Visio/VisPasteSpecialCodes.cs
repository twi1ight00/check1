using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C38-0000-0000-C000-000000000046")]
public enum VisPasteSpecialCodes
{
	visPasteText = 1,
	visPasteBitmap = 2,
	visPasteMetafile = 3,
	visPasteOEMText = 7,
	visPasteDIB = 8,
	visPasteEMF = 14,
	visPasteOLEObject = 65536,
	visPasteRichText = 65537,
	visPasteHyperlink = 65538,
	visPasteURL = 65539,
	visPasteVisioShapes = 65540,
	visPasteVisioMasters = 65541,
	visPasteVisioText = 65542,
	visPasteVisioIcon = 65543,
	visPasteInk = 65544,
	visPasteVisioShapesXML = 65545,
	visPasteVisioMastersXML = 65546,
	visPasteVisioShapesWithoutDataLinks = 65548
}
