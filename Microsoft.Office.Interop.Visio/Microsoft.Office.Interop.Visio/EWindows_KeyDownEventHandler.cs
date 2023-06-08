using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EWindows_KeyDownEventHandler([In] int KeyCode, [In] int KeyButtonState, [In][Out] ref bool CancelDefault);
