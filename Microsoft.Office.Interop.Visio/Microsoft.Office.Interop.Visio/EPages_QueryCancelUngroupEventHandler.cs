using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate bool EPages_QueryCancelUngroupEventHandler([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);
