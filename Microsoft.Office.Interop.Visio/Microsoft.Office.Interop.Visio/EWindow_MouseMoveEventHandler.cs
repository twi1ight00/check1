using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EWindow_MouseMoveEventHandler([In] int Button, [In] int KeyButtonState, [In] double x, [In] double y, [In][Out] ref bool CancelDefault);
