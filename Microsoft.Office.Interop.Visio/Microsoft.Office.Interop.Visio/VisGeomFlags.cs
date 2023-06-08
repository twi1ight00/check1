using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C31-0000-0000-C000-000000000046")]
public enum VisGeomFlags
{
	visGeomExcludeLastPoint = 1,
	visGeomWHPct = 0x10,
	visGeomXYLocal = 0x20
}
