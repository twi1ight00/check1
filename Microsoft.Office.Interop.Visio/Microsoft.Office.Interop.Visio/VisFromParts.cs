using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C20-0000-0000-C000-000000000046")]
public enum VisFromParts
{
	visConnectFromError = -1,
	visFromNone = 0,
	visLeftEdge = 1,
	visCenterEdge = 2,
	visRightEdge = 3,
	visBottomEdge = 4,
	visMiddleEdge = 5,
	visTopEdge = 6,
	visBeginX = 7,
	visBeginY = 8,
	visBegin = 9,
	visEndX = 10,
	visEndY = 11,
	visEnd = 12,
	visFromAngle = 13,
	visFromPin = 14,
	visControlPoint = 100
}
