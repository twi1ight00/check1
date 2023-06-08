using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C89-0000-0000-C000-000000000046")]
[TypeLibType(16)]
public enum tagVisUIBarPosition
{
	visBarLeft,
	visBarTop,
	visBarRight,
	visBarBottom,
	visBarFloating,
	visBarPopup,
	visBarMenu
}
