using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[Guid("000D0C06-0000-0000-C000-000000000046")]
public enum VisRowTags
{
	visTagDefault = 0,
	[TypeLibVar(64)]
	visTagBase = 130,
	[TypeLibVar(64)]
	visTagRowVoid = 180,
	[TypeLibVar(64)]
	visTagInvalid = -1,
	visTagComponent = 137,
	visTagMoveTo = 138,
	visTagLineTo = 139,
	visTagArcTo = 140,
	visTagInfiniteLine = 141,
	visTagEllipse = 143,
	visTagEllipticalArcTo = 144,
	visTagSplineBeg = 165,
	visTagSplineSpan = 166,
	visTagPolylineTo = 193,
	visTagNURBSTo = 195,
	visTagTab0 = 136,
	visTagTab2 = 150,
	visTagTab10 = 151,
	visTagTab60 = 181,
	visTagCnnctPt = 153,
	visTagCnnctNamed = 185,
	visTagCnnctPtABCD = 186,
	visTagCnnctNamedABCD = 187,
	visTagCtlPt = 162,
	visTagCtlPtTip = 170,
	visTagRelMoveTo = 238,
	visTagRelLineTo = 239,
	visTagRelEllipticalArcTo = 240,
	visTagRelCubBezTo = 236,
	visTagRelQuadBezTo = 237
}
