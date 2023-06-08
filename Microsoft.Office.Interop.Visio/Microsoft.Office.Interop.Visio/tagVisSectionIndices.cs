using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Visio;

[TypeLibType(16)]
[Guid("000D0C04-0000-0000-C000-000000000046")]
public enum tagVisSectionIndices
{
	visSectionInval = 255,
	visSectionFirst = 0,
	visSectionLast = 252,
	visSectionNone = 255,
	visSectionObject = 1,
	[TypeLibVar(64)]
	visSectionMember = 2,
	visSectionCharacter = 3,
	visSectionParagraph = 4,
	visSectionTab = 5,
	visSectionScratch = 6,
	visSectionConnectionPts = 7,
	[TypeLibVar(64)]
	visSectionExport = 7,
	visSectionTextField = 8,
	visSectionControls = 9,
	visSectionFirstComponent = 10,
	visSectionLastComponent = 239,
	visSectionAction = 240,
	visSectionLayer = 241,
	visSectionUser = 242,
	visSectionProp = 243,
	visSectionHyperlink = 244,
	visSectionReviewer = 245,
	visSectionAnnotation = 246,
	visSectionSmartTag = 247,
	[TypeLibVar(64)]
	visSectionLastReal = 247,
	visSectionLineGradientStops = 248,
	visSectionFillGradientStops = 249
}
