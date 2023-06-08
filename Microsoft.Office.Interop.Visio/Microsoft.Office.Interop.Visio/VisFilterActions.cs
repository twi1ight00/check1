using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C4D-0000-0000-C000-000000000046")]
public enum VisFilterActions
{
	visFilterMouseMoveNoDrag,
	visFilterMouseMoveDragBegin,
	visFilterMouseMoveDragEnter,
	visFilterMouseMoveDragOver,
	visFilterMouseMoveDragLeave,
	visFilterMouseMoveDragDrop
}
