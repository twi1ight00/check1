using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void ERow_FormulaChangedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Cell Cell);
