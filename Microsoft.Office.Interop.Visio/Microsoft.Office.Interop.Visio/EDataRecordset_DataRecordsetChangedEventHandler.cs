using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EDataRecordset_DataRecordsetChangedEventHandler([In][MarshalAs(UnmanagedType.Interface)] DataRecordsetChangedEvent DataRecordsetChanged);
