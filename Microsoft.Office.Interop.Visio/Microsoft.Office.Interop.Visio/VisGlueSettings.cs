using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C34-0000-0000-C000-000000000046")]
public enum VisGlueSettings
{
	visGlueToNone = 0,
	visGlueToGuides = 1,
	visGlueToHandles = 2,
	visGlueToVertices = 4,
	visGlueToConnectionPoints = 8,
	visGlueToGeometry = 0x20,
	visGlueToDisabled = 0x8000
}
