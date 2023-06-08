using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EApplication_BeforeSelectionDeleteEventHandler([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);
