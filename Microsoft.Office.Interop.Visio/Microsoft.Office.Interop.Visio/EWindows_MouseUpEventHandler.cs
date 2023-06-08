using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EWindows_MouseUpEventHandler([In] int Button, [In] int KeyButtonState, [In] double x, [In] double y, [In][Out] ref bool CancelDefault);
