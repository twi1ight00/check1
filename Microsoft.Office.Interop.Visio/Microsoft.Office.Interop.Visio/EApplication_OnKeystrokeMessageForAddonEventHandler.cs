using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate bool EApplication_OnKeystrokeMessageForAddonEventHandler([In][MarshalAs(UnmanagedType.Interface)] MSGWrap MSG);
