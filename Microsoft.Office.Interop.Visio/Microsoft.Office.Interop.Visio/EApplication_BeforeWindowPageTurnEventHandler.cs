using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EApplication_BeforeWindowPageTurnEventHandler([In][MarshalAs(UnmanagedType.Interface)] Window Window);
