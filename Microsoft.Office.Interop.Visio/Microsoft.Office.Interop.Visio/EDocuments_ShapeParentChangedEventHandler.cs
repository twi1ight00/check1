using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EDocuments_ShapeParentChangedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Shape Shape);
