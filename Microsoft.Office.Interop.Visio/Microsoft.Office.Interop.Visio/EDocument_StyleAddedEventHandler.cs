using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EDocument_StyleAddedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Style Style);
