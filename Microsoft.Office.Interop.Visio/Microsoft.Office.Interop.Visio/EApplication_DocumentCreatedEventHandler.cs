using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EApplication_DocumentCreatedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Document doc);
