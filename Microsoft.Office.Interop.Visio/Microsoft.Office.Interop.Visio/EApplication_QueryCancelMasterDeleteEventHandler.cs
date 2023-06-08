using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate bool EApplication_QueryCancelMasterDeleteEventHandler([In][MarshalAs(UnmanagedType.Interface)] Master Master);
