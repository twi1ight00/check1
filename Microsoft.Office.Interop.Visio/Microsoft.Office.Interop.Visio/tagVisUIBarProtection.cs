using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[Guid("000D0C8A-0000-0000-C000-000000000046")]
public enum tagVisUIBarProtection
{
	visBarNoProtection = 0,
	visBarNoCustomize = 1,
	visBarNoResize = 2,
	visBarNoMove = 4,
	visBarNoChangeDock = 0x10,
	visBarNoVerticalDock = 0x20,
	visBarNoHorizontalDock = 0x40
}
