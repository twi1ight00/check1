using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EApplication_ShapeDataGraphicChangedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Shape Shape);
