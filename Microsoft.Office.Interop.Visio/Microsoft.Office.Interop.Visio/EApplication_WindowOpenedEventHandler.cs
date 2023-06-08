using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EApplication_WindowOpenedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Window Window);
