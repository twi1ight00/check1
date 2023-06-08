using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EApplication_EnterScopeEventHandler([In][MarshalAs(UnmanagedType.Interface)] Application app, [In] int nScopeID, [In][MarshalAs(UnmanagedType.BStr)] string bstrDescription);
