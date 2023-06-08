using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate bool EMasters_QueryCancelSelectionDeleteEventHandler([In][MarshalAs(UnmanagedType.Interface)] Selection Selection);
