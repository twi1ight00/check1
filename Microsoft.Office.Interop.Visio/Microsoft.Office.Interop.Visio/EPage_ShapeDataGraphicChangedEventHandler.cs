using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EPage_ShapeDataGraphicChangedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Shape Shape);
