using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EApplication_BeforePageDeleteEventHandler([In][MarshalAs(UnmanagedType.Interface)] Page Page);
