using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void ECell_CellChangedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Cell Cell);
