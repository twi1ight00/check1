using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C3B-0000-0000-C000-000000000046")]
[TypeLibType(16)]
public enum tagVisZoomBehavior
{
	visZoomNone = 0,
	visZoomInPlaceContainer = 1,
	visZoomVisio = 2,
	visZoomVisioExact = 4
}
