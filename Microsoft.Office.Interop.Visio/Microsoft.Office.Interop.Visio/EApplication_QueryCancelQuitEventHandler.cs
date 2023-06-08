using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate bool EApplication_QueryCancelQuitEventHandler([In][MarshalAs(UnmanagedType.Interface)] Application app);
