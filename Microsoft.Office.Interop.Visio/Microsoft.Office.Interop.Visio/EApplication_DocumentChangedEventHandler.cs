using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EApplication_DocumentChangedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Document doc);
