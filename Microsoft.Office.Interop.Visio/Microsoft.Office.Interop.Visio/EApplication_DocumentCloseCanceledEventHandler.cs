using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EApplication_DocumentCloseCanceledEventHandler([In][MarshalAs(UnmanagedType.Interface)] Document doc);
