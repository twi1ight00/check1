using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C26-0000-0000-C000-000000000046")]
public enum VisScrollbarStates
{
	visScrollBarNeither = 0,
	visScrollBarHoriz = 1,
	visScrollBarVert = 4,
	visScrollBarBoth = 5
}
