using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EMaster_BeforeShapeDeleteEventHandler([In][MarshalAs(UnmanagedType.Interface)] Shape Shape);
