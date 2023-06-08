using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EDocuments_AfterReplaceShapesEventHandler([In][MarshalAs(UnmanagedType.Interface)] Selection sel);
