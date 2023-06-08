using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EPage_GroupCanceledEventHandler([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);
