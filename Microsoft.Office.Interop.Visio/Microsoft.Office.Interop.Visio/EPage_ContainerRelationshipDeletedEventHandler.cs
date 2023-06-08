using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[ComVisible(false)]
[TypeLibType(16)]
public delegate void EPage_ContainerRelationshipDeletedEventHandler([In][MarshalAs(UnmanagedType.Interface)] RelatedShapePairEvent ShapePair);
