using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EDataRecordsets_DataRecordsetChangedEventHandler([In][MarshalAs(UnmanagedType.Interface)] DataRecordsetChangedEvent DataRecordsetChanged);
