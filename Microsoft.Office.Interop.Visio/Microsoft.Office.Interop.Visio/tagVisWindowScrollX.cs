using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[Guid("000D0C2B-0000-0000-C000-000000000046")]
public enum tagVisWindowScrollX
{
	visScrollNoneX = 9,
	visScrollLeft = 0,
	visScrollLeftPage = 2,
	visScrollRight = 1,
	visScrollRightPage = 3,
	visScrollToLeft = 6,
	visScrollToRight = 7
}
