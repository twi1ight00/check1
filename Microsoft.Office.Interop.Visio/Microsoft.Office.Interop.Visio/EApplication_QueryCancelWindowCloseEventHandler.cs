using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate bool EApplication_QueryCancelWindowCloseEventHandler([In][MarshalAs(UnmanagedType.Interface)] Window Window);
