using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EApplication_StyleAddedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Style Style);
