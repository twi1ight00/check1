namespace Microsoft.Office.Interop.Visio;

public enum VisAutoLinkBehaviors
{
	visAutoLinkSelectedShapesOnly = 1,
	visAutoLinkGenericProgressBar = 2,
	visAutoLinkNoApplyDataGraphic = 4,
	visAutoLinkReplaceExistingLinks = 8,
	visAutoLinkDontReplaceExistingLinks = 0x10,
	visAutoLinkNullMatchesNoFormula = 0x20,
	visAutoLinkIncludeHiddenProps = 0x40
}
