using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EMasters_ConnectionsAddedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Connects Connects);
