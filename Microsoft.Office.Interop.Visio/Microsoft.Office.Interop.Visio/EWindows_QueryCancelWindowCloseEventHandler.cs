using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate bool EWindows_QueryCancelWindowCloseEventHandler([In][MarshalAs(UnmanagedType.Interface)] Window Window);
