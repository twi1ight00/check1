using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EApplication_KeyUpEventHandler([In] int KeyCode, [In] int KeyButtonState, [In][Out] ref bool CancelDefault);
