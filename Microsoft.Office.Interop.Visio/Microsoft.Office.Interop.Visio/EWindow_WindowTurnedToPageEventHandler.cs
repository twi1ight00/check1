using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EWindow_WindowTurnedToPageEventHandler([In][MarshalAs(UnmanagedType.Interface)] Window Window);
