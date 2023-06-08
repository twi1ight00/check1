using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[Guid("000D0C27-0000-0000-C000-000000000046")]
public enum tagVisSpatialRelationCodes
{
	visSpatialOverlap = 1,
	visSpatialContain = 2,
	visSpatialContainedIn = 4,
	visSpatialTouching = 8
}
