using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[ComVisible(false)]
public delegate void EDocuments_CalloutRelationshipDeletedEventHandler([In][MarshalAs(UnmanagedType.Interface)] RelatedShapePairEvent ShapePair);