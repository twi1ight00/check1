using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EApplication_MarkerEventEventHandler([In][MarshalAs(UnmanagedType.Interface)] Application app, [In] int SequenceNum, [In][MarshalAs(UnmanagedType.BStr)] string ContextString);
