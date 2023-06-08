using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[Guid("000D0C84-0000-0000-C000-000000000046")]
public enum VisUICtrlAtts
{
	[TypeLibVar(64)]
	visCtrlAlignmentLEFT = 1,
	[TypeLibVar(64)]
	visCtrlAlignmentCENTER = 2,
	[TypeLibVar(64)]
	visCtrlAlignmentRIGHT = 4,
	[TypeLibVar(64)]
	visCtrlAlignmentBOX = 128,
	[TypeLibVar(64)]
	visCtrlAlignmentLEFTBOX = 129,
	[TypeLibVar(64)]
	visCtrlAlignmentCENTERBOX = 130,
	[TypeLibVar(64)]
	visCtrlAlignmentRIGHTBOX = 132
}
