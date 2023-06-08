using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C15-0000-0000-C000-000000000046")]
public enum VisDrawSplineFlags
{
	visSplinePeriodic = 1,
	visSplineDoCircles = 2,
	visSplineAbrupt = 4,
	visSpline1D = 8,
	visPolyline1D = 8,
	visPolyarcs = 256
}
