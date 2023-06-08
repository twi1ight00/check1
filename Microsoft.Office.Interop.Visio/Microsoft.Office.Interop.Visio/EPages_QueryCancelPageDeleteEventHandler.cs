using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate bool EPages_QueryCancelPageDeleteEventHandler([In][MarshalAs(UnmanagedType.Interface)] Page Page);
