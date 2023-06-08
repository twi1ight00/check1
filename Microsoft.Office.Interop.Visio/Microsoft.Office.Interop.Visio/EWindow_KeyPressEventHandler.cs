using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EWindow_KeyPressEventHandler([In] int KeyAscii, [In][Out] ref bool CancelDefault);
