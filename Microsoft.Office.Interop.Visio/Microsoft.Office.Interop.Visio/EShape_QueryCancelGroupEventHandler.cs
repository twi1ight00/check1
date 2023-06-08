using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate bool EShape_QueryCancelGroupEventHandler([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);
