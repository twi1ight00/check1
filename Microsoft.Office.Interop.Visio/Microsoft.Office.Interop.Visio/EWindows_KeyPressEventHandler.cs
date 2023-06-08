using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EWindows_KeyPressEventHandler([In] int KeyAscii, [In][Out] ref bool CancelDefault);
