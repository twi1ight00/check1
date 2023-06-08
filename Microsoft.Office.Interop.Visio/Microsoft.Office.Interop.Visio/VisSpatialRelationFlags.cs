using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C28-0000-0000-C000-000000000046")]
public enum VisSpatialRelationFlags
{
	visSpatialIncludeGuides = 2,
	visSpatialFrontToBack = 4,
	visSpatialBackToFront = 8,
	visSpatialIncludeHidden = 0x10,
	visSpatialIgnoreVisible = 0x20,
	visSpatialIncludeDataGraphics = 0x40,
	visSpatialIncludeContainerShapes = 0x80
}
