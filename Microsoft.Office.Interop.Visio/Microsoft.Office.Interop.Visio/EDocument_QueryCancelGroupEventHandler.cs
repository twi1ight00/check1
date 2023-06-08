using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate bool EDocument_QueryCancelGroupEventHandler([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);
