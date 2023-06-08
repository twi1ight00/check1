using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate bool EDocument_QueryCancelPageDeleteEventHandler([In][MarshalAs(UnmanagedType.Interface)] Page Page);
