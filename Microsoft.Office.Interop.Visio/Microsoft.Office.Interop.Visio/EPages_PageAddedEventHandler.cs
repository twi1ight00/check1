using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EPages_PageAddedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Page Page);