using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EDocuments_MasterChangedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Master Master);
