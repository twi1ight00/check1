using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EDocument_BeforeStyleDeleteEventHandler([In][MarshalAs(UnmanagedType.Interface)] Style Style);
