using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C05-0000-0000-C000-000000000046")]
public enum VisRowIndices
{
	visRowInval = -1,
	visRowFirst = 0,
	visRowLast = -2,
	visRowNone = -1,
	visRowXFormOut = 1,
	[TypeLibVar(64)]
	visRowXFormIn = 1,
	visRowLine = 2,
	visRowFill = 3,
	visRowXForm1D = 4,
	visRowEvent = 5,
	visRowLayerMem = 6,
	[TypeLibVar(64)]
	visRowGuide = 7,
	visRowStyle = 8,
	visRowForeign = 9,
	visRowPage = 10,
	visRowText = 11,
	visRowTextXForm = 12,
	visRowAlign = 14,
	visRowLock = 15,
	visRowHelpCopyright = 16,
	[TypeLibVar(64)]
	visRowData123 = 16,
	visRowMisc = 17,
	visRowRulerGrid = 18,
	[TypeLibVar(64)]
	visRowHyperlink = 19,
	visRowDoc = 20,
	visRowImage = 21,
	visRowGroup = 22,
	visRowShapeLayout = 23,
	visRowPageLayout = 24,
	visRowPrintProperties = 25,
	visRowGradientProperties = 26,
	visRowQuickStyleProperties = 27,
	visRowOtherEffectProperties = 28,
	visRowBevelProperties = 29,
	visRow3DRotationProperties = 30,
	visRowThemeProperties = 31,
	visRowReplaceBehaviors = 32,
	visRowComponent = 0,
	visRowVertex = 1,
	[TypeLibVar(64)]
	visRowMember = 0,
	visRowCharacter = 0,
	visRowParagraph = 0,
	visRowTab = 0,
	visRowScratch = 0,
	visRowConnectionPts = 0,
	[TypeLibVar(64)]
	visRowExport = 0,
	visRowField = 0,
	visRowControl = 0,
	visRowAction = 0,
	visRowLayer = 0,
	visRowUser = 0,
	visRowProp = 0,
	visRow1stHyperlink = 0,
	[TypeLibVar(64)]
	visRowFormat = 0,
	visRowReviewer = 0,
	visRowAnnotation = 0,
	visRowSmartTag = 0,
	visRowGradientStop = 0
}
