using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EPage_SelectionDeleteCanceledEventHandler([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);
