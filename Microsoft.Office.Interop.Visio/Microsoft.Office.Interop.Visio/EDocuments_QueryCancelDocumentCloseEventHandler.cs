using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate bool EDocuments_QueryCancelDocumentCloseEventHandler([In][MarshalAs(UnmanagedType.Interface)] Document doc);
