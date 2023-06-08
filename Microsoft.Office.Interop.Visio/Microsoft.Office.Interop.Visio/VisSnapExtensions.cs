using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C33-0000-0000-C000-000000000046")]
public enum VisSnapExtensions
{
	visSnapExtNone = 0,
	visSnapExtAlignmentBoxExtension = 1,
	visSnapExtCenterAxes = 2,
	visSnapExtCurveTangent = 4,
	visSnapExtEndpoint = 8,
	visSnapExtMidpoint = 0x10,
	visSnapExtLinearExtension = 0x20,
	visSnapExtCurveExtension = 0x40,
	visSnapExtEndpointPerpendicular = 0x80,
	visSnapExtMidpointPerpendicular = 0x100,
	visSnapExtEndpointHorizontal = 0x200,
	visSnapExtEndpointVertical = 0x400,
	visSnapExtEllipseCenter = 0x800,
	visSnapExtIsometricAngles = 0x1000
}
