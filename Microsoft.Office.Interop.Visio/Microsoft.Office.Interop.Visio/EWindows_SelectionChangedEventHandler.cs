using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EWindows_SelectionChangedEventHandler([In][MarshalAs(UnmanagedType.Interface)] Window Window);
