using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EApplication_UngroupCanceledEventHandler([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);
