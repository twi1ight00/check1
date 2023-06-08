using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C01-0000-0000-C000-000000000046")]
public enum VisWinTypes
{
	visWinOther = 0,
	visDrawing = 1,
	visStencil = 2,
	visSheet = 3,
	visIcon = 4,
	visApplication = 5,
	visAnchorBarBuiltIn = 6,
	visDockedStencilBuiltIn = 7,
	visDrawingAddon = 8,
	visStencilAddon = 9,
	visAnchorBarAddon = 10,
	visDockedStencilAddon = 11,
	visPageWin = 128,
	visPageGroupWin = 160,
	visMasterWin = 64,
	visMasterGroupWin = 96,
	visInvalWinID = -1,
	visWinIDCustProp = 1658,
	visWinIDPanZoom = 1653,
	visWinIDSizePos = 1670,
	visWinIDDrawingExplorer = 1721,
	visWinIDFormulaTracing = 1781,
	visWinIDStencilExplorer = 1796,
	visWinIDMasterExplorer = 1916,
	visWinIDShapeSearch = 1669,
	visWinIDExternalData = 2044,
	visWinIDValidationIssues = 2263
}
