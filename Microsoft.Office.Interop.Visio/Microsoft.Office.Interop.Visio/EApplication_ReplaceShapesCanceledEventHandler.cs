using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EApplication_ReplaceShapesCanceledEventHandler([In][MarshalAs(UnmanagedType.Interface)] ReplaceShapesEvent replaceShapes);
