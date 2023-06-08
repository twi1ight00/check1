using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EDocuments_StyleAddedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Style Style);
