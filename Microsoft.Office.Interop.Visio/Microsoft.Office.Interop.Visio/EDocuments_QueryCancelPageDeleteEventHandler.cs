using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate bool EDocuments_QueryCancelPageDeleteEventHandler([In][MarshalAs(UnmanagedType.Interface)] Page Page);
