using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate bool EWindows_OnKeystrokeMessageForAddonEventHandler([In][MarshalAs(UnmanagedType.Interface)] MSGWrap MSG);
