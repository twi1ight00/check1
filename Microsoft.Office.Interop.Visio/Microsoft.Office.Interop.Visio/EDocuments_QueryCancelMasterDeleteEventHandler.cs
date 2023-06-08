using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate bool EDocuments_QueryCancelMasterDeleteEventHandler([In][MarshalAs(UnmanagedType.Interface)] Master Master);
