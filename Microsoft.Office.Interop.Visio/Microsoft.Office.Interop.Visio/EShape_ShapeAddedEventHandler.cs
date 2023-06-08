using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EShape_ShapeAddedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Shape Shape);
