using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[Guid("000D0C26-0000-0000-C000-000000000046")]
public enum tagVisScrollbarStates
{
	visScrollBarNeither = 0,
	visScrollBarHoriz = 1,
	visScrollBarVert = 4,
	visScrollBarBoth = 5
}
