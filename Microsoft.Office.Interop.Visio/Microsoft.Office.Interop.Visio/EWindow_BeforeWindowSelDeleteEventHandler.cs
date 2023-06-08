using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EWindow_BeforeWindowSelDeleteEventHandler([In][MarshalAs(UnmanagedType.Interface)] Window Window);
