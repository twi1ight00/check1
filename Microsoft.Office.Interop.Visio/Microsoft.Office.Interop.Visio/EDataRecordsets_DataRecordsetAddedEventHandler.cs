using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EDataRecordsets_DataRecordsetAddedEventHandler([In][MarshalAs(UnmanagedType.Interface)] DataRecordset DataRecordset);
