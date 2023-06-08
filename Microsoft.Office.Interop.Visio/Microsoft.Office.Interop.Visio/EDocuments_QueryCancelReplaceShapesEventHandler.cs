using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate bool EDocuments_QueryCancelReplaceShapesEventHandler([In][MarshalAs(UnmanagedType.Interface)] ReplaceShapesEvent replaceShapes);
