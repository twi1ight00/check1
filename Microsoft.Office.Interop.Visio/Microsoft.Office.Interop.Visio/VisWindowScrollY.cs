using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C2C-0000-0000-C000-000000000046")]
public enum VisWindowScrollY
{
	visScrollNoneY = 9,
	visScrollUp = 0,
	visScrollUpPage = 2,
	visScrollDown = 1,
	visScrollDownPage = 3,
	visScrollToTop = 6,
	visScrollToBottom = 7
}
