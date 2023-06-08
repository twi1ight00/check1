using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EDocuments_DocumentSavedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Document doc);
