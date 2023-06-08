using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EPages_ShapeLinkAddedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Shape Shape, [In] int DataRecordsetID, [In] int DataRowID);
