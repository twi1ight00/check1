using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate bool EDocuments_QueryCancelStyleDeleteEventHandler([In][MarshalAs(UnmanagedType.Interface)] Style Style);
