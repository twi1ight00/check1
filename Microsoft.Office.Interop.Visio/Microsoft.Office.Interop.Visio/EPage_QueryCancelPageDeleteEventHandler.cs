using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate bool EPage_QueryCancelPageDeleteEventHandler([In][MarshalAs(UnmanagedType.Interface)] Page Page);
