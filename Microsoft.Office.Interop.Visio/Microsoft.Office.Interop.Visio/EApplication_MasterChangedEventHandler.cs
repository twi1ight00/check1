using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EApplication_MasterChangedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Master Master);
