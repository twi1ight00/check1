using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EMasters_ShapeExitedTextEditEventHandler([In][MarshalAs(UnmanagedType.Interface)] Shape Shape);
