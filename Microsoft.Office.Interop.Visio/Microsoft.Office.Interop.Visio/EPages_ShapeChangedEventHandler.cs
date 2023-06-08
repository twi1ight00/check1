using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EPages_ShapeChangedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Shape Shape);
