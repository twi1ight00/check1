using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate bool EApplication_QueryCancelGroupEventHandler([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);
