using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EApplication_NoEventsPendingEventHandler([In][MarshalAs(UnmanagedType.Interface)] Application app);
