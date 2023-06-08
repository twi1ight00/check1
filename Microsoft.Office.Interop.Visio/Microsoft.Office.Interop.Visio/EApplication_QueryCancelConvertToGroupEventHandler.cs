using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate bool EApplication_QueryCancelConvertToGroupEventHandler([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);
