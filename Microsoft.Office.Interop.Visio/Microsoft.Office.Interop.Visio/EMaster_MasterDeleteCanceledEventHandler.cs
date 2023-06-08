using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EMaster_MasterDeleteCanceledEventHandler([In][MarshalAs(UnmanagedType.Interface)] Master Master);
