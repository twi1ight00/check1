using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate bool EWindow_OnKeystrokeMessageForAddonEventHandler([In][MarshalAs(UnmanagedType.Interface)] MSGWrap MSG);
