using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EShape_ShapeExitedTextEditEventHandler([In][MarshalAs(UnmanagedType.Interface)] Shape Shape);
