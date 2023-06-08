using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[Guid("000D0C83-0000-0000-C000-000000000046")]
public enum tagVisUISpacingTypes
{
	[TypeLibVar(64)]
	visCtrlSpacingNONE = 0,
	[TypeLibVar(64)]
	visCtrlSpacingVARIABLE_BEFORE = 1,
	[TypeLibVar(64)]
	visCtrlSpacingVARIABLE_AFTER = 2,
	[TypeLibVar(64)]
	visCtrlSpacingFIXED_BEFORE = 4,
	[TypeLibVar(64)]
	visCtrlSpacingFIXED_AFTER = 8,
	[TypeLibVar(64)]
	visCtrlSpacingNEW_ROW = 16,
	[TypeLibVar(64)]
	visCtrlSpacingTB_NOTFIXED = 32,
	[TypeLibVar(64)]
	visCtrlSpacingPALETTERIGHT = 64,
	[TypeLibVar(64)]
	visCtrlSpacingNEW_ROW_PALETTERIGHT = 80
}
