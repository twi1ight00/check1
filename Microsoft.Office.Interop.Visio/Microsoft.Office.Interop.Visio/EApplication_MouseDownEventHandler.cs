using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EApplication_MouseDownEventHandler([In] int Button, [In] int KeyButtonState, [In] double x, [In] double y, [In][Out] ref bool CancelDefault);
