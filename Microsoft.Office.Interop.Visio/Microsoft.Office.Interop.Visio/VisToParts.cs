using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C21-0000-0000-C000-000000000046")]
public enum VisToParts
{
	visConnectToError = -1,
	visToNone = 0,
	visGuideX = 1,
	visGuideY = 2,
	visWholeShape = 3,
	visGuideIntersect = 4,
	visToAngle = 7,
	visConnectionPoint = 100,
	[TypeLibVar(64)]
	visConnectError = -1,
	[TypeLibVar(64)]
	visNone = 0
}
