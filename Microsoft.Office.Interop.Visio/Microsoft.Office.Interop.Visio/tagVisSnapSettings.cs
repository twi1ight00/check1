using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C32-0000-0000-C000-000000000046")]
[TypeLibType(16)]
public enum tagVisSnapSettings
{
	visSnapToNone = 0,
	visSnapToRulerSubdivisions = 1,
	visSnapToGrid = 2,
	visSnapToGuides = 4,
	visSnapToHandles = 8,
	visSnapToVertices = 0x10,
	visSnapToConnectionPoints = 0x20,
	visSnapToGeometry = 0x100,
	visSnapToAlignmentBox = 0x200,
	visSnapToExtensions = 0x400,
	visSnapToDisabled = 0x8000,
	visSnapToIntersections = 0x10000
}
