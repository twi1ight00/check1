using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EWindows_WindowTurnedToPageEventHandler([In][MarshalAs(UnmanagedType.Interface)] Window Window);
