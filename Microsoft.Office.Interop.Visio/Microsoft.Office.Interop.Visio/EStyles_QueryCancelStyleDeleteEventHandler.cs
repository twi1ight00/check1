using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate bool EStyles_QueryCancelStyleDeleteEventHandler([In][MarshalAs(UnmanagedType.Interface)] Style Style);
