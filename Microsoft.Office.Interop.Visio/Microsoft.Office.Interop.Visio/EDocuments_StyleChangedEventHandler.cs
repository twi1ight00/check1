using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EDocuments_StyleChangedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Style Style);
