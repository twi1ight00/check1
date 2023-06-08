using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EStyle_StyleDeleteCanceledEventHandler([In][MarshalAs(UnmanagedType.Interface)] Style Style);
