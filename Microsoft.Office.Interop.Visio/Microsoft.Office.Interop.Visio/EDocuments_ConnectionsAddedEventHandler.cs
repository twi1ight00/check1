using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EDocuments_ConnectionsAddedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Connects Connects);
